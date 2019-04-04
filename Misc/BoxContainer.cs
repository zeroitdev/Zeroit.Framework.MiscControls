// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BoxContainer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Simple Box Container

    #region Enums

    #region E N U M S    
    /// <summary>
    /// Enum representing SimpleBoxContainerLineStyle
    /// </summary>
    public enum SimpleBoxContainerLineStyle
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal = 2,
        /// <summary>
        /// The box
        /// </summary>
        Box = 3
    }

    /// <summary>
    /// Enum representing SimpleBoxContainerGradientDirection
    /// </summary>
    public enum SimpleBoxContainerGradientDirection
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal = 1,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical = 2
    }

    #endregion

    #endregion

    #region Control

    /// <summary>
    /// A class collection for rendering a container.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class ZeroitSimpleContainer : System.Windows.Forms.UserControl
    {

        #region D E C L A R A T I O N S

        /// <summary>
        /// The line style
        /// </summary>
        private SimpleBoxContainerLineStyle _lineStyle;
        /// <summary>
        /// The color
        /// </summary>
        private System.Drawing.Color _color = System.Drawing.Color.Black;
        /// <summary>
        /// The fill color
        /// </summary>
        private System.Drawing.Color _fillColor = System.Drawing.Color.Transparent;
        /// <summary>
        /// The line width
        /// </summary>
        private int _lineWidth = 1;
        /// <summary>
        /// The fit to parent
        /// </summary>
        private bool _fitToParent = false;
        /// <summary>
        /// The gradient
        /// </summary>
        private System.Drawing.Color _gradient = System.Drawing.Color.Transparent;
        /// <summary>
        /// The use gradient
        /// </summary>
        private bool _useGradient = false;
        /// <summary>
        /// The gradient angle
        /// </summary>
        private SimpleBoxContainerGradientDirection _gradientAngle = SimpleBoxContainerGradientDirection.Horizontal;
        /// <summary>
        /// The back buffer
        /// </summary>
        private Bitmap _backBuffer;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSimpleContainer" /> class.
        /// </summary>
        public ZeroitSimpleContainer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            //			SetStyle( ControlStyles.UserPaint, true ) ;
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Invalidate(true);
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

        #region P R O P E R T I E S

        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        [Category("Custom")]
        public SimpleBoxContainerGradientDirection GradientAngle
        {
            get { return _gradientAngle; }
            set
            {
                _gradientAngle = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to fit to parent.
        /// </summary>
        /// <value><c>true</c> if fit to parent; otherwise, <c>false</c>.</value>
        [Category("Custom")]
        public bool FitToParent
        {
            get { return _fitToParent; }
            set
            {
                _fitToParent = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient.
        /// </summary>
        /// <value><c>true</c> if use gradient; otherwise, <c>false</c>.</value>
        [Category("Custom")]
        public bool UseGradient
        {
            get { return _useGradient; }
            set
            {
                _useGradient = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        [Category("Custom")]
        public System.Drawing.Color FillColor
        {
            get { return _fillColor; }
            set
            {
                _fillColor = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets the gradient.
        /// </summary>
        /// <value>The gradient.</value>
        [Category("Custom")]
        public System.Drawing.Color Gradient
        {
            get { return _gradient; }
            set
            {
                _gradient = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("Custom")]
        public System.Drawing.Color LineColor
        {
            get
            {
                if (_color == Color.Transparent) { _color = Parent.BackColor; }
                return _color;
            }
            set
            {
                _color = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Category("Custom")]
        public int LineWidth
        {
            get { return _lineWidth; }
            set
            {
                _lineWidth = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Browsable(false)]
        public SimpleBoxContainerLineStyle Style
        {
            get { return _lineStyle; }
            set
            {
                _lineStyle = SimpleBoxContainerLineStyle.Box;
                if ((value == SimpleBoxContainerLineStyle.Box) && ((Width <= LineWidth) || (Height <= LineWidth)))
                {
                    Height = 50;
                    Width = 50;
                }
                this.Invalidate(true);
            }
        }

        #endregion

        #region M E T H O D S

        /// <summary>
        /// Called after the control has been added to another container.
        /// </summary>
        protected override void InitLayout()
        {
            base.InitLayout();
            if (null == this.Parent) return;
            if (_fillColor == Color.Transparent) _fillColor = Parent.BackColor;
            if (_lineStyle == SimpleBoxContainerLineStyle.None)
            {
                _lineStyle = SimpleBoxContainerLineStyle.Box;
                _lineWidth = 1;
                this.Left = (Parent.Width / 2) - this.Width / 2;
                this.Top = Parent.Height / 2;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground (pevent);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
            base.OnSizeChanged(e);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            string typeName;
            int idx;

            if (_backBuffer == null || this.DesignMode)
            {
                _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                Graphics g = Graphics.FromImage(_backBuffer);

                Pen pn = new Pen(_color, _lineWidth);
                Point pt1 = new Point(0, 0);
                if (_lineStyle == SimpleBoxContainerLineStyle.Box)
                {
                    Brush br;
                    Rectangle rect = this.ClientRectangle;

                    if (_useGradient) br = new LinearGradientBrush(this.ClientRectangle, _fillColor, _gradient, (_gradientAngle == SimpleBoxContainerGradientDirection.Horizontal) ? 0 : 90, false);
                    else br = new SolidBrush(_fillColor);

                    g.FillRectangle(br, this.ClientRectangle);
                    decimal mod = Decimal.Remainder((decimal)_lineWidth, (decimal)2);
                    int offset = 0;
                    if ((mod != 0) && (_lineWidth != 1)) offset = 1;

                    rect.Offset(_lineWidth / 2, _lineWidth / 2);
                    rect.Height = rect.Height - _lineWidth + offset - 1;
                    rect.Width = rect.Width - _lineWidth + offset - 1;
                    if (_lineWidth > 0) g.DrawRectangle(pn, rect);
                    br.Dispose();
                }
                g.Dispose();
            }
            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
            if (null == this.Controls) return;
            foreach (Control ctl in this.Controls)
            {
                if (e.Graphics.ClipBounds.IntersectsWith(ctl.ClientRectangle))
                {
                    typeName = ctl.GetType().Name;
                    idx = typeName.IndexOf("TransparentLabel");
                    if (idx >= 0) ctl.Invalidate(true);
                }
            }
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
            // ZeroitSimpleContainer
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Name = "ZeroitSimpleContainer";

        }
        #endregion
    }

    #endregion
    
    #endregion
}
