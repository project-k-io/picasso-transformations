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

//AK import android.content.Context;
//AK import android.graphics.PointF;

//AK import java.util.Arrays;

//AK import jp.co.cyberagent.android.gpuimage.filter.GPUImageVignetteFilter;

using Android.Content;
using Android.Graphics;
using Java.Util;
using JP.CO.Cyberagent.Android.Gpuimage.Filter;

namespace jp.wasabeef.picasso.transformations.gpu
{
    /**
 * Performs a vignetting effect, fading out the image at the edges
 * The directional intensity of the vignetting,
 * with a default of x = 0.5, y = 0.5, start = 0, end = 0.75
 */
    public class VignetteFilterTransformation : GPUFilterTransformation {

        private static  PointF mCenter;
        private static  float[] mVignetteColor;
        private static  float mVignetteStart;
        private static  float mVignetteEnd;

        public VignetteFilterTransformation(Context context): this(context, new PointF(0.5f, 0.5f), new float[] { 0.0f, 0.0f, 0.0f }, 0.0f, 0.75f)
        {
    
        }

        public VignetteFilterTransformation(Context context, PointF center, float[] color, float start, float end): base(context, new GPUImageVignetteFilter())
        {
            mCenter = center;
            mVignetteColor = color;
            mVignetteStart = start;
            mVignetteEnd = end;
            GPUImageVignetteFilter filter = getFilter<GPUImageVignetteFilter>();
            filter.SetVignetteCenter(mCenter);
            filter.SetVignetteColor(mVignetteColor);
            filter.SetVignetteStart(mVignetteStart);
            filter.SetVignetteEnd(mVignetteEnd);
        }

        public override string Key => "VignetteFilterTransformation(center=" + mCenter + ",color=" + Arrays.ToString(mVignetteColor) + ",start=" + mVignetteStart + ",end=" + mVignetteEnd + ")";
    }
}