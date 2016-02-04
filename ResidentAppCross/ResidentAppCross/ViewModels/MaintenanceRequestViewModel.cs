using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace ResidentAppCross.ViewModels
{

    public abstract class DialogScreenViewModel : MvxViewModel
    {
        public virtual ICommand HomeCommand
        {
            get
            {
                return new MvxCommand(()=>ShowViewModel<HomeMenuViewModel>());
            }
        }

        public abstract ICommand DoneCommand { get; }

    }


    public class MaintenanceRequestViewModel : DialogScreenViewModel
    {
        public override ICommand DoneCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("Should Send Maintenance Request");
                });
            }
        }
    }
}
