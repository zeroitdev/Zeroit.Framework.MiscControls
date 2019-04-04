// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BezierSplines.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Bezier Curve or Splines
    /// <summary>
    /// Class BazierSplines.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class BazierSplines : Control
    {
        /// <summary>
        /// Size of array.
        /// </summary>
        public static int Counter = 10;

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public int Counts
        {
            get { return Counter; }
            set
            {
                Counter = value;
                //Invalidate();
            }
        }

        /// <summary>
        /// Widget: an array of widgets.
        /// </summary>
        private Point[] _widget = new Point[Counter];
        /// <summary>
        /// Gets or sets the widget.
        /// </summary>
        /// <value>The widget.</value>
        public Point[] Widget
        {
            get { return _widget; }
            set
            {
                _widget = value;
                //Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BazierSplines"/> class.
        /// </summary>
        public BazierSplines()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = new Size(Width, Height);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            // Create pen.
            Pen blackPen = new Pen(Color.Black, 1);

            // Create points for curve.
            Point start = new Point(100, 100);
            Point control1 = new Point(100, 10);
            Point control2 = new Point(200, 50);
            Point end1 = new Point(40, 100);
            Point control3 = new Point(100, 150);
            Point control4 = new Point(500, 250);
            Point end2 = new Point(500, 300);


            Point[] bezierPoints = _widget;

            //Point[] bezierPoints =
            //         {
            //     start, control1, control2, end1,
            //     control3, control4, end2
            // };

            // Draw arc to screen.
            e.Graphics.DrawBeziers(blackPen, bezierPoints);

        }
    }
    #endregion

}
