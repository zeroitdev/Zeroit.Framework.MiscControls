// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-12-2018
// ***********************************************************************
// <copyright file="NaviBandPopup.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for creating a popup control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviForm" />
    public partial class NaviBandPopup : NaviForm
   {
        /// <summary>
        /// The renderer
        /// </summary>
        NaviBandRenderer renderer = new NaviBandRendererOff7();

        /// <summary>
        /// The resizable
        /// </summary>
        bool resizable;
        /// <summary>
        /// The start drag
        /// </summary>
        Point startDrag;
        /// <summary>
        /// The dragging
        /// </summary>
        bool dragging;
        /// <summary>
        /// The content
        /// </summary>
        Control content;
        /// <summary>
        /// The resize bounds
        /// </summary>
        Rectangle resizeBounds;

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public Control Content
      {
         get { return content; }
         set
         {
            content = value;
            if (content != null)
            {
               Controls.Clear();
               content.Dock = DockStyle.Fill;
               Controls.Add(content);
            }
         }
      }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NaviBandPopup" /> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable
      {
         get { return resizable; }
         set { resizable = value; }
      }

        /// <summary>
        /// Gets or sets the renderer.
        /// </summary>
        /// <value>The renderer.</value>
        public NaviBandRenderer Renderer
      {
         get { return renderer; }
         set { renderer = value; }
      }

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
      {
         get
         {
            CreateParams param = base.CreateParams;
            //param.ClassStyle += NativeMethods.CS_DROPSHADOW;
            return param;
         }
      }

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviBandPopup" /> class.
        /// </summary>
        public NaviBandPopup()
      {
         InitializeComponent();
         ResizeRedraw = true;

         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         Padding = new Padding(3);
      }

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
      }

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
      {
         get { return true; }
      }

        /// <summary>
        /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);
         renderer.DrawPopupBand(e.Graphics, ClientRectangle);
      }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         if ((e.Button == MouseButtons.Left)
         && (e.Clicks == 1))
         {
            if (resizeBounds.Contains(e.Location))
            {
               startDrag = e.Location;
               dragging = true;
            }
         }
         else
            dragging = false;
      }

        /// <summary>
        /// Overriden. Raises the MouseDown event.
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         if (dragging)
         {
            Size = new Size(e.Location.X + 3, Size.Height);
            Cursor = Cursors.SizeWE;
         }
         else if (resizeBounds.Contains(e.Location))
         {
            Cursor = Cursors.SizeWE;
         }
         else
         {
            Cursor = Cursors.Default;
         }
      }

        /// <summary>
        /// Overriden. Raises the MouseLeave event and changes the cursor back to default
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         dragging = false;
      }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         resizeBounds = new Rectangle(Width - 3, 0, 3, Height);
      }

        /// <summary>
        /// Overriden. Raises the MouseUp event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         dragging = false;
      }

        /// <summary>
        /// Overloaded. Raises the LayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               // TODO 
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviBandRendererOff7();
               renderer.ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   // TODO renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

      #endregion
   }
}
