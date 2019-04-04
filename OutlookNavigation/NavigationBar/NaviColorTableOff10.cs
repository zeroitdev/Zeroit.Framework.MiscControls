// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff10.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviColorTableOff10.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviColorTableOff7" />
    public class NaviColorTableOff10 : NaviColorTableOff7
   {
        // General colors 
        /// <summary>
        /// Gets the dark outlines.
        /// </summary>
        /// <value>The dark outlines.</value>
        public virtual Color DarkOutlines { get { return Color.FromArgb(187, 195, 205); } }
        /// <summary>
        /// Gets the light outlines.
        /// </summary>
        /// <value>The light outlines.</value>
        public virtual Color LightOutlines { get { return Color.FromArgb(239, 244, 250); } }
        /// <summary>
        /// Gets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public virtual Color TextColor { get { return Color.FromArgb(39, 52, 67); } }

        // NaviButton Normal
        /// <summary>
        /// Gets the button light.
        /// </summary>
        /// <value>The button light.</value>
        public override Color ButtonLight { get { return Color.FromArgb(219, 225, 231); } }
        /// <summary>
        /// Gets the button dark.
        /// </summary>
        /// <value>The button dark.</value>
        public override Color ButtonDark { get { return Color.FromArgb(219, 225, 231); } }
   }
}
