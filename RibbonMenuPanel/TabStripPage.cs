// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripPage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitTabStripPage.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitRibbonPanel" />
    [ToolboxItem(false)] // dont show up in the toolbox, this will be created by the Add TabStripPage verb on the TabPageSwitcherDesigner
    [Docking(DockingBehavior.Never)]  // dont ask about docking
    [System.ComponentModel.DesignerCategory("Code")] // dont bring up the component designer when opened
    public class ZeroitTabStripPage : ZeroitRibbonPanel {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTabStripPage"/> class.
        /// </summary>
        public ZeroitTabStripPage() {
        }


        /// <summary>
        /// Bring this TabStripPage to the front of the switcher.
        /// </summary>
        public void Activate() {
            TabPageSwitcher tabPageSwitcher = this.Parent as TabPageSwitcher;
            if (tabPageSwitcher != null) {
                tabPageSwitcher.SelectedTabStripPage = this;

                try
                {
                    int x0 = tabPageSwitcher.TabStrip.SelectedTab.Bounds.Location.X;
                    int xf = tabPageSwitcher.TabStrip.SelectedTab.Bounds.Right;
                    tabPageSwitcher.SelectedTabStripPage.LinePos(x0, xf, true);
                }
                catch { }
            }
            
        }
    }
}
