// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStyleAngledProvider.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs
{
    /// <summary>
    /// Class TabStyleAngledProvider.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Tabs.TabStyleProvider" />
    [System.ComponentModel.ToolboxItem(false)]
	public class TabStyleAngledProvider : TabStyleProvider
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleAngledProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleAngledProvider(ZeroitDuredoTab tabControl) : base(tabControl){
			this._ImageAlign = ContentAlignment.MiddleRight;
			this._Overlap = 7;
			this._Radius = 10;
			
			//	Must set after the _Radius as this is used in the calculations of the actual padding
			this.Padding = new Point(10, 3);

		}

        /// <summary>
        /// Adds the tab border.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tabBounds">The tab bounds.</param>
        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds){
			switch (this._TabControl.Alignment) {
				case TabAlignment.Top:
					path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X + this._Radius - 2, tabBounds.Y + 2);
					path.AddLine(tabBounds.X + this._Radius, tabBounds.Y, tabBounds.Right - this._Radius, tabBounds.Y);
					path.AddLine(tabBounds.Right - this._Radius + 2, tabBounds.Y + 2, tabBounds.Right, tabBounds.Bottom);
					break;
				case TabAlignment.Bottom:
					path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right - this._Radius + 2, tabBounds.Bottom - 2);
					path.AddLine(tabBounds.Right - this._Radius, tabBounds.Bottom, tabBounds.X + this._Radius, tabBounds.Bottom);
					path.AddLine(tabBounds.X + this._Radius - 2, tabBounds.Bottom - 2, tabBounds.X, tabBounds.Y);
					break;
				case TabAlignment.Left:
					path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X + 2, tabBounds.Bottom - this._Radius + 2);
					path.AddLine(tabBounds.X, tabBounds.Bottom - this._Radius, tabBounds.X, tabBounds.Y + this._Radius);
					path.AddLine(tabBounds.X + 2, tabBounds.Y + this._Radius - 2, tabBounds.Right, tabBounds.Y);
					break;
				case TabAlignment.Right:
					path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right - 2, tabBounds.Y + this._Radius - 2);
					path.AddLine(tabBounds.Right, tabBounds.Y + this._Radius, tabBounds.Right, tabBounds.Bottom - this._Radius);
					path.AddLine(tabBounds.Right - 2, tabBounds.Bottom - this._Radius + 2, tabBounds.X, tabBounds.Bottom);
					break;
			}
		}

	}
}
