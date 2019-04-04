// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonOptions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviButtonOptions.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviButton" />
    [ToolboxItem(false)]
   public partial class NaviButtonOptions : NaviButton
   {
        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
      {
         base.OnPaint(e);
         base.Renderer.DrawOptionsTriangle(e.Graphics, ClientRectangle);
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
