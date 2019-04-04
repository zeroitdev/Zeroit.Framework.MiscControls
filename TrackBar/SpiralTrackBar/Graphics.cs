// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Graphics.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.HelperControls.Widgets;

namespace Zeroit.Framework.MiscControls
{
    #region Graphics

    /// <summary>
    /// Class ZeroitSpiralTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class ZeroitSpiralTrackBar
    {
        /// <summary>
        /// The track path
        /// </summary>
        private GraphicsPath trackPath;

        /// <summary>
        /// Class TrackGradientFill.
        /// </summary>
        private class TrackGradientFill
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TrackGradientFill"/> class.
            /// </summary>
            public TrackGradientFill()
            {
                Path = null;
                Color = Color.Empty;
                Brush = null;
            }

            /// <summary>
            /// The path
            /// </summary>
            public GraphicsPath Path;
            /// <summary>
            /// The color
            /// </summary>
            public Color Color;
            /// <summary>
            /// The brush
            /// </summary>
            public Brush Brush;
        }

        /// <summary>
        /// The track gradient fills
        /// </summary>
        private TrackGradientFill[] trackGradientFills;

        /// <summary>
        /// The angle inc
        /// </summary>
        private const double AngleInc = 3.0;

        /// <summary>
        /// Disposes the track path.
        /// </summary>
        private void DisposeTrackPath()
        {
            if (trackPath != null)
            {
                trackPath.Dispose();
                trackPath = null;
            }

            if (trackGradientFills != null)
            {
                for (int i = 0; i < trackGradientFills.Length; i++)
                {
                    if (trackGradientFills[i] != null)
                    {
                        if (trackGradientFills[i].Path != null)
                        {
                            trackGradientFills[i].Path.Dispose();
                            trackGradientFills[i].Path = null;
                        }
                        if (trackGradientFills[i].Brush != null)
                        {
                            trackGradientFills[i].Brush.Dispose();
                            trackGradientFills[i].Brush = null;
                        }
                        trackGradientFills[i] = null;
                    }
                }
                trackGradientFills = null;
            }
        }

        /// <summary>
        /// Calculates the track path.
        /// </summary>
        private void CalcTrackPath()
        {
            if (trackPath == null)
            {
                // Build list of points at center of track
                // slope values are only required if track path is thick
                List<PointD> pointList = new List<PointD>();
                List<PointD> slopeList = new List<PointD>();

                PointD p = CalcPoint(StartAngle);
                pointList.Add(p);
                PointD s = CalcSlope(StartAngle, p);
                slopeList.Add(s);

                // Two ways to build path - either by angle increments or arc increments
                // Angle increments are smoother at the beginning, and less smooth at the end
                // Inversely so for arc increments.
                // So ... start as angle and switch to arc to maintain best smoothness
                double posInc = 1.0 / Math.Ceiling(100.0 * rotations);
                double angleInc = Math.Min(3.0, 0.5 * (StopAngle - StartAngle));

                double angle = StartAngle;
                double pos = 0.0;
                while (angle + angleInc < StopAngle)
                {
                    double angle1 = angle + angleInc;
                    double angle2 = CalcAngle(pos + posInc);
                    if (angle1 < angle2)
                    {
                        angle = angle1;
                        pos = CalcPos(angle);
                    }
                    else
                    {
                        angle = angle2;
                        pos = pos + posInc;
                    }

                    p = CalcPoint(angle);
                    pointList.Add(p);
                    s = CalcSlope(angle, p);
                    slopeList.Add(s);
                }

                p = CalcPoint(StopAngle);
                pointList.Add(p);
                s = CalcSlope(StopAngle, p);
                slopeList.Add(s);

                // Now build path based on these points
                trackPath = new GraphicsPath();
                PointD[] points = pointList.ToArray();
                if (trackFillSize == 0)
                {
                    CalcTrackPathThin(points);
                }
                else
                {
                    PointD[] slopes = slopeList.ToArray();
                    CalcTrackPathThickBorder(points, slopes);
                    if (trackFill.FillType == Filler2Type.Gradient)
                    {
                        CalcTrackPathThickGradient(points, slopes);
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the track path thin.
        /// </summary>
        /// <param name="points">The points.</param>
        private void CalcTrackPathThin(PointD[] points)
        {
            PointD p1 = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                PointD p2 = points[i];
                trackPath.AddLine(D2G(p1), D2G(p2));
                p1 = p2;
            }
        }

        /// <summary>
        /// Calculates the track path thick border.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="slopes">The slopes.</param>
        private void CalcTrackPathThickBorder(PointD[] points, PointD[] slopes)
        {
            double len = 0.5 * (double)trackFillSize;

            PointD pStart = CalcPoint(points[0], slopes[0], len);

            // 1. Traverse up inside of track
            PointD p1 = pStart;
            PointD p2 = PointD.Empty;
            for (int i = 1; i < points.Length; i++)
            {
                p2 = CalcPoint(points[i], slopes[i], len);
                trackPath.AddLine(D2G(p1), D2G(p2));
                p1 = p2;
            }

            // 2. Cap at high end of track
            p2 = CalcPoint(points[points.Length - 1], slopes[points.Length - 1], -len);
            AddTrackPathEnd(trackPath, points[points.Length - 1], p1, p2, slopes[points.Length - 1]);
            p1 = p2;

            // 3. Traverse down outside of track
            for (int i = points.Length - 2; i >= 0; i--)
            {
                p2 = CalcPoint(points[i], slopes[i], -len);
                trackPath.AddLine(D2G(p1), D2G(p2));
                p1 = p2;
            }

            // 4. Cap at low end of track - done!
            AddTrackPathEnd(trackPath, points[0], p1, pStart, new PointD(-slopes[0].X, -slopes[0].Y));
        }

        /// <summary>
        /// Calculates the track path thick gradient.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="slopes">The slopes.</param>
        private void CalcTrackPathThickGradient(PointD[] points, PointD[] slopes)
        {
            double len = 0.5 * (double)trackFillSize;

            // Create a fill path for each segment in the border path
            int count = points.Length - 1;
            trackGradientFills = new TrackGradientFill[count];

            // First path may have special end
            PointD p11 = CalcPoint(points[0], slopes[0], len);
            PointD p12 = CalcPoint(points[0], slopes[0], -len);
            PointD p21 = CalcPoint(points[1], slopes[1], len);
            PointD p22 = CalcPoint(points[1], slopes[1], -len);

            PointF f11 = D2G(p11);
            PointF f12 = D2G(p12);
            PointF f21 = D2G(p21);
            PointF f22 = D2G(p22);

            GraphicsPath pa = new GraphicsPath();
            pa.AddLine(f11, f21);
            pa.AddLine(f21, f22);
            pa.AddLine(f22, f12);
            AddTrackPathEnd(pa, points[0], p12, p11, new PointD(-slopes[0].X, -slopes[0].Y));

            trackGradientFills[0] = new TrackGradientFill();
            trackGradientFills[0].Path = pa;

            // Loop through all inside paths - all are trapezoids
            for (int i = 1; i < count - 1; i++)
            {
                p11 = p21; p12 = p22;
                f11 = f21; f12 = f22;

                p21 = CalcPoint(points[i + 1], slopes[i + 1], len);
                p22 = CalcPoint(points[i + 1], slopes[i + 1], -len);
                f21 = D2G(p21);
                f22 = D2G(p22);

                pa = new GraphicsPath();
                pa.AddLine(f11, f21);
                pa.AddLine(f21, f22);
                pa.AddLine(f22, f12);
                pa.AddLine(f12, f11);

                trackGradientFills[i] = new TrackGradientFill();
                trackGradientFills[i].Path = pa;
            }

            // Last path may have special end
            p11 = p21; p12 = p22;
            f11 = f21; f12 = f22;

            p21 = CalcPoint(points[count], slopes[count], len);
            p22 = CalcPoint(points[count], slopes[count], -len);
            f21 = D2G(p21);
            f22 = D2G(p22);

            pa = new GraphicsPath();
            pa.AddLine(f11, f21);
            AddTrackPathEnd(pa, points[count], p21, p22, slopes[count]);
            pa.AddLine(f22, f12);
            pa.AddLine(f12, f11);

            trackGradientFills[count - 1] = new TrackGradientFill();
            trackGradientFills[count - 1].Path = pa;

            // Calculate color for each fill
            ColorBlend grad = trackFill.GradientColors;
            trackGradientFills[0].Color = grad.Colors[0];
            trackGradientFills[count - 1].Color = grad.Colors[grad.Colors.Length - 1];

            float div = 1.0f / (float)(count - 1);
            for (int i = 1; i < count - 1; i++)
            {
                float pos = div * (float)i;
                trackGradientFills[i].Color = Utils.CalcGradientColor(grad, pos);
            }
        }

        /// <summary>
        /// Adds the track path end.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="pCenter">The p center.</param>
        /// <param name="pStart">The p start.</param>
        /// <param name="pEnd">The p end.</param>
        /// <param name="slope">The slope.</param>
        private void AddTrackPathEnd(GraphicsPath path, PointD pCenter, PointD pStart, PointD pEnd, PointD slope)
        {
            PointF f1 = D2G(pStart);
            PointF f2 = PointF.Empty;
            PointF fEnd = D2G(pEnd);

            if (trackEnd == SpiralTrackBarTrackEnd.Flat)
            {
                path.AddLine(f1, fEnd);
            }
            else
            {
                int div = 2 * trackFillSize + 1;
                double radius = 0.5 * (double)trackFillSize;
                double radInc = Math.PI / (double)div;
                double rad = Math.Atan2(slope.Y, slope.X);

                for (int i = 1; i < div; i++)
                {
                    rad -= radInc;
                    double dx = radius * Math.Cos(rad);
                    double dy = radius * Math.Sin(rad);
                    f2 = D2G(new PointD(pCenter.X + dx, pCenter.Y + dy));
                    path.AddLine(f1, f2);
                    f1 = f2;
                }

                path.AddLine(f2, fEnd);
            }
        }

        /// <summary>
        /// The tick lines
        /// </summary>
        private PointF[][] tickLines;

        // Calculate start-and-end points for a tick
        // Depends on step index, and whether it major or minor
        /// <summary>
        /// Adds the ticks.
        /// </summary>
        /// <param name="tickList">The tick list.</param>
        /// <param name="step">The step.</param>
        /// <param name="major">if set to <c>true</c> [major].</param>
        private void AddTicks(List<PointF[]> tickList, int step, bool major)
        {
            PointD p = stepPoint[step];
            PointD m = stepSlope[step];

            double length = major ? tickLength : tickLength / 2;
            double dx = length * m.X;
            double dy = length * m.Y;

            double track = 0.5 * (double)trackFillSize;
            double tx = track * m.X;
            double ty = track * m.Y;

            PointD pi1 = new PointD(p.X + tx, p.Y + ty);
            PointD pi2 = new PointD(p.X + tx + dx, p.Y + ty + dy);
            PointD po1 = new PointD(p.X - tx, p.Y - ty);
            PointD po2 = new PointD(p.X - tx - dx, p.Y - ty - dy);

            if (tickStyle == SpiralTrackBarTickStyle.Inner ||
                tickStyle == SpiralTrackBarTickStyle.Both)
            {
                tickList.Add(new PointF[2] { D2G(pi1), D2G(pi2) });
            }
            if (tickStyle == SpiralTrackBarTickStyle.Outer ||
                tickStyle == SpiralTrackBarTickStyle.Both)
            {
                tickList.Add(new PointF[2] { D2G(po1), D2G(po2) });
            }
        }

        /// <summary>
        /// Calculates the ticks.
        /// </summary>
        private void CalcTicks()
        {
            if (tickStyle == SpiralTrackBarTickStyle.None)
            {
                tickLines = new PointF[0][];
                return;
            }

            List<PointF[]> tickList = new List<PointF[]>();

            AddTicks(tickList, 0, true);

            int lastIndex = stepCount - 2;
            int majorIndex = majorTickFrequency;
            int minorIndex = (minorTickFrequency > 0) ? minorTickFrequency : stepCount;

            while (majorIndex <= lastIndex || minorIndex <= lastIndex)
            {
                int index;
                bool major;

                if (minorIndex < majorIndex)
                {
                    index = minorIndex;
                    major = false;
                    minorIndex += minorTickFrequency;
                }
                else if (majorIndex < minorIndex)
                {
                    index = majorIndex;
                    major = true;
                    majorIndex += majorTickFrequency;
                }
                else // (majorIndex == minorIndex)
                {
                    index = majorIndex;
                    major = true;
                    majorIndex += majorTickFrequency;
                    minorIndex += minorTickFrequency;
                }
                AddTicks(tickList, index, major);
            }

            AddTicks(tickList, stepCount - 1, true);

            tickLines = tickList.ToArray();
        }

        /// <summary>
        /// The marker path
        /// </summary>
        private GraphicsPath markerPath;
        /// <summary>
        /// The marker rect
        /// </summary>
        private Rectangle markerRect;

        // These points are used to generate the linear gradient fill (if the fill is gradient)
        /// <summary>
        /// The marker near point
        /// </summary>
        private PointF markerNearPoint;
        /// <summary>
        /// The marker far point
        /// </summary>
        private PointF markerFarPoint;

        /// <summary>
        /// Disposes the marker path.
        /// </summary>
        private void DisposeMarkerPath()
        {
            if (markerPath != null)
            {
                markerPath.Dispose();
                markerPath = null;
            }
        }

        // Marker is at stepValue[valueIndex]
        // Use stepPoint[] and stepSlope[]
        /// <summary>
        /// Calculates the marker path.
        /// </summary>
        private void CalcMarkerPath()
        {
            if (markerPath == null)
            {
                markerPath = new GraphicsPath();

                int x1 = 0, x2 = 0;
                int y1 = 0, y2 = 0;

                if (markerShape.Count > 1)
                {
                    PointD mid = stepPoint[valueIndex];
                    PointD slope = stepSlope[valueIndex];

                    // Matrix is 
                    //  (-sx +sy)
                    //  (-sy -sx)

                    double xNear = markerShape[0].X;
                    double xFar = markerShape[0].X;

                    PointD p1 = new PointD(mid.X - slope.X * markerShape[0].X + slope.Y * markerShape[0].Y,
                                           mid.Y - slope.Y * markerShape[0].X - slope.X * markerShape[0].Y);

                    PointF pf1 = D2G(p1);

                    x1 = (int)Math.Floor(pf1.X);
                    x2 = (int)Math.Ceiling(pf1.X);
                    y1 = (int)Math.Floor(pf1.Y);
                    y2 = (int)Math.Ceiling(pf1.Y);

                    for (int i = 1; i < markerShape.Count; i++)
                    {
                        xNear = Math.Min(xNear, markerShape[i].X);
                        xFar = Math.Max(xFar, markerShape[i].X);

                        PointD p2 = new PointD(mid.X - slope.X * markerShape[i].X + slope.Y * markerShape[i].Y,
                                               mid.Y - slope.Y * markerShape[i].X - slope.X * markerShape[i].Y);

                        PointF pf2 = D2G(p2);

                        x1 = (int)Math.Min(x1, Math.Floor(pf2.X));
                        x2 = (int)Math.Max(x2, Math.Ceiling(pf2.X));
                        y1 = (int)Math.Min(y1, Math.Floor(pf2.Y));
                        y2 = (int)Math.Max(y2, Math.Ceiling(pf2.Y));

                        markerPath.AddLine(pf1, pf2);
                        pf1 = pf2;
                    }

                    if (markerFill.FillType == Filler2Type.Gradient)
                    {
                        PointD pNear = new PointD(mid.X - slope.X * xNear,
                                                  mid.Y - slope.Y * xNear);
                        markerNearPoint = D2G(pNear);

                        PointD pFar = new PointD(mid.X - slope.X * xFar,
                                                 mid.Y - slope.Y * xFar);
                        markerFarPoint = D2G(pFar);

                        DisposeMarkerBrush();
                    }
                }

                markerRect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }
        }

        /// <summary>
        /// The enough space
        /// </summary>
        private bool enoughSpace;

        // RecalcLayout
        // - called when size of any graphical objects has changed
        /// <summary>
        /// Recalcs the layout.
        /// </summary>
        private void RecalcLayout()
        {
            DisposeMarkerPath();
            DisposeTrackPath();

            if (stepCount < 1 || !CalcSpiral())
            {
                enoughSpace = false;
                return;
            }
            enoughSpace = true;

            Stopwatch sw = Stopwatch.StartNew();
            calcLayoutArcCount = 0;

            CalcAngleInit();
            CalcTrackPath();
            CalcSteps();
            CalcTicks();

            sw.Stop();
            calcLayoutTime = sw.ElapsedMilliseconds;

        }

        /// <summary>
        /// The back brush
        /// </summary>
        private Brush backBrush;

        /// <summary>
        /// The track pen
        /// </summary>
        private Pen trackPen;
        /// <summary>
        /// The track brush
        /// </summary>
        private Brush trackBrush;

        /// <summary>
        /// The tick pen
        /// </summary>
        private Pen tickPen;

        /// <summary>
        /// The marker pen
        /// </summary>
        private Pen markerPen;
        /// <summary>
        /// The marker brush
        /// </summary>
        private Brush markerBrush;

        /// <summary>
        /// Disposes the back brush.
        /// </summary>
        private void DisposeBackBrush()
        {
            if (backBrush != null)
            {
                backBrush.Dispose();
                backBrush = null;
            }
        }

        /// <summary>
        /// Disposes the track pen.
        /// </summary>
        private void DisposeTrackPen()
        {
            if (trackPen != null)
            {
                trackPen.Dispose();
                trackPen = null;
            }
        }

        /// <summary>
        /// Disposes the track brush.
        /// </summary>
        private void DisposeTrackBrush()
        {
            if (trackBrush != null)
            {
                trackBrush.Dispose();
                trackBrush = null;
            }
        }

        /// <summary>
        /// Disposes the tick pen.
        /// </summary>
        private void DisposeTickPen()
        {
            if (tickPen != null)
            {
                tickPen.Dispose();
                tickPen = null;
            }
        }

        /// <summary>
        /// Disposes the marker pen.
        /// </summary>
        private void DisposeMarkerPen()
        {
            if (markerPen != null)
            {
                markerPen.Dispose();
                markerPen = null;
            }
        }

        /// <summary>
        /// Disposes the marker brush.
        /// </summary>
        private void DisposeMarkerBrush()
        {
            if (markerBrush != null)
            {
                markerBrush.Dispose();
                markerBrush = null;
            }
        }

        /// <summary>
        /// Handles the Paint event of the SpiralTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void SpiralTrackBar_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (enoughSpace)
            {
                Graphics g = e.Graphics;

                if (AllowTransparency)
                {
                    MakeTransparent(this, g);
                }
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle r = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
                r.Inflate(1, 1);
                if (backBrush == null)
                {
                    backBrush = backgroundFill.GetBrush(r);
                }
                if (backBrush != null)
                {
                    g.FillRectangle(backBrush, r);
                }

                PaintTrack(g);
                PaintTicks(g);
                PaintMarker(g);
            }
            sw.Stop();
            paintTime = sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Paints the track.
        /// </summary>
        /// <param name="g">The g.</param>
        private void PaintTrack(Graphics g)
        {
            CalcTrackPath();

            if (trackPath == null)
            {
                return;
            }

            if (trackPen == null)
            {
                trackPen = trackBorder.GetPen();
            }

            // Draw fill first
            if (trackFillSize > 0)
            {
                // Solid or hatch fill
                if (trackFill.FillType == Filler2Type.Solid ||
                    trackFill.FillType == Filler2Type.Hatch)
                {
                    if (trackBrush == null)
                    {
                        trackBrush = trackFill.GetBrush(this.ClientRectangle);
                    }
                    g.FillPath(trackBrush, trackPath);
                }
                else if (trackFill.FillType == Filler2Type.Gradient)
                {
                    if (trackGradientFills[0].Brush == null)
                    {
                        for (int i = 0; i < trackGradientFills.Length; i++)
                        {
                            trackGradientFills[i].Brush = new SolidBrush(trackGradientFills[i].Color);
                        }
                    }

                    // Change smoothing mode to a "cheaper" mode
                    // Otherwise, we get slivers of unpainted pixels between each fill area
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    for (int i = 0; i < trackGradientFills.Length; i++)
                    {
                        g.FillPath(trackGradientFills[i].Brush,
                                   trackGradientFills[i].Path);
                    }
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                }
            }

            // Draw border
            g.DrawPath(trackPen, trackPath);
        }

        /// <summary>
        /// Paints the ticks.
        /// </summary>
        /// <param name="g">The g.</param>
        private void PaintTicks(Graphics g)
        {
            if (tickPen == null)
            {
                tickPen = tickLine.GetPen();
            }
            for (int t = 0; t < tickLines.Length; t++)
            {
                g.DrawLine(tickPen, tickLines[t][0], tickLines[t][1]);
            }
        }

        /// <summary>
        /// Paints the marker.
        /// </summary>
        /// <param name="g">The g.</param>
        private void PaintMarker(Graphics g)
        {
            CalcMarkerPath();

            if (markerBrush == null)
            {
                markerBrush = markerFill.GetBrush(markerNearPoint, markerFarPoint);
            }
            if (markerBrush != null)
            {
                g.FillPath(markerBrush, markerPath);
            }

            if (markerPen == null)
            {
                markerPen = markerBorder.GetPen();
            }
            g.DrawPath(markerPen, markerPath);
        }

        /// <summary>
        /// The mouse dragging
        /// </summary>
        private bool mouseDragging = false;
        /// <summary>
        /// The mouse angle
        /// </summary>
        private double mouseAngle;

        /// <summary>
        /// Calculates the mouse angle.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <returns>System.Double.</returns>
        private double CalcMouseAngle(MouseEventArgs e)
        {
            double dx = (double)e.X - 0.5 * (double)ClientSize.Width;
            double dy = -((double)e.Y - 0.5 * (double)ClientSize.Height);
            double ang = RADInv * (float)Math.Acos(dx / Math.Sqrt(dx * dx + dy * dy));
            if (dy < 0.0)
            {
                ang = 360.0 - ang;
            }
            return ang;
        }

        /// <summary>
        /// Handles the MouseDown event of the SpiralTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void SpiralTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left &&
                markerPath != null &&
                markerPath.IsVisible(e.Location.X, e.Location.Y))
            {
                mouseDragging = true;
                mouseAngle = CalcMouseAngle(e);
                while (mouseAngle < stepAngle[valueIndex] - 180.0)
                {
                    mouseAngle += 360.0;
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the SpiralTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void SpiralTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDragging)
            {
                // Calc change in angle
                // +'ive is counter clockwise
                // -'ive is clockwise
                double newMouseAngle = CalcMouseAngle(e);
                double diffAngle = newMouseAngle - mouseAngle;
                if (diffAngle == 0.0)
                {
                    return; // no change
                }
                double n1 = newMouseAngle;
                double d1 = diffAngle;
                while (diffAngle < -180)
                {
                    diffAngle += 360;
                }
                while (diffAngle > +180)
                {
                    diffAngle -= 360;
                }
                newMouseAngle = mouseAngle + diffAngle;

                // Find nearest step to match
                double minAngleDiff = Math.Abs(stepAngle[valueIndex] - newMouseAngle);
                int minAngleIndex = valueIndex;

                int curIndex = valueIndex;
                while (true)
                {
                    if (diffAngle < 0.0)
                    {
                        if (curIndex == 0)
                        {
                            break;
                        }
                        curIndex--;
                    }
                    else
                    {
                        if (curIndex == stepAngle.Length - 1)
                        {
                            break;
                        }
                        curIndex++;
                    }
                    double curDiff = Math.Abs(stepAngle[curIndex] - newMouseAngle);
                    if (curDiff > minAngleDiff)
                    {
                        break;
                    }
                    minAngleIndex = curIndex;
                    minAngleDiff = curDiff;
                }

                if (minAngleIndex != valueIndex)
                {
                    mouseAngle = newMouseAngle;
                    valueIndex = minAngleIndex;
                    ValueIndexChanged();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the SpiralTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void SpiralTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDragging = false;
        }

        /// <summary>
        /// Handles the SizeChanged event of the SpiralTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SpiralTrackBar_SizeChanged(object sender, EventArgs e)
        {
            RecalcLayout();
            DisposeBackBrush();
            Invalidate();
        }

        /// <summary>
        /// Handles the FontChanged event of the Base control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Base_FontChanged(object sender, EventArgs e)
        {
            RecalcLayout();
            Invalidate();
        }






        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion



    }

    #endregion
}
