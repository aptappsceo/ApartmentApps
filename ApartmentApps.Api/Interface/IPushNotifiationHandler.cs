using System.Threading.Tasks;

namespace ApartmentApps.Api
{
    public interface IPushNotifiationHandler
    {
        Task<bool> SendToUser(string username, string message);
        Task<bool> SendToUser(string username, NotificationPayload payload);
        Task<bool> SendToRole(int propertyId, string role, string message);
        Task<bool> SendToRole(int propertyId, string role, NotificationPayload payload);
        Task<bool> Send( string message, string pns, string expression);
        Task<bool> Send( NotificationPayload payload, string pns, string expression);
    }
}