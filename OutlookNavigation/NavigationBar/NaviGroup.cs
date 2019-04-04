// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviGroup.cs" company="Zeroit Dev Technologies">
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
#region License and Copyright

/*
 
Author:  Jacob Mesu
 
Attribution-Noncommercial-Share Alike 3.0 Unported
You are free:

    * to Share — to copy, distribute and transmit the work
    * to Remix — to adapt the work

Under the following conditions:

    * Attribution — You must attribute the work and give credits to the author or Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net
    * Noncommercial — You may not use this work for commercial purposes. If you want to adapt
      this work for a commercial purpose, visit Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net and request the Attribution-Share 
      Alike 3.0 Unported license for free. 

http://creativecommons.org/licenses/by-nc-sa/3.0/

*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a container control which can be expanded or collapsed to a header bar only.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviControl" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    [
    Designer(typeof(NaviGroupDesigner)),
   ToolboxItem(true),
   ToolboxBitmap(typeof(ZeroitNaviGroup))
   ]
   public partial class ZeroitNaviGroup : NaviControl, ISupportInitialize
   {
        #region Fields

        /// <summary>
        /// The m header region
        /// </summary>
        Region m_headerRegion;
        /// <summary>
        /// The m header rectangle
        /// </summary>
        Rectangle m_headerRectangle;
        /// <summary>
        /// The m header text bounds
        /// </summary>
        Rectangle m_headerTextBounds;
        /// <summary>
        /// The m header mouse click
        /// </summary>
        MouseEventHandler m_headerMouseClick;
        /// <summary>
        /// The renderer
        /// </summary>
        NaviGroupRenderer renderer;
        /// <summary>
        /// The view state
        /// </summary>
        InputState viewState;
        /// <summary>
        /// The m context menu strip
        /// </summary>
        ContextMenuStrip m_contextMenuStrip;
        /// <summary>
        /// The m header context menu strip
        /// </summary>
        ContextMenuStrip m_headerContextMenuStrip;

        /// <summary>
        /// The m caption
        /// </summary>
        string m_caption;
        /// <summary>
        /// The m expanded
        /// </summary>
        bool m_expanded;
        /// <summary>
        /// The m header height
        /// </summary>
        int m_headerHeight;
        /// <summary>
        /// The m expanded height
        /// </summary>
        int m_expandedHeight;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNaviGroup" /> class.
        /// </summary>
        public ZeroitNaviGroup()
      {
         InitializeComponent();
         Initialize();
      }

        /// <summary>
        /// Initializes a new instance of the GroupView class
        /// </summary>
        /// <param name="container">The container to which this control belongs</param>
        public ZeroitNaviGroup(IContainer container)
         : this()
      {
         container.Add(this);
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the text displayed in the header region
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
      {
         get { return m_caption; }
         set { m_caption = value; }
      }

        /// <summary>
        /// Gets or sets the height of the header
        /// </summary>
        /// <value>The height of the header.</value>
        [
        DefaultValue(20)
      ]
      public int HeaderHeight
      {
         get { return m_headerHeight; }
         set
         {
            if (m_headerHeight != value)
            {
               CreateBounds(value);
            }
            m_headerHeight = value;
         }
      }

        /// <summary>
        /// Gets or sets whether the control is expanded or collapsed to the header only
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        [
        DefaultValue(true)
      ]
      public bool Expanded
      {
         get { return m_expanded; }
         set
         {
            if (m_expanded != value)
            {
               if (value)
               {
                  Expand();
               }
               else
               {
                  Collapse();
               }
            }
            m_expanded = value;
         }
      }

        /// <summary>
        /// Gets or sets the height of the GroupView when it's expanded
        /// </summary>
        /// <value>The height of the expanded.</value>
        [
        DefaultValue(150),
      ]
      public int ExpandedHeight
      {
         get { return m_expandedHeight; }
         set { m_expandedHeight = value; }
      }

        /// <summary>
        /// Overriden. Gets or sets the current height of the GroupView
        /// </summary>
        /// <value>The height.</value>
        public new int Height
      {
         get { return base.Height; }
         set
         {
            base.Height = value;
            // Make sure expanded hight is always as much as the height when a control 
            // is expanded. 
            if (m_expanded)
               m_expandedHeight = value;
         }
      }

        /// <summary>
        /// Overriden. Gets or sets the ContextMenuStrip associated with this control
        /// </summary>
        /// <value>The context menu strip.</value>
        public new ContextMenuStrip ContextMenuStrip
      {
         get { return m_contextMenuStrip; }
         set { m_contextMenuStrip = value; }
      }

        /// <summary>
        /// Gets or sets the shortcut menu to display when the user right-clicks the header.
        /// </summary>
        /// <value>The header context menu strip.</value>
        public ContextMenuStrip HeaderContextMenuStrip
      {
         get { return m_headerContextMenuStrip; }
         set { m_headerContextMenuStrip = value; }
      }

        /// <summary>
        /// Gets the region used for the header
        /// </summary>
        /// <value>The header region.</value>
        [Browsable(false)]
      public Region HeaderRegion
      {
         get { return m_headerRegion; }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time
        /// </summary>
        private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         m_expanded = true;
         m_headerHeight = 20;
         m_expandedHeight = 150;
         renderer = new NaviGroupRendererOff7();
         viewState = InputState.Normal;
         Padding = new Padding(1, 1, 1, 1);
      }

        /// <summary>
        /// Creates a new Region for the header using a specified Height.
        /// </summary>
        /// <param name="height">The height of the header</param>
        private void CreateBounds(int height)
      {
         m_headerRectangle = new Rectangle(0, 0, Width, height);
         m_headerRegion = new Region(m_headerRectangle);
         m_headerTextBounds = m_headerRectangle;
         if (RightToLeft == RightToLeft.Yes)
         {
            m_headerTextBounds.Width -= 19;
            m_headerTextBounds.X += 16;
         }
         else
         {
            m_headerTextBounds.Width -= 16;
            m_headerTextBounds.X += 3;
         }
         Padding = new Padding(Padding.Left, m_headerHeight + 2, Padding.Right, Padding.Bottom);
      }

        /// <summary>
        /// Expands the view to full height
        /// </summary>
        public void Expand()
      {
         m_expanded = true;
         Height = m_expandedHeight;
      }

        /// <summary>
        /// Collapses the view to the header only
        /// </summary>
        public void Collapse()
      {
         m_expanded = false;
         Height = m_headerHeight;
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         renderer.DrawHeader(e.Graphics, m_headerRectangle, viewState, m_expanded,
            RightToLeft == RightToLeft.Yes);
         renderer.DrawText(e.Graphics, m_headerTextBounds, this.Font, m_caption,
            RightToLeft == RightToLeft.Yes);

         if (DesignMode)
         {
            Rectangle containerRect = ClientRectangle;
            containerRect.X++;
            containerRect.Y += m_headerHeight + 1;
            containerRect.Width -= 3;
            containerRect.Height -= (m_headerHeight + 3);

            renderer.DrawHatchedPanel(e.Graphics, containerRect);
         }
      }

        /// <summary>
        /// Overriden. Raises the PaintBackground event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

        /// <summary>
        /// Overriden. Raises the MouseClick event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseClick(MouseEventArgs e)
      {
         bool headerClicked = m_headerRegion.IsVisible(new Point(e.X, e.Y));
         if (headerClicked)
         {
            base.OnMouseClick(e);
            OnHeaderMouseClick(e);
         }
         else
         {
            base.OnMouseClick(e);
            if ((m_contextMenuStrip != null) && (e.Button == MouseButtons.Right))
            {
               m_contextMenuStrip.Show(this, e.Location);
            }
         }
      }

        /// <summary>
        /// Overriden. Raises the MouseMove event and shows a hand when the mouse is moved over the header
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         if (m_headerRegion.IsVisible(new Point(e.X, e.Y)))
         {
            Cursor = Cursors.Hand;
            viewState = InputState.Hovered;
            Invalidate();
         }
         else
         {
            Cursor = Cursors.Default;
            viewState = InputState.Normal;
            Invalidate();
         }
      }

        /// <summary>
        /// Overriden. Raises the MouseLeave event and changes the current cursor to the default.
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         Cursor = Cursors.Default;
         viewState = InputState.Normal;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the Resize event and reinitializes the bounds of the header
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         CreateBounds(m_headerHeight);
         Invalidate();
      }

        /// <summary>
        /// Raises the LayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               renderer = new NaviGroupRendererOff3();
               ((NaviGroupRendererOff3)renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviGroupRendererOff7();
               ((NaviGroupRendererOff7)renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   // TODO renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

        #endregion

        #region Event Handling

        /// <summary>
        /// Occurs when the user clicks with the mouse inside the header region
        /// </summary>
        public event MouseEventHandler HeaderMouseClick
      {
         add { lock (threadLock) { m_headerMouseClick += value; } }
         remove { lock (threadLock) { m_headerMouseClick -= value; } }
      }

        /// <summary>
        /// Occurs when the user clicks with the mouse inside the header region
        /// </summary>
        /// <param name="e">Additional mouse event info</param>
        protected virtual void OnHeaderMouseClick(MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            if (m_expanded)
            {
               Collapse();
            }
            else
            {
               Expand();
            }
         }
         else if (e.Button == MouseButtons.Right)
         {
            if (m_headerContextMenuStrip != null)
            {
               m_headerContextMenuStrip.Show(this, e.Location);
            }
         }
         MouseEventHandler handler = m_headerMouseClick;
         if (handler != null)
         {
            handler(this, e);
         }
      }

        #endregion

        #region ISupportInitialize Members

        /// <summary>
        /// Starts the initialization for the control
        /// </summary>
        public void BeginInit()
      {
      }

        /// <summary>
        /// Automatically creates the bounds for the control based on the current header height.
        /// </summary>
        public void EndInit()
      {
         CreateBounds(m_headerHeight);
      }

      #endregion
   }
}