// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UITypes.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    #region UITypes
    /// <summary>
    /// Enumeration used for various panel types to describe how the
    /// background should be painted (or not painted)
    /// </summary>
    public enum BackgroundStyle
    {
        /// <summary>
        /// No background will be drawn
        /// </summary>
        Transparent,
        /// <summary>
        /// Background will be drawn using <see cref="System.Windows.Forms.Control.BackColor" />
        /// </summary>
        Solid,
        /// <summary>
        /// Background will be drawn using a gradient defined by the control
        /// </summary>
        Gradient
    }
    #endregion
}
