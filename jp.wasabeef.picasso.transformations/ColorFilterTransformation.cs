//AK package jp.wasabeef.picasso.transformations;

using Android.Graphics;
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

//AK import android.graphics.Bitmap;
//AK import android.graphics.Canvas;
//AK import android.graphics.Color;
//AK import android.graphics.Paint;
//AK import android.graphics.PorterDuff;
//AK import android.graphics.PorterDuffColorFilter;

//AK import com.squareup.picasso.Transformation;

    public class ColorFilterTransformation : Object, Square.Picasso.ITransformation {

        private static  Color mColor;

        public ColorFilterTransformation(Color color) {
            mColor = color;
        }

        public Bitmap Transform(Bitmap source)
        {
            if (mColor == Color.Transparent)
            {
                return source;
            }

            int width = source.Width;
            int height = source.Height;

            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmap);
            Paint paint = new Paint();
            paint.AntiAlias = true;
            paint.SetColorFilter(new PorterDuffColorFilter(mColor, PorterDuff.Mode.SrcAtop));
            canvas.DrawBitmap(source, 0, 0, paint);
            source.Recycle();

            return bitmap;
        }

        public string Key => "ColorFilterTransformation(color=" + mColor + ")";
    }
}
