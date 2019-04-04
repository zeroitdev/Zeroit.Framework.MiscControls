using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region MirrorButton    
    /// <summary>
    /// A class collection for rendering mirror button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("MouseClick")]
    [Designer(typeof(ZeroitButtonMirrorDesigner))]
    public partial class ZeroitButtonMirror : UserControl
    {
        #region Constants
        // adjust disabled image alpha level
        private const float FADE_LEVEL = .7F;
        // adjust mirror image alpha level
        private const float MIRROR_LEVEL = .15F;
        // glow color alpha
        private const int GLOW_LEVEL = 40;
        // alpha maximum before pixel is changed
        private const int GLOW_THRESHHOLD = 96;
        // glow padding
        private const int SIZE_OFFSET = 2;
        #endregion

        #region Enums
        private enum ButtonState : int
        {
            Normal = 0,
            Pressed,
            Focused,
            Hover,
            Disabled,
            Checked
        }

        /// <summary>
        /// Enum representing the Checked Style
        /// </summary>
        public enum CheckedStyle : int
        {
            None = 0,
            Border,
            ColorChange
        }

        #endregion

        #region Fields
        private bool _bCheckState = false;
        private bool _bFocusOnHover = false;
        private bool _bClicked = false;
        private bool _bFocusedMask = false;
        private bool _bImageMirror = false;
        private int _iGlowFactor = 2;

        private CheckedStyle _eUseCheckStyle = CheckedStyle.None;
        private ButtonState _eButtonState = ButtonState.Normal;

        private Color _clrCheckedBorderColor = Color.WhiteSmoke;
        private Color _clrImageCheckedColor = Color.SteelBlue;
        private Color _clrImageDisabledColor = Color.Transparent;
        private Color _clrImageFocusedColor = Color.SkyBlue;
        private Color _clrImageGlowColor = Color.WhiteSmoke;
        private Color _clrImageHoverColor = Color.LightSkyBlue;
        private Color _clrImageMirrorColor = Color.WhiteSmoke;
        private Color _clrImagePressedColor = Color.SteelBlue;

        private Image _imgImage;
        private Image _imgBackgroundImage;
        private Bitmap _bmpBuffer;
        private Bitmap _bmpGlow;
        private Bitmap _bmpMirror;
        #endregion

        #region Constructor
        public ZeroitButtonMirror()
        {
            InitializeComponent();

            Create();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }
        private void Create()
        {
            if (_bmpBuffer != null)
                _bmpBuffer.Dispose();
            _bmpBuffer = new Bitmap(this.Width, this.Height);
        }
        private void Destroy()
        {
            if (_bmpBuffer != null)
                _bmpBuffer.Dispose();
            if (_bmpGlow != null)
                _bmpGlow.Dispose();
            if (_bmpMirror != null)
                _bmpMirror.Dispose();
        }
        #endregion

        #region Properties
        #region Hidden Properties
        [Browsable(false)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; Invalidate(); }
        }
        [Browsable(false)]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; Invalidate(); }
        }

        [Browsable(false)]
        public new bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; Invalidate(); }
        }
        [Browsable(false)]
        public new Size AutoScrollMargin
        {
            get { return base.AutoScrollMargin; }
            set { base.AutoScrollMargin = value; Invalidate(); }
        }
        [Browsable(false)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; Invalidate(); }
        }
        [Browsable(false)]
        public new AutoSizeMode AutoSizeMode
        {
            get { return base.AutoSizeMode; }
            set { base.AutoSizeMode = value; Invalidate(); }
        }
        [Browsable(false)]
        public new AutoValidate AutoValidate
        {
            get { return base.AutoValidate; }
            set { base.AutoValidate = value; Invalidate(); }
        }
        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; Invalidate(); }
        }
        [Browsable(false)]
        public new ContextMenu ContextMenuStrip
        {
            get { return base.ContextMenu; }
            set { base.ContextMenu = value; Invalidate(); }
        }
        [Browsable(false)]
        public new DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; Invalidate(); }
        }
        [Browsable(false)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; Invalidate(); }
        }
        [Browsable(false)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; Invalidate(); }
        }
        [Browsable(false)]
        public new RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; Invalidate(); }
        }
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; Invalidate(); }
        }
        #endregion

        #region Public Properties
        /// <summary>Get/Set button Background image</summary>
        [Browsable(true), Category("Appearance"), RefreshProperties(RefreshProperties.All),
        Description("Get/Set button Background image")]
        public Image BackgroundImage
        {
            get { return _imgBackgroundImage; }
            set
            {
                _imgBackgroundImage = value;
                if (_imgBackgroundImage != null)
                    DrawButton();

                Invalidate();
            }
        }

        /// <summary>Get/Set Checkbox state</summary>
        [Browsable(true), Category("Behavior"),
        Description("Get/Set Checkbox state")]
        public bool Checked
        {
            get { return _bCheckState; }
            set
            {
                _bCheckState = value;
                if (!_bCheckState)
                    _eButtonState = ButtonState.Normal;
                DrawButton();

                Invalidate();
            }
        }

        /// <summary>Get/Set the checked border Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the checked border Color")]
        public Color CheckedBorderColor
        {
            get { return _clrCheckedBorderColor; }
            set { _clrCheckedBorderColor = value; Invalidate(); }
        }

        /// <summary>Get/Set Checkbox style</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set Checkbox style")]
        public CheckedStyle CheckStyle
        {
            get { return _eUseCheckStyle; }
            set { _eUseCheckStyle = value; Invalidate(); }
        }

        /// <summary>Get/Set Focus on button hover</summary>
        [Browsable(true), Category("Behavior"),
        Description("Get/Set Focus on button hover")]
        public bool FocusOnHover
        {
            get { return _bFocusOnHover; }
            set { _bFocusOnHover = value; Invalidate(); }
        }

        /// <summary>Get/Set Draw a Focused mask</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set Draw a Focused mask")]
        public bool FocusedMask
        {
            get { return _bFocusedMask; }
            set { _bFocusedMask = value; Invalidate(); }
        }

        /// <summary>Get/Set button image</summary>
        [Browsable(true), Category("Appearance"), RefreshProperties(RefreshProperties.All),
        Description("Get/Set button Image")]
        public Image Image
        {
            get { return _imgImage; }
            set
            {
                _imgImage = value;
                if (_imgImage != null)
                {
                    if (this.AutoSize && this.DesignMode)
                        ResetSize();
                    if (this.ImageMirror)
                        CreateMirror();
                    CreateGlow();
                    DrawButton();


                }

                Invalidate();

            }
        }

        /// <summary>Get/Set the image checked Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the image checked Color")]
        public Color ImageCheckedColor
        {
            get { return _clrImageCheckedColor; }
            set { _clrImageCheckedColor = value; Invalidate(); }
        }

        /// <summary>Get/Set the image disabled Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the image disabled Color")]
        public Color ImageDisabledColor
        {
            get { return _clrImageDisabledColor; }
            set { _clrImageDisabledColor = value; Invalidate(); }
        }

        /// <summary>Get/Set the image focused Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the image focused Color")]
        public Color ImageFocusedColor
        {
            get { return _clrImageFocusedColor; }
            set { _clrImageFocusedColor = value; Invalidate(); }
        }

        /// <summary>Get/Set the glow Color</summary>
        [Browsable(true), Category("Appearance"), RefreshProperties(RefreshProperties.All),
        Description("Get/Set the glow Color")]
        public Color ImageGlowColor
        {
            get { return _clrImageGlowColor; }
            set
            {
                _clrImageGlowColor = value;
                CreateGlow();

                Invalidate();
            }
        }

        /// <summary>Get/Set the hover Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the hover Color")]
        public Color ImageHoverColor
        {
            get { return _clrImageHoverColor; }
            set { _clrImageHoverColor = value; Invalidate(); }
        }

        /// <summary>Get/Set the pressed Color</summary>
        [Browsable(true), Category("Appearance"),
        Description("Get/Set the pressed Color")]
        public Color ImagePressedColor
        {
            get { return _clrImagePressedColor; }
            set { _clrImagePressedColor = value; Invalidate(); }
        }

        /// <summary>Get/Set Glow factor Depth</summary>
        [Browsable(true), Category("Appearance"), RefreshProperties(RefreshProperties.All),
        Description("Get/Set Glow factor Depth")]
        public int ImageGlowFactor
        {
            get { return _iGlowFactor; }
            set
            {
                _iGlowFactor = value;
                CreateGlow();

                Invalidate();
            }
        }

        /// <summary>Get/Set Image Mirror effect</summary>
        [Browsable(true), Category("Behavior"), RefreshProperties(RefreshProperties.All),
        Description("Get/Set Image Mirror effect")]
        public bool ImageMirror
        {
            get { return _bImageMirror; }
            set
            {
                _bImageMirror = value;
                if (_bImageMirror)
                    CreateMirror();
                if (this.Image != null && this.AutoSize && this.DesignMode)
                    ResetSize();
                DrawButton();

                Invalidate();
            }
        }

        #endregion
        #endregion

        #region Overrides
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled == false)
                _eButtonState = ButtonState.Disabled;
            else
                _eButtonState = ButtonState.Normal;
            DrawButton();
            base.OnEnabledChanged(e);


        }

        protected override void OnGotFocus(EventArgs e)
        {
            _eButtonState = ButtonState.Focused;
            if (_bClicked)
                _bClicked = false;
            else
                DrawButton();
            base.OnGotFocus(e);


        }

        protected override void OnHandleCreated(EventArgs e)
        {
            Create();
            base.OnHandleCreated(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            Destroy();
            base.OnHandleDestroyed(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _eButtonState = ButtonState.Normal;
            DrawButton();
            base.OnLostFocus(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && SystemInformation.MouseButtonsSwapped || e.Button == MouseButtons.Left)
                this.Checked = !this.Checked;
            DrawButton();
            base.OnMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && SystemInformation.MouseButtonsSwapped || e.Button == MouseButtons.Left)
            {
                _eButtonState = ButtonState.Pressed;
                DrawButton();
                _bClicked = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.FocusOnHover)
            {
                this.Focus();
                _eButtonState = ButtonState.Focused;
            }
            else
            {
                _eButtonState = ButtonState.Hover;
            }
            DrawButton();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Focused)
                _eButtonState = ButtonState.Focused;
            else
                _eButtonState = ButtonState.Normal;
            DrawButton();
            DrawButton();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _eButtonState = ButtonState.Focused;
            DrawButton();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButton();
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Create();
            base.OnResize(e);
        }
        #endregion

        #region Methods
        /// <summary>Create the Glow image</summary>
        private void CreateGlow()
        {
            if (_bmpGlow != null)
                _bmpGlow.Dispose();
            Rectangle imageRect = new Rectangle(0, 0, this.Image.Width + this.ImageGlowFactor, this.Image.Height + this.ImageGlowFactor);
            _bmpGlow = new Bitmap(imageRect.Width, imageRect.Height);
            using (Graphics g = Graphics.FromImage(_bmpGlow))
                g.DrawImage(this.Image, imageRect);
            int i = 0;
            for (int x = 0; x < imageRect.Height; x++)
            {
                for (i = 0; i < imageRect.Width; i++)
                {
                    if (_bmpGlow.GetPixel(i, x).A > GLOW_THRESHHOLD)
                        _bmpGlow.SetPixel(i, x, Color.FromArgb(GLOW_LEVEL, this.ImageGlowColor));
                }
                i = 0;
            }
        }

        /// <summary>Create the Mirror image</summary>
        private void CreateMirror()
        {
            if (_bmpMirror != null)
                _bmpMirror.Dispose();

            int height = (int)(this.Image.Height * .7f);
            int width = (int)(this.Image.Width * 1f);
            Rectangle imageRect = new Rectangle(0, 0, width, height);
            _bmpMirror = new Bitmap(imageRect.Width, imageRect.Height);

            using (Graphics g = Graphics.FromImage(_bmpMirror))
                g.DrawImage(this.Image, imageRect);
            _bmpMirror.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        /// <summary>Create a rounded rectangle GraphicsPath</summary>
        private GraphicsPath CreateRoundRectanglePath(Graphics g, Rectangle bounds, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            // arc top left
            pathBounds.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);
            // line top
            pathBounds.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - radius, bounds.Top);
            // arc top right
            pathBounds.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90);
            // line right
            pathBounds.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom - radius);
            // arc bottom right
            pathBounds.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            // line bottom
            pathBounds.AddLine(bounds.Right - radius, bounds.Bottom, bounds.Left + radius, bounds.Bottom);
            // arc bottom left
            pathBounds.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90);
            // line left
            pathBounds.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Top + radius);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>Backfill the buffer</summary>
        private void DrawBackGround(Graphics g, Rectangle bounds)
        {
            if (this.BackgroundImage != null)
            {
                using (ImageAttributes ia = new ImageAttributes())
                    g.DrawImage(this.BackgroundImage, bounds, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel, ia);
            }
            else
            {
                using (Brush br = new SolidBrush(this.BackColor))
                    g.FillRectangle(br, bounds);
            }
        }

        /// <summary>Draw border on checked style</summary>
        private void DrawBorder(Graphics g, Rectangle bounds, Color clr)
        {
            bounds.Inflate(-2, -2);
            using (GraphicsPath borderPath = CreateRoundRectanglePath(g, bounds, 4))
            {
                // top-left bottom-right -dark
                using (LinearGradientBrush borderBrush = new LinearGradientBrush(
                    bounds,
                    Color.FromArgb(140, clr),
                    Color.FromArgb(140, Color.White),
                    LinearGradientMode.BackwardDiagonal))
                {
                    Blend blnd = new Blend();
                    blnd.Positions = new float[] { 0f, .5f, 1f };
                    blnd.Factors = new float[] { 1f, 0f, 1f };
                    borderBrush.Blend = blnd;
                    using (Pen borderPen = new Pen(borderBrush, 2f))
                        g.DrawPath(borderPen, borderPath);
                }
            }
        }

        /// <summary>Drawing hub</summary>
        private void DrawButton()
        {
            if (this.Image == null)
                return;

            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle imageBounds = GetImageBounds(bounds, this.Image);

            // draw into a buffer
            using (Graphics g = Graphics.FromImage(_bmpBuffer))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                DrawBackGround(g, bounds);
                if (this.ImageMirror)
                    DrawMirror(g, imageBounds);

                if (this.CheckStyle != CheckedStyle.None && this.Checked == true)
                    _eButtonState = ButtonState.Checked;
                else if (this.CheckStyle != CheckedStyle.None && this.Checked == false && _eButtonState == ButtonState.Focused)
                    _eButtonState = ButtonState.Normal;
                switch (_eButtonState)
                {
                    case ButtonState.Checked:
                        {
                            if (this.CheckStyle == CheckedStyle.Border)
                            {
                                DrawBorder(g, bounds, this.CheckedBorderColor);
                                DrawColoredImage(g, this.Image, imageBounds, this.ImageFocusedColor);
                            }
                            else if (this.CheckStyle == CheckedStyle.ColorChange)
                            {
                                DrawColoredImage(g, this.Image, imageBounds, this.ImageCheckedColor);
                            }
                            else
                            {
                                DrawColoredImage(g, this.Image, imageBounds, this.ImageFocusedColor);
                            }
                            break;
                        }
                    case ButtonState.Disabled:
                        {
                            if (this.ImageDisabledColor == Color.Transparent)
                                DrawFadedImage(g, this.Image, imageBounds);
                            else
                                DrawColoredImage(g, this.Image, imageBounds, this.ImageDisabledColor);
                            break;
                        }
                    case ButtonState.Focused:
                        {
                            DrawColoredImage(g, this.Image, imageBounds, this.ImageFocusedColor);
                            if (this.FocusedMask)
                            {
                                DrawMask(g, bounds);
                                DrawBorder(g, bounds, Color.DarkGray);
                            }
                            break;
                        }
                    case ButtonState.Hover:
                        {
                            DrawGlow(g, this.Image, imageBounds);
                            DrawColoredImage(g, this.Image, imageBounds, this.ImageHoverColor);
                            break;
                        }
                    case ButtonState.Normal:
                        {
                            DrawImage(g, this.Image, imageBounds);
                            break;
                        }
                    case ButtonState.Pressed:
                        {
                            DrawColoredImage(g, this.Image, imageBounds, this.ImagePressedColor);
                            break;
                        }
                }
            }
            // draw the buffer
            using (Graphics g = Graphics.FromHwnd(this.Handle))
                DrawImage(g, _bmpBuffer, bounds);
        }

        /// <summary>Draw a colored bitmap</summary>
        private void DrawColoredImage(Graphics g, Image img, Rectangle bounds, Color clr)
        {
            using (ImageAttributes ia = new ImageAttributes())
            {
                ColorMatrix cm = new ColorMatrix();
                // convert and refactor color palette
                cm.Matrix00 = ParseColor(clr.R);
                cm.Matrix11 = ParseColor(clr.G);
                cm.Matrix22 = ParseColor(clr.B);
                cm.Matrix33 = ParseColor(clr.A);
                cm.Matrix44 = 1f;
                // set matrix
                ia.SetColorMatrix(cm);
                // draw
                g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>draw a faded bitmap</summary>
        private void DrawFadedImage(Graphics g, Image img, Rectangle bounds)
        {
            using (ImageAttributes ia = new ImageAttributes())
            {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = 1f;           //r
                cm.Matrix11 = 1f;           //g
                cm.Matrix22 = 1f;           //b
                cm.Matrix33 = FADE_LEVEL;   //a
                cm.Matrix44 = 1f;           //w

                ia.SetColorMatrix(cm);
                g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>Draw hover glow</summary>
        private void DrawGlow(Graphics g, Image img, Rectangle bounds)
        {
            bounds.Inflate(this.ImageGlowFactor, this.ImageGlowFactor);
            g.DrawImage(_bmpGlow, bounds);
        }

        /// <summary>Draw an unaltered image</summary>
        private void DrawImage(Graphics g, Image img, Rectangle bounds)
        {
            g.DrawImage(img, bounds);
        }

        /// <summary>Draw a gradient mask</summary>
        private void DrawMask(Graphics g, Rectangle bounds)
        {
            bounds.Inflate(-1, -1);
            // create an interior path
            using (GraphicsPath gp = CreateRoundRectanglePath(g, bounds, 4))
            {
                // fill the button with a subtle glow
                using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                    bounds,
                    Color.FromArgb(160, Color.White),
                    Color.FromArgb(5, Color.Silver),
                    75f))
                {
                    Blend blnd = new Blend();
                    blnd.Positions = new float[] { 0f, .1f, .2f, .3f, .4f, .5f, 1f };
                    blnd.Factors = new float[] { 0f, .1f, .2f, .4f, .7f, .8f, 1f };
                    fillBrush.Blend = blnd;
                    g.FillPath(fillBrush, gp);
                }
            }
        }

        /// <summary>Draw a mirror effect</summary>
        private void DrawMirror(Graphics g, Rectangle bounds)
        {
            // Rectangle imageRect = GetImageBounds(bounds, this.Image);
            bounds.Y = bounds.Bottom;
            bounds.Height = _bmpMirror.Height;
            bounds.Width = _bmpMirror.Width;
            using (ImageAttributes ia = new ImageAttributes())
            {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = 1f;           //r
                cm.Matrix11 = 1f;           //g
                cm.Matrix22 = 1f;           //b
                cm.Matrix33 = MIRROR_LEVEL; //a
                cm.Matrix44 = 1f;           //w

                ia.SetColorMatrix(cm);
                g.DrawImage(_bmpMirror, bounds, 0, 0, _bmpMirror.Width, _bmpMirror.Height, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>Get the image size and position</summary>
        private Rectangle GetImageBounds(Rectangle bounds, Image img)
        {
            int left = (int)((bounds.Width - img.Width) * .5f);
            int top = (int)((bounds.Height - img.Height) * .5f);
            if (this.ImageMirror)
                top = (int)((bounds.Height - (img.Height + (int)(img.Height * .7f))) * .5f);
            return new Rectangle(left, top, img.Width, img.Height);
        }

        /// <summary>Convert rgb to float</summary>
        private float ParseColor(byte clr)
        {
            return clr == 0 ? 0 : ((float)clr / 255);
        }

        private void ResetSize()
        {
            this.Width = this.Image.Width + this.ImageGlowFactor + SIZE_OFFSET;
            this.Height = this.Image.Height + this.ImageGlowFactor + SIZE_OFFSET;
            if (this.ImageMirror)
                this.Height += (int)(this.Image.Height * .7f);
        }
        #endregion
    }

    #region Designer Generated Code

    partial class ZeroitButtonMirror
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonMirrorDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitButtonMirrorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitButtonMirrorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitButtonMirror colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitButtonMirrorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitButtonMirror;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
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

        public bool ImageMirror
        {
            get
            {
                return colUserControl.ImageMirror;
            }
            set
            {
                GetPropertyByName("ImageMirror").SetValue(colUserControl, value);
            }
        }

        public int ImageGlowFactor
        {
            get
            {
                return colUserControl.ImageGlowFactor;
            }
            set
            {
                GetPropertyByName("ImageGlowFactor").SetValue(colUserControl, value);
            }
        }

        public Color ImageCheckedColor
        {
            get
            {
                return colUserControl.ImageCheckedColor;
            }
            set
            {
                GetPropertyByName("ImageCheckedColor").SetValue(colUserControl, value);
            }
        }

        public Color ImageDisabledColor
        {
            get
            {
                return colUserControl.ImageDisabledColor;
            }
            set
            {
                GetPropertyByName("ImageDisabledColor").SetValue(colUserControl, value);
            }
        }

        public Color ImageFocusedColor
        {
            get
            {
                return colUserControl.ImageFocusedColor;
            }
            set
            {
                GetPropertyByName("ImageFocusedColor").SetValue(colUserControl, value);
            }
        }

        public Color ImageGlowColor
        {
            get
            {
                return colUserControl.ImageGlowColor;
            }
            set
            {
                GetPropertyByName("ImageGlowColor").SetValue(colUserControl, value);
            }
        }

        public Color ImageHoverColor
        {
            get
            {
                return colUserControl.ImageHoverColor;
            }
            set
            {
                GetPropertyByName("ImageHoverColor").SetValue(colUserControl, value);
            }
        }

        public Color ImagePressedColor
        {
            get
            {
                return colUserControl.ImagePressedColor;
            }
            set
            {
                GetPropertyByName("ImagePressedColor").SetValue(colUserControl, value);
            }
        }

        public bool FocusOnHover
        {
            get
            {
                return colUserControl.FocusOnHover;
            }
            set
            {
                GetPropertyByName("FocusOnHover").SetValue(colUserControl, value);
            }
        }

        public bool FocusedMask
        {
            get
            {
                return colUserControl.FocusedMask;
            }
            set
            {
                GetPropertyByName("FocusedMask").SetValue(colUserControl, value);
            }
        }


        //public bool Checked
        //{
        //    get
        //    {
        //        return colUserControl.Checked;
        //    }
        //    set
        //    {
        //        GetPropertyByName("Checked").SetValue(colUserControl, value);
        //    }
        //}


        //public Color CheckedBorderColor
        //{
        //    get
        //    {
        //        return colUserControl.CheckedBorderColor;
        //    }
        //    set
        //    {
        //        GetPropertyByName("CheckedBorderColor").SetValue(colUserControl, value);
        //    }
        //}


        //public Zeroit.Framework.MiscControls.ZeroitButtonMirror.CheckedStyle CheckStyle
        //{
        //    get
        //    {
        //        return colUserControl.CheckStyle;
        //    }
        //    set
        //    {
        //        GetPropertyByName("CheckStyle").SetValue(colUserControl, value);
        //    }
        //}

        //public Image BackgroundImage
        //{
        //    get
        //    {
        //        return colUserControl.BackgroundImage;
        //    }
        //    set
        //    {
        //        GetPropertyByName("BackgroundImage").SetValue(colUserControl, value);
        //    }
        //}


        #endregion

        #region DesignerActionItemCollection

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the image of the control."));

            items.Add(new DesignerActionPropertyItem("ImageMirror",
                                 "Image Mirror", "Appearance",
                                 "Enable the image to mirror itself."));

            items.Add(new DesignerActionPropertyItem("ImageGlowFactor",
                                 "Image Glow Factor", "Appearance",
                                 "Sets the image glow factor of the control."));

            items.Add(new DesignerActionPropertyItem("ImageCheckedColor",
                                 "Image Checked Color", "Appearance",
                                 "Sets the image checked color."));

            items.Add(new DesignerActionPropertyItem("ImageDisabledColor",
                                 "Image Disabled Color", "Appearance",
                                 "Sets the image disabled color."));

            items.Add(new DesignerActionPropertyItem("ImageFocusedColor",
                                 "Image Focused Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ImageGlowColor",
                                 "Image Glow Color", "Appearance",
                                 "Sets the image color when it is focused."));

            items.Add(new DesignerActionPropertyItem("ImageHoverColor",
                                 "Image Hover Color", "Appearance",
                                 "Sets the image color when hovered."));

            items.Add(new DesignerActionPropertyItem("ImagePressedColor",
                                 "Image Pressed Color", "Appearance",
                                 "Sets the image color when pressed."));

            items.Add(new DesignerActionPropertyItem("FocusOnHover",
                                 "Focus On Hover", "Appearance",
                                 "Sets the hover color."));

            items.Add(new DesignerActionPropertyItem("FocusedMask",
                                 "Focused Mask", "Appearance",
                                 "Sets the focused mask of the control."));

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
