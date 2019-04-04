// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripPage.cs" company="Zeroit Dev Technologies">
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
