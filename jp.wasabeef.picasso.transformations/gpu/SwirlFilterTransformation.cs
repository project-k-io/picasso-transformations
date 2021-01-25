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

//AK import jp.co.cyberagent.android.gpuimage.filter.GPUImageSwirlFilter;

using Android.Content;
using Android.Graphics;
using JP.CO.Cyberagent.Android.Gpuimage.Filter;

namespace jp.wasabeef.picasso.transformations.gpu
{
    /**
 * Creates a swirl distortion on the image.
 */
    public class SwirlFilterTransformation : GPUFilterTransformation {

        private static  float mRadius;
        private static  float mAngle;
        private static  PointF mCenter;

        public SwirlFilterTransformation(Context context): this(context, .5f, 1.0f, new PointF(.5f, .5f))
        {
    
        }

        /**
   * @param radius from 0.0 to 1.0, default 0.5
   * @param angle  minimum 0.0, default 1.0
   * @param center default (0.5, 0.5)
   */
        public SwirlFilterTransformation(Context context, float radius, float angle, PointF center): base(context, new GPUImageSwirlFilter())
        {
            mRadius = radius;
            mAngle = angle;
            mCenter = center;
            GPUImageSwirlFilter filter = getFilter<GPUImageSwirlFilter>();
            filter.SetRadius(mRadius);
            filter.SetAngle(mAngle);
            filter.SetCenter(mCenter);
        }

        public override string Key => "SwirlFilterTransformation(radius=" + mRadius + ",angle=" + mAngle + ",center=" + mCenter + ")";
    }
}
