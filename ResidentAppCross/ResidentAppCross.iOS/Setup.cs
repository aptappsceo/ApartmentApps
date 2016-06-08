using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using ResidentAppCross.iOS.Services;
using ResidentAppCross.Services;

namespace ResidentAppCross.iOS
{
        public class Setup : MvxIosSetup
        {
            public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter)
                : base(appDelegate, presenter)
            {
            }

            protected override IMvxApplication CreateApp()
            {
                return new App();
            }

            protected override void InitializeIoC()
            {
                base.InitializeIoC();
                Mvx.ConstructAndRegisterSingleton<IQRService, IOSQRService>();
                Mvx.ConstructAndRegisterSingleton<IDialogService, IOSDialogService>();
                Mvx.ConstructAndRegisterSingleton<IDefaultViewModelTypeProvider, IOSDefaultViewModelTypeProvider>();
            }
        }

    public class IOSDefaultViewModelTypeProvider : IDefaultViewModelTypeProvider
    {
        public Type DefaultViewModelType => typeof (HomeMenuViewModel);
    }

    public class VerionChecker
    {
        
    }
      
}
