// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 02-13-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="LedButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Led Button

    /// <summary>
    /// The LEDBulb is a .Net control for Windows Forms that emulates a
    /// LED light with two states On and Off.
    /// <para>The purpose of the control is to
    /// provide a sleek looking representation of an LED light that is sizable,
    /// has a transparent background and can be set to different colors.
    /// </para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
	public partial class ZeroitButtonLedBulb : Control
    {
        #region Enums

        /// <summary>
        /// The blinks
        /// </summary>
        private Blinks blinks = Blinks.Once;

        /// <summary>
        /// Enum representing the number of times to Blink
        /// </summary>
        public enum Blinks
        {
            /// <summary>
            /// The once
            /// </summary>
            Once,
            /// <summary>
            /// The infinite
            /// </summary>
            Infinite
        }

        /// <summary>
        /// Gets or sets the type of the blink.
        /// </summary>
        /// <value>The type of the blink.</value>
        public Blinks BlinkType
        {
            get { return blinks; }
            set
            {
                blinks = value;
                Invalidate();
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// The color
        /// </summary>
        private Color _color;
        /// <summary>
        /// The on
        /// </summary>
        private bool _on = true;
        /// <summary>
        /// The reflection color
        /// </summary>
        private Color _reflectionColor = Color.FromArgb(180, 255, 255, 255);
        /// <summary>
        /// The surround color
        /// </summary>
        private Color[] _surroundColor = new Color[] { Color.FromArgb(0, 255, 255, 255) };
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The blink
        /// </summary>
        private int _blink = 0;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the number of blinks.
        /// </summary>
        /// <value>The number of blinks.</value>
        public int NumberOfBlinks
        {
            get { return _blink; }
            set
            {
                _blink = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets the color of the LED light
        /// </summary>
        /// <value>The color.</value>
        [DefaultValue(typeof(Color), "153, 255, 54")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                this.DarkColor = ControlPaint.Dark(_color);
                this.DarkDarkColor = ControlPaint.DarkDark(_color);
                this.Invalidate();  // Redraw the control
            }
        }

        /// <summary>
        /// Dark shade of the LED color used for gradient
        /// </summary>
        /// <value>The color of the dark.</value>
        public Color DarkColor { get; protected set; }

        /// <summary>
        /// Very dark shade of the LED color used for gradient
        /// </summary>
        /// <value>The color of the dark dark.</value>
        public Color DarkDarkColor { get; protected set; }

        /// <summary>
        /// Gets or Sets whether the light is turned on
        /// </summary>
        /// <value><c>true</c> if on; otherwise, <c>false</c>.</value>
        public bool On
        {
            get { return _on; }
            set { _on = value; this.Invalidate(); }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonLedBulb" /> class.
        /// </summary>
        public ZeroitButtonLedBulb()
        {
            SetStyle(ControlStyles.DoubleBuffer
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.ResizeRedraw
            | ControlStyles.UserPaint
            | ControlStyles.SupportsTransparentBackColor, true);

            this.Color = Color.FromArgb(255, 153, 255, 54);
            _timer.Tick += new EventHandler(
                (object sender, EventArgs e) => { this.On = !this.On; }
            );

            this.Click += BlinkLight;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Handles the Paint event for this UserControl
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Create an offscreen graphics object for double buffering
            Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                // Draw the control
                drawControl(g, this.On);
                // Draw the image to the screen
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
            }
        }

        /// <summary>
        /// Renders the control to an image
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="on">if set to <c>true</c> [on].</param>
        private void drawControl(Graphics g, bool on)
        {
            // Is the bulb on or off
            Color lightColor = (on) ? this.Color : Color.FromArgb(150, this.DarkColor);
            Color darkColor = (on) ? this.DarkColor : this.DarkDarkColor;

            // Calculate the dimensions of the bulb
            int width = this.Width - (this.Padding.Left + this.Padding.Right);
            int height = this.Height - (this.Padding.Top + this.Padding.Bottom);
            // Diameter is the lesser of width and height
            int diameter = Math.Min(width, height);
            // Subtract 1 pixel so ellipse doesn't get cut off
            diameter = Math.Max(diameter - 1, 1);

            // Draw the background ellipse
            var rectangle = new Rectangle(this.Padding.Left, this.Padding.Top, diameter, diameter);
            g.FillEllipse(new SolidBrush(darkColor), rectangle);

            // Draw the glow gradient
            var path = new GraphicsPath();
            path.AddEllipse(rectangle);
            var pathBrush = new PathGradientBrush(path);
            pathBrush.CenterColor = lightColor;
            pathBrush.SurroundColors = new Color[] { Color.FromArgb(0, lightColor) };
            g.FillEllipse(pathBrush, rectangle);

            // Draw the white reflection gradient
            var offset = Convert.ToInt32(diameter * .15F);
            var diameter1 = Convert.ToInt32(rectangle.Width * .8F);
            var whiteRect = new Rectangle(rectangle.X - offset, rectangle.Y - offset, diameter1, diameter1);
            var path1 = new GraphicsPath();
            path1.AddEllipse(whiteRect);
            var pathBrush1 = new PathGradientBrush(path);
            pathBrush1.CenterColor = _reflectionColor;
            pathBrush1.SurroundColors = _surroundColor;
            g.FillEllipse(pathBrush1, whiteRect);

            // Draw the border
            g.SetClip(this.ClientRectangle);
            if (this.On) g.DrawEllipse(new Pen(Color.FromArgb(85, Color.Black), 1F), rectangle);
        }

        /// <summary>
        /// Causes the Led to start blinking
        /// </summary>
        /// <param name="milliseconds">Number of milliseconds to blink for. 0 stops blinking</param>
        public void Blink(int milliseconds)
        {
            if (milliseconds > 0)
            {
                this.On = true;
                _timer.Interval = milliseconds;
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = false;
                this.On = false;
            }
        }

        #endregion

        #region Led On and Blink


        // Turn the bulb On or Off
        /// <summary>
        /// Handles the <see cref="E:Light" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnLight(object sender, EventArgs e)
        {
            ((ZeroitButtonLedBulb)sender).On = !((ZeroitButtonLedBulb)sender).On;
        }


        //Led Bulb Blink
        /// <summary>
        /// Blinks the light.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BlinkLight(object sender, EventArgs e)
        {
            switch (blinks)
            {
                case Blinks.Once:
                    ((ZeroitButtonLedBulb)sender).On = !((ZeroitButtonLedBulb)sender).On;
                    break;
                case Blinks.Infinite:
                    //if (_blink == 0) _blink = 500;
                    //else _blink = 0;
                    ((ZeroitButtonLedBulb)sender).Blink(_blink);
                    break;

                default:
                    break;
            }

        }

        #endregion
    }
    #endregion


}
