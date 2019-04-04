// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="OffPanel.cs" company="Zeroit Dev Technologies">
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
    #region Off Panel    
    /// <summary>
    /// A class collection for rendering an office panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitOffice07PanelDesigner))]
    public class ZeroitOffice07Panel : System.Windows.Forms.Panel
    {
        #region Private Fields
        /// <summary>
        /// The x0
        /// </summary>
        int X0;
        /// <summary>
        /// The xf
        /// </summary>
        int XF;
        /// <summary>
        /// The y0
        /// </summary>
        int Y0;
        /// <summary>
        /// The yf
        /// </summary>
        int YF;
        /// <summary>
        /// The t
        /// </summary>
        int T = 2;
        /// <summary>
        /// The i zero
        /// </summary>
        int i_Zero = 180;
        /// <summary>
        /// The i sweep
        /// </summary>
        int i_Sweep = 90;
        /// <summary>
        /// The x
        /// </summary>
        int X; int Y;
        /// <summary>
        /// The path
        /// </summary>
        GraphicsPath path;
        /// <summary>
        /// The d
        /// </summary>
        int D = -1;
        /// <summary>
        /// The r0
        /// </summary>
        int R0 = 215;
        /// <summary>
        /// The g0
        /// </summary>
        int G0 = 227;
        /// <summary>
        /// The b0
        /// </summary>
        int B0 = 242;
        /// <summary>
        /// The base color
        /// </summary>
        Color _BaseColor = Color.FromArgb(215, 227, 242);
        /// <summary>
        /// The base color on
        /// </summary>
        Color _BaseColorOn = Color.FromArgb(215, 227, 242);
        /// <summary>
        /// The i mode
        /// </summary>
        int i_mode = 0; //0 Entering, 1 Leaving
        /// <summary>
        /// The i factor
        /// </summary>
        int i_factor = 8;
        /// <summary>
        /// The i f r
        /// </summary>
        int i_fR = 1; int i_fG = 1; int i_fB = 1;
        /// <summary>
        /// The i op
        /// </summary>
        int i_Op = 255;

        /// <summary>
        /// The s text
        /// </summary>
        string S_TXT = "";

        /// <summary>
        /// The pen colors
        /// </summary>
        Color[] penColors;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOffice07Panel" /> class.
        /// </summary>
        public ZeroitOffice07Panel()
        {
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }


        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the pen colors.
        /// </summary>
        /// <value>The pen colors.</value>
        public Color[] PenColors
        {
            get { return penColors; }
            set
            {
                penColors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the base color.
        /// </summary>
        /// <value>The base color.</value>
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
                R0 = _BaseColor.R;
                B0 = _BaseColor.B;
                G0 = _BaseColor.G;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the base color when on.
        /// </summary>
        /// <value>The base color when on.</value>
        public Color BaseColorOn
        {
            get
            {
                return _BaseColorOn;
            }
            set
            {
                _BaseColorOn = value;
                R0 = _BaseColor.R;
                B0 = _BaseColor.B;
                G0 = _BaseColor.G;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return S_TXT;
            }
            set
            {
                S_TXT = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public int Speed
        {
            get
            {
                return i_factor;
            }
            set
            {
                i_factor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public int Opacity
        {
            get
            {
                return i_Op;
            }
            set
            {
                if (value < 256 | value > -1)
                { i_Op = value; }

                Invalidate();
            }

        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            X0 = 0; XF = this.Width + X0 - 3;
            Y0 = 0; YF = this.Height + Y0 - 3;

            Point P0 = new Point(X0, Y0);
            Point PF = new Point(X0, Y0 + YF - 15);

            penColors = new Color[]
            {
                Color.FromArgb(i_Op, R0 - 18, G0 - 17, B0 - 19),
                Color.FromArgb(i_Op, R0 - 39, G0 - 24, B0 - 3),
                Color.FromArgb(i_Op, R0 + 14, G0 + 9, B0 + 3),
                Color.FromArgb(i_Op, R0 - 8, G0 - 4, B0 - 2),
                Color.FromArgb(i_Op, R0, G0, B0),
                Color.FromArgb(i_Op, R0 - 16, G0 - 11, B0 - 5),
                Color.FromArgb(i_Op, R0, G0 + 4, B0),
                Color.FromArgb(i_Op, R0 - 22, G0 - 10, B0)

            };

            Pen b1 = new Pen(penColors[0]);
            Pen b2 = new Pen(penColors[1]);
            Pen b3 = new Pen(penColors[2]);
            Pen b4 = new Pen(penColors[3]);
            Pen b5 = new Pen(penColors[4]);
            Pen b6 = new Pen(penColors[5]);
            Pen b8 = new Pen(penColors[6]);
            Pen b7 = new Pen(penColors[7]);

            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            Brush B4 = b4.Brush;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            X = X0; Y = Y0; i_Zero = 180; D = 0;
            DrawArc();
            e.Graphics.DrawPath(b1, path);
            DrawArc();
            e.Graphics.DrawPath(b2, path);
            DrawArc();
            e.Graphics.DrawPath(b3, path);

            DrawArc2(0, 20);
            e.Graphics.FillPath(b5.Brush, path);
            LinearGradientBrush brocha = new LinearGradientBrush(P0, PF, b6.Color, b8.Color);
            DrawArc2(15, YF - 15);
            e.Graphics.FillPath(brocha, path);
            DrawArc2(YF - 18, 18);

            Point P_EX = Cursor.Position;
            P_EX = this.PointToClient(P_EX);

            int ix = this.Width / 2 - S_TXT.Length * (int)this.Font.Size / 2;
            PointF P_TXT = new PointF(ix, this.Height - 18);
            Pen pen = new Pen(this.ForeColor);
            e.Graphics.DrawString(S_TXT, this.Font, pen.Brush, P_TXT);

            base.OnPaint(e);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            Point P_EX = Cursor.Position;
            P_EX = this.PointToClient(P_EX);
            if (P_EX.X > 0 | P_EX.X < this.Width | P_EX.Y > 0 | P_EX.Y < this.Height)
            {
                i_mode = 0;
                timer1.Start();
            }
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            Point P_EX = Cursor.Position;
            P_EX = this.PointToClient(P_EX);
            if (P_EX.X < 0 | P_EX.X >= this.Width | P_EX.Y < 0 | P_EX.Y >= this.Height)
            {
                i_mode = 1;
                timer1.Start();
            }
            base.OnMouseLeave(e);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Draws the arc.
        /// </summary>
        public void DrawArc()
        {
            X = X0; Y = Y0; i_Zero = 180; D++;
            path = new GraphicsPath();
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; X += XF;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += YF;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; X -= XF;
            path.AddArc(X + D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y -= YF;
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep);
        }

        /// <summary>
        /// Draws the arc2.
        /// </summary>
        /// <param name="OF_Y">The of y.</param>
        /// <param name="SW_Y">The sw y.</param>
        public void DrawArc2(int OF_Y, int SW_Y)
        {
            X = X0; Y = Y0 + OF_Y; i_Zero = 180;
            path = new GraphicsPath();
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; X += XF;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += SW_Y;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; X -= XF;
            path.AddArc(X + D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y -= SW_Y;
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep);
        }
        #endregion

        #region Timer Utility
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer1_Tick(object sender, EventArgs e)
        {
            #region Entering
            if (i_mode == 0)
            {
                if (System.Math.Abs(_BaseColorOn.R - R0) > i_factor)
                { i_fR = i_factor; }
                else { i_fR = 1; }
                if (System.Math.Abs(_BaseColorOn.G - G0) > i_factor)
                { i_fG = i_factor; }
                else { i_fG = 1; }
                if (System.Math.Abs(_BaseColorOn.B - B0) > i_factor)
                { i_fB = i_factor; }
                else { i_fB = 1; }

                if (_BaseColorOn.R < R0)
                {
                    R0 -= i_fR;
                }
                else if (_BaseColorOn.R > R0)
                {
                    R0 += i_fR;
                }

                if (_BaseColorOn.G < G0)
                {
                    G0 -= i_fG;
                }
                else if (_BaseColorOn.G > G0)
                {
                    G0 += i_fG;
                }

                if (_BaseColorOn.B < B0)
                {
                    B0 -= i_fB;
                }
                else if (_BaseColorOn.B > B0)
                {
                    B0 += i_fB;
                }

                if (_BaseColorOn == Color.FromArgb(R0, G0, B0))
                {
                    timer1.Stop();
                }
                else
                {
                    this.Refresh();
                }
            }
            #endregion

            #region Leaving
            if (i_mode == 1)
            {
                if (System.Math.Abs(_BaseColor.R - R0) < i_factor)
                { i_fR = 1; }
                else { i_fR = i_factor; }
                if (System.Math.Abs(_BaseColor.G - G0) < i_factor)
                { i_fG = 1; }
                else { i_fG = i_factor; }
                if (System.Math.Abs(_BaseColor.B - B0) < i_factor)
                { i_fB = 1; }
                else { i_fB = i_factor; }

                if (_BaseColor.R < R0)
                {
                    R0 -= i_fR;
                }
                else if (_BaseColor.R > R0)
                {
                    R0 += i_fR;
                }
                if (_BaseColor.G < G0)
                {
                    G0 -= i_fG;
                }
                else if (_BaseColor.G > G0)
                {
                    G0 += i_fG;
                }
                if (_BaseColor.B < B0)
                {
                    B0 -= i_fB;
                }
                else if (_BaseColor.B > B0)
                {
                    B0 += i_fB;
                }

                if (_BaseColor == Color.FromArgb(R0, G0, B0))
                {
                    timer1.Stop();
                }
                else
                {
                    this.Refresh();
                }

            }
            #endregion

        }

        #endregion

    }



    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitOffice07PanelDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitOffice07PanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitOffice07PanelDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitOffice07PanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitOffice07PanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitOffice07PanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOffice07Panel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOffice07PanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitOffice07PanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOffice07Panel;

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

        #region Public Properties

        /// <summary>
        /// Gets or sets the pen colors.
        /// </summary>
        /// <value>The pen colors.</value>
        public Color[] PenColors
        {
            get
            {
                return colUserControl.PenColors;
            }
            set
            {
                GetPropertyByName("PenColors").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the base.
        /// </summary>
        /// <value>The color of the base.</value>
        public Color BaseColor
        {
            get
            {
                return colUserControl.BaseColor;
            }
            set
            {
                GetPropertyByName("BaseColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the base color on.
        /// </summary>
        /// <value>The base color on.</value>
        public Color BaseColorOn
        {
            get
            {
                return colUserControl.BaseColorOn;
            }
            set
            {
                GetPropertyByName("BaseColorOn").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return colUserControl.Caption;
            }
            set
            {
                GetPropertyByName("Caption").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public int Speed
        {
            get
            {
                return colUserControl.Speed;
            }
            set
            {
                GetPropertyByName("Speed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public int Opacity
        {
            get
            {
                return colUserControl.Opacity;
            }
            set
            {
                GetPropertyByName("Opacity").SetValue(colUserControl, value);
            }

        }
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("BaseColor",
                                 "Base Color", "Appearance",
                                 "Sets the base color."));

            items.Add(new DesignerActionPropertyItem("BaseColorOn",
                                 "Base Color On", "Appearance",
                                 "Sets the base color on."));

            items.Add(new DesignerActionPropertyItem("PenColors",
                                 "Pen Colors", "Appearance",
                                 "Sets the pen colors."));

            items.Add(new DesignerActionPropertyItem("Caption",
                                 "Caption", "Appearance",
                                 "Sets the caption."));

            items.Add(new DesignerActionPropertyItem("Speed",
                                 "Speed", "Appearance",
                                 "Sets the speed."));

            items.Add(new DesignerActionPropertyItem("Opacity",
                                 "Opacity", "Appearance",
                                 "Sets the opacity."));


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
