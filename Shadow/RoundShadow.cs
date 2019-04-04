// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RoundShadow.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing.Text;
using System.Text;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitRoundShadow

    #region Control

    /// <summary>
    /// A class collection for rendering a rounded shadow control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitRoundShadowDesigner))]
    public class ZeroitRoundShadow : Button
    {

        #region Private Fields
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// The pen
        /// </summary>
        private Pen _pen = null;
        /// <summary>
        /// The brush text
        /// </summary>
        SolidBrush _brushText = null, _brushInside = null;
        /// <summary>
        /// The colorgradient
        /// </summary>
        private byte _colorgradient = 2;        // fading effect
        /// <summary>
        /// The text start point
        /// </summary>
        private Point _textStartPoint = new Point(0, 0);
        /// <summary>
        /// The color step gradient
        /// </summary>
        private byte _colorStepGradient = 2;    // in pixels
        /// <summary>
        /// The fade out
        /// </summary>
        private bool _fadeOut = false;
        /// <summary>
        /// The b draw outline
        /// </summary>
        private bool _bDrawOutline = false;
        /// <summary>
        /// The dashed pen
        /// </summary>
        private Pen _dashedPen = null;
        /// <summary>
        /// The black pen
        /// </summary>
        private Pen _blackPen = null;

        // These are for drawing when you hover over the button
        /// <summary>
        /// The hover color
        /// </summary>
        private Color _hoverColor = Color.FromKnownColor(KnownColor.ControlDark);
        /// <summary>
        /// The hover pen
        /// </summary>
        private Pen _hoverPen = null;
        /// <summary>
        /// The hover brush inside
        /// </summary>
        private SolidBrush _hoverBrushInside = null;

        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// The black pen color
        /// </summary>
        private Color blackPenColor = Color.FromKnownColor(KnownColor.Black);

        /// <summary>
        /// The black pen width
        /// </summary>
        private int blackPenWidth = 2;

        /// <summary>
        /// The border transparency
        /// </summary>
        private int borderTransparency = 255;

        /// <summary>
        /// The pen dash
        /// </summary>
        private DashStyle penDash = DashStyle.Dot;

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color of the black pen.
        /// </summary>
        /// <value>The color of the black pen.</value>
        public Color BlackPenColor
        {
            get { return blackPenColor; }
            set
            {
                blackPenColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the black pen.
        /// </summary>
        /// <value>The width of the black pen.</value>
        public int BlackPenWidth
        {
            get { return blackPenWidth; }
            set
            {
                blackPenWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer pen dashstyle.
        /// </summary>
        /// <value>The hover outer pen.</value>
        public DashStyle HoverOuterPen
        {
            get { return penDash; }
            set
            {
                penDash = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border transparency.
        /// </summary>
        /// <value>The border transparency.</value>
        public int BorderTransparency
        {
            get { return borderTransparency; }
            set
            {
                if (value > 255)
                {
                    value = 255;
                }

                if (value < 0)
                {
                    value = 0;
                }

                borderTransparency = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the color of the control when hovered.
        /// </summary>
        /// <value>The color of the control when hovered.</value>
        [
        Category("Button step-in color"),
        Description("This color will show up when you hover over the button")
        ]
        public Color HoverColor
        {
            get
            {
                return _hoverColor;
            }
            set
            {
                _hoverColor = value;
                _hoverPen.Color = value;
                _hoverBrushInside.Color = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text start point.
        /// </summary>
        /// <value>The text start point.</value>
        [
        Category("Text start point"),
        Description("Point where your text would start getting drawn")
        ]
        public Point TextStartPoint
        {
            get
            {
                return _textStartPoint;
            }
            set
            {
                _textStartPoint = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color gradient.
        /// </summary>
        /// <value>The color gradient.</value>
        [
        Category("Color gradient"),
        Description("Indicates how sharp a color transition you want")
        ]
        public byte ColorGradient
        {
            get
            {
                return _colorgradient;
            }
            set
            {
                _colorgradient = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color step gradient.
        /// </summary>
        /// <value>The color step gradient.</value>
        [
        Category("Color step gradient"),
        Description("Indicates how many every pixels you want color change")
        ]
        public byte ColorStepGradient
        {
            get
            {
                return _colorStepGradient;
            }
            set
            {
                _colorStepGradient = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable fade out.
        /// </summary>
        /// <value><c>true</c> if fade out; otherwise, <c>false</c>.</value>
        [
        Category("Fade"),
        Description("Fade out")
        ]
        public bool FadeOut
        {
            get
            {
                return _fadeOut;
            }
            set
            {
                _fadeOut = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRoundShadow" /> class.
        /// </summary>
        public ZeroitRoundShadow()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);


            // TODO: Add any initialization after the InitComponent call
            _pen = new Pen(BackColor);
            _brushInside = new SolidBrush(BackColor);
            _brushText = new SolidBrush(ForeColor);

            _hoverPen = new Pen(_hoverColor);
            _hoverBrushInside = new SolidBrush(_hoverColor);


            _textStartPoint = new Point(((Width / 2) - (Width / 8)), Height / 2);
        }

        #endregion

        #region Designer Generated Code
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
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
            // RoundButton
            // 
            this.ForeColorChanged += new System.EventHandler(this.RoundButton_ForeColorChanged);
            this.Enter += new System.EventHandler(this.RoundButton_Enter);
            this.MouseEnter += new System.EventHandler(this.RoundButton_MouseEnter);
            this.BackColorChanged += new System.EventHandler(this.RoundButton_BackColorChanged);
            this.Leave += new System.EventHandler(this.RoundButton_Leave);
            this.MouseLeave += new System.EventHandler(this.RoundButton_MouseLeave);

        }
        #endregion

        #endregion

        #region Overrides

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = smoothing;


            _blackPen = new Pen(blackPenColor, blackPenWidth);
            _dashedPen = new Pen(blackPenColor, blackPenWidth);
            _dashedPen.DashStyle = penDash;

            ColorButton(g);

            //g.FillEllipse(new SolidBrush(Color.Black), 0, 0, ClientSize.Width, ClientSize.Height);
            g.DrawEllipse(new Pen(Color.FromArgb(borderTransparency, borderColor)), 0, 0, ClientSize.Width - 2, ClientSize.Height - 2);

            //GraphicsPath path = new GraphicsPath();
            //path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);

            //this.Region = new Region(path);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            _textStartPoint = new Point(((Width / 2) - (Width / 8)), Height / 2);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Colors the button.
        /// </summary>
        /// <param name="g">The g.</param>
        void ColorButton(Graphics g)
        {
            g.SmoothingMode = smoothing;
            g.Clear(BackColor);

            ColorButton5(g, _pen, _brushInside);
        }

        // Fills color. No color gradient.
        /// <summary>
        /// Colors the button1.
        /// </summary>
        /// <param name="g">The g.</param>
        void ColorButton1(Graphics g)
        {
            g.SmoothingMode = smoothing;

            g.DrawEllipse(_pen, 0, 0, ClientSize.Width, ClientSize.Height);
            g.FillEllipse(_brushInside, 0, 0, ClientSize.Width, ClientSize.Height);
        }

        // Fills color with color gradient. Color gets darker toward the righthand-bottom corner.
        /// <summary>
        /// Colors the button2.
        /// </summary>
        /// <param name="g">The g.</param>
        void ColorButton2(Graphics g)
        {
            g.SmoothingMode = smoothing;

            int x = 0, y = 0;
            Color origPenColor = _pen.Color;
            Color origBrushColor = _brushInside.Color;

            for (; x <= ClientSize.Width / 2 && y <= ClientSize.Height / 2; x += _colorStepGradient, y += _colorStepGradient)
            {
                g.DrawEllipse(_pen, x, y, ClientSize.Width, ClientSize.Height);
                g.FillEllipse(_brushInside, x, y, ClientSize.Width, ClientSize.Height);

                byte newR = ((byte)(_pen.Color.R - _colorgradient) > 0 ? (byte)(_pen.Color.R - _colorgradient) : _pen.Color.R);
                byte newG = ((byte)(_pen.Color.G - _colorgradient) > 0 ? (byte)(_pen.Color.G - _colorgradient) : _pen.Color.G);
                byte newB = ((byte)(_pen.Color.B - _colorgradient) > 0 ? (byte)(_pen.Color.B - _colorgradient) : _pen.Color.B);

                Color newcolor = Color.FromArgb(newR, newG, newB);
                _pen.Color = newcolor;
                _brushInside.Color = newcolor;
            }

            _pen.Color = origPenColor;
            _brushInside.Color = origBrushColor;

            DrawText(g);
        }

        // Fills color with color gradient. Color gets darker towards the center. Respects the image property set 
        // by the user.
        /// <summary>
        /// Colors the button3.
        /// </summary>
        /// <param name="g">The g.</param>
        void ColorButton3(Graphics g)
        {
            g.SmoothingMode = smoothing;

            int x = 0, y = 0;
            Color origPenColor = _pen.Color;
            Color origBrushColor = _brushInside.Color;
            int width = ClientSize.Width, height = ClientSize.Height;

            for (; x <= width / 2 && y <= height / 2; x += _colorStepGradient, y += _colorStepGradient, width -= 2 * _colorStepGradient, height -= 2 * _colorStepGradient)
            {
                g.DrawEllipse(_pen, x, y, width, height);
                g.FillEllipse(_brushInside, x, y, width, height);

                byte newR = ((byte)(_pen.Color.R - _colorgradient) > 0 ? (byte)(_pen.Color.R - _colorgradient) : _pen.Color.R);
                byte newG = ((byte)(_pen.Color.G - _colorgradient) > 0 ? (byte)(_pen.Color.G - _colorgradient) : _pen.Color.G);
                byte newB = ((byte)(_pen.Color.B - _colorgradient) > 0 ? (byte)(_pen.Color.B - _colorgradient) : _pen.Color.B);

                Color newcolor = Color.FromArgb(newR, newG, newB);
                _pen.Color = newcolor;
                _brushInside.Color = newcolor;
            }

            _pen.Color = origPenColor;
            _brushInside.Color = origBrushColor;

            DrawText(g);
            DrawImage(g);
        }

        // Implements fade out/ in property. Color gets lighter (fade in) or darker (fade out) towards the center.
        /// <summary>
        /// Colors the button4.
        /// </summary>
        /// <param name="g">The g.</param>
        void ColorButton4(Graphics g)
        {
            g.SmoothingMode = smoothing;

            int x = 0, y = 0;
            Color origPenColor = _pen.Color;
            Color origBrushColor = _brushInside.Color;
            int width = ClientSize.Width, height = ClientSize.Height;

            for (; x <= width / 2 && y <= height / 2; x += _colorStepGradient, y += _colorStepGradient, width -= 2 * _colorStepGradient, height -= 2 * _colorStepGradient)
            {
                g.DrawEllipse(_pen, x, y, width, height);
                g.FillEllipse(_brushInside, x, y, width, height);

                byte newR = _pen.Color.R;
                byte newG = _pen.Color.G;
                byte newB = _pen.Color.B;

                if (_fadeOut)
                {
                    if (_pen.Color.R + _colorgradient <= 255)
                        newR = (byte)(_pen.Color.R + _colorgradient);

                    if (_pen.Color.G + _colorgradient <= 255)
                        newG = (byte)(_pen.Color.G + _colorgradient);

                    if (_pen.Color.B + _colorgradient <= 255)
                        newB = (byte)(_pen.Color.B + _colorgradient);
                }
                else
                {
                    if (_pen.Color.R - _colorgradient >= 0)
                        newR = (byte)(_pen.Color.R - _colorgradient);

                    if (_pen.Color.G - _colorgradient >= 0)
                        newG = (byte)(_pen.Color.G - _colorgradient);

                    if (_pen.Color.B - _colorgradient >= 0)
                        newB = (byte)(_pen.Color.B - _colorgradient);
                }

                Color newcolor = Color.FromArgb(newR, newG, newB);
                _pen.Color = newcolor;
                _brushInside.Color = newcolor;
            }

            _pen.Color = origPenColor;
            _brushInside.Color = origBrushColor;

            DrawText(g);
            DrawImage(g);
        }

        // ColorButton4 modified to take in pen and brush arguments. Needed for hover-coloring.
        // Draws a focus rectangle when the button has focus.
        /// <summary>
        /// Colors the button5.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        void ColorButton5(Graphics g, Pen pen, SolidBrush brush)
        {
            g.SmoothingMode = smoothing;

            int x = 0, y = 0;
            Color origPenColor = pen.Color;
            Color origBrushColor = brush.Color;
            int width = ClientSize.Width, height = ClientSize.Height;

            for (; x <= width / 2 && y <= height / 2; x += _colorStepGradient, y += _colorStepGradient, width -= 2 * _colorStepGradient, height -= 2 * _colorStepGradient)
            {
                // Draw the focus ellipse
                if (_bDrawOutline && (x == 0))
                {
                    // Draw solid black outline
                    g.DrawEllipse(_blackPen, x, y, width, height);
                    x++; y++; width -= 2; height -= 2;
                    g.FillEllipse(brush, x, y, width, height);

                    g.DrawEllipse(_blackPen, x, y, width, height);
                    x++; y++; width -= 2; height -= 2;
                    g.FillEllipse(brush, x, y, width, height);
                }
                else
                    g.DrawEllipse(pen, x, y, width, height);

                if (_bDrawOutline && (x == 6))
                {
                    // Draw dashed black (inner ellipse of focus ellipse)
                    g.DrawEllipse(_dashedPen, x, y, width, height);
                    x += 1; y += 1; width -= 2; height -= 2;
                }

                g.FillEllipse(brush, x, y, width, height);

                byte newR = pen.Color.R;
                byte newG = pen.Color.G;
                byte newB = pen.Color.B;

                if (_fadeOut)
                // outer rim -> darker color
                {
                    if (pen.Color.R + _colorgradient <= 255)
                        newR = (byte)(pen.Color.R + _colorgradient);

                    if (pen.Color.G + _colorgradient <= 255)
                        newG = (byte)(pen.Color.G + _colorgradient);

                    if (pen.Color.B + _colorgradient <= 255)
                        newB = (byte)(pen.Color.B + _colorgradient);
                }
                else
                // outer rim -> lighter color
                {
                    if (pen.Color.R - _colorgradient >= 0)
                        newR = (byte)(pen.Color.R - _colorgradient);

                    if (pen.Color.G - _colorgradient >= 0)
                        newG = (byte)(pen.Color.G - _colorgradient);

                    if (pen.Color.B - _colorgradient >= 0)
                        newB = (byte)(pen.Color.B - _colorgradient);
                }

                Color newcolor = Color.FromArgb(newR, newG, newB);
                pen.Color = newcolor;
                brush.Color = newcolor;
            }

            // restore the original color
            pen.Color = origPenColor;
            brush.Color = origBrushColor;

            DrawText(g);
            DrawImage(g);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawText(Graphics g)
        {
            g.TextRenderingHint = textrendering;
            g.DrawString(this.Text, this.Font, _brushText, new PointF(_textStartPoint.X, _textStartPoint.Y));
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawImage(Graphics g)
        {
            g.SmoothingMode = smoothing;
            // depends on ImageAlign
            if (Image != null)
            {
                Rectangle rc = new Rectangle(new Point((this.Width - Image.Width) / 2, (this.Height - Image.Height) / 2), new Size(Image.Width, Image.Height));
                g.DrawImage(this.Image, rc);
            }

        }

        /// <summary>
        /// Handles the MouseEnter event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_MouseEnter(object sender, System.EventArgs e)
        {
            _pen.Color = _hoverColor;
            _brushInside.Color = _hoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// Handles the MouseLeave event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_MouseLeave(object sender, System.EventArgs e)
        {
            _pen.Color = BackColor;
            _brushInside.Color = BackColor;
            this.Invalidate();
        }

        /// <summary>
        /// Handles the Enter event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_Enter(object sender, System.EventArgs e)
        {
            _bDrawOutline = true;
        }

        /// <summary>
        /// Handles the Leave event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_Leave(object sender, System.EventArgs e)
        {
            _bDrawOutline = false;
        }

        /// <summary>
        /// Handles the BackColorChanged event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_BackColorChanged(object sender, System.EventArgs e)
        {
            _pen.Color = BackColor;
            _brushInside.Color = BackColor;
        }

        /// <summary>
        /// Handles the ForeColorChanged event of the RoundButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RoundButton_ForeColorChanged(object sender, System.EventArgs e)
        {
            _brushText.Color = ForeColor;
        }
        #endregion


    }



    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitRoundShadowDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRoundShadowDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRoundShadowDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRoundShadowSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRoundShadowSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRoundShadowSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRoundShadow colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRoundShadowSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRoundShadowSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRoundShadow;

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

        #region Public Properties


        /// <summary>
        /// Gets or sets the color of the black pen.
        /// </summary>
        /// <value>The color of the black pen.</value>
        public Color BlackPenColor
        {
            get
            {
                return colUserControl.BlackPenColor;
            }
            set
            {
                GetPropertyByName("BlackPenColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the black pen.
        /// </summary>
        /// <value>The width of the black pen.</value>
        public int BlackPenWidth
        {
            get
            {
                return colUserControl.BlackPenWidth;
            }
            set
            {
                GetPropertyByName("BlackPenWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the hover outer pen.
        /// </summary>
        /// <value>The hover outer pen.</value>
        public DashStyle HoverOuterPen
        {
            get
            {
                return colUserControl.HoverOuterPen;
            }
            set
            {
                GetPropertyByName("HoverOuterPen").SetValue(colUserControl, value);
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
        /// Gets or sets the text start point.
        /// </summary>
        /// <value>The text start point.</value>
        public Point TextStartPoint
        {
            get
            {
                return colUserControl.TextStartPoint;
            }
            set
            {
                GetPropertyByName("TextStartPoint").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color gradient.
        /// </summary>
        /// <value>The color gradient.</value>
        public byte ColorGradient
        {
            get
            {
                return colUserControl.ColorGradient;
            }
            set
            {
                GetPropertyByName("ColorGradient").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color step gradient.
        /// </summary>
        /// <value>The color step gradient.</value>
        public byte ColorStepGradient
        {
            get
            {
                return colUserControl.ColorStepGradient;
            }
            set
            {
                GetPropertyByName("ColorStepGradient").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [fade out].
        /// </summary>
        /// <value><c>true</c> if [fade out]; otherwise, <c>false</c>.</value>
        public bool FadeOut
        {
            get
            {
                return colUserControl.FadeOut;
            }
            set
            {
                GetPropertyByName("FadeOut").SetValue(colUserControl, value);
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
        /// Gets or sets the border transparency.
        /// </summary>
        /// <value>The border transparency.</value>
        public int BorderTransparency
        {
            get
            {
                return colUserControl.BorderTransparency;
            }
            set
            {
                GetPropertyByName("BorderTransparency").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get
            {
                return colUserControl.TextRendering;
            }
            set
            {
                GetPropertyByName("TextRendering").SetValue(colUserControl, value);
            }
        }

        #endregion

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

            items.Add(new DesignerActionPropertyItem("HoverColor",
                                 "Hover Color", "Appearance",
                                 "Sets the hover color."));

            items.Add(new DesignerActionPropertyItem("TextStartPoint",
                                 "Text Start Point", "Appearance",
                                 "Sets the text start point."));

            items.Add(new DesignerActionPropertyItem("ColorGradient",
                                 "Color Gradient", "Appearance",
                                 "Sets the gradient level."));

            items.Add(new DesignerActionPropertyItem("ColorStepGradient",
                                 "Color Step Gradient", "Appearance",
                                 "Sets the color step gradient."));

            items.Add(new DesignerActionPropertyItem("FadeOut",
                                 "Fade Out", "Appearance",
                                 "Set to enable fade out."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Set to enable border color."));

            items.Add(new DesignerActionPropertyItem("BorderTransparency",
                                 "Border Transparency", "Appearance",
                                 "Sets the border transparency."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the smoothing mode."));

            items.Add(new DesignerActionPropertyItem("TextRendering",
                                 "Text Rendering", "Appearance",
                                 "Sets the text rendering mode."));


            items.Add(new DesignerActionPropertyItem("BlackPenColor",
                                 "Black Pen Color", "Appearance",
                                 "Sets the black pen."));

            items.Add(new DesignerActionPropertyItem("BlackPenWidth",
                                 "Black Pen Width", "Appearance",
                                 "Sets the black pen width."));

            items.Add(new DesignerActionPropertyItem("HoverOuterPen",
                                 "Hover Outer Pen", "Appearance",
                                 "Sets the hover outer pen."));

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