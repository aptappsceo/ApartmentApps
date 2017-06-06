using System;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public class GlobalModuleConfig : IBaseEntity, IModuleConfig
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Enabled { get; set; }
    }
}