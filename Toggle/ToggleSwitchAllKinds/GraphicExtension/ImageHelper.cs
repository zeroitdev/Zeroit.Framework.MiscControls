// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageHelper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.MiscControls
{
    #region ImageHelper
    /// <summary>
    /// Class ImageHelper.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// The color matrix elements
        /// </summary>
        private static float[][] _colorMatrixElements = {
                                            new float[] {(float)0.299, (float)0.299, (float)0.299, 0, 0},
                                            new float[] {(float)0.587, (float)0.587, (float)0.587, 0, 0},
                                            new float[] {(float)0.114, (float)0.114, (float)0.114, 0, 0},
                                            new float[] {0,  0,  0,  1, 0},
                                            new float[] {0, 0, 0, 0, 1}
                                        };

        /// <summary>
        /// The grayscale color matrix
        /// </summary>
        private static ColorMatrix _grayscaleColorMatrix = new ColorMatrix(_colorMatrixElements);

        /// <summary>
        /// Gets the grayscale attributes.
        /// </summary>
        /// <returns>ImageAttributes.</returns>
        public static ImageAttributes GetGrayscaleAttributes()
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(_grayscaleColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return attr;
        }

        /// <summary>
        /// Rescales the image to fit.
        /// </summary>
        /// <param name="imageSize">Size of the image.</param>
        /// <param name="canvasSize">Size of the canvas.</param>
        /// <returns>Size.</returns>
        /// <exception cref="System.Exception">ImageHelper.RescaleImageToFit - Resize failed!</exception>
        public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
        {
            //Code "borrowed" from http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
            // and the Math.Min improvement from http://stackoverflow.com/questions/6501797/resize-image-proportionally-with-maxheight-and-maxwidth-constraints

            // Figure out the ratio
            double ratioX = (double)canvasSize.Width / (double)imageSize.Width;
            double ratioY = (double)canvasSize.Height / (double)imageSize.Height;

            // use whichever multiplier is smaller
            double ratio = Math.Min(ratioX, ratioY);

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(imageSize.Height * ratio);
            int newWidth = Convert.ToInt32(imageSize.Width * ratio);

            Size resizedSize = new Size(newWidth, newHeight);

            if (resizedSize.Width > canvasSize.Width || resizedSize.Height > canvasSize.Height)
            {
                throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
            }

            return resizedSize;
        }
    }

    #endregion
}
