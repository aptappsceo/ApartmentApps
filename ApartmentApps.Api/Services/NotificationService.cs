using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class NotificationService : StandardCrudService<UserAlert, NotificationViewModel>
    {
        public NotificationService(IRepository<UserAlert> repository) : base(repository)
        {

        }

        public override void ToModel(NotificationViewModel viewModel, UserAlert model)
        {

        }

        public override void ToViewModel(UserAlert model, NotificationViewModel viewModel)
        {
            viewModel.Type = model.Type;
            viewModel.RelatedId = model.RelatedId;
            viewModel.Title = model.Title;
            viewModel.Message = model.Message;
            viewModel.HasRead = model.HasRead;
            viewModel.Date = model.CreatedOn;
        }
    }
}