// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="State.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Enum representing State of Button
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Button is Selected
        /// </summary>
        Selected = 5,
        /// <summary>
        /// Button is Disabled
        /// </summary>
        Disabled = 4,
        /// <summary>
        /// Buton has mouse hover
        /// </summary>
        Hover = 2,
        /// <summary>
        /// Button is Selected and Mouse is over button
        /// </summary>
        SelectedHover = 6,
        /// <summary>
        /// Button is in normal State
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Button is pressed
        /// </summary>
        Pressed = 3
    }
}