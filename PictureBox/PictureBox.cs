// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PictureBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitPictureBox

    /// <summary>
    /// A class collection for rendering for picture box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.PictureBox" />
    public class ZeroitPictureBox : PictureBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPictureBox" /> class.
        /// </summary>
        public ZeroitPictureBox()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

        }
    }
    #endregion
}
