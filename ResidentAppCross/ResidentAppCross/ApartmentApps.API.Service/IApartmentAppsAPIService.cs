﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using ApartmentApps.Client;
using Microsoft.Rest;

namespace ApartmentApps.Client
{
    public partial interface IApartmentAppsAPIService : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri
        {
            get; set; 
        }
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        ServiceClientCredentials Credentials
        {
            get; set; 
        }
        
        IAccount Account
        {
            get; 
        }
        
        IAlerts Alerts
        {
            get; 
        }
        
        ICheckins Checkins
        {
            get; 
        }
        
        IConfigure Configure
        {
            get; 
        }
        
        ICourtesy Courtesy
        {
            get; 
        }
        
        ILookups Lookups
        {
            get; 
        }
        
        IMaitenance Maitenance
        {
            get; 
        }
        
        INotifiations Notifiations
        {
            get; 
        }
        
        IRegister Register
        {
            get; 
        }
        
        IVersion Version
        {
            get; 
        }
    }
}
