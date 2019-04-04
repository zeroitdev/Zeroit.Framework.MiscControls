// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SegmentDisplay.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{

    #region LB7SegmentDisplay 

    #region Control
    /// <summary>
    /// Description of LB7SegmentDisplay.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
    public partial class ZeroitLB7SegmentDisplay : ZeroitLBIndustrialCtrlBase
    {
        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLB7SegmentDisplay"/> class.
        /// </summary>
        public ZeroitLB7SegmentDisplay()
        {
            InitializeComponent();
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// The value
        /// </summary>
        public int val = 0;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [
            Category("Display"),
            Description("Value of the display")
        ]
        public int Value
        {
            set { this.val = value; this.Invalidate(); }
            get { return this.val; }
        }

        /// <summary>
        /// The show dp
        /// </summary>
        private bool showDp = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show dp].
        /// </summary>
        /// <value><c>true</c> if [show dp]; otherwise, <c>false</c>.</value>
        [
            Category("Display"),
            Description("Show the point of the display")
        ]
        public bool ShowDP
        {
            set { this.showDp = value; this.Invalidate(); }
            get { return this.showDp; }
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLB7SegmentDisplayRenderer();
        }
        #endregion
    }
    #endregion

    #region Designer Generated
    partial class ZeroitLB7SegmentDisplay
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LB7SegmentDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LB7SegmentDisplay";
            this.Size = new System.Drawing.Size(44, 65);
            this.ResumeLayout(false);
        }
    }
    #endregion

    #region LB7SegmentDisplayRenderer
    /// <summary>
    /// Description of LB7SegmentDisplayRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBRendererBase" />
	public class ZeroitLB7SegmentDisplayRenderer : ZeroitLBRendererBase
    {
        #region (* Constants *)
        /// <summary>
        /// The width pixel
        /// </summary>
        public const int WIDTH_PIXEL = 11;
        /// <summary>
        /// The height pixels
        /// </summary>
        public const int HEIGHT_PIXELS = 18;
        #endregion

        #region (* Variables *)
        /// <summary>
        /// Segments data array
        /// </summary>
        protected SegmentDictionary segments = new SegmentDictionary();
        /// <summary>
        /// Defaults points coordinates
        /// </summary>
        protected PointsList defPoints = new PointsList();
        /// <summary>
        /// List of the points coordinates
        /// </summary>
        protected PointsList points = new PointsList();
        /// <summary>
        /// Segments list of a value
        /// </summary>
        protected SegmentsValueDictionary valuesSegments = new SegmentsValueDictionary();
        /// <summary>
        /// Rectangle of the dp
        /// </summary>
        protected RectangleF rectDP = new RectangleF();
        #endregion

        #region (* Contructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLB7SegmentDisplayRenderer"/> class.
        /// </summary>
        public ZeroitLB7SegmentDisplayRenderer()
        {
            this.CreateSegmetsData();
            this.CreateDefPointsCoordinates();
            this.CreateSegmentsValuesList();
            this.UpdatePointsCoordinates();
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Update the renderer
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool Update()
        {
            this.UpdatePointsCoordinates();
            return true;
        }

        /// <summary>
        /// Drawing method
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <exception cref="System.ArgumentNullException">Gr</exception>
        /// <exception cref="System.NullReferenceException">Associated control is not valid</exception>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            ZeroitLB7SegmentDisplay ctrl = this.Display;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            RectangleF _rc = new RectangleF(0, 0, ctrl.Width, ctrl.Height);
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DrawBackground(Gr, _rc);
            this.DrawOffSegments(Gr, _rc);
            this.DrawValue(Gr, _rc);
        }
        #endregion

        #region (* Properies *)
        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>The display.</value>
        [Browsable(false)]
        public ZeroitLB7SegmentDisplay Display
        {
            set { this.Control = value; }
            get { return this.Control as ZeroitLB7SegmentDisplay; }
        }

        /// <summary>
        /// Gets the segments.
        /// </summary>
        /// <value>The segments.</value>
        [Browsable(false)]
        public SegmentDictionary Segments
        {
            get { return this.segments; }
        }
        #endregion

        #region (* Virtual methods *)
        /// <summary>
        /// Creation of the default points list of the
        /// all segments
        /// </summary>
        protected virtual void CreateDefPointsCoordinates()
        {
            PointF pt = new PointF(3F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 8F);
            this.defPoints.Add(pt);
        }

        /// <summary>
        /// Create the dictionary of the
        /// segment coordinates
        /// </summary>
        protected virtual void CreateSegmetsData()
        {
            this.Segments.Clear();

            Segment s = new Segment();
            s.PointsIndexs[0] = 0;
            s.PointsIndexs[1] = 1;
            s.PointsIndexs[2] = 2;
            s.PointsIndexs[3] = 19;
            s.PointsIndexs[4] = 18;
            s.PointsIndexs[5] = 17;
            this.Segments.Add('A', s);

            s = new Segment();
            s.PointsIndexs[0] = 2;
            s.PointsIndexs[1] = 3;
            s.PointsIndexs[2] = 4;
            s.PointsIndexs[3] = 5;
            s.PointsIndexs[4] = 20;
            s.PointsIndexs[5] = 19;
            this.Segments.Add('B', s);

            s = new Segment();
            s.PointsIndexs[0] = 6;
            s.PointsIndexs[1] = 7;
            s.PointsIndexs[2] = 8;
            s.PointsIndexs[3] = 22;
            s.PointsIndexs[4] = 21;
            s.PointsIndexs[5] = 5;
            this.Segments.Add('C', s);

            s = new Segment();
            s.PointsIndexs[0] = 9;
            s.PointsIndexs[1] = 10;
            s.PointsIndexs[2] = 11;
            s.PointsIndexs[3] = 23;
            s.PointsIndexs[4] = 22;
            s.PointsIndexs[5] = 8;
            this.Segments.Add('D', s);

            s = new Segment();
            s.PointsIndexs[0] = 12;
            s.PointsIndexs[1] = 13;
            s.PointsIndexs[2] = 14;
            s.PointsIndexs[3] = 24;
            s.PointsIndexs[4] = 23;
            s.PointsIndexs[5] = 11;
            this.Segments.Add('E', s);

            s = new Segment();
            s.PointsIndexs[0] = 15;
            s.PointsIndexs[1] = 16;
            s.PointsIndexs[2] = 17;
            s.PointsIndexs[3] = 18;
            s.PointsIndexs[4] = 25;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('F', s);

            s = new Segment();
            s.PointsIndexs[0] = 25;
            s.PointsIndexs[1] = 20;
            s.PointsIndexs[2] = 5;
            s.PointsIndexs[3] = 21;
            s.PointsIndexs[4] = 24;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('G', s);
        }

        /// <summary>
        /// Create the dictionary of the segments
        /// for the number values
        /// </summary>
        protected virtual void CreateSegmentsValuesList()
        {
            SegmentsList list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            this.valuesSegments.Add(0, list);

            list = new SegmentsList();
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(1, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('E');
            list.Add('D');
            this.valuesSegments.Add(2, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(3, list);

            list = new SegmentsList();
            list.Add('F');
            list.Add('G');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(4, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(5, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            this.valuesSegments.Add(6, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(7, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(8, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(9, list);

            list = new SegmentsList();
            list.Add('G');
            this.valuesSegments.Add((int)'-', list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add((int)'E', list);
        }

        /// <summary>
        /// Calculate the points coordinates for drawing
        /// with the ratio of the control
        /// </summary>
        protected virtual void UpdatePointsCoordinates()
        {
            this.points.Clear();

            double rappW = 1;
            double rappH = 1;

            if (this.Display != null)
            {
                rappW = (double)this.Display.Width / (double)WIDTH_PIXEL;
                rappH = (double)this.Display.Height / (double)HEIGHT_PIXELS;
            }

            for (int idx = 0; idx < this.defPoints.Count; idx++)
            {
                PointF ptDef = this.defPoints[idx];
                PointF pt = new PointF((float)((double)ptDef.X * rappW), (float)((double)ptDef.Y * rappH));
                this.points.Add(pt);
            }

            this.rectDP.X = this.points[7].X - (float)(0.5 * rappW);
            this.rectDP.Y = this.points[8].Y;
            this.rectDP.Width = (float)rappW;
            this.rectDP.Height = (float)rappH;
        }

        /// <summary>
        /// Draw the control background
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            Color c = this.Display.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Display.Width, this.Display.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draw all the segments in the off state
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool DrawOffSegments(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            //            SolidBrush br = new SolidBrush(LBColorManager.StepColor(this.Display.ForeColor, 30));
            Color clr = Color.FromArgb(70, this.Display.ForeColor);
            SolidBrush br = new SolidBrush(clr);

            foreach (Segment seg in this.Segments.Values)
            {
                GraphicsPath pth = new GraphicsPath();

                for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                {
                    PointF pt1 = this.points[seg.PointsIndexs[idx]];
                    PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                    pth.AddLine(pt1, pt2);
                }
                pth.CloseFigure();

                gr.FillPath(br, pth);

                pth.Dispose();
            }

            gr.FillEllipse(br, this.rectDP);

            br.Dispose();
            return true;
        }

        /// <summary>
        /// Draw the segments in on state
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            if (this.valuesSegments.Contains(this.Display.Value) == false)
                return false;

            SegmentsList list = this.valuesSegments[this.Display.Value];
            if (list == null)
                return false;

            SolidBrush br = new SolidBrush(this.Display.ForeColor);

            foreach (char ch in list)
            {
                Segment seg = this.segments[ch];
                if (seg != null)
                {
                    GraphicsPath pth = new GraphicsPath();

                    for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                    {
                        PointF pt1 = this.points[seg.PointsIndexs[idx]];
                        PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                        pth.AddLine(pt1, pt2);
                    }
                    pth.CloseFigure();

                    gr.FillPath(br, pth);

                    pth.Dispose();
                }
            }

            if (this.Display.ShowDP != false)
                gr.FillEllipse(br, this.rectDP);

            br.Dispose();

            return true;
        }
        #endregion
    }

    /// <summary>
    /// Dictionary for the segment associated
    /// to the number
    /// </summary>
    /// <seealso cref="System.Collections.DictionaryBase" />
    public class SegmentDictionary : DictionaryBase
    {
        /// <summary>
        /// Gets or sets the <see cref="Segment"/> with the specified ch.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns>Segment.</returns>
        public Segment this[char ch]
        {
            set
            {
                if (Dictionary.Contains(ch) == false)
                    this.Add(ch, value);
                else
                    Dictionary[ch] = value;
            }
            get
            {
                if (Dictionary.Contains(ch) == false)
                    return null;

                return (Segment)this.Dictionary[ch];
            }
        }

        /// <summary>
        /// Adds the specified ch.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <param name="seg">The seg.</param>
        public void Add(char ch, Segment seg)
        {
            if (this.Contains(ch) == false)
                this.Dictionary.Add(ch, seg);
            else
                this[ch] = seg;
        }

        /// <summary>
        /// Determines whether [contains] [the specified ch].
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns><c>true</c> if [contains] [the specified ch]; otherwise, <c>false</c>.</returns>
        public bool Contains(char ch)
        {
            return this.Dictionary.Contains(ch);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        /// <value>The values.</value>
        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }

    /// <summary>
    /// Class for the segment data
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// The points
        /// </summary>
        private int[] points = new int[6];
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        public Segment()
        {
        }

        /// <summary>
        /// Gets the points indexs.
        /// </summary>
        /// <value>The points indexs.</value>
        public int[] PointsIndexs
        {
            get { return this.points; }
        }
    }

    /// <summary>
    /// Points list
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{System.Drawing.PointF}" />
    public class PointsList : List<PointF>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointsList"/> class.
        /// </summary>
        public PointsList()
        {
        }
    }

    /// <summary>
    /// Segments list
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{System.Char}" />
    public class SegmentsList : List<char>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentsList"/> class.
        /// </summary>
        public SegmentsList()
        {
        }
    }

    /// <summary>
    /// Dictionary for value to segments
    /// </summary>
    /// <seealso cref="System.Collections.DictionaryBase" />
    public class SegmentsValueDictionary : DictionaryBase
    {
        /// <summary>
        /// Gets or sets the <see cref="SegmentsList"/> with the specified number.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>SegmentsList.</returns>
        public SegmentsList this[int num]
        {
            set
            {
                if (Dictionary.Contains(num) == false)
                    this.Add(num, value);
                else
                    Dictionary[num] = value;
            }
            get
            {
                if (Dictionary.Contains(num) == false)
                    return null;

                return (SegmentsList)this.Dictionary[num];
            }
        }

        /// <summary>
        /// Adds the specified number.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="seg">The seg.</param>
        public void Add(int num, SegmentsList seg)
        {
            if (this.Contains(num) == false)
                this.Dictionary.Add(num, seg);
            else
                this[num] = seg;
        }

        /// <summary>
        /// Determines whether [contains] [the specified ch].
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns><c>true</c> if [contains] [the specified ch]; otherwise, <c>false</c>.</returns>
        public bool Contains(int ch)
        {
            return this.Dictionary.Contains(ch);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        /// <value>The values.</value>
        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }
    #endregion

    #endregion


}
