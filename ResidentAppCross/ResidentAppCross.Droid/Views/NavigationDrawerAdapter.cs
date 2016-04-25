using System.Collections.ObjectModel;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ResidentAppCross.Droid.Views.Components.NavigationDrawer
{
    public class NavigationDrawerAdapter : RecyclerView.Adapter
    {

        public ObservableCollection<HomeMenuItemViewModel> Items { get; set; }
        public LayoutInflater Inflater { get; set; }
        public Context Context { get; set; }

        public NavigationDrawerAdapter(Context ctx, ObservableCollection<HomeMenuItemViewModel> items)
        {
            Context = ctx;
            Inflater = LayoutInflater.From(ctx);
            Items = items;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = Inflater.Inflate(Resource.Layout.nav_item_main, parent, false);
            return new ViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as ViewHolder;
            if (vh != null) vh.Title = Items[position].Name;
        }

        public override int ItemCount => Items?.Count ?? 0;

        public class ViewHolder : RecyclerView.ViewHolder
        {

            public ViewHolder(View itemView) : base(itemView)
            {
                View = itemView;
                TitleLabel = View.FindViewById<TextView>(Resource.Id.title);
            }

            public TextView TitleLabel { get; set; }

            public View View { get; set; }

            public string Title
            {
                get { return TitleLabel.Text; }
                set { TitleLabel.Text = value; }
            }
        }


    }
}