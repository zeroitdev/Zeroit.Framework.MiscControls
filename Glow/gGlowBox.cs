// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="gGlowBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// This is a Panel control to add glow effect to a focused child control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />

    [ToolboxItem(true), ToolboxBitmap(typeof(ZeroitGlowBox), "Zeroit.Framework.MiscControls.Glow.gZeroitGlowBox.bmp"), System.Diagnostics.DebuggerStepThrough()]
	public partial class ZeroitGlowBox : Panel
	{

        #region Initialize        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlowBox" /> class.
        /// </summary>
        public ZeroitGlowBox()
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
        };

        /// <summary>
        /// The effect type
        /// </summary>
        private Effects _effectType = Effects.Glow;
        /// <summary>
        /// The glow color
        /// </summary>
        private Color _glowColor = Color.Maroon;
        /// <summary>
        /// The glow on
        /// </summary>
        private bool _glowOn;
        /// <summary>
        /// The glow
        /// </summary>
        int _Glow = 15;
        /// <summary>
        /// The feather
        /// </summary>
        int _Feather = 50;

        //Change these to Properties if you want Design Control of the Values 
        /// <summary>
        /// The shadow offset
        /// </summary>
        Point _ShadowOffset = new Point(3, 3);
        /// <summary>
        /// The shadow color
        /// </summary>
        Color _ShadowColor;
        /// <summary>
        /// The shadow blur
        /// </summary>
        int _ShadowBlur = 2;
        /// <summary>
        /// The shadow feather
        /// </summary>
        int _ShadowFeather = 100;
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
        /// Gets or sets the glow.
        /// </summary>
        /// <value>The glow.</value>
        public int Glow
	    {
            get { return _Glow; }
	        set
	        {
                _Glow = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the feather.
        /// </summary>
        /// <value>The feather.</value>
        public int Feather
	    {
            get { return _Feather; }
	        set
	        {
                _Feather = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the type of the effect.
        /// </summary>
        /// <value>The type of the effect.</value>
        public Effects EffectType
	    {
	        get { return _effectType; }
	        set
            {
                _effectType = value;
	            Invalidate();
	        }

	    }

        /// <summary>
        /// Gets or sets the shadow blur.
        /// </summary>
        /// <value>The shadow blur.</value>
        public int ShadowBlur
	    {
            get { return _ShadowBlur; }
	        set
	        {
                _ShadowBlur = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the shadow offset.
        /// </summary>
        /// <value>The shadow offset.</value>
        public Point ShadowOffset
	    {
            get { return _ShadowOffset; }
	        set
	        {
                _ShadowOffset = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the shadow feather.
        /// </summary>
        /// <value>The shadow feather.</value>
        public int ShadowFeather
	    {
            get { return _ShadowFeather; }
	        set
	        {
                _ShadowFeather = value;
	            Invalidate();
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

		    
            if (DesignMode == true && Controls.Count == 0)
			{
				TextRenderer.DrawText(e.Graphics, string.Format("Drop a control{0}on the Glow Box", Environment.NewLine), new Font("Arial", 8F, FontStyle.Bold), new Point(20, 20), Color.DarkBlue);
				TextRenderer.DrawText(e.Graphics, "Zeroit Dev © 2018", new Font("Arial", 7F, FontStyle.Bold), new Point(Width - 95, Height - 17), Color.DarkGray);

			}
			else if (_glowOn)
			{

			    switch (_effectType)
			    {
                    case Effects.Glow:
                        using (GraphicsPath gp = new GraphicsPath())
                        {

                            //Get a Rectangle a little smaller than the Panel's
                            //and make a GraphicsPath with it
                            Rectangle rect = DisplayRectangle;
                            rect.Inflate(-5, -5);
                            gp.AddRectangle(rect);

                            //Draw multiple rectangles with increasing thickness and transparency
                            for (int i = 1; i <= _Glow; i += 2)
                            {
                                int aGlow = Convert.ToInt32(_Feather - ((_Feather / (double)_Glow) * i));
                                using (Pen pen = new Pen(Color.FromArgb(aGlow, _glowColor), i) { LineJoin = LineJoin.Round })
                                {

                                    e.Graphics.DrawPath(pen, gp);

                                }

                            }

                        }
                        break;

                    case Effects.Shadow:
                        using (GraphicsPath shadowpath = new GraphicsPath())
                        {
                            _ShadowColor = _glowColor;

                            Rectangle rect = new Rectangle(DisplayRectangle.X + 4 + _ShadowOffset.X, DisplayRectangle.Y + 4 + _ShadowOffset.Y, DisplayRectangle.Width - 8, DisplayRectangle.Height - 8);
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

                        break;

                    default:
                        break;  

			    }

				
			}

		}
        #endregion

        #region Sizing

        /// <summary>
        /// Handles the Layout event of the gZeroitGlowBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing the event data.</param>
        private void gZeroitGlowBox_Layout(object sender, LayoutEventArgs e)
		{

			//Resize the gZeroitGlowBox to fit in the Child Control size
			if (Controls.Count > 0)
			{
				if (e.AffectedControl == Controls[0])
				{
					Size = new Size(Controls[0].Width + 7, Controls[0].Height + 7);
					Controls[0].Location = new Point(4, 4);
					Invalidate();
				}

			}

		}

        /// <summary>
        /// Handles the Resize event of the gZeroitGlowBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void gZeroitGlowBox_Resize(object sender, System.EventArgs e)
		{

			//This is needed to avoid resizing an Anchored gZeroitGlowBox when the parent Form is Minimized 
			if ((FindForm() == null) || FindForm().WindowState == FormWindowState.Minimized)
			{
				return;
			}

			//Resize the Child Control to fit the size of the gZeroitGlowBox
			if (Controls.Count > 0)
			{
				Controls[0].Size = new Size(Width - 7, Height - 7);
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

			if (Controls.Count > 0)
			{
				//Check if the control has the ReadOnly property and if so, its value.
				if (!((Controls[0].GetType().GetProperty("ReadOnly") == null)))
				{
					GlowOn = !(bool)(Interaction.CallByName(Controls[0], "ReadOnly", Microsoft.VisualBasic.CallType.Get));
				}
				else
				{
					GlowOn = true;
				}

			}

		}

        /// <summary>
        /// Childs the lost focus.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChildLostFocus(object sender, EventArgs e)
		{
			GlowOn = false;
		}
        #endregion

	}


}