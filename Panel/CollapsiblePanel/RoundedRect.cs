// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RoundedRect.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    #region RoundedRect    
    /// <summary>
    /// Enum representing the type of corner
    /// </summary>
    [Flags]
    public enum XPanelCornerType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// The top right
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// The top
        /// </summary>
        Top = TopLeft | TopRight,
        /// <summary>
        /// The bottom left
        /// </summary>
        BottomLeft = 4,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight = 8,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = BottomLeft | BottomRight,
        /// <summary>
        /// The right
        /// </summary>
        Right = TopRight | BottomRight,
        /// <summary>
        /// The left
        /// </summary>
        Left = TopLeft | BottomLeft,
        /// <summary>
        /// All
        /// </summary>
        All = Top | Bottom
    }

    /// <summary>
    /// Summary description for RoundedRect.
    /// </summary>
    public abstract class RoundedRect
    {
        /// <summary>
        /// Creates the path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="corners">The corners.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreatePath(
                                        RectangleF rect,
                                        int cornerRadius,
                                        int margin,
                                        XPanelCornerType corners
                                        )
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            float xOffset = rect.X + margin;
            float yOffset = rect.Y + margin;
            float xExtent = rect.X + rect.Width - margin;
            float yExtent = rect.Y + rect.Height - margin;
            int diameter = cornerRadius << 1;

            // top arc																																																																																																
            if ((corners & XPanelCornerType.TopLeft) != 0)
            {
                graphicsPath.AddArc(new RectangleF(xOffset, yOffset, diameter, diameter), 180, 90);
            }
            else
            {
                graphicsPath.AddLine(new PointF(xOffset, yOffset + cornerRadius), new PointF(xOffset, yOffset));
                graphicsPath.AddLine(new PointF(xOffset, yOffset), new PointF(xOffset + cornerRadius, yOffset));
            }

            // top line
            graphicsPath.AddLine(new PointF(xOffset + cornerRadius, yOffset), new PointF(xExtent - cornerRadius, yOffset));

            // top right arc
            if ((corners & XPanelCornerType.TopRight) != 0)
                graphicsPath.AddArc(new RectangleF(xExtent - diameter, yOffset, diameter, diameter), 270, 90);
            else
            {
                graphicsPath.AddLine(new PointF(xExtent - cornerRadius, yOffset), new PointF(xExtent, yOffset));
                graphicsPath.AddLine(new PointF(xExtent, yOffset), new PointF(xExtent, yOffset + cornerRadius));
            }

            // right line
            graphicsPath.AddLine(new PointF(xExtent, yOffset + cornerRadius), new PointF(xExtent, yExtent - cornerRadius));

            // bottom right arc
            if ((corners & XPanelCornerType.BottomRight) != 0)
                graphicsPath.AddArc(new RectangleF(xExtent - diameter, yExtent - diameter, diameter, diameter), 0, 90);
            else
            {
                graphicsPath.AddLine(new PointF(xExtent, yExtent - cornerRadius), new PointF(xExtent, yExtent));
                graphicsPath.AddLine(new PointF(xExtent, yExtent), new PointF(xExtent - cornerRadius, yExtent));
            }

            // bottom line
            graphicsPath.AddLine(new PointF(xExtent - cornerRadius, yExtent), new PointF(xOffset + cornerRadius, yExtent));

            // bottom left arc
            if ((corners & XPanelCornerType.BottomLeft) != 0)
                graphicsPath.AddArc(new RectangleF(xOffset, yExtent - diameter, diameter, diameter), 90, 90);
            else
            {
                graphicsPath.AddLine(new PointF(xOffset + cornerRadius, yExtent), new PointF(xOffset, yExtent));
                graphicsPath.AddLine(new PointF(xOffset, yExtent), new PointF(xOffset, yExtent - cornerRadius));
            }


            // left line
            graphicsPath.AddLine(new PointF(xOffset, yExtent - cornerRadius), new PointF(xOffset, yOffset + cornerRadius));

            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        /// <summary>
        /// Creates the path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="margin">The margin.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreatePath(
                                        RectangleF rect,
                                        int cornerRadius,
                                        int margin
                                        )
        {
            return CreatePath(rect, cornerRadius, margin, XPanelCornerType.All);
        }

        /// <summary>
        /// Creates the path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreatePath(RectangleF rect, int cornerRadius)
        {
            return CreatePath(rect, cornerRadius, 1, XPanelCornerType.All);
        }

        /// <summary>
        /// Creates the path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath CreatePath(Rectangle rect, int cornerRadius)
        {
            return CreatePath(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), cornerRadius, 1, XPanelCornerType.All);
        }
    }
    #endregion
}
