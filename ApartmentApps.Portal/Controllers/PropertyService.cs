using System.Web.Mvc;
using ApartmentApps.Data;

namespace ApartmentApps.Portal
{
    [Authorize]
    public class PropertyService
    {
        private PropertyController _propertyController;

        public PropertyService(PropertyController propertyController)
        {
            _propertyController = propertyController;
        }

        public void DeleteProperty(int id)
        {
            Property property = _propertyController.Db.Properties.Find(id);
            _propertyController.Db.Properties.Remove(property);
            _propertyController.Db.SaveChanges();
        }
    }
}