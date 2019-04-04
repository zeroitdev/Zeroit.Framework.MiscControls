// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AdobeEyeDropper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Adobe EyeDropper

    #region Control    
    /// <summary>
    /// A class collection for rendering an eye control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitEyeDropper : Control
    {
        #region Events
        /// <summary>
        /// Occurs when [selected color changed].
        /// </summary>
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Occurs when [begin screen capture].
        /// </summary>
        public event EventHandler BeginScreenCapture;
        /// <summary>
        /// Called when [begin screen capture].
        /// </summary>
        protected void OnBeginScreenCapture()
        {
            if (BeginScreenCapture != null)
                BeginScreenCapture(this, null);
        }

        /// <summary>
        /// Delegate ScreenCapturedArgs
        /// </summary>
        /// <param name="capturedPixels">The captured pixels.</param>
        /// <param name="capturedColor">Color of the captured.</param>
        public delegate void ScreenCapturedArgs(Bitmap capturedPixels, Color capturedColor);
        /// <summary>
        /// Occurs when [screen captured].
        /// </summary>
        public event ScreenCapturedArgs ScreenCaptured;
        /// <summary>
        /// Called when [screen captured].
        /// </summary>
        protected void OnScreenCaptured()
        {
            if (ScreenCaptured != null)
                ScreenCaptured(bmpScreenCapture, _SelectedColor);
        }

        /// <summary>
        /// Occurs when [end screen capture].
        /// </summary>
        public event EventHandler EndScreenCapture;
        /// <summary>
        /// Called when [end screen capture].
        /// </summary>
        protected void OnEndScreenCapture()
        {
            if (EndScreenCapture != null)
                EndScreenCapture(this, null);
        }

        #endregion

        #region Private Fields
        /// <summary>
        /// The BMP screen capture
        /// </summary>
        Bitmap bmpScreenCapture;
        /// <summary>
        /// The current dropper
        /// </summary>
        private Cursor curDropper;
        /// <summary>
        /// The BMP dropper
        /// </summary>
        private Bitmap bmpDropper;
        /// <summary>
        /// The pixel zoom
        /// </summary>
        private PixelZoom pixelZoom;
        /// <summary>
        /// The preview position style
        /// </summary>
        private PreviewPosition _PreviewPositionStyle;
        /// <summary>
        /// The zoom
        /// </summary>
        private float _Zoom = 4;

        /// <summary>
        /// The iscapturing
        /// </summary>
        bool iscapturing = false;
        /// <summary>
        /// The trap screen
        /// </summary>
        bool trapScreen = true;
        #endregion

        #region Public Properties

        /// <summary>
        /// Enum representing the preview position for <c><see cref="ZeroitEyeDropper" /></c>
        /// </summary>
        public enum PreviewPosition
        {
            /// <summary>
            /// The manual
            /// </summary>
            Manual = 0,
            /// <summary>
            /// The centered
            /// </summary>
            Centered = 1,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 2,
            /// <summary>
            /// The top center
            /// </summary>
            TopCenter = 3,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 4,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 5,
            /// <summary>
            /// The bottom center
            /// </summary>
            BottomCenter = 6,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 7
        }

        /// <summary>
        /// Gets or sets a value indicating whether to trap screen.
        /// </summary>
        /// <value><c>true</c> if trap screen; otherwise, <c>false</c>.</value>
        public bool TrapScreen
        {
            get { return trapScreen; }
            set
            {
                trapScreen = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pixel preview zoom.
        /// </summary>
        /// <value>The pixel preview zoom.</value>
        [DefaultValue((float)4)]
        public float PixelPreviewZoom
        {
            get { return _Zoom; }
            set
            {
                _Zoom = value;
                RecalcSnapshotSize();
            }
        }

        /// <summary>
        /// The selected color
        /// </summary>
        Color _SelectedColor;

        /// <summary>
        /// Gets or sets the selected color.
        /// </summary>
        /// <value>The selected color.</value>
        public Color SelectedColor
        {
            get { return _SelectedColor; }
            set
            {
                if (_SelectedColor == value)
                    return;
            }
        }

        /// <summary>
        /// The pixel preview size
        /// </summary>
        private Size _PixelPreviewSize = new Size(100, 50);

        /// <summary>
        /// Gets or sets the size of the pixel preview.
        /// </summary>
        /// <value>The size of the pixel preview.</value>
        public Size PixelPreviewSize
        {
            get { return _PixelPreviewSize; }
            set
            {
                _PixelPreviewSize = value;
                RecalcSnapshotSize();
            }
        }

        /// <summary>
        /// The show pixel preview
        /// </summary>
        private bool _ShowPixelPreview = true;
        /// <summary>
        /// Gets or sets a value indicating if the the pop up
        /// preview will show the captured pixel(s).
        /// </summary>
        /// <value><c>true</c> if [show pixel preview]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ShowPixelPreview
        {
            get { return _ShowPixelPreview; }
            set { _ShowPixelPreview = value; }
        }

        /// <summary>
        /// The show color preview
        /// </summary>
        private bool _ShowColorPreview = true;
        /// <summary>
        /// Gets or sets a value indicating if the the pop up
        /// preview will show the captured color.
        /// </summary>
        /// <value><c>true</c> if [show color preview]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ShowColorPreview
        {
            get { return _ShowColorPreview; }
            set { _ShowColorPreview = value; }
        }

        /// <summary>
        /// The preview location
        /// </summary>
        private Point _PreviewLocation;
        /// <summary>
        /// Gets ot sets the upper-left coordinates of the pop up
        /// preview's location relative to the eyedropper control.
        /// Note: This value is ignored if the PreviewPositionStyle is not set to: Manual
        /// </summary>
        /// <value>The preview location.</value>
        public Point PreviewLocation
        {
            get { return _PreviewLocation; }
            set { _PreviewLocation = value; }
        }


        /// <summary>
        /// Gets or sets the popup style.
        /// </summary>
        /// <value>The preview position style.</value>
        public PreviewPosition PreviewPositionStyle
        {
            get { return _PreviewPositionStyle; }
            set { _PreviewPositionStyle = value; }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitEyeDropper" /> class.
        /// </summary>
        public ZeroitEyeDropper()
        {
            this.Size = new Size(22, 22);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            bmpDropper = new Bitmap(Properties.Resources.eyedropper);
            bmpDropper.MakeTransparent(Color.White);

            curDropper = /*Cursors.Arrow;*/ CursorHandler.LoadCursor(Properties.Resources.EYE_DROPPER);
            RecalcSnapshotSize();
        }


        #endregion

        #region Overrides
        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The maximum size.</value>
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
        }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The minimum size.</value>
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Cursor = curDropper;
                Cursor.Position = this.Parent.PointToScreen(new Point(this.Left + 2, this.Bottom - 4));
                iscapturing = true;
                OnBeginScreenCapture();
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!iscapturing)
                e.Graphics.DrawImage(bmpDropper, (this.Width - bmpDropper.Width) / 2, (this.Height - bmpDropper.Height) / 2);
            Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(SystemPens.ControlDark, r);
            e.Graphics.DrawLine(SystemPens.ControlLightLight, 0, r.Bottom, r.Right, r.Bottom);
            e.Graphics.DrawLine(SystemPens.ControlLightLight, r.Right, 0, r.Right, r.Bottom);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iscapturing)
                captureScreen();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            {
                Cursor = Cursors.Arrow;
                iscapturing = false;
                if (pixelZoom != null)
                {
                    pixelZoom.Close();
                    pixelZoom.Dispose();
                    pixelZoom = null;
                }
                this.Invalidate();
                this.OnEndScreenCapture();
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Captures the screen.
        /// </summary>
        private void captureScreen()
        {
            Point p = Control.MousePosition;
            p.X -= bmpScreenCapture.Width / 2;
            p.Y -= bmpScreenCapture.Height / 2;

            using (System.Drawing.Graphics dc = System.Drawing.Graphics.FromImage(bmpScreenCapture))
            {
                dc.CopyFromScreen(p, new Point(0, 0), bmpScreenCapture.Size);

                Color c = bmpScreenCapture.GetPixel(
                    (int)(bmpScreenCapture.Size.Width / 2.0F),
                    (int)(bmpScreenCapture.Size.Height / 2.0F));
                if (c != _SelectedColor)
                {
                    _SelectedColor = c;
                    if (SelectedColorChanged != null)
                        SelectedColorChanged(this, null);
                }

                if (_ShowPixelPreview || _ShowColorPreview)
                {
                    if (pixelZoom == null)
                        pixelZoom = new PixelZoom(this);
                    pixelZoom.PaintScreenCapture(bmpScreenCapture);
                }
                OnScreenCaptured();
            }
        }

        /// <summary>
        /// Recalcs the size of the snapshot.
        /// </summary>
        void RecalcSnapshotSize()
        {
            if (bmpScreenCapture != null)
                bmpScreenCapture.Dispose();
            Size r = _PixelPreviewSize;
            int w = (int)(Math.Floor(r.Width / PixelPreviewZoom));
            int h = (int)(Math.Floor(r.Height / PixelPreviewZoom));
            bmpScreenCapture = new Bitmap(w, h);
        }


        #endregion

        #region Form

        /// <summary>
        /// Class PixelZoom.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Form" />
        internal class PixelZoom : System.Windows.Forms.Form
        {
            /// <summary>
            /// The parent
            /// </summary>
            private ZeroitEyeDropper parent;

            /// <summary>
            /// The rect color
            /// </summary>
            Rectangle rectColor;
            /// <summary>
            /// The rect screen
            /// </summary>
            Rectangle rectScreen;
            /// <summary>
            /// The shadow
            /// </summary>
            byte shadow = 6;
            /// <summary>
            /// Initializes a new instance of the <see cref="PixelZoom"/> class.
            /// </summary>
            /// <param name="parent">The parent.</param>
            public PixelZoom(ZeroitEyeDropper parent)
            {
                this.parent = parent;
                this.ShowInTaskbar = false;
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.Manual;
                //We intentionally set the bounds after showing the form.
                //This bypasses a bug in the Form class when setting the 
                //bounds internally before calling the Show() method. 
                this.Show();
                setBounds();

                //Paint the bounds as a rounded rectangle...
                System.Drawing.Graphics g = this.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath gpArea = this.BuildRoundedRectangle(new Rectangle(shadow, shadow, this.Width - shadow, this.Height - shadow), 20);
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(150, Color.Black)))
                { g.FillPath(sb, gpArea); }
                g.TranslateTransform(-shadow, -shadow);
                g.FillPath(Brushes.WhiteSmoke, gpArea);
                g.DrawPath(Pens.Black, gpArea);
                g.Dispose();
                gpArea.Dispose();
            }

            /// <summary>
            /// Sets the bounds.
            /// </summary>
            private void setBounds()
            {
                Size parentHalf = new Size(parent.Width / 2, parent.Height / 2);
                Point pntScreen = parent.Parent.PointToScreen(parent.Location);
                Rectangle rBounds;

                if (parent.ShowColorPreview && parent.ShowPixelPreview)
                    rBounds = new Rectangle(0, 0, parent.PixelPreviewSize.Width + 20 + shadow, parent.PixelPreviewSize.Height * 2 + 25 + shadow);
                else
                    rBounds = new Rectangle(0, 0, parent.PixelPreviewSize.Width + 20 + shadow, parent.PixelPreviewSize.Height + 20 + shadow);

                switch (parent.PreviewPositionStyle)
                {
                    case PreviewPosition.Manual:
                        rBounds.Location = new Point(pntScreen.X + parent.PreviewLocation.X, pntScreen.Y + parent.PreviewLocation.Y);
                        break;
                    case PreviewPosition.TopLeft:
                        rBounds.Location = pntScreen;
                        break;
                    case PreviewPosition.TopCenter:
                        rBounds.Location = new Point(
                            pntScreen.X - ((parent.PixelPreviewSize.Width + 20 - parent.Size.Width) / 2),
                            pntScreen.Y);
                        break;
                    case PreviewPosition.TopRight:
                        rBounds.Location = new Point(
                            pntScreen.X + parent.Width,
                            pntScreen.Y);
                        break;
                    case PreviewPosition.BottomLeft:
                        rBounds.Location = new Point(
                            pntScreen.X,
                            pntScreen.Y + parent.Height);
                        break;
                    case PreviewPosition.BottomCenter:
                        rBounds.Location = new Point(
                            pntScreen.X - ((parent.PixelPreviewSize.Width + 20 - parent.Size.Width) / 2),
                            pntScreen.Y + parent.Height);
                        break;
                    case PreviewPosition.BottomRight:
                        rBounds.Location = new Point(
                            pntScreen.X + parent.Width,
                            pntScreen.Y + parent.Height);
                        break;
                    case PreviewPosition.Centered:
                        rBounds.Location = new Point(
                        pntScreen.X - ((parent.PixelPreviewSize.Width + 20 - parent.Size.Width) / 2),
                        pntScreen.Y - (((parent.PixelPreviewSize.Height * 2) + 25 - parent.Size.Height) / 2));
                        break;
                }
                this.Bounds = rBounds;
                if (parent.ShowColorPreview && parent.ShowPixelPreview)
                {
                    rectColor = new Rectangle(10, 10, parent.PixelPreviewSize.Width, parent.PixelPreviewSize.Height);
                    rectScreen = new Rectangle(10, parent.PixelPreviewSize.Height + 15, parent.PixelPreviewSize.Width, parent.PixelPreviewSize.Height);
                }
                else
                {
                    if (parent.ShowColorPreview)
                        rectColor = new Rectangle(10, 10, parent.PixelPreviewSize.Width, parent.PixelPreviewSize.Height);
                    else
                        rectScreen = new Rectangle(10, 10, parent.PixelPreviewSize.Width, parent.PixelPreviewSize.Height);
                }
            }

            /// <summary>
            /// Handles the <see cref="E:Paint" /> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
            protected override void OnPaint(PaintEventArgs e)
            {
                //base.OnPaint(e);
                //No painting is done here or in the OnPaintBackground
                //method so the screen real estate will remain the same.
                //We will create a device context ourselves to do the painting.
            }

            /// <summary>
            /// Paints the background of the control.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                //base.OnPaintBackground(e);
            }

            /// <summary>
            /// Paints the screen capture.
            /// </summary>
            /// <param name="screenCapture">The screen capture.</param>
            public void PaintScreenCapture(System.Drawing.Bitmap screenCapture)
            {
                //create a device context to the form
                System.Drawing.Graphics g = this.CreateGraphics();

                if (parent.ShowColorPreview)
                {
                    //paints the selected pixel color from the screen
                    using (SolidBrush sb = new SolidBrush(parent.SelectedColor))
                    {
                        g.FillRectangle(sb, rectColor);
                        g.DrawRectangle(Pens.Black, rectColor);
                    }
                }

                if (parent.ShowPixelPreview && screenCapture != null)
                {
                    //paints the selected pixels from the screen
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.DrawImage(screenCapture, rectScreen);
                    Color color = parent.SelectedColor;
                    bool useBlack = (color.R + color.G + color.B > 128 * 3 ? true : false);
                    g.DrawRectangle(useBlack ? Pens.Black : Pens.White, new Rectangle(
                        rectScreen.X + (rectScreen.Width / 2) - 2,
                        rectScreen.Y + (rectScreen.Height / 2) - 2, 4, 4));
                    g.DrawRectangle(Pens.Black, rectScreen);
                }
                //dispose the device context
                g.Dispose();
            }

            /// <summary>
            /// Builds the rounded rectangle.
            /// </summary>
            /// <param name="bounds">The bounds.</param>
            /// <param name="roundness">The roundness.</param>
            /// <returns>GraphicsPath.</returns>
            /// <exception cref="System.ArgumentException">Roundess value must be greater than -1!</exception>
            internal GraphicsPath BuildRoundedRectangle(Rectangle bounds, byte roundness)
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                if (roundness < 0)
                    throw new ArgumentException("Roundess value must be greater than -1!");
                if (roundness == 0)
                {
                    gp.AddRectangle(bounds);
                }
                else
                {
                    gp.AddArc(bounds.Right - roundness, bounds.Top, roundness, roundness, 270, 90);
                    gp.AddArc(bounds.Right - roundness, bounds.Bottom - roundness, roundness, roundness, 0, 90);
                    gp.AddArc(bounds.Left, bounds.Bottom - roundness, roundness, roundness, 90, 90);
                    gp.AddArc(bounds.Left, bounds.Top, roundness, roundness, 180, 90);
                    gp.CloseAllFigures();
                }

                return gp;
            }
        }


        #endregion
    }

    #endregion

    #region Cursor Handler

    /// <summary>
    /// Class CursorHandler.
    /// </summary>
    public class CursorHandler
    {
        /// <summary>
        /// Loads the cursor from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);


        /// <summary>
        /// Loads the cursor.
        /// </summary>
        /// <param name="resourcePath">The resource path.</param>
        /// <returns>Cursor.</returns>
        public static Cursor LoadCursor(string resourcePath)
        {
            Cursor c = new Cursor(getCursorHandle(resourcePath));
            return c;
        }


        /// <summary>
        /// Gets the cursor handle.
        /// </summary>
        /// <param name="resourcePath">The resource path.</param>
        /// <returns>IntPtr.</returns>
        private static IntPtr getCursorHandle(string resourcePath)
        {
            //Load cursor from Manifest Resource to Stream 
            Stream streamFrom =
            Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
            Stream streamTo =
            File.Create(Environment.GetEnvironmentVariable("TEMP") + @"\~cur.tmp");
            BinaryReader br = new BinaryReader(streamFrom);
            BinaryWriter bw = new BinaryWriter(streamTo);
            //Write cursor to temporary file 
            bw.Write(br.ReadBytes((int)streamFrom.Length));
            bw.Flush();
            bw.Close();
            br.Close();
            bw = null;
            br = null;
            streamFrom.Close();
            streamTo.Close();
            streamFrom = null;
            streamTo = null;
            //Load handle of temporary cursor file 
            IntPtr hwdCursor = LoadCursorFromFile(
            Environment.GetEnvironmentVariable("TEMP") + @"\~cur.tmp");
            //Delete temporary cursor file 
            File.Delete(Environment.GetEnvironmentVariable("TEMP") + @"\~cur.tmp");
            return hwdCursor;
        }
    }

    #endregion

    #endregion
}
