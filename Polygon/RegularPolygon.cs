// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RegularPolygon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Regular Polygon

    /// <summary>
    /// A class collection for creating a polygon control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitControlPolygonDesigner))]
    public class ZeroitControlPolygon : Control
    {
        #region Variables
        /// <summary>
        /// The star brush
        /// </summary>
        private PolygonBrush starBrush = PolygonBrush.SolidBrush;
        /// <summary>
        /// The polygon color1
        /// </summary>
        private Color _PolygonColor1 = Color.Gray;
        /// <summary>
        /// The polygon color2
        /// </summary>
        private Color _PolygonColor2 = Color.LightGray;
        /// <summary>
        /// The polygon hover color
        /// </summary>
        private Color _PolygonHoverColor = Color.Yellow;
        /// <summary>
        /// The polygon pressed color
        /// </summary>
        private Color _PolygonPressedColor = Color.Green;
        /// <summary>
        /// The polygon leave color
        /// </summary>
        private Color _PolygonLeaveColor = Color.Black;
        /// <summary>
        /// The polygon color default
        /// </summary>
        private Color _PolygonColorDefault = Color.Gray;
        /// <summary>
        /// The polygon pen color
        /// </summary>
        private Color _PolygonPenColor = Color.DarkGray;
        /// <summary>
        /// The polygon pen width
        /// </summary>
        private float _PolygonPenWidth = 1;
        /// <summary>
        /// The polygon smoothing
        /// </summary>
        private SmoothingMode _PolygonSmoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 10;
        /// <summary>
        /// The starting angle
        /// </summary>
        private int startingAngle = 90;
        /// <summary>
        /// The center
        /// </summary>
        Point center;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the polygon sides.
        /// </summary>
        /// <value>The polygon sides.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 3.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Minimum - Value cannot go below 3.</exception>
        public int PolygonSides
        {
            get { return sides; }
            set
            {
                if (value < 3)
                {
                    sides = 3;
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 3.");
                }
                sides = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon radius.
        /// </summary>
        /// <value>The polygon radius.</value>
        public int PolygonRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon starting angle.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public int PolygonStartingAngle
        {
            get { return startingAngle; }
            set
            {
                startingAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the polygon border.
        /// </summary>
        /// <value>The color of the polygon border.</value>
        public Color PolygonPenColor
        {
            get { return _PolygonPenColor; }
            set
            {
                _PolygonPenColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the polygon border.
        /// </summary>
        /// <value>The width of the polygon border.</value>
        public float PolygonPenWidth
        {
            get { return _PolygonPenWidth; }
            set
            {
                _PolygonPenWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon color.
        /// </summary>
        /// <value>The polygon color1.</value>
        public Color PolygonColor1
        {
            get
            {
                return this._PolygonColor1;
            }

            set
            {
                this._PolygonColor1 = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the polygon color leave.
        /// </summary>
        /// <value>The polygon color leave.</value>
        public Color PolygonColorLeave
        {
            get
            {
                return this._PolygonLeaveColor;
            }

            set
            {
                this._PolygonLeaveColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the polygon color.
        /// </summary>
        /// <value>The polygon color2.</value>
        public Color PolygonColor2
        {
            get
            {
                return this._PolygonColor2;
            }

            set
            {
                this._PolygonColor2 = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the polygon color when hovered.
        /// </summary>
        /// <value>The polygon color when hovered.</value>
        public Color PolygonColorHover
        {
            get
            {
                return this._PolygonHoverColor;
            }

            set
            {
                this._PolygonHoverColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the polygon color when pressed.
        /// </summary>
        /// <value>The polygon color when pressed.</value>
        public Color PolygonColorPressed
        {
            get
            {
                return this._PolygonPressedColor;
            }

            set
            {
                this._PolygonPressedColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the default polygon color.
        /// </summary>
        /// <value>The default polygon color.</value>
        public Color PolygonColorDefault
        {
            get
            {
                return this._PolygonColorDefault;
            }

            set
            {
                this._PolygonColorDefault = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the polygon smoothing.
        /// </summary>
        /// <value>The polygon smoothing.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - This causes errors so value will be set to High Quality</exception>
        /// <exception cref="ArgumentOutOfRangeException">Minimum - This causes errors so value will be set to High Quality</exception>
        public SmoothingMode PolygonSmoothing
        {
            get { return this._PolygonSmoothing; }
            set
            {
                if (value == SmoothingMode.Invalid)
                {
                    _PolygonSmoothing = SmoothingMode.HighQuality;
                    throw new ArgumentOutOfRangeException("Minimum", "This causes errors so value will be set to High Quality");
                }
                this._PolygonSmoothing = value;
                this.Invalidate();
            }
        }

        #endregion
        /// <summary>
        /// Enum representing the polygon brush
        /// </summary>
        public enum PolygonBrush
        {
            /// <summary>
            /// The solid brush
            /// </summary>
            SolidBrush,
            /// <summary>
            /// The hatch brush
            /// </summary>
            HatchBrush,
            /// <summary>
            /// The gradient brush
            /// </summary>
            GradientBrush,
            /// <summary>
            /// The pen
            /// </summary>
            Pen

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlPolygon" /> class.
        /// </summary>
        public ZeroitControlPolygon() // contructor
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            //InitializeComponent
            BackColor = Color.Transparent;
            this.Text = "My drawings"; // title of window form
            this.Size = new Size(40, 40); // size of window form
            //this.Paint += new PaintEventHandler(MyPainting); // install handler
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            radius = (Width / 2);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _PolygonColor1 = _PolygonHoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            _PolygonColor1 = _PolygonPressedColor;
            _PolygonLeaveColor = _PolygonPressedColor;
            this.Invalidate();
        }



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            center = new Point(this.Width / 2, this.Height / 2);

            Graphics G = e.Graphics;
            G.SmoothingMode = _PolygonSmoothing;
            // init 4 stars


            Point[] PolyGon1 = CalculateVertices(sides, radius, startingAngle, center);
            SolidBrush FillBrush = new SolidBrush(_PolygonColor1);
            G.FillPolygon(FillBrush, PolyGon1);
            G.DrawPolygon(new Pen(_PolygonPenColor, _PolygonPenWidth), PolyGon1);

        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 sides or more.</exception>
        private Point[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Point.</returns>
        private Point DegreesToXY(float degrees, float radius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitControlPolygonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitControlPolygonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitControlPolygonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitControlPolygonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitControlPolygonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitControlPolygon colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlPolygonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitControlPolygonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitControlPolygon;

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
        /// Gets or sets the color of the polygon pen.
        /// </summary>
        /// <value>The color of the polygon pen.</value>
        public Color PolygonPenColor
        {
            get
            {
                return colUserControl.PolygonPenColor;
            }
            set
            {
                GetPropertyByName("PolygonPenColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the polygon color1.
        /// </summary>
        /// <value>The polygon color1.</value>
        public Color PolygonColor1
        {
            get
            {
                return colUserControl.PolygonColor1;
            }
            set
            {
                GetPropertyByName("PolygonColor1").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon color leave.
        /// </summary>
        /// <value>The polygon color leave.</value>
        public Color PolygonColorLeave
        {
            get
            {
                return colUserControl.PolygonColorLeave;
            }
            set
            {
                GetPropertyByName("PolygonColorLeave").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon color2.
        /// </summary>
        /// <value>The polygon color2.</value>
        public Color PolygonColor2
        {
            get
            {
                return colUserControl.PolygonColor2;
            }
            set
            {
                GetPropertyByName("PolygonColor2").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon color hover.
        /// </summary>
        /// <value>The polygon color hover.</value>
        public Color PolygonColorHover
        {
            get
            {
                return colUserControl.PolygonColorHover;
            }
            set
            {
                GetPropertyByName("PolygonColorHover").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon color pressed.
        /// </summary>
        /// <value>The polygon color pressed.</value>
        public Color PolygonColorPressed
        {
            get
            {
                return colUserControl.PolygonColorPressed;
            }
            set
            {
                GetPropertyByName("PolygonColorPressed").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon color default.
        /// </summary>
        /// <value>The polygon color default.</value>
        public Color PolygonColorDefault
        {
            get
            {
                return colUserControl.PolygonColorDefault;
            }
            set
            {
                GetPropertyByName("PolygonColorDefault").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the polygon sides.
        /// </summary>
        /// <value>The polygon sides.</value>
        public int PolygonSides
        {
            get
            {
                return colUserControl.PolygonSides;
            }
            set
            {
                GetPropertyByName("PolygonSides").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the polygon radius.
        /// </summary>
        /// <value>The polygon radius.</value>
        public int PolygonRadius
        {
            get
            {
                return colUserControl.PolygonRadius;
            }
            set
            {
                GetPropertyByName("PolygonRadius").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the polygon starting angle.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public int PolygonStartingAngle
        {
            get
            {
                return colUserControl.PolygonStartingAngle;
            }
            set
            {
                GetPropertyByName("PolygonStartingAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the polygon pen.
        /// </summary>
        /// <value>The width of the polygon pen.</value>
        public float PolygonPenWidth
        {
            get
            {
                return colUserControl.PolygonPenWidth;
            }
            set
            {
                GetPropertyByName("PolygonPenWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the polygon smoothing.
        /// </summary>
        /// <value>The polygon smoothing.</value>
        public SmoothingMode PolygonSmoothing
        {
            get
            {
                return colUserControl.PolygonSmoothing;
            }
            set
            {
                GetPropertyByName("PolygonSmoothing").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Sets the BackColor."));

            items.Add(new DesignerActionPropertyItem("PolygonPenColor",
                                 "Polygon Pen Color", "Appearance",
                                 "Sets the Pen color to draw the border."));

            items.Add(new DesignerActionPropertyItem("PolygonColor1",
                                 "Polygon Color1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("PolygonColor2",
                                 "Polygon Color2", "Appearance",
                                 "Sets the polygon color."));

            items.Add(new DesignerActionPropertyItem("PolygonColorLeave",
                                 "Polygon Color Leave", "Appearance",
                                 "Sets the polygon color."));

            items.Add(new DesignerActionPropertyItem("PolygonColorHover",
                                 "Polygon Color Hover", "Appearance",
                                 "Sets the polygon color when the mouse enters."));

            items.Add(new DesignerActionPropertyItem("PolygonColorPressed",
                                 "Polygon Color Pressed", "Appearance",
                                 "Sets the polygon color when the mouse is pressed."));

            //items.Add(new DesignerActionPropertyItem("PolygonColorDefault",
            //                     "Polygon Color Default", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("PolygonSides",
                                 "Polygon Sides", "Appearance",
                                 "Sets the polygon sides."));

            items.Add(new DesignerActionPropertyItem("PolygonRadius",
                                 "Polygon Radius", "Appearance",
                                 "Sets the polygon radius."));

            items.Add(new DesignerActionPropertyItem("PolygonStartingAngle",
                                 "Polygon Starting Angle", "Appearance",
                                 "Sets the starting angle to draw the polygon."));

            items.Add(new DesignerActionPropertyItem("PolygonPenWidth",
                                 "Polygon Pen Width", "Appearance",
                                 "Sets the width of the border."));

            items.Add(new DesignerActionPropertyItem("PolygonSmoothing",
                                 "Polygon Smoothing", "Appearance",
                                 "Sets the Smoothing Mode."));

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
