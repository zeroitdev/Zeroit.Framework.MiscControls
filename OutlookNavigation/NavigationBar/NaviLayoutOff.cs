// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviLayoutOff.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviLayoutOff.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviLayout" />
    [
    TypeConverter(typeof(ExpandableObjectConverter)),
   ToolboxItem(false), DesignTimeVisible(false)
   ]
   public class NaviLayoutOff : NaviLayout
   {
        // Fields
        /// <summary>
        /// The splitter rectangle
        /// </summary>
        Rectangle splitterRectangle;
        /// <summary>
        /// The small button rectangle
        /// </summary>
        Rectangle smallButtonRectangle;
        /// <summary>
        /// The header rectangle
        /// </summary>
        Rectangle headerRectangle;
        /// <summary>
        /// The header text rectangle
        /// </summary>
        Rectangle headerTextRectangle;
        /// <summary>
        /// The options button
        /// </summary>
        NaviButtonOptions optionsButton;
        /// <summary>
        /// The collapse button
        /// </summary>
        NaviButtonCollapse collapseButton;
        /// <summary>
        /// The options menu
        /// </summary>
        NaviContextMenu optionsMenu;
        /// <summary>
        /// The mi show more buttons
        /// </summary>
        ToolStripMenuItem miShowMoreButtons;
        /// <summary>
        /// The mi show less buttons
        /// </summary>
        ToolStripMenuItem miShowLessButtons;
        /// <summary>
        /// The mi show more options
        /// </summary>
        ToolStripMenuItem miShowMoreOptions;
        /// <summary>
        /// The mi add or remove buttons
        /// </summary>
        ToolStripMenuItem miAddOrRemoveButtons;
        /// <summary>
        /// The renderer
        /// </summary>
        NaviBarRenderer renderer;
        /// <summary>
        /// The splitter renderer
        /// </summary>
        NaviSplitterRenderer splitterRenderer;
        /// <summary>
        /// The collapsed band
        /// </summary>
        NaviBandCollapsed collapsedBand;
        /// <summary>
        /// The header font
        /// </summary>
        Font headerFont = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        /// <summary>
        /// The popup
        /// </summary>
        NaviBandPopup popup;
        /// <summary>
        /// The popup helper
        /// </summary>
        PopupWindowHelper popupHelper = null;

        /// <summary>
        /// The splitter height
        /// </summary>
        int splitterHeight = 8;
        /// <summary>
        /// The visible buttons
        /// </summary>
        int visibleButtons; // All visible buttons including large ones
                          /// <summary>
                          /// The option button width
                          /// </summary>
        int optionButtonWidth = 18;
        /// <summary>
        /// The splitter position
        /// </summary>
        int splitterPosition;
        /// <summary>
        /// The org width
        /// </summary>
        int orgWidth;
        /// <summary>
        /// The splitter dragging
        /// </summary>
        bool splitterDragging;
        /// <summary>
        /// The show never collapse
        /// </summary>
        bool showNeverCollapse = false;

        #region Properties

        /// <summary>
        /// Gets or sets the renderer responsible for drawing the NaviBar
        /// </summary>
        /// <value>The renderer.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public NaviBarRenderer Renderer
      {
         get { return renderer; }
         set { renderer = value; }
      }

        /// <summary>
        /// Gets or sets whether the collapse button should be visible or not.
        /// </summary>
        /// <value><c>true</c> if [show never collapse]; otherwise, <c>false</c>.</value>
        /// <remarks>This options overrides the showcollapsebutton property</remarks>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public bool ShowNeverCollapse
      {
         get { return showNeverCollapse; }
         internal set { showNeverCollapse = value; }
      }

        /// <summary>
        /// Gets or sets the renderer responsible for drawing the splitter
        /// </summary>
        /// <value>The splitter renderer.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public NaviSplitterRenderer SplitterRenderer
      {
         get { return splitterRenderer; }
         set { splitterRenderer = value; }
      }

        /// <summary>
        /// Gets the amount of visible buttons including the Large buttons
        /// </summary>
        /// <value>The visible buttons.</value>
        public override int VisibleButtons
      {
         get { return visibleButtons; }
      }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NaviOfficeLayout class
        /// </summary>
        public NaviLayoutOff()
      {
      }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the position of the splitter
        /// </summary>
        private void LayoutSplitter()
      {
         // splitterposition is calculated from the bottom of the control to the top. 
         // Thats not the same as the regular coordinate system. 
         splitterPosition = (Bar.ButtonHeight * Bar.VisibleLargeButtons) + splitterHeight;

         // inverse calculation 
         // Width - 2 extra space reserved for the borders on both sides
         splitterRectangle = new Rectangle(1, Bar.Height - (splitterPosition + smallButtonRectangle.Height + 1),
            Bar.Width - 2, splitterHeight);
      }

        /// <summary>
        /// Calculates the size and the position of the bands
        /// </summary>
        private void LayoutBands()
      {
         foreach (NaviBand band in Bar.Bands)
         {
            band.Location = new Point(1, Bar.HeaderHeight);
            band.Size = new Size(Bar.Width - 2, splitterRectangle.Y - Bar.HeaderHeight);

            if ((band == Bar.ActiveBand)
            && (!Bar.Collapsed))
            {
               // Change z-order to front
               band.BringToFront();
            }
         }
         if (Bar.Collapsed)
         {
            collapsedBand.Visible = true;
            collapsedBand.BringToFront();
            collapsedBand.Text = Bar.ActiveBand.Text;
         }
         collapsedBand.Location = new Point(1, Bar.HeaderHeight);
         collapsedBand.Size = new Size(Bar.Width - 2, splitterRectangle.Y - 1 - Bar.HeaderHeight);
      }

        /// <summary>
        /// Recalculates the size and positions of the small button rectangle
        /// </summary>
        private void CalculateRegions()
      {
         headerRectangle = new Rectangle(new Point(1, 1), new Size(Bar.Width - 2, Bar.HeaderHeight - 1));
         headerTextRectangle = new Rectangle(new Point(1, 1), new Size(Bar.Width - 2, Bar.HeaderHeight - 1));
         smallButtonRectangle = new Rectangle(1, Bar.Height - Bar.MinimizedPanelHeight, Bar.Width - 2, Bar.MinimizedPanelHeight - 1);
      }

        /// <summary>
        /// Returns true if the given x and y coordinate are inside the bounds of the splitter
        /// rectangle
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True when the x and y coordinate are inside the bounds; False otherwise</returns>
        private bool MouseInSplitter(int x, int y)
      {
         return ((x > splitterRectangle.X)
            && (x < splitterRectangle.Right)
            && (y > splitterRectangle.Y)
            && (y < splitterRectangle.Bottom));
      }

        /// <summary>
        /// Handles the MouseDown event
        /// </summary>
        /// <param name="e">Additional event info</param>
        private void HandleMouseDown(MouseEventArgs e)
      {
         if (e != null)
         {
            if ((e.Button == MouseButtons.Left)
            && (e.Clicks == 1)
            && (MouseInSplitter(e.X, e.Y)))
            {
               splitterDragging = true;
            }
            else
            {
               splitterDragging = false;
            }
         }
      }

        /// <summary>
        /// Handles the MouseMove event
        /// </summary>
        /// <param name="e">Additional event info</param>
        private void HandleMouseMove(MouseEventArgs e)
      {
         if (e != null)
         {
            if (splitterDragging)
               DragSplitter(e.Y);

            if ((MouseInSplitter(e.X, e.Y))
            || (splitterDragging))
            {
               Bar.Cursor = Cursors.SizeNS;
            }
            else
            {
               Bar.Cursor = Cursors.Default;
            }
         }
      }

        /// <summary>
        /// Recalculates the total visible buttons and visible large buttons
        /// </summary>
        /// <remarks>This method prevents the visible button count and the visible large button count to be
        /// higher than the actual amount of buttons. This method should be called whenever the
        /// collection of buttons is changed</remarks>
        private void ReCalculateButtonTotals()
      {
         visibleButtons = 0;
         foreach (NaviButton button in Bar.Buttons)
         {
            if (button.Visible)
               visibleButtons++;
         }
         if (Bar.VisibleLargeButtons > visibleButtons)
         {
            // Nasty bug when saving a form and then reopening the form design time. 
            // The problem is related to EndInit/Initializing and the bands collection not 
            // being completely filled. 
            //Bar.VisibleLargeButtons = visibleButtons;
         }
      }

        /// <summary>
        /// Moves the splitter to a new location
        /// </summary>
        /// <param name="ylocation">The new y coordinate of the splitter</param>
        /// <remarks>The splitter can not be moved outside the bounds of the control. This method also moves the
        /// splitter based on the current button height and the amount of visible buttons.</remarks>
        private void DragSplitter(int ylocation)
      {
         // Position of the mouse calculated from the buttom of the control up to the top to 
         // make things easier. 
         int ylocinv = (Bar.Height - ylocation) - smallButtonRectangle.Height - splitterHeight;

         if (Bar.VisibleLargeButtons > visibleButtons)
         {
            Bar.VisibleLargeButtons = visibleButtons;
         }

         // Check whether splitter is inside bounds
         if (ylocinv > 0)
         {
            // Increment position using a step. 
            if (ylocinv > (Bar.ButtonHeight + (Bar.VisibleLargeButtons * Bar.ButtonHeight)))
            {
               if (Bar.VisibleLargeButtons < visibleButtons)
               {
                  Bar.VisibleLargeButtons++;
               }
            }
            // Bar.ButtonHeight / 2 because it looks more smooth
            else if (ylocinv <= ((Bar.ButtonHeight * Bar.VisibleLargeButtons) - (Bar.ButtonHeight / 2)))
            {
               if (Bar.VisibleLargeButtons > 0)
               {
                  Bar.VisibleLargeButtons--;
               }
            }
         }
         else
         {
            // Splitter is outside bounds (negative) 
            Bar.VisibleLargeButtons = 0;
         }

         this.Layout(Bar, new LayoutEventArgs(Bar, "Splitter"));
         Bar.Invalidate();
      }

        /// <summary>
        /// Calculates the position of the buttons
        /// </summary>
        protected virtual void LayoutButtons()
      {
         int buttonCount = 0;

         // Gently lays out the position of the large buttons
         int flow = (splitterPosition + smallButtonRectangle.Height + 1) - splitterHeight;

         // 1px extra marge for the border of the control
         // The optionButtonWidth is the space reserved for the options button
         int compactFlow = ((visibleButtons - Bar.VisibleLargeButtons) * Bar.MinimizedButtonWidth) + 1;

         if (Bar.ShowMoreOptionsButton)
         {
            // Initializes the options button
            optionsButton.Small = true;
            optionsButton.Height = smallButtonRectangle.Height;
            optionsButton.Width = optionButtonWidth;
            optionsButton.Visible = true;
            compactFlow += optionButtonWidth;

            if (Bar.RightToLeft == RightToLeft.Yes)
               optionsButton.Location = new Point(1, smallButtonRectangle.Top);
            else
               optionsButton.Location = new Point(Bar.Width - (optionButtonWidth + 1), smallButtonRectangle.Top);
         }
         else
         {
            optionsButton.Visible = false;
         }
         
         // Order of bands can be different than ordering of the list of buttons 
         foreach (NaviBand band in Bar.Bands)
         {
            if (band.Button == null)
               continue;

            NaviButton button = band.Button;
            if (button.Visible)
            {
               buttonCount++;

               // Require
               if ((Bar.ActiveBand != null) 
               && (Bar.ActiveBand.Button == button)
               && (button.Active == false))
               {
                  button.Active = true;
               }

               // Regular 'hot' buttons which are part of the main Bar
               if (buttonCount <= Bar.VisibleLargeButtons)
               {
                  button.Location = new Point(1, Bar.Height - flow);
                  button.Height = Bar.ButtonHeight;
                  button.Width = Bar.Width - 2; // extra space for border on both sides
                  button.Small = false;

                  flow -= Bar.ButtonHeight;
               }
               else
               {
                  // Additional buttons presented at the bottom as small rectangles

                  if (!Bar.Collapsed)
                  {
                     button.Small = true;
                     button.Height = smallButtonRectangle.Height;
                     button.Width = Bar.MinimizedButtonWidth;

                     if (Bar.RightToLeft == RightToLeft.Yes)
                        button.Location = new Point(compactFlow - Bar.MinimizedButtonWidth, smallButtonRectangle.Top);
                     else
                        button.Location = new Point(Bar.Width - compactFlow, smallButtonRectangle.Top);

                     compactFlow -= Bar.MinimizedButtonWidth;
                  }
                  else
                  {
                     button.Location = new Point(0, 0);
                     button.Size = new Size(0, 0);
                  }
               }
            }
         }

         // Collapse button                  
         collapseButton.Visible = Bar.ShowCollapseButton && (!showNeverCollapse);
         collapseButton.Size = new Size(Bar.HeaderHeight, Bar.HeaderHeight - 3);
         if (Bar.RightToLeft == RightToLeft.Yes)
            collapseButton.Location = new Point(2, 2); // (Bar.HeaderHeight / 2) + 3);
         else
            collapseButton.Location = new Point(Bar.Width - Bar.HeaderHeight - 1, 2); // (Bar.HeaderHeight / 2) + 3);        
      }

        /// <summary>
        /// Creates a new instance of the option dialog and shows it to the user.
        /// </summary>
        private void ShowMoreOptionsDialog()
      {
         NaviOptionsForm form = new NaviOptionsForm();
         form.Initialize(Bar);
         if (form.ShowDialog() == DialogResult.OK)
         {
            Layout(Bar, new LayoutEventArgs(Bar, "Band.Visible"));
         }
      }

        /// <summary>
        /// Shows the options menu
        /// </summary>
        public void ShowOptionsMenu()
      {
         Point location = new Point(optionsButton.Right, optionsButton.Top + optionsButton.Height / 2);
         Point screenLocation = Bar.PointToScreen(location);
         optionsMenu.Show(screenLocation);
      }

        /// <summary>
        /// Checks the button count.
        /// </summary>
        public void CheckButtonCount()
      {
         if (Bar.VisibleLargeButtons > visibleButtons)
         {
            Bar.VisibleLargeButtons = visibleButtons;
         }
      }

        /// <summary>
        /// Initializes all child controls
        /// </summary>
        public override void InitializeChildControls()
      {
         renderer = new NaviBarRendererOff7();
         splitterRenderer = new NaviSplitterRendererOff7();

         optionsButton = new NaviButtonOptions();
         optionsButton.Small = true;
         optionsButton.Click += new EventHandler(optionsButton_Click);

         collapseButton = new NaviButtonCollapse();
         collapseButton.Size = new Size(18, 18);
         collapseButton.Name = "navigationBarCollapseButton1";
         collapseButton.Click += new EventHandler(collapseButton_Click);

         collapsedBand = new NaviBandCollapsed();
         collapsedBand.Name = "navigationBarBar.CollapsedBand1";
         collapsedBand.Visible = false;
         collapsedBand.MouseUp += new MouseEventHandler(CollapsedBand_MouseUp);

         optionsButton.LayoutStyle = Bar.LayoutStyle;
         collapseButton.LayoutStyle = Bar.LayoutStyle;
         collapsedBand.LayoutStyle = Bar.LayoutStyle;

         InitializeMenu();

         Bar.Controls.Add(optionsButton);
         Bar.Controls.Add(collapseButton);
         Bar.Controls.Add(collapsedBand);
      }

        /// <summary>
        /// Initializes the menu for the first time
        /// </summary>
        private void InitializeMenu()
      {
         this.optionsMenu = new NaviContextMenu();
         this.miShowMoreButtons = new ToolStripMenuItem();
         this.miShowLessButtons = new ToolStripMenuItem();
         this.miShowMoreOptions = new ToolStripMenuItem();
         this.miAddOrRemoveButtons = new ToolStripMenuItem();

         this.optionsMenu.Items.Clear();
         this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowMoreButtons,
            this.miShowLessButtons,
            this.miShowMoreOptions,
            this.miAddOrRemoveButtons});
         this.optionsMenu.Name = "optionsMenu";
         this.optionsMenu.Size = new System.Drawing.Size(235, 114);
         this.optionsMenu.RightToLeft = Bar.RightToLeft;

         // 
         // miShowMoreButtons
         // 
         this.miShowMoreButtons.Name = "showMoreButtonsToolStripMenuItem";
         this.miShowMoreButtons.Size = new System.Drawing.Size(234, 22);
         this.miShowMoreButtons.Text = "Show more buttons";
         this.miShowMoreButtons.Click += new EventHandler(miShowMoreButtons_Click);
         this.miShowMoreButtons.Image = Properties.Resources.Up1;
         this.miShowMoreButtons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
         // 
         // miShowLessButtons
         // 
         this.miShowLessButtons.Name = "showLessButtonsToolStripMenuItem";
         this.miShowLessButtons.Size = new System.Drawing.Size(234, 22);
         this.miShowLessButtons.Text = "Show less buttons";
         this.miShowLessButtons.Click += new EventHandler(miShowLessButtons_Click);
         this.miShowLessButtons.Image = Properties.Resources.Down2;
         this.miShowLessButtons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
         // 
         // miShowMoreOptions
         // 
         this.miShowMoreOptions.Name = "optionsOfTheNavigationPaneToolStripMenuItem";
         this.miShowMoreOptions.Size = new System.Drawing.Size(234, 22);
         this.miShowMoreOptions.Text = "Options of the navigation pane";
         this.miShowMoreOptions.Click += new EventHandler(miShowMoreOptions_Click);
         // 
         // miAddOrRemoveButtons
         //          
         this.miAddOrRemoveButtons.Name = "addOrRemoveButtonsToolStripMenuItem";
         this.miAddOrRemoveButtons.Size = new System.Drawing.Size(234, 22);
         this.miAddOrRemoveButtons.Text = "Add or remove buttons";
      }

        /// <summary>
        /// Fills the submenu with the approperiate menuitems and initializes their checkstate
        /// </summary>
        private void InitializeSubMenu()
      {
         this.miAddOrRemoveButtons.DropDownItems.Clear();

         foreach (NaviBand band in Bar.Bands)
         {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();

            menuItem.Text = band.Text;
            menuItem.Image = band.SmallImage;
            if (band.Visible)
            {
               menuItem.Checked = true;
               menuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            }
            else
            {
               menuItem.Checked = false;
               menuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            menuItem.CheckOnClick = true;
            menuItem.CheckedChanged += new EventHandler(menuItem_CheckedChanged);

            // Add 
            this.miAddOrRemoveButtons.DropDownItems.Add(menuItem);
         }
      }

        /// <summary>
        /// Relayouts the options menu
        /// </summary>
        private void LayoutMenu()
      {
         optionsMenu.RightToLeft = Bar.RightToLeft;
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Requests that the layout engine should perform a layout operation
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="layoutEventArgs">Additional event info</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
      {
         CalculateRegions();
         LayoutSplitter();
         ReCalculateButtonTotals();
         if (layoutEventArgs.AffectedProperty == "Band.Visible")
         {
            CheckButtonCount();
            InitializeSubMenu();
         }
         if (layoutEventArgs.AffectedProperty == "RightToLeft")
            LayoutMenu();
         LayoutButtons();
         LayoutBands();
         return true;
      }

        /// <summary>
        /// Draws the Navigation pane control
        /// </summary>
        /// <param name="g">A graphics object providing drawing functionality</param>
        public override void Draw(Graphics g)
      {
         if (Bar.ActiveBand != null)
         {
            renderer.DrawHeaderText(g, headerTextRectangle, Bar.ActiveBand.Text,
               headerFont, Bar.RightToLeft == RightToLeft.Yes);
         }
      }

        /// <summary>
        /// Draws the background of the Navigation pane
        /// </summary>
        /// <param name="g">Graphics object providing drawing functionality</param>
        public override void DrawBackground(Graphics g)
      {
         renderer.DrawBackground(g, Bar.ClientRectangle);
         renderer.DrawSmallButtonRegion(g, smallButtonRectangle);
         renderer.DrawHeader(g, headerRectangle);
         splitterRenderer.DrawBackground(g, splitterRectangle);
      }

        /// <summary>
        /// Overriden. Handles the Notification the observable object sent
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        public override void Notify(IObservable obj, string id, object arguments)
      {
         switch (id)
         {
            case "MouseDown":
               HandleMouseDown(arguments as MouseEventArgs);
               break;
            case "MouseMove":
               HandleMouseMove(arguments as MouseEventArgs);
               break;
            case "MouseLeave":
               Bar.Cursor = Cursors.Default;
               break;
            case "MouseUp":
               splitterDragging = false;
               break;
            default: break;
         }
      }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);
         if (Bar.Controls.Contains(optionsButton))
            Bar.Controls.Remove(optionsButton);
         if (Bar.Controls.Contains(collapseButton))
            Bar.Controls.Remove(collapseButton);
         if (Bar.Controls.Contains(collapsedBand))
            Bar.Controls.Remove(collapsedBand);
      }

        /// <summary>
        /// Handles additional functionality at the end of the initialization
        /// </summary>
        public override void EndInit()
      {         
      }

        /// <summary>
        /// Changes the navigation bar to Bar.Collapsed view
        /// </summary>
        /// <param name="collapse">if set to <c>true</c> [collapse].</param>
        /// <param name="oldCollapsed">if set to <c>true</c> [old collapsed].</param>
        public override void SwitchCollapsion(bool collapse, bool oldCollapsed)
      {
         if ((collapse)
         && (!oldCollapsed))
         {
            orgWidth = Bar.Width;
            Bar.Width = 33;
         }

         if (!collapse)
         {
            if (orgWidth < 100)
               orgWidth = 100;
            Bar.Width = orgWidth;
         }

         foreach (NaviButton button in Bar.Buttons)
         {
            button.Collapsed = collapse;
         }
         collapseButton.Collapsed = collapse;
         //Layout(Bar, new LayoutEventArgs(this, "Bar.Collapsed"));
      }

        #endregion

        #region Event Handling

        /// <summary>
        /// Shows the options menu
        /// </summary>
        /// <param name="sender">The button on which this event occured</param>
        /// <param name="e">Additional info</param>
        void optionsButton_Click(object sender, EventArgs e)
      {
         ShowOptionsMenu();
      }

        /// <summary>
        /// Shows more buttons
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        void miShowMoreButtons_Click(object sender, EventArgs e)
      {
         Bar.VisibleLargeButtons++;
         Layout(Bar, new LayoutEventArgs(this, "Bar.VisibleLargeButtons"));
         Bar.Invalidate();
      }

        /// <summary>
        /// Shows less buttons
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        void miShowLessButtons_Click(object sender, EventArgs e)
      {
         Bar.VisibleLargeButtons--;
         Layout(Bar, new LayoutEventArgs(this, "Bar.VisibleLargeButtons"));
         Bar.Invalidate();
      }

        /// <summary>
        /// Shows more options regarding the navigation bar
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        void miShowMoreOptions_Click(object sender, EventArgs e)
      {
         ShowMoreOptionsDialog();
      }

        /// <summary>
        /// Shows or hide the button linked to the menu item
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        void menuItem_CheckedChanged(object sender, EventArgs e)
      {
         if (sender is ToolStripMenuItem)
         {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
               foreach (NaviBand band in Bar.Bands)
               {
                  if (band.Text.Equals(menuItem.Text))
                  {
                     band.Visible = menuItem.Checked;
                  }
               }
            }
            Layout(Bar, new LayoutEventArgs(this, "Bar.VisibleLargeButtons"));
            Bar.Invalidate();
         }
      }

        /// <summary>
        /// Switch the collapsion of the Navigation bar
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void collapseButton_Click(object sender, EventArgs e)
      {
         Bar.Collapsed = !Bar.Collapsed;
      }

        /// <summary>
        /// Shows the band in a popup
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void CollapsedBand_MouseUp(object sender, MouseEventArgs e)
      {
         // TODO Right to left
         popup = new NaviBandPopup();
         popup.Content = Bar.ActiveBand.ClientArea;
         popup.LayoutStyle = Bar.ActiveBand.LayoutStyle;

         popupHelper = new PopupWindowHelper();
         System.Windows.Forms.Form parent = Bar.FindForm();
         popupHelper.PopupClosed += new PopupClosedEventHandler(popupHelper_PopupClosed);

         popupHelper.AssignHandle(parent.Handle);
         popup.Resizable = true;
         popup.ShowInTaskbar = false;
         popup.Width = orgWidth;
         if (Bar.RightToLeft == RightToLeft.Yes)
         {
            popupHelper.ShowPopup(parent, popup, Bar.PointToScreen(new Point(0 - orgWidth, Bar.HeaderHeight)));
         }
         else
         {
            popupHelper.ShowPopup(parent, popup, Bar.PointToScreen(new Point(Bar.Width, Bar.HeaderHeight)));
         }
      }

        /// <summary>
        /// Handles the PopupClosed event of the popupHelper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupClosedEventArgs"/> instance containing the event data.</param>
        void popupHelper_PopupClosed(object sender, PopupClosedEventArgs e)
      {
         Control clientArea = popup.Content;
         Bar.ActiveBand.Controls.Add(clientArea);
         clientArea.Invalidate();
         orgWidth = popup.Width;
         Layout(Bar, new LayoutEventArgs(Bar, "PopUp"));
      }

      #endregion
   }
}
