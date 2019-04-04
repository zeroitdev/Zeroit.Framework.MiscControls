// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripSystemRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
