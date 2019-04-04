// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorGradientEditor.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a control for designing a color gradient.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class ColorGradientEditor : UserControl
    {
        /// <summary>
        /// Default contructor.
        /// </summary>
        public ColorGradientEditor()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.UpdateStyles();

			SetControlPanelLocation();

			vals = new List<Val>();
			SetVal(Utils.GetDefaultColorBlend());

			selMouse = false;
			ChangeSel(1);
			RedrawGradient();
        }

        /// <summary>
        /// Class Val.
        /// </summary>
        private class Val
		{
            /// <summary>
            /// Initializes a new instance of the <see cref="Val"/> class.
            /// </summary>
            /// <param name="position">The position.</param>
            /// <param name="color">The color.</param>
            public Val(int position, Color color)
			{
				Debug.Assert(position >= 0 && position <= 100);
				Position = position;
				Color = color;
			}

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
			{
				return string.Format("Pos {0}; Color.RGB {1},{2},{3}; Color.A {4}",
										Position,
										Color.R, Color.G, Color.B, Color.A);
			}

            /// <summary>
            /// The position
            /// </summary>
            public readonly int Position;
            /// <summary>
            /// The color
            /// </summary>
            public readonly Color Color;
		}

        /// <summary>
        /// The sel
        /// </summary>
        private int sel;
        /// <summary>
        /// The vals
        /// </summary>
        private List<Val> vals;

        /// <summary>
        /// The minimum position
        /// </summary>
        private int minPos; // min position for sel
                            /// <summary>
                            /// The maximum position
                            /// </summary>
        private int maxPos; // max position for sel

        /// <summary>
        /// The sel mouse
        /// </summary>
        private bool selMouse; // is mouse down on sel?
                               /// <summary>
                               /// The sel mouse x
                               /// </summary>
        private int selMouseX; // x position of mouse when mouse goes down
                               /// <summary>
                               /// The sel mouse position
                               /// </summary>
        private int selMousePos; // pos of sel when mouse goes down

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="cb">The cb.</param>
        /// <exception cref="ArgumentNullException">Blend</exception>
        /// <exception cref="ArgumentException">
        /// Blend
        /// or
        /// Blend
        /// </exception>
        private void SetVal(ColorBlend cb)
		{
			if (cb == null)
			{
				throw new ArgumentNullException("Blend");
			}
			if (   cb.Positions.Length < 2
				|| cb.Positions.Length != cb.Colors.Length
				|| cb.Positions[0] != 0.0f
				|| cb.Positions[cb.Positions.Length - 1] != 1.0f)
			{
				throw new ArgumentException("Blend");
			}

			for (int i = 1; i < cb.Positions.Length - 1; i++)
			{
				if (   cb.Positions[i] < cb.Positions[i - 1]
					|| cb.Positions[i] > cb.Positions[i + 1])
				{
					throw new ArgumentException("Blend");
				}
			}

			vals.Clear();
			vals.Add(new Val(0, cb.Colors[0]));
			for (int i = 1; i < cb.Positions.Length - 1; i++)
			{
				vals.Add(new Val((int)Math.Round(100.0 * cb.Positions[i]), cb.Colors[i]));
			}
			vals.Add(new Val(100, cb.Colors[cb.Colors.Length - 1]));
			
		}

        /// <summary>
        /// Gets or sets color blend.
        /// </summary>
        /// <value>Color blend.</value>
    	public ColorBlend Blend
		{
			get
			{
				ColorBlend blend = new ColorBlend(vals.Count);
				for (int i = 0; i < vals.Count; i++)
				{
					blend.Positions[i] = (float)vals[i].Position * 0.01f;
					blend.Colors[i] = vals[i].Color;
				}
				return blend;
			}
			set
			{
				SetVal(value);
				ChangeSel(Math.Min(sel, vals.Count - 1));
				ClearGradientBrush();
				RedrawGradient();
			}
        }

        /// <summary>
        /// The gradient border color
        /// </summary>
        private Color gradientBorderColor = Color.DarkGray;
        /// <summary>
        /// Gets or sets color of border around gradient display.
        /// </summary>
        /// <value>Color of border around gradient display.</value>
		[Category("Appearance"), DefaultValue("DarkGray")]
		public Color GradientBorderColor
		{
			get { return gradientBorderColor; }
			set
			{
				gradientBorderColor = value;
				ClearBorderBrush();
				RedrawGradient();
			}
		}

        /// <summary>
        /// The gradient border size
        /// </summary>
        private int gradientBorderSize = 1;
        /// <summary>
        /// Gets or sets pixel size of border around gradient display.
        /// </summary>
        /// <value>Pixel size of border around gradient display.</value>
		[Category("Appearance"), DefaultValue(1)]
		public int GradientBorderSize
		{
			get { return gradientBorderSize; }
			set
			{
				int val = Math.Max(Math.Min(5, value), 0);
				if (gradientBorderSize != val)
				{
					gradientBorderSize = val;
					ClearGradientBrush();
					ClearMarkers();
					RedrawGradient();
				}
			}
		}

        /// <summary>
        /// The gradient back color
        /// </summary>
        private Color gradientBackColor = Color.White;
        /// <summary>
        /// Gets or sets background color in gradient display.
        /// </summary>
        /// <value>Background color in gradient display.</value>
		[Category("Appearance"), DefaultValue("White")]
		public Color GradientBackColor
		{
			get { return gradientBackColor; }
			set
			{
				gradientBackColor = value;
				ClearBackGradientBrush();
				RedrawGradient();
			}
		}

        /// <summary>
        /// The gradient hatch color
        /// </summary>
        private Color gradientHatchColor = Color.Black;
        /// <summary>
        /// Gets or sets hatch pattern in background of gradient display.
        /// </summary>
        /// <value>Hatch pattern in background of gradient display.</value>
		[Category("Appearance"), DefaultValue("Black")]
		public Color GradientHatchColor
		{
			get { return gradientHatchColor; }
			set
			{
				gradientHatchColor = value;
				ClearBackGradientBrush();
				RedrawGradient();
			}
		}

        /// <summary>
        /// The marker border color
        /// </summary>
        private Color markerBorderColor = Color.Black;
        /// <summary>
        /// Gets or sets marker border color.
        /// </summary>
        /// <value>Marker border color.</value>
		[Category("Appearance"), DefaultValue("Black")]
		public Color MarkerBorderColor
		{
			get { return markerBorderColor; }
			set
			{
				markerBorderColor = value;
				ClearMarkerBorderPen();
				RedrawGradient();
			}
		}

        /// <summary>
        /// The marker fill color
        /// </summary>
        private Color markerFillColor = Color.White;
        /// <summary>
        /// Gets or sets marker fill color.
        /// </summary>
        /// <value>Marker fill color.</value>
		[Category("Appearance"), DefaultValue("White")]
		public Color MarkerFillColor
		{
			get { return markerFillColor; }
			set
			{
				markerFillColor = value;
				ClearMarkerFillBrush();
				RedrawGradient();
			}
		}

        /// <summary>
        /// The sel marker fill color
        /// </summary>
        private Color selMarkerFillColor = Color.Yellow;
        /// <summary>
        /// Gets or sets selected marker fill color.
        /// </summary>
        /// <value>Selected marker fill color.</value>
		[Category("Appearance"), DefaultValue("Yellow")]
		public Color SelMarkerFillColor
		{
			get { return selMarkerFillColor; }
			set
			{
				selMarkerFillColor = value;
				ClearSelMarkerFillBrush();
				RedrawGradient();
			}
		}

        /// <summary>
        /// Handles the SizeChanged event of the gradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gradientPanel_SizeChanged(object sender, EventArgs e)
        {
			ClearGradientBrush();
			ClearMarkers();
			RedrawGradient();
        }

        /// <summary>
        /// Handles the SizeChanged event of the mainSplit_Panel2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mainSplit_Panel2_SizeChanged(object sender, EventArgs e)
        {
			SetControlPanelLocation();
        }

        /// <summary>
        /// Sets the control panel location.
        /// </summary>
        private void SetControlPanelLocation()
		{
        	controlPanel.Location = new Point((mainSplit.Panel2.Size.Width - controlPanel.Size.Width) / 2, 0);
		}

        /// <summary>
        /// Changes the sel.
        /// </summary>
        /// <param name="newSel">The new sel.</param>
        private void ChangeSel(int newSel)
		{
			ClearSelMarker();
			ClearMarker(newSel);
			sel = newSel;
			ChangeSel();
		}

        /// <summary>
        /// The inside change sel
        /// </summary>
        private bool insideChangeSel = false;

        /// <summary>
        /// Changes the sel.
        /// </summary>
        private void ChangeSel()
		{
            insideChangeSel = true;
            
			stopLabel.Text = string.Format("Stop {0}/{1}", sel + 1, vals.Count);

			delButton.Enabled = (sel > 0) && (sel < vals.Count - 1);

			firstButton.Enabled = (sel > 0);
			prevButton.Enabled = (sel > 0);
			nextButton.Enabled = (sel < vals.Count - 1);
			lastButton.Enabled = (sel < vals.Count - 1);

			int nextPos = -1;
			int prevPos = -1;

			if (sel == 0)
			{
				minPos = 0;
				maxPos = 0;
				prevPos = 0;
				nextPos = vals[sel + 1].Position - 1;
			}
			else if (sel == vals.Count - 1)
			{
				minPos = 100;
				maxPos = 100;
				prevPos = vals[sel - 1].Position + 1;
				nextPos = 100;
			}
			else
			{
				minPos = vals[sel - 1].Position + 1;
				maxPos = vals[sel + 1].Position - 1;
				prevPos = minPos;
				nextPos = maxPos;
			}

			newBeforeButton.Enabled = ((vals[sel].Position - prevPos) > 0);
			newAfterButton.Enabled  = ((nextPos - vals[sel].Position) > 0);

			positionNud.Enabled = (sel > 0 && sel < vals.Count - 1);
			positionNud.Minimum = minPos;
			positionNud.Maximum = maxPos;

			ShowSel();
			RedrawGradient();
			
            insideChangeSel = false;
		}

        /// <summary>
        /// Shows the sel.
        /// </summary>
        private void ShowSel()
		{
			positionNud.Value = vals[sel].Position;
			colorLabel.BackColor = Color.FromArgb(255, vals[sel].Color);
			alphaNud.Value = vals[sel].Color.A;
		}

        /// <summary>
        /// Changes the position.
        /// </summary>
        /// <param name="newPos">The new position.</param>
        private void ChangePosition(int newPos)
		{
            if (!insideChangeSel)
            {
                vals[sel] = new Val(Math.Max(Math.Min(newPos, maxPos), minPos), vals[sel].Color);
                ClearGradientBrush();
                ClearSelMarker();
                ShowSel();
                RedrawGradient();
            }
		}

        /// <summary>
        /// Changes the opacity.
        /// </summary>
        /// <param name="newOpacity">The new opacity.</param>
        private void ChangeOpacity(int newOpacity)
        {
            if (!insideChangeSel)
            {
                vals[sel] = new Val(vals[sel].Position, Color.FromArgb(newOpacity, vals[sel].Color));
                ClearGradientBrush();
                ShowSel();
                RedrawGradient();
            }
		}

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="newColor">The new color.</param>
        private void ChangeColor(Color newColor)
		{
            if (!insideChangeSel)
            {
                vals[sel] = new Val(vals[sel].Position, Color.FromArgb(vals[sel].Color.A, newColor));
                ClearGradientBrush();
                ShowSel();
                RedrawGradient();
            }
		}

        /// <summary>
        /// Handles the Click event of the delButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void delButton_Click(object sender, EventArgs e)
        {
			if (sel > 0 && sel < vals.Count - 1)
			{
				ClearGradientBrush();
				ClearMarkers();

				vals.RemoveAt(sel);
				ChangeSel();

				RedrawGradient();
			}
        }

        /// <summary>
        /// Handles the Click event of the newBeforeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newBeforeButton_Click(object sender, EventArgs e)
        {
			NewSel(sel - 1);
        }

        /// <summary>
        /// Handles the Click event of the newAfterButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newAfterButton_Click(object sender, EventArgs e)
        {
			NewSel(sel);
        }

        /// <summary>
        /// News the sel.
        /// </summary>
        /// <param name="selLeft">The sel left.</param>
        private void NewSel(int selLeft)
		{
			ClearGradientBrush();
			ClearMarkers();
			
			Val v1 = vals[selLeft];
			Val v2 = vals[selLeft + 1];
			Val v = new Val((v1.Position + v2.Position) / 2,
							Color.FromArgb((v1.Color.A + v2.Color.A) / 2, 
										   (v1.Color.R + v2.Color.R) / 2, 
										   (v1.Color.G + v2.Color.G) / 2,
										   (v1.Color.B + v2.Color.B) / 2));
			vals.Insert(selLeft + 1, v);

			ChangeSel(selLeft + 1);

			RedrawGradient();
		}

        /// <summary>
        /// Handles the Click event of the firstButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void firstButton_Click(object sender, EventArgs e)
        {
			ChangeSel(0);
        }

        /// <summary>
        /// Handles the Click event of the lastButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lastButton_Click(object sender, EventArgs e)
        {
			ChangeSel(vals.Count - 1);
        }

        /// <summary>
        /// Handles the Click event of the prevButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void prevButton_Click(object sender, EventArgs e)
        {
			ChangeSel(sel - 1);
        }

        /// <summary>
        /// Handles the Click event of the nextButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void nextButton_Click(object sender, EventArgs e)
        {
			ChangeSel(sel + 1);
        }

        /// <summary>
        /// Handles the ValueChanged event of the positionNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void positionNud_ValueChanged(object sender, EventArgs e)
        {
			ChangePosition((int)positionNud.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the alphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
			ChangeOpacity((int)alphaNud.Value);
        }

        /// <summary>
        /// Handles the Click event of the colorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(colorLabel.BackColor, colorButton);
			if (d.ShowDialog() == DialogResult.OK)
			{
				ChangeColor(d.Color);
			}
        }

        /// <summary>
        /// Handles the MouseDown event of the gradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void gradientPanel_MouseDown(object sender, MouseEventArgs e)
        {
			if (selMarker != null && selMarker.IsVisible(e.Location))
			{
				selMouse = true;
			}
			else
			{
				// Is mouse down inside a non-sel marker?
				for (int s = vals.Count - 1; s >= 0; s--)
				{
					if (s != sel && markers[s] != null && markers[s].IsVisible(e.Location))
					{
						ChangeSel(s);
						selMouse = true;
						break;
					}
				}
			}

			if (selMouse)
			{
				selMouseX = e.X;
				selMousePos = vals[sel].Position;
			}
        }

        /// <summary>
        /// Handles the MouseMove event of the gradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void gradientPanel_MouseMove(object sender, MouseEventArgs e)
        {
			if (selMouse)
			{
				int dx = e.X - selMouseX;
				int newPos = Math.Max(Math.Min(maxPos, selMousePos + DxToDpos(dx)), minPos);
				if (newPos != vals[sel].Position)
				{
					ChangePosition(newPos);
				}
			}
        }

        /// <summary>
        /// Handles the MouseUp event of the gradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void gradientPanel_MouseUp(object sender, MouseEventArgs e)
        {
			selMouse = false;
        }

        /// <summary>
        /// Redraws the gradient.
        /// </summary>
        private void RedrawGradient()
		{
			gradientPanel.Invalidate(true);
		}

        /// <summary>
        /// The border brush
        /// </summary>
        private Brush borderBrush = null;
        /// <summary>
        /// The back gradient brush
        /// </summary>
        private HatchBrush backGradientBrush = null;

        /// <summary>
        /// The gradient brush
        /// </summary>
        private LinearGradientBrush2 gradientBrush = null;
        /// <summary>
        /// The gradient rect
        /// </summary>
        private Rectangle gradientRect = Rectangle.Empty;

        /// <summary>
        /// The scale font brush
        /// </summary>
        private Brush scaleFontBrush = null;
        /// <summary>
        /// The marker border pen
        /// </summary>
        private Pen markerBorderPen = null;
        /// <summary>
        /// The marker fill brush
        /// </summary>
        private Brush markerFillBrush = null;
        /// <summary>
        /// The sel marker fill brush
        /// </summary>
        private Brush selMarkerFillBrush = null;

        /// <summary>
        /// Clears the border brush.
        /// </summary>
        private void ClearBorderBrush()
		{
			if (borderBrush != null)
			{
				borderBrush.Dispose();
				borderBrush = null;
			}
		}

        /// <summary>
        /// Clears the back gradient brush.
        /// </summary>
        private void ClearBackGradientBrush()
		{
			if (backGradientBrush != null)
			{
				backGradientBrush.Dispose();
				backGradientBrush = null;
			}
		}

        /// <summary>
        /// Clears the gradient brush.
        /// </summary>
        private void ClearGradientBrush()
		{
			if (gradientBrush != null)
			{
				gradientBrush.Dispose();
				gradientBrush = null;
			}
		}

        /// <summary>
        /// Clears the marker border pen.
        /// </summary>
        private void ClearMarkerBorderPen()
		{
			if (markerBorderPen != null)
			{
				markerBorderPen.Dispose();
				markerBorderPen = null;
			}
		}

        /// <summary>
        /// Clears the marker fill brush.
        /// </summary>
        private void ClearMarkerFillBrush()
		{
			if (markerFillBrush != null)
			{
				markerFillBrush.Dispose();
				markerFillBrush = null;
			}
		}

        /// <summary>
        /// Clears the sel marker fill brush.
        /// </summary>
        private void ClearSelMarkerFillBrush()
		{
			if (selMarkerFillBrush != null)
			{
				selMarkerFillBrush.Dispose();
				selMarkerFillBrush = null;
			}
		}

        /// <summary>
        /// Allocs the pens and brushes.
        /// </summary>
        private void AllocPensAndBrushes()
		{
			if (borderBrush == null)
			{
				borderBrush = new SolidBrush(Color.Black /*gradientBorderColor*/);
			}
			if (backGradientBrush == null)
			{
				backGradientBrush = new HatchBrush(HatchStyle.DiagonalCross, gradientHatchColor, gradientBackColor);
			}
			if (gradientBrush == null)
			{
				gradientBrush = new LinearGradientBrush2(gradientRect, Blend, LinearGradientMode.Horizontal);
			}
			if (markerBorderPen == null)
			{
				markerBorderPen = new Pen(markerBorderColor, markerBorderSize);
			}
			if (markerFillBrush == null)
			{
				markerFillBrush = new SolidBrush(markerFillColor);
			}
			if (selMarkerFillBrush == null)
			{
				selMarkerFillBrush = new SolidBrush(selMarkerFillColor);
			}
		}

        /// <summary>
        /// Clears the scale font brush.
        /// </summary>
        private void ClearScaleFontBrush()
		{
			if (scaleFontBrush != null)
			{
				scaleFontBrush.Dispose();
				scaleFontBrush = null;
			}
		}

        /// <summary>
        /// Clears the markers.
        /// </summary>
        private void ClearMarkers()
		{
			if (markers != null)
			{
                for (int s = 0; s < markers.Length; s++)
                {
                    ClearMarker(s);
                }
				markers = null;
			}
			ClearSelMarker();
		}

        /// <summary>
        /// Clears the marker.
        /// </summary>
        /// <param name="s">The s.</param>
        private void ClearMarker(int s)
		{
			if (markers != null && markers[s] != null)
			{
				markers[s].Dispose();
				markers[s] = null;
			}
		}

        /// <summary>
        /// Clears the sel marker.
        /// </summary>
        private void ClearSelMarker()
		{
			if (selMarker != null)
			{
				selMarker.Dispose();
				selMarker = null;
			}
		}

        /// <summary>
        /// Positions to x.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Int32.</returns>
        private int PosToX(int pos)
		{
			return gradientRect.Left + (int)Math.Round((double)(pos * (gradientRect.Width - 1)) * 0.01);
		}

        /// <summary>
        /// Dxes to dpos.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <returns>System.Int32.</returns>
        private int DxToDpos(int dx)
		{
			return (int)Math.Round((100.0 * dx)/(gradientRect.Width - 1));
		}

        /// <summary>
        /// Allocs the marker.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath AllocMarker(int pos)
		{
			int h2 = markerHeight / 2;
			int w2 = markerHeight / 2;

			int x = PosToX(pos);
			Point[] pts = new Point[] { new Point(x,      yMarker               ),
										new Point(x + w2, yMarker + h2          ),
										new Point(x,      yMarker + markerHeight),
										new Point(x - w2, yMarker + h2          ),
										new Point(x,      yMarker               ) };

			GraphicsPath p = new GraphicsPath();
			p.AddLines(pts);
			return p;
		}

        /// <summary>
        /// Allocs the sel marker.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath AllocSelMarker(int pos)
		{
			int w2 = selMarkerWidth / 2;

			int x = PosToX(pos);
            Point[] pts = new Point[] { new Point(x,          yMarker                  ),
										new Point(x + w2,     yMarker + selMarkerHeight),
										new Point(x - w2,     yMarker + selMarkerHeight),
										new Point(x,          yMarker                  ) };

			GraphicsPath p = new GraphicsPath();
			p.AddLines(pts);
			return p;
		}

        /// <summary>
        /// Draws the marker.
        /// </summary>
        /// <param name="p">The p.</param>
        private void DrawMarker(GraphicsPath p)
		{
			g.FillPath(markerFillBrush, p);
			g.DrawPath(markerBorderPen, p);
		}

        /// <summary>
        /// Draws the sel marker.
        /// </summary>
        /// <param name="p">The p.</param>
        private void DrawSelMarker(GraphicsPath p)
		{
			g.FillPath(selMarkerFillBrush, p);
			g.DrawPath(markerBorderPen, p);
		}

        /// <summary>
        /// The marker height
        /// </summary>
        private const int markerHeight = 10;
        /// <summary>
        /// The marker width
        /// </summary>
        private const int markerWidth = 10;
        /// <summary>
        /// The marker border size
        /// </summary>
        private const int markerBorderSize = 1;
        /// <summary>
        /// The sel marker height
        /// </summary>
        private const int selMarkerHeight = 14;
        /// <summary>
        /// The sel marker width
        /// </summary>
        private const int selMarkerWidth = 12;

        /// <summary>
        /// The scale point size
        /// </summary>
        private const float scalePointSize = 8.0f;

        /// <summary>
        /// The g
        /// </summary>
        private Graphics g;
        /// <summary>
        /// The y marker
        /// </summary>
        private int yMarker;

        /// <summary>
        /// The markers
        /// </summary>
        private GraphicsPath[] markers = null;
        /// <summary>
        /// The sel marker
        /// </summary>
        private GraphicsPath selMarker = null;

        /// <summary>
        /// Handles the Paint event of the gradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void gradientPanel_Paint(object sender, PaintEventArgs e)
        {
			Size cs = gradientPanel.ClientSize;

			int xpad = Math.Max(Math.Max(markerWidth / 2, selMarkerWidth / 2), gradientBorderSize);
			int ytop = gradientBorderSize;
			int dx = cs.Width - 2 * xpad;
			int dy = cs.Height - 2 * gradientBorderSize - 3 - Math.Max(markerHeight, selMarkerHeight) - 2;

			if (dx < 1 || dy < 1)
			{
				return; // too small to draw anything
			}

			g = e.Graphics;
			Rectangle gr = new Rectangle(xpad, ytop, dx, dy);
			if (gr != gradientRect)
			{
				ClearGradientBrush();
				gradientRect = gr;
			}
			yMarker = ytop + dy + gradientBorderSize + 3;

			AllocPensAndBrushes();

			// Fill background + border with border color
			if (gradientBorderSize > 0)
			{
				Rectangle r = Rectangle.Inflate(gr, gradientBorderSize, gradientBorderSize);
				g.FillRectangle(borderBrush, r);
			}

			// Draw gradient
			gradientBrush.FillRectangle(g, gr, backGradientBrush);

			// Draw markers
			if (markers == null)
			{
				markers = new GraphicsPath[vals.Count];
			}
			for (int s = 0; s < vals.Count; s++)
			{
				if (s != sel)
				{
					if (markers[s] == null)
					{
						markers[s] = AllocMarker(vals[s].Position);
					}
					DrawMarker(markers[s]);
				}
			}
			if (selMarker == null)
			{
				selMarker = AllocSelMarker(vals[sel].Position);
			}
			DrawSelMarker(selMarker);
        }
    }
}


