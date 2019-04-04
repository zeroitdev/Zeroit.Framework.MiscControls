// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="OdameTracker.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Zeroit Odame TrackBar

    #region Control
    // Original code from Michal Brylka on Code Project
    // see https://www.codeproject.com/Articles/17395/Owner-drawn-trackbar-slider
    // ColorSlider is a trackbar control written in C# as a replacement of the trackbar 
    // proposed by Microsoft in Visual Studio

    /// <summary>
    /// Encapsulates control that visualy displays certain integer value and allows user to change it within desired range. It imitates <see cref="System.Windows.Forms.TrackBar" /> as far as mouse usage is concerned.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxBitmap(typeof(TrackBar))]
    [DefaultEvent("Scroll"), DefaultProperty("BarInnerColor")]
    [Designer(typeof(ZeroitOdameSliderDesigner))]
    public partial class ZeroitOdameTrackBar : Control
    {
        #region Events

        /// <summary>
        /// Fires when Slider position has changed
        /// </summary>
        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event EventHandler ValueChanged;

        /// <summary>
        /// Fires when user scrolls the Slider
        /// </summary>
        [Description("Event fires when the Slider position is changed")]
        [Category("Behavior")]
        public event ScrollEventHandler Scroll;

        #endregion


        #region Properties

        /// <summary>
        /// The bar rect
        /// </summary>
        private Rectangle barRect; //bounding rectangle of bar area
        /// <summary>
        /// The bar half rect
        /// </summary>
        private Rectangle barHalfRect;
        /// <summary>
        /// The thumb half rect
        /// </summary>
        private Rectangle thumbHalfRect;
        /// <summary>
        /// The elapsed rect
        /// </summary>
        private Rectangle elapsedRect; //bounding rectangle of elapsed area

        #region thumb

        /// <summary>
        /// The thumb rect
        /// </summary>
        private Rectangle thumbRect; //bounding rectangle of thumb area
        /// <summary>
        /// Gets the thumb rect. Usefull to determine bounding rectangle when creating custom thumb shape.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        public Rectangle ThumbRect
        {
            get { return thumbRect; }
        }


        /// <summary>
        /// The thumb size
        /// </summary>
        private Size _thumbSize = new Size(16, 16);

        /// <summary>
        /// Gets or sets the size of the thumb.
        /// </summary>
        /// <value>The size of the thumb.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">TrackSize has to be greather than zero and lower than half of Slider width</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is lower than zero or grather than half of appropiate dimension</exception>
        [Description("Set Slider thumb size")]
        [Category("ColorSlider")]
        [DefaultValue(16)]
        public Size ThumbSize
        {
            get { return _thumbSize; }
            set
            {
                int h = value.Height;
                int w = value.Width;
                if (h > 0 && w > 0)
                {
                    _thumbSize = new Size(w, h);
                }
                else
                    throw new ArgumentOutOfRangeException(
                        "TrackSize has to be greather than zero and lower than half of Slider width");

                Invalidate();
            }
        }

        /// <summary>
        /// The thumb custom shape
        /// </summary>
        private GraphicsPath _thumbCustomShape = null;
        /// <summary>
        /// Gets or sets the thumb custom shape. Use ThumbRect property to determine bounding rectangle.
        /// </summary>
        /// <value>The thumb custom shape. null means default shape</value>
        [Description("Set Slider's thumb's custom shape")]
        [Category("ColorSlider")]
        [Browsable(false)]
        [DefaultValue(typeof(GraphicsPath), "null")]
        public GraphicsPath ThumbCustomShape
        {
            get { return _thumbCustomShape; }
            set
            {
                _thumbCustomShape = value;
                //_thumbSize = (int) (_barOrientation == Orientation.Horizontal ? value.GetBounds().Width : value.GetBounds().Height) + 1;
                _thumbSize = new Size((int)value.GetBounds().Width, (int)value.GetBounds().Height);

                Invalidate();
            }
        }

        /// <summary>
        /// The thumb round rect size
        /// </summary>
        private Size _thumbRoundRectSize = new Size(16, 16);
        /// <summary>
        /// Gets or sets the size of the thumb round rectangle edges.
        /// </summary>
        /// <value>The size of the thumb round rectangle edges.</value>
        [Description("Set Slider's thumb round rect size")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Size), "16; 16")]
        public Size ThumbRoundRectSize
        {
            get { return _thumbRoundRectSize; }
            set
            {
                int h = value.Height, w = value.Width;
                if (h <= 0) h = 1;
                if (w <= 0) w = 1;
                _thumbRoundRectSize = new Size(w, h);
                Invalidate();
            }
        }

        /// <summary>
        /// The border round rect size
        /// </summary>
        private Size _borderRoundRectSize = new Size(8, 8);
        /// <summary>
        /// Gets or sets the size of the border round rect.
        /// </summary>
        /// <value>The size of the border round rect.</value>
        [Description("Set Slider's border round rect size")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Size), "8; 8")]
        public Size BorderRoundRectSize
        {
            get { return _borderRoundRectSize; }
            set
            {
                int h = value.Height, w = value.Width;
                if (h <= 0) h = 1;
                if (w <= 0) w = 1;
                _borderRoundRectSize = new Size(w, h);
                Invalidate();
            }
        }


        /// <summary>
        /// The draw semitransparent thumb
        /// </summary>
        private bool _drawSemitransparentThumb = true;
        /// <summary>
        /// Gets or sets a value indicating whether to draw semitransparent thumb.
        /// </summary>
        /// <value><c>true</c> if semitransparent thumb should be drawn; otherwise, <c>false</c>.</value>
        [Description("Set whether to draw semitransparent thumb")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool DrawSemitransparentThumb
        {
            get { return _drawSemitransparentThumb; }
            set
            {
                _drawSemitransparentThumb = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The thumb image
        /// </summary>
        private Image _thumbImage = null;
        //private Image _thumbImage = Properties.Resources.BTN_Thumb_Blue;
        /// <summary>
        /// Gets or sets the Image used to render the thumb.
        /// </summary>
        /// <value>the thumb Image</value>
        [Description("Set to use a specific Image for the thumb")]
        [Category("ColorSlider")]
        [DefaultValue(null)]
        public Image ThumbImage
        {
            get { return _thumbImage; }
            set
            {
                if (value != null)
                    _thumbImage = value;
                else
                    _thumbImage = null;
                Invalidate();
            }
        }

        #endregion


        #region Appearance

        /// <summary>
        /// The bar orientation
        /// </summary>
        private Orientation _barOrientation = Orientation.Horizontal;
        /// <summary>
        /// Gets or sets the orientation of Slider.
        /// </summary>
        /// <value>The orientation.</value>
        [Description("Set Slider orientation")]
        [Category("ColorSlider")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return _barOrientation; }
            set
            {
                if (_barOrientation != value)
                {
                    _barOrientation = value;
                    int temp = Width;
                    Width = Height;
                    Height = temp;

                    //if (_thumbCustomShape != null)
                    //    _thumbSize = (int)(_barOrientation == Orientation.Horizontal ? _thumbCustomShape.GetBounds().Width : _thumbCustomShape.GetBounds().Height) + 1;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// The draw focus rectangle
        /// </summary>
        private bool _drawFocusRectangle = false;
        /// <summary>
        /// Gets or sets a value indicating whether to draw focus rectangle.
        /// </summary>
        /// <value><c>true</c> if focus rectangle should be drawn; otherwise, <c>false</c>.</value>
        [Description("Set whether to draw focus rectangle")]
        [Category("ColorSlider")]
        [DefaultValue(false)]
        public bool DrawFocusRectangle
        {
            get { return _drawFocusRectangle; }
            set
            {
                _drawFocusRectangle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The mouse effects
        /// </summary>
        private bool _mouseEffects = true;
        /// <summary>
        /// Gets or sets whether mouse entry and exit actions have impact on how control look.
        /// </summary>
        /// <value><c>true</c> if mouse entry and exit actions have impact on how control look; otherwise, <c>false</c>.</value>
        [Description("Set whether mouse entry and exit actions have impact on how control look")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool MouseEffects
        {
            get { return _mouseEffects; }
            set
            {
                _mouseEffects = value;
                Invalidate();
            }
        }

        #endregion


        #region values

        /// <summary>
        /// The tracker value
        /// </summary>
        private int _trackerValue = 30;
        /// <summary>
        /// Gets or sets the value of Slider.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value is outside appropriate range (min, max)</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
        [Description("Set Slider value")]
        [Category("ColorSlider")]
        [DefaultValue(30)]
        public int Value
        {
            get { return _trackerValue; }
            set
            {
                if (value >= _minimum & value <= _maximum)
                {
                    _trackerValue = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }


        /// <summary>
        /// The minimum
        /// </summary>
        private int _minimum = 0;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimal value is greather than maximal one</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when minimal value is greather than maximal one</exception>
        [Description("Set Slider minimal point")]
        [Category("ColorSlider")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                if (value < _maximum)
                {
                    _minimum = value;
                    if (_trackerValue < _minimum)
                    {
                        _trackerValue = _minimum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");
            }
        }


        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum = 100;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when maximal value is lower than minimal one</exception>
        [Description("Set Slider maximal point")]
        [Category("ColorSlider")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value > _minimum)
                {
                    _maximum = value;
                    if (_trackerValue > _maximum)
                    {
                        _trackerValue = _maximum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                //else throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");
            }
        }

        /// <summary>
        /// The small change
        /// </summary>
        private uint _smallChange = 1;
        /// <summary>
        /// Gets or sets trackbar's small change. It affects how to behave when directional keys are pressed
        /// </summary>
        /// <value>The small change value.</value>
        [Description("Set trackbar's small change")]
        [Category("ColorSlider")]
        [DefaultValue(1)]
        public uint SmallChange
        {
            get { return _smallChange; }
            set { _smallChange = value; }
        }

        /// <summary>
        /// The large change
        /// </summary>
        private uint _largeChange = 5;
        /// <summary>
        /// Gets or sets trackbar's large change. It affects how to behave when PageUp/PageDown keys are pressed
        /// </summary>
        /// <value>The large change value.</value>
        [Description("Set trackbar's large change")]
        [Category("ColorSlider")]
        [DefaultValue(5)]
        public uint LargeChange
        {
            get { return _largeChange; }
            set { _largeChange = value; }
        }

        /// <summary>
        /// The mouse wheel bar partitions
        /// </summary>
        private int _mouseWheelBarPartitions = 10;
        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">MouseWheelBarPartitions has to be greather than zero</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value isn't greather than zero</exception>
        [Description("Set to how many parts is bar divided when using mouse wheel")]
        [Category("ColorSlider")]
        [DefaultValue(10)]
        public int MouseWheelBarPartitions
        {
            get { return _mouseWheelBarPartitions; }
            set
            {
                if (value > 0)
                    _mouseWheelBarPartitions = value;
                else throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
            }
        }

        #endregion


        #region colors

        /// <summary>
        /// The thumb outer color
        /// </summary>
        private Color _thumbOuterColor = Color.White;
        /// <summary>
        /// Gets or sets the thumb outer color.
        /// </summary>
        /// <value>The thumb outer color.</value>
        [Description("Sets Slider thumb outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color ThumbOuterColor
        {
            get { return _thumbOuterColor; }
            set
            {
                _thumbOuterColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The thumb inner color
        /// </summary>
        private Color _thumbInnerColor = Color.FromArgb(21, 56, 152);
        /// <summary>
        /// Gets or sets the inner color of the thumb.
        /// </summary>
        /// <value>The inner color of the thumb.</value>
        [Description("Set Slider thumb inner color")]
        [Category("ColorSlider")]
        public Color ThumbInnerColor
        {
            get { return _thumbInnerColor; }
            set
            {
                _thumbInnerColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The thumb pen color
        /// </summary>
        private Color _thumbPenColor = Color.FromArgb(21, 56, 152);
        /// <summary>
        /// Gets or sets the color of the thumb pen.
        /// </summary>
        /// <value>The color of the thumb pen.</value>
        [Description("Set Slider thumb pen color")]
        [Category("ColorSlider")]
        public Color ThumbPenColor
        {
            get { return _thumbPenColor; }
            set
            {
                _thumbPenColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The bar inner color
        /// </summary>
        private Color _barInnerColor = Color.Black;
        /// <summary>
        /// Gets or sets the inner color of the bar.
        /// </summary>
        /// <value>The inner color of the bar.</value>
        [Description("Set Slider bar inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BarInnerColor
        {
            get { return _barInnerColor; }
            set
            {
                _barInnerColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The elapsed pen color top
        /// </summary>
        private Color _elapsedPenColorTop = Color.FromArgb(95, 140, 180);   // bleu clair
        /// <summary>
        /// Gets or sets the top color of the Elapsed
        /// </summary>
        /// <value>The elapsed pen color top.</value>
        [Description("Gets or sets the top color of the elapsed")]
        [Category("ColorSlider")]
        public Color ElapsedPenColorTop
        {
            get { return _elapsedPenColorTop; }
            set
            {
                _elapsedPenColorTop = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The elapsed pen color bottom
        /// </summary>
        private Color _elapsedPenColorBottom = Color.FromArgb(99, 130, 208);   // bleu très clair
        /// <summary>
        /// Gets or sets the bottom color of the elapsed
        /// </summary>
        /// <value>The elapsed pen color bottom.</value>
        [Description("Gets or sets the bottom color of the elapsed")]
        [Category("ColorSlider")]
        public Color ElapsedPenColorBottom
        {
            get { return _elapsedPenColorBottom; }
            set
            {
                _elapsedPenColorBottom = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The bar pen color top
        /// </summary>
        private Color _barPenColorTop = Color.FromArgb(55, 60, 74);     // gris foncé
        /// <summary>
        /// Gets or sets the top color of the bar
        /// </summary>
        /// <value>The bar pen color top.</value>
        [Description("Gets or sets the top color of the bar")]
        [Category("ColorSlider")]
        public Color BarPenColorTop
        {
            get { return _barPenColorTop; }
            set
            {
                _barPenColorTop = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar pen color bottom
        /// </summary>
        private Color _barPenColorBottom = Color.FromArgb(87, 94, 110);    // gris moyen
        /// <summary>
        /// Gets or sets the bottom color of bar
        /// </summary>
        /// <value>The bar pen color bottom.</value>
        [Description("Gets or sets the bottom color of the bar")]
        [Category("ColorSlider")]
        public Color BarPenColorBottom
        {
            get { return _barPenColorBottom; }
            set
            {
                _barPenColorBottom = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The elapsed inner color
        /// </summary>
        private Color _elapsedInnerColor = Color.FromArgb(21, 56, 152);
        /// <summary>
        /// Gets or sets the inner color of the elapsed.
        /// </summary>
        /// <value>The inner color of the elapsed.</value>
        [Description("Set Slider's elapsed part inner color")]
        [Category("ColorSlider")]
        public Color ElapsedInnerColor
        {
            get { return _elapsedInnerColor; }
            set
            {
                _elapsedInnerColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The tick color
        /// </summary>
        private Color _tickColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the graduations
        /// </summary>
        /// <value>The color of the tick.</value>
        [Description("Color of graduations")]
        [Category("ColorSlider")]
        public Color TickColor
        {
            get { return _tickColor; }
            set
            {
                if (value != _tickColor)
                {
                    _tickColor = value;
                    Invalidate();
                }
            }
        }

        #endregion


        #region divisions

        /// <summary>
        /// The tick style
        /// </summary>
        private System.Windows.Forms.TickStyle _tickStyle = System.Windows.Forms.TickStyle.TopLeft;
        /// <summary>
        /// Gets or sets where to display the ticks (None, both top-left, bottom-right)
        /// </summary>
        /// <value>The tick style.</value>
        [Description("Gets or sets where to display the ticks")]
        [Category("ColorSlider")]
        [DefaultValue(System.Windows.Forms.TickStyle.TopLeft)]
        public System.Windows.Forms.TickStyle TickStyle
        {
            get { return _tickStyle; }
            set
            {
                _tickStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The scale divisions
        /// </summary>
        private int _scaleDivisions = 10;
        /// <summary>
        /// How many divisions of maximum?
        /// </summary>
        /// <value>The scale divisions.</value>
        [Description("Set the number of intervals between minimum and maximum")]
        [Category("ColorSlider")]
        public int ScaleDivisions
        {
            get { return _scaleDivisions; }
            set
            {
                if (value > 0)
                {
                    _scaleDivisions = value;

                }
                //else throw new ArgumentOutOfRangeException("TickFreqency must be > 0 and < Maximum");

                Invalidate();

            }
        }

        /// <summary>
        /// The scale sub divisions
        /// </summary>
        private int _scaleSubDivisions = 5;
        /// <summary>
        /// How many subdivisions for each division
        /// </summary>
        /// <value>The scale sub divisions.</value>
        [Description("Set the number of subdivisions between main divisions of graduation.")]
        [Category("ColorSlider")]
        public int ScaleSubDivisions
        {
            get { return _scaleSubDivisions; }
            set
            {
                if (value > 0 && _scaleDivisions > 0 && (_maximum - _minimum) / ((value + 1) * _scaleDivisions) > 0)
                {
                    _scaleSubDivisions = value;

                }
                //else throw new ArgumentOutOfRangeException("TickSubFreqency must be > 0 and < TickFrequency");

                Invalidate();

            }
        }

        /// <summary>
        /// The show small scale
        /// </summary>
        private bool _showSmallScale = false;
        /// <summary>
        /// Shows Small Scale marking.
        /// </summary>
        /// <value><c>true</c> if [show small scale]; otherwise, <c>false</c>.</value>
        [Description("Show or hide subdivisions of graduations")]
        [Category("ColorSlider")]
        public bool ShowSmallScale
        {
            get { return _showSmallScale; }
            set
            {

                if (value == true)
                {
                    if (_scaleDivisions > 0 && _scaleSubDivisions > 0 && (_maximum - _minimum) / ((_scaleSubDivisions + 1) * _scaleDivisions) > 0)
                    {
                        _showSmallScale = value;
                        Invalidate();
                    }
                    else
                    {
                        _showSmallScale = false;
                    }
                }
                else
                {
                    _showSmallScale = value;
                    // need to redraw 
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// The show divisions text
        /// </summary>
        private bool _showDivisionsText = true;
        /// <summary>
        /// Shows Small Scale marking.
        /// </summary>
        /// <value><c>true</c> if [show divisions text]; otherwise, <c>false</c>.</value>
        [Description("Show or hide text value of graduations")]
        [Category("ColorSlider")]
        public bool ShowDivisionsText
        {
            get { return _showDivisionsText; }
            set
            {
                _showDivisionsText = value;
                Invalidate();
            }
        }

        #endregion

        #endregion


        #region Color schemas

        //define own color schemas
        /// <summary>
        /// a color schema
        /// </summary>
        private Color[,] aColorSchema = new Color[,]
            {
                {
                    Color.White,                    // thumb outer
                    Color.FromArgb(21, 56, 152),    // thumb inner
                    Color.FromArgb(21, 56, 152),    // thumb pen color
                    
                    Color.Black,                    // bar inner    

                    Color.FromArgb(95, 140, 180),     // slider elapsed top                   
                    Color.FromArgb(99, 130, 208),     // slider elapsed bottom                    

                    Color.FromArgb(55, 60, 74),     // slider remain top                    
                    Color.FromArgb(87, 94, 110),     // slider remain bottom
                                         
                    Color.FromArgb(21, 56, 152)     // elapsed interieur centre
                },
                {
                    Color.White,                    // thumb outer
                    Color.Red,    // thumb inner
                    Color.Red,    // thumb pen color
                    
                    Color.Black,                    // bar inner    

                    Color.LightCoral,     // slider elapsed top                   
                    Color.Salmon,     // slider elapsed bottom
                    

                    Color.FromArgb(55, 60, 74),     // slider remain top                    
                    Color.FromArgb(87, 94, 110),     // slider remain bottom
                                         
                    Color.Red     // gauche interieur centre
                },
                {
                    Color.White,                    // thumb outer
                    Color.Green,    // thumb inner
                    Color.Green,    // thumb pen color
                    
                    Color.Black,                    // bar inner    

                    Color.SpringGreen,     // slider elapsed top                   
                    Color.LightGreen,     // slider elapsed bottom
                    

                    Color.FromArgb(55, 60, 74),     // slider remain top                    
                    Color.FromArgb(87, 94, 110),     // slider remain bottom
                                         
                    Color.Green     // gauche interieur centre
                },
            };

        /// <summary>
        /// Enum representing the color schemes for the control
        /// </summary>
        public enum ColorSchemas
        {
            /// <summary>
            /// The blue colors
            /// </summary>
            BlueColors,
            /// <summary>
            /// The red colors
            /// </summary>
            RedColors,
            /// <summary>
            /// The green colors
            /// </summary>
            GreenColors
        }

        /// <summary>
        /// The color schema
        /// </summary>
        private ColorSchemas colorSchema = ColorSchemas.BlueColors;

        /// <summary>
        /// Sets color schema. Color generalization / fast color changing. Has no effect when slider colors are changed manually after schema was applied.
        /// </summary>
        /// <value>New color schema value</value>
        [Description("Set Slider color schema. Has no effect when slider colors are changed manually after schema was applied.")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(ColorSchemas), "BlueColors")]
        public ColorSchemas ColorSchema
        {
            get { return colorSchema; }
            set
            {
                colorSchema = value;
                byte sn = (byte)value;
                _thumbOuterColor = aColorSchema[sn, 0];
                _thumbInnerColor = aColorSchema[sn, 1];
                _thumbPenColor = aColorSchema[sn, 2];

                _barInnerColor = aColorSchema[sn, 3];

                _elapsedPenColorTop = aColorSchema[sn, 4];
                _elapsedPenColorBottom = aColorSchema[sn, 5];

                _barPenColorTop = aColorSchema[sn, 6];
                _barPenColorBottom = aColorSchema[sn, 7];

                _elapsedInnerColor = aColorSchema[sn, 8];

                Invalidate();
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSlider" /> class.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="value">The current value.</param>
        public ZeroitOdameTrackBar(int min, int max, int value)
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.Selectable |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.UserMouse |
                     ControlStyles.UserPaint, true);

            // Default backcolor
            //BackColor = Color.FromArgb(70, 77, 95);



            Minimum = min;
            Maximum = max;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSlider" /> class.
        /// </summary>
        public ZeroitOdameTrackBar() : this(0, 100, 30) { }

        #endregion

        #region Paint

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Enabled)
            {
                Color[] desaturatedColors = DesaturateColors(_thumbOuterColor, _thumbInnerColor, _thumbPenColor,
                                                             _barInnerColor,
                                                             _elapsedPenColorTop, _elapsedPenColorBottom,
                                                             _barPenColorTop, _barPenColorBottom,
                                                             _elapsedInnerColor);
                DrawColorSlider(e,
                                    desaturatedColors[0], desaturatedColors[1], desaturatedColors[2],
                                    desaturatedColors[3],
                                    desaturatedColors[4], desaturatedColors[5],
                                    desaturatedColors[6], desaturatedColors[7],
                                    desaturatedColors[8]);
            }
            else
            {
                if (_mouseEffects && mouseInRegion)
                {
                    Color[] lightenedColors = LightenColors(_thumbOuterColor, _thumbInnerColor, _thumbPenColor,
                                                            _barInnerColor,
                                                            _elapsedPenColorTop, _elapsedPenColorBottom,
                                                            _barPenColorTop, _barPenColorBottom,
                                                            _elapsedInnerColor);
                    DrawColorSlider(e,
                        lightenedColors[0], lightenedColors[1], lightenedColors[2],
                        lightenedColors[3],
                        lightenedColors[4], lightenedColors[5],
                        lightenedColors[6], lightenedColors[7],
                        lightenedColors[8]);
                }
                else
                {
                    DrawColorSlider(e,
                                    _thumbOuterColor, _thumbInnerColor, _thumbPenColor,
                                    _barInnerColor,
                                    _elapsedPenColorTop, _elapsedPenColorBottom,
                                    _barPenColorTop, _barPenColorBottom,
                                    _elapsedInnerColor);
                }
            }
        }

        /// <summary>
        /// Draws the colorslider control using passed colors.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        /// <param name="thumbOuterColorPaint">The thumb outer color paint.</param>
        /// <param name="thumbInnerColorPaint">The thumb inner color paint.</param>
        /// <param name="thumbPenColorPaint">The thumb pen color paint.</param>
        /// <param name="barInnerColorPaint">The bar inner color paint.</param>
        /// <param name="ElapsedTopPenColorPaint">The elapsed top pen color paint.</param>
        /// <param name="ElapsedBottomPenColorPaint">The elapsed bottom pen color paint.</param>
        /// <param name="barTopPenColorPaint">The bar top pen color paint.</param>
        /// <param name="barBottomPenColorPaint">The bar bottom pen color paint.</param>
        /// <param name="elapsedInnerColorPaint">The elapsed inner color paint.</param>
        private void DrawColorSlider(PaintEventArgs e,
            Color thumbOuterColorPaint, Color thumbInnerColorPaint, Color thumbPenColorPaint,
            Color barInnerColorPaint,
            Color ElapsedTopPenColorPaint, Color ElapsedBottomPenColorPaint,
            Color barTopPenColorPaint, Color barBottomPenColorPaint,
            Color elapsedInnerColorPaint)
        {
            try
            {
                //set up thumbRect approprietly
                if (_barOrientation == Orientation.Horizontal)
                {
                    #region horizontal
                    if (_thumbImage != null)
                    {
                        int TrackX = (((_trackerValue - _minimum) * (ClientRectangle.Width - _thumbImage.Width)) / (_maximum - _minimum));
                        thumbRect = new Rectangle(TrackX, ClientRectangle.Height / 2 - _thumbImage.Height / 2, _thumbImage.Width, _thumbImage.Height);
                    }
                    else
                    {
                        int TrackX = (((_trackerValue - _minimum) * (ClientRectangle.Width - _thumbSize.Width)) / (_maximum - _minimum));
                        //thumbRect = new Rectangle(TrackX, 1, _thumbSize - 1, ClientRectangle.Height - 3);
                        thumbRect = new Rectangle(TrackX, ClientRectangle.Y + ClientRectangle.Height / 2 - _thumbSize.Height / 2, _thumbSize.Width, _thumbSize.Height);
                    }
                    #endregion
                }
                else
                {
                    #region vertical
                    if (_thumbImage != null)
                    {
                        int TrackY = (((_maximum - (_trackerValue - _minimum)) * (ClientRectangle.Height - _thumbImage.Height)) / (_maximum - _minimum));
                        thumbRect = new Rectangle(ClientRectangle.Width / 2 - _thumbImage.Width / 2, TrackY, _thumbImage.Width, _thumbImage.Height);
                    }
                    else
                    {
                        int TrackY = (((_maximum - (_trackerValue - _minimum)) * (ClientRectangle.Height - _thumbSize.Height)) / (_maximum - _minimum));
                        //thumbRect = new Rectangle(1, TrackY, ClientRectangle.Width - 3, _thumbSize - 1);
                        thumbRect = new Rectangle(ClientRectangle.X + ClientRectangle.Width / 2 - _thumbSize.Width / 2, TrackY, _thumbSize.Width, _thumbSize.Height);
                    }
                    #endregion
                }


                //adjust drawing rects
                barRect = ClientRectangle;
                // TODO : make barRect rectangle smaller than Control rectangle  
                // barRect = new Rectangle(ClientRectangle.X + 5, ClientRectangle.Y + 5, ClientRectangle.Width - 10, ClientRectangle.Height - 10);
                thumbHalfRect = thumbRect;
                LinearGradientMode gradientOrientation;


                if (_barOrientation == Orientation.Horizontal)
                {
                    #region horizontal
                    barRect.Inflate(-1, -barRect.Height / 3);
                    barHalfRect = barRect;
                    barHalfRect.Height /= 2;

                    gradientOrientation = LinearGradientMode.Vertical;


                    thumbHalfRect.Height /= 2;
                    elapsedRect = barRect;
                    elapsedRect.Width = thumbRect.Left + _thumbSize.Width / 2;
                    #endregion
                }
                else
                {
                    #region vertical
                    barRect.Inflate(-barRect.Width / 3, -1);
                    barHalfRect = barRect;
                    barHalfRect.Width /= 2;

                    gradientOrientation = LinearGradientMode.Vertical;

                    thumbHalfRect.Width /= 2;
                    elapsedRect = barRect;
                    elapsedRect.Height = barRect.Height - (thumbRect.Top + ThumbSize.Height / 2);
                    elapsedRect.Y = 1 + thumbRect.Top + ThumbSize.Height / 2;

                    #endregion
                }

                //get thumb shape path 
                GraphicsPath thumbPath;
                if (_thumbCustomShape == null)
                    thumbPath = CreateRoundRectPath(thumbRect, _thumbRoundRectSize);
                else
                {
                    thumbPath = _thumbCustomShape;
                    Matrix m = new Matrix();
                    m.Translate(thumbRect.Left - thumbPath.GetBounds().Left, thumbRect.Top - thumbPath.GetBounds().Top);
                    thumbPath.Transform(m);
                }


                //draw bar

                #region draw inner bar

                // inner bar is a single line 
                // draw the line on the whole lenght of the control
                if (_barOrientation == Orientation.Horizontal)
                {
                    e.Graphics.DrawLine(new Pen(barInnerColorPaint, 1f), barRect.X, barRect.Y + barRect.Height / 2, barRect.X + barRect.Width, barRect.Y + barRect.Height / 2);
                }
                else
                {
                    e.Graphics.DrawLine(new Pen(barInnerColorPaint, 1f), barRect.X + barRect.Width / 2, barRect.Y, barRect.X + barRect.Width / 2, barRect.Y + barRect.Height);
                }
                #endregion


                #region draw elapsed bar

                //draw elapsed inner bar (single line too)                               
                if (_barOrientation == Orientation.Horizontal)
                {
                    e.Graphics.DrawLine(new Pen(elapsedInnerColorPaint, 1f), barRect.X, barRect.Y + barRect.Height / 2, barRect.X + elapsedRect.Width, barRect.Y + barRect.Height / 2);
                }
                else
                {
                    e.Graphics.DrawLine(new Pen(elapsedInnerColorPaint, 1f), barRect.X + barRect.Width / 2, barRect.Y + (barRect.Height - elapsedRect.Height), barRect.X + barRect.Width / 2, barRect.Y + barRect.Height);
                }

                #endregion draw elapsed bar


                #region draw external contours

                //draw external bar band 
                // 2 lines: top and bottom
                if (_barOrientation == Orientation.Horizontal)
                {
                    #region horizontal
                    // Elapsed top
                    e.Graphics.DrawLine(new Pen(ElapsedTopPenColorPaint, 1f), barRect.X, barRect.Y - 1 + barRect.Height / 2, barRect.X + elapsedRect.Width, barRect.Y - 1 + barRect.Height / 2);
                    // Elapsed bottom
                    e.Graphics.DrawLine(new Pen(ElapsedBottomPenColorPaint, 1f), barRect.X, barRect.Y + 1 + barRect.Height / 2, barRect.X + elapsedRect.Width, barRect.Y + 1 + barRect.Height / 2);


                    // Remain top
                    e.Graphics.DrawLine(new Pen(barTopPenColorPaint, 1f), barRect.X + elapsedRect.Width, barRect.Y - 1 + barRect.Height / 2, barRect.X + barRect.Width, barRect.Y - 1 + barRect.Height / 2);
                    // Remain bottom
                    e.Graphics.DrawLine(new Pen(barBottomPenColorPaint, 1f), barRect.X + elapsedRect.Width, barRect.Y + 1 + barRect.Height / 2, barRect.X + barRect.Width, barRect.Y + 1 + barRect.Height / 2);


                    // Left vertical (dark)
                    e.Graphics.DrawLine(new Pen(barTopPenColorPaint, 1f), barRect.X, barRect.Y - 1 + barRect.Height / 2, barRect.X, barRect.Y + barRect.Height / 2 + 1);

                    // Right vertical (light)                        
                    e.Graphics.DrawLine(new Pen(barBottomPenColorPaint, 1f), barRect.X + barRect.Width, barRect.Y - 1 + barRect.Height / 2, barRect.X + barRect.Width, barRect.Y + 1 + barRect.Height / 2);
                    #endregion
                }
                else
                {
                    #region vertical
                    // Elapsed top
                    e.Graphics.DrawLine(new Pen(ElapsedTopPenColorPaint, 1f), barRect.X - 1 + barRect.Width / 2, barRect.Y + (barRect.Height - elapsedRect.Height), barRect.X - 1 + barRect.Width / 2, barRect.Y + barRect.Height);

                    // Elapsed bottom
                    e.Graphics.DrawLine(new Pen(ElapsedBottomPenColorPaint, 1f), barRect.X + 1 + barRect.Width / 2, barRect.Y + (barRect.Height - elapsedRect.Height), barRect.X + 1 + barRect.Width / 2, barRect.Y + barRect.Height);


                    // Remain top
                    e.Graphics.DrawLine(new Pen(barTopPenColorPaint, 1f), barRect.X - 1 + barRect.Width / 2, barRect.Y, barRect.X - 1 + barRect.Width / 2, barRect.Y + barRect.Height - elapsedRect.Height);


                    // Remain bottom
                    e.Graphics.DrawLine(new Pen(barBottomPenColorPaint, 1f), barRect.X + 1 + barRect.Width / 2, barRect.Y, barRect.X + 1 + barRect.Width / 2, barRect.Y + barRect.Height - elapsedRect.Height);


                    // top horizontal (dark) 
                    e.Graphics.DrawLine(new Pen(barTopPenColorPaint, 1f), barRect.X - 1 + barRect.Width / 2, barRect.Y, barRect.X + 1 + barRect.Width / 2, barRect.Y);

                    // bottom horizontal (light)
                    e.Graphics.DrawLine(new Pen(barBottomPenColorPaint, 1f), barRect.X - 1 + barRect.Width / 2, barRect.Y + barRect.Height, barRect.X + 1 + barRect.Width / 2, barRect.Y + barRect.Height);
                    #endregion

                }

                #endregion draw contours

                #region draw thumb

                //draw thumb
                Color newthumbOuterColorPaint = thumbOuterColorPaint, newthumbInnerColorPaint = thumbInnerColorPaint;
                if (Capture && _drawSemitransparentThumb)
                {
                    newthumbOuterColorPaint = Color.FromArgb(175, thumbOuterColorPaint);
                    newthumbInnerColorPaint = Color.FromArgb(175, thumbInnerColorPaint);
                }

                LinearGradientBrush lgbThumb;
                if (_barOrientation == Orientation.Horizontal)
                {
                    lgbThumb = new LinearGradientBrush(thumbRect, newthumbOuterColorPaint, newthumbInnerColorPaint, gradientOrientation);
                }
                else
                {
                    lgbThumb = new LinearGradientBrush(thumbHalfRect, newthumbOuterColorPaint, newthumbInnerColorPaint, gradientOrientation);
                }
                using (lgbThumb)
                {
                    lgbThumb.WrapMode = WrapMode.TileFlipXY;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(lgbThumb, thumbPath);

                    //draw thumb band
                    Color newThumbPenColor = thumbPenColorPaint;

                    if (_mouseEffects && (Capture || mouseInThumbRegion))
                        newThumbPenColor = ControlPaint.Dark(newThumbPenColor);
                    using (Pen thumbPen = new Pen(newThumbPenColor))
                    {

                        if (_thumbImage != null)
                        {
                            Bitmap bmp = new Bitmap(_thumbImage);
                            bmp.MakeTransparent(Color.FromArgb(255, 0, 255));
                            Rectangle srceRect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                            e.Graphics.DrawImage(bmp, thumbRect, srceRect, GraphicsUnit.Pixel);
                            bmp.Dispose();

                        }
                        else
                        {
                            e.Graphics.DrawPath(thumbPen, thumbPath);
                        }
                    }

                }
                #endregion draw thumb


                #region draw focusing rectangle
                //draw focusing rectangle
                if (Focused & _drawFocusRectangle)
                    using (Pen p = new Pen(Color.FromArgb(200, ElapsedTopPenColorPaint)))
                    {
                        p.DashStyle = DashStyle.Dot;
                        Rectangle r = ClientRectangle;
                        r.Width -= 2;
                        r.Height--;
                        r.X++;

                        using (GraphicsPath gpBorder = CreateRoundRectPath(r, _borderRoundRectSize))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawPath(p, gpBorder);
                        }
                    }
                #endregion draw focusing rectangle


                #region draw ticks

                // Draw the ticks (main divisions, subdivisions and text)
                if (_tickStyle != System.Windows.Forms.TickStyle.None)
                {
                    int x1, x2, y1, y2 = 0;
                    int nbticks = 1 + _scaleDivisions * (_scaleSubDivisions + 1);
                    int interval = 0;
                    int start = 0;
                    int W = 0;
                    float rulerValue = 0;

                    // Calculate width W to draw graduations 
                    // Remove the width of the thumb (half thumb at each end)
                    // in order that when the thumb is at minimum position or maximum position, 
                    // the graduation coincide with the middle of the thumb  
                    if (_barOrientation == Orientation.Horizontal)
                    {
                        start = thumbRect.Width / 2;
                        W = barRect.Width - thumbRect.Width;
                        rulerValue = (float)_minimum;
                    }
                    else
                    {
                        start = thumbRect.Height / 2;
                        W = barRect.Height - thumbRect.Height;
                        rulerValue = (float)_maximum;
                    }

                    // pen for ticks
                    // TODO: color for subdivision different?
                    Pen penTickL = new Pen(_tickColor, 1f);
                    Pen penTickS = new Pen(_tickColor, 1f);
                    int idx = 0;
                    int scaleL = 5;     // division lenght
                    int scaleS = 3;     // subdivision length    


                    // strings graduations
                    // TODO: color for Text different?
                    float tx = 0;
                    float ty = 0;
                    float fSize = (float)(6F);

                    int startDiv = 0;

                    Color _scaleColor = Color.White;
                    SolidBrush br = new SolidBrush(ForeColor);

                    // Caluculate max size of text 
                    String str = String.Format("{0,0:D}", _maximum);
                    Font font = new Font(this.Font.FontFamily, fSize);
                    SizeF maxsize = e.Graphics.MeasureString(str, font);


                    float lineLeftX, lineRightX = 0;
                    lineLeftX = ClientRectangle.X + maxsize.Width / 2;
                    lineRightX = ClientRectangle.X + ClientRectangle.Width - maxsize.Width / 2;


                    for (int i = 0; i <= _scaleDivisions; i++)
                    {
                        // Calculate current text size
                        double val = Math.Round(rulerValue);
                        str = String.Format("{0,0:D}", (int)val);
                        SizeF size = e.Graphics.MeasureString(str, font);

                        // HORIZONTAL
                        if (_barOrientation == Orientation.Horizontal)
                        {
                            #region horizontal

                            // Draw string graduations
                            if (_showDivisionsText)
                            {
                                if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                {
                                    tx = (start + barRect.X + interval) - (float)(size.Width * 0.5);
                                    ty = ClientRectangle.Y;
                                    e.Graphics.DrawString(str, font, br, tx, ty);
                                }
                                if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                {
                                    tx = (start + barRect.X + interval) - (float)(size.Width * 0.5);
                                    ty = ClientRectangle.Y + ClientRectangle.Height - (size.Height) + 3;
                                    e.Graphics.DrawString(str, font, br, tx, ty);
                                }

                                startDiv = (int)size.Height;
                            }



                            // draw main ticks                           
                            if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                            {
                                x1 = start + barRect.X + interval;
                                y1 = ClientRectangle.Y + startDiv;
                                x2 = start + barRect.X + interval;
                                y2 = ClientRectangle.Y + startDiv + scaleL;
                                e.Graphics.DrawLine(penTickL, x1, y1, x2, y2);
                            }
                            if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                            {

                                x1 = start + barRect.X + interval;
                                y1 = ClientRectangle.Y + ClientRectangle.Height - startDiv;
                                x2 = start + barRect.X + interval;
                                y2 = ClientRectangle.Y + ClientRectangle.Height - scaleL - startDiv;

                                e.Graphics.DrawLine(penTickL, x1, y1, x2, y2);
                            }


                            rulerValue += (float)((_maximum - _minimum) / (_scaleDivisions));

                            // Draw subdivisions
                            if (i < _scaleDivisions)
                            {
                                for (int j = 0; j <= _scaleSubDivisions; j++)
                                {
                                    idx++;
                                    interval = idx * W / (nbticks - 1);

                                    if (_showSmallScale)
                                    {
                                        // Horizontal                            
                                        if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                        {
                                            x1 = start + barRect.X + interval;
                                            y1 = ClientRectangle.Y + startDiv;
                                            x2 = start + barRect.X + interval;
                                            y2 = ClientRectangle.Y + startDiv + scaleS;
                                            e.Graphics.DrawLine(penTickS, x1, y1, x2, y2);
                                        }
                                        if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                        {
                                            x1 = start + barRect.X + interval;
                                            y1 = ClientRectangle.Y + ClientRectangle.Height - startDiv;
                                            x2 = start + barRect.X + interval;
                                            y2 = ClientRectangle.Y + ClientRectangle.Height - scaleS - startDiv;

                                            e.Graphics.DrawLine(penTickS, x1, y1, x2, y2);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region vertical

                            // Draw string graduations
                            if (_showDivisionsText)
                            {
                                if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                {
                                    tx = lineLeftX - size.Width / 2;
                                    ty = start + barRect.Y + interval - (float)(size.Height * 0.5);
                                    e.Graphics.DrawString(str, font, br, tx, ty);
                                }
                                if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                {
                                    tx = lineRightX - size.Width / 2;
                                    ty = start + barRect.Y + interval - (float)(size.Height * 0.5);
                                    e.Graphics.DrawString(str, font, br, tx, ty);
                                }

                                startDiv = (int)maxsize.Width + 3;
                            }


                            // draw main ticks                            
                            if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                            {
                                x1 = ClientRectangle.X + startDiv;
                                y1 = start + barRect.Y + interval;
                                x2 = ClientRectangle.X + scaleL + startDiv;
                                y2 = start + barRect.Y + interval;
                                e.Graphics.DrawLine(penTickL, x1, y1, x2, y2);
                            }
                            if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                            {
                                x1 = ClientRectangle.X + ClientRectangle.Width - startDiv;
                                y1 = start + barRect.Y + interval;
                                x2 = ClientRectangle.X + ClientRectangle.Width - scaleL - startDiv;
                                y2 = start + barRect.Y + interval;
                                e.Graphics.DrawLine(penTickL, x1, y1, x2, y2);
                            }

                            rulerValue -= (float)((_maximum - _minimum) / (_scaleDivisions));

                            // draw subdivisions
                            if (i < _scaleDivisions)
                            {
                                for (int j = 0; j <= _scaleSubDivisions; j++)
                                {
                                    idx++;
                                    interval = idx * W / (nbticks - 1);

                                    if (_showSmallScale)
                                    {
                                        if (_tickStyle == System.Windows.Forms.TickStyle.TopLeft || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                        {
                                            x1 = ClientRectangle.X + startDiv;
                                            y1 = start + barRect.Y + interval;
                                            x2 = ClientRectangle.X + scaleS + startDiv;
                                            y2 = start + barRect.Y + interval;
                                            e.Graphics.DrawLine(penTickS, x1, y1, x2, y2);
                                        }
                                        if (_tickStyle == System.Windows.Forms.TickStyle.BottomRight || _tickStyle == System.Windows.Forms.TickStyle.Both)
                                        {
                                            x1 = ClientRectangle.X + ClientRectangle.Width - startDiv;
                                            y1 = start + barRect.Y + interval;
                                            x2 = ClientRectangle.X + ClientRectangle.Width - scaleS - startDiv;
                                            y2 = start + barRect.Y + interval;
                                            e.Graphics.DrawLine(penTickS, x1, y1, x2, y2);
                                        }
                                    }
                                }
                            }

                            #endregion
                        }



                    }
                }
                #endregion


            }
            catch (Exception Err)
            {
                Console.WriteLine("DrawBackGround Error in " + Name + ":" + Err.Message);
            }
            finally
            {
            }
        }

        #endregion

        #region Overided events

        /// <summary>
        /// The mouse in region
        /// </summary>
        private bool mouseInRegion = false;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseInRegion = true;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseInRegion = false;
            mouseInThumbRegion = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = true;
                if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, _trackerValue));
                if (ValueChanged != null) ValueChanged(this, new EventArgs());
                OnMouseMove(e);
            }
        }

        /// <summary>
        /// The mouse in thumb region
        /// </summary>
        private bool mouseInThumbRegion = false;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mouseInThumbRegion = IsPointInRect(e.Location, thumbRect);
            if (Capture & e.Button == MouseButtons.Left)
            {
                ScrollEventType set = ScrollEventType.ThumbPosition;
                Point pt = e.Location;
                int p = _barOrientation == Orientation.Horizontal ? pt.X : pt.Y;
                int margin = _thumbSize.Height >> 1;
                p -= margin;
                float coef = (float)(_maximum - _minimum) /
                             (float)
                             ((_barOrientation == Orientation.Horizontal ? ClientSize.Width : ClientSize.Height) - 2 * margin);


                _trackerValue = _barOrientation == Orientation.Horizontal ? (int)(p * coef + _minimum) : (_maximum - (int)(p * coef + _minimum));


                if (_trackerValue <= _minimum)
                {
                    _trackerValue = _minimum;
                    set = ScrollEventType.First;
                }
                else if (_trackerValue >= _maximum)
                {
                    _trackerValue = _maximum;
                    set = ScrollEventType.Last;
                }

                if (Scroll != null) Scroll(this, new ScrollEventArgs(set, _trackerValue));
                if (ValueChanged != null) ValueChanged(this, new EventArgs());
            }
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Capture = false;
            mouseInThumbRegion = IsPointInRect(e.Location, thumbRect);
            if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, _trackerValue));
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (mouseInRegion)
            {
                int v = e.Delta / 120 * (_maximum - _minimum) / _mouseWheelBarPartitions;
                SetProperValue(Value + v);

                // Avoid to send MouseWheel event to the parent container
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Left:
                    SetProperValue(Value - (int)_smallChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, Value));
                    break;
                case Keys.Up:
                case Keys.Right:
                    SetProperValue(Value + (int)_smallChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, Value));
                    break;
                case Keys.Home:
                    Value = _minimum;
                    break;
                case Keys.End:
                    Value = _maximum;
                    break;
                case Keys.PageDown:
                    SetProperValue(Value - (int)_largeChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, Value));
                    break;
                case Keys.PageUp:
                    SetProperValue(Value + (int)_largeChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, Value));
                    break;
            }
            if (Scroll != null && Value == _minimum) Scroll(this, new ScrollEventArgs(ScrollEventType.First, Value));
            if (Scroll != null && Value == _maximum) Scroll(this, new ScrollEventArgs(ScrollEventType.Last, Value));
            Point pt = PointToClient(Cursor.Position);
            OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, pt.X, pt.Y, 0));
        }

        /// <summary>
        /// Processes a dialog key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
        /// <returns>true if the key was processed by the control; otherwise, false.</returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab | ModifierKeys == Keys.Shift)
                return base.ProcessDialogKey(keyData);
            else
            {
                OnKeyDown(new KeyEventArgs(keyData));
                return true;
            }
        }

        #endregion

        #region Help routines

        /// <summary>
        /// Creates the round rect path.
        /// </summary>
        /// <param name="rect">The rectangle on which graphics path will be spanned.</param>
        /// <param name="size">The size of rounded rectangle edges.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreateRoundRectPath(Rectangle rect, Size size)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(rect.Left + size.Width / 2, rect.Top, rect.Right - size.Width / 2, rect.Top);
            gp.AddArc(rect.Right - size.Width, rect.Top, size.Width, size.Height, 270, 90);

            gp.AddLine(rect.Right, rect.Top + size.Height / 2, rect.Right, rect.Bottom - size.Width / 2);
            gp.AddArc(rect.Right - size.Width, rect.Bottom - size.Height, size.Width, size.Height, 0, 90);

            gp.AddLine(rect.Right - size.Width / 2, rect.Bottom, rect.Left + size.Width / 2, rect.Bottom);
            gp.AddArc(rect.Left, rect.Bottom - size.Height, size.Width, size.Height, 90, 90);

            gp.AddLine(rect.Left, rect.Bottom - size.Height / 2, rect.Left, rect.Top + size.Height / 2);
            gp.AddArc(rect.Left, rect.Top, size.Width, size.Height, 180, 90);
            return gp;
        }

        /// <summary>
        /// Desaturates colors from given array.
        /// </summary>
        /// <param name="colorsToDesaturate">The colors to be desaturated.</param>
        /// <returns>Color[].</returns>
        public static Color[] DesaturateColors(params Color[] colorsToDesaturate)
        {
            Color[] colorsToReturn = new Color[colorsToDesaturate.Length];
            for (int i = 0; i < colorsToDesaturate.Length; i++)
            {
                //use NTSC weighted avarage
                int gray =
                    (int)(colorsToDesaturate[i].R * 0.3 + colorsToDesaturate[i].G * 0.6 + colorsToDesaturate[i].B * 0.1);
                colorsToReturn[i] = Color.FromArgb(-0x010101 * (255 - gray) - 1);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Lightens colors from given array.
        /// </summary>
        /// <param name="colorsToLighten">The colors to lighten.</param>
        /// <returns>Color[].</returns>
        public static Color[] LightenColors(params Color[] colorsToLighten)
        {
            Color[] colorsToReturn = new Color[colorsToLighten.Length];
            for (int i = 0; i < colorsToLighten.Length; i++)
            {
                colorsToReturn[i] = ControlPaint.Light(colorsToLighten[i]);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < _minimum) Value = _minimum;
            else if (val > _maximum) Value = _maximum;
            else Value = val;
        }

        /// <summary>
        /// Determines whether rectangle contains given point.
        /// </summary>
        /// <param name="pt">The point to test.</param>
        /// <param name="rect">The base rectangle.</param>
        /// <returns><c>true</c> if rectangle contains given point; otherwise, <c>false</c>.</returns>
        private static bool IsPointInRect(Point pt, Rectangle rect)
        {
            if (pt.X > rect.Left & pt.X < rect.Right & pt.Y > rect.Top & pt.Y < rect.Bottom)
                return true;
            else return false;
        }

        #endregion
    }


    #endregion

    #region Designer Generated Code

    partial class ZeroitOdameTrackBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ColorSlider
            // 
            this.Size = new System.Drawing.Size(200, 48);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitOdameSliderDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitOdameSliderDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitOdameSliderDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitOdameSliderSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitOdameSliderSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitOdameSliderSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOdameTrackBar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOdameSliderSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitOdameSliderSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOdameTrackBar;

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
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the thumb.
        /// </summary>
        /// <value>The size of the thumb.</value>
        public Size ThumbSize
        {
            get
            {
                return colUserControl.ThumbSize;
            }
            set
            {
                GetPropertyByName("ThumbSize").SetValue(colUserControl, value);
            }
        }

        //public GraphicsPath ThumbCustomShape
        //{
        //    get
        //    {
        //        return colUserControl.ThumbCustomShape;
        //    }
        //    set
        //    {
        //        GetPropertyByName("ThumbCustomShape").SetValue(colUserControl, value);
        //    }
        //}

        /// <summary>
        /// Gets or sets the size of the thumb round rect.
        /// </summary>
        /// <value>The size of the thumb round rect.</value>
        public Size ThumbRoundRectSize
        {
            get
            {
                return colUserControl.ThumbRoundRectSize;
            }
            set
            {
                GetPropertyByName("ThumbRoundRectSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the border round rect.
        /// </summary>
        /// <value>The size of the border round rect.</value>
        public Size BorderRoundRectSize
        {
            get
            {
                return colUserControl.BorderRoundRectSize;
            }
            set
            {
                GetPropertyByName("BorderRoundRectSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw semitransparent thumb].
        /// </summary>
        /// <value><c>true</c> if [draw semitransparent thumb]; otherwise, <c>false</c>.</value>
        public bool DrawSemitransparentThumb
        {
            get
            {
                return colUserControl.DrawSemitransparentThumb;
            }
            set
            {
                GetPropertyByName("DrawSemitransparentThumb").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the thumb image.
        /// </summary>
        /// <value>The thumb image.</value>
        public Image ThumbImage
        {
            get
            {
                return colUserControl.ThumbImage;
            }
            set
            {
                GetPropertyByName("ThumbImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw focus rectangle].
        /// </summary>
        /// <value><c>true</c> if [draw focus rectangle]; otherwise, <c>false</c>.</value>
        public bool DrawFocusRectangle
        {
            get
            {
                return colUserControl.DrawFocusRectangle;
            }
            set
            {
                GetPropertyByName("DrawFocusRectangle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [mouse effects].
        /// </summary>
        /// <value><c>true</c> if [mouse effects]; otherwise, <c>false</c>.</value>
        public bool MouseEffects
        {
            get
            {
                return colUserControl.MouseEffects;
            }
            set
            {
                GetPropertyByName("MouseEffects").SetValue(colUserControl, value);
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
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        public uint SmallChange
        {
            get
            {
                return colUserControl.SmallChange;
            }
            set
            {
                GetPropertyByName("SmallChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        public uint LargeChange
        {
            get
            {
                return colUserControl.LargeChange;
            }
            set
            {
                GetPropertyByName("LargeChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        public int MouseWheelBarPartitions
        {
            get
            {
                return colUserControl.MouseWheelBarPartitions;
            }
            set
            {
                GetPropertyByName("MouseWheelBarPartitions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the thumb outer.
        /// </summary>
        /// <value>The color of the thumb outer.</value>
        public Color ThumbOuterColor
        {
            get
            {
                return colUserControl.ThumbOuterColor;
            }
            set
            {
                GetPropertyByName("ThumbOuterColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the thumb inner.
        /// </summary>
        /// <value>The color of the thumb inner.</value>
        public Color ThumbInnerColor
        {
            get
            {
                return colUserControl.ThumbInnerColor;
            }
            set
            {
                GetPropertyByName("ThumbInnerColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the thumb pen.
        /// </summary>
        /// <value>The color of the thumb pen.</value>
        public Color ThumbPenColor
        {
            get
            {
                return colUserControl.ThumbPenColor;
            }
            set
            {
                GetPropertyByName("ThumbPenColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the bar inner.
        /// </summary>
        /// <value>The color of the bar inner.</value>
        public Color BarInnerColor
        {
            get
            {
                return colUserControl.BarInnerColor;
            }
            set
            {
                GetPropertyByName("BarInnerColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the elapsed pen color top.
        /// </summary>
        /// <value>The elapsed pen color top.</value>
        public Color ElapsedPenColorTop
        {
            get
            {
                return colUserControl.ElapsedPenColorTop;
            }
            set
            {
                GetPropertyByName("ElapsedPenColorTop").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the elapsed pen color bottom.
        /// </summary>
        /// <value>The elapsed pen color bottom.</value>
        public Color ElapsedPenColorBottom
        {
            get
            {
                return colUserControl.ElapsedPenColorBottom;
            }
            set
            {
                GetPropertyByName("ElapsedPenColorBottom").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar pen color top.
        /// </summary>
        /// <value>The bar pen color top.</value>
        public Color BarPenColorTop
        {
            get
            {
                return colUserControl.BarPenColorTop;
            }
            set
            {
                GetPropertyByName("BarPenColorTop").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar pen color bottom.
        /// </summary>
        /// <value>The bar pen color bottom.</value>
        public Color BarPenColorBottom
        {
            get
            {
                return colUserControl.BarPenColorBottom;
            }
            set
            {
                GetPropertyByName("BarPenColorBottom").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the elapsed inner.
        /// </summary>
        /// <value>The color of the elapsed inner.</value>
        public Color ElapsedInnerColor
        {
            get
            {
                return colUserControl.ElapsedInnerColor;
            }
            set
            {
                GetPropertyByName("ElapsedInnerColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor
        {
            get
            {
                return colUserControl.TickColor;
            }
            set
            {
                GetPropertyByName("TickColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick style.
        /// </summary>
        /// <value>The tick style.</value>
        public System.Windows.Forms.TickStyle TickStyle
        {
            get
            {
                return colUserControl.TickStyle;
            }
            set
            {
                GetPropertyByName("TickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale divisions.
        /// </summary>
        /// <value>The scale divisions.</value>
        public int ScaleDivisions
        {
            get
            {
                return colUserControl.ScaleDivisions;
            }
            set
            {
                GetPropertyByName("ScaleDivisions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale sub divisions.
        /// </summary>
        /// <value>The scale sub divisions.</value>
        public int ScaleSubDivisions
        {
            get
            {
                return colUserControl.ScaleSubDivisions;
            }
            set
            {
                GetPropertyByName("ScaleSubDivisions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show small scale].
        /// </summary>
        /// <value><c>true</c> if [show small scale]; otherwise, <c>false</c>.</value>
        public bool ShowSmallScale
        {
            get
            {
                return colUserControl.ShowSmallScale;
            }
            set
            {
                GetPropertyByName("ShowSmallScale").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show divisions text].
        /// </summary>
        /// <value><c>true</c> if [show divisions text]; otherwise, <c>false</c>.</value>
        public bool ShowDivisionsText
        {
            get
            {
                return colUserControl.ShowDivisionsText;
            }
            set
            {
                GetPropertyByName("ShowDivisionsText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color schema.
        /// </summary>
        /// <value>The color schema.</value>
        public Zeroit.Framework.MiscControls.ZeroitOdameTrackBar.ColorSchemas ColorSchema
        {
            get
            {
                return colUserControl.ColorSchema;
            }
            set
            {
                GetPropertyByName("ColorSchema").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("DrawFocusRectangle",
                                 "Draw Focus Rectangle", "Appearance",
                                 "Set to draw focus rectangle."));

            items.Add(new DesignerActionPropertyItem("MouseEffects",
                                 "Mouse Effects", "Appearance",
                                 "Set to enable mouse effects."));

            items.Add(new DesignerActionPropertyItem("ShowSmallScale",
                                 "Show Small Scale", "Appearance",
                                 "Set to show small scale."));

            items.Add(new DesignerActionPropertyItem("ShowDivisionsText",
                                 "Show Divisions Text", "Appearance",
                                 "Set to show divisions text."));

            items.Add(new DesignerActionPropertyItem("DrawSemitransparentThumb",
                                 "Draw Semi transparent Thumb", "Appearance",
                                 "Set to draw semi transparent thumb."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ThumbOuterColor",
                                 "Thumb Outer Color", "Appearance",
                                 "Sets the thumb outer color."));


            items.Add(new DesignerActionPropertyItem("ThumbInnerColor",
                                 "Thumb Inner Color", "Appearance",
                                 "Sets the thumb inner color."));

            items.Add(new DesignerActionPropertyItem("ThumbPenColor",
                                 "Thumb Pen Color", "Appearance",
                                 "Sets the thumb pen color."));

            items.Add(new DesignerActionPropertyItem("BarInnerColor",
                                 "Bar Inner Color", "Appearance",
                                 "Set to draw bar inner color."));

            items.Add(new DesignerActionPropertyItem("ElapsedPenColorTop",
                                 "Elapsed Pen ColorTop", "Appearance",
                                 "Sets the pen color top."));


            items.Add(new DesignerActionPropertyItem("ElapsedPenColorBottom",
                                 "Elapsed Pen Color Bottom", "Appearance",
                                 "Sets the pen color bottom."));

            items.Add(new DesignerActionPropertyItem("ElapsedInnerColor",
                                 "Elapsed Inner Color", "Appearance",
                                 "Sets the elapsed inner color."));

            items.Add(new DesignerActionPropertyItem("TickColor",
                                 "Tick Color", "Appearance",
                                 "Sets the tick color."));

            items.Add(new DesignerActionPropertyItem("ThumbRoundRectSize",
                                 "Thumb Round Rect Size", "Appearance",
                                 "Sets the thumb round rectangle size."));

            items.Add(new DesignerActionPropertyItem("BorderRoundRectSize",
                                 "Border Round Rect Size", "Appearance",
                                 "Sets the border round rectangle size."));

            //items.Add(new DesignerActionPropertyItem("ThumbImage",
            //                     "Thumb Image", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                                 "Orientation", "Appearance",
                                 "Sets the orientation."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));


            //items.Add(new DesignerActionPropertyItem("SmallChange",
            //                     "SmallChange", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("LargeChange",
            //                     "Large Change", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("MouseWheelBarPartitions",
            //                     "Mouse Wheel Bar Partitions", "Appearance",
            //                     "Type few characters to filter Cities."));



            items.Add(new DesignerActionPropertyItem("TickStyle",
                                 "Tick Style", "Appearance",
                                 "Sets the tick style."));

            items.Add(new DesignerActionPropertyItem("ScaleDivisions",
                                 "Scale Divisions", "Appearance",
                                 "Sets the scale divisions."));

            items.Add(new DesignerActionPropertyItem("ScaleSubDivisions",
                                 "Scale Sub Divisions", "Appearance",
                                 "Sets the scale sub divisions."));



            //items.Add(new DesignerActionPropertyItem("ColorSchema",
            //                     "Color Schema", "Appearance",
            //                     "Type few characters to filter Cities."));


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
