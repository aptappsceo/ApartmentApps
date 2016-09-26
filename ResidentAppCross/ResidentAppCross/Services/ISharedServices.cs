using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Interfaces;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Services
{
    public interface ISharedCommands
    {
        ITaskCommandContext GetCheckVersionCommand(ViewModelBase owner);

        ITaskCommandContext GetLoginCommand(ViewModelBase owner, Func<string> usernameGetter = null,
            Func<string> passwordGetter = null);

        ITaskCommandContext GetAutoLoginCommand(ViewModelBase owner);

        ITaskCommandContext CheckVersionAndLogInIfNeededCommand(ViewModelBase owner, Func<string> usernameGetter = null,
            Func<string> passwordGetter = null);
    }

    public class SharedCommands : MvxNavigatingObject, ISharedCommands, IEventAware
    {

        private IVersionChecker _versionChecker;
        private IApartmentAppsAPIService _dataService;
        private ILoginManager _loginManager;
        private IMvxMessenger _eventAggregator;

        public SharedCommands(IVersionChecker versionChecker, IApartmentAppsAPIService dataService,
            ILoginManager loginManager)
        {
            _versionChecker = versionChecker;
            _dataService = dataService;
            _loginManager = loginManager;
        }

        public async Task CheckVersionProcedure(ITaskCommandContext context)
        {
            if (_versionChecker != null)
            {
                var version = await _dataService.Version.GetAsync();
                if (!_versionChecker.CheckVersion(version))
                {
                    context.FailTask("Please, update your application!", () =>
                    {
                        _versionChecker.OpenInStore(version);
                    });
                }
            }
        }



        public async Task LoginProcedure(ITaskCommandContext context, string username, string password)
        {

            _loginManager.Logout();

#if DEBUG
            username = string.IsNullOrEmpty(username) ? "micahosborne@gmail.com" : username;
            password = string.IsNullOrEmpty(password) ? "Asdf1234!" : password;
#endif

            if (!await _loginManager.LoginAsync(username, password))
            {
                context.FailTask("Invalid login or password!");
            }

        }

        public async Task AutoLoginProcedure(ITaskCommandContext context)
        {
            if (!await _loginManager.LoginAsync(null, null))
            {
                context.FailTask("Invalid login or password!");
            }
        }

        public ITaskCommandContext GetLoginCommand(ViewModelBase owner, Func<string> usernameGetter,
            Func<string> passwordGetter)
        {
            return owner.TaskCommand(async context =>
            {
                await LoginProcedure(context, usernameGetter?.Invoke(), passwordGetter?.Invoke());
                ;
            }).OnStart("Logging In...");
        }

        public ITaskCommandContext GetAutoLoginCommand(ViewModelBase owner)
        {
            return owner.TaskCommand(async context =>
            {
                await AutoLoginProcedure(context);
            }).OnStart("Logging In...");
        }

        public ITaskCommandContext GetCheckVersionCommand(ViewModelBase owner)
        {
            return
                owner.TaskCommand(async context => { await CheckVersionProcedure(context); })
                    .OnStart("Checking Version...");
        }

        //Context-agnostic command to log in
        public ITaskCommandContext CheckVersionAndLogInIfNeededCommand(ViewModelBase owner,
            Func<string> usernameGetter = null,
            Func<string> passwordGetter = null)
        {
            return owner.TaskCommand(async ctx =>
            {

                await CheckVersionProcedure(ctx);

                var username = usernameGetter?.Invoke();
                var password = passwordGetter?.Invoke();


                if (_loginManager.IsLoggedIn && !(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
                {
                    await AutoLoginProcedure(ctx);
                }
                else
                {
                    await LoginProcedure(ctx, username, password);
                }

                ShowHomeScreen();

                if (EventAggregator.HasSubscriptionsFor<UserLoggedInEvent>())
                {
                    var message = new UserLoggedInEvent(this);
                    EventAggregator.Publish(message);
                }

            });
        }

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        private void ShowHomeScreen()
        {
            var type = Mvx.Resolve<IDefaultViewModelTypeProvider>().DefaultViewModelType;
            this.ShowViewModel(type);
        }

    }


}
