﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public partial class Building
    {
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private int? _propertyId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PropertyId
        {
            get { return this._propertyId; }
            set { this._propertyId = value; }
        }
        
        private int? _rentAmount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? RentAmount
        {
            get { return this._rentAmount; }
            set { this._rentAmount = value; }
        }
        
        private IList<Unit> _units;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Unit> Units
        {
            get { return this._units; }
            set { this._units = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Building class.
        /// </summary>
        public Building()
        {
            this.Units = new LazyList<Unit>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken nameValue = inputObject["Name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken propertyIdValue = inputObject["PropertyId"];
                if (propertyIdValue != null && propertyIdValue.Type != JTokenType.Null)
                {
                    this.PropertyId = ((int)propertyIdValue);
                }
                JToken rentAmountValue = inputObject["RentAmount"];
                if (rentAmountValue != null && rentAmountValue.Type != JTokenType.Null)
                {
                    this.RentAmount = ((int)rentAmountValue);
                }
                JToken unitsSequence = ((JToken)inputObject["Units"]);
                if (unitsSequence != null && unitsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken unitsValue in ((JArray)unitsSequence))
                    {
                        Unit unit = new Unit();
                        unit.DeserializeJson(unitsValue);
                        this.Units.Add(unit);
                    }
                }
            }
        }
    }
}
