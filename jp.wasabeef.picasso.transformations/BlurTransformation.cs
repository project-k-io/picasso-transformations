//AK package jp.wasabeef.picasso.transformations;

using Android.Content;
using Android.Graphics;
using Android.Renderscripts;
using Java.Lang;
using jp.wasabeef.picasso.transformations.@internal;

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
//AK import android.os.Build;
//AK import android.renderscript.RSRuntimeException;

//AK import com.squareup.picasso.Transformation;

//AK import jp.wasabeef.picasso.transformations.internal.FastBlur;
//AK import jp.wasabeef.picasso.transformations.internal.RSBlur;

    public class BlurTransformation : Object, Square.Picasso.ITransformation {

        private static  int MAX_RADIUS = 25;
        private static  int DEFAULT_DOWN_SAMPLING = 1;

        private static  Context mContext;

        private static  int mRadius;
        private static  int mSampling;

        public BlurTransformation(Context context): this(context, MAX_RADIUS, DEFAULT_DOWN_SAMPLING)
        {
            ;
        }

        public BlurTransformation(Context context, int radius) : this(context, radius, DEFAULT_DOWN_SAMPLING){
            ;
        }

        public BlurTransformation(Context context, int radius, int sampling) {
            mContext = context.ApplicationContext;
            mRadius = radius;
            mSampling = sampling;
        }

  
        public Bitmap Transform(Bitmap source)
        {
            int scaledWidth = source.Width / mSampling;
            int scaledHeight = source.Height / mSampling;

            Bitmap bitmap = Bitmap.CreateBitmap(scaledWidth, scaledHeight, Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmap);
            canvas.Scale(1 / (float)mSampling, 1 / (float)mSampling);
            Paint paint = new Paint();
            paint.Flags = PaintFlags.FilterBitmap;
            canvas.DrawBitmap(source, 0, 0, paint);

            try
            {
                bitmap = RSBlur.blur(mContext, bitmap, mRadius);
            }
            catch (RSRuntimeException e)
            {
                bitmap = FastBlur.blur(bitmap, mRadius, true);
            }

            source.Recycle();

            return bitmap;
        }

        public string Key => "BlurTransformation(radius=" + mRadius + ", sampling=" + mSampling + ")";
    }
}
