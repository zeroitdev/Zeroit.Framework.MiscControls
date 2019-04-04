// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="XPanderPanelList.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region XPanderPanelList

    #region Control
    
    #region Class XPanderPanelList
    /// <summary>
    /// Manages a related set of xpanderpanels.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ScrollableControl" />
    /// <copyright>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    /// <remarks>The ZeroitProPanelList contains ZeroitProPanels, which are represented by ZeroitProPanel
    /// objects that you can add through the XPanderPanels property.
    /// The order of ZeroitProPanel objects reflects the order the xpanderpanels appear
    /// in the ZeroitProPanelList control.</remarks>
    [Designer(typeof(XPanderPanelListDesigner)),
    DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
    public partial class ZeroitProPanelList : ScrollableControl
    {
        #region Events
        /// <summary>
        /// The PanelStyleChanged event occurs when PanelStyle flags have been changed.
        /// </summary>
        [Description("The PanelStyleChanged event occurs when PanelStyle flags have been changed.")]
        public event EventHandler<PanelStyleChangeEventArgs> PanelStyleChanged;
        /// <summary>
        /// The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.
        /// </summary>
        [Description("The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.")]
        public event EventHandler<EventArgs> CaptionStyleChanged;
        /// <summary>
        /// The ZeroitProColorSchemeChanged event occurs when ZeroitProColorScheme flags have been changed.
        /// </summary>
        [Description("The ZeroitProColorSchemeChanged event occurs when ZeroitProColorScheme flags have been changed.")]
        public event EventHandler<ZeroitProColorSchemeChangeEventArgs> ZeroitProColorSchemeChanged;
        /// <summary>
        /// Occurs when the value of the CaptionHeight property changes.
        /// </summary>
        [Description("Occurs when the value of the CaptionHeight property changes.")]
        public event EventHandler<EventArgs> CaptionHeightChanged;
        #endregion

        #region FieldsPrivate

        /// <summary>
        /// The m b show border
        /// </summary>
        private bool m_bShowBorder;
        /// <summary>
        /// The m b show gradient background
        /// </summary>
        private bool m_bShowGradientBackground;
        /// <summary>
        /// The m b show expand icon
        /// </summary>
        private bool m_bShowExpandIcon;
        /// <summary>
        /// The m b show close icon
        /// </summary>
        private bool m_bShowCloseIcon;
        /// <summary>
        /// The m i caption height
        /// </summary>
        private int m_iCaptionHeight;
        /// <summary>
        /// The m linear gradient mode
        /// </summary>
        private LinearGradientMode m_linearGradientMode;
        /// <summary>
        /// The m color gradient background
        /// </summary>
        private System.Drawing.Color m_colorGradientBackground;
        /// <summary>
        /// The m caption style
        /// </summary>
        private CaptionStyle m_captionStyle;
        /// <summary>
        /// The m e panel style
        /// </summary>
        private PanelStyle m_ePanelStyle;
        /// <summary>
        /// The m e zeroit pro color scheme
        /// </summary>
        private ZeroitProColorScheme m_eZeroitProColorScheme;
        /// <summary>
        /// The m xpander panels
        /// </summary>
        private XPanderPanelCollection m_xpanderPanels;
        /// <summary>
        /// The m panel colors
        /// </summary>
        private PanelColors m_panelColors;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the collection of xpanderpanels in this xpanderpanellist.
        /// </summary>
        /// <value>The x pander panels.</value>
        /// <example>The following code example creates a XPanderPanel and adds it to the XPanderPanels collection,
        /// <code>
        /// private void btnAddXPanderPanel_Click(object sender, EventArgs e)
        /// {
        /// if (xPanderPanelList3 != null)
        /// {
        /// // Create and initialize a XPanderPanel.
        /// XPanderPanel xpanderPanel = new XPanderPanel();
        /// xpanderPanel.Text = "new XPanderPanel";
        /// // and add it to the XPanderPanels collection
        /// xPanderPanelList3.XPanderPanels.Add(xpanderPanel);
        /// }
        /// }
        /// </code></example>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("Collection containing all the XPanderPanels for the xpanderpanellist.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(XPanderPanelCollectionEditor), typeof(UITypeEditor))]
        public XPanderPanelCollection XPanderPanels
        {
            get { return this.m_xpanderPanels; }
        }
        /// <summary>
        /// Specifies the style of the panels in this xpanderpanellist.
        /// </summary>
        /// <value>The panel style.</value>
        [Description("Specifies the style of the xpanderpanels in this xpanderpanellist."),
        DefaultValue(PanelStyle.Default),
        Category("Appearance")]
        public PanelStyle PanelStyle
        {
            get { return this.m_ePanelStyle; }
            set
            {
                if (value != this.m_ePanelStyle)
                {
                    this.m_ePanelStyle = value;
                    OnPanelStyleChanged(this, new PanelStyleChangeEventArgs(this.m_ePanelStyle));
                }
            }
        }
        /// <summary>
        /// Gets or sets the Panelcolors table.
        /// </summary>
        /// <value>The panel colors.</value>
        public PanelColors PanelColors
        {
            get { return this.m_panelColors; }
            set { this.m_panelColors = value; }
        }
        /// <summary>
        /// Specifies the ZeroitProColorScheme of the xpanderpanels in the xpanderpanellist
        /// </summary>
        /// <value>The zeroit pro color scheme.</value>
        [Description("The ZeroitProColorScheme of the xpanderpanels in the xpanderpanellist")]
        [DefaultValue(ZeroitProColorScheme.Professional)]
        [Category("Appearance")]
        public ZeroitProColorScheme ZeroitProColorScheme
        {
            get { return this.m_eZeroitProColorScheme; }
            set
            {
                if (value != this.m_eZeroitProColorScheme)
                {
                    this.m_eZeroitProColorScheme = value;
                    OnZeroitProColorSchemeChanged(this, new ZeroitProColorSchemeChangeEventArgs(this.m_eZeroitProColorScheme));
                }
            }
        }
        /// <summary>
        /// Gets or sets the style of the captionbar.
        /// </summary>
        /// <value>The caption style.</value>
        [Description("The style of the captionbar.")]
        [Category("Appearance")]
        public CaptionStyle CaptionStyle
        {
            get { return this.m_captionStyle; }
            set
            {
                this.m_captionStyle = value;
                OnCaptionStyleChanged(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// LinearGradientMode of the background in the xpanderpanellist
        /// </summary>
        /// <value>The linear gradient mode.</value>
        [Description("LinearGradientMode of the background in the xpanderpanellist"),
        DefaultValue(LinearGradientMode.Vertical),
        Category("Appearance")]
        public LinearGradientMode LinearGradientMode
        {
            get { return this.m_linearGradientMode; }
            set
            {
                if (value != this.m_linearGradientMode)
                {
                    this.m_linearGradientMode = value;
                    this.Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether a xpanderpanellist's gradient background is shown.
        /// </summary>
        /// <value><c>true</c> if [show gradient background]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets a value indicating whether a xpanderpanellist's gradient background is shown."),
        DefaultValue(false),
        Category("Appearance")]
        public bool ShowGradientBackground
        {
            get { return this.m_bShowGradientBackground; }
            set
            {
                if (value != this.m_bShowGradientBackground)
                {
                    this.m_bShowGradientBackground = value;
                    this.Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether a xpanderpanellist's border is shown
        /// </summary>
        /// <value><c>true</c> if [show border]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets a value indicating whether a xpanderpanellist's border is shown"),
        DefaultValue(true),
        Category("Appearance")]
        public bool ShowBorder
        {
            get { return this.m_bShowBorder; }
            set
            {
                if (value != this.m_bShowBorder)
                {
                    this.m_bShowBorder = value;
                    foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
                    {
                        xpanderPanel.ShowBorder = this.m_bShowBorder;
                    }
                    this.Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the expand icon of the xpanderpanels in this xpanderpanellist are visible.
        /// </summary>
        /// <value><c>true</c> if [show expand icon]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets a value indicating whether the expand icon of the xpanderpanels in this xpanderpanellist are visible."),
        DefaultValue(false),
        Category("Appearance")]
        public bool ShowExpandIcon
        {
            get { return this.m_bShowExpandIcon; }
            set
            {
                if (value != this.m_bShowExpandIcon)
                {
                    this.m_bShowExpandIcon = value;
                    foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
                    {
                        xpanderPanel.ShowExpandIcon = this.m_bShowExpandIcon;
                    }
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the close icon of the xpanderpanels in this xpanderpanellist are visible.
        /// </summary>
        /// <value><c>true</c> if [show close icon]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets a value indicating whether the close icon of the xpanderpanels in this xpanderpanellist are visible."),
        DefaultValue(false),
        Category("Appearance")]
        public bool ShowCloseIcon
        {
            get { return this.m_bShowCloseIcon; }
            set
            {
                if (value != this.m_bShowCloseIcon)
                {
                    this.m_bShowCloseIcon = value;
                    foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
                    {
                        xpanderPanel.ShowCloseIcon = this.m_bShowCloseIcon;
                    }
                }
            }
        }
        /// <summary>
        /// Gradientcolor background in this xpanderpanellist
        /// </summary>
        /// <value>The gradient background.</value>
        [Description("Gradientcolor background in this xpanderpanellist"),
        DefaultValue(false),
        Category("Appearance")]
        public System.Drawing.Color GradientBackground
        {
            get { return this.m_colorGradientBackground; }
            set
            {
                if (value != this.m_colorGradientBackground)
                {
                    this.m_colorGradientBackground = value;
                    this.Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets the height of the XpanderPanels in this XPanderPanelList.
        /// </summary>
        /// <value>The height of the caption.</value>
        /// <exception cref="System.InvalidOperationException"></exception>
        [Description("Gets or sets the height of the XpanderPanels in this XPanderPanelList. "),
        DefaultValue(25),
        Category("Appearance")]
        public int CaptionHeight
        {
            get { return m_iCaptionHeight; }
            set
            {
                if (value < Constants.CaptionMinHeight)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        System.Globalization.CultureInfo.CurrentUICulture,
                        Properties.Resources.IDS_InvalidOperationExceptionInteger, value, "CaptionHeight", Constants.CaptionMinHeight));
                }
                this.m_iCaptionHeight = value;
                OnCaptionHeightChanged(this, EventArgs.Empty);
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the XPanderPanelList class.
        /// </summary>
        public ZeroitProPanelList()
        {
            // Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, false);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            this.m_xpanderPanels = new XPanderPanelCollection(this);

            this.ShowBorder = true;
            this.PanelStyle = PanelStyle.Default;
            this.LinearGradientMode = LinearGradientMode.Vertical;
            this.CaptionHeight = 25;
        }
        /// <summary>
        /// Expands the specified XPanderPanel
        /// </summary>
        /// <param name="panel">The XPanderPanel to expand</param>
        /// <exception cref="System.ArgumentNullException">panel</exception>
        /// <example>
        ///   <code>
        /// private void btnExpandXPander_Click(object sender, EventArgs e)
        /// {
        /// // xPanderPanel10 is not null
        /// if (xPanderPanel10 != null)
        /// {
        /// XPanderPanelList panelList = xPanderPanel10.Parent as XPanderPanelList;
        /// // and it's parent panelList is not null
        /// if (panelList != null)
        /// {
        /// // expands xPanderPanel10 in it's panelList.
        /// panelList.Expand(xPanderPanel10);
        /// }
        /// }
        /// }
        /// </code>
        /// </example>
        public void Expand(BasePanel panel)
        {
            if (panel == null)
            {
                throw new ArgumentNullException("panel",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentException,
                    "panel"));
            }

            XPanderPanel xpanderPanel = panel as XPanderPanel;
            if (xpanderPanel != null)
            {
                foreach (XPanderPanel tmpXPanderPanel in this.m_xpanderPanels)
                {
                    if (tmpXPanderPanel.Equals(xpanderPanel) == false)
                    {
                        tmpXPanderPanel.Expand = false;
                    }
                }
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel)["Expand"];
                if (propertyDescriptor != null)
                {
                    propertyDescriptor.SetValue(xpanderPanel, true);
                }
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Paints the background of the xpanderpanellist.
        /// </summary>
        /// <param name="pevent">A PaintEventArgs that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (this.m_bShowGradientBackground == true)
            {
                Rectangle rectangle = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
                using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                    rectangle,
                    this.BackColor,
                    this.GradientBackground,
                    this.LinearGradientMode))
                {
                    pevent.Graphics.FillRectangle(linearGradientBrush, rectangle);
                }
            }
        }
        /// <summary>
        /// Raises the ControlAdded event.
        /// </summary>
        /// <param name="e">A ControlEventArgs that contains the event data.</param>
        /// <exception cref="System.InvalidOperationException">Can only add XPanderPanel</exception>
        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlAdded(e);
            XPanderPanel xpanderPanel = e.Control as XPanderPanel;
            if (xpanderPanel != null)
            {
                if (xpanderPanel.Expand == true)
                {
                    foreach (XPanderPanel tmpXPanderPanel in this.XPanderPanels)
                    {
                        if (tmpXPanderPanel != xpanderPanel)
                        {
                            tmpXPanderPanel.Expand = false;
                            tmpXPanderPanel.Height = xpanderPanel.CaptionHeight;
                        }
                    }
                }
                xpanderPanel.Parent = this;
                xpanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                xpanderPanel.Left = this.Padding.Left;
                xpanderPanel.Width = this.ClientRectangle.Width
                    - this.Padding.Left
                    - this.Padding.Right;
                xpanderPanel.PanelStyle = this.PanelStyle;
                xpanderPanel.ZeroitProColorScheme = this.ZeroitProColorScheme;
                if (this.PanelColors != null)
                {
                    xpanderPanel.SetPanelProperties(this.PanelColors);
                }
                xpanderPanel.ShowBorder = this.ShowBorder;
                xpanderPanel.ShowCloseIcon = this.m_bShowCloseIcon;
                xpanderPanel.ShowExpandIcon = this.m_bShowExpandIcon;
                xpanderPanel.CaptionStyle = this.m_captionStyle;
                xpanderPanel.Top = this.GetTopPosition();
                xpanderPanel.PanelStyleChanged += new EventHandler<PanelStyleChangeEventArgs>(XpanderPanelPanelStyleChanged);
                xpanderPanel.ExpandClick += new EventHandler<EventArgs>(this.XPanderPanelExpandClick);
                xpanderPanel.CloseClick += new EventHandler<EventArgs>(this.XPanderPanelCloseClick);
            }
            else
            {
                throw new InvalidOperationException("Can only add XPanderPanel");
            }
        }
        /// <summary>
        /// Raises the ControlRemoved event.
        /// </summary>
        /// <param name="e">A ControlEventArgs that contains the event data.</param>
        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            XPanderPanel xpanderPanel =
                e.Control as XPanderPanel;

            if (xpanderPanel != null)
            {
                xpanderPanel.PanelStyleChanged -= new EventHandler<PanelStyleChangeEventArgs>(XpanderPanelPanelStyleChanged);
                xpanderPanel.ExpandClick -= new EventHandler<EventArgs>(this.XPanderPanelExpandClick);
                xpanderPanel.CloseClick -= new EventHandler<EventArgs>(this.XPanderPanelCloseClick);
            }
        }
        /// <summary>
        /// Raises the Resize event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            int iXPanderPanelCaptionHeight = 0;

            if (this.m_xpanderPanels != null)
            {
                foreach (XPanderPanel xpanderPanel in this.m_xpanderPanels)
                {
                    xpanderPanel.Width = this.ClientRectangle.Width
                        - this.Padding.Left
                        - this.Padding.Right;
                    if (xpanderPanel.Visible == false)
                    {
                        iXPanderPanelCaptionHeight -= xpanderPanel.CaptionHeight;
                    }
                    iXPanderPanelCaptionHeight += xpanderPanel.CaptionHeight;
                }

                foreach (XPanderPanel xpanderPanel in this.m_xpanderPanels)
                {
                    if (xpanderPanel.Expand == true)
                    {
                        xpanderPanel.Height =
                            this.Height
                            - iXPanderPanelCaptionHeight
                            - this.Padding.Top
                            - this.Padding.Bottom
                            + xpanderPanel.CaptionHeight;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Raises the PanelStyle changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A PanelStyleChangeEventArgs that contains the event data.</param>
        protected virtual void OnPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
        {
            PanelStyle panelStyle = e.PanelStyle;
            this.Padding = new System.Windows.Forms.Padding(0);

            foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
            {
                PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(xpanderPanel);
                if (propertyDescriptorCollection.Count > 0)
                {
                    PropertyDescriptor propertyDescriptorPanelStyle = propertyDescriptorCollection["PanelStyle"];
                    if (propertyDescriptorPanelStyle != null)
                    {
                        propertyDescriptorPanelStyle.SetValue(xpanderPanel, panelStyle);
                    }
                    PropertyDescriptor propertyDescriptorLeft = propertyDescriptorCollection["Left"];
                    if (propertyDescriptorLeft != null)
                    {
                        propertyDescriptorLeft.SetValue(xpanderPanel, this.Padding.Left);
                    }
                    PropertyDescriptor propertyDescriptorWidth = propertyDescriptorCollection["Width"];
                    if (propertyDescriptorWidth != null)
                    {
                        propertyDescriptorWidth.SetValue(
                            xpanderPanel,
                            this.ClientRectangle.Width
                            - this.Padding.Left
                            - this.Padding.Right);
                    }

                }
            }
            if (this.PanelStyleChanged != null)
            {
                this.PanelStyleChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the ZeroitProColorScheme changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnZeroitProColorSchemeChanged(object sender, ZeroitProColorSchemeChangeEventArgs e)
        {
            ZeroitProColorScheme eZeroitProColorScheme = e.ZeroitProColorSchema;
            foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
            {
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel)["ZeroitProColorScheme"];
                if (propertyDescriptor != null)
                {
                    propertyDescriptor.SetValue(xpanderPanel, eZeroitProColorScheme);
                }
            }
            if (this.ZeroitProColorSchemeChanged != null)
            {
                this.ZeroitProColorSchemeChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the CaptionHeight changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnCaptionHeightChanged(object sender, EventArgs e)
        {
            foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
            {
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel)["CaptionHeight"];
                if (propertyDescriptor != null)
                {
                    propertyDescriptor.SetValue(xpanderPanel, this.m_iCaptionHeight);
                }
            }
            if (this.CaptionHeightChanged != null)
            {
                this.CaptionHeightChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the CaptionStyleChanged changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnCaptionStyleChanged(object sender, EventArgs e)
        {
            foreach (XPanderPanel xpanderPanel in this.XPanderPanels)
            {
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel)["CaptionStyle"];
                if (propertyDescriptor != null)
                {
                    propertyDescriptor.SetValue(xpanderPanel, this.m_captionStyle);
                }
            }
            if (this.CaptionStyleChanged != null)
            {
                this.CaptionStyleChanged(sender, e);
            }
        }
        #endregion

        #region MethodsPrivate

        /// <summary>
        /// xes the pander panel expand click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void XPanderPanelExpandClick(object sender, EventArgs e)
        {
            XPanderPanel xpanderPanel = sender as XPanderPanel;
            if (xpanderPanel != null)
            {
                this.Expand(xpanderPanel);
            }
        }

        /// <summary>
        /// xes the pander panel close click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void XPanderPanelCloseClick(object sender, EventArgs e)
        {
            XPanderPanel xpanderPanel = sender as XPanderPanel;
            if (xpanderPanel != null)
            {
                this.Controls.Remove(xpanderPanel);
            }
        }

        /// <summary>
        /// Xpanders the panel panel style changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PanelStyleChangeEventArgs"/> instance containing the event data.</param>
        private void XpanderPanelPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
        {
            PanelStyle panelStyle = e.PanelStyle;
            if (panelStyle != this.m_ePanelStyle)
            {
                this.PanelStyle = panelStyle;
            }
        }

        /// <summary>
        /// Gets the top position.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetTopPosition()
        {
            int iTopPosition = this.Padding.Top;
            int iNextTopPosition = 0;

            //The next top position is the highest top value + that controls height, with a
            //little vertical spacing thrown in for good measure
            IEnumerator enumerator = this.XPanderPanels.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XPanderPanel xpanderPanel = (XPanderPanel)enumerator.Current;

                if (xpanderPanel.Visible == true)
                {
                    if (iNextTopPosition == this.Padding.Top)
                    {
                        iTopPosition = this.Padding.Top;
                    }
                    else
                    {
                        iTopPosition = iNextTopPosition;
                    }
                    iNextTopPosition = iTopPosition + xpanderPanel.Height;
                }
            }
            return iTopPosition;
        }
        #endregion
    }

    #endregion

    #region Class XPanderPanelListDesigner

    /// <summary>
    /// Extends the design mode behavior of a XPanderPanelList control that supports nested controls.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    internal class XPanderPanelListDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region FieldsPrivate

        /// <summary>
        /// The m border pen
        /// </summary>
        private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));
        /// <summary>
        /// The m xpander panel list
        /// </summary>
        private ZeroitProPanelList m_xpanderPanelList;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// nitializes a new instance of the XPanderPanelListDesigner class.
        /// </summary>
        public XPanderPanelListDesigner()
        {
            this.m_borderPen.DashStyle = DashStyle.Dash;
        }
        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The IComponent to associate with the designer.</param>
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.m_xpanderPanelList = (ZeroitProPanelList)this.Control;
            //Disable the autoscroll feature for the control during design time.  The control
            //itself sets this property to true when it initializes at run time.  Trying to position
            //controls in this control with the autoscroll property set to True is problematic.
            this.m_xpanderPanelList.AutoScroll = false;
        }
        /// <summary>
        /// This member overrides ParentControlDesigner.ActionLists
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create action list collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Add custom action list
                actionLists.Add(new XPanderPanelListDesignerActionList(this.Component));

                // Return to the designer action service
                return actionLists;
            }
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Releases the unmanaged resources used by the XPanderPanelDesigner,
        /// and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.m_borderPen != null)
                    {
                        this.m_borderPen.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        /// <summary>
        /// Receives a call when the control that the designer is managing has painted its surface so the designer can
        /// paint any additional adornments on top of the xpanderpanel.
        /// </summary>
        /// <param name="e">A PaintEventArgs the designer can use to draw on the xpanderpanel.</param>
        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
            e.Graphics.DrawRectangle(this.m_borderPen, 0, 0, this.m_xpanderPanelList.Width - 2, this.m_xpanderPanelList.Height - 2);
        }

        #endregion
    }

    #endregion

    #region Class XPanderPanelListDesignerActionList

    /// <summary>
    /// Provides the class for types that define a list of items used to create a smart tag panel for the XPanderPanelList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class XPanderPanelListDesignerActionList : DesignerActionList
    {
        #region Properties

        /// <summary>
        /// Gets a collecion of XPanderPanel objects
        /// </summary>
        /// <value>The x pander panels.</value>
        [Editor(typeof(XPanderPanelCollectionEditor), typeof(UITypeEditor))]
        public XPanderPanelCollection XPanderPanels
        {
            get { return this.ZeroitProPanelList.XPanderPanels; }
        }
        /// <summary>
        /// Gets or sets the style of the panel.
        /// </summary>
        /// <value>The panel style.</value>
        public PanelStyle PanelStyle
        {
            get { return this.ZeroitProPanelList.PanelStyle; }
            set { SetProperty("PanelStyle", value); }
        }
        /// <summary>
        /// Gets or sets the color schema which is used for the panel.
        /// </summary>
        /// <value>The zeroit pro color scheme.</value>
        public ZeroitProColorScheme ZeroitProColorScheme
        {
            get { return this.ZeroitProPanelList.ZeroitProColorScheme; }
            set { SetProperty("ZeroitProColorScheme", value); }
        }
        /// <summary>
        /// Gets or sets the style of the caption (not for PanelStyle.Aqua).
        /// </summary>
        /// <value>The caption style.</value>
        public CaptionStyle CaptionStyle
        {
            get { return this.ZeroitProPanelList.CaptionStyle; }
            set { SetProperty("CaptionStyle", value); }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the control shows a border.
        /// </summary>
        /// <value><c>true</c> if [show border]; otherwise, <c>false</c>.</value>
        public bool ShowBorder
        {
            get { return this.ZeroitProPanelList.ShowBorder; }
            set { SetProperty("ShowBorder", value); }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the expand icon is visible
        /// </summary>
        /// <value><c>true</c> if [show expand icon]; otherwise, <c>false</c>.</value>
        public bool ShowExpandIcon
        {
            get { return this.ZeroitProPanelList.ShowExpandIcon; }
            set { SetProperty("ShowExpandIcon", value); }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the close icon is visible
        /// </summary>
        /// <value><c>true</c> if [show close icon]; otherwise, <c>false</c>.</value>
        public bool ShowCloseIcon
        {
            get { return this.ZeroitProPanelList.ShowCloseIcon; }
            set { SetProperty("ShowCloseIcon", value); }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the XPanderPanelListDesignerActionList class.
        /// </summary>
        /// <param name="component">A component related to the DesignerActionList.</param>
        public XPanderPanelListDesignerActionList(System.ComponentModel.IComponent component)
            : base(component)
        {
            // Automatically display smart tag panel when
            // design-time component is dropped onto the
            // Windows Forms Designer
            base.AutoShow = true;
        }
        /// <summary>
        /// Returns the collection of DesignerActionItem objects contained in the list.
        /// </summary>
        /// <returns>A DesignerActionItem array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create list to store designer action items
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(
              new DesignerActionMethodItem(
                this,
                "ToggleDockStyle",
                GetDockStyleText(),
                "Design",
                "Dock or undock this control in it's parent container.",
                true));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ShowBorder",
                "Show Border",
                GetCategory(this.ZeroitProPanelList, "ShowBorder")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ShowExpandIcon",
                "Show ExpandIcon",
                GetCategory(this.ZeroitProPanelList, "ShowExpandIcon")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ShowCloseIcon",
                "Show CloseIcon",
                GetCategory(this.ZeroitProPanelList, "ShowCloseIcon")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "PanelStyle",
                "Select PanelStyle",
                GetCategory(this.ZeroitProPanelList, "PanelStyle")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ZeroitProColorScheme",
                "Select ZeroitProColorScheme",
                GetCategory(this.ZeroitProPanelList, "ZeroitProColorScheme")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "CaptionStyle",
                "Select CaptionStyle",
                GetCategory(this.ZeroitProPanelList, "CaptionStyle")));

            actionItems.Add(
              new DesignerActionPropertyItem(
                "XPanderPanels",
                "Edit XPanderPanels",
                GetCategory(this.ZeroitProPanelList, "XPanderPanels")));

            return actionItems;
        }
        /// <summary>
        /// Dock/Undock designer action method implementation
        /// </summary>
        public void ToggleDockStyle()
        {
            // Toggle ClockControl's Dock property
            if (this.ZeroitProPanelList.Dock != DockStyle.Fill)
            {
                SetProperty("Dock", DockStyle.Fill);
            }
            else
            {
                SetProperty("Dock", DockStyle.None);
            }
        }

        #endregion

        #region MethodsPrivate
        /// <summary>
        /// Helper method that returns an appropriate display name for the Dock/Undock property,
        /// based on the ClockControl's current Dock property value
        /// </summary>
        /// <returns>the string to display</returns>
        private string GetDockStyleText()
        {
            if (this.ZeroitProPanelList.Dock == DockStyle.Fill)
            {
                return "Undock in parent container";
            }
            else
            {
                return "Dock in parent container";
            }
        }

        /// <summary>
        /// Gets the zeroit pro panel list.
        /// </summary>
        /// <value>The zeroit pro panel list.</value>
        private ZeroitProPanelList ZeroitProPanelList
        {
            get { return (ZeroitProPanelList)this.Component; }
        }

        // Helper method to safely set a component’s property
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        private void SetProperty(string propertyName, object value)
        {
            // Get property
            System.ComponentModel.PropertyDescriptor property
                = System.ComponentModel.TypeDescriptor.GetProperties(this.ZeroitProPanelList)[propertyName];
            // Set property value
            property.SetValue(this.ZeroitProPanelList, value);
        }
        // Helper method to return the Category string from a
        // CategoryAttribute assigned to a property exposed by 
        //the specified object
        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.String.</returns>
        private static string GetCategory(object source, string propertyName)
        {
            System.Reflection.PropertyInfo property = source.GetType().GetProperty(propertyName);
            CategoryAttribute attribute = (CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), false)[0];
            if (attribute == null)
            {
                return null;
            }
            else
            {
                return attribute.Category;
            }
        }

        #endregion
    }

    #endregion

    #region Class XPanderPanelCollection

    /// <summary>
    /// Contains a collection of XPanderPanel objects.
    /// </summary>
    /// <seealso cref="System.Collections.IList" />
    /// <seealso cref="System.Collections.ICollection" />
    /// <seealso cref="System.Collections.IEnumerable" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface")]
    public sealed class XPanderPanelCollection : IList, ICollection, IEnumerable
    {

        #region FieldsPrivate

        /// <summary>
        /// The m xpander panel list
        /// </summary>
        private ZeroitProPanelList m_xpanderPanelList;
        /// <summary>
        /// The m control collection
        /// </summary>
        private Control.ControlCollection m_controlCollection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="XPanderPanelCollection"/> class.
        /// </summary>
        /// <param name="xpanderPanelList">The xpander panel list.</param>
        internal XPanderPanelCollection(ZeroitProPanelList xpanderPanelList)
        {
            this.m_xpanderPanelList = xpanderPanelList;
            this.m_controlCollection = this.m_xpanderPanelList.Controls;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a XPanderPanel in the collection.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The xPanderPanel at the specified index.</returns>
        public XPanderPanel this[int index]
        {
            get { return (XPanderPanel)this.m_controlCollection[index] as XPanderPanel; }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Determines whether the XPanderPanelCollection contains a specific XPanderPanel
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to locate in the XPanderPanelCollection</param>
        /// <returns>true if the XPanderPanelCollection contains the specified value; otherwise, false.</returns>
        public bool Contains(XPanderPanel xpanderPanel)
        {
            return this.m_controlCollection.Contains(xpanderPanel);
        }
        /// <summary>
        /// Adds a XPanderPanel to the collection.
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to add.</param>
        public void Add(XPanderPanel xpanderPanel)
        {
            this.m_controlCollection.Add(xpanderPanel);
            this.m_xpanderPanelList.Invalidate();

        }
        /// <summary>
        /// Removes the first occurrence of a specific XPanderPanel from the XPanderPanelCollection
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to remove from the XPanderPanelCollection</param>
        public void Remove(XPanderPanel xpanderPanel)
        {
            this.m_controlCollection.Remove(xpanderPanel);
        }
        /// <summary>
        /// Removes all the XPanderPanels from the collection.
        /// </summary>
        public void Clear()
        {
            this.m_controlCollection.Clear();
        }
        /// <summary>
        /// Gets the number of XPanderPanels in the collection.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return this.m_controlCollection.Count; }
        }
        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return this.m_controlCollection.IsReadOnly; }
        }
        /// <summary>
        /// Returns an enumeration of all the XPanderPanels in the collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return this.m_controlCollection.GetEnumerator();
        }
        /// <summary>
        /// Returns the index of the specified XPanderPanel in the collection.
        /// </summary>
        /// <param name="xpanderPanel">The xpanderPanel to find the index of.</param>
        /// <returns>The index of the xpanderPanel, or -1 if the xpanderPanel is not in the <see ref="ControlCollection">ControlCollection</see> instance.</returns>
        public int IndexOf(XPanderPanel xpanderPanel)
        {
            return this.m_controlCollection.IndexOf(xpanderPanel);
        }
        /// <summary>
        /// Removes the XPanderPanel at the specified index from the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the xpanderPanel to remove from the ControlCollection instance.</param>
        public void RemoveAt(int index)
        {
            this.m_controlCollection.RemoveAt(index);
        }
        /// <summary>
        /// Inserts an XPanderPanel to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="xpanderPanel">The XPanderPanel to insert into the Collection.</param>
        public void Insert(int index, XPanderPanel xpanderPanel)
        {
            ((IList)this).Insert(index, (object)xpanderPanel);
        }
        /// <summary>
        /// Copies the elements of the collection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="xpanderPanels">The one-dimensional Array that is the destination of the elements copied from ICollection.
        /// The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(XPanderPanel[] xpanderPanels, int index)
        {
            this.m_controlCollection.CopyTo(xpanderPanels, index);
        }

        #endregion

        #region Interface ICollection
        /// <summary>
        /// Gets the number of elements contained in the ICollection.
        /// </summary>
        /// <value>The count.</value>
        int ICollection.Count
        {
            get { return this.Count; }
        }
        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized
        /// </summary>
        /// <value><c>true</c> if this instance is synchronized; otherwise, <c>false</c>.</value>
		bool ICollection.IsSynchronized
        {
            get { return ((ICollection)this.m_controlCollection).IsSynchronized; }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the ICollection.
        /// </summary>
        /// <value>The synchronize root.</value>
		object ICollection.SyncRoot
        {
            get { return ((ICollection)this.m_controlCollection).SyncRoot; }
        }
        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
		void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)this.m_controlCollection).CopyTo(array, index);
        }

        #endregion

        #region Interface IList
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The element at the specified index.</returns>
        object IList.this[int index]
        {
            get { return this.m_controlCollection[index]; }
            set { }
        }
        /// <summary>
        /// Adds an item to the IList.
        /// </summary>
        /// <param name="value">The Object to add to the IList.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        /// <exception cref="System.ArgumentException"></exception>
		int IList.Add(object value)
        {
            XPanderPanel xpanderPanel = value as XPanderPanel;
            if (xpanderPanel == null)
            {
                throw new ArgumentException(string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    Properties.Resources.IDS_ArgumentException,
                    typeof(XPanderPanel).Name));
            }
            this.Add(xpanderPanel);
            return this.IndexOf(xpanderPanel);
        }
        /// <summary>
        /// Determines whether the IList contains a specific value.
        /// </summary>
        /// <param name="value">The Object to locate in the IList.</param>
        /// <returns>true if the Object is found in the IList; otherwise, false.</returns>
		bool IList.Contains(object value)
        {
            return this.Contains(value as XPanderPanel);
        }
        /// <summary>
        /// Determines the index of a specific item in the IList.
        /// </summary>
        /// <param name="value">The Object to locate in the IList.</param>
        /// <returns>The index of value if found in the list; otherwise, -1.</returns>
		int IList.IndexOf(object value)
        {
            return this.IndexOf(value as XPanderPanel);
        }
        /// <summary>
        /// Inserts an item to the IList at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to insert.</param>
        /// <param name="value">The Object to insert into the IList.</param>
        /// <exception cref="System.ArgumentException"></exception>
		void IList.Insert(int index, object value)
        {
            if ((value is XPanderPanel) == false)
            {
                throw new ArgumentException(
                    string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    Properties.Resources.IDS_ArgumentException,
                    typeof(XPanderPanel).Name));
            }
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the IList.
        /// </summary>
        /// <param name="value">The Object to remove from the IList.</param>
		void IList.Remove(object value)
        {
            this.Remove(value as XPanderPanel);
        }
        /// <summary>
        /// Removes the IList item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
		void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }
        /// <summary>
        /// Gets a value indicating whether the IList is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
		bool IList.IsReadOnly
        {
            get { return this.IsReadOnly; }
        }
        /// <summary>
        /// Gets a value indicating whether the IList has a fixed size.
        /// </summary>
        /// <value><c>true</c> if this instance is fixed size; otherwise, <c>false</c>.</value>
		bool IList.IsFixedSize
        {
            get { return ((IList)this.m_controlCollection).IsFixedSize; }
        }

        #endregion
    }

    #endregion

    #region Class XPanderPanelCollectionEditor
    /// <summary>
    /// Provides a user interface that can edit most types of collections at design time.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
    internal class XPanderPanelCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        /// <summary>
        /// The m collection form
        /// </summary>
        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the XPanderPanelCollectionEditor class
        /// using the specified collection type.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
        public XPanderPanelCollectionEditor(Type type)
            : base(type)
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>A CollectionEditor.CollectionForm to provide as the user interface for editing the collection.</returns>
        protected override CollectionForm CreateCollectionForm()
        {
            this.m_collectionForm = base.CreateCollectionForm();
            return this.m_collectionForm;
        }
        /// <summary>
        /// Creates a new instance of the specified collection item type.
        /// </summary>
        /// <param name="ItemType">The type of item to create.</param>
        /// <returns>A new instance of the specified object.</returns>
        protected override Object CreateInstance(Type ItemType)
        {
            /* you can create the new instance yourself 
                 * ComplexItem ci=new ComplexItem(2,"ComplexItem",null);
                 * we know for sure that the itemType it will always be ComplexItem
                 *but this time let it to do the job... 
                 */

            XPanderPanel xpanderPanel =
                (XPanderPanel)base.CreateInstance(ItemType);

            if (this.Context.Instance != null)
            {
                xpanderPanel.Expand = true;
            }
            return xpanderPanel;
        }

        #endregion
    }

    #endregion


    #endregion

    #region Designer Generated Code

    partial class ZeroitProPanelList
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
            components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(200, 100);
            this.Name = "xPanderPanelList";
        }

        #endregion
    }

    #endregion

    #endregion
}
