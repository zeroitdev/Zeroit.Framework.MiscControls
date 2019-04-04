// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RectTracker.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region RectTracker

    /// <summary>
    /// A class collection for rendering a tracker.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitTracker : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        //original rect
        /// <summary>
        /// The base rect
        /// </summary>
        Rectangle baseRect;

        //new rect with bounds
        /// <summary>
        /// The control rect
        /// </summary>
        Rectangle ControlRect;

        //all small rects
        /// <summary>
        /// The small rect
        /// </summary>
        Rectangle[] SmallRect = new Rectangle[8];

        //sqare size
        /// <summary>
        /// The sqare
        /// </summary>
        Size Sqare = new Size(6, 6);

        //graphics object
        /// <summary>
        /// The g
        /// </summary>
        Graphics g;

        //the control that is tracked
        /// <summary>
        /// The current control
        /// </summary>
        Control currentControl;

        // To store the location of previous mouse left click in the form
        // so that we can use it to calculate the new form location during dragging
        /// <summary>
        /// The previous left click
        /// </summary>
        private Point prevLeftClick;

        // To determine if it is the first time entry for every dragging of the form
        /// <summary>
        /// The is first
        /// </summary>
        private bool isFirst = true;

        //defines the color surrounding the tracker
        /// <summary>
        /// My back color
        /// </summary>
        Color MyBackColor;

        //defines the color of the sqares
        /// <summary>
        /// The sqare color
        /// </summary>
        Color SqareColor = Color.White;

        //defines the line color of the sqares 
        /// <summary>
        /// The sqare line color
        /// </summary>
        Color SqareLineColor = Color.Black;

        //The Control the tracker is used on         
        /// <summary>
        /// Gets or sets the control the tracker is used on.
        /// </summary>
        /// <value>The control.</value>
        public Control Control
        {
            get { return currentControl; }
            set
            {
                currentControl = value;
                Rect = currentControl.Bounds;
                Invalidate();
            }
        }

        /// <summary>
        /// Keep track of which border of the box is to be resized.
        /// </summary>
        enum ResizeBorder
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The top
            /// </summary>
            Top = 1,
            /// <summary>
            /// The right
            /// </summary>
            Right = 2,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom = 3,
            /// <summary>
            /// The left
            /// </summary>
            Left = 4,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 5,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 6,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 7,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 8
        }

        //currently resize mouse location
        /// <summary>
        /// The curr border
        /// </summary>
        private ResizeBorder CurrBorder;

        /// <summary>
        /// The current position of the rectangle in client coordinates (pixels).
        /// </summary>
        /// <value>The rect.</value>
        public Rectangle Rect
        {
            get { return baseRect; }
            set
            {
                int X = Sqare.Width;
                int Y = Sqare.Height;
                int Height = value.Height;
                int Width = value.Width;
                baseRect = new Rectangle(X, Y, Width, Height);
                SetRectangles();
            }

        }


        /// <summary>
        /// Set the Sqares positions
        /// </summary>
        void SetRectangles()
        {
            //TopLeft
            SmallRect[0] = new Rectangle(new Point(baseRect.X - Sqare.Width, baseRect.Y - Sqare.Height), Sqare);
            //TopRight
            SmallRect[1] = new Rectangle(new Point(baseRect.X + baseRect.Width, baseRect.Y - Sqare.Height), Sqare);
            //BottomLeft
            SmallRect[2] = new Rectangle(new Point(baseRect.X - Sqare.Width, baseRect.Y + baseRect.Height), Sqare);
            //BottomRight
            SmallRect[3] = new Rectangle(new Point(baseRect.X + baseRect.Width, baseRect.Y + baseRect.Height), Sqare);
            //TopMiddle
            SmallRect[4] = new Rectangle(new Point(baseRect.X + (baseRect.Width / 2) - (Sqare.Width / 2), baseRect.Y - Sqare.Height), Sqare);
            //BottomMiddle
            SmallRect[5] = new Rectangle(new Point(baseRect.X + (baseRect.Width / 2) - (Sqare.Width / 2), baseRect.Y + baseRect.Height), Sqare);
            //LeftMiddle
            SmallRect[6] = new Rectangle(new Point(baseRect.X - Sqare.Width, baseRect.Y + (baseRect.Height / 2) - (Sqare.Height / 2)), Sqare);
            //RightMiddle
            SmallRect[7] = new Rectangle(new Point(baseRect.X + baseRect.Width, baseRect.Y + (baseRect.Height / 2) - (Sqare.Height / 2)), Sqare);

            //the whole tracker rect
            ControlRect = new Rectangle(new Point(0, 0), this.Bounds.Size);
        }

        /// <summary>
        /// Draws Sqares
        /// </summary>
        private void Draw()
        {
            try
            {
                //draw sqares
                g.FillRectangles(Brushes.White, SmallRect);
                //fill sqares
                g.DrawRectangles(Pens.Black, SmallRect);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Check point position to see if it's on tracker
        /// </summary>
        /// <param name="point">Current Point Position</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Hit_Test(Point point)
        {
            //Check if the point is somewhere on the tracker
            if (!ControlRect.Contains(point))
            {
                //should never happen
                Cursor.Current = Cursors.Arrow;

                return false;
            }
            else if (SmallRect[0].Contains(point))
            {
                Cursor.Current = Cursors.SizeNWSE;
                CurrBorder = ResizeBorder.TopLeft;
            }
            else if (SmallRect[3].Contains(point))
            {
                Cursor.Current = Cursors.SizeNWSE;
                CurrBorder = ResizeBorder.BottomRight;
            }
            else if (SmallRect[1].Contains(point))
            {
                Cursor.Current = Cursors.SizeNESW;
                CurrBorder = ResizeBorder.TopRight;
            }
            else if (SmallRect[2].Contains(point))
            {
                Cursor.Current = Cursors.SizeNESW;
                CurrBorder = ResizeBorder.BottomLeft;
            }
            else if (SmallRect[4].Contains(point))
            {
                Cursor.Current = Cursors.SizeNS;
                CurrBorder = ResizeBorder.Top;
            }
            else if (SmallRect[5].Contains(point))
            {
                Cursor.Current = Cursors.SizeNS;
                CurrBorder = ResizeBorder.Bottom;
            }
            else if (SmallRect[6].Contains(point))
            {
                Cursor.Current = Cursors.SizeWE;
                CurrBorder = ResizeBorder.Left;
            }
            else if (SmallRect[7].Contains(point))
            {
                Cursor.Current = Cursors.SizeWE;
                CurrBorder = ResizeBorder.Right;
            }
            else if (ControlRect.Contains(point))
            {
                Cursor.Current = Cursors.SizeAll;
                CurrBorder = ResizeBorder.None;

            }


            return true;
        }

        /// <summary>
        /// Check point position to see if it's on tracker
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Hit_Test(int x, int y)
        {
            return Hit_Test(new Point(x, y));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTracker" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public ZeroitTracker(Control control)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            //set the tracked control 
            currentControl = control;

            //Create the tracker
            Create();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTracker" /> class.
        /// </summary>
        public ZeroitTracker()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Setup the tracker
        /// </summary>
        private void Create()
        {
            //create tracker bounds
            int X = currentControl.Bounds.X - Sqare.Width;
            int Y = currentControl.Bounds.Y - Sqare.Height;
            int Height = currentControl.Bounds.Height + (Sqare.Height * 2);
            int Width = currentControl.Bounds.Width + (Sqare.Width * 2);

            //set bounds
            this.Bounds = new Rectangle(X, Y, Width + 1, Height + 1);

            this.BringToFront();

            //create inside rect bounds
            Rect = currentControl.Bounds;

            //create transparent area around the control
            this.Region = new Region(BuildFrame());

            //create graphics
            g = this.CreateGraphics();

        }

        /// <summary>
        /// Transparents the control area in the tracker
        /// </summary>
        /// <returns>Graphics Path made for transparenting</returns>
        private GraphicsPath BuildFrame()
        {
            //make the tracker to "contain" the control like this:
            //
            //
            //+++++++++++++++++++++++
            //+						+
            //+						+
            //+	 	 CONTROL		+
            //+						+
            //+						+
            //+++++++++++++++++++++++
            //

            GraphicsPath path = new GraphicsPath();

            //Top Rectagle
            path.AddRectangle(new Rectangle(0, 0, currentControl.Width + (Sqare.Width * 2) + 1, Sqare.Height + 1)); ;
            //Left Rectangle
            path.AddRectangle(new Rectangle(0, Sqare.Height + 1, Sqare.Width + 1, currentControl.Bounds.Height + Sqare.Height + 1));
            //Bottom Rectagle
            path.AddRectangle(new Rectangle(Sqare.Width + 1, currentControl.Bounds.Height + Sqare.Height, currentControl.Width + Sqare.Width + 1, Sqare.Height + 1));
            //Right Rectagle
            path.AddRectangle(new Rectangle(currentControl.Width + Sqare.Width, Sqare.Height + 1, Sqare.Width + 1, currentControl.Height - 2));

            return path;
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
            // RectTracker
            // 
            //this.BackColor = System.Drawing.Color.Wheat;
            this.Name = "RectTracker";
            this.Size = new System.Drawing.Size(64, 56);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RectTracker_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RectTracker_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RectTracker_MouseMove);

        }
        #endregion

        /// <summary>
        /// Handles the Move event of the Mouse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        public void Mouse_Move(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //minimum size for the control is 8x8
            if (currentControl.Height < 8)
            {
                currentControl.Height = 8;
                return;
            }
            else if (currentControl.Width < 8)
            {
                currentControl.Width = 8;
                return;
            }

            switch (this.CurrBorder)
            {
                case ResizeBorder.Top:
                    currentControl.Height = currentControl.Height - e.Y + prevLeftClick.Y;
                    if (currentControl.Height > 8)
                        currentControl.Top = currentControl.Top + e.Y - prevLeftClick.Y;
                    break;
                case ResizeBorder.TopLeft:
                    currentControl.Height = currentControl.Height - e.Y + prevLeftClick.Y;
                    if (currentControl.Height > 8)
                        currentControl.Top = currentControl.Top + e.Y - prevLeftClick.Y;
                    currentControl.Width = currentControl.Width - e.X + prevLeftClick.X;
                    if (currentControl.Width > 8)
                        currentControl.Left = currentControl.Left + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.TopRight:
                    currentControl.Height = currentControl.Height - e.Y + prevLeftClick.Y;
                    if (currentControl.Height > 8)
                        currentControl.Top = currentControl.Top + e.Y - prevLeftClick.Y;
                    currentControl.Width = currentControl.Width + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.Right:
                    currentControl.Width = currentControl.Width + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.Bottom:
                    currentControl.Height = currentControl.Height + e.Y - prevLeftClick.Y;
                    break;
                case ResizeBorder.BottomLeft:
                    currentControl.Height = currentControl.Height + e.Y - prevLeftClick.Y;
                    currentControl.Width = currentControl.Width - e.X + prevLeftClick.X;
                    if (currentControl.Width > 8)
                        currentControl.Left = currentControl.Left + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.BottomRight:
                    currentControl.Height = currentControl.Height + e.Y - prevLeftClick.Y;
                    currentControl.Width = currentControl.Width + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.Left:
                    currentControl.Width = currentControl.Width - e.X + prevLeftClick.X;
                    if (currentControl.Width > 8)
                        currentControl.Left = currentControl.Left + e.X - prevLeftClick.X;
                    break;
                case ResizeBorder.None:
                    currentControl.Location = new Point(currentControl.Location.X + e.X - prevLeftClick.X, currentControl.Location.Y + e.Y - prevLeftClick.Y);
                    break;

            }

        }

        /// <summary>
        /// Handles the MouseMove event of the RectTracker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void RectTracker_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;

            if (e.Button == MouseButtons.Left)
            {
                // If this is the first mouse move event for left click dragging of the form,
                // store the current point clicked so that we can use it to calculate the form's
                // new location in subsequent mouse move events due to left click dragging of the form
                if (isFirst == true)
                {
                    // Store previous left click position
                    prevLeftClick = new Point(e.X, e.Y);

                    // Subsequent mouse move events will not be treated as first time, until the
                    // left mouse click is released or other mouse click occur
                    isFirst = false;
                }
                else
                {
                    //hide tracker
                    this.Visible = false;
                    //forward mouse position to append changes
                    Mouse_Move(this, e);
                    // Store new previous left click position
                    prevLeftClick = new Point(e.X, e.Y);
                }


            }
            else
            {
                // This is a new mouse move event so reset flag
                isFirst = true;
                //show the tracker
                this.Visible = true;

                //update the mouse pointer to other cursors by checking it's position
                Hit_Test(e.X, e.Y);
            }


        }

        /// <summary>
        /// Handles the Paint event of the RectTracker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void RectTracker_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //redraw sqares
            Draw();
        }

        /// <summary>
        /// Handles the MouseUp event of the RectTracker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void RectTracker_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //the mouse is up, recreate the control to append changes
            Create();
            this.Visible = true;

        }

    }

    #endregion
}
