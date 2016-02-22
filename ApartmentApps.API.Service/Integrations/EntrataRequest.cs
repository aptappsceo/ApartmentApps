﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Entrata.Model.Requests
{

    public class Auth
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Params
    {

        [JsonProperty("propertyId")]
        public string PropertyId { get; set; }
    }

    public class Method
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }
    }

    public class EntrataRequest
    {

        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("method")]
        public Method Method { get; set; }
    }

}