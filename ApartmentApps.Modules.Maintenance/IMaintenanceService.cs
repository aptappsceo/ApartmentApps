using System;
using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;

namespace ApartmentApps.Api
{
    public interface IMaintenanceService : IService
    {
        int SubmitRequest(string comments, int requestTypeId, int petStatus, bool emergency, bool permissionToEnter, List<byte[]> images, int unitId = 0);
        bool PauseRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images);
        bool CompleteRequest(ApplicationUser worker, int requestId, string comments, List<byte[]> images);
        void StartRequest(ApplicationUser worker, int id, string comments, List<byte[]> images);
        void ScheduleRequest(ApplicationUser currentUser, int id, DateTime scheduleDate);
        IEnumerable<TViewModel> GetAppointments<TViewModel>();
        //void AssignRequest(int requestId, string userId);
        void AssignRequest(int id, string assignedToId);
    }
}