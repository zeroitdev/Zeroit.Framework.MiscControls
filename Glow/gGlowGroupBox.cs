// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="gGlowGroupBox.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This is a panel Control to add Glow Effect to all of the Child Controls
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxItem(true), ToolboxBitmap(typeof(ZeroitGlowBox), "Zeroit.Framework.MiscControls.Glow.gZeroitGlowGroupBox.bmp"), System.Diagnostics.DebuggerStepThrough()]
	public partial class ZeroitGlowGroupBox : Panel
	{

        #region Initialize        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlowGroupBox" /> class.
        /// </summary>
        public ZeroitGlowGroupBox()
		{

			// This call is required by the designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}
        #endregion

        #region Fields
        /// <summary>
        /// The glow color
        /// </summary>
        private Color _glowColor = Color.Maroon;
        /// <summary>
        /// The glow on
        /// </summary>
        private bool _glowOn;
        /// <summary>
        /// The effect type
        /// </summary>
        private Effects _EffectType = Effects.Glow;
        #endregion

        #region Properties

        /// <summary>
        /// Get or Set the color of the Glow
        /// </summary>
        /// <value>The color of the glow.</value>
        [Category("gZeroitGlowBox"), Description("Get or Set the color of the Glow"), DefaultValue(typeof(Color), "Maroon")]
		public Color GlowColor
		{
			get
			{
				return _glowColor;
			}
			set
			{
				_glowColor = value;
				Invalidate();
			}
		}


        /// <summary>
        /// Turn the Glow effect on or off
        /// </summary>
        /// <value><c>true</c> if [glow on]; otherwise, <c>false</c>.</value>
        [Category("gZeroitGlowBox"), Description("Turn the Glow effect on or off"), DefaultValue(false)]
		public bool GlowOn
		{
			get
			{
				return _glowOn;
			}
			set
			{
				_glowOn = value;
				Invalidate();
			}
		}

        /// <summary>
        /// Enum representing the type of Effect.
        /// </summary>
        public enum Effects
		{
            /// <summary>
            /// The glow
            /// </summary>
            Glow,
            /// <summary>
            /// The shadow
            /// </summary>
            Shadow
        }


        /// <summary>
        /// Choose Glow or Shadow
        /// </summary>
        /// <value>The type of the effect.</value>
        [Category("gZeroitGlowBox"), Description("Choose Glow or Shadow"), DefaultValue("Glow")]
		public Effects EffectType
		{
			get
			{
				return _EffectType;
			}
			set
			{
				_EffectType = value;
			}
		}

        #endregion

        #region Paint

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			if (DesignMode == true && Controls.Count == 0)
			{
				TextRenderer.DrawText(e.Graphics, string.Format("Drop controls{0}on the Glow GroupBox", Environment.NewLine), new Font("Arial", 8F, FontStyle.Bold), new Point(20, 20), Color.DarkBlue);
				
			    TextRenderer.DrawText(e.Graphics, "Zeroit Dev © 2018", new Font("Arial", 7F, FontStyle.Bold), new Point(Width - 95, Height - 17), Color.DarkGray);

            }
            else if (_glowOn)
			{

				foreach (Control _control in Controls)
				{

					if (_control.Focused == true)
					{

						bool GlowK = true;

						////Check if the control has the ReadOnly property and if so, its value.
						//if (!((_control.GetType().GetProperty("ReadOnly") == null)))
						//{
						//	GlowK = !(CallByName(_control, "ReadOnly", Microsoft.VisualBasic.CallType.Get));
						//}

					    if ((_control.GetType().GetProperty("ReadOnly") != null))
					    {
					        //GlowK = !Interaction.CallByName(_control, "ReadOnly", CallType.Get);

					        
					        GlowK = !(bool)(Interaction.CallByName(_control, "ReadOnly", CallType.Get));

                        }

                        if (GlowK)
						{

							if (EffectType == Effects.Glow)
							{

								using (GraphicsPath gp = new GraphicsPath())
								{
									//Change these to Properties if you want Design Control of the Values 
									var _Glow = 15;
									var _Feather = 50;
									//Get a Rectangle a little smaller than the control's
									//and make a GraphicsPath with it
									Rectangle rect = new Rectangle(_control.Bounds.X, _control.Bounds.Y, _control.Bounds.Width - 1, _control.Bounds.Height - 1);
									rect.Inflate(-1, -1);
									gp.AddRectangle(rect);

									//Draw multiple rectangles with increasing thickness and transparency
									for (int i = 1; i <= _Glow; i += 2)
									{
										int aGlow = Convert.ToInt32(_Feather - ((_Feather / (double)_Glow) * i));
										using (Pen pen = new Pen(Color.FromArgb(aGlow, _glowColor), i) {LineJoin = LineJoin.Round})
										{

											e.Graphics.DrawPath(pen, gp);

										}

									}

								}

							}
							else
							{
								using (GraphicsPath shadowpath = new GraphicsPath())
								{
									//Change these to Properties if you want Design Control of the Values 
									Point _ShadowOffset = new Point(3, 3);
									Color _ShadowColor = _glowColor;
									int _ShadowBlur = 2;
									int _ShadowFeather = 100;

									Rectangle rect = new Rectangle(_control.Bounds.X + 4 + _ShadowOffset.X, _control.Bounds.Y + 4 + _ShadowOffset.Y, _control.Bounds.Width - 8, _control.Bounds.Height - 8);
									shadowpath.AddRectangle(rect);

									int x = 6;
									for (int i = 1; i <= x; i++)
									{
										using (Pen pen = new Pen(Color.FromArgb(Convert.ToInt32(_ShadowFeather - ((_ShadowFeather / (double)x) * i)), _ShadowColor), Convert.ToSingle(i * (_ShadowBlur))))
										{
											pen.LineJoin = LineJoin.Round;
											e.Graphics.DrawPath(pen, shadowpath);
										}
									}

									e.Graphics.FillPath(new SolidBrush(_ShadowColor), shadowpath);
								}
							}


						}
					}
				}

			}

		}
        #endregion

        #region Control Focus Event

        /// <summary>
        /// Handles the ControlAdded event of the gZeroitGlowBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void gZeroitGlowBox_ControlAdded(object sender, ControlEventArgs e)
		{
			// Add handlers to let the gZeroitGlowBox know when the child control gets Focus 
			e.Control.GotFocus += ChildGotFocus;
			e.Control.LostFocus += ChildLostFocus;
		}

        /// <summary>
        /// Childs the got focus.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChildGotFocus(object sender, EventArgs e)
		{
			Invalidate();
		}

        /// <summary>
        /// Childs the lost focus.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChildLostFocus(object sender, EventArgs e)
		{
			Invalidate();
		}
        #endregion

	}
}