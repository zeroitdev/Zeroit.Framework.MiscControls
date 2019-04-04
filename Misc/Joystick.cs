// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Joystick.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region JoyStick Controls

    #region Joystick

    /// <summary>
    /// Enum representing the compass points
    /// </summary>
    public enum CompassPoints
    {
        /// <summary>
        /// The north
        /// </summary>
        north,
        /// <summary>
        /// The northeast
        /// </summary>
        northeast,
        /// <summary>
        /// The east
        /// </summary>
        east,
        /// <summary>
        /// The southeast
        /// </summary>
        southeast,
        /// <summary>
        /// The south
        /// </summary>
        south,
        /// <summary>
        /// The southwest
        /// </summary>
        southwest,
        /// <summary>
        /// The west
        /// </summary>
        west,
        /// <summary>
        /// The northwest
        /// </summary>
        northwest
    }
    /// <summary>
    /// Delegate MouseNowInside
    /// </summary>
    public delegate void MouseNowInside();
    /// <summary>
    /// Delegate MouseNowOutside
    /// </summary>
    public delegate void MouseNowOutside();
    /// <summary>
    /// Delegate MouseMoving
    /// </summary>
    /// <param name="orientation">The orientation.</param>
    /// <param name="magnitude">The magnitude.</param>
    public delegate void MouseMoving(CompassPoints orientation, int magnitude);

    /// <summary>
    /// A class collection for dealing with Joystick controls.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public class JoyStickControl : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The mouse point
        /// </summary>
        private System.Drawing.Point mousePoint;
        /// <summary>
        /// The old mouse point
        /// </summary>
        private System.Drawing.Point oldMousePoint;
        /// <summary>
        /// The center pt
        /// </summary>
        private System.Drawing.Point centerPt;
        /// <summary>
        /// The line color
        /// </summary>
        private System.Drawing.Color lineColor;
        /// <summary>
        /// The ray width
        /// </summary>
        private float rayWidth;
        /// <summary>
        /// The ray cap
        /// </summary>
        private System.Drawing.Drawing2D.LineCap rayCap;
        /// <summary>
        /// The mouse in
        /// </summary>
        private bool mouseIn;

        /// <summary>
        /// Occurs when [mouse enter event].
        /// </summary>
        public event MouseNowInside MouseEnterEvent;
        /// <summary>
        /// Occurs when [mouse leave event].
        /// </summary>
        public event MouseNowOutside MouseLeaveEvent;
        /// <summary>
        /// Occurs when [mouse moving event].
        /// </summary>
        public event MouseMoving MouseMovingEvent;
        /// <summary>
        /// The movement size scaling
        /// </summary>
        public double movementSizeScaling;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoyStickControl" /> class.
        /// </summary>
        public JoyStickControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            this.centerPt = new Point(this.Width / 2, this.Height / 2);
            this.mousePoint = new Point(0, 0);
            this.oldMousePoint = new Point(0, 0);
            this.mouseIn = false;
            this.BackColor = System.Drawing.Color.Black;
            this.lineColor = System.Drawing.Color.Red;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.rayCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            this.rayWidth = 12;
            this.movementSizeScaling = ((double)this.Width) / 30;
            this.Resize += new System.EventHandler(this.resizeAdjustScaling);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
            // 
            // JoyStickControl
            // 
            this.Name = "JoyStickControl";
            this.Size = new System.Drawing.Size(200, 200);
            this.Resize += new System.EventHandler(this.resizeAdjustScaling);
            this.MouseEnter += new System.EventHandler(this.MouseInside);
            this.ParentChanged += new System.EventHandler(this.resizeAdjustScaling);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoving);
            this.MouseLeave += new System.EventHandler(this.MouseOutside);

        }
        #endregion


        #region Methods

        /// <summary>
        /// Finds the orientation.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>CompassPoints.</returns>
        private CompassPoints FindOrientation(double x, double y)
        {
            double angle;
            double radians;

            //get the radians
            radians = Math.Atan2(y, x);
            /// convert radians to angle, just 'cause I'm too lazy to deal with
            /// real radians.
            radians = radians + Math.PI;
            angle = radians * (180 / Math.PI);
            if (angle >= 293 && angle < 338)
            {
                return CompassPoints.southwest;
            }
            else if (angle >= 23 && angle < 68)
            {
                return CompassPoints.northwest;
            }
            else if (angle >= 68 && angle < 113)
            {
                return CompassPoints.north;
            }
            else if (angle >= 113 && angle < 158)
            {
                return CompassPoints.northeast;
            }
            else if (angle >= 158 && angle < 203)
            {
                return CompassPoints.east;
            }
            else if (angle >= 203 && angle < 248)
            {
                return CompassPoints.southeast;
            }
            else if (angle >= 248 && angle < 293)
            {
                return CompassPoints.south;
            }
            else
            {
                return CompassPoints.west;
            }
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (GraphicsPath gp = new GraphicsPath())
            {
                /// We choose the area of the control that we want to deal with--
                /// by setting the region we don't have to worry about the part
                /// of the control outside the circle.
                gp.AddEllipse(this.ClientRectangle);
                this.Region = new Region(gp);
                using (Pen pen = new Pen(this.lineColor, this.rayWidth / 2))
                {
                    /// Make a little cross hair in the center
                    g.DrawLine(pen, this.centerPt.X, this.centerPt.Y - 5, this.centerPt.X, this.centerPt.Y + 5);
                    g.DrawLine(pen, this.centerPt.X - 5, this.centerPt.Y, this.centerPt.X + 5, this.centerPt.Y);

                    /// if the mouse is inside our region, we draw a line to 
                    /// the mouse pointer.  With a cute endcap.
                    if (this.mouseIn)
                    {
                        pen.Width = this.rayWidth;
                        pen.EndCap = this.RayCap;
                        g.DrawLine(pen, this.centerPt, this.mousePoint);
                        this.oldMousePoint = this.mousePoint;
                    }
                }
            }
        }

        /// <summary>
        /// Mouses the inside.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MouseInside(object sender, System.EventArgs e)
        {
            this.mouseIn = true;
            /// Let anybody who cares know that the mouse is inside--not really
            /// necessary as it turns out.
            if (this.MouseEnterEvent != null)
                this.MouseEnterEvent();
        }

        /// <summary>
        /// Mouses the outside.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MouseOutside(object sender, System.EventArgs e)
        {
            this.mouseIn = false;
            /// Let anybody who cares know that the mouse is no longer inside--
            /// not really necessary as it turns out.
            if (this.MouseLeaveEvent != null)
                this.MouseLeaveEvent();
            this.Refresh();
        }

        /// <summary>
        /// Mouses the moving.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void MouseMoving(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.X != this.oldMousePoint.X || e.X != this.oldMousePoint.X)
            {
                this.mousePoint = new Point(e.X, e.Y);
                this.Refresh();
                double movX = (double)(this.mousePoint.X - this.centerPt.X) / this.movementSizeScaling;
                double movY = (double)(this.mousePoint.Y - this.centerPt.X) / this.movementSizeScaling;
                double mag = Math.Sqrt(Math.Pow(movX, 2) + Math.Pow(movY, 2));
                if (mag > 15)
                    mag = 15;
                mag = Math.Round(mag, 0);
                if (this.MouseMovingEvent != null)
                    /// We want to return a sort of 2d vector, in the form of an orientation
                    /// and a magnitude that the client app can use to move something.
                    this.MouseMovingEvent(this.FindOrientation(movX, movY), (int)mag);
            }
        }

        /// <summary>
        /// Resizes the adjust scaling.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void resizeAdjustScaling(object sender, System.EventArgs e)
        {
            /// First, make sure it's still a circle!
            if (this.Width > this.Height)
                this.Width = this.Height;
            if (this.Width < this.Height)
                this.Height = this.Width;
            if (this.centerPt.X != this.Width / 2)
                this.centerPt = new Point(this.Width / 2, this.Height / 2);
            /// now we make sure that scaling still works, so that we produce 
            /// a maximum radius of 15
            this.movementSizeScaling = ((double)this.Width) / 30;
        }

        #endregion


        #region Properties        
        /// <summary>
        /// Gets or sets the color of the ray.
        /// </summary>
        /// <value>The color of the ray.</value>
        [
        CategoryAttribute("Appearance"),
        DescriptionAttribute("Color of joystick ray")
        ]
        public Color RayColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the ray.
        /// </summary>
        /// <value>The width of the ray.</value>
        [
        CategoryAttribute("Appearance"),
        DescriptionAttribute("Width of joystick ray")
        ]
        public float RayWidth
        {
            get { return this.rayWidth; }
            set
            {
                this.rayWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the ray cap.
        /// </summary>
        /// <value>The ray cap.</value>
        [
        CategoryAttribute("Appearance"),
        DescriptionAttribute("LineCap at end of joystick ray")
        ]
        public System.Drawing.Drawing2D.LineCap RayCap
        {
            get { return this.rayCap; }
            set
            {
                this.rayCap = value;
            }
        }



        #endregion
    }

    #endregion

    #region Vehicle

    /// <summary>
    /// A class collection for manipulating Joystick.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />

    [ToolboxItem(false)]
    public class Vehicle : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// The orientation
        /// </summary>
        private CompassPoints orientation;
        /// <summary>
        /// The magnitude
        /// </summary>
        private double magnitude;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        public Vehicle()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.orientation = CompassPoints.north;
            this.magnitude = 0;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Vehicle(int x, int y, int width, int height)
        {
            this.InitializeComponent();
            this.Location = new System.Drawing.Point(x, y);


            this.Width = width;
            this.Height = height;
            this.orientation = CompassPoints.north;
            this.magnitude = 0;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
            // 
            // Vehicle
            // 
            this.BackColor = System.Drawing.Color.IndianRed;
            this.Location = new System.Drawing.Point(150, 150);
            this.Name = "Vehicle";
            this.Size = new System.Drawing.Size(4, 4);

        }
        #endregion

        /// <summary>
        /// Offsets the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="magnitude">The magnitude.</param>
        public void Offset(CompassPoints orientation, int magnitude)
        {
            this.orientation = orientation;
            this.magnitude = (double)magnitude;
            switch (orientation)
            {
                case CompassPoints.north:
                    this.Location = new Point(this.Location.X, this.Location.Y - (int)this.magnitude);
                    break;
                case CompassPoints.northeast:
                    this.Location = new Point(this.Location.X + ((int)Math.Round(Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2), 0)), this.Location.Y + (int)-Math.Round((Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2)), 0));
                    break;
                case CompassPoints.east:
                    this.Location = new Point(this.Location.X + magnitude, this.Location.Y);
                    break;
                case CompassPoints.southeast:
                    this.Location = new Point(this.Location.X + (int)Math.Round(Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2), 0), this.Location.Y + (int)Math.Round(Math.Sqrt((Math.Pow(this.magnitude, 2) / 2)), 0));

                    break;
                case CompassPoints.south:
                    this.Location = new Point(this.Location.X, this.Location.Y + (magnitude));

                    break;
                case CompassPoints.southwest:
                    this.Location = new Point(this.Location.X + (int)-Math.Round(Math.Sqrt(Math.Pow(this.magnitude, 2) / 2), 0), this.Location.Y + (int)Math.Round((Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2)), 0));

                    break;
                case CompassPoints.west:
                    this.Location = new Point(this.Location.X - (magnitude), this.Location.Y);

                    break;
                case CompassPoints.northwest:
                    this.Location = new Point(this.Location.X + (int)-Math.Round(Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2), 0), this.Location.Y + (int)-Math.Round(Math.Sqrt((Math.Pow(this.magnitude, 2)) / 2), 0));

                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public CompassPoints Orientation
        {
            get { return orientation; }
            set
            {
                this.orientation = value;
            }
        }

        /// <summary>
        /// Gets or sets the magnitude.
        /// </summary>
        /// <value>The magnitude.</value>
        public int Magnitude
        {
            get { return (int)Math.Round(this.magnitude, 0); }
            set
            {
                this.magnitude = (double)value;
            }
        }
    }

    #endregion

    #endregion
}
