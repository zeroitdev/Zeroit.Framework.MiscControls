// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Shadow.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a shadow control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitRectShadowPanel : Control
    {

        #region Enumeration

        /// <summary>
        /// Enum representing the type of shadow
        /// </summary>
        public enum TypeOfZeroitRectShadowPanel
        {
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// The polygonal
            /// </summary>
            Polygonal
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// The shadow type
        /// </summary>
        private TypeOfZeroitRectShadowPanel _shadowType = TypeOfZeroitRectShadowPanel.Rectangle;

        /// <summary>
        /// The transparency
        /// </summary>
        private float transparency = 10;

        /// <summary>
        /// The color
        /// </summary>
        public Color color = Color.Black;

        #endregion

        #region Public Properties

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the type of the shadow.
        /// </summary>
        /// <value>The type of the shadow.</value>
        public TypeOfZeroitRectShadowPanel ZeroitRectShadowPanelType
        {
            get { return _shadowType; }
            set
            {
                _shadowType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transparency.
        /// </summary>
        /// <value>The transparency.</value>
        public float Transparency
        {
            get { return transparency; }
            set
            {
                transparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRectShadowPanel" /> class.
        /// </summary>
        public ZeroitRectShadowPanel()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            
        }

        #endregion

        #region PolyGon Code

        #region Variables        
        /// <summary>
        /// Enum representing the type of brush to use for rendering.
        /// </summary>
        public enum PolygonBrush
        {
            /// <summary>
            /// The solid brush
            /// </summary>
            SolidBrush,
            /// <summary>
            /// The hatch brush
            /// </summary>
            HatchBrush,
            /// <summary>
            /// The gradient brush
            /// </summary>
            GradientBrush,
            /// <summary>
            /// The pen
            /// </summary>
            Pen

        }

        /// <summary>
        /// The star brush
        /// </summary>
        private PolygonBrush starBrush = PolygonBrush.SolidBrush;
        /// <summary>
        /// The polygon color
        /// </summary>
        private Color _PolygonColor = Color.Gray;
        /// <summary>
        /// The polygon pen color
        /// </summary>
        private Color _PolygonPenColor = Color.DarkGray;
        /// <summary>
        /// The polygon pen width
        /// </summary>
        private float _PolygonPenWidth = 1;
        /// <summary>
        /// The polygon smoothing
        /// </summary>
        private SmoothingMode _PolygonSmoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 10;
        /// <summary>
        /// The starting angle
        /// </summary>
        private int startingAngle = 90;
        /// <summary>
        /// The center
        /// </summary>
        Point center;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the polygon sides.
        /// </summary>
        /// <value>The polygon sides.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 3.</exception>
        public Int32 PolygonSides
        {
            get { return sides; }
            set
            {
                if (value < 3)
                {
                    sides = 3;
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 3.");
                }
                sides = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon radius.
        /// </summary>
        /// <value>The polygon radius.</value>
        public Int32 PolygonRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon starting angle.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return startingAngle; }
            set
            {
                startingAngle = value;
                this.Invalidate();
            }
        }

        //public Color PolygonPenColor
        //{
        //    get { return _PolygonPenColor; }
        //    set
        //    {
        //        _PolygonPenColor = value;
        //        this.Invalidate();
        //    }
        //}

        //public float PolygonPenWidth
        //{
        //    get { return _PolygonPenWidth; }
        //    set
        //    {
        //        _PolygonPenWidth = value;
        //        this.Invalidate();
        //    }
        //}

        //public Color PolygonColor
        //{
        //    get
        //    {
        //        return this._PolygonColor;
        //    }

        //    set
        //    {
        //        this._PolygonColor = value;
        //        this.Invalidate();
        //    }

        //}


        #endregion

        #region Private Methods

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 sides or more.</exception>
        private Point[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Point.</returns>
        private Point DegreesToXY(float degrees, float radius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
        }

        #endregion

        /******************************** Paint Event ******************************
         center = new Point(this.Width / 2, this.Height / 2);
  
         Point[] PolyGon1 = CalculateVertices(sides, radius, startingAngle, center);
         SolidBrush FillBrush = new SolidBrush(_PolygonColor);
         G.FillPolygon(FillBrush, PolyGon1);
         G.DrawPolygon(new Pen(_PolygonPenColor, _PolygonPenWidth), PolyGon1);
         
         ***************************************************************************/

        #endregion

        #region Rounded Control

        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The solid color
        /// </summary>
        private SolidBrush solidColor;

        /// <summary>
        /// The radius upper left
        /// </summary>
        private Int32 _RadiusUpperLeft = 10;
        /// <summary>
        /// The radius upper right
        /// </summary>
        private Int32 _RadiusUpperRight = 10;
        /// <summary>
        /// The radius bottom left
        /// </summary>
        private Int32 _RadiusBottomLeft = 10;
        /// <summary>
        /// The radius bottom right
        /// </summary>
        private Int32 _RadiusBottomRight = 10;

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;


        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The radius upper left.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperLeft
        {
            get { return this._RadiusUpperLeft; }
            set
            {
                if (_RadiusUpperLeft == null)
                {
                    this._RadiusUpperLeft = 10;

                }


                this._RadiusUpperLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius upper right.</value>
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperRight
        {
            get { return this._RadiusUpperRight; }
            set
            {
                if (_RadiusUpperRight == null)
                {
                    this._RadiusUpperRight = 10;

                }

                this._RadiusUpperRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom left.</value>
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomLeft
        {
            get { return this._RadiusBottomLeft; }
            set
            {
                if (_RadiusBottomLeft == null)
                {
                    this._RadiusBottomLeft = 10;

                }

                this._RadiusBottomLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom right.</value>
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomRight
        {
            get { return this._RadiusBottomRight; }
            set
            {
                if (_RadiusBottomRight == null)
                {
                    this._RadiusBottomRight = 10;

                }

                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="color">The color.</param>
        /// <param name="rect">The rect.</param>
        public void DrawRoundedRectangle(PaintEventArgs e, Color color, Rectangle rect)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Shape = new GraphicsPath();
            Rectangle R1 = rect;
            //Rectangle R1 = new Rectangle(0, 0, Width, Height);

            // Button Background Colors
            solidColor = new SolidBrush(color);

            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();

            g.FillPath(solidColor, Shape);
            g.DrawPath(new Pen(borderColor, borderWidth), Shape);

        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
                        
            Graphics g = e.Graphics;
            g.SmoothingMode = smoothing;

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle region = new Rectangle(1, 1, Width - 2, Height - 2);

            center = new Point(this.Width / 2, this.Height / 2);
            radius = (Width / 4) + (Height / 4) - 2;

            switch (_shadowType)
            {
                case TypeOfZeroitRectShadowPanel.Circle:
                    g.FillEllipse(new SolidBrush(Color.FromArgb(Convert.ToInt32((transparency / 100) * 255f), color)), region);
                    break;
                case TypeOfZeroitRectShadowPanel.Rectangle:
                    DrawRoundedRectangle(e, Color.FromArgb(Convert.ToInt32((transparency / 100f) * 255f), color), region);
                    //g.FillRectangle(new SolidBrush(Color.FromArgb(Convert.ToInt32((transparency / 100f) * 255f), color)), region);
                    break;
                case TypeOfZeroitRectShadowPanel.Polygonal:

                    Point[] PolyGon1 = CalculateVertices(sides, radius, startingAngle, center);
                    SolidBrush FillBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32((transparency / 100f) * 255f), color));
                    g.FillPolygon(FillBrush, PolyGon1);
                    //g.DrawPolygon(new Pen(_PolygonPenColor, _PolygonPenWidth), PolyGon1);

                    break;
                default:
                    break;
            }

            


        }
                
    }
}
