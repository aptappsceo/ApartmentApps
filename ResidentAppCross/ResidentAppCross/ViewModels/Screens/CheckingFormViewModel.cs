using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CheckingFormViewModel : ViewModelBase
    {
        private string _comments;
        private ImageBundleViewModel _photos;
        private string _actionText;

        public CheckingFormViewModel()
        {
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments,value); }
        }

        public ImageBundleViewModel Photos
        {
            get { return _photos ?? (_photos = new ImageBundleViewModel()); }
            set { SetProperty(ref _photos,value); }
        }

        public string ActionText
        {
            get { return _actionText; }
            set { SetProperty(ref _actionText, value); }
        }

        public ICommand ActionCommand { get; set; }

        
    }
}
