// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviToolstripOffice07Renderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviToolstripOffice07Renderer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripProfessionalRenderer" />
    public class NaviToolstripOffice07Renderer : ToolStripProfessionalRenderer
   {
        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the ToolstripOffice07Renderer class
        /// </summary>
        /// <param name="colorTable">The colors used to draw the MenuStrip</param>
        public NaviToolstripOffice07Renderer(ProfessionalColorTable colorTable)
         : base(colorTable)
      {
      }

      #endregion
   }
}
