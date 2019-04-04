// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TrackBarOval.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

    #region  TrackBarOval    
    /// <summary>
    /// A class collection for rendering a track bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitTrackBarOvalDesigner))]
    [DefaultEvent("ValueChanged")]
    public class ZeroitTrackBarOval : Control
    {

        #region  Enums

        /// <summary>
        /// Enum representing a value divisor
        /// </summary>
        public enum ValueDivisor
        {
            /// <summary>
            /// The by1
            /// </summary>
            By1 = 1,
            /// <summary>
            /// The by10
            /// </summary>
            By10 = 10,
            /// <summary>
            /// The by100
            /// </summary>
            By100 = 100,
            /// <summary>
            /// The by1000
            /// </summary>
            By1000 = 1000
        }


        #region Brush Enum
        /// <summary>
        /// The background
        /// </summary>
        private Color background = Color.White;


        /// <summary>
        /// Enum Background
        /// </summary>
        private enum Background
        {
            /// <summary>
            /// The alice blue
            /// </summary>
            AliceBlue,
            /// <summary>
            /// The antique white
            /// </summary>
            AntiqueWhite,
            /// <summary>
            /// The aqua
            /// </summary>
            Aqua,
            /// <summary>
            /// The aquamarine
            /// </summary>
            Aquamarine,
            /// <summary>
            /// The azure
            /// </summary>
            Azure,
            /// <summary>
            /// The beige
            /// </summary>
            Beige,
            /// <summary>
            /// The bisque
            /// </summary>
            Bisque,
            /// <summary>
            /// The black
            /// </summary>
            Black,
            /// <summary>
            /// The blanched almond
            /// </summary>
            BlanchedAlmond,
            /// <summary>
            /// The blue
            /// </summary>
            Blue,
            /// <summary>
            /// The blue violet
            /// </summary>
            BlueViolet,
            /// <summary>
            /// The brown
            /// </summary>
            Brown,
            /// <summary>
            /// The burly wood
            /// </summary>
            BurlyWood,
            /// <summary>
            /// The cadet blue
            /// </summary>
            CadetBlue,
            /// <summary>
            /// The chartreuse
            /// </summary>
            Chartreuse,
            /// <summary>
            /// The chocolate
            /// </summary>
            Chocolate,
            /// <summary>
            /// The coral
            /// </summary>
            Coral,
            /// <summary>
            /// The cornflower blue
            /// </summary>
            CornflowerBlue,
            /// <summary>
            /// The cornsilk
            /// </summary>
            Cornsilk,
            /// <summary>
            /// The crimson
            /// </summary>
            Crimson,
            /// <summary>
            /// The cyan
            /// </summary>
            Cyan,
            /// <summary>
            /// The dark blue
            /// </summary>
            DarkBlue,
            /// <summary>
            /// The dark cyan
            /// </summary>
            DarkCyan,
            /// <summary>
            /// The dark goldenrod
            /// </summary>
            DarkGoldenrod,
            /// <summary>
            /// The dark gray
            /// </summary>
            DarkGray,
            /// <summary>
            /// The dark green
            /// </summary>
            DarkGreen,
            /// <summary>
            /// The dark khaki
            /// </summary>
            DarkKhaki,
            /// <summary>
            /// The dark magenta
            /// </summary>
            DarkMagenta,
            /// <summary>
            /// The dark olive green
            /// </summary>
            DarkOliveGreen,
            /// <summary>
            /// The dark orange
            /// </summary>
            DarkOrange,
            /// <summary>
            /// The dark orchid
            /// </summary>
            DarkOrchid,
            /// <summary>
            /// The dark red
            /// </summary>
            DarkRed,
            /// <summary>
            /// The dark salmon
            /// </summary>
            DarkSalmon,
            /// <summary>
            /// The dark sea green
            /// </summary>
            DarkSeaGreen,
            /// <summary>
            /// The dark slate blue
            /// </summary>
            DarkSlateBlue,
            /// <summary>
            /// The dark slate gray
            /// </summary>
            DarkSlateGray,
            /// <summary>
            /// The dark turquoise
            /// </summary>
            DarkTurquoise,
            /// <summary>
            /// The dark violet
            /// </summary>
            DarkViolet,
            /// <summary>
            /// The deep pink
            /// </summary>
            DeepPink,
            /// <summary>
            /// The deep sky blue
            /// </summary>
            DeepSkyBlue,
            /// <summary>
            /// The dim gray
            /// </summary>
            DimGray,
            /// <summary>
            /// The dodger blue
            /// </summary>
            DodgerBlue,
            /// <summary>
            /// The firebrick
            /// </summary>
            Firebrick,
            /// <summary>
            /// The floral white
            /// </summary>
            FloralWhite,
            /// <summary>
            /// The forest green
            /// </summary>
            ForestGreen,
            /// <summary>
            /// The fuchsia
            /// </summary>
            Fuchsia,
            /// <summary>
            /// The gainsboro
            /// </summary>
            Gainsboro,
            /// <summary>
            /// The ghost white
            /// </summary>
            GhostWhite,
            /// <summary>
            /// The gold
            /// </summary>
            Gold,
            /// <summary>
            /// The goldenrod
            /// </summary>
            Goldenrod,
            /// <summary>
            /// The gray
            /// </summary>
            Gray,
            /// <summary>
            /// The green
            /// </summary>
            Green,
            /// <summary>
            /// The green yellow
            /// </summary>
            GreenYellow,
            /// <summary>
            /// The honeydew
            /// </summary>
            Honeydew,
            /// <summary>
            /// The hot pink
            /// </summary>
            HotPink,
            /// <summary>
            /// The indian red
            /// </summary>
            IndianRed,
            /// <summary>
            /// The indigo
            /// </summary>
            Indigo,
            /// <summary>
            /// The ivory
            /// </summary>
            Ivory,
            /// <summary>
            /// The khaki
            /// </summary>
            Khaki,
            /// <summary>
            /// The lavender
            /// </summary>
            Lavender,
            /// <summary>
            /// The lavender blush
            /// </summary>
            LavenderBlush,
            /// <summary>
            /// The lawn green
            /// </summary>
            LawnGreen,
            /// <summary>
            /// The lemon chiffon
            /// </summary>
            LemonChiffon,
            /// <summary>
            /// The light blue
            /// </summary>
            LightBlue,
            /// <summary>
            /// The light coral
            /// </summary>
            LightCoral,
            /// <summary>
            /// The light cyan
            /// </summary>
            LightCyan,
            /// <summary>
            /// The light goldenrod yellow
            /// </summary>
            LightGoldenrodYellow,
            /// <summary>
            /// The light gray
            /// </summary>
            LightGray,
            /// <summary>
            /// The light green
            /// </summary>
            LightGreen,
            /// <summary>
            /// The light pink
            /// </summary>
            LightPink,
            /// <summary>
            /// The light salmon
            /// </summary>
            LightSalmon,
            /// <summary>
            /// The light sea green
            /// </summary>
            LightSeaGreen,
            /// <summary>
            /// The light sky blue
            /// </summary>
            LightSkyBlue,
            /// <summary>
            /// The light slate gray
            /// </summary>
            LightSlateGray,
            /// <summary>
            /// The light steel blue
            /// </summary>
            LightSteelBlue,
            /// <summary>
            /// The light yellow
            /// </summary>
            LightYellow,
            /// <summary>
            /// The lime
            /// </summary>
            Lime,
            /// <summary>
            /// The lime green
            /// </summary>
            LimeGreen,
            /// <summary>
            /// The linen
            /// </summary>
            Linen,
            /// <summary>
            /// The magenta
            /// </summary>
            Magenta,
            /// <summary>
            /// The maroon
            /// </summary>
            Maroon,
            /// <summary>
            /// The medium aquamarine
            /// </summary>
            MediumAquamarine,
            /// <summary>
            /// The medium blue
            /// </summary>
            MediumBlue,
            /// <summary>
            /// The medium orchid
            /// </summary>
            MediumOrchid,
            /// <summary>
            /// The medium purple
            /// </summary>
            MediumPurple,
            /// <summary>
            /// The medium sea green
            /// </summary>
            MediumSeaGreen,
            /// <summary>
            /// The medium slate blue
            /// </summary>
            MediumSlateBlue,
            /// <summary>
            /// The medium spring green
            /// </summary>
            MediumSpringGreen,
            /// <summary>
            /// The medium turquoise
            /// </summary>
            MediumTurquoise,
            /// <summary>
            /// The medium violet red
            /// </summary>
            MediumVioletRed,
            /// <summary>
            /// The midnight blue
            /// </summary>
            MidnightBlue,
            /// <summary>
            /// The mint cream
            /// </summary>
            MintCream,
            /// <summary>
            /// The misty rose
            /// </summary>
            MistyRose,
            /// <summary>
            /// The moccasin
            /// </summary>
            Moccasin,
            /// <summary>
            /// The navajo white
            /// </summary>
            NavajoWhite,
            /// <summary>
            /// The navy
            /// </summary>
            Navy,
            /// <summary>
            /// The old lace
            /// </summary>
            OldLace,
            /// <summary>
            /// The olive
            /// </summary>
            Olive,
            /// <summary>
            /// The olive drab
            /// </summary>
            OliveDrab,
            /// <summary>
            /// The orange
            /// </summary>
            Orange,
            /// <summary>
            /// The orange red
            /// </summary>
            OrangeRed,
            /// <summary>
            /// The orchid
            /// </summary>
            Orchid,
            /// <summary>
            /// The pale goldenrod
            /// </summary>
            PaleGoldenrod,
            /// <summary>
            /// The pale green
            /// </summary>
            PaleGreen,
            /// <summary>
            /// The pale turquoise
            /// </summary>
            PaleTurquoise,
            /// <summary>
            /// The pale violet red
            /// </summary>
            PaleVioletRed,
            /// <summary>
            /// The papaya whip
            /// </summary>
            PapayaWhip,
            /// <summary>
            /// The peach puff
            /// </summary>
            PeachPuff,
            /// <summary>
            /// The peru
            /// </summary>
            Peru,
            /// <summary>
            /// The pink
            /// </summary>
            Pink,
            /// <summary>
            /// The plum
            /// </summary>
            Plum,
            /// <summary>
            /// The powder blue
            /// </summary>
            PowderBlue,
            /// <summary>
            /// The purple
            /// </summary>
            Purple,
            /// <summary>
            /// The red
            /// </summary>
            Red,
            /// <summary>
            /// The rosy brown
            /// </summary>
            RosyBrown,
            /// <summary>
            /// The royal blue
            /// </summary>
            RoyalBlue,
            /// <summary>
            /// The saddle brown
            /// </summary>
            SaddleBrown,
            /// <summary>
            /// The salmon
            /// </summary>
            Salmon,
            /// <summary>
            /// The sandy brown
            /// </summary>
            SandyBrown,
            /// <summary>
            /// The sea green
            /// </summary>
            SeaGreen,
            /// <summary>
            /// The sea shell
            /// </summary>
            SeaShell,
            /// <summary>
            /// The sienna
            /// </summary>
            Sienna,
            /// <summary>
            /// The silver
            /// </summary>
            Silver,
            /// <summary>
            /// The sky blue
            /// </summary>
            SkyBlue,
            /// <summary>
            /// The slate blue
            /// </summary>
            SlateBlue,
            /// <summary>
            /// The slate gray
            /// </summary>
            SlateGray,
            /// <summary>
            /// The snow
            /// </summary>
            Snow,
            /// <summary>
            /// The spring green
            /// </summary>
            SpringGreen,
            /// <summary>
            /// The steel blue
            /// </summary>
            SteelBlue,
            /// <summary>
            /// The tan
            /// </summary>
            Tan,
            /// <summary>
            /// The teal
            /// </summary>
            Teal,
            /// <summary>
            /// The thistle
            /// </summary>
            Thistle,
            /// <summary>
            /// The tomato
            /// </summary>
            Tomato,
            /// <summary>
            /// The transparent
            /// </summary>
            Transparent,
            /// <summary>
            /// The turquoise
            /// </summary>
            Turquoise,
            /// <summary>
            /// The violet
            /// </summary>
            Violet,
            /// <summary>
            /// The wheat
            /// </summary>
            Wheat,
            /// <summary>
            /// The white
            /// </summary>
            White,
            /// <summary>
            /// The white smoke
            /// </summary>
            WhiteSmoke,
            /// <summary>
            /// The yellow green
            /// </summary>
            YellowGreen
        }

        #endregion


        #endregion

        #region  Variables

        /// <summary>
        /// The pipe border
        /// </summary>
        private GraphicsPath PipeBorder;
        /// <summary>
        /// The fill value
        /// </summary>
        private GraphicsPath FillValue;
        /// <summary>
        /// The track bar handle rect
        /// </summary>
        private Rectangle TrackBarHandleRect;
        /// <summary>
        /// The cap
        /// </summary>
        private bool Cap;
        /// <summary>
        /// The value drawer
        /// </summary>
        private int ValueDrawer;

        /// <summary>
        /// The thumb size
        /// </summary>
        private Size ThumbSize = new Size(15, 15);
        /// <summary>
        /// The track thumb
        /// </summary>
        private Rectangle TrackThumb;

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 50;

        /// <summary>
        /// The draw value string
        /// </summary>
        private bool _DrawValueString = false;
        /// <summary>
        /// The jump to mouse
        /// </summary>
        private bool _JumpToMouse = false;
        /// <summary>
        /// The divided value
        /// </summary>
        private ValueDivisor DividedValue = ValueDivisor.By1;

        /// <summary>
        /// The back ground color
        /// </summary>
        private Color backGroundColor = Color.FromArgb(221, 221, 221);
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// The value color
        /// </summary>
        private Color valueColor = Color.FromArgb(128, 128, 255);
        /// <summary>
        /// The ellipse color
        /// </summary>
        private Color ellipseColor = Color.FromArgb(192, 192, 255);
        /// <summary>
        /// The ellipse border color
        /// </summary>
        private Color ellipseBorderColor = Color.Black;

        /// <summary>
        /// The percent symbol
        /// </summary>
        private string percentSymbol = "%";
        #endregion

        #region  Properties

        /// <summary>
        /// The string position
        /// </summary>
        private float stringPosition = 212f;

        /// <summary>
        /// Gets or sets the string postion.
        /// </summary>
        /// <value>The string postion.</value>
        public float StringPostion
        {
            get { return stringPosition; }
            set
            {
                stringPosition = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return background; }
            set
            {
                background = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the back ground.
        /// </summary>
        /// <value>The color of the back ground.</value>
        public Color BackGroundColor
        {
            get { return backGroundColor; }
            set
            {
                backGroundColor = value;
                Invalidate();
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

        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        public Color ValueColor
        {
            get { return valueColor; }
            set
            {
                valueColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the color of the ellipse.
        /// </summary>
        /// <value>The color of the ellipse.</value>
        public Color EllipseColor
        {
            get { return ellipseColor; }
            set
            {
                ellipseColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the ellipse's border.
        /// </summary>
        /// <value>The color of the ellipse's border.</value>
        public Color EllipseBorderColor
        {
            get { return ellipseBorderColor; }
            set
            {
                ellipseBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {

                if (value >= _Maximum)
                {
                    value = _Maximum - 10;
                }
                if (_Value < value)
                {
                    _Value = value;
                }

                _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {

                if (value <= _Minimum)
                {
                    value = _Minimum + 10;
                }
                if (_Value > value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        public delegate void ValueChangedEventHandler();
        /// <summary>
        /// The value changed event
        /// </summary>
        private ValueChangedEventHandler ValueChangedEvent;

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ValueChangedEventHandler ValueChanged
        {
            add
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Combine(ValueChangedEvent, value);
            }
            remove
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Remove(ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    if (value < _Minimum)
                    {
                        _Value = _Minimum;
                    }
                    else
                    {
                        if (value > _Maximum)
                        {
                            _Value = _Maximum;
                        }
                        else
                        {
                            _Value = value;
                        }
                    }
                    Invalidate();
                    if (ValueChangedEvent != null)
                        ValueChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value divisor.
        /// </summary>
        /// <value>The value divisor.</value>
        public ValueDivisor ValueDivison
        {
            get
            {
                return DividedValue;
            }
            set
            {
                DividedValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value to set.
        /// </summary>
        /// <value>The value to set.</value>
        [Browsable(false)]
        public float ValueToSet
        {
            get
            {
                return _Value / (int)DividedValue;
            }
            set
            {
                Value = (int)(value * (int)DividedValue);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to jump to mouse.
        /// </summary>
        /// <value><c>true</c> if jump to mouse; otherwise, <c>false</c>.</value>
        public bool JumpToMouse
        {
            get
            {
                return _JumpToMouse;
            }
            set
            {
                _JumpToMouse = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw value string.
        /// </summary>
        /// <value><c>true</c> if draw value string; otherwise, <c>false</c>.</value>
        public bool DrawValueString
        {
            get
            {
                return _DrawValueString;
            }
            set
            {
                _DrawValueString = value;
                if (_DrawValueString == true)
                {
                    Height = 35;
                }
                else
                {
                    Height = 22;
                }
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            checked
            {
                bool flag = this.Cap && e.X > -1 && e.X < this.Width + 1;
                if (flag)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            bool flag = e.Button == MouseButtons.Left;
            checked
            {
                if (flag)
                {
                    this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
                    this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 25, 25);
                    this.Cap = this.TrackBarHandleRect.Contains(e.Location);
                    this.Focus();
                    flag = this._JumpToMouse;
                    if (flag)
                    {
                        this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTrackBarOval" /> class.
        /// </summary>
        public ZeroitTrackBarOval()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor), true);

            Size = new Size(440, 35);
            MinimumSize = new Size(47, 22);

            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_DrawValueString == true)
            {
                Height = 35;
            }
            else
            {
                Height = 22;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            //G.Clear(Parent.BackColor);
            G.SmoothingMode = smoothing;
            TrackThumb = new Rectangle(8, 10, Width - 16, 2);
            PipeBorder = RoundRectangle.RoundRect(1, 8, Width - 3, 5, 2);

            try
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
            }
            catch (Exception)
            {
            }

            TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);

            G.SetClip(PipeBorder); // Set the clipping region of this Graphics to the specified GraphicsPath
            G.FillPath(new SolidBrush(backGroundColor), PipeBorder);
            FillValue = RoundRectangle.RoundRect(1, 8, TrackBarHandleRect.X + TrackBarHandleRect.Width - 4, 5, 2);

            G.ResetClip(); // Reset the clip region of this Graphics to an infinite region

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.DrawPath(new Pen(borderColor), PipeBorder); // Draw pipe border
            G.FillPath(new SolidBrush(valueColor), FillValue);

            G.FillEllipse(new SolidBrush(ellipseColor), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
            G.DrawEllipse(new Pen(ellipseBorderColor), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);

            if (_DrawValueString == true)
            {
                G.DrawString(System.Convert.ToString(ValueToSet + percentSymbol), Font, new SolidBrush(background), stringPosition, 20);

                
                //G.DrawString(System.Convert.ToString(ValueToSet), Font, Brushes.DimGray, stringPosition, 20);
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitTrackBarOvalDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitTrackBarOvalDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitTrackBarOvalSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitTrackBarOvalSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitTrackBarOvalSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitTrackBarOval colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTrackBarOvalSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitTrackBarOvalSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitTrackBarOval;

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

        /// <summary>
        /// Gets or sets the color of the back ground.
        /// </summary>
        /// <value>The color of the back ground.</value>
        public Color BackGroundColor
        {
            get
            {
                return colUserControl.BackGroundColor;
            }
            set
            {
                GetPropertyByName("BackGroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        public Color ValueColor
        {
            get
            {
                return colUserControl.ValueColor;
            }
            set
            {
                GetPropertyByName("ValueColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the ellipse.
        /// </summary>
        /// <value>The color of the ellipse.</value>
        public Color EllipseColor
        {
            get
            {
                return colUserControl.EllipseColor;
            }
            set
            {
                GetPropertyByName("EllipseColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the ellipse border.
        /// </summary>
        /// <value>The color of the ellipse border.</value>
        public Color EllipseBorderColor
        {
            get
            {
                return colUserControl.EllipseBorderColor;
            }
            set
            {
                GetPropertyByName("EllipseBorderColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value divison.
        /// </summary>
        /// <value>The value divison.</value>
        public Zeroit.Framework.MiscControls.ZeroitTrackBarOval.ValueDivisor ValueDivison
        {
            get
            {
                return colUserControl.ValueDivison;
            }
            set
            {
                GetPropertyByName("ValueDivison").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [jump to mouse].
        /// </summary>
        /// <value><c>true</c> if [jump to mouse]; otherwise, <c>false</c>.</value>
        public bool JumpToMouse
        {
            get
            {
                return colUserControl.JumpToMouse;
            }
            set
            {
                GetPropertyByName("JumpToMouse").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw value string].
        /// </summary>
        /// <value><c>true</c> if [draw value string]; otherwise, <c>false</c>.</value>
        public bool DrawValueString
        {
            get
            {
                return colUserControl.DrawValueString;
            }
            set
            {
                GetPropertyByName("DrawValueString").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the string postion.
        /// </summary>
        /// <value>The string postion.</value>
        public float StringPostion
        {
            get
            {
                return colUserControl.StringPostion;
            }
            set
            {
                GetPropertyByName("StringPostion").SetValue(colUserControl, value);
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
                                 "Sets the BackColor."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the smoothing mode."));

            items.Add(new DesignerActionPropertyItem("BackGroundColor",
                                 "BackGround Color", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("ValueColor",
                                 "Value Color", "Appearance",
                                 "Sets the value color."));

            items.Add(new DesignerActionPropertyItem("EllipseColor",
                                 "Ellipse Color", "Appearance",
                                 "Sets the handle color."));

            items.Add(new DesignerActionPropertyItem("EllipseBorderColor",
                                 "Ellipse Border Color", "Appearance",
                                 "Sets the handle border color."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the control."));

            items.Add(new DesignerActionPropertyItem("ValueDivison",
                                 "Value Divison", "Appearance",
                                 "Sets how the value can be divided by."));

            items.Add(new DesignerActionPropertyItem("JumpToMouse",
                                 "Jump To Mouse", "Appearance",
                                 "Set to allow mouse to set value."));

            items.Add(new DesignerActionPropertyItem("DrawValueString",
                                 "Draw Value String", "Appearance",
                                 "Set to show the progress percentage."));

            items.Add(new DesignerActionPropertyItem("StringPostion",
                                 "String Postion", "Appearance",
                                 "Set the location of the progress percentage."));

            items.Add(new DesignerActionPropertyItem("TextColor",
                                 "Text Color", "Appearance",
                                 "Set the color of the text."));

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
