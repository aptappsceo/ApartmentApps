using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Commands
{
    public static class StubCommands
    {

        public static ICommand NoActionSpecifiedCommand(ViewModelBase target, [CallerMemberName] string command = "")
        {
            return new MvxCommand(() =>
            {
                Debug.WriteLine("No action specified for {0}.{1}", target.GetType().Name, command);
                Mvx.Resolve<IDialogService>().OpenNotification("Coming Soon...", "...to Your Community!", "Ok");
            });
        }

    }
}
