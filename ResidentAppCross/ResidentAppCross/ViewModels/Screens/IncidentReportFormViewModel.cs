using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class IncidentReportFormViewModel : ViewModelBase
    {
        private readonly IApartmentAppsAPIService _service;
        private readonly IImageService _imageService;
        private readonly IDialogService _dialogService;

        private string _comments;
        private int? _selectIncidentReportTypeId;
        private bool _entrancePermission;

        public IncidentReportFormViewModel(IApartmentAppsAPIService service, IImageService imageService, IDialogService dialogService)
        {
            _service = service;
            _imageService = imageService;
            _dialogService = dialogService;
        }

        public override void Start()
        {
            base.Start();
            
        }

    
        public ImageBundleViewModel Photos { get; set; } = new ImageBundleViewModel() { Title = "Photos?" };


        public int? SelectIncidentReportTypeId
        {
            get { return _selectIncidentReportTypeId; }
            set { SetProperty(ref _selectIncidentReportTypeId, value); }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

  
 

        private ObservableCollection<SegmentItem> _incidentReportTypes;

        public ICommand HomeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Close(this);
                });
            }
        }

        public ICommand DoneCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var images = Photos.RawImages.Select(p =>
                    {
                        return Convert.ToBase64String(p.Data);
                    })
                        .ToList();

                    var requestModel = new IncidentReportModel()
                    {
                        Comments = Comments,
                       
                        IncidentReportTypeId = SelectIncidentReportTypeId,
                        Images =
                            images

                    };
                    await _service.Courtesy.SubmitIncidentReportWithOperationResponseAsync(requestModel);
                   
                }).OnStart("Sending Request...")
                .OnComplete("Request Sent", () => Close(this));
            }
        }



        public ICommand AddPhotoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _imageService.SelectImage(s =>
                    {
                        Photos.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Data = s
                        });
                    }, () => { });
                });
            }
        }



        public bool EntrancePermission
        {
            get { return _entrancePermission; }
            set { SetProperty(ref _entrancePermission, value); }
        }

        public ObservableCollection<SegmentItem> IncidentReportTypes
        {
            get
            {
                if (_incidentReportTypes == null)
                {
                    _incidentReportTypes = new ObservableCollection<SegmentItem>
                    {
                        new SegmentItem() {Title = "Noise", Id = 0},
                        new SegmentItem() {Title = "Parking", Id = 1},
                        new SegmentItem() {Title = "Visual Disturbance", Id = 2},
                        new SegmentItem() {Title = "Other", Id = 3}
                    };
                }
                return _incidentReportTypes;
            }
            set { _incidentReportTypes = value; }
        }
    }

    public class SegmentItem
    {
        public string Title { get; set; }
        public int Id { get; set; }
    }

    public class NotificationsFormViewModel : ViewModelBase
    {
        
    }
}
