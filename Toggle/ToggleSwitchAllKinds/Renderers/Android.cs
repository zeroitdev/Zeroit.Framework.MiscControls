// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Android.cs" company="Zeroit Dev Technologies">
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
    #region Android Renderer
    /// <summary>
    /// Class ToggleSwitchAndroidRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ToggleSwitchRendererBase" />
    public class ToggleSwitchAndroidRenderer : ToggleSwitchRendererBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleSwitchAndroidRenderer"/> class.
        /// </summary>
        public ToggleSwitchAndroidRenderer()
        {
            BorderColor = Color.FromArgb(255, 166, 166, 166);
            BackColor = Color.FromArgb(255, 32, 32, 32);
            LeftSideColor = Color.FromArgb(255, 32, 32, 32);
            RightSideColor = Color.FromArgb(255, 32, 32, 32);
            OffButtonColor = Color.FromArgb(255, 70, 70, 70);
            OnButtonColor = Color.FromArgb(255, 27, 161, 226);
            OffButtonBorderColor = Color.FromArgb(255, 70, 70, 70);
            OnButtonBorderColor = Color.FromArgb(255, 27, 161, 226);
            SlantAngle = 8;
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the left side.
        /// </summary>
        /// <value>The color of the left side.</value>
        public Color LeftSideColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the right side.
        /// </summary>
        /// <value>The color of the right side.</value>
        public Color RightSideColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the off button.
        /// </summary>
        /// <value>The color of the off button.</value>
        public Color OffButtonColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the on button.
        /// </summary>
        /// <value>The color of the on button.</value>
        public Color OnButtonColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the off button border.
        /// </summary>
        /// <value>The color of the off button border.</value>
        public Color OffButtonBorderColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the on button border.
        /// </summary>
        /// <value>The color of the on button border.</value>
        public Color OnButtonBorderColor { get; set; }
        /// <summary>
        /// Gets or sets the slant angle.
        /// </summary>
        /// <value>The slant angle.</value>
        public int SlantAngle { get; set; }

        #endregion Public Properties

        #region Render Method Implementations

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="borderRectangle">The border rectangle.</param>
        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            Color borderColor = !ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled ? BorderColor.ToGrayScale() : BorderColor;

            g.SetClip(borderRectangle);

            using (Pen borderPen = new Pen(borderColor))
            {
                g.DrawRectangle(borderPen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
            }
        }

        /// <summary>
        /// Renders the left toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="leftRectangle">The left rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Color leftColor = LeftSideColor;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                leftColor = leftColor.ToGrayScale();

            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int halfCathetusLength = GetHalfCathetusLengthBasedOnAngle();

            Rectangle adjustedLeftRect = new Rectangle(leftRectangle.X, leftRectangle.Y, leftRectangle.Width + halfCathetusLength, leftRectangle.Height);

            g.IntersectClip(adjustedLeftRect);

            using (Brush leftBrush = new SolidBrush(leftColor))
            {
                g.FillRectangle(leftBrush, adjustedLeftRect);
            }

            g.ResetClip();
        }

        /// <summary>
        /// Renders the right toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rightRectangle">The right rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            Color rightColor = RightSideColor;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                rightColor = rightColor.ToGrayScale();

            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int halfCathetusLength = GetHalfCathetusLengthBasedOnAngle();

            Rectangle adjustedRightRect = new Rectangle(rightRectangle.X - halfCathetusLength, rightRectangle.Y, rightRectangle.Width + halfCathetusLength, rightRectangle.Height);

            g.IntersectClip(adjustedRightRect);

            using (Brush rightBrush = new SolidBrush(rightColor))
            {
                g.FillRectangle(rightBrush, adjustedRightRect);
            }

            g.ResetClip();
        }

        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="buttonRectangle">The button rectangle.</param>
        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int fullCathetusLength = GetCathetusLengthBasedOnAngle();
            int dblFullCathetusLength = 2 * fullCathetusLength;

            Point[] polygonPoints = new Point[4];

            Rectangle adjustedButtonRect = new Rectangle(buttonRectangle.X - fullCathetusLength, controlRectangle.Y, buttonRectangle.Width + dblFullCathetusLength, controlRectangle.Height);

            if (SlantAngle > 0)
            {
                polygonPoints[0] = new Point(adjustedButtonRect.X + fullCathetusLength, adjustedButtonRect.Y);
                polygonPoints[1] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - 1, adjustedButtonRect.Y);
                polygonPoints[2] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - fullCathetusLength - 1, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
                polygonPoints[3] = new Point(adjustedButtonRect.X, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
            }
            else
            {
                polygonPoints[0] = new Point(adjustedButtonRect.X, adjustedButtonRect.Y);
                polygonPoints[1] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - fullCathetusLength - 1, adjustedButtonRect.Y);
                polygonPoints[2] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - 1, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
                polygonPoints[3] = new Point(adjustedButtonRect.X + fullCathetusLength, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
            }

            g.IntersectClip(adjustedButtonRect);

            Color buttonColor = ToggleSwitch.Checked ? OnButtonColor : OffButtonColor;
            Color buttonBorderColor = ToggleSwitch.Checked ? OnButtonBorderColor : OffButtonBorderColor;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
            {
                buttonColor = buttonColor.ToGrayScale();
                buttonBorderColor = buttonBorderColor.ToGrayScale();
            }

            using (Pen buttonPen = new Pen(buttonBorderColor))
            {
                g.DrawPolygon(buttonPen, polygonPoints);
            }

            using (Brush buttonBrush = new SolidBrush(buttonColor))
            {
                g.FillPolygon(buttonBrush, polygonPoints);
            }

            Image buttonImage = ToggleSwitch.ButtonImage ?? (ToggleSwitch.Checked ? ToggleSwitch.OnButtonImage : ToggleSwitch.OffButtonImage);
            string buttonText = ToggleSwitch.Checked ? ToggleSwitch.OnText : ToggleSwitch.OffText;

            if (buttonImage != null || !string.IsNullOrEmpty(buttonText))
            {
                ZeroitToggleSwitch.ToggleSwitchButtonAlignment alignment = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonAlignment : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonAlignment : ToggleSwitch.OffButtonAlignment);

                if (buttonImage != null)
                {
                    Size imageSize = buttonImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)adjustedButtonRect.X;

                    bool scaleImage = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonScaleImageToFit : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonScaleImageToFit : ToggleSwitch.OffButtonScaleImageToFit);

                    if (scaleImage)
                    {
                        Size canvasSize = adjustedButtonRect.Size;
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(buttonImage, imageRectangle);
                    }
                    else
                    {
                        if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)imageSize.Width) / 2));
                        }
                        else if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(buttonImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(buttonText))
                {
                    Font buttonFont = ToggleSwitch.Checked ? ToggleSwitch.OnFont : ToggleSwitch.OffFont;
                    Color buttonForeColor = ToggleSwitch.Checked ? ToggleSwitch.OnForeColor : ToggleSwitch.OffForeColor;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        buttonForeColor = buttonForeColor.ToGrayScale();

                    SizeF textSize = g.MeasureString(buttonText, buttonFont);

                    float textXPos = adjustedButtonRect.X;

                    if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Center)
                    {
                        textXPos = (float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)textSize.Width) / 2);
                    }
                    else if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Right)
                    {
                        textXPos = (float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    using (Brush textBrush = new SolidBrush(buttonForeColor))
                    {
                        g.DrawString(buttonText, buttonFont, textBrush, textRectangle);
                    }
                }
            }

            g.ResetClip();
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        /// <summary>
        /// Gets the inner control rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle GetInnerControlRectangle()
        {
            return new Rectangle(1, 1, ToggleSwitch.Width - 2, ToggleSwitch.Height - 2);
        }

        /// <summary>
        /// Gets the cathetus length based on angle.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
                return 0;

            double degrees = Math.Abs(SlantAngle);
            double radians = degrees * (Math.PI / 180);
            double length = Math.Tan(radians) * ToggleSwitch.Height;

            return (int)length;
        }

        /// <summary>
        /// Gets the half cathetus length based on angle.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetHalfCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
                return 0;

            double degrees = Math.Abs(SlantAngle);
            double radians = degrees * (Math.PI / 180);
            double length = (Math.Tan(radians) * ToggleSwitch.Height) / 2;

            return (int)length;
        }

        /// <summary>
        /// Gets the width of the button.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetButtonWidth()
        {
            double buttonWidth = (double)ToggleSwitch.Width / 2;
            return (int)buttonWidth;
        }

        /// <summary>
        /// Gets the button rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        /// <summary>
        /// Gets the button rectangle.
        /// </summary>
        /// <param name="buttonWidth">Width of the button.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            Rectangle buttonRect = new Rectangle(ToggleSwitch.ButtonValue, 0, buttonWidth, ToggleSwitch.Height);
            return buttonRect;
        }

        #endregion Helper Method Implementations
    }
    #endregion
}
