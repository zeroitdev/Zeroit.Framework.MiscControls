// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="KokonsaSwitchButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitKokonsaSwitch.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKokonsaSwitch : Control
    {
        /// <summary>
        /// Delegate SliderChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Occurs when [slider value changed].
        /// </summary>
        public event SliderChangedEventHandler SliderValueChanged;

        #region Variables
        /// <summary>
        /// The diameter
        /// </summary>
        float diameter;
        /// <summary>
        /// The rect
        /// </summary>
        RoundedRectangleF rect;
        /// <summary>
        /// The circle
        /// </summary>
        RectangleF circle;
        /// <summary>
        /// The is on
        /// </summary>
        private bool isOn;
        /// <summary>
        /// The artis
        /// </summary>
        float artis;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// The text enabled
        /// </summary>
        private bool textEnabled;
        /// <summary>
        /// The paint ticker
        /// </summary>
        System.Windows.Forms.Timer paintTicker = new System.Windows.Forms.Timer();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [text enabled].
        /// </summary>
        /// <value><c>true</c> if [text enabled]; otherwise, <c>false</c>.</value>
        public bool TextEnabled
        {
            get { return textEnabled; }
            set
            {
                textEnabled = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is on.
        /// </summary>
        /// <value><c>true</c> if this instance is on; otherwise, <c>false</c>.</value>
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                paintTicker.Stop();
                isOn = value;
                paintTicker.Start();
                if (SliderValueChanged != null)
                    SliderValueChanged(this, EventArgs.Empty);
            }
        }
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

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKokonsaSwitch"/> class.
        /// </summary>
        public ZeroitKokonsaSwitch()
        {

            Cursor = Cursors.Hand;
            DoubleBuffered = true;

            artis = 4; //increment for sliding animation
            diameter = 30;
            textEnabled = true;
            rect = new RoundedRectangleF(2 * diameter, diameter + 2, diameter / 2, 1, 1);
            circle = new RectangleF(1, 1, diameter, diameter);
            isOn = true;
            borderColor = Color.LightGray;

            paintTicker.Tick += paintTicker_Tick;
            paintTicker.Interval = 1;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Width = (Height - 2) * 2;
            diameter = Width / 2;
            artis = 4 * diameter / 30;
            rect = new RoundedRectangleF(2 * diameter, diameter + 2, diameter / 2, 1, 1);
            circle = new RectangleF(!isOn ? 1 : Width - diameter - 1, 1, diameter, diameter);
            base.OnResize(e);
        }
        //creates slide animation
        /// <summary>
        /// Handles the Tick event of the paintTicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = circle.X;

            if (isOn)           //switch the circle to the left
            {
                if (x + artis <= Width - diameter - 1)
                {
                    x += artis;
                    circle = new RectangleF(x, 1, diameter, diameter);

                    Invalidate();
                }
                else
                {
                    x = Width - diameter - 1;
                    circle = new RectangleF(x, 1, diameter, diameter);

                    Invalidate();
                    paintTicker.Stop();
                }

            }
            else //switch the circle to the left with animation
            {
                if (x - artis >= 1)
                {
                    x -= artis;
                    circle = new RectangleF(x, 1, diameter, diameter);

                    Invalidate();
                }
                else
                {
                    x = 1;
                    circle = new RectangleF(x, 1, diameter, diameter);

                    Invalidate();
                    paintTicker.Stop();

                }
            }
        }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(60, 35);
            }
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (Enabled)
            {
                using (SolidBrush brush = new SolidBrush(isOn ? Color.LightGreen : Color.LightGray))
                    e.Graphics.FillPath(brush, rect.Path);

                using (Pen pen = new Pen(borderColor, 2f))
                    e.Graphics.DrawPath(pen, rect.Path);

                string on = "ON";
                string off = "OFF";
                if (textEnabled)
                    using (Font font = new Font("Arial", 8.2f * diameter / 30, FontStyle.Bold))
                    {
                        int height = TextRenderer.MeasureText(on, font).Height;
                        float y = (diameter - height) / 2f;
                        e.Graphics.DrawString(on, font, Brushes.Gray, 5, y + 1);

                        height = TextRenderer.MeasureText(off, font).Height;
                        y = (diameter - height) / 2f;
                        e.Graphics.DrawString(off, font, Brushes.Gray, diameter + 2, y + 1);
                    }

                using (SolidBrush circleBrush = new SolidBrush("#f6f0e6".FromHex()))
                    e.Graphics.FillEllipse(circleBrush, circle);

                using (Pen pen = new Pen(Color.LightGray, 1.2f))
                    e.Graphics.DrawEllipse(pen, circle);

            }
            else
            {
                using (SolidBrush disableBrush = new SolidBrush("#CFCFCF".FromHex()))
                using (SolidBrush ellBrush = new SolidBrush("#B3B3B3".FromHex()))
                {
                    e.Graphics.FillPath(disableBrush, rect.Path);
                    e.Graphics.FillEllipse(ellBrush, circle);
                    e.Graphics.DrawEllipse(Pens.DarkGray, circle);
                }
            }

            base.OnPaint(e);

        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            isOn = !isOn;
            IsOn = isOn;

            base.OnMouseClick(e);
        }

        
    }

    /// <summary>
    /// Class HexConvert.
    /// </summary>
    public static class HexConvert
    {
        /// <summary>
        /// Froms the hexadecimal.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns>Color.</returns>
        public static Color FromHex(this string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }
    }

    /// <summary>
    /// Class RoundedRectangleF.
    /// </summary>
    public class RoundedRectangleF
    {

        /// <summary>
        /// The location
        /// </summary>
        Point location;
        /// <summary>
        /// The radius
        /// </summary>
        float radius;
        /// <summary>
        /// The gr path
        /// </summary>
        GraphicsPath grPath;
        /// <summary>
        /// The x
        /// </summary>
        float x, y;
        /// <summary>
        /// The width
        /// </summary>
        float width, height;


        /// <summary>
        /// Initializes a new instance of the <see cref="RoundedRectangleF"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public RoundedRectangleF(float width, float height, float radius, float x = 0, float y = 0)
        {

            location = new Point(0, 0);
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            grPath = new GraphicsPath();
            if (radius <= 0)
            {
                grPath.AddRectangle(new RectangleF(x, y, width, height));
                return;
            }
            RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
            RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
            RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
            RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

            grPath.AddArc(upperLeftRect, 180, 90);
            grPath.AddArc(upperRightRect, 270, 90);
            grPath.AddArc(lowerRightRect, 0, 90);
            grPath.AddArc(lowerLeftRect, 90, 90);
            grPath.CloseAllFigures();

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundedRectangleF"/> class.
        /// </summary>
        public RoundedRectangleF()
        {
        }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public GraphicsPath Path
        {
            get
            {
                return grPath;
            }
        }
        /// <summary>
        /// Gets the rect.
        /// </summary>
        /// <value>The rect.</value>
        public RectangleF Rect
        {
            get
            {
                return new RectangleF(x, y, width, height);
            }
        }
        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

    }

}
