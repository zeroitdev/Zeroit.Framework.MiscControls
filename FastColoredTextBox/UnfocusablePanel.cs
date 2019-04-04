// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UnfocusablePanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class UnfocusablePanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [System.ComponentModel.ToolboxItem(false)]
    public class UnfocusablePanel : UserControl
    {
        /// <summary>
        /// Gets or sets the back color2.
        /// </summary>
        /// <value>The back color2.</value>
        public Color BackColor2 { get; set; }
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public new string Text { get; set; }
        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfocusablePanel"/> class.
        /// </summary>
        public UnfocusablePanel()
        {
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(ClientRectangle, BackColor2, BackColor, 90))
                e.Graphics.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            using(var pen = new Pen(BorderColor))
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            if (!string.IsNullOrEmpty(Text))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = TextAlignment;
                sf.LineAlignment = StringAlignment.Center;
                using(var brush = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Text, Font, brush, new RectangleF(1, 1, ClientSize.Width - 2, ClientSize.Height - 2), sf);
            }
        }
    }
}
