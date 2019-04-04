// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Renderer.cs" company="Zeroit Dev Technologies">
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
    #region Arrow

    //[Serializable]
    /// <summary>
    /// Class ArrowRenderer.
    /// </summary>
    public class ArrowRenderer
    {
        #region Properties

        /// <summary>
        /// The width
        /// </summary>
        private float width = 15;
        /// <summary>
        /// Gets or sets width (in pixels) of the full base of the arrowhead
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// The theta
        /// </summary>
        private float theta = 0.5f;
        /// <summary>
        /// Gets or sets angle (in radians) at the arrow tip between the two sides of the arrowhead
        /// </summary>
        /// <value>The theta.</value>
        public float Theta
        {
            get { return theta; }
            set { theta = value; }
        }

        /// <summary>
        /// Sets the theta in degrees.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        public void SetThetaInDegrees(float degrees)
        {
            if (degrees <= 0) degrees = 1;
            if (degrees >= 180) degrees = 179;
            theta = (float)Math.PI / 180 * degrees;
        }

        /// <summary>
        /// The fill arrow head
        /// </summary>
        private bool fillArrowHead = true;
        /// <summary>
        /// Gets or sets flag indicating whether or not the arrowhead should be filled
        /// </summary>
        /// <value><c>true</c> if arrow head should be filled; otherwise, <c>false</c>.</value>
        public bool FillArrowHead
        {
            get { return fillArrowHead; }
            set { fillArrowHead = value; }
        }

        /// <summary>
        /// The number of bezier curve nodes
        /// </summary>
        private int numberOfBezierCurveNodes = 100;
        /// <summary>
        /// Gets or sets the number of nodes used to calculate bezier curve.
        /// </summary>
        /// <value>The number of bezier curve nodes.</value>
        public int NumberOfBezierCurveNodes
        {
            get { return numberOfBezierCurveNodes; }
            set
            {
                if (value > 4) numberOfBezierCurveNodes = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowRenderer"/> class.
        /// </summary>
        public ArrowRenderer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowRenderer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        public ArrowRenderer(float width)
        {
            this.width = width;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowRenderer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="theta">The theta.</param>
        public ArrowRenderer(float width, float theta)
        {
            this.width = width;
            this.theta = theta;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowRenderer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="theta">The theta.</param>
        /// <param name="fillArrowHead">if set to <c>true</c> [fill arrow head].</param>
        public ArrowRenderer(float width, float theta, bool fillArrowHead)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowHead = fillArrowHead;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowRenderer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="theta">The theta.</param>
        /// <param name="fillArrowHead">if set to <c>true</c> [fill arrow head].</param>
        /// <param name="numberOfBezierCurveNodes">The number of bezier curve nodes.</param>
        public ArrowRenderer(float width, float theta, bool fillArrowHead, int numberOfBezierCurveNodes)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowHead = fillArrowHead;
            this.numberOfBezierCurveNodes = numberOfBezierCurveNodes;
        }

        #endregion

        #region DrawArrow

        /// <summary>
        /// Draws the arrow.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        public void DrawArrow(Graphics g, Pen pen, Brush brush, float x1, float y1, float x2, float y2)
        {
            DrawArrow(g, pen, brush, new PointF(x1, y1), new PointF(x2, y2));
        }

        /// <summary>
        /// Renders the arrow on given graphics using desired paramethers.
        /// </summary>
        /// <param name="g">The grahpics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="p1">Initial point.</param>
        /// <param name="p2">Terminal point.</param>
        public void DrawArrow(Graphics g, Pen pen, Brush brush, PointF p1, PointF p2)
        {
            PointF[] aptArrowHead = new PointF[3];

            // set first node to terminal point            
            aptArrowHead[0] = p2;

            Vector vecLine = new Vector(p2.X - p1.X, p2.Y - p1.Y);// build the line vector
            Vector vecLeft = new Vector(-vecLine[1], vecLine[0]);// build the arrow base vector - normal to the line

            // setup remaining arrow head points
            float lineLength = vecLine.Length;
            float th = Width / (2.0f * lineLength);
            float ta = Width / (2.0f * ((float)Math.Tan(Theta / 2.0f)) * lineLength);

            // find the base of the arrow
            PointF pBase = new PointF(aptArrowHead[0].X + -ta * vecLine[0], aptArrowHead[0].Y + -ta * vecLine[1]); //base of the arrow

            // build the points on the sides of the arrow
            aptArrowHead[1] = new PointF(pBase.X + th * vecLeft[0], pBase.Y + th * vecLeft[1]);
            aptArrowHead[2] = new PointF(pBase.X + -th * vecLeft[0], pBase.Y + -th * vecLeft[1]);

            g.DrawLine(pen, p1, pBase); //master line

            if (FillArrowHead) g.FillPolygon(brush, aptArrowHead); //fill arrow head if desired

            g.DrawPolygon(pen, aptArrowHead); //draw outline
        }

        #endregion

        #region DrawArrowOnCurve

        /// <summary>
        /// Draws the arrow on curve.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="controlPoints">The control points.</param>
        /// <exception cref="System.ArgumentException">controlPoints has to be valid float array 8 elements in length</exception>
        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, float[] controlPoints)
        {
            if (controlPoints.Length != 8)
                throw new ArgumentException("controlPoints has to be valid float array 8 elements in length");
            DrawArrowOnCurve(g, pen, brush, controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3],
                                            controlPoints[4], controlPoints[5], controlPoints[6], controlPoints[7]);
        }

        /// <summary>
        /// Renders the arrow on given graphics using desired paramethers.
        /// </summary>
        /// <param name="g">The grahpics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="p1">Initial point.</param>
        /// <param name="p2">Terminal point.</param>
        /// <param name="p1c">First control point.</param>
        /// <param name="p2c">Second control point.</param>
        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, PointF p1, PointF p2, PointF p1c, PointF p2c)
        {
            DrawArrowOnCurve(g, pen, brush, p1.X, p1.Y, p2.X, p2.Y, p1c.X, p1c.Y, p2c.X, p2c.Y);
        }

        /// <summary>
        /// Draws the arrow on curve.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="p1X">The p1 x.</param>
        /// <param name="p1Y">The p1 y.</param>
        /// <param name="p2X">The p2 x.</param>
        /// <param name="p2Y">The p2 y.</param>
        /// <param name="p1cX">The P1C x.</param>
        /// <param name="p1cY">The P1C y.</param>
        /// <param name="p2cX">The P2C x.</param>
        /// <param name="p2cY">The P2C y.</param>
        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY)
        {
            if (numberOfBezierCurveNodes < 4) numberOfBezierCurveNodes = 4;
            PointF[] bezierLine = GetBezierCurveNodes(p1X, p1Y, p2X, p2Y, p1cX, p1cY, p2cX, p2cY, numberOfBezierCurveNodes);

            float arrowHeadHeight = width / (2.0f * ((float)Math.Tan(theta / 2.0f)));
            float distDelta = arrowHeadHeight;
            int lineTerminalNode = bezierLine.Length - 2;
            for (int i = bezierLine.Length - 2; i >= 1; i--)
            {
                float currDist = GetDistance(bezierLine[i].X, bezierLine[i].Y, p2X, p2Y);
                float tempDelta = Math.Abs(arrowHeadHeight - currDist);

                if (tempDelta > distDelta) break;
                distDelta = tempDelta;
                lineTerminalNode = i;
            }

            PointF pBase = bezierLine[lineTerminalNode]; //set arrow base node
            arrowHeadHeight = GetDistance(pBase.X, pBase.Y, p2X, p2Y);

            PointF[] aptArrowHead = new PointF[3];
            aptArrowHead[0] = new PointF(p2X, p2Y); // set first node to terminal point

            //Vector vecLine = new Vector(p2.X - pBase.X, p2.Y - pBase.Y); // build the arrow height vector
            //Vector vecLeft = new Vector(pBase.Y - p2.Y, p2.X - pBase.X); // build the arrow base vector - normal to the line

            float th = width / (2.0f * arrowHeadHeight);//coeficient used for remaining arrow head points setup
            // build the points on the remaining sides of the arrow
            aptArrowHead[1] = new PointF(pBase.X + th * (pBase.Y - p2Y), pBase.Y + th * (p2X - pBase.X));
            aptArrowHead[2] = new PointF(pBase.X + th * (p2Y - pBase.Y), pBase.Y + th * (pBase.X - p2X));

            g.DrawCurve(pen, bezierLine, 0, lineTerminalNode); //master line
            if (FillArrowHead) g.FillPolygon(brush, aptArrowHead); //fill arrow head if desired
            g.DrawPolygon(pen, aptArrowHead); //draw outline

            #region Debug - nodes
            /* //visually check position of all nodes
            using (Pen ppp = new Pen(Color.FromArgb(150, Color.Red)))
                for (int i = 0; i < bezierLine.Length; i++)
                {
                    g.DrawEllipse(ppp, bezierLine[i].X - 2, bezierLine[i].Y - 2, 4, 4);
                }*/
            #endregion

            #region Alternate - draw path

            /*using(GraphicsPath gp = new GraphicsPath())
            {
                //gp.FillMode = FillMode.Alternate;
                gp.AddCurve(bezierLine, 0, lineTerminalNode, 1); //master line
                gp.AddPolygon(aptArrowHead); //outline

                if (FillArrowHead) 
                    g.FillPath(brush, gp); //fill arrow head if desired
                g.DrawPath(pen, gp);
            }*/

            #endregion
        }

        /// <summary>
        /// Gets the bezier curve nodes.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="p1c">The P1C.</param>
        /// <param name="p2c">The P2C.</param>
        /// <param name="numberOfNodes">The number of nodes.</param>
        /// <returns>PointF[].</returns>
        private PointF[] GetBezierCurveNodes(PointF p1, PointF p2, PointF p1c, PointF p2c, int numberOfNodes)
        {
            return GetBezierCurveNodes(p1.X, p1.Y, p2.X, p2.Y, p1c.X, p1c.Y, p2c.X, p2c.Y, numberOfNodes);
        }

        /// <summary>
        /// Gets the bezier curve nodes.
        /// </summary>
        /// <param name="p1X">The p1 x.</param>
        /// <param name="p1Y">The p1 y.</param>
        /// <param name="p2X">The p2 x.</param>
        /// <param name="p2Y">The p2 y.</param>
        /// <param name="p1cX">The P1C x.</param>
        /// <param name="p1cY">The P1C y.</param>
        /// <param name="p2cX">The P2C x.</param>
        /// <param name="p2cY">The P2C y.</param>
        /// <param name="numberOfNodes">The number of nodes.</param>
        /// <returns>PointF[].</returns>
        protected PointF[] GetBezierCurveNodes(float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY, int numberOfNodes)
        {
            PointF[] apt = new PointF[numberOfNodes];

            float dt = 1f / (apt.Length - 1);
            float t = -dt;
            for (int i = 0; i < apt.Length; i++)
            {
                t += dt;
                float tt = t * t;
                float ttt = tt * t;
                float tt1 = (1 - t) * (1 - t);
                float ttt1 = tt1 * (1 - t);

                float x = ttt1 * p1X +
                          3 * t * tt1 * p1cX +
                          3 * tt * (1 - t) * p2cX +
                          ttt * p2X;

                float y = ttt1 * p1Y +
                          3 * t * tt1 * p1cY +
                          3 * tt * (1 - t) * p2cY +
                          ttt * p2Y;

                apt[i] = new PointF(x, y);
            }
            return apt;
        }

        /// <summary>
        /// Calculate Euclieden distance between two points.
        /// </summary>
        /// <param name="x1">The first point x coordinate.</param>
        /// <param name="y1">The first point y coordinate</param>
        /// <param name="x2">The second point x coordinate</param>
        /// <param name="y2">The second point y coordinate</param>
        /// <returns>System.Single.</returns>
        protected float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        #endregion

        #region DrawArrows

        /// <summary>
        /// Draws the arrows.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="apf">The apf.</param>
        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf)
        {
            DrawArrows(g, pen, brush, apf, 0, 0);
        }

        /// <summary>
        /// Draws the arrows.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="apf">The apf.</param>
        /// <param name="startOffset">The start offset.</param>
        /// <param name="endOffset">The end offset.</param>
        /// <exception cref="System.ArgumentException">PointF[] apf has to be at least 2 in length</exception>
        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf, float startOffset, float endOffset)
        {
            if (apf.Length < 2) throw new ArgumentException("PointF[] apf has to be at least 2 in length");
            PointF[] newApf = new PointF[apf.Length + 1];
            Array.Copy(apf, newApf, apf.Length);
            newApf[newApf.Length - 1] = newApf[0];

            PointF fromP = newApf[0], toP;
            for (int i = 0; i < newApf.Length - 1; i++)
            {
                toP = newApf[i + 1];
                Vector vecLine = new Vector(toP.X - fromP.X, toP.Y - fromP.Y);
                Vector vecStart = vecLine - (vecLine.Length - startOffset);
                PointF nFromP = new PointF(fromP.X + vecStart.X, fromP.Y + vecStart.Y);
                Vector vecEnd = vecLine - endOffset;
                PointF nToP = new PointF(fromP.X + vecEnd.X, fromP.Y + vecEnd.Y);
                DrawArrow(g, pen, brush, nFromP, nToP);
                fromP = toP;
            }
        }

        /// <summary>
        /// Draws arrows between consecutive points.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="apf">Array of points at which arrow polygon will be spanned.</param>
        /// <param name="startOffsets">The start offsets.</param>
        /// <param name="endOffsets">The end offsets.</param>
        /// <exception cref="System.ArgumentException">
        /// PointF[] apf has to be at least 2 in length
        /// or
        /// apf, startOffsets and endOffsets have to be arrays of equal length
        /// </exception>
        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf, float[] startOffsets, float[] endOffsets)
        {
            if (apf.Length < 2) throw new ArgumentException("PointF[] apf has to be at least 2 in length");
            if (apf.Length != startOffsets.Length || apf.Length != endOffsets.Length ||
                endOffsets.Length != startOffsets.Length)
                throw new ArgumentException("apf, startOffsets and endOffsets have to be arrays of equal length");

            PointF[] newApf = new PointF[apf.Length + 1];
            Array.Copy(apf, newApf, apf.Length);
            newApf[newApf.Length - 1] = newApf[0];

            PointF fromP = newApf[0], toP;
            for (int i = 0; i < newApf.Length - 1; i++)
            {
                toP = newApf[i + 1];
                Vector vecLine = new Vector(toP.X - fromP.X, toP.Y - fromP.Y);
                Vector vecStart = vecLine - (vecLine.Length - startOffsets[i]);
                PointF nFromP = new PointF(fromP.X + vecStart.X, fromP.Y + vecStart.Y);
                Vector vecEnd = vecLine - endOffsets[i];
                PointF nToP = new PointF(fromP.X + vecEnd.X, fromP.Y + vecEnd.Y);
                DrawArrow(g, pen, brush, nFromP, nToP);
                fromP = toP;
            }
        }

        #endregion
    }

    #endregion
}
