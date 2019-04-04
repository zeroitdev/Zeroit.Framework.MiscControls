// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FATabStrip.cs" company="Zeroit Dev Technologies">
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
    /// <summary>
    /// A class collection for rendering a tab strip control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.BaseStyledPanel" />
    /// <seealso cref="Zeroit.Framework.MiscControls.BaseClasses.BaseStyledPanel" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    /// <seealso cref="System.IDisposable" />
    [Designer(typeof (ZeroitFameyeTabStripDesigner))]
    [DefaultEvent("TabStripItemSelectionChanged")]
    [DefaultProperty("Items")]
    [ToolboxItem(true)]
    [ToolboxBitmap("FATabStrip.bmp")]
    public class ZeroitFameyeTabStrip : BaseStyledPanel, ISupportInitialize, IDisposable
    {
        #region Static Fields

        /// <summary>
        /// The preferred width
        /// </summary>
        internal static int PreferredWidth = 350;
        /// <summary>
        /// The preferred height
        /// </summary>
        internal static int PreferredHeight = 200;

        #endregion

        #region Constants

        /// <summary>
        /// The definition header height
        /// </summary>
        private const int DEF_HEADER_HEIGHT = 19;
        /// <summary>
        /// The definition glyph width
        /// </summary>
        private const int DEF_GLYPH_WIDTH = 40;

        /// <summary>
        /// The definition start position
        /// </summary>
        private int DEF_START_POS = 10;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [tab strip item closing].
        /// </summary>
        public event TabStripItemClosingHandler TabStripItemClosing;
        /// <summary>
        /// Occurs when [tab strip item selection changed].
        /// </summary>
        public event TabStripItemChangedHandler TabStripItemSelectionChanged;
        /// <summary>
        /// Occurs when [menu items loading].
        /// </summary>
        public event HandledEventHandler MenuItemsLoading;
        /// <summary>
        /// Occurs when [menu items loaded].
        /// </summary>
        public event EventHandler MenuItemsLoaded;
        /// <summary>
        /// Occurs when [tab strip item closed].
        /// </summary>
        public event EventHandler TabStripItemClosed;

        #endregion

        #region Fields

        /// <summary>
        /// The strip button rect
        /// </summary>
        private Rectangle stripButtonRect = Rectangle.Empty;
        /// <summary>
        /// The selected item
        /// </summary>
        private ZeroitFameyeTabStripItem selectedItem = null;
        /// <summary>
        /// The menu
        /// </summary>
        private ContextMenuStrip menu = null;
        /// <summary>
        /// The menu glyph
        /// </summary>
        private ZeroitFameyeTabStripMenuGlyph menuGlyph = null;
        /// <summary>
        /// The close button
        /// </summary>
        private ZeroitFameyeTabStripCloseButton closeButton = null;
        /// <summary>
        /// The items
        /// </summary>
        private FATabStripItemCollection items;
        /// <summary>
        /// The sf
        /// </summary>
        private StringFormat sf = null;
        /// <summary>
        /// The default font
        /// </summary>
        private static Font defaultFont = new Font("Tahoma", 8.25f, FontStyle.Regular);

        /// <summary>
        /// The always show close
        /// </summary>
        private bool alwaysShowClose = true;
        /// <summary>
        /// The is initing
        /// </summary>
        private bool isIniting = false;
        /// <summary>
        /// The always show menu glyph
        /// </summary>
        private bool alwaysShowMenuGlyph = true;
        /// <summary>
        /// The menu open
        /// </summary>
        private bool menuOpen = false;

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Returns hit test results
        /// </summary>
        /// <param name="pt">The pt.</param>
        /// <returns>HitTestResult.</returns>
        public HitTestResult HitTest(Point pt)
        {
            if(closeButton.Bounds.Contains(pt))
                return HitTestResult.CloseButton;
            
            if(menuGlyph.Bounds.Contains(pt))
                return HitTestResult.MenuGlyph;

            if (GetTabItemByPoint(pt) != null)
                return HitTestResult.TabItem;
            
            //No other result is available.
            return HitTestResult.None;
        }

        /// <summary>
        /// Add a <see cref="FATabStripItem" /> to this control without selecting it.
        /// </summary>
        /// <param name="tabItem">The tab item.</param>
        public void AddTab(ZeroitFameyeTabStripItem tabItem)
        {
            AddTab(tabItem, false);
        }

        /// <summary>
        /// Add a <see cref="FATabStripItem" /> to this control.
        /// User can make the currently selected item or not.
        /// </summary>
        /// <param name="tabItem">The tab item.</param>
        /// <param name="autoSelect">if set to <c>true</c> [automatic select].</param>
        public void AddTab(ZeroitFameyeTabStripItem tabItem, bool autoSelect)
        {
            tabItem.Dock = DockStyle.Fill;
            Items.Add(tabItem);

            if ((autoSelect && tabItem.Visible) || (tabItem.Visible && Items.DrawnCount < 1 ))
            {
                SelectedItem = tabItem;
                SelectItem(tabItem);
            }
        }

        /// <summary>
        /// Remove a <see cref="FATabStripItem" /> from this control.
        /// </summary>
        /// <param name="tabItem">The tab item.</param>
        public void RemoveTab(ZeroitFameyeTabStripItem tabItem)
        {
            int tabIndex = Items.IndexOf(tabItem);

            if (tabIndex >= 0)
            {
                UnSelectItem(tabItem);
                Items.Remove(tabItem);
            }

            if (Items.Count > 0)
            {
                if (RightToLeft == RightToLeft.No)
                {
                    if (Items[tabIndex - 1] != null)
                    {
                        SelectedItem = Items[tabIndex - 1];
                    }
                    else
                    {
                        SelectedItem = Items.FirstVisible;
                    }
                }
                else
                {
                    if (Items[tabIndex + 1] != null)
                    {
                        SelectedItem = Items[tabIndex + 1];
                    }
                    else
                    {
                        SelectedItem = Items.LastVisible;
                    }
                }
            }
        }

        /// <summary>
        /// Get a <see cref="FATabStripItem" /> at provided point.
        /// If no item was found, returns null value.
        /// </summary>
        /// <param name="pt">The pt.</param>
        /// <returns>ZeroitFameyeTabStripItem.</returns>
        public ZeroitFameyeTabStripItem GetTabItemByPoint(Point pt)
        {
            ZeroitFameyeTabStripItem item = null;
            bool found = false;
            
            for (int i = 0; i < Items.Count; i++)
            {
                ZeroitFameyeTabStripItem current = Items[i];
                
                if (current.StripRect.Contains(pt) && current.Visible && current.IsDrawn)
                {
                    item = current;
                    found = true;
                }
                
                if(found)
                    break;
            }

            return item;
        }

        /// <summary>
        /// Display items menu
        /// </summary>
        public virtual void ShowMenu()
        {
            if (menu.Visible == false && menu.Items.Count > 0)
            {
                if (RightToLeft == RightToLeft.No)
                {
                    menu.Show(this, new Point(menuGlyph.Bounds.Left, menuGlyph.Bounds.Bottom));
                }
                else
                {
                    menu.Show(this, new Point(menuGlyph.Bounds.Right, menuGlyph.Bounds.Bottom));
                }

                menuOpen = true;
            }
        }

        #endregion

        #region Internal

        /// <summary>
        /// Uns the draw all.
        /// </summary>
        internal void UnDrawAll()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].IsDrawn = false;
            }
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="tabItem">The tab item.</param>
        internal void SelectItem(ZeroitFameyeTabStripItem tabItem)
        {
            tabItem.Dock = DockStyle.Fill;
            tabItem.Visible = true;
            tabItem.Selected = true;
        }

        /// <summary>
        /// Uns the select item.
        /// </summary>
        /// <param name="tabItem">The tab item.</param>
        internal void UnSelectItem(ZeroitFameyeTabStripItem tabItem)
        {
            //tabItem.Visible = false;
            tabItem.Selected = false;
        }

        #endregion

        #region Protected

        /// <summary>
        /// Fires <see cref="TabStripItemClosing" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TabStripItemClosingEventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnTabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if (TabStripItemClosing != null)
                TabStripItemClosing(e);
        }

        /// <summary>
        /// Fires <see cref="TabStripItemClosed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnTabStripItemClosed(EventArgs e)
        {
            if (TabStripItemClosed != null)
                TabStripItemClosed(this, e);
        }

        /// <summary>
        /// Fires <see cref="MenuItemsLoading" /> event.
        /// </summary>
        /// <param name="e">The <see cref="HandledEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMenuItemsLoading(HandledEventArgs e)
        {
            if (MenuItemsLoading != null)
                MenuItemsLoading(this, e);
        }
        /// <summary>
        /// Fires <see cref="MenuItemsLoaded" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMenuItemsLoaded(EventArgs e)
        {
            if (MenuItemsLoaded != null)
                MenuItemsLoaded(this, e);
        }

        /// <summary>
        /// Fires <see cref="TabStripItemSelectionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TabStripItemChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTabStripItemChanged(TabStripItemChangedEventArgs e)
        {
            if (TabStripItemSelectionChanged != null)
                TabStripItemSelectionChanged(e);
        }

        /// <summary>
        /// Loads menu items based on <see cref="FATabStripItem" />s currently added
        /// to this control.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMenuItemsLoad(EventArgs e)
        {
            menu.RightToLeft = RightToLeft;
            menu.Items.Clear();

            for (int i = 0; i < Items.Count; i++)
            {
                ZeroitFameyeTabStripItem item = Items[i];
                if (!item.Visible)
                    continue;

                ToolStripMenuItem tItem = new ToolStripMenuItem(item.Title);
                tItem.Tag = item;
                tItem.Image = item.Image;
                menu.Items.Add(tItem);
            }

            OnMenuItemsLoaded(EventArgs.Empty);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Handles the <see cref="E:RightToLeftChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            UpdateLayout();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            SetDefaultSelected();
            Rectangle borderRc = ClientRectangle;
            borderRc.Width--;
            borderRc.Height--;

            if (RightToLeft == RightToLeft.No)
            {
                DEF_START_POS = 10;
            }
            else
            {
                DEF_START_POS = stripButtonRect.Right;
            }

            e.Graphics.DrawRectangle(SystemPens.ControlDark, borderRc);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            #region Draw Pages

            for (int i = 0; i < Items.Count; i++)
            {
                ZeroitFameyeTabStripItem currentItem = Items[i];
                if (!currentItem.Visible && !DesignMode)
                    continue;

                OnCalcTabPage(e.Graphics, currentItem);
                currentItem.IsDrawn = false;

                if (!AllowDraw(currentItem))
                    continue;

                OnDrawTabPage(e.Graphics, currentItem);
            }

            #endregion

            #region Draw UnderPage Line

            if (RightToLeft == RightToLeft.No)
            {
                if (Items.DrawnCount == 0 || Items.VisibleCount == 0)
                {
                    e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, DEF_HEADER_HEIGHT),
                                        new Point(ClientRectangle.Width, DEF_HEADER_HEIGHT));
                }
                else if (SelectedItem != null && SelectedItem.IsDrawn)
                {
                    Point end = new Point((int)SelectedItem.StripRect.Left - 9, DEF_HEADER_HEIGHT);
                    e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, DEF_HEADER_HEIGHT), end);
                    end.X += (int)SelectedItem.StripRect.Width + 10;
                    e.Graphics.DrawLine(SystemPens.ControlDark, end, new Point(ClientRectangle.Width, DEF_HEADER_HEIGHT));
                }
            }
            else
            {
                if (Items.DrawnCount == 0 || Items.VisibleCount == 0)
                {
                    e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, DEF_HEADER_HEIGHT),
                                        new Point(ClientRectangle.Width, DEF_HEADER_HEIGHT));
                }
                else if (SelectedItem != null && SelectedItem.IsDrawn)
                {
                    Point end = new Point((int)SelectedItem.StripRect.Left, DEF_HEADER_HEIGHT);
                    e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, DEF_HEADER_HEIGHT), end);
                    end.X += (int)SelectedItem.StripRect.Width + 20;
                    e.Graphics.DrawLine(SystemPens.ControlDark, end, new Point(ClientRectangle.Width, DEF_HEADER_HEIGHT));
                }
            }

            #endregion

            #region Draw Menu and Close Glyphs

            if (AlwaysShowMenuGlyph || Items.DrawnCount > Items.VisibleCount)
                menuGlyph.DrawGlyph(e.Graphics);

            if (AlwaysShowClose || (SelectedItem != null && SelectedItem.CanClose))
                closeButton.DrawCross(e.Graphics);

            #endregion
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            HitTestResult result = HitTest(e.Location);
            if(result == HitTestResult.MenuGlyph)
            {
                HandledEventArgs args = new HandledEventArgs(false);
                OnMenuItemsLoading(args);
                
                if (!args.Handled)
                    OnMenuItemsLoad(EventArgs.Empty);

                ShowMenu();
            }
            else if (result == HitTestResult.CloseButton)
            {
                if (SelectedItem != null)
                {
                    TabStripItemClosingEventArgs args = new TabStripItemClosingEventArgs(SelectedItem);
                    OnTabStripItemClosing(args);
                    if (!args.Cancel && SelectedItem.CanClose)
                    {
                        RemoveTab(SelectedItem);
                        OnTabStripItemClosed(EventArgs.Empty);
                    }
                }
            }
            else if(result == HitTestResult.TabItem)
            {
                ZeroitFameyeTabStripItem item = GetTabItemByPoint(e.Location);
                if (item != null)
                    SelectedItem = item;
            }

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (menuGlyph.Bounds.Contains(e.Location))
            {
                menuGlyph.IsMouseOver = true;
                Invalidate(menuGlyph.Bounds);
            }
            else
            {
                if (menuGlyph.IsMouseOver && !menuOpen)
                {
                    menuGlyph.IsMouseOver = false;
                    Invalidate(menuGlyph.Bounds);
                }
            }

            if (closeButton.Bounds.Contains(e.Location))
            {
                closeButton.IsMouseOver = true;
                Invalidate(closeButton.Bounds);
            }
            else
            {
                if (closeButton.IsMouseOver)
                {
                    closeButton.IsMouseOver = false;
                    Invalidate(closeButton.Bounds);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            menuGlyph.IsMouseOver = false;
            Invalidate(menuGlyph.Bounds);

            closeButton.IsMouseOver = false;
            Invalidate(closeButton.Bounds);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (isIniting)
                return;

            UpdateLayout();
        }

        #endregion

        #region Private

        /// <summary>
        /// Allows the draw.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool AllowDraw(ZeroitFameyeTabStripItem item)
        {
            bool result = true;

            if (RightToLeft == RightToLeft.No)
            {
                if (item.StripRect.Right >= stripButtonRect.Width)
                    result = false;
            }
            else
            {
                if (item.StripRect.Left <= stripButtonRect.Left)
                    return false;
            }

            return result;
        }

        /// <summary>
        /// Sets the default selected.
        /// </summary>
        private void SetDefaultSelected()
        {
            if (selectedItem == null && Items.Count > 0)
                SelectedItem = Items[0];

            for (int i = 0; i < Items.Count; i++)
            {
                ZeroitFameyeTabStripItem itm = Items[i];
                itm.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MenuItemClicked" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ToolStripItemClickedEventArgs"/> instance containing the event data.</param>
        private void OnMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ZeroitFameyeTabStripItem clickedItem = (ZeroitFameyeTabStripItem) e.ClickedItem.Tag;
            SelectedItem = clickedItem;
        }

        /// <summary>
        /// Handles the <see cref="E:MenuVisibleChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnMenuVisibleChanged(object sender, EventArgs e)
        {
            if (menu.Visible == false)
            {
                menuOpen = false;
            }
        }

        /// <summary>
        /// Called when [calculate tab page].
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="currentItem">The current item.</param>
        private void OnCalcTabPage(Graphics g, ZeroitFameyeTabStripItem currentItem)
        {
            Font currentFont = Font;
            if (currentItem == SelectedItem)
                currentFont = new Font(Font, FontStyle.Bold);

            SizeF textSize = g.MeasureString(currentItem.Title, currentFont, new SizeF(200, 10), sf);
            textSize.Width += 20;

            if (RightToLeft == RightToLeft.No)
            {
                RectangleF buttonRect = new RectangleF(DEF_START_POS, 3, textSize.Width, 17);
                currentItem.StripRect = buttonRect;
                DEF_START_POS += (int) textSize.Width;
            }
            else
            {
                RectangleF buttonRect = new RectangleF(DEF_START_POS - textSize.Width + 1, 3, textSize.Width - 1, 17);
                currentItem.StripRect = buttonRect;
                DEF_START_POS -= (int) textSize.Width;
            }
        }

        /// <summary>
        /// Called when [draw tab page].
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="currentItem">The current item.</param>
        private void OnDrawTabPage(Graphics g, ZeroitFameyeTabStripItem currentItem)
        {
            bool isFirstTab = Items.IndexOf(currentItem) == 0;
            Font currentFont = Font;

            if (currentItem == SelectedItem)
                currentFont = new Font(Font, FontStyle.Bold);

            SizeF textSize = g.MeasureString(currentItem.Title, currentFont, new SizeF(200, 10), sf);
            textSize.Width += 20;
            RectangleF buttonRect = currentItem.StripRect;

            GraphicsPath path = new GraphicsPath();
            LinearGradientBrush brush;
            int mtop = 3;

            #region Draw Not Right-To-Left Tab

            if (RightToLeft == RightToLeft.No)
            {
                if (currentItem == SelectedItem || isFirstTab)
                {
                    path.AddLine(buttonRect.Left - 10, buttonRect.Bottom - 1,
                                 buttonRect.Left + (buttonRect.Height/2) - 4, mtop + 4);
                }
                else
                {
                    path.AddLine(buttonRect.Left, buttonRect.Bottom - 1, buttonRect.Left,
                                 buttonRect.Bottom - (buttonRect.Height/2) - 2);
                    path.AddLine(buttonRect.Left, buttonRect.Bottom - (buttonRect.Height/2) - 3,
                                 buttonRect.Left + (buttonRect.Height/2) - 4, mtop + 3);
                }

                path.AddLine(buttonRect.Left + (buttonRect.Height/2) + 2, mtop, buttonRect.Right - 3, mtop);
                path.AddLine(buttonRect.Right, mtop + 2, buttonRect.Right, buttonRect.Bottom - 1);
                path.AddLine(buttonRect.Right - 4, buttonRect.Bottom - 1, buttonRect.Left, buttonRect.Bottom - 1);
                path.CloseFigure();

                if (currentItem == SelectedItem)
                {
                    brush = new LinearGradientBrush(buttonRect, SystemColors.ControlLightLight, SystemColors.Window, LinearGradientMode.Vertical);
                }
                else
                {
                    brush = new LinearGradientBrush(buttonRect, SystemColors.ControlLightLight, SystemColors.Control, LinearGradientMode.Vertical);
                }

                g.FillPath(brush, path);
                g.DrawPath(SystemPens.ControlDark, path);

                if (currentItem == SelectedItem)
                {
                    g.DrawLine(new Pen(brush), buttonRect.Left - 9, buttonRect.Height + 2,
                               buttonRect.Left + buttonRect.Width - 1, buttonRect.Height + 2);
                }

                PointF textLoc = new PointF(buttonRect.Left + buttonRect.Height - 4, buttonRect.Top + (buttonRect.Height/2) - (textSize.Height/2) - 3);
                RectangleF textRect = buttonRect;
                textRect.Location = textLoc;
                textRect.Width = buttonRect.Width - (textRect.Left - buttonRect.Left) - 4;
                textRect.Height = textSize.Height + currentFont.Size/2;

                if (currentItem == SelectedItem)
                {
                    //textRect.Y -= 2;
                    g.DrawString(currentItem.Title, currentFont, new SolidBrush(ForeColor), textRect, sf);
                }
                else
                {
                    g.DrawString(currentItem.Title, currentFont, new SolidBrush(ForeColor), textRect, sf);
                }
            }

            #endregion

            #region Draw Right-To-Left Tab

            if (RightToLeft == RightToLeft.Yes)
            {
                if (currentItem == SelectedItem || isFirstTab)
                {
                    path.AddLine(buttonRect.Right + 10, buttonRect.Bottom - 1,
                                 buttonRect.Right - (buttonRect.Height/2) + 4, mtop + 4);
                }
                else
                {
                    path.AddLine(buttonRect.Right, buttonRect.Bottom - 1, buttonRect.Right,
                                 buttonRect.Bottom - (buttonRect.Height/2) - 2);
                    path.AddLine(buttonRect.Right, buttonRect.Bottom - (buttonRect.Height/2) - 3,
                                 buttonRect.Right - (buttonRect.Height/2) + 4, mtop + 3);
                }

                path.AddLine(buttonRect.Right - (buttonRect.Height/2) - 2, mtop, buttonRect.Left + 3, mtop);
                path.AddLine(buttonRect.Left, mtop + 2, buttonRect.Left, buttonRect.Bottom - 1);
                path.AddLine(buttonRect.Left + 4, buttonRect.Bottom - 1, buttonRect.Right, buttonRect.Bottom - 1);
                path.CloseFigure();

                if (currentItem == SelectedItem)
                {
                    brush =
                        new LinearGradientBrush(buttonRect, SystemColors.ControlLightLight, SystemColors.Window,
                                                LinearGradientMode.Vertical);
                }
                else
                {
                    brush =
                        new LinearGradientBrush(buttonRect, SystemColors.ControlLightLight, SystemColors.Control,
                                                LinearGradientMode.Vertical);
                }

                g.FillPath(brush, path);
                g.DrawPath(SystemPens.ControlDark, path);

                if (currentItem == SelectedItem)
                {
                    g.DrawLine(new Pen(brush), buttonRect.Right + 9, buttonRect.Height + 2,
                               buttonRect.Right - buttonRect.Width + 1, buttonRect.Height + 2);
                }

                PointF textLoc = new PointF(buttonRect.Left + 2, buttonRect.Top + (buttonRect.Height/2) - (textSize.Height/2) - 2);
                RectangleF textRect = buttonRect;
                textRect.Location = textLoc;
                textRect.Width = buttonRect.Width - (textRect.Left - buttonRect.Left) - 10;
                textRect.Height = textSize.Height + currentFont.Size/2;

                if (currentItem == SelectedItem)
                {
                    textRect.Y -= 1;
                    g.DrawString(currentItem.Title, currentFont, new SolidBrush(ForeColor), textRect, sf);
                }
                else
                {
                    g.DrawString(currentItem.Title, currentFont, new SolidBrush(ForeColor), textRect, sf);
                }

                //g.FillRectangle(Brushes.Red, textRect);
            }

            #endregion

            currentItem.IsDrawn = true;
        }

        /// <summary>
        /// Updates the layout.
        /// </summary>
        private void UpdateLayout()
        {
            if (RightToLeft == RightToLeft.No)
            {
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags |= StringFormatFlags.NoWrap;
                sf.FormatFlags &= StringFormatFlags.DirectionRightToLeft;

                stripButtonRect = new Rectangle(0, 0, ClientSize.Width - DEF_GLYPH_WIDTH - 2, 10);
                menuGlyph.Bounds = new Rectangle(ClientSize.Width - DEF_GLYPH_WIDTH, 2, 16, 16);
                closeButton.Bounds = new Rectangle(ClientSize.Width - 20, 2, 16, 16);
            }
            else
            {
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags |= StringFormatFlags.NoWrap;
                sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

                stripButtonRect = new Rectangle(DEF_GLYPH_WIDTH + 2, 0, ClientSize.Width - DEF_GLYPH_WIDTH - 15, 10);
                closeButton.Bounds = new Rectangle(4, 2, 16, 16); //ClientSize.Width - DEF_GLYPH_WIDTH, 2, 16, 16);
                menuGlyph.Bounds = new Rectangle(20 + 4, 2, 16, 16); //this.ClientSize.Width - 20, 2, 16, 16);
            }

            DockPadding.Top = DEF_HEADER_HEIGHT + 1;
            DockPadding.Bottom = 1;
            DockPadding.Right = 1;
            DockPadding.Left = 1;
        }

        /// <summary>
        /// Handles the <see cref="E:CollectionChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs"/> instance containing the event data.</param>
        private void OnCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            ZeroitFameyeTabStripItem itm = (ZeroitFameyeTabStripItem) e.Element;

            if (e.Action == CollectionChangeAction.Add)
            {
                Controls.Add(itm);
                OnTabStripItemChanged(new TabStripItemChangedEventArgs(itm, FATabStripItemChangeTypes.Added));
            }
            else if (e.Action == CollectionChangeAction.Remove)
            {
                Controls.Remove(itm);
                OnTabStripItemChanged(new TabStripItemChangedEventArgs(itm, FATabStripItemChangeTypes.Removed));
            }
            else
            {
                OnTabStripItemChanged(new TabStripItemChangedEventArgs(itm, FATabStripItemChangeTypes.Changed));
            }

            UpdateLayout();
            Invalidate();
        }

        #endregion

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStrip" /> class.
        /// </summary>
        public ZeroitFameyeTabStrip()
        {
            BeginInit();

            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, true);

            items = new FATabStripItemCollection();
            items.CollectionChanged += new CollectionChangeEventHandler(OnCollectionChanged);
            base.Size = new Size(350, 200);

            menu = new ContextMenuStrip();
            menu.Renderer = ToolStripRenderer;
            menu.ItemClicked += new ToolStripItemClickedEventHandler(OnMenuItemClicked);
            menu.VisibleChanged += new EventHandler(OnMenuVisibleChanged);

            menuGlyph = new ZeroitFameyeTabStripMenuGlyph(ToolStripRenderer);
            closeButton = new ZeroitFameyeTabStripCloseButton(ToolStripRenderer);
            Font = defaultFont;
            sf = new StringFormat();

            EndInit();

            UpdateLayout();
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.All)]
        public ZeroitFameyeTabStripItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;

                if (value == null && Items.Count > 0)
                {
                    ZeroitFameyeTabStripItem itm = Items[0];
                    if (itm.Visible)
                    {
                        selectedItem = itm;
                        selectedItem.Selected = true;
                        selectedItem.Dock = DockStyle.Fill;
                    }
                }
                else
                {
                    selectedItem = value;
                }

                foreach (ZeroitFameyeTabStripItem itm in Items)
                {
                    if (itm == selectedItem)
                    {
                        SelectItem(itm);
                        itm.Dock = DockStyle.Fill;
                        itm.Show();
                    }
                    else
                    {
                        UnSelectItem(itm);
                        itm.Hide();
                    }
                }

                SelectItem(selectedItem);
                Invalidate();

                if (!selectedItem.IsDrawn)
                {
                    Items.MoveTo(0, selectedItem);
                    Invalidate();
                }

                OnTabStripItemChanged(
                    new TabStripItemChangedEventArgs(selectedItem, FATabStripItemChangeTypes.SelectionChanged));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to always show menu glyph.
        /// </summary>
        /// <value><c>true</c> if always show menu glyph; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool AlwaysShowMenuGlyph
        {
            get { return alwaysShowMenuGlyph; }
            set
            {
                if (alwaysShowMenuGlyph == value)
                    return;

                alwaysShowMenuGlyph = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to always show close.
        /// </summary>
        /// <value><c>true</c> if always show close; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool AlwaysShowClose
        {
            get { return alwaysShowClose; }
            set
            {
                if (alwaysShowClose == value)
                    return;

                alwaysShowClose = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FATabStripItemCollection Items
        {
            get { return items; }
        }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        [DefaultValue(typeof (Size), "350,200")]
        public new Size Size
        {
            get { return base.Size; }
            set
            {
                if (base.Size == value)
                    return;

                base.Size = value;
                UpdateLayout();
            }
        }

        /// <summary>
        /// DesignerSerializationVisibility
        /// </summary>
        /// <value>The controls.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ControlCollection Controls
        {
            get { return base.Controls; }
        }

        #endregion

        #region ShouldSerialize

        /// <summary>
        /// Shoulds the serialize font.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeFont()
        {
            return Font != null && !Font.Equals(defaultFont);
        }

        /// <summary>
        /// Shoulds the serialize selected item.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeSelectedItem()
        {
            return true;
        }

        /// <summary>
        /// Shoulds the serialize items.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeItems()
        {
            return items.Count > 0;
        }

        /// <summary>
        /// Resets the <see cref="P:System.Windows.Forms.Control.Font" /> property to its default value.
        /// </summary>
        public new void ResetFont()
        {
            Font = defaultFont;
        }

        #endregion

        #region ISupportInitialize Members

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            isIniting = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            isIniting = false;
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                items.CollectionChanged -= new CollectionChangeEventHandler(OnCollectionChanged);
                menu.ItemClicked        -= new ToolStripItemClickedEventHandler(OnMenuItemClicked);
                menu.VisibleChanged     -= new EventHandler(OnMenuVisibleChanged);

                foreach (ZeroitFameyeTabStripItem item in items)
                {
                    if (item != null && !item.IsDisposed)
                        item.Dispose();
                }

                if (menu != null && !menu.IsDisposed)
                    menu.Dispose();

                if (sf != null)
                    sf.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}