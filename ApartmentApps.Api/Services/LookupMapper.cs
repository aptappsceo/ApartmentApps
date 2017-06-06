using System;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Services
{
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
}