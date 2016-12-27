using ApartmentApps.Api.Modules;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.Services
{
    public interface IMapper<TModel, TViewModel>
    {
        void ToModel(TViewModel viewModel, TModel model);
        TModel ToModel(TViewModel viewModel);

        void ToViewModel(TModel model, TViewModel viewMOdel);
        TViewModel ToViewModel(TModel model);
    }

    public abstract class BaseMapper<TModel, TViewModel> : IMapper<TModel, TViewModel> where TModel : new() where TViewModel : new()
    {
        public IUserContext UserContext { get; set; }

        protected BaseMapper(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public abstract void ToModel(TViewModel viewModel, TModel model);
        public TModel ToModel(TViewModel viewModel)
        {
           var model = new TModel();
            ToModel(viewModel, model);
            return model;
        }

        public abstract void ToViewModel(TModel model, TViewModel viewModel);

        public TViewModel ToViewModel(TModel model)
        {
            var vm = new TViewModel();
            ToViewModel(model, vm);
            var bvm = vm as BaseViewModel;

            if (bvm != null)
                ModuleHelper.EnabledModules.Signal<IFillActions>(_=>_.FillActions(bvm.ActionLinks,bvm));

            return vm;
        }
    }
}