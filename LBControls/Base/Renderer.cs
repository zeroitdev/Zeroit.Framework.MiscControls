// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Renderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{

    #region Renderer
    /// <summary>
    /// Renderer interface for all
    /// LBSoft.IndustrialCtrls renderer
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ILBRenderer : IDisposable
    {
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        object Control
        {
            set;
            get;
        }
        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Update();
        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        void Draw(Graphics Gr);
    }
    #endregion


}
