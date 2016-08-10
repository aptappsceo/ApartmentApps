using System.Linq;
using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Entrata.Client;
using Ninject;

namespace ApartmentApps.Api
{
    public class EntrataModule : PropertyIntegrationModule<EntrataConfig>
    {
        public EntrataModule(ApplicationDbContext dbContext,PropertyContext context, DefaultUserManager manager,  IRepository<EntrataConfig> configRepo, IUserContext userContext, IKernel kernel) : base(dbContext, context, manager, configRepo, userContext, kernel)
        {
        }

        public override void Execute(ILogger logger)
        {
            foreach (var item in _context.PropertyEntrataInfos.ToArray())
            {
                var entrataClient = new EntrataClient()
                {
                    Username = item.Username,
                    Password = item.Password,
                    EndPoint = item.Endpoint
                };
                var result = entrataClient.GetMitsUnits(item.EntrataPropertyId).Result;
                if (result?.response?.error?.code == 301)
                {
                    logger.Warning(result.response.error.message);
                    continue;
                }
                if (result?.response != null)
                    if (result?.response?.result?.PhysicalProperty != null)
                        foreach (var property in result?.response?.result?.PhysicalProperty?.Property)
                        {
                            foreach (var ilsUnit in property.ILS_Unit.Select(p=>p.Units.Unit))
                            {
                                ImportUnit(logger, ilsUnit.BuildingName,ilsUnit.MarketingName);
                            }
                        }

                var customers =
                    entrataClient.GetCustomers(item.EntrataPropertyId).Result.Response.Result.Customers.Customer;
                foreach (var customer in customers)
                {

                    Building building;
                    Unit unit;
                    ImportUnit(logger,customer.BuildingName,customer.UnitNumber,out unit, out building);

                    ImportCustomer(this,unit.Id, customer.PhoneNumber.NumbersOnly(),customer.City, customer.Email, customer.FirstName, customer.LastName,customer.MiddleName,customer.Gender,customer.PostalCode,customer.State,customer.Address);

                }
            }

        }

        
    }
}