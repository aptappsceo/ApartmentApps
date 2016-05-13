using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public abstract class StandardCrudService<TModel, TViewModel> : IService, IMapper<TModel, TViewModel>, IServiceFor<TViewModel> where TViewModel : BaseViewModel, new() where TModel : IBaseEntity, new()
    {
        public IRepository<TModel> Repository { get; set; }
        public IMapper<TModel, TViewModel> Mapper { get; set; }

        protected StandardCrudService(IRepository<TModel> repository) : this(repository, null)
        {
            Repository = repository;
            Mapper = this;
        }

        protected StandardCrudService(IRepository<TModel> repository, IMapper<TModel, TViewModel> mapper)
        {
            Repository = repository;
            Mapper = mapper;
            if (Mapper == null)
                Mapper = this;
        }
        public IEnumerable<TViewModel> GetAll()
        {
            return Repository.GetAll().ToArray().Select(Mapper.ToViewModel);
        }

        public IEnumerable<TViewModel> GetRange(int skip, int take)
        {
            return Repository.GetAll().Skip(skip).Take(take).Select(Mapper.ToViewModel);
        }
        public void Add(TViewModel viewModel)
        {
            Repository.Add(Mapper.ToModel(viewModel));
            Repository.Save();

        }

        public void Remove(int id)
        {
            Repository.Remove(Repository.Find(id));
            Repository.Save();
        }

        public TViewModel Find(int id)
        {

            var vm = new TViewModel();
            Mapper.ToViewModel(Repository.Find(id), vm);
            return vm;
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
            var viewModel = new TViewModel();
            ToViewModel(model, viewModel);
            return viewModel;
        }

        public TViewModel CreateNew()
        {
            return new TViewModel();
        }

        public void Save(TViewModel unit)
        {
            var result = Repository.Find(unit.Id);
            if (result != null)
            {
                Mapper.ToModel(unit, result);
            }
            else
            {
                Repository.Add(Mapper.ToModel(unit));

            }
            Repository.Save();
        }
    }
}