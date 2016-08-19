using System;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Modules.Inspections
{
    public class InspectionViewModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public UserBindingModel SubmissionUser { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public int PetStatus { get; set; }
        public bool HasPet { get; set; }
    }
    public class IInspectionsService
    {

    }

    public class InspectionViewModelMapper : BaseMapper<Inspection, InspectionViewModel>
    {
        public IMapper<ApplicationUser, UserBindingModel> UserMapper { get; set; }

        public InspectionViewModelMapper(IMapper<ApplicationUser,UserBindingModel>  userMapper)
        {
            UserMapper = userMapper;
        }

        public override void ToModel(InspectionViewModel viewModel, Inspection model)
        {
            
        }

        public override void ToViewModel(Inspection model, InspectionViewModel viewModel)
        {
            
            viewModel.CreateDate = model.CreateDate;
            viewModel.ScheduleDate = model.ScheduleDate;
            if (model.ScheduleDate != null)
                viewModel.EndDate = model.ScheduleDate.Value.Add(new TimeSpan(0, 0, 30, 0));
            viewModel.Message = model.Message;
            viewModel.SubmissionUser = UserMapper.ToViewModel(model.SubmissionUser);
            //if (model.LatestCheckin != null && model.LatestCheckin.StatusId == "Complete")
            //{
            //    var user = model.LatestCheckin.Worker;
            //    if (user != null)
            //    {
            //        viewModel.CompletedBy = UserMapper.ToViewModel(user);
            //    }
            //}
            viewModel.Status = model.Status;
            viewModel.Id = model.Id.ToString();
            viewModel.UnitName = model.Unit?.Name;
            viewModel.BuildingName = model.Unit?.Building?.Name;
            //viewModel.PermissionToEnter = model.PermissionToEnter;
            viewModel.PetStatus = model.PetStatus;
            viewModel.HasPet = model.PetStatus > 1;
            //viewModel.StartDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Started")?.Date;
            //viewModel.CompleteDate = model.Checkins.FirstOrDefault(p => p.StatusId == "Complete")?.Date;

            //viewModel.LatestCheckin = model.LatestCheckin?.ToMaintenanceCheckinBindingModel(_blobStorageService);
            //viewModel.Checkins = model.Checkins.Select(p => p.ToMaintenanceCheckinBindingModel(_blobStorageService));
        }
    }
    public class InspectionsService
    {
        
    }
}