// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DigitalBar.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Utils;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable
{
    /// <summary>
    /// Enum SegmentOrientation
    /// </summary>
    public enum SegmentOrientation
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical
    }

    /// <summary>
    /// Enum SegmentCorners
    /// </summary>
    [Flags]
    public enum SegmentCorners
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0x0,
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft = 0x1,
        /// <summary>
        /// The bottom left
        /// </summary>
        BottomLeft = 0x2,
        /// <summary>
        /// The top right
        /// </summary>
        TopRight = 0x4,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight = 0x8,
        /// <summary>
        /// All
        /// </summary>
        All = 0xf,
        //two+ at once
        /// <summary>
        /// The both top
        /// </summary>
        BothTop = 0x5,
        /// <summary>
        /// The both right
        /// </summary>
        BothRight = 0xC,
        /// <summary>
        /// The both bottom
        /// </summary>
        BothBottom = 0xA,
        /// <summary>
        /// The both left
        /// </summary>
        BothLeft = 0x3
    }

    /// <summary>
    /// Class DigitalBar.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable.IDrawable" />
    public class DigitalBar : IDisposable, IDrawable
    {
        #region Public Accessors

        /// <summary>
        /// The color of the bar
        /// </summary>
        /// <value>The color.</value>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color of the bar")]
        [Category("Appearance")]
        public virtual Color Color { get; set; }

        /// <summary>
        /// How opaque the bar is when it is turned off
        /// </summary>
        /// <value>The opacity when off.</value>
        [DefaultValue(0.1d)]
        [Description("How opaque the bar is when it is turned off")]
        [Category("Appearance")]
        public virtual double OpacityWhenOff { get; set; }

        /// <summary>
        /// Whether this segment is on or off
        /// </summary>
        /// <value><c>true</c> if this instance is on; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Whether this segment is on or off")]
        [Category("Appearance")]
        public virtual bool IsOn { get; set; }

        /// <summary>
        /// The corners that are drawn on this segment
        /// </summary>
        /// <value>The corners.</value>
        [DefaultValue(typeof(SegmentCorners), "None")]
        [Description("The corners that are drawn on this segment")]
        [Category("Appearance")]
        public virtual SegmentCorners Corners { get; set; }

        /// <summary>
        /// The horizontal or vertical padding
        /// </summary>
        /// <value>The padding.</value>
        [DefaultValue(0)]
        [Description("The horizontal or vertical padding")]
        [Category("Appearance")]
        public virtual float Padding { get; set; }

        /// <summary>
        /// The length of the tip that would intersect
        /// another segment. This is typically the width of the segment.
        /// </summary>
        /// <value>The length of the tip.</value>
        [DefaultValue(0)]
        [Description("The length of the tip that would intersect another segment")]
        [Category("Appearance")]
        public virtual float TipLength { get; set; }

        #endregion

        /// <summary>
        /// Gets the color of the off.
        /// </summary>
        /// <value>The color of the off.</value>
        protected Color OffColor
        {
            get
            {
                int alphaAmt = (int)(255 * OpacityWhenOff);
                return Color.FromArgb(alphaAmt, Color);
            }
        }

        /// <summary>
        /// The m path
        /// </summary>
        protected GraphicsPath m_path;
        /// <summary>
        /// The m redraw region
        /// </summary>
        protected Region m_redrawRegion;
        /// <summary>
        /// The m orientation
        /// </summary>
        protected SegmentOrientation m_orientation = SegmentOrientation.Horizontal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalBar"/> class.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        public DigitalBar(SegmentOrientation orientation)
        {
            Color = Color.Black;
            OpacityWhenOff = 0.1d;
            IsOn = true;
            m_orientation = orientation;
            Corners = SegmentCorners.None;
            Padding = 0;

            m_redrawRegion = new Region();
            CalculatePaths(new RectangleF());
        }

        /// <summary>
        /// Draws a control onto the graphics
        /// </summary>
        /// <param name="g">The graphics to draw onto</param>
        public virtual void Draw(Graphics g)
        {
            Color color = IsOn ? Color : OffColor;
            using (Brush brush = new SolidBrush(color))
            {
                g.FillPath(brush, m_path);
            }

            //now these areas need to be redrawn if they change
            m_redrawRegion.Dispose();
            m_redrawRegion = new Region();
            m_redrawRegion.Union(m_path);
        }

        /// <summary>
        /// Calculates this controls shape and size that will be used
        /// when it is drawn
        /// </summary>
        /// <param name="container">The allowed space for the control</param>
        public virtual void CalculatePaths(RectangleF container)
        {
            DisposePaths();
            m_path = new GraphicsPath();

            RectangleF rect = container;
            bool bHorizontal = (m_orientation == SegmentOrientation.Horizontal);
            if (bHorizontal)
            {
                rect.Inflate(-Padding, 0);
            }
            else
            {
                rect.Inflate(0, -Padding);
            }

            PointF topLeft = new PointF(rect.Left, rect.Top);
            PointF topRight = new PointF(rect.Right, rect.Top);
            PointF bottomLeft = new PointF(rect.Left, rect.Bottom);
            PointF bottomRight = new PointF(rect.Right, rect.Bottom);

            float xOffset = bHorizontal ? TipLength : 0;
            float yOffset = bHorizontal ? 0 : TipLength;

            PointF topLeftOffset = new PointF(topLeft.X + xOffset, topLeft.Y + yOffset);
            PointF topRightOffset = new PointF(topRight.X - xOffset, topRight.Y + yOffset);
            PointF bottomLeftOffset = new PointF(bottomLeft.X + xOffset, bottomLeft.Y - yOffset);
            PointF bottomRightOffset = new PointF(bottomRight.X - xOffset, bottomRight.Y - yOffset);

            PointF topCenter = new PointF(rect.Left + (rect.Width / 2f), rect.Y + (yOffset / 2f));
            PointF leftCenter = new PointF(rect.Left + (xOffset / 2f), rect.Y + (rect.Height / 2f));
            PointF bottomCenter = new PointF(topCenter.X, rect.Bottom - (yOffset / 2f));
            PointF rightCenter = new PointF(rect.Right - (xOffset / 2f), leftCenter.Y);

            List<PointF> points = new List<PointF>();

            points.Add(leftCenter);
            if (CustomExtensions.IsFlagSet(Corners, SegmentCorners.TopLeft))
            {
                points.Add(topLeft);
            }
            else
            {
                points.Add(topLeftOffset);
                points.Add(topCenter);
            }

            if (CustomExtensions.IsFlagSet(Corners, SegmentCorners.TopRight))
            {
                points.Add(topRight);
            }
            else
            {
                points.Add(topRightOffset);
            }

            if (CustomExtensions.IsFlagSet(Corners, SegmentCorners.BottomRight))
            {
                points.Add(bottomRight);
            }
            else
            {
                points.Add(rightCenter);
                points.Add(bottomRightOffset);
            }

            if (CustomExtensions.IsFlagSet(Corners, SegmentCorners.BottomLeft))
            {
                points.Add(bottomLeft);
            }
            else
            {
                points.Add(bottomCenter);
                points.Add(bottomLeftOffset);
            }

            if (CustomExtensions.IsFlagSet(Corners, SegmentCorners.TopLeft))
            {
                points.Add(topLeft);
            }

            m_path.AddLines(points.ToArray());
            m_path.CloseFigure();

            //these areas need to be redrawn now
            m_redrawRegion.Union(m_path);
        }

        /// <summary>
        /// Gets the region that needs to be redrawn because of changes to the control.
        /// This should be a union of where the control was last drawn and where it needs
        /// to be drawn.
        /// </summary>
        /// <returns>The region affected by this control</returns>
        public virtual Region GetRedrawRegion()
        {
            return m_redrawRegion;
        }

        /// <summary>
        /// Disposes the paths.
        /// </summary>
        protected virtual void DisposePaths()
        {
            if (m_path != null)
            {
                m_path.Dispose();
                m_path = null;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            DisposePaths();

            if (m_redrawRegion != null)
            {
                m_redrawRegion.Dispose();
                m_redrawRegion = null;
            }
        }
    }
}
