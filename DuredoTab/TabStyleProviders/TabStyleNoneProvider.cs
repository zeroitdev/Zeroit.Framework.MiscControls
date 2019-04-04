// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStyleNoneProvider.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls.Tabs
{
    /// <summary>
    /// Class TabStyleNoneProvider.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Tabs.TabStyleProvider" />
    [System.ComponentModel.ToolboxItem(false)]
	public class TabStyleNoneProvider : TabStyleProvider
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleNoneProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleNoneProvider(ZeroitDuredoTab tabControl) : base(tabControl){
		}

        /// <summary>
        /// Adds the tab border.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tabBounds">The tab bounds.</param>
        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds){
		}
	}
}
