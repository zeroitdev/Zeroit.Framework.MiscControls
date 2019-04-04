// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region TabControl

    /// <summary>
    /// A class collection for rendering a tab control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    [Designer(typeof(ZeroitTabControlDesigner))]
    [DefaultMember("Item")]
    public class ZeroitTabControl : TabControl
    {

        // NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        // the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        // high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        // determined in the ImageList

        // INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        // Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        // Check it out from here: http://www.gentleface.com/free_icon_set.html

        #region Variables
        /// <summary>
        /// The color tab
        /// </summary>
        private Color colorTab = Color.FromArgb(35, 36, 38);
        /// <summary>
        /// The color tab background
        /// </summary>
        private Color colorTabBackground = Color.FromArgb(54, 57, 64);
        /// <summary>
        /// The color tab border
        /// </summary>
        private Color colorTabBorder = Color.FromArgb(25, 26, 28);
        /// <summary>
        /// The color tab highlight
        /// </summary>
        private Color colorTabHighlight = Color.FromArgb(89, 169, 222);

        /// <summary>
        /// The color tab page
        /// </summary>
        private Color colorTabPage = Color.FromArgb(246, 246, 246);
        /// <summary>
        /// The collection
        /// </summary>
        private TabPageCollection collection = new TabPageCollection(new TabControl());


        /// <summary>
        /// The add page
        /// </summary>
        private static String addPage = "Page1";
        /// <summary>
        /// The remove page
        /// </summary>
        private String removePage = "0";

        /// <summary>
        /// The get page
        /// </summary>
        TabPage getPage = new TabPage(addPage);

        #endregion

        #region Properties

        //
        // Summary:
        //     Gets the collection of tab pages in this tab control.
        //
        // Returns:
        //     A System.Windows.Forms.TabControl.TabPageCollection that contains the System.Windows.Forms.TabPage
        //     objects in this System.Windows.Forms.TabControl.        
        /// <summary>
        /// Gets or sets the color tab.
        /// </summary>
        /// <value>The color tab.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor("System.Windows.Forms.Design.TabPageCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(true)]
        
        public Color ColorTab
        {
            get { return colorTab; }
            set
            {
                colorTab = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the tab's background.
        /// </summary>
        /// <value>The color of the tab's background.</value>
        public Color ColorTabBackground
        {
            get { return colorTabBackground; }
            set
            {
                colorTabBackground = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the tab's highlight.
        /// </summary>
        /// <value>The color tab highlight.</value>
        public Color ColorTabHighlight
        {
            get { return colorTabHighlight; }
            set
            {
                colorTabHighlight = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the tab border.
        /// </summary>
        /// <value>The color tab border.</value>
        public Color ColorTabBorder
        {
            get { return colorTabBorder; }
            set
            {
                colorTabBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the tab page.
        /// </summary>
        /// <value>The color tab page.</value>
        public Color ColorTabPage
        {
            get { return colorTabPage; }
            set
            {
                colorTabPage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public TabPageCollection Items
        {

            get { return TabPages; }

        }

        /// <summary>
        /// Gets or sets the add page.
        /// </summary>
        /// <value>The add page.</value>
        public string AddPage
        {
            get { return addPage; }
            set
            {
                //try
                //{
                //    if(DesignMode)
                //    {
                //        addPage = value;
                //        if(addPage==value)
                //        {
                //            getPage.Name = addPage;
                //            Items.Add(getPage);
                //            Invalidate();
                //        }

                //    }


                //    //Items.Add(addPage);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    throw;
                //}

                //----------------------------------------Working Code-----------------------------------------//
                //addPage = value;
                //Items.Add(addPage);

                //if(TabPages.ContainsKey(addPage))
                //{
                //    foreach(TabPage Page in TabPages)
                //    {
                //        Page.Name = Page.Text;
                //        Invalidate();
                //    }
                //}


                //----------------------------------------Working Code-----------------------------------------//

            }
        }

        /// <summary>
        /// Gets or sets the remove page.
        /// </summary>
        /// <value>The remove page.</value>
        public string RemovePage
        {
            get { return removePage; }
            set
            {
                //string[] tabText = { TabPages.Count.ToString() };
                //for (int i = 0; i <= tabText.Length; i++)
                //{



                //}

                removePage = value;


                Items.RemoveByKey(removePage);
                Invalidate();
                //removePage = value;

                //Items.RemoveByKey(removePage);



            }
        }

        /// <summary>
        /// Gets or sets which control borders are docked to its parent control and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The dock.</value>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            set
            {
                base.Dock = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTabControl" /> class.
        /// </summary>
        public ZeroitTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 135);
            DrawMode = TabDrawMode.OwnerDrawFixed;

            foreach (TabPage Page in this.TabPages)
            {

                Page.BackColor = colorTabPage;
            }


        }



        /// <summary>
        /// This member overrides <see cref="M:System.Windows.Forms.Control.CreateHandle" />.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();

            base.DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = this.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TabPage current = (TabPage)enumerator.Current;
                        current = new TabPage();

                    }
                }
                finally
                {
                    e.Control.BackColor = colorTabPage;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);


            var _Graphics = G;

            _Graphics.Clear(colorTabPage);
            _Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            _Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            // Draw tab selector background
            _Graphics.FillRectangle(new SolidBrush(colorTabBackground), new Rectangle(-5, 0, ItemSize.Height + 4, Height));
            // Draw vertical line at the end of the tab selector rectangle
            _Graphics.DrawLine(new Pen(colorTabBorder), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

            for (int TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
            {
                if (TabIndex == SelectedIndex)
                {
                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));

                    // Draw background of the selected tab
                    _Graphics.FillRectangle(new SolidBrush(colorTab), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3);
                    // Draw a tab highlighter on the background of the selected tab
                    Rectangle TabHighlighter = new Rectangle(new Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - (TabIndex == 0 ? 1 : 1)), new Size(4, GetTabRect(TabIndex).Height - 7));
                    _Graphics.FillRectangle(new SolidBrush(colorTabHighlight), TabHighlighter);
                    // Draw tab text
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(254, 255, 255)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }
                }
                else
                {
                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(159, 162, 167)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }

                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);

            //if (getPage.Name != null)
            //{
            //    getPage.Name = addPage;
            //}




            G.Dispose();
            B.Dispose();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitTabControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitTabControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitTabControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitTabControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitTabControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitTabControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTabControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitTabControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitTabControl;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color tab.
        /// </summary>
        /// <value>The color tab.</value>
        public Color ColorTab
        {
            get
            {
                return colUserControl.ColorTab;
            }
            set
            {
                GetPropertyByName("ColorTab").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color tab background.
        /// </summary>
        /// <value>The color tab background.</value>
        public Color ColorTabBackground
        {
            get
            {
                return colUserControl.ColorTabBackground;
            }
            set
            {
                GetPropertyByName("ColorTabBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color tab highlight.
        /// </summary>
        /// <value>The color tab highlight.</value>
        public Color ColorTabHighlight
        {
            get
            {
                return colUserControl.ColorTabHighlight;
            }
            set
            {
                GetPropertyByName("ColorTabHighlight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color tab border.
        /// </summary>
        /// <value>The color tab border.</value>
        public Color ColorTabBorder
        {
            get
            {
                return colUserControl.ColorTabBorder;
            }
            set
            {
                GetPropertyByName("ColorTabBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color tab page.
        /// </summary>
        /// <value>The color tab page.</value>
        public Color ColorTabPage
        {
            get
            {
                return colUserControl.ColorTabPage;
            }
            set
            {
                GetPropertyByName("ColorTabPage").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public Zeroit.Framework.MiscControls.ZeroitTabControl.TabPageCollection Items
        {
            get
            {
                return colUserControl.Items;
            }
            set
            {
                GetPropertyByName("Items").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the add page.
        /// </summary>
        /// <value>The add page.</value>
        public string AddPage
        {
            get
            {
                return colUserControl.AddPage;
            }
            set
            {
                GetPropertyByName("AddPage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the remove page.
        /// </summary>
        /// <value>The remove page.</value>
        public string RemovePage
        {
            get
            {
                return colUserControl.RemovePage;
            }
            set
            {
                GetPropertyByName("RemovePage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the dock.
        /// </summary>
        /// <value>The dock.</value>
        public DockStyle Dock
        {
            get
            {
                return colUserControl.Dock;
            }
            set
            {
                GetPropertyByName("Dock").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("Dock",
                                 "Dock", "Appearance",
                                 "Sets the dock of this control."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ColorTab",
                                 "Color Tab", "Appearance",
                                 "Sets Color of the tab."));

            items.Add(new DesignerActionPropertyItem("ColorTabBackground",
                                 "Color Tab Background", "Appearance",
                                 "Sets the background color of the tab."));

            items.Add(new DesignerActionPropertyItem("ColorTabHighlight",
                                 "Color Tab Highlight", "Appearance",
                                 "Sets the left highlight color of the tab."));

            items.Add(new DesignerActionPropertyItem("ColorTabBorder",
                                 "Color Tab Border", "Appearance",
                                 "Sets the boder color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorTabPage",
                                 "Color Tab Page", "Appearance",
                                 "Sets the background color of the Page."));

            items.Add(new DesignerActionPropertyItem("Items",
                                 "Items", "Appearance",
                                 "See Item collection to add and remove some."));

            //items.Add(new DesignerActionPropertyItem("AddPage",
            //                     "Add Page", "Appearance",
            //                     "Add a tab to the control."));

            //items.Add(new DesignerActionPropertyItem("RemovePage",
            //                     "Remove Page", "Appearance",
            //                     "Type few characters to filter Cities."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion



    #endregion
}
