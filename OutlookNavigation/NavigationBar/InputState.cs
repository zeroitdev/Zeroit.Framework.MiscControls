// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="InputState.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Indicates what input has been given to the control
    /// </summary>
    public enum InputState
   {
        /// <summary>
        /// Indicates that no input has been given
        /// </summary>
        Normal,

        /// <summary>
        /// Indicates that the user is currently clicking on the control
        /// </summary>
        Clicked,

        /// <summary>
        /// Indicates that the user is currently hovering the control with the mouse
        /// </summary>
        Hovered,
   }
}
