// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GradientPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region GradientPanel    
    /// <summary>
    /// A class collection for rendering a gradient panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [Designer(typeof(ZeroitPanelGradientDesigner))]
    public class ZeroitPanelGradient : ContainerControl
    {
        #region Variables

        /// <summary>
        /// The mouse state
        /// </summary>
        private int MouseState;
        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The inactive gb
        /// </summary>
        private LinearGradientBrush InactiveGB;
        /// <summary>
        /// The pressed gb
        /// </summary>
        private LinearGradientBrush PressedGB;
        /// <summary>
        /// The pressed contour gb
        /// </summary>
        private LinearGradientBrush PressedContourGB;
        /// <summary>
        /// The hover gb
        /// </summary>
        private LinearGradientBrush HoverGB;
        /// <summary>
        /// The hover contour gb
        /// </summary>
        private LinearGradientBrush HoverContourGB;
        /// <summary>
        /// The inactive contour gb
        /// </summary>
        private LinearGradientBrush InactiveContourGB;
        /// <summary>
        /// The r1
        /// </summary>
        private Rectangle R1;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The p2
        /// </summary>
        private Pen P2;
        /// <summary>
        /// The p3
        /// </summary>
        private Pen P3;
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The background color1
        /// </summary>
        private Color _BackgroundColor1;
        /// <summary>
        /// The background color2
        /// </summary>
        private Color _BackgroundColor2;
        /// <summary>
        /// The background color pressed1
        /// </summary>
        private Color _BackgroundColorPressed1;
        /// <summary>
        /// The background color pressed2
        /// </summary>
        private Color _BackgroundColorPressed2;
        /// <summary>
        /// The background color pressed contour1
        /// </summary>
        private Color _BackgroundColorPressedContour1;
        /// <summary>
        /// The background color pressed contour2
        /// </summary>
        private Color _BackgroundColorPressedContour2;
        /// <summary>
        /// The background contour1
        /// </summary>
        private Color _BackgroundContour1;
        /// <summary>
        /// The background contour2
        /// </summary>
        private Color _BackgroundContour2;
        /// <summary>
        /// The hover contour1
        /// </summary>
        private Color _HoverContour1;
        /// <summary>
        /// The hover contour2
        /// </summary>
        private Color _HoverContour2;
        /// <summary>
        /// The hover back color1
        /// </summary>
        private Color _HoverBackColor1;
        /// <summary>
        /// The hover back color2
        /// </summary>
        private Color _HoverBackColor2;
        /// <summary>
        /// The radius upper left
        /// </summary>
        private Int32 _RadiusUpperLeft = 10;
        /// <summary>
        /// The radius upper right
        /// </summary>
        private Int32 _RadiusUpperRight = 10;
        /// <summary>
        /// The radius bottom left
        /// </summary>
        private Int32 _RadiusBottomLeft = 10;
        /// <summary>
        /// The radius bottom right
        /// </summary>
        private Int32 _RadiusBottomRight = 10;
        /// <summary>
        /// The angle
        /// </summary>
        private Double _Angle = 90f;
        /// <summary>
        /// The correct angle
        /// </summary>
        private float CorrectAngle;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

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
        #region Properties        
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
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
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get { return this._TextAlignment; }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image alignment.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get { return this._BackgroundColor1; }
            set
            {
                this._BackgroundColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get { return this._BackgroundColor2; }
            set
            {
                this._BackgroundColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed1.</value>
        public Color BackgroundColorPressed1
        {
            get { return this._BackgroundColorPressed1; }
            set
            {
                this._BackgroundColorPressed1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed2.</value>
        public Color BackgroundColorPressed2
        {
            get { return this._BackgroundColorPressed2; }
            set
            {
                this._BackgroundColorPressed2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background border color pressed1.</value>
        public Color BackgroundColorPressedContour1
        {
            get { return this._BackgroundColorPressedContour1; }
            set
            {
                this._BackgroundColorPressedContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background border color pressed2.</value>
        public Color BackgroundColorPressedContour2
        {
            get { return this._BackgroundColorPressedContour2; }
            set
            {
                this._BackgroundColorPressedContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is hovered.
        /// </summary>
        /// <value>The back hover color1.</value>
        public Color BackHoverColor1
        {
            get { return this._HoverBackColor1; }
            set
            {
                this._HoverBackColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is hovered.
        /// </summary>
        /// <value>The back hover color2.</value>
        public Color BackHoverColor2
        {
            get { return this._HoverBackColor2; }
            set
            {
                this._HoverBackColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color when the control is hovered.
        /// </summary>
        /// <value>The hover contour1.</value>
        public Color HoverContour1
        {
            get { return this._HoverContour1; }
            set
            {
                this._HoverContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color when the control is hovered.
        /// </summary>
        /// <value>The hover contour2.</value>
        public Color HoverContour2
        {
            get { return this._HoverContour2; }
            set
            {
                this._HoverContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value>The border contour1.</value>
        public Color BackgroundContour1
        {
            get { return this._BackgroundContour1; }
            set
            {
                this._BackgroundContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value>The border contour2.</value>
        public Color BackgroundContour2
        {
            get { return this._BackgroundContour2; }
            set
            {
                this._BackgroundContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The radius.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 1.</exception>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 Radius
        {
            get
            {
                return this._RadiusUpperLeft;
                return this._RadiusUpperRight;
                return this._RadiusBottomLeft;
                return this._RadiusBottomRight;
            }
            set
            {
                if (_RadiusUpperLeft == null && _RadiusUpperRight == null && _RadiusBottomLeft == null && _RadiusBottomRight == null)
                {
                    this._RadiusUpperLeft = 10;
                    this._RadiusUpperRight = 10;
                    this._RadiusBottomLeft = 10;
                    this._RadiusBottomRight = 10;

                    Invalidate();
                }

                if (value < 1)
                {

                    this._RadiusUpperLeft = 1;
                    this._RadiusUpperRight = 1;
                    this._RadiusBottomLeft = 1;
                    this._RadiusBottomRight = 1;
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 1.");

                }


                this._RadiusUpperLeft = value;

                this._RadiusUpperRight = value;

                this._RadiusBottomLeft = value;

                this._RadiusBottomRight = value;

                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The radius upper left.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperLeft
        {
            get { return this._RadiusUpperLeft; }
            set
            {
                if (_RadiusUpperLeft == null)
                {
                    this._RadiusUpperLeft = 10;

                }


                this._RadiusUpperLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius upper right.</value>
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperRight
        {
            get { return this._RadiusUpperRight; }
            set
            {
                if (_RadiusUpperRight == null)
                {
                    this._RadiusUpperRight = 10;

                }

                this._RadiusUpperRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom left.</value>
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomLeft
        {
            get { return this._RadiusBottomLeft; }
            set
            {
                if (_RadiusBottomLeft == null)
                {
                    this._RadiusBottomLeft = 10;

                }

                this._RadiusBottomLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom right.</value>
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomRight
        {
            get { return this._RadiusBottomRight; }
            set
            {
                if (_RadiusBottomRight == null)
                {
                    this._RadiusBottomRight = 10;

                }

                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }


        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The angle.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"),
        Browsable(true)]
        public Double Angle
        {
            get { return this._Angle; }
            set
            {
                if (_Angle == null)
                {
                    this._Angle = 30f;
                }

                this._Angle = value;
                CorrectAngle = DoubleToFloat(_Angle);

                this.Invalidate();



            }
        }

        /// <summary>
        /// Doubles to float.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <returns>System.Single.</returns>
        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        #endregion
        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            // [Inactive]
            Invalidate();
            // Update control
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPanelGradient" /> class.
        /// </summary>
        public ZeroitPanelGradient()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);


                // Button Background Colors
                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
                InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
                HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
                HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);
                P1 = new Pen(InactiveContourGB);
                P3 = new Pen(PressedContourGB);
                P2 = new Pen(HoverContourGB);
            }

            // Button Radius iTalk
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;

                case 2:
                    _G.FillPath(HoverGB, Shape);
                    _G.DrawPath(P2, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }

            if (DesignMode)
            {
                Font = new Font("Tahoma", 10);

            }

            #region Remove code if it causes trouble
            //if (Width > 0 && Height > 0)
            //{
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            // Button Background Colors
            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
            InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
            HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
            HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);
            P1 = new Pen(InactiveContourGB);
            P3 = new Pen(PressedContourGB);
            P2 = new Pen(HoverContourGB);
            //}

            // Button Radius
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();
            #endregion
            base.OnPaint(e);
        }

        //-----------------------------------Allow Form To Be Dragged ---------------------------------//

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
        //    {
        //        m.Result = (IntPtr)2;   // HTCLIENT
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPanelGradientDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPanelGradientDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPanelGradientSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPanelGradientSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPanelGradientSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPanelGradient colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPanelGradientSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPanelGradientSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPanelGradient;

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

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get
            {
                return colUserControl.TextAlignment;
            }
            set
            {
                GetPropertyByName("TextAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get
            {
                return colUserControl.ImageAlign;
            }
            set
            {
                GetPropertyByName("ImageAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color1.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get
            {
                return colUserControl.BackgroundColor1;
            }
            set
            {
                GetPropertyByName("BackgroundColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color2.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get
            {
                return colUserControl.BackgroundColor2;
            }
            set
            {
                GetPropertyByName("BackgroundColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed1.
        /// </summary>
        /// <value>The background color pressed1.</value>
        public Color BackgroundColorPressed1
        {
            get
            {
                return colUserControl.BackgroundColorPressed1;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressed1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed2.
        /// </summary>
        /// <value>The background color pressed2.</value>
        public Color BackgroundColorPressed2
        {
            get
            {
                return colUserControl.BackgroundColorPressed2;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressed2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed contour1.
        /// </summary>
        /// <value>The background color pressed contour1.</value>
        public Color BackgroundColorPressedContour1
        {
            get
            {
                return colUserControl.BackgroundColorPressedContour1;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed contour2.
        /// </summary>
        /// <value>The background color pressed contour2.</value>
        public Color BackgroundColorPressedContour2
        {
            get
            {
                return colUserControl.BackgroundColorPressedContour2;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover color1.
        /// </summary>
        /// <value>The back hover color1.</value>
        public Color BackHoverColor1
        {
            get
            {
                return colUserControl.BackHoverColor1;
            }
            set
            {
                GetPropertyByName("BackHoverColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover color2.
        /// </summary>
        /// <value>The back hover color2.</value>
        public Color BackHoverColor2
        {
            get
            {
                return colUserControl.BackHoverColor2;
            }
            set
            {
                GetPropertyByName("BackHoverColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the hover contour1.
        /// </summary>
        /// <value>The hover contour1.</value>
        public Color HoverContour1
        {
            get
            {
                return colUserControl.HoverContour1;
            }
            set
            {
                GetPropertyByName("HoverContour1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the hover contour2.
        /// </summary>
        /// <value>The hover contour2.</value>
        public Color HoverContour2
        {
            get
            {
                return colUserControl.HoverContour2;
            }
            set
            {
                GetPropertyByName("HoverContour2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background contour1.
        /// </summary>
        /// <value>The background contour1.</value>
        public Color BackgroundContour1
        {
            get
            {
                return colUserControl.BackgroundContour1;
            }
            set
            {
                GetPropertyByName("BackgroundContour1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background contour2.
        /// </summary>
        /// <value>The background contour2.</value>
        public Color BackgroundContour2
        {
            get
            {
                return colUserControl.BackgroundContour2;
            }
            set
            {
                GetPropertyByName("BackgroundContour2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public Int32 Radius
        {
            get
            {
                return colUserControl.Radius;
            }
            set
            {
                GetPropertyByName("Radius").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius upper left.
        /// </summary>
        /// <value>The radius upper left.</value>
        public Int32 RadiusUpperLeft
        {
            get
            {
                return colUserControl.RadiusUpperLeft;
            }
            set
            {
                GetPropertyByName("RadiusUpperLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius upper right.
        /// </summary>
        /// <value>The radius upper right.</value>
        public Int32 RadiusUpperRight
        {
            get
            {
                return colUserControl.RadiusUpperRight;
            }
            set
            {
                GetPropertyByName("RadiusUpperRight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius bottom left.
        /// </summary>
        /// <value>The radius bottom left.</value>
        public Int32 RadiusBottomLeft
        {
            get
            {
                return colUserControl.RadiusBottomLeft;
            }
            set
            {
                GetPropertyByName("RadiusBottomLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius bottom right.
        /// </summary>
        /// <value>The radius bottom right.</value>
        public Int32 RadiusBottomRight
        {
            get
            {
                return colUserControl.RadiusBottomRight;
            }
            set
            {
                GetPropertyByName("RadiusBottomRight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        public Double Angle
        {
            get
            {
                return colUserControl.Angle;
            }
            set
            {
                GetPropertyByName("Angle").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Sets the foreground color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Set the image of the control."));

            items.Add(new DesignerActionPropertyItem("TextAlignment",
                                 "Text Alignment", "Appearance",
                                 "Sets the text alignment of the control."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the image alignment."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor1",
                                 "Background Color1", "Appearance",
                                 "Sets the inactive background color."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor2",
                                 "Background Color2", "Appearance",
                                 "Sets the inactive background color."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed1",
                                 "Background ColorPressed1", "Appearance",
                                 "Sets the background color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed2",
                                 "Background Color Pressed2", "Appearance",
                                 "Sets the background color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour1",
                                 "Background Color Pressed Contour1", "Appearance",
                                 "Sets the border color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour2",
                                 "Background Color Pressed Contour2", "Appearance",
                                 "Sets the border color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor1",
                                 "Back Hover Color1", "Appearance",
                                 "Sets the background color when hovered."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor2",
                                 "Back Hover Color2", "Appearance",
                                 "Sets the background color when hovered."));

            items.Add(new DesignerActionPropertyItem("HoverContour1",
                                 "Hover Contour1", "Appearance",
                                 "Sets the border color when hovered."));

            items.Add(new DesignerActionPropertyItem("HoverContour2",
                                 "Hover Contour2", "Appearance",
                                 "Sets the border color when hovered."));

            items.Add(new DesignerActionPropertyItem("BackgroundContour1",
                                 "Background Contour1", "Appearance",
                                 "Sets the inactive border color."));

            items.Add(new DesignerActionPropertyItem("BackgroundContour2",
                                 "Background Contour2", "Appearance",
                                 "Sets the inactive border color."));

            items.Add(new DesignerActionPropertyItem("Radius",
                                 "Radius", "Appearance",
                                 "Sets the corner curve for all sides."));

            items.Add(new DesignerActionPropertyItem("RadiusUpperLeft",
                                 "Radius Upper Left", "Appearance",
                                 "Sets the upper-left corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusUpperRight",
                                 "Radius Upper Right", "Appearance",
                                 "Sets the upper-right corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomLeft",
                                 "Radius Bottom Left", "Appearance",
                                 "Sets the bottom-left corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomRight",
                                 "Radius Bottom Right", "Appearance",
                                 "Sets the bottom-right corner curve."));

            items.Add(new DesignerActionPropertyItem("Angle",
                                 "Angle", "Appearance",
                                 "Sets the color angle."));



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
