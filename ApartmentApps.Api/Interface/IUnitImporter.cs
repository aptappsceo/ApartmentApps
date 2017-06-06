using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IUnitImporter
    {
        Task ImportResident(ICreateUser createUser, Property property, IExternalUnitImportInfo item);
    }
}