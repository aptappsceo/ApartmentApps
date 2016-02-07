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

        public ObservableCollection<byte[]> RawImages { get; set; } = new ObservableCollection<byte[]>();
        public ObservableCollection<string> RemoteImages { get; set; } = new ObservableCollection<string>();
    }
}
