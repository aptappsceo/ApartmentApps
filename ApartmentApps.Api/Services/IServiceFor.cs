using System;
using System.Collections.Generic;
using ApartmentApps.Portal.Controllers;
using Korzh.EasyQuery.Db;

namespace ApartmentApps.Api
{
    public interface IService
    {
        Type ModelType { get; }

        IEnumerable<TViewModel> GetAll<TViewModel>(DbQuery query, out int count, string orderBy, bool orderByDesc,
            int page = 0, int resultsPerPage = 20);
        IEnumerable<TViewModel> GetAll<TViewModel>();
    //    IEnumerable<TViewModel> GetRange(int skip, int take);
        void Add<TViewModel>(TViewModel viewModel);
        void Remove(string id);
        TViewModel Find<TViewModel>(string id) where TViewModel : class, new();
        TViewModel CreateNew<TViewModel>() where TViewModel : new();
        void Save<TViewModel>(TViewModel unit) where TViewModel : BaseViewModel;
    }
}