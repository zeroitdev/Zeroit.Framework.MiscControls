// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GraphicsHelper.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Utils
{

    /// <summary>
    /// Class GraphicsHelper.
    /// </summary>
    static class GraphicsHelper
    {
        /// <summary>
        /// The rounded rect RAD percent
        /// </summary>
        private const double ROUNDED_RECT_RAD_PERCENT = .05d;//5 percent

        /// <summary>
        /// Gets the graphics path.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="shape">The shape.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GetGraphicsPath(Rectangle container, ControlShape shape)
        {
            GraphicsPath path = new GraphicsPath();

            Rectangle pathRect = container;
            pathRect.Width -= 1;
            pathRect.Height -= 1;

            switch (shape)
            {
                case ControlShape.Rect:
                    path.AddRectangle(pathRect);
                    break;
                case ControlShape.RoundedRect:
                    //radius is 10% of smallest side
                    int rad = (int)(Math.Min(pathRect.Height, pathRect.Width) * ROUNDED_RECT_RAD_PERCENT);
                    CustomExtensions.AddRoundedRectangle(path, pathRect, rad);
                    break;
                case ControlShape.Circular:
                    path.AddEllipse(pathRect);
                    break;
            }

            return path;
        }

        /// <summary>
        /// Get3s the d shine path.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="shape">The shape.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath Get3DShinePath(Rectangle container, ControlShape shape)
        {
            GraphicsPath path = new GraphicsPath();

            Rectangle pathRect = container;
            pathRect.Width -= 1;
            pathRect.Height -= 1;

            RectangleF halfRect = new RectangleF(pathRect.X, pathRect.Y,
                                                    pathRect.Width, pathRect.Height / 2f);

            if (pathRect.Height > 0 && pathRect.Width > 0)
            {
                switch (shape)
                {
                    case ControlShape.Rect:
                        path.AddRectangle(halfRect);
                        break;
                    case ControlShape.RoundedRect:
                        //radius is 10% of smallest side
                        int rad = (int)(Math.Min(halfRect.Height, halfRect.Width) * ROUNDED_RECT_RAD_PERCENT);
                        CustomExtensions.AddRoundedRectangle(path, halfRect, rad);
                        break;
                    case ControlShape.Circular:
                        path.AddArc(pathRect, 180, 142);
                        PointF[] pts = new PointF[]
                    {
                        path.GetLastPoint(),
                        new PointF(container.Width * .70f, container.Height * .33f),
                        new PointF(container.Width * .25f, container.Height * .5f),
                        path.PathPoints[0]
                    };
                        path.AddCurve(pts);
                        path.CloseFigure();
                        break;
                }
            }

            return path;
        }

        /// <summary>
        /// Gets the grad brush.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="color">The color.</param>
        /// <returns>Brush.</returns>
        public static Brush GetGradBrush(Rectangle container, ControlShape shape, Color color)
        {
            Brush brush = null;

            switch (shape)
            {
                case ControlShape.Rect:
                case ControlShape.RoundedRect:
                    brush = new LinearGradientBrush(container, color, Color.Transparent,
                        LinearGradientMode.Vertical);
                    break;
                case ControlShape.Circular:
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse(container);
                        PathGradientBrush pgb = new PathGradientBrush(path);
                        pgb.CenterColor = color;
                        pgb.SurroundColors = new Color[] { Color.Transparent };
                        pgb.CenterPoint = new PointF(container.Left + container.Width * .5f,
                                                     container.Bottom + container.Height);
                        brush = pgb;
                    }
                        
                    break;
            }

            return brush;
        }

        /// <summary>
        /// Gets the arc path.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="dStartDegrees">The d start degrees.</param>
        /// <param name="dArcLengthDegrees">The d arc length degrees.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GetArcPath(RectangleF container, double dStartDegrees, double dArcLengthDegrees)
        {
            GraphicsPath arcPath = new GraphicsPath();

            int nPoints = 100;
            double dEachPointDelta = dArcLengthDegrees / (double)(nPoints);
            List<PointF> arcPts = new List<PointF>();
            for (int i = 0; i <= nPoints; i++)
            {
                double curDeg = dStartDegrees - (i * dEachPointDelta);
                arcPts.Add(GetPointInArc(container, curDeg, 0));
            }

            arcPath.AddCurve(arcPts.ToArray());

            return arcPath;
        }

        /// <summary>
        /// Gets the point in arc.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="degrees">The degrees.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>PointF.</returns>
        public static PointF GetPointInArc(RectangleF rect, double degrees, double offset)
        {
            PointF center = new PointF(rect.Left + rect.Width / 2f,
                                       rect.Top + rect.Height / 2f);

            double rads = (Math.PI / 180d) * (degrees + 90);
            
            double xVal = center.X + (offset + (rect.Width / 2d)) * Math.Sin(rads);
            double yVal = center.Y + (offset + (rect.Height / 2d)) * Math.Cos(rads);

            return new PointF((float)xVal, (float)yVal);
        }

        /// <summary>
        /// Gets the color of the mixed.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="percentage">The percentage.</param>
        /// <returns>Color.</returns>
        public static Color GetMixedColor(Color start, Color end, double percentage)
        {
            //get distance between colors
            double aDif = end.A - start.A;
            double rDif = end.R - start.R;
            double gDif = end.G - start.G;
            double bDif = end.B - start.B;

            //shrink to percentage of total distance between colors
            aDif *= percentage;
            rDif *= percentage;
            gDif *= percentage;
            bDif *= percentage;

            //get the lowest of the two colors
            double aLow = Math.Min(start.A, end.A);
            double rLow = Math.Min(start.R, end.R);
            double gLow = Math.Min(start.G, end.G);
            double bLow = Math.Min(start.B, end.B);

            //get the highest of the two colors
            double aHigh = Math.Max(start.A, end.A);
            double rHigh = Math.Max(start.R, end.R);
            double gHigh = Math.Max(start.G, end.G);
            double bHigh = Math.Max(start.B, end.B);

            //new color will be percentage between start and end
            double alpha = aDif + ((aDif > 0) ? aLow : aHigh);
            double red = rDif + ((rDif > 0) ? rLow : rHigh);
            double green = gDif + ((gDif > 0) ? gLow : gHigh);
            double blue = bDif + ((bDif > 0) ? bLow : bHigh);

            return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
        }
    }
}
