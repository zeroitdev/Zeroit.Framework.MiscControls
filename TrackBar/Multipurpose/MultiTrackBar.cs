// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="MultiTrackBar.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Drawing.Text;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitMultiTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(true), ToolboxBitmap(typeof(ZeroitMultiTrackBar), "ZeroitMultiTrackBar.ZeroitMultiTrackBar.bmp"), DefaultEvent("ValueChanged"), System.Diagnostics.DebuggerStepThrough()]
	[Designer(typeof(ZeroitMultiTrackBarDesigner))]
    public partial class ZeroitMultiTrackBar
	{
        //private bool InstanceFieldsInitialized = false;

        /// <summary>
        /// Initializes the instance fields.
        /// </summary>
        private void InitializeInstanceFields()
			{
				rectLabel = new Rectangle(0, 0, Width, 20);
				_Orientation = Orientation.Horizontal;
				CurrSliderColor = _ColorUp.Face;
				CurrSliderBorderColor = _ColorUp.Border;
				CurrSliderHiLtColor = _ColorUp.Highlight;
			}

        /// <summary>
        /// The mouse timer
        /// </summary>
        private Timer MouseTimer = new Timer();
        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;
        /// <summary>
        /// Delegate ScrollEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
        public new delegate void ScrollEventHandler(object sender, ScrollEventArgs e);
        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        public new event ScrollEventHandler Scroll;

        #region Initiate

        /// <summary>
        /// The mouse state
        /// </summary>
        private eMouseState MouseState = eMouseState.Up;
        /// <summary>
        /// The is over slider
        /// </summary>
        private bool IsOverSlider;
        /// <summary>
        /// The is over down button
        /// </summary>
        private bool IsOverDownButton;
        /// <summary>
        /// The is over up button
        /// </summary>
        private bool IsOverUpButton;
        /// <summary>
        /// The gp slider
        /// </summary>
        private readonly GraphicsPath gpSlider = new GraphicsPath();
        /// <summary>
        /// The int slide indent
        /// </summary>
        private int intSlideIndent = 13;
        /// <summary>
        /// The SNG slider position
        /// </summary>
        private float sngSliderPos = 35F;
        /// <summary>
        /// The rect value box
        /// </summary>
        private Rectangle rectValueBox = new Rectangle(0, 0, 30, 20);
        /// <summary>
        /// The rect slider
        /// </summary>
        private Rectangle rectSlider = new Rectangle(0, 0, 250, 21);
        /// <summary>
        /// The rect down button
        /// </summary>
        private Rectangle rectDownButton = new Rectangle(0, 2, 15, 26);
        /// <summary>
        /// The rect up button
        /// </summary>
        private Rectangle rectUpButton = new Rectangle(235, 2, 15, 26);
        /// <summary>
        /// The rect label
        /// </summary>
        private Rectangle rectLabel;
        /// <summary>
        /// The initialize
        /// </summary>
        private bool Init = true;

        /// <summary>
        /// The sf
        /// </summary>
        private readonly StringFormat sf = new StringFormat();

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMultiTrackBar"/> class.
        /// </summary>
        public ZeroitMultiTrackBar()
		{

			// This call is required by the Windows Form Designer.
			if (!InstanceFieldsInitialized)
			{
				InitializeInstanceFields();
				InstanceFieldsInitialized = true;
			}
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SubscribeToEvents();

		    
		}

        /// <summary>
        /// Handles the Load event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TBSlider_Load(object sender, EventArgs e)
		{
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			UpdateRects();
			Init = false;

		}

        #endregion

        #region Enum

        /// <summary>
        /// Enum eTickType
        /// </summary>
        public enum eTickType
		{
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// Up right
            /// </summary>
            Up_Right,
            /// <summary>
            /// Down left
            /// </summary>
            Down_Left,
            /// <summary>
            /// The both
            /// </summary>
            Both,
            /// <summary>
            /// The middle
            /// </summary>
            Middle
        }

        /// <summary>
        /// Enum eMouseState
        /// </summary>
        public enum eMouseState
		{
            /// <summary>
            /// Up
            /// </summary>
            Up,
            /// <summary>
            /// Down
            /// </summary>
            Down
        }

        /// <summary>
        /// Enum eShape
        /// </summary>
        public enum eShape
		{
            /// <summary>
            /// The ellipse
            /// </summary>
            Ellipse,
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// The arrow up
            /// </summary>
            ArrowUp,
            /// <summary>
            /// The arrow down
            /// </summary>
            ArrowDown,
            /// <summary>
            /// The arrow right
            /// </summary>
            ArrowRight,
            /// <summary>
            /// The arrow left
            /// </summary>
            ArrowLeft
        }

        /// <summary>
        /// Enum eValueBox
        /// </summary>
        public enum eValueBox
		{
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// Enum eBrushStyle
        /// </summary>
        public enum eBrushStyle
		{
            /// <summary>
            /// The image
            /// </summary>
            Image,
            /// <summary>
            /// The linear
            /// </summary>
            Linear,
            /// <summary>
            /// The linear2
            /// </summary>
            Linear2,
            /// <summary>
            /// The path
            /// </summary>
            Path
        }

        #endregion

        #region Properties

        #region Smoothing Mode

        private SmoothingMode smoothing = SmoothingMode.HighQuality;

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


        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }
        #endregion


        #region Hidden

        /// <summary>
        /// Gets or sets the border style of the user control.
        /// </summary>
        /// <value><c>true</c> if [border style]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static new bool BorderStyle
		{
			get
			{
				return false; //always false
			}
			set //empty
			{
			}
		}

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static new Font Font
		{
			get
			{
				return null; //always false
			}
			set //empty
			{
			}
		}

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static new Color ForeColor
		{
			get
			{
				return new Color(); //always false
			}
			set //empty
			{
			}
		}

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Padding Padding
		{
			get
			{
				return _LabelPadding;
			}
			set
			{
				base.Padding = value;
			}
		}
        #endregion

        #region Value

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Current Value for the Slider"), Bindable(true)]
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
					if (value < _MinValue)
					{
						_Value = _MinValue;
					}
					else
					{
						if (value > _MaxValue)
						{
							_Value = _MaxValue;
						}
						else
						{
							_Value = value;
						}
					}
					UpdateRects();
					Invalidate();
					if (ValueChanged != null)
						ValueChanged(this, EventArgs.Empty);
				}
			}
		}

        /// <summary>
        /// Gets or sets the value adjusted.
        /// </summary>
        /// <value>The value adjusted.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Current Value Adjusted by the Divisor"), Browsable(false)]
		public float ValueAdjusted
		{
			get
			{
				return Convert.ToSingle((float)((int)_Value / (int)_valueDivisor));
			}
			set
			{
				value = Convert.ToInt32(value * (int)_valueDivisor);

			}
		}

        /// <summary>
        /// Enum eValueDivisor
        /// </summary>
        public enum eValueDivisor
		{
            /// <summary>
            /// The e1
            /// </summary>
            e1 = 1,
            /// <summary>
            /// The e10
            /// </summary>
            e10 = 10,
            /// <summary>
            /// The e100
            /// </summary>
            e100 = 100,
            /// <summary>
            /// The e1000
            /// </summary>
            e1000 = 1000
		}

        /// <summary>
        /// The value divisor
        /// </summary>
        private eValueDivisor _valueDivisor = eValueDivisor.e1;
        /// <summary>
        /// Gets or sets the value divisor.
        /// </summary>
        /// <value>The value divisor.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Divisor to adjust the Value by")]
		public eValueDivisor ValueDivisor
		{
			get
			{
				return _valueDivisor;
			}
			set
			{
				_valueDivisor = value;
			}
		}

        /// <summary>
        /// The value string format
        /// </summary>
        private string _valueStrFormat;
        /// <summary>
        /// Gets or sets the value string format.
        /// </summary>
        /// <value>The value string format.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Format to display the Value")]
		public string ValueStrFormat
		{
			get
			{
				return _valueStrFormat;
			}
			set
			{
				_valueStrFormat = value;
				Invalidate();
			}
		}
        #endregion

        #region Control

        /// <summary>
        /// The brush style
        /// </summary>
        private eBrushStyle _BrushStyle = eBrushStyle.Path;
        /// <summary>
        /// Gets or sets the brush style.
        /// </summary>
        /// <value>The brush style.</value>
        [Category("Appearance Slider"), Description("Use a Linear or Path type Brush on the Slider"), DefaultValue(typeof(eBrushStyle), "Path")]
		public eBrushStyle BrushStyle
		{
			get
			{
				return _BrushStyle;
			}
			set
			{
				_BrushStyle = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The brush direction
        /// </summary>
        private LinearGradientMode _BrushDirection = LinearGradientMode.Horizontal;
        /// <summary>
        /// Gets or sets the brush direction.
        /// </summary>
        /// <value>The brush direction.</value>
        [Category("Appearance Slider"), Description("The LinearGradientMode for the Linear Fill Type Brush"), DefaultValue(typeof(LinearGradientMode), "Horizontal")]
		public LinearGradientMode BrushDirection
		{
			get
			{
				return _BrushDirection;
			}
			set
			{
				_BrushDirection = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation _Orientation;
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Horizontal or Vertical Orientation"), DefaultValue(typeof(Orientation), "Horizontal")]
		public Orientation Orientation
		{
			get
			{
				return _Orientation;
			}
			set
			{
				_Orientation = value;
				Size = new Size(Height, Width);
				SliderSize = new Size(_SliderSize.Height, _SliderSize.Width);
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The minimum value
        /// </summary>
        private int _MinValue;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Minimum Value allowed for the Slider"), RefreshProperties(RefreshProperties.All), DefaultValue(0)]
		public int MinValue
		{
			get
			{
				return _MinValue;
			}
			set
			{
				if (!Init)
				{
					if (value >= _MaxValue)
					{
						value = _MaxValue - 10;
					}
					if (_Value < value)
					{
						_Value = value;
					}
				}
				_MinValue = value;
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The maximum value
        /// </summary>
        private int _MaxValue = 50;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Maximum Value allowed for the Slider"), RefreshProperties(RefreshProperties.All), DefaultValue(50)]
		public int MaxValue
		{
			get
			{
				return _MaxValue;
			}
			set
			{
				if (!Init)
				{
					if (value <= _MinValue)
					{
						value = _MinValue + 10;
					}
					if (_Value > value)
					{
						_Value = value;
					}
				}
				_MaxValue = value;
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The change large
        /// </summary>
        private int _ChangeLarge = 10;
        /// <summary>
        /// Gets or sets the change large.
        /// </summary>
        /// <value>The change large.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("How far to adjust the value when clicking to the right or left of the slider or when the Arrow Keys are pressed while holding the Shift Key too."), DefaultValue(10)]
		public int ChangeLarge
		{
			get
			{
				return _ChangeLarge;
			}
			set
			{
				_ChangeLarge = Math.Abs(value);
			}
		}

        /// <summary>
        /// The change small
        /// </summary>
        private int _ChangeSmall = 1;
        /// <summary>
        /// Gets or sets the change small.
        /// </summary>
        /// <value>The change small.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("How far to adjust the value when clicking the Arrow buttons or when the Arrow Keys are pressed"), DefaultValue(1)]
		public int ChangeSmall
		{
			get
			{
				return _ChangeSmall;
			}
			set
			{
				_ChangeSmall = Math.Abs(value);
			}
		}

        /// <summary>
        /// The border show
        /// </summary>
        private bool _BorderShow;
        /// <summary>
        /// Gets or sets a value indicating whether [border show].
        /// </summary>
        /// <value><c>true</c> if [border show]; otherwise, <c>false</c>.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Show or not show the border around the control"), DefaultValue(false)]
		public bool BorderShow
		{
			get
			{
				return _BorderShow;
			}
			set
			{
				_BorderShow = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The show focus
        /// </summary>
        private bool _ShowFocus = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show focus].
        /// </summary>
        /// <value><c>true</c> if [show focus]; otherwise, <c>false</c>.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Show or not show when the control has focus"), DefaultValue(true)]
		public bool ShowFocus
		{
			get
			{
				return _ShowFocus;
			}
			set
			{
				_ShowFocus = value;
			}
		}

        /// <summary>
        /// The jump to mouse
        /// </summary>
        private bool _JumpToMouse;
        /// <summary>
        /// Gets or sets a value indicating whether [jump to mouse].
        /// </summary>
        /// <value><c>true</c> if [jump to mouse]; otherwise, <c>false</c>.</value>
        [Category("Behavior Slider"), Description("Get or Set if the Slider Jumps to the mouse position or increments to it"), DefaultValue(false)]
		public bool JumpToMouse
		{
			get
			{
				return _JumpToMouse;
			}
			set
			{
				_JumpToMouse = value;
			}
		}

        /// <summary>
        /// The snap to value
        /// </summary>
        private bool _SnapToValue = true;
        /// <summary>
        /// Gets or sets a value indicating whether [snap to value].
        /// </summary>
        /// <value><c>true</c> if [snap to value]; otherwise, <c>false</c>.</value>
        [Category("Behavior Slider"), Description("Get or Set if the Slider Jumps to the Value position when the mouse is up"), DefaultValue(true)]
		public bool SnapToValue
		{
			get
			{
				return _SnapToValue;
			}
			set
			{
				_SnapToValue = value;
			}
		}

        #endregion

        #region Ticks

        /// <summary>
        /// The tick type
        /// </summary>
        private eTickType _TickType = eTickType.None;
        /// <summary>
        /// Gets or sets the type of the tick.
        /// </summary>
        /// <value>The type of the tick.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("Where to draw the Tick Marks"), DefaultValue(typeof(eTickType), "None")]
		public eTickType TickType
		{
			get
			{
				return _TickType;
			}
			set
			{
				_TickType = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The tick interval
        /// </summary>
        private int _TickInterval = 10;
        /// <summary>
        /// Gets or sets the tick interval.
        /// </summary>
        /// <value>The tick interval.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("The Interval between the Tick Marks"), DefaultValue(10)]
		public int TickInterval
		{
			get
			{
				return _TickInterval;
			}
			set
			{
				_TickInterval = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The tick width
        /// </summary>
        private int _TickWidth = 5;
        /// <summary>
        /// Gets or sets the width of the tick.
        /// </summary>
        /// <value>The width of the tick.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("How long to draw the Tick Marks"), DefaultValue(5)]
		public int TickWidth
		{
			get
			{
				return _TickWidth;
			}
			set
			{
				_TickWidth = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The tick thickness
        /// </summary>
        private float _TickThickness = 1F;
        /// <summary>
        /// Gets or sets the tick thickness.
        /// </summary>
        /// <value>The tick thickness.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("How Thick to draw the Tick Marks"), DefaultValue(1)]
		public float TickThickness
		{
			get
			{
				return _TickThickness;
			}
			set
			{
				_TickThickness = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The tick offset
        /// </summary>
        private int _TickOffset = 10;
        /// <summary>
        /// Gets or sets the tick offset.
        /// </summary>
        /// <value>The tick offset.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("How far to offset the Tick Marks"), DefaultValue(10)]
		public int TickOffset
		{
			get
			{
				return _TickOffset;
			}
			set
			{
				_TickOffset = value;
				Invalidate();
			}
		}

        #endregion

        #region FloatValue

        /// <summary>
        /// The float value
        /// </summary>
        private bool _FloatValue = true;
        /// <summary>
        /// Gets or sets a value indicating whether [float value].
        /// </summary>
        /// <value><c>true</c> if [float value]; otherwise, <c>false</c>.</value>
        [Category("Appearance FloatValue"), Description("Show or not show the value above the slider while dragging it back and forth"), DefaultValue(true)]
		public bool FloatValue
		{
			get
			{
				return _FloatValue;
			}
			set
			{
				_FloatValue = value;
			}
		}

        /// <summary>
        /// The float value font
        /// </summary>
        private Font _FloatValueFont = new Font("Arial", 8F, FontStyle.Bold);
        /// <summary>
        /// Gets or sets the float value font.
        /// </summary>
        /// <value>The float value font.</value>
        [Category("Appearance FloatValue"), Description("Font to use for the value above the slider "), DefaultValue(typeof(Font), "Arial, 8pt, style=Bold")]
		public Font FloatValueFont
		{
			get
			{
				return _FloatValueFont;
			}
			set
			{
				_FloatValueFont = value;
				Invalidate();
			}
		}

        #endregion

        #region Label

        /// <summary>
        /// The label
        /// </summary>
        private string _Label;
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        [Category("Appearance Label"), Description("Text to appear as a label on the control")]
		public string Label
		{
			get
			{
				return _Label;
			}
			set
			{
				_Label = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The label font
        /// </summary>
        private Font _LabelFont = new Font("Arial", 12F, FontStyle.Bold);
        /// <summary>
        /// Gets or sets the label font.
        /// </summary>
        /// <value>The label font.</value>
        [Category("Appearance Label"), Description("Font to use for the Label Text"), DefaultValue(typeof(Font), "Arial, 12pt, style=Bold")]
		public Font LabelFont
		{
			get
			{
				return _LabelFont;
			}
			set
			{
				_LabelFont = value;
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The labelsf
        /// </summary>
        private readonly StringFormat _Labelsf = new StringFormat();
        /// <summary>
        /// The label alighnment
        /// </summary>
        private StringAlignment _LabelAlighnment = StringAlignment.Near;
        /// <summary>
        /// Gets or sets the label alighnment.
        /// </summary>
        /// <value>The label alighnment.</value>
        [Category("Appearance Label"), Description("Alignment for the Label Text"), DefaultValue(typeof(StringAlignment), "Near")]
		public StringAlignment LabelAlighnment
		{
			get
			{
				return _LabelAlighnment;
			}
			set
			{
				_LabelAlighnment = value;
				_Labelsf.Alignment = value;
				_Labelsf.Trimming = StringTrimming.EllipsisCharacter;
				Invalidate();
			}
		}

        /// <summary>
        /// The label padding
        /// </summary>
        private Padding _LabelPadding = new Padding(3);
        /// <summary>
        /// Gets or sets the label padding.
        /// </summary>
        /// <value>The label padding.</value>
        [Category("Appearance Label"), Description("Pad the Label Text from the edge of the Control"), DefaultValue(typeof(Padding), "3, 3, 3, 3")]
		public Padding LabelPadding
		{
			get
			{
				return _LabelPadding;
			}
			set
			{
				_LabelPadding = value;
				Padding = value;
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The label show
        /// </summary>
        private bool _LabelShow;
        /// <summary>
        /// Gets or sets a value indicating whether [label show].
        /// </summary>
        /// <value><c>true</c> if [label show]; otherwise, <c>false</c>.</value>
        [Category("Appearance Label"), Description("Show or not show the Label Text"), DefaultValue(false)]
		public bool LabelShow
		{
			get
			{
				return _LabelShow;
			}
			set
			{
				_LabelShow = value;
				UpdateRects();

				Invalidate();
			}
		}

        #endregion //Label

        #region Slider

        /// <summary>
        /// The slider width high
        /// </summary>
        private float _SliderWidthHigh = 1F;
        /// <summary>
        /// Gets or sets the slider width high.
        /// </summary>
        /// <value>The slider width high.</value>
        [Category("Appearance Slider"), Description("How wide to make the High side of the Slider Line"), DefaultValue(1)]
		public float SliderWidthHigh
		{
			get
			{
				return _SliderWidthHigh;
			}
			set
			{
				_SliderWidthHigh = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider width low
        /// </summary>
        private float _SliderWidthLow = 1F;
        /// <summary>
        /// Gets or sets the slider width low.
        /// </summary>
        /// <value>The slider width low.</value>
        [Category("Appearance Slider"), Description("How wide to make Low side of the Slider Line"), DefaultValue(1)]
		public float SliderWidthLow
		{
			get
			{
				return _SliderWidthLow;
			}
			set
			{
				_SliderWidthLow = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider image
        /// </summary>
        private Bitmap _SliderImage;
        /// <summary>
        /// Gets or sets the slider image.
        /// </summary>
        /// <value>The slider image.</value>
        [Category("Appearance Slider"), Description("Slider Image"), DefaultValue(typeof(Bitmap), "none")]
		public Bitmap SliderImage
		{
			get
			{
				return _SliderImage;
			}
			set
			{
				_SliderImage = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider cap start
        /// </summary>
        private LineCap _SliderCapStart = LineCap.Round;
        /// <summary>
        /// Gets or sets the slider cap start.
        /// </summary>
        /// <value>The slider cap start.</value>
        [Category("Appearance Slider"), Description("Cap style to use for the start of the Slider Line"), DefaultValue(typeof(LineCap), "Round")]
		public LineCap SliderCapStart
		{
			get
			{
				return _SliderCapStart;
			}
			set
			{
				_SliderCapStart = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider cap end
        /// </summary>
        private LineCap _SliderCapEnd = LineCap.Round;
        /// <summary>
        /// Gets or sets the slider cap end.
        /// </summary>
        /// <value>The slider cap end.</value>
        [Category("Appearance Slider"), Description("Cap style to use for the end of the Slider Line"), DefaultValue(typeof(LineCap), "Round")]
		public LineCap SliderCapEnd
		{
			get
			{
				return _SliderCapEnd;
			}
			set
			{
				_SliderCapEnd = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider size
        /// </summary>
        private Size _SliderSize = new Size(20, 20);
        /// <summary>
        /// Gets or sets the size of the slider.
        /// </summary>
        /// <value>The size of the slider.</value>
        [Category("Appearance Slider"), Description("Size of the Slider"), DefaultValue(typeof(Size), "20, 10")]
		public Size SliderSize
		{
			get
			{
				return _SliderSize;
			}
			set
			{
				_SliderSize = value;
				if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
				{
					intSlideIndent = Convert.ToInt32(value.Width / 2.0) + 5;
				}
				else
				{
					intSlideIndent = Convert.ToInt32(value.Height / 2.0) + 5;
				}
				UpdateRects();
				Invalidate();
			}
		}

        /// <summary>
        /// The slider shape
        /// </summary>
        private eShape _SliderShape = eShape.Ellipse;
        /// <summary>
        /// Gets or sets the slider shape.
        /// </summary>
        /// <value>The slider shape.</value>
        [Category("Appearance Slider"), Description("Shape for the Slider"), DefaultValue(typeof(eShape), "Ellipse")]
		public eShape SliderShape
		{
			get
			{
				return _SliderShape;
			}
			set
			{
				_SliderShape = value;
				SetSliderPath();
				Invalidate();
			}
		}

        /// <summary>
        /// The slider highlight pt
        /// </summary>
        private PointF _SliderHighlightPt = new PointF(-5.0F, -2.5F);
        /// <summary>
        /// Gets or sets the slider highlight pt.
        /// </summary>
        /// <value>The slider highlight pt.</value>
        [Category("Appearance Slider"), Description("Point on the Slider for the Highlight Color"), TypeConverter(typeof(PointFConverter))]
		public PointF SliderHighlightPt
		{
			get
			{
				return _SliderHighlightPt;
			}
			set
			{
				_SliderHighlightPt = value;
				Invalidate();
			}
		}

        #region SliderHighlightPt Default Value

        /// <summary>
        /// Resets the slider highlight pt.
        /// </summary>
        public void ResetSliderHighlightPt()
		{
			SliderHighlightPt = new PointF(-5.0F, -2.5F);
		}

        /// <summary>
        /// Shoulds the serialize slider highlight pt.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSliderHighlightPt()
		{
			return !(_SliderHighlightPt.Equals(new PointF(-5.0F, -2.5F)));
		}
        #endregion

        /// <summary>
        /// The slider focal pt
        /// </summary>
        private PointF _SliderFocalPt = new PointF(0.0F, 0.0F);
        /// <summary>
        /// Gets or sets the slider focal pt.
        /// </summary>
        /// <value>The slider focal pt.</value>
        [Category("Appearance Slider"), Description("Focus of the Center Point"), TypeConverter(typeof(PointFConverter))]
		public PointF SliderFocalPt
		{
			get
			{
				return _SliderFocalPt;
			}
			set
			{
				_SliderFocalPt = value;
				Invalidate();
			}
		}

        #region SliderFocalPt Default Value

        /// <summary>
        /// Resets the slider focal pt.
        /// </summary>
        public void ResetSliderFocalPt()
		{
			SliderFocalPt = new PointF(0.0F, 0.0F);
		}

        /// <summary>
        /// Shoulds the serialize slider focal pt.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSliderFocalPt()
		{
			return !(_SliderFocalPt.Equals(new PointF(0.0F, 0.0F)));
		}
        #endregion

        #endregion //Slider

        #region ValueBox

        /// <summary>
        /// The value box
        /// </summary>
        private eValueBox _ValueBox = eValueBox.None;
        /// <summary>
        /// Gets or sets the value box.
        /// </summary>
        /// <value>The value box.</value>
        [Category("Appearance ValueBox"), Description("Where to draw the Value Box"), DefaultValue(typeof(eValueBox), "None")]
		public eValueBox ValueBox
		{
			get
			{
				return _ValueBox;
			}
			set
			{
				_ValueBox = value;
				SetSliderRect();
				Invalidate();
			}
		}

        /// <summary>
        /// The value box size
        /// </summary>
        private Size _ValueBoxSize = new Size(30, 20);
        /// <summary>
        /// Gets or sets the size of the value box.
        /// </summary>
        /// <value>The size of the value box.</value>
        [Category("Appearance ValueBox"), Description("What size to draw the Value Box"), DefaultValue(typeof(Size), "30, 20")]
		public Size ValueBoxSize
		{
			get
			{
				return _ValueBoxSize;
			}
			set
			{
				_ValueBoxSize = value;
				rectValueBox.Width = value.Width;
				rectValueBox.Height = value.Height;
				SetSliderRect();
				Invalidate();
			}
		}

        /// <summary>
        /// The value box font
        /// </summary>
        private Font _ValueBoxFont = new Font("Arial", 8.25f);
        /// <summary>
        /// Gets or sets the value box font.
        /// </summary>
        /// <value>The value box font.</value>
        [Category("Appearance ValueBox"), Description("What font to use in the Value Box"), DefaultValue(typeof(Font), "Arial, 8.25pt")]
		public Font ValueBoxFont
		{
			get
			{
				return _ValueBoxFont;
			}
			set
			{
				_ValueBoxFont = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The value box shape
        /// </summary>
        private eShape _ValueBoxShape = eShape.Rectangle;
        /// <summary>
        /// Gets or sets the value box shape.
        /// </summary>
        /// <value>The value box shape.</value>
        [Category("Appearance ValueBox"), Description("What Shape to draw the Value Box"), DefaultValue(typeof(eShape), "Rectangle")]
		public eShape ValueBoxShape
		{
			get
			{
				return _ValueBoxShape;
			}
			set
			{
				_ValueBoxShape = value;
				Invalidate();
			}
		}

        #endregion //Value Box

        #region UpDownButtons

        /// <summary>
        /// Up down width
        /// </summary>
        private int _UpDownWidth = 30;
        /// <summary>
        /// Gets or sets the width of up down.
        /// </summary>
        /// <value>The width of up down.</value>
        [Category("Appearance UpDownButtons"), Description("Width to draw the Up and Down Buttons if not set to Auto"), DefaultValue(30)]
		public int UpDownWidth
		{
			get
			{
				return _UpDownWidth;
			}
			set
			{
				if (value < 10)
				{
					value = 10;
				}
				_UpDownWidth = value;
				SetUpDnButtonsRect();
				Invalidate();
			}
		}

        /// <summary>
        /// Up down automatic width
        /// </summary>
        private bool _UpDownAutoWidth = true;
        /// <summary>
        /// Gets or sets a value indicating whether [up down automatic width].
        /// </summary>
        /// <value><c>true</c> if [up down automatic width]; otherwise, <c>false</c>.</value>
        [Category("Appearance UpDownButtons"), Description("Auto Size the Buttons to the Control"), DefaultValue(true)]
		public bool UpDownAutoWidth
		{
			get
			{
				return _UpDownAutoWidth;
			}
			set
			{
				_UpDownAutoWidth = value;
				SetUpDnButtonsRect();
				Invalidate();
			}
		}

        /// <summary>
        /// Up down show
        /// </summary>
        private bool _UpDownShow = false;
        /// <summary>
        /// Gets or sets a value indicating whether [up down show].
        /// </summary>
        /// <value><c>true</c> if [up down show]; otherwise, <c>false</c>.</value>
        [Category("Appearance UpDownButtons"), Description("Get or Set if the Up and Down buttons are shown"), DefaultValue(true)]
		public bool UpDownShow
		{
			get
			{
				return _UpDownShow;
			}
			set
			{
				_UpDownShow = value;
				SetSliderRect();
				Invalidate();
			}
		}

        #endregion //UpDownButtons

        #region Colors

        /// <summary>
        /// The color up
        /// </summary>
        private ColorPack _ColorUp = new ColorPack();
        /// <summary>
        /// Gets or sets the color up.
        /// </summary>
        /// <value>The color up.</value>
        [Category("Appearance Slider"), Description("Main Color of the Slider when State is Up"), Editor(typeof(ColorPackEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorPackConverter))]
		public ColorPack ColorUp
		{
			get
			{
				return _ColorUp;
			}
			set
			{
				_ColorUp = value;
				CurrSliderColor = _ColorUp.Face;
				CurrSliderBorderColor = _ColorUp.Border;
				CurrSliderHiLtColor = _ColorUp.Highlight;
				Invalidate();
			}
		}

        #region ColorUp Default Value

        /// <summary>
        /// Resets the color up.
        /// </summary>
        public void ResetColorUp()
		{
			ColorUp = new ColorPack();
		}

        /// <summary>
        /// Shoulds the serialize color up.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeColorUp()
		{
			return !(_ColorUp.Equals(new ColorPack()));
		}
        #endregion

        /// <summary>
        /// The color down
        /// </summary>
        private ColorPack _ColorDown = new ColorPack(Color.CornflowerBlue, Color.DarkSlateBlue, Color.AliceBlue);
        /// <summary>
        /// Gets or sets the color down.
        /// </summary>
        /// <value>The color down.</value>
        [Category("Appearance Slider"), Description("Main Color of the Slider when State is Down"), Editor(typeof(ColorPackEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorPackConverter))]
		public ColorPack ColorDown
		{
			get
			{
				return _ColorDown;
			}
			set
			{
				_ColorDown = value;
				Invalidate();
			}
		}

        #region ColorDown Default Value

        /// <summary>
        /// Resets the color down.
        /// </summary>
        public void ResetColorDown()
		{
			ColorDown = new ColorPack(Color.CornflowerBlue, Color.DarkSlateBlue, Color.AliceBlue);
		}

        /// <summary>
        /// Shoulds the serialize color down.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeColorDown()
		{
			return !(_ColorDown.Equals(new ColorPack(Color.CornflowerBlue, Color.DarkSlateBlue, Color.AliceBlue)));
		}
        #endregion

        /// <summary>
        /// The color hover
        /// </summary>
        private ColorPack _ColorHover = new ColorPack(Color.Blue, Color.RoyalBlue, Color.White);
        /// <summary>
        /// Gets or sets the color hover.
        /// </summary>
        /// <value>The color hover.</value>
        [Category("Appearance Slider"), Description("Main Color of the Slider when State is Hovering"), Editor(typeof(ColorPackEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorPackConverter))]
		public ColorPack ColorHover
		{
			get
			{
				return _ColorHover;
			}
			set
			{
				_ColorHover = value;
				Invalidate();
			}
		}

        #region ColorHover Default Value

        /// <summary>
        /// Resets the color hover.
        /// </summary>
        public void ResetColorHover()
		{
			ColorHover = new ColorPack(Color.Blue, Color.RoyalBlue, Color.White);
		}

        /// <summary>
        /// Shoulds the serialize color hover.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeColorHover()
		{
			return !(_ColorHover.Equals(new ColorPack(Color.Blue, Color.RoyalBlue, Color.White)));
		}
        #endregion

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance ZeroitMultiTrackBar"), Description("The Color of the Border around the Control"), DefaultValue(typeof(Color), "Black")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The slider color low
        /// </summary>
        private ColorLinearGradient _SliderColorLow = new ColorLinearGradient(Color.Red, Color.Red);
        /// <summary>
        /// Gets or sets the slider color low.
        /// </summary>
        /// <value>The slider color low.</value>
        [Category("Appearance Slider"), Description("The Color of the Slider Line on the Low Value Side"), Editor(typeof(ColorLinearGradientEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorLinearGradientConverter))]
		public ColorLinearGradient SliderColorLow
		{
			get
			{
				return _SliderColorLow;
			}
			set
			{
				_SliderColorLow = value;
				Invalidate();
			}
		}

        #region SliderColorLow Default Value

        /// <summary>
        /// Resets the slider color low.
        /// </summary>
        public void ResetSliderColorLow()
		{
			SliderColorLow = new ColorLinearGradient(Color.Red, Color.Red);
		}

        /// <summary>
        /// Shoulds the serialize slider color low.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSliderColorLow()
		{
			return !(_SliderColorLow.Equals(new ColorLinearGradient(Color.Red, Color.Red)));
		}
        #endregion

        /// <summary>
        /// The slider color high
        /// </summary>
        private ColorLinearGradient _SliderColorHigh = new ColorLinearGradient(Color.DarkGray, Color.DarkGray);
        /// <summary>
        /// Gets or sets the slider color high.
        /// </summary>
        /// <value>The slider color high.</value>
        [Category("Appearance Slider"), Description("The Color of the Slider Line on the High Value Side"), Editor(typeof(ColorLinearGradientEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorLinearGradientConverter))]
		public ColorLinearGradient SliderColorHigh
		{
			get
			{
				return _SliderColorHigh;
			}
			set
			{
				_SliderColorHigh = value;
				Invalidate();
			}
		}

        #region SliderColorHigh Default Value

        /// <summary>
        /// Resets the slider color high.
        /// </summary>
        public void ResetSliderColorHigh()
		{
			SliderColorHigh = new ColorLinearGradient(Color.DarkGray, Color.DarkGray);
		}

        /// <summary>
        /// Shoulds the serialize slider color high.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSliderColorHigh()
		{
			return !(_SliderColorHigh.Equals(new ColorLinearGradient(Color.DarkGray, Color.DarkGray)));
		}
        #endregion

        /// <summary>
        /// The arrow color up
        /// </summary>
        private Color _ArrowColorUp = Color.LightSteelBlue;
        /// <summary>
        /// Gets or sets the arrow color up.
        /// </summary>
        /// <value>The arrow color up.</value>
        [Category("Appearance UpDownButtons"), Description("Color of the Button Arrow when the State is Up"), DefaultValue(typeof(Color), "LightSteelBlue")]
		public Color ArrowColorUp
		{
			get
			{
				return _ArrowColorUp;
			}
			set
			{
				_ArrowColorUp = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The arrow color down
        /// </summary>
        private Color _ArrowColorDown = Color.GhostWhite;
        /// <summary>
        /// Gets or sets the arrow color down.
        /// </summary>
        /// <value>The arrow color down.</value>
        [Category("Appearance UpDownButtons"), Description("Color of the Button Arrow when the State is Down"), DefaultValue(typeof(Color), "GhostWhite")]
		public Color ArrowColorDown
		{
			get
			{
				return _ArrowColorDown;
			}
			set
			{
				_ArrowColorDown = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The arrow color hover
        /// </summary>
        private Color _ArrowColorHover = Color.DarkBlue;
        /// <summary>
        /// Gets or sets the arrow color hover.
        /// </summary>
        /// <value>The arrow color hover.</value>
        [Category("Appearance UpDownButtons"), Description("Color of the Button Arrow when the State is Hovering"), DefaultValue(typeof(Color), "DarkBlue")]
		public Color ArrowColorHover
		{
			get
			{
				return _ArrowColorHover;
			}
			set
			{
				_ArrowColorHover = value;
				Invalidate();
			}
		}

        /// <summary>
        /// a but color
        /// </summary>
        private ColorPack _AButColor = new ColorPack(Color.SteelBlue, Color.CornflowerBlue, Color.Lavender);
        /// <summary>
        /// Gets or sets the color of a but.
        /// </summary>
        /// <value>The color of a but.</value>
        [Category("Appearance UpDownButtons"), Description("Color of the Up Down Button"), Editor(typeof(ColorPackEditor), typeof(UITypeEditor)), TypeConverter(typeof(ColorPackConverter))]
		public ColorPack AButColor
		{
			get
			{
				return _AButColor;
			}
			set
			{
				_AButColor = value;
				Invalidate();
			}
		}

        #region AButColor Default Value

        /// <summary>
        /// Resets the color of a but.
        /// </summary>
        public void ResetAButColor()
		{
			AButColor = new ColorPack(Color.SteelBlue, Color.CornflowerBlue, Color.Lavender);
		}

        /// <summary>
        /// Shoulds the color of the serialize a but.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeAButColor()
		{
			return !(_AButColor.Equals(new ColorPack(Color.SteelBlue, Color.CornflowerBlue, Color.Lavender)));
		}
        #endregion

        /// <summary>
        /// The value box back color
        /// </summary>
        private Color _ValueBoxBackColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the value box back.
        /// </summary>
        /// <value>The color of the value box back.</value>
        [Category("Appearance ValueBox"), Description("Background Color for the Value Box"), DefaultValue(typeof(Color), "White")]
		public Color ValueBoxBackColor
		{
			get
			{
				return _ValueBoxBackColor;
			}
			set
			{
				_ValueBoxBackColor = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The value box border
        /// </summary>
        private Color _ValueBoxBorder = Color.MediumBlue;
        /// <summary>
        /// Gets or sets the value box border.
        /// </summary>
        /// <value>The value box border.</value>
        [Category("Appearance ValueBox"), Description("Color of the Border for the Value Box"), DefaultValue(typeof(Color), "MediumBlue")]
		public Color ValueBoxBorder
		{
			get
			{
				return _ValueBoxBorder;
			}
			set
			{
				_ValueBoxBorder = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The value box font color
        /// </summary>
        private Color _ValueBoxFontColor = Color.MediumBlue;
        /// <summary>
        /// Gets or sets the color of the value box font.
        /// </summary>
        /// <value>The color of the value box font.</value>
        [Category("Appearance ValueBox"), Description("Color of the Font for the Value Box"), DefaultValue(typeof(Color), "MediumBlue")]
		public Color ValueBoxFontColor
		{
			get
			{
				return _ValueBoxFontColor;
			}
			set
			{
				_ValueBoxFontColor = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The label color
        /// </summary>
        private Color _LabelColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the label.
        /// </summary>
        /// <value>The color of the label.</value>
        [Category("Appearance Label"), Description("Color of the Label Text"), DefaultValue(typeof(Color), "MediumBlue")]
		public Color LabelColor
		{
			get
			{
				return _LabelColor;
			}
			set
			{
				_LabelColor = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The float value font color
        /// </summary>
        private Color _FloatValueFontColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the float value font.
        /// </summary>
        /// <value>The color of the float value font.</value>
        [Category("Appearance FloatValue"), Description("Color of the Value floating above the Slider"), DefaultValue(typeof(Color), "MediumBlue")]
		public Color FloatValueFontColor
		{
			get
			{
				return _FloatValueFontColor;
			}
			set
			{
				_FloatValueFontColor = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The tick color
        /// </summary>
        private Color _TickColor = Color.DarkGray;
        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        [Category("Appearance Slider"), Description("Color of the Tick Marks"), DefaultValue(typeof(Color), "DarkGray")]
		public Color TickColor
		{
			get
			{
				return _TickColor;
			}
			set
			{
				_TickColor = value;
				Invalidate();
			}
		}

        #endregion //Colors

        #endregion

        #region Painting

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransInPaint(e.Graphics);

			base.OnPaint(e);

			//Setup the Graphics
			Graphics g = e.Graphics;
			g.SmoothingMode = Smoothing;
			g.TextRenderingHint = TextRendering;

            

            //Draw a Border around the control if requested
            if (_BorderShow)
			{
				g.DrawRectangle(new Pen(_BorderColor), 0, 0, Width - 1, Height - 1);
			}

			//Add the value increment buttons if requested
			if (_UpDownShow)
			{
				DrawUpDnButtons(ref g);
			}

			//Add the Line and Tick Marks
			DrawSliderLine(ref g);

			//Draw the Label Text if requested
			if (_LabelShow)
			{
				DrawLabel(ref g);
				//g.DrawRectangle(Pens.Gray, rectLabel)
			}

			//Add the Slider button
			DrawSlider(ref g);

			//Draw the Value above the Slider if requested
			if (_FloatValue && IsOverSlider && MouseState == eMouseState.Down)
			{
				DrawFloatValue(ref g);
			}

			//Draw the Box displating the value if requested
			if (!(_ValueBox == eValueBox.None))
			{
				DrawValueBox(ref g);
			}

			//Draw Focus Rectangle around control if requested 
			if (_ShowFocus && Focused)
			{
				ControlPaint.DrawFocusRectangle(g, new Rectangle(2 + Convert.ToInt32(!_BorderShow), 2 + Convert.ToInt32(!_BorderShow), Width - ((2 + Convert.ToInt32(!_BorderShow)) * 2), Height - ((2 + Convert.ToInt32(!_BorderShow)) * 2)), Color.Black, BackColor);
			}


		}

        /// <summary>
        /// Draws the label.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawLabel(ref Graphics g)
		{
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				_Labelsf.FormatFlags = 0;
			}
			else
			{
				_Labelsf.FormatFlags = StringFormatFlags.DirectionVertical;
			}
			g.DrawString(_Label, _LabelFont, new SolidBrush(_LabelColor), rectLabel, _Labelsf);
		}

        /// <summary>
        /// Draws the slider.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSlider(ref Graphics g)
		{
			switch (_BrushStyle)
			{
				case eBrushStyle.Linear:

					using (LinearGradientBrush br = new LinearGradientBrush(gpSlider.GetBounds(), CurrSliderHiLtColor, CurrSliderColor, _BrushDirection))
					{

						g.FillPath(br, gpSlider);

					}

					break;
				case eBrushStyle.Linear2:
					ColorBlend blend = new ColorBlend();
					Color[] bColors = new Color[] {CurrSliderColor, CurrSliderColor, CurrSliderHiLtColor, CurrSliderColor, CurrSliderColor};
					blend.Colors = bColors;

					float[] bPts = new float[] {0F, _SliderFocalPt.X, 0.5F, _SliderFocalPt.Y, 1F};
					blend.Positions = bPts;

					using (LinearGradientBrush br = new LinearGradientBrush(gpSlider.GetBounds(), CurrSliderColor, CurrSliderHiLtColor, _BrushDirection))
					{
						br.InterpolationColors = blend;
						g.FillPath(br, gpSlider);
                        

					}

					break;
				case eBrushStyle.Path:

					using (PathGradientBrush br = new PathGradientBrush(gpSlider))
					{
						br.SurroundColors = new Color[] {CurrSliderColor};
						br.CenterColor = CurrSliderHiLtColor;
						br.CenterPoint = new PointF(br.CenterPoint.X + SliderHighlightPt.X, br.CenterPoint.Y + SliderHighlightPt.Y);
						br.FocusScales = _SliderFocalPt;
						g.FillPath(br, gpSlider);
					}

					break;
				case eBrushStyle.Image:


				break;
			}

			if (_BrushStyle == eBrushStyle.Image)
			{
				if (_SliderImage == null)
				{
					g.DrawRectangle(new Pen(CurrSliderBorderColor), Rectangle.Round(gpSlider.GetBounds()));
				}
				else
				{
					g.DrawImage(_SliderImage, gpSlider.GetBounds());
				}
			}
			else
			{
				g.DrawPath(new Pen(CurrSliderBorderColor), gpSlider);
			}

		}

        /// <summary>
        /// Draws the float value.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawFloatValue(ref Graphics g)
		{
			SizeF sz = g.MeasureString(Microsoft.VisualBasic.Strings.Format(ValueAdjusted, _valueStrFormat), _FloatValueFont, new PointF(0F, 0F), StringFormat.GenericDefault);
			Rectangle rect = new Rectangle();
			PathGradientBrush pbr = null;
			GraphicsPath gp = new GraphicsPath();
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				rect = new Rectangle(Convert.ToInt32(sngSliderPos - (sz.Width / 2.0)), Convert.ToInt32((rectSlider.Height / 2.0) + rectSlider.Y - (_SliderSize.Height / 2.0) - 1 - sz.Height), Convert.ToInt32(sz.Width) + 1, Convert.ToInt32(sz.Height));
			}
			else
			{
				rect = new Rectangle(Convert.ToInt32((rectSlider.Width / 2.0) - (sz.Width / 2.0)), Convert.ToInt32(sngSliderPos - sz.Height - (_SliderSize.Height / 2.0) - 3), Convert.ToInt32(sz.Width + 1), Convert.ToInt32(sz.Height + 2));
			}
			gp.AddRectangle(rect);
			pbr = new PathGradientBrush(gp);
			pbr.SurroundColors = new Color[] {Color.Transparent};
			if (BackColor == Color.Transparent)
			{
				pbr.CenterColor = Parent.BackColor;
			}
			else
			{
				pbr.CenterColor = BackColor;
			}
			g.FillRectangle(pbr, rect);
			rect.Y += 2;
			g.DrawString(Microsoft.VisualBasic.Strings.Format(ValueAdjusted, _valueStrFormat), _FloatValueFont, new SolidBrush(_FloatValueFontColor), rect, sf);
			pbr.Dispose();
			gp.Dispose();
		}

        /// <summary>
        /// Draws the value box.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawValueBox(ref Graphics g)
		{

			using (Brush bbr = new SolidBrush(_ValueBoxBackColor), fbr = new SolidBrush(_ValueBoxFontColor))
			{
				using (Pen pn = new Pen(_ValueBoxBorder))
				{
					Rectangle rect = new Rectangle(rectValueBox.X, rectValueBox.Y, rectValueBox.Width, rectValueBox.Height);
					if (ValueBoxShape == eShape.Rectangle)
					{
						g.FillRectangle(bbr, rect);
						g.DrawRectangle(pn, rect.X, rect.Y, rect.Width, rect.Height);
					}
					else
					{
						g.FillEllipse(bbr, rect);
						g.DrawEllipse(pn, rect.X, rect.Y, rect.Width, rect.Height);
					}
	
					g.DrawString(Microsoft.VisualBasic.Strings.Format(ValueAdjusted, _valueStrFormat), _ValueBoxFont, fbr, new Rectangle(rect.X, rect.Y + 1, rect.Width + 1, rect.Height + 1), sf);
				}
			}

		}

        /// <summary>
        /// Draws up dn buttons.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawUpDnButtons(ref Graphics g)
		{
			using (Pen pn = new Pen(_ArrowColorUp, 2F))
			{
				pn.EndCap = LineCap.Round;
				pn.StartCap = LineCap.Round;
				pn.LineJoin = LineJoin.Round;
				GraphicsPath gp = new GraphicsPath();
				Point[] pts = null;
				Matrix mx = new Matrix();
				pts = new Point[] {
					new Point(5, 0),
					new Point(0, 5),
					new Point(5, 10)
				};
				gp.AddLines(pts);

				if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
				{

					if (IsOverDownButton)
					{
						g.FillRectangle(new LinearGradientBrush(rectDownButton, _AButColor.Highlight, _AButColor.Face, LinearGradientMode.Horizontal), rectDownButton);
						if (MouseState == eMouseState.Down)
						{
							pn.Color = _ArrowColorDown;
						}
						else
						{
							pn.Color = _ArrowColorHover;
						}
						g.DrawRectangle(new Pen(_AButColor.Border), new Rectangle(rectDownButton.X + 1, rectDownButton.Y, rectDownButton.Width - 1, rectDownButton.Height - 1));
					}
					mx.Translate(5F, Convert.ToSingle((rectDownButton.Y + (rectDownButton.Height / 2.0)) - 6));
					gp.Transform(mx);
					g.DrawPath(pn, gp);

					pn.Color = _ArrowColorUp;
					if (IsOverUpButton)
					{
						g.FillRectangle(new LinearGradientBrush(rectUpButton, _AButColor.Face, _AButColor.Highlight, LinearGradientMode.Horizontal), rectUpButton);
						if (MouseState == eMouseState.Down)
						{
							pn.Color = _ArrowColorDown;
						}
						else
						{
							pn.Color = _ArrowColorHover;
						}
						g.DrawRectangle(new Pen(_AButColor.Border), new Rectangle(rectUpButton.X, rectUpButton.Y, rectUpButton.Width - 1, rectUpButton.Height - 1));
					}
					mx = new Matrix(-1F, 0F, 0F, 1F, 5F, 0F);
					mx.Translate(rectUpButton.X + 9, 0F, MatrixOrder.Append);
					gp.Transform(mx);
					g.DrawPath(pn, gp);
				}
				else
				{

					if (IsOverUpButton)
					{
						g.FillRectangle(new LinearGradientBrush(rectUpButton, _AButColor.Face, _AButColor.Highlight, LinearGradientMode.Vertical), rectUpButton);
						g.DrawRectangle(new Pen(_AButColor.Border), new Rectangle(rectUpButton.X, rectUpButton.Y, rectUpButton.Width - 1, rectUpButton.Height - 1));
						if (MouseState == eMouseState.Down)
						{
							pn.Color = _ArrowColorDown;
						}
						else
						{
							pn.Color = _ArrowColorHover;
						}
					}
					mx.RotateAt(90F, new PointF(Convert.ToInt32(gp.GetBounds().Width / 2.0), Convert.ToInt32(gp.GetBounds().Height / 2.0)));
					mx.Translate(Convert.ToSingle((rectDownButton.X + (rectDownButton.Width / 2.0)) - 3), 4F, MatrixOrder.Append);
					gp.Transform(mx);
					g.DrawPath(pn, gp);

					pn.Color = _ArrowColorUp;
					if (IsOverDownButton)
					{
						g.FillRectangle(new LinearGradientBrush(rectDownButton, _AButColor.Highlight, _AButColor.Face, LinearGradientMode.Vertical), rectDownButton);
						g.DrawRectangle(new Pen(_AButColor.Border), new Rectangle(rectDownButton.X, rectDownButton.Y, rectDownButton.Width - 1, rectDownButton.Height - 1));
						if (MouseState == eMouseState.Down)
						{
							pn.Color = _ArrowColorDown;
						}
						else
						{
							pn.Color = _ArrowColorHover;
						}
					}
					mx = new Matrix(1F, 0F, 0F, -1F, 0F, 10F);
					mx.Translate(0F, rectDownButton.Y + 6, MatrixOrder.Append);
					gp.Transform(mx);
					g.DrawPath(pn, gp);
				}
				mx.Dispose();
				gp.Dispose();
			}

		}

        /// <summary>
        /// Draws the slider line.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSliderLine(ref Graphics g)
		{
			using (Pen pn = new Pen(_SliderColorLow.ColorA, _SliderWidthLow), tpn = new Pen(_TickColor, _TickThickness))
			{
				int @switch = Convert.ToInt32((_Orientation == System.Windows.Forms.Orientation.Horizontal) ? 1 : -1);
				float t1 = 0F;
				float t2 = 0F;
				int lAdj = 0;

				switch (_TickType)
				{
					case eTickType.Middle:
						t1 = Convert.ToSingle(-_TickWidth / 2.0);
						t2 = Convert.ToSingle(_TickWidth / 2.0);

						break;
					case eTickType.Up_Right:
						t1 = (-5 - _TickOffset - _TickWidth) * @switch;
						t2 = (-5 - _TickOffset) * @switch;

						break;
					case eTickType.Down_Left:
					case eTickType.Both:
						t1 = (5 + _TickOffset + _TickWidth) * @switch;
						t2 = (5 + _TickOffset) * @switch;

						break;
				}

				if (_LabelShow)
				{
					lAdj += rectLabel.Height + _LabelPadding.Vertical - 4;
				}

				int Tickpos = 0;
				if (Orientation == System.Windows.Forms.Orientation.Horizontal)
				{

					if (_TickType != eTickType.None)
					{
//INSTANT C# TODO TASK: The step increment was not confirmed to be positive - confirm that the stopping condition is appropriate:
//ORIGINAL LINE: For i As Integer = 0 To _MaxValue - _MinValue Step _TickInterval
						for (int i = 0; i <= _MaxValue - _MinValue; i += _TickInterval)
						{
							Tickpos = Convert.ToInt32(rectSlider.X + (rectSlider.Width * (i / (double)(_MaxValue - _MinValue))));
							g.DrawLine(tpn, Tickpos, Convert.ToSingle(rectSlider.Height / 2.0) + t1 + lAdj, Tickpos, Convert.ToSingle(rectSlider.Height / 2.0) + t2 + lAdj);
							if (_TickType == eTickType.Both)
							{
								g.DrawLine(tpn, Tickpos, Convert.ToSingle(rectSlider.Height / 2.0) - t1 + lAdj, Tickpos, Convert.ToSingle(rectSlider.Height / 2.0) - t2 + lAdj);
							}
						}
					}

					pn.StartCap = _SliderCapStart;
					if (_Value == _MaxValue)
					{
						pn.EndCap = _SliderCapEnd;
					}
					else
					{
						pn.EndCap = LineCap.Flat;
					}
					pn.Brush = new LinearGradientBrush(new PointF(Convert.ToSingle(rectSlider.X - _SliderWidthLow), Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y)), new PointF(sngSliderPos + _SliderWidthLow, Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y)), _SliderColorLow.ColorA, _SliderColorLow.ColorB);
					g.DrawLine(pn, Convert.ToSingle(rectSlider.X), Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y), sngSliderPos + 1, Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y));

					if (_Value == _MinValue)
					{
						pn.StartCap = _SliderCapStart;
					}
					else
					{
						pn.StartCap = LineCap.Flat;
					}
					pn.EndCap = _SliderCapEnd;
					pn.Brush = new LinearGradientBrush(new PointF(sngSliderPos - _SliderWidthHigh, Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y)), new PointF(Convert.ToSingle(rectSlider.X + rectSlider.Width + _SliderWidthHigh + 1), Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y)), _SliderColorHigh.ColorA, _SliderColorHigh.ColorB);
					pn.Width = _SliderWidthHigh;
					g.DrawLine(pn, sngSliderPos, Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y), Convert.ToSingle(rectSlider.X + rectSlider.Width), Convert.ToSingle(rectSlider.Height / 2.0 + rectSlider.Y));
				}
				else
				{

					if (_TickType != eTickType.None)
					{
//INSTANT C# TODO TASK: The step increment was not confirmed to be positive - confirm that the stopping condition is appropriate:
//ORIGINAL LINE: For i As Integer = 0 To _MaxValue - _MinValue Step _TickInterval
						for (int i = 0; i <= _MaxValue - _MinValue; i += _TickInterval)
						{
							Tickpos = Convert.ToInt32(rectSlider.Y + (rectSlider.Height * (i / (double)(_MaxValue - _MinValue))));
							g.DrawLine(tpn, Convert.ToSingle(rectSlider.Width / 2.0) + t1, Tickpos, Convert.ToSingle(rectSlider.Width / 2.0) + t2, Tickpos);
							if (_TickType == eTickType.Both)
							{
								g.DrawLine(tpn, Convert.ToSingle(rectSlider.Width / 2.0) - t1, Tickpos, Convert.ToSingle(rectSlider.Width / 2.0) - t2, Tickpos);
							}
						}
					}

					//Bottom
					pn.StartCap = _SliderCapStart;
					if (_Value == _MaxValue)
					{
						pn.EndCap = _SliderCapEnd;
					}
					else
					{
						pn.EndCap = LineCap.Flat;
					}
					pn.Brush = new LinearGradientBrush(new PointF(Convert.ToSingle(rectSlider.Width / 2.0), sngSliderPos - _SliderWidthLow), new PointF(Convert.ToSingle(rectSlider.Width / 2.0), Convert.ToSingle(rectSlider.Y + rectSlider.Height + _SliderWidthLow + 1)), _SliderColorLow.ColorA, _SliderColorLow.ColorB);

					pn.Width = _SliderWidthLow;
					g.DrawLine(pn, Convert.ToSingle(rectSlider.Width / 2.0), Convert.ToSingle(rectSlider.Y + rectSlider.Height), Convert.ToSingle(rectSlider.Width / 2.0), sngSliderPos);

					//top
					if (_Value == _MinValue)
					{
						pn.StartCap = _SliderCapStart;
					}
					else
					{
						pn.StartCap = LineCap.Flat;
					}
					pn.EndCap = _SliderCapEnd;
					pn.Color = _SliderColorHigh.ColorA;
					pn.Width = _SliderWidthHigh;
					pn.Brush = new LinearGradientBrush(new PointF(Convert.ToSingle(rectSlider.Width / 2.0), Convert.ToSingle(rectSlider.Y - _SliderWidthHigh - 1)), new PointF(Convert.ToSingle(rectSlider.Width / 2.0), sngSliderPos + _SliderWidthHigh), _SliderColorHigh.ColorA, _SliderColorHigh.ColorB);

					pn.Width = _SliderWidthHigh;

					g.DrawLine(pn, Convert.ToSingle(rectSlider.Width / 2.0), sngSliderPos, Convert.ToSingle(rectSlider.Width / 2.0), Convert.ToSingle(rectSlider.Y));
				}
			}

		}

        #endregion

        #region Building

        /// <summary>
        /// Sets the slider path.
        /// </summary>
        private void SetSliderPath()
		{
		    Graphics g = CreateGraphics();
		    g.SmoothingMode = SmoothingMode.HighQuality;
			gpSlider.Reset();
			RectangleF rect = new RectangleF();
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				rect = new RectangleF(Convert.ToSingle(sngSliderPos - (_SliderSize.Width / 2.0)), Convert.ToSingle(rectSlider.Y + (rectSlider.Height / 2.0) - (_SliderSize.Height) / 2.0), _SliderSize.Width, _SliderSize.Height);
			}
			else
			{
				rect = new RectangleF(Convert.ToSingle((rectSlider.Width - _SliderSize.Width) / 2.0), Convert.ToSingle(sngSliderPos - (_SliderSize.Height / 2.0)), _SliderSize.Width, _SliderSize.Height);
			}

			switch (_SliderShape)
			{

				case eShape.Rectangle:
					gpSlider.AddRectangle(rect);

					break;
				case eShape.Ellipse:
					gpSlider.AddEllipse(rect);
				    break;
				case eShape.ArrowUp:
					gpSlider.AddPolygon(new PointF[] {
						new PointF(rect.X, rect.Bottom),
						new PointF(rect.Right, rect.Bottom),
						new PointF((int)(rect.X + (rect.Width / 2.0)), rect.Top)
					});

					break;
				case eShape.ArrowDown:
					gpSlider.AddPolygon(new PointF[] {
						new PointF(rect.X, rect.Top),
						new PointF(rect.Right, rect.Top),
						new PointF((int)(rect.X + (rect.Width / 2.0)), rect.Bottom)
					});

					break;
				case eShape.ArrowRight:
					gpSlider.AddPolygon(new PointF[] {
						new PointF(rect.X, rect.Bottom),
						new PointF(rect.Right, (int)(rect.Top + (rect.Height / 2.0))),
						new PointF(rect.X, rect.Top)
					});

					break;
				case eShape.ArrowLeft:
					gpSlider.AddPolygon(new PointF[] {
						new PointF(rect.Right, rect.Bottom),
						new PointF(rect.X, (int)(rect.Top + (rect.Height / 2.0))),
						new PointF(rect.Right, rect.Top)
					});

					break;
			}

			InvRect = Rectangle.Round(gpSlider.GetBounds());
			InvRect.Inflate(2, 2);
		}

        /// <summary>
        /// Updates the slider.
        /// </summary>
        /// <param name="xPos">The x position.</param>
        private void UpdateSlider(int xPos)
		{
			RectangleF rect = gpSlider.GetBounds();
			rect.Inflate(20F, 20F);
			rect.Offset(-10F, -10F);
			Invalidate(Rectangle.Round(rect));
			sngSliderPos = xPos;
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				if (sngSliderPos - rectSlider.X < 0)
				{
					sngSliderPos = rectSlider.X;
				}
				if (sngSliderPos > rectSlider.X + rectSlider.Width)
				{
					sngSliderPos = rectSlider.X + rectSlider.Width;
				}
			}
			else
			{
				if (sngSliderPos - rectSlider.Y < 0)
				{
					sngSliderPos = rectSlider.Y;
				}
				if (sngSliderPos > rectSlider.Y + rectSlider.Height)
				{
					sngSliderPos = rectSlider.Y + rectSlider.Height;
				}
			}
			SetSliderPath();
			Invalidate(Rectangle.Round(rect));
		}

        /// <summary>
        /// Sets up dn buttons rect.
        /// </summary>
        private void SetUpDnButtonsRect()
		{
			int UDWidth = 0;
			int UDY = 0;

			if (Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				if (_UpDownAutoWidth)
				{
					UDWidth = rectSlider.Height - 4;
					UDY = 3;
				}
				else
				{
					UDWidth = _UpDownWidth;
					UDY = Convert.ToInt32((rectSlider.Height - UDWidth) / 2.0);
				}

				if (_LabelShow)
				{
					UDY += rectLabel.Height + _LabelPadding.Vertical - 4;
				}

				rectDownButton = new Rectangle(1, UDY, 15, UDWidth);
				rectUpButton = new Rectangle(Width - 17, UDY, 15, UDWidth);
			}
			else
			{
				if (_UpDownAutoWidth)
				{
					UDWidth = rectSlider.Width - 4;
					UDY = 2;
				}
				else
				{
					UDWidth = _UpDownWidth;
					UDY = Convert.ToInt32((rectSlider.Width - UDWidth) / 2.0);
				}

				rectUpButton = new Rectangle(UDY, 2, UDWidth, 15);
				rectDownButton = new Rectangle(UDY, Height - 17, UDWidth, 15);
			}
		}

        /// <summary>
        /// Sets the label rect.
        /// </summary>
        private void SetLabelRect()
		{
			if (Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				rectLabel = new Rectangle(_LabelPadding.Left, _LabelPadding.Top, Width - _LabelPadding.Horizontal - 1, LabelFont.Height);
			}
			else
			{
				rectLabel = new Rectangle(Width - LabelFont.Height - _LabelPadding.Top, _LabelPadding.Left, LabelFont.Height, Height - _LabelPadding.Horizontal - 1);
			}
		}

        /// <summary>
        /// Sets the slider rect.
        /// </summary>
        private void SetSliderRect()
		{
			try
			{
				int ButtonOffset = 17;
				if (!_UpDownShow)
				{
					ButtonOffset = 0;
				}
				if (Orientation == System.Windows.Forms.Orientation.Horizontal)
				{
					float _SliderWidth = Math.Max(_SliderWidthLow, _SliderWidthHigh);

					if (_LabelShow)
					{
						rectSlider.Height = Height - rectLabel.Height - _LabelPadding.Top;
					}
					else
					{
						rectSlider.Height = Height - 1;
					}

					switch (_ValueBox)
					{
						case eValueBox.None:
							rectSlider.X = ButtonOffset + intSlideIndent;
							rectSlider.Width = Width - ((ButtonOffset * 2) + 1) - (intSlideIndent * 2);
							break;
						case eValueBox.Left:
							rectValueBox.X = ButtonOffset + 1;
							rectValueBox.Y = Convert.ToInt32(((rectSlider.Height - rectValueBox.Height) / 2.0));
							rectSlider.Width = Convert.ToInt32(Width - ((ButtonOffset * 2) + 1) - rectValueBox.Width - (intSlideIndent * 2) - (_SliderWidth / 2));
							rectSlider.X = Convert.ToInt32(rectValueBox.Width + ButtonOffset + intSlideIndent + (_SliderWidth / 2));
							break;
						case eValueBox.Right:
							rectValueBox.X = Width - ButtonOffset - 2 - rectValueBox.Width;
							rectValueBox.Y = Convert.ToInt32(((rectSlider.Height - rectValueBox.Height) / 2.0));
							rectSlider.Width = Convert.ToInt32(Width - ((ButtonOffset * 2) + 1) - rectValueBox.Width - (intSlideIndent * 2) - (_SliderWidth / 2));
							rectSlider.X = ButtonOffset + intSlideIndent;
							break;
					}

					if (_LabelShow)
					{
						rectSlider.Y = rectLabel.Height + _LabelPadding.Vertical - 4;
						rectValueBox.Y += rectLabel.Height + _LabelPadding.Vertical - 4;
					}
					else
					{
						rectSlider.Y = 0;
					}
					UpdateSlider(Convert.ToInt32(rectSlider.X + (rectSlider.Width * ((_Value - _MinValue) / (double)(_MaxValue - _MinValue)))));

				}
				else
				{
					switch (_ValueBox)
					{
						case eValueBox.None:
							rectSlider.Y = ButtonOffset + intSlideIndent;
							rectSlider.Height = Height - ((ButtonOffset * 2) + 1) - (intSlideIndent * 2);
							break;
						case eValueBox.Left:
							rectValueBox.X = Convert.ToInt32(((rectSlider.Width - rectValueBox.Width) / 2.0));
							rectValueBox.Y = ButtonOffset + 1;
							rectSlider.Height = Convert.ToInt32(Height - ((ButtonOffset * 2) + 1) - rectValueBox.Height - (intSlideIndent * 2));
							rectSlider.Y = Convert.ToInt32(rectValueBox.Height + ButtonOffset + intSlideIndent);
							break;
						case eValueBox.Right:
							rectValueBox.X = Convert.ToInt32(((rectSlider.Width - rectValueBox.Width) / 2.0));
							rectValueBox.Y = Height - ButtonOffset - 2 - rectValueBox.Height;
							rectSlider.Height = Convert.ToInt32(Height - ((ButtonOffset * 2) + 1) - rectValueBox.Height - (intSlideIndent * 2));
							rectSlider.Y = ButtonOffset + intSlideIndent;
							break;
					}
					if (_LabelShow)
					{
						rectSlider.X = 0;
						rectSlider.Width = Width - rectLabel.Width - _LabelPadding.Top;
					}
					else
					{
						rectSlider.X = 0;
						rectSlider.Width = Width - 1;
					}
					int adj = 0;
					if (_MinValue < 0)
					{
						adj = Math.Abs(_MinValue);
					}
					UpdateSlider(Convert.ToInt32(rectSlider.Y + (rectSlider.Height * (((_MaxValue + adj) - _Value - adj) / (double)((_MaxValue + adj) - (_MinValue + adj))))));

				}
			}
			catch (Exception ex)
			{

			}
		}

        /// <summary>
        /// Updates the rects.
        /// </summary>
        private void UpdateRects()
		{
			SetLabelRect();
			SetSliderRect();
			SetSliderPath();
			SetUpDnButtonsRect();
		}

        #endregion

        #region Mouse

        /// <summary>
        /// The inv rect
        /// </summary>
        private Rectangle InvRect;
        /// <summary>
        /// The curr slider color
        /// </summary>
        private Color CurrSliderColor;
        /// <summary>
        /// The curr slider border color
        /// </summary>
        private Color CurrSliderBorderColor;
        /// <summary>
        /// The curr slider hi lt color
        /// </summary>
        private Color CurrSliderHiLtColor;
        //   Private Orient As Integer = 1
        /// <summary>
        /// The mouse hold down ticker
        /// </summary>
        private int MouseHoldDownTicker;
        /// <summary>
        /// The mouse hold down change
        /// </summary>
        private int MouseHoldDownChange;
        /// <summary>
        /// The old value
        /// </summary>
        private int OldValue;
        /// <summary>
        /// The scroll type
        /// </summary>
        private ScrollEventType ScrollType;

        /// <summary>
        /// Handles the MouseDown event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TBSlider_MouseDown(object sender, MouseEventArgs e)
		{
			OldValue = _Value;
			MouseState = eMouseState.Down;
			MouseHoldDownTicker = 0;
			MouseTimer.Interval = 100;
			if (_UpDownShow)
			{
				if (IsOverDownButton)
				{
					MouseHoldDownChange = -_ChangeSmall;
					OldValue = _Value;
					ScrollType = ScrollEventType.SmallDecrement;
					Value += MouseHoldDownChange;
					if (Scroll != null)
						Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
					MouseTimer.Start();
				}
				else if (IsOverUpButton)
				{
					MouseHoldDownChange = _ChangeSmall;
					OldValue = _Value;
					ScrollType = ScrollEventType.SmallIncrement;
					Value += MouseHoldDownChange;
					if (Scroll != null)
						Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
					MouseTimer.Start();
				}
			}
			IsOverSlider = gpSlider.IsVisible(e.X, e.Y);
			int pos = 0;
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				pos = e.X;
			}
			else
			{
				pos = e.Y;
			}
			if (IsOverSlider)
			{
				CurrSliderColor = _ColorDown.Face;
				CurrSliderBorderColor = _ColorDown.Border;
				CurrSliderHiLtColor = _ColorDown.Highlight;
			}
			else if (rectSlider.Contains(e.Location))
			{
				if (_JumpToMouse)
				{
					sngSliderPos = pos;
					IsOverSlider = true;
					OldValue = _Value;
					SetSliderValue(new Point(e.X, e.Y));
					ScrollType = ScrollEventType.ThumbPosition;
					if (Scroll != null)
						Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));

				}
				else
				{
					if (pos < sngSliderPos)
					{
						MouseHoldDownChange = _ChangeLarge * Convert.ToInt32((Orientation == System.Windows.Forms.Orientation.Horizontal) ? - 1 : 1);
						OldValue = _Value;
						ScrollType = ScrollEventType.LargeIncrement;
						Value += MouseHoldDownChange;
						if (Scroll != null)
							Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
					}
					else
					{
						MouseHoldDownChange = -(_ChangeLarge * Convert.ToInt32((Orientation == System.Windows.Forms.Orientation.Horizontal) ? - 1 : 1));
						OldValue = _Value;
						ScrollType = ScrollEventType.LargeDecrement;
						Value += MouseHoldDownChange;
						if (Scroll != null)
							Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
					}
					MouseTimer.Start();
				}
			}
			Invalidate();
		}

        /// <summary>
        /// Handles the MouseLeave event of the gTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gTrackBar_MouseLeave(object sender, EventArgs e)
		{
			IsOverDownButton = false;
			IsOverUpButton = false;
			CurrSliderColor = _ColorUp.Face;
			CurrSliderBorderColor = _ColorUp.Border;
			CurrSliderHiLtColor = _ColorUp.Highlight;
			Invalidate();
		}

        /// <summary>
        /// Handles the MouseMove event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TBSlider_MouseMove(object sender, MouseEventArgs e)
		{
			if (!IsOverSlider)
			{
				IsOverDownButton = rectDownButton.Contains(e.Location);
				IsOverUpButton = rectUpButton.Contains(e.Location);
			}
			Rectangle rect = rectDownButton;
			rect.Inflate(1, 1);
			Invalidate(rect);
			rect = rectUpButton;
			rect.Inflate(1, 1);
			Invalidate(rect);

			if (MouseState == eMouseState.Up)
			{
				IsOverSlider = gpSlider.IsVisible(e.X, e.Y);
			}

			if (IsOverSlider && MouseState == eMouseState.Down)
			{
				OldValue = _Value;
				SetSliderValue(new Point(e.X, e.Y));
				if (Scroll != null)
					Scroll(this, new ScrollEventArgs(ScrollEventType.ThumbTrack,OldValue,_Value, (ScrollOrientation)this.Orientation));

			}
			else if (IsOverSlider && MouseState == eMouseState.Up)
			{
				CurrSliderColor = _ColorHover.Face;
				CurrSliderBorderColor = _ColorHover.Border;
				CurrSliderHiLtColor = _ColorHover.Highlight;
				Invalidate(InvRect);
			}
			else
			{
				CurrSliderColor = _ColorUp.Face;
				CurrSliderBorderColor = _ColorUp.Border;
				CurrSliderHiLtColor = _ColorUp.Highlight;
				Invalidate(InvRect);

			}
			Update();
		}

        /// <summary>
        /// Sets the slider value.
        /// </summary>
        /// <param name="pt">The pt.</param>
        private void SetSliderValue(Point pt)
		{
			if (_Orientation == System.Windows.Forms.Orientation.Horizontal)
			{
				Value = Convert.ToInt32(((sngSliderPos - rectSlider.X) / (rectSlider.Width / (double)(_MaxValue - _MinValue))) + _MinValue);
				UpdateSlider(pt.X);
			}
			else
			{
				int adj = 0;
				if (_MinValue < 0)
				{
					adj = Math.Abs(_MinValue);
				}
				Value = ((_MaxValue + adj) - Convert.ToInt32(((sngSliderPos - rectSlider.Y) / (rectSlider.Height / (double)((_MaxValue + adj) - (_MinValue + adj)))))) - adj;
				UpdateSlider(pt.Y);
			}

		}

        /// <summary>
        /// Handles the MouseUp event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TBSlider_MouseUp(object sender, MouseEventArgs e)
		{
			MouseTimer.Stop();
			MouseState = eMouseState.Up;
			IsOverDownButton = rectDownButton.Contains(e.Location);
			IsOverUpButton = rectUpButton.Contains(e.Location);
			if (_SnapToValue)
			{

				OldValue = _Value;
				SetSliderRect();

			}
			Invalidate();
		}

        /// <summary>
        /// Handles the MouseWheel event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TBSlider_MouseWheel(object sender, MouseEventArgs e)
		{
			OldValue = _Value;
			if (e.Delta > 0)
			{
				ScrollType = ScrollEventType.SmallIncrement;
				Value += _ChangeSmall;
			}
			else
			{
				ScrollType = ScrollEventType.SmallDecrement;
				Value -= _ChangeSmall;
			}

			if (Scroll != null)
				Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));

		}

        #endregion

        #region KeyDown

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
		{
			//Because a Usercontrol ignores the arrows in the KeyDown Event
			//and changes focus no matter what in the KeyUp Event
			//This is needed to fix the KeyDown problem
			switch (keyData & Keys.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Left:
					return true;
				default:
					return base.IsInputKey(keyData);
			}
		}

        /// <summary>
        /// Handles the KeyUp event of the gTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void gTrackBar_KeyUp(object sender, KeyEventArgs e)
		{

			OldValue = _Value;

			int adjust = 0;
			if (e.Shift)
			{
				adjust = _ChangeLarge;
			}
			else
			{
				adjust = _ChangeSmall;
			}

			switch (e.KeyValue)
			{
				case (System.Int32)Keys.Up:
				case (System.Int32)Keys.Right:
					Value += adjust;
					if (e.Shift)
					{
						ScrollType = ScrollEventType.LargeIncrement;
					}
					else
					{
						ScrollType = ScrollEventType.SmallIncrement;
					}

					break;
				case (System.Int32)Keys.Down:
				case (System.Int32)Keys.Left:
					Value -= adjust;
					if (e.Shift)
					{
						ScrollType = ScrollEventType.LargeDecrement;
					}
					else
					{
						ScrollType = ScrollEventType.SmallDecrement;
					}
					break;
			}
			if (Scroll != null)
				Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
		}

        #endregion

        #region Resize

        /// <summary>
        /// Handles the Resize event of the TBSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TBSlider_Resize(object sender, EventArgs e)
		{
			UpdateRects();
			Refresh();
		}

        #endregion

        #region Focus

        /// <summary>
        /// Handles the LostFocus event of the gTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gTrackBar_LostFocus(object sender, EventArgs e)
		{
			Invalidate();
		}

        #endregion

        #region Mouse Hold Down Timer

        /// <summary>
        /// Handles the Tick event of the MouseTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MouseTimer_Tick(object sender, EventArgs e)
		{
			//Check if mouse was just clicked
			if (MouseHoldDownTicker < 5)
			{
				MouseHoldDownTicker += 1;
				//Interval was set to 100 on MouseDown
				//Tick off 5 times and then reset the Timer Interval
				//  based on the Min/Max span
				if (MouseHoldDownTicker == 5)
				{
					MouseTimer.Interval = Convert.ToInt32(Math.Max(10, 100 - ((_MaxValue - _MinValue) / 10.0)));
				}
			}
			else
			{
				//Change the value until the mouse is released
				OldValue = _Value;
				Value += MouseHoldDownChange;
				if (Scroll != null)
					Scroll(this, new ScrollEventArgs(ScrollType, OldValue, _Value, (ScrollOrientation)this.Orientation));
			}
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






    }
    
}