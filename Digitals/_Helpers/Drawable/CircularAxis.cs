// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CircularAxis.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Utils;
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable
{
    /// <summary>
    /// Enum TickPosition
    /// </summary>
    public enum TickPosition
    {
        /// <summary>
        /// The inside
        /// </summary>
        Inside,
        /// <summary>
        /// The middle
        /// </summary>
        Middle,
        /// <summary>
        /// The outside
        /// </summary>
        Outside
    }

    /// <summary>
    /// Enum LabelPosition
    /// </summary>
    public enum LabelPosition
    {
        /// <summary>
        /// The inside
        /// </summary>
        Inside,
        /// <summary>
        /// The outside
        /// </summary>
        Outside
    }

    /// <summary>
    /// Class CircularAxis.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable.IDrawable" />
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Category("Appearance")]
    [Description("The axis associated with this control")]
    public class CircularAxis : IDisposable, IDrawable
    {

        #region Public Properties

        /// <summary>
        /// Raised when the appearance (color, etc) of the axis has changed
        /// </summary>
        [Description("Raised when the appearance (color, etc) of the axis has changed")]
        public event EventHandler AppearanceChanged;

        /// <summary>
        /// Raised when the underlying graphics paths need to be recalculated
        /// </summary>
        [Description("Raised when the underlying graphics paths need to be recalculated")]
        public event EventHandler LayoutChanged;

        /// <summary>
        /// The m minimum value
        /// </summary>
        private int m_minVal = 0;
        /// <summary>
        /// The m maximum value
        /// </summary>
        private int m_maxVal = 100;

        /// <summary>
        /// The minimum value for the axis
        /// </summary>
        /// <value>The minimum value.</value>
        [DefaultValue(0)]
        [Description("The minimum value for the axis")]
        public int MinValue
        {
            get { return m_minVal; }
            set
            {
                m_minVal = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The maximum value for the axis
        /// </summary>
        /// <value>The maximum value.</value>
        [DefaultValue(100)]
        [Description("The maximum value for the axis")]
        public int MaxValue
        {
            get { return m_maxVal; }
            set
            {
                m_maxVal = value;
                OnLayoutChanged();
            }
        }

        #region Main Axis

        /// <summary>
        /// The m RAD percent
        /// </summary>
        private float m_radPercent = .85f;
        /// <summary>
        /// The m axis color
        /// </summary>
        private Color m_axisColor = Color.Black;
        /// <summary>
        /// The m axis width
        /// </summary>
        private float m_axisWidth = 3f;
        /// <summary>
        /// The m axis start degrees
        /// </summary>
        private int m_axisStartDegrees = 245;
        /// <summary>
        /// The m axis length degrees
        /// </summary>
        private int m_axisLengthDegrees = 310;

        /// <summary>
        /// The percent of the whole control to use for the axis radius
        /// </summary>
        /// <value>The radius percent.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        [DefaultValue(.85f)]
        [Description("The percent of the whole control to use for the axis radius")]
        public float RadiusPercent
        {
            get { return m_radPercent; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                m_radPercent = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The color of the axis
        /// </summary>
        /// <value>The color of the axis.</value>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color of the axis")]
        public Color AxisColor
        {
            get { return m_axisColor; }
            set
            {
                m_axisColor = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// The width (weight) of the axis
        /// </summary>
        /// <value>The width of the axis.</value>
        [DefaultValue(3f)]
        [Description("The width (weight) of the axis")]
        public float AxisWidth
        {
            get { return m_axisWidth; }
            set
            {
                m_axisWidth = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// Where the axis starts in relation to the center
        /// </summary>
        /// <value>The axis start degrees.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        [DefaultValue(245)]
        [Description("Where the axis starts in relation to the center")]
        public int AxisStartDegrees
        {
            get { return m_axisStartDegrees; }
            set
            {
                if (Math.Abs(value) > 360)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                m_axisStartDegrees = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The length of the axis in degrees
        /// </summary>
        /// <value>The axis length degrees.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        [DefaultValue(310)]
        [Description("The length of the axis in degrees")]
        public int AxisLengthDegrees
        {
            get { return m_axisLengthDegrees; }
            set
            {
                if (Math.Abs(value) > 360)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                m_axisLengthDegrees = value;
                OnLayoutChanged();
            }
        }

        #endregion

        #region Major Ticks

        /// <summary>
        /// The m major tick length
        /// </summary>
        private float m_majorTickLength = 10f;
        /// <summary>
        /// The m major tick division
        /// </summary>
        private int m_majorTickDivision = 10;
        /// <summary>
        /// The m major tick width
        /// </summary>
        private float m_majorTickWidth = 3f;
        /// <summary>
        /// The m major tick position
        /// </summary>
        private TickPosition m_majorTickPosition = TickPosition.Inside;

        /// <summary>
        /// The length of major ticks
        /// </summary>
        /// <value>The length of the major tick.</value>
        [DefaultValue(10f)]
        [Description("The length of major ticks")]
        public float MajorTickLength
        {
            get { return m_majorTickLength; }
            set
            {
                m_majorTickLength = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The spacing between major ticks (major tick interval)
        /// </summary>
        /// <value>The major tick division.</value>
        [DefaultValue(10)]
        [Description("The spacing between major ticks (major tick interval)")]
        public int MajorTickDivision
        {
            get { return m_majorTickDivision; }
            set
            {
                m_majorTickDivision = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The width (weight) of major ticks
        /// </summary>
        /// <value>The width of the major tick.</value>
        [DefaultValue(3f)]
        [Description("The width (weight) of major ticks")]
        public float MajorTickWidth
        {
            get { return m_majorTickWidth; }
            set
            {
                m_majorTickWidth = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The position of major ticks
        /// </summary>
        /// <value>The major tick position.</value>
        [DefaultValue(typeof(TickPosition), "Inside")]
        [Description("The position of major ticks")]
        public TickPosition MajorTickPosition
        {
            get { return m_majorTickPosition; }
            set
            {
                m_majorTickPosition = value;
                OnLayoutChanged();
            }
        }

        #endregion

        #region Minor Ticks

        /// <summary>
        /// The m minor tick length
        /// </summary>
        private float m_minorTickLength = 10f;
        /// <summary>
        /// The m minor tick division
        /// </summary>
        private int m_minorTickDivision = 10;
        /// <summary>
        /// The m minor tick width
        /// </summary>
        private float m_minorTickWidth = 3f;
        /// <summary>
        /// The m minor tick position
        /// </summary>
        private TickPosition m_minorTickPosition = TickPosition.Inside;

        /// <summary>
        /// The length of minor ticks
        /// </summary>
        /// <value>The length of the minor tick.</value>
        [DefaultValue(6f)]
        [Description("The length of minor ticks")]
        public float MinorTickLength
        {
            get { return m_minorTickLength; }
            set
            {
                m_minorTickLength = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The spacing between minor ticks (minor tick interval)
        /// </summary>
        /// <value>The minor tick division.</value>
        [DefaultValue(2)]
        [Description("The spacing between minor ticks (minor tick interval)")]
        public int MinorTickDivision
        {
            get { return m_minorTickDivision; }
            set
            {
                m_minorTickDivision = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The width (weight) of minor ticks
        /// </summary>
        /// <value>The width of the minor tick.</value>
        [DefaultValue(1.5f)]
        [Description("The width (weight) of minor ticks")]
        public float MinorTickWidth
        {
            get { return m_minorTickWidth; }
            set
            {
                m_minorTickWidth = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The position of minor ticks
        /// </summary>
        /// <value>The minor tick position.</value>
        [DefaultValue(typeof(TickPosition), "Inside")]
        [Description("The position of minor ticks")]
        public TickPosition MinorTickPosition
        {
            get { return m_minorTickPosition; }
            set
            {
                m_minorTickPosition = value;
                OnLayoutChanged();
            }
        }

        #endregion

        #region Label

        /// <summary>
        /// The m label offset
        /// </summary>
        private float m_labelOffset = 20f;
        /// <summary>
        /// The m label position
        /// </summary>
        private LabelPosition m_labelPosition = LabelPosition.Inside;
        /// <summary>
        /// The m label color
        /// </summary>
        private Color m_labelColor = Color.Black;
        /// <summary>
        /// The m label font family
        /// </summary>
        private string m_labelFontFamily = "Arial";
        /// <summary>
        /// The m label font size
        /// </summary>
        private float m_labelFontSize = 12f;
        /// <summary>
        /// The m label font style
        /// </summary>
        private FontStyle m_labelFontStyle = FontStyle.Regular;

        /// <summary>
        /// The distance from the axis to the center of each label
        /// </summary>
        /// <value>The label offset.</value>
        [Description("The distance from the axis to the center of each label")]
        [DefaultValue(20f)]
        public float LabelOffset
        {
            get { return m_labelOffset; }
            set
            {
                m_labelOffset = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The position of minor ticks
        /// </summary>
        /// <value>The label position.</value>
        [DefaultValue(typeof(LabelPosition), "Inside")]
        [Description("The position of the labels")]
        public LabelPosition LabelPosition
        {
            get { return m_labelPosition; }
            set
            {
                m_labelPosition = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The color of the labels
        /// </summary>
        /// <value>The color of the label.</value>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color of the labels")]
        public Color LabelColor
        {
            get { return m_labelColor; }
            set
            {
                m_labelColor = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// The font family for the labels
        /// </summary>
        /// <value>The label font family.</value>
        [DefaultValue("Arial")]
        [Description("The font family for the labels")]
        public string LabelFontFamily
        {
            get { return m_labelFontFamily; }
            set
            {
                m_labelFontFamily = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The font size for the labels
        /// </summary>
        /// <value>The size of the label font.</value>
        [DefaultValue(12f)]
        [Description("The font size for the labels")]
        public float LabelFontSize
        {
            get { return m_labelFontSize; }
            set
            {
                m_labelFontSize = value;
                OnLayoutChanged();
            }
        }

        /// <summary>
        /// The font style for the labels
        /// </summary>
        /// <value>The label font style.</value>
        [DefaultValue(typeof(FontStyle), "Regular")]
        [Description("The font style for the labels")]
        public FontStyle LabelFontStyle
        {
            get { return m_labelFontStyle; }
            set
            {
                m_labelFontStyle = value;
                OnLayoutChanged();
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// The m arc path
        /// </summary>
        private GraphicsPath m_arcPath;
        /// <summary>
        /// The m major ticks path
        /// </summary>
        private GraphicsPath m_majorTicksPath;
        /// <summary>
        /// The m minor ticks path
        /// </summary>
        private GraphicsPath m_minorTicksPath;
        /// <summary>
        /// The m label path
        /// </summary>
        private GraphicsPath m_labelPath;
        /// <summary>
        /// The m redraw region
        /// </summary>
        private Region m_redrawRegion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularAxis"/> class.
        /// </summary>
        public CircularAxis()
        {
            MinValue = 0;
            MaxValue = 100;
            RadiusPercent = .85f;
            AxisWidth = 3f;
            AxisColor = Color.Black;
            AxisStartDegrees = 245;
            AxisLengthDegrees = 310;

            MajorTickLength = 10f;
            MajorTickDivision = 10;
            MajorTickWidth = 3f;
            MajorTickPosition = TickPosition.Inside;

            MinorTickLength = 6f;
            MinorTickDivision = 2;
            MinorTickWidth = AxisWidth * .5f;
            MinorTickPosition = TickPosition.Inside;

            LabelOffset = 20f;
            LabelPosition = LabelPosition.Inside;
            LabelColor = Color.Black;
            LabelFontFamily = "Arial";
            LabelFontSize = 12f;
            LabelFontStyle = FontStyle.Regular;

            m_redrawRegion = new Region();

            CalculatePaths(new RectangleF());
        }

        /// <summary>
        /// Gets the region that needs to be redrawn because of changes to the control.
        /// This should be a union of where the control was last drawn and where it needs
        /// to be drawn.
        /// </summary>
        /// <returns>The region affected by this control</returns>
        public Region GetRedrawRegion()
        {
            return m_redrawRegion;
        }

        /// <summary>
        /// Called when [layout changed].
        /// </summary>
        protected virtual void OnLayoutChanged()
        {
            if (LayoutChanged != null)
            {
                LayoutChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        protected virtual void OnAppearanceChanged()
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Draws a control onto the graphics
        /// </summary>
        /// <param name="g">The graphics to draw onto</param>
        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen axisPen = new Pen(AxisColor, AxisWidth))
            using (Pen majorPen = new Pen(AxisColor, MajorTickWidth))
            using (Pen minorPen = new Pen(AxisColor, MinorTickWidth))
            using (Brush labelBrush = new SolidBrush(LabelColor))
            {
                axisPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
                majorPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
                minorPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

                try
                {
                    g.DrawPath(axisPen, m_arcPath);
                    g.DrawPath(majorPen, m_majorTicksPath);
                    g.DrawPath(minorPen, m_minorTicksPath);
                    g.FillPath(labelBrush, m_labelPath);
                }
                catch { }
            }

            //now these areas need to be redrawn if they change
            m_redrawRegion.Dispose();
            m_redrawRegion = new Region();
            m_redrawRegion.Union(m_arcPath);
            m_redrawRegion.Union(m_labelPath);
            m_redrawRegion.Union(m_majorTicksPath);
            m_redrawRegion.Union(m_minorTicksPath);
        }

        /// <summary>
        /// Calculates this controls shape and size that will be used
        /// when it is drawn
        /// </summary>
        /// <param name="container">The allowed space for the control</param>
        public void CalculatePaths(RectangleF container)
        {
            DisposePaths();

            float deltaX = ((container.Width * (1 - RadiusPercent)) / 2f);
            float deltaY = ((container.Height * (1 - RadiusPercent)) / 2f);
            RectangleF axisRect = container;
            axisRect.Inflate(-deltaX, -deltaY);

            m_arcPath = GraphicsHelper.GetArcPath(axisRect, AxisStartDegrees, AxisLengthDegrees);
            m_majorTicksPath = new GraphicsPath();
            m_minorTicksPath = new GraphicsPath();
            m_labelPath = new GraphicsPath();

            CalculateTicks(m_majorTicksPath, m_minorTicksPath, m_labelPath, axisRect);

            //these areas need to be redrawn now
            m_redrawRegion.Union(m_arcPath);
            m_redrawRegion.Union(m_labelPath);
            m_redrawRegion.Union(m_majorTicksPath);
            m_redrawRegion.Union(m_minorTicksPath);
        }

        /// <summary>
        /// Calculates the ticks.
        /// </summary>
        /// <param name="majorPath">The major path.</param>
        /// <param name="minorPath">The minor path.</param>
        /// <param name="labelPath">The label path.</param>
        /// <param name="rect">The rect.</param>
        private void CalculateTicks(GraphicsPath majorPath, GraphicsPath minorPath,
            GraphicsPath labelPath, RectangleF rect)
        {
            int nRange = MaxValue - MinValue;
            double dEachPointDelta = AxisLengthDegrees / (double)(nRange);

            double majorStartOffset = 0;
            double majorEndOffset = 0;
            double minorStartOffset = 0;
            double minorEndOffset = 0;

            switch (MajorTickPosition)
            {
                case TickPosition.Inside:
                    majorEndOffset = -MajorTickLength;
                    break;
                case TickPosition.Middle:
                    majorStartOffset = MajorTickLength / 2d;
                    majorEndOffset = -majorStartOffset;
                    break;
                case TickPosition.Outside:
                    majorStartOffset = MajorTickLength;
                    break;
            }

            switch (MinorTickPosition)
            {
                case TickPosition.Inside:
                    minorEndOffset = -MinorTickLength;
                    break;
                case TickPosition.Middle:
                    minorStartOffset = MinorTickLength / 2d;
                    minorEndOffset = -minorStartOffset;
                    break;
                case TickPosition.Outside:
                    minorStartOffset = MinorTickLength;
                    break;
            }

            for (int i = MinValue; i <= MaxValue; i++)
            {
                double curDeg = AxisStartDegrees - ((i - MinValue) * dEachPointDelta);

                if (i % MajorTickDivision == 0)
                {
                    //only draw MinValue if axis is 360 and MinValue and MaxValue have labels
                    //to keep them from overlapping
                    if (Math.Abs(AxisLengthDegrees) < 360 || 
                       (i < MaxValue) || 
                       ((MinValue % MajorTickDivision) != 0))
                    {
                        AddLabel(labelPath, rect, curDeg, i);
                    }

                    PointF start = GraphicsHelper.GetPointInArc(rect, curDeg, majorStartOffset);
                    PointF end = GraphicsHelper.GetPointInArc(rect, curDeg, majorEndOffset);
                    majorPath.StartFigure();
                    majorPath.AddLine(start, end);
                    majorPath.CloseFigure();
                }
                else if (i % MinorTickDivision == 0)
                {
                    PointF start = GraphicsHelper.GetPointInArc(rect, curDeg, minorStartOffset);
                    PointF end = GraphicsHelper.GetPointInArc(rect, curDeg, minorEndOffset);
                    minorPath.StartFigure();
                    minorPath.AddLine(start, end);
                    minorPath.CloseFigure();
                }
            }
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelPath">The label path.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="degrees">The degrees.</param>
        /// <param name="value">The value.</param>
        private void AddLabel(GraphicsPath labelPath, RectangleF rect, double degrees, int value)
        {
            double offset = 0;

            switch (LabelPosition)
            {
                case LabelPosition.Inside:
                    offset = -LabelOffset;
                    break;
                case LabelPosition.Outside:
                    offset = LabelOffset;
                    break;
            }

            PointF center = GraphicsHelper.GetPointInArc(rect, degrees, offset);

            using (Bitmap bm = new Bitmap(1,1))
            using (Graphics g = Graphics.FromImage(bm))
            using (Font font = new Font(LabelFontFamily, LabelFontSize, LabelFontStyle))
            {
                SizeF size = SizeF.Empty;
                try
                {
                    size = CustomExtensions.MeasureDisplayStringSize(g, value.ToString(), font);
                }
                catch { }

                PointF origin = new PointF(center.X - (size.Width / 2f),
                                           center.Y - (size.Height / 2f));
                labelPath.AddString(value.ToString(), font.FontFamily, (int)font.Style, font.Size,
                    origin, StringFormat.GenericDefault);
            }
        }

        /// <summary>
        /// Disposes the paths.
        /// </summary>
        private void DisposePaths()
        {
            if (m_arcPath != null)
            {
                m_arcPath.Dispose();
                m_arcPath = null;
            }
            if (m_majorTicksPath != null)
            {
                m_majorTicksPath.Dispose();
                m_majorTicksPath = null;
            }
            if (m_minorTicksPath != null)
            {
                m_minorTicksPath.Dispose();
                m_minorTicksPath = null;
            }
            if (m_labelPath != null)
            {
                m_labelPath.Dispose();
                m_labelPath = null;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DisposePaths();
        }
    }
}
