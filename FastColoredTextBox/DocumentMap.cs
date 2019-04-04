// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DocumentMap.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Shows document map of FCTB
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitDocumentMap : Control
    {
        /// <summary>
        /// The target changed
        /// </summary>
        public EventHandler TargetChanged;

        /// <summary>
        /// The target
        /// </summary>
        ZeroitCodeTextBox target;
        /// <summary>
        /// The scale
        /// </summary>
        private float scale = 0.3f;
        /// <summary>
        /// The need repaint
        /// </summary>
        private bool needRepaint = true;
        /// <summary>
        /// The start place
        /// </summary>
        private Place startPlace = Place.Empty;
        /// <summary>
        /// The scrollbar visible
        /// </summary>
        private bool scrollbarVisible = true;

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        [Description("Target ZeroitCodeTextBox")]
        public ZeroitCodeTextBox Target
        {
            get { return target; }
            set
            {
                if (target != null)
                    UnSubscribe(target);

                target = value;
                if (value != null)
                {
                    Subscribe(target);
                }
                OnTargetChanged();
            }
        }

        /// <summary>
        /// Scale
        /// </summary>
        /// <value>The scale.</value>
        [Description("Scale")]
        [DefaultValue(0.3f)]
        public float Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                NeedRepaint();
            }
        }

        /// <summary>
        /// Scrollbar visibility
        /// </summary>
        /// <value><c>true</c> if [scrollbar visible]; otherwise, <c>false</c>.</value>
        [Description("Scrollbar visibility")]
        [DefaultValue(true)]
        public bool ScrollbarVisible
        {
            get { return scrollbarVisible; }
            set
            {
                scrollbarVisible = value;
                NeedRepaint();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDocumentMap"/> class.
        /// </summary>
        public ZeroitDocumentMap()
        {
            ForeColor = Color.Maroon;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Application.Idle += Application_Idle;
        }

        /// <summary>
        /// Handles the Idle event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_Idle(object sender, EventArgs e)
        {
            if(needRepaint)
                Invalidate();
        }

        /// <summary>
        /// Called when [target changed].
        /// </summary>
        protected virtual void OnTargetChanged()
        {
            NeedRepaint();

            if (TargetChanged != null)
                TargetChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="target">The target.</param>
        protected virtual void UnSubscribe(ZeroitCodeTextBox target)
        {
            target.Scroll -= new ScrollEventHandler(Target_Scroll);
            target.SelectionChangedDelayed -= new EventHandler(Target_SelectionChanged);
            target.VisibleRangeChanged -= new EventHandler(Target_VisibleRangeChanged);
        }

        /// <summary>
        /// Subscribes the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        protected virtual void Subscribe(ZeroitCodeTextBox target)
        {
            target.Scroll += new ScrollEventHandler(Target_Scroll);
            target.SelectionChangedDelayed += new EventHandler(Target_SelectionChanged);
            target.VisibleRangeChanged += new EventHandler(Target_VisibleRangeChanged);
        }

        /// <summary>
        /// Handles the VisibleRangeChanged event of the Target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void Target_VisibleRangeChanged(object sender, EventArgs e)
        {
            NeedRepaint();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the Target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void Target_SelectionChanged(object sender, EventArgs e)
        {
            NeedRepaint();
        }

        /// <summary>
        /// Handles the Scroll event of the Target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
        protected virtual void Target_Scroll(object sender, ScrollEventArgs e)
        {
            NeedRepaint();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            NeedRepaint();
        }

        /// <summary>
        /// Needs the repaint.
        /// </summary>
        public void NeedRepaint()
        {
            needRepaint = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (target == null)
                return;

            var zoom = this.Scale * 100 / target.Zoom;

            if (zoom <= float.Epsilon)
                return;

            //calc startPlace
            var r = target.VisibleRange;
            if (startPlace.iLine > r.Start.iLine)
                startPlace.iLine = r.Start.iLine;
            else
            {
                var endP = target.PlaceToPoint(r.End);
                endP.Offset(0, -(int)(ClientSize.Height / zoom) + target.CharHeight);
                var pp = target.PointToPlace(endP);
                if (pp.iLine > startPlace.iLine)
                    startPlace.iLine = pp.iLine;
            }
            startPlace.iChar = 0;
            //calc scroll pos
            var linesCount = target.Lines.Count;
            var sp1 = (float)r.Start.iLine / linesCount;
            var sp2 = (float)r.End.iLine / linesCount;

            //scale graphics
            e.Graphics.ScaleTransform(zoom, zoom);
            //draw text
            var size = new SizeF(ClientSize.Width / zoom, ClientSize.Height / zoom);
            target.DrawText(e.Graphics, startPlace, size.ToSize());

            //draw visible rect
            var p0 = target.PlaceToPoint(startPlace);
            var p1 = target.PlaceToPoint(r.Start);
            var p2 = target.PlaceToPoint(r.End);
            var y1 = p1.Y - p0.Y;
            var y2 = p2.Y + target.CharHeight - p0.Y;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var brush = new SolidBrush(Color.FromArgb(50, ForeColor)))
            using (var pen = new Pen(brush, 1 / zoom))
            {
                var rect = new Rectangle(0, y1, (int)((ClientSize.Width - 1) / zoom), y2 - y1);
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawRectangle(pen, rect);
            }

            //draw scrollbar
            if (scrollbarVisible)
            {
                e.Graphics.ResetTransform();
                e.Graphics.SmoothingMode = SmoothingMode.None;

                using (var brush = new SolidBrush(Color.FromArgb(200, ForeColor)))
                {
                    var rect = new RectangleF(ClientSize.Width - 3, ClientSize.Height*sp1, 2,
                                              ClientSize.Height*(sp2 - sp1));
                    e.Graphics.FillRectangle(brush, rect);
                }
            }

            needRepaint = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                Scroll(e.Location);
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                Scroll(e.Location);
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Scrolls the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        private void Scroll(Point point)
        {
            if (target == null)
                return;

            var zoom = this.Scale*100/target.Zoom;

            if (zoom <= float.Epsilon)
                return;

            var p0 = target.PlaceToPoint(startPlace);
            p0 = new Point(0, p0.Y + (int) (point.Y/zoom));
            var pp = target.PointToPlace(p0);
            target.DoRangeVisible(new Range(target, pp, pp), true);
            BeginInvoke((MethodInvoker)OnScroll);
        }

        /// <summary>
        /// Called when [scroll].
        /// </summary>
        private void OnScroll()
        {
            Refresh();
            target.Refresh();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Application.Idle -= Application_Idle;
                if (target != null)
                    UnSubscribe(target);
            }
            base.Dispose(disposing);
        }
    }
}
