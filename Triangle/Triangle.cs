// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Triangle.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Triangle

    /// <summary>
    /// A class collection for rendering a triangle control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitControlTriangle : Control
    {

        /// <summary>
        /// The height
        /// </summary>
        private int _height;
        /// <summary>
        /// The width
        /// </summary>
        private int _width;
        /// <summary>
        /// The triangle color1
        /// </summary>
        private Color _TriangleColor1 = Color.Gray;
        /// <summary>
        /// The triangle color2
        /// </summary>
        private Color _TriangleColor2 = Color.Gray;

        /// <summary>
        /// The smoothing
        /// </summary>
        SmoothingMode _smoothing;

        /// <summary>
        /// The rotate left
        /// </summary>
        private int _rotateLeft = -1;
        /// <summary>
        /// The rotate right
        /// </summary>
        private int _rotateRight = 1;

        /// <summary>
        /// The rotate triangle
        /// </summary>
        private RotateTriangle _rotateTriangle = RotateTriangle.Right;

        /// <summary>
        /// Enum representing triangle rotation
        /// </summary>
        public enum RotateTriangle
        {
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right,
            /// <summary>
            /// Up
            /// </summary>
            Up,
            /// <summary>
            /// Down
            /// </summary>
            Down
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return _smoothing; }
            set
            {
                if (value == SmoothingMode.Invalid)
                {
                    _smoothing = SmoothingMode.HighQuality;
                    Invalidate();
                }
                _smoothing = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the triangle color.
        /// </summary>
        /// <value>The triangle color1.</value>
        public Color TriangleColor1
        {
            get { return this._TriangleColor1; }
            set
            {
                this._TriangleColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the triangle color.
        /// </summary>
        /// <value>The triangle color2.</value>
        public Color TriangleColor2
        {
            get { return this._TriangleColor2; }
            set
            {
                this._TriangleColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the triangle position.
        /// </summary>
        /// <value>The triangle position.</value>
        public RotateTriangle TrianglePosition
        {
            get { return this._rotateTriangle; }
            set
            {
                this._rotateTriangle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the triangle.
        /// </summary>
        /// <value>The height of the triangle.</value>
        public int TriangleHeight
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                _width = _height / 2;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlTriangle" /> class.
        /// </summary>
        public ZeroitControlTriangle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.ResizeRedraw | ControlStyles.UserPaint | 
                ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, 
                true);

            _height = 50;

            _width = 25;
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics surface = e.Graphics;
            surface.SmoothingMode = _smoothing;

            _height = Width;
            _width = Width / 2;

            SolidBrush brush = new SolidBrush(Color.Blue);
            LinearGradientBrush lin = new LinearGradientBrush(new Point(_width, 0), new Point(_width, _height), _TriangleColor1, _TriangleColor2);
            
            switch (_rotateTriangle)
            {
                case RotateTriangle.Left:
                    Point[] pointsLeft = { new Point(_width, 0), new Point(_width, _height), new Point(0, _width) };
                    //Point[] points = { new Point(25, 0), new Point(25, 50), new Point(0, 25) }; // Rotate Left
                    surface.FillPolygon(lin, pointsLeft);
                    break;
                case RotateTriangle.Right:
                    Point[] pointsRight = { new Point(0, 0), new Point(0, _height), new Point(_width, _width) };
                    //Point[] points = { new Point(25, 0), new Point(25, 50), new Point(0, 25) }; // Rotate Left
                    surface.FillPolygon(lin, pointsRight);
                    break;
                case RotateTriangle.Down:
                    Point[] pointsUp = { new Point(0, 0), new Point(_width, _width), new Point(_height, 0) }; // Rotate Left
                    surface.FillPolygon(lin, pointsUp);
                    break;
                case RotateTriangle.Up:
                    Point[] pointsDown = { new Point(0, _height), new Point(_width, _height - (_height / 2)), new Point(_height, _height) }; // Rotate Left
                    surface.FillPolygon(lin, pointsDown);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Invalidated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.InvalidateEventArgs" /> that contains the event data.</param>
        protected override void OnInvalidated(InvalidateEventArgs e)
        {

            base.OnInvalidated(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Invalidate();
        }
    }
    #endregion
}
