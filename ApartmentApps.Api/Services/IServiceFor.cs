using System.Collections.Generic;

namespace ApartmentApps.Portal.Controllers
{
    public interface IServiceFor<TViewModel>
    {
        IEnumerable<TViewModel> GetAll();
        IEnumerable<TViewModel> GetRange(int skip, int take);
        void Add(TViewModel viewModel);
        void Remove(int id);
        TViewModel Find(int id);
        TViewModel CreateNew();
        void Save(TViewModel unit);
      
    }
}