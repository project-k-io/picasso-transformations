using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace jp.wasabeef.example.picasso
{
    public class ViewHolder : RecyclerView.ViewHolder
    {

        public ImageView image;
        public TextView title;

        public ViewHolder(View itemView) : base(itemView)
        {
            image = itemView.FindViewById<ImageView>(Resource.Id.image);
            title = itemView.FindViewById<TextView>(Resource.Id.title);
        }
    }
}