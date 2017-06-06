using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;

namespace ApartmentApps.Portal.Controllers
{
    public class NotificationMapper : BaseMapper<UserAlert, NotificationViewModel>
    {
        public NotificationMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
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