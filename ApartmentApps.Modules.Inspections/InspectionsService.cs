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
using Ninject.Infrastructure.Language;
using ApartmentApps.Api.Modules;
using Ninject;

namespace ApartmentApps.Modules.Inspections
{
    public class InspectionViewModel : BaseViewModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public UserBindingModel SubmissionUser { get; set; }
        public InspectionStatus Status { get; set; }
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

        public InspectionViewModelMapper(IMapper<ApplicationUser,UserBindingModel>  userMapper , IUserContext userContext) : base(userContext)
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
        public int InspectionId { get; set; }

        public List<InspectionCategoryAnswerViewModel> Answers { get; set; }
        public InspectionCategoryStatus Status { get; set; }
    }

    public class InspectionCategoryAnswerViewModel
    {
        public int RoomId { get; set; }
        public int CategoryId { get; set; }
        public List<InspectionAnswerViewModel> Answers { get; set; }
        public InspectionCategoryStatus Status { get; set; }
    }
    public class InspectionAnswerViewModel
    {
        public int QuestionId { get; set; }
        public string Value { get; set; }
    }

    public class InspectionsService : StandardCrudService<Inspection>
    {
        private readonly PropertyContext _propertyContext;
        private readonly IRepository<InspectionCheckin> _inspectionCheckins;
        private readonly IRepository<InspectionCategoryResult> _categoryAnswers;
        private readonly IRepository<InspectionResult> _answers;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IUserContext _userContext;

        public InspectionsService(PropertyContext propertyContext, IRepository<InspectionCheckin> inspectionCheckins,
            IRepository<InspectionCategoryResult> categoryAnswers, IRepository<InspectionResult> answers, IBlobStorageService blobStorageService, IUserContext userContext, IRepository<Inspection> repository, IKernel kernel) : base(kernel, repository)
        {
            _propertyContext = propertyContext;
            _inspectionCheckins = inspectionCheckins;
            _categoryAnswers = categoryAnswers;
            _answers = answers;
            _blobStorageService = blobStorageService;
            _userContext = userContext;
        }

        public void CreateInspection(CreateInspectionViewModel inspectionViewModel)
        {
       
            var inspection = new Inspection()
            {
                ScheduleDate = inspectionViewModel.ScheduleDate,
                CreateDate = _userContext.CurrentUser.TimeZone.Now(),
                SubmissionUserId = _userContext.UserId,
                UnitId = inspectionViewModel.UnitId,
                AssignedToId = inspectionViewModel.WorkerId,
                Message = inspectionViewModel.Notes,
                Status = InspectionStatus.Created,
                CompleteDate = null,

            };
            Repository.Add(inspection);
            Repository.Save();

            Checkin(inspection.Id, inspectionViewModel.Notes, InspectionStatus.Created, null);
        }

        public void StartInspection(int id)
        {
            //var inspection = Repository.Find(id);
            //inspection.Status = InspectionStatus.Started;
            //Repository.Save();
            Checkin(id, "Inspection Started", InspectionStatus.Started, null);
        }

        public void PauseInspection(int id)
        {
            //var inspection = Repository.Find(id);
            Checkin(id, "Inspection Paused", InspectionStatus.Paused, null);
        }

        public void SaveInspectionCategory(int inspectionId, InspectionCategoryAnswerViewModel item)
        {
           // var inspection = Repository.Find(inspectionId);
            var inspectionCategoryAnswer = new InspectionCategoryResult()
            {
                InspectionCategoryId = item.CategoryId,
                InspectionRoomId = item.RoomId,
               InspectionId = inspectionId,
                Status = item.Status

            };
            _categoryAnswers.Add(inspectionCategoryAnswer);
            _categoryAnswers.Save();
            foreach (var answer in item.Answers)
            {
                _answers.Add(new InspectionResult()
                {
                    InspectionCategoryResultId = inspectionCategoryAnswer.Id,
                    InspectionQuestionId = answer.QuestionId,
                    Value = answer.Value
                });
                _answers.Save();
            }

        }
        public void FinishInspection(FinishInspectionViewModel vm)
        {
            var inspection = Repository.Find(vm.InspectionId);
            
            foreach (var item in vm.Answers)
            {
                var inspectionCategoryAnswer = new InspectionCategoryResult()
                {
                    InspectionCategoryId = item.CategoryId,
                    InspectionRoomId = item.RoomId,
                    Status = item.Status
                    ,InspectionId = vm.InspectionId
                };
                _categoryAnswers.Add(inspectionCategoryAnswer);
                _categoryAnswers.Save();

                foreach (var answer in item.Answers)
                {
                    _answers.Add(new InspectionResult()
                    {
                        InspectionCategoryResultId = inspectionCategoryAnswer.Id,
                        InspectionQuestionId = answer.QuestionId,
                        Value = answer.Value
                    });
                    _answers.Save();
                }
            }
            Repository.Save();
            Checkin(inspection.Id, "Inspection Finished", InspectionStatus.Completed, null, null);
        }
        private bool Checkin( int inspectionId, string comments, InspectionStatus status, List<byte[]> photos, Guid? groupId = null)
        {
            var worker = this._userContext.CurrentUser;
            var checkin = new InspectionCheckin
            {
                InspectionId = inspectionId,
                Comments = comments,
                Status = status,
                WorkerId = this._userContext.CurrentUser.Id,
                Date = worker.TimeZone.Now(),
                GroupId = groupId ?? Guid.NewGuid()
            };

            if (photos != null && groupId == null)
                foreach (var image in photos)
                {
                    var imageKey = $"{Guid.NewGuid()}.{worker.UserName.Replace('@', '_').Replace('.', '_')}".ToLowerInvariant();
                    var filename = _blobStorageService.UploadPhoto(image, imageKey);
                    _propertyContext.ImageReferences.Add(new ImageReference()
                    {
                        GroupId = checkin.GroupId,
                        Url = filename,
                        ThumbnailUrl = filename
                    });
                }
            _inspectionCheckins.Add(checkin);
            _inspectionCheckins.Save();
            var request =
                Repository.Find(inspectionId);

            request.Status = status;

            if (status == InspectionStatus.Completed)
            {
                request.CompleteDate = worker.TimeZone.Now();
            }
            _propertyContext.SaveChanges();

            ModuleHelper.EnabledModules.Signal<IInspectionCheckin>(_ => _.InspectionCheckin(checkin, request));
            return true;

        }
        public IEnumerable<TViewModel> GetAllForUser<TViewModel>(string userId)
        {
            var mapper = _kernel.Get<IMapper<Inspection, TViewModel>>();
            return Repository.Where(p => p.AssignedToId == userId).ToArray().Select(mapper.ToViewModel);
        }
    }

    internal interface IInspectionCheckin
    {
        void InspectionCheckin(InspectionCheckin checkin, Inspection request);
    }
}