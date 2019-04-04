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

    #region Button Aqua    
    /// <summary>
    /// A class collection for rendering acqua gradient button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("Aqua Button Control")]
    [Designer(typeof(ZeroitButtonAcquaGradientDesigner))]
    public class ZeroitButtonAcquaGradient : Control
    {
        #region Class Constants

        private static int ButtonDefaultWidth = 80;

        // Set this to the height of your source bitmaps
        private static int ButtonHeight = 30;

        // If your source bitmaps have shadows, set this 
        // to the shadow size so DrawText can position the 
        // label appears centered on the label
        private static int ButtonShadowOffset = 5;

        // These settings approximate the pulse effect
        // of buttons on Mac OS X
        private static int PulseInterval = 70;
        private static float PulseGammaMax = 1.8f;
        private static float PulseGammaMin = 0.7f;
        private static float PulseGammaShift = 0.2f;
        private static float PulseGammaReductionThreshold = 0.2f;
        private static float PulseGammaShiftReduction = 0.5f;

        #endregion


        #region Member Variables

        // Appearance
        protected bool pulse = false;
        protected bool sizeToLabel = true;

        // Pulsing
        private System.Windows.Forms.Timer timer;
        private float gamma, gammaShift;

        // Mouse tracking
        protected Point ptMousePosition;
        private bool mousePressed;

        //
        // Summary:
        //     Gets or sets a value indicating whether the button control is the default button.
        //
        // Returns:
        //     true if the button control is the default button; otherwise, false.
        public bool IsDefault { get; set; }


        // Images used to draw the button
        private Image imgLeft, imgFill, imgRight;

        // Rectangles to position images on the button face
        private Rectangle rcLeft, rcRight;

        // Matrices for transparency transformation
        private ImageAttributes iaDefault, iaNormal;
        private ColorMatrix cmDefault, cmNormal;

        #endregion


        #region Constructors and Initializers

        public ZeroitButtonAcquaGradient()
        {
            InitializeComponent();


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.StandardClick, true);

            BackColor = Color.Transparent;

            pulse = true;



        }

        private void InitializeComponent()
        {
        }

        #endregion


        #region Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitButtonAcquaGradient"/> pulses. Note that only the default button can pulse.
        /// </summary>
        /// <value><c>true</c> if pulse; otherwise, <c>false</c>.</value>
        [Description("Determines whether the button pulses. Note that only the default button can pulse.")]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button should automatically size to fit the label.
        /// </summary>
        /// <value><c>true</c> if size to label; otherwise, <c>false</c>.</value>
        [Description("Determines whether the button should automatically size to fit the label")]
        [Category("Layout")]
        [DefaultValue(true)]
        public bool SizeToLabel
        {
            get { return sizeToLabel; }
            set
            {
                sizeToLabel = value;
                OnTextChanged(EventArgs.Empty);
            }
        }

        #endregion


        #region Property overrides

        /* AquaButton has a fixed height */
        protected override Size DefaultSize
        {
            get
            {
                return new Size(ZeroitButtonAcquaGradient.ButtonDefaultWidth,
                    ZeroitButtonAcquaGradient.ButtonHeight);
            }
        }


        /* Shadow Control.Width to make it browsable */
        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width.</value>
        [Description("See also: SizeToLabel")]
        [Category("Layout")]
        [Browsable(true)]
        public new int Width
        {
            get { return base.Width; }
            set { base.Width = value; }
        }

        /* Shadow Control.Height to make it browsable and read only */
        /// <summary>
        /// Gets or sets the height of the control. Aqua buttons have a fixed height.
        /// </summary>
        /// <value>The height.</value>
        [Description("Aqua buttons have a fixed height")]
        [Category("Layout")]
        [Browsable(true)]
        [ReadOnly(true)]
        public new int Height { get { return base.Height; } }

        #endregion


        #region Method overrides

        protected override void OnCreateControl()
        {
            LoadImages();
            InitializeGraphics();
        }


        protected override void OnTextChanged(EventArgs e)
        {
            if (sizeToLabel)
            {
                Graphics g = this.CreateGraphics();
                SizeF sizeF = g.MeasureString(Text, Font);
                Width = imgLeft.Width + (int)sizeF.Width + imgRight.Width;
                g.Dispose();
            }
            Invalidate();
            Update();
            base.OnTextChanged(e);
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 27;

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Pulse = false;
            IsDefault = false;


        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsDefault = true;
            pulse = true;


        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.Clear(Parent.BackColor);

            Draw(g);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (pulse == true)
                StartPulsing();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (pulse == false)
                StopPulsing();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                mousePressed = true;

                ptMousePosition.X = e.X;
                ptMousePosition.Y = e.Y;

                StopPulsing();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Buttons receives MouseMove events when the
            // mouse enters or leaves the client area.

            base.OnMouseMove(e);

            if (mousePressed && (e.Button & MouseButtons.Left) != 0)
            {
                ptMousePosition.X = e.X;
                ptMousePosition.Y = e.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (mousePressed)
            {
                mousePressed = false;

                StartPulsing();

                Invalidate();
                Update();
            }
        }

        public void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (mousePressed && e.KeyChar == '\x001B')  // Escape
            {
                mousePressed = false;

                StartPulsing();

                Invalidate();
                Update();
            }
        }

        #endregion


        #region Implementation

        public void LoadImages()
        {
            //imgLeft = new Bitmap(GetType(), "Button.left.png");
            //imgRight = new Bitmap(GetType(), "Button.right.png");
            //imgFill = new Bitmap(GetType(), "Button.fill.png");

            imgLeft = new Bitmap(Properties.Resources.left);
            imgRight = new Bitmap(Properties.Resources.right);
            imgFill = new Bitmap(Properties.Resources.fill);
        }

        public void InitializeGraphics()
        {
            // Rectangles for placing images relative to the client rectangle
            rcLeft = new Rectangle(1, 0, imgLeft.Width, imgLeft.Height);
            rcRight = new Rectangle(-1, 0, imgRight.Width, imgRight.Height);

            // Image attributes used to lighten default buttons

            cmDefault = new ColorMatrix();
            cmDefault.Matrix33 = 0.5f;  // reduce opacity by 50%

            iaDefault = new ImageAttributes();
            iaDefault.SetColorMatrix(cmDefault, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            // Image attributes that lighten and desaturate normal buttons

            cmNormal = new ColorMatrix();

            // desaturate the image
            cmNormal.Matrix00 = 1 / 3f;
            cmNormal.Matrix01 = 1 / 3f;
            cmNormal.Matrix02 = 1 / 3f;
            cmNormal.Matrix10 = 1 / 3f;
            cmNormal.Matrix11 = 1 / 3f;
            cmNormal.Matrix12 = 1 / 3f;
            cmNormal.Matrix20 = 1 / 3f;
            cmNormal.Matrix21 = 1 / 3f;
            cmNormal.Matrix22 = 1 / 3f;
            cmNormal.Matrix33 = 0.5f;  // reduce opacity by 50%

            iaNormal = new ImageAttributes();
            iaNormal.SetColorMatrix(cmNormal, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
        }

        public void StartPulsing()
        {
            if (Focused && Pulse && !this.DesignModeDetected())
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = ZeroitButtonAcquaGradient.PulseInterval;
                timer.Tick += new EventHandler(TimerOnTick);
                gamma = ZeroitButtonAcquaGradient.PulseGammaMax;
                gammaShift = -ZeroitButtonAcquaGradient.PulseGammaShift;
                timer.Start();
            }
        }

        public void StopPulsing()
        {
            if (timer != null)
            {
                iaDefault.SetGamma(1.0f, ColorAdjustType.Bitmap);
                timer.Stop();
            }
        }

        public void Draw(Graphics g)
        {
            DrawButton(g);
            DrawText(g);
        }

        public void DrawButton(Graphics g)
        {
            // Update our destination rectangles
            rcRight.X = this.Width - imgRight.Width;

            if (mousePressed)
            {
                if (ClientRectangle.Contains(ptMousePosition.X, ptMousePosition.Y))
                    DrawButtonState(g, iaDefault);
                else
                    DrawButtonState(g, iaNormal);
            }
            else if (pulse = true && IsDefault == true)
                DrawButtonState(g, iaDefault);
            else
                DrawButtonState(g, iaNormal);
        }

        public void DrawButtonState(Graphics g, ImageAttributes ia)
        {
            TextureBrush tb;

            // Draw the left and right endcaps
            g.DrawImage(imgLeft, rcLeft, 0, 0,
                imgLeft.Width, imgLeft.Height, GraphicsUnit.Pixel, ia);

            g.DrawImage(imgRight, rcRight, 0, 0,
                imgRight.Width, imgRight.Height, GraphicsUnit.Pixel, ia);

            // Draw the middle
            tb = new TextureBrush(imgFill,
                new Rectangle(0, 0, imgFill.Width, imgFill.Height), ia);
            tb.WrapMode = WrapMode.Tile;

            g.FillRectangle(tb, imgLeft.Width, 0,
                this.Width - (imgLeft.Width + imgRight.Width),
                imgFill.Height);

            tb.Dispose();
        }

        public void DrawText(Graphics g)
        {
            RectangleF layoutRect =
                new RectangleF(0, 0, this.Width,
                    this.Height - ZeroitButtonAcquaGradient.ButtonShadowOffset);

            int LabelShadowOffset = 1;

            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            // Draw the shadow below the label
            layoutRect.Offset(0, LabelShadowOffset);
            SolidBrush textShadowBrush = new SolidBrush(Color.Gray);
            g.DrawString(Text, Font, textShadowBrush, layoutRect, fmt);
            textShadowBrush.Dispose();

            // and the label itself
            layoutRect.Offset(0, -LabelShadowOffset);
            SolidBrush brushFiller = new SolidBrush(Color.Black);
            g.DrawString(Text, Font, brushFiller, layoutRect, fmt);
            brushFiller.Dispose();
        }

        public void TimerOnTick(object obj, EventArgs e)
        {
            // set the new gamma level
            if ((gamma - ZeroitButtonAcquaGradient.PulseGammaMin < ZeroitButtonAcquaGradient.PulseGammaReductionThreshold) ||
                (ZeroitButtonAcquaGradient.PulseGammaMax - gamma < ZeroitButtonAcquaGradient.PulseGammaReductionThreshold))
                gamma += gammaShift * ZeroitButtonAcquaGradient.PulseGammaShiftReduction;
            else
                gamma += gammaShift;

            if (gamma <= ZeroitButtonAcquaGradient.PulseGammaMin || gamma >= ZeroitButtonAcquaGradient.PulseGammaMax)
                gammaShift = -gammaShift;

            iaDefault.SetGamma(gamma, ColorAdjustType.Bitmap);

            Invalidate();
            Update();
        }

        public bool DesignModeDetected()
        {
            // base.DesignMode always returns false, so try this workaround
            IDesignerHost host =
                (IDesignerHost)this.GetService(typeof(IDesignerHost));

            return (host != null);
        }

        #endregion
    }

    public class ZeroitButtonAcquaGradientDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        public ZeroitButtonAcquaGradientDesigner()
        {
        }

        //Overrides

        /// <summary>
        /// Remove Button and Control properties that are 
        /// not supported by the Aqua Button
        /// </summary>
        /// <param name="Properties"></param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("BackColor");
            //Properties.Remove("BackgroundImage");
            //Properties.Remove("ContextMenu");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("Image");
            //Properties.Remove("ImageAlign");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
            //Properties.Remove("Size");
            //Properties.Remove("TextAlign");
        }
    }

    #endregion


}
