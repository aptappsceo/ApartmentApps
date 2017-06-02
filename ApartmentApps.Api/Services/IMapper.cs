using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.Api.Services
{
    public interface IMapper<TModel, TViewModel>
    {
        void ToModel(TViewModel viewModel, TModel model);
        TModel ToModel(TViewModel viewModel);

        void ToViewModel(TModel model, TViewModel viewMOdel);
        TViewModel ToViewModel(TModel model);
    }
    public class LookupService
    {
        private readonly IKernel _kernel;

        public LookupService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public QueryResult<LookupBindingModel> GetLookups(Type type, string search)
        {
            var datasheetType = typeof(IDataSheet<>).MakeGenericType(type);
            var datasheet = this._kernel.Get(datasheetType);
            var queryMethod = datasheetType.GetMethod("Query");
            var obj = queryMethod.Invoke(datasheet, new[] {search});
            var get = obj.GetType().GetMethods().First(p=>p.ContainsGenericParameters && p.Name == "Get").MakeGenericMethod(typeof(LookupBindingModel));
            return ((QueryResult<LookupBindingModel>) get.Invoke (obj, null));
        }
    }
    public class LookupMapper<TModel> : BaseMapper<TModel, LookupBindingModel> where TModel :  new()
    {
        public Func<TModel, string> ValueSelector { get; set; }
        public Func<TModel, string> LabelSelector { get; set; }

        public LookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(LookupBindingModel viewModel, TModel model)
        {

        }

        public override void ToViewModel(TModel model, LookupBindingModel viewModel)
        {
            viewModel.Title = LabelSelector(model);
            viewModel.Id = ValueSelector(model);
        }
    }
    public abstract class BaseMapper<TModel, TViewModel> : IMapper<TModel, TViewModel> where TModel : new() where TViewModel : new()
    {
        private readonly IModuleHelper _moduleHelper;
        public IUserContext UserContext { get; set; }

        protected BaseMapper(IUserContext userContext, IModuleHelper moduleHelper)
        {
            _moduleHelper = moduleHelper;
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
                _moduleHelper.SignalToEnabled<IFillActions>(_=>_.FillActions(bvm.ActionLinks,bvm));

            return vm;
        }
    }
}