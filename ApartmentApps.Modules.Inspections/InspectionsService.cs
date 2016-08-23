using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Modules.Inspections
{
    public class InspectionViewModel : BaseViewModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public UserBindingModel SubmissionUser { get; set; }
        public string Status { get; set; }
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

    public class CreateInspectionViewModel
    {
        private readonly IRepository<Unit> _unitRepositoy;
        private readonly IRepository<ApplicationUser> _userRepository;

        public CreateInspectionViewModel()
        {
        }

        public CreateInspectionViewModel(IRepository<Unit> unitRepositoy,IRepository<ApplicationUser> userRepository)
        {
            _unitRepositoy = unitRepositoy;
            _userRepository = userRepository;
        }

        [DisplayName("Unit")]
        public int UnitId { get; set; }

        public IEnumerable<FormPropertySelectItem> UnitId_Items => _unitRepositoy.ToArray()
                    .OrderByAlphaNumeric(p => p.Name)
                    .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.Name, UnitId == p.Id));

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public DateTime ScheduleDate { get; set; }

        [DisplayName("Assign To")]
        public string WorkerId { get; set; }

        public IEnumerable<FormPropertySelectItem> WorkerId_Items => _userRepository.ToArray()
                    .Where(p => p.Roles.Any(x => x.RoleId == "Maintenance"))
                    .OrderByAlphaNumeric(p => p.LastName)
                    .Select(p => new FormPropertySelectItem(p.Id.ToString(), p.FirstName, WorkerId == p.Id));
    }

    public class FinishInspectionViewModel
    {
        private int InspectionId { get; set; }


    }

    public class InspectionAnswerViewModel
    {
        
    }

    public class InspectionsService : StandardCrudService<Inspection, InspectionViewModel>
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public InspectionsService(IBlobStorageService blobStorageService, IUserContext userContext, IRepository<Inspection> repository, IMapper<Inspection, InspectionViewModel> mapper) : base(repository, mapper)
        {
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public void CreateInspection(CreateInspectionViewModel inspectionViewModel)
        {
            var inspection = new Inspection()
            {
                ScheduleDate = 
            };
            inspection.Unit = inspectionViewModel.UnitId;
            Repository.Add();
        }

        public void StartInspection(int id)
        {
            
        }

        public void PauseInspection(int id)
        {
            
        }

        public void FinishInspection(int id)
        {
            
        }
    }
}