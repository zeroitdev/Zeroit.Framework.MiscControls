// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AyebiTabStrip.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class AyebiTabStripSelectedTabChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class AyebiTabStripSelectedTabChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The selected tab
        /// </summary>
        public readonly TabStripButton SelectedTab;

        /// <summary>
        /// Initializes a new instance of the <see cref="AyebiTabStripSelectedTabChangedEventArgs"/> class.
        /// </summary>
        /// <param name="tab">The tab.</param>
        public AyebiTabStripSelectedTabChangedEventArgs(TabStripButton tab)
        {
            SelectedTab = tab;
        }

    }

    /// <summary>
    /// A class collection for rendering tab strip control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStrip" />
    public class ZeroitAyebiTabStrip : ToolStrip
    {
        /// <summary>
        /// My renderer
        /// </summary>
        private TabStripRenderer myRenderer = new TabStripRenderer();
        /// <summary>
        /// My sel tab
        /// </summary>
        protected TabStripButton mySelTab;
        /// <summary>
        /// The ins page
        /// </summary>
        DesignerVerb insPage = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyebiTabStrip" /> class.
        /// </summary>
        public ZeroitAyebiTabStrip() : base()
        {
            InitControl();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyebiTabStrip" /> class.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        public ZeroitAyebiTabStrip(params TabStripButton[] buttons) : base(buttons)
        {
            InitControl();
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected void InitControl()
        {
            base.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            base.Renderer = myRenderer;
            myRenderer.RenderMode = this.RenderStyle;
            insPage = new DesignerVerb("Insert tab page", new EventHandler(OnInsertPageClicked));
        }

        /// <summary>
        /// Gets or sets the site of the control.
        /// </summary>
        /// <value>The site.</value>
        public override ISite Site
        {
            get
            {
                ISite site = base.Site;
                if (site != null && site.DesignMode)
                {
                    IContainer comp = site.Container;
                    if (comp != null)
                    {
                        IDesignerHost host = comp as IDesignerHost;
                        if (host != null)
                        {
                            IDesigner designer = host.GetDesigner(site.Component);
                            if (designer != null && !designer.Verbs.Contains(insPage))
                                designer.Verbs.Add(insPage);
                        }
                    }
                }
                return site;
            }
            set
            {
                base.Site = value;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:InsertPageClicked" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnInsertPageClicked(object sender, EventArgs e)
        {
            ISite site = base.Site;
            if (site != null && site.DesignMode)
            {
                IContainer container = site.Container;
                if (container != null)
                {
                    TabStripButton btn = new TabStripButton();
                    container.Add(btn);
                    btn.Text = btn.Name;
                }
            }
        }

        /// <summary>
        /// Gets custom renderer for TabStrip. Set operation has no effect
        /// </summary>
        /// <value>The renderer.</value>
        public new ToolStripRenderer Renderer
        {
            get { return myRenderer; }
            set { base.Renderer = myRenderer; }
        }

        /// <summary>
        /// Gets or sets layout style for TabStrip control
        /// </summary>
        /// <value>The layout style.</value>
        public new ToolStripLayoutStyle LayoutStyle
        {
            get { return base.LayoutStyle; }
            set
            {
                switch (value)
                {
                    case ToolStripLayoutStyle.StackWithOverflow:
                    case ToolStripLayoutStyle.HorizontalStackWithOverflow:
                    case ToolStripLayoutStyle.VerticalStackWithOverflow:
                        base.LayoutStyle = ToolStripLayoutStyle.StackWithOverflow;
                        break;
                    case ToolStripLayoutStyle.Table:
                        base.LayoutStyle = ToolStripLayoutStyle.Table;
                        break;
                    case ToolStripLayoutStyle.Flow:
                        base.LayoutStyle = ToolStripLayoutStyle.Flow;
                        break;
                    default:
                        base.LayoutStyle = ToolStripLayoutStyle.StackWithOverflow;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the render mode.
        /// </summary>
        /// <value>The render mode.</value>
        [Obsolete("Use RenderStyle instead")]
        [Browsable(false)]
        public new ToolStripRenderMode RenderMode
        {
            get { return base.RenderMode; }
            set { RenderStyle = value; }
        }

        /// <summary>
        /// Gets or sets render style for TabStrip, use it instead of
        /// </summary>
        /// <value>The render style.</value>
        [Category("Appearance")]
        [Description("Gets or sets render style for TabStrip. You should use this property instead of RenderMode.")]
        public ToolStripRenderMode RenderStyle
        {
            get { return myRenderer.RenderMode; }
            set
            {
                myRenderer.RenderMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets the internal spacing, in pixels, of the contents of a <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </summary>
        /// <value>The default padding.</value>
        protected override Padding DefaultPadding
        {
            get
            {
                return Padding.Empty;
            }
        }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return DefaultPadding; }
            set { }
        }

        /// <summary>
        /// Gets or sets if control should use system visual styles for painting items
        /// </summary>
        /// <value><c>true</c> if [use visual styles]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Specifies if TabStrip should use system visual styles for painting items")]
        public bool UseVisualStyles
        {
            get { return myRenderer.UseVS; }
            set
            {
                myRenderer.UseVS = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets if TabButtons should be drawn flipped
        /// </summary>
        /// <value><c>true</c> if [flip buttons]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Specifies if TabButtons should be drawn flipped (for right- and bottom-aligned TabStrips)")]
        public bool FlipButtons
        {
            get { return myRenderer.Mirrored; }
            set
            {
                myRenderer.Mirrored = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets currently selected tab
        /// </summary>
        /// <value>The selected tab.</value>
        /// <exception cref="System.ArgumentException">Cannot select TabButtons that do not belong to this TabStrip</exception>
        public TabStripButton SelectedTab
        {
            get { return mySelTab; }
            set
            {
                if (value == null)
                    return;
                if (mySelTab == value)
                    return;
                if (value.Owner != this)
                    throw new ArgumentException("Cannot select TabButtons that do not belong to this TabStrip");
                OnItemClicked(new ToolStripItemClickedEventArgs(value));
            }
        }

        /// <summary>
        /// Occurs when [selected tab changed].
        /// </summary>
        public event EventHandler<AyebiTabStripSelectedTabChangedEventArgs> SelectedTabChanged;

        /// <summary>
        /// Called when [tab selected].
        /// </summary>
        /// <param name="tab">The tab.</param>
        protected void OnTabSelected(TabStripButton tab)
        {
            this.Invalidate();
            if (SelectedTabChanged != null)
                SelectedTabChanged(this, new AyebiTabStripSelectedTabChangedEventArgs(tab));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs" /> that contains the event data.</param>
        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            base.OnItemAdded(e);
            if (e.Item is TabStripButton)
                SelectedTab = (TabStripButton)e.Item;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemClicked" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs" /> that contains the event data.</param>
        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            TabStripButton clickedBtn = e.ClickedItem as TabStripButton;
            if (clickedBtn != null)
            {
                this.SuspendLayout();
                mySelTab = clickedBtn;
                this.ResumeLayout();
                OnTabSelected(clickedBtn);
            }
            base.OnItemClicked(e);
        }

    }

    /// <summary>
    /// Represents a renderer class for TabStrip control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripRenderer" />
    internal class TabStripRenderer : ToolStripRenderer
    {
        /// <summary>
        /// The sel offset
        /// </summary>
        private const int selOffset = 2;

        /// <summary>
        /// The current renderer
        /// </summary>
        private ToolStripRenderer currentRenderer = null;
        /// <summary>
        /// The render mode
        /// </summary>
        private ToolStripRenderMode renderMode = ToolStripRenderMode.Custom;
        /// <summary>
        /// The mirrored
        /// </summary>
        private bool mirrored = false;
        /// <summary>
        /// The use vs
        /// </summary>
        private bool useVS = Application.RenderWithVisualStyles;

        /// <summary>
        /// Gets or sets render mode for this renderer
        /// </summary>
        /// <value>The render mode.</value>
        public ToolStripRenderMode RenderMode
        {
            get { return renderMode; }
            set
            {
                renderMode = value;
                switch (renderMode)
                {
                    case ToolStripRenderMode.Professional:
                        currentRenderer = new ToolStripProfessionalRenderer();
                        break;
                    case ToolStripRenderMode.System:
                        currentRenderer = new ToolStripSystemRenderer();
                        break;
                    default:
                        currentRenderer = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to mirror background
        /// </summary>
        /// <value><c>true</c> if mirrored; otherwise, <c>false</c>.</value>
        /// <remarks>Use false for left and top positions, true for right and bottom</remarks>
        public bool Mirrored
        {
            get { return mirrored; }
            set { mirrored = value; }
        }

        /// <summary>
        /// Returns if visual styles should be applied for drawing
        /// </summary>
        /// <value><c>true</c> if [use vs]; otherwise, <c>false</c>.</value>
        public bool UseVS
        {
            get { return useVS; }
            set
            {
                if (value && !Application.RenderWithVisualStyles)
                    return;
                useVS = value;
            }
        }

        /// <summary>
        /// Initializes the specified ts.
        /// </summary>
        /// <param name="ts">The ts.</param>
        protected override void Initialize(ToolStrip ts)
        {
            base.Initialize(ts);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBorder" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Color c = SystemColors.AppWorkspace;
            if (UseVS)
            {
                VisualStyleRenderer rndr = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
                c = rndr.GetColor(ColorProperty.BorderColorHint);
            }

            using (Pen p = new Pen(c))
            using (Pen p2 = new Pen(e.BackColor))
            {
                Rectangle r = e.ToolStrip.Bounds;
                int x1 = (Mirrored) ? 0 : r.Width - 1 - e.ToolStrip.Padding.Horizontal;
                int y1 = (Mirrored) ? 0 : r.Height - 1;
                if (e.ToolStrip.Orientation == Orientation.Horizontal)
                    e.Graphics.DrawLine(p, 0, y1, r.Width, y1);
                else
                {
                    e.Graphics.DrawLine(p, x1, 0, x1, r.Height);
                    if (!Mirrored)
                        for (int i = x1 + 1; i < r.Width; i++)
                            e.Graphics.DrawLine(p2, i, 0, i, r.Height);
                }
                foreach (ToolStripItem x in e.ToolStrip.Items)
                {
                    if (x.IsOnOverflow) continue;
                    TabStripButton btn = x as TabStripButton;
                    if (btn == null) continue;
                    Rectangle rc = btn.Bounds;
                    int x2 = (Mirrored) ? rc.Left : rc.Right;
                    int y2 = (Mirrored) ? rc.Top : rc.Bottom - 1;
                    int addXY = (Mirrored) ? 0 : 1;
                    if (e.ToolStrip.Orientation == Orientation.Horizontal)
                    {
                        e.Graphics.DrawLine(p, rc.Left, y2, rc.Right, y2);
                        if (btn.Checked) e.Graphics.DrawLine(p2, rc.Left + 2 - addXY, y2, rc.Right - 2 - addXY, y2);
                    }
                    else
                    {
                        e.Graphics.DrawLine(p, x2, rc.Top, x2, rc.Bottom);
                        if (btn.Checked) e.Graphics.DrawLine(p2, x2, rc.Top + 2 - addXY, x2, rc.Bottom - 2 - addXY);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawToolStripBackground(e);
            else
                base.OnRenderToolStripBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            ZeroitAyebiTabStrip tabs = e.ToolStrip as ZeroitAyebiTabStrip;
            TabStripButton tab = e.Item as TabStripButton;
            if (tabs == null || tab == null)
            {
                if (currentRenderer != null)
                    currentRenderer.DrawButtonBackground(e);
                else
                    base.OnRenderButtonBackground(e);
                return;
            }

            bool selected = tab.Checked;
            bool hovered = tab.Selected;
            int top = 0;
            int left = 0;
            int width = tab.Bounds.Width - 1;
            int height = tab.Bounds.Height - 1;
            Rectangle drawBorder;


            if (UseVS)
            {
                if (tabs.Orientation == Orientation.Horizontal)
                {
                    if (!selected)
                    {
                        top = selOffset;
                        height -= (selOffset - 1);
                    }
                    else
                        top = 1;
                    drawBorder = new Rectangle(0, 0, width, height);
                }
                else
                {
                    if (!selected)
                    {
                        left = selOffset;
                        width -= (selOffset - 1);
                    }
                    else
                        left = 1;
                    drawBorder = new Rectangle(0, 0, height, width);
                }
                using (Bitmap b = new Bitmap(drawBorder.Width, drawBorder.Height))
                {
                    VisualStyleElement el = VisualStyleElement.Tab.TabItem.Normal;
                    if (selected)
                        el = VisualStyleElement.Tab.TabItem.Pressed;
                    if (hovered)
                        el = VisualStyleElement.Tab.TabItem.Hot;
                    if (!tab.Enabled)
                        el = VisualStyleElement.Tab.TabItem.Disabled;

                    if (!selected || hovered) drawBorder.Width++; else drawBorder.Height++;

                    using (Graphics gr = Graphics.FromImage(b))
                    {
                        VisualStyleRenderer rndr = new VisualStyleRenderer(el);
                        rndr.DrawBackground(gr, drawBorder);

                        if (tabs.Orientation == Orientation.Vertical)
                        {
                            if (Mirrored)
                                b.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            else
                                b.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        else
                        {
                            if (Mirrored)
                                b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }
                        if (Mirrored)
                        {
                            left = tab.Bounds.Width - b.Width - left;
                            top = tab.Bounds.Height - b.Height - top;
                        }
                        g.DrawImage(b, left, top);
                    }
                }
            }
            else
            {
                if (tabs.Orientation == Orientation.Horizontal)
                {
                    if (!selected)
                    {
                        top = selOffset;
                        height -= (selOffset - 1);
                    }
                    else
                        top = 1;
                    if (Mirrored)
                    {
                        left = 1;
                        top = 0;
                    }
                    else
                        top++;
                    width--;
                }
                else
                {
                    if (!selected)
                    {
                        left = selOffset;
                        width--;
                    }
                    else
                        left = 1;
                    if (Mirrored)
                    {
                        left = 0;
                        top = 1;
                    }
                }
                height--;
                drawBorder = new Rectangle(left, top, width, height);

                using (GraphicsPath gp = new GraphicsPath())
                {
                    if (Mirrored && tabs.Orientation == Orientation.Horizontal)
                    {
                        gp.AddLine(drawBorder.Left, drawBorder.Top, drawBorder.Left, drawBorder.Bottom - 2);
                        gp.AddArc(drawBorder.Left, drawBorder.Bottom - 3, 2, 2, 90, 90);
                        gp.AddLine(drawBorder.Left + 2, drawBorder.Bottom, drawBorder.Right - 2, drawBorder.Bottom);
                        gp.AddArc(drawBorder.Right - 2, drawBorder.Bottom - 3, 2, 2, 0, 90);
                        gp.AddLine(drawBorder.Right, drawBorder.Bottom - 2, drawBorder.Right, drawBorder.Top);
                    }
                    else if (!Mirrored && tabs.Orientation == Orientation.Horizontal)
                    {
                        gp.AddLine(drawBorder.Left, drawBorder.Bottom, drawBorder.Left, drawBorder.Top + 2);
                        gp.AddArc(drawBorder.Left, drawBorder.Top + 1, 2, 2, 180, 90);
                        gp.AddLine(drawBorder.Left + 2, drawBorder.Top, drawBorder.Right - 2, drawBorder.Top);
                        gp.AddArc(drawBorder.Right - 2, drawBorder.Top + 1, 2, 2, 270, 90);
                        gp.AddLine(drawBorder.Right, drawBorder.Top + 2, drawBorder.Right, drawBorder.Bottom);
                    }
                    else if (Mirrored && tabs.Orientation == Orientation.Vertical)
                    {
                        gp.AddLine(drawBorder.Left, drawBorder.Top, drawBorder.Right - 2, drawBorder.Top);
                        gp.AddArc(drawBorder.Right - 2, drawBorder.Top + 1, 2, 2, 270, 90);
                        gp.AddLine(drawBorder.Right, drawBorder.Top + 2, drawBorder.Right, drawBorder.Bottom - 2);
                        gp.AddArc(drawBorder.Right - 2, drawBorder.Bottom - 3, 2, 2, 0, 90);
                        gp.AddLine(drawBorder.Right - 2, drawBorder.Bottom, drawBorder.Left, drawBorder.Bottom);
                    }
                    else
                    {
                        gp.AddLine(drawBorder.Right, drawBorder.Top, drawBorder.Left + 2, drawBorder.Top);
                        gp.AddArc(drawBorder.Left, drawBorder.Top + 1, 2, 2, 180, 90);
                        gp.AddLine(drawBorder.Left, drawBorder.Top + 2, drawBorder.Left, drawBorder.Bottom - 2);
                        gp.AddArc(drawBorder.Left, drawBorder.Bottom - 3, 2, 2, 90, 90);
                        gp.AddLine(drawBorder.Left + 2, drawBorder.Bottom, drawBorder.Right, drawBorder.Bottom);
                    }

                    if (selected || hovered)
                    {
                        Color fill = (hovered) ? Color.WhiteSmoke : Color.White;
                        if (renderMode == ToolStripRenderMode.Professional)
                        {
                            fill = (hovered) ? ProfessionalColors.ButtonCheckedGradientBegin : ProfessionalColors.ButtonCheckedGradientEnd;
                            using (LinearGradientBrush br = new LinearGradientBrush(tab.ContentRectangle, fill, ProfessionalColors.ButtonCheckedGradientMiddle, LinearGradientMode.Vertical))
                                g.FillPath(br, gp);
                        }
                        else
                            using (SolidBrush br = new SolidBrush(fill))
                                g.FillPath(br, gp);
                    }
                    using (Pen p = new Pen((selected) ? ControlPaint.Dark(SystemColors.AppWorkspace) : SystemColors.AppWorkspace))
                        g.DrawPath(p, gp);
                }
            }

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemImage" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemImageRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle rc = e.ImageRectangle;
            TabStripButton btn = e.Item as TabStripButton;
            if (btn != null)
            {
                int delta = ((Mirrored) ? -1 : 1) * ((btn.Checked) ? 1 : selOffset);
                if (e.ToolStrip.Orientation == Orientation.Horizontal)
                    rc.Offset((Mirrored) ? 2 : 1, delta + ((Mirrored) ? 1 : 0));
                else
                    rc.Offset(delta + 2, 0);
            }
            ToolStripItemImageRenderEventArgs x =
                new ToolStripItemImageRenderEventArgs(e.Graphics, e.Item, e.Image, rc);
            if (currentRenderer != null)
                currentRenderer.DrawItemImage(x);
            else
                base.OnRenderItemImage(x);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemText" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemTextRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            Rectangle rc = e.TextRectangle;
            TabStripButton btn = e.Item as TabStripButton;
            Color c = e.TextColor;
            Font f = e.TextFont;
            if (btn != null)
            {
                int delta = ((Mirrored) ? -1 : 1) * ((btn.Checked) ? 1 : selOffset);
                if (e.ToolStrip.Orientation == Orientation.Horizontal)
                    rc.Offset((Mirrored) ? 2 : 1, delta + ((Mirrored) ? 1 : -1));
                else
                    rc.Offset(delta + 2, 0);
                if (btn.Selected)
                    c = btn.HotTextColor;
                else if (btn.Checked)
                    c = btn.SelectedTextColor;
                if (btn.Checked)
                    f = btn.SelectedFont;
            }
            ToolStripItemTextRenderEventArgs x =
                new ToolStripItemTextRenderEventArgs(e.Graphics, e.Item, e.Text, rc, c, f, e.TextFormat);
            x.TextDirection = e.TextDirection;
            if (currentRenderer != null)
                currentRenderer.DrawItemText(x);
            else
                base.OnRenderItemText(x);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderArrow" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripArrowRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawArrow(e);
            else
                base.OnRenderArrow(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderDropDownButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawDropDownButtonBackground(e);
            else
                base.OnRenderDropDownButtonBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderGrip" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripGripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawGrip(e);
            else
                base.OnRenderGrip(e);
        }

        /// <summary>
        /// Draws the item background.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawImageMargin(e);
            else
                base.OnRenderImageMargin(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ToolStripSystemRenderer.OnRenderItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawItemBackground(e);
            else
                base.OnRenderItemBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemCheck" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemImageRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawItemCheck(e);
            else
                base.OnRenderItemCheck(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderLabelBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawLabelBackground(e);
            else
                base.OnRenderLabelBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderMenuItemBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawMenuItemBackground(e);
            else
                base.OnRenderMenuItemBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderOverflowButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawOverflowButtonBackground(e);
            else
                base.OnRenderOverflowButtonBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderSeparator" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripSeparatorRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawSeparator(e);
            else
                base.OnRenderSeparator(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ToolStripRenderer.OnRenderSplitButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawSplitButton(e);
            else
                base.OnRenderSplitButtonBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderStatusStripSizingGrip" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawStatusStripSizingGrip(e);
            else
                base.OnRenderStatusStripSizingGrip(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripContentPanelBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripContentPanelRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawToolStripContentPanelBackground(e);
            else
                base.OnRenderToolStripContentPanelBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripPanelBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripPanelRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawToolStripPanelBackground(e);
            else
                base.OnRenderToolStripPanelBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripStatusLabelBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
            if (currentRenderer != null)
                currentRenderer.DrawToolStripStatusLabelBackground(e);
            else
                base.OnRenderToolStripStatusLabelBackground(e);
        }
    }

    /// <summary>
    /// Represents a TabButton for TabStrip control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripButton" />
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class TabStripButton : ToolStripButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        public TabStripButton() : base() { InitButton(); }
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public TabStripButton(Image image) : base(image) { InitButton(); }
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public TabStripButton(string text) : base(text) { InitButton(); }
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public TabStripButton(string text, Image image) : base(text, image) { InitButton(); }
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Image">The image.</param>
        /// <param name="Handler">The handler.</param>
        public TabStripButton(string Text, Image Image, EventHandler Handler) : base(Text, Image, Handler) { InitButton(); }
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripButton"/> class.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Image">The image.</param>
        /// <param name="Handler">The handler.</param>
        /// <param name="name">The name.</param>
        public TabStripButton(string Text, Image Image, EventHandler Handler, string name) : base(Text, Image, Handler, name) { InitButton(); }

        /// <summary>
        /// Initializes the button.
        /// </summary>
        private void InitButton()
        {
            m_SelectedFont = this.Font;
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a <see cref="T:System.Windows.Forms.ToolStripButton" /> can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The specified area for a <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public override Size GetPreferredSize(Size constrainingSize)
        {
            Size sz = base.GetPreferredSize(constrainingSize);
            if (this.Owner != null && this.Owner.Orientation == Orientation.Vertical)
            {
                sz.Width += 3;
                sz.Height += 10;
            }
            return sz;
        }

        /// <summary>
        /// Gets the default margin of an item.
        /// </summary>
        /// <value>The default margin.</value>
        protected override Padding DefaultMargin
        {
            get
            {
                return new Padding(0);
            }
        }

        /// <summary>
        /// Gets or sets the space between the item and adjacent items.
        /// </summary>
        /// <value>The margin.</value>
        [Browsable(false)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { }
        }

        /// <summary>
        /// Gets or sets the internal spacing, in pixels, between the item's contents and its edges.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { }
        }

        /// <summary>
        /// The m hot text color
        /// </summary>
        private Color m_HotTextColor = Control.DefaultForeColor;

        /// <summary>
        /// Gets or sets the color of the hot text.
        /// </summary>
        /// <value>The color of the hot text.</value>
        [Category("Appearance")]
        [Description("Text color when TabButton is highlighted")]
        public Color HotTextColor
        {
            get { return m_HotTextColor; }
            set { m_HotTextColor = value; }
        }

        /// <summary>
        /// The m selected text color
        /// </summary>
        private Color m_SelectedTextColor = Control.DefaultForeColor;

        /// <summary>
        /// Gets or sets the color of the selected text.
        /// </summary>
        /// <value>The color of the selected text.</value>
        [Category("Appearance")]
        [Description("Text color when TabButton is selected")]
        public Color SelectedTextColor
        {
            get { return m_SelectedTextColor; }
            set { m_SelectedTextColor = value; }
        }

        /// <summary>
        /// The m selected font
        /// </summary>
        private Font m_SelectedFont;

        /// <summary>
        /// Gets or sets the selected font.
        /// </summary>
        /// <value>The selected font.</value>
        [Category("Appearance")]
        [Description("Font when TabButton is selected")]
        public Font SelectedFont
        {
            get { return (m_SelectedFont == null) ? this.Font : m_SelectedFont; }
            set { m_SelectedFont = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripButton" /> is pressed or not pressed.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DefaultValue(false)]
        public new bool Checked
        {
            get { return IsSelected; }
            set { }
        }

        /// <summary>
        /// Gets or sets if this TabButton is currently selected
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsSelected
        {
            get
            {
                ZeroitAyebiTabStrip owner = Owner as ZeroitAyebiTabStrip;
                if (owner != null)
                    return (this == owner.SelectedTab);
                return false;
            }
            set
            {
                if (value == false) return;
                ZeroitAyebiTabStrip owner = Owner as ZeroitAyebiTabStrip;
                if (owner == null) return;
                owner.SelectedTab = this;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.OwnerChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <exception cref="System.Exception">Cannot add TabStripButton to " + Owner.GetType().Name</exception>
        protected override void OnOwnerChanged(EventArgs e)
        {
            if (Owner != null && !(Owner is ZeroitAyebiTabStrip))
                throw new Exception("Cannot add TabStripButton to " + Owner.GetType().Name);
            base.OnOwnerChanged(e);
        }

    }
}
