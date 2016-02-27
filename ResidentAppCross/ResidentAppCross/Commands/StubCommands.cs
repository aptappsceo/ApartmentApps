﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
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
                target.FailTaskWithPrompt("This feature is not yet implemented.");
            });
        }

    }
}
