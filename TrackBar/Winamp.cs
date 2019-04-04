// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Winamp.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Winamp TrackBar

    #region EventArgs
    /// <summary>
    /// Class ZeroitWinampTrackBarSeekEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitWinampTrackBarSeekEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWinampTrackBarSeekEventArgs"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ZeroitWinampTrackBarSeekEventArgs(int value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Class ZeroitWinampTrackBarValueChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitWinampTrackBarValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; private set; }
        /// <summary>
        /// Gets the change source.
        /// </summary>
        /// <value>The change source.</value>
        public ZeroitWinampTrackBar.ZeroitWinampTrackBarValueChangeSource ChangeSource { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWinampTrackBarValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="changeSource">The change source.</param>
        public ZeroitWinampTrackBarValueChangedEventArgs(int value, ZeroitWinampTrackBar.ZeroitWinampTrackBarValueChangeSource changeSource)
        {
            Value = value;
            ChangeSource = changeSource;
        }
    }

    /// <summary>
    /// Class ZeroitWinampTrackBarValueChangingEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitWinampTrackBarValueChangingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; private set; }
        /// <summary>
        /// Gets the change source.
        /// </summary>
        /// <value>The change source.</value>
        public ZeroitWinampTrackBar.ZeroitWinampTrackBarValueChangeSource ChangeSource { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitWinampTrackBarValueChangingEventArgs"/> is cancel.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWinampTrackBarValueChangingEventArgs"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="changeSource">The change source.</param>
        public ZeroitWinampTrackBarValueChangingEventArgs(int value, ZeroitWinampTrackBar.ZeroitWinampTrackBarValueChangeSource changeSource)
        {
            Value = value;
            ChangeSource = changeSource;
            Cancel = false;
        }
    }
    #endregion

    #region GraphicsExtensionMethods
    /// <summary>
    /// Class ZeroitWinampGraphicsExtensionMethods.
    /// </summary>
    public static class ZeroitWinampGraphicsExtensionMethods
    {
        /// <summary>
        /// Draxes the pixel.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public static void DraxPixel(this Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillRectangle(brush, x, y, 1, 1);
        }
    }
    #endregion

    #region HorizontalWinampTrackBarRenderer
    /// <summary>
    /// Class ZeroitHorizontalWinampTrackBarRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitWinampTrackBarRenderer" />
    public class ZeroitHorizontalWinampTrackBarRenderer : ZeroitWinampTrackBarRenderer
    {
        /// <summary>
        /// The track bar
        /// </summary>
        private ZeroitWinampTrackBar _trackBar;
        /// <summary>
        /// The acceptable space between scale and track bar
        /// </summary>
        private const int AcceptableSpaceBetweenScaleAndTrackBar = 3;
        /// <summary>
        /// The acceptable space between tick and track bar
        /// </summary>
        private const int AcceptableSpaceBetweenTickAndTrackBar = 2;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHorizontalWinampTrackBarRenderer"/> class.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <exception cref="System.Exception">You have to pass the TrackBar object in the constructor!</exception>
        public ZeroitHorizontalWinampTrackBarRenderer(ZeroitWinampTrackBar trackBar)
            : base(trackBar)
        {
            if (trackBar == null)
                throw new Exception("You have to pass the TrackBar object in the constructor!");

            _trackBar = trackBar;
        }

        #endregion Constructor

        #region ScaleFields

        /// <summary>
        /// Gets the scale field layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetScaleFieldLayoutRectangle()
        {
            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                int offset = GetOffset();

                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(0, offset, _trackBar.Width, _trackBar.ScaleFieldMaxHeight);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(0, _trackBar.Height - offset - _trackBar.ScaleFieldMaxHeight, _trackBar.Width, _trackBar.ScaleFieldMaxHeight);
                        break;
                }
            }

            return Rectangle.Empty;
        }

        /// <summary>
        /// Renders the scale fields.
        /// </summary>
        /// <param name="g">The g.</param>
        public override void RenderScaleFields(Graphics g)
        {
            int fieldCount = CalculateScaleFieldCount(_trackBar);
            Dictionary<int, int> fieldHeights = CalculateScaleFieldHeights(_trackBar, fieldCount);

            int totalScaleWidth = CalculateTotalScaleWidth(_trackBar, fieldCount);
            int scaleOffset = (_trackBar.Width - totalScaleWidth) / 2;

            foreach (var fieldHeight in fieldHeights)
            {
                int fieldNumber = fieldHeight.Key;

                int fieldValue = fieldHeights[fieldNumber];
                int fieldX = scaleOffset + (fieldNumber * (_trackBar.ScaleFieldWidth + _trackBar.ScaleFieldSpacing));
                int fieldY = 0;

                if (_trackBar.ScaleFieldPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop)
                    fieldY = _trackBar.ScaleFieldMaxHeight - fieldValue;

                Rectangle fieldRectangle = new Rectangle((int)g.ClipBounds.X + fieldX, (int)g.ClipBounds.Y + fieldY, _trackBar.ScaleFieldWidth, fieldValue);

                using (Brush fieldBrush = new SolidBrush(_trackBar.ScaleFieldColor))
                {
                    g.FillRectangle(fieldBrush, fieldRectangle);
                }
            }
        }

        #endregion ScaleFields

        #region Ticks

        /// <summary>
        /// Gets the tick layout rectangle.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetTickLayoutRectangle(ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position)
        {
            int tickFieldSize = GetTickFieldSize();
            int offset = GetOffset();

            int tickFieldLength = _trackBar.Width - 4;
            int lengthOffset = 0;

            if (_trackBar.IsSliderVisible)
            {
                tickFieldLength -= _trackBar.SliderButtonSize.Width;
                lengthOffset = _trackBar.SliderButtonSize.Width / 2;
            }

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                switch (position)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(lengthOffset + 2, offset, tickFieldLength, tickFieldSize);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(lengthOffset + 2, _trackBar.Height - offset - tickFieldSize - 1, tickFieldLength, tickFieldSize);
                        break;
                }
            }

            return Rectangle.Empty;
        }

        /// <summary>
        /// Renders the ticks.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="position">The position.</param>
        public override void RenderTicks(Graphics g, ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position)
        {
            int pixelValueZero = ValueToPixelValue(0);
            int pixelPos = pixelValueZero;

            if (_trackBar.TickWidth > 0)
                pixelPos = pixelPos - (_trackBar.TickWidth / 2);

            Rectangle zeroRectangle;

            if (_trackBar.TickEmphasizeMinMaxAndZero)
            {
                zeroRectangle = new Rectangle(pixelPos, (int)g.ClipBounds.Y, _trackBar.TickWidth, _trackBar.TickEmphasizedHeight);

                using (Brush zeroBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                {
                    g.FillRectangle(zeroBrush, zeroRectangle);
                }
            }
            else
            {
                zeroRectangle = new Rectangle(pixelPos, (int)g.ClipBounds.Y, _trackBar.TickWidth, _trackBar.TickHeight);

                using (Brush zeroBrush = new SolidBrush(_trackBar.TickColor))
                {
                    g.FillRectangle(zeroBrush, zeroRectangle);
                }
            }

            Rectangle tickRectangle;
            bool tickIsEmphasized;
            int tickHeight;
            int offsetY;

            if (_trackBar.Minimum == 0 || (_trackBar.Minimum < 0 && _trackBar.Maximum > 0))
            {
                //Paint ticks from 0 up to maximum

                int pixelPosCurrent = pixelPos;
                int pixelPosNext = pixelPosCurrent + _trackBar.TickWidth + _trackBar.TickSpacing;
                int nextTickMaxWidth = pixelPosNext + _trackBar.TickWidth;
                bool nextTickFits = nextTickMaxWidth <= (int)(g.ClipBounds.X + g.ClipBounds.Width) - 1;

                while (nextTickFits)
                {
                    pixelPosCurrent = pixelPosNext;
                    pixelPosNext = pixelPosCurrent + _trackBar.TickWidth + _trackBar.TickSpacing;
                    nextTickMaxWidth = pixelPosNext + _trackBar.TickWidth;
                    nextTickFits = nextTickMaxWidth <= (int)(g.ClipBounds.X + g.ClipBounds.Width) - 1;

                    tickIsEmphasized = _trackBar.TickEmphasizeMinMaxAndZero && !nextTickFits;

                    tickHeight = tickIsEmphasized ? _trackBar.TickEmphasizedHeight : _trackBar.TickHeight;
                    offsetY = 0;

                    if (!tickIsEmphasized)
                    {
                        if (_trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Center)
                        {
                            offsetY = (int)((g.ClipBounds.Height - tickHeight) / 2);
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near))
                        {
                            offsetY = 0;
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far))
                        {
                            offsetY = (int)g.ClipBounds.Height - tickHeight;
                        }
                    }

                    tickRectangle = new Rectangle(pixelPosCurrent, (int)g.ClipBounds.Y + offsetY, _trackBar.TickWidth, tickHeight);

                    if (tickIsEmphasized)
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                    else
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                }
            }

            if (_trackBar.Maximum == 0 || (_trackBar.Minimum < 0 && _trackBar.Maximum > 0))
            {
                //Paint ticks from 0 down to minimum

                int pixelPosCurrent = pixelPos;
                int pixelPosNext = pixelPosCurrent - _trackBar.TickWidth - _trackBar.TickSpacing;
                int nextTickMaxWidth = pixelPosNext - _trackBar.TickWidth;
                bool nextTickFits = nextTickMaxWidth >= (int)g.ClipBounds.X;

                while (nextTickFits)
                {
                    pixelPosCurrent = pixelPosNext;
                    pixelPosNext = pixelPosCurrent - _trackBar.TickWidth - _trackBar.TickSpacing;
                    nextTickMaxWidth = pixelPosNext - _trackBar.TickWidth;
                    nextTickFits = nextTickMaxWidth >= (int)g.ClipBounds.X;

                    tickIsEmphasized = _trackBar.TickEmphasizeMinMaxAndZero && !nextTickFits;

                    tickHeight = tickIsEmphasized ? _trackBar.TickEmphasizedHeight : _trackBar.TickHeight;
                    offsetY = 0;

                    if (!tickIsEmphasized)
                    {
                        if (_trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Center)
                        {
                            offsetY = (int)((g.ClipBounds.Height - tickHeight) / 2);
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near))
                        {
                            offsetY = 0;
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far))
                        {
                            offsetY = (int)g.ClipBounds.Height - tickHeight;
                        }
                    }

                    tickRectangle = new Rectangle(pixelPosCurrent, (int)g.ClipBounds.Y + offsetY, _trackBar.TickWidth, tickHeight);

                    if (tickIsEmphasized)
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                    else
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                }
            }
        }

        #endregion Ticks

        #region Track

        /// <summary>
        /// Gets the track layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetTrackLayoutRectangle()
        {
            const int trackThickness = 5;

            int totalTrackThickness = GetTrackFieldSize();
            int offset = GetOffset();
            int trackOffset = (totalTrackThickness - trackThickness) / 2;

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(0, offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar + trackOffset, _trackBar.Width, trackThickness);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(0, offset + trackOffset, _trackBar.Width, trackThickness);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(0, offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar + trackOffset, _trackBar.Width, trackThickness);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(0, offset + trackOffset, _trackBar.Width, trackThickness);
                        break;
                }
            }

            return new Rectangle(0, (_trackBar.Height - trackThickness) / 2, _trackBar.Width, trackThickness);
        }

        /// <summary>
        /// Renders the track.
        /// </summary>
        /// <param name="g">The g.</param>
        public override void RenderTrack(Graphics g)
        {
            //Draw Track Border
            Color trackUpperBorderColor = Color.FromArgb(55, 60, 62);

            using (Brush trackUpperBrush = new SolidBrush(trackUpperBorderColor))
            {
                using (Pen trackUpperPen = new Pen(trackUpperBrush))
                {
                    g.DrawLine(trackUpperPen, g.ClipBounds.X + 1, g.ClipBounds.Y, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y);
                    g.FillRectangle(trackUpperBrush, g.ClipBounds.X, g.ClipBounds.Y + 1, 1, 1);
                    g.FillRectangle(trackUpperBrush, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + 1, 1, 1);
                }
            }

            Color trackUpperInnerBorderColor = Color.FromArgb(35, 38, 41);

            using (Brush trackUpperInnerBrush = new SolidBrush(trackUpperInnerBorderColor))
            {
                using (Pen trackUpperInnerPen = new Pen(trackUpperInnerBrush))
                {
                    g.DrawLine(trackUpperInnerPen, g.ClipBounds.X + 1, g.ClipBounds.Y + 1, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + 1);
                }
            }

            Color trackLowerBorderColor = Color.FromArgb(60, 65, 66);

            using (Brush trackLowerBrush = new SolidBrush(trackLowerBorderColor))
            {
                using (Pen trackLowerPen = new Pen(trackLowerBrush))
                {
                    g.DrawLine(trackLowerPen, g.ClipBounds.X + 1, g.ClipBounds.Y + g.ClipBounds.Height - 1, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + g.ClipBounds.Height - 1);
                    g.FillRectangle(trackLowerBrush, g.ClipBounds.X, g.ClipBounds.Y + g.ClipBounds.Height - 3, 1, 2);
                    g.FillRectangle(trackLowerBrush, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + g.ClipBounds.Height - 3, 1, 2);
                }
            }

            Color innerFieldColor = Color.FromArgb(20, 21, 21);

            using (Brush innerFieldBrush = new SolidBrush(innerFieldColor))
            {
                g.FillRectangle(innerFieldBrush, g.ClipBounds.X + 1, g.ClipBounds.Y + 2, 1, 2);
                g.FillRectangle(innerFieldBrush, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + 2, 1, 2);
            }

            //Fill Empty Track
            Color emptyTrackColor = _trackBar.EmptyTrackColor;

            using (Brush emptyTrackBrush = new SolidBrush(emptyTrackColor))
            {
                g.FillRectangle(emptyTrackBrush, g.ClipBounds.X + 2, g.ClipBounds.Y + 2, g.ClipBounds.Width - 4, 2);
            }

            if (_trackBar.TrackStyle != ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.None)
            {
                //Paint Track

                int startPixel = 0;
                int endPixel = 0;

                Rectangle trackRectangle = GetTrackLayoutRectangle();

                if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromLeftOrTop || (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero && _trackBar.Minimum == 0))
                {
                    startPixel = 2;
                    endPixel = ValueToPixelValue(_trackBar.Value);
                }
                else if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromRightOrBottom || (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero && _trackBar.Maximum == 0))
                {
                    startPixel = ValueToPixelValue(_trackBar.Value);
                    endPixel = trackRectangle.Width - 3;
                }
                else if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero)
                {
                    startPixel = ValueToPixelValue(0);
                    endPixel = ValueToPixelValue(_trackBar.Value);
                }

                if (startPixel != endPixel)
                {
                    using (Brush upperTrackBrush = new SolidBrush(_trackBar.TrackUpperColor))
                    {
                        using (Pen upperTrackPen = new Pen(upperTrackBrush))
                        {
                            g.DrawLine(upperTrackPen, g.ClipBounds.X + startPixel, g.ClipBounds.Y + 2, g.ClipBounds.X + endPixel, g.ClipBounds.Y + 2);
                        }
                    }

                    using (Brush lowerTrackBrush = new SolidBrush(_trackBar.TrackLowerColor))
                    {
                        using (Pen lowerTrackPen = new Pen(lowerTrackBrush))
                        {
                            g.DrawLine(lowerTrackPen, g.ClipBounds.X + startPixel, g.ClipBounds.Y + 3, g.ClipBounds.X + endPixel, g.ClipBounds.Y + 3);
                        }
                    }
                }
            }
        }

        #endregion Track

        #region ClickArea

        /// <summary>
        /// Gets the click rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetClickRectangle()
        {
            int totalTrackThickness = GetTrackFieldSize();
            int offset = GetOffset();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(2, offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar, _trackBar.Width - 4, totalTrackThickness);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(2, offset, _trackBar.Width - 4, totalTrackThickness);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(2, offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar, _trackBar.Width - 4, totalTrackThickness);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(2, offset, _trackBar.Width - 4, totalTrackThickness);
                        break;
                }
            }

            return new Rectangle(2, ((_trackBar.Height - totalTrackThickness) / 2), _trackBar.Width - 4, totalTrackThickness);
        }

        #endregion ClickArea

        #region Slider

        /// <summary>
        /// Gets the slider layout rectangle.
        /// </summary>
        /// <param name="sliderValue">The slider value.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetSliderLayoutRectangle(int sliderValue)
        {
            if (!_trackBar.IsSliderVisible)
                return Rectangle.Empty;

            int sliderPixelValue = ValueToPixelValue(sliderValue);
            double dblPixelValue = ((double)sliderPixelValue - ((double)_trackBar.SliderButtonSize.Width / 2));
            int pixelValue = (int)dblPixelValue;

            int offset = GetOffset();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(pixelValue, offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(pixelValue, offset, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(pixelValue, offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(pixelValue, offset, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                }
            }

            return new Rectangle(pixelValue, (_trackBar.Height - _trackBar.SliderButtonSize.Height) / 2, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
        }

        #endregion Slider

        #region Helper Methods

        /// <summary>
        /// Gets the size of the track field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTrackFieldSize()
        {
            return _trackBar.SliderButtonSize.Height;
        }

        /// <summary>
        /// Gets the size of the tick field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTickFieldSize()
        {
            int tickFieldSize = _trackBar.TickHeight;

            if (_trackBar.TickEmphasizeMinMaxAndZero && _trackBar.TickEmphasizedHeight > _trackBar.TickHeight)
                tickFieldSize = _trackBar.TickEmphasizedHeight;

            return tickFieldSize;
        }

        /// <summary>
        /// Gets the total size of the field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTotalFieldSize()
        {
            int totalSize = GetTrackFieldSize();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                totalSize += AcceptableSpaceBetweenScaleAndTrackBar;
                totalSize += _trackBar.ScaleFieldMaxHeight;
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickFieldSize = GetTickFieldSize();

                totalSize += AcceptableSpaceBetweenTickAndTrackBar;
                totalSize += tickFieldSize;

                if (_trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both)
                {
                    totalSize += AcceptableSpaceBetweenTickAndTrackBar;
                    totalSize += tickFieldSize;
                }
            }

            return totalSize;
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetOffset()
        {
            int totalSize = GetTotalFieldSize();
            return GetOffset(totalSize);
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <param name="totalSize">The total size.</param>
        /// <returns>System.Int32.</returns>
        public override int GetOffset(int totalSize)
        {
            int offset = ((_trackBar.Height - totalSize) / 2);
            return offset;
        }

        #endregion Helper Methods

        #region Value Converters

        /// <summary>
        /// Values to pixel value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public override int ValueToPixelValue(int value)
        {
            Rectangle trackRectangle = GetTrackLayoutRectangle();
            int maxPixelCount = trackRectangle.Width - 4; //Adjust for track border
            int maxPixelValue = maxPixelCount - 1; //Adjust for pixel array

            int valueOffset = _trackBar.Minimum;
            int adjustedMaxValue = _trackBar.Maximum - valueOffset;

            int adjustedValue = value - valueOffset;

            int pixelValue = 0;
            double dblPixelValue = 0;
            double factor = 0;

            if (!_trackBar.IsSliderVisible)
            {
                factor = ((double)maxPixelValue / (double)adjustedMaxValue);
                dblPixelValue = factor * (double)adjustedValue;
            }
            else
            {
                int trackButtonPixelSize = _trackBar.SliderButtonSize.Width;
                double trackButtonOffset = (double)trackButtonPixelSize / 2;

                int adjustedMaxPixelValue = maxPixelValue - trackButtonPixelSize;

                factor = ((double)adjustedMaxPixelValue / (double)adjustedMaxValue);
                dblPixelValue = factor * (double)adjustedValue;
                dblPixelValue += (double)trackButtonOffset;
            }

            pixelValue = (int)Math.Round(dblPixelValue, 0);

            if (pixelValue < 0)
                pixelValue = 0;

            if (pixelValue > maxPixelCount)
                pixelValue = maxPixelCount;

            pixelValue += 2; //Adjust for track border

            return pixelValue;
        }

        /// <summary>
        /// Pixels the value to value.
        /// </summary>
        /// <param name="pixelValue">The pixel value.</param>
        /// <returns>System.Int32.</returns>
        public override int PixelValueToValue(int pixelValue)
        {
            pixelValue -= 2; //Adjust for track border

            Rectangle trackRectangle = GetTrackLayoutRectangle();
            int maxPixelCount = trackRectangle.Width - 4; //Adjust for track border
            int maxPixelValue = maxPixelCount - 1; //Adjust for pixel array
            maxPixelValue = (int)((int)((double)maxPixelValue / 2) * 2); //Make value equal number

            int valueOffset = _trackBar.Minimum;
            int adjustedMaxValue = _trackBar.Maximum - valueOffset;

            int returnValue = 0;
            double dblReturnValue = 0;
            double factor = 0;

            if (!_trackBar.IsSliderVisible)
            {
                factor = ((double)adjustedMaxValue / (double)maxPixelValue);
                dblReturnValue = factor * (double)pixelValue;
            }
            else
            {
                int trackButtonPixelSize = _trackBar.SliderButtonSize.Width;
                int trackButtonOffset = trackButtonPixelSize / 2;

                int adjustedMaxPixelValue = maxPixelValue - trackButtonPixelSize;
                pixelValue -= trackButtonOffset;

                factor = ((double)adjustedMaxValue / (double)adjustedMaxPixelValue);
                dblReturnValue = factor * (double)pixelValue;
            }

            returnValue = (int)Math.Round(dblReturnValue, 0);

            returnValue += valueOffset;

            if (returnValue < _trackBar.Minimum)
                returnValue = _trackBar.Minimum;

            if (returnValue > _trackBar.Maximum)
                returnValue = _trackBar.Maximum;

            return returnValue;
        }

        #endregion Value Converters
    }
    #endregion

    #region VerticalWinampTrackBarRenderer
    /// <summary>
    /// Class ZeroitVerticalWinampTrackBarRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitWinampTrackBarRenderer" />
    public class ZeroitVerticalWinampTrackBarRenderer : ZeroitWinampTrackBarRenderer
    {
        /// <summary>
        /// The track bar
        /// </summary>
        private ZeroitWinampTrackBar _trackBar;
        /// <summary>
        /// The acceptable space between scale and track bar
        /// </summary>
        private const int AcceptableSpaceBetweenScaleAndTrackBar = 3;
        /// <summary>
        /// The acceptable space between tick and track bar
        /// </summary>
        private const int AcceptableSpaceBetweenTickAndTrackBar = 2;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitVerticalWinampTrackBarRenderer"/> class.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <exception cref="System.Exception">You have to pass the TrackBar object in the constructor!</exception>
        public ZeroitVerticalWinampTrackBarRenderer(ZeroitWinampTrackBar trackBar)
            : base(trackBar)
        {
            if (trackBar == null)
                throw new Exception("You have to pass the TrackBar object in the constructor!");

            _trackBar = trackBar;
        }

        #endregion Constructor

        #region ScaleFields

        /// <summary>
        /// Gets the scale field layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetScaleFieldLayoutRectangle()
        {
            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                int offset = GetOffset();

                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(offset, 0, _trackBar.ScaleFieldMaxHeight, _trackBar.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(_trackBar.Width - offset - _trackBar.ScaleFieldMaxHeight, 0, _trackBar.ScaleFieldMaxHeight, _trackBar.Height);
                        break;
                }
            }

            return Rectangle.Empty;
        }

        /// <summary>
        /// Renders the scale fields.
        /// </summary>
        /// <param name="g">The g.</param>
        public override void RenderScaleFields(Graphics g)
        {
            int fieldCount = CalculateScaleFieldCount(_trackBar);
            Dictionary<int, int> fieldHeights = CalculateScaleFieldHeights(_trackBar, fieldCount);

            int totalScaleHeight = CalculateTotalScaleWidth(_trackBar, fieldCount);
            int scaleOffset = (_trackBar.Height - totalScaleHeight) / 2;

            foreach (var fieldHeight in fieldHeights)
            {
                int fieldNumber = fieldCount - fieldHeight.Key - 1;

                int fieldValue = fieldHeights[fieldHeight.Key];
                int fieldX = 0;
                int fieldY = scaleOffset + (fieldNumber * (_trackBar.ScaleFieldWidth + _trackBar.ScaleFieldSpacing));

                if (_trackBar.ScaleFieldPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop)
                    fieldX = _trackBar.ScaleFieldMaxHeight - fieldValue;

                Rectangle fieldRectangle = new Rectangle((int)g.ClipBounds.X + fieldX, (int)g.ClipBounds.Y + fieldY, fieldValue, _trackBar.ScaleFieldWidth);

                using (Brush fieldBrush = new SolidBrush(_trackBar.ScaleFieldColor))
                {
                    g.FillRectangle(fieldBrush, fieldRectangle);
                }
            }
        }

        #endregion ScaleFields

        #region Ticks

        /// <summary>
        /// Gets the tick layout rectangle.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetTickLayoutRectangle(ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position)
        {
            int tickFieldSize = GetTickFieldSize();
            int offset = GetOffset();

            int tickFieldLength = _trackBar.Height - 4;
            int lengthOffset = 0;

            if (_trackBar.IsSliderVisible)
            {
                tickFieldLength -= _trackBar.SliderButtonSize.Height;
                lengthOffset = _trackBar.SliderButtonSize.Height / 2;
            }

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                switch (position)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(offset, lengthOffset + 2, tickFieldSize, tickFieldLength);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(_trackBar.Width - offset - tickFieldSize - 1, lengthOffset + 2, tickFieldSize, tickFieldLength);
                        break;
                }
            }

            return Rectangle.Empty;
        }

        /// <summary>
        /// Renders the ticks.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="position">The position.</param>
        public override void RenderTicks(Graphics g, ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position)
        {
            int pixelValueZero = ValueToPixelValue(0);
            int pixelPos = pixelValueZero;

            if (_trackBar.TickWidth > 0)
                pixelPos = pixelPos - (_trackBar.TickWidth / 2);

            Rectangle zeroRectangle;

            if (_trackBar.TickEmphasizeMinMaxAndZero)
            {
                zeroRectangle = new Rectangle((int)g.ClipBounds.X, pixelPos, _trackBar.TickEmphasizedHeight, _trackBar.TickWidth);

                using (Brush zeroBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                {
                    g.FillRectangle(zeroBrush, zeroRectangle);
                }
            }
            else
            {
                zeroRectangle = new Rectangle((int)g.ClipBounds.X, pixelPos, _trackBar.TickHeight, _trackBar.TickWidth);

                using (Brush zeroBrush = new SolidBrush(_trackBar.TickColor))
                {
                    g.FillRectangle(zeroBrush, zeroRectangle);
                }
            }

            Rectangle tickRectangle;
            bool tickIsEmphasized;
            int tickHeight;
            int offsetX;

            if (_trackBar.Minimum == 0 || (_trackBar.Minimum < 0 && _trackBar.Maximum > 0))
            {
                //Paint ticks from 0 up to maximum

                int pixelPosCurrent = pixelPos;
                int pixelPosNext = pixelPosCurrent - _trackBar.TickWidth - _trackBar.TickSpacing;
                int nextTickMaxWidth = pixelPosNext - _trackBar.TickWidth;
                bool nextTickFits = nextTickMaxWidth >= (int)g.ClipBounds.Y;

                while (nextTickFits)
                {
                    pixelPosCurrent = pixelPosNext;
                    pixelPosNext = pixelPosCurrent - _trackBar.TickWidth - _trackBar.TickSpacing;
                    nextTickMaxWidth = pixelPosNext - _trackBar.TickWidth;
                    nextTickFits = nextTickMaxWidth >= (int)g.ClipBounds.Y;

                    tickIsEmphasized = _trackBar.TickEmphasizeMinMaxAndZero && !nextTickFits;

                    tickHeight = tickIsEmphasized ? _trackBar.TickEmphasizedHeight : _trackBar.TickHeight;
                    offsetX = 0;

                    if (!tickIsEmphasized)
                    {
                        if (_trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Center)
                        {
                            offsetX = (int)((g.ClipBounds.Width - tickHeight) / 2);
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near))
                        {
                            offsetX = 0;
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far))
                        {
                            offsetX = (int)g.ClipBounds.Width - tickHeight;
                        }
                    }

                    tickRectangle = new Rectangle((int)g.ClipBounds.X + offsetX, pixelPosCurrent, tickHeight, _trackBar.TickWidth);

                    if (tickIsEmphasized)
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                    else
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                }
            }


            if (_trackBar.Maximum == 0 || (_trackBar.Minimum < 0 && _trackBar.Maximum > 0))
            {
                //Paint ticks from 0 down to minimum

                int pixelPosCurrent = pixelPos;
                int pixelPosNext = pixelPosCurrent + _trackBar.TickWidth + _trackBar.TickSpacing;
                int nextTickMaxWidth = pixelPosNext + _trackBar.TickWidth;
                bool nextTickFits = nextTickMaxWidth <= (int)(g.ClipBounds.Y + g.ClipBounds.Height) - 1;

                while (nextTickFits)
                {
                    pixelPosCurrent = pixelPosNext;
                    pixelPosNext = pixelPosCurrent + _trackBar.TickWidth + _trackBar.TickSpacing;
                    nextTickMaxWidth = pixelPosNext + _trackBar.TickWidth;
                    nextTickFits = nextTickMaxWidth <= (int)(g.ClipBounds.Y + g.ClipBounds.Height) - 1;

                    tickIsEmphasized = _trackBar.TickEmphasizeMinMaxAndZero && !nextTickFits;

                    tickHeight = tickIsEmphasized ? _trackBar.TickEmphasizedHeight : _trackBar.TickHeight;
                    offsetX = 0;

                    if (!tickIsEmphasized)
                    {
                        if (_trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Center)
                        {
                            offsetX = (int)((g.ClipBounds.Width - tickHeight) / 2);
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near))
                        {
                            offsetX = 0;
                        }
                        else if ((position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Near) ||
                                 (position == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom && _trackBar.TickAlignment == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickAlignment.Far))
                        {
                            offsetX = (int)g.ClipBounds.Width - tickHeight;
                        }
                    }

                    tickRectangle = new Rectangle((int)g.ClipBounds.X + offsetX, pixelPosCurrent, tickHeight, _trackBar.TickWidth);

                    if (tickIsEmphasized)
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickEmphasizedColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                    else
                    {
                        using (Brush tickBrush = new SolidBrush(_trackBar.TickColor))
                        {
                            g.FillRectangle(tickBrush, tickRectangle);
                        }
                    }
                }
            }
        }

        #endregion Ticks

        #region Track

        /// <summary>
        /// Gets the track layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetTrackLayoutRectangle()
        {
            const int trackThickness = 5;

            int totalTrackThickness = GetTrackFieldSize();
            int offset = GetOffset();
            int trackOffset = (totalTrackThickness - trackThickness) / 2;

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar + trackOffset, 0, trackThickness, _trackBar.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(offset + trackOffset, 0, trackThickness, _trackBar.Height);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar + trackOffset, 0, trackThickness, _trackBar.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(offset + trackOffset, 0, trackThickness, _trackBar.Height);
                        break;
                }
            }

            return new Rectangle((_trackBar.Width - trackThickness) / 2, 0, trackThickness, _trackBar.Height);
        }

        /// <summary>
        /// Renders the track.
        /// </summary>
        /// <param name="g">The g.</param>
        public override void RenderTrack(Graphics g)
        {
            //Draw Track Border
            Color trackUpperBorderColor = Color.FromArgb(55, 60, 62);

            using (Brush trackUpperBrush = new SolidBrush(trackUpperBorderColor))
            {
                using (Pen trackUpperPen = new Pen(trackUpperBrush))
                {
                    g.DrawLine(trackUpperPen, g.ClipBounds.X + 1, g.ClipBounds.Y, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y);
                }
            }

            Color trackUpperInnerBorderColor = Color.FromArgb(35, 38, 41);

            using (Brush trackUpperInnerBrush = new SolidBrush(trackUpperInnerBorderColor))
            {
                using (Pen trackUpperInnerPen = new Pen(trackUpperInnerBrush))
                {
                    g.DrawLine(trackUpperInnerPen, g.ClipBounds.X + 1, g.ClipBounds.Y + 1, g.ClipBounds.X + 1, g.ClipBounds.Y + g.ClipBounds.Height - 2);
                }
            }

            Color trackLowerBorderColor = Color.FromArgb(60, 65, 66);

            using (Brush trackLowerBrush = new SolidBrush(trackLowerBorderColor))
            {
                using (Pen trackLowerPen = new Pen(trackLowerBrush))
                {
                    g.DrawLine(trackLowerPen, g.ClipBounds.X + 1, g.ClipBounds.Y + g.ClipBounds.Height - 1, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + g.ClipBounds.Height - 1);
                }
            }

            RectangleF linearGradientRectangle = g.ClipBounds;
            linearGradientRectangle.Y += 2;
            linearGradientRectangle.Height -= 4;

            using (Brush trackSideBorderBrush = new LinearGradientBrush(linearGradientRectangle, trackUpperBorderColor, trackLowerBorderColor, LinearGradientMode.Vertical))
            {
                using (Pen trackSideBorderPen = new Pen(trackSideBorderBrush))
                {
                    g.DrawLine(trackSideBorderPen, g.ClipBounds.X, g.ClipBounds.Y + 1, g.ClipBounds.X, g.ClipBounds.Y + g.ClipBounds.Height - 2);
                    g.DrawLine(trackSideBorderPen, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + 1, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + g.ClipBounds.Height - 2);
                }
            }

            Color innerFieldColor = Color.FromArgb(20, 21, 21);

            using (Brush innerFieldBrush = new SolidBrush(innerFieldColor))
            {
                g.FillRectangle(innerFieldBrush, g.ClipBounds.X + 2, g.ClipBounds.Y + 1, 2, 1);
                g.FillRectangle(innerFieldBrush, g.ClipBounds.X + 2, g.ClipBounds.Y + g.ClipBounds.Height - 2, 2, 1);
            }

            //Fill Empty Track
            Color emptyTrackColor = _trackBar.EmptyTrackColor;

            using (Brush emptyTrackBrush = new SolidBrush(emptyTrackColor))
            {
                g.FillRectangle(emptyTrackBrush, g.ClipBounds.X + 2, g.ClipBounds.Y + 2, 2, g.ClipBounds.Height - 4);
            }

            if (_trackBar.TrackStyle != ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.None)
            {
                //Paint Track

                int startPixel = 0;
                int endPixel = 0;

                Rectangle trackRectangle = GetTrackLayoutRectangle();

                if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromLeftOrTop || (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero && _trackBar.Maximum == 0))
                {
                    startPixel = 2;
                    endPixel = ValueToPixelValue(_trackBar.Value);
                }
                else if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromRightOrBottom || (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero && _trackBar.Minimum == 0))
                {
                    startPixel = ValueToPixelValue(_trackBar.Value);
                    endPixel = trackRectangle.Height - 3;
                }
                else if (_trackBar.TrackStyle == ZeroitWinampTrackBar.ZeroitWinampTrackBarTrackStyle.FromZero)
                {
                    startPixel = ValueToPixelValue(0);
                    endPixel = ValueToPixelValue(_trackBar.Value);
                }

                if (startPixel != endPixel)
                {
                    using (Brush upperTrackBrush = new SolidBrush(_trackBar.TrackUpperColor))
                    {
                        using (Pen upperTrackPen = new Pen(upperTrackBrush))
                        {
                            g.DrawLine(upperTrackPen, g.ClipBounds.X + 2, g.ClipBounds.Y + startPixel, g.ClipBounds.X + 2, g.ClipBounds.Y + endPixel);
                        }
                    }

                    using (Brush lowerTrackBrush = new SolidBrush(_trackBar.TrackLowerColor))
                    {
                        using (Pen lowerTrackPen = new Pen(lowerTrackBrush))
                        {
                            g.DrawLine(lowerTrackPen, g.ClipBounds.X + 3, g.ClipBounds.Y + startPixel, g.ClipBounds.X + 3, g.ClipBounds.Y + endPixel);
                        }
                    }
                }
            }
        }

        #endregion Track

        #region ClickArea

        /// <summary>
        /// Gets the click rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetClickRectangle()
        {
            int totalTrackThickness = GetTrackFieldSize();
            int offset = GetOffset();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar, 2, totalTrackThickness, _trackBar.Height - 4);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(offset, 2, totalTrackThickness, _trackBar.Height - 4);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar, 2, totalTrackThickness, _trackBar.Height - 4);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(offset, 2, totalTrackThickness, _trackBar.Height - 4);
                        break;
                }
            }

            return new Rectangle((_trackBar.Width - totalTrackThickness) / 2, 0, totalTrackThickness, _trackBar.Height - 4);
        }

        #endregion ClickArea

        #region Slider

        /// <summary>
        /// Gets the slider layout rectangle.
        /// </summary>
        /// <param name="sliderValue">The slider value.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetSliderLayoutRectangle(int sliderValue)
        {
            if (!_trackBar.IsSliderVisible)
                return Rectangle.Empty;

            int sliderPixelValue = ValueToPixelValue(sliderValue);
            double dblPixelValue = ((double)sliderPixelValue - ((double)_trackBar.SliderButtonSize.Height / 2));
            int pixelValue = (int)dblPixelValue;

            int offset = GetOffset();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                switch (_trackBar.ScaleFieldPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop:
                        return new Rectangle(offset + _trackBar.ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar, pixelValue, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleFieldPosition.RightOrBottom:
                        return new Rectangle(offset, pixelValue, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickHeight = GetTickFieldSize();

                switch (_trackBar.TickPosition)
                {
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both:
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop:
                        return new Rectangle(offset + tickHeight + AcceptableSpaceBetweenTickAndTrackBar, pixelValue, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                    case ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom:
                        return new Rectangle(offset, pixelValue, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
                        break;
                }
            }

            return new Rectangle((_trackBar.Width - _trackBar.SliderButtonSize.Width) / 2, pixelValue, _trackBar.SliderButtonSize.Width, _trackBar.SliderButtonSize.Height);
        }

        #endregion Slider

        #region Helper Methods

        /// <summary>
        /// Gets the size of the track field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTrackFieldSize()
        {
            return _trackBar.SliderButtonSize.Width;
        }

        /// <summary>
        /// Gets the size of the tick field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTickFieldSize()
        {
            int tickFieldSize = _trackBar.TickHeight;

            if (_trackBar.TickEmphasizeMinMaxAndZero && _trackBar.TickEmphasizedHeight > _trackBar.TickHeight)
                tickFieldSize = _trackBar.TickEmphasizedHeight;

            return tickFieldSize;
        }

        /// <summary>
        /// Gets the total size of the field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetTotalFieldSize()
        {
            int totalSize = GetTrackFieldSize();

            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                totalSize += AcceptableSpaceBetweenScaleAndTrackBar;
                totalSize += _trackBar.ScaleFieldMaxHeight;
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                int tickFieldSize = GetTickFieldSize();

                totalSize += AcceptableSpaceBetweenTickAndTrackBar;
                totalSize += tickFieldSize;

                if (_trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both)
                {
                    totalSize += AcceptableSpaceBetweenTickAndTrackBar;
                    totalSize += tickFieldSize;
                }
            }

            return totalSize;
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetOffset()
        {
            int totalSize = GetTotalFieldSize();
            return GetOffset(totalSize);
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <param name="totalSize">The total size.</param>
        /// <returns>System.Int32.</returns>
        public override int GetOffset(int totalSize)
        {
            int offset = ((_trackBar.Width - totalSize) / 2);
            return offset;
        }

        #endregion Helper Methods

        #region Value Converters

        /// <summary>
        /// Values to pixel value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public override int ValueToPixelValue(int value)
        {
            Rectangle trackRectangle = GetTrackLayoutRectangle();
            int maxPixelCount = trackRectangle.Height - 4; //Adjust for track border
            int maxPixelValue = maxPixelCount - 1; //Adjust for pixel array

            int valueOffset = _trackBar.Minimum;
            int adjustedMaxValue = _trackBar.Maximum - valueOffset;

            int adjustedValue = value - valueOffset;

            int pixelValue = 0;
            double dblPixelValue = 0;
            double factor = 0;

            if (!_trackBar.IsSliderVisible)
            {
                factor = ((double)maxPixelValue / (double)adjustedMaxValue);
                dblPixelValue = factor * (double)adjustedValue;
            }
            else
            {
                int trackButtonPixelSize = _trackBar.SliderButtonSize.Height;
                double trackButtonOffset = (double)trackButtonPixelSize / 2;

                int adjustedMaxPixelValue = maxPixelValue - trackButtonPixelSize;

                factor = ((double)adjustedMaxPixelValue / (double)adjustedMaxValue);
                dblPixelValue = factor * (double)adjustedValue;
                dblPixelValue += (double)trackButtonOffset;
            }

            pixelValue = (int)((double)maxPixelValue - dblPixelValue); //Invert Y-axis

            if (pixelValue < 0)
                pixelValue = 0;

            if (pixelValue > maxPixelCount)
                pixelValue = maxPixelCount;

            pixelValue += 2; //Adjust for track border

            return pixelValue;
        }

        /// <summary>
        /// Pixels the value to value.
        /// </summary>
        /// <param name="pixelValue">The pixel value.</param>
        /// <returns>System.Int32.</returns>
        public override int PixelValueToValue(int pixelValue)
        {
            pixelValue -= 2; //Adjust for track border

            Rectangle trackRectangle = GetTrackLayoutRectangle();
            int maxPixelCount = trackRectangle.Height - 4; //Adjust for track border
            int maxPixelValue = maxPixelCount - 1; //Adjust for pixel array
            maxPixelValue = (int)((int)((double)maxPixelValue / 2) * 2); //Make value equal number

            int valueOffset = _trackBar.Minimum;
            int adjustedMaxValue = _trackBar.Maximum - valueOffset;

            int returnValue = 0;
            double dblReturnValue = 0;
            double factor = 0;

            pixelValue = maxPixelValue - pixelValue; //Invert Y-axis

            if (!_trackBar.IsSliderVisible)
            {
                factor = ((double)adjustedMaxValue / (double)maxPixelValue);
                dblReturnValue = factor * (double)pixelValue;
            }
            else
            {
                int trackButtonPixelSize = _trackBar.SliderButtonSize.Height;
                int trackButtonOffset = trackButtonPixelSize / 2;

                int adjustedMaxPixelCount = maxPixelValue - trackButtonPixelSize;
                pixelValue -= trackButtonOffset;

                factor = ((double)adjustedMaxValue / (double)adjustedMaxPixelCount);
                dblReturnValue = factor * (double)pixelValue;
            }

            returnValue = (int)Math.Round(dblReturnValue, 0);

            returnValue += valueOffset;

            if (returnValue < _trackBar.Minimum)
                returnValue = _trackBar.Minimum;

            if (returnValue > _trackBar.Maximum)
                returnValue = _trackBar.Maximum;

            return returnValue;
        }

        #endregion Value Converters
    }
    #endregion

    #region WinampScalePanel
    /// <summary>
    /// Class ZeroitWinampScalePanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxBitmap(typeof(Panel))]
    public class ZeroitWinampScalePanel : Panel
    {
        /// <summary>
        /// Enum representing the scale field locations
        /// </summary>
        public enum ScaleFieldLocations
        {
            /// <summary>
            /// The top or left
            /// </summary>
            TopOrLeft,
            /// <summary>
            /// The bottom or right
            /// </summary>
            BottomOrRight
        }

        /// <summary>
        /// Enum representing the scale field orientations
        /// </summary>
        public enum ScaleFieldOrientations
        {
            /// <summary>
            /// The right to left
            /// </summary>
            RightToLeft,
            /// <summary>
            /// The left to right
            /// </summary>
            LeftToRight,
            /// <summary>
            /// The horizontal middle out
            /// </summary>
            HorizontalMiddleOut,
            /// <summary>
            /// The top to bottom
            /// </summary>
            TopToBottom,
            /// <summary>
            /// The bottom to top
            /// </summary>
            BottomToTop,
            /// <summary>
            /// The vertical middle out
            /// </summary>
            VerticalMiddleOut
        }

        /// <summary>
        /// The minimum scale field height
        /// </summary>
        private int _minimumScaleFieldHeight = 2;

        /// <summary>
        /// The scale field color
        /// </summary>
        private Color _scaleFieldColor = Color.FromArgb(72, 76, 79);
        /// <summary>
        /// Gets or sets the color of the scale field.
        /// </summary>
        /// <value>The color of the scale field.</value>
        [Bindable(true)]
        [DefaultValue(typeof(Color), "72, 76, 79")]
        [Category("Appearance")]
        [Description("The color of the scale fields")]
        public Color ScaleFieldColor
        {
            get { return _scaleFieldColor; }
            set
            {
                _scaleFieldColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The scale field size
        /// </summary>
        private int _scaleFieldSize = 3;
        /// <summary>
        /// Gets or sets the size of the scale field.
        /// </summary>
        /// <value>The size of the scale field.</value>
        [Bindable(true)]
        [DefaultValue(3)]
        [Category("Appearance")]
        [Description("Gets or sets the size of the scale fields")]
        public int ScaleFieldSize
        {
            get { return _scaleFieldSize; }
            set
            {
                _scaleFieldSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The scale field spacing
        /// </summary>
        private int _scaleFieldSpacing = 1;
        /// <summary>
        /// Gets or sets the scale field spacing.
        /// </summary>
        /// <value>The scale field spacing.</value>
        [Bindable(true)]
        [DefaultValue(1)]
        [Category("Appearance")]
        [Description("Gets or sets the spacing between the scale fields")]
        public int ScaleFieldSpacing
        {
            get { return _scaleFieldSpacing; }
            set
            {
                _scaleFieldSpacing = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The scale field orientation
        /// </summary>
        private ScaleFieldOrientations _scaleFieldOrientation = ScaleFieldOrientations.LeftToRight;
        /// <summary>
        /// Gets or sets the scale field orientation.
        /// </summary>
        /// <value>The scale field orientation.</value>
        [Bindable(true)]
        [DefaultValue(typeof(ScaleFieldOrientations), "LeftToRight")]
        [Category("Appearance")]
        [Description("Gets or sets the orientation of the scale fields")]
        public ScaleFieldOrientations ScaleFieldOrientation
        {
            get { return _scaleFieldOrientation; }
            set
            {
                _scaleFieldOrientation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The scale field location
        /// </summary>
        private ScaleFieldLocations _scaleFieldLocation = ScaleFieldLocations.TopOrLeft;
        /// <summary>
        /// Gets or sets the scale field location.
        /// </summary>
        /// <value>The scale field location.</value>
        [Bindable(true)]
        [DefaultValue(typeof(ScaleFieldLocations), "TopOrLeft")]
        [Category("Appearance")]
        [Description("Gets or sets the location of the scale fields")]
        public ScaleFieldLocations ScaleFieldLocation
        {
            get { return _scaleFieldLocation; }
            set
            {
                _scaleFieldLocation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int scaleFieldCount;
            int scaleFieldOtherSizeEnd;
            int scaleFieldOtherSizeStart;
            int scaleFieldOffset = 0;
            bool evenScaleFieldCount = false;

            if (ScaleFieldOrientation == ScaleFieldOrientations.LeftToRight || ScaleFieldOrientation == ScaleFieldOrientations.RightToLeft || ScaleFieldOrientation == ScaleFieldOrientations.HorizontalMiddleOut)
            {
                scaleFieldCount = (int)Math.Floor(((double)Width + (double)ScaleFieldSpacing) / ((double)ScaleFieldSize + (double)ScaleFieldSpacing));
                scaleFieldOtherSizeEnd = Height;
                scaleFieldOtherSizeStart = _minimumScaleFieldHeight;

                if (ScaleFieldOrientation == ScaleFieldOrientations.HorizontalMiddleOut)
                {
                    scaleFieldOffset = (int)Math.Floor((decimal)scaleFieldCount / 2);
                    evenScaleFieldCount = ((2 * scaleFieldOffset) == scaleFieldCount);
                }

                for (int x = 0; x < scaleFieldCount; x++)
                {
                    int scaleFieldOtherSize;

                    if (ScaleFieldOrientation != ScaleFieldOrientations.HorizontalMiddleOut)
                    {
                        scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)x / (double)scaleFieldCount));
                    }
                    else
                    {
                        if (evenScaleFieldCount)
                        {
                            if (x < scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (scaleFieldOffset - x)) / (double)scaleFieldCount));
                            }
                            else
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (x - scaleFieldOffset + 1)) / (double)scaleFieldCount));
                            }
                        }
                        else
                        {
                            if (x < scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (scaleFieldOffset - x)) / (double)scaleFieldCount));
                            }
                            else if (x == scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart;
                            }
                            else
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (x - scaleFieldOffset)) / (double)scaleFieldCount));
                            }
                        }
                    }

                    Size scaleFieldSize = new Size(ScaleFieldSize, scaleFieldOtherSize);

                    int scaleFieldXPos;

                    if (ScaleFieldOrientation == ScaleFieldOrientations.LeftToRight || ScaleFieldOrientation == ScaleFieldOrientations.HorizontalMiddleOut)
                        scaleFieldXPos = x * (ScaleFieldSize + ScaleFieldSpacing);
                    else
                        scaleFieldXPos = Width - (x * (ScaleFieldSize + ScaleFieldSpacing) + ScaleFieldSize);

                    int scaleFieldYPos;

                    if (ScaleFieldLocation == ScaleFieldLocations.TopOrLeft)
                        scaleFieldYPos = scaleFieldOtherSizeEnd - scaleFieldOtherSize;
                    else
                        scaleFieldYPos = 0;

                    Point scaleFieldLocation = new Point(scaleFieldXPos, scaleFieldYPos);

                    Rectangle scaleFieldRectangle = new Rectangle(scaleFieldLocation, scaleFieldSize);

                    using (Brush scaleFieldBrush = new SolidBrush(ScaleFieldColor))
                    {
                        e.Graphics.FillRectangle(scaleFieldBrush, scaleFieldRectangle);
                    }
                }
            }
            else
            {
                scaleFieldCount = (int)Math.Floor(((double)Height + (double)ScaleFieldSpacing) / ((double)ScaleFieldSize + (double)ScaleFieldSpacing));
                scaleFieldOtherSizeEnd = Width;
                scaleFieldOtherSizeStart = _minimumScaleFieldHeight;

                if (ScaleFieldOrientation == ScaleFieldOrientations.VerticalMiddleOut)
                {
                    scaleFieldOffset = (int)Math.Floor((decimal)scaleFieldCount / 2);
                    evenScaleFieldCount = ((2 * scaleFieldOffset) == scaleFieldCount);
                }

                for (int x = 0; x < scaleFieldCount; x++)
                {
                    int scaleFieldOtherSize;

                    if (ScaleFieldOrientation != ScaleFieldOrientations.VerticalMiddleOut)
                    {
                        scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)x / (double)scaleFieldCount));
                    }
                    else
                    {
                        if (evenScaleFieldCount)
                        {
                            if (x < scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (scaleFieldOffset - x)) / (double)scaleFieldCount));
                            }
                            else
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (x - scaleFieldOffset + 1)) / (double)scaleFieldCount));
                            }
                        }
                        else
                        {
                            if (x < scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (scaleFieldOffset - x)) / (double)scaleFieldCount));
                            }
                            else if (x == scaleFieldOffset)
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart;
                            }
                            else
                            {
                                scaleFieldOtherSize = scaleFieldOtherSizeStart + (int)Math.Floor(((double)scaleFieldOtherSizeEnd - (double)scaleFieldOtherSizeStart) * ((double)(2 * (x - scaleFieldOffset)) / (double)scaleFieldCount));
                            }
                        }
                    }

                    Size scaleFieldSize = new Size(scaleFieldOtherSize, ScaleFieldSize);

                    int scaleFieldXPos;

                    if (ScaleFieldLocation == ScaleFieldLocations.TopOrLeft)
                        scaleFieldXPos = scaleFieldOtherSizeEnd - scaleFieldOtherSize;
                    else
                        scaleFieldXPos = 0;

                    int scaleFieldYPos;

                    if (ScaleFieldOrientation == ScaleFieldOrientations.TopToBottom)
                        scaleFieldYPos = x * (ScaleFieldSize + ScaleFieldSpacing);
                    else
                        scaleFieldYPos = Height - (x * (ScaleFieldSize + ScaleFieldSpacing) + ScaleFieldSize);

                    Point scaleFieldLocation = new Point(scaleFieldXPos, scaleFieldYPos);

                    Rectangle scaleFieldRectangle = new Rectangle(scaleFieldLocation, scaleFieldSize);

                    using (Brush scaleFieldBrush = new SolidBrush(ScaleFieldColor))
                    {
                        e.Graphics.FillRectangle(scaleFieldBrush, scaleFieldRectangle);
                    }
                }
            }
        }
    }
    #endregion

    #region ZeroitWinampTrackBar    
    /// <summary>
    /// A class collection for rendering winamp trackbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultValue("Value"), DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(TrackBar))]
    public class ZeroitWinampTrackBar : Control
    {
        /// <summary>
        /// The acceptable space between scale and track bar
        /// </summary>
        private const int AcceptableSpaceBetweenScaleAndTrackBar = 3;
        /// <summary>
        /// The tool tip
        /// </summary>
        private ToolTip _toolTip;

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWinampTrackBar" /> class.
        /// </summary>
        public ZeroitWinampTrackBar()
        {
            SetStyle(ControlStyles.ResizeRedraw |
                        ControlStyles.SupportsTransparentBackColor |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.DoubleBuffer, true);

            //BackColor = Color.FromArgb(56, 63, 67);

            _renderer = new ZeroitHorizontalWinampTrackBarRenderer(this);
            _toolTip = new ToolTip();
        }

        #endregion Constructor

        #region Enums

        /// <summary>
        /// Enum representing when the slider should be shown
        /// </summary>
        public enum ZeroitWinampTrackBarShowSlider
        {
            /// <summary>
            /// The never
            /// </summary>
            Never,
            /// <summary>
            /// The on hover
            /// </summary>
            OnHover,
            /// <summary>
            /// The always
            /// </summary>
            Always
        }

        /// <summary>
        /// Enum representing the Track Style
        /// </summary>
        public enum ZeroitWinampTrackBarTrackStyle
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// From zero
            /// </summary>
            FromZero,
            /// <summary>
            /// From left or top
            /// </summary>
            FromLeftOrTop,
            /// <summary>
            /// From right or bottom
            /// </summary>
            FromRightOrBottom
        }

        /// <summary>
        /// Enum representing Scale Field Position
        /// </summary>
        public enum ZeroitWinampTrackBarScaleFieldPosition
        {
            /// <summary>
            /// The left or top
            /// </summary>
            LeftOrTop,
            /// <summary>
            /// The right or bottom
            /// </summary>
            RightOrBottom
        }

        /// <summary>
        /// Enum representing a Tick Position
        /// </summary>
        public enum ZeroitWinampTrackBarTickPosition
        {
            /// <summary>
            /// The left or top
            /// </summary>
            LeftOrTop,
            /// <summary>
            /// The right or bottom
            /// </summary>
            RightOrBottom,
            /// <summary>
            /// The both
            /// </summary>
            Both
        }

        /// <summary>
        /// Enum representing a Tick Alignment
        /// </summary>
        public enum ZeroitWinampTrackBarTickAlignment
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
        /// Enum representing if the user should be able to change the trackbar value using the arrow keys
        /// </summary>
        public enum ZeroitWinampTrackBarKeyChangeOption
        {
            /// <summary>
            /// The no key change
            /// </summary>
            NoKeyChange,
            /// <summary>
            /// The left and right arrow keys
            /// </summary>
            LeftAndRightArrowKeys,
            /// <summary>
            /// Up and down arrow keys
            /// </summary>
            UpAndDownArrowKeys
        }

        /// <summary>
        /// Enum representing value change source
        /// </summary>
        public enum ZeroitWinampTrackBarValueChangeSource
        {
            /// <summary>
            /// The code
            /// </summary>
            Code,
            /// <summary>
            /// The slider change
            /// </summary>
            SliderChange,
            /// <summary>
            /// The track click
            /// </summary>
            TrackClick,
            /// <summary>
            /// The mouse wheel
            /// </summary>
            MouseWheel,
            /// <summary>
            /// The key press
            /// </summary>
            KeyPress
        }

        /// <summary>
        /// Enum representing the Scale Type
        /// </summary>
        public enum ZeroitWinampTrackBarScaleType
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The scale fields
            /// </summary>
            ScaleFields,
            /// <summary>
            /// The ticks
            /// </summary>
            Ticks
        }

        #endregion Enums

        #region Events & Delegates

        /// <summary>
        /// Delegate ValueChangingDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ZeroitWinampTrackBarValueChangingEventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangingDelegate(Object sender, ZeroitWinampTrackBarValueChangingEventArgs e);
        /// <summary>
        /// Occurs when [value changing].
        /// </summary>
        [Description("Raised before the TrackBar Value property changes")]
        public event ValueChangingDelegate ValueChanging;

        /// <summary>
        /// Delegate ValueChangedDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ZeroitWinampTrackBarValueChangedEventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedDelegate(Object sender, ZeroitWinampTrackBarValueChangedEventArgs e);
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Description("Raised when the TrackBar Value property has changed")]
        public event ValueChangedDelegate ValueChanged;

        /// <summary>
        /// Delegate ScrollDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ScrollDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        [Description("Raised when the TrackBar has scrolled.")]
        public event ScrollDelegate Scroll;

        /// <summary>
        /// Delegate SeekingDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ZeroitWinampTrackBarSeekEventArgs"/> instance containing the event data.</param>
        public delegate void SeekingDelegate(Object sender, ZeroitWinampTrackBarSeekEventArgs e);
        /// <summary>
        /// Occurs when [seeking].
        /// </summary>
        [Description("Raised when the TrackBar is seeking.")]
        public event SeekingDelegate Seeking;

        /// <summary>
        /// Delegate SeekDoneDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ZeroitWinampTrackBarSeekEventArgs"/> instance containing the event data.</param>
        public delegate void SeekDoneDelegate(Object sender, ZeroitWinampTrackBarSeekEventArgs e);
        /// <summary>
        /// Occurs when [seek done].
        /// </summary>
        [Description("Raised when the TrackBar seek is done.")]
        public event SeekDoneDelegate SeekDone;

        /// <summary>
        /// Delegate MaximumChangedDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void MaximumChangedDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Occurs when [maximum changed].
        /// </summary>
        [Description("Raised when the TrackBar Maximum changes.")]
        public event MaximumChangedDelegate MaximumChanged;

        /// <summary>
        /// Delegate MinimumChangedDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void MinimumChangedDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Occurs when [minimum changed].
        /// </summary>
        [Description("Raised when the TrackBar Minimum changes.")]
        public event MinimumChangedDelegate MinimumChanged;

        /// <summary>
        /// Delegate SliderButtonDoubleClickDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public delegate void SliderButtonDoubleClickDelegate(Object sender, MouseEventArgs e);
        /// <summary>
        /// Occurs when [slider button double click].
        /// </summary>
        [Description("Raised when the Slider Button of the TrackBar is double-clicked.")]
        public event SliderButtonDoubleClickDelegate SliderButtonDoubleClick;

        #endregion Events & Delegates

        #region Private Members

        /// <summary>
        /// The renderer
        /// </summary>
        private ZeroitWinampTrackBarRenderer _renderer;

        /// <summary>
        /// The value
        /// </summary>
        private int _value;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _minimum;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum = 100;

        /// <summary>
        /// The is seeking
        /// </summary>
        private bool _isSeeking;
        /// <summary>
        /// The seek value
        /// </summary>
        private int _seekValue;
        /// <summary>
        /// The is control hovered
        /// </summary>
        private bool _isControlHovered;
        /// <summary>
        /// The is slider hovered
        /// </summary>
        private bool _isSliderHovered;
        /// <summary>
        /// The mouse pointer x offset
        /// </summary>
        private int _mousePointerXOffset;
        /// <summary>
        /// The mouse pointer y offset
        /// </summary>
        private int _mousePointerYOffset;

        /// <summary>
        /// The automatic size
        /// </summary>
        private bool _autoSize;
        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation _orientation = Orientation.Horizontal;

        /// <summary>
        /// The slider button size
        /// </summary>
        private Size _sliderButtonSize = new Size(38, 10);
        /// <summary>
        /// The use seeking
        /// </summary>
        private bool _useSeeking = true;
        /// <summary>
        /// The allow user slide change
        /// </summary>
        private bool _allowUserSlideChange = true;
        /// <summary>
        /// The show slider
        /// </summary>
        private ZeroitWinampTrackBarShowSlider _showSlider = ZeroitWinampTrackBarShowSlider.Always;
        /// <summary>
        /// The seek slider transparency
        /// </summary>
        private int _seekSliderTransparency = 200;
        /// <summary>
        /// The use hover effect
        /// </summary>
        private bool _useHoverEffect = true;

        /// <summary>
        /// The key change option
        /// </summary>
        private ZeroitWinampTrackBarKeyChangeOption _keyChangeOption = ZeroitWinampTrackBarKeyChangeOption.UpAndDownArrowKeys;
        /// <summary>
        /// The small change
        /// </summary>
        private int _smallChange = 3;
        /// <summary>
        /// The large change
        /// </summary>
        private int _largeChange = 10;
        /// <summary>
        /// The allow mouse wheel change
        /// </summary>
        private bool _allowMouseWheelChange = true;

        /// <summary>
        /// The scale type
        /// </summary>
        private ZeroitWinampTrackBarScaleType _scaleType = ZeroitWinampTrackBarScaleType.ScaleFields;

        /// <summary>
        /// The tick position
        /// </summary>
        private ZeroitWinampTrackBarTickPosition _tickPosition = ZeroitWinampTrackBarTickPosition.Both;
        /// <summary>
        /// The tick spacing
        /// </summary>
        private int _tickSpacing = 1;
        /// <summary>
        /// The tick width
        /// </summary>
        private int _tickWidth = 1;
        /// <summary>
        /// The tick height
        /// </summary>
        private int _tickHeight = 1;
        /// <summary>
        /// The tick emphasized height
        /// </summary>
        private int _tickEmphasizedHeight = 3;
        /// <summary>
        /// The tick alignment
        /// </summary>
        private ZeroitWinampTrackBarTickAlignment _tickAlignment = ZeroitWinampTrackBarTickAlignment.Center;
        /// <summary>
        /// The tick color
        /// </summary>
        private Color _tickColor = Color.FromArgb(72, 76, 79);
        /// <summary>
        /// The tick emphasized color
        /// </summary>
        private Color _tickEmphasizedColor = Color.FromArgb(72, 76, 79);
        /// <summary>
        /// The tick emphasize minimum maximum and zero
        /// </summary>
        private bool _tickEmphasizeMinMaxAndZero = true;

        /// <summary>
        /// The scale field position
        /// </summary>
        private ZeroitWinampTrackBarScaleFieldPosition _scaleFieldPosition = ZeroitWinampTrackBarScaleFieldPosition.LeftOrTop;
        /// <summary>
        /// The scale field width
        /// </summary>
        private int _scaleFieldWidth = 3;
        /// <summary>
        /// The scale field maximum height
        /// </summary>
        private int _scaleFieldMaxHeight = 10;
        /// <summary>
        /// The scale field spacing
        /// </summary>
        private int _scaleFieldSpacing = 1;
        /// <summary>
        /// The scale field color
        /// </summary>
        private Color _scaleFieldColor = Color.FromArgb(72, 76, 79);
        /// <summary>
        /// The scale field equalize heights
        /// </summary>
        private bool _scaleFieldEqualizeHeights;

        /// <summary>
        /// The track style
        /// </summary>
        private ZeroitWinampTrackBarTrackStyle _trackStyle = ZeroitWinampTrackBarTrackStyle.FromZero;
        /// <summary>
        /// The track upper color
        /// </summary>
        private Color _trackUpperColor = Color.FromArgb(156, 169, 173);
        /// <summary>
        /// The track lower color
        /// </summary>
        private Color _trackLowerColor = Color.FromArgb(88, 107, 113);
        /// <summary>
        /// The empty track color
        /// </summary>
        private Color _emptyTrackColor = Color.Black;

        /// <summary>
        /// The tool tip text
        /// </summary>
        private string _toolTipText = "";
        /// <summary>
        /// The slider tool tip text
        /// </summary>
        private string _sliderToolTipText = "";

        #endregion Private Members

        #region Internal Properties

        /// <summary>
        /// Gets a value indicating whether this instance is seeking.
        /// </summary>
        /// <value><c>true</c> if this instance is seeking; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        internal bool IsSeeking
        {
            get { return _isSeeking; }
            private set
            {
                _isSeeking = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the seek value.
        /// </summary>
        /// <value>The seek value.</value>
        [Browsable(false)]
        internal int SeekValue
        {
            get { return _seekValue; }
            private set
            {
                _seekValue = value;
                Invalidate();

                if (Seeking != null)
                {
                    ZeroitWinampTrackBarSeekEventArgs eargs = new ZeroitWinampTrackBarSeekEventArgs(_seekValue);
                    Seeking(this, eargs);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is slider visible.
        /// </summary>
        /// <value><c>true</c> if this instance is slider visible; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        internal bool IsSliderVisible
        {
            get
            {
                switch (_showSlider)
                {
                    case ZeroitWinampTrackBarShowSlider.Always:
                        return true;
                        break;
                    case ZeroitWinampTrackBarShowSlider.Never:
                        return false;
                        break;
                    case ZeroitWinampTrackBarShowSlider.OnHover:
                        return _isControlHovered;
                        break;
                }

                return true;
            }
            set
            {
                if (_showSlider != ZeroitWinampTrackBarShowSlider.Never)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is slider hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is slider hovered; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        internal bool IsSliderHovered
        {
            get { return _isSliderHovered; }
            set
            {
                if (value != _isSliderHovered)
                {
                    _isSliderHovered = value;
                    Invalidate();
                }
            }
        }

        #endregion Internal Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Bindable(true)]
        [DefaultValue(0)]
        [Category("Data")]
        [Description("Gets or sets the value of the TrackBar")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    if (value < Minimum)
                        value = Minimum;

                    if (value > Maximum)
                        value = Maximum;

                    if (ValueChanging != null)
                    {
                        ZeroitWinampTrackBarValueChangingEventArgs args = new ZeroitWinampTrackBarValueChangingEventArgs(value, ZeroitWinampTrackBarValueChangeSource.Code);
                        ValueChanging(this, args);

                        if (args.Cancel)
                            return;
                    }

                    _value = value;
                    Invalidate();

                    if (ValueChanged != null)
                        ValueChanged(this, new ZeroitWinampTrackBarValueChangedEventArgs(_value, ZeroitWinampTrackBarValueChangeSource.Code));
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Bindable(false)]
        [DefaultValue(0)]
        [Category("Data")]
        [Description("Gets or sets the Minimum value of the TrackBar")]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                if (value != _minimum)
                {
                    _minimum = value;
                    Invalidate();

                    if (MinimumChanged != null)
                        MinimumChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Bindable(false)]
        [DefaultValue(100)]
        [Category("Data")]
        [Description("Gets or sets the Maximum value of the TrackBar")]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value != _maximum)
                {
                    _maximum = value;
                    Invalidate();

                    if (MaximumChanged != null)
                        MaximumChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the slider button.
        /// </summary>
        /// <value>The size of the slider button.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Size), "38, 10")]
        [Category("Appearance")]
        [Description("Gets or sets the size of the Slider Button")]
        public Size SliderButtonSize
        {
            get { return _sliderButtonSize; }
            set
            {
                if (value != _sliderButtonSize)
                {
                    _sliderButtonSize = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the control should autosize to fit a whole number of scale fields.
        /// </summary>
        /// <value><c>true</c> if automatic size; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the control should autosize to fit a whole number of scale fields.")]
        public new bool AutoSize
        {
            get { return _autoSize; }
            set
            {
                if (value != _autoSize)
                {
                    _autoSize = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// If false, clicking the Track will change the calue to the selected value immediately. If true, the value will not be changed before the mouse capture is released.
        /// </summary>
        /// <value><c>true</c> if [use seeking]; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("If false, clicking the Track will change the calue to the selected value immediately. If true, the value will not be changed before the mouse capture is released.")]
        public bool UseSeeking
        {
            get { return _useSeeking; }
            set
            {
                if (value != _useSeeking)
                {
                    _useSeeking = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the seek slider transparency.
        /// </summary>
        /// <value>The seek slider transparency.</value>
        [Bindable(false)]
        [DefaultValue(200)]
        [Category("Appearance")]
        [Description("Gets or sets how tranparent the seek slider should be. Only used if UseSeeking = true")]
        public int SeekSliderTransparency
        {
            get { return _seekSliderTransparency; }
            set { _seekSliderTransparency = value; }
        }

        /// <summary>
        /// If false, the user cannot change the value by dragging the Slider Button or clicking the Track. This can be useful if you just want to use the TrackBar to show some kind of progress.
        /// </summary>
        /// <value><c>true</c> if allow user value change; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("If false, the user cannot change the value by dragging the Slider Button or clicking the Track. This can be useful if you just want to use the TrackBar to show some kind of progress.")]
        public bool AllowUserValueChange
        {
            get { return _allowUserSlideChange; }
            set
            {
                if (value != _allowUserSlideChange)
                {
                    _allowUserSlideChange = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the slider should light up when the mouse hovers over it.
        /// </summary>
        /// <value><c>true</c> if use hover effect; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets whether the slider should light up when the mouse hovers over it.")]
        public bool UseHoverEffect
        {
            get { return _useHoverEffect; }
            set
            {
                if (value != _useHoverEffect)
                {
                    _useHoverEffect = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the upper color of the filled part of the track.
        /// </summary>
        /// <value>The color of the track upper.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "156, 169, 173")]
        [Category("Appearance")]
        [Description("Gets or sets the upper color of the filled part of the track")]
        public Color TrackUpperColor
        {
            get { return _trackUpperColor; }
            set
            {
                if (value != _trackUpperColor)
                {
                    _trackUpperColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the lower color of the filled part of the track.
        /// </summary>
        /// <value>The color of the track lower.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "88, 107, 113")]
        [Category("Appearance")]
        [Description("Gets or sets the lower color of the filled part of the track")]
        public Color TrackLowerColor
        {
            get { return _trackLowerColor; }
            set
            {
                if (value != _trackLowerColor)
                {
                    _trackLowerColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the empty part of the track.
        /// </summary>
        /// <value>The empty color of the track.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "72, 76, 79")]
        [Category("Appearance")]
        [Description("Gets or sets the color of the empty part of the track")]
        public Color EmptyTrackColor
        {
            get { return _emptyTrackColor; }
            set
            {
                if (value != _emptyTrackColor)
                {
                    _emptyTrackColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the TrackBar orientation, Horizontal or Vertical.
        /// </summary>
        /// <value>The orientation.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Orientation), "Horizontal")]
        [Category("Appearance")]
        [Description("Gets or sets the TrackBar orientation, Horizontal or Vertical")]
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (value != _orientation)
                {
                    _orientation = value;

                    switch (_orientation)
                    {
                        case Orientation.Horizontal:
                            _renderer = new ZeroitHorizontalWinampTrackBarRenderer(this);
                            break;
                        case Orientation.Vertical:
                            _renderer = new ZeroitHorizontalWinampTrackBarRenderer(this);
                            break;
                    }
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets how the TrackBar track should be filled.
        /// </summary>
        /// <value>The track style.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarTrackStyle), "FromZero")]
        [Category("Behavior")]
        [Description("Gets or sets how the TrackBar track should be filled")]
        public ZeroitWinampTrackBarTrackStyle TrackStyle
        {
            get { return _trackStyle; }
            set
            {
                if (value != _trackStyle)
                {
                    _trackStyle = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the scale.
        /// </summary>
        /// <value>The type of the scale.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarScaleType), "ScaleFields")]
        [Category("Appearance")]
        [Description("Gets or sets the TrackBar scale type")]
        public ZeroitWinampTrackBarScaleType ScaleType
        {
            get { return _scaleType; }
            set
            {
                if (value != _scaleType)
                {
                    _scaleType = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the tick position.
        /// </summary>
        /// <value>The tick position.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarTickPosition), "Both")]
        [Category("Appearance")]
        [Description("Gets or sets the position of the TrackBar ticks")]
        public ZeroitWinampTrackBarTickPosition TickPosition
        {
            get { return _tickPosition; }
            set
            {
                if (value != _tickPosition)
                {
                    _tickPosition = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the tick spacing.
        /// </summary>
        /// <value>The tick spacing.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">TickSpacing cannot be negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">TickSpacing cannot be negative!</exception>
        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Appearance")]
        [Description("Gets or sets the spacing in pixels between the TrackBar ticks")]
        public int TickSpacing
        {
            get { return _tickSpacing; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("TickSpacing cannot be negative!");

                if (value != _tickSpacing)
                {
                    _tickSpacing = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the tick.
        /// </summary>
        /// <value>The width of the tick.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">TickWidth cannot be zero or negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">TickWidth cannot be zero or negative!</exception>
        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Appearance")]
        [Description("Gets or sets the width in pixels of the normal TrackBar ticks (TickHeight for vertical orientation)")]
        public int TickWidth
        {
            get { return _tickWidth; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("TickWidth cannot be zero or negative!");

                if (value != _tickWidth)
                {
                    _tickWidth = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the tick.
        /// </summary>
        /// <value>The height of the tick.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">TickHeight cannot be zero or negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">TickHeight cannot be zero or negative!</exception>
        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Appearance")]
        [Description("Gets or sets the height in pixels of the normal TrackBar ticks (TickWidth for vertical orientation)")]
        public int TickHeight
        {
            get { return _tickHeight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("TickHeight cannot be zero or negative!");

                if (value != _tickHeight)
                {
                    _tickHeight = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the tick emphasized.
        /// </summary>
        /// <value>The height of the tick emphasized.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">TickEmphasizedHeight cannot be zero or negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">TickEmphasizedHeight cannot be zero or negative!</exception>
        [Bindable(false)]
        [DefaultValue(3)]
        [Category("Appearance")]
        [Description("Gets or sets the height in pixels of the emphasized TrackBar ticks (TickEmphasizedWidth for vertical orientation)")]
        public int TickEmphasizedHeight
        {
            get { return _tickEmphasizedHeight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("TickEmphasizedHeight cannot be zero or negative!");

                if (value != _tickEmphasizedHeight)
                {
                    _tickEmphasizedHeight = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the tick alignment.
        /// </summary>
        /// <value>The tick alignment.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarTickAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets the alignment of the TrackBar ticks")]
        public ZeroitWinampTrackBarTickAlignment TickAlignment
        {
            get { return _tickAlignment; }
            set
            {
                if (value != _tickAlignment)
                {
                    _tickAlignment = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "72, 76, 79")]
        [Category("Appearance")]
        [Description("Gets or sets the color of the ticks")]
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

        /// <summary>
        /// Gets or sets the color of the tick emphasized.
        /// </summary>
        /// <value>The color of the tick emphasized.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "72, 76, 79")]
        [Category("Appearance")]
        [Description("Gets or sets the color of the emphasized ticks")]
        public Color TickEmphasizedColor
        {
            get { return _tickEmphasizedColor; }
            set
            {
                if (value != _tickEmphasizedColor)
                {
                    _tickEmphasizedColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the Minimum value, the Maximum value and Zero should be emphasized with a larger ticks.
        /// </summary>
        /// <value><c>true</c> if tick emphasize minimum maximum and zero; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Gets or sets whether the Minimum value, the Maximum value and Zero should be emphasized with a larger ticks")]
        public bool TickEmphasizeMinMaxAndZero
        {
            get { return _tickEmphasizeMinMaxAndZero; }
            set
            {
                if (value != _tickEmphasizeMinMaxAndZero)
                {
                    _tickEmphasizeMinMaxAndZero = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the scale field position.
        /// </summary>
        /// <value>The scale field position.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarScaleFieldPosition), "LeftOrTop")]
        [Category("Appearance")]
        [Description("Gets or sets the position of the TrackBar scale fields")]
        public ZeroitWinampTrackBarScaleFieldPosition ScaleFieldPosition
        {
            get { return _scaleFieldPosition; }
            set
            {
                if (value != _scaleFieldPosition)
                {
                    _scaleFieldPosition = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets When the slider should be shown.
        /// </summary>
        /// <value>The show slider.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarShowSlider), "Always")]
        [Category("Behavior")]
        [Description("Gets or sets When the slider should be shown")]
        public ZeroitWinampTrackBarShowSlider ShowSlider
        {
            get { return _showSlider; }
            set
            {
                if (value != _showSlider)
                {
                    _showSlider = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the scale field.
        /// </summary>
        /// <value>The color of the scale field.</value>
        [Bindable(false)]
        [DefaultValue(typeof(Color), "72, 76, 79")]
        [Category("Appearance")]
        [Description("Gets or sets the color of the scale fields")]
        public Color ScaleFieldColor
        {
            get { return _scaleFieldColor; }
            set
            {
                if (value != _scaleFieldColor)
                {
                    _scaleFieldColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the scale field in Horizontal mode (will be field HEIGHT in Vertical mode).
        /// </summary>
        /// <value>The width of the scale field.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">ScaleFieldWidth cannot be zero or negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">ScaleFieldWidth cannot be zero or negative!</exception>
        [Bindable(true)]
        [DefaultValue(3)]
        [Category("Appearance")]
        [Description("Gets or sets the width of the scale fields in Horizontal mode (will be field HEIGHT in Vertical mode)")]
        public int ScaleFieldWidth
        {
            get { return _scaleFieldWidth; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ScaleFieldWidth cannot be zero or negative!");

                if (value != _scaleFieldWidth)
                {
                    _scaleFieldWidth = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum height of the scale field in Horizontal mode (will be maximum field WIDTH in Vertical mode).
        /// </summary>
        /// <value>The maximum height of the scale field.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">ScaleFieldMaxHeight cannot be zero or negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">ScaleFieldMaxHeight cannot be zero or negative!</exception>
        [Bindable(true)]
        [DefaultValue(10)]
        [Category("Appearance")]
        [Description("Gets or sets the maximum height of the scale fields in Horizontal mode (will be maximum field WIDTH in Vertical mode)")]
        public int ScaleFieldMaxHeight
        {
            get { return _scaleFieldMaxHeight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ScaleFieldMaxHeight cannot be zero or negative!");

                if (value != _scaleFieldMaxHeight)
                {
                    _scaleFieldMaxHeight = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets if both ends or a dual scale should have the same height even if they have different values.
        /// </summary>
        /// <value><c>true</c> if [scale field equalize heights]; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets if both ends or a dual scale should have the same height even if they have different values")]
        public bool ScaleFieldEqualizeHeights
        {
            get { return _scaleFieldEqualizeHeights; }
            set
            {
                if (value != _scaleFieldEqualizeHeights)
                {
                    _scaleFieldEqualizeHeights = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the scale field spacing.
        /// </summary>
        /// <value>The scale field spacing.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">ScaleFieldSpacing cannot be negative!</exception>
        /// <exception cref="ArgumentOutOfRangeException">ScaleFieldSpacing cannot be negative!</exception>
        [Bindable(true)]
        [DefaultValue(1)]
        [Category("Appearance")]
        [Description("Gets or sets the spacing in pixels between the scale fields")]
        public int ScaleFieldSpacing
        {
            get { return _scaleFieldSpacing; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("ScaleFieldSpacing cannot be negative!");

                if (value != _scaleFieldSpacing)
                {
                    _scaleFieldSpacing = value;
                    OnResize(null);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets if the user should be able to change the trackbar value using the arrow keys.
        /// </summary>
        /// <value>The key change option.</value>
        [Bindable(false)]
        [DefaultValue(typeof(ZeroitWinampTrackBarKeyChangeOption), "UpAndDownArrowKeys")]
        [Category("Behavior")]
        [Description("Gets or sets if the user should be able to change the trackbar value using the arrow keys")]
        public ZeroitWinampTrackBarKeyChangeOption KeyChangeOption
        {
            get { return _keyChangeOption; }
            set { _keyChangeOption = value; }
        }

        /// <summary>
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        [Bindable(false)]
        [DefaultValue(3)]
        [Category("Behavior")]
        [Description("Gets or sets the small value change")]
        public int SmallChange
        {
            get { return _smallChange; }
            set { _smallChange = value; }
        }

        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        [Bindable(false)]
        [DefaultValue(10)]
        [Category("Behavior")]
        [Description("Gets or sets the large value change")]
        public int LargeChange
        {
            get { return _largeChange; }
            set { _largeChange = value; }
        }

        /// <summary>
        /// Gets or sets if the user should be able to change the trackbar value using the mouse wheel.
        /// </summary>
        /// <value><c>true</c> if [allow mouse wheel change]; otherwise, <c>false</c>.</value>
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the user should be able to change the trackbar value using the mouse wheel")]
        public bool AllowMouseWheelChange
        {
            get { return _allowMouseWheelChange; }
            set { _allowMouseWheelChange = value; }
        }

        /// <summary>
        /// Gets or sets the tooltip text that is shown when the mouse hovers over the control.
        /// </summary>
        /// <value>The tool tip text.</value>
        [Bindable(true)]
        [DefaultValue("")]
        [Category("Behavior")]
        [Description("Gets or sets the tooltip text that is shown when the mouse hovers over the control")]
        public new string ToolTipText
        {
            get { return _toolTipText; }
            set { _toolTipText = value; }
        }

        /// <summary>
        /// Gets or sets the tooltip text that is shown when the mouse hovers over the trackbar slider button.
        /// </summary>
        /// <value>The tool tip text slider button.</value>
        [Bindable(true)]
        [DefaultValue("")]
        [Category("Behavior")]
        [Description("Gets or sets the tooltip text that is shown when the mouse hovers over the trackbar slider button")]
        public string ToolTipTextSliderButton
        {
            get { return _sliderToolTipText; }
            set { _sliderToolTipText = value; }
        }

        /// <summary>
        /// Determines if the ToolTip is active. A tip will only appear if the ToolTip has been activated.
        /// </summary>
        /// <value><c>true</c> if [tool tip active]; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Determines if the ToolTip is active. A tip will only appear if the ToolTip has been activated.")]
        public bool ToolTipActive
        {
            get { return _toolTip.Active; }
            set { _toolTip.Active = value; }
        }

        /// <summary>
        /// Gets or sets the values of AutoPopDelay, InitialDelay, and ReshowDelay to the appropriate values.
        /// </summary>
        /// <value>The tool tip automatic delay.</value>
        [Bindable(true)]
        [DefaultValue(500)]
        [Category("Behavior")]
        [Description("Sets the values of AutoPopDelay, InitialDelay, and ReshowDelay to the appropriate values.")]
        public int ToolTipAutomaticDelay
        {
            get { return _toolTip.AutomaticDelay; }
            set { _toolTip.AutomaticDelay = value; }
        }

        /// <summary>
        /// Determines the length of time the ToolTip window remains visible if the pointer is stationary inside a ToolTip region.
        /// </summary>
        /// <value>The tool tip automatic pop delay.</value>
        [Bindable(true)]
        [DefaultValue(5000)]
        [Category("Behavior")]
        [Description("Determines the length of time the ToolTip window remains visible if the pointer is stationary inside a ToolTip region.")]
        public int ToolTipAutoPopDelay
        {
            get { return _toolTip.AutoPopDelay; }
            set { _toolTip.AutoPopDelay = value; }
        }

        /// <summary>
        /// Gets or sets the color of the tool tip background.
        /// </summary>
        /// <value>The color of the tool tip background.</value>
        [Bindable(true)]
        [DefaultValue(typeof(Color), "Info")]
        [Category("Behavior")]
        [Description("The background color of the ToolTip.")]
        public Color ToolTipBackColor
        {
            get { return _toolTip.BackColor; }
            set { _toolTip.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the tool tip foreground.
        /// </summary>
        /// <value>The color of the tool tip foreground.</value>
        [Bindable(true)]
        [DefaultValue(typeof(Color), "InfoText")]
        [Category("Behavior")]
        [Description("The foreground color of the ToolTip.")]
        public Color ToolTipForeColor
        {
            get { return _toolTip.ForeColor; }
            set { _toolTip.ForeColor = value; }
        }

        /// <summary>
        /// Determines the length of time the pointer must remain stationary within a ToolTip region before the ToolTip window appears.
        /// </summary>
        /// <value>The tool tip initial delay.</value>
        [Bindable(true)]
        [DefaultValue(500)]
        [Category("Behavior")]
        [Description("Determines the length of time the pointer must remain stationary within a ToolTip region before the ToolTip window appears.")]
        public int ToolTipInitialDelay
        {
            get { return _toolTip.InitialDelay; }
            set { _toolTip.InitialDelay = value; }
        }

        /// <summary>
        /// Indicates whether the ToolTip will take on a balloon form.
        /// </summary>
        /// <value><c>true</c> if [tool tip is balloon]; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Indicates whether the ToolTip will take on a balloon form.")]
        public bool ToolTipIsBalloon
        {
            get { return _toolTip.IsBalloon; }
            set { _toolTip.IsBalloon = value; }
        }

        /// <summary>
        /// Determines the length of time it takes for subsequent windows to appear as the pointer moves from one ToolTip region to another.
        /// </summary>
        /// <value>The tool tip reshow delay.</value>
        [Bindable(true)]
        [DefaultValue(100)]
        [Category("Behavior")]
        [Description("Determines the length of time it takes for subsequent windows to appear as the pointer moves from one ToolTip region to another.")]
        public int ToolTipReshowDelay
        {
            get { return _toolTip.ReshowDelay; }
            set { _toolTip.ReshowDelay = value; }
        }

        /// <summary>
        /// Determines if the tool tip will be displayed always, even if the parent window is not active.
        /// </summary>
        /// <value><c>true</c> if [tool tip strip ampersands]; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Determines if the tool tip will be displayed always, even if the parent window is not active.")]
        public bool ToolTipStripAmpersands
        {
            get { return _toolTip.StripAmpersands; }
            set { _toolTip.StripAmpersands = value; }
        }

        /// <summary>
        /// When set to true, any ampersands in the Text property are not displayed.
        /// </summary>
        /// <value><c>true</c> if [tool tip show always]; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("When set to true, any ampersands in the Text property are not displayed.")]
        public bool ToolTipShowAlways
        {
            get { return _toolTip.ShowAlways; }
            set { _toolTip.ShowAlways = value; }
        }

        /// <summary>
        /// Gets or sets the tool tip icon.
        /// </summary>
        /// <value>The tool tip icon.</value>
        [Bindable(true)]
        [DefaultValue(typeof(ToolTipIcon), "None")]
        [Category("Behavior")]
        [Description("Determines the icon that is shown on the ToolTip.")]
        public ToolTipIcon ToolTipIcon
        {
            get { return _toolTip.ToolTipIcon; }
            set { _toolTip.ToolTipIcon = value; }
        }

        /// <summary>
        /// Gets or sets the tool tip title.
        /// </summary>
        /// <value>The tool tip title.</value>
        [Bindable(true)]
        [DefaultValue("")]
        [Category("Behavior")]
        [Description("Determines the title of the ToolTip.")]
        public string ToolTipTitle
        {
            get { return _toolTip.ToolTipTitle; }
            set { _toolTip.ToolTipTitle = value; }
        }

        /// <summary>
        /// When set to true, animations are used when the ToolTip is shown or hidden.
        /// </summary>
        /// <value><c>true</c> if tool tip use animation; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("When set to true, animations are used when the ToolTip is shown or hidden.")]
        public bool ToolTipUseAnimation
        {
            get { return _toolTip.UseAnimation; }
            set { _toolTip.UseAnimation = value; }
        }

        /// <summary>
        /// When set to true, a fade effect is used when the ToolTip is shown or hidden.
        /// </summary>
        /// <value><c>true</c> if tool tip use fading; otherwise, <c>false</c>.</value>
        [Bindable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("When set to true, a fade effect is used when the ToolTip is shown or hidden.")]
        public bool ToolTipUseFading
        {
            get { return _toolTip.UseFading; }
            set { _toolTip.UseFading = value; }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        public new string Text
        {
            get { return ""; }
            set { base.Text = ""; }
        }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Sets the value internal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="raiseScroll">if set to <c>true</c> [raise scroll].</param>
        /// <param name="source">The source.</param>
        private void SetValueInternal(int value, bool raiseScroll, ZeroitWinampTrackBarValueChangeSource source)
        {
            if (value > Maximum)
                value = Maximum;

            if (value < Minimum)
                value = Minimum;

            if (ValueChanging != null)
            {
                ZeroitWinampTrackBarValueChangingEventArgs args = new ZeroitWinampTrackBarValueChangingEventArgs(value, source);
                ValueChanging(this, args);

                if (args.Cancel)
                    return;
            }

            _value = value;

            Invalidate();

            if (raiseScroll && Scroll != null)
                Scroll(this, new EventArgs());

            if (ValueChanged != null)
                ValueChanged(this, new ZeroitWinampTrackBarValueChangedEventArgs(_value, source));
        }

        #endregion Private Methods

        #region Overridden Base Class Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            _renderer.RenderControl(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _isControlHovered = true;
            IsSliderVisible = true;

            if (_toolTip != null && _toolTipText != "")
                _toolTip.SetToolTip(this, _toolTipText);

            if (!AllowUserValueChange)
                return;

            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            _isControlHovered = true;

            if (!AllowUserValueChange)
                return;

            base.OnMouseHover(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _isControlHovered = false;
            IsSliderVisible = false;

            if (_toolTip != null)
                _toolTip.SetToolTip(this, "");

            if (!AllowUserValueChange)
                return;

            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _isControlHovered = true;

            bool savedButtonHovered = IsSliderHovered;

            Rectangle sliderRectangle = _renderer.GetSliderLayoutRectangle(Value);
            IsSliderHovered = (sliderRectangle.Contains(e.Location));

            if (IsSliderHovered && savedButtonHovered != IsSliderHovered && _toolTip != null && _sliderToolTipText != "")
                _toolTip.SetToolTip(this, _sliderToolTipText);
            else if (!IsSliderHovered && savedButtonHovered != IsSliderHovered && _toolTip != null && _toolTipText != "")
                _toolTip.SetToolTip(this, _toolTipText);

            if (!AllowUserValueChange)
                return;

            if (IsSeeking)
            {
                int adjustedCoordinate = Orientation == Orientation.Horizontal ? e.X + _mousePointerXOffset : e.Y + _mousePointerYOffset;
                int currentValue = _renderer.PixelValueToValue(adjustedCoordinate);

                if (UseSeeking)
                    SeekValue = currentValue;
                else
                    SetValueInternal(currentValue, true, ZeroitWinampTrackBarValueChangeSource.SliderChange);
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!AllowUserValueChange)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            Rectangle sliderRectangle = _renderer.GetSliderLayoutRectangle(Value);
            Rectangle clickRectangle = _renderer.GetClickRectangle();

            if (sliderRectangle.Contains(e.Location))
            {
                IsSeeking = true;
                SeekValue = Value;

                int middleXValue = sliderRectangle.X + (sliderRectangle.Width / 2) - 1;
                _mousePointerXOffset = middleXValue - e.X;

                int middleYValue = sliderRectangle.Y + (sliderRectangle.Height / 2) - 1;
                _mousePointerYOffset = middleYValue - e.Y;
            }
            else if (clickRectangle.Contains(e.Location))
            {
                int currentValue = Orientation == Orientation.Horizontal ? _renderer.PixelValueToValue(e.X) : _renderer.PixelValueToValue(e.Y);
                SetValueInternal(currentValue, true, ZeroitWinampTrackBarValueChangeSource.TrackClick);
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!AllowUserValueChange)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            base.OnMouseUp(e);

            if (UseSeeking && IsSeeking)
            {
                SetValueInternal(SeekValue, true, ZeroitWinampTrackBarValueChangeSource.SliderChange);

                if (SeekDone != null)
                    SeekDone(this, new ZeroitWinampTrackBarSeekEventArgs(SeekValue));
            }

            IsSeeking = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDoubleClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (!AllowUserValueChange)
                return;

            Rectangle sliderRectangle = _renderer.GetSliderLayoutRectangle(Value);

            if (sliderRectangle.Contains(e.Location))
            {
                if (SliderButtonDoubleClick != null)
                    SliderButtonDoubleClick(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!AllowUserValueChange || !AllowMouseWheelChange)
                return;

            if (e.Delta > 0)
                SetValueInternal(Value + SmallChange, true, ZeroitWinampTrackBarValueChangeSource.MouseWheel);

            if (e.Delta < 0)
                SetValueInternal(Value - SmallChange, true, ZeroitWinampTrackBarValueChangeSource.MouseWheel);

            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!AllowUserValueChange || _keyChangeOption == ZeroitWinampTrackBarKeyChangeOption.NoKeyChange)
                return;

            if (_keyChangeOption == ZeroitWinampTrackBarKeyChangeOption.LeftAndRightArrowKeys)
            {
                if (e.KeyCode == Keys.Left)
                {
                    SetValueInternal(Value - SmallChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    SetValueInternal(Value + SmallChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Up)
                {
                    SetValueInternal(Value + SmallChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    SetValueInternal(Value - SmallChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
                }
            }

            if (e.KeyCode == Keys.PageUp)
            {
                SetValueInternal(Value + LargeChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                SetValueInternal(Value - LargeChange, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
            }
            else if (e.KeyCode == Keys.Home)
            {
                SetValueInternal(Maximum, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
            }
            else if (e.KeyCode == Keys.End)
            {
                SetValueInternal(Minimum, false, ZeroitWinampTrackBarValueChangeSource.KeyPress);
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!AllowUserValueChange || _keyChangeOption == ZeroitWinampTrackBarKeyChangeOption.NoKeyChange)
                return;

            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            const int extraBorder = 1;

            if (AutoSize)
            {
                int fieldCount = _renderer.CalculateScaleFieldCount(this);
                int scaleWidth = _renderer.CalculateTotalScaleWidth(this, fieldCount);

                int tickFieldHeight = TickHeight;

                if (TickEmphasizeMinMaxAndZero && TickEmphasizedHeight > TickHeight)
                    tickFieldHeight = TickEmphasizedHeight;

                int tickCount = _renderer.CalculateTickCount(this);
                int tickScaleWidth = _renderer.CalculateTotalTickWidth(this, tickCount);

                if (Orientation == Orientation.Horizontal)
                {
                    switch (ScaleType)
                    {
                        case ZeroitWinampTrackBarScaleType.None:
                            Height = SliderButtonSize.Height + (2 * extraBorder);
                            break;
                        case ZeroitWinampTrackBarScaleType.ScaleFields:
                            Height = ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar + SliderButtonSize.Height + (2 * extraBorder);
                            Width = scaleWidth;
                            break;
                        case ZeroitWinampTrackBarScaleType.Ticks:
                            Height = tickFieldHeight + AcceptableSpaceBetweenScaleAndTrackBar + SliderButtonSize.Height + (2 * extraBorder);

                            if (TickPosition == ZeroitWinampTrackBarTickPosition.Both)
                                Height = Height + tickFieldHeight + AcceptableSpaceBetweenScaleAndTrackBar;

                            Width = tickScaleWidth;
                            break;
                    }
                }
                else
                {
                    switch (ScaleType)
                    {
                        case ZeroitWinampTrackBarScaleType.None:
                            Width = SliderButtonSize.Width + (2 * extraBorder);
                            break;
                        case ZeroitWinampTrackBarScaleType.ScaleFields:
                            Height = scaleWidth;
                            Width = ScaleFieldMaxHeight + AcceptableSpaceBetweenScaleAndTrackBar + SliderButtonSize.Width + (2 * extraBorder);
                            break;
                        case ZeroitWinampTrackBarScaleType.Ticks:
                            Width = tickFieldHeight + AcceptableSpaceBetweenScaleAndTrackBar + SliderButtonSize.Width + (2 * extraBorder);

                            if (TickPosition == ZeroitWinampTrackBarTickPosition.Both)
                                Width = Width + tickFieldHeight + AcceptableSpaceBetweenScaleAndTrackBar;

                            Height = tickScaleWidth;
                            break;
                    }
                }
            }

            base.OnResize(e);
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Home:
                case Keys.End:
                    return true;
                    //case Keys.Shift | Keys.Right:
                    //case Keys.Shift | Keys.Left:
                    //case Keys.Shift | Keys.Up:
                    //case Keys.Shift | Keys.Down:
                    //case Keys.Shift | Keys.PageUp:
                    //case Keys.Shift | Keys.PageDown:
                    //case Keys.Shift | Keys.Home:
                    //case Keys.Shift | Keys.End:
                    //    return true;
            }

            return base.IsInputKey(keyData);
        }

        #endregion Overridden Base Class Methods
    }

    #endregion

    #region ZeroitWinampTrackBarRenderer
    /// <summary>
    /// Class ZeroitWinampTrackBarRenderer.
    /// </summary>
    public abstract class ZeroitWinampTrackBarRenderer
    {
        /// <summary>
        /// The track bar
        /// </summary>
        private ZeroitWinampTrackBar _trackBar;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWinampTrackBarRenderer"/> class.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <exception cref="System.Exception">You have to pass the TrackBar object in the constructor!</exception>
        protected ZeroitWinampTrackBarRenderer(ZeroitWinampTrackBar trackBar)
        {
            if (trackBar == null)
                throw new Exception("You have to pass the TrackBar object in the constructor!");

            _trackBar = trackBar;
        }

        #endregion Constructor

        #region Render Methods

        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RenderControl(PaintEventArgs e)
        {
            if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.ScaleFields)
            {
                Rectangle scaleRectangle = GetScaleFieldLayoutRectangle();

                if (scaleRectangle != Rectangle.Empty)
                {
                    e.Graphics.SetClip(scaleRectangle);
                    RenderScaleFields(e.Graphics);
                    e.Graphics.ResetClip();
                }
            }
            else if (_trackBar.ScaleType == ZeroitWinampTrackBar.ZeroitWinampTrackBarScaleType.Ticks)
            {
                if (_trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop ||
                    _trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both)
                {
                    Rectangle tickRectangle = GetTickLayoutRectangle(ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop);

                    if (tickRectangle != Rectangle.Empty)
                    {
                        e.Graphics.SetClip(tickRectangle);
                        RenderTicks(e.Graphics, ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.LeftOrTop);
                        e.Graphics.ResetClip();
                    }
                }

                if (_trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom ||
                    _trackBar.TickPosition == ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.Both)
                {
                    Rectangle tickRectangle = GetTickLayoutRectangle(ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom);

                    if (tickRectangle != Rectangle.Empty)
                    {
                        e.Graphics.SetClip(tickRectangle);
                        RenderTicks(e.Graphics, ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition.RightOrBottom);
                        e.Graphics.ResetClip();
                    }
                }
            }

            Rectangle trackRectangle = GetTrackLayoutRectangle();

            e.Graphics.SetClip(trackRectangle);
            RenderTrack(e.Graphics);
            e.Graphics.ResetClip();

            if (_trackBar.IsSliderVisible)
            {
                Rectangle sliderRectangle = GetSliderLayoutRectangle(_trackBar.Value);
                sliderRectangle.Inflate(1, 1); //Shadow

                if (sliderRectangle != Rectangle.Empty)
                {
                    e.Graphics.SetClip(sliderRectangle);
                    RenderSlider(e.Graphics, 255, (_trackBar.IsSliderHovered && _trackBar.UseHoverEffect));
                    e.Graphics.ResetClip();
                }
            }

            if (_trackBar.IsSeeking && _trackBar.UseSeeking)
            {
                Rectangle seekSliderRectangle = GetSliderLayoutRectangle(_trackBar.SeekValue);
                seekSliderRectangle.Inflate(1, 1); //Shadow

                if (seekSliderRectangle != Rectangle.Empty)
                {
                    e.Graphics.SetClip(seekSliderRectangle);
                    RenderSlider(e.Graphics, _trackBar.SeekSliderTransparency, false);
                    e.Graphics.ResetClip();
                }
            }
        }

        /// <summary>
        /// Gets the tick layout rectangle.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetTickLayoutRectangle(ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position);
        /// <summary>
        /// Renders the ticks.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="position">The position.</param>
        public abstract void RenderTicks(Graphics g, ZeroitWinampTrackBar.ZeroitWinampTrackBarTickPosition position);

        /// <summary>
        /// Gets the scale field layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetScaleFieldLayoutRectangle();
        /// <summary>
        /// Renders the scale fields.
        /// </summary>
        /// <param name="g">The g.</param>
        public abstract void RenderScaleFields(Graphics g);

        /// <summary>
        /// Gets the track layout rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetTrackLayoutRectangle();
        /// <summary>
        /// Renders the track.
        /// </summary>
        /// <param name="g">The g.</param>
        public abstract void RenderTrack(Graphics g);

        /// <summary>
        /// Gets the click rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetClickRectangle();
        /// <summary>
        /// Gets the slider layout rectangle.
        /// </summary>
        /// <param name="sliderValue">The slider value.</param>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetSliderLayoutRectangle(int sliderValue);

        /// <summary>
        /// Values to pixel value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public abstract int ValueToPixelValue(int value);
        /// <summary>
        /// Pixels the value to value.
        /// </summary>
        /// <param name="pixelValue">The pixel value.</param>
        /// <returns>System.Int32.</returns>
        public abstract int PixelValueToValue(int pixelValue);

        /// <summary>
        /// Gets the size of the track field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public abstract int GetTrackFieldSize();
        /// <summary>
        /// Gets the size of the tick field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public abstract int GetTickFieldSize();
        /// <summary>
        /// Gets the total size of the field.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public abstract int GetTotalFieldSize();
        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public abstract int GetOffset();
        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <param name="totalSize">The total size.</param>
        /// <returns>System.Int32.</returns>
        public abstract int GetOffset(int totalSize);

        #endregion Render Methods

        #region Scale Fields

        /// <summary>
        /// Calculates the scale field count.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <returns>System.Int32.</returns>
        public int CalculateScaleFieldCount(ZeroitWinampTrackBar trackBar)
        {
            int width = trackBar.Orientation == Orientation.Horizontal ? trackBar.Width : trackBar.Height;

            return (int)Math.Floor(((double)width + (double)trackBar.ScaleFieldSpacing) / ((double)trackBar.ScaleFieldWidth + (double)trackBar.ScaleFieldSpacing));
        }

        /// <summary>
        /// Calculates the total width of the scale.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <returns>System.Int32.</returns>
        public int CalculateTotalScaleWidth(ZeroitWinampTrackBar trackBar, int fieldCount)
        {
            return (fieldCount * trackBar.ScaleFieldWidth) + ((fieldCount - 1) * trackBar.ScaleFieldSpacing);
        }

        /// <summary>
        /// Calculates the scale field heights.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <returns>Dictionary&lt;System.Int32, System.Int32&gt;.</returns>
        public Dictionary<int, int> CalculateScaleFieldHeights(ZeroitWinampTrackBar trackBar, int fieldCount)
        {
            Dictionary<int, int> heightList = new Dictionary<int, int>();

            if (fieldCount > 0)
            {
                double stepWidth;

                if (trackBar.Maximum >= trackBar.Minimum)
                {
                    //Normal

                    if ((trackBar.Maximum >= 0 && trackBar.Minimum >= 0) || (trackBar.Maximum <= 0 && trackBar.Minimum <= 0))
                    {
                        stepWidth = 100 / ((double)fieldCount - 1);

                        for (int i = 0; i < fieldCount; i++)
                        {
                            double stepValue = i * stepWidth;
                            int absoluteStepValue = (int)Math.Abs(stepValue);

                            double fraction = (double)absoluteStepValue / 100;
                            double height = (fraction * ((double)trackBar.ScaleFieldMaxHeight - 2)) + 2;

                            heightList.Add(i, (int)height);
                        }
                    }
                    else
                    {
                        stepWidth = ((double)trackBar.Maximum - (double)trackBar.Minimum) / ((double)fieldCount - 1);

                        for (int i = 0; i < fieldCount; i++)
                        {
                            double stepValue = (double)trackBar.Minimum + i * stepWidth;
                            int absoluteStepValue = (int)Math.Abs(stepValue);

                            double fraction;

                            if (trackBar.ScaleFieldEqualizeHeights)
                            {
                                if (stepValue < 0)
                                    fraction = (double)absoluteStepValue / (double)Math.Abs(trackBar.Minimum);
                                else
                                    fraction = (double)absoluteStepValue / (double)Math.Abs(trackBar.Maximum);
                            }
                            else
                            {
                                fraction = (double)absoluteStepValue / (double)Math.Max(Math.Abs(trackBar.Maximum), Math.Abs(trackBar.Minimum));
                            }

                            double height = (fraction * ((double)trackBar.ScaleFieldMaxHeight - 2)) + 2;

                            heightList.Add(i, (int)height);
                        }
                    }
                }
                else
                {
                    //Turn that thing around...

                    if ((trackBar.Maximum >= 0 && trackBar.Minimum >= 0) || (trackBar.Maximum <= 0 && trackBar.Minimum <= 0))
                    {
                        stepWidth = 100 / ((double)fieldCount - 1);

                        for (int i = 0; i < fieldCount; i++)
                        {
                            double stepValue = 100 - i * stepWidth;
                            int absoluteStepValue = (int)Math.Abs(stepValue);

                            double fraction = (double)absoluteStepValue / 100;
                            double height = (fraction * ((double)trackBar.ScaleFieldMaxHeight - 2)) + 2;

                            heightList.Add(i, (int)height);
                        }
                    }
                    else
                    {
                        stepWidth = ((double)trackBar.Minimum - (double)trackBar.Maximum) / ((double)fieldCount - 1);

                        for (int i = 0; i < fieldCount; i++)
                        {
                            double stepValue = (double)trackBar.Minimum - i * stepWidth;
                            int absoluteStepValue = (int)Math.Abs(stepValue);

                            double fraction;

                            if (trackBar.ScaleFieldEqualizeHeights)
                            {
                                if (stepValue < 0)
                                    fraction = (double)absoluteStepValue / (double)Math.Abs(trackBar.Maximum);
                                else
                                    fraction = (double)absoluteStepValue / (double)Math.Abs(trackBar.Minimum);
                            }
                            else
                            {
                                fraction = (double)absoluteStepValue / (double)Math.Max(Math.Abs(trackBar.Maximum), Math.Abs(trackBar.Minimum));
                            }

                            double height = (fraction * ((double)trackBar.ScaleFieldMaxHeight - 2)) + 2;

                            heightList.Add(i, (int)height);
                        }
                    }
                }
            }

            return heightList;
        }

        #endregion Scale Fields

        #region Ticks

        /// <summary>
        /// Calculates the tick count.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <returns>System.Int32.</returns>
        public int CalculateTickCount(ZeroitWinampTrackBar trackBar)
        {
            int width = trackBar.Orientation == Orientation.Horizontal ? trackBar.Width : trackBar.Height;

            int tickCount = (int)Math.Floor(((double)width + (double)trackBar.TickSpacing) / ((double)trackBar.TickWidth + (double)trackBar.TickSpacing));

            if (trackBar.TickEmphasizeMinMaxAndZero && tickCount % 2 != 0)
            {
                tickCount -= 1;
            }

            return tickCount;
        }

        /// <summary>
        /// Calculates the total width of the tick.
        /// </summary>
        /// <param name="trackBar">The track bar.</param>
        /// <param name="tickCount">The tick count.</param>
        /// <returns>System.Int32.</returns>
        public int CalculateTotalTickWidth(ZeroitWinampTrackBar trackBar, int tickCount)
        {
            return (tickCount * trackBar.TickWidth) + ((tickCount - 1) * trackBar.TickSpacing);
        }

        #endregion Ticks

        #region Slider

        /// <summary>
        /// Renders the slider.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="transparency">The transparency.</param>
        /// <param name="isHovered">if set to <c>true</c> [is hovered].</param>
        public void RenderSlider(Graphics g, int transparency, bool isHovered)
        {
            //Draw double gradient slider center
            int gradientWidth = (int)g.ClipBounds.Width - 4;
            int gradientTotalHeight = (int)g.ClipBounds.Height - 4;

            int gradientLowerHeight = (int)Math.Round((double)gradientTotalHeight / 2, 0);
            int gradientUpperHeight = gradientTotalHeight - gradientLowerHeight;

            if (gradientWidth > 0 && gradientLowerHeight > 0)
            {
                Color lowerGradientColor1 = isHovered ? Color.FromArgb(transparency, 174, 174, 174) : Color.FromArgb(transparency, 169, 169, 169);
                Color lowerGradientColor2 = isHovered ? Color.FromArgb(transparency, 210, 210, 210) : Color.FromArgb(transparency, 186, 186, 186);

                Rectangle lowerGradientRectangle = new Rectangle((int)g.ClipBounds.X + 2, (int)g.ClipBounds.Y + gradientUpperHeight + 2, gradientWidth, gradientLowerHeight);
                RectangleF lowerBrushRectangle = new RectangleF(lowerGradientRectangle.Location, lowerGradientRectangle.Size);
                lowerBrushRectangle.Inflate(0, 1);

                using (Brush lowerGradientBrush = new LinearGradientBrush(lowerBrushRectangle, lowerGradientColor1, lowerGradientColor2, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(lowerGradientBrush, lowerGradientRectangle);
                }
            }

            if (gradientWidth > 0 && gradientUpperHeight > 0)
            {
                Color upperGradientColor1 = isHovered ? Color.FromArgb(transparency, 249, 249, 249) : Color.FromArgb(transparency, 248, 248, 248);
                Color upperGradientColor2 = isHovered ? Color.FromArgb(transparency, 215, 215, 215) : Color.FromArgb(transparency, 200, 200, 200);

                RectangleF upperGradientRectangle = new RectangleF(g.ClipBounds.X + 2, g.ClipBounds.Y + 2, gradientWidth, gradientUpperHeight);
                RectangleF upperBrushRectangle = new RectangleF(upperGradientRectangle.Location, upperGradientRectangle.Size);
                upperBrushRectangle.Inflate(0, 1);

                using (Brush upperGradientBrush = new LinearGradientBrush(upperBrushRectangle, upperGradientColor1, upperGradientColor2, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(upperGradientBrush, upperGradientRectangle);
                }
            }

            //Render shadow:
            int shadowTansparencyValue = transparency == 255 ? 30 : 15;
            Color shadowColor = Color.FromArgb(shadowTansparencyValue, Color.Black);

            using (Pen shadowPen = new Pen(shadowColor))
            {
                g.DrawLine(shadowPen, g.ClipBounds.X, g.ClipBounds.Y + 1, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + 1);
                g.DrawLine(shadowPen, g.ClipBounds.X + 1, g.ClipBounds.Y, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y);

                g.DrawLine(shadowPen, g.ClipBounds.X, g.ClipBounds.Y + 2, g.ClipBounds.X, g.ClipBounds.Y + g.ClipBounds.Height - 3);
                g.DrawLine(shadowPen, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + 2, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + g.ClipBounds.Height - 3);

                g.DrawLine(shadowPen, g.ClipBounds.X, g.ClipBounds.Y + g.ClipBounds.Height - 2, g.ClipBounds.X + g.ClipBounds.Width - 1, g.ClipBounds.Y + g.ClipBounds.Height - 2);
                g.DrawLine(shadowPen, g.ClipBounds.X + 1, g.ClipBounds.Y + g.ClipBounds.Height - 1, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + g.ClipBounds.Height - 1);
            }

            //Draw slider border
            Color borderColor = isHovered ? Color.White : Color.FromArgb(transparency, 210, 210, 210);

            using (Pen borderPen = new Pen(borderColor))
            {
                g.DrawLine(borderPen, g.ClipBounds.X + 2, g.ClipBounds.Y + 1, g.ClipBounds.X + g.ClipBounds.Width - 3, g.ClipBounds.Y + 1);
                g.DrawLine(borderPen, g.ClipBounds.X + 1, g.ClipBounds.Y + 2, g.ClipBounds.X + 1, g.ClipBounds.Y + g.ClipBounds.Height - 3);
                g.DrawLine(borderPen, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + 2, g.ClipBounds.X + g.ClipBounds.Width - 2, g.ClipBounds.Y + g.ClipBounds.Height - 3);
                g.DrawLine(borderPen, g.ClipBounds.X + 2, g.ClipBounds.Y + g.ClipBounds.Height - 2, g.ClipBounds.X + g.ClipBounds.Width - 3, g.ClipBounds.Y + g.ClipBounds.Height - 2);
            }

            Color innerBorderColor = isHovered ? Color.FromArgb(transparency, 250, 250, 250) : Color.FromArgb(transparency, 208, 208, 208);

            using (Pen borderPen = new Pen(innerBorderColor))
            {
                g.DrawLine(borderPen, g.ClipBounds.X + 2, g.ClipBounds.Y + g.ClipBounds.Height - 3, g.ClipBounds.X + g.ClipBounds.Width - 3, g.ClipBounds.Y + g.ClipBounds.Height - 3);
            }
        }

        #endregion Slider
    }
    #endregion

    #endregion
}
