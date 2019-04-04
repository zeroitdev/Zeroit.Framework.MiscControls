// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Knob.cs" company="Zeroit Dev Technologies">
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
    #region KnobControl

    #region Control
    // A delegate type for hooking up ValueChanged notifications. 
    /// <summary>
    /// Delegate ValueChangedEventHandler
    /// </summary>
    /// <param name="Sender">The sender.</param>
    public delegate void ValueChangedEventHandler(object Sender);

    /// <summary>
    /// A class collection for rendering a knob control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitKnobDesigner))]
    public class ZeroitKnob : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Styles of pointer button
        /// </summary>
        public enum PointerStyle
        {
            /// <summary>
            /// The Circle
            /// </summary>
            Circle,
            /// <summary>
            /// The Line
            /// </summary>
            Line,
        }


        #region private properties

        /// <summary>
        /// The knob pointer style
        /// </summary>
        private PointerStyle _knobPointerStyle = PointerStyle.Circle;
        /// <summary>
        /// The line width
        /// </summary>
        private int lineWidth = 1;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum = 25;
        /// <summary>
        /// The large change
        /// </summary>
        private int _LargeChange = 5;
        /// <summary>
        /// The small change
        /// </summary>
        private int _SmallChange = 1;

        /// <summary>
        /// The scale divisions
        /// </summary>
        private int _scaleDivisions;
        /// <summary>
        /// The scale sub divisions
        /// </summary>
        private int _scaleSubDivisions;
        /// <summary>
        /// The scale color
        /// </summary>
        private Color _scaleColor;
        /// <summary>
        /// The knob back color
        /// </summary>
        private Color _knobBackColor = Color.LightGray;
        /// <summary>
        /// The draw div inside
        /// </summary>
        private bool _drawDivInside;

        /// <summary>
        /// The show small scale
        /// </summary>
        private bool _showSmallScale = false;
        /// <summary>
        /// The show large scale
        /// </summary>
        private bool _showLargeScale = true;

        /// <summary>
        /// The start angle
        /// </summary>
        private float _startAngle = 135;
        /// <summary>
        /// The end angle
        /// </summary>
        private float _endAngle = 405;
        /// <summary>
        /// The delta angle
        /// </summary>
        private float deltaAngle;
        /// <summary>
        /// The mouse wheel bar partitions
        /// </summary>
        private int _mouseWheelBarPartitions = 10;


        /// <summary>
        /// The draw ratio
        /// </summary>
        private float drawRatio;

        // Color of the pointer
        /// <summary>
        /// The pointer color
        /// </summary>
        private Color _PointerColor = Color.SlateBlue;


        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;
        /// <summary>
        /// The is focused
        /// </summary>
        private bool isFocused = false;
        /// <summary>
        /// The is knob rotating
        /// </summary>
        private bool isKnobRotating = false;
        /// <summary>
        /// The r knob
        /// </summary>
        private Rectangle rKnob;
        /// <summary>
        /// The p knob
        /// </summary>
        private Point pKnob;
        /// <summary>
        /// The dotted pen
        /// </summary>
        private Pen DottedPen;

        /// <summary>
        /// The b knob
        /// </summary>
        Brush bKnob;
        /// <summary>
        /// The b knob point
        /// </summary>
        Brush bKnobPoint;

        /// <summary>
        /// The knob font
        /// </summary>
        private Font knobFont;

        //-------------------------------------------------------
        // declare Off screen image and Offscreen graphics       
        //-------------------------------------------------------
        /// <summary>
        /// The off screen image
        /// </summary>
        private Image OffScreenImage;
        /// <summary>
        /// The g off screen
        /// </summary>
        private Graphics gOffScreen;

        #endregion


        #region event
        //-------------------------------------------------------
        // An event that clients can use to be notified whenever 
        // the Value is Changed.                                 
        //-------------------------------------------------------
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        //-------------------------------------------------------
        // Invoke the ValueChanged event; called  when value     
        // is changed                                            
        //-------------------------------------------------------
        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        protected virtual void OnValueChanged(object sender)
        {
            if (ValueChanged != null)
                ValueChanged(sender);
        }

        #endregion


        #region (* public Properties *)


        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public int LineWidth
        {
            get { return lineWidth; }
            set
            {
                if (value < 1)
                {

                    value = 1;
                }
                lineWidth = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Start angle to display graduations
        /// </summary>
        /// <value>The start angle to display graduations.</value>
        [Description("Set the start angle to display graduations (min 90)")]
        [Category("KnobControl")]
        [DefaultValue(135)]
        public float StartAngle
        {
            get { return _startAngle; }
            set
            {
                if (value >= 90 && value < _endAngle)
                {
                    _startAngle = value;
                    deltaAngle = _endAngle - StartAngle;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// End angle to display graduations
        /// </summary>
        /// <value>The end angle to display graduations.</value>
        [Description("Set the end angle to display graduations (max 450)")]
        [Category("KnobControl")]
        [DefaultValue(405)]
        public float EndAngle
        {
            get { return _endAngle; }
            set
            {
                if (value <= 450 && value > _startAngle)
                {
                    _endAngle = value;
                    deltaAngle = _endAngle - _startAngle;
                    Invalidate();
                }
            }
        }


        /// <summary>
        /// Style of pointer: Circle or Line
        /// </summary>
        /// <value>The knob pointer style.</value>
        [Description("Set the style of the knob pointer: a Circle or a Line")]
        [Category("KnobControl")]
        public PointerStyle KnobPointerStyle
        {
            get { return _knobPointerStyle; }
            set
            {
                _knobPointerStyle = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">MouseWheelBarPartitions has to be greather than zero</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value isn't greather than zero</exception>
        [Description("Set to how many parts is bar divided when using mouse wheel")]
        [Category("KnobControl")]
        [DefaultValue(10)]
        public int MouseWheelBarPartitions
        {
            get { return _mouseWheelBarPartitions; }
            set
            {
                if (value > 0)
                    _mouseWheelBarPartitions = value;
                else throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
            }
        }

        /// <summary>
        /// Draw string graduations inside or outside knob Circle
        /// </summary>
        /// <value><c>true</c> if [draw div inside]; otherwise, <c>false</c>.</value>
        [Description("Draw graduation strings inside or outside the knob Circle")]
        [Category("KnobControl")]
        [DefaultValue(false)]
        public bool DrawDivInside
        {
            get { return _drawDivInside; }
            set
            {
                _drawDivInside = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Color of graduations
        /// </summary>
        /// <value>The color of the scale.</value>
        [Description("Color of graduations")]
        [Category("KnobControl")]
        public Color ScaleColor
        {
            get { return _scaleColor; }
            set
            {
                _scaleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Color of graduations
        /// </summary>
        /// <value>The color of the knob back.</value>
        [Description("Color of knob")]
        [Category("KnobControl")]
        public Color KnobBackColor
        {
            get { return _knobBackColor; }
            set
            {
                _knobBackColor = value;
                setDimensions();
                Invalidate();
            }
        }

        /// <summary>
        /// How many divisions of maximum?
        /// </summary>
        /// <value>The scale divisions.</value>
        [Description("Set the number of intervals between minimum and maximum")]
        [Category("KnobControl")]
        public int ScaleDivisions
        {
            get { return _scaleDivisions; }
            set
            {
                _scaleDivisions = value;
                Invalidate();

            }
        }

        /// <summary>
        /// How many subdivisions for each division
        /// </summary>
        /// <value>The scale sub divisions.</value>
        [Description("Set the number of subdivisions between main divisions of graduation.")]
        [Category("KnobControl")]
        public int ScaleSubDivisions
        {
            get { return _scaleSubDivisions; }
            set
            {
                if (value > 0 && _scaleDivisions > 0 && (_maximum - _minimum) / (value * _scaleDivisions) > 0)
                {
                    _scaleSubDivisions = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Shows Small Scale marking.
        /// </summary>
        /// <value><c>true</c> if [show small scale]; otherwise, <c>false</c>.</value>
        [Description("Show or hide subdivisions of graduations")]
        [Category("KnobControl")]
        public bool ShowSmallScale
        {
            get { return _showSmallScale; }
            set
            {
                if (value == true)
                {
                    if (_scaleDivisions > 0 && _scaleSubDivisions > 0 && (_maximum - _minimum) / (_scaleSubDivisions * _scaleDivisions) > 0)
                    {
                        _showSmallScale = value;
                        Invalidate();
                    }
                }
                else
                {
                    _showSmallScale = value;
                    // need to redraw 
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Shows Large Scale marking
        /// </summary>
        /// <value><c>true</c> if [show large scale]; otherwise, <c>false</c>.</value>
        [Description("Show or hide graduations")]
        [Category("KnobControl")]
        public bool ShowLargeScale
        {
            get { return _showLargeScale; }
            set
            {
                _showLargeScale = value;
                // need to redraw
                setDimensions();

                Invalidate();
            }
        }

        /// <summary>
        /// Minimum Value for knob Control
        /// </summary>
        /// <value>The minimum.</value>
        [Description("set the minimum value for the knob control")]
        [Category("KnobControl")]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Maximum value for knob control
        /// </summary>
        /// <value>The maximum.</value>
        [Description("set the maximum value for the knob control")]
        [Category("KnobControl")]
        public int Maximum
        {
            get { return _maximum; }
            set
            {

                if (value > _minimum)
                {

                    _maximum = value;


                    if (_scaleSubDivisions > 0 && _scaleDivisions > 0 && (_maximum - _minimum) / (_scaleSubDivisions * _scaleDivisions) <= 0)
                    {
                        _showSmallScale = false;
                    }

                    setDimensions();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// value set for large change
        /// </summary>
        /// <value>The large change.</value>
        [Description("set the value for the large changes")]
        [Category("KnobControl")]
        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                _LargeChange = value;
                Invalidate();
            }
        }
        /// <summary>
        /// value set for small change.
        /// </summary>
        /// <value>The small change.</value>
        [Description("set the minimum value for the small changes")]
        [Category("KnobControl")]
        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                _SmallChange = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Current Value of knob control
        /// </summary>
        /// <value>The value.</value>
        [Description("set the current value of the knob control")]
        [Category("KnobControl")]
        public int Value
        {
            get { return _Value; }
            set
            {

                _Value = value;
                // need to redraw 
                Invalidate();
                // call delegate  
                OnValueChanged(this);
            }
        }

        /// <summary>
        /// Color of the button
        /// </summary>
        /// <value>The color of the pointer.</value>
        [Description("set the color of the pointer")]
        [Category("KnobControl")]
        public Color PointerColor
        {
            get { return _PointerColor; }
            set
            {
                _PointerColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// Color of the button
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("set the color of the pointer")]
        [Category("KnobControl")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        #endregion properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKnob" /> class.
        /// </summary>
        public ZeroitKnob()
        {

            // This call is required by the Windows.Forms Form Designer.
            DottedPen = new Pen(Utility.getDarkColor(this.BackColor, 40));
            DottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            DottedPen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;

            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);


            knobFont = new Font(this.Font.FontFamily, this.Font.Size);

            // Properties initialisation

            // "start angle" and "end angle" possible values:

            // 90 = bottom (minimum value for "start angle")
            // 180 = left
            // 270 = top
            // 360 = right
            // 450 = bottom again (maximum value for "end angle")

            // So the couple (90, 450) will give an entire Circle and the couple (180, 360) will give half a Circle.

            _startAngle = 135;
            _endAngle = 405;
            deltaAngle = _endAngle - _startAngle;

            _minimum = 0;
            _maximum = 100;
            _scaleDivisions = 11;
            _scaleSubDivisions = 4;
            _mouseWheelBarPartitions = 10;

            _scaleColor = Color.Black;
            _knobBackColor = Color.White;

            setDimensions();
        }
        #endregion

        #region override

        /// <summary>
        /// Paint event: draw all
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }

            // Set antialias effect on                     
            gOffScreen.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Set background color of Image...            
            gOffScreen.Clear(BackColor);
            // Fill knob Background to give knob effect....
            gOffScreen.FillEllipse(bKnob, rKnob);

            // Draw border of knob                         
            gOffScreen.DrawEllipse(new Pen(borderColor), rKnob);

            //if control is focused 
            if (this.isFocused)
            {
                gOffScreen.DrawEllipse(DottedPen, rKnob);
            }

            // DrawPointer
            DrawPointer(gOffScreen);

            //---------------------------------------------
            // darw small and large scale                  
            //---------------------------------------------
            DrawDivisions(gOffScreen, rKnob);

            // Drawimage on screen                    
            g.DrawImage(OffScreenImage, 0, 0);


        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Empty To avoid Flickring due do background Drawing.
        }

        /// <summary>
        /// Mouse down event: select control
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Utility.isPointinRectangle(new Point(e.X, e.Y), rKnob))
            {
                if (isFocused)
                {
                    // was already selected
                    // Start Rotation of knob only if it was selected before        
                    isKnobRotating = true;
                }
                else
                {
                    // Was not selected before => select it
                    Focus();
                    isFocused = true;
                    isKnobRotating = false; // disallow rotation, must click again
                    // draw dotted border to show that it is selected
                    Invalidate();
                }
            }

        }


        //----------------------------------------------------------
        // we need to override IsInputKey method to allow user to   
        // use up, down, right and bottom keys other wise using this
        // keys will change focus from current object to another    
        // object on the form                                       
        //----------------------------------------------------------
        /// <summary>
        /// Determines whether [is input key] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if [is input key] [the specified key]; otherwise, <c>false</c>.</returns>
        protected override bool IsInputKey(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                    return true;
            }
            return base.IsInputKey(key);
        }

        /// <summary>
        /// Mouse up event: display new value
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
		protected override void OnMouseUp(MouseEventArgs e)
        {

            if (Utility.isPointinRectangle(new Point(e.X, e.Y), rKnob))
            {
                if (isFocused == true && isKnobRotating == true)
                {
                    // change value is allowed only only after 2nd click                   
                    this.Value = this.getValueFromPosition(new Point(e.X, e.Y));

                }
                else
                {
                    // 1st click = only focus
                    isFocused = true;
                    isKnobRotating = true;
                }

            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse move event: drag the pointer to the mouse position
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
        {
            //--------------------------------------
            //  Following Handles Knob Rotating     
            //--------------------------------------
            if (e.Button == MouseButtons.Left && this.isKnobRotating == true)
            {
                this.Cursor = Cursors.Hand;
                Point p = new Point(e.X, e.Y);
                int posVal = this.getValueFromPosition(p);
                Value = posVal;
            }

        }

        /// <summary>
        /// Mousewheel: change value
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (isFocused && isKnobRotating && Utility.isPointinRectangle(new Point(e.X, e.Y), rKnob))
            {
                // the Delta value is always 120, as explained in MSDN
                int v = (e.Delta / 120) * (_maximum - _minimum) / _mouseWheelBarPartitions;
                SetProperValue(Value + v);

                // Avoid to send MouseWheel event to the parent container
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }


        /*
        protected override void OnEnter(EventArgs e)
		{
			
            Invalidate();

			base.OnEnter(new EventArgs());
		}
        */

        /// <summary>
        /// Leave event: disallow knob rotation
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            // unselect the control (remove dotted border)
            isFocused = false;
            isKnobRotating = false;
            Invalidate();

            base.OnLeave(new EventArgs());
        }

        /// <summary>
        /// Key down event: change value
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (isFocused)
            {
                //--------------------------------------------------------
                // Handles knob rotation with up,down,left and right keys 
                //--------------------------------------------------------
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
                {
                    if (_Value < _maximum) Value = _Value + 1;
                    this.Refresh();
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
                {
                    if (_Value > _minimum) Value = _Value - 1;
                    this.Refresh();
                }
            }
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


        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // KnobControl
            // 
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "KnobControl";
            this.Resize += new System.EventHandler(this.KnobControl_Resize);

        }
        #endregion

        #region Draw

        /// <summary>
        /// Draw the pointer of the knob (a small button inside the main button)
        /// </summary>
        /// <param name="Gr">The gr.</param>
        private void DrawPointer(Graphics Gr)
        {

            try
            {
                if (_knobPointerStyle == PointerStyle.Line)
                {
                    float radius = (float)(rKnob.Width / 2);

                    int l = (int)radius / 2;
                    int w = l / 4;
                    Point[] pt = getKnobLine(l);

                    Gr.DrawLine(new Pen(_PointerColor,/*w*/ lineWidth), pt[0], pt[1]);

                }
                else
                {
                    int w = 0;
                    int h = 0;

                    // Size of pointer
                    w = rKnob.Width / 10;
                    if (w < 7)
                        w = 7;

                    h = w;

                    Point Arrow = this.getKnobPosition(w);

                    // Draw pointer arrow that shows knob position             
                    Rectangle rPointer = new Rectangle(Arrow.X - w / 2, Arrow.Y - w / 2, w, h);


                    Utility.DrawInsetCircle(ref Gr, rPointer, new Pen(_PointerColor));
                    Gr.FillEllipse(bKnobPoint, rPointer);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Draw graduations
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool DrawDivisions(Graphics Gr, RectangleF rc)
        {
            if (this == null)
                return false;

            float cx = pKnob.X;
            float cy = pKnob.Y;

            float w = rc.Width;
            float h = rc.Height;

            float tx;
            float ty;

            float incr = Utility.GetRadian((_endAngle - _startAngle) / ((_scaleDivisions - 1) * (_scaleSubDivisions + 1)));
            float currentAngle = Utility.GetRadian(_startAngle);

            float radius = (float)(rKnob.Width / 2);
            float rulerValue = (float)_minimum;


            Pen penL = new Pen(_scaleColor, (2 * drawRatio));
            Pen penS = new Pen(_scaleColor, (1 * drawRatio));

            SolidBrush br = new SolidBrush(_scaleColor);

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            int n = 0;

            if (_showLargeScale)
            {
                for (; n < _scaleDivisions; n++)
                {
                    // draw divisions
                    ptStart.X = (float)(cx + (radius) * Math.Cos(currentAngle));
                    ptStart.Y = (float)(cy + (radius) * Math.Sin(currentAngle));

                    ptEnd.X = (float)(cx + (radius + w / 50) * Math.Cos(currentAngle));
                    ptEnd.Y = (float)(cy + (radius + w / 50) * Math.Sin(currentAngle));

                    Gr.DrawLine(penL, ptStart, ptEnd);


                    //Draw graduations Strings                    
                    float fSize = (float)(6F * drawRatio);
                    if (fSize < 6)
                        fSize = 6;
                    Font font = new Font(this.Font.FontFamily, fSize);

                    double val = Math.Round(rulerValue);
                    String str = String.Format("{0,0:D}", (int)val);
                    SizeF size = Gr.MeasureString(str, font);

                    if (_drawDivInside)
                    {
                        // graduations strings inside the knob
                        tx = (float)(cx + (radius - (11 * drawRatio)) * Math.Cos(currentAngle));
                        ty = (float)(cy + (radius - (11 * drawRatio)) * Math.Sin(currentAngle));


                    }
                    else
                    {
                        // graduation strings outside the knob
                        tx = (float)(cx + (radius + (11 * drawRatio)) * Math.Cos(currentAngle));
                        ty = (float)(cy + (radius + (11 * drawRatio)) * Math.Sin(currentAngle));

                    }

                    Gr.DrawString(str,
                                    font,
                                    br,
                                    tx - (float)(size.Width * 0.5),
                                    ty - (float)(size.Height * 0.5));

                    rulerValue += (float)((_maximum - _minimum) / (_scaleDivisions - 1));

                    if (n == _scaleDivisions - 1)
                    {
                        font.Dispose();
                        break;
                    }


                    // Subdivisions

                    if (_scaleDivisions <= 0)
                        currentAngle += incr;
                    else
                    {

                        for (int j = 0; j <= _scaleSubDivisions; j++)
                        {
                            currentAngle += incr;

                            // if user want to display small graduations
                            if (_showSmallScale)
                            {
                                ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                                ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                                ptEnd.X = (float)(cx + (radius + w / 50) * Math.Cos(currentAngle));
                                ptEnd.Y = (float)(cy + (radius + w / 50) * Math.Sin(currentAngle));

                                Gr.DrawLine(penS, ptStart, ptEnd);
                            }
                        }
                    }


                    font.Dispose();
                }
            }

            return true;
        }

        /// <summary>
        /// Set position of button inside its rectangle to insure that divisions will fit.
        /// </summary>
        private void setDimensions()
        {

            int size = this.Width;
            Height = size;


            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = Size.Width;
            h = Size.Height;

            // Calculate ratio
            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            if (_showLargeScale)
            {
                float fSize = (float)(6F * drawRatio);
                if (fSize < 6)
                    fSize = 6;
                knobFont = new Font(this.Font.FontFamily, fSize);
                double val = _maximum;
                String str = String.Format("{0,0:D}", (int)val);


                Graphics Gr = this.CreateGraphics();
                SizeF strsize = Gr.MeasureString(str, knobFont);
                int strw = (int)strsize.Width + 4;
                int strh = (int)strsize.Height;

                // allow 10% gap on all side to determine size of knob    
                //this.rKnob = new Rectangle((int)(size * 0.10), (int)(size * 0.15), (int)(size * 0.80), (int)(size * 0.80));
                x = (int)strw;
                //y = x;
                y = 2 * strh;
                w = (int)(size - 2 * strw);
                if (w <= 0)
                    w = 1;
                h = w;
                this.rKnob = new Rectangle((int)x, (int)y, (int)w, (int)h);
                Gr.Dispose();
            }
            else
            {
                this.rKnob = new Rectangle(0, 0, Width, Height);
            }


            // Center of knob
            this.pKnob = new Point(rKnob.X + rKnob.Width / 2, rKnob.Y + rKnob.Height / 2);

            // create offscreen image                                 
            this.OffScreenImage = new Bitmap(this.Width, this.Height);
            // create offscreen graphics                              
            this.gOffScreen = Graphics.FromImage(OffScreenImage);

            // create LinearGradientBrush for creating knob            
            bKnob = new System.Drawing.Drawing2D.LinearGradientBrush(
                rKnob, Utility.getLightColor(_knobBackColor, 55), Utility.getDarkColor(_knobBackColor, 55), LinearGradientMode.ForwardDiagonal);

            // create LinearGradientBrush for knobPoint                
            bKnobPoint = new System.Drawing.Drawing2D.LinearGradientBrush(
                rKnob, Utility.getLightColor(_PointerColor, 55), Utility.getDarkColor(_PointerColor, 55), LinearGradientMode.ForwardDiagonal);
        }

        #endregion

        #region resize

        /// <summary>
        /// Resize event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void KnobControl_Resize(object sender, System.EventArgs e)
        {
            setDimensions();
            //Refresh();
            Invalidate();
        }

        #endregion

        #region private functions

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < _minimum) Value = _minimum;
            else if (val > _maximum) Value = _maximum;
            else Value = val;
        }

        /// <summary>
        /// gets knob position that is to be drawn on control.
        /// </summary>
        /// <param name="l">The l.</param>
        /// <returns>Point that describes current knob position</returns>
        private Point getKnobPosition(int l)
        {
            float cx = pKnob.X;
            float cy = pKnob.Y;


            float radius = (float)(rKnob.Width / 2);

            float degree = deltaAngle * this.Value / (_maximum - _minimum);
            degree = Utility.GetRadian(degree + _startAngle);

            Point Pos = new Point(0, 0);

            Pos.X = (int)(cx + (radius - (11) * drawRatio) * Math.Cos(degree));
            Pos.Y = (int)(cy + (radius - (11) * drawRatio) * Math.Sin(degree));

            return Pos;
        }

        /// <summary>
        /// return 2 points of a Line starting from the center of the knob to the periphery
        /// </summary>
        /// <param name="l">The l.</param>
        /// <returns>Point[].</returns>
        private Point[] getKnobLine(int l)
        {
            Point[] pret = new Point[2];

            float cx = pKnob.X;
            float cy = pKnob.Y;


            float radius = (float)(rKnob.Width / 2);

            float degree = deltaAngle * this.Value / (_maximum - _minimum);
            degree = Utility.GetRadian(degree + _startAngle);

            Point Pos = new Point(0, 0);

            Pos.X = (int)(cx + (radius - drawRatio * 10) * Math.Cos(degree));
            Pos.Y = (int)(cy + (radius - drawRatio * 10) * Math.Sin(degree));

            pret[0] = new Point(Pos.X, Pos.Y);

            Pos.X = (int)(cx + (radius - drawRatio * 10 - l) * Math.Cos(degree));
            Pos.Y = (int)(cy + (radius - drawRatio * 10 - l) * Math.Sin(degree));

            pret[1] = new Point(Pos.X, Pos.Y);

            return pret;
        }

        /// <summary>
        /// converts geometrical position into value..
        /// </summary>
        /// <param name="p">Point that is to be converted</param>
        /// <returns>Value derived from position</returns>
        private int getValueFromPosition(Point p)
        {
            float degree = 0;
            int v = 0;

            if (p.X <= pKnob.X)
            {
                degree = (float)(pKnob.Y - p.Y) / (float)(pKnob.X - p.X);
                degree = (float)Math.Atan(degree);

                degree = (degree) * (float)(180 / Math.PI) + (180 - _startAngle);

            }
            else if (p.X > pKnob.X)
            {
                degree = (float)(p.Y - pKnob.Y) / (float)(p.X - pKnob.X);
                degree = (float)Math.Atan(degree);

                degree = (degree) * (float)(180 / Math.PI) + 360 - _startAngle;
            }

            // round to the nearest value (when you click just before or after a graduation!)
            v = (int)Math.Round(degree * (_maximum - _minimum) / deltaAngle);


            if (v > _maximum) v = _maximum;
            if (v < _minimum) v = _minimum;
            return v;

        }

        #endregion





        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
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


    #endregion

    #region Utility

    /// <summary>
    /// Summary description for Utility.
    /// </summary>
    public class Utility
    {

        /// <summary>
        /// Gets the radian.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>System.Single.</returns>
        public static float GetRadian(float val)
        {
            return (float)(val * Math.PI / 180);
        }


        /// <summary>
        /// Gets the color of the dark.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>Color.</returns>
        public static Color getDarkColor(Color c, byte d)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (c.R > d) r = (byte)(c.R - d);
            if (c.G > d) g = (byte)(c.G - d);
            if (c.B > d) b = (byte)(c.B - d);

            Color c1 = Color.FromArgb(r, g, b);
            return c1;
        }
        /// <summary>
        /// Gets the color of the light.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>Color.</returns>
        public static Color getLightColor(Color c, byte d)
        {
            byte r = 255;
            byte g = 255;
            byte b = 255;

            if (c.R + d < 255) r = (byte)(c.R + d);
            if (c.G + d < 255) g = (byte)(c.G + d);
            if (c.B + d < 255) b = (byte)(c.B + d);

            Color c2 = Color.FromArgb(r, g, b);
            return c2;
        }

        /// <summary>
        /// Method which checks is particular point is in rectangle
        /// </summary>
        /// <param name="p">Point to be Chaecked</param>
        /// <param name="r">Rectangle</param>
        /// <returns>true is Point is in rectangle, else false</returns>
        public static bool isPointinRectangle(Point p, Rectangle r)
        {
            bool flag = false;
            if (p.X > r.X && p.X < r.X + r.Width && p.Y > r.Y && p.Y < r.Y + r.Height)
            {
                flag = true;
            }
            return flag;

        }
        /// <summary>
        /// Draws the inset circle.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="p">The p.</param>
        public static void DrawInsetCircle(ref Graphics g, Rectangle r, Pen p)
        {

            Pen p1 = new Pen(getDarkColor(p.Color, 50));
            Pen p2 = new Pen(getLightColor(p.Color, 50));
            for (int i = 0; i < p.Width; i++)
            {
                Rectangle r1 = new Rectangle(r.X + i, r.Y + i, r.Width - i * 2, r.Height - i * 2);
                g.DrawArc(p2, r1, -45, 180);
                g.DrawArc(p1, r1, 135, 180);
            }
        }




    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitKnobDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitKnobDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitKnobSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitKnobSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitKnobSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitKnob colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKnobSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitKnobSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitKnob;

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
        /// Gets or sets the color of the scale.
        /// </summary>
        /// <value>The color of the scale.</value>
        public Color ScaleColor
        {
            get
            {
                return colUserControl.ScaleColor;
            }
            set
            {
                GetPropertyByName("ScaleColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the knob back.
        /// </summary>
        /// <value>The color of the knob back.</value>
        public Color KnobBackColor
        {
            get
            {
                return colUserControl.KnobBackColor;
            }
            set
            {
                GetPropertyByName("KnobBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pointer.
        /// </summary>
        /// <value>The color of the pointer.</value>
        public Color PointerColor
        {
            get
            {
                return colUserControl.PointerColor;
            }
            set
            {
                GetPropertyByName("PointerColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public float StartAngle
        {
            get
            {
                return colUserControl.StartAngle;
            }
            set
            {
                GetPropertyByName("StartAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>The end angle.</value>
        public float EndAngle
        {
            get
            {
                return colUserControl.EndAngle;
            }
            set
            {
                GetPropertyByName("EndAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the knob pointer style.
        /// </summary>
        /// <value>The knob pointer style.</value>
        public Zeroit.Framework.MiscControls.ZeroitKnob.PointerStyle KnobPointerStyle
        {
            get
            {
                return colUserControl.KnobPointerStyle;
            }
            set
            {
                GetPropertyByName("KnobPointerStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public int LineWidth
        {
            get
            {
                return colUserControl.LineWidth;
            }
            set
            {
                GetPropertyByName("LineWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        public int MouseWheelBarPartitions
        {
            get
            {
                return colUserControl.MouseWheelBarPartitions;
            }
            set
            {
                GetPropertyByName("MouseWheelBarPartitions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale divisions.
        /// </summary>
        /// <value>The scale divisions.</value>
        public int ScaleDivisions
        {
            get
            {
                return colUserControl.ScaleDivisions;
            }
            set
            {
                GetPropertyByName("ScaleDivisions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale sub divisions.
        /// </summary>
        /// <value>The scale sub divisions.</value>
        public int ScaleSubDivisions
        {
            get
            {
                return colUserControl.ScaleSubDivisions;
            }
            set
            {
                GetPropertyByName("ScaleSubDivisions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        public int LargeChange
        {
            get
            {
                return colUserControl.LargeChange;
            }
            set
            {
                GetPropertyByName("LargeChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        public int SmallChange
        {
            get
            {
                return colUserControl.SmallChange;
            }
            set
            {
                GetPropertyByName("SmallChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show small scale].
        /// </summary>
        /// <value><c>true</c> if [show small scale]; otherwise, <c>false</c>.</value>
        public bool ShowSmallScale
        {
            get
            {
                return colUserControl.ShowSmallScale;
            }
            set
            {
                GetPropertyByName("ShowSmallScale").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show large scale].
        /// </summary>
        /// <value><c>true</c> if [show large scale]; otherwise, <c>false</c>.</value>
        public bool ShowLargeScale
        {
            get
            {
                return colUserControl.ShowLargeScale;
            }
            set
            {
                GetPropertyByName("ShowLargeScale").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw div inside].
        /// </summary>
        /// <value><c>true</c> if [draw div inside]; otherwise, <c>false</c>.</value>
        public bool DrawDivInside
        {
            get
            {
                return colUserControl.DrawDivInside;
            }
            set
            {
                GetPropertyByName("DrawDivInside").SetValue(colUserControl, value);
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ScaleColor",
                                 "Scale Color", "Appearance",
                                 "Sets the scale color of the control."));

            items.Add(new DesignerActionPropertyItem("KnobBackColor",
                                 "Knob BackColor", "Appearance",
                                 "Sets the knob background color of the control."));

            items.Add(new DesignerActionPropertyItem("PointerColor",
                                 "Pointer Color", "Appearance",
                                 "Sets the pointer color of the control."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color of the control."));

            items.Add(new DesignerActionPropertyItem("StartAngle",
                                 "Start Angle", "Appearance",
                                 "Sets the start angle of the control."));

            items.Add(new DesignerActionPropertyItem("EndAngle",
                                 "End Angle", "Appearance",
                                 "Sets the end angle."));

            items.Add(new DesignerActionPropertyItem("KnobPointerStyle",
                                 "Knob Pointer Style", "Appearance",
                                 "Sets the pointer style of the control."));

            items.Add(new DesignerActionPropertyItem("LineWidth",
                                 "Line Width", "Appearance",
                                 "Sets the Line pointer when Line pointer is selected."));

            items.Add(new DesignerActionPropertyItem("MouseWheelBarPartitions",
                                 "Mouse WheelBar Partitions", "Appearance",
                                 "Sets the mouse wheel partitions."));

            items.Add(new DesignerActionPropertyItem("ScaleDivisions",
                                 "Scale Divisions", "Appearance",
                                 "Sets the scale divisions."));

            items.Add(new DesignerActionPropertyItem("ScaleSubDivisions",
                                 "Scale Sub Divisions", "Appearance",
                                 "Sets the scale sub divisions of the control."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value of the control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the control."));

            items.Add(new DesignerActionPropertyItem("LargeChange",
                                 "Large Change", "Appearance",
                                 "Sets the large change value of the control."));

            items.Add(new DesignerActionPropertyItem("SmallChange",
                                 "Small Change", "Appearance",
                                 "Sets the small change value of the control."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the control."));

            items.Add(new DesignerActionPropertyItem("ShowSmallScale",
                                 "Show Small Scale", "Appearance",
                                 "Enable small scale."));

            items.Add(new DesignerActionPropertyItem("ShowLargeScale",
                                 "Show Large Scale", "Appearance",
                                 "Enable large scale."));

            items.Add(new DesignerActionPropertyItem("DrawDivInside",
                                 "Draw Div Inside", "Appearance",
                                 "Enable control to draw values in the inside the control."));

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
