// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviContextMenu.cs" company="Zeroit Dev Technologies">
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
