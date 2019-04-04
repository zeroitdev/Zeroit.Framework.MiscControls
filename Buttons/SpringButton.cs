using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Spring Button

    /// <summary>
    /// A simple example about
    /// how to  create a c# control
    /// and 
    /// how to manage a delegate with
    /// embedded Eventargs
    /// </summary>
     

    //This is the Embedded eventargs...
    //it just say if the clicked items
    //is right or left triangle

    public class TriangleClickEventArgs
    {
        public bool Isleft = true;

        public TriangleClickEventArgs(bool TriangleIsleft)
        {

            Isleft = TriangleIsleft;

        }

    }

    /// <summary>
    /// A class collection for rendering a button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class SpringButton : Control
    {


        #region Events and Delegates
        //When user click on the triangle(left o right)
        //the control  run a new event called "TriangleClick"
        //and say what triangle has been clicked.


        public event TriangleClickDelegate TriangleClick;

        public delegate void TriangleClickDelegate(Object sender, TriangleClickEventArgs e); 
        #endregion

        #region Private Fields
        //this variable say if the
        //mouse is over the contol
        private bool Sel = false;
        private Color BackColor2 = Color.Gray;
        int _triangle = 25; 
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ending border's color.
        /// </summary>
        /// <value>The back color end.</value>
        public Color BackColorEnd
        {
            get { return BackColor2; }
            set
            {
                BackColor2 = value;
                this.Invalidate();
            }

        }


        //I add a proprety
        //that's the length of
        //a triangle rectangle (45°)

        /// <summary>
        /// Gets or sets the triangle.
        /// </summary>
        /// <value>The triangle.</value>
        public int Triangle
        {
            get { return _triangle; }
            set
            {
                _triangle = value;
                //if lenght change I update 
                //the control
                this.Invalidate(true);
            }
        } 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SpringButton"/> class.
        /// </summary>
        public SpringButton()
        {
            //First of all i set the style 

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint
                 | ControlStyles.UserMouse, true);


            this.Invalidate();

        } 
        
        #endregion

        #region Methods and Overrides
        //I override the default event " Onclick"
        //adding the detection of "triangle click"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnClick(e);
            // if the user use this delegate...
            if (this.TriangleClick != null)
            {
                //check if the user click on the left triangle
                //or in the right with some geometrics  rules...
                //(is't possible to click all triangle at the same time )

                int x = e.X;
                int y = e.Y;

                if ((x < _triangle) && (y <= (_triangle - x)) ||
                   (x > this.ClientRectangle.Width - _triangle) && (y >= (this.ClientRectangle.Height - _triangle - x)))
                {


                    //try with right...
                    TriangleClickEventArgs te = new TriangleClickEventArgs(false);
                    //if not...
                    if ((x < _triangle) && (y <= (_triangle - x)))
                        te = new TriangleClickEventArgs(true);

                    this.TriangleClick(this, te);


                }
            }
        }
        //set the button as "selected" on mouse entering
        //and as not selected on mouse leaving
        protected override void OnMouseEnter(EventArgs e)
        {
            Sel = true;

            this.Invalidate();

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Sel = false;

            this.Invalidate();

        }

        //i overide the default paint
        //and do my special routine...
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            this.PaintBut(e);
        }

        //If  this component is resized i update him
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(true);
        }

        //The Core of this control...
        protected void PaintBut(PaintEventArgs e)
        {
            //I select the rights color 
            //To paint the button...
            Color FColor = this.BackColorEnd;
            Color BColor = this.BackColor;
            if (Sel == true)
            {
                FColor = this.BackColor;

                BColor = this.BackColorEnd;
            }
            //I daw the central rectangle


            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), this.ClientRectangle);

            Rectangle rect = new Rectangle(5, 5, this.ClientRectangle.Width - 10, this.ClientRectangle.Height - 10);

            e.Graphics.FillRectangle(new LinearGradientBrush(rect, BColor, Color.FromArgb(10, BColor), 45, true), rect);
            e.Graphics.DrawRectangle(new Pen(FColor), rect);

            //I define the triangle's coordinate...
            Point[] tringleleft = new Point[4];
            tringleleft[0] = new Point(0, 0);
            tringleleft[1] = new Point(_triangle, 0);
            tringleleft[2] = new Point(0, _triangle);
            tringleleft[3] = new Point(0, 0);

            Point[] tringleright = new Point[4];
            tringleright[0] = new Point(this.Width - 1, this.Height - 1);
            tringleright[1] = new Point(this.Width - _triangle - 1, this.Height - 1);
            tringleright[2] = new Point(this.Width - 1, this.Height - _triangle - 1);
            tringleright[3] = new Point(this.Width - 1, this.Height - 1);




            //..and paint the triangle on the control 
            e.Graphics.FillPolygon(new SolidBrush(BColor), tringleleft);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleleft);


            e.Graphics.FillPolygon(new SolidBrush(BColor), tringleright);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleright);

            //At last i write the text with
            //some allignament...
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;

            sf.Trimming = StringTrimming.Character;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, sf);

        }

        #endregion


    }
    #endregion
    
}
