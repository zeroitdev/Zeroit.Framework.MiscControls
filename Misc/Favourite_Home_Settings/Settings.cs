// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Settings.cs" company="Zeroit Dev Technologies">
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
    #region Settings Control

    #region Control
    // ************************************************ class Settings    
    /// <summary>
    /// A class collection for rendering a settings control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitSettingsDesigner))]
    public class ZeroitSettings : Control
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

        // ************************************************* constants

        /// <summary>
        /// The control color
        /// </summary>
        static Color CONTROL_COLOR = Color.White;
        /// <summary>
        /// The control height
        /// </summary>
        const int CONTROL_HEIGHT = 200;
        /// <summary>
        /// The hover color
        /// </summary>
        static Color HOVER_COLOR = Color.LightSkyBlue;
        /// <summary>
        /// The hovering
        /// </summary>
        const bool HOVERING = false;
        /// <summary>
        /// The offset
        /// </summary>
        const int OFFSET = 2;
        /// <summary>
        /// The outline
        /// </summary>
        const bool OUTLINE = true;

        // ******************************* Settings specific constants

        /// <summary>
        /// The degree increment
        /// </summary>
        const int DEGREE_INCREMENT = 45;
        /// <summary>
        /// The inner circle multiplier
        /// </summary>
        const float INNER_CIRCLE_MULTIPLIER = 0.3F;
        // be careful when changing 
        // NUMBER_TEETH as a varying 
        // number of teeth was not 
        // accounted for in code
        /// <summary>
        /// The number teeth
        /// </summary>
        const int NUMBER_TEETH = 8;
        /// <summary>
        /// The outer circle multiplier
        /// </summary>
        const float OUTER_CIRCLE_MULTIPLIER = 0.1F;

        // ************************************************* variables

        /// <summary>
        /// The control brush
        /// </summary>
        Brush control_brush = null;
        /// <summary>
        /// The control color
        /// </summary>
        Color control_color = CONTROL_COLOR;
        /// <summary>
        /// The control height
        /// </summary>
        int control_height = CONTROL_HEIGHT;
        /// <summary>
        /// The control region
        /// </summary>
        Region control_region = null;
        /// <summary>
        /// The hover color
        /// </summary>
        Color hover_color = HOVER_COLOR;
        /// <summary>
        /// The hovering
        /// </summary>
        bool hovering = HOVERING;
        /// <summary>
        /// The outline
        /// </summary>
        bool outline = OUTLINE;

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

        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        /// <summary>
        /// Rounds the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>System.Int32.</returns>
        public static int round(float parameter)
        {

            return ((int)(parameter + 0.5F));
        }

        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        /// <summary>
        /// Rounds the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>System.Int32.</returns>
        public static int round(double parameter)
        {

            return ((int)(parameter + 0.5));
        }

        // ************************************************* deg_2_rad

        /// <summary>
        /// Degs the 2 RAD.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Double.</returns>
        public static double deg_2_rad(int degrees)
        {

            return (((double)degrees / 180.0) *
                     System.Math.PI);
        }

        // *************************************************** cos_deg

        /// <summary>
        /// Coses the deg.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Single.</returns>
        public static float cos_deg(int degrees)
        {

            return ((float)System.Math.Cos(deg_2_rad(
                                                     degrees)));
        }

        // *************************************************** sin_deg

        /// <summary>
        /// Sins the deg.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Single.</returns>
        public static float sin_deg(int degrees)
        {

            return ((float)System.Math.Sin(deg_2_rad(
                                                     degrees)));
        }

        // ************************************* create_annulus_region

        /// <summary>
        /// Creates the annulus region.
        /// </summary>
        /// <param name="control_height">Height of the control.</param>
        /// <returns>Region.</returns>
        Region create_annulus_region(int control_height)
        {
            int diameter = 0;
            GraphicsPath inner_path = new GraphicsPath();
            Region inner_region = null;
            int origin = 0;
            GraphicsPath outer_path = new GraphicsPath();
            Region outer_region = null;
            Rectangle rectangle;
            float scale = 0.0F;
            Matrix transform = new Matrix();

            scale = (float)control_height /
                    (float)CONTROL_HEIGHT;
            transform.Scale(scale, scale);
            // define outer region
            origin = round(OUTER_CIRCLE_MULTIPLIER *
                             (float)CONTROL_HEIGHT) +
                             OFFSET;
            diameter = CONTROL_HEIGHT - 2 * origin;
            rectangle = new Rectangle(
                            new Point(origin,
                                        origin),
                            new Size((diameter - 1),
                                       (diameter - 1)));
            outer_path.AddEllipse(rectangle);
            outer_path.Transform(transform);
            outer_region = new Region(outer_path);
            // define inner region
            origin = round(INNER_CIRCLE_MULTIPLIER *
                             (float)CONTROL_HEIGHT) +
                             OFFSET; ;
            diameter = CONTROL_HEIGHT - 2 * origin;
            rectangle = new Rectangle(
                            new Point(origin,
                                        origin),
                            new Size((diameter - 1),
                                       (diameter - 1)));
            inner_path.AddEllipse(rectangle);
            inner_path.Transform(transform);
            inner_region = new Region(inner_path);
            // exclude inner from outer
            outer_region.Exclude(inner_region);
            // dispose of intermediates
            inner_path.Dispose();
            inner_region.Dispose();
            outer_path.Dispose();
            transform.Dispose();

            return (outer_region);
        }

        // ******************************************** new_gear_tooth

        /// <summary>
        /// News the gear tooth.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>Rectangle.</returns>
        Rectangle new_gear_tooth(int width,
                                   int height)
        {

            return (new Rectangle(0, 0, width, height));
        }

        // *************************************** create_teeth_region

        /// <summary>
        /// Creates the teeth region.
        /// </summary>
        /// <param name="control_height">Height of the control.</param>
        /// <returns>Region.</returns>
        Region create_teeth_region(int control_height)
        {
            Point center;
            int d;
            double height_div_2;
            double height_div_2_squared;
            int radius = 0;
            Region region = new Region();
            float scale = 0.0F;
            int tooth_height;
            int tooth_width;
            float tooth_width_div_2;

            scale = (float)control_height /
                    (float)CONTROL_HEIGHT;

            region.MakeEmpty();       // must do this!!

            radius = round((float)CONTROL_HEIGHT / 2.0F) -
                             OFFSET;
            center = new Point(radius, radius);

            height_div_2 = (double)CONTROL_HEIGHT / 2.0 -
                           2.0 * (double)OFFSET;
            height_div_2_squared = height_div_2 * height_div_2;
            d = round(Math.Sqrt(height_div_2_squared +
                                    height_div_2_squared));
            tooth_height = round((float)d / 2.0F);
            tooth_width = round(0.2F * (float)CONTROL_HEIGHT);
            tooth_width_div_2 = (float)tooth_width / 2.0F;

            for (int i = 0; (i < NUMBER_TEETH); i++)
            {
                // do not move transform or
                // path outside this loop
                int beta = 0;
                Rectangle gear_tooth;
                float offset_x = (float)OFFSET;
                float offset_y = (float)OFFSET;
                GraphicsPath path = new GraphicsPath();
                float rotate = 0.0F;
                Point t = new Point();
                int theta = i * DEGREE_INCREMENT;
                Matrix transform = new Matrix();

                t.X = center.X + round((float)d *
                                         cos_deg(theta));
                t.Y = center.Y + round((float)d *
                                         sin_deg(theta));

                beta = theta - 90;
                if (beta < 0)
                {
                    beta = beta + 360;
                }

                offset_x = (float)t.X + (float)OFFSET +
                           (tooth_width_div_2 *
                           cos_deg(beta));
                offset_y = (float)t.Y + (float)OFFSET +
                           (tooth_width_div_2 *
                           sin_deg(beta));

                rotate = (float)theta + 90.0F;
                if (rotate > 360.0F)
                {
                    rotate = rotate - 360.0F;
                }

                transform.Reset();
                transform.Translate(offset_x, offset_y);
                transform.Rotate(rotate);
                transform.Scale(scale, scale, MatrixOrder.Append);

                gear_tooth = new_gear_tooth(tooth_width,
                                              tooth_height);
                gear_tooth.Inflate(-1, -1);

                path.Reset();
                path.AddRectangle(gear_tooth);
                path.Transform(transform);

                region.Union(path);

                transform.Dispose();
                path.Dispose();
            }

            return (region);
        }

        // ************************************ create_clipping_region

        /// <summary>
        /// Creates the clipping region.
        /// </summary>
        /// <param name="control_height">Height of the control.</param>
        /// <returns>Region.</returns>
        Region create_clipping_region(int control_height)
        {
            int height = CONTROL_HEIGHT - 2 * OFFSET;
            GraphicsPath path = new GraphicsPath();
            Region region = null;
            float scale = 0.0F;
            Matrix transform = new Matrix();

            scale = (float)control_height /
                    (float)CONTROL_HEIGHT;
            transform.Scale(scale, scale);

            path.AddEllipse(new Rectangle(
                                  new Point(OFFSET, OFFSET),
                                  new Size((height - 1),
                                             (height - 1))));
            path.Transform(transform);

            region = new Region(path);

            path.Dispose();
            transform.Dispose();

            return (region);
        }

        // ************************************* create_control_region

        /// <summary>
        /// Creates the control region.
        /// </summary>
        /// <param name="new_height">The new height.</param>
        /// <param name="control_region">The control region.</param>
        /// <returns>Region.</returns>
        Region create_control_region(int new_height,
                                       Region control_region)
        {
            Region annulus_region = null;
            Region clipping_region = null;
            Region teeth_region = null;

            control_height = new_height;
            this.Height = control_height;
            this.Width = control_height;

            annulus_region = create_annulus_region(
                                    control_height);
            teeth_region = create_teeth_region(
                                    control_height);
            clipping_region = create_clipping_region(
                                    control_height);

            if (control_region != null)
            {
                control_region.Dispose();
            }
            control_region = new Region();
            control_region.MakeEmpty();

            control_region.Union(annulus_region);
            control_region.Union(teeth_region);
            control_region.Intersect(clipping_region);

            annulus_region.Dispose();
            annulus_region = null;
            clipping_region.Dispose();
            clipping_region = null;
            teeth_region.Dispose();
            teeth_region = null;

            return (control_region);
        }

        // ************************************************** Settings

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSettings" /> class.
        /// </summary>
        public ZeroitSettings()
        {

            this.SetStyle((ControlStyles.DoubleBuffer |
                              ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint),
                            true);
            this.UpdateStyles();

            this.Disposed += new EventHandler(memory_cleanup);

            control_brush = new SolidBrush(CONTROL_COLOR);
            control_region = create_control_region(CONTROL_HEIGHT,
                                                     control_region);
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
                    control_brush = new SolidBrush(hover_color);
                }
                else
                {
                    control_brush = new SolidBrush(control_color);
                }
                this.Invalidate();
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
            //e.Graphics.FillRegion(control_brush, control_region);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
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
          DefaultValue(typeof(Color), "LightSkyBlue"),
          Bindable(true)]
        public Color HoverColor
        {

            get
            {
                return (hover_color);
            }
            set
            {
                if (value != hover_color)
                {
                    hover_color = value;
                    this.Invalidate();
                }
            }
        }

        // *************************************************** Outline

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitSettings" /> should have an outline drawn.
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

    } // class Settings

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSettingsDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSettingsDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSettingsDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSettingsSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSettingsSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSettingsSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSettings colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSettingsSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSettingsSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSettings;

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
        /// Gets or sets a value indicating whether this <see cref="ZeroitSettingsSmartTagActionList"/> is outline.
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
                                 "Enables the control to have an outline."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ControlColor",
                                 "Control Color", "Appearance",
                                 "Sets the control's color."));

            items.Add(new DesignerActionPropertyItem("Color",
                                 "Color", "Appearance",
                                 "Sets the control's color."));

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
