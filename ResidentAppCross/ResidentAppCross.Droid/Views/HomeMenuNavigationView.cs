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
using MvvmCross.Core.ViewModels;
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
        private IMvxMessenger _eventAggregator;
        private Dictionary<int, ICommand> _commandsMap;
        private HomeMenuRegistry _registry;

        public HomeMenuNavigationView(Context context) : base(context)
        {
        }

        protected HomeMenuNavigationView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public HomeMenuNavigationView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public HomeMenuNavigationView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        [Outlet] public AppCompatTextView EmailLabel { get; set; }
        [Outlet] public AppCompatTextView UsernameLabel { get; set; }
        [Outlet] public CircleImageView AvatarView { get; set; }
        public event MenuContentRequestDelegate OnRequestContent;
        public event Action<object, NavigationItemSelectedEventArgs> BeforeNavigate;

        public HomeMenuViewModel ViewModel => _viewModel ?? (_viewModel = ResolveViewModel());

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }

        public HomeMenuRegistry Registry
        {
            get
            {
                if (_registry == null)
                {
                    _registry = new HomeMenuRegistry(Menu);
                    _registry.OnBeforeSelectItem += OnOnBeforeSelectItem;
                }
                return _registry;
            }
            set { _registry = value; }
        }

        private HomeMenuViewModel ResolveViewModel()
        {
            EventAggregator.SubscribeOnMainThread<HomeMenuUpdatedEvent>(evt =>
            {
                if (evt.Sender == ViewModel) UpdateContent();
            }, MvxReference.Strong);

            NavigationItemSelected += HomeMenuView_NavigationItemSelected;

            return Mvx.Resolve<HomeMenuViewModel>();
        }


        private void HomeMenuView_NavigationItemSelected(object sender, NavigationItemSelectedEventArgs e)
        {
            Registry.Select(e.MenuItem.ItemId);
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


        public void UpdateHeader()
        {
            if (UsernameLabel == null)
            {
                var header = this.FindViewById(Resource.Id.NavigationHeader);
                header.LocateOutlets(this);
            }

            if(UsernameLabel == null || EmailLabel == null || AvatarView == null) throw new Exception("Header structure is incorrect, Outlets were not found");

            UsernameLabel.Text = ViewModel?.Username;
            EmailLabel.Text = ViewModel?.Email;

            if (!string.IsNullOrEmpty(ViewModel?.ProfileImageUrl))
                ImageExtensions.GetBitmapWithPicasso(ViewModel.ProfileImageUrl).NoFade().Placeholder(Resource.Drawable.avatar_placeholder).CenterCrop().Fit().Into(AvatarView);
        }



        private void UpdateContent()
        {
            UpdateHeader();

            Registry.Clear();

            foreach (var item in ViewModel.MenuItems)
            {
                Registry.AddCommand(item.Name, item.Icon.ToDrawableId(),item.Command);
            }

            Registry.AddCommand("Change Profile Photo", SharedResources.Icons.User.ToDrawableId(), ViewModel.EditProfileCommand);

            Registry.AddCommand("Sign Out", SharedResources.Icons.Exit.ToDrawableId(), ViewModel.SignOutCommand);

            Registry.AddCommand("Message Screen", SharedResources.Icons.Exit.ToDrawableId(), new MvxCommand(() =>
            {
                ViewModel.ShowViewModel<MessageDetailsViewModel>(vm => { });
            }));

            Registry.AddCommand("Change Password", SharedResources.Icons.Exit.ToDrawableId(), new MvxCommand(() =>
            {
                ViewModel.ShowViewModel<ChangePasswordViewModel>(vm => { });
            }));

            OnOnRequestContent(Registry);

            Registry.Generate();
        }

        public event Action<HomeMenuRegistry.IRegistryItem> OnBeforeSelectItem;


        public delegate void MenuContentRequestDelegate(HomeMenuRegistry registry);

        protected virtual void OnOnRequestContent(HomeMenuRegistry registry)
        {
            OnRequestContent?.Invoke(registry);
        }

        protected virtual void OnOnBeforeSelectItem(HomeMenuRegistry.IRegistryItem obj)
        {
            OnBeforeSelectItem?.Invoke(obj);
        }
    }



    public class HomeMenuRegistry
    {
        private Dictionary<int, ICommand> _commandsMap;
        private IMenu _menu;
        private int _orderCounter = 0;
        private Dictionary<int, IRegistryItem> _items;
        private IList<IRegistryItem> _templates;

        public HomeMenuRegistry(IMenu menu)
        {
            _menu = menu;
        }

        public Dictionary<int, ICommand> CommandsMap
        {
            get { return _commandsMap ?? (_commandsMap = new Dictionary<int, ICommand>()); }
            set { _commandsMap = value; }
        }

        public Dictionary<int, IRegistryItem> Items
        {
            get { return _items ?? (_items = new Dictionary<int, IRegistryItem>()); }
            set { _items = value; }
        }

        public IList<IRegistryItem> Templates
        {
            get { return _templates ?? (_templates = new List<IRegistryItem>()); }
            set { _templates = value; }
        }

        public void Generate()
        {
            foreach (var template in Templates)
            {
                template.Construct(this);
            }
        }

        public void Clear()
        {
            _menu.Clear();
            Items.Clear();
            Templates.Clear();
            _orderCounter = 0;
        }

        public void AddCommand(string title, int iconId, ICommand command, bool isNavigation = true, bool checkable = true)
        {
            Templates.Add(new CommandItem()
            {
                Command =  command,
                IconId = iconId,
                Title = title,
                IsCheckable = checkable,
                IsNavigation = isNavigation
            });
        }

        public event Action<IRegistryItem> OnBeforeSelectItem;

        public void Select(int itemId)
        {
            if (!Items.ContainsKey(itemId)) return;
            var item = Items[itemId];
            OnOnBeforeSelectItem(item);
            item.Select(this);
        }

        public void Select(CommandItem item)
        {
            if (item.IsCheckable) item.UIItem.SetChecked(true);
            item?.Command?.Execute(null);
        }

        public IMenuItem Construct(CommandItem item)
        {
            var index = _orderCounter++;
            var menuitem = _menu.Add(0, index, index, item.Title);
            menuitem.SetIcon(item.IconId);
            item.UIItem = menuitem;
            Items[menuitem.ItemId] = item;
            menuitem.SetCheckable(item.IsCheckable);
            return menuitem;
        }

        public class CommandItem : IRegistryItem
        {
            public IMenuItem UIItem { get; set; }
            public string Title { get; set; }
            public int IconId { get; set; }
            public bool IsCheckable { get; set; }
            public bool IsNavigation { get; set; }
            public ICommand Command { get; set; }

            public IMenuItem Construct(HomeMenuRegistry registry)
            {
                return registry.Construct(this);
            }

            public void Select(HomeMenuRegistry registry)
            {
                registry.Select(this);
            }
        }

        public interface IRegistryItem
        {
            IMenuItem UIItem { get; set; }
            string Title { get; set; }
            int IconId { get; set; }
            bool IsNavigation { get; set; }
            IMenuItem Construct(HomeMenuRegistry registry);
            void Select(HomeMenuRegistry registry);
        }

        protected virtual void OnOnBeforeSelectItem(IRegistryItem obj)
        {
            OnBeforeSelectItem?.Invoke(obj);
        }
    }

}