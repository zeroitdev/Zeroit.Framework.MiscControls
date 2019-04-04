// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="AppearanceAction.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Enums representing type of change when appearance is changed.
    /// </summary>
    public enum AppearanceAction
    {
        /// <summary>
        /// Appearance was recreated.
        /// </summary>
        Recreate,
        /// <summary>
        /// Request to paint control.
        /// </summary>
        Repaint,
        /// <summary>
        /// Appearance was updated.
        /// </summary>
        Update
    }
}