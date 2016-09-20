using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class MessageMapperFullDetails : MessageMapper
    {
        public override void ToViewModel(Message model, MessageViewModel viewModel)
        {
            base.ToViewModel(model, viewModel);
            viewModel.DeliverCount = model.MessageReceipts.Count(p => !p.Error);

            viewModel.Receipts = model.MessageReceipts.Select(p => new MessageReceiptViewModel()
            {
                Id = p.Id,
                UserEmail = p.User.Email,
                Opened = p.Opened,
                ErrorMessage = p.ErrorMessage,
                Error = p.Error
            }).ToArray();
        }
    }
    public class MessageMapper : BaseMapper<Message, MessageViewModel>
    {
        public override void ToModel(MessageViewModel viewModel, Message model)
        {
            model.Subject = viewModel.Title;
            model.Body = viewModel.Body;
            model.SentToCount = viewModel.SentToCount;
            model.Id = Convert.ToInt32(viewModel.Id);

        }

        public override void ToViewModel(Message model, MessageViewModel viewModel)
        {
            viewModel.Title = model.Subject;
            viewModel.Body = model.Body;
            viewModel.SentOn = model.SentOn;
            viewModel.SentToCount = model.MessageReceipts.Count();
            viewModel.Id = model.Id.ToString();
            viewModel.OpenCount = model.MessageReceipts.Count(p => !p.Error && p.Opened);
            viewModel.DeliverCount = model.MessageReceipts.Count(p => p.Error == false);
        }
    }
    public class MessagingService : StandardCrudService<Message>
    {
      

        public IEnumerable<TViewModel> GetHistory<TViewModel>()
        {
           
            return Repository.GetAll().OrderByDescending(p=>p.SentOn).Take(15).ToArray().Select(Map<TViewModel>().ToViewModel);
        }

        public MessageViewModel GetMessageWithDetails(string messageId)
        {
            return Find(messageId, new MessageMapperFullDetails());
        }


        public MessagingService(IKernel kernel, IRepository<Message> repository) : base(kernel, repository)
        {
        }
    }
}