using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform;
using RecyclerViewAnimators.Adapters;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Interfaces;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views
{

    public static class MapViewExtensions
    {
        public static void BindLifecycleProvider<TDL>(this MapView map, TDL lifecycle)
            where TDL : ILifecycleProvider, IDisposableContainer
        {
            map.OnCreate(Bundle.Empty);
            lifecycle.DestroyEvent += map.OnDestroy;
            lifecycle.PauseEvent += map.OnPause;
            lifecycle.LowMemoryEvent += map.OnLowMemory;
            lifecycle.ResumeEvent += map.OnResume;
            lifecycle.SaveInstanceState += map.OnSaveInstanceState;
            lifecycle.CreateEvent += map.OnCreate;
            new Disposable(() =>
            {
                lifecycle.DestroyEvent -= map.OnDestroy;
                lifecycle.PauseEvent -= map.OnPause;
                lifecycle.LowMemoryEvent -= map.OnLowMemory;
                lifecycle.ResumeEvent -= map.OnResume;
                lifecycle.SaveInstanceState -= map.OnSaveInstanceState;
                lifecycle.CreateEvent -= map.OnCreate;
            }).DisposeWith(lifecycle);
        }
    }

    public class MapSection : FragmentSection
    {
        [Outlet]
        public MapView Map { get; set; }
        [Outlet]
        public TextView Label { get; set; }


        public void SetLifecycleProvider<TDL>(TDL lifecycle) where TDL : ILifecycleProvider, IDisposableContainer
        {
            Map.BindLifecycleProvider(lifecycle);
        }

        private void OnCreate(Bundle obj)
        {
            Map.OnCreate(obj);   
        }

        private void OnSaveInstance(Bundle obj)
        {
            Map.OnSaveInstanceState(obj);
        }

        private void OnResume()
        {
            Map.OnResume();
        }

        private void OnLowMemory()
        {
            Map.OnLowMemory();
        }

        private void OnPause()
        {
            Map.OnPause();
        }

        private void OnDestroy()
        {
            Map.OnDestroy();
        }
    }

    public class GallerySection : FragmentSection
    {
        private bool _editable;

        [Outlet]
        public ViewGroup GallerySectionEmptyContainer { get; set; }

        [Outlet]
        public ViewGroup GallerySectionGalleryContainer { get; set; }

        [Outlet]
        public TextView HeaderLabel { get; set; }

        [Outlet]
        public Button AddPhotoButton1 { get; set; }

        [Outlet]
        public Button AddPhotoButton2 { get; set; }

        [Outlet]
        public RecyclerView ImageContainer { get; set; }

        public GallerySectionAdapter Adapter { get; set; }

        public bool Editable
        {
            get { return _editable; }
            set
            {
                _editable = value;
                if (value)
                {
                    AddPhotoButton1.Visibility = AddPhotoButton2.Visibility = ViewStates.Visible;
                }
                else
                {
                    AddPhotoButton1.Visibility = AddPhotoButton2.Visibility = ViewStates.Invisible;
                }
            }
        }

        public override void OnInflated()
        {
            base.OnInflated();
            Adapter = new GallerySectionAdapter();

            Adapter.ItemSelected = (item) =>
            {
                if (item.Data != null)
                {
                    Mvx.Resolve<IDialogService>().OpenImageFullScreen(item.Data);
                }
                else if (item.Uri != null)
                {
                    Mvx.Resolve<IDialogService>().OpenImageFullScreenFromUrl(item.Uri.ToString());
                }
            };
            ImageContainer.SetItemAnimator(new SlideInUpAnimator());
            ImageContainer.SetLayoutManager(new StaggeredGridLayoutManager(2, StaggeredGridLayoutManager.Horizontal));
            ImageContainer.SetAdapter(new SlideInLeftAnimationAdapter(Adapter));

            Editable = false;

            UpdateContainers();
        }

        public void Bind(ImageBundleViewModel vm)
        {
            Adapter.Items = vm?.RawImages;
            UpdateContainers();

            AddPhotoButton1.Click += async (sender, args) =>
            {
                await AddPhoto();
            };

            AddPhotoButton2.Click += async (sender, args) =>
            {
                await AddPhoto();
            };
            vm.RawImages.CollectionChanged += (sender, args) => View.Post(UpdateContainers);

         

        }

        public async Task AddPhoto()
        {
            var service = Mvx.Resolve<IDialogService>();
            var photo = await service.OpenImageDialog();
            if (photo != null)
            {
                Adapter.Items.Add(new ImageBundleItemViewModel() { Data = photo });
            }
            UpdateContainers();
        }

        private void UpdateContainers()
        {
            if (!Adapter?.Items?.Any() ?? true)
            {
                GallerySectionEmptyContainer.Visibility = ViewStates.Visible;
                GallerySectionGalleryContainer.Visibility = ViewStates.Gone;
            }
            else
            {
                GallerySectionEmptyContainer.Visibility = ViewStates.Gone;
                GallerySectionGalleryContainer.Visibility = ViewStates.Visible;
            } 
        }


        public class GallerySectionAdapter : GenericRecyclerAdapter<GenericViewHolder<AsyncImageView>>
        {
            private ObservableCollection<ImageBundleItemViewModel> _items;


            public ObservableCollection<ImageBundleItemViewModel> Items
            {
                get { return _items; }
                set
                {
                    _items = value;
                    this.BindToCollection(_items);
                }
            }

            //public int? ItemHeight;

//            public Object GetItem(int position)
//            {
//                return null;
//            }

            public int GetCount()
            {
                return Items?.Count ?? 0;
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override void OnBind(GenericViewHolder<AsyncImageView> holder, int position)
            {
                if(position >= Items.Count) return; 
                var photo = Items[position];

                if (photo.Uri != null)
                {
                    holder.View.SetImage(photo.Uri.ToString(), null);
                }
                else if (photo.Data != null)
                {
                    holder.View.SetImage(photo.Data);
                }
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                var item = new AsyncImageView(parent.Context) { UsageMode = AspectAwareImageView.ImageMeasureMode.HorisontalLayout }.WithHeightWrapContent().WithWidthWrapContent();
                item.TargetHeight = parent.Height/2;
                var viewHolder = new GenericViewHolder<AsyncImageView>(item);
                item.Click += (sender, args) =>
                {
                    ItemSelected?.Invoke(Items[viewHolder.AdapterPosition]);
                };

                return viewHolder;
            }

            public Action<ImageBundleItemViewModel> ItemSelected { get; set; }

            public override int ItemCount => Items?.Count ?? 0;

        }

    }

    public static class ObjectExtensions
    {
        public static string GetDisposedLogMessage(this object obj)
        {
            return $"{obj.GetType().Name} was finalized at {DateTime.Now.ToString("G")}";
        }
    }

    public static class ImageGalleryUtils
    {
        public static ImageBundleViewModel GetTestAsyncImages()
        {

            var imageBundle = new ImageBundleViewModel();
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://i.cbc.ca/1.3376224.1450794847!/fileImage/httpImage/image.jpg_gen/derivatives/4x3_620/tundra-tea-toss.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "https://timedotcom.files.wordpress.com/2015/12/scott-kelly-photograph-iss-9th-month02.jpg?quality=75&strip=color&w=838"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "https://timedotcom.files.wordpress.com/2015/12/top-100-photos-of-the-year-2015-087.jpg?quality=75&strip=color&w=838"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri = new Uri("http://www.self.com/wp-content/uploads/2016/01/birth-photo-2.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://i2.cdn.turner.com/cnnnext/dam/assets/160107172135-33-week-in-photos-0107-restricted-super-169.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://www.telegraph.co.uk/content/dam/Travel/leadAssets/34/97/comedy-hamster_3497562a-large.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/bkg-start.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri = new Uri("https://www.google.com/photos/about/images/auto-awesome/motion-module/motion-1.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://images.nationalgeographic.com/wpf/media-live/photos/000/911/cache/man-ocean-phytoplankton_91111_600x450.jpg"),
                        });
                        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://i2.cdn.turner.com/cnnnext/dam/assets/160201140511-05-china-moon-surface-photos-super-169.jpg"),
                        });
        imageBundle.RawImages.Add(new ImageBundleItemViewModel()
                        {
                            Uri =
                                new Uri(
                                    "http://b.static.trunity.net/files/299501_299600/299598/vertical-farming-chris-jacobs.jpg"),
                        });

            return imageBundle;

        }
    }


}