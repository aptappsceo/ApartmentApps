using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using DbQuery = Korzh.EasyQuery.Db.DbQuery;

namespace ApartmentApps.Modules.Payments
{
    public class PaymentsRequestsService : StandardCrudService<UserLeaseInfo>
    {

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public PropertyContext Context { get; set; }

        public PaymentsRequestsService(PropertyContext propertyContext, IRepository<UserLeaseInfo> repository, IBlobStorageService blobStorageService, IUserContext userContext, IKernel kernel) : base(kernel, repository)
        {
            Context = propertyContext;
        }



#region Queries
        //((int)LeaseState.Active).ToString()
        public DbQuery Active()
        {
            return this.CreateQuery("Submitted", new ConditionItem("UserLeaseInfo.State", "Equal", ((int)LeaseState.Active).ToString() ));
        }

        public DbQuery Archived()
        {
            return this.CreateQuery("Archived", new ConditionItem("UserLeaseInfo.State", "Equal", ((int)LeaseState.Archived).ToString()));
        }

#endregion


    }

    public class InvoicesService : StandardCrudService<Invoice>
    {

        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public PropertyContext Context { get; set; }

        public InvoicesService(PropertyContext propertyContext, IRepository<Invoice> repository, IBlobStorageService blobStorageService, IUserContext userContext, IKernel kernel) : base(kernel, repository)
        {
            Context = propertyContext;
        }



#region Queries


#endregion


    }


    public class PaymentsRequestsEditMapper : BaseMapper<UserLeaseInfo, EditUserLeaseInfoBindingModel>
    {
        public PropertyContext Context { get; set; }
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public PaymentsRequestsEditMapper(IUserContext userContext, PropertyContext context, IMapper<ApplicationUser, UserBindingModel> userMapper ) : base(userContext)
        {
            Context = context;
            UserMapper = userMapper;
        }

        public override void ToModel(EditUserLeaseInfoBindingModel viewModel, UserLeaseInfo model)
        {
            throw new NotImplementedException();
            
        }

        public override void ToViewModel(UserLeaseInfo model, EditUserLeaseInfoBindingModel viewModel)
        {
            viewModel.Id = model?.Id.ToString();
            viewModel.Amount = model?.Amount ?? 0;
            viewModel.NextInvoiceDate = model?.NextInvoiceDate;
            viewModel.CompleteDate = model?.RepetitionCompleteDate;
            viewModel.Title = model?.Title;
            viewModel.UserId = model?.User?.Id;
            viewModel.IntervalMonths = model?.IntervalMonths;
            viewModel.UseInterval = model?.IsIntervalSet() ?? false;
            viewModel.UseCompleteDate = model?.RepetitionCompleteDate.HasValue ?? false;
            viewModel.UserIdItems =
                Context.Users.GetAll()
                    .Where(u => !u.Archived)
                    .ToList()
                    .Select(u => UserMapper.ToViewModel(u))
                    .Where(u => !string.IsNullOrWhiteSpace(u.FullName))
                    .ToList();
        }
    }

    public class PaymentsRequestsInvoiceMapper : BaseMapper<Invoice, PaymentRequestInvoiceViewModel>
    {
        public PaymentsRequestsInvoiceMapper(IUserContext userContext) : base(userContext)
        {
        }

        public override void ToModel(PaymentRequestInvoiceViewModel viewModel, Invoice model)
        {
        }

        public override void ToViewModel(Invoice invoice, PaymentRequestInvoiceViewModel viewModel)
        {

            viewModel.Id = invoice.Id.ToString();
            viewModel.Amount = invoice.Amount;
            viewModel.Title = invoice.Title;
            viewModel.DueDate = invoice.DueDate;
            viewModel.AvailableDate = invoice.AvailableDate;
            viewModel.State = invoice.State;

            

            var tzNow = invoice.UserLeaseInfo.User.Property.TimeZone.Now();
            if(tzNow > invoice.DueDate) viewModel.UrgencyState = InvoiceUrgencyState.Urgent;
            else if(tzNow > invoice.AvailableDate) viewModel.UrgencyState = InvoiceUrgencyState.Available;
            else viewModel.UrgencyState = InvoiceUrgencyState.Upcoming;
            
        }
    }

    public class PaymentsRequestsMapper : BaseMapper<UserLeaseInfo, UserLeaseInfoBindingModel>
    {
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }
        public IMapper<Invoice, PaymentRequestInvoiceViewModel> InvoiceMapper { get; set; }
        public IBlobStorageService BlobStorageService { get; set; }

        public PaymentsRequestsMapper(IMapper<ApplicationUser, UserBindingModel> userMapper, IMapper<Invoice, PaymentRequestInvoiceViewModel> invoiceMapper,
            IBlobStorageService blobStorageService, IRepository<Invoice> invoices, IUserContext userContext) : base(userContext)
        {
            UserMapper = userMapper;
            BlobStorageService = blobStorageService;
            Invoices = invoices;
            InvoiceMapper = invoiceMapper;
        }

        public IRepository<Invoice> Invoices { get; set; }

        public override void ToModel(UserLeaseInfoBindingModel viewModel, UserLeaseInfo model)
        {

        }

        public override void ToViewModel(UserLeaseInfo lease, UserLeaseInfoBindingModel viewModel)
        {

            viewModel.Amount = lease.Amount;
            viewModel.Title = lease.Title;
            viewModel.User = UserMapper.ToViewModel(lease.User);
            viewModel.CreateDate = lease.CreateDate;
            viewModel.NextInvoiceDate = lease.NextInvoiceDate;
            viewModel.Id = lease.Id.ToString();
            viewModel.RepetitionCompleteDate = lease.RepetitionCompleteDate;
            viewModel.IntervalDays = lease.IntervalDays;
            viewModel.IntervalMonths = lease.IntervalMonths;
            viewModel.IntervalYears = lease.IntervalYears;
            viewModel.State = lease.State;
            viewModel.UsesInterval = lease.IsIntervalSet();
                viewModel.UsesCompleteDate = lease.RepetitionCompleteDate.HasValue;
            viewModel.Invoices =
                Invoices.Where(s => s.UserLeaseInfoId == lease.Id).ToArray().Select(s => InvoiceMapper.ToViewModel(s)).ToList();

        }

    }
}
