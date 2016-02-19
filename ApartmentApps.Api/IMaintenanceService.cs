namespace ApartmentApps.Api
{
    public interface IMaintenanceService : IService
    {
        int SubmitRequest(string user, string comments, int requestTypeId);
        bool PauseRequest(int requestId, string comments);
        bool CompleteRequest(int requestId, string comments);
    }
}