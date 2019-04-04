// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ICaptionRandomizer.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls.Tabs.ZeroitKRBTab
{
    /// <summary>
    /// Interface ICaptionRandomizer
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ICaptionRandomizer : IDisposable
    {
        /// <summary>
        /// Determines whether the randomizer effect is enable or not for tab control caption.
        /// </summary>
        /// <value><c>true</c> if this instance is randomizer enabled; otherwise, <c>false</c>.</value>
        bool IsRandomizerEnabled { get; set; }

        /// <summary>
        /// Determines whether the transparency effect is visible or not for tab control caption.
        /// </summary>
        /// <value><c>true</c> if this instance is transparency enabled; otherwise, <c>false</c>.</value>
        bool IsTransparencyEnabled { get; set; }

        /// <summary>
        /// Gets or Sets, the red color component value of the caption bitmap.
        /// </summary>
        /// <value>The red.</value>
        byte Red { get; set; }

        /// <summary>
        /// Gets or Sets, the green color component value of the caption bitmap.
        /// </summary>
        /// <value>The green.</value>
        byte Green { get; set; }

        /// <summary>
        /// Gets or Sets, the blue color component value of the caption bitmap.
        /// </summary>
        /// <value>The blue.</value>
        byte Blue { get; set; }

        /// <summary>
        /// Gets or Sets, the alpha color component value of the caption bitmap.
        /// </summary>
        /// <value>The transparency.</value>
        byte Transparency { get; set; }
    }
}