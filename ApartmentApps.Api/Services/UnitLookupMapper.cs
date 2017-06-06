using System;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Portal.Controllers
{
    public class UnitLookupMapper : BaseMapper<Unit, LookupBindingModel>
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        public UnitLookupMapper(IUserContext userContext, IRepository<ApplicationUser> userRepository, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
            _userRepository = userRepository;
        }

        public override void ToModel(LookupBindingModel viewModel, Unit model)
        {
            throw new NotImplementedException();
        }

        public override void ToViewModel(Unit model, LookupBindingModel viewModel)
        {
            viewModel.Id = model.Id.ToString();
            var name = $"[{ model.Building.Name }] {model.Name}";
            var id = model.Id;
            var user = model.Users.FirstOrDefault(x => !x.Archived && x.UnitId == id);
            if (user != null)
                name += $" ({user.FirstName} {user.LastName})";

            viewModel.Title = name;

        }

    }
}