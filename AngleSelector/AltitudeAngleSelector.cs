// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 02-13-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="AltitudeAngleSelector.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitAngleAltitudeSelector

    #region AngleAltitudeSelector

    /// <summary>
    /// A class collection for rendering an angle selector.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitAngleAltitudeSelectorDesigner))]
    public class ZeroitAngleAltitudeSelector : UserControl
    {

        #region Private Field
        /// <summary>
        /// The angle
        /// </summary>
        private int angle;
        /// <summary>
        /// The altitude
        /// </summary>
        private int altitude = 90;

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

        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>The altitude.</value>
        public int Altitude
        {
            get { return altitude; }
            set
            {
                altitude = value;

                if (!this.DesignMode && AltitudeChanged != null)
                    AltitudeChanged(); //Raise event

                this.Refresh();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAngleAltitudeSelector" /> class.
        /// </summary>
        public ZeroitAngleAltitudeSelector()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            BackColor = Color.Transparent;
            this.DoubleBuffered = true;

            //this.setDrawRegion();

            //AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion




        #region Transparency


        #region Include in Paint

        private void TransInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
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

        #region Method

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


        #endregion



        #region Methods and Overrides

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AngleAltitudeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AngleAltitudeSelector";
            this.Size = new System.Drawing.Size(40, 40);
            this.Load += new System.EventHandler(this.AngleAltitudeSelector_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AngleAltitudeSelector_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AngleAltitudeSelector_MouseDown);
            this.SizeChanged += new System.EventHandler(this.AngleAltitudeSelector_SizeChanged);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Handles the Load event of the AngleAltitudeSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AngleAltitudeSelector_Load(object sender, EventArgs e)
        {
            setDrawRegion();
        }

        /// <summary>
        /// Handles the SizeChanged event of the AngleAltitudeSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AngleAltitudeSelector_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.Width;
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
        /// Delegate AltitudeChangedDelegate
        /// </summary>
        public delegate void AltitudeChangedDelegate();
        /// <summary>
        /// Occurs when [altitude changed].
        /// </summary>
        public event AltitudeChangedDelegate AltitudeChanged;

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
        /// Gets the distance.
        /// </summary>
        /// <param name="point1">The point1.</param>
        /// <param name="point2">The point2.</param>
        /// <returns>System.Single.</returns>
        private float getDistance(Point point1, Point point2)
        {
            return (float)Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransInPaint(e.Graphics);

            Graphics g = e.Graphics;

            
            Pen outline = new Pen(_AnglePenColor, 2.0f);
            SolidBrush fill = new SolidBrush(_AngleFillColor);

            float radius = (origin.X * (90.0f - altitude) / 100.0f);

            PointF anglePoint = DegreesToXY(angle, radius, origin);
            Rectangle originSquare = new Rectangle(origin.X - 1, origin.Y - 1, 3, 3);
            Rectangle pointSquare = new Rectangle((int)anglePoint.X, (int)anglePoint.Y, 1, 1);

            //Draw
            g.SmoothingMode = SmoothingMode.AntiAlias; //Smooth edges

            g.DrawEllipse(outline, drawRegion);
            g.FillEllipse(fill, drawRegion);

            g.SmoothingMode = SmoothingMode.HighSpeed; //Make the edges sharp

            //Draw point
            g.FillRectangle(Brushes.Black, pointSquare);

            int leftX0 = pointSquare.X - 3;
            if (leftX0 < 0) leftX0 = 0;

            int leftX = pointSquare.X - 2;
            if (leftX < 0) leftX = 0;

            int rightX0 = pointSquare.X + 2;
            if (rightX0 > drawRegion.Right) rightX0 = drawRegion.Right;

            int rightX = pointSquare.X + 3;
            if (rightX > drawRegion.Right) rightX = drawRegion.Right;

            int topY0 = pointSquare.Y - 3;
            if (topY0 < 0) topY0 = 0;

            int topY = pointSquare.Y - 2;
            if (topY < 0) topY = 0;

            int bottomY0 = pointSquare.Y + 2;
            if (bottomY0 > drawRegion.Bottom) bottomY0 = drawRegion.Bottom;

            int bottomY = pointSquare.Y + 3;
            if (bottomY > drawRegion.Bottom) bottomY = drawRegion.Bottom;

            g.DrawLine(Pens.Black, leftX0, pointSquare.Y, leftX, pointSquare.Y);
            g.DrawLine(Pens.Black, rightX0, pointSquare.Y, rightX, pointSquare.Y);

            g.DrawLine(Pens.Black, pointSquare.X, topY0, pointSquare.X, topY);
            g.DrawLine(Pens.Black, pointSquare.X, bottomY0, pointSquare.X, bottomY);

            g.FillRectangle(Brushes.Black, originSquare);

            fill.Dispose();
            outline.Dispose();

            base.OnPaint(e);
        }

        /// <summary>
        /// Handles the MouseDown event of the AngleAltitudeSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void AngleAltitudeSelector_MouseDown(object sender, MouseEventArgs e)
        {
            int thisAngle = findNearestAngle(new Point(e.X, e.Y));
            int thisAltitude = findAltitude(new Point(e.X, e.Y));

            if (thisAngle != -1)
                this.Angle = thisAngle;

            this.Altitude = thisAltitude;

            this.Refresh();
        }

        /// <summary>
        /// Handles the MouseMove event of the AngleAltitudeSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void AngleAltitudeSelector_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int thisAngle = findNearestAngle(new Point(e.X, e.Y));
                int thisAltitude = findAltitude(new Point(e.X, e.Y));

                if (thisAngle != -1)
                    this.Angle = thisAngle;

                this.Altitude = thisAltitude;

                this.Refresh();
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

        /// <summary>
        /// Finds the altitude.
        /// </summary>
        /// <param name="mouseXY">The mouse xy.</param>
        /// <returns>System.Int32.</returns>
        private int findAltitude(Point mouseXY)
        {
            float distance = getDistance(mouseXY, origin);
            int alt = 90 - (int)(90.0f * (distance / origin.X));
            if (alt < 0) alt = 0;

            return alt;
        }

        #endregion




        

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitAngleAltitudeSelectorDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitAngleAltitudeSelectorDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitAngleAltitudeSelectorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitAngleAltitudeSelectorSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitAngleAltitudeSelectorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitAngleAltitudeSelector colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAngleAltitudeSelectorSmartTagActionList" /> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitAngleAltitudeSelectorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAngleAltitudeSelector;

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

    #endregion
}
