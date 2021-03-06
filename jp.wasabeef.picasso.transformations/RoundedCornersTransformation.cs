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
//AK import android.graphics.Paint;
//AK import android.graphics.RectF;
//AK import android.graphics.Shader;

//AK import com.squareup.picasso.Transformation;

    public class RoundedCornersTransformation : Object, Square.Picasso.ITransformation {

        public enum CornerType {
            ALL,
            TOP_LEFT, TOP_RIGHT, BOTTOM_LEFT, BOTTOM_RIGHT,
            TOP, BOTTOM, LEFT, RIGHT,
            OTHER_TOP_LEFT, OTHER_TOP_RIGHT, OTHER_BOTTOM_LEFT, OTHER_BOTTOM_RIGHT,
            DIAGONAL_FROM_TOP_LEFT, DIAGONAL_FROM_TOP_RIGHT
        }

        private static  int mRadius;
        private static  int mDiameter;
        private static  int mMargin;
        private static  CornerType mCornerType;

        public RoundedCornersTransformation(int radius, int margin): this(radius, margin, CornerType.ALL)
        {
        }

        public RoundedCornersTransformation(int radius, int margin, CornerType cornerType) {
            mRadius = radius;
            mDiameter = radius * 2;
            mMargin = margin;
            mCornerType = cornerType;
        }
        public Bitmap Transform(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;

            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);

            Canvas canvas = new Canvas(bitmap);
            Paint paint = new Paint();
            paint.AntiAlias =true;
            paint.SetShader(new BitmapShader(source, Shader.TileMode.Clamp, Shader.TileMode.Clamp));
            DrawRoundRect(canvas, paint, width, height);
            source.Recycle();

            return bitmap;
        }

        private void DrawRoundRect(Canvas canvas, Paint paint, float width, float height) {
            float right = width - mMargin;
            float bottom = height - mMargin;

            switch (mCornerType) {
                case CornerType.ALL:
                    canvas.DrawRoundRect(new RectF(mMargin, mMargin, right, bottom), mRadius, mRadius, paint);
                    break;
                case CornerType.TOP_LEFT:
                    drawTopLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.TOP_RIGHT:
                    drawTopRightRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.BOTTOM_LEFT:
                    drawBottomLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.BOTTOM_RIGHT:
                    drawBottomRightRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.TOP:
                    drawTopRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.BOTTOM:
                    drawBottomRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.LEFT:
                    drawLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.RIGHT:
                    drawRightRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.OTHER_TOP_LEFT:
                    drawOtherTopLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.OTHER_TOP_RIGHT:
                    drawOtherTopRightRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.OTHER_BOTTOM_LEFT:
                    drawOtherBottomLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.OTHER_BOTTOM_RIGHT:
                    drawOtherBottomRightRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.DIAGONAL_FROM_TOP_LEFT:
                    drawDiagonalFromTopLeftRoundRect(canvas, paint, right, bottom);
                    break;
                case CornerType.DIAGONAL_FROM_TOP_RIGHT:
                    drawDiagonalFromTopRightRoundRect(canvas, paint, right, bottom);
                    break;
                default:
                    canvas.DrawRoundRect(new RectF(mMargin, mMargin, right, bottom), mRadius, mRadius, paint);
                    break;
            }
        }

        private void drawTopLeftRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, mMargin + mDiameter, mMargin + mDiameter),
                mRadius, mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin + mRadius, mMargin + mRadius, bottom), paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin, right, bottom), paint);
        }

        private void drawTopRightRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(right - mDiameter, mMargin, right, mMargin + mDiameter), mRadius,
                mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right - mRadius, bottom), paint);
            canvas.DrawRect(new RectF(right - mRadius, mMargin + mRadius, right, bottom), paint);
        }

        private void drawBottomLeftRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, bottom - mDiameter, mMargin + mDiameter, bottom),
                mRadius, mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, mMargin + mDiameter, bottom - mRadius), paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin, right, bottom), paint);
        }

        private void drawBottomRightRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(right - mDiameter, bottom - mDiameter, right, bottom), mRadius,
                mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right - mRadius, bottom), paint);
            canvas.DrawRect(new RectF(right - mRadius, mMargin, right, bottom - mRadius), paint);
        }

        private void drawTopRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, right, mMargin + mDiameter), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin, mMargin + mRadius, right, bottom), paint);
        }

        private void drawBottomRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, bottom - mDiameter, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right, bottom - mRadius), paint);
        }

        private void drawLeftRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, mMargin + mDiameter, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin, right, bottom), paint);
        }

        private void drawRightRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(right - mDiameter, mMargin, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right - mRadius, bottom), paint);
        }

        private void drawOtherTopLeftRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, bottom - mDiameter, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRoundRect(new RectF(right - mDiameter, mMargin, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right - mRadius, bottom - mRadius), paint);
        }

        private void drawOtherTopRightRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, mMargin + mDiameter, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRoundRect(new RectF(mMargin, bottom - mDiameter, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin, right, bottom - mRadius), paint);
        }

        private void drawOtherBottomLeftRoundRect(Canvas canvas, Paint paint, float right, float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, right, mMargin + mDiameter), mRadius, mRadius,
                paint);
            canvas.DrawRoundRect(new RectF(right - mDiameter, mMargin, right, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin, mMargin + mRadius, right - mRadius, bottom), paint);
        }

        private void drawOtherBottomRightRoundRect(Canvas canvas, Paint paint, float right,
            float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, right, mMargin + mDiameter), mRadius, mRadius,
                paint);
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, mMargin + mDiameter, bottom), mRadius, mRadius,
                paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin + mRadius, right, bottom), paint);
        }

        private void drawDiagonalFromTopLeftRoundRect(Canvas canvas, Paint paint, float right,
            float bottom) {
            canvas.DrawRoundRect(new RectF(mMargin, mMargin, mMargin + mDiameter, mMargin + mDiameter),
                mRadius, mRadius, paint);
            canvas.DrawRoundRect(new RectF(right - mDiameter, bottom - mDiameter, right, bottom), mRadius,
                mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin + mRadius, right - mRadius, bottom), paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin, right, bottom - mRadius), paint);
        }

        private void drawDiagonalFromTopRightRoundRect(Canvas canvas, Paint paint, float right,
            float bottom) {
            canvas.DrawRoundRect(new RectF(right - mDiameter, mMargin, right, mMargin + mDiameter), mRadius,
                mRadius, paint);
            canvas.DrawRoundRect(new RectF(mMargin, bottom - mDiameter, mMargin + mDiameter, bottom),
                mRadius, mRadius, paint);
            canvas.DrawRect(new RectF(mMargin, mMargin, right - mRadius, bottom - mRadius), paint);
            canvas.DrawRect(new RectF(mMargin + mRadius, mMargin + mRadius, right, bottom), paint);
        }



        public string Key => "RoundedTransformation(radius=" + mRadius + ", margin=" + mMargin + ", diameter=" + mDiameter + ", cornerType=" + mCornerType + ")";
    }
}
