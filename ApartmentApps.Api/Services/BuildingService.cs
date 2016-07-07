using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;

namespace ApartmentApps.Portal.Controllers
{
  

    public class BuildingService : StandardCrudService<Building, BuildingViewModel>
    {
        public BuildingService(IRepository<Building> repository) : base(repository)
        {
        }

        public override void ToModel(BuildingViewModel viewModel, Building model)
        {
            model.Name = viewModel.Name;
            model.Id = Convert.ToInt32(viewModel.Id);

        }

        public override void ToViewModel(Building model, BuildingViewModel viewModel)
        {
            viewModel.Name = model.Name;
            viewModel.Id = model.Id.ToString();
        }
    }
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
            viewModel.Title = model.Subject;
            viewModel.Body = model.Body;
            viewModel.SentOn = model.SentOn;
            viewModel.SentToCount = model.SentToCount;
            viewModel.Id = model.Id.ToString();
        }
        public IEnumerable<MessageViewModel> GetHistory()
        {
            return Repository.GetAll().OrderByDescending(p=>p.SentOn).Take(15).ToArray().Select(Mapper.ToViewModel);
        }
    }
}