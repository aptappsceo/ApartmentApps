using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Api
{
    public class YardiModule : PropertyIntegrationModule<YardiConfig>
    {
        public YardiModule(ApplicationDbContext dbContext,PropertyContext context, DefaultUserManager manager, IRepository<YardiConfig> configRepo, IUserContext userContext, IKernel kernel) : base( dbContext, context, manager, configRepo, userContext,kernel)
        {
        }

        public override void Execute(ILogger logger)
        {
            var config = Config;
            //var req = new GetUnitInformation_LoginRequest(new GetUnitInformation_LoginRequestBody());

            //var xml = (new GetChargeTypes_LoginResponseBody()).GetChargeTypes_LoginResult.Value;
            //var client = new ItfResidentDataSoapClient();


            //var client = new ItfResidentTransactions2_0SoapClient();
            //client.GetUnitInformation_Login("apartmentappbp", "67621", "YCSQL5TEST_2K8R2", "afqoml_70dev", "SQL Server",
            //    "", "Apartment App Payments", "");


        }


    }
}