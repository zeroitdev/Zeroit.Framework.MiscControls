// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroKnob.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.MiscControls;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a metro-style knob.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("A class for creating metro knob.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitSimpleKnob))]
    [Designer(typeof(ZeroitMetroKnobDesigner))]
    public class ZeroitSimpleKnob : Control
	{
        #region Enum

	    /// <summary>
	    /// Enum MouseState
	    /// </summary>
	    public enum MouseState
	    {
	        /// <summary>
	        /// The none
	        /// </summary>
	        None,
	        /// <summary>
	        /// The over
	        /// </summary>
	        Over,
	        /// <summary>
	        /// The pressed
	        /// </summary>
	        Pressed
	    }

        /// <summary>
        /// Enum representing the Knob Fill Modes
        /// </summary>
        public enum KnobFillModes
	    {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The linear gradient
            /// </summary>
            LinearGradient,
            /// <summary>
            /// The radial gradient
            /// </summary>
            RadialGradient,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch
        }

        /// <summary>
        /// Enum representing Knob Styles
        /// </summary>
        public enum KnobStyles
	    {
            /// <summary>
            /// The arc
            /// </summary>
            Arc,
            /// <summary>
            /// The arc filled
            /// </summary>
            ArcFilled,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The circle filled
            /// </summary>
            CircleFilled
        }

        #endregion

        #region Events and Delegates

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ZeroitSimpleKnob.ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedEventHandler(object sender, EventArgs e);


        #endregion

        #region Private Fields

        /// <summary>
        /// The moving percentage
        /// </summary>
        private bool movingPercentage = true;

        /// <summary>
        /// The show percentage
        /// </summary>
        private bool showPercentage = true;

        /// <summary>
        /// The post fix
        /// </summary>
        private string postFix = "%";

        /// <summary>
        /// The show border
        /// </summary>
        private bool showBorder = true;
        /// <summary>
        /// The percentage
        /// </summary>
        private float percentage;

        /// <summary>
        /// The base angle
        /// </summary>
        private float baseAngle;

        /// <summary>
        /// The block angle
        /// </summary>
        private float blockAngle;

        /// <summary>
        /// The line end
        /// </summary>
        private int lineEnd;

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum;

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;

        /// <summary>
        /// The line length
        /// </summary>
        private int _LineLength;

        /// <summary>
        /// The line width
        /// </summary>
        private int _LineWidth;

        /// <summary>
        /// The knob style
        /// </summary>
        private ZeroitSimpleKnob.KnobStyles _KnobStyle;

        /// <summary>
        /// The fill mode
        /// </summary>
        private ZeroitSimpleKnob.KnobFillModes _FillMode;

        /// <summary>
        /// The hatch style
        /// </summary>
        private System.Drawing.Drawing2D.HatchStyle _HatchStyle;

        /// <summary>
        /// The draw line shadow
        /// </summary>
        private bool _DrawLineShadow;

        ///// <summary>
        ///// The style
        ///// </summary>
        //private Design.Style _Style;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor = Color.Black;

        /// <summary>
        /// The line color
        /// </summary>
        private Color _LineColor = Color.LightGray;

        /// <summary>
        /// The accent color
        /// </summary>
        private Color _AccentColor = Color.DarkSlateGray;

        /// <summary>
        /// The fill color
        /// </summary>
        private Color _FillColor = SystemColors.Control;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _GradientColor = Color.FromArgb(100,20,20,20);

        /// <summary>
        /// The default color
        /// </summary>
        private Color shadowColor = Color.FromArgb(40,0,0,0);

        /// <summary>
        /// The automatic style
        /// </summary>
        //private bool _AutoStyle;

        /// <summary>
        /// The mouse state
        /// </summary>
        private MouseState _MouseState = MouseState.None;

        /// <summary>
        /// The circle pen
        /// </summary>
        private PenParameters circlePen = new PenParameters();
        /// <summary>
        /// The line pen
        /// </summary>
        private PenParameters linePen = new PenParameters();
        #endregion

        #region Public Properties 

        /// <summary>
        /// Gets or sets a value indicating whether [show percentage].
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        public bool ShowPercentage
	    {
	        get { return showPercentage; }
	        set
	        {
                showPercentage = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets a value indicating whether [moving percentage].
        /// </summary>
        /// <value><c>true</c> if [moving percentage]; otherwise, <c>false</c>.</value>
        public bool MovingPercentage
	    {
	        get { return movingPercentage; }
	        set
	        {
                movingPercentage = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the post fix.
        /// </summary>
        /// <value>The post fix.</value>
        public string PostFix
	    {
	        get { return postFix; }
	        set
	        {
                postFix = value;
	            Invalidate();
	        }
	    }
        /// <summary>
        /// Gets or sets a value indicating whether [show border].
        /// </summary>
        /// <value><c>true</c> if [show border]; otherwise, <c>false</c>.</value>
        public bool ShowBorder
	    {
	        get { return showBorder; }
	        set
	        {
                showBorder = value;
	            Invalidate();
	        }
	    }
        /// <summary>
        /// Gets or sets the circle properties.
        /// </summary>
        /// <value>The circle pen.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PenParameters CirclePen
        {
            get { return circlePen; }
            set
            {
                circlePen = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the line properties.
        /// </summary>
        /// <value>The line pen.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PenParameters LinePen
        {
            get { return linePen; }
            set
            {
                linePen = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>The color of the accent.</value>
        [Category("Appearance")]
        [Description("Sets the color of the accent.")]
        public Color AccentColor
        {
            get
            {
                return this._AccentColor;
            }
            set
            {
                if (this._AccentColor != value)
                {
                    this._AccentColor = value;
                    this.Invalidate();
                }
            }
        }

        
        /// <summary>
        /// Gets or sets the blocked angle.
        /// </summary>
        /// <value>The blocked angle.</value>
        [Category("Behavior")]
        [DefaultValue(90)]
        [Description("Sets the blocked angle.")]
        public float BlockedAngle
        {
            get
            {
                return this.blockAngle;
            }
            set
            {
                if (value != this.blockAngle)
                {
                    if (this.blockAngle >= 0f & this.blockAngle < 360f)
                    {
                        this.blockAngle = value;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance")]
        [Description("Sets the color of the border.")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                if (this._BorderColor != value)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <value>The context menu strip.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the default color.
        /// </summary>
        /// <value>The default color.</value>
        [Category("Appearance")]
        [Description("Sets the default color.")]
        public Color ShadowColor
        {
            get
            {
                return this.shadowColor;
            }
            set
            {
                if (this.shadowColor != value)
                {
                    this.shadowColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw the line shadow.
        /// </summary>
        /// <value><c>true</c> if [draw line shadow]; otherwise, <c>false</c>.</value>
        [Category("Apperance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw the line shadow.")]
        public bool DrawLineShadow
        {
            get
            {
                return this._DrawLineShadow;
            }
            set
            {
                if (this._DrawLineShadow != value)
                {
                    this._DrawLineShadow = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        [Category("Appearance")]
        [Description("Sets the color of the fill.")]
        public Color FillColor
        {
            get
            {
                return this._FillColor;
            }
            set
            {
                if (this._FillColor != value)
                {
                    this._FillColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        [Category("Apperance")]
        [DefaultValue(0)]
        [Description("Sets the fill mode.")]
        public ZeroitSimpleKnob.KnobFillModes FillMode
        {
            get
            {
                return this._FillMode;
            }
            set
            {
                if (this._FillMode != value)
                {
                    this._FillMode = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.Font Font
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        
        /// <summary>
        /// Gets or sets the color of the gradient.
        /// </summary>
        /// <value>The color of the gradient.</value>
        [Category("Appearance")]
        [Description("Sets the color of the gradient.")]
        public Color GradientColor
        {
            get
            {
                return this._GradientColor;
            }
            set
            {
                if (this._GradientColor != value)
                {
                    this._GradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the hatch style.
        /// </summary>
        /// <value>The hatch style.</value>
        [Category("Apperance")]
        [DefaultValue(3)]
        [Description("Sets the hatch style.")]
        public System.Drawing.Drawing2D.HatchStyle HatchStyle
        {
            get
            {
                return this._HatchStyle;
            }
            set
            {
                if (this._HatchStyle != value)
                {
                    this._HatchStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the knob style.
        /// </summary>
        /// <value>The knob style.</value>
        [Category("Apperance")]
        [DefaultValue(2)]
        [Description("Sets the knob style.")]
        public ZeroitSimpleKnob.KnobStyles KnobStyle
        {
            get
            {
                return this._KnobStyle;
            }
            set
            {
                if (this._KnobStyle != value)
                {
                    this._KnobStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("Appearance")]
        [Description("Sets the color of the line.")]
        public Color LineColor
        {
            get
            {
                return this._LineColor;
            }
            set
            {
                if (this._LineColor != value)
                {
                    this._LineColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the length of the line.
        /// </summary>
        /// <value>The length of the line.</value>
        [Category("Apperance")]
        [DefaultValue(18)]
        [Description("Sets the length of the line.")]
        public int LineLength
        {
            get
            {
                return this._LineLength;
            }
            set
            {
                if (this._LineLength != value)
                {
                    if (value <= 100)
                    {
                        if (value <= 90)
                        {
                            this.lineEnd = 90;
                        }
                        else
                        {
                            this.lineEnd = value;
                        }
                        this._LineLength = value;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Category("Apperance")]
        [DefaultValue(1)]
        [Description("Die Dicke der Linie.")]
        public int LineWidth
        {
            get
            {
                return this._LineWidth;
            }
            set
            {
                if (this._LineWidth != value)
                {
                    this._LineWidth = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Data")]
        [DefaultValue(100)]
        [Description("Sets the maximum.")]
        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                if (this._Maximum != value)
                {
                    this._Maximum = value;
                    if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    if (this._Minimum > this._Maximum)
                    {
                        this._Minimum = this._Maximum;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Data")]
        [DefaultValue(0)]
        [Description("Sets the minimum.")]
        public int Minimum
        {
            get
            {
                return this._Minimum;
            }
            set
            {
                if (this._Minimum != value)
                {
                    this._Minimum = value;
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    if (this._Maximum < this._Minimum)
                    {
                        this._Maximum = this._Minimum;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.RightToLeft RightToLeft
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Data")]
        [DefaultValue(50)]
        [Description("Sets the current value.")]
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (this._Value != value)
                {
                    this._Value = value;
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    else if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    this.percentage = (float)((double)(checked(this._Value - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum)));
                    ZeroitSimpleKnob.ValueChangedEventHandler valueChangedEventHandler = this.ValueChanged;
                    if (valueChangedEventHandler != null)
                    {
                        valueChangedEventHandler(this, new EventArgs());
                    }
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSimpleKnob" /> class.
        /// </summary>
        public ZeroitSimpleKnob()
        {
            this.percentage = 50f;
            this.baseAngle = 90f;
            this.blockAngle = 90f;
            this.lineEnd = 90;
            this._Minimum = 0;
            this._Maximum = 100;
            this._Value = 50;
            this._LineLength = 18;
            this._LineWidth = 1;
            this._KnobStyle = ZeroitSimpleKnob.KnobStyles.Circle;
            this._FillMode = ZeroitSimpleKnob.KnobFillModes.Solid;
            this._HatchStyle = System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal;
            this._DrawLineShadow = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            //this.BackColor = this.FindForm().BackColor;
            this.UpdateStyles();
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Gets the knob brush.
        /// </summary>
        /// <param name="fillMode">The fill mode.</param>
        /// <returns>Brush.</returns>
        private Brush GetKnobBrush(ZeroitSimpleKnob.KnobFillModes fillMode)
        {
            Brush solidBrush;
            Point point = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
            Point point1 = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
            switch (fillMode)
            {
                case ZeroitSimpleKnob.KnobFillModes.Solid:
                    {
                        solidBrush = new SolidBrush(this._FillColor);
                        break;
                    }
                case ZeroitSimpleKnob.KnobFillModes.LinearGradient:
                    {
                        solidBrush = new LinearGradientBrush(point, point1, this._FillColor, this._GradientColor);
                        break;
                    }
                case ZeroitSimpleKnob.KnobFillModes.RadialGradient:
                    {
                        using (GraphicsPath graphicsPath = new GraphicsPath())
                        {
                            int width = checked(this.ClientSize.Width - 1);
                            System.Drawing.Size clientSize = this.ClientSize;
                            Rectangle rectangle = new Rectangle(0, 0, width, checked(clientSize.Height - 1));
                            graphicsPath.AddEllipse(rectangle);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath)
                            {
                                CenterColor = this._FillColor,
                                SurroundColors = new Color[] { this._GradientColor }
                            };
                            solidBrush = pathGradientBrush;
                        }
                        break;
                    }
                default:
                    {
                        solidBrush = new HatchBrush(this._HatchStyle, this._FillColor, this.BackColor);
                        break;
                    }
            }
            return solidBrush;
        }

	    private int dashOffset = 0;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this._MouseState = MouseState.Pressed;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.UpdateAngle(e.X, e.Y);
                circlePen.DashOffset = Math.Abs((e.X + e.Y)/2);
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            this._MouseState = MouseState.Over;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this._MouseState = MouseState.None;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
            {
                this.UpdateAngle(e.X, e.Y);
                circlePen.DashOffset = Math.Abs((e.X + e.Y) / 2);
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._MouseState = MouseState.Over;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransInPaint(e.Graphics);
            System.Drawing.Size size;
            Graphics graphics = e.Graphics;
            float single = this.baseAngle + this.blockAngle / 2f + this.percentage * (360f - this.blockAngle);
            System.Drawing.Size clientSize = this.ClientSize;
            int width = checked(clientSize.Width - 1);
            System.Drawing.Size clientSize1 = this.ClientSize;
            Rectangle rectangle = new Rectangle(0, 0, width, checked(clientSize1.Height - 1));
            clientSize1 = this.ClientSize;
            int num = checked((int)Math.Round((double)clientSize1.Width / 2));
            clientSize = this.ClientSize;
            Point point = new Point(num, checked((int)Math.Round((double)clientSize.Height / 2)));
            Point point1 = new Point(0, 0);
            Point circleIntersectionPoints = GetCircleIntersectionPoints(rectangle, point, point1)[0];

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.Clear(Parent.BackColor);

            if (EnableHatchAnimation)
            {
                graphics.RenderingOrigin = new Point(reactorOFS, 0);
            }

            using (Pen pen = new Pen((this._MouseState == MouseState.None ? this._BorderColor : this._AccentColor))
            {
                Width = circlePen.Width,
                EndCap = circlePen.EndCap,
                StartCap = circlePen.EndCap,
                Alignment = circlePen.Alignment,
                DashCap = circlePen.DashCap,
                DashOffset = circlePen.DashOffset,
                DashStyle = circlePen.DashStyle,
                LineJoin = circlePen.LineJoin,

            })
            {


                switch (this._KnobStyle)
                {
                    case ZeroitSimpleKnob.KnobStyles.Arc:
                        {
                            graphics.DrawArc(pen, rectangle, this.baseAngle + this.blockAngle / 2f, 360f - this.blockAngle);
                            break;
                        }
                    case ZeroitSimpleKnob.KnobStyles.ArcFilled:
                        {
                            Brush knobBrush = this.GetKnobBrush(this._FillMode);
                            graphics.FillEllipse(knobBrush, rectangle);
                            if (ShowBorder)
                                graphics.DrawEllipse(pen, rectangle);
                            using (SolidBrush solidBrush = new SolidBrush(this.BackColor))
                            {
                                Point point2 = circleIntersectionPoints;
                                clientSize1 = this.ClientSize;
                                int num1 = checked((checked(checked((int)Math.Round((double)clientSize1.Width / 2)) - circleIntersectionPoints.X)) * 2);
                                clientSize = this.ClientSize;
                                size = new System.Drawing.Size(num1, checked((checked(checked((int)Math.Round((double)clientSize.Height / 2)) - circleIntersectionPoints.Y)) * 2));
                                Rectangle rectangle1 = new Rectangle(point2, size);
                                graphics.FillEllipse(solidBrush, rectangle1);
                                if (ShowBorder)
                                    graphics.DrawEllipse(pen, rectangle1);
                                rectangle1 = new Rectangle(-1, -1, checked(this.Width + 1), checked(this.Height + 1));

                                graphics.FillPie(solidBrush, rectangle1, (float)(checked(90 - checked((int)Math.Round((double)((float)(this.blockAngle / 2f)))))), this.blockAngle);

                                
                            }
                            knobBrush.Dispose();
                            break;
                        }
                    case ZeroitSimpleKnob.KnobStyles.Circle:
                        {
                            graphics.DrawEllipse(pen, rectangle);
                            break;
                        }
                    case ZeroitSimpleKnob.KnobStyles.CircleFilled:
                        {
                            using (Brush brush = this.GetKnobBrush(this._FillMode))
                            {
                                graphics.FillEllipse(brush, rectangle);

                                if (ShowBorder)
                                    graphics.DrawEllipse(pen, rectangle);
                            }
                            break;
                        }
                }

                Point[] pointOnLine = new Point[2];
                size = this.ClientSize;
                int num2 = checked((int)Math.Round((double)((float)((float)size.Width * 0.5f))));
                clientSize1 = this.ClientSize;
                int num3 = checked((int)Math.Round((double)((float)((float)clientSize1.Height * 0.5f))));
                clientSize = this.ClientSize;
                int num4 = checked((int)Math.Round((double)((float)((float)clientSize.Width * 0.5f * ((float)Math.Cos((double)single * 3.14159265358979 / 180) + 1f)))));
                System.Drawing.Size size1 = this.ClientSize;
                pointOnLine[0] = GetPointOnLine(num2, num3, num4, checked((int)Math.Round((double)((float)((float)size1.Height * 0.5f * ((float)Math.Sin((double)single * 3.14159265358979 / 180) + 1f))))), this.lineEnd);
                System.Drawing.Size clientSize2 = this.ClientSize;
                int num5 = checked((int)Math.Round((double)((float)((float)clientSize2.Width * 0.5f))));
                System.Drawing.Size size2 = this.ClientSize;
                int num6 = checked((int)Math.Round((double)((float)((float)size2.Height * 0.5f))));
                System.Drawing.Size clientSize3 = this.ClientSize;
                int num7 = checked((int)Math.Round((double)((float)((float)clientSize3.Width * 0.5f * ((float)Math.Cos((double)single * 3.14159265358979 / 180) + 1f)))));
                System.Drawing.Size size3 = this.ClientSize;
                pointOnLine[1] = GetPointOnLine(num5, num6, num7, checked((int)Math.Round((double)((float)((float)size3.Height * 0.5f * ((float)Math.Sin((double)single * 3.14159265358979 / 180) + 1f))))), checked(this.lineEnd - this._LineLength));
                Point[] pointArray = pointOnLine;

                Pen pen1 = new Pen(this._MouseState == MouseState.None ? this._BorderColor : this._AccentColor)
                {
                    Width = LinePen.Width,
                    EndCap = LinePen.EndCap,
                    StartCap = LinePen.StartCap,
                    Alignment = LinePen.Alignment,
                    DashCap = LinePen.DashCap,
                    DashOffset = LinePen.DashOffset,
                    DashStyle = LinePen.DashStyle,
                    LineJoin = LinePen.LineJoin,

                };

                if (this._DrawLineShadow)
                {
                    pen1.Width = (float)(checked(this._LineWidth + 2));
                    pen1.Color = ShadowColor;
                    graphics.DrawLine(pen1, pointArray[0], pointArray[1]);
                    pen1.Width = (float)this._LineWidth;
                }
                pen1.Color = (this._MouseState == MouseState.None ? this._LineColor : this._AccentColor);
                graphics.DrawLine(pen1, pointArray[0], pointArray[1]);

                if (ShowPercentage)
                {
                    if (MovingPercentage)
                    {
                        graphics.DrawString(Convert.ToInt32(Value).ToString() + "" + PostFix, Font, new SolidBrush(ForeColor), new PointF(pointArray[0].X, pointArray[1].Y));

                    }
                    else
                    {
                        CenterString(graphics, Convert.ToInt32(Value).ToString() + "" + PostFix, Font, ForeColor,
                            this.ClientRectangle);
                    }
                }
                
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Width, this.Width);
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Updates the angle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void UpdateAngle(int x, int y)
        {
            float single = 360f - this.blockAngle / 2f;
            float single1 = this.blockAngle / 2f;
            double num = (double)y;
            System.Drawing.Size clientSize = this.ClientSize;
            double height = num - (double)clientSize.Height / 2;
            double num1 = (double)x;
            System.Drawing.Size size = this.ClientSize;
            float single2 = Math.Min(single, Math.Max(single1, ((float)(Math.Atan2(height, num1 - (double)size.Width / 2) * 180 / 3.14159265358979) - this.baseAngle + 720f) % 360f));
            this.percentage = (single2 - this.blockAngle / 2f) / (360f - this.blockAngle);
            this._Value = checked(checked((int)Math.Round((double)((float)((float)(checked(this._Maximum - this._Minimum)) * this.percentage)))) + this._Minimum);
            ZeroitSimpleKnob.ValueChangedEventHandler valueChangedEventHandler = this.ValueChanged;
            if (valueChangedEventHandler != null)
            {
                valueChangedEventHandler(this, new EventArgs());
            }
            this.Invalidate();
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Gets the circle intersection points.
        /// </summary>
        /// <param name="ellipse">The ellipse.</param>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        /// <returns>Point[].</returns>
        public static Point[] GetCircleIntersectionPoints(Rectangle ellipse, Point point1, Point point2)
        {
            float single;
            Point point;
            List<Point> points = new List<Point>();
            float x = (float)(checked(ellipse.X + checked((int)Math.Round((double)ellipse.Width / 2))));
            float y = (float)(checked(ellipse.Y + checked((int)Math.Round((double)ellipse.Height / 2))));
            float x1 = (float)(checked(point2.X - point1.X));
            float y1 = (float)(checked(point2.Y - point1.Y));
            float single1 = x1 * x1 + y1 * y1;
            float x2 = 2f * (x1 * ((float)point1.X - x) + y1 * ((float)point1.Y - y));
            float single2 = ((float)point1.X - x) * ((float)point1.X - x) + ((float)point1.Y - y) * ((float)point1.Y - y) - (float)(checked(checked((int)Math.Round((double)ellipse.Width / 2)) * checked((int)Math.Round((double)ellipse.Width / 2))));
            float single3 = x2 * x2 - 4f * single1 * single2;
            if (!((double)single1 <= 1E-07 | single3 < 0f))
            {
                if (single3 != 0f)
                {
                    single = (float)(((double)(-x2) + Math.Sqrt((double)single3)) / (double)(2f * single1));
                    point = new Point(checked((int)Math.Round((double)((float)((float)point1.X + single * x1)))), checked((int)Math.Round((double)((float)((float)point1.Y + single * y1)))));
                    points.Add(point);
                    single = (float)(((double)(-x2) - Math.Sqrt((double)single3)) / (double)(2f * single1));
                    point = new Point(checked((int)Math.Round((double)((float)((float)point1.X + single * x1)))), checked((int)Math.Round((double)((float)((float)point1.Y + single * y1)))));
                    points.Add(point);
                }
                else
                {
                    single = -x2 / (2f * single1);
                    point = new Point(checked((int)Math.Round((double)((float)((float)point1.X + single * x1)))), checked((int)Math.Round((double)((float)((float)point1.Y + single * y1)))));
                    points.Add(point);
                }
            }
            return points.ToArray();
        }

        /// <summary>
        /// Gets the circle intersection points.
        /// </summary>
        /// <param name="ellipse">The ellipse.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>Point[].</returns>
        public static Point[] GetCircleIntersectionPoints(Rectangle ellipse, int x1, int y1, int x2, int y2)
        {
            Point point = new Point(x1, y1);
            Point point1 = new Point(x2, y2);
            return GetCircleIntersectionPoints(ellipse, point, point1);
        }

        /// <summary>
        /// Gets the point on line.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="perc">The perc.</param>
        /// <returns>Point.</returns>
        public static Point GetPointOnLine(Point p1, Point p2, int perc)
        {
            float x = (float)((double)(checked(p2.X - p1.X)) * ((double)perc / 100) + (double)p1.X);
            float y = (float)((double)(checked(p2.Y - p1.Y)) * ((double)perc / 100) + (double)p1.Y);
            Point point = new Point(checked((int)Math.Round((double)x)), checked((int)Math.Round((double)y)));
            return point;
        }

        /// <summary>
        /// Gets the point on line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="perc">The perc.</param>
        /// <returns>Point.</returns>
        public static Point GetPointOnLine(int x1, int y1, int x2, int y2, int perc)
        {
            Point point = new Point(x1, y1);
            Point point1 = new Point(x2, y2);
            return GetPointOnLine(point, point1, perc);
        }

        /// <summary>
        /// Gets the point on line.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="point2">The point2.</param>
        /// <param name="perc">The perc.</param>
        /// <returns>Point.</returns>
        public static Point GetPointOnLine(int x1, int y1, Point point2, int perc)
        {
            Point point = new Point(x1, y1);
            return GetPointOnLine(point, point2, perc);
        }

        /// <summary>
        /// Gets the point on line.
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="perc">The perc.</param>
        /// <returns>Point.</returns>
        public static Point GetPointOnLine(Point point1, int x2, int y2, int perc)
        {
            Point point = new Point(x2, y2);
            return GetPointOnLine(point1, point, perc);
        }


        #endregion
        
        #region Transparency


        #region Include in Paint

        private void TransInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion


        #endregion




        #region Hatch Animation

        private bool enableHatchAnimation = true;

        public bool EnableHatchAnimation
        {
            get { return enableHatchAnimation; }
            set
            {
                enableHatchAnimation = value;
                Invalidate();
            }
        }

        public int HatchSpeed
        {
            get { return hatchSpeed; }
            set
            {
                hatchSpeed = value;
                Invalidate();
            }
        }



        //---------------------------Include in Paint--------------------//
        //
        //if (EnableHatchAnimation)
        //{
        //    G.RenderingOrigin = new Point(reactorOFS, 0);
        //}
        //
        //---------------------------Include in Paint--------------------//

        private int reactorOFS = 20;
        private int hatchSpeed = 50;

        private void ReactorCreateHandle()
        {

            if (EnableHatchAnimation)
            {
                // Dim tmr As New Timer With {.Interval = hatchSpeed}
                // AddHandler tmr.Tick, AddressOf ReactorAnimate
                // tmr.Start()
                System.Threading.Thread T = new System.Threading.Thread(ReactorAnimate);
                T.IsBackground = true;
                T.Start();
            }

        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            ReactorCreateHandle();
        }

        public void ReactorAnimate()
        {
            while (true)
            {
                if (reactorOFS <= Width)
                {
                    reactorOFS += 1;
                }
                else
                {
                    reactorOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(hatchSpeed);
            }
        }


        #endregion




        #region Center Text

        //------------------------------Include in Paint----------------------------//
        //
        // CenterString(G,Text,Font,ForeColor,this.ClientRectangle);
        //
        //------------------------------Include in Paint----------------------------//

        /// <summary>
        /// Center Text
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="T">Set string</param>
        /// <param name="F">Set Font</param>
        /// <param name="C">Set color</param>
        /// <param name="R">Set rectangle</param>
        private static void CenterString(System.Drawing.Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point((int)(R.Width / 2 - (TS.Width / 2)), (int)(R.Height / 2 - (TS.Height / 2))));
            }
        }

        #endregion




    }

    /// <summary>
    /// Class PenParameters.
    /// </summary>
    public class PenParameters
    {

        /// <summary>
        /// The end cap
        /// </summary>
        private LineCap endCap = LineCap.ArrowAnchor;
        /// <summary>
        /// The start cap
        /// </summary>
        private LineCap startCap = LineCap.DiamondAnchor;
        /// <summary>
        /// The alignment
        /// </summary>
        private PenAlignment alignment = PenAlignment.Center;
        /// <summary>
        /// The dash cap
        /// </summary>
        private DashCap dashCap = DashCap.Flat;
        /// <summary>
        /// The dash offset
        /// </summary>
        private float dashOffset = 0.5f;
        /// <summary>
        /// The dash style
        /// </summary>
        private DashStyle dashStyle = DashStyle.DashDot;
        /// <summary>
        /// The line join
        /// </summary>
        private LineJoin lineJoin = LineJoin.Bevel;
        /// <summary>
        /// The width
        /// </summary>
        private int width = 1;

        /// <summary>
        /// Gets or sets the end cap.
        /// </summary>
        /// <value>The end cap.</value>
        public LineCap EndCap
        {
            get { return endCap; }
            set { endCap = value; }
        }

        /// <summary>
        /// Gets or sets the start cap.
        /// </summary>
        /// <value>The start cap.</value>
        public LineCap StartCap
        {
            get { return startCap; }
            set { startCap = value; }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        public PenAlignment Alignment
        {
            get { return alignment; }
            set { alignment = value; }
        }

        /// <summary>
        /// Gets or sets the dash cap.
        /// </summary>
        /// <value>The dash cap.</value>
        public DashCap DashCap
        {
            get { return dashCap; }
            set { dashCap = value; }
        }

        /// <summary>
        /// Gets or sets the dash offset.
        /// </summary>
        /// <value>The dash offset.</value>
        public float DashOffset
        {
            get { return dashOffset; }
            set { dashOffset = value; }
        }

        /// <summary>
        /// Gets or sets the dash style.
        /// </summary>
        /// <value>The dash style.</value>
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set { dashStyle = value; }
        }

        /// <summary>
        /// Gets or sets the line join.
        /// </summary>
        /// <value>The line join.</value>
        public LineJoin LineJoin
        {
            get { return lineJoin; }
            set { lineJoin = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}