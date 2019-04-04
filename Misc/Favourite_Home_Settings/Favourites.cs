// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Favourites.cs" company="Zeroit Dev Technologies">
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
    #region Favourites Control

    #region Control
    // *********************************************** class Favorites

    /// <summary>
    /// A class collection for rendering a favorite control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitFavouriteDesigner))]
    public class ZeroitFavourite : Control
    {

        // ******************************** control delegate and event

        /// <summary>
        /// Delegate UserClickedHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void UserClickedHandler(Object sender,
                                                  EventArgs e);

        /// <summary>
        /// Occurs when [user clicked].
        /// </summary>
        public event UserClickedHandler UserClicked;

        // *********************************** constants and variables

        /// <summary>
        /// The control color
        /// </summary>
        static Color CONTROL_COLOR = Color.White;
        /// <summary>
        /// The control color hover
        /// </summary>
        static Color CONTROL_COLOR_HOVER = Color.Gold;
        /// <summary>
        /// The control height
        /// </summary>
        const int CONTROL_HEIGHT = 200;
        /// <summary>
        /// The offset
        /// </summary>
        const int OFFSET = 2;

        // ***********************************************************

        /// <summary>
        /// The control brush
        /// </summary>
        Brush control_brush = null;
        /// <summary>
        /// The control height
        /// </summary>
        int control_height = CONTROL_HEIGHT;
        /// <summary>
        /// The control region
        /// </summary>
        Region control_region = null;
        /// <summary>
        /// The control color
        /// </summary>
        Color control_color = CONTROL_COLOR;
        /// <summary>
        /// The control color hover
        /// </summary>
        Color control_color_hover = CONTROL_COLOR_HOVER;
        /// <summary>
        /// The hovering
        /// </summary>
        bool hovering = false;
        /// <summary>
        /// The outline
        /// </summary>
        bool outline = true;
        /// <summary>
        /// The star
        /// </summary>
        Point[] star = { new Point (  40, 200 ),
                             new Point (  62, 125 ),
                             new Point (   0,  80 ),
                             new Point (  75,  80 ),
                             new Point ( 100,   0 ),
                             new Point ( 125,  80 ),
                             new Point ( 200,  80 ),
                             new Point ( 138, 125 ),
                             new Point ( 160, 200 ),
                             new Point ( 100, 155 ),
                             new Point (  40, 200 ) };

        // ******************************************** memory_cleanup

        /// <summary>
        /// Handles the cleanup event of the memory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void memory_cleanup(object sender,
                              EventArgs e)
        {

            if (control_brush != null)
            {
                control_brush.Dispose();
                control_brush = null;
            }

            if (control_region != null)
            {
                control_region.MakeEmpty();
                control_region.Dispose();
                control_region = null;
            }
        }

        // ************************************* create_control_region

        /// <summary>
        /// Creates the control region.
        /// </summary>
        /// <param name="new_height">The new height.</param>
        /// <param name="points">The points.</param>
        /// <param name="control_region">The control region.</param>
        /// <returns>Region.</returns>
        Region create_control_region(int new_height,
                                       Point[] points,
                                       Region control_region)
        {
            GraphicsPath path = new GraphicsPath();
            float scale = 0.0F;
            Matrix transform = new Matrix();

            control_height = new_height;
            this.Height = control_height;
            this.Width = control_height;

            scale = (float)new_height / (float)CONTROL_HEIGHT;
            transform.Scale(scale, scale);

            path.AddPolygon(points);
            path.Transform(transform);

            if (control_region != null)
            {
                control_region.Dispose();
                control_region = null;
            }
            control_region = new Region(path);

            transform.Dispose();
            path.Dispose();

            return (control_region);
        }

        // ************************************************* Favorites

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFavourite" /> class.
        /// </summary>
        public ZeroitFavourite()
        {

            this.SetStyle(
                (ControlStyles.DoubleBuffer |
                  ControlStyles.UserPaint |
                  ControlStyles.AllPaintingInWmPaint),
                true);
            this.UpdateStyles();

            this.Disposed += new EventHandler(memory_cleanup);

            control_brush = new SolidBrush(CONTROL_COLOR);
            control_region = create_control_region(CONTROL_HEIGHT,
                                                     star,
                                                     control_region);
        }

        // ********************************************** OnMouseLeave

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {

            base.OnMouseLeave(e);

            if (hovering)
            {
                if (control_brush != null)
                {
                    control_brush.Dispose();
                }
                control_brush = new SolidBrush(control_color);
                this.Invalidate();
                hovering = false;
            }
        }

        // *********************************************** OnMouseMove

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool was_hovering = hovering;

            base.OnMouseMove(e);

            hovering = false;
            if (control_region != null)
            {
                hovering = (control_region.IsVisible(
                                 new Point(e.X, e.Y)));
            }

            if (was_hovering != hovering)
            {
                if (control_brush != null)
                {
                    control_brush.Dispose();
                }
                if (hovering)
                {
                    control_brush = new SolidBrush(
                                            control_color_hover);
                }
                else
                {
                    control_brush = new SolidBrush(control_color);
                }
                this.Invalidate();
            }
        }

        // ********************************************** OnMouseClick

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {

            base.OnMouseClick(e);

            if (control_region != null)
            {
                if (control_region.IsVisible(
                         new Point(e.X, e.Y)))
                {
                    if (UserClicked != null)
                    {
                        UserClicked(this, EventArgs.Empty);
                    }
                }
            }
        }

        // *************************************************** OnPaint

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //e.Graphics.FillRegion(control_brush, control_region);

            e.Graphics.FillRegion(new SolidBrush(color), control_region);
            if (Outline)
            {
                FrameRegion.frame_region(e.Graphics,
                                                     control_region);
            }
        }

        // ************************************************** OnResize

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);

            control_region = create_control_region(this.Height,
                                                     star,
                                                     control_region);
            this.Invalidate();
        }

        // ********************************************* ControlColor

        /// <summary>
        /// Gets or sets the color of the control.
        /// </summary>
        /// <value>The color of the control.</value>
        [Category("Appearance"),
          Description("Gets/Sets color of control"),
          DefaultValue(typeof(Color), "White"),
          Bindable(true),
            Browsable(false)]
        public Color ControlColor
        {

            get
            {
                return (control_color);
            }
            set
            {
                if (value != control_color)
                {
                    control_color = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.White;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {

            get
            {
                return (color);
            }
            set
            {
                color = value;
                Invalidate();
            }
        }

        // ******************************************** ControlHeight

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        [Category("Appearance"),
          Description("Gets/Sets control height"),
          DefaultValue(typeof(int), "CONTROL_HEIGHT"),
          Bindable(true)]
        public int ControlHeight
        {

            get
            {
                return (control_height);
            }
            set
            {
                if (value != control_height)
                {
                    control_region = create_control_region(
                                                    value,
                                                    star,
                                                    control_region);
                    this.Invalidate();
                }
            }
        }

        // *********************************************** HoverColor

        /// <summary>
        /// Gets or sets the color of the control when hovered.
        /// </summary>
        /// <value>The color of the control when hovered.</value>
        [Category("Appearance"),
          Description("Gets/Sets color of control when mouse hovers"),
          DefaultValue(typeof(Color), "Gold"),
          Bindable(true)]
        public Color HoverColor
        {

            get
            {
                return (control_color_hover);
            }
            set
            {
                if (value != control_color_hover)
                {
                    control_color_hover = value;
                    this.Invalidate();
                }
            }
        }

        // *************************************************** Outline

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitFavourite" /> should have an outline drawn.
        /// </summary>
        /// <value><c>true</c> if outline; otherwise, <c>false</c>.</value>
        [Category("Appearance"),
          Description("Gets/Sets whether outline is to be drawn"),
          DefaultValue(typeof(bool), "true"),
          Bindable(true)]
        public bool Outline
        {

            get
            {
                return (outline);
            }
            set
            {
                if (value != outline)
                {
                    outline = value;
                    this.Invalidate();
                }
            }
        }

    } // class Favorites

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitFavouriteDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitFavouriteDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitFavouriteDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitFavouriteSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitFavouriteSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitFavouriteSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitFavourite colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFavouriteSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitFavouriteSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitFavourite;

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
        /// Gets or sets the color of the control.
        /// </summary>
        /// <value>The color of the control.</value>
        public Color ControlColor
        {

            get
            {
                return colUserControl.ControlColor;
            }
            set
            {
                GetPropertyByName("ControlColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {

            get
            {
                return colUserControl.Color;
            }
            set
            {
                GetPropertyByName("Color").SetValue(colUserControl, value);
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
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {

            get
            {
                return colUserControl.HoverColor;
            }
            set
            {
                GetPropertyByName("HoverColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitFavouriteSmartTagActionList"/> is outline.
        /// </summary>
        /// <value><c>true</c> if outline; otherwise, <c>false</c>.</value>
        public bool Outline
        {

            get
            {
                return colUserControl.Outline;
            }
            set
            {
                GetPropertyByName("Outline").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("Outline",
                                 "Outline", "Appearance",
                                 "Set to draw a border around the control."));


            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ControlColor",
                                 "Control Color", "Appearance",
                                 "Sets the control color."));

            items.Add(new DesignerActionPropertyItem("Color",
                                 "Color", "Appearance",
                                 "Sets the control color."));


            items.Add(new DesignerActionPropertyItem("ControlHeight",
                                 "Control Height", "Appearance",
                                 "Sets the control height."));

            items.Add(new DesignerActionPropertyItem("HoverColor",
                                 "Hover Color", "Appearance",
                                 "Sets the hover color."));



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
