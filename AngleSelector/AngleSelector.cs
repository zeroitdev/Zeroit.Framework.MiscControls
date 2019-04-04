// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 02-13-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="AngleSelector.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitAngleSelector    
    /// <summary>
    /// A class collection for rendering an angle selector.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitAngleSelectorDesigner))]
    public class ZeroitAngleSelector : UserControl
    {

        #region Private Fields
        /// <summary>
        /// The angle
        /// </summary>
        private int angle;
        /// <summary>
        /// The draw region
        /// </summary>
        private Rectangle drawRegion;
        /// <summary>
        /// The origin
        /// </summary>
        private Point origin;
        /// <summary>
        /// The angle pen color
        /// </summary>
        private Color _AnglePenColor = Color.Gray;
        /// <summary>
        /// The angle fill color
        /// </summary>
        private Color _AngleFillColor = Color.LightGray;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color of the angle border.
        /// </summary>
        /// <value>The color of the angle border.</value>
        public Color AngleBorderColor
        {
            get { return _AnglePenColor; }
            set
            {
                _AnglePenColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the angle fill.
        /// </summary>
        /// <value>The color of the angle fill.</value>
        public Color AngleFillColor
        {
            get { return _AngleFillColor; }
            set
            {
                _AngleFillColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        public int Angle
        {
            get { return angle; }
            set
            {
                angle = value;

                if (!this.DesignMode && AngleChanged != null)
                    AngleChanged(); //Raise event

                this.Refresh();
            }
        }

        #endregion

        #region Constructor  

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAngleSelector" /> class.
        /// </summary>
        public ZeroitAngleSelector()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        #endregion

        #region Methods and overrides

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AngleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AngleSelector";
            this.Size = new System.Drawing.Size(40, 40);
            this.Load += new System.EventHandler(this.AngleSelector_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AngleSelector_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AngleSelector_MouseDown);
            this.SizeChanged += new System.EventHandler(this.AngleSelector_SizeChanged);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Handles the Load event of the AngleSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AngleSelector_Load(object sender, EventArgs e)
        {
            setDrawRegion();
        }

        /// <summary>
        /// Handles the SizeChanged event of the AngleSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AngleSelector_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.Width; //Keep it a square
            setDrawRegion();
        }

        /// <summary>
        /// Sets the draw region.
        /// </summary>
        private void setDrawRegion()
        {
            drawRegion = new Rectangle(0, 0, this.Width, this.Height);
            drawRegion.X += 2;
            drawRegion.Y += 2;
            drawRegion.Width -= 4;
            drawRegion.Height -= 4;

            int offset = 2;
            origin = new Point(drawRegion.Width / 2 + offset, drawRegion.Height / 2 + offset);

            this.Refresh();
        }

        /// <summary>
        /// Delegate AngleChangedDelegate
        /// </summary>
        public delegate void AngleChangedDelegate();
        /// <summary>
        /// Occurs when [angle changed].
        /// </summary>
        public event AngleChangedDelegate AngleChanged;

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>PointF.</returns>
        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            PointF xy = new PointF();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (float)Math.Cos(radians) * radius + origin.X;
            xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;

            return xy;
        }

        /// <summary>
        /// Xies to degrees.
        /// </summary>
        /// <param name="xy">The xy.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>System.Single.</returns>
        private float XYToDegrees(Point xy, Point origin)
        {
            double angle = 0.0;

            if (xy.Y < origin.Y)
            {
                if (xy.X > origin.X)
                {
                    angle = (double)(xy.X - origin.X) / (double)(origin.Y - xy.Y);
                    angle = Math.Atan(angle);
                    angle = 90.0 - angle * 180.0 / Math.PI;
                }
                else if (xy.X < origin.X)
                {
                    angle = (double)(origin.X - xy.X) / (double)(origin.Y - xy.Y);
                    angle = Math.Atan(-angle);
                    angle = 90.0 - angle * 180.0 / Math.PI;
                }
            }
            else if (xy.Y > origin.Y)
            {
                if (xy.X > origin.X)
                {
                    angle = (double)(xy.X - origin.X) / (double)(xy.Y - origin.Y);
                    angle = Math.Atan(-angle);
                    angle = 270.0 - angle * 180.0 / Math.PI;
                }
                else if (xy.X < origin.X)
                {
                    angle = (double)(origin.X - xy.X) / (double)(xy.Y - origin.Y);
                    angle = Math.Atan(angle);
                    angle = 270.0 - angle * 180.0 / Math.PI;
                }
            }

            if (angle > 180) angle -= 360; //Optional. Keeps values between -180 and 180
            return (float)angle;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }

            Pen outline = new Pen(_AnglePenColor, 2.0f);
            SolidBrush fill = new SolidBrush(_AngleFillColor);

            PointF anglePoint = DegreesToXY(angle, origin.X - 2, origin);
            Rectangle originSquare = new Rectangle(origin.X - 1, origin.Y - 1, 3, 3);

            //Draw
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(outline, drawRegion);
            g.FillEllipse(fill, drawRegion);
            g.DrawLine(Pens.Black, origin, anglePoint);

            g.SmoothingMode = SmoothingMode.HighSpeed; //Make the square edges sharp
            g.FillRectangle(Brushes.Black, originSquare);

            fill.Dispose();
            outline.Dispose();

            base.OnPaint(e);
        }

        /// <summary>
        /// Handles the MouseDown event of the AngleSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void AngleSelector_MouseDown(object sender, MouseEventArgs e)
        {
            int thisAngle = findNearestAngle(new Point(e.X, e.Y));

            if (thisAngle != -1)
            {
                this.Angle = thisAngle;
                this.Refresh();
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the AngleSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void AngleSelector_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int thisAngle = findNearestAngle(new Point(e.X, e.Y));

                if (thisAngle != -1)
                {
                    this.Angle = thisAngle;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Finds the nearest angle.
        /// </summary>
        /// <param name="mouseXY">The mouse xy.</param>
        /// <returns>System.Int32.</returns>
        private int findNearestAngle(Point mouseXY)
        {
            int thisAngle = (int)XYToDegrees(mouseXY, origin);
            if (thisAngle != 0)
                return thisAngle;
            else
                return -1;
        }
        #endregion


        
        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        
        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion




    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitAngleSelectorDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitAngleSelectorDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitAngleSelectorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitAngleSelectorSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitAngleSelectorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitAngleSelector colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAngleSelectorSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitAngleSelectorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAngleSelector;

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
        /// Gets or sets the color of the angle border.
        /// </summary>
        /// <value>The color of the angle border.</value>
        public Color AngleBorderColor
        {
            get
            {
                return colUserControl.AngleBorderColor;
            }
            set
            {
                GetPropertyByName("AngleBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the angle fill.
        /// </summary>
        /// <value>The color of the angle fill.</value>
        public Color AngleFillColor
        {
            get
            {
                return colUserControl.AngleFillColor;
            }
            set
            {
                GetPropertyByName("AngleFillColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("AngleBorderColor",
                                 "Angle Pen Color", "Appearance",
                                 "Sets the color of the pen."));

            items.Add(new DesignerActionPropertyItem("AngleFillColor",
                                 "Angle Fill Color", "Appearance",
                                 "Sets the inner-fill color."));

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
