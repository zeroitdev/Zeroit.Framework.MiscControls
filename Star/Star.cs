// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Star.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Star    
    /// <summary>
    /// A class collection for rendering a star control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitControlStarDesigner))]
    public class ZeroitControlStar : Control
    {
        #region Variables
        /// <summary>
        /// The star brush
        /// </summary>
        private StarBrush starBrush = StarBrush.SolidBrush;
        /// <summary>
        /// The star point x
        /// </summary>
        private float _StarPointX = 15f;
        /// <summary>
        /// The star point y
        /// </summary>
        private float _StarPointY = 15f;
        /// <summary>
        /// The star radius inner
        /// </summary>
        public float _StarRadiusInner = 3f;  //6f
        /// <summary>
        /// The star radius outer
        /// </summary>
        public float _StarRadiusOuter = 6f; //12f
        /// <summary>
        /// The star grad a point x
        /// </summary>
        private int _StarGradAPointX = 50; //150
        /// <summary>
        /// The star grad a point y
        /// </summary>
        private int _StarGradAPointY = 10;  //30
        /// <summary>
        /// The star grad b point x
        /// </summary>
        private int _StarGradBPointX = 70; //100
        /// <summary>
        /// The star grad b point y
        /// </summary>
        private int _StarGradBPointY = 140; //200
        /// <summary>
        /// The star width
        /// </summary>
        private float _StarWidth = 5;
        /// <summary>
        /// The star color1
        /// </summary>
        private Color _StarColor1 = Color.Gray;
        /// <summary>
        /// The star color2
        /// </summary>
        private Color _StarColor2 = Color.LightGray;
        /// <summary>
        /// The star hover color
        /// </summary>
        private Color _StarHoverColor = Color.Yellow;
        /// <summary>
        /// The star pressed color
        /// </summary>
        private Color _StarPressedColor = Color.Green;
        /// <summary>
        /// The star leave color
        /// </summary>
        private Color _StarLeaveColor = Color.Black;
        /// <summary>
        /// The star color default
        /// </summary>
        private Color _StarColorDefault = Color.Gray;
        /// <summary>
        /// The pen color
        /// </summary>
        private Color penColor = Color.Black;
        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode _Smoothing = SmoothingMode.HighQuality;
        /// <summary>
        /// The pen width
        /// </summary>
        private int penWidth = 3;


        #region HatchBrush

        /// <summary>
        /// The hatch brushgradient1
        /// </summary>
        private Color hatchBrushgradient1 = Color.Black;
        /// <summary>
        /// The hatch brushgradient2
        /// </summary>
        private Color hatchBrushgradient2 = Color.Transparent;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchBrushType hatchBrushType = HatchBrushType.ForwardDiagonal;

        /// <summary>
        /// Enum representing the type of hatch brush
        /// </summary>
        public enum HatchBrushType
        {
            /// <summary>
            /// The backward diagonal
            /// </summary>
            BackwardDiagonal,
            /// <summary>
            /// The cross
            /// </summary>
            Cross,
            /// <summary>
            /// The dark downward diagonal
            /// </summary>
            DarkDownwardDiagonal,
            /// <summary>
            /// The dark horizontal
            /// </summary>
            DarkHorizontal,
            /// <summary>
            /// The dark upward diagonal
            /// </summary>
            DarkUpwardDiagonal,
            /// <summary>
            /// The dark vertical
            /// </summary>
            DarkVertical,
            /// <summary>
            /// The dashed downward diagonal
            /// </summary>
            DashedDownwardDiagonal,
            /// <summary>
            /// The dashed horizontal
            /// </summary>
            DashedHorizontal,
            /// <summary>
            /// The dashed upward diagonal
            /// </summary>
            DashedUpwardDiagonal,
            /// <summary>
            /// The dashed vertical
            /// </summary>
            DashedVertical,
            /// <summary>
            /// The diagonal brick
            /// </summary>
            DiagonalBrick,
            /// <summary>
            /// The diagonal cross
            /// </summary>
            DiagonalCross,
            /// <summary>
            /// The divot
            /// </summary>
            Divot,
            /// <summary>
            /// The dotted diamond
            /// </summary>
            DottedDiamond,
            /// <summary>
            /// The dotted grid
            /// </summary>
            DottedGrid,
            /// <summary>
            /// The forward diagonal
            /// </summary>
            ForwardDiagonal,
            /// <summary>
            /// The horizontal
            /// </summary>
            Horizontal,
            /// <summary>
            /// The horizontal brick
            /// </summary>
            HorizontalBrick,
            /// <summary>
            /// The large checker board
            /// </summary>
            LargeCheckerBoard,
            /// <summary>
            /// The large confetti
            /// </summary>
            LargeConfetti,
            /// <summary>
            /// The large grid
            /// </summary>
            LargeGrid,
            /// <summary>
            /// The light downward diagonal
            /// </summary>
            LightDownwardDiagonal,
            /// <summary>
            /// The light horizontal
            /// </summary>
            LightHorizontal,
            /// <summary>
            /// The light upward diagonal
            /// </summary>
            LightUpwardDiagonal,
            /// <summary>
            /// The light vertical
            /// </summary>
            LightVertical,
            /// <summary>
            /// The maximum
            /// </summary>
            Max,
            /// <summary>
            /// The minimum
            /// </summary>
            Min,
            /// <summary>
            /// The narrow horizontal
            /// </summary>
            NarrowHorizontal,
            /// <summary>
            /// The narrow vertical
            /// </summary>
            NarrowVertical,
            /// <summary>
            /// The outlined diamond
            /// </summary>
            OutlinedDiamond,
            /// <summary>
            /// The percent05
            /// </summary>
            Percent05,
            /// <summary>
            /// The percent10
            /// </summary>
            Percent10,
            /// <summary>
            /// The percent20
            /// </summary>
            Percent20,
            /// <summary>
            /// The percent25
            /// </summary>
            Percent25,
            /// <summary>
            /// The percent30
            /// </summary>
            Percent30,
            /// <summary>
            /// The percent40
            /// </summary>
            Percent40,
            /// <summary>
            /// The percent50
            /// </summary>
            Percent50,
            /// <summary>
            /// The percent60
            /// </summary>
            Percent60,
            /// <summary>
            /// The percent70
            /// </summary>
            Percent70,
            /// <summary>
            /// The percent75
            /// </summary>
            Percent75,
            /// <summary>
            /// The percent80
            /// </summary>
            Percent80,
            /// <summary>
            /// The percent90
            /// </summary>
            Percent90,
            /// <summary>
            /// The plaid
            /// </summary>
            Plaid,
            /// <summary>
            /// The shingle
            /// </summary>
            Shingle,
            /// <summary>
            /// The small checker board
            /// </summary>
            SmallCheckerBoard,
            /// <summary>
            /// The small confetti
            /// </summary>
            SmallConfetti,
            /// <summary>
            /// The small grid
            /// </summary>
            SmallGrid,
            /// <summary>
            /// The solid diamond
            /// </summary>
            SolidDiamond,
            /// <summary>
            /// The sphere
            /// </summary>
            Sphere,
            /// <summary>
            /// The trellis
            /// </summary>
            Trellis,
            /// <summary>
            /// The vertical
            /// </summary>
            Vertical,
            /// <summary>
            /// The wave
            /// </summary>
            Wave,
            /// <summary>
            /// The weave
            /// </summary>
            Weave,
            /// <summary>
            /// The wide downward diagonal
            /// </summary>
            WideDownwardDiagonal,
            /// <summary>
            /// The wide upward diagonal
            /// </summary>
            WideUpwardDiagonal,
            /// <summary>
            /// The zig zag
            /// </summary>
            ZigZag
        }
        #endregion

        #endregion

        #region Properties

        #region HatchBrush Property

        /// <summary>
        /// Gets or sets the gradient color of the hatch brush.
        /// </summary>
        /// <value>The gradient color1 of the hatch brush.</value>
        public Color ColorHatchBrushgradient1
        {
            get { return hatchBrushgradient1; }
            set
            {
                hatchBrushgradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color of the hatch brush.
        /// </summary>
        /// <value>The gradient color2 of the hatch brush.</value>
        public Color ColorHatchBrushgradient2
        {
            get { return hatchBrushgradient2; }
            set
            {
                hatchBrushgradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
        public HatchBrushType HatchBrush
        {
            get
            {
                return hatchBrushType;
            }

            set
            {
                hatchBrushType = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the type of the star.
        /// </summary>
        /// <value>The type of the star.</value>
        public StarBrush StarType
        {
            get { return this.starBrush; }
            set
            {
                starBrush = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the pen.
        /// </summary>
        /// <value>The width of the pen.</value>
        public int PenWidth
        {
            get { return penWidth; }
            set
            {
                penWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad a point x.</value>
        public int StarGradAPointX
        {
            get { return _StarGradAPointX; }
            set
            {
                _StarGradAPointX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad a point y.</value>
        public int StarGradAPointY
        {
            get { return _StarGradAPointY; }
            set
            {
                _StarGradAPointY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad b point x.</value>
        public int StarGradBPointX
        {
            get { return _StarGradBPointX; }
            set
            {
                _StarGradBPointX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad b point y.</value>
        public int StarGradBPointY
        {
            get { return this._StarGradBPointY; }
            set
            {
                _StarGradBPointY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star horizontal point.
        /// </summary>
        /// <value>The star point x.</value>
        public float StarPointX
        {
            get { return _StarPointX; }
            set
            {
                _StarPointX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star vertical point.
        /// </summary>
        /// <value>The star point x.</value>
        public float StarPointY
        {
            get { return this._StarPointY; }
            set
            {
                _StarPointY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star radius inner.
        /// </summary>
        /// <value>The star radius inner.</value>
        public float StarRadiusInner
        {
            get { return _StarRadiusInner; }
            set
            {
                _StarRadiusInner = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star radius outer.
        /// </summary>
        /// <value>The star radius outer.</value>
        public float StarRadiusOuter
        {
            get { return _StarRadiusOuter; }
            set
            {
                _StarRadiusOuter = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get
            {
                return penColor;
            }

            set
            {
                penColor = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color.
        /// </summary>
        /// <value>The star color1.</value>
        public Color StarColor1
        {
            get
            {
                return _StarColor1;
            }

            set
            {
                _StarColor1 = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when the user leaves the control.
        /// </summary>
        /// <value>The star color leave.</value>
        public Color StarColorLeave
        {
            get
            {
                return _StarLeaveColor;
            }

            set
            {
                _StarLeaveColor = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color2.
        /// </summary>
        /// <value>The star color2.</value>
        public Color StarColor2
        {
            get
            {
                return _StarColor2;
            }

            set
            {
                _StarColor2 = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when the user hovers on the control.
        /// </summary>
        /// <value>The star color hover.</value>
        public Color StarColorHover
        {
            get
            {
                return _StarHoverColor;
            }

            set
            {
                _StarHoverColor = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when the control is pressed.
        /// </summary>
        /// <value>The star color pressed.</value>
        public Color StarColorPressed
        {
            get
            {
                return _StarPressedColor;
            }

            set
            {
                _StarPressedColor = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the default star color.
        /// </summary>
        /// <value>The star color default.</value>
        public Color StarColorDefault
        {
            get
            {
                return _StarColorDefault;
            }

            set
            {
                _StarColorDefault = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the width of the star.
        /// </summary>
        /// <value>The width of the star.</value>
        public float StarWidth
        {
            get { return _StarWidth; }
            set
            {
                _StarWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return _Smoothing; }
            set
            {
                _Smoothing = value;
                Invalidate();
            }
        }

        #endregion


        /// <summary>
        /// Enum representing how the star will be rendered
        /// </summary>
        public enum StarBrush
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
        /// Initializes a new instance of the <see cref="ZeroitControlStar" /> class.
        /// </summary>
        public ZeroitControlStar() // contructor
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            //InitializeComponent
            //this.Text = "My drawings"; // title of window form
            this.Size = new Size(30, 30); // size of window form
            //this.Paint += new PaintEventHandler(MyPainting); // install handler
        }

        /// <summary>
        /// Doubles to float.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <returns>System.Single.</returns>
        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseHover(e);
            _StarColor1 = _StarHoverColor;
            this.Invalidate();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _StarColor1 = _StarLeaveColor;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _StarColor1 = _StarHoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            _StarColor1 = _StarPressedColor;
            _StarLeaveColor = _StarPressedColor;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.SmoothingMode = _Smoothing;
            // init 4 stars
            switch (starBrush)
            {
                case StarBrush.SolidBrush:
                    PointF[] Star1 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);
                    SolidBrush FillBrush = new SolidBrush(_StarColor1);
                    G.FillPolygon(FillBrush, Star1);
                    G.DrawPolygon(new Pen(_StarColor1, 5), Star1);
                    //this.Invalidate();
                    break;

                case StarBrush.HatchBrush:
                    PointF[] Star2 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);

                    #region HatchBrush Paint
                    switch (hatchBrushType)
                    {
                        case HatchBrushType.BackwardDiagonal:
                            HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB, Star2);
                            break;
                        case HatchBrushType.Cross:
                            HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB1, Star2);
                            break;
                        case HatchBrushType.DarkDownwardDiagonal:
                            HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB2, Star2);
                            break;
                        case HatchBrushType.DarkHorizontal:
                            HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB3, Star2);
                            break;
                        case HatchBrushType.DarkUpwardDiagonal:
                            HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB4, Star2);
                            break;
                        case HatchBrushType.DarkVertical:
                            HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB5, Star2);
                            break;
                        case HatchBrushType.DashedDownwardDiagonal:
                            HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB6, Star2);
                            break;
                        case HatchBrushType.DashedHorizontal:
                            HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB7, Star2);
                            break;
                        case HatchBrushType.DashedUpwardDiagonal:
                            HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB8, Star2);
                            break;
                        case HatchBrushType.DashedVertical:
                            HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB9, Star2);
                            break;
                        case HatchBrushType.DiagonalBrick:
                            HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBA, Star2);
                            break;
                        case HatchBrushType.DiagonalCross:
                            HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBB, Star2);
                            break;
                        case HatchBrushType.Divot:
                            HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBC, Star2);
                            break;
                        case HatchBrushType.DottedDiamond:
                            HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBD, Star2);
                            break;
                        case HatchBrushType.DottedGrid:
                            HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBE, Star2);
                            break;
                        case HatchBrushType.ForwardDiagonal:
                            HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBF, Star2);
                            break;
                        case HatchBrushType.Horizontal:
                            HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBG, Star2);
                            break;
                        case HatchBrushType.HorizontalBrick:
                            HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBH, Star2);
                            break;
                        case HatchBrushType.LargeCheckerBoard:
                            HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBI, Star2);
                            break;
                        case HatchBrushType.LargeConfetti:
                            HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBJ, Star2);
                            break;
                        case HatchBrushType.LargeGrid:
                            HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBK, Star2);
                            break;
                        case HatchBrushType.LightDownwardDiagonal:
                            HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBL, Star2);
                            break;
                        case HatchBrushType.LightHorizontal:
                            HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBM, Star2);
                            break;
                        case HatchBrushType.LightUpwardDiagonal:
                            HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBN, Star2);
                            break;
                        case HatchBrushType.LightVertical:
                            HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBO, Star2);
                            break;
                        case HatchBrushType.Max:
                            HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBP, Star2);
                            break;
                        case HatchBrushType.Min:
                            HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBQ, Star2);
                            break;
                        case HatchBrushType.NarrowHorizontal:
                            HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBR, Star2);
                            break;
                        case HatchBrushType.NarrowVertical:
                            HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBS, Star2);
                            break;
                        case HatchBrushType.OutlinedDiamond:
                            HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBT, Star2);
                            break;
                        case HatchBrushType.Percent05:
                            HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBU, Star2);
                            break;
                        case HatchBrushType.Percent10:
                            HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBV, Star2);
                            break;
                        case HatchBrushType.Percent20:
                            HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBW, Star2);
                            break;
                        case HatchBrushType.Percent25:
                            HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBX, Star2);
                            break;
                        case HatchBrushType.Percent30:
                            HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBY, Star2);
                            break;
                        case HatchBrushType.Percent40:
                            HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HBZ, Star2);
                            break;
                        case HatchBrushType.Percent50:
                            HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB10, Star2);
                            break;
                        case HatchBrushType.Percent60:
                            HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB11, Star2);
                            break;
                        case HatchBrushType.Percent70:
                            HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB12, Star2);
                            break;
                        case HatchBrushType.Percent75:
                            HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB13, Star2);
                            break;
                        case HatchBrushType.Percent80:
                            HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB14, Star2);
                            break;
                        case HatchBrushType.Percent90:
                            HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB15, Star2);
                            break;
                        case HatchBrushType.Plaid:
                            HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB16, Star2);
                            break;
                        case HatchBrushType.Shingle:
                            HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB17, Star2);
                            break;
                        case HatchBrushType.SmallCheckerBoard:
                            HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB18, Star2);
                            break;
                        case HatchBrushType.SmallConfetti:
                            HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB19, Star2);
                            break;
                        case HatchBrushType.SmallGrid:
                            HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB20, Star2);
                            break;
                        case HatchBrushType.SolidDiamond:
                            HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB21, Star2);
                            break;
                        case HatchBrushType.Sphere:
                            HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB22, Star2);
                            break;
                        case HatchBrushType.Trellis:
                            HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB23, Star2);
                            break;
                        case HatchBrushType.Vertical:
                            HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB24, Star2);
                            break;
                        case HatchBrushType.Wave:
                            HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB25, Star2);
                            break;
                        case HatchBrushType.Weave:
                            HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB26, Star2);
                            break;
                        case HatchBrushType.WideDownwardDiagonal:
                            HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB27, Star2);
                            break;
                        case HatchBrushType.WideUpwardDiagonal:
                            HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB28, Star2);
                            break;
                        case HatchBrushType.ZigZag:
                            HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                            G.FillPolygon(HB29, Star2);
                            break;
                        default:
                            break;
                    }
                    #endregion

                    //HatchBrush pat = new HatchBrush(HatchStyle.Horizontal, _StarColor1, _StarColor2);
                    //G.FillPolygon(pat, Star2);
                    //this.Invalidate();
                    //G.Dispose();
                    //pat.Dispose();
                    break;

                case StarBrush.GradientBrush:
                    PointF[] Star3 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);
                    LinearGradientBrush lin = new LinearGradientBrush(new Point(_StarGradAPointX, _StarGradAPointY), new Point(_StarGradBPointX, _StarGradBPointY), _StarColor1, _StarColor2);

                    G.FillPolygon(lin, Star3);
                    //G.Dispose();
                    //lin.Dispose();
                    //this.Invalidate();
                    break;

                case StarBrush.Pen:
                    PointF[] Star4 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);
                    SolidBrush FillBrush1 = new SolidBrush(_StarColor1);
                    G.DrawPolygon(new Pen(penColor, penWidth), Star4);
                    G.FillPolygon(FillBrush1, Star4);
                    //G.Dispose();

                    //this.Invalidate();
                    break;

                default:
                    break;
            }


        }
        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="Orig">The origin is the middle of the star.</param>
        /// <param name="outerradius">Radius of the surrounding circle.</param>
        /// <param name="innerradius">Radius of the circle for the "inner" points</param>
        /// <returns>Array of 10 PointF structures</returns>
        private PointF[] Calculate5StarPoints(PointF Orig, float outerradius, float innerradius)
        {
            // Define some variables to avoid as much calculations as possible
            // conversions to radians
            double Ang36 = Math.PI / 5.0;   // 36Â° x PI/180
            double Ang72 = 2.0 * Ang36;     // 72Â° x PI/180
            // some sine and cosine values we need
            float Sin36 = (float)Math.Sin(Ang36);
            float Sin72 = (float)Math.Sin(Ang72);
            float Cos36 = (float)Math.Cos(Ang36);
            float Cos72 = (float)Math.Cos(Ang72);
            // Fill array with 10 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig };
            pnts[0].Y -= outerradius;  // top off the star, or on a clock this is 12:00 or 0:00 hours
            pnts[1].X += innerradius * Sin36; pnts[1].Y -= innerradius * Cos36; // 0:06 hours
            pnts[2].X += outerradius * Sin72; pnts[2].Y -= outerradius * Cos72; // 0:12 hours
            pnts[3].X += innerradius * Sin72; pnts[3].Y += innerradius * Cos72; // 0:18
            pnts[4].X += outerradius * Sin36; pnts[4].Y += outerradius * Cos36; // 0:24 
            // Phew! Glad I got that trig working.
            pnts[5].Y += innerradius;
            // I use the symmetry of the star figure here
            pnts[6].X += pnts[6].X - pnts[4].X; pnts[6].Y = pnts[4].Y;  // mirror point
            pnts[7].X += pnts[7].X - pnts[3].X; pnts[7].Y = pnts[3].Y;  // mirror point
            pnts[8].X += pnts[8].X - pnts[2].X; pnts[8].Y = pnts[2].Y;  // mirror point
            pnts[9].X += pnts[9].X - pnts[1].X; pnts[9].Y = pnts[1].Y;  // mirror point
            return pnts;
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitControlStarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitControlStarDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitControlStarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitControlStarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitControlStarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitControlStar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlStarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitControlStarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitControlStar;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the star.
        /// </summary>
        /// <value>The type of the star.</value>
        public Zeroit.Framework.MiscControls.ZeroitControlStar.StarBrush StarType
        {
            get
            {
                return colUserControl.StarType;
            }
            set
            {
                GetPropertyByName("StarType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the pen.
        /// </summary>
        /// <value>The width of the pen.</value>
        public int PenWidth
        {
            get
            {
                return colUserControl.PenWidth;
            }
            set
            {
                GetPropertyByName("PenWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad a point x.
        /// </summary>
        /// <value>The star grad a point x.</value>
        public int StarGradAPointX
        {
            get
            {
                return colUserControl.StarGradAPointX;
            }
            set
            {
                GetPropertyByName("StarGradAPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad a point y.
        /// </summary>
        /// <value>The star grad a point y.</value>
        public int StarGradAPointY
        {
            get
            {
                return colUserControl.StarGradAPointY;
            }
            set
            {
                GetPropertyByName("StarGradAPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad b point x.
        /// </summary>
        /// <value>The star grad b point x.</value>
        public int StarGradBPointX
        {
            get
            {
                return colUserControl.StarGradBPointX;
            }
            set
            {
                GetPropertyByName("StarGradBPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad b point y.
        /// </summary>
        /// <value>The star grad b point y.</value>
        public int StarGradBPointY
        {
            get
            {
                return colUserControl.StarGradBPointY;
            }
            set
            {
                GetPropertyByName("StarGradBPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star point x.
        /// </summary>
        /// <value>The star point x.</value>
        public float StarPointX
        {
            get
            {
                return colUserControl.StarPointX;
            }
            set
            {
                GetPropertyByName("StarPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star point y.
        /// </summary>
        /// <value>The star point y.</value>
        public float StarPointY
        {
            get
            {
                return colUserControl.StarPointY;
            }
            set
            {
                GetPropertyByName("StarPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star radius inner.
        /// </summary>
        /// <value>The star radius inner.</value>
        public float StarRadiusInner
        {
            get
            {
                return colUserControl.StarRadiusInner;
            }
            set
            {
                GetPropertyByName("StarRadiusInner").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star radius outer.
        /// </summary>
        /// <value>The star radius outer.</value>
        public float StarRadiusOuter
        {
            get
            {
                return colUserControl.StarRadiusOuter;
            }
            set
            {
                GetPropertyByName("StarRadiusOuter").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get
            {
                return colUserControl.PenColor;
            }
            set
            {
                GetPropertyByName("PenColor").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color1.
        /// </summary>
        /// <value>The star color1.</value>
        public Color StarColor1
        {
            get
            {
                return colUserControl.StarColor1;
            }
            set
            {
                GetPropertyByName("StarColor1").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color leave.
        /// </summary>
        /// <value>The star color leave.</value>
        public Color StarColorLeave
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color2.
        /// </summary>
        /// <value>The star color2.</value>
        public Color StarColor2
        {
            get
            {
                return colUserControl.StarColor2;
            }
            set
            {
                GetPropertyByName("StarColor2").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color hover.
        /// </summary>
        /// <value>The star color hover.</value>
        public Color StarColorHover
        {
            get
            {
                return colUserControl.StarColorHover;
            }
            set
            {
                GetPropertyByName("StarColorHover").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color pressed.
        /// </summary>
        /// <value>The star color pressed.</value>
        public Color StarColorPressed
        {
            get
            {
                return colUserControl.StarColorPressed;
            }
            set
            {
                GetPropertyByName("StarColorPressed").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color default.
        /// </summary>
        /// <value>The star color default.</value>
        public Color StarColorDefault
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the width of the star.
        /// </summary>
        /// <value>The width of the star.</value>
        public float StarWidth
        {
            get
            {
                return colUserControl.StarWidth;
            }
            set
            {
                GetPropertyByName("StarWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("StarType",
                                 "Pen Width", "Appearance",
                                 "Sets the type of star."));

            items.Add(new DesignerActionPropertyItem("PenWidth",
                                 "Star Type", "Appearance",
                                 "Sets the width of the pen."));

            items.Add(new DesignerActionPropertyItem("StarGradAPointX",
                                 "Star GradA Point X", "Appearance",
                                 "Sets the gradient x-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradAPointY",
                                 "Star GradA Point Y", "Appearance",
                                 "Sets the gradient y-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradBPointX",
                                 "Star GradB Point X", "Appearance",
                                 "Sets the gradient x-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradBPointY",
                                 "Star GradB Point Y", "Appearance",
                                 "Sets the gradient y-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarPointX",
                                 "Star Point X", "Appearance",
                                 "Sets the x-cordinate location of the star."));

            items.Add(new DesignerActionPropertyItem("StarPointY",
                                 "Star Point Y", "Appearance",
                                 "Sets the y-cordinate location of the star."));

            items.Add(new DesignerActionPropertyItem("StarRadiusInner",
                                 "Star Radius Inner", "Appearance",
                                 "Sets the inner radius of the star. Increase in value widens the star."));

            items.Add(new DesignerActionPropertyItem("StarRadiusOuter",
                                 "Star Radius Outer", "Appearance",
                                 "Sets the outer radius of the star. Increase in value increases the size of the star."));

            items.Add(new DesignerActionPropertyItem("PenColor",
                                 "PenColor", "Appearance",
                                 "Sets the color of the star."));

            items.Add(new DesignerActionPropertyItem("StarColor1",
                                 "Star Color1", "Appearance",
                                 "Sets the solid brush color of the star."));

            items.Add(new DesignerActionPropertyItem("StarColor2",
                                 "Star Color2", "Appearance",
                                 "Sets the gradient brush of the star. Not needed though."));

            items.Add(new DesignerActionPropertyItem("StarColorLeave",
                                 "Star Color Leave", "Appearance",
                                 "Sets the color of the star when the mouse leaves the control."));

            items.Add(new DesignerActionPropertyItem("StarColorHover",
                                 "Star Color Hover", "Appearance",
                                 "Sets the hover color of the star when the mouse enters the control."));

            items.Add(new DesignerActionPropertyItem("StarColorPressed",
                                 "Star Color Pressed", "Appearance",
                                 "Sets the color of the star when it is pressed."));

            items.Add(new DesignerActionPropertyItem("StarColorDefault",
                                 "Star Color Default", "Appearance",
                                 "Sets the default color of the star when inactive."));

            items.Add(new DesignerActionPropertyItem("StarWidth",
                                 "Star Width", "Appearance",
                                 "Sets the width of the star."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the smoothing mode of the star."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

    #endregion
}
