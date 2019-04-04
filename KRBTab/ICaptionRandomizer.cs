// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ICaptionRandomizer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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