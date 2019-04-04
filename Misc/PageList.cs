// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PageList.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region PageList

    #region Control
    /// <summary>
    /// User control which is used to simplify page representation of data.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(true)]

    [Designer(typeof(ZeroitPageListDesigner))]
    public class ZeroitPageList : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The label page
        /// </summary>
        private System.Windows.Forms.Label labelPage;
        /// <summary>
        /// The link label first
        /// </summary>
        private System.Windows.Forms.LinkLabel linkLabelFirst;
        /// <summary>
        /// The link label previous
        /// </summary>
        private System.Windows.Forms.LinkLabel linkLabelPrev;
        /// <summary>
        /// The link label next
        /// </summary>
        private System.Windows.Forms.LinkLabel linkLabelNext;
        /// <summary>
        /// The link label last
        /// </summary>
        private System.Windows.Forms.LinkLabel linkLabelLast;

        /// <summary>
        /// The pages count
        /// </summary>
        private uint pagesCount;

        // number of pixels between links
        /// <summary>
        /// The gap
        /// </summary>
        private const int gap = 3;

        /// <summary>
        /// The current page
        /// </summary>
        private uint currentPage = 1;
        /// <summary>
        /// The number pages shown
        /// </summary>
        private uint numPagesShown = 3;

        /// <summary>
        /// The pages
        /// </summary>
        private ArrayList pages = new ArrayList();

        /// <summary>
        /// This delegate is called when current page of lister is
        /// changed.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        public delegate void PageChangeHandler(uint currentPage);

        /// <summary>
        /// Event fired when the current page is changed.
        /// </summary>
        public event PageChangeHandler PageChanged;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPageList" /> class.
        /// </summary>
        public ZeroitPageList()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.labelPage = new System.Windows.Forms.Label();
            this.linkLabelFirst = new System.Windows.Forms.LinkLabel();
            this.linkLabelPrev = new System.Windows.Forms.LinkLabel();
            this.linkLabelNext = new System.Windows.Forms.LinkLabel();
            this.linkLabelLast = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(8, 8);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(80, 18);
            this.labelPage.TabIndex = 0;
            this.labelPage.Text = "Page ... of ...";
            // 
            // linkLabelFirst
            // 
            this.linkLabelFirst.AutoSize = true;
            this.linkLabelFirst.Location = new System.Drawing.Point(152, 8);
            this.linkLabelFirst.Name = "linkLabelFirst";
            this.linkLabelFirst.Size = new System.Drawing.Size(20, 18);
            this.linkLabelFirst.TabIndex = 1;
            this.linkLabelFirst.TabStop = true;
            this.linkLabelFirst.Text = "<<";
            this.linkLabelFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
            // 
            // linkLabelPrev
            // 
            this.linkLabelPrev.AutoSize = true;
            this.linkLabelPrev.Location = new System.Drawing.Point(187, 8);
            this.linkLabelPrev.Name = "linkLabelPrev";
            this.linkLabelPrev.Size = new System.Drawing.Size(13, 18);
            this.linkLabelPrev.TabIndex = 2;
            this.linkLabelPrev.TabStop = true;
            this.linkLabelPrev.Text = "<";
            this.linkLabelPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
            // 
            // linkLabelNext
            // 
            this.linkLabelNext.AutoSize = true;
            this.linkLabelNext.Location = new System.Drawing.Point(280, 8);
            this.linkLabelNext.Name = "linkLabelNext";
            this.linkLabelNext.Size = new System.Drawing.Size(13, 18);
            this.linkLabelNext.TabIndex = 3;
            this.linkLabelNext.TabStop = true;
            this.linkLabelNext.Text = ">";
            this.linkLabelNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
            // 
            // linkLabelLast
            // 
            this.linkLabelLast.AutoSize = true;
            this.linkLabelLast.Location = new System.Drawing.Point(315, 8);
            this.linkLabelLast.Name = "linkLabelLast";
            this.linkLabelLast.Size = new System.Drawing.Size(20, 18);
            this.linkLabelLast.TabIndex = 4;
            this.linkLabelLast.TabStop = true;
            this.linkLabelLast.Text = ">>";
            this.linkLabelLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
            // 
            // PageLister
            // 
            this.Controls.Add(this.linkLabelLast);
            this.Controls.Add(this.linkLabelNext);
            this.Controls.Add(this.linkLabelPrev);
            this.Controls.Add(this.linkLabelFirst);
            this.Controls.Add(this.labelPage);
            this.Name = "PageLister";
            this.Size = new System.Drawing.Size(640, 32);
            this.ResumeLayout(false);

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        /// <value>The pages count.</value>
        [Bindable(true),
        DefaultValue(7),
        Description("Total number of pages.")]
        public uint PagesCount
        {
            get
            {
                return pagesCount;
            }
            set
            {
                pagesCount = value;

                populateLinks();
            }
        }

        /// <summary>
        /// Gets or sets a number of the current page.
        /// </summary>
        /// <value>The current page.</value>
        [Bindable(true),
        DefaultValue(1),
        Description("Specifies current page's number")]
        public uint CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;

                populateLinks();
            }
        }

        /// <summary>
        /// Gets or sets the number of pages shown on the
        /// each side of the current page. So, the maximal total number
        /// of numbered page links is NumPagesShown * 2 + 1.
        /// </summary>
        /// <value>The number pages shown.</value>
        [Bindable(true),
        DefaultValue(3),
        Description("Specifies the number of pages shown on the each "
        + "side of the current page")]
        public uint NumPagesShown
        {
            get
            {
                return numPagesShown;
            }
            set
            {
                numPagesShown = value;

                populateLinks();
            }
        }
        #endregion

        /// <summary>
        /// Populates the links.
        /// </summary>
        private void populateLinks()
        {
            if (pagesCount < currentPage
                || pagesCount == 0
                || currentPage == 0)
            {
                // info hasn't been entered completely yet
                return;
            }

            // set label's text
            labelPage.Text = "Page " + currentPage.ToString()
                + " of " + pagesCount.ToString() + ".";

            // set position of the two first (static) links
            linkLabelFirst.Location =
                new Point(
                labelPage.Location.X + labelPage.Width + gap,
                labelPage.Location.Y);

            linkLabelPrev.Location =
                new Point(
                linkLabelFirst.Location.X + linkLabelFirst.Width + gap,
                linkLabelFirst.Location.Y);

            // calculate number of links on both left and right sides
            // of the current page
            uint pagesLeft = numPagesShown;
            uint pagesRight = numPagesShown;
            uint pagesShownTotal = (uint)Math.Min(2 * numPagesShown + 1, pagesCount);

            if (currentPage <= numPagesShown)
            {
                pagesLeft = currentPage - 1;
                pagesRight = pagesShownTotal - pagesLeft - 1;
            }
            else
            if (pagesCount - currentPage <= numPagesShown)
            {
                pagesRight = pagesCount - currentPage;
                pagesLeft = pagesShownTotal - pagesRight - 1;
            }

            // change existing pages without deleting them
            // to avoid blinking
            for (int i = 0; i < Math.Min(pagesShownTotal, pages.Count); i++)
            {
                uint pageNum = (uint)(currentPage - pagesLeft + i);
                LinkLabel page = (LinkLabel)pages[i];
                page.Tag = pageNum;
                page.Text = page.Tag.ToString();
                page.Font = pageNum == currentPage ?
                    new Font(this.Font, FontStyle.Bold) : null;

                // set page link's location relative to the previous
                // link
                LinkLabel pagePrev = i > 0 ?
                    (LinkLabel)pages[i - 1] : linkLabelPrev;
                page.Location = new Point(
                    pagePrev.Location.X + pagePrev.Width + gap,
                    pagePrev.Location.Y);
            }

            if (pages.Count > pagesShownTotal)
            {
                // remove unnecessary pages
                for (int i = pages.Count - 1; i >= pagesShownTotal; i--)
                {
                    LinkLabel page = (LinkLabel)pages[i];
                    page.Parent = null;
                    page.Visible = false;
                    pages.RemoveAt(i);
                    page.Dispose();
                }
            }
            else
            if (pages.Count < pagesShownTotal)
            {
                // add pages
                for (int i = pages.Count; i < pagesShownTotal; i++)
                {
                    LinkLabel page = new LinkLabel();
                    page.AutoSize = true;
                    page.Tag = (uint)(currentPage - pagesLeft + i);
                    page.Text = page.Tag.ToString();

                    page.Height = linkLabelFirst.Height;

                    // set page location relative to the previous page
                    LinkLabel pagePrev = pages.Count > 0 ?
                        (LinkLabel)pages[i - 1] : linkLabelPrev;

                    page.Font = i == currentPage ?
                        new Font(this.Font, FontStyle.Bold) : null;

                    page.Parent = this;

                    page.Location = new Point(
                        pagePrev.Location.X + pagePrev.Width + gap,
                        pagePrev.Location.Y);

                    pages.Add(page);
                    page.LinkClicked +=
                        new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                        linkClicked);
                }
            }

            Debug.Assert(pages.Count > 0);

            // change location of the last two links (next & last)
            LinkLabel pageLast = (LinkLabel)pages[pages.Count - 1];

            linkLabelNext.Location = new Point(
                pageLast.Location.X + pageLast.Width + gap,
                linkLabelNext.Location.Y);

            linkLabelLast.Location = new Point(
                linkLabelNext.Location.X + linkLabelNext.Width,
                linkLabelLast.Location.Y);

            checkPages();
        }

        /// <summary>
        /// Checks the pages.
        /// </summary>
        private void checkPages()
        {
            linkLabelFirst.Enabled =
            linkLabelPrev.Enabled = currentPage > 1;
            linkLabelNext.Enabled =
            linkLabelLast.Enabled = currentPage < pagesCount;
        }

        /// <summary>
        /// Links the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkClicked(object sender,
            System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel page = (LinkLabel)sender;
            switch (page.Text)
            {
                case "<<":
                    if (currentPage == 1)
                        return;
                    currentPage = 1;
                    break;
                case "<":
                    if (currentPage == 1)
                        return;
                    currentPage--;
                    break;
                case ">":
                    if (currentPage == pagesCount)
                        return;
                    currentPage++;
                    break;
                case ">>":
                    if (currentPage == pagesCount)
                        return;
                    currentPage = pagesCount;
                    break;
                default:
                    currentPage = (uint)page.Tag;
                    break;
            }

            populateLinks();

            if (PageChanged != null)
                PageChanged(currentPage);
        }
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitPageListDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPageListDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPageListDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPageListSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPageListSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPageListSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPageList colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPageListSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPageListSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPageList;

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
        /// Gets or sets the pages count.
        /// </summary>
        /// <value>The pages count.</value>
        public uint PagesCount
        {
            get
            {
                return colUserControl.PagesCount;
            }
            set
            {
                GetPropertyByName("PagesCount").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public uint CurrentPage
        {
            get
            {
                return colUserControl.CurrentPage;
            }
            set
            {
                GetPropertyByName("CurrentPage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the number pages shown.
        /// </summary>
        /// <value>The number pages shown.</value>
        public uint NumPagesShown
        {
            get
            {
                return colUserControl.NumPagesShown;
            }
            set
            {
                GetPropertyByName("NumPagesShown").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("PagesCount",
                                 "Pages Count", "Appearance",
                                 "Sets the page count."));

            items.Add(new DesignerActionPropertyItem("CurrentPage",
                                 "Current Page", "Appearance",
                                 "Sets the current page."));

            items.Add(new DesignerActionPropertyItem("NumPagesShown",
                                 "Num Pages Shown", "Appearance",
                                 "Set the number of pages shown."));

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
