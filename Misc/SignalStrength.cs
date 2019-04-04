// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SignalStrength.cs" company="Zeroit Dev Technologies">
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
    #region Signal Strength

    #region Control

    /// <summary>
    /// Enum for representing Signal Strength Layout for <c><see cref="ZeroitSignal" /></c>.
    /// </summary>
    public enum SignalStrengthLayout
    {
        /// <summary>
        /// The left to right
        /// </summary>
        LeftToRight = 0,
        /// <summary>
        /// The right to left
        /// </summary>
        RightToLeft = 1,
        /// <summary>
        /// The bottom to top
        /// </summary>
        BottomToTop = 2,
        /// <summary>
        /// The top to bottom
        /// </summary>
        TopToBottom = 3
    }

    /// <summary>
    /// Enum representing the Signal Strength Background Style for <c><see cref="ZeroitSignal" /></c>.
    /// </summary>
    public enum SignalStrengthBackgroundStyle
    {
        /// <summary>
        /// The normal
        /// </summary>
        Normal,
        /// <summary>
        /// The transparent
        /// </summary>
        Transparent
    }

    /// <summary>
    /// A class collection for rendering a signal control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItemFilter("Silic0re Controls"), ToolboxBitmap("signalimg.bmp")]
    [Designer(typeof(ZeroitSignalDesigner))]
    public partial class ZeroitSignal : UserControl
    {
        #region Fields

        // Bar Properties
        /// <summary>
        /// The number of bars
        /// </summary>
        private int numberOfBars = 5;
        /// <summary>
        /// The bar spacing
        /// </summary>
        private int barSpacing = 2;
        /// <summary>
        /// The small bar height
        /// </summary>
        private int smallBarHeight = 10;
        /// <summary>
        /// The bar step size
        /// </summary>
        private int barStepSize = 20;

        //Bar Colors
        /// <summary>
        /// The good signal color
        /// </summary>
        private Color goodSignalColor = Color.Green;
        /// <summary>
        /// The poor signal color
        /// </summary>
        private Color poorSignalColor = Color.Yellow;
        /// <summary>
        /// The weak signal color
        /// </summary>
        private Color weakSignalColor = Color.Red;
        /// <summary>
        /// The no signal color
        /// </summary>
        private Color noSignalColor = Color.White;
        /// <summary>
        /// The empty bar color
        /// </summary>
        private Color emptyBarColor = Color.Gray;
        /// <summary>
        /// The center gradient color
        /// </summary>
        private Color centerGradientColor = Color.WhiteSmoke;
        /// <summary>
        /// The x color
        /// </summary>
        private Color xColor = Color.Red;
        /// <summary>
        /// The use solid bars
        /// </summary>
        private bool useSolidBars = false;

        //Ranges
        /// <summary>
        /// The good signal threshold
        /// </summary>
        private float goodSignalThreshold = 0.8f;
        /// <summary>
        /// The poor signal threshold
        /// </summary>
        private float poorSignalThreshold = 0.5f;
        /// <summary>
        /// The weak signal threshold
        /// </summary>
        private float weakSignalThreshold = 0.2f;
        /// <summary>
        /// The no signal threshold
        /// </summary>
        private float noSignalThreshold = 0.0f;

        //Layout/Style
        /// <summary>
        /// The bar layout
        /// </summary>
        private SignalStrengthLayout barLayout;
        /// <summary>
        /// The background style
        /// </summary>
        private SignalStrengthBackgroundStyle backgroundStyle;
        /// <summary>
        /// The draw x if no signal
        /// </summary>
        private bool drawXIfNoSignal = true;
        /// <summary>
        /// The x pen width
        /// </summary>
        private float xPenWidth = 1.5f;

        //Data
        /// <summary>
        /// The value
        /// </summary>
        private float value = 0.0f;
        /// <summary>
        /// The minimum value
        /// </summary>
        private float minValue = 0.0f;
        /// <summary>
        /// The maximum value
        /// </summary>
        private float maxValue = 1.0f;

        #endregion

        #region Properties

        /// <summary>
        /// Draw X over bar graph if no signal is seen,
        /// only works if BackgroundStyle is set to Normal.
        /// </summary>
        /// <value><c>true</c> if x if no signal; otherwise, <c>false</c>.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Draw X over bar graph if no signal is seen, only works if"
            + " BackgroundStyle is set to Normal")]
        public bool XIfNoSignal
        {
            get { return drawXIfNoSignal; }
            set { drawXIfNoSignal = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the x that is drawn if no signal value.
        /// </summary>
        /// <value>The color of the x.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("The color of the X that is drawn if no signal value")]
        public Color XColor
        {
            get { return xColor; }
            set { xColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the Width of the X lines if no signal value.
        /// </summary>
        /// <value>The width of the x.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Width of the X lines if no signal value")]
        public float XWidth
        {
            get { return xPenWidth; }
            set { xPenWidth = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the background style.
        /// </summary>
        /// <value>The background style.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Style of the background, if transparent the region is changed"
        + " to allow for true transparency")]
        public SignalStrengthBackgroundStyle BackgroundStyle
        {
            get { return backgroundStyle; }
            set { backgroundStyle = value; CalculateRegion(); this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use solid bars.
        /// </summary>
        /// <value><c>true</c> if use solid bars; otherwise, <c>false</c>.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("True to use a solid fill on the bars, otherwise a gradient fill is used")]
        public bool UseSolidBars
        {
            get { return useSolidBars; }
            set { useSolidBars = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar layout.
        /// </summary>
        /// <value>The bar layout.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Layout orientation of the signal bars")]
        public SignalStrengthLayout BarLayout
        {
            get { return barLayout; }
            set { barLayout = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the number of bars.
        /// </summary>
        /// <value>The number of bars.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Number of bars in the signal monitor")]
        public int NumberOfBars
        {
            get { return numberOfBars; }
            set { numberOfBars = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar spacing.
        /// </summary>
        /// <value>The bar spacing.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Spacing in pixels between the bars")]
        public int BarSpacing
        {
            get { return barSpacing; }
            set { barSpacing = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the height of the smallest bar.
        /// </summary>
        /// <value>The height of the small bar.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Height of the smallest bar")]
        public int SmallBarHeight
        {
            get { return smallBarHeight; }
            set { smallBarHeight = value; }
        }

        /// <summary>
        /// Gets or sets the number of pixels to add to the length of the bars.
        /// </summary>
        /// <value>The size of the bar step.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Number of pixels to add to the length of the bars")]
        public int BarStepSize
        {
            get { return barStepSize; }
            set { barStepSize = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the good signal.
        /// </summary>
        /// <value>The color of the good signal.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color used when the bar is considered empty")]
        public Color GoodSignalColor
        {
            get { return goodSignalColor; }
            set { goodSignalColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the empty color of the bar.
        /// </summary>
        /// <value>The empty color of the bar.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color of the bars when the bar is empty")]
        public Color EmptyBarColor
        {
            get { return emptyBarColor; }
            set { emptyBarColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the poor signal.
        /// </summary>
        /// <value>The color of the poor signal.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color of the bars when the signal is at or above PoorSignalThreshold but"
            + " below GoodSignalThreshold")]
        public Color PoorSignalColor
        {
            get { return poorSignalColor; }
            set { poorSignalColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the weak signal.
        /// </summary>
        /// <value>The color of the weak signal.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color of the bars when the signal is at or above WeakSignalThreshold but"
            + " below PoorSignalThreshold")]
        public Color WeakSignalColor
        {
            get { return weakSignalColor; }
            set { weakSignalColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the no signal.
        /// </summary>
        /// <value>The color of the no signal.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color of the bars when the signal is at or below NoSignalThreshold")]
        public Color NoSignalColor
        {
            get { return noSignalColor; }
            set { noSignalColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the center gradient.
        /// </summary>
        /// <value>The color of the center gradient.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Appearance"), Description("Color of the center of the bars in the gradient fill")]
        public Color CenterGradientColor
        {
            get { return centerGradientColor; }
            set { centerGradientColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the good signal threshold.
        /// </summary>
        /// <value>The good signal threshold.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Signal Thresholds"), Description("At or above this level the signal is drawn using the"
            + " GoodSignalColor")]
        public float GoodSignalThreshold
        {
            get { return goodSignalThreshold; }
            set { goodSignalThreshold = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the poor signal threshold.
        /// </summary>
        /// <value>The poor signal threshold.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Signal Thresholds"), Description("At or above this value, but below GoodSignalThreshold"
            + " the signal is drawn using the PoorSignalColor")]
        public float PoorSignalThreshold
        {
            get { return poorSignalThreshold; }
            set { poorSignalThreshold = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the weak signal threshold.
        /// </summary>
        /// <value>The weak signal threshold.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Signal Thresholds"), Description("At or above this value, but below PoorSignalThreshold"
            + " the signal is drawn using the WeakSignalColor")]
        public float WeakSignalThreshold
        {
            get { return weakSignalThreshold; }
            set { weakSignalThreshold = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the no signal threshold.
        /// </summary>
        /// <value>The no signal threshold.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Signal Thresholds"), Description("At or below this value the signal is drawn using the"
            + " NoSignalColor")]
        public float NoSignalThreshold
        {
            get { return noSignalThreshold; }
            set { noSignalThreshold = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the value of the signal, used to determine how many bars to fill.
        /// </summary>
        /// <value>The value.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Data"), Description("Value of the signal, used to determine how many bars to fill"
            + " and what color to use")]
        public float Value
        {
            get { return value; }
            set { this.value = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Data"), Description("The maximum value of the signal input")]
        public float MaximumValue
        {
            get { return maxValue; }
            set { this.maxValue = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(BindableSupport.Yes),
        Category("Data"), Description("The minimum value of the signal input")]
        public float MinimumValue
        {
            get { return minValue; }
            set { this.minValue = value; this.Invalidate(); }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSignal" /> class.
        /// </summary>
        public ZeroitSignal()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Calculates the region.
        /// </summary>
        private void CalculateRegion()
        {
            if (backgroundStyle == SignalStrengthBackgroundStyle.Normal)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddRectangle(ClientRectangle);
                this.Region = new Region(gp);
            }
            else
            {
                GraphicsPath myGP = new GraphicsPath();

                float startX = 0.0f;
                float startY = 0.0f;
                float stepX = 0.0f;
                float stepY = 0.0f;
                float barWidth = 0.0f;
                float barHeight = 0.0f;
                RectangleF barRect;
                float calcBarStep = 0.0f;
                float barHeightStep = 0.0f;

                if (barLayout == SignalStrengthLayout.LeftToRight)
                {
                    calcBarStep = (this.Height - smallBarHeight) / numberOfBars;
                    startX = barSpacing / 2.0f;
                    barWidth = this.Width / numberOfBars - barSpacing;
                    if (barWidth <= 0)
                        barWidth = 1;
                    startY = this.Height - smallBarHeight;
                    stepX = barWidth + barSpacing;
                    stepY = -calcBarStep;
                    barHeight = smallBarHeight;
                    barHeightStep = calcBarStep;
                }
                else if (barLayout == SignalStrengthLayout.RightToLeft)
                {
                    calcBarStep = (this.Height - smallBarHeight) / numberOfBars;

                    barWidth = this.Width / numberOfBars - barSpacing;
                    startX = this.Width - (barSpacing / 2.0f) - barWidth;
                    if (barWidth <= 0)
                        barWidth = 1;
                    startY = this.Height - smallBarHeight;
                    stepX = -(barWidth + barSpacing);
                    stepY = -calcBarStep;
                    barHeight = smallBarHeight;
                    barHeightStep = calcBarStep;
                }
                else if (barLayout == SignalStrengthLayout.TopToBottom)
                {
                    calcBarStep = (this.Width - smallBarHeight) / numberOfBars;
                    barWidth = this.Height / numberOfBars - barSpacing;
                    if (barWidth <= 0)
                        barWidth = 0;

                    startX = 0;
                    startY = 0;
                    stepX = 0;
                    stepY = barWidth + barSpacing;
                    barHeight = smallBarHeight;
                    barHeightStep = calcBarStep;
                }
                else
                {
                    calcBarStep = (this.Width - smallBarHeight) / numberOfBars;
                    barWidth = this.Height / numberOfBars - barSpacing;
                    if (barWidth <= 0)
                        barWidth = 0;

                    startX = 0;
                    startY = this.Height - barWidth;
                    stepX = 0;
                    stepY = -(barWidth + barSpacing);
                    barHeight = smallBarHeight;
                    barHeightStep = calcBarStep;
                }

                for (int i = 0; i < numberOfBars; i++)
                {
                    if (barLayout == SignalStrengthLayout.LeftToRight || barLayout == SignalStrengthLayout.RightToLeft)
                    {
                        barRect = new RectangleF(startX, startY, barWidth, barHeight);
                    }
                    else
                        barRect = new RectangleF(startX, startY, barHeight, barWidth);

                    myGP.AddRectangle(barRect);

                    startX += stepX;
                    startY += stepY;
                    barHeight += calcBarStep;
                }

                this.Region = new Region(myGP);
            }
        }

        #region Hidden Properties

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the wait cursor for the current control and all child controls.
        /// </summary>
        /// <value><c>true</c> if [use wait cursor]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseWaitCursor
        {
            get { return base.UseWaitCursor; }
            set { UseWaitCursor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if [allow drop]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        /// <summary>
        /// Gets or sets the automatic scaling mode of the control.
        /// </summary>
        /// <value>The automatic scale mode.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoScaleMode AutoScaleMode
        {
            get { return base.AutoScaleMode; }
            set { base.AutoScaleMode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value><c>true</c> if [automatic scroll]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; }
        }

        /// <summary>
        /// Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <value>The automatic scroll margin.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMargin
        {
            get { return base.AutoScrollMargin; }
            set { base.AutoScrollMargin = value; }
        }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value>The minimum size of the automatic scroll.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; }
        }

        /// <summary>
        /// Gets or sets where this control is scrolled to in <see cref="M:System.Windows.Forms.ScrollableControl.ScrollControlIntoView(System.Windows.Forms.Control)" />.
        /// </summary>
        /// <value>The automatic scroll offset.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Point AutoScrollOffset
        {
            get { return base.AutoScrollOffset; }
            set { base.AutoScrollOffset = value; }
        }

        /// <summary>
        /// Gets or sets the location of the auto-scroll position.
        /// </summary>
        /// <value>The automatic scroll position.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new Point AutoScrollPosition
        {
            get { return base.AutoScrollPosition; }
            set { base.AutoScrollPosition = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic size].
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        /// <summary>
        /// Gets or sets how the control will resize itself.
        /// </summary>
        /// <value>The automatic size mode.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoSizeMode AutoSizeMode
        {
            get { return base.AutoSizeMode; }
            set { base.AutoSizeMode = value; }
        }

        /// <summary>
        /// Gets or sets the Input Method Editor (IME) mode of the control.
        /// </summary>
        /// <value>The IME mode.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <value>The index of the tab.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        /// <summary>
        /// Gets or sets how the control performs validation when the user changes focus to another control.
        /// </summary>
        /// <value>The automatic validate.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoValidate AutoValidate
        {
            get { return base.AutoValidate; }
            set { base.AutoValidate = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.
        /// </summary>
        /// <value><c>true</c> if [causes validation]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation
        {
            get { return base.CausesValidation; }
            set { base.CausesValidation = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Draws to image.
        /// </summary>
        /// <returns>Image.</returns>
        public Image DrawToImage()
        {
            Bitmap retVal = new Bitmap(this.Width, this.Height);
            PaintEventArgs e = new PaintEventArgs(Graphics.FromImage(retVal), ClientRectangle);
            e.Graphics.Clear(BackColor);
            OnPaint(e);
            return retVal;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            CalculateRegion();
            base.OnResize(e);
        }

        #endregion

        #region Painting

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Color barColor = noSignalColor;

            if (value >= goodSignalThreshold)
                barColor = goodSignalColor;

            if (value >= poorSignalThreshold && value < goodSignalThreshold)
                barColor = poorSignalColor;

            if (value >= weakSignalThreshold && value < poorSignalThreshold)
                barColor = weakSignalColor;

            float startX = 0.0f;
            float startY = 0.0f;
            float stepX = 0.0f;
            float stepY = 0.0f;
            float barWidth = 0.0f;
            float barHeight = 0.0f;
            RectangleF barRect;
            float calcBarStep = 0.0f;
            float barHeightStep = 0.0f;

            if (barLayout == SignalStrengthLayout.LeftToRight)
            {
                calcBarStep = (this.Height - smallBarHeight) / numberOfBars;
                startX = barSpacing / 2.0f;
                barWidth = this.Width / numberOfBars - barSpacing;
                if (barWidth <= 0)
                    barWidth = 1;
                startY = this.Height - smallBarHeight;
                stepX = barWidth + barSpacing;
                stepY = -calcBarStep;
                barHeight = smallBarHeight;
                barHeightStep = calcBarStep;
            }
            else if (barLayout == SignalStrengthLayout.RightToLeft)
            {
                calcBarStep = (this.Height - smallBarHeight) / numberOfBars;

                barWidth = this.Width / numberOfBars - barSpacing;
                startX = this.Width - (barSpacing / 2.0f) - barWidth;
                if (barWidth <= 0)
                    barWidth = 1;
                startY = this.Height - smallBarHeight;
                stepX = -(barWidth + barSpacing);
                stepY = -calcBarStep;
                barHeight = smallBarHeight;
                barHeightStep = calcBarStep;
            }
            else if (barLayout == SignalStrengthLayout.TopToBottom)
            {
                calcBarStep = (this.Width - smallBarHeight) / numberOfBars;
                barWidth = this.Height / numberOfBars - barSpacing;
                if (barWidth <= 0)
                    barWidth = 0;

                startX = 0;
                startY = 0;
                stepX = 0;
                stepY = barWidth + barSpacing;
                barHeight = smallBarHeight;
                barHeightStep = calcBarStep;
            }
            else
            {
                calcBarStep = (this.Width - smallBarHeight) / numberOfBars;
                barWidth = this.Height / numberOfBars - barSpacing;
                if (barWidth <= 0)
                    barWidth = 0;

                startX = 0;
                startY = this.Height - barWidth;
                stepX = 0;
                stepY = -(barWidth + barSpacing);
                barHeight = smallBarHeight;
                barHeightStep = calcBarStep;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.High;

            float barPercentageStep = 1.0f / numberOfBars;
            float currentBarPercent = 0.0f;// barPercentageStep;
            float currentValue = (value - minValue) / (maxValue - minValue);

            if (currentValue > 1)
                currentValue = 1.0f;

            if (currentValue < 0)
                currentValue = 0.0f;

            for (int i = 0; i < numberOfBars; i++)
            {
                if (barLayout == SignalStrengthLayout.LeftToRight || barLayout == SignalStrengthLayout.RightToLeft)
                {
                    barRect = new RectangleF(startX, startY, barWidth, barHeight);
                }
                else
                    barRect = new RectangleF(startX, startY, barHeight, barWidth);

                if (currentValue >= currentBarPercent)
                    DrawBar(g, barRect, barColor);
                else
                    DrawBar(g, barRect, emptyBarColor);

                currentBarPercent += barPercentageStep;

                startX += stepX;
                startY += stepY;
                barHeight += barHeightStep;
            }

            if (value <= noSignalThreshold && drawXIfNoSignal)
            {
                //We just need to draw a big red X from extreme to extreme
                Pen xPen = new Pen(xColor, xPenWidth);
                g.DrawLine(xPen, 0.0f, 0.0f, this.Width, this.Height);
                g.DrawLine(xPen, this.Width, 0.0f, 0.0f, this.Height);
                xPen.Dispose();
            }

        }

        /// <summary>
        /// Draws the bar.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="barRect">The bar rect.</param>
        /// <param name="barMainColor">Color of the bar main.</param>
        private void DrawBar(Graphics g, RectangleF barRect, Color barMainColor)
        {
            //Bars are drawn very simply by filling the rectangle, we
            //just need to figure out the linear gradient
            LinearGradientBrush lgb;
            RectangleF lgbRect;
            Color gradColor = centerGradientColor;

            if (useSolidBars)
                gradColor = barMainColor;

            if (barLayout == SignalStrengthLayout.LeftToRight || barLayout == SignalStrengthLayout.RightToLeft)
            {
                lgbRect = new RectangleF(barRect.X, barRect.Y, barRect.Width / 2.0f, barRect.Height);
                lgb = new LinearGradientBrush(lgbRect, barMainColor, gradColor, 0.0f);
                lgb.WrapMode = WrapMode.TileFlipX;
            }
            else
            {
                lgbRect = new RectangleF(barRect.X, barRect.Y, barRect.Width, barRect.Height / 2.0f);
                lgb = new LinearGradientBrush(lgbRect, barMainColor, gradColor, 90.0f);
                lgb.WrapMode = WrapMode.TileFlipX;
            }

            g.FillRectangle(lgb, barRect);
            lgb.Dispose();
        }

        #endregion
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitSignal
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
            // SignalStrength
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SignalStrength";
            this.Size = new System.Drawing.Size(58, 53);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSignalDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSignalDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSignalDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSignalSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSignalSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSignalSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSignal colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSignalSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSignalSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSignal;

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
        /// Gets or sets a value indicating whether [x if no signal].
        /// </summary>
        /// <value><c>true</c> if [x if no signal]; otherwise, <c>false</c>.</value>
        public bool XIfNoSignal
        {
            get
            {
                return colUserControl.XIfNoSignal;
            }
            set
            {
                GetPropertyByName("XIfNoSignal").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use solid bars].
        /// </summary>
        /// <value><c>true</c> if [use solid bars]; otherwise, <c>false</c>.</value>
        public bool UseSolidBars
        {
            get
            {
                return colUserControl.UseSolidBars;
            }
            set
            {
                GetPropertyByName("UseSolidBars").SetValue(colUserControl, value);
            }
        }

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

        #region Properties

        /// <summary>
        /// Gets or sets the color of the x.
        /// </summary>
        /// <value>The color of the x.</value>
        public Color XColor
        {
            get
            {
                return colUserControl.XColor;
            }
            set
            {
                GetPropertyByName("XColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the good signal.
        /// </summary>
        /// <value>The color of the good signal.</value>
        public Color GoodSignalColor
        {
            get
            {
                return colUserControl.GoodSignalColor;
            }
            set
            {
                GetPropertyByName("GoodSignalColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the empty color of the bar.
        /// </summary>
        /// <value>The empty color of the bar.</value>
        public Color EmptyBarColor
        {
            get
            {
                return colUserControl.EmptyBarColor;
            }
            set
            {
                GetPropertyByName("EmptyBarColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the poor signal.
        /// </summary>
        /// <value>The color of the poor signal.</value>
        public Color PoorSignalColor
        {
            get
            {
                return colUserControl.PoorSignalColor;
            }
            set
            {
                GetPropertyByName("PoorSignalColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the weak signal.
        /// </summary>
        /// <value>The color of the weak signal.</value>
        public Color WeakSignalColor
        {
            get
            {
                return colUserControl.WeakSignalColor;
            }
            set
            {
                GetPropertyByName("WeakSignalColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the no signal.
        /// </summary>
        /// <value>The color of the no signal.</value>
        public Color NoSignalColor
        {
            get
            {
                return colUserControl.NoSignalColor;
            }
            set
            {
                GetPropertyByName("NoSignalColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the center gradient.
        /// </summary>
        /// <value>The color of the center gradient.</value>
        public Color CenterGradientColor
        {
            get
            {
                return colUserControl.CenterGradientColor;
            }
            set
            {
                GetPropertyByName("CenterGradientColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background style.
        /// </summary>
        /// <value>The background style.</value>
        public SignalStrengthBackgroundStyle BackgroundStyle
        {
            get
            {
                return colUserControl.BackgroundStyle;
            }
            set
            {
                GetPropertyByName("BackgroundStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar layout.
        /// </summary>
        /// <value>The bar layout.</value>
        public SignalStrengthLayout BarLayout
        {
            get
            {
                return colUserControl.BarLayout;
            }
            set
            {
                GetPropertyByName("BarLayout").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the x.
        /// </summary>
        /// <value>The width of the x.</value>
        public float XWidth
        {
            get
            {
                return colUserControl.XWidth;
            }
            set
            {
                GetPropertyByName("XWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of bars.
        /// </summary>
        /// <value>The number of bars.</value>
        public int NumberOfBars
        {
            get
            {
                return colUserControl.NumberOfBars;
            }
            set
            {
                GetPropertyByName("NumberOfBars").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar spacing.
        /// </summary>
        /// <value>The bar spacing.</value>
        public int BarSpacing
        {
            get
            {
                return colUserControl.BarSpacing;
            }
            set
            {
                GetPropertyByName("BarSpacing").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the small bar.
        /// </summary>
        /// <value>The height of the small bar.</value>
        public int SmallBarHeight
        {
            get
            {
                return colUserControl.SmallBarHeight;
            }
            set
            {
                GetPropertyByName("SmallBarHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the bar step.
        /// </summary>
        /// <value>The size of the bar step.</value>
        public int BarStepSize
        {
            get
            {
                return colUserControl.BarStepSize;
            }
            set
            {
                GetPropertyByName("BarStepSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the good signal threshold.
        /// </summary>
        /// <value>The good signal threshold.</value>
        public float GoodSignalThreshold
        {
            get
            {
                return colUserControl.GoodSignalThreshold;
            }
            set
            {
                GetPropertyByName("GoodSignalThreshold").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the poor signal threshold.
        /// </summary>
        /// <value>The poor signal threshold.</value>
        public float PoorSignalThreshold
        {
            get
            {
                return colUserControl.PoorSignalThreshold;
            }
            set
            {
                GetPropertyByName("PoorSignalThreshold").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the weak signal threshold.
        /// </summary>
        /// <value>The weak signal threshold.</value>
        public float WeakSignalThreshold
        {
            get
            {
                return colUserControl.WeakSignalThreshold;
            }
            set
            {
                GetPropertyByName("WeakSignalThreshold").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the no signal threshold.
        /// </summary>
        /// <value>The no signal threshold.</value>
        public float NoSignalThreshold
        {
            get
            {
                return colUserControl.NoSignalThreshold;
            }
            set
            {
                GetPropertyByName("NoSignalThreshold").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
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
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public float MaximumValue
        {
            get
            {
                return colUserControl.MaximumValue;
            }
            set
            {
                GetPropertyByName("MaximumValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public float MinimumValue
        {
            get
            {
                return colUserControl.MinimumValue;
            }
            set
            {
                GetPropertyByName("MinimumValue").SetValue(colUserControl, value);
            }
        }

        #endregion

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

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("XIfNoSignal",
                                 "X If No Signal", "Appearance",
                                 "Set if no signal."));

            items.Add(new DesignerActionPropertyItem("UseSolidBars",
                                 "Use Solid Bars", "Appearance",
                                 "Use solid colors than gradient like colors."));

            items.Add(new DesignerActionPropertyItem("XColor",
                                 "X Color", "Appearance",
                                 "No signal color."));

            items.Add(new DesignerActionPropertyItem("GoodSignalColor",
                                 "Good Signal Color", "Appearance",
                                 "Sets the good signal color."));

            items.Add(new DesignerActionPropertyItem("EmptyBarColor",
                                 "Empty Bar Color", "Appearance",
                                 "Sets the empty bar color."));

            items.Add(new DesignerActionPropertyItem("PoorSignalColor",
                                 "Poor Signal Color", "Appearance",
                                 "Sets the poor signal color."));

            items.Add(new DesignerActionPropertyItem("WeakSignalColor",
                                 "Weak Signal Color", "Appearance",
                                 "Sets the weak signal color."));

            items.Add(new DesignerActionPropertyItem("NoSignalColor",
                                 "No Signal Color", "Appearance",
                                 "Sets the no signal color."));

            items.Add(new DesignerActionPropertyItem("CenterGradientColor",
                                 "Center Gradient Color", "Appearance",
                                 "Sets the center gradient color."));

            items.Add(new DesignerActionPropertyItem("BackgroundStyle",
                                 "Background Style", "Appearance",
                                 "Sets the style of the background."));

            items.Add(new DesignerActionPropertyItem("BarLayout",
                                 "Bar Layout", "Appearance",
                                 "Sets the bar layout."));

            items.Add(new DesignerActionPropertyItem("XWidth",
                                 "X Width", "Appearance",
                                 "Sets the width of the no signal."));

            items.Add(new DesignerActionPropertyItem("NumberOfBars",
                                 "Number Of Bars", "Appearance",
                                 "Sets the number of bars."));

            items.Add(new DesignerActionPropertyItem("BarSpacing",
                                 "Bar Spacing", "Appearance",
                                 "Sets the bar spacing."));

            items.Add(new DesignerActionPropertyItem("SmallBarHeight",
                                 "Small Bar Height", "Appearance",
                                 "Sets the small bar height."));

            items.Add(new DesignerActionPropertyItem("BarStepSize",
                                 "Bar Step Size", "Appearance",
                                 "Sets the bar step size ."));

            items.Add(new DesignerActionPropertyItem("GoodSignalThreshold",
                                 "Good Signal Threshold", "Appearance",
                                 "Sets the good signal threshold."));

            items.Add(new DesignerActionPropertyItem("PoorSignalThreshold",
                                 "Poor Signal Threshold", "Appearance",
                                 "Sets the poor signal threshold."));

            items.Add(new DesignerActionPropertyItem("WeakSignalThreshold",
                                 "Weak Signal Threshold", "Appearance",
                                 "Sets the weak signal threshold."));

            items.Add(new DesignerActionPropertyItem("NoSignalThreshold",
                                 "No Signal Threshold", "Appearance",
                                 "Sets the no signal threshold."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value."));

            items.Add(new DesignerActionPropertyItem("MaximumValue",
                                 "Maximum Value", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("MinimumValue",
                                 "Minimum Value", "Appearance",
                                 "Sets the minimum value."));


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
