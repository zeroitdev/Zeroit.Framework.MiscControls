// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Fancy.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    #region Fancy Renderer
    /// <summary>
    /// Class ToggleSwitchFancyRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ToggleSwitchRendererBase" />
    /// <seealso cref="System.IDisposable" />
    public class ToggleSwitchFancyRenderer : ToggleSwitchRendererBase, IDisposable
    {
        #region Constructor

        /// <summary>
        /// The inner control path
        /// </summary>
        private GraphicsPath _innerControlPath = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleSwitchFancyRenderer"/> class.
        /// </summary>
        public ToggleSwitchFancyRenderer()
        {
            OuterBorderColor1 = Color.FromArgb(255, 197, 199, 201);
            OuterBorderColor2 = Color.FromArgb(255, 207, 209, 212);
            InnerBorderColor1 = Color.FromArgb(200, 205, 208, 207);
            InnerBorderColor2 = Color.FromArgb(255, 207, 209, 212);
            LeftSideBackColor1 = Color.FromArgb(255, 61, 110, 6);
            LeftSideBackColor2 = Color.FromArgb(255, 93, 170, 9);
            RightSideBackColor1 = Color.FromArgb(255, 149, 0, 0);
            RightSideBackColor2 = Color.FromArgb(255, 198, 0, 0);
            ButtonNormalBorderColor1 = Color.FromArgb(255, 212, 209, 211);
            ButtonNormalBorderColor2 = Color.FromArgb(255, 197, 199, 201);
            ButtonNormalUpperSurfaceColor1 = Color.FromArgb(255, 252, 251, 252);
            ButtonNormalUpperSurfaceColor2 = Color.FromArgb(255, 247, 247, 247);
            ButtonNormalLowerSurfaceColor1 = Color.FromArgb(255, 233, 233, 233);
            ButtonNormalLowerSurfaceColor2 = Color.FromArgb(255, 225, 225, 225);
            ButtonHoverBorderColor1 = Color.FromArgb(255, 212, 207, 209);
            ButtonHoverBorderColor2 = Color.FromArgb(255, 223, 223, 223);
            ButtonHoverUpperSurfaceColor1 = Color.FromArgb(255, 240, 239, 240);
            ButtonHoverUpperSurfaceColor2 = Color.FromArgb(255, 235, 235, 235);
            ButtonHoverLowerSurfaceColor1 = Color.FromArgb(255, 221, 221, 221);
            ButtonHoverLowerSurfaceColor2 = Color.FromArgb(255, 214, 214, 214);
            ButtonPressedBorderColor1 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedBorderColor2 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedUpperSurfaceColor1 = Color.FromArgb(255, 189, 188, 189);
            ButtonPressedUpperSurfaceColor2 = Color.FromArgb(255, 185, 185, 185);
            ButtonPressedLowerSurfaceColor1 = Color.FromArgb(255, 175, 175, 175);
            ButtonPressedLowerSurfaceColor2 = Color.FromArgb(255, 169, 169, 169);
            ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);

            ButtonShadowWidth = 7;
            CornerRadius = 6;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_innerControlPath != null)
                _innerControlPath.Dispose();
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets or sets the outer border color1.
        /// </summary>
        /// <value>The outer border color1.</value>
        public Color OuterBorderColor1 { get; set; }
        /// <summary>
        /// Gets or sets the outer border color2.
        /// </summary>
        /// <value>The outer border color2.</value>
        public Color OuterBorderColor2 { get; set; }
        /// <summary>
        /// Gets or sets the inner border color1.
        /// </summary>
        /// <value>The inner border color1.</value>
        public Color InnerBorderColor1 { get; set; }
        /// <summary>
        /// Gets or sets the inner border color2.
        /// </summary>
        /// <value>The inner border color2.</value>
        public Color InnerBorderColor2 { get; set; }
        /// <summary>
        /// Gets or sets the left side back color1.
        /// </summary>
        /// <value>The left side back color1.</value>
        public Color LeftSideBackColor1 { get; set; }
        /// <summary>
        /// Gets or sets the left side back color2.
        /// </summary>
        /// <value>The left side back color2.</value>
        public Color LeftSideBackColor2 { get; set; }
        /// <summary>
        /// Gets or sets the right side back color1.
        /// </summary>
        /// <value>The right side back color1.</value>
        public Color RightSideBackColor1 { get; set; }
        /// <summary>
        /// Gets or sets the right side back color2.
        /// </summary>
        /// <value>The right side back color2.</value>
        public Color RightSideBackColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button normal border color1.
        /// </summary>
        /// <value>The button normal border color1.</value>
        public Color ButtonNormalBorderColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button normal border color2.
        /// </summary>
        /// <value>The button normal border color2.</value>
        public Color ButtonNormalBorderColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button normal upper surface color1.
        /// </summary>
        /// <value>The button normal upper surface color1.</value>
        public Color ButtonNormalUpperSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button normal upper surface color2.
        /// </summary>
        /// <value>The button normal upper surface color2.</value>
        public Color ButtonNormalUpperSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button normal lower surface color1.
        /// </summary>
        /// <value>The button normal lower surface color1.</value>
        public Color ButtonNormalLowerSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button normal lower surface color2.
        /// </summary>
        /// <value>The button normal lower surface color2.</value>
        public Color ButtonNormalLowerSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button hover border color1.
        /// </summary>
        /// <value>The button hover border color1.</value>
        public Color ButtonHoverBorderColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button hover border color2.
        /// </summary>
        /// <value>The button hover border color2.</value>
        public Color ButtonHoverBorderColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button hover upper surface color1.
        /// </summary>
        /// <value>The button hover upper surface color1.</value>
        public Color ButtonHoverUpperSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button hover upper surface color2.
        /// </summary>
        /// <value>The button hover upper surface color2.</value>
        public Color ButtonHoverUpperSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button hover lower surface color1.
        /// </summary>
        /// <value>The button hover lower surface color1.</value>
        public Color ButtonHoverLowerSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button hover lower surface color2.
        /// </summary>
        /// <value>The button hover lower surface color2.</value>
        public Color ButtonHoverLowerSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed border color1.
        /// </summary>
        /// <value>The button pressed border color1.</value>
        public Color ButtonPressedBorderColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed border color2.
        /// </summary>
        /// <value>The button pressed border color2.</value>
        public Color ButtonPressedBorderColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed upper surface color1.
        /// </summary>
        /// <value>The button pressed upper surface color1.</value>
        public Color ButtonPressedUpperSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed upper surface color2.
        /// </summary>
        /// <value>The button pressed upper surface color2.</value>
        public Color ButtonPressedUpperSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed lower surface color1.
        /// </summary>
        /// <value>The button pressed lower surface color1.</value>
        public Color ButtonPressedLowerSurfaceColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button pressed lower surface color2.
        /// </summary>
        /// <value>The button pressed lower surface color2.</value>
        public Color ButtonPressedLowerSurfaceColor2 { get; set; }
        /// <summary>
        /// Gets or sets the button shadow color1.
        /// </summary>
        /// <value>The button shadow color1.</value>
        public Color ButtonShadowColor1 { get; set; }
        /// <summary>
        /// Gets or sets the button shadow color2.
        /// </summary>
        /// <value>The button shadow color2.</value>
        public Color ButtonShadowColor2 { get; set; }

        /// <summary>
        /// Gets or sets the width of the button shadow.
        /// </summary>
        /// <value>The width of the button shadow.</value>
        public int ButtonShadowWidth { get; set; }
        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get; set; }

        #endregion Public Properties

        #region Render Method Implementations

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="borderRectangle">The border rectangle.</param>
        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //Draw outer border
            using (GraphicsPath outerBorderPath = GetRoundedRectanglePath(borderRectangle, CornerRadius))
            {
                g.SetClip(outerBorderPath);

                Color outerBorderColor1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? OuterBorderColor1.ToGrayScale() : OuterBorderColor1;
                Color outerBorderColor2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? OuterBorderColor2.ToGrayScale() : OuterBorderColor2;

                using (Brush outerBorderBrush = new LinearGradientBrush(borderRectangle, outerBorderColor1, outerBorderColor2, LinearGradientMode.Vertical))
                {
                    g.FillPath(outerBorderBrush, outerBorderPath);
                }

                g.ResetClip();
            }

            //Draw inner border
            Rectangle innerborderRectangle = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 2, borderRectangle.Height - 2);

            using (GraphicsPath innerBorderPath = GetRoundedRectanglePath(innerborderRectangle, CornerRadius))
            {
                g.SetClip(innerBorderPath);

                Color innerBorderColor1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor1.ToGrayScale() : InnerBorderColor1;
                Color innerBorderColor2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor2.ToGrayScale() : InnerBorderColor2;

                using (Brush borderBrush = new LinearGradientBrush(borderRectangle, innerBorderColor1, innerBorderColor2, LinearGradientMode.Vertical))
                {
                    g.FillPath(borderBrush, innerBorderPath);
                }

                g.ResetClip();
            }

            Rectangle backgroundRectangle = new Rectangle(borderRectangle.X + 2, borderRectangle.Y + 2, borderRectangle.Width - 4, borderRectangle.Height - 4);
            _innerControlPath = GetRoundedRectanglePath(backgroundRectangle, CornerRadius);
        }

        /// <summary>
        /// Renders the left toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="leftRectangle">The left rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            int buttonWidth = GetButtonWidth();

            //Draw inner background
            int gradientRectWidth = leftRectangle.Width + buttonWidth / 2;
            Rectangle gradientRectangle = new Rectangle(leftRectangle.X, leftRectangle.Y, gradientRectWidth, leftRectangle.Height);

            Color leftSideBackColor1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColor1.ToGrayScale() : LeftSideBackColor1;
            Color leftSideBackColor2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColor2.ToGrayScale() : LeftSideBackColor2;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(gradientRectangle);
            }
            else
            {
                g.SetClip(gradientRectangle);
            }

            using (Brush backgroundBrush = new LinearGradientBrush(gradientRectangle, leftSideBackColor1, leftSideBackColor2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(backgroundBrush, gradientRectangle);
            }

            g.ResetClip();

            Rectangle leftShadowRectangle = new Rectangle();
            leftShadowRectangle.X = leftRectangle.X + leftRectangle.Width - ButtonShadowWidth;
            leftShadowRectangle.Y = leftRectangle.Y;
            leftShadowRectangle.Width = ButtonShadowWidth + CornerRadius;
            leftShadowRectangle.Height = leftRectangle.Height;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(leftShadowRectangle);
            }
            else
            {
                g.SetClip(leftShadowRectangle);
            }

            using (Brush buttonShadowBrush = new LinearGradientBrush(leftShadowRectangle, ButtonShadowColor2, ButtonShadowColor1, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(buttonShadowBrush, leftShadowRectangle);
            }

            g.ResetClip();

            //Draw image or text
            if (ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OnText))
            {
                RectangleF fullRectangle = new RectangleF(leftRectangle.X + 1 - (totalToggleFieldWidth - leftRectangle.Width), 1, totalToggleFieldWidth - 1, ToggleSwitch.Height - 2);

                if (_innerControlPath != null)
                {
                    g.SetClip(_innerControlPath);
                    g.IntersectClip(fullRectangle);
                }
                else
                {
                    g.SetClip(fullRectangle);
                }

                if (ToggleSwitch.OnSideImage != null)
                {
                    Size imageSize = ToggleSwitch.OnSideImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)fullRectangle.X;

                    if (ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size canvasSize = new Size((int)fullRectangle.Width, (int)fullRectangle.Height);
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                    else
                    {
                        if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(ToggleSwitch.OnText))
                {
                    SizeF textSize = g.MeasureString(ToggleSwitch.OnText, ToggleSwitch.OnFont);

                    float textXPos = fullRectangle.X;

                    if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OnSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        textXPos = (float)fullRectangle.X + (float)fullRectangle.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)fullRectangle.Y + (((float)fullRectangle.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    Color textForeColor = ToggleSwitch.OnForeColor;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        textForeColor = textForeColor.ToGrayScale();

                    using (Brush textBrush = new SolidBrush(textForeColor))
                    {
                        g.DrawString(ToggleSwitch.OnText, ToggleSwitch.OnFont, textBrush, textRectangle);
                    }
                }

                g.ResetClip();
            }
        }

        /// <summary>
        /// Renders the right toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rightRectangle">The right rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            int buttonWidth = GetButtonWidth();

            //Draw inner background
            int gradientRectWidth = rightRectangle.Width + buttonWidth / 2;
            Rectangle gradientRectangle = new Rectangle(rightRectangle.X - buttonWidth / 2, rightRectangle.Y, gradientRectWidth, rightRectangle.Height);

            Color rightSideBackColor1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideBackColor1.ToGrayScale() : RightSideBackColor1;
            Color rightSideBackColor2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideBackColor2.ToGrayScale() : RightSideBackColor2;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(gradientRectangle);
            }
            else
            {
                g.SetClip(gradientRectangle);
            }

            using (Brush backgroundBrush = new LinearGradientBrush(gradientRectangle, rightSideBackColor1, rightSideBackColor2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(backgroundBrush, gradientRectangle);
            }

            g.ResetClip();

            Rectangle rightShadowRectangle = new Rectangle();
            rightShadowRectangle.X = rightRectangle.X - CornerRadius;
            rightShadowRectangle.Y = rightRectangle.Y;
            rightShadowRectangle.Width = ButtonShadowWidth + CornerRadius;
            rightShadowRectangle.Height = rightRectangle.Height;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rightShadowRectangle);
            }
            else
            {
                g.SetClip(rightShadowRectangle);
            }

            using (Brush buttonShadowBrush = new LinearGradientBrush(rightShadowRectangle, ButtonShadowColor1, ButtonShadowColor2, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(buttonShadowBrush, rightShadowRectangle);
            }

            g.ResetClip();

            //Draw image or text
            if (ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OffText))
            {
                RectangleF fullRectangle = new RectangleF(rightRectangle.X, 1, totalToggleFieldWidth - 1, ToggleSwitch.Height - 2);

                if (_innerControlPath != null)
                {
                    g.SetClip(_innerControlPath);
                    g.IntersectClip(fullRectangle);
                }
                else
                {
                    g.SetClip(fullRectangle);
                }

                if (ToggleSwitch.OffSideImage != null)
                {
                    Size imageSize = ToggleSwitch.OffSideImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)fullRectangle.X;

                    if (ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size canvasSize = new Size((int)fullRectangle.Width, (int)fullRectangle.Height);
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                    else
                    {
                        if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(ToggleSwitch.OffSideImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(ToggleSwitch.OffText))
                {
                    SizeF textSize = g.MeasureString(ToggleSwitch.OffText, ToggleSwitch.OffFont);

                    float textXPos = fullRectangle.X;

                    if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OffSideAlignment == ZeroitToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        textXPos = (float)fullRectangle.X + (float)fullRectangle.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)fullRectangle.Y + (((float)fullRectangle.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    Color textForeColor = ToggleSwitch.OffForeColor;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        textForeColor = textForeColor.ToGrayScale();

                    using (Brush textBrush = new SolidBrush(textForeColor))
                    {
                        g.DrawString(ToggleSwitch.OffText, ToggleSwitch.OffFont, textBrush, textRectangle);
                    }
                }

                g.ResetClip();
            }
        }

        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="buttonRectangle">The button rectangle.</param>
        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //Draw button surface
            Color buttonUpperSurfaceColor1 = ButtonNormalUpperSurfaceColor1;
            Color buttonUpperSurfaceColor2 = ButtonNormalUpperSurfaceColor2;
            Color buttonLowerSurfaceColor1 = ButtonNormalLowerSurfaceColor1;
            Color buttonLowerSurfaceColor2 = ButtonNormalLowerSurfaceColor2;

            if (ToggleSwitch.IsButtonPressed)
            {
                buttonUpperSurfaceColor1 = ButtonPressedUpperSurfaceColor1;
                buttonUpperSurfaceColor2 = ButtonPressedUpperSurfaceColor2;
                buttonLowerSurfaceColor1 = ButtonPressedLowerSurfaceColor1;
                buttonLowerSurfaceColor2 = ButtonPressedLowerSurfaceColor2;
            }
            else if (ToggleSwitch.IsButtonHovered)
            {
                buttonUpperSurfaceColor1 = ButtonHoverUpperSurfaceColor1;
                buttonUpperSurfaceColor2 = ButtonHoverUpperSurfaceColor2;
                buttonLowerSurfaceColor1 = ButtonHoverLowerSurfaceColor1;
                buttonLowerSurfaceColor2 = ButtonHoverLowerSurfaceColor2;
            }

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
            {
                buttonUpperSurfaceColor1 = buttonUpperSurfaceColor1.ToGrayScale();
                buttonUpperSurfaceColor2 = buttonUpperSurfaceColor2.ToGrayScale();
                buttonLowerSurfaceColor1 = buttonLowerSurfaceColor1.ToGrayScale();
                buttonLowerSurfaceColor2 = buttonLowerSurfaceColor2.ToGrayScale();
            }

            buttonRectangle.Inflate(-1, -1);

            int upperHeight = buttonRectangle.Height / 2;

            Rectangle upperGradientRect = new Rectangle(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Width, upperHeight);
            Rectangle lowerGradientRect = new Rectangle(buttonRectangle.X, buttonRectangle.Y + upperHeight, buttonRectangle.Width, buttonRectangle.Height - upperHeight);

            using (GraphicsPath buttonPath = GetRoundedRectanglePath(buttonRectangle, CornerRadius))
            {
                g.SetClip(buttonPath);
                g.IntersectClip(upperGradientRect);

                //Draw upper button surface gradient
                using (Brush buttonUpperSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonUpperSurfaceColor1, buttonUpperSurfaceColor2, LinearGradientMode.Vertical))
                {
                    g.FillPath(buttonUpperSurfaceBrush, buttonPath);
                }

                g.ResetClip();

                g.SetClip(buttonPath);
                g.IntersectClip(lowerGradientRect);

                //Draw lower button surface gradient
                using (Brush buttonLowerSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonLowerSurfaceColor1, buttonLowerSurfaceColor2, LinearGradientMode.Vertical))
                {
                    g.FillPath(buttonLowerSurfaceBrush, buttonPath);
                }

                g.ResetClip();

                g.SetClip(buttonPath);

                //Draw button border
                Color buttonBorderColor1 = ButtonNormalBorderColor1;
                Color buttonBorderColor2 = ButtonNormalBorderColor2;

                if (ToggleSwitch.IsButtonPressed)
                {
                    buttonBorderColor1 = ButtonPressedBorderColor1;
                    buttonBorderColor2 = ButtonPressedBorderColor2;
                }
                else if (ToggleSwitch.IsButtonHovered)
                {
                    buttonBorderColor1 = ButtonHoverBorderColor1;
                    buttonBorderColor2 = ButtonHoverBorderColor2;
                }

                if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                {
                    buttonBorderColor1 = buttonBorderColor1.ToGrayScale();
                    buttonBorderColor2 = buttonBorderColor2.ToGrayScale();
                }

                using (Brush buttonBorderBrush = new LinearGradientBrush(buttonRectangle, buttonBorderColor1, buttonBorderColor2, LinearGradientMode.Vertical))
                {
                    using (Pen buttonBorderPen = new Pen(buttonBorderBrush))
                    {
                        g.DrawPath(buttonBorderPen, buttonPath);
                    }
                }

                g.ResetClip();

                //Draw button image
                Image buttonImage = ToggleSwitch.ButtonImage ?? (ToggleSwitch.Checked ? ToggleSwitch.OnButtonImage : ToggleSwitch.OffButtonImage);

                if (buttonImage != null)
                {
                    g.SetClip(buttonPath);

                    ZeroitToggleSwitch.ToggleSwitchButtonAlignment alignment = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonAlignment : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonAlignment : ToggleSwitch.OffButtonAlignment);

                    Size imageSize = buttonImage.Size;

                    Rectangle imageRectangle;

                    int imageXPos = buttonRectangle.X;

                    bool scaleImage = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonScaleImageToFit : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonScaleImageToFit : ToggleSwitch.OffButtonScaleImageToFit);

                    if (scaleImage)
                    {
                        Size canvasSize = buttonRectangle.Size;
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)buttonRectangle.Y + (((float)buttonRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(buttonImage, imageRectangle);
                    }
                    else
                    {
                        if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (alignment == ZeroitToggleSwitch.ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)buttonRectangle.Y + (((float)buttonRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(buttonImage, imageRectangle);
                    }

                    g.ResetClip();
                }
            }
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        /// <summary>
        /// Gets the rounded rectangle path.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath GetRoundedRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            int diameter = 2 * radius;

            if (diameter > ToggleSwitch.Height)
                diameter = ToggleSwitch.Height;

            if (diameter > ToggleSwitch.Width)
                diameter = ToggleSwitch.Width;

            gp.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
            gp.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y, diameter, diameter, 270, 90);
            gp.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 0, 90);
            gp.AddArc(rectangle.X, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 90, 90);
            gp.CloseFigure();

            return gp;
        }

        /// <summary>
        /// Gets the width of the button.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetButtonWidth()
        {
            float buttonWidth = 1.61f * ToggleSwitch.Height;
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
