// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Primitives.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region 2D PRIMITIVE

    /// <summary>
    /// A class collection for rendering primitive controls.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitPrimitives : Control
    {
        #region Private Fields        
        /// <summary>
        /// Enum representing the shape type.
        /// </summary>
        public enum ShapeType
        {
            /// <summary>
            /// The line
            /// </summary>
            LINE,
            /// <summary>
            /// The circle
            /// </summary>
            CIRCLE,
            /// <summary>
            /// The rect
            /// </summary>
            RECT
            /*, FREEHAND, NONE*/
        };
        /// <summary>
        /// The draw type
        /// </summary>
        private ShapeType drawType = ShapeType.RECT;
        /// <summary>
        /// The enable
        /// </summary>
        private bool enable = true;
        /// <summary>
        /// The pen color
        /// </summary>
        private Color penColor = Color.Green;
        /// <summary>
        /// The pen width
        /// </summary>
        private float penWidth = 1f;
        /// <summary>
        /// The brush color
        /// </summary>
        private Color brushColor = Color.Yellow;

        /// <summary>
        /// The lines
        /// </summary>
        private List<Rectangle> lines = new List<Rectangle>();
        /// <summary>
        /// The circles
        /// </summary>
        private List<Rectangle> circles = new List<Rectangle>();
        /// <summary>
        /// The fill circles
        /// </summary>
        private List<Rectangle> fillCircles = new List<Rectangle>();
        /// <summary>
        /// The recs
        /// </summary>
        private List<Rectangle> recs = new List<Rectangle>();
        /// <summary>
        /// The fill recs
        /// </summary>
        private List<Rectangle> fillRecs = new List<Rectangle>();
        /// <summary>
        /// The freehand
        /// </summary>
        private List<Point> freehand = new List<Point>();

        /// <summary>
        /// The memory g
        /// </summary>
        Graphics memG = null;
        /// <summary>
        /// The memory BMP
        /// </summary>
        Bitmap memBmp = null;
        #endregion


        #region Public Properties        
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return penColor; }
            set
            {
                penColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public ShapeType Shape
        {
            get { return drawType; }
            set
            {
                drawType = value;
                Invalidate();
            }
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPrimitives" /> class.
        /// </summary>
        public ZeroitPrimitives()
        {

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Point[] star = new Point[10];
            star[0] = new Point(20, 0); //A
            star[1] = new Point(35, 20); //B
            star[2] = new Point(20, 40); //C
            star[3] = new Point(35, 50); //D
            star[4] = new Point(40, 80); //E
            star[5] = new Point(55, 50); //F
            star[6] = new Point(100, 40); //G
            star[7] = new Point(55, 20); //H
            star[8] = new Point(100, 0); //I
            star[9] = new Point(40, 15); //J

            switch (drawType)
            {
                case ShapeType.LINE:
                    g.DrawLine(new Pen(penColor, penWidth), new Point(0, 0), new Point(this.Width, 0));
                    break;
                case ShapeType.CIRCLE:
                    g.DrawEllipse(new Pen(penColor, penWidth), new Rectangle(new Point((int)penWidth, 0), new Size(this.Width - (int)penWidth * 2, this.Height - (int)penWidth * 2)));
                    break;
                case ShapeType.RECT:
                    g.DrawRectangle(new Pen(penColor, penWidth), new Rectangle(new Point((int)penWidth, 0), new Size(this.Width - (int)penWidth * 2, this.Height - (int)penWidth * 2)));
                    break;
                //case ShapeType.FREEHAND:
                //    g.DrawPolygon(new Pen(Color.Black), star);
                //    break;
                //case ShapeType.NONE:
                //    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The start point
        /// </summary>
        private Point startPoint;
        /// <summary>
        /// The end point
        /// </summary>
        private Point endPoint;

        /// <summary>
        /// Finds the enclosing rect.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <param name="en">The en.</param>
        /// <returns>Region.</returns>
        private Region FindEnclosingRect(Point st, Point en)
        {
            double r = Math.Sqrt(Math.Pow((en.Y - st.Y), 2) + Math.Pow((en.X - st.X), 2));
            Rectangle rc = new Rectangle(0, 0, (int)r, 0);
            rc.Inflate((int)penWidth + 1, (int)penWidth + 1);
            Region rgn = new Region(rc);

            double m = (((double)en.Y - st.Y)) / (en.X - st.X);
            double angle = Math.Atan(m);

            if (en.X < st.X)
                angle += 3.14;
            Matrix mtrx = new Matrix();
            mtrx.Reset();
            mtrx.Rotate((float)(angle * 180 * 7 / 22));
            rgn.Transform(mtrx);
            mtrx.Reset();
            mtrx.Translate(st.X, st.Y);
            rgn.Transform(mtrx);

            return rgn;
        }

        /// <summary>
        /// Rectangles the specified 1.
        /// </summary>
        /// <param name="_1">The 1.</param>
        /// <param name="_2">The 2.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle Rectangle(Point _1, Point _2)
        {
            return new Rectangle((_1.X < _2.X) ? _1.X : _2.X, (_1.Y < _2.Y) ? _1.Y : _2.Y,
                Math.Abs(_2.X - _1.X), Math.Abs(_2.Y - _1.Y));
        }

        /// <summary>
        /// Finds the outer rect.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <param name="en">The en.</param>
        /// <returns>Region.</returns>
        private Region FindOuterRect(Point st, Point en)
        {
            Rectangle rc = Rectangle(st, en);
            rc.Inflate(2 * (int)penWidth, 2 * (int)penWidth);
            Region rgn = new Region(rc);
            rc = Rectangle(st, en);
            if (/*!Fill.Checked &&*/ rc.Width > (4 * penWidth) && rc.Height > (4 * penWidth))
            {
                rc.Inflate(-2 * (int)penWidth, -2 * (int)penWidth);
                rgn.Exclude(rc);
            }
            return rgn;
        }

        /// <summary>
        /// Finds the outer circle.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <param name="en">The en.</param>
        /// <returns>Region.</returns>
        private Region FindOuterCircle(Point st, Point en)
        {
            GraphicsPath gp = new GraphicsPath();
            Rectangle rc = Rectangle(st, en);
            rc.Inflate(2 * (int)penWidth, 2 * (int)penWidth);
            gp.AddEllipse(rc);
            Region rgn = new Region(gp);
            rc = Rectangle(st, en);
            if (/*!Fill.Checked && */rc.Width > (4 * penWidth) && rc.Height > (4 * penWidth))
            {
                gp.Reset();
                rc.Inflate(-2 * (int)penWidth, -2 * (int)penWidth);
                gp.AddEllipse(rc);
                rgn.Exclude(gp);
            }
            return rgn;
        }

        /// <summary>
        /// Updates the line.
        /// </summary>
        /// <param name="_loc">The loc.</param>
        private void UpdateLine(Point _loc)
        {
            GraphicsPath path = new GraphicsPath();

            double m = 0f, angle = 0f, r = -10f, x = 0f, y = 0f;

            if ((endPoint.Y - startPoint.Y) == 0)
                x = ((endPoint.X - startPoint.X) > 0) ? 2f : ((endPoint.X - startPoint.X) < 0) ? -2f : 0f;

            if ((endPoint.X - startPoint.X) == 0)
                y = ((endPoint.Y - startPoint.Y) > 0) ? 2f : ((endPoint.Y - startPoint.Y) < 0) ? -2f : 0f;

            Point stPoint = startPoint;
            Point enPoint = endPoint;
            if ((endPoint.Y - startPoint.Y) != 0 && (endPoint.X - startPoint.X) != 0)
            {
                m = ((double)endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X);
                angle = Math.Atan(m);
                x = r * Math.Cos(angle);
                y = r * Math.Sin(angle);

            }
            enPoint += new Size((int)x, (int)y);
            stPoint -= new Size((int)x, (int)y);
            path.AddLine(stPoint, enPoint);

            endPoint = _loc;

            stPoint = startPoint;
            enPoint = endPoint;

            if ((endPoint.Y - startPoint.Y) == 0)
                x = ((endPoint.X - startPoint.X) > 0) ? 2f : ((endPoint.X - startPoint.X) < 0) ? -2f : 0f;

            if ((endPoint.X - startPoint.X) == 0)
                y = ((endPoint.Y - startPoint.Y) > 0) ? 2f : ((endPoint.Y - startPoint.Y) < 0) ? -2f : 0f;

            if ((endPoint.Y - startPoint.Y) != 0 && (endPoint.X - startPoint.X) != 0)
            {
                m = ((double)endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X);
                angle = Math.Atan(m);
                x = r * Math.Cos(angle);
                y = r * Math.Sin(angle);

            }

            enPoint += new Size((int)x, (int)y);
            stPoint -= new Size((int)x, (int)y);
            path.AddLine(stPoint, enPoint);

            Pen widenPen = new Pen(Color.Black, 3f);
            path.Widen(widenPen);
            widenPen.Dispose();

            Region rgn = new Region(path);

            Parent.Invalidate(rgn);
        } //Useless

        /// <summary>
        /// Updates the line1.
        /// </summary>
        /// <param name="_loc">The loc.</param>
        private void UpdateLine1(Point _loc)
        {
            Parent.Invalidate(FindEnclosingRect(startPoint, endPoint));
            endPoint = _loc;
            Parent.Invalidate(FindEnclosingRect(startPoint, endPoint));
        }

        /// <summary>
        /// Updates the rect.
        /// </summary>
        /// <param name="_loc">The loc.</param>
        private void UpdateRect(Point _loc)
        {
            Parent.Invalidate(FindOuterRect(startPoint, endPoint));
            endPoint = _loc;
            Parent.Invalidate(FindOuterRect(startPoint, endPoint));
        }

        /// <summary>
        /// Updates the circle.
        /// </summary>
        /// <param name="_loc">The loc.</param>
        private void UpdateCircle(Point _loc)
        {
            Parent.Invalidate(FindOuterCircle(startPoint, endPoint));
            //    Region updateRegion = FindOuterCircle(startPoint, endPoint);
            endPoint = _loc;
            //updateRegion.Union(FindOuterCircle(startPoint, endPoint));
            Parent.Invalidate(FindOuterCircle(startPoint, endPoint));
            //Parent.Invalidate(updateRegion);                
        }

        //private void UpdateFreehand(Point _loc)
        //{
        //    startPoint = endPoint;
        //    //freehand.Add(startPoint);
        //    endPoint = _loc;
        //    DrawOnMem(memG);
        //    Region updateRgn = FindEnclosingRect(startPoint, endPoint);
        //    startPoint = Point.Empty;
        //    Parent.Invalidate(updateRgn);
        //}
        //private void DrawingMove(Point _loc)
        //{
        //    switch (drawType)
        //    {
        //        case ShapeType.LINE:
        //            UpdateLine1(_loc);
        //            break;
        //        case ShapeType.CIRCLE:
        //            UpdateCircle(_loc);
        //            break;
        //        case ShapeType.RECT:
        //            UpdateRect(_loc);
        //            break;
        //        case ShapeType.FREEHAND:
        //            UpdateFreehand(_loc);
        //            break;
        //        case ShapeType.NONE:
        //            break;
        //        default:
        //            break;
        //    }

        //}

        /// <summary>
        /// Drawings the start.
        /// </summary>
        /// <param name="_loc">The loc.</param>
        private void DrawingStart(Point _loc)
        {
            endPoint = startPoint = _loc;
        }


        //private void DrawingEnd(Point _loc)
        //{
        //    if (_loc - new Size(startPoint.X, startPoint.Y) != Point.Empty)
        //        switch (drawType)
        //        {
        //            case ShapeType.LINE:
        //                UpdateLine1(_loc);
        //                DrawOnMem(memG);
        //                //lines.Add(Rectangle(startPoint, endPoint));
        //                break;
        //            case ShapeType.CIRCLE:
        //                UpdateCircle(_loc);
        //                DrawOnMem(memG);
        //                //if(brushColor==Color.Transparent)
        //                //    circles.Add(Rectangle(startPoint, endPoint));
        //                //else
        //                //    fillCircles.Add(Rectangle(startPoint, endPoint));
        //                break;
        //            case ShapeType.RECT:
        //                UpdateRect(_loc);
        //                DrawOnMem(memG);
        //                //if (brushColor == Color.Transparent)
        //                //    recs.Add(Rectangle(startPoint,endPoint));
        //                //else
        //                //    fillRecs.Add(Rectangle(startPoint,endPoint));
        //                break;
        //            case ShapeType.FREEHAND:
        //                break;
        //            case ShapeType.NONE:
        //                break;
        //            default:
        //                break;
        //        }
        //    startPoint = endPoint = Point.Empty;
        //}



    }
    #endregion
}
