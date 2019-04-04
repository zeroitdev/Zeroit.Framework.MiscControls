// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region TextBox    
    /// <summary>
    /// A class collection for rendering a text box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TextBox" />
    public class ZeroitTextBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTextBox" /> class.
        /// </summary>
        public ZeroitTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }

    #endregion
}
