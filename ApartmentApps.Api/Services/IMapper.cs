using System.Collections.Generic;

namespace ApartmentApps.Api.Services
{
    public interface IMapper<TModel, TViewModel>
    {
        void ToModel(TViewModel viewModel, TModel model);
        TModel ToModel(TViewModel viewModel);

        void ToViewModel(TModel model, TViewModel viewMOdel);
        TViewModel ToViewModel(TModel model);
    }
}