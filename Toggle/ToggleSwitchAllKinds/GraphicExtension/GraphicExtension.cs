// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GraphicExtension.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region Graphic Extension Methods
    /// <summary>
    /// Class GraphicsExtensionMethods.
    /// </summary>
    public static class GraphicsExtensionMethods
    {
        /// <summary>
        /// To the gray scale.
        /// </summary>
        /// <param name="originalColor">Color of the original.</param>
        /// <returns>Color.</returns>
        public static Color ToGrayScale(this Color originalColor)
        {
            if (originalColor.Equals(Color.Transparent))
                return originalColor;

            int grayScale = (int)((originalColor.R * .299) + (originalColor.G * .587) + (originalColor.B * .114));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }
    }

    #endregion
}
