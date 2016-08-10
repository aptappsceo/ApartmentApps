using System.Threading.Tasks;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IDataImporter
    {
        Task<bool> ImportData(ICreateUser createUser, Property property);
    }
}