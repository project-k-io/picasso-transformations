//AK package jp.wasabeef.picasso.transformations.internal;

//AK import android.annotation.TargetApi;
//AK import android.content.Context;
//AK import android.graphics.Bitmap;
//AK import android.os.Build;
//AK import android.renderscript.Allocation;
//AK import android.renderscript.Element;
//AK import android.renderscript.RSRuntimeException;
//AK import android.renderscript.RenderScript;
//AK import android.renderscript.ScriptIntrinsicBlur;

using Android.Content;
using Android.Graphics;
using Android.Renderscripts;

namespace jp.wasabeef.picasso.transformations.@internal
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

    public class RSBlur {

        public static Bitmap blur(Context context, Bitmap bitmap, int radius) /*AK throws RSRuntimeException*/ {
            RenderScript rs = null;
            Allocation input = null;
            Allocation output = null;
            ScriptIntrinsicBlur blur = null;
            try {
                rs = RenderScript.Create(context);
                rs.MessageHandler = new RenderScript.RSMessageHandler();
                input = Allocation.CreateFromBitmap(rs, bitmap, Allocation.MipmapControl.MipmapNone, AllocationUsage.Script);
                output = Allocation.CreateTyped(rs, input.Type);
                blur = ScriptIntrinsicBlur.Create(rs, Element.U8_4(rs));

                blur.SetInput(input);
                blur.SetRadius(radius);
                blur.ForEach(output);
                output.CopyTo(bitmap);
            } finally {
                if (rs != null) {
                    rs.Destroy();
                }
                if (input != null) {
                    input.Destroy();
                }
                if (output != null) {
                    output.Destroy();
                }
                if (blur != null) {
                    blur.Destroy();
                }
            }

            return bitmap;
        }
    }
}
