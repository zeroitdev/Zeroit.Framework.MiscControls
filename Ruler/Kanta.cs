// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Kanta.cs" company="Zeroit Dev Technologies">
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
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitCodeTextBoxRuler Kanta

    #region Control    
    /// <summary>
    /// A class collection for rendering a ruler.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitRulerKantaDesigner))]
    public class ZeroitRulerKanta : UserControl
    {

        /// <summary>
        /// The context menu
        /// </summary>
        private System.Windows.Forms.ContextMenu contextMenu;
        /// <summary>
        /// The menu item flip
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemFlip;
        /// <summary>
        /// The menu item separator1
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemSeparator1;
        /// <summary>
        /// The menu item pixel
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemPixel;
        /// <summary>
        /// The menu item inch
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemInch;
        /// <summary>
        /// The menu item centimeter
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemCentimeter;
        /// <summary>
        /// The menu item separator2
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemSeparator2;
        /// <summary>
        /// The menu item about
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemAbout;
        /// <summary>
        /// The menu item exit
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemExit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRulerKanta" /> class.
        /// </summary>
        public ZeroitRulerKanta()
        {
            //
            // Required for Windows Form Designer support
            //
            this.InitializeComponent();

            this.size = new Size(this.Width, this.Width);
            this.pen = new Pen(Color.Black, float.Epsilon);
            this.format = new StringFormat(StringFormat.GenericTypographic);
            this.format.FormatFlags = StringFormatFlags.NoWrap;
            this.format.Trimming = StringTrimming.Character;
        }

        /// <summary>
        /// Handles the Load event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Ruler_Load(object sender, System.EventArgs e)
        {
            this.ContextMenu = this.contextMenu;
            this.Horizontal = true;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ZeroitRulerKanta));
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemFlip = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemPixel = new System.Windows.Forms.MenuItem();
            this.menuItemInch = new System.Windows.Forms.MenuItem();
            this.menuItemCentimeter = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                        this.menuItemFlip,
                                                                                        this.menuItemSeparator1,
                                                                                        this.menuItemPixel,
                                                                                        this.menuItemInch,
                                                                                        this.menuItemCentimeter,
                                                                                        this.menuItemSeparator2,
                                                                                        this.menuItemAbout,
                                                                                        this.menuItemExit});
            // 
            // menuItemFlip
            // 
            this.menuItemFlip.Index = 0;
            this.menuItemFlip.Text = "Flip ZeroitCodeTextBoxRuler";
            this.menuItemFlip.Click += new System.EventHandler(this.menuItemFlip_Click);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Index = 1;
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemPixel
            // 
            this.menuItemPixel.Checked = true;
            this.menuItemPixel.Index = 2;
            this.menuItemPixel.Text = "Pixels";
            this.menuItemPixel.Click += new System.EventHandler(this.menuItemPixel_Click);
            // 
            // menuItemInch
            // 
            this.menuItemInch.Index = 3;
            this.menuItemInch.Text = "Inches";
            this.menuItemInch.Click += new System.EventHandler(this.menuItemInch_Click);
            // 
            // menuItemCentimeter
            // 
            this.menuItemCentimeter.Index = 4;
            this.menuItemCentimeter.Text = "Centimeters";
            this.menuItemCentimeter.Click += new System.EventHandler(this.menuItemCentimeter_Click);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Index = 5;
            this.menuItemSeparator2.Text = "-";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 6;
            this.menuItemAbout.Text = "About ZeroitCodeTextBoxRuler...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 7;
            this.menuItemExit.Text = "Exit ZeroitCodeTextBoxRuler";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // ZeroitCodeTextBoxRuler
            // 
            //this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            //this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(400, 45);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.MinimumSize = new System.Drawing.Size(45, 45);
            this.Name = "ZeroitCodeTextBoxRuler";

            this.Text = "ZeroitCodeTextBoxRuler";

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ruler_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseDown);
            this.Load += new System.EventHandler(this.Ruler_Load);
            this.DoubleClick += new System.EventHandler(this.menuItemFlip_Click);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ruler_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseMove);

        }
        #endregion


        //---------------------------------------------------------------------

        /// <summary>
        /// The size
        /// </summary>
        private Size size;

        /// <summary>
        /// Ensures the visible.
        /// </summary>
        private void EnsureVisible()
        {
            Rectangle screen = Screen.FromControl(this).Bounds;
            Rectangle ruler = this.Bounds;
            Rectangle r = Rectangle.Intersect(screen, ruler);
            int w = this.MinimumSize.Width / 2;
            if (r.Width < w)
            {
                this.Location = new Point(
                    Math.Max(screen.X - ruler.Width + w, Math.Min(ruler.X, screen.Right - w)),
                    this.Location.Y
                );
            }
            int h = this.MinimumSize.Height / 2;
            if (r.Height < h)
            {
                this.Location = new Point(
                    this.Location.X,
                    Math.Max(screen.Y - ruler.Height + h, Math.Min(ruler.Y, screen.Bottom - h))
                );
            }
        }

        /// <summary>
        /// The horizontal
        /// </summary>
        private bool horizontal;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRulerKanta" /> is horizontal.
        /// </summary>
        /// <value><c>true</c> if horizontal; otherwise, <c>false</c>.</value>
        public bool Horizontal
        {
            get { return this.horizontal; }
            set
            {
                this.horizontal = value;
                if (this.horizontal)
                {
                    this.Size = new Size(this.size.Width, this.MinimumSize.Height);
                }
                else
                {
                    this.Size = new Size(this.MinimumSize.Width, this.size.Height);
                }
                this.EnsureVisible();
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The move point
        /// </summary>
        private Point movePoint;
        /// <summary>
        /// The is moving
        /// </summary>
        private bool isMoving = false;
        /// <summary>
        /// The is left sizing
        /// </summary>
        private bool isLeftSizing = false;
        /// <summary>
        /// The is right sizing
        /// </summary>
        private bool isRightSizing = false;
        /// <summary>
        /// The is top sizing
        /// </summary>
        private bool isTopSizing = false;
        /// <summary>
        /// The is bottom sizing
        /// </summary>
        private bool isBottomSizing = false;

        /// <summary>
        /// Handles the MouseDown event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks <= 1 && e.Button == MouseButtons.Left)
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3)
                    {
                        this.isLeftSizing = this.Capture = true;
                    }
                    else if (e.X >= this.Width - 3)
                    {
                        this.isRightSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                else
                {
                    if (e.Y <= 3)
                    {
                        this.isTopSizing = this.Capture = true;
                    }
                    else if (e.Y >= this.Height - 3)
                    {
                        this.isBottomSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                this.movePoint = this.PointToScreen(new Point(e.X, e.Y));
            }
        }
        /// <summary>
        /// Handles the MouseUp event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Capture && e.Button == MouseButtons.Left)
            {
                this.isMoving =
                this.isLeftSizing =
                this.isRightSizing =
                this.isTopSizing =
                this.isBottomSizing =
                this.Capture = false;
                this.EnsureVisible();
                this.Invalidate();
            }
        }
        /// <summary>
        /// Handles the MouseMove event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Capture)
            {
                Point p = this.PointToScreen(new Point(e.X, e.Y));
                Rectangle ruler = this.Bounds;
                Size min = this.MinimumSize;
                if (this.isMoving)
                {
                    this.Location = new Point(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y + p.Y - this.movePoint.Y
                    );
                }
                else if (this.isLeftSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y,
                        ruler.Width - p.X + this.movePoint.X,
                        min.Height
                    );
                    this.size.Width = this.Width;
                }
                else if (this.isRightSizing)
                {
                    this.Size = new Size(ruler.Width + p.X - this.movePoint.X, ruler.Height);
                    this.size.Width = this.Width;
                }
                else if (this.isTopSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X,
                        ruler.Y + p.Y - this.movePoint.Y,
                        min.Width,
                        ruler.Height - p.Y + this.movePoint.Y
                    );
                    this.size.Height = this.Height;
                }
                else if (this.isBottomSizing)
                {
                    this.Size = new Size(min.Width, ruler.Height + p.Y - this.movePoint.Y);
                    this.size.Height = this.Height;
                }
                this.movePoint = p;
                //this.Invalidate();
            }
            else
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3 || e.X >= this.Width - 3)
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (e.Y <= 3 || e.Y >= this.Height - 3)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void Ruler_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int step = e.Shift ? 10 : 1;
            if (e.KeyCode == Keys.Left)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width -= step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X - step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width += step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X + step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height -= step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height += step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Handles the Click event of the menuItemFlip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemFlip_Click(object sender, System.EventArgs e)
        {
            this.Horizontal = !this.Horizontal;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemPixel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemPixel_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = true;
            this.menuItemInch.Checked = false;
            this.menuItemCentimeter.Checked = false;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemInch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemInch_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = false;
            this.menuItemInch.Checked = true;
            this.menuItemCentimeter.Checked = false;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemCentimeter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemCentimeter_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = false;
            this.menuItemInch.Checked = false;
            this.menuItemCentimeter.Checked = true;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemAbout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            using (RulerAbout dlg = new RulerAbout())
            {
                dlg.ShowDialog(this);
            }
        }
        /// <summary>
        /// Handles the Click event of the menuItemExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The pen
        /// </summary>
        private Pen pen;
        /// <summary>
        /// The format
        /// </summary>
        private StringFormat format;
        /// <summary>
        /// Handles the Paint event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void Ruler_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int scale;
            int step;
            int small;
            int big;
            int number;
            string unit;
            if (this.menuItemPixel.Checked)
            {
                step = 5;
                small = 10;
                big = 50;
                number = 100;
                scale = 1;
                unit = " Pixels";
            }
            else if (this.menuItemInch.Checked)
            {
                g.PageUnit = GraphicsUnit.Inch;
                g.PageScale = 1f / 12f;
                step = 1;
                small = 2;
                big = 6;
                number = 12;
                scale = 12;
                unit = "\"";
            }
            else
            { //Cm.
                g.PageUnit = GraphicsUnit.Millimeter;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " Cm.";
            }
            PointF[] point = new PointF[] {
                new PointF(2, 2), new PointF(5, 5), new Point(this.Size), this.Location
            };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, point);
            float infoDelta = this.Horizontal ? point[0].Y : point[0].X;
            float stroke = this.Horizontal ? point[1].Y : point[1].X;
            int length = (int)(point[2].X + point[2].Y);

            if (!this.Horizontal)
            {
                g.RotateTransform(90, MatrixOrder.Prepend);
                g.TranslateTransform(point[2].X, 0, MatrixOrder.Append);
            }

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0)
                {
                    if (i % big == 0)
                    {
                        d = 3;
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, i, 0f, i, d * stroke);
                if ((i % number) == 0)
                {
                    string text = (i / scale).ToString(CultureInfo.InvariantCulture);
                    SizeF size = g.MeasureString(text, this.Font, length, this.format);
                    g.DrawString(text, this.Font, new SolidBrush(ForeColor), i - size.Width / 2, d * stroke, this.format);
                }
            }
            string info = string.Format(CultureInfo.InvariantCulture,
                "X={0} Y={1} Length={2}{3}",
                Math.Round(point[3].X / scale, 1),
                Math.Round(point[3].Y / scale, 1),
                Math.Round((float)(this.Horizontal ? point[2].X : point[2].Y) / scale, 1),
                unit
            );
            SizeF infoSize = g.MeasureString(info, this.Font, length, this.format);
            float y = (float)(this.Horizontal ? point[2].Y : point[2].X);
            g.DrawString(info, this.Font, new SolidBrush(ForeColor),
                (y - infoSize.Height) / 2, y - infoSize.Height - infoDelta, this.format
            );
        }
    }

    #endregion

    #region About
    /// <summary>
    /// Summary description for About.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class RulerAbout : System.Windows.Forms.Form
    {
        /// <summary>
        /// The button ok
        /// </summary>
        private System.Windows.Forms.Button buttonOk;
        /// <summary>
        /// The label header
        /// </summary>
        private System.Windows.Forms.Label labelHeader;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RulerAbout"/> class.
        /// </summary>
        public RulerAbout()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOk.Location = new System.Drawing.Point(264, 160);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&OK";
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(40, 16);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(216, 23);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Screen ZeroitCodeTextBoxRuler";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doubleclick will flip the ZeroitCodeTextBoxRuler";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(56, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Use arrow keys to move the ZeroitCodeTextBoxRuler";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(72, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ctrl + arrow key resize it";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(72, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Shift + arrow key move or resize it faster";
            // 
            // About
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(346, 192);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zeroit ZeroitCodeTextBoxRuler";
            this.ResumeLayout(false);

        }
        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitRulerKantaDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRulerKantaDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRulerKantaDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRulerKantaSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRulerKantaSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRulerKantaSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRulerKanta colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRulerKantaSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRulerKantaSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRulerKanta;

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
        /// Gets or sets a value indicating whether this <see cref="ZeroitRulerKantaSmartTagActionList"/> is horizontal.
        /// </summary>
        /// <value><c>true</c> if horizontal; otherwise, <c>false</c>.</value>
        public bool Horizontal
        {
            get
            {
                return colUserControl.Horizontal;
            }
            set
            {
                GetPropertyByName("Horizontal").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Horizontal",
                                 "Horizontal", "Appearance",
                                 "Set to Enable either horizontal or vertical mode."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));



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
