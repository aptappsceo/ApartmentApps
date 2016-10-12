using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class MessageMapperFullDetails : MessageMapper
    {
        public MessageMapperFullDetails(IMapper<ApplicationUser, UserBindingModel> userMapper, IUserContext userContext) : base(userMapper, userContext)
        {
        }

        public override void ToViewModel(Message model, MessageViewModel viewModel)
        {
            base.ToViewModel(model, viewModel);
            viewModel.DeliverCount = model.MessageReceipts.Count(p => !p.Error);

            viewModel.Receipts = model.MessageReceipts.Select(p => new MessageReceiptViewModel()
            {
                Id = p.Id,
                UserEmail = p.User.Email,
                UserName = $"{p.User.FirstName} {p.User.LastName}",
                Opened = p.Opened,
                ErrorMessage = p.ErrorMessage,
                Error = p.Error
            }).ToArray();
        }
    }

    public class MessageTargetsViewModel : BaseViewModel
    {
        
        public int TargetsCount { get; set; }
        public string TargetsXml { get; set; }
        public string TargetsDescription { get; set; }
        public string Subject { get; set; }
    }

    public class MessageTargetMapper : BaseMapper<Message, MessageTargetsViewModel>
    {
        public MessageTargetMapper(IUserContext userContext) : base(userContext)
        {
        }

        public override void ToModel(MessageTargetsViewModel viewModel, Message model)
        {
            model.Filter = viewModel.TargetsXml;
            model.TargetsCount = viewModel.TargetsCount;
            model.TargetsDescription = viewModel.TargetsDescription;
        }

        public override void ToViewModel(Message model, MessageTargetsViewModel viewModel)
        {
            viewModel.Subject = model.Subject;
            viewModel.TargetsXml = model.Filter;
            viewModel.TargetsDescription = model.TargetsDescription;
            viewModel.Id = model.Id.ToString();
            viewModel.TargetsCount = model.TargetsCount;
        }
    }
    public class MessageMapper : BaseMapper<Message, MessageViewModel>
    {
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;

        public MessageMapper(IMapper<ApplicationUser,UserBindingModel> userMapper, IUserContext userContext) : base(userContext)
        {
            _userMapper = userMapper;
        }

        public override void ToModel(MessageViewModel viewModel, Message model)
        {
            model.Subject = viewModel.Title;
            model.Filter = viewModel.TargetsXml;
            model.Body = viewModel.Body;
            model.SentToCount = viewModel.SentToCount;
            model.Id = Convert.ToInt32(viewModel.Id);

        }

        public override void ToViewModel(Message model, MessageViewModel viewModel)
        {
            viewModel.Title = model.Subject;
            viewModel.From = _userMapper.ToViewModel(model.From);
            viewModel.Body = model.Body;
            viewModel.SentOn = model.SentOn;
            viewModel.Id = model.Id.ToString();
            if (model.MessageReceipts != null)
            {
                viewModel.SentToCount = model.MessageReceipts.Count();
                viewModel.OpenCount = model.MessageReceipts.Count(p => !p.Error && p.Opened);
                viewModel.DeliverCount = model.MessageReceipts.Count(p => p.Error == false);
            }
            
            viewModel.TargetsXml = model.Filter;
            viewModel.TargetsDescription = model.TargetsDescription;
            viewModel.TargetsCount = model.TargetsCount;
            viewModel.Sent = model.Sent;
        }
    }

    public class MessageFormMapper : BaseMapper<Message,MessageFormViewModel>
    {
        public MessageFormMapper(IUserContext userContext) : base(userContext)
        {
        }

        public override void ToModel(MessageFormViewModel viewModel, Message model)
        {
            model.Body = viewModel.Body;
            model.Subject = viewModel.Subject;
        }

        public override void ToViewModel(Message model, MessageFormViewModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            viewModel.Body = model.Body;
            viewModel.Subject = model.Subject;
        }
    }
    public class MessageFormViewModel : BaseViewModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }


    public class MessagingService : StandardCrudService<Message>
    {
        private readonly IUserContext _userContext;
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;


        public MessagingService( IUserContext userContext,IMapper<ApplicationUser, UserBindingModel> userMapper,IKernel kernel, IRepository<Message> repository) : base(kernel, repository)
        {
            _userContext = userContext;
            _userMapper = userMapper;
        }

        public IEnumerable<TViewModel> GetHistory<TViewModel>()
        {
           
            return Repository.GetAll().OrderByDescending(p=>p.SentOn).Take(15).ToArray().Select(Map<TViewModel>().ToViewModel);
        }

        public MessageViewModel GetMessageWithDetails(string messageId)
        {
            return Find(messageId, new MessageMapperFullDetails(_userMapper, _userContext));
        }

        public override void Add<TViewModel>(TViewModel viewModel)
        {

            base.Add(viewModel);
        }

        public override string DefaultOrderBy => "Id";

        public MessagingService(IKernel kernel, IRepository<Message> repository) : base(kernel, repository)
        {
        }

        public void MarkSent(int messageId)
        {
            var message = Repository.Find(messageId);
            message.Sent = true;
            Repository.Save();
        }
    }
}