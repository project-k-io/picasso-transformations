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
//AK import android.graphics.BitmapShader;
//AK import android.graphics.Canvas;
//AK import android.graphics.Matrix;
//AK import android.graphics.Paint;

//AK import com.squareup.picasso.Transformation;

    public class CropCircleTransformation : Object, Square.Picasso.ITransformation {


        public Bitmap Transform(Bitmap source)
        {
            int size = Math.Min(source.Width, source.Height);

            int width = (source.Width - size) / 2;
            int height = (source.Height - size) / 2;

            Bitmap bitmap = Bitmap.CreateBitmap(size, size, Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmap);
            Paint paint = new Paint();
            BitmapShader shader =
                new BitmapShader(source, BitmapShader.TileMode.Clamp, BitmapShader.TileMode.Clamp);
            if (width != 0 || height != 0)
            {
                // source isn't square, move viewport to center
                Matrix matrix = new Matrix();
                matrix.SetTranslate(-width, -height);
                shader.SetLocalMatrix(matrix);
            }
            paint.SetShader(shader);
            paint.AntiAlias =true;

            float r = size / 2f;
            canvas.DrawCircle(r, r, r, paint);

            source.Recycle();

            return bitmap;
        }

        public string Key => "CropCircleTransformation()";
    }
}
