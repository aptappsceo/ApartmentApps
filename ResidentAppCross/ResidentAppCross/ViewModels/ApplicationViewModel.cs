﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public override void Start()
        {
            base.Start();
            ShowViewModel<AddCreditCardPaymentOptionViewModel>();
        }

    }

    public class Fragment1ViewModel : ViewModelBase
    {
        
    }

    public class Fragment2ViewModel : ViewModelBase
    {
        
    }

    public class Fragment3ViewModel : ViewModelBase
    {
        
    }

}
