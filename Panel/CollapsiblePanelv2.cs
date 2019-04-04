// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsiblePanelv2.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    #region Collapsible Panel

    #region Collapsible Panel

    #region Control    
    /// <summary>
    /// A class collection for rendering a collapsible panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitCollapsiblePanelDesigner))]
    [ToolboxBitmap(typeof(ZeroitCollapsiblePanel), "OVT.CustomControls.CollapsiblePanel.bmp")]
    [DefaultProperty("HeaderText")]
    public partial class ZeroitCollapsiblePanel : Panel
    {

        #region "Private members"

        /// <summary>
        /// The collapse
        /// </summary>
        private bool collapse = false;
        /// <summary>
        /// The original hight
        /// </summary>
        private int originalHight = 0;
        /// <summary>
        /// The use animation
        /// </summary>
        private bool useAnimation;
        /// <summary>
        /// The show header separator
        /// </summary>
        private bool showHeaderSeparator = true;
        /// <summary>
        /// The rounded corners
        /// </summary>
        private bool roundedCorners;
        /// <summary>
        /// The header corners radius
        /// </summary>
        private int headerCornersRadius = 10;
        /// <summary>
        /// The header text automatic ellipsis
        /// </summary>
        private bool headerTextAutoEllipsis;
        /// <summary>
        /// The header text
        /// </summary>
        private string headerText;
        /// <summary>
        /// The header text color
        /// </summary>
        private Color headerTextColor;
        /// <summary>
        /// The header image
        /// </summary>
        private Image headerImage;
        /// <summary>
        /// The header font
        /// </summary>
        private Font headerFont;
        /// <summary>
        /// The tool tip rectangle
        /// </summary>
        private RectangleF toolTipRectangle = new RectangleF();
        /// <summary>
        /// The use tool tip
        /// </summary>
        private bool useToolTip = false;

        /// <summary>
        /// The header back1
        /// </summary>
        private Color headerBack1 = Color.Snow;
        /// <summary>
        /// The header back2
        /// </summary>
        private Color headerBack2 = Color.LightBlue;

        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// The header gradient mode
        /// </summary>
        private LinearGradientMode headerGradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        /// <summary>
        /// The seperatorborder
        /// </summary>
        private int seperatorborder = 2;

        #endregion 


        #region "Public Properties"        
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
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the seperator.
        /// </summary>
        /// <value>The width of the seperator.</value>
        public int SeperatorWidth
        {
            get { return seperatorborder; }
            set
            {
                seperatorborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the header gradient mode.
        /// </summary>
        /// <value>The header gradient mode.</value>
        public LinearGradientMode HeaderGradMode
        {
            get { return headerGradientMode; }
            set
            {
                headerGradientMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the header color.
        /// </summary>
        /// <value>The header color1.</value>
        public Color HeaderColor1
        {
            get { return headerBack1; }
            set
            {
                headerBack1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the header color.
        /// </summary>
        /// <value>The header color2.</value>
        public Color HeaderColor2
        {
            get { return headerBack2; }
            set
            {
                headerBack2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public new Color BackColor
        {
            get
            {
                return Color.Transparent;

            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCollapsiblePanel" /> allows collapse.
        /// </summary>
        /// <value><c>true</c> if collapse; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Collapses the control when set to true")]
        [Category("CollapsiblePanel")]
        public bool Collapse
        {
            get { return collapse; }
            set
            {
                // If using animation make sure to ignore requests for collapse or expand while a previous
                // operation is in progress.
                if (useAnimation)
                {
                    // An operation is already in progress.
                    if (timerAnimation.Enabled)
                    {
                        return;
                    }
                }
                collapse = value;
                CollapseOrExpand();
                Refresh();
            }
        }

        /// <summary>
        /// Specifies the speed (in ms) of Expand/Collapse operation when using animation. UseAnimation property must be set to true.
        /// </summary>
        /// <value>The animation interval.</value>
        [DefaultValue(50)]
        [Category("CollapsiblePanel")]
        [Description("Specifies the speed (in ms) of Expand/Collapse operation when using animation. UseAnimation property must be set to true.")]
        public int AnimationInterval
        {
            get
            {
                return timerAnimation.Interval;
            }
            set
            {
                // Update animation interval only during idle times.
                if (!timerAnimation.Enabled)
                    timerAnimation.Interval = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use animation.
        /// </summary>
        /// <value><c>true</c> if use animation; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category("CollapsiblePanel")]
        [Description("Indicate if the panel uses amination during Expand/Collapse operation")]
        public bool UseAnimation
        {
            get { return useAnimation; }
            set { useAnimation = value; }
        }

        /// <summary>
        /// When set to true draws panel borders, and shows a line separating the panel's header from the rest of the control.
        /// </summary>
        /// <value><c>true</c> if show header separator; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Category("CollapsiblePanel")]
        [Description("When set to true draws panel borders, and shows a line separating the panel's header from the rest of the control")]
        public bool ShowHeaderSeparator
        {
            get { return showHeaderSeparator; }
            set
            {
                showHeaderSeparator = value;
                Refresh();
            }
        }

        /// <summary>
        /// When set to true, draws a panel with rounded top corners, the radius can bet set through HeaderCornersRadius property.
        /// </summary>
        /// <value><c>true</c> if rounded corners; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category("CollapsiblePanel")]
        [Description("When set to true, draws a panel with rounded top corners, the radius can bet set through HeaderCornersRadius property")]
        public bool RoundedCorners
        {
            get
            {
                return roundedCorners;
            }
            set
            {
                roundedCorners = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the header corners radius. It should be in [1, 15] range
        /// </summary>
        /// <value>The header corners radius.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">HeaderCornersRadius - Value should be in range [1, 90]</exception>
        /// <exception cref="ArgumentOutOfRangeException">HeaderCornersRadius - Value should be in range [1, 90]</exception>
        [DefaultValue(10)]
        [Category("CollapsiblePanel")]
        [Description("Top corners radius, it should be in [1, 15] range")]
        public int HeaderCornersRadius
        {
            get
            {
                return headerCornersRadius;
            }

            set
            {
                if (value < 1 || value > 15)
                    throw new ArgumentOutOfRangeException("HeaderCornersRadius", value, "Value should be in range [1, 90]");
                else
                {
                    headerCornersRadius = value;
                    Refresh();
                }
            }
        }


        /// <summary>
        /// Enables the automatic handling of text that extends beyond the width of the label control.
        /// </summary>
        /// <value><c>true</c> if header text automatic ellipsis; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category("CollapsiblePanel")]
        [Description("Enables the automatic handling of text that extends beyond the width of the label control.")]
        public bool HeaderTextAutoEllipsis
        {
            get { return headerTextAutoEllipsis; }
            set
            {
                headerTextAutoEllipsis = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>The header text.</value>
        [Category("CollapsiblePanel")]
        [Description("Text to show in panel's header")]
        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the header text.
        /// </summary>
        /// <value>The color of the header text.</value>
        [Category("CollapsiblePanel")]
        [Description("Color of text header, and panel's borders when ShowHeaderSeparator is set to true")]
        public Color HeaderTextColor
        {
            get { return headerTextColor; }
            set
            {
                headerTextColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the header image. Image that will be displayed in the top left corner of the panel.
        /// </summary>
        /// <value>The header image.</value>
        [Category("CollapsiblePanel")]
        [Description("Image that will be displayed in the top left corner of the panel")]
        public Image HeaderImage
        {
            get { return headerImage; }
            set
            {
                headerImage = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the header font.
        /// </summary>
        /// <value>The header font.</value>
        [Category("CollapsiblePanel")]
        [Description("The font used to display text in the panel's header.")]
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                Refresh();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsiblePanel" /> class.
        /// </summary>
        public ZeroitCollapsiblePanel()
        {
            InitializeComponent();
            this.pnlHeader.Width = this.Width - 1;

            headerFont = new Font(Font, FontStyle.Bold);
            headerTextColor = Color.Black;
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


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = smoothing;
            DrawHeaderPanel(e);
        }

        /// <summary>
        /// Draws the header corners.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public void DrawHeaderCorners(Graphics g, Brush brush, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height); // Line
            gp.AddLine(x + width, y + height, x, y + height); // Line
            gp.AddLine(x, y + height, x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();
            g.FillPath(brush, gp);
            if (showHeaderSeparator)
            {
                g.DrawPath(new Pen(headerTextColor), gp);
            }
            gp.Dispose();
        }

        /// <summary>
        /// Draws the header panel.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawHeaderPanel(PaintEventArgs e)
        {
            Rectangle headerRect = pnlHeader.ClientRectangle;
            LinearGradientBrush headerBrush = new LinearGradientBrush(
                headerRect, headerBack1, headerBack2, headerGradientMode);

            if (!roundedCorners)
            {
                e.Graphics.FillRectangle(headerBrush, headerRect);
                if (showHeaderSeparator)
                {
                    e.Graphics.DrawRectangle(new Pen(borderColor, borderWidth), headerRect);
                }
            }
            else
                DrawHeaderCorners(e.Graphics, headerBrush, headerRect.X, headerRect.Y,
                    headerRect.Width, headerRect.Height, headerCornersRadius);


            // Draw header separator
            if (showHeaderSeparator)
            {
                Point start = new Point(pnlHeader.Location.X, pnlHeader.Location.Y + pnlHeader.Height);
                Point end = new Point(pnlHeader.Location.X + pnlHeader.Width, pnlHeader.Location.Y + pnlHeader.Height);
                e.Graphics.DrawLine(new Pen(borderColor, seperatorborder), start, end);
                // Draw rectangle lines for the rest of the control.
                Rectangle bodyRect = this.ClientRectangle;
                bodyRect.Y += this.pnlHeader.Height;
                bodyRect.Height -= (this.pnlHeader.Height + 1);
                bodyRect.Width -= 1;
                e.Graphics.DrawRectangle(new Pen(borderColor, borderWidth), bodyRect);
            }

            int headerRectHeight = pnlHeader.Height;
            // Draw header image.
            if (headerImage != null)
            {
                pictureBoxImage.Image = headerImage;
                pictureBoxImage.Visible = true;
            }
            else
            {
                pictureBoxImage.Image = null;
                pictureBoxImage.Visible = false;
            }


            // Calculate header string position.
            if (!String.IsNullOrEmpty(headerText))
            {
                useToolTip = false;
                int delta = pictureBoxExpandCollapse.Width + 5;
                int offset = 0;
                if (headerImage != null)
                {
                    offset = headerRectHeight;
                }
                PointF headerTextPosition = new PointF();
                Size headerTextSize = TextRenderer.MeasureText(headerText, headerFont);
                if (headerTextAutoEllipsis)
                {
                    if (headerTextSize.Width >= headerRect.Width - (delta + offset))
                    {
                        RectangleF rectLayout =
                            new RectangleF((float)headerRect.X + offset,
                            (float)(headerRect.Height - headerTextSize.Height) / 2,
                            (float)headerRect.Width - delta,
                            (float)headerTextSize.Height);
                        StringFormat format = new StringFormat();
                        format.Trimming = StringTrimming.EllipsisWord;
                        e.Graphics.DrawString(headerText, headerFont, new SolidBrush(headerTextColor),
                            rectLayout, format);

                        toolTipRectangle = rectLayout;
                        useToolTip = true;
                    }
                    else
                    {
                        headerTextPosition.X = (offset + headerRect.Width - headerTextSize.Width) / 2;
                        headerTextPosition.Y = (headerRect.Height - headerTextSize.Height) / 2;
                        e.Graphics.DrawString(headerText, headerFont, new SolidBrush(headerTextColor),
                            headerTextPosition);
                    }
                }
                else
                {
                    headerTextPosition.X = (offset + headerRect.Width - headerTextSize.Width) / 2;
                    headerTextPosition.Y = (headerRect.Height - headerTextSize.Height) / 2;
                    e.Graphics.DrawString(headerText, headerFont, new SolidBrush(headerTextColor),
                        headerTextPosition);
                }

            }
        }

        /// <summary>
        /// Handles the Click event of the pictureBoxExpandCollapse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBoxExpandCollapse_Click(object sender, EventArgs e)
        {
            Collapse = !Collapse;
        }

        /// <summary>
        /// Collapses the or expand.
        /// </summary>
        private void CollapseOrExpand()
        {
            if (!useAnimation)
            {
                if (collapse)
                {
                    originalHight = this.Height;
                    this.Height = pnlHeader.Height + 3;
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxexpand;
                }
                else
                {
                    this.Height = originalHight;
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxcollapse;
                }
            }
            else
            {

                // Keep original height only in case of a collapse operation.
                if (collapse)
                    originalHight = this.Height;

                timerAnimation.Enabled = true;
                timerAnimation.Start();
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the pictureBoxExpandCollapse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void pictureBoxExpandCollapse_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timerAnimation.Enabled)
            {
                if (!collapse)
                {
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxcollapse_hightlight;
                }
                else
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxexpand_highlight;
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the pictureBoxExpandCollapse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBoxExpandCollapse_MouseLeave(object sender, EventArgs e)
        {
            if (!timerAnimation.Enabled)
            {
                if (!collapse)
                {
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxcollapse;
                }
                else
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxexpand;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.pnlHeader.Width = this.Width - 1;
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.pnlHeader.Width = this.Width - 1;
            Refresh();
        }

        /// <summary>
        /// Handles the Tick event of the timerAnimation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (collapse)
            {
                if (this.Height <= pnlHeader.Height + 3)
                {
                    timerAnimation.Stop();
                    timerAnimation.Enabled = false;
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxexpand;
                }
                else
                {
                    int newHight = this.Height - 20;
                    if (newHight <= pnlHeader.Height + 3)
                        newHight = pnlHeader.Height + 3;
                    this.Height = newHight;
                }


            }
            else
            {
                if (this.Height >= originalHight)
                {
                    timerAnimation.Stop();
                    timerAnimation.Enabled = false;
                    pictureBoxExpandCollapse.Image = Properties.Resources.zenxcollapse;
                }
                else
                {
                    int newHeight = this.Height + 20;
                    if (newHeight >= originalHight)
                        newHeight = originalHight;
                    this.Height = newHeight;
                }
            }
        }

        /// <summary>
        /// Handles the MouseHover event of the pnlHeader control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pnlHeader_MouseHover(object sender, EventArgs e)
        {
            if (useToolTip)
            {
                Point p = this.PointToClient(Control.MousePosition);
                if (toolTipRectangle.Contains(p))
                {
                    toolTip.Show(headerText, pnlHeader, p);
                }
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the pnlHeader control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pnlHeader_MouseLeave(object sender, EventArgs e)
        {
            if (useToolTip)
            {
                Point p = this.PointToClient(Control.MousePosition);
                if (!toolTipRectangle.Contains(p))
                {
                    toolTip.Hide(pnlHeader);
                }
            }
        }



    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitCollapsiblePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBoxExpandCollapse = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.pictureBoxExpandCollapse);
            this.pnlHeader.Controls.Add(this.pictureBoxImage);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(249, 30);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseLeave += new System.EventHandler(this.pnlHeader_MouseLeave);
            this.pnlHeader.MouseHover += new System.EventHandler(this.pnlHeader_MouseHover);
            // 
            // pictureBoxExpandCollapse
            // 
            this.pictureBoxExpandCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxExpandCollapse.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExpandCollapse.Image = Properties.Resources.zenxcollapse;
            this.pictureBoxExpandCollapse.Location = new System.Drawing.Point(224, 5);
            this.pictureBoxExpandCollapse.Name = "pictureBoxExpandCollapse";
            this.pictureBoxExpandCollapse.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxExpandCollapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExpandCollapse.TabIndex = 2;
            this.pictureBoxExpandCollapse.TabStop = false;
            this.pictureBoxExpandCollapse.MouseLeave += new System.EventHandler(this.pictureBoxExpandCollapse_MouseLeave);
            this.pictureBoxExpandCollapse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxExpandCollapse_MouseMove);
            this.pictureBoxExpandCollapse.Click += new System.EventHandler(this.pictureBoxExpandCollapse_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Visible = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 50;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // CollapsiblePanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHeader);
            this.Name = "CollapsiblePanel";
            this.Size = new System.Drawing.Size(250, 150);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandCollapse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The PNL header
        /// </summary>
        private System.Windows.Forms.Panel pnlHeader;
        /// <summary>
        /// The picture box expand collapse
        /// </summary>
        private System.Windows.Forms.PictureBox pictureBoxExpandCollapse;
        /// <summary>
        /// The picture box image
        /// </summary>
        private System.Windows.Forms.PictureBox pictureBoxImage;
        /// <summary>
        /// The timer animation
        /// </summary>
        private System.Windows.Forms.Timer timerAnimation;
        /// <summary>
        /// The tool tip
        /// </summary>
        private System.Windows.Forms.ToolTip toolTip;
    }

    #endregion

    #endregion

    #region Collapsible Panel ActionList

    /// <summary>
    /// Class ZeroitCollapsiblePanelActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCollapsiblePanelActionList : DesignerActionList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsiblePanelActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCollapsiblePanelActionList(IComponent component)
            : base(component)
        {

        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).HeaderText;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["HeaderText"];
                property.SetValue(this.Component, value);

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use animation].
        /// </summary>
        /// <value><c>true</c> if [use animation]; otherwise, <c>false</c>.</value>
        public bool UseAnimation
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).UseAnimation;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["UseAnimation"];
                property.SetValue(this.Component, value);

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCollapsiblePanelActionList"/> is collapsed.
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        public bool Collapsed
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).Collapse;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["Collapse"];
                property.SetValue(this.Component, value);

            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [show separator].
        /// </summary>
        /// <value><c>true</c> if [show separator]; otherwise, <c>false</c>.</value>
        public bool ShowSeparator
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).ShowHeaderSeparator;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["ShowHeaderSeparator"];
                property.SetValue(this.Component, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use rounded corner].
        /// </summary>
        /// <value><c>true</c> if [use rounded corner]; otherwise, <c>false</c>.</value>
        public bool UseRoundedCorner
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).RoundedCorners;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["RoundedCorners"];
                property.SetValue(this.Component, value);
            }
        }

        /// <summary>
        /// Gets or sets the header corners radius.
        /// </summary>
        /// <value>The header corners radius.</value>
        public int HeaderCornersRadius
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).HeaderCornersRadius;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["HeaderCornersRadius"];
                property.SetValue(this.Component, value);
            }
        }



        /// <summary>
        /// Gets or sets the header image.
        /// </summary>
        /// <value>The header image.</value>
        public Image HeaderImage
        {
            get
            {
                return ((ZeroitCollapsiblePanel)this.Component).HeaderImage;
            }
            set
            {
                PropertyDescriptor property = TypeDescriptor.GetProperties(this.Component)["HeaderImage"];
                property.SetValue(this.Component, value);
            }
        }



        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            items.Add(new DesignerActionHeaderItem("Header Parameters"));
            items.Add(new DesignerActionPropertyItem("Title", "Panel's header text"));
            items.Add(new DesignerActionPropertyItem("HeaderImage", "Image"));
            items.Add(new DesignerActionPropertyItem("UseAnimation", "Animated panel"));
            items.Add(new DesignerActionPropertyItem("Collapsed", "Collapse"));
            items.Add(new DesignerActionPropertyItem("ShowSeparator", "Show borders"));
            items.Add(new DesignerActionPropertyItem("UseRoundedCorner", "Rounded corners"));
            items.Add(new DesignerActionPropertyItem("HeaderCornersRadius", "Corner's radius [5,10]"));

            return items;


        }
    }

    #endregion

    #region CollapsiblePanelDesigner

    /// <summary>
    /// Class ZeroitCollapsiblePanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    public class ZeroitCollapsiblePanelDesigner : ParentControlDesigner
    {

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override System.ComponentModel.Design.DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection collection = new DesignerActionListCollection();
                if (this.Control != null && this.Control is ZeroitCollapsiblePanel)
                {
                    ZeroitCollapsiblePanel panel = (ZeroitCollapsiblePanel)this.Control;
                    if (!String.IsNullOrEmpty(panel.Name))
                    {
                        if (String.IsNullOrEmpty(panel.HeaderText))
                            panel.HeaderText = panel.Name;
                    }
                }

                collection.Add(new ZeroitCollapsiblePanelActionList(this.Control));

                return collection;
            }
        }





    }

    #endregion

    #endregion
}
