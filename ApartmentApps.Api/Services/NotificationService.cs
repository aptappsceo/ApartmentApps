using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Portal.Controllers
{
    public class NotificationMapper : BaseMapper<UserAlert, NotificationViewModel>
    {

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
    public class NotificationService : StandardCrudService<UserAlert>
    {
        public NotificationService(IKernel kernel, IRepository<UserAlert> repository) : base(kernel, repository)
        {
        }
    }
}