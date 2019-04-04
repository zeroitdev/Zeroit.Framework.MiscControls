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

    #region Button Aqua 2

    /// <summary>
	/// A class collection for rendering an aqua button.
	/// </summary>
	[Serializable]
    [Designer(typeof(ZeroitAquaButtonDenseDesigner))]
    public class ZeroitAquaButtonDense : Control
    {
        #region Variables
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private bool pulseOnFocus;

        ///
        ///Additional variables to handle pulsing
        ///
        private ImageAttributes imgAttr = new ImageAttributes();
        private float gamma;
        private float minGamma;
        private float maxGamma;
        private float gammaStep;
        private System.Windows.Forms.Timer pulseTimer = new System.Windows.Forms.Timer();
        private Bitmap buttonBitmap;
        private Rectangle buttonBitmapRectangle;


        private bool addShadow = true;
        private Color color1 = Color.Green;
        private Color color2 = Color.White;
        private Color gradientColor = Color.White;

        private int shadowOffset = 8;
        private int btnOffset = 0;


        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to pulse on focus.
        /// </summary>
        /// <value><c>true</c> if pulse on focus; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool PulseOnFocus
        {
            get { return pulseOnFocus; }
            set { pulseOnFocus = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to add shadow.
        /// </summary>
        /// <value><c>true</c> if add shadow; otherwise, <c>false</c>.</value>
        public bool AddShadow
        {
            get { return addShadow; }
            set
            {
                addShadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color.</value>
        public Color GradientColor
        {
            get { return gradientColor; }
            set
            {
                gradientColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow offset.
        /// </summary>
        /// <value>The shadow offset.</value>
        public int ShadowOffSet
        {
            get { return shadowOffset; }
            set
            {
                shadowOffset = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the button offset.
        /// </summary>
        /// <value>The button offset.</value>
        public int ButtonOffset
        {
            get { return btnOffset; }
            set
            {
                btnOffset = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the linear gradient mode.
        /// </summary>
        /// <value>The linear gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAquaButtonDense"/> class.
        /// </summary>
        public ZeroitAquaButtonDense()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            mouseAction = MouseActionType.None;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            //The following defaults are better suited to draw the text outline
            this.Font = new Font("Arial Black", 12, FontStyle.Bold);
            this.BackColor = Color.Transparent;
            this.Size = new Size(112, 48);
            this.ForeColor = Color.Black;

            //Initialize variables to Pulse button
            gamma = 1.0f;
            minGamma = 1.0f;
            maxGamma = 2.2f;
            gammaStep = .2f;
            pulseTimer.Interval = 90;
            pulseTimer.Tick += new EventHandler(pulseTimer_Tick);
        }

        
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
        }
        #endregion

        private enum MouseActionType
        {
            None,
            Hover,
            Click
        }

        private MouseActionType mouseAction;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(Parent.BackColor);
            //Color clr = BackColor;

            switch (mouseAction)
            {
                case MouseActionType.Click:
                    shadowOffset = 4;
                    //clr = Color.Gold;
                    btnOffset = 2;
                    break;
                case MouseActionType.Hover:
                    //clr = Color.Gold;
                    break;
            }
            g.SmoothingMode = SmoothingMode.HighQuality;

            ///
            /// Create main colored shape
            /// 
            Rectangle rc = new Rectangle(btnOffset, btnOffset, this.ClientSize.Width - 8 - btnOffset, this.ClientSize.Height - 8 - btnOffset);
            GraphicsPath path1 = this.GetPath(rc, 20);
            LinearGradientBrush br1 = new LinearGradientBrush(new Point(0, 0), new Point(0, rc.Height + 6), color1, color2);

            ///
            /// Create shadow
            /// 
            if (addShadow == true)
            {
                Rectangle rc2 = rc;
                rc2.Offset(shadowOffset, shadowOffset);
                GraphicsPath path2 = this.GetPath(rc2, 20);
                PathGradientBrush br2 = new PathGradientBrush(path2);
                br2.CenterColor = ControlPaint.DarkDark(Color.Silver);
                br2.SurroundColors = new Color[] { Color.Transparent };

                g.FillPath(br2, path2); //draw shadow

                ///
                ///Set the region for the button
                Region rgn = new Region(path1);
                rgn.Union(path2);
                this.Region = rgn;
            }


            ///
            /// Create top water color to give "aqua" effect
            /// 
            Rectangle rc3 = rc;
            rc3.Inflate(-5, -5);
            rc3.Height = 15;
            GraphicsPath path3 = GetPath(rc3, 20);
            LinearGradientBrush br3 = new LinearGradientBrush(rc3, Color.FromArgb(255, gradientColor), Color.FromArgb(0, gradientColor), gradientMode);

            ///
            ///draw shapes
            ///

            g.FillPath(br1, path1); //draw main
            g.FillPath(br3, path3); //draw top bubble

            ///
            ///Create a backup of the button image to a bitmap so we can manipulate it's pulsing action
            ///
            buttonBitmapRectangle = new Rectangle(rc.Location, rc.Size);
            buttonBitmap = new Bitmap(buttonBitmapRectangle.Width, buttonBitmapRectangle.Height);
            Graphics g_bmp = Graphics.FromImage(buttonBitmap);
            g_bmp.SmoothingMode = SmoothingMode.HighQuality;
            g_bmp.FillPath(br1, path1);
            g_bmp.FillPath(br3, path3);



            ///
            /// Create a Path to draw the text to give the button a nice outline
            /// 
            GraphicsPath path4 = new GraphicsPath();

            RectangleF path1bounds = path1.GetBounds();
            Rectangle rcText = new Rectangle((int)path1bounds.X, (int)path1bounds.Y, (int)path1bounds.Width, (int)path1bounds.Height);

            StringFormat strformat = new StringFormat();
            strformat.Alignment = StringAlignment.Center;
            strformat.LineAlignment = StringAlignment.Center;
            path4.AddString(this.Text, this.Font.FontFamily, (int)this.Font.Style, this.Font.Size,
                rcText, strformat);

            Pen txtPen = new Pen(this.ForeColor, 1);
            g.DrawPath(txtPen, path4);
            g_bmp.DrawPath(txtPen, path4);
        }

        private GraphicsPath GetPath(Rectangle rc, int r)
        {
            int x = rc.X, y = rc.Y, w = rc.Width, h = rc.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, r, r, 180, 90);               //Upper left corner
            path.AddArc(x + w - r, y, r, r, 270, 90);           //Upper right corner
            path.AddArc(x + w - r, y + h - r, r, r, 0, 90);     //Lower right corner
            path.AddArc(x, y + h - r, r, r, 90, 90);            //Lower left corner
            path.CloseFigure();
            return path;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseAction = MouseActionType.Click;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.Bounds.Contains(e.X, e.Y))
                this.mouseAction = MouseActionType.Hover;
            else
                this.mouseAction = MouseActionType.None;
            this.Invalidate();
            base.OnMouseUp(e);
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.mouseAction = MouseActionType.None;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        //-----------------------------------------------------------------
        // METHODS TO HANDLE PULSING
        //-----------------------------------------------------------------

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.pulseOnFocus)
                pulseTimer.Start();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            pulseTimer.Stop();
            this.Invalidate();  //redraw to get back it's original picture
        }

        private void pulseTimer_Tick(object sender, EventArgs e)
        {
            if (this.Focused && pulseOnFocus && buttonBitmap != null)
            {
                gamma += gammaStep;
                if (gamma > this.maxGamma) gammaStep = -gammaStep;
                if (gamma < this.minGamma) gammaStep = Math.Abs(gammaStep);

                imgAttr.SetGamma(gamma);
                this.CreateGraphics().DrawImage(buttonBitmap, buttonBitmapRectangle, 0, 0,
                                      buttonBitmap.Width, buttonBitmap.Height, GraphicsUnit.Pixel, imgAttr);
            }
        }
    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitAquaButtonDenseDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitAquaButtonDenseSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitAquaButtonDenseSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitAquaButtonDense colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitAquaButtonDenseSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAquaButtonDense;

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

        public bool AddShadow
        {
            get
            {
                return colUserControl.AddShadow;
            }
            set
            {
                GetPropertyByName("AddShadow").SetValue(colUserControl, value);
            }
        }

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

        public Color Color1
        {
            get
            {
                return colUserControl.Color1;
            }
            set
            {
                GetPropertyByName("Color1").SetValue(colUserControl, value);
            }
        }

        public Color Color2
        {
            get
            {
                return colUserControl.Color2;
            }
            set
            {
                GetPropertyByName("Color2").SetValue(colUserControl, value);
            }
        }

        public Color GradientColor
        {
            get
            {
                return colUserControl.GradientColor;
            }
            set
            {
                GetPropertyByName("GradientColor").SetValue(colUserControl, value);
            }
        }

        public int ShadowOffSet
        {
            get
            {
                return colUserControl.ShadowOffSet;
            }
            set
            {
                GetPropertyByName("ShadowOffSet").SetValue(colUserControl, value);
            }
        }

        public int ButtonOffset
        {
            get
            {
                return colUserControl.ButtonOffset;
            }
            set
            {
                GetPropertyByName("ButtonOffset").SetValue(colUserControl, value);
            }
        }

        public LinearGradientMode GradientMode
        {
            get
            {
                return colUserControl.GradientMode;
            }
            set
            {
                GetPropertyByName("GradientMode").SetValue(colUserControl, value);
            }
        }

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

            items.Add(new DesignerActionPropertyItem("Color1",
                                 "Color1", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("Color2",
                                 "Color2", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("GradientColor",
                                 "Gradient Color Glow", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("ShadowOffSet",
                                 "ShadowOffSet", "Appearance",
                                 "Sets the shadow offset."));

            items.Add(new DesignerActionPropertyItem("ButtonOffset",
                                 "ButtonOffset", "Appearance",
                                 "Sets the button offset."));

            items.Add(new DesignerActionPropertyItem("GradientMode",
                                 "GradientMode", "Appearance",
                                 "Sets the gradient mode of the color."));

            items.Add(new DesignerActionPropertyItem("AddShadow",
                                 "AddShadow", "Appearance",
                                 "Adds a shadow to the control"));

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
