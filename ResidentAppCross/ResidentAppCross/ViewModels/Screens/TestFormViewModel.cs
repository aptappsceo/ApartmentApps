using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentAppCross.ViewModels.Screens
{
    public class TestFormViewModel : ViewModelBase
    {
        private string _headerTitle = "Testing MVVM Bindings";
        private string _subheaderTitle = "Binding work, if you see this.";

        public TestFormViewModel()
        {
        }

        public string SubheaderTitle
        {
            get { return _subheaderTitle; }
            set { SetProperty(ref _subheaderTitle,value); }
        }

        public string HeaderTitle
        {
            get { return _headerTitle; }
            set { SetProperty(ref _headerTitle, value); }
        }
    }
}
