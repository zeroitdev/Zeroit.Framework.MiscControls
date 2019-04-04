// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomColorPicker.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a color picker for selecting a customized color.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker" />
    public partial class CustomColorPicker : BaseColorPicker
    {
        /// <summary>
        /// Constructor with no starting color.
        /// </summary>
        public CustomColorPicker() : this(Color.Empty)
        {
		}

        /// <summary>
        /// Constructor with starting color.
        /// </summary>
        /// <param name="color">Starting color.</param>
        public CustomColorPicker(Color color)
        {
            InitializeComponent();


            
            bmPen = new Pen(Color.Black);
            bm = Zeroit.Framework.MiscControls.Properties.Resources.HSL200;
			bmRad = bm.Width / 2;
			bmMid = new Point(bitmapPanel.Width / 2, bitmapPanel.Height / 2);
			bmOff = new Point(bmMid.X - bmRad, bmMid.Y - bmRad);

			lumOff = new Point(4, bmOff.Y);
			lumHeight = bm.Height;
			lumMarkerPen = new Pen(Color.Black);
			lumMarkerBrush = null;

			lumY0 = Lum2Y(0.0);
			lumY1 = Lum2Y(1.0);

			SetColor(color);
        }

        /// <summary>
        /// The setting
        /// </summary>
        private int setting = 0;

        /// <summary>
        /// The bm
        /// </summary>
        private Bitmap bm;
        /// <summary>
        /// The bm RAD
        /// </summary>
        private int bmRad;
        /// <summary>
        /// The bm off
        /// </summary>
        private Point bmOff;
        /// <summary>
        /// The bm mid
        /// </summary>
        private Point bmMid;
        /// <summary>
        /// The bm pen
        /// </summary>
        private Pen bmPen = null;
        /// <summary>
        /// The bm x
        /// </summary>
        private int bmX = -1; // current 
                              /// <summary>
                              /// The bm y
                              /// </summary>
        private int bmY = -1;
        /// <summary>
        /// The bm mouse down
        /// </summary>
        private bool bmMouseDown = false;

        /// <summary>
        /// The lum off
        /// </summary>
        private Point lumOff;
        /// <summary>
        /// The lum height
        /// </summary>
        private int lumHeight = -1;
        /// <summary>
        /// The lum marker path
        /// </summary>
        private GraphicsPath lumMarkerPath;
        /// <summary>
        /// The lum marker pen
        /// </summary>
        private Pen lumMarkerPen = null;
        /// <summary>
        /// The lum marker brush
        /// </summary>
        private Brush lumMarkerBrush = null;
        /// <summary>
        /// The lum mouse down
        /// </summary>
        private bool lumMouseDown = false;
        /// <summary>
        /// The lum mouse offset
        /// </summary>
        private int lumMouseOffset; // Y offset

        /// <summary>
        /// The lum y0
        /// </summary>
        private int lumY0;
        /// <summary>
        /// The lum y1
        /// </summary>
        private int lumY1;

        /// <summary>
        /// The lum bar width
        /// </summary>
        private const int lumBarWidth = 20;
        /// <summary>
        /// The lum gap
        /// </summary>
        private const int lumGap = 4;
        /// <summary>
        /// The lum marker width
        /// </summary>
        private const int lumMarkerWidth = 20;
        /// <summary>
        /// The lum marker height
        /// </summary>
        private const int lumMarkerHeight = 8;


        /// <summary>
        /// The huemax
        /// </summary>
        private const int huemax = 360;
        /// <summary>
        /// The satmax
        /// </summary>
        private const int satmax = 240;
        /// <summary>
        /// The lummax
        /// </summary>
        private const int lummax = 240;

        /// <summary>
        /// The RAD to angle
        /// </summary>
        private const double RadToAngle = 180.0 / Math.PI;
        /// <summary>
        /// The angle to RAD
        /// </summary>
        private const double AngleToRad = Math.PI / 180.0;

        // Current color
        /// <summary>
        /// The RGB color
        /// </summary>
        private Color rgbColor;
        /// <summary>
        /// The HSL color
        /// </summary>
        private HSColor hslColor;

        /// <summary>
        /// Set current selected color.
        /// </summary>
        /// <param name="color">Current color.</param>
        /// <returns><c>True</c>.</returns>
		public override bool SetColor(Color color)
		{
			setting++;
			alphaNud.Value = (decimal)color.A;
			setting--;

			rgbColor = Color.FromArgb(255, color);
			hslColor = HSColor.RGB2HSL(rgbColor);
			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetGraphics();
			SetColorPanel();
			return true;
		}

        /// <summary>
        /// Sets the RGB text boxes.
        /// </summary>
        private void SetRGBTextBoxes()
		{
			setting++;
			redTextBox.Text   = rgbColor.R.ToString();
			greenTextBox.Text = rgbColor.G.ToString();
			blueTextBox.Text  = rgbColor.B.ToString();
			setting--;
		}

        /// <summary>
        /// Sets the HSL text boxes.
        /// </summary>
        private void SetHSLTextBoxes()
		{
			setting++;
            hueTextBox.Text = ((int)Math.Round(hslColor.Hue % huemax)).ToString();
			satTextBox.Text = ((int)Math.Round(hslColor.Sat * satmax)).ToString();
			lumTextBox.Text = ((int)Math.Round(hslColor.Val * lummax)).ToString();
			setting--;
		}

        /// <summary>
        /// Sets the graphics.
        /// </summary>
        private void SetGraphics()
		{
			double radhue = hslColor.Hue * AngleToRad;
			bmX = bmOff.X + bmRad + (int)Math.Round(bmRad * hslColor.Sat * Math.Cos(radhue));
			bmY = bmOff.Y + bmRad - (int)Math.Round(bmRad * hslColor.Sat * Math.Sin(radhue));
			bitmapPanel.Invalidate();
			lumPanel.Invalidate();
			ClearLumMarker();
		}

        /// <summary>
        /// Gets the color of the ARGB.
        /// </summary>
        /// <returns>Color.</returns>
        private Color GetArgbColor()
		{
			return Color.FromArgb((int)alphaNud.Value, rgbColor);
		}

        /// <summary>
        /// Sets the color panel.
        /// </summary>
        private void SetColorPanel()
		{
			colorLabel.BackColor = rgbColor;
			colorALabel.BackColor = GetArgbColor();
		}

        /// <summary>
        /// Updates from RGB.
        /// </summary>
        private void UpdateFromRGB()
		{
			int r = GetInt(redTextBox);
			int g = GetInt(greenTextBox);
			int b = GetInt(blueTextBox);
			rgbColor = Color.FromArgb(r, g, b);
			hslColor = HSColor.RGB2HSL(rgbColor);
			SetHSLTextBoxes();
			SetGraphics();
			SetColorPanel();
		}

        /// <summary>
        /// Updates from HSL.
        /// </summary>
        private void UpdateFromHSL()
		{
			double hue = (double)GetInt(hueTextBox);
			double sat = (double)GetInt(satTextBox) / satmax;
			double lum = (double)GetInt(lumTextBox) / lummax;
			hslColor = new HSColor(hue, sat, lum);
			rgbColor = hslColor.ToRGB(ColorSpace.HSL);
			SetRGBTextBoxes();
            SetGraphics();
			SetColorPanel();
		}

        /// <summary>
        /// Updates from bitmap mouse.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void UpdateFromBitmapMouse(MouseEventArgs e)
		{
			// Calc cartesian coords
            int x = e.X - bmMid.X;
			int y = bmMid.Y - e.Y;
			int rad = (int)Math.Round(Math.Sqrt(x*x + y*y));

			double hue = Math.Atan2(y, x) * RadToAngle;
			if (hue < 0)
			{
				hue = 360 + hue;
			}

			// If rad is greater than bmRad, then must recalc bmX,bmY so that
			// they stay within the circle
			if (rad > bmRad)
			{
				double radRatio = (double)bmRad / (double)rad;
                bmX = (int)Math.Floor(x * radRatio) + bmMid.X;
				bmY = bmMid.Y - (int)Math.Floor(y * radRatio);
				rad = bmRad;
			}
			else
			{
                bmX = e.X;
                bmY = e.Y;
			}

			double sat = rad / (double)bmRad;

			hslColor = new HSColor(hue, sat, hslColor.Val);
			rgbColor = hslColor.ToRGB(ColorSpace.HSL);

			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetColorPanel();

            bitmapPanel.Invalidate();
			lumPanel.Invalidate();
			ClearLumMarker();
		}

        /// <summary>
        /// Updates from lum mouse.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void UpdateFromLumMouse(MouseEventArgs e)
		{
			double newLum = Math.Max(Math.Min(1.0, Y2Lum(e.Y + lumMouseOffset)), 0.0);

			hslColor = new HSColor(hslColor.Hue, hslColor.Sat, newLum);
            rgbColor = hslColor.ToRGB(ColorSpace.HSL);

			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetColorPanel();

			lumPanel.Invalidate();
			ClearLumMarker();
		}

        /// <summary>
        /// Fixes the int.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <param name="max">The maximum.</param>
        private void FixInt(TextBox textBox, int max)
		{
			if (textBox.Text.Length == 0)
			{
				return;
			}
			int val;
			if (Int32.TryParse(textBox.Text, out val) && val <= max)
			{
				return;
			}
			setting++;
			textBox.Text = max.ToString();
			setting--;
		}

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <returns>System.Int32.</returns>
        private int GetInt(TextBox textBox)
		{
			if (textBox.Text.Length == 0)
			{
				return 0;
			}
			int val = 0;
			Int32.TryParse(textBox.Text, out val);
			return val;
		}

        /// <summary>
        /// Handles the TextChanged event of the hueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hueTextBox_TextChanged(object sender, EventArgs e)
        {
			if (setting == 0)
			{
				FixInt(hueTextBox, huemax);
				UpdateFromHSL();
			}
        }

        /// <summary>
        /// Handles the TextChanged event of the satTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void satTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(satTextBox, satmax);
				UpdateFromHSL();
			}
        }

        /// <summary>
        /// Handles the TextChanged event of the lumTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lumTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(lumTextBox, lummax);
				UpdateFromHSL();
			}
        }

        /// <summary>
        /// Handles the TextChanged event of the redTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void redTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(redTextBox, 255);
				UpdateFromRGB();
			}
        }

        /// <summary>
        /// Handles the TextChanged event of the greenTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void greenTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(greenTextBox, 255);
				UpdateFromRGB();
			}
        }

        /// <summary>
        /// Handles the TextChanged event of the blueTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void blueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(blueTextBox, 255);
				UpdateFromRGB();
			}
        }

        /// <summary>
        /// Handles the KeyPress event of the num control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
			bool want = (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back);
			e.Handled = !want;
        }

        /// <summary>
        /// Handles the Paint event of the bitmapPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void bitmapPanel_Paint(object sender, PaintEventArgs e)
        {
			Graphics g = e.Graphics;
			g.DrawImageUnscaled(bm, bmOff);
			g.DrawLine(bmPen, bmX,     bmY + 2, bmX,       bmY + 200);
            g.DrawLine(bmPen, bmX,     bmY - 2, bmX,       bmY - 200);
            g.DrawLine(bmPen, bmX + 2, bmY,     bmX + 200, bmY);
            g.DrawLine(bmPen, bmX - 2, bmY,     bmX - 200, bmY);
        }

        /// <summary>
        /// Handles the Click event of the selectButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void selectButton_Click(object sender, EventArgs e)
        {
			SelectColor(GetArgbColor());
		}

        /// <summary>
        /// Handles the MouseDown event of the bitmapPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bitmapPanel_MouseDown(object sender, MouseEventArgs e)
        {
			bmMouseDown = true;
			UpdateFromBitmapMouse(e);
        }

        /// <summary>
        /// Handles the MouseMove event of the bitmapPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bitmapPanel_MouseMove(object sender, MouseEventArgs e)
        {
			if (bmMouseDown)
			{
				UpdateFromBitmapMouse(e);
			}
        }

        /// <summary>
        /// Handles the MouseUp event of the bitmapPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bitmapPanel_MouseUp(object sender, MouseEventArgs e)
        {
			bmMouseDown = false;
        }

        /// <summary>
        /// Clears the lum marker.
        /// </summary>
        private void ClearLumMarker()
		{
			if (lumMarkerPath != null)
			{
				lumMarkerPath.Dispose();
				lumMarkerPath = null;
			}
			if (lumMarkerBrush != null)
			{
				lumMarkerBrush.Dispose();
				lumMarkerBrush = null;
			}
		}

        /// <summary>
        /// Makes the lum marker.
        /// </summary>
        private void MakeLumMarker()
		{
			if (lumMarkerPath == null)
			{
				lumMarkerPath = new GraphicsPath();
				int y = Lum2Y(hslColor.Val);
				int x = lumOff.X + lumBarWidth + lumGap;
				lumMarkerPath.AddPolygon(new Point[] { new Point(x, y),
												   new Point(x + lumMarkerWidth, y - lumMarkerHeight),
												   new Point(x + lumMarkerWidth, y + lumMarkerHeight),
												   new Point(x, y) } );
			}

			if (lumMarkerBrush == null)
			{
				lumMarkerBrush = new SolidBrush(GetLumColor(hslColor.Val));
			}
		}

        /// <summary>
        /// Lum2s the y.
        /// </summary>
        /// <param name="lum">The lum.</param>
        /// <returns>System.Int32.</returns>
        private int Lum2Y(double lum)
		{
			return lumOff.Y + lumHeight - 1 - (int)Math.Round(lum * (lumHeight - 1));
		}

        /// <summary>
        /// Y2s the lum.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <returns>System.Double.</returns>
        private double Y2Lum(int y)
		{
			return (double)(lumOff.Y + lumHeight - 1 - y) / (double)(lumHeight - 1);
		}

        /// <summary>
        /// Gets the color of the lum.
        /// </summary>
        /// <param name="lum">The lum.</param>
        /// <returns>Color.</returns>
        private Color GetLumColor(double lum)
		{
			return HSColor.HSL2RGB(hslColor.Hue, hslColor.Sat, lum);
		}

        /// <summary>
        /// Handles the Paint event of the lumPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void lumPanel_Paint(object sender, PaintEventArgs e)
        {
			if (lumHeight < 0)
			{
				return;
			}

			Graphics g = e.Graphics;
			Pen pen = new Pen(Color.White);

			for (int y = lumY1; y <= lumY0; y++)
			{
				double lum = Y2Lum(y);
				pen.Color = GetLumColor(lum);
				g.DrawLine(pen, lumOff.X, y, lumOff.X + lumBarWidth, y);
			}

			MakeLumMarker();
			g.FillPath(lumMarkerBrush, lumMarkerPath);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawPath(lumMarkerPen,   lumMarkerPath);
        }

        /// <summary>
        /// Handles the MouseDown event of the lumPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void lumPanel_MouseDown(object sender, MouseEventArgs e)
        {
			if (lumMarkerPath.IsVisible(e.Location))
			{
				lumMouseDown = true;
				lumMouseOffset = Lum2Y(hslColor.Val) - e.Y;
			}
        }

        /// <summary>
        /// Handles the MouseMove event of the lumPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void lumPanel_MouseMove(object sender, MouseEventArgs e)
        {
			if (lumMouseDown)
			{
				UpdateFromLumMouse(e);
			}
        }

        /// <summary>
        /// Handles the MouseUp event of the lumPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void lumPanel_MouseUp(object sender, MouseEventArgs e)
        {
			lumMouseDown = false;
        }

        /// <summary>
        /// Handles the ValueChanged event of the alphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
			if (setting == 0)
			{
				SetColorPanel();
			}
        }
    }
}
