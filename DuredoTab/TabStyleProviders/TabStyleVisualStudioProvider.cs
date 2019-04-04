// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStyleVisualStudioProvider.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs
{

    /// <summary>
    /// Class TabStyleVisualStudioProvider.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Tabs.TabStyleProvider" />
    [System.ComponentModel.ToolboxItem(false)]
	public class TabStyleVisualStudioProvider : TabStyleProvider
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleVisualStudioProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleVisualStudioProvider(ZeroitDuredoTab tabControl) : base(tabControl){
			this._ImageAlign = ContentAlignment.MiddleRight;
			this._Overlap = 7;
			
			//	Must set after the _Radius as this is used in the calculations of the actual padding
			this.Padding = new Point(14, 1);
		}

        /// <summary>
        /// Adds the tab border.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tabBounds">The tab bounds.</param>
        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds){
			switch (this._TabControl.Alignment) {
				case TabAlignment.Top:
					path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X + tabBounds.Height - 4, tabBounds.Y + 2);
					path.AddLine(tabBounds.X + tabBounds.Height, tabBounds.Y, tabBounds.Right - 3, tabBounds.Y);
					path.AddArc(tabBounds.Right - 6, tabBounds.Y, 6, 6, 270, 90);
					path.AddLine(tabBounds.Right, tabBounds.Y + 3, tabBounds.Right, tabBounds.Bottom);
					break;
				case TabAlignment.Bottom:
					path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom - 3);
					path.AddArc(tabBounds.Right - 6, tabBounds.Bottom - 6, 6, 6, 0, 90);
					path.AddLine(tabBounds.Right - 3, tabBounds.Bottom, tabBounds.X + tabBounds.Height, tabBounds.Bottom);
					path.AddLine(tabBounds.X + tabBounds.Height - 4, tabBounds.Bottom - 2, tabBounds.X, tabBounds.Y);
					break;
				case TabAlignment.Left:
					path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X + 3, tabBounds.Bottom);
					path.AddArc(tabBounds.X, tabBounds.Bottom - 6, 6, 6, 90, 90);
					path.AddLine(tabBounds.X, tabBounds.Bottom - 3, tabBounds.X, tabBounds.Y + tabBounds.Width);
					path.AddLine(tabBounds.X + 2, tabBounds.Y + tabBounds.Width - 4, tabBounds.Right, tabBounds.Y);
					break;
				case TabAlignment.Right:
					path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right - 2, tabBounds.Y + tabBounds.Width - 4);
					path.AddLine(tabBounds.Right, tabBounds.Y + tabBounds.Width, tabBounds.Right, tabBounds.Bottom - 3);
					path.AddArc(tabBounds.Right - 6, tabBounds.Bottom - 6, 6, 6, 0, 90);
					path.AddLine(tabBounds.Right - 3, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
					break;
			}
		}

	}
}
