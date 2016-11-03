using System;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class ServiceResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ServiceResponseBase()
        {
            Success = true;

        }
        public ServiceResponseBase(string message)
        {
            Message = message;
            Success = false;
        }
        public ServiceResponseBase(Exception message)
        {
            Message = message.Message + Environment.NewLine + message.StackTrace;
            Success = false;
        }
    }
}