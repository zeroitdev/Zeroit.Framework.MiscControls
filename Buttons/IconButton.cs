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

    #region IconButton

    #region Alpha
    /// <summary>
	/// Summary description for alpha.
	/// </summary>
	public class alpha
    {
        public alpha()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static int min(int val)
        {
            return (val < 0 ? 0 : val);
        }

        public static void setAlpha(Bitmap bmp, int alpha)
        {
            Color col;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
        }

        public static Bitmap returnAlpha(Bitmap bmp, int alpha)
        {
            Color col;
            Bitmap bmp2 = new Bitmap(bmp);

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp2.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
            return bmp2;
        }
    }

    #endregion

    #region Control

    /// <summary>
	/// Summary description for Iconits.
	/// </summary>
    /// 
    [Designer(typeof(ZeroitButtonIconDesigner))]
    public class ZeroitButtonIcon : System.Windows.Forms.Control
    {

        #region Private Field
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip t = new ToolTip();
        Bitmap[] bmp;
        int flag;
        bool enter;
        Graphics g, g2;
        int imwidth, imheight;
        double curwidth, curheight;
        double addx, addy;
        Bitmap dblbuffer;
        bool blur = true;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Bitmap Icon
        {
            get { return bmp[0]; }
            set
            {
                for (int i = 0; i < 4; i++)
                    bmp[i] = new Bitmap(Width, Height);
                dblbuffer = new Bitmap(Width, Height);

                bmp[0] = value;
                bmp[1] = alpha.returnAlpha(bmp[0], 60);
                bmp[2] = alpha.returnAlpha(bmp[0], 120);
                bmp[3] = alpha.returnAlpha(bmp[0], 180);
                draw(0);
            }
        }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        public new Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = ((Size)value).Width;
                Height = ((Size)value).Height;
                if (Width > 160)
                {
                    //MessageBox.Show("Width cannot exceed 160 :p");
                    Width = 160;
                }
                if (Height > 128)
                {
                    //MessageBox.Show("Height cannot exceed 128 :p");
                    Height = 128;
                }
                calc();
            }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        public Size IconSize
        {
            get { return new Size(imwidth, imheight); }
            set
            {
                imwidth = ((Size)value).Width;
                imheight = ((Size)value).Height;
                if (imwidth > Width) imwidth = Width;
                if (imheight > Height) imheight = Height;
                calc();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitButtonIcon"/> should have blur enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if blur; otherwise, <c>false</c>.</value>
        public bool Blur
        {
            get { return blur; }
            set
            {
                blur = value;
                if (!blur)
                {
                    bmp[1].Dispose();
                    bmp[2].Dispose();
                    bmp[3].Dispose();
                }
                else
                {
                    bmp[1] = alpha.returnAlpha(bmp[0], 60);
                    bmp[2] = alpha.returnAlpha(bmp[0], 120);
                    bmp[3] = alpha.returnAlpha(bmp[0], 180);
                }
            }
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        /// <value>The tooltip text.</value>
        public string TooltipText
        {
            get { return t.GetToolTip(this); }
            set
            {
                t.SetToolTip(this, value);
            }
        }
        
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonIcon"/> class.
        /// </summary>
        public ZeroitButtonIcon()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            SetStyle(ControlStyles.SupportsTransparentBackColor, true);


            // TODO: Add any initialization after the InitializeComponent call			
            bmp = new Bitmap[4];
            for (int i = 0; i < 4; i++)
                bmp[i] = new Bitmap(Width, Height);
            dblbuffer = new Bitmap(Width, Height);
            IconSize = new Size(Width / 2, Height / 2);

            g = this.CreateGraphics();





        } 
        
        #endregion

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Iconits
            // 
            //this.BackColor = Parent.BackColor;
            this.Name = "Iconits";
            this.Size = new System.Drawing.Size(64, 64);
            this.IconSize = new Size(32, 32);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Iconits_Paint);
            this.MouseEnter += new System.EventHandler(this.Iconits_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Iconits_MouseLeave);

        }
        #endregion

        private void Iconits_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            draw(3);
        }

        private void calc()
        {
            curwidth = imwidth;
            curheight = imheight;

            addx = (double)(Width - imwidth) / 10;
            addy = (double)(Height - imheight) / 10;
        }

        private void draw(int state)
        {
            int st;

            if (blur)
                st = state;
            else
                st = 0;

            g2 = Graphics.FromImage(dblbuffer);
            g2.Clear(this.BackColor);
            g2.DrawImage(bmp[st], (int)((double)Width - curwidth) / 2, (int)((double)Height - curheight) / 2, (int)curwidth, (int)curheight);

            g.DrawImageUnscaled(dblbuffer, 0, 0);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (enter)
            {
                if (curwidth < Width)
                {
                    curwidth += addx;
                }

                if (curheight < Height)
                {
                    curheight += addy;
                }

                if (curwidth >= Width && curheight >= Height) timer1.Stop();

                flag++;
            }
            else
            {
                if (curwidth > imwidth)
                {
                    curwidth -= addx;
                }

                if (curheight > imheight)
                {
                    curheight -= addy;
                }

                if (curwidth <= imwidth && curheight <= imheight) timer1.Stop();

                flag--;
            }

            if (flag > 9) draw(0);
            else if (flag > 6) draw(1);
            else if (flag > 3) draw(2);
            else draw(3);
        }

        private void Iconits_MouseEnter(object sender, System.EventArgs e)
        {
            enter = true;
            timer1.Start();
        }

        private void Iconits_MouseLeave(object sender, System.EventArgs e)
        {
            enter = false;
            timer1.Start();
        }

        

    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonIconDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonIconSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitButtonIconSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitButtonIcon colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitButtonIconSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitButtonIcon;

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

        public Bitmap Icon
        {
            get
            {
                return colUserControl.Icon;
            }
            set
            {
                GetPropertyByName("Icon").SetValue(colUserControl, value);
            }
        }

        public Size Size
        {
            get
            {
                return colUserControl.Size;
            }
            set
            {
                GetPropertyByName("Size").SetValue(colUserControl, value);
            }
        }

        public Size IconSize
        {
            get
            {
                return colUserControl.IconSize;
            }
            set
            {
                GetPropertyByName("IconSize").SetValue(colUserControl, value);
            }
        }

        public string TooltipText
        {
            get
            {
                return colUserControl.TooltipText;
            }
            set
            {
                GetPropertyByName("TooltipText").SetValue(colUserControl, value);
            }
        }

        public bool Blur
        {
            get
            {
                return colUserControl.Blur;
            }
            set
            {
                GetPropertyByName("Blur").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Icon",
                                 "Icon", "Appearance",
                                 "Sets the image of the control."));

            items.Add(new DesignerActionPropertyItem("Size",
                                 "Size", "Appearance",
                                 "Sets the expand limit. "));

            items.Add(new DesignerActionPropertyItem("IconSize",
                                 "Icon Size", "Appearance",
                                 "Sets the Icon Size. Max-Width:160 Max-Height:128."));

            items.Add(new DesignerActionPropertyItem("TooltipText",
                                 "Tooltip Text", "Appearance",
                                 "Sets the tooltip text."));

            items.Add(new DesignerActionPropertyItem("Blur",
                                 "Blur", "Appearance",
                                 "Enable the blur property of the control."));

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
