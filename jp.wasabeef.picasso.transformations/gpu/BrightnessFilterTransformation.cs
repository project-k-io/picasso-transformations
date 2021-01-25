using Android.Content;
using JP.CO.Cyberagent.Android.Gpuimage.Filter;

//AK package jp.wasabeef.picasso.transformations.gpu;

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

////AK import jp.co.cyberagent.android.gpuimage.filter.GPUImageBrightnessFilter;

namespace jp.wasabeef.picasso.transformations.gpu
{
    /**
 * brightness value ranges from -1.0 to 1.0, with 0.0 as the normal level
 */
    public class BrightnessFilterTransformation : GPUFilterTransformation {

        private static  float mBrightness;

        public BrightnessFilterTransformation(Context context): this(context, 0.0f)
        {
            ;
        }

        public BrightnessFilterTransformation(Context context, float brightness): base(context, new GPUImageBrightnessFilter())
        {
            mBrightness = brightness;
            GPUImageBrightnessFilter filter = getFilter<GPUImageBrightnessFilter>();
            filter.SetBrightness(mBrightness);
        }

        public override string Key => "BrightnessFilterTransformation(brightness=" + mBrightness + ")";
    }
}
