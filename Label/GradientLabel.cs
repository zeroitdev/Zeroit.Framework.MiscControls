// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GradientLabel.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Gradient Label

    /// <summary>
    /// A class collection for rendering a gradient label.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public class ZeroitLabelGradient : Label
    {
        #region Variables

        /// <summary>
        /// The color1
        /// </summary>
        private Color color1 = Color.Gold;
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2 = Color.Black;
        /// <summary>
        /// The gradient mode
        /// </summary>
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        /// <summary>
        /// The brushtype
        /// </summary>
        private BrushType brushtype = BrushType.Linear;
        #endregion

        #region Enum

        /// <summary>
        /// Enum representing the type of Brush
        /// </summary>
        public enum BrushType
        {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The linear
            /// </summary>
            Linear,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch
        }

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
        /// Enum representing the type of Hatch Brush
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

        /// <summary>
        /// Gets or sets the kind of the brush.
        /// </summary>
        /// <value>The kind of the brush.</value>
        public BrushType BrushKind
        {
            get { return brushtype; }
            set
            {
                brushtype = value;
                Invalidate();
            }
        }

        #region HatchBrush Property

        /// <summary>
        /// Gets or sets the color hatch brushgradient1.
        /// </summary>
        /// <value>The color hatch brushgradient1.</value>
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
        /// Gets or sets the color hatch brushgradient2.
        /// </summary>
        /// <value>The color hatch brushgradient2.</value>
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
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the linear gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelGradient" /> class.
        /// </summary>
        public ZeroitLabelGradient()
        {

        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the formatted text string to the DrawingContext of the control.
            //base.OnPaint(e);
            switch (brushtype)
            {
                case BrushType.Solid:
                    SolidBrush solidbrush = new SolidBrush(color1);
                    e.Graphics.DrawString(Text, Font, solidbrush, 0, 0);
                    break;
                case BrushType.Linear:
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), color1, color2, gradientMode);
                    e.Graphics.DrawString(Text, Font, brush, 0, 0);
                    break;
                case BrushType.Hatch:

                    #region HatchBrush Paint
                    switch (hatchBrushType)
                    {
                        case HatchBrushType.BackwardDiagonal:
                            HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Cross:
                            HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB1, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DarkDownwardDiagonal:
                            HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB2, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DarkHorizontal:
                            HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB3, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DarkUpwardDiagonal:
                            HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB4, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DarkVertical:
                            HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB5, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DashedDownwardDiagonal:
                            HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB6, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DashedHorizontal:
                            HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB7, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DashedUpwardDiagonal:
                            HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB8, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DashedVertical:
                            HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB9, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DiagonalBrick:
                            HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBA, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DiagonalCross:
                            HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBB, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Divot:
                            HatchBrush HBC = new HatchBrush(HatchStyle.Divot, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBC, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DottedDiamond:
                            HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBD, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.DottedGrid:
                            HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBE, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.ForwardDiagonal:
                            HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBF, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Horizontal:
                            HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBG, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.HorizontalBrick:
                            HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBH, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LargeCheckerBoard:
                            HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBI, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LargeConfetti:
                            HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBJ, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LargeGrid:
                            HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBK, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LightDownwardDiagonal:
                            HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBL, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LightHorizontal:
                            HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBM, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LightUpwardDiagonal:
                            HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBN, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.LightVertical:
                            HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBO, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Max:
                            HatchBrush HBP = new HatchBrush(HatchStyle.Max, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBP, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Min:
                            HatchBrush HBQ = new HatchBrush(HatchStyle.Min, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBQ, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.NarrowHorizontal:
                            HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBR, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.NarrowVertical:
                            HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBS, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.OutlinedDiamond:
                            HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBT, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent05:
                            HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBU, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent10:
                            HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBV, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent20:
                            HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBW, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent25:
                            HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBX, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent30:
                            HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBY, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent40:
                            HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, color1, color2);
                            e.Graphics.DrawString(Text, Font, HBZ, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent50:
                            HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB10, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent60:
                            HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB11, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent70:
                            HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB12, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent75:
                            HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB13, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Percent80:
                            HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB14, new Rectangle(0, 0, Width, Height + 5)); ;
                            break;
                        case HatchBrushType.Percent90:
                            HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB15, new Rectangle(0, 0, Width, Height + 5)); ;
                            break;
                        case HatchBrushType.Plaid:
                            HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB16, new Rectangle(0, 0, Width, Height + 5)); ;
                            break;
                        case HatchBrushType.Shingle:
                            HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB17, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.SmallCheckerBoard:
                            HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB18, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.SmallConfetti:
                            HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB19, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.SmallGrid:
                            HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB20, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.SolidDiamond:
                            HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB21, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Sphere:
                            HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB22, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Trellis:
                            HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB23, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Vertical:
                            HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB24, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Wave:
                            HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB25, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.Weave:
                            HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB26, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.WideDownwardDiagonal:
                            HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB27, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.WideUpwardDiagonal:
                            HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB28, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        case HatchBrushType.ZigZag:
                            HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, color1, color2);
                            e.Graphics.DrawString(Text, Font, HB29, new Rectangle(0, 0, Width, Height + 5));
                            break;
                        default:
                            break;
                    }
                    #endregion

                    break;
                default:
                    break;
            }


        }

        #endregion

    }
    #endregion
}
