using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using ResidentAppCross;

public class App : MvxApplication
{
    public App()
    {
        //Mvx.RegisterType<ICalculation, Calculation>();
        Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
        Mvx.RegisterSingleton(new ApplicationContext());
    }
}