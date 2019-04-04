// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="HitArea.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Enum representing Hit Area.
    /// </summary>
    public enum HitArea
    {
        /// <summary>
        /// Hit Nowhere.
        /// </summary>
        None,
        /// <summary>
        /// Hit on a button.
        /// </summary>
        Button,
        /// <summary>
        /// Hit on client other than button.
        /// </summary>
        Client
    }
}