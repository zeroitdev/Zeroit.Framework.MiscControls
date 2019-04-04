// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripSystemRenderer.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This is just the start of what you would do if you wanted to draw using
    /// the theme APIs.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripSystemRenderer" />
    class TabStripSystemRenderer : ToolStripSystemRenderer {

        /// <summary>
        /// Handles the <see cref="E:RenderButtonBackground" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
            ZeroitTabStrip tabStrip = e.ToolStrip as ZeroitTabStrip;
            Tab tab = e.Item as Tab;
            Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);

            if (tab != null && tabStrip != null) {
                System.Windows.Forms.VisualStyles.TabItemState tabState = System.Windows.Forms.VisualStyles.TabItemState.Normal;
                if (tab.Checked) {
                    tabState |= System.Windows.Forms.VisualStyles.TabItemState.Selected;
                }
                if (tab.Selected) {
                    tabState |= System.Windows.Forms.VisualStyles.TabItemState.Hot;
                }
                TabRenderer.DrawTabItem(e.Graphics, bounds, tabState);
            }
            else {
                base.OnRenderButtonBackground(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemText" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemTextRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            base.OnRenderItemText(e);
            Tab tab = e.Item as Tab;
            if (tab != null && tab.Checked) {                
                Rectangle rect = e.TextRectangle;
                ControlPaint.DrawFocusRectangle(e.Graphics, rect);
            }
        }


        
        
    }
}
