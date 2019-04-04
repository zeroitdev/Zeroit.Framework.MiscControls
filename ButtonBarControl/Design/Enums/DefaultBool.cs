// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="DefaultBool.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Indicates wether borders needs to be shown or not for the <c><see cref="ZeroitToxicButton" /></c>.
    /// </summary>
    public enum ShowBorder
    {
        /// <summary>
        /// Inherit from parent
        /// </summary>
        Inherit,
        /// <summary>
        /// Show borders
        /// </summary>
        Show,
        /// <summary>
        /// Don't show
        /// </summary>
        NotShow
    }
}