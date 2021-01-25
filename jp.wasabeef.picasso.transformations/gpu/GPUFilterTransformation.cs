using Android.Content;
using Android.Graphics;
using Java.Lang;
using JP.CO.Cyberagent.Android.Gpuimage.Filter;
using JP.CyberAgent.GpuImageLib;

// //AK package jp.wasabeef.picasso.transformations.gpu;

namespace jp.wasabeef.picasso.transformations.gpu
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

////AK import android.content.Context;
////AK import android.graphics.Bitmap;

////AK import com.squareup.picasso.Transformation;

////AK import jp.co.cyberagent.android.gpuimage.GPUImage;
////AK import jp.co.cyberagent.android.gpuimage.filter.GPUImageFilter;

    public class GPUFilterTransformation : Object, Square.Picasso.ITransformation
    {

        private Context mContext;
        private GPUImageFilter mFilter;

        public GPUFilterTransformation(Context context, GPUImageFilter filter)
        {
            mContext = context.ApplicationContext;
            mFilter = filter;
        }

        // @SuppressWarnings("unchecked")
        public T getFilter<T>() where T : GPUImageFilter
        {
            return (T)mFilter;
        }

        public Bitmap Transform(Bitmap source)
        {
            var gpuImage = new GPUImage(mContext);
            gpuImage.SetImage(source);
            gpuImage.SetFilter(mFilter);

            var bitmap = gpuImage.BitmapWithFilterApplied;
            source.Recycle();

            return bitmap;
        }

        public virtual string Key => Class?.SimpleName;
    }
}
