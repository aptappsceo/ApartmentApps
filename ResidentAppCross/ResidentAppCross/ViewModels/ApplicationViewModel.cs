using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public override void Start()
        {
            base.Start();

            var auth = Mvx.Resolve<ILoginManager>();
            if (!auth.IsLoggedIn)
            {
                ShowViewModel<LoginFormViewModel>();
            }
            else
            {
                var sharedCommands = Mvx.Resolve<ISharedCommands>();
                var taskCommandContext = sharedCommands.CheckVersionAndLogInIfNeededCommand(this, null, null)
                    .OnFail(ex => ShowViewModel<LoginFormViewModel>());

                taskCommandContext.OnStart("Logging in...").Execute(null);
            }

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
