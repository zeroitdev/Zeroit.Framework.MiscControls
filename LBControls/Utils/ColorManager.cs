// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorManager.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{

    #region Color Manager

    /// <summary>
    /// Manager for color
    /// </summary>
    public class ZeroitLBColorManager : Object
    {
        /// <summary>
        /// Blends the colour.
        /// </summary>
        /// <param name="fg">The fg.</param>
        /// <param name="bg">The bg.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>System.Double.</returns>
        public static double BlendColour(double fg, double bg, double alpha)
        {
            double result = bg + (alpha * (fg - bg));
            if (result < 0.0)
                result = 0.0;
            if (result > 255)
                result = 255;
            return result;
        }

        /// <summary>
        /// Steps the color.
        /// </summary>
        /// <param name="clr">The color.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Color.</returns>
        public static Color StepColor(Color clr, int alpha)
        {
            if (alpha == 100)
                return clr;

            byte a = clr.A;
            byte r = clr.R;
            byte g = clr.G;
            byte b = clr.B;
            float bg = 0;

            int _alpha = Math.Min(alpha, 200);
            _alpha = Math.Max(alpha, 0);
            double ialpha = ((double)(_alpha - 100.0)) / 100.0;

            if (ialpha > 100)
            {
                // blend with white
                bg = 255.0F;
                ialpha = 1.0F - ialpha;  // 0 = transparent fg; 1 = opaque fg
            }
            else
            {
                // blend with black
                bg = 0.0F;
                ialpha = 1.0F + ialpha;  // 0 = transparent fg; 1 = opaque fg
            }

            r = (byte)(ZeroitLBColorManager.BlendColour(r, bg, ialpha));
            g = (byte)(ZeroitLBColorManager.BlendColour(g, bg, ialpha));
            b = (byte)(ZeroitLBColorManager.BlendColour(b, bg, ialpha));

            return Color.FromArgb(a, r, g, b);
        }


    };

    #endregion


}
