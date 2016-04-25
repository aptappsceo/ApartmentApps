using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ResidentAppCross.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public override void Start()
        {
            base.Start();
            ShowViewModel<LoginFormViewModel>();
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
