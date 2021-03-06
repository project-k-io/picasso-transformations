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
//AK import android.graphics.ColorMatrix;
//AK import android.graphics.ColorMatrixColorFilter;
//AK import android.graphics.Paint;

//AK import com.squareup.picasso.Transformation;

    public class GrayscaleTransformation : Object, Square.Picasso.ITransformation {

        public Bitmap Transform(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;

            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmap);
            ColorMatrix saturation = new ColorMatrix();
            saturation.SetSaturation(0f);
            Paint paint = new Paint();
            paint.SetColorFilter(new ColorMatrixColorFilter(saturation));
            canvas.DrawBitmap(source, 0, 0, paint);
            source.Recycle();

            return bitmap;
        }

        public string Key => "GrayscaleTransformation()";
    }
}
