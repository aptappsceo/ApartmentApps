﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using ApartmentApps.Client.Models;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class ModuleInfo
    {
        private CourtesyConfig _courtesyConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public CourtesyConfig CourtesyConfig
        {
            get { return this._courtesyConfig; }
            set { this._courtesyConfig = value; }
        }
        
        private MaintenanceConfig _maintenanceConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public MaintenanceConfig MaintenanceConfig
        {
            get { return this._maintenanceConfig; }
            set { this._maintenanceConfig = value; }
        }
        
        private MessagingConfig _messagingConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public MessagingConfig MessagingConfig
        {
            get { return this._messagingConfig; }
            set { this._messagingConfig = value; }
        }
        
        private PaymentsConfig _paymentsConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public PaymentsConfig PaymentsConfig
        {
            get { return this._paymentsConfig; }
            set { this._paymentsConfig = value; }
        }
        
        private ProspectModuleConfig _prospectConfig;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public ProspectModuleConfig ProspectConfig
        {
            get { return this._prospectConfig; }
            set { this._prospectConfig = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ModuleInfo class.
        /// </summary>
        public ModuleInfo()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken courtesyConfigValue = inputObject["CourtesyConfig"];
                if (courtesyConfigValue != null && courtesyConfigValue.Type != JTokenType.Null)
                {
                    CourtesyConfig courtesyConfig = new CourtesyConfig();
                    courtesyConfig.DeserializeJson(courtesyConfigValue);
                    this.CourtesyConfig = courtesyConfig;
                }
                JToken maintenanceConfigValue = inputObject["MaintenanceConfig"];
                if (maintenanceConfigValue != null && maintenanceConfigValue.Type != JTokenType.Null)
                {
                    MaintenanceConfig maintenanceConfig = new MaintenanceConfig();
                    maintenanceConfig.DeserializeJson(maintenanceConfigValue);
                    this.MaintenanceConfig = maintenanceConfig;
                }
                JToken messagingConfigValue = inputObject["MessagingConfig"];
                if (messagingConfigValue != null && messagingConfigValue.Type != JTokenType.Null)
                {
                    MessagingConfig messagingConfig = new MessagingConfig();
                    messagingConfig.DeserializeJson(messagingConfigValue);
                    this.MessagingConfig = messagingConfig;
                }
                JToken paymentsConfigValue = inputObject["PaymentsConfig"];
                if (paymentsConfigValue != null && paymentsConfigValue.Type != JTokenType.Null)
                {
                    PaymentsConfig paymentsConfig = new PaymentsConfig();
                    paymentsConfig.DeserializeJson(paymentsConfigValue);
                    this.PaymentsConfig = paymentsConfig;
                }
                JToken prospectConfigValue = inputObject["ProspectConfig"];
                if (prospectConfigValue != null && prospectConfigValue.Type != JTokenType.Null)
                {
                    ProspectModuleConfig prospectModuleConfig = new ProspectModuleConfig();
                    prospectModuleConfig.DeserializeJson(prospectConfigValue);
                    this.ProspectConfig = prospectModuleConfig;
                }
            }
        }
    }
}
