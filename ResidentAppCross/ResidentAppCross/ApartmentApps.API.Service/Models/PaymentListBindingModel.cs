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
    public partial class PaymentListBindingModel
    {
        private IList<PaymentLineBindingModel> _items;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<PaymentLineBindingModel> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the PaymentListBindingModel class.
        /// </summary>
        public PaymentListBindingModel()
        {
            this.Items = new LazyList<PaymentLineBindingModel>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken itemsSequence = ((JToken)inputObject["Items"]);
                if (itemsSequence != null && itemsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken itemsValue in ((JArray)itemsSequence))
                    {
                        PaymentLineBindingModel paymentLineBindingModel = new PaymentLineBindingModel();
                        paymentLineBindingModel.DeserializeJson(itemsValue);
                        this.Items.Add(paymentLineBindingModel);
                    }
                }
            }
        }
    }
}
