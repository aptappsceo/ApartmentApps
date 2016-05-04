using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using blocke.circleimageview;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Resources;

namespace ResidentAppCross.Droid.Views.Components.Navigation
{
    public class HomeMenuNavigationView : NavigationView
    {
        private HomeMenuViewModel _viewModel;

        public HomeMenuNavigationView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public HomeMenuNavigationView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public HomeMenuNavigationView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public HomeMenuNavigationView(Context context) : base(context)
        {
        }


        [Outlet] public AppCompatTextView EmailLabel { get; set; }
        [Outlet] public AppCompatTextView UsernameLabel { get; set; }
        [Outlet] public CircleImageView AvatarView { get; set; }

        public HomeMenuViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                if (value != null) OnViewModelSet();
            }
        }

        private IMvxMessenger _eventAggregator;
        private Dictionary<int, ICommand> _commandsMap;

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public event MenuContentRequestDelegate OnRequestContent;

        public virtual void OnViewModelSet()
        {

            EventAggregator.SubscribeOnMainThread<HomeMenuUpdatedEvent>(evt =>
            {
                if (evt.Sender == ViewModel)
                {
                    UpdateContent();
                }
            },MvxReference.Strong);
            NavigationItemSelected += HomeMenuView_NavigationItemSelected;
            //ViewModel.UpdateMenuItems();

        }

        public event Action<object, NavigationItemSelectedEventArgs> BeforeNavigate;

        private void HomeMenuView_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs e)
        {
            BeforeNavigate?.Invoke(sender,  e);
            CommandsMap[e.MenuItem.ItemId].Execute(null);
        }

        public void Refresh()
        {
            ViewModel.UpdateMenuItems();
        }

        public Dictionary<int, ICommand> CommandsMap
        {
            get { return _commandsMap ?? (_commandsMap = new Dictionary<int, ICommand>()); }
            set { _commandsMap = value; }
        }


        private void UpdateContent()
        {
            Menu.Clear();

            var index = 0;

            if (UsernameLabel == null)
            {
                var header = this.FindViewById(Resource.Id.NavigationHeader);
                header.LocateOutlets(this);
            }

            UsernameLabel.Text = ViewModel?.Username;
            EmailLabel.Text = ViewModel?.Email;

            if (!string.IsNullOrEmpty(ViewModel?.ProfileImageUrl))
                ImageExtensions.GetBitmapWithPicasso(ViewModel.ProfileImageUrl).NoFade().Placeholder(Resource.Drawable.avatar_placeholder).CenterCrop().Fit().Into(AvatarView);

            var homeMenu = Menu.AddSubMenu("Home Menu");
            for (int i = 0; i < ViewModel.MenuItems.Count; i++)
            {
                var item = ViewModel.MenuItems[i];
                var menuitem = homeMenu.Add(0,index,index,item.Name);
                menuitem.SetIcon(item.Icon.ToDrawableId());
                CommandsMap[menuitem.ItemId] = item.Command;
                menuitem.SetCheckable(true);
                index++;
            }

            //Edit Profile
            var changeAvatarItem = homeMenu.Add(0, index, index, "Change Profile Photo");
            changeAvatarItem.SetIcon(SharedResources.Icons.User.ToDrawableId());
            CommandsMap[changeAvatarItem.ItemId] = ViewModel.EditProfileCommand;
            changeAvatarItem.SetCheckable(true);
            index++;

            //Sign Out
            var signoutItem = homeMenu.Add(0, index, index, "Sign Out");
            signoutItem.SetIcon(SharedResources.Icons.Exit.ToDrawableId());
            CommandsMap[signoutItem.ItemId] = ViewModel.SignOutCommand;
            signoutItem.SetCheckable(true);
            index++;



            OnOnRequestContent(Menu, ref index);
        }

        public delegate void MenuContentRequestDelegate(IMenu dataRow, ref int index);

        protected virtual void OnOnRequestContent(IMenu menu, ref int index)
        {
            OnRequestContent?.Invoke(menu, ref index);
        }
    }

}