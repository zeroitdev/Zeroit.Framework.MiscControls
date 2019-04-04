// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ButtonBarDesigner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Serialization;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitToxicButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    internal class ZeroitToxicButtonDesigner : ControlDesigner
    {
        /// <summary>
        /// The action list collection
        /// </summary>
        private readonly DesignerActionListCollection actionListCollection = new DesignerActionListCollection();
        /// <summary>
        /// The button bar
        /// </summary>
        private ZeroitToxicButton buttonBar;
        /// <summary>
        /// The designer action list
        /// </summary>
        private ZeroitToxicButtonDesignerActionList designerActionList;

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get { return actionListCollection; }
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>The service.</value>
        private DesignerActionUIService Service
        {
            get { return GetService(typeof (DesignerActionUIService)) as DesignerActionUIService; }
        }

        /// <summary>
        /// Indicates whether a mouse click at the specified point should be handled by the control.
        /// </summary>
        /// <param name="point">A <see cref="T:System.Drawing.Point" /> indicating the position at which the mouse was clicked, in screen coordinates.</param>
        /// <returns>true if a click at the specified point is to be handled by the control; otherwise, false.</returns>
        protected override bool GetHitTest(Point point)
        {
            var test = buttonBar.HitTest(buttonBar.PointToClient(point));
            return test.ButtonIndex >= 0;
        }

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            buttonBar = (ZeroitToxicButton) component;
            buttonBar.ThemeProperty.ThemeChanged += delegate { RefreshComponent(); };
            buttonBar.SelectionChanged += delegate { RefreshComponent(); };
            buttonBar.ItemsChanging += delegate { RefreshComponent(); };
            buttonBar.ItemsClearing += delegate { RefreshComponent(); };
            buttonBar.ItemsInserting += delegate { RefreshComponent(); };
            buttonBar.ItemsRemoving += delegate { RefreshComponent(); };
            buttonBar.ItemClick += delegate { RefreshComponent(); };
            buttonBar.Appearance.Bar.AppearanceChanged += delegate { RefreshComponent(); };
            buttonBar.Appearance.Item.AppearanceChanged += delegate { RefreshComponent(); };
            designerActionList = new ZeroitToxicButtonDesignerActionList(buttonBar);
            actionListCollection.Add(designerActionList);
        }

        /// <summary>
        /// Refreshes the component.
        /// </summary>
        internal void RefreshComponent()
        {
            if (Service != null)
                Service.Refresh(Control);
        }
    }

    /// <summary>
    /// Class ZeroitToxicButtonDesignerActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    internal class ZeroitToxicButtonDesignerActionList : DesignerActionList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToxicButtonDesignerActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitToxicButtonDesignerActionList(IComponent component) : base(component)
        {
        }

        /// <summary>
        /// Gets the zeroit toxic button.
        /// </summary>
        /// <value>The zeroit toxic button.</value>
        protected virtual ZeroitToxicButton ZeroitToxicButton
        {
            get { return (ZeroitToxicButton) Component; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the smart tag panel should automatically be displayed when it is created.
        /// </summary>
        /// <value><c>true</c> if [automatic show]; otherwise, <c>false</c>.</value>
        public override bool AutoShow
        {
            get { return true; }
            set { base.AutoShow = value; }
        }

        /// <summary>
        /// Gets the designer action UI service.
        /// </summary>
        /// <value>The designer action UI service.</value>
        private DesignerActionUIService DesignerActionUIService
        {
            get { return GetService(typeof (DesignerActionUIService)) as DesignerActionUIService; }
        }

        /// <summary>
        /// Gets the edit items.
        /// </summary>
        /// <value>The edit items.</value>
        public GenericCollection<BarItem> EditItems
        {
            get { return ZeroitToxicButton.Items; }
        }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        public ColorScheme Theme
        {
            get { return ZeroitToxicButton.ThemeProperty.ColorScheme; }
            set
            {
                if (ZeroitToxicButton.ThemeProperty.ColorScheme == value) return;
                ZeroitToxicButton.ThemeProperty.ColorScheme = value;
                ZeroitToxicButton.ThemeProperty.ColorScheme = value;
                ZeroitToxicButton.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the button.
        /// </summary>
        /// <value>The width of the button.</value>
        public int ButtonWidth
        {
            get { return ZeroitToxicButton.ButtonWidth; }
            set
            {
                if (ZeroitToxicButton.ButtonWidth == value) return;
                ZeroitToxicButton.ButtonWidth = value;
                ZeroitToxicButton.Invalidate();
            }
        }

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Design", "Appearance"));
            items.Add(new DesignerActionPropertyItem("Theme", "Theme", "Appearance"));
            if (!ZeroitToxicButton.ShowBorders)
                items.Add(new DesignerActionMethodItem(this, "ShowBorders", "Show Borders", "Appearance", true));
            else
                items.Add(new DesignerActionMethodItem(this, "ShowBorders", "Hide Borders", "Appearance", true));

            items.Add(new DesignerActionPropertyItem("ButtonWidth", "ButtonWidth", "Appearance"));
            items.Add(new DesignerActionMethodItem(this, "ApplyTemplate", "Apply Template", "Appearance", true));

            items.Add(new DesignerActionHeaderItem("Collection", "Collection"));
            items.Add(new DesignerActionPropertyItem("EditItems", "Edit Buttons", "Collection"));
            if (ZeroitToxicButton.Items.Count > 0)
                items.Add(new DesignerActionMethodItem(this, "ClearButtons", "Clear Buttons", "Collection", true));
            items.Add(new DesignerActionMethodItem(this, "AddButton", "Add Button", "Collection", true));
            if (ZeroitToxicButton.Items.Count > 0)
                items.Add(new DesignerActionMethodItem(this, "DeleteButton", "Delete Button", "Collection", true));

            items.Add(new DesignerActionHeaderItem("Export", "Export"));
            items.Add(new DesignerActionMethodItem(this, "Export", "Save Appearance", "Export", true));
            items.Add(new DesignerActionMethodItem(this, "Import", "Load Appearance", "Export", true));

            return items;
        }

        /// <summary>
        /// Refreshes the component.
        /// </summary>
        internal void RefreshComponent()
        {
            if (DesignerActionUIService != null)
                DesignerActionUIService.Refresh(ZeroitToxicButton);
        }

        /// <summary>
        /// Shows the borders.
        /// </summary>
        protected virtual void ShowBorders()
        {
            ZeroitToxicButton.ShowBorders = !ZeroitToxicButton.ShowBorders;
            ZeroitToxicButton.Invalidate();
            RefreshComponent();
        }

        /// <summary>
        /// Clears the buttons.
        /// </summary>
        protected virtual void ClearButtons()
        {
            ZeroitToxicButton.Items.Clear();
            ZeroitToxicButton.RefreshControl();
            ZeroitToxicButton.Invalidate();
            RefreshComponent();
        }

        /// <summary>
        /// Applies the template.
        /// </summary>
        protected virtual void ApplyTemplate()
        {
            var editor = new AppearanceEditor.AppearanceEditorUI(ZeroitToxicButton);
            editor.ShowDialog();
        }

        /// <summary>
        /// Adds the button.
        /// </summary>
        protected virtual void AddButton()
        {
            var item = new BarItem(ZeroitToxicButton);
            ZeroitToxicButton.Items.Add(item);
            ZeroitToxicButton.RefreshControl();
            ZeroitToxicButton.Invalidate();
            RefreshComponent();
        }

        /// <summary>
        /// Deletes the button.
        /// </summary>
        protected virtual void DeleteButton()
        {
            if (ZeroitToxicButton.SelectedItem == null) return;
            ZeroitToxicButton.Items.Remove(ZeroitToxicButton.SelectedItem);
            if (ZeroitToxicButton.Items.Count > 0)
            {
                ZeroitToxicButton.Items[0].Selected = true;
            }
            ZeroitToxicButton.RefreshControl();
            ZeroitToxicButton.Invalidate();
            RefreshComponent();
        }

        /// <summary>
        /// Exports this instance.
        /// </summary>
        protected virtual void Export()
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = Properties.Resources.XML_FILE;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                using (XmlWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof(Appearance));
                    serializer.Serialize(writer, ZeroitToxicButton.Appearance);
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// Imports this instance.
        /// </summary>
        protected virtual void Import()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = Properties.Resources.XML_FILE;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(Appearance));
                    var app = (Zeroit.Framework.MiscControls.Appearance)serializer.Deserialize(fs);
                    ZeroitToxicButton.Appearance.Assign(app);
                    ZeroitToxicButton.SetThemeDefaults();
                    ZeroitToxicButton.Refresh();
                }
            }
        }
    }
}