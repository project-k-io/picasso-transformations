//AK package jp.wasabeef.example.picasso;

using System.Collections.Generic;
using Android.Content;

namespace jp.wasabeef.example.picasso
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

    public class Utils {

        public static int toDp(Context context, float dp) {
            float scale = context.Resources.DisplayMetrics.Density;
            return (int) (dp * scale + 0.5f);
        }

        public static List<MaskTypes> CreateMasks()
        {
            var list = new List<MaskTypes>
            {
                MaskTypes.Invert,
                MaskTypes.Mask,
                MaskTypes.NinePatchMask,
                MaskTypes.CropCenterTop,
                MaskTypes.CropCenterCenter,
                MaskTypes.CropCenterBottom,
                MaskTypes.CropSquare,
                MaskTypes.CropCircle,
                MaskTypes.ColorFilter,
                MaskTypes.Grayscale,
                MaskTypes.RoundedCorners,
                MaskTypes.Blur,
                MaskTypes.Toon,
                MaskTypes.Sepia,
                MaskTypes.Contrast,
                MaskTypes.Pixel,
                MaskTypes.Sketch,
                MaskTypes.Swirl,
                MaskTypes.Brightness,
                MaskTypes.Kuawahara,
                MaskTypes.Vignette,
                MaskTypes.CropLeftTop,
                MaskTypes.CropLeftCenter,
                MaskTypes.CropLeftBottom,
                MaskTypes.CropRightTop,
                MaskTypes.CropRightCenter,
                MaskTypes.CropRightBottom,
                MaskTypes.Crop169CenterCenter,
                MaskTypes.Crop43CenterCenter,
                MaskTypes.Crop31CenterCenter,
                MaskTypes.Crop31CenterTop,
                MaskTypes.CropSquareCenterCenter,
                MaskTypes.CropQuarterCenterCenter,
                MaskTypes.CropQuarterCenterTop,
                MaskTypes.CropQuarterBottomRight,
                MaskTypes.CropHalfWidth43CenterCenter
            };

            return list;

        }

    }
}
