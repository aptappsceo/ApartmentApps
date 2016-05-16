using System;
using System.Linq;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Maps;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Shared.Fragments;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Components.Navigation;
using ResidentAppCross.Droid.Views.Components.NavigationDrawer;
using ResidentAppCross.Events;
using ResidentAppCross.ViewModels;
using Exception = System.Exception;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ResidentAppCross.Droid.Views
{


    [Activity(Label = "Apartment Apps", 
        MainLauncher = true, 
        NoHistory = false,
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class ApplicationHostActivity : MvxCachingFragmentCompatActivity<ApplicationViewModel>
    {
        private FrameLayout _frame;
        private Toolbar _toolbar;
        private DrawerLayout _drawerLayout;
        private HomeMenuNavigationView _navigationView;
        private UsefulActionBarDrawerToggle _drawerToggle;
        private IMvxMessenger _eventAggregator;
        private Timer _waitTimer;

        public DrawerLayout DrawerLayout
        {
            get { return _drawerLayout ?? (_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.application_host_container)); }
            set { _drawerLayout = value; }
        }

        public Toolbar Toolbar
        {
            get { return _toolbar ?? (_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar)); }
            set { _toolbar = value; }
        }

        public HomeMenuNavigationView HomeMenuView
        {
            get { return _navigationView ?? (_navigationView = FindViewById<HomeMenuNavigationView>(Resource.Id.navigation_view)); }
            set { _navigationView = value; }
        }

        public UsefulActionBarDrawerToggle DrawerToggle
        {
            get { return _drawerToggle ?? (_drawerToggle = new UsefulActionBarDrawerToggle(this, DrawerLayout, Toolbar, Resource.String.drawer_open, Resource.String.drawer_close)); }
            set { _drawerToggle = value; }
        }

        public override void OnBeforeFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnBeforeFragmentChanging(fragmentInfo, transaction);
            transaction.SetCustomAnimations(Android.Resource.Animation.FadeIn, Android.Resource.Animation.FadeOut, Android.Resource.Animation.FadeIn, Android.Resource.Animation.FadeOut);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        public bool IsToolbarVisible
        {
            set
            {
                if (value)
                {
                    Toolbar.Visibility = ViewStates.Visible;
                    SupportActionBar.Show();
                }
                else
                {
                    Toolbar.Visibility = ViewStates.Gone;
                    SupportActionBar.Hide();
                }
            }
        }

        protected override void OnViewModelSet()
        {

            base.OnViewModelSet();

            //Setup content
            SetContentView(Resource.Layout.application_host);

            //Setup action bar
            SetSupportActionBar(Toolbar);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetShowHideAnimationEnabled(true);

            //Setup drawer
            DrawerLayout.AddDrawerListener(DrawerToggle);
            DrawerLayout.Post(() => DrawerToggle.SyncState());

            //Refresh HomeMenuView when we open the drawer
            DrawerToggle.Opening += () => HomeMenuView.Refresh();

            HomeMenuView.OnBeforeSelectItem += item =>
            {
                if (item.IsNavigation)
                {
                    ClearHistoryAndCloseAllFragments();
                    DrawerLayout.CloseDrawers();
                } else if (!item.IsCheckable)
                {
                   DrawerLayout.CloseDrawers();
                }
            };


            this.OnEvent<TaskStarted>(evt => SetTaskRunning(evt.Label));
            this.OnEvent<TaskComplete>(evt => SetTaskComplete(evt.ShouldPrompt, evt.Label, evt.OnPrompted));
            this.OnEvent<TaskFailed>(evt => SetTaskFailed(evt.ShouldPrompt, evt.Label, evt.Reason, evt.OnPrompted));
            this.OnEvent<TaskProgressUpdated>(evt => SetTaskProgress(evt.ShouldPrompt, evt.Label));

        }

        public void ClearHistoryAndCloseAllFragments()
        {
            for (int i = 0; i < SupportFragmentManager.BackStackEntryCount; ++i)
            {
                SupportFragmentManager.PopBackStack();
            }
            GetCurrentCacheableFragmentsInfo().Clear();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //NavigationView.InflateMenu(Resource.Menu.menu_main);
            menu.Clear();
            MenuInflater.Inflate(Resource.Menu.menu_main,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute)
        {
            string fragmentTag = this.GetFragmentTag(request, bundle, fragmentType);
            this.FragmentCacheConfiguration.RegisterFragmentToCache(fragmentTag, fragmentType, request.ViewModelType, fragmentAttribute.AddToBackStack);
            this.ShowFragment(fragmentTag, fragmentAttribute.FragmentContentId, bundle, false, false);
            return true;
        }

        protected override void ShowFragment(string tag, int contentId, Bundle bundle, bool forceAddToBackStack = false,
            bool forceReplaceFragment = false)
        {
            IMvxCachedFragmentInfo cachedFragmentInfo1;
            this.FragmentCacheConfiguration.TryGetValue(tag, out cachedFragmentInfo1);
            IMvxCachedFragmentInfo cachedFragmentInfo2 = (IMvxCachedFragmentInfo)null;
            Android.Support.V4.App.Fragment fragmentById = this.SupportFragmentManager.FindFragmentById(contentId);
            if (fragmentById != null)
                this.FragmentCacheConfiguration.TryGetValue(fragmentById.Tag, out cachedFragmentInfo2);
            if (cachedFragmentInfo1 == null)
                throw new MvxException("Could not find tag: {0} in cache, you need to register it first.", new object[1]
                {
          (object) tag
                });
            MvxCachingFragmentCompatActivity.FragmentReplaceMode fragmentReplaceMode = MvxCachingFragmentCompatActivity.FragmentReplaceMode.ReplaceFragmentAndViewModel;
            if (!forceReplaceFragment)
                fragmentReplaceMode = this.ShouldReplaceCurrentFragment(cachedFragmentInfo1, cachedFragmentInfo2, bundle);
            if (fragmentReplaceMode == MvxCachingFragmentCompatActivity.FragmentReplaceMode.NoReplace)
                return;
            FragmentTransaction transaction = this.SupportFragmentManager.BeginTransaction();
            this.OnBeforeFragmentChanging(cachedFragmentInfo1, transaction);
            cachedFragmentInfo1.ContentId = contentId;
            if (cachedFragmentInfo1.CachedFragment != null && fragmentReplaceMode == MvxCachingFragmentCompatActivity.FragmentReplaceMode.ReplaceFragment)
            {
                (cachedFragmentInfo1.CachedFragment as Android.Support.V4.App.Fragment).Arguments.Clear();
                (cachedFragmentInfo1.CachedFragment as Android.Support.V4.App.Fragment).Arguments.PutAll(bundle);
            }
            else
            {
                cachedFragmentInfo1.CachedFragment = Android.Support.V4.App.Fragment.Instantiate((Context)this, this.FragmentJavaName(cachedFragmentInfo1.FragmentType), bundle) as IMvxFragmentView;
                this.OnFragmentCreated(cachedFragmentInfo1, transaction);
            }
            transaction.Replace(cachedFragmentInfo1.ContentId, cachedFragmentInfo1.CachedFragment as Android.Support.V4.App.Fragment, cachedFragmentInfo1.Tag);
            if (fragmentReplaceMode == MvxCachingFragmentCompatActivity.FragmentReplaceMode.ReplaceFragmentAndViewModel)
                Mvx.GetSingleton<IMvxMultipleViewModelCache>().GetAndClear(cachedFragmentInfo1.ViewModelType, this.GetTagFromFragment(cachedFragmentInfo1.CachedFragment as Android.Support.V4.App.Fragment));
            if (((fragmentById == null ? 0 : (cachedFragmentInfo1.AddToBackStack ? 1 : 0)) | (forceAddToBackStack ? 1 : 0)) != 0)
                transaction.AddToBackStack(cachedFragmentInfo1.Tag);
            this.OnFragmentChanging(cachedFragmentInfo1, transaction);
            transaction.CommitAllowingStateLoss();
            this.SupportFragmentManager.ExecutePendingTransactions();
            this.OnFragmentChanged(cachedFragmentInfo1);
        }

        protected override string FragmentJavaName(Type fragmentType)
        {
            return Java.Lang.Class.FromType(fragmentType).Name;
        }

        public override void OnFragmentCreated(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnFragmentCreated(fragmentInfo, transaction);
        }

        public override void OnFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, FragmentTransaction transaction)
        {
            base.OnFragmentChanging(fragmentInfo, transaction);
        }

        public override bool Close(IMvxViewModel viewModel)
        {
            IMvxCachedFragmentInfo cachedFragmentInfo = GetCurrentCacheableFragmentsInfo().First(x => x.ViewModelType == viewModel.GetType());
            this.CloseFragment(cachedFragmentInfo.Tag, cachedFragmentInfo.ContentId);
            return true;
        }

        protected override FragmentReplaceMode ShouldReplaceCurrentFragment(IMvxCachedFragmentInfo newFragment,
            IMvxCachedFragmentInfo currentFragment, Bundle replacementBundle)
        {
            Fragment fragment = newFragment.CachedFragment as Fragment;
            Bundle bundle = fragment?.Arguments;
            if (bundle == null) return FragmentReplaceMode.ReplaceFragmentAndViewModel;
            IMvxNavigationSerializer navigationSerializer = Mvx.Resolve<IMvxNavigationSerializer>();
            string string1 = bundle.GetString("__mvxViewModelRequest");
            MvxViewModelRequest viewModelRequest1 = navigationSerializer.Serializer.DeserializeObject<MvxViewModelRequest>(string1);
            if (viewModelRequest1 == null)
                return FragmentReplaceMode.ReplaceFragment;
            string string2 = replacementBundle.GetString("__mvxViewModelRequest");
            MvxViewModelRequest viewModelRequest2 = navigationSerializer.Serializer.DeserializeObject<MvxViewModelRequest>(string2);
            if (viewModelRequest2 == null)
                return FragmentReplaceMode.ReplaceFragment;
            bool flag = viewModelRequest1.ParameterValues == viewModelRequest2.ParameterValues || viewModelRequest1.ParameterValues.Count == viewModelRequest2.ParameterValues.Count && !viewModelRequest1.ParameterValues.Except(viewModelRequest2.ParameterValues).Any();
            if (currentFragment?.Tag != newFragment.Tag)
                return flag ? FragmentReplaceMode.ReplaceFragment : FragmentReplaceMode.ReplaceFragmentAndViewModel;
            return flag ? FragmentReplaceMode.NoReplace : FragmentReplaceMode.ReplaceFragmentAndViewModel;
        }

        protected override void CloseFragment(string tag, int contentId)
        {
            var findFragmentById = this.SupportFragmentManager.FindFragmentById(contentId);
            if (findFragmentById == null)
                return;
            this.SupportFragmentManager.PopBackStackImmediate(tag, 1);
        }

        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount >= 1)
            {
                SupportFragmentManager.PopBackStackImmediate();
                if (!FragmentCacheConfiguration.EnableOnFragmentPoppedCallback)
                    return;
                OnFragmentPopped(GetCurrentCacheableFragmentsInfo());
            }
        }

        private static NotificationDialog _progressDialog;

        public static NotificationDialog CurrentDialog
        {
            get { return _progressDialog; }
            set { _progressDialog = value; }
        }

        public static NotificationDialog GetOrCreateDialog(Activity targetActivity)
        {

            if (targetActivity == null) return null;

            if (targetActivity == CurrentDialog?.SourceActivity)
            {
                return CurrentDialog;
            }

            DismissCurrentDialog();
            CurrentDialog = new NotificationDialog()
            {
                SourceActivity = targetActivity
            };

            CurrentDialog.Show(targetActivity.FragmentManager, "notification");
            CurrentDialog.OnceOnDismiss(() => CurrentDialog = null);

            return CurrentDialog;

        }

        public static void DismissCurrentDialog()
        {
            CurrentDialog?.Dismiss();
            CurrentDialog = null;
        }

        private bool _nextWaitingBlock = false;
        private string _nextWaitingString = null;

        public void SetTaskRunning(string label, bool block = true)
        {
            _nextWaitingBlock = block;
            _nextWaitingString = label;
            WaitTimer.Start();
        }

        public Timer WaitTimer
        {
            get
            {
                if (_waitTimer == null)
                {
                    _waitTimer = new Timer(250f) {AutoReset = false};
                    _waitTimer.Elapsed += (s, e) =>
                    {

                        DrawerLayout.Post(() =>
                        {
                            if (_nextWaitingBlock && !string.IsNullOrEmpty(_nextWaitingString))
                            {
                                var dialog = GetOrCreateDialog(this);
                                dialog.Mode = NotificationDialogMode.Progress;
                                dialog.TitleText = _nextWaitingString;
                                dialog.SubTitleText = Resource.String.please_wait.GetResourceString();
                                dialog.ShouldDismissWhenClickedOutside = false;
                            }
                            else
                            {
                                //DismissCurrentDialog();
                            }
                        });

                    };

                }
                return _waitTimer;
            }
            set { _waitTimer = value; }
        }

        public void SetTaskProgress(bool prompt, string label)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
                dialog.Mode = NotificationDialogMode.Progress;
                dialog.TitleText = label;
                dialog.SubTitleText = Resource.String.please_wait.GetResourceString();
                dialog.ShouldDismissWhenClickedOutside = false;
            }
            else
            {
                DismissCurrentDialog();
            }
        }

        public void SetTaskComplete(bool prompt, string label = null, Action onPrompted = null)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
                dialog.Mode = NotificationDialogMode.Complete;
                dialog.TitleText = label;
                dialog.SubTitleText = null;
                dialog.ShouldDismissWhenClickedOutside = true;
                dialog.OnceOnDismiss(onPrompted);
                dialog.SetActions(new[] { new NotificationDialogItem() { Action = () => { }, Title = Resource.String.ok.GetResourceString(), ShouldDismiss = true } });
            }
            else
            {
                DismissCurrentDialog();
                onPrompted?.Invoke();
            }

        }

        public void SetTaskFailed(bool prompt, string label = null, Exception reason = null, Action<Exception> onPrompted = null)
        {
            WaitTimer?.Stop();
            _nextWaitingBlock = false;

            if (prompt && !string.IsNullOrEmpty(label))
            {
                var dialog = GetOrCreateDialog(this);
                dialog.Mode = NotificationDialogMode.Failed;
                dialog.TitleText = Resource.String.problem_occurred.GetResourceString();
                dialog.SubTitleText = label;
                dialog.ShouldDismissWhenClickedOutside = true;
                if (onPrompted != null) dialog.OnceOnDismiss(() => onPrompted?.Invoke(reason));
            }
            else
            {
                DismissCurrentDialog();
                onPrompted?.Invoke(reason);
            }
        }

        public void OnEvent<TMessage>(Action<TMessage> handler) where TMessage : MvxMessage
        {
            EventAggregator.Subscribe<TMessage>(evt =>
            {
                DrawerLayout.Post(() =>
                {
                    try
                    {
                        handler(evt);
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine(x.Message);
                    }
                });
            } ,MvxReference.Strong);
        }

        public IMvxMessenger EventAggregator
        {
            get { return _eventAggregator ?? (_eventAggregator = Mvx.Resolve<IMvxMessenger>()); }
            set { _eventAggregator = value; }
        }
    }

}