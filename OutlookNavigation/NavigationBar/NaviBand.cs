// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBand.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class represents a Band which is a part of the Navigation bar
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviControl" />
    /// <remarks>The band is the actual control container which will be displayed when the user clicks
    /// on the button which has been assigned to this band.
    /// The size of this control is controlled by the layout engine.</remarks>
    [
    Designer(typeof(NaviBandDesigner)),
   ToolboxItem(false)
   ]
   public partial class NaviBand : NaviControl
   {
        #region Fields

        /// <summary>
        /// The renderer
        /// </summary>
        NaviBandRenderer renderer;
        /// <summary>
        /// The button
        /// </summary>
        NaviButton button;
        /// <summary>
        /// The large image
        /// </summary>
        Image largeImage;
        /// <summary>
        /// The small image
        /// </summary>
        Image smallImage;
        /// <summary>
        /// The client area
        /// </summary>
        NaviBandClientArea clientArea;
        /// <summary>
        /// The order
        /// </summary>
        int order;
        /// <summary>
        /// The original order
        /// </summary>
        int originalOrder;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviBand" /> class.
        /// </summary>
        public NaviBand()
      {
         InitializeComponent();
         Initialize();
      }

        /// <summary>
        /// Initializes a new instance of the NaviControl
        /// </summary>
        /// <param name="container">The parent container</param>
        public NaviBand(IContainer container)
      {
         container.Add(this);
         InitializeComponent();
         Initialize();
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the position in a list of this band
        /// </summary>
        /// <value>The order.</value>
        internal int Order
      {
         get { return order; }
         set { order = value; }
      }

        /// <summary>
        /// Gets or sets the original position in a list of this band
        /// </summary>
        /// <value>The original order.</value>
        internal int OriginalOrder
      {
         get { return originalOrder; }
         set { originalOrder = value; }
      }

        /// <summary>
        /// Gets or sets the large image displayed when the button is not in minimized mode
        /// </summary>
        /// <value>The large image.</value>
        [
        DefaultValue(null),
      Localizable(true),
      Category("Appearance"),
      Description("The image displayed when the button is not displayed as a small button"),
      ]
      public Image LargeImage
      {
         get { return largeImage; }
         set
         {
            largeImage = value;
            if (button != null)
               button.LargeImage = value;
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or set the image displayed when the button is in minimized mode
        /// </summary>
        /// <value>The small image.</value>
        [
        DefaultValue(null),
      Localizable(true),
      Category("The image displayed when the button is displayed as a small button"),
      ]
      public Image SmallImage
      {
         get { return smallImage; }
         set
         {
            smallImage = value;
            if (button != null)
               button.SmallImage = value;
            Invalidate();
         }
      }

        /// <summary>
        /// Gets the button which is associated with this band
        /// </summary>
        /// <value>The button.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviButton Button
      {
         get { return button; }
         internal set { button = value; }
      }

        /// <summary>
        /// Gets or sets the client area.
        /// </summary>
        /// <value>The client area.</value>
        [
        Browsable(false), 
      DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
      ]
      public NaviBandClientArea ClientArea
      {
         get { return clientArea; }
         set { clientArea = value; }
      }

        /// <summary>
        /// Gets or sets the renderer for this control
        /// </summary>
        /// <value>The renderer.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBandRenderer Renderer
      {
         get { return renderer; }
         set { renderer = value; }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time.
        /// </summary>
        internal void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         renderer = new NaviBandRendererOff7();

         clientArea = new NaviBandClientArea();
         clientArea.Name = "ClientArea";
         clientArea.Location = new Point(0, 0);
         clientArea.Size = Size;
         Controls.Add(clientArea);

         ResizeRedraw = true;
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
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

        /// <summary>
        /// Overriden. Raises the PaintBackground and draws the background of the Navigation band
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
      {
         base.OnPaintBackground(e);         
      }

        /// <summary>
        /// Overriden. Raises the Resize event and Invalidates the control
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         clientArea.Size = Size;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the TetChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnTextChanged(EventArgs e)
      {
         base.OnTextChanged(e);
         if (button != null)
            button.Text = Text;
      }

        /// <summary>
        /// Overriden. Raises the LayoutStyleChanged event and changes the colorstyle on
        /// childcontrols
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         foreach (Control childControl in clientArea.Controls)
         {
            if (childControl is NaviControl)
            {
               ((NaviControl)childControl).LayoutStyle = LayoutStyle;
            }
         }

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

      #region Event Handling
      #endregion
   }
}
