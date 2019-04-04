// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PandaPanelGroup.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitPandaPanelGroup


    #region ZeroitPandaPanelGroup enumerations
    /// <summary>
    /// Enumeration of <see cref="ZeroitPandaPanelGroup" /> properties
    /// </summary>
    public enum ZeroitPandaPanelGroupProperties
    {
        /// <summary>
        /// <see cref="ZeroitPandaPanelGroup.BorderMargin" />
        /// </summary>
        BorderMarginProperty,

        /// <summary>
        /// <see cref="ZeroitPandaPanelGroup.PanelSpacing" />
        /// </summary>
        PanelSpacingProperty,

        /// <summary>
        /// <see cref="ZeroitPandaPanelGroup.PanelGradient" />
        /// </summary>
        PanelGradientProperty
    }
    #endregion ZeroitPandaPanelGroup enumerations

    /// <summary>
    /// ZeroitPandaPanelGroup provides a container for <see cref="ZeroitPandaPanel" /> controls
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    /// <remarks><para>
    ///   <c>ZeroitPandaPanelGroup</c> has the following primary properties:
    /// <list type="table"><listheader><term>Property</term><description>Purpose</description></listheader><item><term><see cref="BorderMargin" /></term><description>Controls the Left/Right/Top margins for contained <see cref="ZeroitPandaPanel" /> controls</description></item><item><term><see cref="PanelSpacing" /></term><description>Controls the Y spacing between <see cref="ZeroitPandaPanel" /> controls</description></item><item><term><see cref="PanelGradient" /></term><description>Defines the <see cref="GradientColor" /> for the background of the <c>ZeroitPandaPanelGroup</c></description></item></list></para>
    /// <para>
    ///   <c>ZeroitPandaPanelGroup</c> has the following primary events:
    /// <list type="table"><listheader><term>Event</term><description>Purpose</description></listheader><item><term><see cref="PropertyChange" /></term><description>Triggered when a primary property changes. See <see cref="ZeroitPandaPanelGroupProperties" /></description></item></list></para>
    /// <para>
    ///   <c>ZeroitPandaPanelGroup</c> has the following primary methods:
    /// <list type="table"><listheader><term>Method</term><description>Purpose</description></listheader><item><term><see cref="MovePanel" /></term><description>Change the order/position of a panel within the <c>ZeroitPandaPanelGroup</c></description></item><item><term><see cref="EnsureVisible" /></term><description>Attempt to make an <see cref="ZeroitPandaPanel" /> fully visible
    /// within the <c>ZeroitPandaPanelGroup</c></description></item></list></para></remarks>
    [ToolboxItem(true)]
    public class ZeroitPandaPanelGroup : System.Windows.Forms.Panel, System.ComponentModel.ISupportInitialize
    {
        #region class PropertyChangeEventArgs
        /// <summary>
        /// <see cref="ZeroitPandaPanelGroup.PropertyChange" /> event arguments
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class PropertyChangeEventArgs : System.EventArgs
        {
            /// <summary>
            /// The enumeration for the property that changed
            /// </summary>
            private readonly ZeroitPandaPanelGroupProperties property;

            /// <summary>
            /// Create a <c>PropertyChangeEventArgs</c>
            /// </summary>
            /// <param name="property">The enumeration for the property that changed</param>
            public PropertyChangeEventArgs(ZeroitPandaPanelGroupProperties property)
            {
                this.property = property;
            }

            /// <summary>
            /// Get the enumeration for the property that changed
            /// </summary>
            /// <value>The property.</value>
            public ZeroitPandaPanelGroupProperties Property
            {
                get
                {
                    return property;
                }
            }
        }
        #endregion class PropertyChangeEventArgs

        #region Constants
        /// <summary>
        /// Default value for <see cref="PanelGradient" />
        /// </summary>
        public static readonly GradientColor DefaultPanelGradient = new GradientColor(Color.CornflowerBlue);

        /// <summary>
        /// Default value for <see cref="BorderMargin" />
        /// </summary>
        public static readonly Size DefaultBorderMargin = new Size(8, 8);

        /// <summary>
        /// Default value for <see cref="PanelSpacing" />
        /// </summary>
        public const int DefaultSpacing = 8;
        #endregion Constants

        #region Fields
        /// <summary>
        /// Controls left/top/right spacing of <see cref="ZeroitPandaPanel" /> controls within the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        private Size borderMargin = new Size(DefaultBorderMargin.Width, DefaultBorderMargin.Height);

        /// <summary>
        /// Controls the Y spacing between <see cref="ZeroitPandaPanel" /> controls within the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        private int panelSpacing = DefaultSpacing;

        /// <summary>
        /// <see langword="true" /> when we are in InitializeComponent()
        /// </summary>
        private bool isInitializingComponent = false;

        /// <summary>
        /// The <see cref="GradientColor" /> for the background of the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        private GradientColor panelGradient = new GradientColor(DefaultPanelGradient);

        /// <summary>
        /// Collection to hold the <see cref="ZeroitPandaPanel" /> controls in the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        private ArrayList panels = new ArrayList();

        #region Events (and related)
        /// <summary>
        /// Event handler for <see cref="ZeroitPandaPanel.PanelStateChange" />
        /// </summary>
        private EventHandler xpPanelEventHandler;

        /// <summary>
        /// PropertyChange event listeners
        /// </summary>
        private EventHandler propertyChangeListeners = null;
        #endregion Events (and related)
        #endregion Fields

        #region Constructor(s)
        /// <summary>
        /// Construct an <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        public ZeroitPandaPanelGroup()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // force this on
            AutoScroll = true;
            BackColor = Color.Transparent;

            // Use these control styles for smoother drawing and transparency support
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            // single instance of ZeroitPandaPanel.PanelStateChange event handler
            xpPanelEventHandler = new EventHandler(ZeroitPandaPanelGroup_PanelStateChange);
        }
        #endregion Constructor(s)

        #region Dispose (and related)
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion Dispose (and related)

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() { }
        #endregion

        #region Properties
        /// <summary>
        /// Sets the left/right/top margins for <see cref="ZeroitPandaPanel" /> controls within the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        /// <value>The border margin.</value>
        /// <remarks>Fires a PropertyChange event w/ <see cref="ZeroitPandaPanelGroupProperties.BorderMarginProperty" /> argument</remarks>
        [Category("Appearance"),
        Description("X/Y margins for ZeroitPandaPanels in the ZeroitPandaPanelGroup")]
        public Size BorderMargin
        {
            get
            {
                return borderMargin;
            }

            set
            {
                if (!borderMargin.Equals(value))
                {
                    borderMargin = value;
                    OnPropertyChange(ZeroitPandaPanelGroupProperties.BorderMarginProperty);
                }
            }
        }

        /// <summary>
        /// Determine if this property should be serialized
        /// </summary>
        /// <returns><see langword="true" /> if the proeprty does not equal the default value</returns>
        protected bool ShouldSerializeBorderMargin()
        {
            return borderMargin != DefaultBorderMargin;
        }

        /// <summary>
        /// Reset the property to its default value
        /// </summary>
        /// <remarks>Called by the IDE designer</remarks>
        protected void ResetBorderMargin()
        {
            BorderMargin = DefaultBorderMargin;
        }

        /// <summary>
        /// Y spacing between <see cref="ZeroitPandaPanel" /> controls within the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        /// <value>The panel spacing.</value>
        /// <remarks>Default value for this property is <see cref="DefaultSpacing" /><para>Fires a PropertyChange event w/ <see cref="ZeroitPandaPanelGroupProperties.PanelSpacingProperty" /> argument</para></remarks>
        [Category("Appearance"),
        Description("Y spacing between ZeroitPandaPanels in the ZeroitPandaPanelGroup"),
        DefaultValue(DefaultSpacing)]
        public int PanelSpacing
        {
            get
            {
                return panelSpacing;
            }

            set
            {
                if (panelSpacing != value)
                {
                    panelSpacing = value;
                    OnPropertyChange(ZeroitPandaPanelGroupProperties.PanelSpacingProperty);
                }
            }
        }

        /// <summary>
        /// <see cref="GradientColor" /> used to draw the background of the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        /// <value>The panel gradient.</value>
        /// <remarks>Fires a PropertyChange event w/ <see cref="ZeroitPandaPanelGroupProperties.PanelGradientProperty" /> argument</remarks>
        [Category("Appearance"),
        Description("Gradient color for the background of the ZeroitPandaPanelGroup")]
        public GradientColor PanelGradient
        {
            get
            {
                return panelGradient;
            }

            set
            {
                if (!panelGradient.Equals(value))
                {
                    panelGradient = value;
                    OnPropertyChange(ZeroitPandaPanelGroupProperties.PanelGradientProperty);
                }
            }
        }

        /// <summary>
        /// Determine if this property should be serialized
        /// </summary>
        /// <returns><see langword="true" /> if the proeprty does not equal the default value</returns>
        protected bool ShouldSerializePanelGradient()
        {
            return panelGradient != DefaultPanelGradient;
        }

        /// <summary>
        /// Reset the property to its default value
        /// </summary>
        /// <remarks>Called by the IDE designer</remarks>
        protected void ResetPanelGradient()
        {
            PanelGradient = DefaultPanelGradient;
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Change the order/position of an <see cref="ZeroitPandaPanel" />
        /// </summary>
        /// <param name="currIndex">The current index/position</param>
        /// <param name="newIndex">The new index/position</param>
        public void MovePanel(int currIndex, int newIndex)
        {
            if ((currIndex >= 0) && (currIndex < panels.Count) && (currIndex != newIndex))
            {
                Object item = panels[currIndex];
                panels.RemoveAt(currIndex);
                panels.Insert(newIndex, item);
                UpdatePanels();
            }
        }

        /// <summary>
        /// Change the order/position of the specified <see cref="ZeroitPandaPanel" />
        /// </summary>
        /// <param name="newIndex">The new index/position</param>
        /// <param name="xpPanel">The <see cref="ZeroitPandaPanel" /> to move</param>
        public void MovePanel(int newIndex, ZeroitPandaPanel xpPanel)
        {
            int indexOf = panels.IndexOf(xpPanel);

            if ((indexOf != -1) && (indexOf != newIndex))
            {
                panels.RemoveAt(indexOf);
                panels.Insert(newIndex, xpPanel);
                UpdatePanels();
            }
        }

        /// <summary>
        /// Ensure that the specified panel is fully visible (if possible) within
        /// the <c>ZeroitPandaPanelGroup</c>
        /// </summary>
        /// <param name="xpPanel">The <see cref="ZeroitPandaPanel" /> to make visible</param>
        /// <exception cref="System.ArgumentException">The specified ZeroitPandaPanel is not a member of this ZeroitPandaPanelGroup - ZeroitPandaPanel</exception>
        /// <exception cref="ArgumentException">If the specified <see cref="ZeroitPandaPanel" /> is not
        /// a member of the <c>ZeroitPandaPanelGroup</c></exception>
        /// <remarks>If the panel is not visible it is made visible. If the bottom of the panel
        /// not visible, the group is scrolled to make it visible, otherwise if the
        /// top of the panel is not visible the scroll is adjusted to make it visible</remarks>
        public void EnsureVisible(ZeroitPandaPanel xpPanel)
        {
            if (!panels.Contains(xpPanel))
            {
                throw new ArgumentException("The specified ZeroitPandaPanel is not a member of this ZeroitPandaPanelGroup", "ZeroitPandaPanel");
            }

            if (!xpPanel.Visible)
                xpPanel.Visible = true;

            if (xpPanel.Bottom > (Height + AutoScrollPosition.Y))
            {
                AutoScrollPosition = new Point(AutoScrollPosition.X, xpPanel.Bottom - Height);
            }
            else if (xpPanel.Top < 0)
            {
                AutoScrollPosition = new Point(AutoScrollPosition.X, Math.Max(0, xpPanel.Top - 1));
            }
        }
        #endregion Methods

        #region Events
        /// <summary>
        /// Add/Remove a PropertyChange listener
        /// </summary>
        public event EventHandler PropertyChange
        {
            add
            {
                propertyChangeListeners += value;
            }

            remove
            {
                propertyChangeListeners -= value;
            }
        }
        #endregion Events

        #region Implementation
        /// <summary>
        /// React to property changes and invoke PropertyChange event to listeners
        /// </summary>
        /// <param name="property">The property that changed</param>
        protected virtual void OnPropertyChange(ZeroitPandaPanelGroupProperties property)
        {
            switch (property)
            {
                case ZeroitPandaPanelGroupProperties.BorderMarginProperty:
                case ZeroitPandaPanelGroupProperties.PanelSpacingProperty:
                    // force the position of panels to be reevaluated
                    UpdatePanels();
                    break;

                case ZeroitPandaPanelGroupProperties.PanelGradientProperty:
                    break;
            }

            if (propertyChangeListeners != null)
            {
                propertyChangeListeners(this, new PropertyChangeEventArgs(property));
            }

            Invalidate();
        }

        /// <summary>
        /// Update an individual <see cref="ZeroitPandaPanel" />
        /// </summary>
        /// <param name="panel">The panel to be updated</param>
        /// <param name="lastBottom">Bottom position of last <see cref="ZeroitPandaPanel" /> or 0 if this is the 1st panel
        /// in the <c>ZeroitPandaPanelGroup</c></param>
        private void UpdatePanel(ZeroitPandaPanel panel, int lastBottom)
        {
            if (panel.Left != BorderMargin.Width)
                panel.Left = BorderMargin.Width;

            if (lastBottom != 0)
            {
                if (panel.Top != lastBottom + PanelSpacing)
                    panel.Top = lastBottom + PanelSpacing;
            }
            else
            {
                if (panel.Top != lastBottom + BorderMargin.Height)
                    panel.Top = lastBottom + BorderMargin.Height;
            }

            if (panel.Width != this.Width - (BorderMargin.Width << 1) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0))
                panel.Width = this.Width - (BorderMargin.Width << 1) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0);
        }

        /// <summary>
        /// Flag to avoid reentrancy (just a waste of cpu cycles)
        /// </summary>
        private bool updatingPanels = false;

        /// <summary>
        /// Update the location and width of all the <see cref="ZeroitPandaPanel" /> controls
        /// in the <see cref="ZeroitPandaPanelGroup" />
        /// </summary>
        private void UpdatePanels()
        {
            int lastBottom = 0;

            if (isInitializingComponent || updatingPanels)
                return;

            updatingPanels = true;

            for (int i = 0; i < panels.Count; i++)
            {
                ZeroitPandaPanel panel = (ZeroitPandaPanel)panels[i];

                if (!panel.Visible)
                    continue;

                UpdatePanel(panel, lastBottom);
                lastBottom = panel.Top + panel.Height;
            }

            updatingPanels = false;
        }

        /// <summary>
        /// Update the location of all the <see cref="ZeroitPandaPanel" /> controls
        /// in the <see cref="ZeroitPandaPanelGroup" /> after a particular index
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <remarks>Used when a panel is collapsed or expanded to change all the
        /// subsequent panels</remarks>
        private void UpdatePanelsAfter(ZeroitPandaPanel panel)
        {
            // @@BUGFIX: 1.1
            if (!panel.Visible)
            {
                UpdatePanels();
                return;
            }

            if (isInitializingComponent || updatingPanels)
                return;

            updatingPanels = true;

            // the bottom of the specified panel plus the BorderMargin.Height (which we always need
            // to take into account)
            int lastBottom = panel.Top + panel.Height;

            // map the panel to its index in our panels collection
            int panelIndex = panels.IndexOf(panel) + 1;

            // for each following panel, relocate it
            for (int i = panelIndex; i < panels.Count; i++)
            {
                ZeroitPandaPanel nextPanel = (ZeroitPandaPanel)panels[i];

                // @@BUGFIX: 1.1
                if (!nextPanel.Visible)
                    continue;

                UpdatePanel(nextPanel, lastBottom);
                lastBottom = nextPanel.Top + nextPanel.Height;
            }

            updatingPanels = false;
        }
        #endregion Implementation

        #region ISupportInitialize Members
        /// <summary>
        /// Set flag noting that we are in InitializeComponent()
        /// </summary>
        public void BeginInit()
        {
            isInitializingComponent = true;
        }

        /// <summary>
        /// Clear flag noting that we are in InitializeComponent()
        /// </summary>
        public void EndInit()
        {
            isInitializingComponent = false;
        }
        #endregion ISupportInitialize Members

        #region Overrides
        /// <summary>
        /// Provide a version of <see cref="ScrollableControl.AutoScroll" /> that hides the base class
        /// version
        /// </summary>
        /// <value><c>true</c> if [automatic scroll]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }

            set
            {
                if (value == true)
                {
                    base.AutoScroll = value;
                }
            }
        }

        /// <summary>
        /// Provide a version of <see cref="Control.BackColor" />that hides the base class
        /// version
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                if (value == Color.Transparent)
                {
                    base.BackColor = value;
                }
            }
        }

        /// <summary>
        /// Overridden to handle the addition of <see cref="ZeroitPandaPanel" /> items
        /// specially
        /// </summary>
        /// <param name="e">ControlAdded event args</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is ZeroitPandaPanel)
            {
                e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                // during InitializeComponent panels are provided in the inverse order
                if (isInitializingComponent)
                {
                    // insert as the 1st panel
                    panels.Insert(0, (ZeroitPandaPanel)e.Control);
                }
                else
                {
                    // add to the end
                    panels.Add((ZeroitPandaPanel)e.Control);

                    // force all panels to be updated
                    UpdatePanels();
                }

                // listen for PanelStateChange events so we can make adjustments
                ((ZeroitPandaPanel)e.Control).PanelStateChange += xpPanelEventHandler;
                ((ZeroitPandaPanel)e.Control).Expanded += new EventHandler(ZeroitPandaPanelGroup_Expanded);
                ((ZeroitPandaPanel)e.Control).PropertyChange += new PanelPropertyChangeHandler(ZeroitPandaPanelGroup_PropertyChange);
            }

            e.Control.VisibleChanged += new EventHandler(Control_VisibleChanged);
        }

        /// <summary>
        /// Overridden to provide special handling for <see cref="ZeroitPandaPanel" /> controls
        /// </summary>
        /// <param name="e">ControlRemoved event args</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            if (e.Control is ZeroitPandaPanel)
            {
                // dont track the panel anymore
                panels.Remove((ZeroitPandaPanel)e.Control);
                // dont listen to events
                ((ZeroitPandaPanel)e.Control).PanelStateChange -= xpPanelEventHandler;
                ((ZeroitPandaPanel)e.Control).Expanded -= new EventHandler(ZeroitPandaPanelGroup_Expanded);
                ((ZeroitPandaPanel)e.Control).PropertyChange -= new PanelPropertyChangeHandler(ZeroitPandaPanelGroup_PropertyChange);
                // reposition everything
                UpdatePanels();
            }

            e.Control.VisibleChanged -= new EventHandler(Control_VisibleChanged);
        }

        /// <summary>
        /// Paint the background of the <c>ZeroitPandaPanelGroup</c> using the gradient color for the panel
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            // add support for transparent background by just not drawing anything
            if (!panelGradient.IsTransparent)
            {
                using (LinearGradientBrush b = new LinearGradientBrush(this.ClientRectangle, panelGradient.Start, panelGradient.End, LinearGradientMode.Vertical))
                {
                    pevent.Graphics.FillRectangle(b, pevent.ClipRectangle);
                }
            }
        }

        /// <summary>
        /// Our size changed, relocate all panels
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdatePanels();
        }
        #endregion Overrides

        #region Event Handlers
        /// <summary>
        /// <see cref="ZeroitPandaPanel.PanelStateChange" /> event handler
        /// </summary>
        /// <param name="sender">The <see cref="ZeroitPandaPanel" /> that changed</param>
        /// <param name="e"><see cref="System.EventArgs.Empty" /></param>
        private void ZeroitPandaPanelGroup_PanelStateChange(object sender, EventArgs e)
        {
            ZeroitPandaPanel panel = sender as ZeroitPandaPanel;

            // sometimes this needs to be forced
            if (panel.Width != this.Width - (BorderMargin.Width << 1) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0))
                panel.Width = this.Width - (BorderMargin.Width << 1) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0);

            UpdatePanelsAfter((ZeroitPandaPanel)sender);
        }

        /// <summary>
        /// Handle panel/control visibility changes
        /// </summary>
        /// <param name="sender">The control whose visibility changed</param>
        /// <param name="e"><see cref="System.EventArgs.Empty" /></param>
        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            AutoScrollPosition = new Point(0, 0);
            UpdatePanels();
        }

        /// <summary>
        /// Handle the <see cref="ZeroitPandaPanel.Expanded" /> event so that the entire panel can
        /// be made visible
        /// </summary>
        /// <param name="sender">The <see cref="ZeroitPandaPanel" /> that is expanded</param>
        /// <param name="e"><see cref="System.EventArgs.Empty" /></param>
        /// <remarks>Generally this event is triggered when the caption of the <see cref="ZeroitPandaPanel" />
        /// is clicked, or a programattic action triggers expansion</remarks>
        private void ZeroitPandaPanelGroup_Expanded(object sender, EventArgs e)
        {
            EnsureVisible((ZeroitPandaPanel)sender);
        }

        /// <summary>
        /// Handle the <see cref="ZeroitPandaPanel.PropertyChange" /> event
        /// </summary>
        /// <param name="xpPanel">The <see cref="ZeroitPandaPanel" /> whose property changed</param>
        /// <param name="e">instance of <see cref="ZeroitPandaPanelPropertyChangeEventArgs" /> describing the property change</param>
        /// <remarks>Currently we handle the <see cref="ZeroitPandaPanelProperties.PanelHeightProperty" /> so that we can
        /// ensure that the entire panel is visible. The <see cref="ZeroitPandaPanelProperties.PanelHeightProperty" />
        /// is only changed when a <see cref="ZeroitPandaPanel" /> resizes due to a change in the size of child
        /// controls. Typically this indicates some interest/focus on the users part, but you may want to
        /// supress this event if these changes are 'randomesque' in your application</remarks>
        private void ZeroitPandaPanelGroup_PropertyChange(ZeroitPandaPanel xpPanel, ZeroitPandaPanelPropertyChangeEventArgs e)
        {
            if (e.ZeroitPandaPanelProperty == ZeroitPandaPanelProperties.PanelHeightProperty)
            {
                EnsureVisible(xpPanel);
            }
        }
        #endregion Event Handlers
    }
    #endregion
}
