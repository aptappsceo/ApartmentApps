namespace ApartmentApps.Portal.Controllers
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
            return vm;
        }
    }
}