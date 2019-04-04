// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ToggleSwitch    
    /// <summary>
    /// A class collection for rendering a toggle switch.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitToggleSwitchDesigner))]
    [DefaultValue("Checked"), DefaultEvent("CheckedChanged"), ToolboxBitmap(typeof(CheckBox))]
    public class ZeroitToggleSwitch : Control
    {
        #region Delegate and Event declarations

        /// <summary>
        /// Delegate CheckedChangedDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void CheckedChangedDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        [Description("Raised when the ToggleSwitch has changed state")]
        public event CheckedChangedDelegate CheckedChanged;

        #endregion Delegate and Event declarations

        #region Enums

        /// <summary>
        /// Enum representing the toggle type
        /// </summary>
        public enum ToggleSwitchStyle
        {
            /// <summary>
            /// The metro
            /// </summary>
            Metro,
            /// <summary>
            /// The android
            /// </summary>
            Android,
            /// <summary>
            /// The ios 5
            /// </summary>
            IOS5,
            /// <summary>
            /// The brushed metal
            /// </summary>
            BrushedMetal,
            /// <summary>
            /// The osx
            /// </summary>
            OSX,
            /// <summary>
            /// The carbon
            /// </summary>
            Carbon,
            /// <summary>
            /// The iphone
            /// </summary>
            Iphone,
            /// <summary>
            /// The fancy
            /// </summary>
            Fancy,
            /// <summary>
            /// The modern
            /// </summary>
            Modern
        }

        /// <summary>
        /// Enum representing the switch alignment
        /// </summary>
        public enum ToggleSwitchAlignment
        {
            /// <summary>
            /// The near
            /// </summary>
            Near,
            /// <summary>
            /// The center
            /// </summary>
            Center,
            /// <summary>
            /// The far
            /// </summary>
            Far
        }

        /// <summary>
        /// Enum representing the button alignment
        /// </summary>
        public enum ToggleSwitchButtonAlignment
        {
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The center
            /// </summary>
            Center,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        #endregion Enums

        #region Private Members

        /// <summary>
        /// The animation timer
        /// </summary>
        private readonly System.Windows.Forms.Timer _animationTimer = new System.Windows.Forms.Timer();
        /// <summary>
        /// The renderer
        /// </summary>
        private ToggleSwitchRendererBase _renderer;

        /// <summary>
        /// The style
        /// </summary>
        private ToggleSwitchStyle _style = ToggleSwitchStyle.Metro;
        /// <summary>
        /// The checked
        /// </summary>
        private bool _checked = false;
        /// <summary>
        /// The moving
        /// </summary>
        private bool _moving = false;
        /// <summary>
        /// The animating
        /// </summary>
        private bool _animating = false;
        /// <summary>
        /// The animation result
        /// </summary>
        private bool _animationResult = false;
        /// <summary>
        /// The animation target
        /// </summary>
        private int _animationTarget = 0;
        /// <summary>
        /// The use animation
        /// </summary>
        private bool _useAnimation = true;
        /// <summary>
        /// The animation interval
        /// </summary>
        private int _animationInterval = 1;
        /// <summary>
        /// The animation step
        /// </summary>
        private int _animationStep = 10;
        /// <summary>
        /// The allow user change
        /// </summary>
        private bool _allowUserChange = true;

        /// <summary>
        /// The is left field hovered
        /// </summary>
        private bool _isLeftFieldHovered = false;
        /// <summary>
        /// The is button hovered
        /// </summary>
        private bool _isButtonHovered = false;
        /// <summary>
        /// The is right field hovered
        /// </summary>
        private bool _isRightFieldHovered = false;
        /// <summary>
        /// The is left field pressed
        /// </summary>
        private bool _isLeftFieldPressed = false;
        /// <summary>
        /// The is button pressed
        /// </summary>
        private bool _isButtonPressed = false;
        /// <summary>
        /// The is right field pressed
        /// </summary>
        private bool _isRightFieldPressed = false;

        /// <summary>
        /// The button value
        /// </summary>
        private int _buttonValue = 0;
        /// <summary>
        /// The saved button value
        /// </summary>
        private int _savedButtonValue = 0;
        /// <summary>
        /// The x offset
        /// </summary>
        private int _xOffset = 0;
        /// <summary>
        /// The x value
        /// </summary>
        private int _xValue = 0;
        /// <summary>
        /// The threshold percentage
        /// </summary>
        private int _thresholdPercentage = 50;
        /// <summary>
        /// The gray when disabled
        /// </summary>
        private bool _grayWhenDisabled = true;
        /// <summary>
        /// The toggle on button click
        /// </summary>
        private bool _toggleOnButtonClick = true;
        /// <summary>
        /// The toggle on side click
        /// </summary>
        private bool _toggleOnSideClick = true;

        /// <summary>
        /// The last mouse event arguments
        /// </summary>
        private MouseEventArgs _lastMouseEventArgs = null;

        /// <summary>
        /// The button scale image
        /// </summary>
        private bool _buttonScaleImage;
        /// <summary>
        /// The button alignment
        /// </summary>
        private ToggleSwitchButtonAlignment _buttonAlignment = ToggleSwitchButtonAlignment.Center;
        /// <summary>
        /// The button image
        /// </summary>
        private Image _buttonImage = null;

        /// <summary>
        /// The off text
        /// </summary>
        private string _offText = "";
        /// <summary>
        /// The off fore color
        /// </summary>
        private Color _offForeColor = Color.Black;
        /// <summary>
        /// The off font
        /// </summary>
        private Font _offFont;
        /// <summary>
        /// The off side image
        /// </summary>
        private Image _offSideImage = null;
        /// <summary>
        /// The off side scale image
        /// </summary>
        private bool _offSideScaleImage;
        /// <summary>
        /// The off side alignment
        /// </summary>
        private ToggleSwitchAlignment _offSideAlignment = ToggleSwitchAlignment.Center;
        /// <summary>
        /// The off button image
        /// </summary>
        private Image _offButtonImage = null;
        /// <summary>
        /// The off button scale image
        /// </summary>
        private bool _offButtonScaleImage;
        /// <summary>
        /// The off button alignment
        /// </summary>
        private ToggleSwitchButtonAlignment _offButtonAlignment = ToggleSwitchButtonAlignment.Center;

        /// <summary>
        /// The on text
        /// </summary>
        private string _onText = "";
        /// <summary>
        /// The on fore color
        /// </summary>
        private Color _onForeColor = Color.Black;
        /// <summary>
        /// The on font
        /// </summary>
        private Font _onFont;
        /// <summary>
        /// The on side image
        /// </summary>
        private Image _onSideImage = null;
        /// <summary>
        /// The on side scale image
        /// </summary>
        private bool _onSideScaleImage;
        /// <summary>
        /// The on side alignment
        /// </summary>
        private ToggleSwitchAlignment _onSideAlignment = ToggleSwitchAlignment.Center;
        /// <summary>
        /// The on button image
        /// </summary>
        private Image _onButtonImage = null;
        /// <summary>
        /// The on button scale image
        /// </summary>
        private bool _onButtonScaleImage;
        /// <summary>
        /// The on button alignment
        /// </summary>
        private ToggleSwitchButtonAlignment _onButtonAlignment = ToggleSwitchButtonAlignment.Center;

        #endregion Private Members

        #region Constructor Etc.        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleSwitch" /> class.
        /// </summary>
        public ZeroitToggleSwitch()
        {
            SetStyle(ControlStyles.ResizeRedraw |
                        ControlStyles.SupportsTransparentBackColor |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.DoubleBuffer, true);

            OnFont = base.Font;
            OffFont = base.Font;

            SetRenderer(new ToggleSwitchMetroRenderer());

            _animationTimer.Enabled = false;
            _animationTimer.Interval = _animationInterval;
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        /// <summary>
        /// Sets the renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        public void SetRenderer(ToggleSwitchRendererBase renderer)
        {
            renderer.SetToggleSwitch(this);
            _renderer = renderer;

            if (_renderer != null)
                Refresh();
        }

        #endregion Constructor Etc.

        #region Public Properties        
        /// <summary>
        /// Gets or sets the style of the ToggleSwitch.
        /// </summary>
        /// <value>The style.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchStyle), "Metro")]
        [Category("Appearance")]
        [Description("Gets or sets the style of the ToggleSwitch")]
        public ToggleSwitchStyle Style
        {
            get { return _style; }
            set
            {
                if (value != _style)
                {
                    _style = value;

                    switch (_style)
                    {
                        case ToggleSwitchStyle.Metro:
                            SetRenderer(new ToggleSwitchMetroRenderer());
                            break;
                        case ToggleSwitchStyle.Android:
                            SetRenderer(new ToggleSwitchAndroidRenderer());
                            break;
                        case ToggleSwitchStyle.IOS5:
                            SetRenderer(new ToggleSwitchIOS5Renderer());
                            break;
                        case ToggleSwitchStyle.BrushedMetal:
                            SetRenderer(new ToggleSwitchBrushedMetalRenderer());
                            break;
                        case ToggleSwitchStyle.OSX:
                            SetRenderer(new ToggleSwitchOSXRenderer());
                            break;
                        case ToggleSwitchStyle.Carbon:
                            SetRenderer(new ToggleSwitchCarbonRenderer());
                            break;
                        case ToggleSwitchStyle.Iphone:
                            SetRenderer(new ToggleSwitchIphoneRenderer());
                            break;
                        case ToggleSwitchStyle.Fancy:
                            SetRenderer(new ToggleSwitchFancyRenderer());
                            break;
                        case ToggleSwitchStyle.Modern:
                            SetRenderer(new ToggleSwitchModernRenderer());
                            break;
                    }
                }

                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitToggleSwitch" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Data")]
        [Description("Gets or sets the Checked value of the ToggleSwitch")]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value != _checked)
                {
                    while (_animating)
                    {
                        Application.DoEvents();
                    }

                    if (value == true)
                    {
                        int buttonWidth = _renderer.GetButtonWidth();
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can change the value of the button or not.
        /// </summary>
        /// <value><c>true</c> if allow user change; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets whether the user can change the value of the button or not")]
        public bool AllowUserChange
        {
            get { return _allowUserChange; }
            set { _allowUserChange = value; }
        }

        /// <summary>
        /// Gets the checked string.
        /// </summary>
        /// <value>The checked string.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CheckedString
        {
            get
            {
                return Checked ? (string.IsNullOrEmpty(OnText) ? "ON" : OnText) : (string.IsNullOrEmpty(OffText) ? "OFF" : OffText);
            }
        }

        /// <summary>
        /// Gets the button rectangle.
        /// </summary>
        /// <value>The button rectangle.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ButtonRectangle
        {
            get
            {
                return _renderer.GetButtonRectangle();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the ToggleSwitch should be grayed out when disabled.
        /// </summary>
        /// <value><c>true</c> if gray when disabled; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Gets or sets if the ToggleSwitch should be grayed out when disabled")]
        public bool GrayWhenDisabled
        {
            get { return _grayWhenDisabled; }
            set
            {
                if (value != _grayWhenDisabled)
                {
                    _grayWhenDisabled = value;

                    if (!Enabled)
                        Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the ToggleSwitch should toggle when the button is clicked.
        /// </summary>
        /// <value><c>true</c> if toggle on button click; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the button is clicked")]
        public bool ToggleOnButtonClick
        {
            get { return _toggleOnButtonClick; }
            set { _toggleOnButtonClick = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating if the ToggleSwitch should toggle when the track besides the button is clicked.
        /// </summary>
        /// <value><c>true</c> if [toggle on side click]; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the track besides the button is clicked")]
        public bool ToggleOnSideClick
        {
            get { return _toggleOnSideClick; }
            set { _toggleOnSideClick = value; }
        }

        /// <summary>
        /// Gets or sets how much the button need to be on the other side (in peercept) before it snaps.
        /// </summary>
        /// <value>The threshold percentage.</value>
        [Bindable(false)]
        [DefaultValue(50)]
        [Category("Behavior")]
        [Description("Gets or sets how much the button need to be on the other side (in peercept) before it snaps")]
        public int ThresholdPercentage
        {
            get { return _thresholdPercentage; }
            set { _thresholdPercentage = value; }
        }

        /// <summary>
        /// Gets or sets the forecolor of the text when Checked=false.
        /// </summary>
        /// <value>The color of the off fore.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        [Description("Gets or sets the forecolor of the text when Checked=false")]
        public Color OffForeColor
        {
            get { return _offForeColor; }
            set
            {
                if (value != _offForeColor)
                {
                    _offForeColor = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text when Checked=false.
        /// </summary>
        /// <value>The off font.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=false")]
        public Font OffFont
        {
            get { return _offFont; }
            set
            {
                if (!value.Equals(_offFont))
                {
                    _offFont = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text when Checked=true.
        /// </summary>
        /// <value>The off text.</value>
        [Bindable(false)]
        [DefaultValue("")]
        [Category("Appearance")]
        [Description("Gets or sets the text when Checked=true")]
        public string OffText
        {
            get { return _offText; }
            set
            {
                if (value != _offText)
                {
                    _offText = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the side image when Checked=false - Note: Settings the OffSideImage overrules the OffText property.
        /// Only the image will be shown.
        /// </summary>
        /// <value>The off side image.</value>
        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the side image when Checked=false - Note: Settings the OffSideImage overrules the OffText property. Only the image will be shown")]
        public Image OffSideImage
        {
            get { return _offSideImage; }
            set
            {
                if (value != _offSideImage)
                {
                    _offSideImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the side image visible when Checked=false should be scaled to fit.
        /// </summary>
        /// <value><c>true</c> if off side scale image to fit; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the side image visible when Checked=false should be scaled to fit")]
        public bool OffSideScaleImageToFit
        {
            get { return _offSideScaleImage; }
            set
            {
                if (value != _offSideScaleImage)
                {
                    _offSideScaleImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets how the text or side image visible when Checked=false should be aligned.
        /// </summary>
        /// <value>The off side alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the text or side image visible when Checked=false should be aligned")]
        public ToggleSwitchAlignment OffSideAlignment
        {
            get { return _offSideAlignment; }
            set
            {
                if (value != _offSideAlignment)
                {
                    _offSideAlignment = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button image when Checked=false and ButtonImage is not set.
        /// </summary>
        /// <value>The off button image.</value>
        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image when Checked=false and ButtonImage is not set")]
        public Image OffButtonImage
        {
            get { return _offButtonImage; }
            set
            {
                if (value != _offButtonImage)
                {
                    _offButtonImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the button image visible when Checked=false should be scaled to fit.
        /// </summary>
        /// <value><c>true</c> if off button scale image to fit; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image visible when Checked=false should be scaled to fit")]
        public bool OffButtonScaleImageToFit
        {
            get { return _offButtonScaleImage; }
            set
            {
                if (value != _offButtonScaleImage)
                {
                    _offButtonScaleImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets how the button image visible when Checked=false should be aligned.
        /// </summary>
        /// <value>The off button alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image visible when Checked=false should be aligned")]
        public ToggleSwitchButtonAlignment OffButtonAlignment
        {
            get { return _offButtonAlignment; }
            set
            {
                if (value != _offButtonAlignment)
                {
                    _offButtonAlignment = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the forecolor of the text when Checked=true.
        /// </summary>
        /// <value>The color of the on fore.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        [Description("Gets or sets the forecolor of the text when Checked=true")]
        public Color OnForeColor
        {
            get { return _onForeColor; }
            set
            {
                if (value != _onForeColor)
                {
                    _onForeColor = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text when Checked=true.
        /// </summary>
        /// <value>The on font.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8,25pt")]
        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=true")]
        public Font OnFont
        {
            get { return _onFont; }
            set
            {
                if (!value.Equals(_onFont))
                {
                    _onFont = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text when Checked=true.
        /// </summary>
        /// <value>The on text.</value>
        [Bindable(false)]
        [DefaultValue("")]
        [Category("Appearance")]
        [Description("Gets or sets the text when Checked=true")]
        public string OnText
        {
            get { return _onText; }
            set
            {
                if (value != _onText)
                {
                    _onText = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the side image visible when Checked=true - Note: Settings the OnSideImage overrules the OnText property.
        /// Only the image will be shown.
        /// </summary>
        /// <value>The on side image.</value>
        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the side image visible when Checked=true - Note: Settings the OnSideImage overrules the OnText property. Only the image will be shown.")]
        public Image OnSideImage
        {
            get { return _onSideImage; }
            set
            {
                if (value != _onSideImage)
                {
                    _onSideImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the side image visible when Checked=true should be scaled to fit.
        /// </summary>
        /// <value><c>true</c> if on side scale image to fit; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the side image visible when Checked=true should be scaled to fit")]
        public bool OnSideScaleImageToFit
        {
            get { return _onSideScaleImage; }
            set
            {
                if (value != _onSideScaleImage)
                {
                    _onSideScaleImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        /// <value>The button image.</value>
        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image")]
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set
            {
                if (value != _buttonImage)
                {
                    _buttonImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the button image should be scaled to fit.
        /// </summary>
        /// <value><c>true</c> if button scale image to fit; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image should be scaled to fit")]
        public bool ButtonScaleImageToFit
        {
            get { return _buttonScaleImage; }
            set
            {
                if (value != _buttonScaleImage)
                {
                    _buttonScaleImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button alignment.
        /// </summary>
        /// <value>The button alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image should be aligned")]
        public ToggleSwitchButtonAlignment ButtonAlignment
        {
            get { return _buttonAlignment; }
            set
            {
                if (value != _buttonAlignment)
                {
                    _buttonAlignment = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets how the text or side image visible when Checked=true should be aligned.
        /// </summary>
        /// <value>The on side alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the text or side image visible when Checked=true should be aligned")]
        public ToggleSwitchAlignment OnSideAlignment
        {
            get { return _onSideAlignment; }
            set
            {
                if (value != _onSideAlignment)
                {
                    _onSideAlignment = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button image visible when Checked=true and ButtonImage is not set.
        /// </summary>
        /// <value>The on button image.</value>
        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image visible when Checked=true and ButtonImage is not set")]
        public Image OnButtonImage
        {
            get { return _onButtonImage; }
            set
            {
                if (value != _onButtonImage)
                {
                    _onButtonImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the button image visible when Checked=true should be scaled to fit.
        /// </summary>
        /// <value><c>true</c> if on button scale image to fit; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image visible when Checked=true should be scaled to fit")]
        public bool OnButtonScaleImageToFit
        {
            get { return _onButtonScaleImage; }
            set
            {
                if (value != _onButtonScaleImage)
                {
                    _onButtonScaleImage = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets how the button image visible when Checked=true should be aligned.
        /// </summary>
        /// <value>The on button alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image visible when Checked=true should be aligned")]
        public ToggleSwitchButtonAlignment OnButtonAlignment
        {
            get { return _onButtonAlignment; }
            set
            {
                if (value != _onButtonAlignment)
                {
                    _onButtonAlignment = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the toggle change should be animated or not.
        /// </summary>
        /// <value><c>true</c> if [use animation]; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets whether the toggle change should be animated or not")]
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set { _useAnimation = value; }
        }

        /// <summary>
        /// Gets or sets the interval in ms between animation frames.
        /// </summary>
        /// <value>The animation interval.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">AnimationInterval must larger than zero!</exception>
        /// <exception cref="ArgumentOutOfRangeException">AnimationInterval must larger than zero!</exception>
        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Behavior")]
        [Description("Gets or sets the interval in ms between animation frames")]
        public int AnimationInterval
        {
            get { return _animationInterval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationInterval must larger than zero!");
                }

                _animationInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets the step in pixels the button should be moved between each animation interval.
        /// </summary>
        /// <value>The animation step.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">AnimationStep must larger than zero!</exception>
        /// <exception cref="ArgumentOutOfRangeException">AnimationStep must larger than zero!</exception>
        [Bindable(false)]
        [DefaultValue(10)]
        [Category("Behavior")]
        [Description("Gets or sets the step in pixels the button should be moved between each animation interval")]
        public int AnimationStep
        {
            get { return _animationStep; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationStep must larger than zero!");
                }

                _animationStep = value;
            }
        }

        #region Hidden Base Properties        
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get { return ""; }
            set { base.Text = ""; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get { return Color.Black; }
            set { base.ForeColor = Color.Black; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = new Font(base.Font, FontStyle.Regular); }
        }

        #endregion Hidden Base Properties

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets a value indicating whether this instance is button hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is button hovered; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonHovered
        {
            get { return _isButtonHovered && !_isButtonPressed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is button pressed.
        /// </summary>
        /// <value><c>true</c> if this instance is button pressed; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonPressed
        {
            get { return _isButtonPressed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is left side hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is left side hovered; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSideHovered
        {
            get { return _isLeftFieldHovered && !_isLeftFieldPressed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is left side pressed.
        /// </summary>
        /// <value><c>true</c> if this instance is left side pressed; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSidePressed
        {
            get { return _isLeftFieldPressed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is right side hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is right side hovered; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSideHovered
        {
            get { return _isRightFieldHovered && !_isRightFieldPressed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is right side pressed.
        /// </summary>
        /// <value><c>true</c> if this instance is right side pressed; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSidePressed
        {
            get { return _isRightFieldPressed; }
        }

        /// <summary>
        /// Gets or sets the button value.
        /// </summary>
        /// <value>The button value.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ButtonValue
        {
            get
            {
                if (_animating || _moving)
                    return _buttonValue;
                else if (_checked)
                    return Width - _renderer.GetButtonWidth();
                else
                    return 0;
            }
            set
            {
                if (value != _buttonValue)
                {
                    _buttonValue = value;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is button on left side.
        /// </summary>
        /// <value><c>true</c> if this instance is button on left side; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnLeftSide
        {
            get { return (ButtonValue <= 0); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is button on right side.
        /// </summary>
        /// <value><c>true</c> if this instance is button on right side; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnRightSide
        {
            get { return (ButtonValue >= (Width - _renderer.GetButtonWidth())); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is button moving left.
        /// </summary>
        /// <value><c>true</c> if this instance is button moving left; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingLeft
        {
            get { return (_animating && !IsButtonOnLeftSide && _animationResult == false); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is button moving right.
        /// </summary>
        /// <value><c>true</c> if this instance is button moving right; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingRight
        {
            get { return (_animating && !IsButtonOnRightSide && _animationResult == true); }
        }

        /// <summary>
        /// Gets a value indicating whether [animation result].
        /// </summary>
        /// <value><c>true</c> if [animation result]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool AnimationResult
        {
            get { return _animationResult; }
        }

        #endregion Private Properties

        #region Overridden Control Methods

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get { return new Size(50, 19); }
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.ResetClip();

            base.OnPaintBackground(pevent);

            if (_renderer != null)
                _renderer.RenderBackground(pevent);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.ResetClip();

            base.OnPaint(e);

            if (_renderer != null)
                _renderer.RenderControl(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _lastMouseEventArgs = e;

            int buttonWidth = _renderer.GetButtonWidth();
            Rectangle buttonRectangle = _renderer.GetButtonRectangle(buttonWidth);

            if (_moving)
            {
                int val = _xValue + (e.Location.X - _xOffset);

                if (val < 0)
                    val = 0;

                if (val > Width - buttonWidth)
                    val = Width - buttonWidth;

                ButtonValue = val;
                Refresh();
                return;
            }

            if (buttonRectangle.Contains(e.Location))
            {
                _isButtonHovered = true;
                _isLeftFieldHovered = false;
                _isRightFieldHovered = false;
            }
            else
            {
                if (e.Location.X > buttonRectangle.X + buttonRectangle.Width)
                {
                    _isButtonHovered = false;
                    _isLeftFieldHovered = false;
                    _isRightFieldHovered = true;
                }
                else if (e.Location.X < buttonRectangle.X)
                {
                    _isButtonHovered = false;
                    _isLeftFieldHovered = true;
                    _isRightFieldHovered = false;
                }
            }

            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_animating || !AllowUserChange)
                return;

            int buttonWidth = _renderer.GetButtonWidth();
            Rectangle buttonRectangle = _renderer.GetButtonRectangle(buttonWidth);

            _savedButtonValue = ButtonValue;

            if (buttonRectangle.Contains(e.Location))
            {
                _isButtonPressed = true;
                _isLeftFieldPressed = false;
                _isRightFieldPressed = false;

                _moving = true;
                _xOffset = e.Location.X;
                _buttonValue = buttonRectangle.X;
                _xValue = ButtonValue;
            }
            else
            {
                if (e.Location.X > buttonRectangle.X + buttonRectangle.Width)
                {
                    _isButtonPressed = false;
                    _isLeftFieldPressed = false;
                    _isRightFieldPressed = true;
                }
                else if (e.Location.X < buttonRectangle.X)
                {
                    _isButtonPressed = false;
                    _isLeftFieldPressed = true;
                    _isRightFieldPressed = false;
                }
            }

            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_animating || !AllowUserChange)
                return;

            int buttonWidth = _renderer.GetButtonWidth();

            bool wasLeftSidePressed = IsLeftSidePressed;
            bool wasRightSidePressed = IsRightSidePressed;

            _isButtonPressed = false;
            _isLeftFieldPressed = false;
            _isRightFieldPressed = false;

            if (_moving)
            {
                int percentage = (int)((100 * (double)ButtonValue) / ((double)Width - (double)buttonWidth));

                if (_checked)
                {
                    if (percentage <= (100 - _thresholdPercentage))
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                    else if (ToggleOnButtonClick && _savedButtonValue == ButtonValue)
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                    else
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                }
                else
                {
                    if (percentage >= _thresholdPercentage)
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else if (ToggleOnButtonClick && _savedButtonValue == ButtonValue)
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                }

                _moving = false;
                return;
            }

            if (IsButtonOnRightSide)
            {
                _buttonValue = Width - buttonWidth;
                _animationTarget = 0;
            }
            else
            {
                _buttonValue = 0;
                _animationTarget = Width - buttonWidth;
            }

            if (wasLeftSidePressed && ToggleOnSideClick)
            {
                SetValueInternal(false);
            }
            else if (wasRightSidePressed && ToggleOnSideClick)
            {
                SetValueInternal(true);
            }

            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _isButtonHovered = false;
            _isLeftFieldHovered = false;
            _isRightFieldHovered = false;
            _isButtonPressed = false;
            _isLeftFieldPressed = false;
            _isRightFieldPressed = false;

            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.RegionChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnRegionChanged(EventArgs e)
        {
            base.OnRegionChanged(e);
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (_animationTarget > 0)
            {
                int buttonWidth = _renderer.GetButtonWidth();
                _animationTarget = Width - buttonWidth;
            }

            base.OnSizeChanged(e);
        }

        #endregion Overridden Control Methods

        #region Private Methods

        /// <summary>
        /// Sets the value internal.
        /// </summary>
        /// <param name="checkedValue">if set to <c>true</c> [checked value].</param>
        private void SetValueInternal(bool checkedValue)
        {
            if (checkedValue == _checked)
                return;

            while (_animating)
            {
                Application.DoEvents();
            }

            BeginAnimation(checkedValue);
        }

        /// <summary>
        /// Begins the animation.
        /// </summary>
        /// <param name="checkedValue">if set to <c>true</c> [checked value].</param>
        private void BeginAnimation(bool checkedValue)
        {
            _animating = true;
            _animationResult = checkedValue;

            if (_animationTimer != null && _useAnimation)
            {
                _animationTimer.Interval = _animationInterval;
                _animationTimer.Enabled = true;
            }
            else
            {
                AnimationComplete();
            }
        }

        /// <summary>
        /// Handles the Tick event of the AnimationTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _animationTimer.Enabled = false;

            bool animationDone = false;
            int newButtonValue;

            if (IsButtonMovingRight)
            {
                newButtonValue = ButtonValue + _animationStep;

                if (newButtonValue > _animationTarget)
                    newButtonValue = _animationTarget;

                ButtonValue = newButtonValue;

                animationDone = ButtonValue >= _animationTarget;
            }
            else
            {
                newButtonValue = ButtonValue - _animationStep;

                if (newButtonValue < _animationTarget)
                    newButtonValue = _animationTarget;

                ButtonValue = newButtonValue;

                animationDone = ButtonValue <= _animationTarget;
            }

            if (animationDone)
                AnimationComplete();
            else
                _animationTimer.Enabled = true;
        }

        /// <summary>
        /// Animations the complete.
        /// </summary>
        private void AnimationComplete()
        {
            _animating = false;
            _moving = false;
            _checked = _animationResult;

            _isButtonHovered = false;
            _isButtonPressed = false;
            _isLeftFieldHovered = false;
            _isLeftFieldPressed = false;
            _isRightFieldHovered = false;
            _isRightFieldPressed = false;

            Refresh();

            if (CheckedChanged != null)
                CheckedChanged(this, new EventArgs());

            if (_lastMouseEventArgs != null)
                OnMouseMove(_lastMouseEventArgs);

            _lastMouseEventArgs = null;
        }

        #endregion Private Methods
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitToggleSwitchDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitToggleSwitchDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitToggleSwitchSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitToggleSwitchSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitToggleSwitchSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitToggleSwitch colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleSwitchSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitToggleSwitchSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitToggleSwitch;

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
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchStyle Style
        {
            get
            {
                return colUserControl.Style;
            }
            set
            {
                GetPropertyByName("Style").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitToggleSwitchSmartTagActionList"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get
            {
                return colUserControl.Checked;
            }
            set
            {
                GetPropertyByName("Checked").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow user change].
        /// </summary>
        /// <value><c>true</c> if [allow user change]; otherwise, <c>false</c>.</value>
        public bool AllowUserChange
        {
            get
            {
                return colUserControl.AllowUserChange;
            }
            set
            {
                GetPropertyByName("AllowUserChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the checked string.
        /// </summary>
        /// <value>The checked string.</value>
        public string CheckedString
        {
            get
            {
                return colUserControl.CheckedString;
            }
            set
            {
                GetPropertyByName("CheckedString").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button rectangle.
        /// </summary>
        /// <value>The button rectangle.</value>
        public Rectangle ButtonRectangle
        {
            get
            {
                return colUserControl.ButtonRectangle;
            }
            set
            {
                GetPropertyByName("ButtonRectangle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [gray when disabled].
        /// </summary>
        /// <value><c>true</c> if [gray when disabled]; otherwise, <c>false</c>.</value>
        public bool GrayWhenDisabled
        {
            get
            {
                return colUserControl.GrayWhenDisabled;
            }
            set
            {
                GetPropertyByName("GrayWhenDisabled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [toggle on button click].
        /// </summary>
        /// <value><c>true</c> if [toggle on button click]; otherwise, <c>false</c>.</value>
        public bool ToggleOnButtonClick
        {
            get
            {
                return colUserControl.ToggleOnButtonClick;
            }
            set
            {
                GetPropertyByName("ToggleOnButtonClick").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [toggle on side click].
        /// </summary>
        /// <value><c>true</c> if [toggle on side click]; otherwise, <c>false</c>.</value>
        public bool ToggleOnSideClick
        {
            get
            {
                return colUserControl.ToggleOnSideClick;
            }
            set
            {
                GetPropertyByName("ToggleOnSideClick").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the threshold percentage.
        /// </summary>
        /// <value>The threshold percentage.</value>
        public int ThresholdPercentage
        {
            get
            {
                return colUserControl.ThresholdPercentage;
            }
            set
            {
                GetPropertyByName("ThresholdPercentage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the off fore.
        /// </summary>
        /// <value>The color of the off fore.</value>
        public Color OffForeColor
        {
            get
            {
                return colUserControl.OffForeColor;
            }
            set
            {
                GetPropertyByName("OffForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off font.
        /// </summary>
        /// <value>The off font.</value>
        public Font OffFont
        {
            get
            {
                return colUserControl.OffFont;
            }
            set
            {
                GetPropertyByName("OffFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off text.
        /// </summary>
        /// <value>The off text.</value>
        public string OffText
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
        /// Gets or sets the off side image.
        /// </summary>
        /// <value>The off side image.</value>
        public Image OffSideImage
        {
            get
            {
                return colUserControl.OffSideImage;
            }
            set
            {
                GetPropertyByName("OffSideImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [off side scale image to fit].
        /// </summary>
        /// <value><c>true</c> if [off side scale image to fit]; otherwise, <c>false</c>.</value>
        public bool OffSideScaleImageToFit
        {
            get
            {
                return colUserControl.OffSideScaleImageToFit;
            }
            set
            {
                GetPropertyByName("OffSideScaleImageToFit").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off side alignment.
        /// </summary>
        /// <value>The off side alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchAlignment OffSideAlignment
        {
            get
            {
                return colUserControl.OffSideAlignment;
            }
            set
            {
                GetPropertyByName("OffSideAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off button image.
        /// </summary>
        /// <value>The off button image.</value>
        public Image OffButtonImage
        {
            get
            {
                return colUserControl.OffButtonImage;
            }
            set
            {
                GetPropertyByName("OffButtonImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [off button scale image to fit].
        /// </summary>
        /// <value><c>true</c> if [off button scale image to fit]; otherwise, <c>false</c>.</value>
        public bool OffButtonScaleImageToFit
        {
            get
            {
                return colUserControl.OffButtonScaleImageToFit;
            }
            set
            {
                GetPropertyByName("OffButtonScaleImageToFit").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the off button alignment.
        /// </summary>
        /// <value>The off button alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchButtonAlignment OffButtonAlignment
        {
            get
            {
                return colUserControl.OffButtonAlignment;
            }
            set
            {
                GetPropertyByName("OffButtonAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the on fore.
        /// </summary>
        /// <value>The color of the on fore.</value>
        public Color OnForeColor
        {
            get
            {
                return colUserControl.OnForeColor;
            }
            set
            {
                GetPropertyByName("OnForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the on font.
        /// </summary>
        /// <value>The on font.</value>
        public Font OnFont
        {
            get
            {
                return colUserControl.OnFont;
            }
            set
            {
                GetPropertyByName("OnFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the on text.
        /// </summary>
        /// <value>The on text.</value>
        public string OnText
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
        /// Gets or sets the on side image.
        /// </summary>
        /// <value>The on side image.</value>
        public Image OnSideImage
        {
            get
            {
                return colUserControl.OnSideImage;
            }
            set
            {
                GetPropertyByName("OnSideImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [on side scale image to fit].
        /// </summary>
        /// <value><c>true</c> if [on side scale image to fit]; otherwise, <c>false</c>.</value>
        public bool OnSideScaleImageToFit
        {
            get
            {
                return colUserControl.OnSideScaleImageToFit;
            }
            set
            {
                GetPropertyByName("OnSideScaleImageToFit").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        /// <value>The button image.</value>
        public Image ButtonImage
        {
            get
            {
                return colUserControl.ButtonImage;
            }
            set
            {
                GetPropertyByName("ButtonImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [button scale image to fit].
        /// </summary>
        /// <value><c>true</c> if [button scale image to fit]; otherwise, <c>false</c>.</value>
        public bool ButtonScaleImageToFit
        {
            get
            {
                return colUserControl.ButtonScaleImageToFit;
            }
            set
            {
                GetPropertyByName("ButtonScaleImageToFit").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button alignment.
        /// </summary>
        /// <value>The button alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchButtonAlignment ButtonAlignment
        {
            get
            {
                return colUserControl.ButtonAlignment;
            }
            set
            {
                GetPropertyByName("ButtonAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the on side alignment.
        /// </summary>
        /// <value>The on side alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchAlignment OnSideAlignment
        {
            get
            {
                return colUserControl.OnSideAlignment;
            }
            set
            {
                GetPropertyByName("OnSideAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the on button image.
        /// </summary>
        /// <value>The on button image.</value>
        public Image OnButtonImage
        {
            get
            {
                return colUserControl.OnButtonImage;
            }
            set
            {
                GetPropertyByName("OnButtonImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [on button scale image to fit].
        /// </summary>
        /// <value><c>true</c> if [on button scale image to fit]; otherwise, <c>false</c>.</value>
        public bool OnButtonScaleImageToFit
        {
            get
            {
                return colUserControl.OnButtonScaleImageToFit;
            }
            set
            {
                GetPropertyByName("OnButtonScaleImageToFit").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the on button alignment.
        /// </summary>
        /// <value>The on button alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleSwitch.ToggleSwitchButtonAlignment OnButtonAlignment
        {
            get
            {
                return colUserControl.OnButtonAlignment;
            }
            set
            {
                GetPropertyByName("OnButtonAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use animation].
        /// </summary>
        /// <value><c>true</c> if [use animation]; otherwise, <c>false</c>.</value>
        public bool UseAnimation
        {
            get
            {
                return colUserControl.UseAnimation;
            }
            set
            {
                GetPropertyByName("UseAnimation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation interval.
        /// </summary>
        /// <value>The animation interval.</value>
        public int AnimationInterval
        {
            get
            {
                return colUserControl.AnimationInterval;
            }
            set
            {
                GetPropertyByName("AnimationInterval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation step.
        /// </summary>
        /// <value>The animation step.</value>
        public int AnimationStep
        {
            get
            {
                return colUserControl.AnimationStep;
            }
            set
            {
                GetPropertyByName("AnimationStep").SetValue(colUserControl, value);
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("Style",
                                 "Style", "Appearance",
                                 "Sets the style of the toggle."));

            //items.Add(new DesignerActionPropertyItem("Checked",
            //                     "Checked", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("AllowUserChange",
            //                     "Allow User Change", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("CheckedString",
            //                    "Checked String", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("GrayWhenDisabled",
            //                    "Gray When Disabled", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("ToggleOnButtonClick",
            //                    "Toggle On Button Click", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("ToggleOnSideClick",
            //                    "Toggle On Side Click", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("ThresholdPercentage",
            //                    "Threshold Percentage", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("OffForeColor",
            //                    "Off ForeColor", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("OnForeColor",
            //                    "On ForeColor", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("OffFont",
            //                    "Off Font", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("OffText",
            //                    "Off Text", "Appearance",
            //                    "Type few characters to filter Cities."));



            items.Add(new DesignerActionPropertyItem("OffButtonImage",
                                "Off Button Image", "Appearance",
                                "Sets the off button image."));

            items.Add(new DesignerActionPropertyItem("OnButtonImage",
                                "On Button Image", "Appearance",
                                "Sets the on button image."));

            //items.Add(new DesignerActionPropertyItem("OffSideAlignment",
            //                    "Off Side Alignment", "Appearance",
            //                    "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("OffButtonScaleImageToFit",
                                "Off Button Scale Image To Fit", "Appearance",
                                "Sets the off button image to fit."));

            items.Add(new DesignerActionPropertyItem("OnButtonScaleImageToFit",
                                "On Button Scale Image To Fit", "Appearance",
                                "Sets the on button image to fit."));

            items.Add(new DesignerActionPropertyItem("OffButtonAlignment",
                                "Off Button Alignment", "Appearance",
                                "Sets the off button alignment."));

            items.Add(new DesignerActionPropertyItem("OnButtonAlignment",
                                "On Button Alignment", "Appearance",
                                "Sets the on button alignment."));

            //items.Add(new DesignerActionPropertyItem("OnFont",
            //                    "On Font", "Appearance",
            //                    "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("OnText",
            //                    "On Text", "Appearance",
            //                    "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("OffSideImage",
                    "Off Side Image", "Appearance",
                    "Sets the off side image."));

            items.Add(new DesignerActionPropertyItem("OnSideImage",
                                "On Side Image", "Appearance",
                                "Sets the off side image."));

            items.Add(new DesignerActionPropertyItem("OffSideScaleImageToFit",
                                "Off Side Scale Image To Fit", "Appearance",
                                "Sets the off side image to fit."));

            items.Add(new DesignerActionPropertyItem("OnSideScaleImageToFit",
                                "On Side Scale Image To Fit", "Appearance",
                                "Sets the on side image to fit."));

            items.Add(new DesignerActionPropertyItem("ButtonImage",
                                "Button Image", "Appearance",
                                "Sets the button image."));

            items.Add(new DesignerActionPropertyItem("ButtonScaleImageToFit",
                                "ButtonScaleImageToFit", "Appearance",
                                "Sets the button image to fit."));

            items.Add(new DesignerActionPropertyItem("ButtonAlignment",
                                "Button Alignment", "Appearance",
                                "Sets the button alignment."));

            //items.Add(new DesignerActionPropertyItem("OnSideAlignment",
            //                    "On Side Alignment", "Appearance",
            //                    "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("UseAnimation",
                                "Use Animation", "Appearance",
                                "Set to enable animation."));

            items.Add(new DesignerActionPropertyItem("AnimationInterval",
                                "Animation Interval", "Appearance",
                                "Sets the animation interval."));

            items.Add(new DesignerActionPropertyItem("AnimationStep",
                                "Animation Step", "Appearance",
                                "Sets the animation step."));


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
