// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BlendExample.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Gradient Blends

    /// <summary>
    /// Class BlendColorsExample.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class BlendColorsExample : Control
    {


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DemonstrateColorBlend(e);

        }

        #region Blend Examples 


        /// <summary>
        /// The following example is intended to be used in a Windows Forms environment.
        /// It demonstrates how to use the Blend class in conjunction with the LinearGradientBrush class to draw an ellipse to screen that has its colors blended.
        /// The ellipse is blue on the left, blends to red in the center, and blends back to blue on the right.
        /// This is accomplished through the settings in the myFactors and myPositions arrays used in the Factors and Positions properties.
        /// Note that the Blend property of the LinearGradientBrush object named lgBrush2 must be made equal to the Blend object myBlend.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void BlendConstExample(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothing;

            //Draw ellipse using Blend.
            Point startPoint2 = new Point(20, 110);
            Point endPoint2 = new Point(140, 110);
            float[] myFactors = { .2f, .4f, .8f, .8f, .4f, .2f };
            float[] myPositions = { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
            Blend myBlend = new Blend();

            myBlend.Factors = myFactors;
            myBlend.Positions = myPositions;

            LinearGradientBrush brush = new LinearGradientBrush(
                startPoint2,
                endPoint2,
                Color.Blue,
                Color.Red);
            brush.Blend = myBlend;


            Rectangle ellipseRect2 = new Rectangle(20, 110, 120, 80);
            e.Graphics.FillEllipse(brush, ellipseRect2);

            // End example.
        }


        /// <summary>
        /// The following code example demonstrates how to use the Blend class by setting the Factors and Positions properties.
        /// This example is designed to be used with Windows Forms. Paste the code into a form that imports the System.Drawing.Drawing2D namespace.
        /// Handle the form's Paint event and call the DemonstrateBlend method, passing e as PaintEventArgs.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>

        private void DemonstrateBlend(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothing;

            Blend blend1 = new Blend(9);

            // Set the values in the Factors array to be all green, 
            // go to all blue, and then go back to green.
            blend1.Factors = new float[]{0.0F, 0.2F, 0.5F, 0.7F, 1.0F,
                                    0.7F, 0.5F, 0.2F, 0.0F};

            // Set the positions.
            blend1.Positions =
                new float[]{0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F,
                0.7F, 0.8F, 1.0F};

            // Declare a rectangle to draw the Blend in.
            Rectangle rectangle1 = new Rectangle(10, 10, 120, 100);

            // Create a new LinearGradientBrush using the rectangle, 
            // green and blue. and 90-degree angle.
            LinearGradientBrush brush =
                new LinearGradientBrush(rectangle1, Color.LightGreen,
                Color.Blue, 90, true);


            // Set the Blend property on the brush to the custom blend.
            brush.Blend = blend1;


            // Fill in an ellipse with the brush.
            e.Graphics.FillEllipse(brush, rectangle1);

            // Dispose of the custom brush.
            brush.Dispose();
        }

        /// <summary>
        /// The following code example demonstrates how to use the ColorBlend class by setting the Factors and Positions properties.
        /// This example is designed to be used with Windows Forms. Paste the code into a form that imports the System.Drawing.Drawing2D namespace.
        /// Handle the form's Paint event and call the DemonstrateBlend method, passing e as PaintEventArgs.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DemonstrateColorBlend(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothing;

            // Declare a rectangle to draw the Blend in.
            Rectangle rectangle = new Rectangle(10, 10, 120, 100);

            // Create a new LinearGradientBrush using the rectangle, 
            // green and blue. and 90-degree angle.
            LinearGradientBrush brush =
                new LinearGradientBrush(rectangle, Color.LightGreen,
                Color.Blue, 90, true);


            ColorBlend colorBlend = new ColorBlend();

            Single[] blendPoints = new Single[]
            {
                0.000f,
                0.327f,
                0.439f,
                0.610f,
                0.777f,
                1.000f

            };

            Color[] blendcolors = new System.Drawing.Color[]
                {

                Color.Red,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.LightGray,
                Color.Indigo,
                Color.IndianRed,
                Color.DarkOrange
                };

            colorBlend.Positions = blendPoints;

            brush.InterpolationColors = colorBlend;


            // Fill in an ellipse with the brush.
            e.Graphics.FillEllipse(brush, rectangle);

            // Dispose of the custom brush.
            brush.Dispose();
        }

        #endregion

    }
    #endregion
}
