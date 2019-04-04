// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="VisualMarker.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class VisualMarker.
    /// </summary>
    public class VisualMarker
    {
        /// <summary>
        /// The rectangle
        /// </summary>
        public readonly Rectangle rectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualMarker"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public VisualMarker(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="pen">The pen.</param>
        public virtual void Draw(Graphics gr, Pen pen)
        {
        }

        /// <summary>
        /// Gets the cursor.
        /// </summary>
        /// <value>The cursor.</value>
        public virtual Cursor Cursor
        {
            get { return Cursors.Hand; }
        }
    }

    /// <summary>
    /// Class CollapseFoldingMarker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.VisualMarker" />
    public class CollapseFoldingMarker: VisualMarker
    {
        /// <summary>
        /// The i line
        /// </summary>
        public readonly int iLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseFoldingMarker"/> class.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <param name="rectangle">The rectangle.</param>
        public CollapseFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <param name="forePen">The fore pen.</param>
        public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
        {
            //draw minus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
        }
    }

    /// <summary>
    /// Class ExpandFoldingMarker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.VisualMarker" />
    public class ExpandFoldingMarker : VisualMarker
    {
        /// <summary>
        /// The i line
        /// </summary>
        public readonly int iLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandFoldingMarker"/> class.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <param name="rectangle">The rectangle.</param>
        public ExpandFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <param name="forePen">The fore pen.</param>
        public void Draw(Graphics gr, Pen pen,  Brush backgroundBrush, Pen forePen)
        {
            //draw plus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
            gr.DrawLine(forePen, rectangle.Left + rectangle.Width / 2, rectangle.Top + 2, rectangle.Left + rectangle.Width / 2, rectangle.Bottom - 2);
        }
    }

    /// <summary>
    /// Class FoldedAreaMarker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.VisualMarker" />
    public class FoldedAreaMarker : VisualMarker
    {
        /// <summary>
        /// The i line
        /// </summary>
        public readonly int iLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldedAreaMarker"/> class.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <param name="rectangle">The rectangle.</param>
        public FoldedAreaMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="pen">The pen.</param>
        public override void Draw(Graphics gr, Pen pen)
        {
            gr.DrawRectangle(pen, rectangle);
        }
    }

    /// <summary>
    /// Class StyleVisualMarker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.VisualMarker" />
    public class StyleVisualMarker : VisualMarker
    {
        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <value>The style.</value>
        public Style Style{get;private set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleVisualMarker"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="style">The style.</param>
        public StyleVisualMarker(Rectangle rectangle, Style style)
            : base(rectangle)
        {
            this.Style = style;
        }
    }

    /// <summary>
    /// Class VisualMarkerEventArgs.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.MouseEventArgs" />
    public class VisualMarkerEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <value>The style.</value>
        public Style Style { get; private set; }
        /// <summary>
        /// Gets the marker.
        /// </summary>
        /// <value>The marker.</value>
        public StyleVisualMarker Marker { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualMarkerEventArgs"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <param name="marker">The marker.</param>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args)
            : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
        {
            this.Style = style;
            this.Marker = marker;
        }
    }
}
