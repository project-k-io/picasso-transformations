//AK package jp.wasabeef.example.picasso;

//AK import android.content.Context;
//AK import android.graphics.Color;
//AK import android.graphics.PointF;
//AK import android.view.LayoutInflater;
//AK import android.view.View;
//AK import android.view.ViewGroup;
//AK import android.widget.ImageView;
//AK import android.widget.TextView;

//AK import androidx.recyclerview.widget.RecyclerView;

//AK import com.squareup.picasso.Picasso;

//AK import java.util.List;

//AK import jp.wasabeef.picasso.transformations.BlurTransformation;
//AK import jp.wasabeef.picasso.transformations.ColorFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.CropCircleTransformation;
//AK import jp.wasabeef.picasso.transformations.CropSquareTransformation;
//AK import jp.wasabeef.picasso.transformations.CropTransformation;
//AK import jp.wasabeef.picasso.transformations.GrayscaleTransformation;
//AK import jp.wasabeef.picasso.transformations.MaskTransformation;
//AK import jp.wasabeef.picasso.transformations.RoundedCornersTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.BrightnessFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.ContrastFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.InvertFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.KuwaharaFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.PixelationFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.SepiaFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.SketchFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.SwirlFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.ToonFilterTransformation;
//AK import jp.wasabeef.picasso.transformations.gpu.VignetteFilterTransformation;

using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Java.Lang;
using jp.wasabeef.picasso.transformations;
using jp.wasabeef.picasso.transformations.gpu;
using Square.Picasso;

namespace jp.wasabeef.example.picasso
{
    /**
 * Created by Wasabeef on 2015/01/11.
 */
    public class MainAdapter : RecyclerView.Adapter
    {

        private Context mContext;
        private List<MaskTypes> mDataSet;


        public MainAdapter(Context context, List<MaskTypes> dataSet)
        {
            mContext = context;
            mDataSet = dataSet;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(mContext).Inflate(Resource.Layout.layout_list_item, parent, false);
            return new ViewHolder(v);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder1, int position)
        {
            ViewHolder holder = (ViewHolder)holder1;
            switch (mDataSet[position])
            {
                case MaskTypes.Mask:
                {
                    int width = Utils.toDp(mContext, 266.66f);
                    int height = Utils.toDp(mContext, 252.66f);

                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Resize(width, height)
                        .CenterCrop()
                        .Transform((new MaskTransformation(mContext, Resource.Drawable.mask_starfish)))
                        .Into(holder.image);
                    break;
                }
                case MaskTypes.NinePatchMask:
                {
                    int width = Utils.toDp(mContext, 300.0f);
                    int height = Utils.toDp(mContext, 200.0f);
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Resize(width, height)
                        .CenterCrop()
                        .Transform(new MaskTransformation(mContext, Resource.Drawable.chat_me_mask))
                        .Into(holder.image);
                    break;
                }
                case MaskTypes.CropLeftTop:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.LEFT,
                            CropTransformation.GravityVertical.TOP))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropLeftCenter:
                    Picasso.Get().Load(Resource.Drawable.demo)
                        // 300, 100, CropTransformation.GravityHorizontal.LEFT, CropTransformation.GravityVertical.CENTER))
                        .Transform(new CropTransformation(300, 100)).Into(holder.image);
                    break;
                case MaskTypes.CropLeftBottom:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.LEFT,
                            CropTransformation.GravityVertical.BOTTOM))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropCenterTop:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.TOP))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropCenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropCenterBottom:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.BOTTOM))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropRightTop:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.RIGHT,
                            CropTransformation.GravityVertical.TOP))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropRightCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.RIGHT,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropRightBottom:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(300, 100, CropTransformation.GravityHorizontal.RIGHT,
                            CropTransformation.GravityVertical.BOTTOM))
                        .Into(holder.image);
                    break;
                case MaskTypes.Crop169CenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)16 / (float)9,
                            CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.Crop43CenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)4 / (float)3,
                            CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.Crop31CenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(3, CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.Crop31CenterTop:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(3, CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.TOP))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropSquareCenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation(1, CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropQuarterCenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)0.5, (float)0.5,
                            CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropQuarterCenterTop:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)0.5, (float)0.5,
                            CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.TOP))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropQuarterBottomRight:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)0.5, (float)0.5,
                            CropTransformation.GravityHorizontal.RIGHT,
                            CropTransformation.GravityVertical.BOTTOM))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropHalfWidth43CenterCenter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropTransformation((float)0.5, 0, (float)4 / (float)3,
                            CropTransformation.GravityHorizontal.CENTER,
                            CropTransformation.GravityVertical.CENTER))
                        .Into(holder.image);
                    break;
                case MaskTypes.CropSquare:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropSquareTransformation())
                        .Into(holder.image);
                    break;
                case MaskTypes.CropCircle:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new CropCircleTransformation())
                        .Into(holder.image);
                    break;
                case MaskTypes.ColorFilter:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new ColorFilterTransformation(Color.Argb(80, 255, 0, 0)))
                        .Into(holder.image);
                    break;
                case MaskTypes.Grayscale:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new GrayscaleTransformation())
                        .Into(holder.image);
                    break;
                case MaskTypes.RoundedCorners:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new RoundedCornersTransformation(120, 0,
                            RoundedCornersTransformation.CornerType.DIAGONAL_FROM_TOP_LEFT))
                        .Into(holder.image);
                    break;
                case MaskTypes.Blur:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new BlurTransformation(mContext, 25, 1))
                        .Into(holder.image);
                    break;
                case MaskTypes.Toon:
                    Picasso.Get()
                        .Load(Resource.Drawable.demo)
                        .Transform(new ToonFilterTransformation(mContext))
                        .Into(holder.image);
                    break;
                case MaskTypes.Sepia:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new SepiaFilterTransformation(mContext))
                        .Into(holder.image);
                    break;
                case MaskTypes.Contrast:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new ContrastFilterTransformation(mContext, 2.0f))
                        .Into(holder.image);
                    break;
                case MaskTypes.Invert:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new InvertFilterTransformation(mContext))
                        .Into(holder.image);
                    break;
                case MaskTypes.Pixel:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new PixelationFilterTransformation(mContext, 20))
                        .Into(holder.image);
                    break;
                case MaskTypes.Sketch:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new SketchFilterTransformation(mContext))
                        .Into(holder.image);
                    break;
                case MaskTypes.Swirl:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new SwirlFilterTransformation(mContext, 0.5f, 1.0f, new PointF(0.5f, 0.5f)))
                        .Into(holder.image);

                    break;
                case MaskTypes.Brightness:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new BrightnessFilterTransformation(mContext, 0.5f))
                        .Into(holder.image);
                    break;
                case MaskTypes.Kuawahara:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new KuwaharaFilterTransformation(mContext, 25))
                        .Into(holder.image);
                    break;
                case MaskTypes.Vignette:
                    Picasso.Get()
                        .Load(Resource.Drawable.check)
                        .Transform(new VignetteFilterTransformation(mContext, new PointF(0.5f, 0.5f),
                            new float[] { 0.0f, 0.0f, 0.0f }, 0f, 0.75f))
                        .Into(holder.image);
                    break;
            }

            var dd = mDataSet[position];
            holder.title.Text  = dd.ToString();
        }




        public override int ItemCount => mDataSet.Count;
    }
}