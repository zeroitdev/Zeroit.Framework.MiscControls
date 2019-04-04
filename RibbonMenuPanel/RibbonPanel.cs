// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RibbonPanel.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering ribbon panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitRibbonPanelDesigner))]
    public class ZeroitRibbonPanel : System.Windows.Forms.Panel
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
        int T = 3;
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
        /// The activex0
        /// </summary>
        private int activex0 = 0;
        /// <summary>
        /// The activexf
        /// </summary>
        private int activexf = 0;
        /// <summary>
        /// The activestate
        /// </summary>
        private bool activestate = false;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the base color.
        /// </summary>
        /// <value>The color of the base.</value>
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
            }
        }

        /// <summary>
        /// Gets or sets the base color.
        /// </summary>
        /// <value>The base color on.</value>
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
            }

        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRibbonPanel" /> class.
        /// </summary>
        public ZeroitRibbonPanel()
        {
            this.Padding = new Padding(0, 3, 0, 0);
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Fires the event indicating that the panel has been resized. Inheriting controls should use this in favor of actually listening to the event, but should still call base.onResize to ensure that the event is fired for external listeners.
        /// </summary>
        /// <param name="eventargs">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs eventargs)
        {
            this.Refresh();
            base.OnResize(eventargs);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            X0 = 0; XF = this.Width + X0 - 3;
            Y0 = 0; YF = this.Height + Y0 - 3;
            T = 6;
            Point P0 = new Point(X0, Y0 - 1);
            Point PF = new Point(X0, Y0 + YF + 8);
            Pen b1 = new Pen(Color.FromArgb(i_Op, R0 - 18, G0 - 17, B0 - 19));
            Pen b2 = Pens.Black;
            try
            {
                //For Light Colors
                b2 = new Pen(Color.FromArgb(i_Op, R0 - 74, G0 - 49, B0 - 15));
            }
            catch
            {
                //For Dark Colors
                b2 = new Pen(Color.FromArgb(i_Op, R0 - 22, G0 - 11, B0));
            }
            Pen b22 = new Pen(Color.FromArgb(i_Op, R0 + 23, G0 + 21, B0 + 13));
            Pen b3 = new Pen(Color.FromArgb(i_Op, R0 + 14, G0 + 9, B0 + 3));
            Pen b4 = new Pen(Color.FromArgb(i_Op, R0 - 8, G0 - 4, B0 - 2));
            Pen b5 = new Pen(Color.FromArgb(i_Op, R0 + 4, G0 + 3, B0 + 3));
            Pen b6 = new Pen(Color.FromArgb(i_Op, R0 - 16, G0 - 11, B0 - 5));
            Pen b8 = new Pen(Color.FromArgb(i_Op, R0 + 12, G0 + 17, B0 + 13));
            Pen b7 = new Pen(Color.FromArgb(i_Op, R0 - 22, G0 - 10, B0));

            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            Brush B4 = b4.Brush;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            X = X0; Y = Y0; i_Zero = 180; D = 0;

            DrawArc();
            e.Graphics.FillPath(b5.Brush, path);
            Rectangle rect = e.ClipRectangle;
            //LinearGradientBrush brocha = new LinearGradientBrush(rect, b6.Color, b8.Color,LinearGradientMode.Vertical);
            LinearGradientBrush brocha = new LinearGradientBrush(P0, PF, b6.Color, b8.Color);
            DrawArc2(17, YF + 7);
            e.Graphics.FillPath(brocha, path);
            D--;
            DrawFHalfArc();
            e.Graphics.DrawPath(b2, path);
            DrawSHalfArc();
            e.Graphics.DrawPath(b22, path);

            if (activestate)
            {
                e.Graphics.DrawLine(b5, new Point(activex0 + 1, 0), new Point(activexf - 9, 0));
            }

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
        /// Lines the position.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="xf">The xf.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public void LinePos(int x0, int xf, bool state)
        {
            activex0 = x0; activexf = xf; activestate = state;
            this.Refresh();
        }

        /// <summary>
        /// Draws the arc2.
        /// </summary>
        /// <param name="OF_Y">The of y.</param>
        /// <param name="SW_Y">The sw y.</param>
        public void DrawArc2(int OF_Y, int SW_Y)
        {
            X = X0 - 1; Y = Y0 + OF_Y; i_Zero = 180;
            path = new GraphicsPath();
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; X += XF - 1;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += SW_Y - 20;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; X -= XF - 1;
            path.AddArc(X + D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y -= SW_Y - 20;
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep);
        }


        /// <summary>
        /// Draws the arc.
        /// </summary>
        public void DrawArc()
        {
            X = X0 - 2; Y = Y0 - 1; i_Zero = 180; D++;
            path = new GraphicsPath();
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; X += XF;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += YF;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; X -= XF;
            path.AddArc(X + D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y -= YF;
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep);
        }

        /// <summary>
        /// Draws the f half arc.
        /// </summary>
        public void DrawFHalfArc()
        {
            X = X0 - 2; Y = Y0 - 1; i_Zero = 180; D++;
            path = new GraphicsPath();
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; X += XF - 1;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += YF;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep);

        }

        /// <summary>
        /// Draws the s half arc.
        /// </summary>
        public void DrawSHalfArc()
        {
            X = X0 - 3; Y = Y0 - 1; i_Zero = 180; D++;
            path = new GraphicsPath();
            i_Zero += 90; X += XF;
            path.AddArc(X - D, Y + D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y += YF - 1;
            path.AddArc(X - D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; X -= XF - 1;
            path.AddArc(X + D, Y - D, T, T, i_Zero, i_Sweep); i_Zero += 90; Y -= YF - 1;
            path.AddArc(X + D, Y + D, T, T, i_Zero, i_Sweep);

        }
        #endregion

        #region Timer Utility
        /// <summary>
        /// The timer1
        /// </summary>
        private Timer timer1 = new Timer();

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

    //--------------- [Designer(typeof(ZeroitRibbonPanelDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRibbonPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRibbonPanelDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRibbonPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRibbonPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRibbonPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRibbonPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRibbonPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRibbonPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRibbonPanel;

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

}