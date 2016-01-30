using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace ResidentAppCross
{
    public class LoginViewModel : MvxViewModel
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value;
                SetProperty(ref _username, value, "Username");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value, "Password"); }
        }

        
        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine(string.Format("Should login {0}:{1}", Username, Password));
                    ShowViewModel<HomeMenuViewModel>();
                }
                    , () => true);
            }
        }
    }
}