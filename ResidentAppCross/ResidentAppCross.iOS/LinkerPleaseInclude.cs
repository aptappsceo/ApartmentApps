using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MvvmCross.Platform.IoC;
using UIKit;

namespace ResidentAppCross.iOS
{
    // This class is never actually executed, but when Xamarin linking is enabled it does how to ensure types and properties
    // are preserved in the deployed app
    public class LinkerPleaseInclude
    {
        public void Include(UIButton uiButton)
        {
        }

        public void Include(UIBarButtonItem barButton)
        {
        }

        public void Include(UITextField textField)
        {
        }

        public void Include(UITextView textView)
        {
        }

        public void Include(UILabel label)
        {
        }

        public void Include(UIImageView imageView)
        {
        }

        public void Include(UIDatePicker date)
        {
        }

        public void Include(UISlider slider)
        {
        }

        public void Include(UISwitch sw)
        {
        }

        public void Include(INotifyCollectionChanged changed)
        {
         
        }

        public void Include(INotifyPropertyChanged changed)
        {
            changed.PropertyChanged += (sender, e) => {
                var test = e.PropertyName;
            };
        }

        public void Include(ICommand command)
        {
        }

        public void Include(MvxPropertyInjector injector)
        {
            injector = new MvxPropertyInjector();
        }
    }
}
