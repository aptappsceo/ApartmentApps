using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Data.ActionModels
{
    public class SearchModelGetResponse
    {
        public ClientSearchModel Model { get; set; }       
    }

    public class ClientSearchModel
    {
        public string Id { get; set; }
        public List<ClientSearchFilterModel> Filters { get; set; }   
    }

    public class ClientSearchFilterModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DataSource { get; set; }
        public string EditorType { get; set; }
        public bool DefaultActive { get; set; }
        public string DataSourceType { get; set; }
    }

}
