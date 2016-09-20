using System.Collections.Generic;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{
    public interface IService
    {
        IEnumerable<TViewModel> GetAll<TViewModel>();
    //    IEnumerable<TViewModel> GetRange(int skip, int take);
        void Add<TViewModel>(TViewModel viewModel);
        void Remove(int id);
        TViewModel Find<TViewModel>(string id) where TViewModel : class, new();
        TViewModel CreateNew<TViewModel>() where TViewModel : new();
        void Save<TViewModel>(TViewModel unit) where TViewModel : BaseViewModel;
    }
}