using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Modules.Payments;
using ApartmentApps.Modules.Payments.Services;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    [Authorize]
    public class PaymentRequestsController :
        AutoGridController
        <PaymentsRequestsService, PaymentsRequestsService, UserLeaseInfoBindingModel, EditUserLeaseInfoBindingModel>
    {

        public PaymentsRequestsService PaymentsRequestsService { get; set; }
        private readonly IMapper<ApplicationUser, UserLookupBindingModel> _userLookupMapper;
        private IMapper<UserLeaseInfo, EditUserLeaseInfoBindingModel> _editPaymentRequestMapper;
        private LeaseInfoManagementService _leaseService;
        private IMapper<ApplicationUser, UserLookupBindingModel> _userMapper;
        public PaymentRequestsController(IMapper<ApplicationUser,UserLookupBindingModel> userLookupMapper, IKernel kernel, PaymentsRequestsService formService, PaymentsRequestsService indexService, PropertyContext context, IUserContext userContext, PaymentsRequestsService service, IMapper<UserLeaseInfo, EditUserLeaseInfoBindingModel> editPaymentRequestMapper, LeaseInfoManagementService leaseService, IMapper<ApplicationUser, UserLookupBindingModel> userMapper) : base(kernel, formService, indexService, context, userContext, service)
        {
            PaymentsRequestsService = formService;
            _userLookupMapper = userLookupMapper;
            _editPaymentRequestMapper = editPaymentRequestMapper;
            _leaseService = leaseService;
            _userMapper = userMapper;
        }

        public override ActionResult GridResult(GridList<UserLeaseInfoBindingModel> grid)
        {
            if (Request != null && Request.IsAjaxRequest())
            {
                return View("OverviewListPartial", grid);
            }
            return View("Overview", new PaymentsRequestOverviewViewModel()
            {
                FeedItems = grid
            });
        }

        public override ActionResult Entry(string id = null)
        {
            
            UserLeaseInfo paymentRequest = Repository<UserLeaseInfo>().Find(id);
            EditUserLeaseInfoBindingModel editPaymentRequestModel = 
                _editPaymentRequestMapper.ToViewModel(paymentRequest); //for null paymentRequest will return empty but prepared EditModel ready for Creation of Payment Request
            return AutoForm(editPaymentRequestModel, nameof(SaveEntry), paymentRequest == null ? "Create Payment Request" : "Edit Payment Request Information");
            //return View("EditUserLeaseInfo", new EditUserLeaseInfoBindingModel());
        }

        [HttpGet]
        public ActionResult QuickAddRent(string userId = null)
        {
            return AutoForm(new QuickAddRentBindingModel()
            {
                Title = "Quick add rent",
                Id = null,
                UserIdItems = Repository<ApplicationUser>().ToArray().Select(s=>_userLookupMapper.ToViewModel(s)).ToList(),
                UserId = userId,
            }, nameof(QuickAddRent), "Quickly add rent subscription to user");
        }

        [HttpPost]
        public ActionResult QuickAddRent(QuickAddRentBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var invoiceDate = model.NextInvoiceDate.Value;
                _leaseService.CreateUserLeaseInfo(new CreateUserLeaseInfoBindingModel()
                {
                    Amount = model.Amount,
                    IntervalMonths = 1,
                    Title = $"Rent from {invoiceDate.ToString("d")}",
                    RepetitionCompleteDate = null,
                    UserId = model.UserId,
                    UseCompleteDate = false,
                    UseInterval = true,
                    InvoiceDate = invoiceDate, //not null due to validation
                });

                if (Request  != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                model.UserIdItems =
                    Repository<ApplicationUser>().ToArray().Select(s => _userLookupMapper.ToViewModel(s)).ToList();
                return AutoForm(model, nameof(QuickAddRent), "Quickly add rent subscription to user");
            }
        }

        public override ActionResult SaveEntry(EditUserLeaseInfoBindingModel model)
        {

            if (ModelState.IsValid)
            {

                var newRequest = model.Id == null;
                UserLeaseInfo paymentRequest = null;
                if (newRequest)
                {
                    _leaseService.CreateUserLeaseInfo(new CreateUserLeaseInfoBindingModel()
                    {
                        Amount = model.Amount,
                        IntervalMonths = model.IntervalMonths,
                        Title = model.Title,
                        RepetitionCompleteDate = model.CompleteDate,
                        UserId = model.UserId,
                        UseCompleteDate = model.UseCompleteDate,
                        UseInterval = model.UseInterval,
                        InvoiceDate = model.NextInvoiceDate.Value, //not null due to validation
                    });
                }
                else
                {
                    _leaseService.EditUserLeaseInfo(model);
                }

                if (Request  != null && Request.IsAjaxRequest())
                {
                    return JsonUpdate();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            model.UserIdItems = Context.Users.GetAll()
                .Where(u => !u.Archived)
                .ToList()
                .Select(u => _userMapper.ToViewModel(u))
                .Where(u => !string.IsNullOrWhiteSpace(u.Title))
                .ToList();

            return AutoForm(model, nameof(SaveEntry), "Create/Update Payment Request Information");
            

        }
    }
}