// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="OnOffSwitch.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitOnOff    
    /// <summary>
    /// A class collection for rendering a switch control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ThemeControl154" />
    [Designer(typeof(ZeroitSwitchOnOffDesigner))]
    public class ZeroitSwitchOnOff : ThemeControl154
    {
        #region Variables
        /// <summary>
        /// The tb
        /// </summary>
        Brush TB;
        /// <summary>
        /// The b
        /// </summary>
        Pen b;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked = false;
        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        /// <summary>
        /// The gradient color1
        /// </summary>
        private Color gradientColor1 = Color.FromArgb(120, 120, 120);
        /// <summary>
        /// The gradient color2
        /// </summary>
        private Color gradientColor2 = Color.FromArgb(100, 100, 100);
        /// <summary>
        /// The hatch color1
        /// </summary>
        private Color hatchColor1 = Color.FromArgb(10, Color.White);
        /// <summary>
        /// The hatch color2
        /// </summary>
        private Color hatchColor2 = Color.Transparent;
        /// <summary>
        /// The border1
        /// </summary>
        private Color border1 = Color.FromArgb(200, 200, 200);
        /// <summary>
        /// The border2
        /// </summary>
        private Color border2 = Color.FromArgb(150, 150, 150);
        /// <summary>
        /// The border3
        /// </summary>
        private Color border3 = Color.FromArgb(125, 125, 125);
        /// <summary>
        /// The text color
        /// </summary>
        private Color textColor = Color.FromArgb(125, 125, 125);
        /// <summary>
        /// The on text
        /// </summary>
        private string onText = "On";
        /// <summary>
        /// The off text
        /// </summary>
        private string offText = "Off";

        /// <summary>
        /// The on location x
        /// </summary>
        private static int onLocationX = 36;
        /// <summary>
        /// The on location y
        /// </summary>
        private static int onLocationY = 6;

        /// <summary>
        /// The off location x
        /// </summary>
        private static int offLocationX = 5;
        /// <summary>
        /// The off location y
        /// </summary>
        private static int offLocationY = 6;

        /// <summary>
        /// The location
        /// </summary>
        int[] location = { onLocationX, onLocationY, offLocationX, offLocationY };

        #region HatchBrush Enum

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
        /// Enum representing the Hatch Brush Type
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
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public int[] Locations
        {
            get
            {
                return location;
            }

            set
            {

                location = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the on text.
        /// </summary>
        /// <value>The on text.</value>
        public String OnText
        {
            get { return onText; }
            set
            {
                onText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the off text.
        /// </summary>
        /// <value>The off text.</value>
        public String OffText
        {
            get { return offText; }
            set
            {
                offText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color GradientColor1
        {
            get { return gradientColor1; }
            set
            {
                gradientColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color GradientColor2
        {
            get { return gradientColor2; }
            set
            {
                gradientColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hatch color.
        /// </summary>
        /// <value>The hatch color1.</value>
        public Color HatchColor1
        {
            get { return hatchColor1; }
            set
            {
                hatchColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hatch color.
        /// </summary>
        /// <value>The hatch color2.</value>
        public Color HatchColor2
        {
            get { return hatchColor2; }
            set
            {
                hatchColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border1.</value>
        public Color Border1
        {
            get { return border1; }
            set
            {
                border1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border2.</value>
        public Color Border2
        {
            get { return border2; }
            set
            {
                border2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border3.</value>
        public Color Border3
        {
            get { return border3; }
            set
            {
                border3 = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;

                Invalidate();
            }
        }

        #region HatchBrush Property        
        /// <summary>
        /// Gets or sets the color hatch brushgradient.
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
        /// Gets or sets the color hatch brushgradient.
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
        /// Gets or sets a value indicating whether this <see cref="ZeroitSwitchOnOff" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }

        #endregion

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, G);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset, G);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G);
        }
        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
                _Checked = false;
            else
                _Checked = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSwitchOnOff"/> class.
        /// </summary>
        public ZeroitSwitchOnOff()
        {
            LockHeight = 24;
            LockWidth = 62;
            SetColor("Texts", textColor);
            SetColor("border", border3);

        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            TB = GetBrush("Texts");
            b = GetPen("border");
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {


            G.Clear(BackColor);
            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), gradientColor1, gradientColor2, 90);
            //HatchBrush HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchColor1, hatchColor2);

            if (_Checked)
            {
                G.FillRectangle(LGB1, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));

                #region HatchBrush Paint
                switch (hatchBrushType)
                {
                    case HatchBrushType.BackwardDiagonal:
                        HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Cross:
                        HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB1, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DarkDownwardDiagonal:
                        HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB2, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DarkHorizontal:
                        HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB3, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DarkUpwardDiagonal:
                        HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB4, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DarkVertical:
                        HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB5, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DashedDownwardDiagonal:
                        HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB6, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DashedHorizontal:
                        HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB7, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DashedUpwardDiagonal:
                        HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB8, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DashedVertical:
                        HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB9, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DiagonalBrick:
                        HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBA, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DiagonalCross:
                        HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBB, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Divot:
                        HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBC, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DottedDiamond:
                        HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBD, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.DottedGrid:
                        HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBE, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.ForwardDiagonal:
                        HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBF, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Horizontal:
                        HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBG, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.HorizontalBrick:
                        HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBH, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LargeCheckerBoard:
                        HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBI, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LargeConfetti:
                        HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBJ, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LargeGrid:
                        HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBK, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LightDownwardDiagonal:
                        HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBL, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LightHorizontal:
                        HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBM, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LightUpwardDiagonal:
                        HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBN, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.LightVertical:
                        HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBO, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Max:
                        HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBP, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Min:
                        HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBQ, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.NarrowHorizontal:
                        HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBR, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.NarrowVertical:
                        HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBS, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.OutlinedDiamond:
                        HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBT, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent05:
                        HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBU, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent10:
                        HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBV, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent20:
                        HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBW, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent25:
                        HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBX, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent30:
                        HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBY, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent40:
                        HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBZ, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent50:
                        HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB10, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent60:
                        HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB11, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent70:
                        HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB12, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent75:
                        HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB13, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent80:
                        HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB14, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Percent90:
                        HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB15, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Plaid:
                        HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB16, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Shingle:
                        HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB17, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.SmallCheckerBoard:
                        HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB18, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.SmallConfetti:
                        HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB19, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.SmallGrid:
                        HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB20, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.SolidDiamond:
                        HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB21, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Sphere:
                        HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB22, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Trellis:
                        HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB23, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Vertical:
                        HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB24, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Wave:
                        HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB25, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.Weave:
                        HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB26, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.WideDownwardDiagonal:
                        HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB27, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.WideUpwardDiagonal:
                        HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB28, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    case HatchBrushType.ZigZag:
                        HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB29, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                        break;
                    default:
                        break;
                }
                #endregion

                //G.FillRectangle(HB1, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));


                G.DrawString(onText, Font, TB, new Point(location[0], location[1]));
            }
            else if (!_Checked)
            {
                G.FillRectangle(LGB1, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));

                #region HatchBrush Paint
                switch (hatchBrushType)
                {
                    case HatchBrushType.BackwardDiagonal:
                        HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Cross:
                        HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB1, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DarkDownwardDiagonal:
                        HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB2, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DarkHorizontal:
                        HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB3, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DarkUpwardDiagonal:
                        HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB4, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DarkVertical:
                        HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB5, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DashedDownwardDiagonal:
                        HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB6, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DashedHorizontal:
                        HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB7, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DashedUpwardDiagonal:
                        HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB8, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DashedVertical:
                        HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB9, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DiagonalBrick:
                        HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBA, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DiagonalCross:
                        HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBB, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Divot:
                        HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBC, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DottedDiamond:
                        HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBD, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.DottedGrid:
                        HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBE, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.ForwardDiagonal:
                        HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBF, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Horizontal:
                        HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBG, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.HorizontalBrick:
                        HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBH, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LargeCheckerBoard:
                        HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBI, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LargeConfetti:
                        HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBJ, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LargeGrid:
                        HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBK, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LightDownwardDiagonal:
                        HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBL, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LightHorizontal:
                        HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBM, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LightUpwardDiagonal:
                        HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBN, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.LightVertical:
                        HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBO, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Max:
                        HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBP, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Min:
                        HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBQ, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.NarrowHorizontal:
                        HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBR, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.NarrowVertical:
                        HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBS, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.OutlinedDiamond:
                        HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBT, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent05:
                        HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBU, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent10:
                        HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBV, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent20:
                        HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBW, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent25:
                        HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBX, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent30:
                        HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBY, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent40:
                        HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HBZ, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent50:
                        HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB10, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent60:
                        HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB11, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent70:
                        HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB12, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent75:
                        HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB13, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent80:
                        HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB14, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Percent90:
                        HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB15, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Plaid:
                        HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB16, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Shingle:
                        HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB17, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.SmallCheckerBoard:
                        HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB18, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.SmallConfetti:
                        HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB19, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.SmallGrid:
                        HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB20, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.SolidDiamond:
                        HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB21, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Sphere:
                        HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB22, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Trellis:
                        HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB23, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Vertical:
                        HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB24, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Wave:
                        HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB25, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.Weave:
                        HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB26, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.WideDownwardDiagonal:
                        HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB27, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.WideUpwardDiagonal:
                        HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB28, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    case HatchBrushType.ZigZag:
                        HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                        G.FillRectangle(HB29, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                        break;
                    default:
                        break;
                }
                #endregion

                //G.FillRectangle(HB1, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                G.DrawString(offText, Font, TB, new Point(location[2], location[3]));
            }
            DrawBorders(new Pen(new SolidBrush(border1)), G);
            DrawBorders(new Pen(new SolidBrush(border2)), 1, G);

        }
    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSwitchOnOffDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSwitchOnOffDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSwitchOnOffSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSwitchOnOffSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSwitchOnOffSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSwitchOnOff colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSwitchOnOffSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSwitchOnOffSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSwitchOnOff;

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
        /// Gets or sets the hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
        public Zeroit.Framework.MiscControls.ZeroitSwitchOnOff.HatchBrushType HatchBrush
        {
            get
            {
                return colUserControl.HatchBrush;
            }
            set
            {
                GetPropertyByName("HatchBrush").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public int[] Locations
        {
            get
            {
                return colUserControl.Locations;
            }
            set
            {
                GetPropertyByName("Locations").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the on text.
        /// </summary>
        /// <value>The on text.</value>
        public String OnText
        {
            get
            {
                return colUserControl.OnText;
            }
            set
            {
                GetPropertyByName("OnText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off text.
        /// </summary>
        /// <value>The off text.</value>
        public String OffText
        {
            get
            {
                return colUserControl.OffText;
            }
            set
            {
                GetPropertyByName("OffText").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the gradient color1.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color GradientColor1
        {
            get
            {
                return colUserControl.GradientColor1;
            }
            set
            {
                GetPropertyByName("GradientColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient color2.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color GradientColor2
        {
            get
            {
                return colUserControl.GradientColor2;
            }
            set
            {
                GetPropertyByName("GradientColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color hatch brushgradient1.
        /// </summary>
        /// <value>The color hatch brushgradient1.</value>
        public Color ColorHatchBrushgradient1
        {
            get
            {
                return colUserControl.ColorHatchBrushgradient1;
            }
            set
            {
                GetPropertyByName("ColorHatchBrushgradient1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color hatch brushgradient2.
        /// </summary>
        /// <value>The color hatch brushgradient2.</value>
        public Color ColorHatchBrushgradient2
        {
            get
            {
                return colUserControl.ColorHatchBrushgradient2;
            }
            set
            {
                GetPropertyByName("ColorHatchBrushgradient2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border1.
        /// </summary>
        /// <value>The border1.</value>
        public Color Border1
        {
            get
            {
                return colUserControl.Border1;
            }
            set
            {
                GetPropertyByName("Border1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border2.
        /// </summary>
        /// <value>The border2.</value>
        public Color Border2
        {
            get
            {
                return colUserControl.Border2;
            }
            set
            {
                GetPropertyByName("Border2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border3.
        /// </summary>
        /// <value>The border3.</value>
        public Color Border3
        {
            get
            {
                return colUserControl.Border3;
            }
            set
            {
                GetPropertyByName("Border3").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get
            {
                return colUserControl.TextColor;
            }
            set
            {
                GetPropertyByName("TextColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("HatchBrush",
                                 "Hatch Brush", "Appearance",
                                 "Sets the hatch brush."));

            items.Add(new DesignerActionPropertyItem("Locations",
                                 "Locations", "Appearance",
                                 "Sets the locations on the ontext and offtext."));

            items.Add(new DesignerActionPropertyItem("OnText",
                                 "OnText", "Appearance",
                                 "Sets the on button text."));

            items.Add(new DesignerActionPropertyItem("OffText",
                                 "OffText", "Appearance",
                                 "Sets the on button text."));

            items.Add(new DesignerActionPropertyItem("GradientColor1",
                                 "Gradient Color1", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("GradientColor2",
                                 "Gradient Color2", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient1",
                                 "Color Hatch Brushgradient1", "Appearance",
                                 "Sets the hatch background color."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient2",
                                 "Color Hatch Brushgradient2", "Appearance",
                                 "Sets the hatch background color."));

            items.Add(new DesignerActionPropertyItem("Border1",
                                 "Border1", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("Border2",
                                 "Border2", "Appearance",
                                 "Sets the border color."));

            //items.Add(new DesignerActionPropertyItem("Border3",
            //                     "Border3", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TextColor",
                                 "Text Color", "Appearance",
                                 "Sets the text color."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the Font of the On and Off."));



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
