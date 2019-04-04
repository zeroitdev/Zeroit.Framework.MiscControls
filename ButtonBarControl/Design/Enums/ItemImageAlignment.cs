// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="ItemImageAlignment.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Enum having options for <see cref="BarItem.ImageAlignment" /> property.
    /// </summary>
    public enum ItemImageAlignment
    {
        /// <summary>
        /// Align as per Parent alignment
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// Align to left
        /// </summary>
        Left = 1,
        /// <summary>
        /// Align to right
        /// </summary>
        Right = 2,
        /// <summary>
        /// Align to top
        /// </summary>
        Top = 3,
        /// <summary>
        /// Align to bottom
        /// </summary>
        Bottom = 4
    }
}