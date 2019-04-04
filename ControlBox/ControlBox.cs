// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitControlBox    
    /// <summary>
    /// A class collection for rendering a control box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitControlBoxDesigner))]
    public class ZeroitControlBox : Control
    {

        #region Enums

        /// <summary>
        /// Enum MouseState
        /// </summary>
        public enum MouseState : byte
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The over
            /// </summary>
            Over = 1,
            /// <summary>
            /// Down
            /// </summary>
            Down = 2,
            /// <summary>
            /// The block
            /// </summary>
            Block = 3
        }

        #endregion

        #region Variables

        /// <summary>
        /// The state
        /// </summary>
        MouseState State = MouseState.None;
        /// <summary>
        /// The i
        /// </summary>
        int i;
        /// <summary>
        /// The xwidth
        /// </summary>
        int xwidth = 47;
        /// <summary>
        /// The height
        /// </summary>
        int height = 18;
        /// <summary>
        /// The minwidth
        /// </summary>
        int minwidth = 28;


        /// <summary>
        /// The color back1 none
        /// </summary>
        private Color colorBack1None = Color.FromArgb(73, 73, 73);
        /// <summary>
        /// The color back2 none
        /// </summary>
        private Color colorBack2None = Color.FromArgb(58, 58, 58);

        /// <summary>
        /// The color back1 hover
        /// </summary>
        private Color colorBack1Hover = Color.FromArgb(73, 73, 73);
        /// <summary>
        /// The color back2 hover
        /// </summary>
        private Color colorBack2Hover = Color.FromArgb(58, 58, 58);

        /// <summary>
        /// The color back path
        /// </summary>
        private Color colorBackPath = Color.FromArgb(40, 40, 40);

        /// <summary>
        /// The fore color
        /// </summary>
        private Color foreColor = Color.FromArgb(221, 221, 221);

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the xwidth.
        /// </summary>
        /// <value>The xwidth.</value>
        public int Xwidth
        {
            get { return xwidth; }
            set
            {
                xwidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum width.
        /// </summary>
        /// <value>The minimum width.</value>
        public int Minwidth
        {
            get { return minwidth; }
            set
            {
                minwidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        public int ControlHeight
        {
            get { return height; }
            set
            {
                height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color back when no activity.
        /// </summary>
        /// <value>The color back none1.</value>
        public Color ColorBackNone1
        {
            get { return colorBack1None; }
            set
            {
                colorBack1None = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the color back when no activity.
        /// </summary>
        /// <value>The color back none2.</value>
        public Color ColorBackNone2
        {
            get { return colorBack2None; }
            set
            {
                colorBack2None = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the color of the back when hovered.
        /// </summary>
        /// <value>The color back hover1.</value>
        public Color ColorBackHover1
        {
            get { return colorBack1Hover; }
            set
            {
                colorBack1Hover = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the color of the back when hovered.
        /// </summary>
        /// <value>The color back hover2.</value>
        public Color ColorBackHover2
        {
            get { return colorBack2Hover; }
            set
            {
                colorBack2Hover = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the color of the back path.
        /// </summary>
        /// <value>The color back path.</value>
        public Color ColorBackPath
        {
            get { return colorBackPath; }
            set
            {
                colorBackPath = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color text.</value>
        public Color ColorText
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                Invalidate();
            }

        }
        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (i > 0 & i < 28)
            {
                this.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (i > 30 & i < 75)
            {
                this.FindForm().Close();
            }

            State = MouseState.Down;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            i = e.Location.X;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 77;
            Height = 19;
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlBox" /> class.
        /// </summary>
        public ZeroitControlBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl" /> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Point location = new Point(checked(this.FindForm().Width - 81), -1);
            this.Location = location;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            GraphicsPath GP_MinimizeRect = new GraphicsPath();
            GraphicsPath GP_CloseRect = new GraphicsPath();

            Rectangle CloseRect = new Rectangle(28, 0, xwidth, height);
            Rectangle MinimizeRect = new Rectangle(0, 0, minwidth, height);

            GP_MinimizeRect.AddRectangle(MinimizeRect);
            GP_CloseRect.AddRectangle(CloseRect);
            G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    NonePoint:
                    LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, colorBack1None, colorBack2None, 90);
                    G.FillPath(MinimizeGradient, GP_MinimizeRect);
                    G.DrawPath(new Pen(colorBackPath), GP_MinimizeRect);
                    G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                    LinearGradientBrush CloseGradient = new LinearGradientBrush(CloseRect, colorBack1None, colorBack2None, 90);
                    G.FillPath(CloseGradient, GP_CloseRect);
                    G.DrawPath(new Pen(colorBackPath), GP_CloseRect);
                    G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), CloseRect.Width - 4, CloseRect.Height - 16);
                    break;
                case MouseState.Over:
                    if (i > 0 & i < 28)
                    {
                        LinearGradientBrush xMinimizeGradient = new LinearGradientBrush(MinimizeRect, colorBack1Hover, colorBack2Hover, 90f);
                        G.FillPath(xMinimizeGradient, GP_MinimizeRect);
                        G.DrawPath(new Pen(colorBackPath), GP_MinimizeRect);
                        G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                        LinearGradientBrush xCloseGradient = new LinearGradientBrush(CloseRect, colorBack1None, colorBack2None, 90);
                        G.FillPath(xCloseGradient, GP_CloseRect);
                        G.DrawPath(new Pen(colorBackPath), GP_CloseRect);
                        G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), CloseRect.Width - 4, CloseRect.Height - 16);
                    }
                    else if (i > 30 & i < 75)
                    {
                        LinearGradientBrush xCloseGradient = new LinearGradientBrush(CloseRect, colorBack1Hover, colorBack2Hover, 90);
                        G.FillPath(xCloseGradient, GP_CloseRect);
                        G.DrawPath(new Pen(colorBackPath), GP_CloseRect);
                        G.DrawString("r", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), CloseRect.Width - 4, CloseRect.Height - 16);

                        LinearGradientBrush xMinimizeGradient = new LinearGradientBrush(MinimizeRect, colorBack1None, colorBack2None, 90);
                        G.FillPath(xMinimizeGradient, RoundRectangle.RoundRect(MinimizeRect, 1));
                        G.DrawPath(new Pen(colorBackPath), GP_MinimizeRect);
                        G.DrawString("0", new Font("Marlett", 11, FontStyle.Regular), new SolidBrush(foreColor), MinimizeRect.Width - 22, MinimizeRect.Height - 16);
                    }
                    else
                    {
                        goto NonePoint; // Return to [MouseState = None]     
                    }
                    break;
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            GP_CloseRect.Dispose();
            GP_MinimizeRect.Dispose();
            B.Dispose();
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitControlBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitControlBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitControlBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitControlBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitControlBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitControlBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitControlBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitControlBox;

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
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
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
        /// Gets or sets the xwidth.
        /// </summary>
        /// <value>The xwidth.</value>
        public int Xwidth
        {
            get
            {
                return colUserControl.Xwidth;
            }
            set
            {
                GetPropertyByName("Xwidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minwidth.
        /// </summary>
        /// <value>The minwidth.</value>
        public int Minwidth
        {
            get
            {
                return colUserControl.Minwidth;
            }
            set
            {
                GetPropertyByName("Minwidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        public int ControlHeight
        {
            get
            {
                return colUserControl.ControlHeight;
            }
            set
            {
                GetPropertyByName("ControlHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color back none1.
        /// </summary>
        /// <value>The color back none1.</value>
        public Color ColorBackNone1
        {
            get
            {
                return colUserControl.ColorBackNone1;
            }
            set
            {
                GetPropertyByName("ColorBackNone1").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the color back none2.
        /// </summary>
        /// <value>The color back none2.</value>
        public Color ColorBackNone2
        {
            get
            {
                return colUserControl.ColorBackNone2;
            }
            set
            {
                GetPropertyByName("ColorBackNone2").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the color back hover1.
        /// </summary>
        /// <value>The color back hover1.</value>
        public Color ColorBackHover1
        {
            get
            {
                return colUserControl.ColorBackHover1;
            }
            set
            {
                GetPropertyByName("ColorBackHover1").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the color back hover2.
        /// </summary>
        /// <value>The color back hover2.</value>
        public Color ColorBackHover2
        {
            get
            {
                return colUserControl.ColorBackHover2;
            }
            set
            {
                GetPropertyByName("ColorBackHover2").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the color back path.
        /// </summary>
        /// <value>The color back path.</value>
        public Color ColorBackPath
        {
            get
            {
                return colUserControl.ColorBackPath;
            }
            set
            {
                GetPropertyByName("ColorBackPath").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Xwidth",
                                 "X width", "Appearance",
                                 "Sets the width of the close button."));

            items.Add(new DesignerActionPropertyItem("Minwidth",
                                 "Minimize width", "Appearance",
                                 "Sets the width of the minimize button."));

            items.Add(new DesignerActionPropertyItem("ControlHeight",
                                 "Control Height", "Appearance",
                                 "Sets the height of the control."));

            items.Add(new DesignerActionPropertyItem("ColorBackNone1",
                                 "Color BackNone1", "Appearance",
                                 "Sets the color of the button when inactive."));

            items.Add(new DesignerActionPropertyItem("ColorBackNone2",
                                 "Color BackNone2", "Appearance",
                                 "Sets the color of the button when inactive."));

            items.Add(new DesignerActionPropertyItem("ColorBackHover1",
                                 "Color BackHover1", "Appearance",
                                 "Sets the color of the button when hovered."));

            items.Add(new DesignerActionPropertyItem("ColorBackHover2",
                                 "Color BackHover2", "Appearance",
                                 "Sets the color of the button when hovered."));

            items.Add(new DesignerActionPropertyItem("ColorBackPath",
                                 "Color BackPath", "Appearance",
                                 "Sets the color of the border."));

            items.Add(new DesignerActionPropertyItem("ColorText",
                                 "Color Text", "Appearance",
                                 "Sets the forecolor of the text."));

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
