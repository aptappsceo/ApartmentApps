using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ResidentAppCross.ViewModels
{
    public class ImageBundleViewModel : MvxNotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value; 
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ImageBundleItemViewModel> RawImages { get; set; } = new ObservableCollection<ImageBundleItemViewModel>();
    }

    public class ImageBundleItemViewModel
    {
        public Uri Uri { get; set; } = new Uri("file:///tmp/"+Guid.NewGuid().ToString());
        public byte[] Data { get; set; }
    }
}
