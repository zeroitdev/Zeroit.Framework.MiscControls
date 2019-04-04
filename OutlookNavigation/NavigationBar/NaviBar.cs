// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a navigation control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviControl" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IObservable" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    [
    Designer(typeof(NaviBarDesigner)),
   DefaultEvent("activeBandChanged"),
   DefaultProperty("Bands"),
   ToolboxItem(true),
   ToolboxBitmap(typeof(ZeroitNaviBar))
   ]
   public partial class ZeroitNaviBar : NaviControl, IObservable, ISupportInitialize
   {
        #region Fields

        /// <summary>
        /// The bands
        /// </summary>
        NaviBandCollection bands;
        /// <summary>
        /// The buttons
        /// </summary>
        NaviButtonCollection buttons;
        /// <summary>
        /// The navi layout
        /// </summary>
        NaviLayout naviLayout;
        /// <summary>
        /// The active band
        /// </summary>
        NaviBand activeBand;

        /// <summary>
        /// The active band changing
        /// </summary>
        NaviBandEventHandler activeBandChanging;
        /// <summary>
        /// The active band changed
        /// </summary>
        EventHandler activeBandChanged;
        /// <summary>
        /// The layout changed
        /// </summary>
        EventHandler layoutChanged;
        /// <summary>
        /// The band added
        /// </summary>
        ControlEventHandler bandAdded;
        /// <summary>
        /// The settings
        /// </summary>
        NaviBarSettings settings;

        /// <summary>
        /// The initializing
        /// </summary>
        bool initializing = true;
        /// <summary>
        /// The show minimize button
        /// </summary>
        bool showMinimizeButton = true;
        /// <summary>
        /// The show more options button
        /// </summary>
        bool showMoreOptionsButton = true;
        /// <summary>
        /// The collapsed
        /// </summary>
        bool collapsed = false;
        /// <summary>
        /// The show collapse button
        /// </summary>
        bool showCollapseButton = true;
        /// <summary>
        /// The header height
        /// </summary>
        int headerHeight = 27;
        /// <summary>
        /// The minimized button width
        /// </summary>
        int minimizedButtonWidth = 25;
        /// <summary>
        /// The minimized panel height
        /// </summary>
        int minimizedPanelHeight = 32;
        /// <summary>
        /// The button height
        /// </summary>
        int buttonHeight = 32;
        /// <summary>
        /// The visible large buttons
        /// </summary>
        int visibleLargeButtons;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBar class
        /// </summary>
        public ZeroitNaviBar()
      {
         InitializeComponent();
         Initialize();
      }

        /// <summary>
        /// Iniializes a new instance of the NaviBar class
        /// </summary>
        /// <param name="container">The parent container</param>
        public ZeroitNaviBar(IContainer container)
      {
         container.Add(this);
         Initialize();
         InitializeComponent();
      }

        #endregion

        #region Properties

        // Design time visible

        /// <summary>
        /// Gets or sets the collection of Bands
        /// </summary>
        /// <value>The bands.</value>
        [
        Browsable(true),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBandCollection Bands
      {
         get { return bands; }
         set { bands = value; }
      }

        /// <summary>
        /// Gets or sets the active band
        /// </summary>
        /// <value>The active band.</value>
        [
        Browsable(true),
      ]
      public NaviBand ActiveBand
      {
         get { return activeBand; }
         set
         {
            SetActiveBand(value);
         }
      }

        /// <summary>
        /// Gets or sets the layout
        /// </summary>
        /// <value>The navi layout.</value>
        /// <exception cref="System.ArgumentNullException"></exception>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviLayout NaviLayout
      {
         get { return naviLayout; }
         set
         {
            if (value == null)
               throw new ArgumentNullException();
            naviLayout = value;
            naviLayout.Bar = this;
            observers.Add(naviLayout);
         }
      }

        /// <summary>
        /// Gets or sets the collection of buttons
        /// </summary>
        /// <value>The buttons.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviButtonCollection Buttons
      {
         get { return buttons; }
         set { buttons = value; }
      }

        /// <summary>
        /// Gets or sets the settings file
        /// </summary>
        /// <value>The settings.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
      ]
      public NaviBarSettings Settings
      {
         get
         {
            if (settings == null)
               settings = new NaviBarSettings();
            settings.BandSettings.Clear();
            settings.VisibleButtons = visibleLargeButtons;
            settings.Collapsed = collapsed;

            foreach (NaviBand band in bands)
            {
               NaviBandSetting setting = new NaviBandSetting();
               
               setting.Name = band.Text;
               setting.Order = band.Order;
               setting.Visible = band.Visible;

               settings.BandSettings.Add(setting);
            }

            return settings;
         }
         set
         {
            settings = value;
         }
      }

        /// <summary>
        /// Gets or sets the height of the header containing the title
        /// </summary>
        /// <value>The height of the header.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(27)
      ]
      public int HeaderHeight
      {
         get { return headerHeight; }
         set
         {
            headerHeight = value;

            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "HeaderHeight"));
         }
      }

        /// <summary>
        /// Gets or sets the height of the minimized buttons panel
        /// </summary>
        /// <value>The height of the minimized panel.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(32)
      ]
      public int MinimizedPanelHeight
      {
         get { return minimizedPanelHeight; }
         set
         {
            minimizedPanelHeight = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "MinimizedPanelHeight"));
            Invalidate();
         }
      }

        /// <summary>
        /// TODO Gets or sets the font of the header
        /// </summary>
        /// <value>The height of the button.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(32)
      ]
      public int ButtonHeight
      {
         get { return buttonHeight; }
         set
         {
            buttonHeight = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ButtonHeight"));
         }
      }

        /// <summary>
        /// Gets or sets whether to show the more options button or not
        /// </summary>
        /// <value><c>true</c> if [show more options button]; otherwise, <c>false</c>.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowMoreOptionsButton
      {
         get { return showMoreOptionsButton; }
         set
         {
            showMoreOptionsButton = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ShowMoreOptionsButton"));
         }
      }

        /// <summary>
        /// Gets or sets whether the pane is minimized or not
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(false)
      ]
      public bool Collapsed
      {
         get { return collapsed; }
         set
         {
            bool oldCollapsed = collapsed;
            collapsed = value;
            naviLayout.SwitchCollapsion(value, oldCollapsed);
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "Collapsed"));
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets whether the pane is minimized or not
        /// </summary>
        /// <value><c>true</c> if [show collapse button]; otherwise, <c>false</c>.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowCollapseButton
      {
         get { return showCollapseButton; }
         set
         {
            showCollapseButton = value;
            if (!initializing)
               OnLayout(new LayoutEventArgs(this, "ShowCollapseButton"));
            Invalidate();
         }
      }

        /// <summary>
        /// Gets or sets whether the minimize button should be visible
        /// </summary>
        /// <value><c>true</c> if [show minimize button]; otherwise, <c>false</c>.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(true)
      ]
      public bool ShowMinimizeButton
      {
         get { return showMinimizeButton; }
         set { showMinimizeButton = value; }
      }

        /// <summary>
        /// Gets or sets the width of the minimized buttons
        /// </summary>
        /// <value>The width of the minimized button.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(25)
      ]
      public int MinimizedButtonWidth
      {
         get { return minimizedButtonWidth; }
         set { minimizedButtonWidth = value; }
      }

        /// <summary>
        /// Gets or sets the amount of visible buttons
        /// </summary>
        /// <value>The visible large buttons.</value>
        [
        Browsable(true),
      NotifyParentProperty(true),
      EditorBrowsable(EditorBrowsableState.Always),
      DefaultValue(0)
      ]
      public int VisibleLargeButtons
      {
         get { return visibleLargeButtons; }
         set
         {
            if (!initializing)
            {
               if (value < 0)
               {
                  visibleLargeButtons = 0;
               }
               else if (value > naviLayout.VisibleButtons)
               {
                  visibleLargeButtons = naviLayout.VisibleButtons;
               }
               else
               {
                  visibleLargeButtons = value;
               }
               OnLayout(new LayoutEventArgs(this, "VisibleLargeButtos"));
            }
            else
            {
               visibleLargeButtons = value;
            }
            Invalidate();
         }
      }

        // Design time not visible

        #endregion

        #region Events

        /// <summary>
        /// Occurs before the active band is changed
        /// </summary>
        public event NaviBandEventHandler ActiveBandChanging
      {
         add { lock (threadLock) { activeBandChanging += value; } }
         remove { lock (threadLock) { activeBandChanging -= value; } }
      }

        /// <summary>
        /// Occurs after the active band has been changed
        /// </summary>
        public event EventHandler ActiveBandChanged
      {
         add { lock (threadLock) { activeBandChanged += value; } }
         remove { lock (threadLock) { activeBandChanged -= value; } }
      }

        /// <summary>
        /// Occurs when the layout has been changed
        /// </summary>
        public event EventHandler LayoutChanged
      {
         add { lock (threadLock) { layoutChanged += value; } }
         remove { lock (threadLock) { layoutChanged -= value; } }
      }

        /// <summary>
        /// Occurs after a new band has been added to the collection of bands
        /// </summary>
        public event ControlEventHandler BandAdded
      {
         add { lock (threadLock) { bandAdded += value; } }
         remove { lock (threadLock) { bandAdded -= value; } }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the Control for the first time
        /// </summary>
        private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         bands = new NaviBandCollection();
         bands.ItemAdded += new CollectionEventHandler(bands_ItemAdded);
         bands.ItemRemoved += new CollectionEventHandler(bands_ItemRemoved);
         buttons = new NaviButtonCollection();
      }

        /// <summary>
        /// Creates the 2007 office layout objects
        /// </summary>
        private void Initialize2007Layout()
      {
         if (!(naviLayout is NaviLayoutOff))
         {
            if (naviLayout != null)
               naviLayout.Dispose();
            NaviLayout = new NaviLayoutOff();
            naviLayout.Bar = this;
            naviLayout.InitializeChildControls();
            NaviLayout.EndInit();
         }

         NaviLayoutOff offLayout = (NaviLayoutOff)naviLayout;
         offLayout.ShowNeverCollapse = false;
         if (!(offLayout.Renderer is NaviBarRendererOff7))
            offLayout.Renderer = new NaviBarRendererOff7();

         if (!(offLayout.SplitterRenderer is NaviSplitterRendererOff7))
            offLayout.SplitterRenderer = new NaviSplitterRendererOff7();

      }

        /// <summary>
        /// Creates the 2003 office layout objects
        /// </summary>
        private void Initialize2003Layout()
      {
         if (!(naviLayout is NaviLayoutOff))
         {
            if (naviLayout != null)
               naviLayout.Dispose();
            NaviLayout = new NaviLayoutOff();
            naviLayout.Bar = this;
            naviLayout.InitializeChildControls();
         }

         NaviLayoutOff offLayout = (NaviLayoutOff)naviLayout;
         offLayout.ShowNeverCollapse = true;
         if (!(offLayout.Renderer is NaviBarRendererOff3))
            offLayout.Renderer = new NaviBarRendererOff3();

         if (!(offLayout.SplitterRenderer is NaviSplitterRendererOff3))
            offLayout.SplitterRenderer = new NaviSplitterRendererOff3();
      }

        /// <summary>
        /// Res the initialize layout.
        /// </summary>
        internal void ReInitializeLayout()
      {
         NaviLayoutOff offLayout;
         switch (LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3();
               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3();
               break;
            case NaviLayoutStyle.Office2003Green:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3Green();
               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3Green();
               break;
            case NaviLayoutStyle.Office2003Silver:
               Initialize2003Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff3)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff3Silver();

               ((NaviBarRendererOff3)offLayout.Renderer).ColorTable = new NaviColorTableOff3Silver();
               break;
            case NaviLayoutStyle.Office2007Blue:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7();
               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7();
               break;
            case NaviLayoutStyle.Office2007Black:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7Black();

               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7Black();

               break;
            case NaviLayoutStyle.Office2007Silver:
               Initialize2007Layout();
               offLayout = (NaviLayoutOff)naviLayout;

               ((NaviSplitterRendererOff7)offLayout.SplitterRenderer).ColorTable =
                  new NaviColorTableOff7Silver();

               ((NaviBarRendererOff7)offLayout.Renderer).ColorTable = new NaviColorTableOff7Silver();
               break;
         }
         if (!initializing)
            OnLayout(new LayoutEventArgs(this, "Collapsed"));
         Invalidate();
      }

        /// <summary>
        /// Raises the ActiveBandChanging event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnActiveBandChanging(NaviBandEventArgs e)
      {
         NaviBandEventHandler handler = activeBandChanging;
         if (handler != null)
         {
            handler(this, e);
         }
      }

        /// <summary>
        /// Raises the ActiveBandChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnActiveBandChanged(EventArgs e)
      {
         EventHandler handler = activeBandChanged;
         if (handler != null)
         {
            handler(this, e);
         }
      }

        /// <summary>
        /// Raises the LayoutChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnLayoutChanged(EventArgs e)
      {
         EventHandler handler = layoutChanged;
         if (handler != null)
         {
            handler(this, e);
         }
      }

        /// <summary>
        /// Raises the BandAdded event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnBandAdded(ControlEventArgs e)
      {
         ControlEventHandler handler = bandAdded;
         if (handler != null)
         {
            handler(this, e);
         }
      }

        /// <summary>
        /// Adds a new band to the collection of bands
        /// </summary>
        /// <param name="band">The new band</param>
        internal void AddBand(NaviBand band)
      {
         if (!Controls.Contains(band))
            Controls.Add(band);

         if (!bands.Contains(band))
            bands.SilentAdd(band);

         AddButton(band);
         band.VisibleChanged += new EventHandler(band_VisibleChanged);

         band.LayoutStyle = LayoutStyle;
         band.Button.LayoutStyle = LayoutStyle;

         OnBandAdded(new ControlEventArgs(band));
      }

        /// <summary>
        /// Changes the currently active band to a new band
        /// </summary>
        /// <param name="newBand">The new band.</param>
        public void SetActiveBand(NaviBand newBand)
      {
         NaviBandEventArgs e = new NaviBandEventArgs(newBand);
         OnActiveBandChanging(e);
         if (!e.Canceled)
         {
            if (activeBand != newBand)
            {
               foreach (NaviBand band in bands)
               {
                  if ((band != newBand) && (band.Button != null))
                  {
                     band.Button.Active = false;
                  }
               }
            }
            if ((newBand != null) && (newBand.Button != null))
            {
               newBand.Button.Active = true;
            }

            activeBand = newBand;

            OnLayout(new LayoutEventArgs(this, "ActiveBand"));
            OnActiveBandChanged(new EventArgs());
            Invalidate();
         }
         else
         {
            // Lost focus but did not recieve an mouse leave event. So force redraw
            newBand.Button.Active = false;
         }
      }

        /// <summary>
        /// Adds the band button to the collection of controls
        /// </summary>
        /// <param name="band">The band</param>
        private void AddButton(NaviBand band)
      {
         if (band.Button == null)
         {
            NaviButton button = new NaviButton();

            button.SmallImage = band.SmallImage;
            button.LargeImage = band.LargeImage;
            button.Text = band.Text;
            button.Click += new EventHandler(button_Click);

            band.Button = button;
         }
         if (!Controls.Contains(band.Button))
         {
            Controls.Add(band.Button);
         }
         if (!buttons.Contains(band.Button))
         {
            buttons.Add(band.Button);
         }
      }

        /// <summary>
        /// Removes a band from te collection of bands
        /// </summary>
        /// <param name="band">The band to remove</param>
        public void RemoveBand(NaviBand band)
      {
         if (band.Button != null)
         {
            band.Button.Click -= new EventHandler(button_Click);
            band.VisibleChanged -= new EventHandler(band_VisibleChanged);
         }

         if (Controls.Contains(band.Button))
            Controls.Remove(band.Button);
         if (buttons.Contains(band.Button))
            buttons.Remove(band.Button);

         if (Controls.Contains(band))
            Controls.Remove(band);
         if (bands.Contains(band))
            bands.Remove(band);
      }

        /// <summary>
        /// Applies the settings currently loaded in the Settings property
        /// </summary>
        /// <remarks>It's possible that no setting exist for this particular band. For example a new
        /// version has been released. Then this band is added at the end of the collection
        /// and visible is set to true</remarks>
        public void ApplySettings()
      {
         if (settings == null) 
            return;
         
         foreach (NaviBand band in bands)
         {
            // try to find the setting
            NaviBandSetting setting = null;
            foreach (NaviBandSetting tmpSetting in settings.BandSettings)
            {
               if (tmpSetting.Name.ToLower() == band.Text.ToLower())
                  setting = tmpSetting;
            }

            // It's possible that no setting exist for this particular band. For example a new
            // version has been released. Then this band is added at the end of the collection 
            // and visible is set to true
            if (setting == null)
            {
               band.Order = 999;
               band.Visible = true;
            }
            else
            {
               band.Visible = setting.Visible;
               band.Order = setting.Order;
            }   
         }

         VisibleLargeButtons = settings.VisibleButtons;
         Collapsed = settings.Collapsed;
         bands.Sort(new NaviBandOrderComparer());

         // Rebuild ordering values. This is to prevent 999 and duplicate values from showing 
         // up in the settings file
         for (int i = 0; i < bands.Count; i++)
            bands[i].Order = i;
         OnLayout(new LayoutEventArgs(this, "Band.Visible"));
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the ControlAdded event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
      {
         base.OnControlAdded(e);
         if ((e.Control is NaviBand)
         && !(e.Control is NaviBandCollapsed))
         {
            AddBand(e.Control as NaviBand);
            OnLayout(new LayoutEventArgs(this, "Bands"));
         }
      }

        /// <summary>
        /// Overriden. Raises the ControlRemoved event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
      {
         base.OnControlRemoved(e);
         if (e.Control is NaviBand)
         {
            RemoveBand(e.Control as NaviBand);
         }
      }

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         if (!initializing)
            naviLayout.Draw(e.Graphics);
      }

        /// <summary>
        /// Overriden. Raises the PaintBackground
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
      {
         if (!initializing)
            naviLayout.DrawBackground(pevent.Graphics);
      }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);
         NotifyObservers(this, "MouseDown", e);
      }

        /// <summary>
        /// Overriden. Raises the MouseDown event.
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);
         NotifyObservers(this, "MouseMove", e);
      }

        /// <summary>
        /// Overriden. Raises the MouseLeave event and changes the cursor back to default
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
      {
         base.OnMouseLeave(e);
         NotifyObservers(this, "MouseLeave", e);
      }

        /// <summary>
        /// Overriden. Raises the MouseUp event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);
         NotifyObservers(this, "MouseUp", e);
      }

        /// <summary>
        /// Overriden. Raises the LayoutStyleChanged event and changes the colorstyle on
        /// childcontrols
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayoutStyleChanged(EventArgs e)
      {
         base.OnLayoutStyleChanged(e);
         foreach (Control childControl in Controls)
         {
            if (childControl is NaviControl)
            {
               ((NaviControl)childControl).LayoutStyle = LayoutStyle;
            }
         }
         ReInitializeLayout();
      }

        /// <summary>
        /// Overriden. Raises the Resize event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnResize(EventArgs e)
      {
         base.OnResize(e);
         OnLayout(new LayoutEventArgs(this, "Size"));
      }

        /// <summary>
        /// Overriden. Raises the RightToLeftChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnRightToLeftChanged(EventArgs e)
      {
         base.OnRightToLeftChanged(e);
         OnLayout(new LayoutEventArgs(this, "RightToLeft"));
      }

        /// <summary>
        /// Overriden. Raises the OnLayout event
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.LayoutEventArgs" /> that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs e)
      {
         base.OnLayout(e);
         if ((NaviLayout != null)
         && (!initializing))
         {
            NaviLayout.Layout(this, e);
         }
      }

        #endregion

        #region Event Handling

        /// <summary>
        /// Handles the ItemRemoved event of the bands control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ChildCollectionEventArgs"/> instance containing the event data.</param>
        void bands_ItemRemoved(object sender, ChildCollectionEventArgs e)
      {
         RemoveBand(e.Item as NaviBand);
      }

        /// <summary>
        /// Handles the ItemAdded event of the bands control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ChildCollectionEventArgs"/> instance containing the event data.</param>
        void bands_ItemAdded(object sender, ChildCollectionEventArgs e)
      {
         AddBand(e.Item as NaviBand);
      }

        /// <summary>
        /// Changes the active button to the button on which this event occured
        /// </summary>
        /// <param name="sender">The button on which this event occured</param>
        /// <param name="e">Additional info</param>
        void button_Click(object sender, EventArgs e)
      {
         NaviButton button = sender as NaviButton;
         if (button != null)
         {
            foreach (NaviBand band in bands)
            {
               if (band.Button == button)
               {
                  SetActiveBand(band);
                  return;
               }
            }
         }
      }

        /// <summary>
        /// Relayouts the control
        /// </summary>
        /// <param name="sender">The band which triggered this event</param>
        /// <param name="e">Additional event info</param>
        void band_VisibleChanged(object sender, EventArgs e)
      {
         NaviBand band = sender as NaviBand;
         if ((band != null) && (band.Button != null))
         {
            band.Button.Visible = band.Visible;
         }
         OnLayout(new LayoutEventArgs(this, "Band.Visible"));
         Invalidate();
      }

        #endregion

        #region IObservable Members

        /// <summary>
        /// The observers
        /// </summary>
        List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// Gets the list of observers
        /// </summary>
        /// <value>The observers.</value>
        public List<IObserver> Observers
      {
         get { return observers; }
      }

        /// <summary>
        /// Notifies the Observers
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional arguments</param>
        public void NotifyObservers(IObservable obj, string id, object arguments)
      {
         foreach (IObserver observer in observers)
            observer.Notify(obj, id, arguments);
      }

        #endregion

        #region ISupportInitialize Members

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
      {
         initializing = true;
      }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
      {
         ReInitializeLayout();
         initializing = false;
         naviLayout.EndInit();
         Invalidate();
      }

      #endregion
   }
}
