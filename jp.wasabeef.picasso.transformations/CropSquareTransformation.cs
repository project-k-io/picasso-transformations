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

//AK import com.squareup.picasso.Transformation;

    public class CropSquareTransformation : Object, Square.Picasso.ITransformation {

        private int mWidth;
        private int mHeight;

        public Bitmap Transform(Bitmap source)
        {
            int size = Math.Min(source.Width, source.Height);

            mWidth = (source.Width - size) / 2;
            mHeight = (source.Height - size) / 2;

            Bitmap bitmap = Bitmap.CreateBitmap(source, mWidth, mHeight, size, size);
            if (bitmap != source)
            {
                source.Recycle();
            }

            return bitmap;
        }

        public string Key => "CropSquareTransformation(width=" + mWidth + ", height=" + mHeight + ")";
    }
}
