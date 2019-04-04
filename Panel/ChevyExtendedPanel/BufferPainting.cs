// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BufferPainting.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitBufferPanel

    /// <summary>
    /// An extension of the Panel class that enables double buffering(all painting occurs in WM_PAINT
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public class ZeroitBufferPanel : Panel
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBufferPanel"/> class.
        /// </summary>
        protected ZeroitBufferPanel()
        {
            ///set up the control styles so that it support double buffering painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.DoubleBuffer, true);

            UpdateStyles();

        }
        #endregion
    }

    #endregion
}
