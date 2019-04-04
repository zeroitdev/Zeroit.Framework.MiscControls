// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButton.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a button.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviControl" />
    [
    //Designer(typeof(Zeroit.Framework.MiscControls.Design.NavigationBarButtonDesigner))
    DefaultEvent("Activated"),
   ]
   public partial class NaviButton : NaviControl
   {
        #region Fields

        /// <summary>
        /// The activated
        /// </summary>
        EventHandler activated;

        /// <summary>
        /// The large image
        /// </summary>
        Image largeImage;
        /// <summary>
        /// The small image
        /// </summary>
        Image smallImage;

        /// <summary>
        /// The small
        /// </summary>
        bool small;
        /// <summary>
        /// The collapsed
        /// </summary>
        bool collapsed;
        /// <summary>
        /// The active
        /// </summary>
        bool active;
        /// <summary>
        /// The show image
        /// </summary>
        bool showImage;

        /// <summary>
        /// The renderer
        /// </summary>
        protected NaviButtonRenderer renderer;
        /// <summary>
        /// The state
        /// </summary>
        protected ControlState state;
        /// <summary>
        /// The input state
        /// </summary>
        protected InputState inputState;
        /// <summary>
        /// The band
        /// </summary>
        protected NaviBand band;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButton
        /// </summary>
        public NaviButton()
      {
         InitializeComponent();
         Initialize();
      }

        /// <summary>
        /// Initializes a new instance of the NaviButton
        /// </summary>
        /// <param name="container">The parent container</param>
        public NaviButton(IContainer container)
         : this()
      {
         container.Add(this);
         InitializeComponent();
      }

        #endregion

        #region Properties

        // Design time 

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
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets whether the image is visible or not
        /// </summary>
        /// <value><c>true</c> if [show image]; otherwise, <c>false</c>.</value>
        [
        DefaultValue(true),
      Category("Indicates if the image is visible or not"),
      ]
      public bool ShowImage
      {
         get { return showImage; }
         set { showImage = value; Invalidate(); }
      }

        /// <summary>
        /// Gets or sets the band that is associated with this button
        /// </summary>
        /// <value>The band.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBand Band
      {
         get { return band; }
         internal set { band = value; }
      }

        // Non design time

        /// <summary>
        /// Gets or sets whether the button is currently the active button
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public bool Active
      {
         get { return active; }
         set
         {
            active = value;
            if (active)
            {
               state = ControlState.Active;
               OnActivated(new EventArgs());
            }
            else
            {
               state = ControlState.Normal;
               inputState = InputState.Normal;
            }
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets whether the button should be drawn in the compact mode or the full mode
        /// </summary>
        /// <value><c>true</c> if small; otherwise, <c>false</c>.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public bool Small
      {
         get { return small; }
         set
         {
            small = value;
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets whether the buttons should be drawn in minimized mode or not
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public virtual bool Collapsed
      {
         get { return collapsed; }
         set
         {
            collapsed = value;
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets the renderer
        /// </summary>
        /// <value>The renderer.</value>
        /// <exception cref="System.ArgumentNullException">Renderer</exception>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public NaviButtonRenderer Renderer
      {
         get { return renderer; }
         set
         {
            if (value == null)
               throw new ArgumentNullException("Renderer");
            renderer = value;
            Invalidate();
         }
      }

        #endregion

        #region Events

        /// <summary>
        /// Occurs the button is activated
        /// </summary>
        public event EventHandler Activated
      {
         add { lock (threadLock) { activated += value; } }
         remove { lock (threadLock) { activated -= value; } }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the button for the first time
        /// </summary>
        private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         Visible = true;
         small = false;
         collapsed = false;
         showImage = true;
         renderer = new NaviButtonRendererOff7();
      }

        /// <summary>
        /// Raises the Activated event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected virtual void OnActivated(EventArgs e)
      {
         EventHandler handler = activated;
         if (handler != null)
            handler(this, e);
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
         renderer.DrawBackground(e.Graphics, ClientRectangle, state, inputState);

         if (small)
         {
            if ((smallImage != null) && (showImage))
            {
               Point location = new Point((int)((Width / 2) - (smallImage.Width / 2)),
                  (int)((Height / 2) - (smallImage.Height / 2)));
               renderer.DrawImage(e.Graphics, location, smallImage);
            }
         }
         else
         {
            Rectangle bounds = ClientRectangle;
            if ((largeImage != null) && showImage)
            {
               Point location;

               int margin = 10;
               if (collapsed)
                  margin = 4;

               if (RightToLeft == RightToLeft.Yes)
                  location = new Point(Width - margin - largeImage.Width, (int)((Height / 2) - (largeImage.Height / 2)));
               else
                  location = new Point(margin, (int)((Height / 2) - (largeImage.Height / 2)));

               renderer.DrawImage(e.Graphics, location, largeImage);

               // Calculate bounds for text
               if (RightToLeft == RightToLeft.No)
               {
                  bounds.X += 32;
               }
               bounds.Width -= 32;
            }
            bounds.X += 10;
            bounds.Width -= 10;
            if (!collapsed)
               renderer.DrawText(e.Graphics, bounds, Font, Text, RightToLeft == RightToLeft.Yes);
         }
      }

        /// <summary>
        /// Overloaded. Raises the OnLayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               renderer = new NaviButtonRendererOff3();
               ((NaviButtonRendererOff3)renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7Black();
               break;
            case NaviLayoutStyle.Office2007Silver:
               renderer = new NaviButtonRendererOff7();
               ((NaviButtonRendererOff7)renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
            //case NaviLayoutStyle.Office2010:
            //   renderer = new NaviButtonRendererOff10();
            //   break;
         }
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the MouseEnter event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseEnter(EventArgs e)
      {
         base.OnMouseEnter(e);
         inputState = InputState.Hovered;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         inputState = InputState.Clicked;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the MouseUp event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         inputState = InputState.Normal;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the MouseLeave event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         inputState = InputState.Normal;
         Invalidate();
      }

        /// <summary>
        /// Overriden. Raises the TextChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnTextChanged(EventArgs e)
      {
         base.OnTextChanged(e);
         Invalidate();
      }

      #endregion
   }
}
