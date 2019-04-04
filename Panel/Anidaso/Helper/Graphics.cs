// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="Graphics.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class Graphics.
    /// </summary>
    [DebuggerStepThrough]
    internal class Graphics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Graphics"/> class.
        /// </summary>
        public Graphics()
        {
        }

        /// <summary>
        /// Adds the color.
        /// </summary>
        /// <param name="col1">The col1.</param>
        /// <param name="col2">The col2.</param>
        /// <returns>Color.</returns>
        public static Color AddColor(Color col1, Color col2)
        {
            return Color.FromArgb((col1.R + col2.R) / 2, (col1.G + col2.G) / 2, (col1.B + col2.B) / 2);
        }

        /// <summary>
        /// Gets the color scale.
        /// </summary>
        /// <param name="Passentage">The passentage.</param>
        /// <param name="startColor">The start color.</param>
        /// <param name="endColor">The end color.</param>
        /// <returns>Color.</returns>
        public static Color getColorScale(int Passentage, Color startColor, Color endColor)
        {
            double num = Math.Round((double)startColor.R + (double)((endColor.R - startColor.R) * Passentage) * 0.01, 0);
            int num1 = int.Parse(num.ToString());
            num = Math.Round((double)startColor.G + (double)((endColor.G - startColor.G) * Passentage) * 0.01, 0);
            int num2 = int.Parse(num.ToString());
            num = Math.Round((double)startColor.B + (double)((endColor.B - startColor.B) * Passentage) * 0.01, 0);
            int num3 = int.Parse(num.ToString());
            return Color.FromArgb(255, num1, num2, num3);
        }

        /// <summary>
        /// Overlays the color.
        /// </summary>
        /// <param name="_Image">The image.</param>
        /// <param name="Find">The find.</param>
        /// <param name="Replace">The replace.</param>
        /// <returns>Image.</returns>
        public static Image OverlayColor(Image _Image, Color Find, Color Replace)
        {
            Bitmap bitmap = new Bitmap(_Image);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (!smethod_0(bitmap.GetPixel(j, i)))
                    {
                        bitmap.SetPixel(j, i, Replace);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Overlays the color.
        /// </summary>
        /// <param name="_Image">The image.</param>
        /// <param name="Replace">The replace.</param>
        /// <returns>Image.</returns>
        public static Image OverlayColor(Image _Image, Color Replace)
        {
            Bitmap bitmap = new Bitmap(_Image);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (!smethod_0(bitmap.GetPixel(j, i)))
                    {
                        bitmap.SetPixel(j, i, Replace);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Smethods the 0.
        /// </summary>
        /// <param name="color_0">The color 0.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool smethod_0(Color color_0)
        {
            if (color_0.R != 0 || color_0.G != 0)
            {
                return false;
            }
            return color_0.B == 0;
        }

        /// <summary>
        /// Smoothens the specified img.
        /// </summary>
        /// <param name="_img">The img.</param>
        /// <returns>Image.</returns>
        public static Image Smoothen(Image _img)
        {
            Bitmap bitmap = new Bitmap(_img);
            List<int[]> numArrays = new List<int[]>();
            for (int i = 0; i < bitmap.Height - 1; i++)
            {
                for (int j = 0; j < bitmap.Width - 1; j++)
                {
                    Color[] pixel = new Color[] { bitmap.GetPixel(j, i), default(Color), bitmap.GetPixel(j, i + 1), default(Color) };
                    pixel[1] = bitmap.GetPixel(j + 1, i);
                    pixel[3] = bitmap.GetPixel(j + 1, i + 1);
                    if (pixel[1] == pixel[2] && !smethod_0(pixel[1]) && smethod_0(pixel[0]))
                    {
                        numArrays.Add(new int[] { j, i });
                    }
                    if (pixel[0] == pixel[3] && !smethod_0(pixel[0]) && smethod_0(pixel[2]))
                    {
                        numArrays.Add(new int[] { j, i + 1 });
                    }
                    if (pixel[0] == pixel[3] && !smethod_0(pixel[0]) && smethod_0(pixel[1]))
                    {
                        numArrays.Add(new int[] { j + 1, i });
                    }
                    if (pixel[1] == pixel[2] && !smethod_0(pixel[1]) && smethod_0(pixel[3]))
                    {
                        numArrays.Add(new int[] { j + 1, i + 1 });
                    }
                }
            }
            for (int k = 0; k < numArrays.Count; k++)
            {
                bitmap.SetPixel(numArrays[k][0], numArrays[k][1], AddColor(Color.Yellow, Color.FromArgb(211, 211, 211)));
            }
            return bitmap;
        }
    }
}
