using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Microsoft.Rest;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.Events;
using ResidentAppCross.Extensions;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{

    public class MaintenanceRequestFormViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private IImageService _imageService;

        private ObservableCollection<LookupPairModel> _requestTypes =
            new ObservableCollection<LookupPairModel>();

        private string _title;
        private LookupPairModel _selectedRequestType;
        private string _comments;

        public MaintenanceRequestFormViewModel(IApartmentAppsAPIService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;

        }

        public override void Start()
        {
            base.Start();
            //            _service.Maitenance.GetMaitenanceRequestTypesWithOperationResponseAsync().ContinueWith(t =>
            //            {
            //                RequestTypes.AddRange(t.Result.Body);
            //            });
            Task.Run(async () =>
            {
                this.Publish(new TaskStarted(this)
                {
                    Label = "Loading Request Types..."
                });

                HttpOperationResponse<IList<LookupPairModel>> op;
                try
                {
                    op = await _service.Maitenance.GetMaitenanceRequestTypesWithOperationResponseAsync();
                    RequestTypes.AddRange(op.Body);
                    SelectedRequestType = RequestTypes.FirstOrDefault();
                    this.Publish(new TaskComplete(this));
                }
                catch(Exception ex)
                {
                    this.Publish(new TaskFailed(this)
                    {
                        Label = "Loading Request Types...",
                        ShouldPrompt = true,
                        OnPrompted = () => Close(this)
                    });
                    return;
                }

             

            });
            
        }

        public ObservableCollection<LookupPairModel> RequestTypes
        {
            get { return _requestTypes; }
            set
            {
                _requestTypes = value;
                RaisePropertyChanged();
            }
        }

        public string Title => "Maintenance Request";

        public ICommand DoneCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var c = Comments;
                    this.Publish(new TaskStarted(this) { Label = "Sending Request..."});
                    object result;
                    try
                    {
                        result = await _service.Maitenance.SubmitRequestAsync(new MaitenanceRequestModel()
                        {
                            Comments = c,
                            MaitenanceRequestTypeId = Convert.ToInt32(SelectedRequestType.Key),
                            Images =
                                ImagesToUpload.RawImages.Select(p => Encoding.UTF8.GetString(p.Data, 0, p.Data.Length))
                                    .ToList()
                        });
                    }
                    catch (Exception ex)
                    {
                        this.Publish(new TaskFailed(this)
                        {
                            Label = string.Format("Failed to send request: {0}", ex.Message),
                            ShouldPrompt = true,
                            OnPrompted = () =>
                            {
                             Close(this);
                            }
                        });
                        return;
                    }

                    this.Publish(new TaskComplete(this)
                    {
                        Label = "Request Sent",
                        ShouldPrompt = true,
                        OnPrompted = () =>
                        {
                            Close(this);
                        }
                    });
                });
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
                        ImagesToUpload.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Data = s
                        });
                    }, ()=> {});
                });
            }
        }

        public ImageBundleViewModel ImagesToUpload { get; set; } = new ImageBundleViewModel() { Title = "Halo?" };

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

        public LookupPairModel SelectedRequestType
        {
            get { return _selectedRequestType; }
            set
            {
                SetProperty(ref _selectedRequestType, value);
            }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public void OnRequestTypeSelected(LookupPairModel type)
        {
            SelectedRequestType = type;
        }

        public ICommand SelectRequestTypeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MaintenanceRequestTypeSelectionViewModel.OnSelect = OnRequestTypeSelected;
                    MaintenanceRequestTypeSelectionViewModel.Options = RequestTypes.ToList();
                    ShowViewModel<MaintenanceRequestTypeSelectionViewModel>();
                });
            }
        }
    }
}
