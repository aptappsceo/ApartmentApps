﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Newtonsoft.Json.Linq;

namespace ApartmentApps.Client.Models
{
    public static partial class CourtesyOfficerLocationCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<CourtesyOfficerLocation> DeserializeJson(JToken inputObject)
        {
            IList<CourtesyOfficerLocation> deserializedObject = new List<CourtesyOfficerLocation>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                CourtesyOfficerLocation courtesyOfficerLocation = new CourtesyOfficerLocation();
                courtesyOfficerLocation.DeserializeJson(iListValue);
                deserializedObject.Add(courtesyOfficerLocation);
            }
            return deserializedObject;
        }
    }
}