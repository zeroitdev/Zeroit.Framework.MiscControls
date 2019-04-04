// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviContextMenu.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a context menu strip.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContextMenuStrip" />
    [ToolboxItem(false)]
   public class NaviContextMenu : ContextMenuStrip
   {
        /// <summary>
        /// The renderer
        /// </summary>
        ToolStripRenderer renderer;
        /// <summary>
        /// The color table
        /// </summary>
        ProfessionalColorTable colorTable;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviContextMenu"/> class.
        /// </summary>
        public NaviContextMenu()
         : base()
      {
         Initialize();
      }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
      {
         colorTable = new NaviToolstripOffice07ColorTable();
         renderer = new NaviToolstripOffice07Renderer(colorTable);
         base.Renderer = renderer;
      }

      #endregion
   }
}
