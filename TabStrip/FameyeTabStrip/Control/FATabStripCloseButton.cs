// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FATabStripCloseButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFameyeTabStripCloseButton.
    /// </summary>
    internal class ZeroitFameyeTabStripCloseButton
    {
        #region Fields

        /// <summary>
        /// The cross rect
        /// </summary>
        private Rectangle crossRect = Rectangle.Empty;
        /// <summary>
        /// The is mouse over
        /// </summary>
        private bool isMouseOver = false;
        /// <summary>
        /// The renderer
        /// </summary>
        private ToolStripProfessionalRenderer renderer;

        #endregion

        #region Props

        /// <summary>
        /// Gets or sets a value indicating whether this instance is mouse over.
        /// </summary>
        /// <value><c>true</c> if this instance is mouse over; otherwise, <c>false</c>.</value>
        public bool IsMouseOver
        {
            get { return isMouseOver; }
            set { isMouseOver = value; }
        }

        /// <summary>
        /// Gets or sets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public Rectangle Bounds
        {
            get { return crossRect; }
            set { crossRect = value; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStripCloseButton"/> class.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        internal ZeroitFameyeTabStripCloseButton(ToolStripProfessionalRenderer renderer)
        {
            this.renderer = renderer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the cross.
        /// </summary>
        /// <param name="g">The g.</param>
        public void DrawCross(Graphics g)
        {
            if (isMouseOver)
            {
                Color fill = renderer.ColorTable.ButtonSelectedHighlight;

                g.FillRectangle(new SolidBrush(fill), crossRect);

                Rectangle borderRect = crossRect;

                borderRect.Width--;
                borderRect.Height--;

                g.DrawRectangle(SystemPens.Highlight, borderRect);
            }

            using (Pen pen = new Pen(Color.Black, 1.6f))
            {
                g.DrawLine(pen, crossRect.Left + 3, crossRect.Top + 3,
                    crossRect.Right - 5, crossRect.Bottom - 4);

                g.DrawLine(pen, crossRect.Right - 5, crossRect.Top + 3,
                    crossRect.Left + 3, crossRect.Bottom - 4);
            }
        }

        #endregion
    }
}
