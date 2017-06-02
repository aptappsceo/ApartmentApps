using System;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Services;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Api
{


    public class IncidentStatusLookupMapper : LookupMapper<IncidentReportStatus>
    {
        public IncidentStatusLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
            ValueSelector = x => x.Name;
            LabelSelector = x => x.Name;
        }
    }



}