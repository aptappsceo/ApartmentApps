﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
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
                Mvx.ConstructAndRegisterSingleton<IQRService, IosQRService>();
            }
        }

        public class IosQRService : IQRService
        {
            public async Task<QRData> ScanAsync()
            {
                return new QRData()
                {
                    Data = "",
                    ImageData = new byte[0],
                    Timestamp = long.MinValue
                };
            }
        }
}