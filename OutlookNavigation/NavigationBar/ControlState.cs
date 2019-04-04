// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="ControlState.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Indicates in what state the control currently is.
    /// </summary>
    public enum ControlState
   {
        /// <summary>
        /// Indicates that the control is in it's normal state
        /// </summary>
        Normal,

        /// <summary>
        /// Indicates the the control is the active control
        /// </summary>
        Active
    }
}
