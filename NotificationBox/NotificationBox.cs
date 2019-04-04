// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NotificationBox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region  NotificationBox

    /// <summary>
    /// A class collection for rendering a notification control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitNotificationBoxDesigner))]
    public class ZeroitNotificationBox : Control
    {

        #region  Variables

        /// <summary>
        /// The close coordinates
        /// </summary>
        private Point CloseCoordinates;
        /// <summary>
        /// The is over close
        /// </summary>
        private bool IsOverClose;
        /// <summary>
        /// The border curve
        /// </summary>
        private int _BorderCurve = 8;
        /// <summary>
        /// The create round path
        /// </summary>
        private GraphicsPath CreateRoundPath;
        /// <summary>
        /// The notification text
        /// </summary>
        private string notificationText = "";
        /// <summary>
        /// The notification type
        /// </summary>
        private Type _NotificationType;
        /// <summary>
        /// The rounded corners
        /// </summary>
        private bool _RoundedCorners;
        /// <summary>
        /// The show close button
        /// </summary>
        private bool _ShowCloseButton;
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        // Declare Color to paint the control's Text, Background and Border
        /// <summary>
        /// The background color
        /// </summary>
        private Color backgroundColor = Color.FromArgb(111, 177, 199);
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(111, 177, 199);
        /// <summary>
        /// The fore color
        /// </summary>
        private Color foreColor = Color.White;
        /// <summary>
        /// The notice color
        /// </summary>
        private Color noticeColor = Color.White;
        /// <summary>
        /// The color close button
        /// </summary>
        private Color colorCloseButton = Color.FromArgb(130, 130, 130);

        // Determine the header Notification Type font
        /// <summary>
        /// The type font
        /// </summary>
        private Font typeFont = new Font("Tahoma", 9, FontStyle.Bold);

        /// <summary>
        /// The location x
        /// </summary>
        private float locationX = 12;
        /// <summary>
        /// The location y
        /// </summary>
        private float locationY = 4;
        /// <summary>
        /// The imagesize
        /// </summary>
        private float imagesize = 16;

        /// <summary>
        /// The textlocation x
        /// </summary>
        private int textlocationX = 10;
        /// <summary>
        /// The textlocation y
        /// </summary>
        private int textlocationY = 30;

        #endregion

        #region  Enums

        // Create a list of Notification Types        
        /// <summary>
        /// Enum for Create a list of Notification Types
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// The notice
            /// </summary>
            @Notice,
            /// <summary>
            /// The success
            /// </summary>
            @Success,
            /// <summary>
            /// The warning
            /// </summary>
            @Warning,
            /// <summary>
            /// The error
            /// </summary>
            @Error,
            /// <summary>
            /// The custom
            /// </summary>
            @Custom

        }

        #endregion

        #region Image Designer

        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region  Custom Properties        
        /// <summary>
        /// Gets or sets the horizontal text location.
        /// </summary>
        /// <value>The textlocation x.</value>
        public int TextlocationX
        {
            get { return textlocationX; }
            set
            {
                textlocationX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical text location.
        /// </summary>
        /// <value>The textlocation y.</value>
        public int TextlocationY
        {
            get { return textlocationY; }
            set
            {
                textlocationY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the horizontal image location.
        /// </summary>
        /// <value>The image location x.</value>
        public float ImageLocationX
        {
            get { return locationX; }
            set
            {
                locationX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical image location.
        /// </summary>
        /// <value>The image location y.</value>
        public float ImageLocationY
        {
            get { return locationY; }
            set
            {
                locationY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of image.
        /// </summary>
        /// <value>The size of image.</value>
        public float SizeOfImage
        {
            get { return imagesize; }
            set
            {
                imagesize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type font.
        /// </summary>
        /// <value>The type font.</value>
        public Font TypeFont
        {
            get { return typeFont; }
            set
            {
                typeFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the notification text.
        /// </summary>
        /// <value>The notification text.</value>
        public String NotificationText
        {
            get { return notificationText; }
            set
            {
                notificationText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the close button.
        /// </summary>
        /// <value>The color close button.</value>
        public Color ColorCloseButton
        {
            get { return colorCloseButton; }
            set
            {
                colorCloseButton = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color ColorText
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the notice.
        /// </summary>
        /// <value>The color of the notice.</value>
        public Color ColorNotice
        {
            get { return noticeColor; }
            set
            {
                noticeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color ColorBackground
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color ColorBorder
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        // Create a NotificationType property and add the Type enum to it        
        /// <summary>
        /// Gets or sets the type of the notification.
        /// </summary>
        /// <value>The type of the notification.</value>
        public Type NotificationType
        {
            get
            {
                return _NotificationType;
            }
            set
            {
                _NotificationType = value;
                Invalidate();
            }
        }
        // Boolean value to determine whether the control should use border radius        
        /// <summary>
        /// Gets or sets a value indicating whether the control should use rounded corners.
        /// </summary>
        /// <value><c>true</c> if round corners; otherwise, <c>false</c>.</value>
        public bool RoundCorners
        {
            get
            {
                return _RoundedCorners;
            }
            set
            {
                _RoundedCorners = value;
                Invalidate();
            }
        }

        // Boolean value to determine whether the control should draw the close button        
        /// <summary>
        /// Gets or sets a value indicating whether to show the close button.
        /// </summary>
        /// <value><c>true</c> if show close button; otherwise, <c>false</c>.</value>
        public bool ShowCloseButton
        {
            get
            {
                return _ShowCloseButton;
            }
            set
            {
                _ShowCloseButton = value;
                Invalidate();
            }
        }

        // Integer value to determine the curve level of the borders        
        /// <summary>
        /// Gets or sets the border curve.
        /// </summary>
        /// <value>The border curve.</value>
        public int BorderCurve
        {
            get
            {
                return _BorderCurve;
            }
            set
            {
                _BorderCurve = value;
                Invalidate();
            }
        }
        // Image value to determine whether the control should draw an image before the header        
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;

                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image alignment.
        /// </summary>
        /// <value>The image alignment.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        // Size value - returns the image size        
        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // Decides the location of the drawn ellipse. If mouse is over the correct coordinates, "IsOverClose" boolean will be triggered to draw the ellipse
            if (e.X >= Width - 19 && e.X <= Width - 10 && e.Y > CloseCoordinates.Y && e.Y < CloseCoordinates.Y + 12)
            {
                IsOverClose = true;
            }
            else
            {
                IsOverClose = false;
            }
            // Updates the control
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Disposes the control when the close button is clicked
            if (_ShowCloseButton == true)
            {
                if (IsOverClose)
                {
                    Dispose();
                }
            }
        }

        #endregion

        /// <summary>
        /// Creates the round rect.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="curve">The curve.</param>
        /// <returns>GraphicsPath.</returns>
        internal GraphicsPath CreateRoundRect(Rectangle r, int curve)
        {
            // Draw a border radius
            try
            {
                CreateRoundPath = new GraphicsPath(FillMode.Winding);
                CreateRoundPath.AddArc(r.X, r.Y, curve, curve, 180.0F, 90.0F);
                CreateRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270.0F, 90.0F);
                CreateRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0.0F, 90.0F);
                CreateRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90.0F, 90.0F);
                CreateRoundPath.CloseFigure();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + "Value must be either \'1\' or higher", "Invalid Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Return to the default border curve if the parameter is less than "1"
                _BorderCurve = 8;
                BorderCurve = 8;
            }
            return CreateRoundPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNotificationBox" /> class.
        /// </summary>
        public ZeroitNotificationBox()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor), true);
            BackColor = Color.Transparent;

            this.MinimumSize = new Size(100, 40);
            RoundCorners = false;
            ShowCloseButton = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            // Declare Graphics to draw the control
            Graphics GFX = e.Graphics;


            // Decalre a new rectangle to draw the control inside it
            Rectangle MainRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            // Declare a GraphicsPath to create a border radius
            GraphicsPath CrvBorderPath = CreateRoundRect(MainRectangle, _BorderCurve);

            GFX.SmoothingMode = SmoothingMode.HighQuality;
            GFX.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //GFX.Clear(Parent.BackColor);

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            //_G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

            #region Old Code
            switch (_NotificationType)
            {
                case Type.Notice:
                    backgroundColor = Color.FromArgb(111, 177, 199);
                    borderColor = Color.FromArgb(111, 177, 199);
                    foreColor = Color.White;
                    noticeColor = Color.White;

                    if (_RoundedCorners == true)
                    {
                        GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
                        GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
                    }
                    else
                    {
                        GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
                        GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
                    }

                    break;
                case Type.Success:
                    backgroundColor = Color.FromArgb(91, 195, 162);
                    borderColor = Color.FromArgb(91, 195, 162);
                    foreColor = Color.White;
                    noticeColor = Color.White;

                    if (_RoundedCorners == true)
                    {
                        GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
                        GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
                    }
                    else
                    {
                        GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
                        GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
                    }
                    break;
                case Type.Warning:
                    backgroundColor = Color.FromArgb(254, 209, 108);
                    borderColor = Color.FromArgb(254, 209, 108);
                    foreColor = Color.White;
                    noticeColor = Color.White;

                    if (_RoundedCorners == true)
                    {
                        GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
                        GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
                    }
                    else
                    {
                        GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
                        GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
                    }
                    break;
                case Type.Error:
                    backgroundColor = Color.FromArgb(217, 103, 93);
                    borderColor = Color.FromArgb(217, 103, 93);
                    foreColor = Color.White;
                    noticeColor = Color.White;

                    if (_RoundedCorners == true)
                    {
                        GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
                        GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
                    }
                    else
                    {
                        GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
                        GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
                    }

                    break;
                case Type.Custom:
                    if (_RoundedCorners == true)
                    {
                        GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
                        GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
                    }
                    else
                    {
                        GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
                        GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
                    }
                    break;
            }
            #endregion

            //if (_RoundedCorners == true)
            //{
            //    GFX.FillPath(new SolidBrush(backgroundColor), CrvBorderPath);
            //    GFX.DrawPath(new Pen(borderColor), CrvBorderPath);
            //}
            //else
            //{
            //    GFX.FillRectangle(new SolidBrush(backgroundColor), MainRectangle);
            //    GFX.DrawRectangle(new Pen(borderColor), MainRectangle);
            //}

            #region Old code
            switch (_NotificationType)
            {
                case Type.Notice:
                    notificationText = "NOTICE";

                    if (Image == null)
                    {
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    else
                    {
                        //GFX.DrawImage(_Image, 12, 4, 16, 16);

                        //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                        GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    break;
                case Type.Success:
                    notificationText = "SUCCESS";

                    if (Image == null)
                    {
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    else
                    {
                        //GFX.DrawImage(_Image, 12, 4, 16, 16);

                        //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                        GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    break;
                case Type.Warning:
                    notificationText = "WARNING";

                    if (Image == null)
                    {
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    else
                    {
                        //GFX.DrawImage(_Image, 12, 4, 16, 16);

                        //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                        GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    break;
                case Type.Error:
                    notificationText = "ERROR";

                    if (Image == null)
                    {
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    else
                    {
                        //GFX.DrawImage(_Image, 12, 4, 16, 16);

                        //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                        GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    break;
                case Type.Custom:

                    if (Image == null)
                    {
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    else
                    {
                        //GFX.DrawImage(_Image, 12, 4, 16, 16);

                        //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                        GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                        GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                        GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
                    }
                    break;
            }
            #endregion

            if (Image == null)
            {
                GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(10, 5));
                GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
            }
            else
            {
                //GFX.DrawImage(_Image, 12, 4, 16, 16);

                //GFX.DrawImage(_Image, ipt.X, ipt.Y, 16, 16);
                GFX.DrawImage(_Image, locationX, locationY, imagesize, imagesize);
                GFX.DrawString(notificationText, typeFont, new SolidBrush(noticeColor), new Point(30, 5));
                GFX.DrawString(Text, Font, new SolidBrush(foreColor), new Rectangle(textlocationX, textlocationY, Width - 17, Height - 5));
            }

            CloseCoordinates = new Point(Width - 26, 4);

            if (_ShowCloseButton == true)
            {
                // Draw the close button
                GFX.DrawString("r", new Font("Marlett", 7, FontStyle.Regular), new SolidBrush(colorCloseButton), new Rectangle(Width - 20, 10, Width, Height), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
            }

            CrvBorderPath.Dispose();
        }

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitNotificationBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitNotificationBoxDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitNotificationBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitNotificationBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitNotificationBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitNotificationBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNotificationBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitNotificationBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitNotificationBox;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.
        /// <summary>
        /// Gets or sets the textlocation x.
        /// </summary>
        /// <value>The textlocation x.</value>
        public int TextlocationX
        {
            get
            {
                return colUserControl.TextlocationX;
            }
            set
            {
                GetPropertyByName("TextlocationX").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the textlocation y.
        /// </summary>
        /// <value>The textlocation y.</value>
        public int TextlocationY
        {
            get
            {
                return colUserControl.TextlocationY;
            }
            set
            {
                GetPropertyByName("TextlocationY").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the image location x.
        /// </summary>
        /// <value>The image location x.</value>
        public float ImageLocationX
        {
            get
            {
                return colUserControl.ImageLocationX;
            }
            set
            {
                GetPropertyByName("ImageLocationX").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the image location y.
        /// </summary>
        /// <value>The image location y.</value>
        public float ImageLocationY
        {
            get
            {
                return colUserControl.ImageLocationY;
            }
            set
            {
                GetPropertyByName("ImageLocationY").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the size of image.
        /// </summary>
        /// <value>The size of image.</value>
        public float SizeOfImage
        {
            get
            {
                return colUserControl.SizeOfImage;
            }
            set
            {
                GetPropertyByName("SizeOfImage").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the type font.
        /// </summary>
        /// <value>The type font.</value>
        public Font TypeFont
        {
            get
            {
                return colUserControl.TypeFont;
            }
            set
            {
                GetPropertyByName("TypeFont").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the notification text.
        /// </summary>
        /// <value>The notification text.</value>
        public String NotificationText
        {
            get
            {
                return colUserControl.NotificationText;
            }
            set
            {
                GetPropertyByName("NotificationText").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color close button.
        /// </summary>
        /// <value>The color close button.</value>
        public Color ColorCloseButton
        {
            get
            {
                return colUserControl.ColorCloseButton;
            }
            set
            {
                GetPropertyByName("ColorCloseButton").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color notice.
        /// </summary>
        /// <value>The color notice.</value>
        public Color ColorNotice
        {
            get
            {
                return colUserControl.ColorNotice;
            }
            set
            {
                GetPropertyByName("ColorNotice").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color text.
        /// </summary>
        /// <value>The color text.</value>
        public Color ColorText
        {
            get
            {
                return colUserControl.ColorText;
            }
            set
            {
                GetPropertyByName("ColorText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background.</value>
        public Color ColorBackground
        {
            get
            {
                return colUserControl.ColorBackground;
            }
            set
            {
                GetPropertyByName("ColorBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
            }
        }

        // Create a NotificationType property and add the Type enum to it
        /// <summary>
        /// Gets or sets the type of the notification.
        /// </summary>
        /// <value>The type of the notification.</value>
        public Zeroit.Framework.MiscControls.ZeroitNotificationBox.Type NotificationType
        {
            get
            {
                return colUserControl.NotificationType;
            }
            set
            {
                GetPropertyByName("NotificationType").SetValue(colUserControl, value);
            }
        }
        // Boolean value to determine whether the control should use border radius
        /// <summary>
        /// Gets or sets a value indicating whether [round corners].
        /// </summary>
        /// <value><c>true</c> if [round corners]; otherwise, <c>false</c>.</value>
        public bool RoundCorners
        {
            get
            {
                return colUserControl.RoundCorners;
            }
            set
            {
                GetPropertyByName("RoundCorners").SetValue(colUserControl, value);
            }
        }
        // Boolean value to determine whether the control should draw the close button
        /// <summary>
        /// Gets or sets a value indicating whether [show close button].
        /// </summary>
        /// <value><c>true</c> if [show close button]; otherwise, <c>false</c>.</value>
        public bool ShowCloseButton
        {
            get
            {
                return colUserControl.ShowCloseButton;
            }
            set
            {
                GetPropertyByName("ShowCloseButton").SetValue(colUserControl, value);
            }
        }
        // Integer value to determine the curve level of the borders
        /// <summary>
        /// Gets or sets the border curve.
        /// </summary>
        /// <value>The border curve.</value>
        public int BorderCurve
        {
            get
            {
                return colUserControl.BorderCurve;
            }
            set
            {
                GetPropertyByName("BorderCurve").SetValue(colUserControl, value);
            }
        }
        // Image value to determine whether the control should draw an image before the header
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return colUserControl.Image;
            }
            set
            {
                GetPropertyByName("Image").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("TextlocationX",
                                 "Text LocationX", "Appearance",
                                 "Sets the xLocation of the text."));

            items.Add(new DesignerActionPropertyItem("TextlocationY",
                                 "Text LocationY", "Appearance",
                                 "Sets the yLocation of the text."));

            items.Add(new DesignerActionPropertyItem("ImageLocationX",
                                 "Image LocationX", "Appearance",
                                 "Sets the xLocation of the image."));

            items.Add(new DesignerActionPropertyItem("ImageLocationY",
                                 "Image LocationY", "Appearance",
                                 "Sets the yLocation of the image."));

            items.Add(new DesignerActionPropertyItem("SizeOfImage",
                                 "Size Of Image", "Appearance",
                                 "Sets the size of the image."));

            items.Add(new DesignerActionPropertyItem("TypeFont",
                                 "Type Font", "Appearance",
                                 "Sets the font of the text."));

            items.Add(new DesignerActionPropertyItem("NotificationText",
                                 "Notification Text", "Appearance",
                                 "Sets the notificate text."));

            items.Add(new DesignerActionPropertyItem("ColorCloseButton",
                                 "Color Close Button", "Appearance",
                                 "Sets the color of the close button."));

            items.Add(new DesignerActionPropertyItem("ColorNotice",
                                 "Color Notice", "Appearance",
                                 "Sets the color of the notice text."));

            items.Add(new DesignerActionPropertyItem("ColorText",
                                 "Color Text", "Appearance",
                                 "Sets the color of the main text."));

            items.Add(new DesignerActionPropertyItem("ColorBackground",
                                 "Color Background", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the color of the border."));

            items.Add(new DesignerActionPropertyItem("NotificationType",
                                 "Notification Type", "Appearance",
                                 "Sets the type of notification."));

            items.Add(new DesignerActionPropertyItem("RoundCorners",
                                 "Round Corners", "Appearance",
                                 "Set to enable rounded corners."));

            items.Add(new DesignerActionPropertyItem("ShowCloseButton",
                                 "Show Close Button", "Appearance",
                                 "Set to show the close button."));

            items.Add(new DesignerActionPropertyItem("BorderCurve",
                                 "Border Curve", "Appearance",
                                 "Set the border curve when rounded corners is enabled."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Set the image of the control."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion
}
