// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FATabStripMenuGlyph.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFameyeTabStripMenuGlyph.
    /// </summary>
    internal class ZeroitFameyeTabStripMenuGlyph
    {
        #region Fields

        /// <summary>
        /// The glyph rect
        /// </summary>
        private Rectangle glyphRect = Rectangle.Empty;
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
            get { return glyphRect; }
            set { glyphRect = value; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStripMenuGlyph"/> class.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        internal ZeroitFameyeTabStripMenuGlyph(ToolStripProfessionalRenderer renderer)
        {
            this.renderer = renderer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the glyph.
        /// </summary>
        /// <param name="g">The g.</param>
        public void DrawGlyph(Graphics g)
        {
            if (isMouseOver)
            {
                Color fill = renderer.ColorTable.ButtonSelectedHighlight; //Color.FromArgb(35, SystemColors.Highlight);
                g.FillRectangle(new SolidBrush(fill), glyphRect);
                Rectangle borderRect = glyphRect;

                borderRect.Width--;
                borderRect.Height--;

                g.DrawRectangle(SystemPens.Highlight, borderRect);
            }

            SmoothingMode bak = g.SmoothingMode;

            g.SmoothingMode = SmoothingMode.Default;

            using (Pen pen = new Pen(Color.Black))
            {
                pen.Width = 2;

                g.DrawLine(pen, new Point(glyphRect.Left + (glyphRect.Width / 3) - 2, glyphRect.Height / 2 - 1),
                    new Point(glyphRect.Right - (glyphRect.Width / 3), glyphRect.Height / 2 - 1));
            }

            g.FillPolygon(Brushes.Black, new Point[]{
                new Point(glyphRect.Left + (glyphRect.Width / 3)-2, glyphRect.Height / 2+2),
                new Point(glyphRect.Right - (glyphRect.Width / 3), glyphRect.Height / 2+2),
                new Point(glyphRect.Left + glyphRect.Width / 2-1,glyphRect.Bottom-4)});

            g.SmoothingMode = bak;
        }

        #endregion
    }
}
