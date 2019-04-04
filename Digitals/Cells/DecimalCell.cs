// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DecimalCell.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable;

namespace Zeroit.Framework.MiscControls.Digitals.Cells
{
    /// <summary>
    /// A cell to display decimal point, comma, colon and semi-colon
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitDigitalCell" />
    [ToolboxItem(true)]
    [Description("A cell to display decimal point, comma, colon and semi-colon")]
    public partial class ZeroitDecimalCell : ZeroitDigitalCell
    {
        //this cell intended to be half the width of a 7-segment cell
        /// <summary>
        /// The padding ratio y
        /// </summary>
        protected const double PADDING_RATIO_Y = .0446d;
        /// <summary>
        /// The barsize ratio x
        /// </summary>
        protected const double BARSIZE_RATIO_X = .3276d;
        /// <summary>
        /// The barsize ratio y
        /// </summary>
        protected const double BARSIZE_RATIO_Y = .1049d;
        /// <summary>
        /// The comma pad
        /// </summary>
        protected const double COMMA_PAD = .02d;

        /// <summary>
        /// The segment map
        /// </summary>
        private Dictionary<char, bool[]> SEGMENT_MAP = new Dictionary<char, bool[]>()
        {
            {'.', new bool[3] { false, true, false } },
            {',', new bool[3] { false, true, true } },
            {':', new bool[3] { true, true, false } },
            {';', new bool[3] { true, true, true } }
        };

        /// <summary>
        /// The m segment a
        /// </summary>
        protected DigitalBar m_segmentA = new DigitalBar(SegmentOrientation.Horizontal);
        /// <summary>
        /// The m segment b
        /// </summary>
        protected DigitalBar m_segmentB = new DigitalBar(SegmentOrientation.Vertical);
        /// <summary>
        /// The m segment c
        /// </summary>
        protected DigitalBar m_segmentC = new DigitalBar(SegmentOrientation.Vertical);

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDecimalCell"/> class.
        /// </summary>
        public ZeroitDecimalCell()
        {
            Value = '.';

            m_segmentA.Color = this.ForeColor;
            m_segmentB.Color = this.ForeColor;
            m_segmentC.Color = this.ForeColor;

            m_segmentA.OpacityWhenOff = this.OpacityWhenOff;
            m_segmentB.OpacityWhenOff = this.OpacityWhenOff;
            m_segmentC.OpacityWhenOff = this.OpacityWhenOff;

            //never use internal padding for this type of cell
            m_segmentA.Padding = 0;
            m_segmentB.Padding = 0;
            m_segmentC.Padding = 0;

            //corners for the comma
            m_segmentC.Corners = SegmentCorners.TopLeft | SegmentCorners.TopRight | SegmentCorners.BottomRight;

            Segments.Add(m_segmentA);
            Segments.Add(m_segmentB);
            Segments.Add(m_segmentC);

            InitializeComponent();
        }

        /// <summary>
        /// When overriden, this function should recalculate the size/location
        /// of any segments given the containing rectangle
        /// </summary>
        /// <param name="container">the parent container</param>
        protected override void CalculateSegments(RectangleF container)
        {
            float paddingY = (float)(PADDING_RATIO_Y * container.Height);
            float segWidthX = (float)(BARSIZE_RATIO_X * container.Width);
            float segWidthY = (float)(BARSIZE_RATIO_Y * container.Height);
            float commaPad = (float)(COMMA_PAD * container.Height);

            float aYStart = container.Top + paddingY + segWidthY;
            float bYStart = container.Bottom - (paddingY + (segWidthY * 2));
            float startX = container.X + ((container.Width - segWidthX) / 2f);
            float cHeight = (container.Bottom - (bYStart + segWidthY)) - commaPad;

            RectangleF rectA = new RectangleF(startX, aYStart, segWidthX, segWidthY);
            RectangleF rectB = new RectangleF(startX, bYStart, segWidthX, segWidthY);
            RectangleF rectC = new RectangleF(startX, bYStart + segWidthY, segWidthX, cHeight);

            m_segmentA.TipLength = 0;
            m_segmentA.CalculatePaths(rectA);

            m_segmentB.TipLength = 0;
            m_segmentB.CalculatePaths(rectB);

            m_segmentC.TipLength = cHeight / 2f;
            m_segmentC.CalculatePaths(rectC);
        }

        /// <summary>
        /// When overridden, tells the control what values are acceptable for the Value parameter.
        /// </summary>
        /// <param name="value">The value in question</param>
        /// <returns>True if the value specified can be handled</returns>
        protected override bool CanHandleValue(char value)
        {
            return (value == '.') || (value == ',') ||
                   (value == ':') || (value == ';');
        }

        /// <summary>
        /// When overridden, handles setting segments on/off and corners.
        /// </summary>
        protected override void UpdateSegmentsOnOff()
        {
            bool[] segs = SEGMENT_MAP[Value];

            m_segmentA.IsOn = segs[0];
            m_segmentB.IsOn = segs[1];
            m_segmentC.IsOn = segs[2];
        }
    }
}
