// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SpiralTrackBarControl.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.HelperControls.Widgets;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitSpiralTrackBar Control

    #region Control

    #region Enums
    /// <summary>
    /// The style of the tick marks on the <c><see cref="ZeroitSpiralTrackBar" /></c>.
    /// </summary>
    public enum SpiralTrackBarTickStyle
    {
        /// <summary>
        /// No ticks.
        /// </summary>
        None,

        /// <summary>
        /// Tick marks extend from track line in towards center.
        /// </summary>
        Inner,

        /// <summary>
        /// Tick marks extend from track line out away from center.
        /// </summary>
        Outer,

        /// <summary>
        /// Tick marks are located on both sides of track line.
        /// </summary>
        Both
    };

    /// <summary>
    /// Indicates the spacing of the tick marks on the track line for <c><see cref="ZeroitSpiralTrackBar" /></c>.
    /// </summary>
	public enum SpiralTrackBarTickSpacing
    {
        /// <summary>
        /// Tick marks are equally spaced out by arc length along the track line.
        /// </summary>
        ArcLength,

        /// <summary>
        /// Tick marks are equally spaced out by angle along the track line.
        /// </summary>
        Angular
    };

    /// <summary>
    /// Indicates the shape of the ends of the track line for <c><see cref="ZeroitSpiralTrackBar" /></c>.
    /// </summary>
	public enum SpiralTrackBarTrackEnd
    {
        /// <summary>
        /// Ends of track line are flat.
        /// </summary>
        Flat,

        /// <summary>
        /// Ends of track line are rounded.
        /// </summary>
		Round
    };
    #endregion

    /// <summary>
    /// A class collection for rendering a spiral trackbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ZeroitSpiralTrackBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSpiralTrackBar" /> class.
        /// </summary>
        public ZeroitSpiralTrackBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, false);

            base.FontChanged += new EventHandler(Base_FontChanged);

            markerShape = new Polygon(new PointF[] { new PointF(-15,   0),
                                                     new PointF(+10, -12),
                                                     new PointF(+10, +12),
                                                     new PointF(-15,   0) });

            RecalcRange();
        }

        /// <summary>
        /// Occurs when the Value property changes, either by movement or programmatically.
        /// </summary>
		public event EventHandler ValueChanged;

        /// <summary>
        /// The start angle
        /// </summary>
        private double startAngle = 90.0;
        /// <summary>
        /// Gets or sets the start angle for the spiral track line.
        /// </summary>
        /// <value>Start angle for the spiral track line.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>StartAngle</c> is less than zero.</exception>
        [Category("Behavior"), DefaultValue(90.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double StartAngle
        {
            get { return startAngle; }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("StartAngle", "Must be greater than or equal to zero");
                }
                startAngle = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the final angle for the spiral track line.
        /// </summary>
        /// <value>Final angle for the spiral track line.</value>
        /// <remarks>This value is calculated from <c>StartAngle</c> and <c>Rotations</c>.</remarks>
		[Category("Behavior")]
        public double StopAngle
        {
            get { return startAngle + rotations * 360.0; }
        }

        /// <summary>
        /// The rotations
        /// </summary>
        private double rotations = 2.0;
        /// <summary>
        /// Gets or sets the length of the spiral track line in terms of full rotations.
        /// </summary>
        /// <value>Length of the spiral track line in terms of full rotations.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>Rotations</c> is less than or equal to zero.</exception>
        [Category("Behavior"), DefaultValue(2.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double Rotations
        {
            get { return rotations; }
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentOutOfRangeException("Rotations", "Must be greater than zero");
                }
                rotations = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The minimum
        /// </summary>
        private double minimum = 0.0;
        /// <summary>
        /// Gets or sets the lower limit of the range for <c>Value</c>.
        /// </summary>
        /// <value>The lower limit of the range for <c>Value</c>.</value>
        /// <remarks>Setting this value may result in <c>Maximum</c> or <c>Value</c> changing.
        /// <c>Maximum</c> is changed if the difference between <c>Maximum</c> and <c>Minimum</c>
        /// is not evenly divisible by <c>StepSize</c>.
        /// <c>Value</c> is changed if it is not one the valid step values.</remarks>
        [Category("Behavior"), DefaultValue(0.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double Minimum
        {
            get { return minimum; }
            set
            {
                minimum = value;
                if (minimum >= maximum)
                {
                    maximum = minimum + stepSize;
                }
                minimumLastSet = true;
                RecalcRange();
                Invalidate();
            }
        }

        /// <summary>
        /// The maximum
        /// </summary>
        private double maximum = 100.0;
        /// <summary>
        /// Gets or sets the upper limit of the range for <c>Value</c>.
        /// </summary>
        /// <value>The upper limit of the range for <c>Value</c>.</value>
        /// <remarks>Setting this value may result in <c>Minimum</c> or <c>Value</c> changing.
        /// <c>Minimum</c> is changed if the difference between <c>Maximum</c> and <c>Minimum</c>
        /// is not evenly divisible by <c>StepSize</c>.
        /// <c>Value</c> is changed if it is not one the valid step values.</remarks>
        [Category("Behavior"), DefaultValue(100.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                if (maximum <= minimum)
                {
                    minimum = maximum - stepSize;
                }
                minimumLastSet = false;
                RecalcRange();
                Invalidate();
            }
        }

        /// <summary>
        /// The step size
        /// </summary>
        private double stepSize = 1.0;
        /// <summary>
        /// Gets or sets the step size (amount that <c>Value</c> changes when the marker is moved the minimal amount).
        /// </summary>
        /// <value>The step size (amount that <c>Value</c> changes when the marker is moved the minimal amount).</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Step - Must be greater than zero</exception>
        /// <remarks>Setting this value may result in any of <c>Minimum</c>, <c>Maximum</c>, or <c>Value</c> changing.
        /// <c>Minimum</c> or <c>Maximum</c> is changed if the difference between <c>Maximum</c> and <c>Minimum</c>
        /// is not evenly divisible by <c>StepSize</c>.
        /// <c>Value</c> is changed if it is not one the valid step values.</remarks>
        [Category("Behavior"), DefaultValue(1.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double StepSize
        {
            get { return stepSize; }
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentOutOfRangeException("Step", "Must be greater than zero");
                }
                stepSize = value;
                RecalcRange();
                Invalidate();
            }
        }

        /// <summary>
        /// The step count
        /// </summary>
        private int stepCount; // total number of ticks (visible or not)
                               /// <summary>
                               /// Gets the number of steps for this ZeroitSpiralTrackBar.
                               /// </summary>
                               /// <value>The number of steps for this ZeroitSpiralTrackBar.</value>
                               /// <remarks>This value is calculated from the <c>Minimum</c>, <c>Maximum</c>, and <c>StepSize</c> values.</remarks>
        [Category("Behavior")]
        public int StepCount
        {
            get { return stepCount; }
        }

        /// <summary>
        /// The value
        /// </summary>
        private double val = 50.0;
        /// <summary>
        /// Gets or sets the current value programatically.
        /// </summary>
        /// <value>The current value.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>Value</c> is less than <c>Minimum</c> or greater than <c>Maxmimum</c>.</exception>
        /// <remarks><c>Value</c> may be changed to be equal to the nearest step value.</remarks>
        [Category("Behavior"), DefaultValue(50.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double Value
        {
            get { return val; }
            set
            {
                if (value < minimum)
                {
                    throw new ArgumentOutOfRangeException("Value", "Must not be less than Minimum");
                }
                if (value > maximum)
                {
                    throw new ArgumentOutOfRangeException("Value", "Must not be greater than Maximum");
                }
                RecalcValue(value);
            }
        }

        /// <summary>
        /// The indent start
        /// </summary>
        private double indentStart = 0.3;
        /// <summary>
        /// Gets or sets the indent value at the start of the track line.
        /// </summary>
        /// <value>The indent value at the start of the track line.
        /// <para>
        /// This value is the distance from the center of the control, where 1.0 is defined
        /// as the distance from the center of the control to the nearest edge.
        /// </para></value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>Indent</c> is less than or equal to zero or greater than or equal to <c>IndentStop</c>.</exception>
        [Category("Appearance"), DefaultValue(0.3)]
        [RefreshProperties(RefreshProperties.All)]
        public double IndentStart
        {
            get { return indentStart; }
            set
            {
                if (value <= 0.0 || value >= indentStop)
                {
                    throw new ArgumentOutOfRangeException("IndentStart", "Must be greater than zero and less IndentStop");
                }
                indentStart = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The indent stop
        /// </summary>
        private double indentStop = 0.9;
        /// <summary>
        /// Gets or sets the indent value at the end of the track line.
        /// </summary>
        /// <value>The indent value at the end of the track line.
        /// <para>
        /// This value is the distance from the center of the control, where 1.0 is defined
        /// as the distance from the center of the control to the nearest edge.
        /// </para></value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>Indent</c> is less than or equal to <c>IndentStart</c> or greater than or equal to 1.</exception>
        [Category("Appearance"), DefaultValue(0.9)]
        [RefreshProperties(RefreshProperties.All)]
        public double IndentStop
        {
            get { return indentStop; }
            set
            {
                if (value <= indentStart || value >= 1.0)
                {
                    throw new ArgumentOutOfRangeException("IndentStop", "Must be greater than IndentStart and less than one");
                }
                indentStop = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The track border
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Line trackBorder = new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line();
        /// <summary>
        /// Gets or sets the style used to draw the spiral track line.
        /// </summary>
        /// <value>The style used to draw the spiral track line.
        /// <para>
        /// If set to null, the default line style is used.
        /// </para></value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Line TrackBorder
        {
            get { return trackBorder; }
            set
            {
                trackBorder = (value == null) ? new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line() : value.Clone();
                DisposeTrackPen();
                Invalidate();
            }
        }

        /// <summary>
        /// The track end
        /// </summary>
        private SpiralTrackBarTrackEnd trackEnd = SpiralTrackBarTrackEnd.Flat;
        /// <summary>
        /// Gets or sets the shape at the end of the track line.
        /// </summary>
        /// <value>The shape at the end of the track line.</value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public SpiralTrackBarTrackEnd TrackEnd
        {
            get { return trackEnd; }
            set
            {
                trackEnd = value;
                DisposeTrackPath();
                Invalidate();
            }
        }

        /// <summary>
        /// The track fill
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler2 trackFill = new Filler2(Color.FromArgb(128, Color.Red));
        /// <summary>
        /// Gets or sets the <c>Filler2</c> which is used to fill the inside area of the track.
        /// </summary>
        /// <value>The <c>Filler2</c> which is used to fill the inside area of the track.</value>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>TrackFill</c> is <c>null</c>.</exception>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler2 TrackFill
        {
            get { return trackFill; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("TrackFill");
                }
                trackFill = value.Clone();
                DisposeTrackBrush();
                DisposeTrackPath(); // just in case gradient
                Invalidate();
            }
        }

        /// <summary>
        /// The track fill size
        /// </summary>
        private int trackFillSize = 0;
        /// <summary>
        /// Gets or sets of the size of the inside of the track.
        /// </summary>
        /// <value>The size of the inside of the track.  Default is 0.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>TrackFillSize</c> is less than zero.</exception>
        /// <remarks>If the value is zero, then the track is composed of a single line as indicated by <c>TrackBorder</c>.</remarks>
        [Category("Appearance"), DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int TrackFillSize
        {
            get { return trackFillSize; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("TrackFillSize", "Must be greater than or equal to zero");
                }
                trackFillSize = value;
                DisposeTrackBrush();
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The tick line
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Line tickLine = new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line();
        /// <summary>
        /// Gets or sets the style used to draw the tick lines.
        /// </summary>
        /// <value>The style used to draw the tick lines.
        /// <para>
        /// If set to null, the default line style is used.
        /// </para></value>
		[Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Line TickLine
        {
            get { return tickLine; }
            set
            {
                tickLine = (value == null) ? new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line() : value.Clone();
                DisposeTickPen();
                Invalidate();
            }
        }

        /// <summary>
        /// The tick spacing
        /// </summary>
        private SpiralTrackBarTickSpacing tickSpacing = SpiralTrackBarTickSpacing.ArcLength;
        /// <summary>
        /// Gets or sets a value indicating the spacing of the tick marks track line.
        /// </summary>
        /// <value>One of the <c>SpiralTrackBarTickSpacing</c> values.  The default is <c>ArcLength</c>.</value>
        [Category("Appearance"), DefaultValue("SpiralTrackBarTickSpacing.ArcLength")]
        [RefreshProperties(RefreshProperties.All)]
        public SpiralTrackBarTickSpacing TickSpacing
        {
            get { return tickSpacing; }
            set
            {
                tickSpacing = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The calculate layout time
        /// </summary>
        private long calcLayoutTime = 0;
        /// <summary>
        /// Get time (in milliseconds) required to calculate control layout.
        /// </summary>
        /// <value>Time (in milliseconds) required to calculate control layout.</value>
        [Category("Performance Statistics")]
        public long CalcLayoutTime
        {
            get { return calcLayoutTime; }
        }

        /// <summary>
        /// The calculate layout arc count
        /// </summary>
        private int calcLayoutArcCount = 0;
        /// <summary>
        /// Get number of arc calculations required.
        /// </summary>
        /// <value>Number of arc calculations required.</value>
        [Category("Performance Statistics")]
        public int CalcLayoutArcCount
        {
            get { return calcLayoutArcCount; }
        }

        /// <summary>
        /// The paint time
        /// </summary>
        private long paintTime = 0;
        /// <summary>
        /// Get time (in milliseconds) required to paint control.
        /// </summary>
        /// <value>Time (in milliseconds) required to paint control.</value>
        [Category("Performance Statistics")]
        public long PaintTime
        {
            get { return paintTime; }
        }

        /// <summary>
        /// The tick style
        /// </summary>
        private SpiralTrackBarTickStyle tickStyle = SpiralTrackBarTickStyle.Both;
        /// <summary>
        /// Gets or sets a value indicating how to display the tick marks on the track line.
        /// </summary>
        /// <value>One of the <c>SpiralTrackBarTickStyle</c> values.  The default is <c>Both</c>.</value>
        [Category("Appearance"), DefaultValue("SpiralTrackBarTickStyle.Both")]
        [RefreshProperties(RefreshProperties.All)]
        public SpiralTrackBarTickStyle TickStyle
        {
            get { return tickStyle; }
            set
            {
                tickStyle = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The tick length
        /// </summary>
        private int tickLength = 5;
        /// <summary>
        /// Gets or sets of the length of tick marks (in pixels).
        /// </summary>
        /// <value>The length of tick marks (in pixels).  Default is 5.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>TickLength</c> is less than zero.</exception>
        [Category("Appearance"), DefaultValue(5)]
        [RefreshProperties(RefreshProperties.All)]
        public int TickLength
        {
            get { return tickLength; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("TickLength", "Must be greater than or equal to zero");
                }
                tickLength = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The major tick frequency
        /// </summary>
        private int majorTickFrequency = 1;
        /// <summary>
        /// Gets or sets the frequency with which major tick marks appear.
        /// </summary>
        /// <value>The frequency with which major tick marks appear.
        /// <para>
        /// Major tick marks have a length of <c>TickLength</c>. Minor tick marks are half that length.
        /// </para></value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>MajorTickFrequency</c> is less than one.</exception>
        [Category("Appearance"), DefaultValue(1)]
        [RefreshProperties(RefreshProperties.All)]
        public int MajorTickFrequency
        {
            get { return majorTickFrequency; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("MajorTickFrequency", "Must be greater than zero");
                }
                majorTickFrequency = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The minor tick frequency
        /// </summary>
        private int minorTickFrequency = 0;
        /// <summary>
        /// Gets or sets the frequency with which minor tick marks appear.
        /// </summary>
        /// <value>The frequency with which minor tick marks appear.
        /// If zero, then there are no minor tick marks.
        /// <para>
        /// Major tick marks have a length of <c>TickLength</c>. Minor tick marks are half that length.
        /// </para></value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>MinorTickFrequency</c> is less than zero.</exception>
		[Category("Appearance"), DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int MinorTickFrequency
        {
            get { return minorTickFrequency; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MinorTickFrequency", "Must be zero or greater");
                }
                minorTickFrequency = value;
                RecalcLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// The marker shape
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Polygon markerShape = null;
        /// <summary>
        /// Gets or sets the polygon which defines the shape of the marker.
        /// </summary>
        /// <value>The polygon which defines the shape of the marker.</value>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>MarkerShape</c> is <c>null</c>.</exception>
		[Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Polygon MarkerShape
        {
            get { return markerShape; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("MarkerShape");
                }
                markerShape = value.Clone();
                DisposeMarkerPath();
                Invalidate();
            }
        }

        /// <summary>
        /// The marker border
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Line markerBorder = new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line();
        /// <summary>
        /// Gets or sets the style used to draw the marker border
        /// </summary>
        /// <value>The style used to draw the marker border.
        /// <para>
        /// If set to null, the default line style is used.
        /// </para></value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Line MarkerBorder
        {
            get { return markerBorder; }
            set
            {
                markerBorder = (value == null) ? new Zeroit.Framework.MiscControls.HelperControls.Widgets.Line() : value.Clone();
                DisposeMarkerPen();
                Invalidate();
            }
        }

        /// <summary>
        /// The marker fill
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler2 markerFill = new Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler2(Color.Blue);
        /// <summary>
        /// Gets or sets the <c>Filler2</c> which is used to fill the inside area of the marker.
        /// </summary>
        /// <value>The <c>Filler2</c> which is used to fill the inside area of the marker.</value>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>MarkerFill</c> is <c>null</c>.</exception>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler2 MarkerFill
        {
            get { return markerFill; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("MarkerFill");
                }
                markerFill = value.Clone();
                DisposeMarkerPath();
                DisposeMarkerBrush();
                Invalidate();
            }
        }


        /// <summary>
        /// The background fill
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler backgroundFill = new Filler(SystemColors.Control);
        /// <summary>
        /// Gets or sets the <c>Filler</c> which is used to fill the background of the control.
        /// </summary>
        /// <value>The <c>Filler</c> which is used to fill the background of the control.</value>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>BackgroundFill</c> is <c>null</c>.</exception>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Filler BackgroundFill
        {
            get { return backgroundFill; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("BackgroundFill");
                }
                backgroundFill = value.Clone();
                DisposeBackBrush();
                Invalidate();
            }
        }
    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitSpiralTrackBar
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
            // ZeroitSpiralTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ZeroitSpiralTrackBar";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpiralTrackBar_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpiralTrackBar_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpiralTrackBar_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SpiralTrackBar_MouseUp);
            this.SizeChanged += new System.EventHandler(this.SpiralTrackBar_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    #endregion
}
