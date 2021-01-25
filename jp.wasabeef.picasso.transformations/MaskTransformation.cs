//AK package jp.wasabeef.picasso.transformations;

using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.Lang;

namespace jp.wasabeef.picasso.transformations
{
    /**
 * Copyright (C) 2020 Wasabeef
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

//AK import android.content.Context;
//AK import android.graphics.Bitmap;
//AK import android.graphics.Canvas;
//AK import android.graphics.Paint;
//AK import android.graphics.PorterDuff;
//AK import android.graphics.PorterDuffXfermode;
//AK import android.graphics.drawable.Drawable;

//AK import com.squareup.picasso.Transformation;

    public class MaskTransformation : Object, Square.Picasso.ITransformation
    {

        private static Paint mMaskingPaint = new Paint();
        private static Context mContext;
        private static int mMaskId;
        static MaskTransformation()
        {
            mMaskingPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
        }

        //static {
        //}

        /**
   * @param maskId If you change the mask file, please also rename the mask file, or Glide will get
   *               the cache with the old mask. Because getId() return the same values if using the
   *               same make file name. If you have a good idea please tell us, thanks.
   */
        public MaskTransformation(Context context, int maskId)
        {
            mContext = context.ApplicationContext;
            mMaskId = maskId;
        }


        public Bitmap Transform(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;

            Bitmap result = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);

            Drawable mask = mContext.GetDrawable(mMaskId);

            Canvas canvas = new Canvas(result);
            mask.SetBounds(0, 0, width, height);
            mask.Draw(canvas);
            canvas.DrawBitmap(source, 0, 0, mMaskingPaint);

            source.Recycle();

            return result;
        }

        public string Key => "MaskTransformation(maskId=" + mContext.Resources.GetResourceEntryName(mMaskId) + ")";
    }
}
