using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class MessagingService : StandardCrudService<Message, MessageViewModel>
    {
        public MessagingService(IRepository<Message> repository) : base(repository)
        {
        }

        public override void ToModel(MessageViewModel viewModel, Message model)
        {
            model.Subject = viewModel.Title;
            model.Body = viewModel.Body;
            model.SentToCount = viewModel.SentToCount;
            model.Id = Convert.ToInt32(viewModel.Id);

        }

        public override void ToViewModel(Message model, MessageViewModel viewModel)
        {
            ToViewModel(model, viewModel, false);
        }
        public void ToViewModel(Message model, MessageViewModel viewModel, bool fullDetails)
        {
            viewModel.Title = model.Subject;
            viewModel.Body = model.Body;
            viewModel.SentOn = model.SentOn;
            viewModel.SentToCount = model.MessageReceipts.Count();
            viewModel.Id = model.Id.ToString();
            viewModel.OpenCount = model.MessageReceipts.Count(p => !p.Error && p.Opened);
            viewModel.DeliverCount = model.MessageReceipts.Count(p => p.Error == false);
            if (fullDetails)
            {
                viewModel.DeliverCount = model.MessageReceipts.Count(p => !p.Error);
             
                viewModel.Receipts = model.MessageReceipts.Select(p=>new MessageReceiptViewModel()
                {
                    Id = p.Id,
                    UserEmail = p.User.Email,
                    UnitNumber = p.User.Unit?.Name,
                    BuildingNumber = p.User.Unit?.Building?.Name,
                    Opened = p.Opened,
                    ErrorMessage = p.ErrorMessage,
                    Error =  p.Error
                }).ToArray();
            }
            //viewModel.OpenCount = model.MessageReceipts.Count

        }
        public IEnumerable<MessageViewModel> GetHistory()
        {
            return Repository.GetAll().OrderByDescending(p=>p.SentOn).Take(15).ToArray().Select(Mapper.ToViewModel);
        }

        public MessageViewModel GetMessageWithDetails(int messageId)
        {
            var vm = new MessageViewModel();
            ToViewModel(Repository.Find(messageId),vm,true);
            return vm;
        }
    }
}