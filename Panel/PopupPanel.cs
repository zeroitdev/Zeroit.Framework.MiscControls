// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PopupPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Popup Panel

    #region CBPopupHelpForm

    /// <summary>
    /// A class collection for rendering popup.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class PopupHelpForm : System.Windows.Forms.Form
    {
        #region Win32 API
        //Obtained from www.PInvoke.net

        /// <summary>
        /// Shows the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nCmdShow">The n command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// The sw noactivate
        /// </summary>
        private const int SW_NOACTIVATE = 4;

        #region UpdateLayeredWindow
        /// <summary>
        /// Updates the layered window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hdcDst">The HDC DST.</param>
        /// <param name="pptDst">The PPT DST.</param>
        /// <param name="psize">The psize.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="pptSrc">The PPT source.</param>
        /// <param name="crKey">The cr key.</param>
        /// <param name="pblend">The pblend.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
           ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey,
           [In] ref BLENDFUNCTION pblend, uint dwFlags);

        /// <summary>
        /// Struct BLENDFUNCTION
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct BLENDFUNCTION
        {
            /// <summary>
            /// The blend op
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// The blend flags
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// The source constant alpha
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// The alpha format
            /// </summary>
            public byte AlphaFormat;

            /// <summary>
            /// Initializes a new instance of the <see cref="BLENDFUNCTION"/> struct.
            /// </summary>
            /// <param name="op">The op.</param>
            /// <param name="flags">The flags.</param>
            /// <param name="alpha">The alpha.</param>
            /// <param name="format">The format.</param>
            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }

        /// <summary>
        /// The ac source over
        /// </summary>
        private const int AC_SRC_OVER = 0;
        /// <summary>
        /// The ac source alpha
        /// </summary>
        private const int AC_SRC_ALPHA = 1;
        /// <summary>
        /// The ulw alpha
        /// </summary>
        private const int ULW_ALPHA = 2;
        #endregion

        #region GDI
        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hDC">The h dc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hgdiobj">The hgdiobj.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);
        #endregion
        #endregion

        #region Constants
        /// <summary>
        /// The ws ex layered
        /// </summary>
        private const int WS_EX_LAYERED = 0x80000;
        /// <summary>
        /// The line height
        /// </summary>
        private const int LINE_HEIGHT = 2;
        /// <summary>
        /// The border thickness
        /// </summary>
        private const int BORDER_THICKNESS = 1;
        /// <summary>
        /// The total border thickness
        /// </summary>
        private const int TOTAL_BORDER_THICKNESS = BORDER_THICKNESS + BORDER_THICKNESS;
        /// <summary>
        /// The golden ratio
        /// </summary>
        private const float GOLDEN_RATIO = 1.61803399f;
        #endregion

        #region Variables
        /// <summary>
        /// The control
        /// </summary>
        private ZeroitPopupHelp ctrl;
        /// <summary>
        /// The title size
        /// </summary>
        private Size titleSize;
        /// <summary>
        /// The message size
        /// </summary>
        private Size messageSize;
        /// <summary>
        /// The f1 help size
        /// </summary>
        private Size f1HelpSize;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PopupHelpForm"/> class.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        public PopupHelpForm(ZeroitPopupHelp ctrl)
        {
            this.ctrl = ctrl;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;

            #region Popup Size
            Size = CalculateSize();
            #endregion

            #region Popup Location
            Point screenPosition = ctrl.PointToScreen(new Point(ctrl.RightPopupMargin + ctrl.Width + ctrl.RightPopupMargin, -ctrl.TitlePadding.Top));
            if (screenPosition.X + Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                //if the popup will not display entirely on the screen move it to the left of the control
                int x = ctrl.PointToScreen(new Point(0, 0)).X - ctrl.LeftPopupMargin - Size.Width;
                if (x >= 0)//if the left coordinate is left of the screen (negative) display what you can on the right
                    screenPosition.X = x;
            }
            Location = screenPosition;
            #endregion

            #region Draw Bitmap
            using (Bitmap bmp = new Bitmap(Size.Width, Size.Height))
            {
                DrawBitmap(bmp);
                SelectBitmap(bmp);
            }
            #endregion

            ShowWindow(Handle, SW_NOACTIVATE);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED;
                return cp;
            }
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Calculates the size.
        /// </summary>
        /// <returns>Size.</returns>
        private Size CalculateSize()
        {
            int maximumPopupWidth = ctrl.UseGoldenRatio ?
                Math.Min(ctrl.MaximumPopupWidth, GetGoldenRatioWidth()) :
                ctrl.MaximumPopupWidth;

            int maxTitleWidth = maximumPopupWidth - ctrl.TitlePadding.Left - ctrl.TitlePadding.Right;
            int maxMessageWidth = maximumPopupWidth - ctrl.MessagePadding.Left - ctrl.MessagePadding.Right;
            int maxF1HelpWidth = maximumPopupWidth - ctrl.F1HelpPadding.Left - Properties.Resources.help.Width - (Properties.Resources.help.Width / 4) - ctrl.F1HelpPadding.Right;

            Size retVal = new Size();
            using (Graphics g = CreateGraphics())
            {
                titleSize = MeasureString(g, ctrl.TitleText, ctrl.TitleFont, maxTitleWidth);
                messageSize = MeasureString(g, ctrl.MessageText, ctrl.MessageFont, maxMessageWidth);
                f1HelpSize = MeasureString(g, ctrl.F1HelpText, ctrl.F1HelpFont, maxF1HelpWidth);
                int titleWidth = ctrl.TitlePadding.Left + titleSize.Width + ctrl.TitlePadding.Right;
                int messageWidth = ctrl.MessagePadding.Left + messageSize.Width + ctrl.MessagePadding.Right;
                int f1HelpWidth = ctrl.F1HelpPadding.Left + Properties.Resources.help.Width + (Properties.Resources.help.Width / 4) + f1HelpSize.Width + ctrl.F1HelpPadding.Right;
                int width = Math.Max(titleWidth, messageWidth);
                width = Math.Max(width, f1HelpWidth);
                retVal.Width = Math.Min(maximumPopupWidth, width);

                int titleHeight = !string.IsNullOrEmpty(ctrl.TitleText) ?
                    ctrl.TitlePadding.Top + titleSize.Height + ctrl.TitlePadding.Bottom + LINE_HEIGHT :
                    0;

                retVal.Height = titleHeight +
                    ctrl.MessagePadding.Top + messageSize.Height + ctrl.MessagePadding.Bottom +
                    LINE_HEIGHT +
                    ctrl.F1HelpPadding.Top + f1HelpSize.Height + ctrl.F1HelpPadding.Bottom;
            }

            retVal.Width += TOTAL_BORDER_THICKNESS + ctrl.ShadowDepth;
            retVal.Height += TOTAL_BORDER_THICKNESS + ctrl.ShadowDepth;

            return retVal;
        }

        /// <summary>
        /// Creates the round rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateRoundRect(Rectangle rect, int radius)
        {
            GraphicsPath gp = new GraphicsPath();

            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            if (width > 0 && height > 0)
            {
                radius = Math.Min(radius, height / 2 - 1);
                radius = Math.Min(radius, width / 2 - 1);

                gp.AddLine(x + radius, y, x + width - (radius * 2), y);
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
                gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                gp.AddLine(x, y + height - (radius * 2), x, y + radius);
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
                gp.CloseFigure();
            }
            return gp;
        }

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBackground(Graphics g)
        {
            Rectangle messageRect = new Rectangle(
                0,
                0,
                Width - ctrl.ShadowDepth - BORDER_THICKNESS,
                Height - ctrl.ShadowDepth - BORDER_THICKNESS);
            if (messageRect.Width > 0 && messageRect.Height > 0)
            {
                using (GraphicsPath messagePath = CreateRoundRect(messageRect, 4))
                {
                    using (Brush messageBackgroundBrush = new LinearGradientBrush(
                        messageRect, ctrl.LightBackgroundColor, ctrl.DarkBackgroundColor, LinearGradientMode.Vertical))
                    {
                        g.FillPath(messageBackgroundBrush, messagePath);
                        using (Pen messageBoarderPen = new Pen(ctrl.BorderColor))
                            g.DrawPath(messageBoarderPen, messagePath);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the bitmap.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        private void DrawBitmap(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                DrawShadow(g);
                DrawBackground(g);
                DrawContent(g);
            }
        }

        /// <summary>
        /// Draws the content.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawContent(Graphics g)
        {
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Pen darkPen = null;
            Pen lightPen = null;
            try
            {
                darkPen = new Pen(ctrl.DarkLineColor);
                lightPen = new Pen(ctrl.LightLineColor);
                int y = 0;
                int x = BORDER_THICKNESS + ctrl.TitlePadding.Left;
                int x2 = Width - ctrl.TitlePadding.Right - ctrl.ShadowDepth - TOTAL_BORDER_THICKNESS;

                #region Title and Line
                if (!string.IsNullOrEmpty(ctrl.TitleText))
                {
                    #region Title
                    Rectangle titleRect = new Rectangle(
                        BORDER_THICKNESS + ctrl.TitlePadding.Left,
                        BORDER_THICKNESS + ctrl.TitlePadding.Top,
                        titleSize.Width,
                        titleSize.Height);
                    using (Brush titleBrush = new SolidBrush(ctrl.TitleForeColor))
                        g.DrawString(ctrl.TitleText, ctrl.TitleFont, titleBrush, titleRect);
                    y = titleRect.Bottom + ctrl.TitlePadding.Bottom;
                    #endregion

                    #region Line
                    g.DrawLine(darkPen, x, y, x2, y);
                    y++;
                    g.DrawLine(lightPen, x, y, x2, y);
                    y++;
                    #endregion
                }
                #endregion

                #region Message
                Rectangle messageRect = new Rectangle(
                    BORDER_THICKNESS + ctrl.MessagePadding.Left,
                    y + ctrl.MessagePadding.Top,
                    messageSize.Width,
                    messageSize.Height);
                using (Brush messageBrush = new SolidBrush(ctrl.MessageForeColor))
                    g.DrawString(ctrl.MessageText, ctrl.MessageFont, messageBrush, messageRect);
                y = messageRect.Bottom + ctrl.MessagePadding.Bottom;
                #endregion

                #region Line
                g.DrawLine(darkPen, x, y, x2, y);
                y++;
                g.DrawLine(lightPen, x, y, x2, y);
                y++;
                #endregion

                #region Press F1
                g.DrawImage(Properties.Resources.Help_16px, new Point(BORDER_THICKNESS + ctrl.F1HelpPadding.Left, y + ctrl.F1HelpPadding.Top));

                Rectangle f1HelpRect = new Rectangle(
                    BORDER_THICKNESS + ctrl.F1HelpPadding.Left + Properties.Resources.help.Width + (Properties.Resources.help.Width / 4),
                    y + ctrl.F1HelpPadding.Top,
                    f1HelpSize.Width,
                    f1HelpSize.Height);
                using (Brush f1HelpBrush = new SolidBrush(ctrl.F1HelpForeColor))
                    g.DrawString(ctrl.F1HelpText, ctrl.F1HelpFont, f1HelpBrush, f1HelpRect);
                #endregion
            }
            finally
            {
                if (darkPen != null)
                    darkPen.Dispose();

                if (lightPen != null)
                    lightPen.Dispose();
            }
        }

        /// <summary>
        /// Draws the shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawShadow(Graphics g)
        {
            if (ctrl.ShadowDepth > 0)
            {
                Rectangle shadowRect = new Rectangle(
                    ctrl.ShadowDepth,
                    ctrl.ShadowDepth,
                    Width - ctrl.ShadowDepth,
                    Height - ctrl.ShadowDepth);

                if (shadowRect.Width > 0 && shadowRect.Height > 0)
                {
                    using (GraphicsPath shadowPath = CreateRoundRect(shadowRect, 4))
                    {
                        using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                        {
                            Color[] colors = new Color[4];
                            float[] positions = new float[4];
                            ColorBlend sBlend = new ColorBlend();
                            colors[0] = Color.FromArgb(0, 0, 0, 0);
                            colors[1] = Color.FromArgb(32, 0, 0, 0);
                            colors[2] = Color.FromArgb(64, 0, 0, 0);
                            colors[3] = Color.FromArgb(128, 0, 0, 0);
                            positions[0] = 0.0f;
                            positions[1] = 0.015f;
                            positions[2] = 0.030f;
                            positions[3] = 1.0f;
                            sBlend.Colors = colors;
                            sBlend.Positions = positions;

                            shadowBrush.InterpolationColors = sBlend;
                            shadowBrush.CenterPoint = new Point(
                                shadowRect.Left + (shadowRect.Width / 2),
                                shadowRect.Top + (shadowRect.Height / 2));

                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the width of the golden ratio.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetGoldenRatioWidth()
        {
            using (Graphics g = CreateGraphics())
            {
                int goldenWidth = 0;
                float volumn = 0;
                for (int i = 0; i < ctrl.GoldenRatioSampleRate; i++)
                {
                    titleSize = MeasureString(g, ctrl.TitleText, ctrl.TitleFont, goldenWidth);
                    messageSize = MeasureString(g, ctrl.MessageText, ctrl.MessageFont, goldenWidth);
                    f1HelpSize = MeasureString(g, ctrl.F1HelpText, ctrl.F1HelpFont, goldenWidth);
                    int titleWidth = ctrl.TitlePadding.Left + titleSize.Width + ctrl.TitlePadding.Right;
                    int messageWidth = ctrl.MessagePadding.Left + messageSize.Width + ctrl.MessagePadding.Right;
                    int f1HelpWidth = ctrl.F1HelpPadding.Left + Properties.Resources.help.Width + (Properties.Resources.help.Width / 4) + f1HelpSize.Width + ctrl.F1HelpPadding.Right;
                    int width = Math.Max(titleWidth, messageWidth);
                    width = Math.Max(width, f1HelpWidth);

                    int titleHeight = !string.IsNullOrEmpty(ctrl.TitleText) ?
                        ctrl.TitlePadding.Top + titleSize.Height + ctrl.TitlePadding.Bottom + LINE_HEIGHT :
                        0;

                    int height =
                        titleHeight +
                        ctrl.MessagePadding.Top + messageSize.Height + ctrl.MessagePadding.Bottom + LINE_HEIGHT +
                        ctrl.F1HelpPadding.Top + f1HelpSize.Height + ctrl.F1HelpPadding.Bottom;

                    float sampleVolumn = height * width;
                    if (sampleVolumn == volumn)
                        break;
                    volumn = sampleVolumn;
                    double x = Math.Sqrt(volumn * GOLDEN_RATIO);
                    double y = volumn / x;
                    goldenWidth = 1 + (int)x;
                }
                return goldenWidth;
            }
        }

        /// <summary>
        /// Measures the string.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="val">The value.</param>
        /// <param name="font">The font.</param>
        /// <returns>Size.</returns>
        private Size MeasureString(Graphics g, string val, Font font)
        {
            SizeF sizeF = g.MeasureString(val, font);
            return new Size((int)sizeF.Width + 1, (int)sizeF.Height + 1);
        }

        /// <summary>
        /// Measures the string.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="val">The value.</param>
        /// <param name="font">The font.</param>
        /// <param name="maxWidth">The maximum width.</param>
        /// <returns>Size.</returns>
        private Size MeasureString(Graphics g, string val, Font font, int maxWidth)
        {
            if (maxWidth <= 0)
                return MeasureString(g, val, font);

            SizeF sizeF = g.MeasureString(val, font, maxWidth);
            return new Size(
                (int)sizeF.Width < maxWidth ? (int)sizeF.Width + 1 : maxWidth,
                (int)sizeF.Height + 1);
        }

        /// <summary>
        /// Selects the bitmap.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        private void SelectBitmap(Bitmap bmp)
        {
            IntPtr hDC = GetDC(IntPtr.Zero);
            try
            {
                IntPtr hMemDC = CreateCompatibleDC(hDC);
                try
                {
                    IntPtr hBmp = bmp.GetHbitmap(Color.FromArgb(0));
                    try
                    {
                        IntPtr previousBmp = SelectObject(hMemDC, hBmp);
                        try
                        {
                            Point ptDst = new Point(Left, Top);
                            Size size = new Size(bmp.Width, bmp.Height);
                            Point ptSrc = new Point(0, 0);

                            BLENDFUNCTION blend = new BLENDFUNCTION();
                            blend.BlendOp = AC_SRC_OVER;
                            blend.BlendFlags = 0;
                            blend.SourceConstantAlpha = 255;
                            blend.AlphaFormat = AC_SRC_ALPHA;

                            UpdateLayeredWindow(
                                Handle,
                                hDC,
                                ref ptDst,
                                ref size,
                                hMemDC,
                                ref ptSrc,
                                0,
                                ref blend,
                                ULW_ALPHA);
                        }
                        finally
                        {
                            SelectObject(hDC, previousBmp);
                        }
                    }
                    finally
                    {
                        DeleteObject(hBmp);
                    }
                }
                finally
                {
                    DeleteDC(hMemDC);
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hDC);
            }
        }
        #endregion
    }

    #endregion

    #region ZeroitPopupHelp

    #region Control

    /// <summary>
    /// A class collection for rendering a popup.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitPopupHelpDesigner))]
    public partial class ZeroitPopupHelp : UserControl
    {
        #region Constants
        /// <summary>
        /// The default golden ratio sample rate
        /// </summary>
        private const int DEFAULT_GOLDEN_RATIO_SAMPLE_RATE = 3;
        /// <summary>
        /// The default left popup margin
        /// </summary>
        private const int DEFAULT_LEFT_POPUP_MARGIN = 1;
        /// <summary>
        /// The default maximum popup width
        /// </summary>
        private const int DEFAULT_MAX_POPUP_WIDTH = 500;
        /// <summary>
        /// The default right popup margin
        /// </summary>
        private const int DEFAULT_RIGHT_POPUP_MARGIN = 4;
        /// <summary>
        /// The default shadow depth
        /// </summary>
        private const int DEFAULT_SHADOW_DEPTH = 5;
        /// <summary>
        /// The minimum maximum popup width
        /// </summary>
        private const int MIN_MAX_POPUP_WIDTH = 100;
        /// <summary>
        /// The maximum golden ratio sample rate
        /// </summary>
        private const int MAX_GOLDEN_RATIO_SAMPLE_RATE = 10;
        /// <summary>
        /// The category
        /// </summary>
        private const string CATEGORY = "Appearance";
        /// <summary>
        /// The default f1 help
        /// </summary>
        private const string DEFAULT_F1HELP = "Press F1 for more help";
        /// <summary>
        /// The default message
        /// </summary>
        private const string DEFAULT_MESSAGE = "Provides a simple icon users can easily identify as a help provider. Once a user moves their mouse over the icon, a visually pleasing popup window displays context sensitive help that remains visible until they choose to close the view.";
        /// <summary>
        /// The default title
        /// </summary>
        private const string DEFAULT_TITLE = "Corner Bowl Popup Help";
        #endregion

        #region Variables

        /// <summary>
        /// The form
        /// </summary>
        private PopupHelpForm form;

        #region Text
        /// <summary>
        /// The f1 help text
        /// </summary>
        private string f1HelpText = DEFAULT_F1HELP;
        /// <summary>
        /// The message text
        /// </summary>
        private string messageText = DEFAULT_MESSAGE;
        /// <summary>
        /// The title text
        /// </summary>
        private string titleText = DEFAULT_TITLE;
        #endregion

        #region Fonts
        /// <summary>
        /// The f1 help font
        /// </summary>
        private Font f1HelpFont = new Font("Segoe UI", 8.25f, FontStyle.Bold);
        /// <summary>
        /// The message font
        /// </summary>
        private Font messageFont = new Font("Segoe UI", 8.25f);
        /// <summary>
        /// The title font
        /// </summary>
        private Font titleFont = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        #endregion

        #region Maximum Width and Shadow
        /// <summary>
        /// The use golden ratio
        /// </summary>
        private bool useGoldenRatio = true;
        /// <summary>
        /// The golden ratio sample rate
        /// </summary>
        private int goldenRatioSampleRate = DEFAULT_GOLDEN_RATIO_SAMPLE_RATE;
        /// <summary>
        /// The maximum popup width
        /// </summary>
        private int maximumPopupWidth = DEFAULT_MAX_POPUP_WIDTH;
        /// <summary>
        /// The shadow depth
        /// </summary>
        private int shadowDepth = DEFAULT_SHADOW_DEPTH;
        #endregion

        #region Popup Margins
        /// <summary>
        /// The left popup margin
        /// </summary>
        private int leftPopupMargin = DEFAULT_LEFT_POPUP_MARGIN;
        /// <summary>
        /// The right popup margin
        /// </summary>
        private int rightPopupMargin = DEFAULT_RIGHT_POPUP_MARGIN;
        #endregion

        #region Padding
        /// <summary>
        /// The f1 help padding
        /// </summary>
        private Padding f1HelpPadding = new Padding(6, 4, 6, 4);
        /// <summary>
        /// The message padding
        /// </summary>
        private Padding messagePadding = new Padding(12, 6, 12, 2);
        /// <summary>
        /// The title padding
        /// </summary>
        private Padding titlePadding = new Padding(6, 8, 6, 0);
        #endregion

        #region Fore Colors
        /// <summary>
        /// The f1 help fore color
        /// </summary>
        private Color f1HelpForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// The message fore color
        /// </summary>
        private Color messageForeColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// The title fore color
        /// </summary>
        private Color titleForeColor = Color.FromArgb(64, 64, 64);
        #endregion

        #region Background Colors
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(118, 118, 118);
        /// <summary>
        /// The dark background color
        /// </summary>
        private Color darkBackgroundColor = Color.FromArgb(201, 217, 239);
        /// <summary>
        /// The dark line color
        /// </summary>
        private Color darkLineColor = Color.FromArgb(158, 187, 221);
        /// <summary>
        /// The light background color
        /// </summary>
        private Color lightBackgroundColor = Color.White;
        /// <summary>
        /// The light line color
        /// </summary>
        private Color lightLineColor = Color.White;
        #endregion

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPopupHelp" /> class.
        /// </summary>
        public ZeroitPopupHelp()
        {
            InitializeComponent();

            TabIndex = 0;
            TabStop = false;
        }
        #endregion

        #region Properties

        #region Text        
        /// <summary>
        /// Gets or sets the F1 help text.
        /// </summary>
        /// <value>The F1 help text.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_F1HELP)]
        public string F1HelpText
        {
            set { f1HelpText = value; Invalidate(); }
            get { return f1HelpText; }
        }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>The message text.</value>
        [DefaultValue(DEFAULT_MESSAGE),
         Browsable(true)]
        public string MessageText
        {
            set { messageText = value; Invalidate(); }
            get { return messageText; }
        }

        /// <summary>
        /// Gets or sets the title text.
        /// </summary>
        /// <value>The title text.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_TITLE)]
        public string TitleText
        {
            set { titleText = value; Invalidate(); }
            get { return titleText; }
        }
        #endregion

        #region Fonts        
        /// <summary>
        /// Gets or sets the F1 help font.
        /// </summary>
        /// <value>The f1 help font.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Font), "Segoe UI, 8.25pt, style=Bold")]
        public Font F1HelpFont
        {
            get { return f1HelpFont; }
            set
            {
                if (f1HelpFont != null)
                    f1HelpFont.Dispose();
                f1HelpFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        /// <value>The message font.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Font), "Segoe UI, 8.25pt")]
        public Font MessageFont
        {
            get { return messageFont; }
            set
            {
                if (messageFont != null)
                    messageFont.Dispose();
                messageFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Font), "Segoe UI, 9.75pt, style=Bold")]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                if (titleFont != null)
                    titleFont.Dispose();
                titleFont = value;
                Invalidate();
            }
        }
        #endregion

        #region Maximum Width and Shadow        
        /// <summary>
        /// Gets or sets a value indicating whether to use golden ratio.
        /// </summary>
        /// <value><c>true</c> if use golden ratio; otherwise, <c>false</c>.</value>
        [Category(CATEGORY),
         DefaultValue(true)]
        public bool UseGoldenRatio
        {
            set { useGoldenRatio = value; Invalidate(); }
            get { return useGoldenRatio; }
        }

        /// <summary>
        /// Gets or sets the golden ratio sample rate.
        /// </summary>
        /// <value>The golden ratio sample rate.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_GOLDEN_RATIO_SAMPLE_RATE)]
        public int GoldenRatioSampleRate
        {
            set
            {
                if (value <= 0)
                    value = 1;
                if (value > MAX_GOLDEN_RATIO_SAMPLE_RATE)
                    value = MAX_GOLDEN_RATIO_SAMPLE_RATE;
                goldenRatioSampleRate = value;
                Invalidate();
            }
            get { return goldenRatioSampleRate; }
        }

        /// <summary>
        /// Gets or sets the maximum width of the popup.
        /// </summary>
        /// <value>The maximum width of the popup.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_MAX_POPUP_WIDTH)]
        public int MaximumPopupWidth
        {
            set
            {
                if (value < MIN_MAX_POPUP_WIDTH)
                    value = MIN_MAX_POPUP_WIDTH;
                maximumPopupWidth = value;
                Invalidate();
            }
            get { return maximumPopupWidth; }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_SHADOW_DEPTH)]
        public int ShadowDepth
        {
            set
            {
                if (value < 0)
                    value = 0;
                shadowDepth = value;
                Invalidate();
            }
            get { return shadowDepth; }
        }
        #endregion

        #region Popup Margins        
        /// <summary>
        /// Gets or sets the left popup margin.
        /// </summary>
        /// <value>The left popup margin.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_LEFT_POPUP_MARGIN)]
        public int LeftPopupMargin
        {
            set
            {
                if (value < 0)
                    value = 0;
                leftPopupMargin = value;
                Invalidate();
            }
            get { return leftPopupMargin; }
        }

        /// <summary>
        /// Gets or sets the right popup margin.
        /// </summary>
        /// <value>The right popup margin.</value>
        [Category(CATEGORY),
         DefaultValue(DEFAULT_RIGHT_POPUP_MARGIN)]
        public int RightPopupMargin
        {
            set
            {
                if (value < 0)
                    value = 0;
                rightPopupMargin = value;
                Invalidate();
            }
            get { return rightPopupMargin; }
        }
        #endregion

        #region Padding        
        /// <summary>
        /// Gets or sets the F1 help padding.
        /// </summary>
        /// <value>The F1 help padding.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Padding), "6, 4, 6, 4")]
        public Padding F1HelpPadding
        {
            set { f1HelpPadding = value; Invalidate(); }
            get { return f1HelpPadding; }
        }

        /// <summary>
        /// Gets or sets the message padding.
        /// </summary>
        /// <value>The message padding.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Padding), "12, 6, 12, 2")]
        public Padding MessagePadding
        {
            set { messagePadding = value; Invalidate(); }
            get { return messagePadding; }
        }

        /// <summary>
        /// Gets or sets the title padding.
        /// </summary>
        /// <value>The title padding.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Padding), "6, 8, 6, 0")]
        public Padding TitlePadding
        {
            set { titlePadding = value; Invalidate(); }
            get { return titlePadding; }
        }
        #endregion

        #region Fore Colors        
        /// <summary>
        /// Gets or sets the color of the F1 help fore.
        /// </summary>
        /// <value>The color of the F1 help fore.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "64, 64, 64")]
        public Color F1HelpForeColor
        {
            set { f1HelpForeColor = value; Invalidate(); }
            get { return f1HelpForeColor; }
        }

        /// <summary>
        /// Gets or sets the color of the message fore.
        /// </summary>
        /// <value>The color of the message fore.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "64, 64, 64")]
        public Color MessageForeColor
        {
            set { messageForeColor = value; Invalidate(); }
            get { return messageForeColor; }
        }

        /// <summary>
        /// Gets or sets the color of the title.
        /// </summary>
        /// <value>The color of the title.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "64, 64, 64")]
        public Color TitleForeColor
        {
            set { titleForeColor = value; Invalidate(); }
            get { return titleForeColor; }
        }
        #endregion

        #region Background Colors        
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "118, 118, 118")]
        public Color BorderColor
        {
            set { borderColor = value; Invalidate(); }
            get { return borderColor; }
        }

        /// <summary>
        /// Gets or sets the color of the dark background.
        /// </summary>
        /// <value>The color of the dark background.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "201, 217, 239")]
        public Color DarkBackgroundColor
        {
            set { darkBackgroundColor = value; Invalidate(); }
            get { return darkBackgroundColor; }
        }

        /// <summary>
        /// Gets or sets the color of the dark line.
        /// </summary>
        /// <value>The color of the dark line.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "158, 187, 221")]
        public Color DarkLineColor
        {
            set { darkLineColor = value; Invalidate(); }
            get { return darkLineColor; }
        }

        /// <summary>
        /// Gets or sets the color of the light background.
        /// </summary>
        /// <value>The color of the light background.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "255, 255, 255")]
        public Color LightBackgroundColor
        {
            set { lightBackgroundColor = value; Invalidate(); }
            get { return lightBackgroundColor; }
        }

        /// <summary>
        /// Gets or sets the color of the light line.
        /// </summary>
        /// <value>The color of the light line.</value>
        [Category(CATEGORY),
         DefaultValue(typeof(Color), "255, 255, 255")]
        public Color LightLineColor
        {
            set { lightLineColor = value; Invalidate(); }
            get { return lightLineColor; }
        }
        #endregion

        #endregion

        #region Base Class Properties        
        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [DefaultValue(typeof(ImageLayout), "None"),
         Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        /// <summary>
        /// Gets or sets the border style of the user control.
        /// </summary>
        /// <value>The border style.</value>
        [Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The maximum size.</value>
        [DefaultValue(typeof(Size), "16, 16"),
         Browsable(false)]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The minimum size.</value>
        [DefaultValue(typeof(Size), "16, 16"),
         Browsable(false)]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        [Browsable(false)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        /// <summary>
        /// Gets or sets the tab order of the control within its container.
        /// </summary>
        /// <value>The index of the tab.</value>
        [DefaultValue(0),
         Browsable(false)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <value><c>true</c> if tab stop; otherwise, <c>false</c>.</value>
        [DefaultValue(false),
         Browsable(false)]
        public new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = false; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Shows the popup.
        /// </summary>
        public void ShowPopup()
        {
            if (form == null)
                form = new PopupHelpForm(this);
        }

        /// <summary>
        /// Hides the popup.
        /// </summary>
        public void HidePopup()
        {
            if (form != null)
            {
                form.Close();
                form.Dispose();
                form = null;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the EnabledChanged event of the CBPopupHelpCtrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CBPopupHelpCtrl_EnabledChanged(object sender, EventArgs e)
        {
            BackgroundImage = Enabled ?
                    Properties.Resources.Help_16px :
                    Properties.Resources.Help_16px_1;
        }

        /// <summary>
        /// Handles the MouseEnter event of the PopupHelpCtrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PopupHelpCtrl_MouseEnter(object sender, System.EventArgs e)
        {
            ShowPopup();
        }

        /// <summary>
        /// Handles the MouseLeave event of the PopupHelpCtrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PopupHelpCtrl_MouseLeave(object sender, System.EventArgs e)
        {
            HidePopup();
        }
        #endregion
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitPopupHelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ZeroitPopupHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Properties.Resources.Help_16px;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MaximumSize = new System.Drawing.Size(16, 16);
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Name = "ZeroitPopupHelp";
            this.Size = new System.Drawing.Size(16, 16);
            this.MouseLeave += new System.EventHandler(this.PopupHelpCtrl_MouseLeave);
            this.EnabledChanged += new System.EventHandler(this.CBPopupHelpCtrl_EnabledChanged);
            this.MouseEnter += new System.EventHandler(this.PopupHelpCtrl_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPopupHelpDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPopupHelpDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPopupHelpSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPopupHelpSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPopupHelpSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPopupHelp colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPopupHelpSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPopupHelpSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPopupHelp;

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


        #region Properties

        #region Text
        /// <summary>
        /// Gets or sets the f1 help text.
        /// </summary>
        /// <value>The f1 help text.</value>
        public string F1HelpText
        {
            get
            {
                return colUserControl.F1HelpText;
            }
            set
            {
                GetPropertyByName("F1HelpText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>The message text.</value>
        public string MessageText
        {
            get
            {
                return colUserControl.MessageText;
            }
            set
            {
                GetPropertyByName("MessageText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the title text.
        /// </summary>
        /// <value>The title text.</value>
        public string TitleText
        {
            get
            {
                return colUserControl.TitleText;
            }
            set
            {
                GetPropertyByName("TitleText").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Fonts
        /// <summary>
        /// Gets or sets the f1 help font.
        /// </summary>
        /// <value>The f1 help font.</value>
        public Font F1HelpFont
        {
            get
            {
                return colUserControl.F1HelpFont;
            }
            set
            {
                GetPropertyByName("F1HelpFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        /// <value>The message font.</value>
        public Font MessageFont
        {
            get
            {
                return colUserControl.MessageFont;
            }
            set
            {
                GetPropertyByName("MessageFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        public Font TitleFont
        {
            get
            {
                return colUserControl.TitleFont;
            }
            set
            {
                GetPropertyByName("TitleFont").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Maximum Width and Shadow
        /// <summary>
        /// Gets or sets a value indicating whether [use golden ratio].
        /// </summary>
        /// <value><c>true</c> if [use golden ratio]; otherwise, <c>false</c>.</value>
        public bool UseGoldenRatio
        {
            get
            {
                return colUserControl.UseGoldenRatio;
            }
            set
            {
                GetPropertyByName("UseGoldenRatio").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the golden ratio sample rate.
        /// </summary>
        /// <value>The golden ratio sample rate.</value>
        public int GoldenRatioSampleRate
        {
            get
            {
                return colUserControl.GoldenRatioSampleRate;
            }
            set
            {
                GetPropertyByName("GoldenRatioSampleRate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum width of the popup.
        /// </summary>
        /// <value>The maximum width of the popup.</value>
        public int MaximumPopupWidth
        {
            get
            {
                return colUserControl.MaximumPopupWidth;
            }
            set
            {
                GetPropertyByName("MaximumPopupWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        public int ShadowDepth
        {
            get
            {
                return colUserControl.ShadowDepth;
            }
            set
            {
                GetPropertyByName("ShadowDepth").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Popup Margins
        /// <summary>
        /// Gets or sets the left popup margin.
        /// </summary>
        /// <value>The left popup margin.</value>
        public int LeftPopupMargin
        {
            get
            {
                return colUserControl.LeftPopupMargin;
            }
            set
            {
                GetPropertyByName("LeftPopupMargin").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the right popup margin.
        /// </summary>
        /// <value>The right popup margin.</value>
        public int RightPopupMargin
        {
            get
            {
                return colUserControl.RightPopupMargin;
            }
            set
            {
                GetPropertyByName("RightPopupMargin").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Padding
        /// <summary>
        /// Gets or sets the f1 help padding.
        /// </summary>
        /// <value>The f1 help padding.</value>
        public Padding F1HelpPadding
        {
            get
            {
                return colUserControl.F1HelpPadding;
            }
            set
            {
                GetPropertyByName("F1HelpPadding").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the message padding.
        /// </summary>
        /// <value>The message padding.</value>
        public Padding MessagePadding
        {
            get
            {
                return colUserControl.MessagePadding;
            }
            set
            {
                GetPropertyByName("MessagePadding").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the title padding.
        /// </summary>
        /// <value>The title padding.</value>
        public Padding TitlePadding
        {
            get
            {
                return colUserControl.TitlePadding;
            }
            set
            {
                GetPropertyByName("TitlePadding").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Fore Colors
        /// <summary>
        /// Gets or sets the color of the f1 help fore.
        /// </summary>
        /// <value>The color of the f1 help fore.</value>
        public Color F1HelpForeColor
        {
            get
            {
                return colUserControl.F1HelpForeColor;
            }
            set
            {
                GetPropertyByName("F1HelpForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the message fore.
        /// </summary>
        /// <value>The color of the message fore.</value>
        public Color MessageForeColor
        {
            get
            {
                return colUserControl.MessageForeColor;
            }
            set
            {
                GetPropertyByName("MessageForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the title fore.
        /// </summary>
        /// <value>The color of the title fore.</value>
        public Color TitleForeColor
        {
            get
            {
                return colUserControl.TitleForeColor;
            }
            set
            {
                GetPropertyByName("TitleForeColor").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Background Colors
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the dark background.
        /// </summary>
        /// <value>The color of the dark background.</value>
        public Color DarkBackgroundColor
        {
            get
            {
                return colUserControl.DarkBackgroundColor;
            }
            set
            {
                GetPropertyByName("DarkBackgroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the dark line.
        /// </summary>
        /// <value>The color of the dark line.</value>
        public Color DarkLineColor
        {
            get
            {
                return colUserControl.DarkLineColor;
            }
            set
            {
                GetPropertyByName("DarkLineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the light background.
        /// </summary>
        /// <value>The color of the light background.</value>
        public Color LightBackgroundColor
        {
            get
            {
                return colUserControl.LightBackgroundColor;
            }
            set
            {
                GetPropertyByName("LightBackgroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the light line.
        /// </summary>
        /// <value>The color of the light line.</value>
        public Color LightLineColor
        {
            get
            {
                return colUserControl.LightLineColor;
            }
            set
            {
                GetPropertyByName("LightLineColor").SetValue(colUserControl, value);
            }
        }
        #endregion

        #endregion


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

            items.Add(new DesignerActionPropertyItem("UseGoldenRatio",
                                 "Use Golden Ratio", "Appearance",
                                 "Enable golden ration."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("F1HelpForeColor",
                                 "F1 Help ForeColor", "Appearance",
                                 "Sets the F1 Forecolor."));

            items.Add(new DesignerActionPropertyItem("MessageForeColor",
                                 "Message ForeColor", "Appearance",
                                 "Sets the message forecolor."));

            items.Add(new DesignerActionPropertyItem("TitleForeColor",
                                 "Title ForeColor", "Appearance",
                                 "Sets the title forecolor."));


            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border forecolor."));

            items.Add(new DesignerActionPropertyItem("DarkBackgroundColor",
                                 "Dark Background Color", "Appearance",
                                 "Sets the dark background color."));

            items.Add(new DesignerActionPropertyItem("DarkLineColor",
                                 "Dark Line Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("LightBackgroundColor",
                                 "Light Background Color", "Appearance",
                                 "Sets the the light background color."));

            items.Add(new DesignerActionPropertyItem("LightLineColor",
                                 "Light Line Color", "Appearance",
                                 "Sets the light line color."));

            items.Add(new DesignerActionHeaderItem("Text"));

            items.Add(new DesignerActionPropertyItem("F1HelpText",
                                 "F1 Help Text", "Text",
                                 "Sets the F1 help text."));

            items.Add(new DesignerActionPropertyItem("MessageText",
                                 "Message Text", "Text",
                                 "Sets the message text."));

            items.Add(new DesignerActionPropertyItem("TitleText",
                                 "Title Text", "Appearance",
                                 "Sets the title text."));

            items.Add(new DesignerActionPropertyItem("F1HelpFont",
                                 "F1 Help Font", "Text",
                                 "Sets the F1 help font."));

            items.Add(new DesignerActionPropertyItem("MessageFont",
                                 "Message Font", "Text",
                                 "Sets the message font."));

            items.Add(new DesignerActionPropertyItem("TitleFont",
                                 "Title Font", "Text",
                                 "Sets the title font."));


            items.Add(new DesignerActionPropertyItem("GoldenRatioSampleRate",
                                 "Golden Ratio Sample Rate", "Appearance",
                                 "Sets the golden ratio sample rate."));

            items.Add(new DesignerActionPropertyItem("MaximumPopupWidth",
                                 "Maximum Popup Width", "Appearance",
                                 "Sets the maximum popup width."));

            items.Add(new DesignerActionPropertyItem("ShadowDepth",
                                 "Shadow Depth", "Appearance",
                                 "Sets the shadow depth."));


            items.Add(new DesignerActionPropertyItem("LeftPopupMargin",
                                 "Left Popup Margin", "Appearance",
                                 "Sets the left popup margin."));

            items.Add(new DesignerActionPropertyItem("RightPopupMargin",
                                 "Right Popup Margin", "Appearance",
                                 "Sets the right popup margin."));

            items.Add(new DesignerActionPropertyItem("F1HelpPadding",
                                 "F1 Help Padding", "Appearance",
                                 "Sets F1 help padding."));

            items.Add(new DesignerActionPropertyItem("MessagePadding",
                                 "Message Padding", "Appearance",
                                 "Sets the message padding."));


            items.Add(new DesignerActionPropertyItem("TitlePadding",
                                 "Title Padding", "Appearance",
                                 "Sets the title padding."));

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

    #endregion
}
