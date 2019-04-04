// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Calcs.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region Calcs

    /// <summary>
    /// Class ZeroitSpiralTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class ZeroitSpiralTrackBar
    {
        // Internally, all calculations are in double
        // Only convert to float when using Graphics methods
        /// <summary>
        /// Struct PointD
        /// </summary>
        private struct PointD
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PointD"/> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            public PointD(double x, double y)
            {
                X = x;
                Y = y;
            }

            /// <summary>
            /// Gets the empty.
            /// </summary>
            /// <value>The empty.</value>
            public static PointD Empty
            {
                get { return new PointD(0.0, 0.0); }
            }

            /// <summary>
            /// The x
            /// </summary>
            public readonly double X;
            /// <summary>
            /// The y
            /// </summary>
            public readonly double Y;

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                return "X=" + X.ToString("F2") + ",Y=" + Y.ToString("F2");
            }
        }

        /// <summary>
        /// D2s the g.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>PointF.</returns>
        private PointF D2G(double x, double y)
        {
            return new PointF((float)this.ClientSize.Width * 0.5f + (float)x,
                              (float)this.ClientSize.Height * 0.5f - (float)y);
        }

        /// <summary>
        /// D2s the g.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>PointF.</returns>
        private PointF D2G(PointD p)
        {
            return D2G(p.X, p.Y);
        }


        // All Math.Trig methods use radians, not degrees
        /// <summary>
        /// The RAD
        /// </summary>
        private const double RAD = Math.PI / 180.0;
        /// <summary>
        /// The RAD inv
        /// </summary>
        private const double RADInv = 1.0 / RAD;

        /// <summary>
        /// Angles to RAD.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Double.</returns>
        private double AngleToRad(double angle)
        {
            return angle * RAD;
        }

        // The formula for the spiral track line in polar coordinates is:
        // 		r = a + b*angle
        //
        // The values of a,b depend on the size of the control, and the 
        // values of indent[Start,Stop]
        //
        // Various other operations on b are pre-calculated for use in CalcArc()
        /// <summary>
        /// a
        /// </summary>
        private double a;
        /// <summary>
        /// The b
        /// </summary>
        private double b;

        /// <summary>
        /// The invb
        /// </summary>
        private double invb;
        /// <summary>
        /// The bb
        /// </summary>
        private double bb;

        /// <summary>
        /// The start arc
        /// </summary>
        private double startArc;
        /// <summary>
        /// The stop arc
        /// </summary>
        private double stopArc;
        /// <summary>
        /// The inv arc
        /// </summary>
        private double invArc;

        /// <summary>
        /// Calculates the r.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Double.</returns>
        private double CalcR(double angle)
        {
            return a + b * AngleToRad(angle);
        }

        // Calc necessary values for the spiral track line
        // These are a, b, and the start/stop arc values
        //
        // Return true if there is enough space for the spiral, otherwise false
        /// <summary>
        /// Calculates the spiral.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CalcSpiral()
        {
            double minwid = (double)Math.Min(ClientSize.Width, ClientSize.Height) * 0.5;
            double space = minwid - 2 * tickLength;
            if (space < 10)
            {
                return false;
            }

            double pixin = minwid * indentStart;
            double pixout = minwid * indentStop;

            double startRad = AngleToRad(StartAngle);
            double stopRad = AngleToRad(StopAngle);

            b = (pixin - pixout) / (startRad - stopRad);
            a = pixin - b * startRad;

            invb = 1.0 / b;
            bb = b * b;

            startArc = CalcArc(StartAngle);
            stopArc = CalcArc(StopAngle);
            invArc = 1.0 / (stopArc - startArc);

            return true;
        }

        // For a given point on the spiral, the formula to convert to cartesian coordinates is
        // 		x = r * cos(A)
        // 		y = r * sin(A)
        // where A is the angle
        /// <summary>
        /// Calculates the point.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>PointD.</returns>
        private PointD CalcPoint(double angle)
        {
            double r = CalcR(angle);
            double rad = AngleToRad(angle);
            double x = r * Math.Cos(rad);
            double y = r * Math.Sin(rad);
            return new PointD(x, y);
        }

        // The slope at a point on the spiral refers to the line which is perpendicular
        // to the tangent (of the spiral).  This slope is used for drawing the tick marks
        // (among other things).
        //
        // The slope is expressed as x,y offsets of a vector from the point on the spiral
        // towards the center.  Using offsets nicely handles the issue of vertical lines
        // (which have a slope of +Inf or -Inf).
        //
        // The tangent on a curve in polar coordinates is:
        //		t = (r'*sin(A) + r*cos(A)) / (r'*cos(A) - r*sin(A))
        // where
        // 		r' = b (first derivative of r)
        //
        // The slope of the perpendicular is:
        //      m = -1 / t
        // 		  = (r*sin(A) - r'*cos(A)) / (r'*sin(A) + r*cos(A))
        // 		  = (r*sin(A) - b*cos(A)) / (b*sin(A) + r*cos(A))
        //
        /// <summary>
        /// Calculates the slope.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>PointD.</returns>
        private PointD CalcSlope(double angle)
        {
            return CalcSlope(angle, CalcPoint(angle));
        }

        /// <summary>
        /// Calculates the slope.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="p">The p.</param>
        /// <returns>PointD.</returns>
        private PointD CalcSlope(double angle, PointD p)
        {
            double r = CalcR(angle);

            double rad = AngleToRad(angle);
            double sin = Math.Sin(rad);
            double cos = Math.Cos(rad);

            double mnum = r * sin - b * cos;
            double mden = b * sin + r * cos;

            double dx;
            double dy;

            if (Math.Abs(mden) > 0.0001)
            {
                // Far enough from vertical that overflow should not occur
                double m = mnum / mden;
                double m1 = 1.0 / Math.Sqrt(1 + m * m);
                dx = (float)m1;
                dy = (float)(m * m1);
            }
            else
            {
                // Close to vertical - special rules
                double da = angle % 360.0;
                double d90 = Math.Abs(90 - da);
                double d270 = Math.Abs(270 - da);
                dy = (d90 < d270) ? +1.0 : -1.0;
                dx = 0.0;
            }

            // Is (dx,dy) towards or away from center
            double dist2 = p.X * p.X + p.Y * p.Y;
            double xdx = p.X + dx;
            double ydy = p.Y + dy;
            double step2 = xdx * xdx + ydy * ydy;

            if (step2 > dist2) // (dx,dy) is away from center
            {
                dx = -dx;
                dy = -dy;
            }
            PointD slope = new PointD(dx, dy);
            return slope;
        }

        // Calculate a new point given a point, slope, and length (positive is towards center
        // negative away from center).
        /// <summary>
        /// Calculates the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="slope">The slope.</param>
        /// <param name="length">The length.</param>
        /// <returns>PointD.</returns>
        private PointD CalcPoint(PointD point, PointD slope, double length)
        {
            double dx = length * slope.X;
            double dy = length * slope.Y;
            return new PointD(point.X + dx, point.Y + dy);
        }

        // The arc length is the distance along the spiral track line.
        // It is really only meaningful when measuring a difference - from one angle to another
        //
        // The formula to this is the solution to a somewhat unfriendly integral:
        //		arc = Integral( sqrt( r'^2 + r^2 ) )
        // 			= Integral( sqrt( b^2 + (a + b*A)^2 ) )
        //
        // The solution is the general solution to the integral of the sqrt of a 2nd degree polynomial.
        // Solution is courtesy of the Handbook of Tables for Mathematics (4th edition), page 562
        // (integral formula #242):
        //
        //		arc = 0.5 * (r/b) * P + (b/2) * log(2*b*(P + r))
        // where
        // 		P = sqrt( b^2 + (a + b*A)^2 )
        // 
        // Note that this formula cannot be inverted, that is, there is no formula
        // to calculate angle from arc
        //
        /// <summary>
        /// Calculates the arc.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Double.</returns>
        private double CalcArc(double angle)
        {
            calcLayoutArcCount++;

            double rad = AngleToRad(angle);
            double r = a + b * rad;
            double root = Math.Sqrt(bb + r * r);
            double log = 0.5 * b * Math.Log(2 * b * (root + r));
            double arc = 0.5 * r * root * invb + log;
            return arc;
        }

        // Pos is the arc value scaled such that the range is [0,1]
        /// <summary>
        /// Calculates the position.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Double.</returns>
        private double CalcPos(double angle)
        {
            double arc = CalcArc(angle);
            double pos = (arc - startArc) * invArc;
            // Adjust pos value in case it slips out of range due to round-off
            return Math.Min(Math.Max(posMin, pos), posMax);
        }

        // As mentioned above in CalcArc(), there is no simple arc to angle formula.
        // Given an arc (or pos) value, must determine angle by searching
        //
        // Initially had designed a lookup table to avoid too many calls to CalcArc()
        // Turned out to be unnecessary. On my (6 year old PC), it could do 3000 CalcArc()
        // calls in ONE MILLISECOND.  Later I learned that modern processors had builtin
        // SQRT and LOG functions.
        //
        /// <summary>
        /// Positions the equal.
        /// </summary>
        /// <param name="pos1">The pos1.</param>
        /// <param name="pos2">The pos2.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool PosEqual(double pos1, double pos2)
        {
            return Math.Abs(pos1 - pos2) < 0.0001;
        }

        /// <summary>
        /// The position minimum
        /// </summary>
        private const double posMin = 0.0;
        /// <summary>
        /// The position maximum
        /// </summary>
        private const double posMax = 1.0;

        /// <summary>
        /// The ang minimum
        /// </summary>
        private double angMin;
        /// <summary>
        /// The ang maximum
        /// </summary>
        private double angMax;
        /// <summary>
        /// The ang50
        /// </summary>
        private double ang50;
        /// <summary>
        /// The pos50
        /// </summary>
        private double pos50;

        /// <summary>
        /// Calculates the angle initialize.
        /// </summary>
        private void CalcAngleInit()
        {
            angMin = StartAngle;
            angMax = StopAngle;
            // Pre-calc the first one, might speed things up a bit...
            ang50 = 0.5 * (angMin + angMax);
            pos50 = CalcPos(ang50);
        }

        /// <summary>
        /// Calculates the angle.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Double.</returns>
        private double CalcAngle(double pos)
        {
            if (pos <= 0.0 || PosEqual(pos, posMin))
            {
                return angMin;
            }
            if (pos >= 1.0 || PosEqual(pos, posMax))
            {
                return angMax;
            }

            double angLo = angMin;
            double angHi = angMax;
            double angMid = ang50;
            double posMid = pos50;

            while (true)
            {
                if (PosEqual(pos, posMid))
                {
                    break;
                }
                if (pos < posMid)
                {
                    angHi = angMid;
                }
                else
                {
                    angLo = angMid;
                }

                angMid = 0.5 * (angHi + angLo);
                posMid = CalcPos(angMid);
            }

            return angMid;
        }
    }

    #endregion
}
