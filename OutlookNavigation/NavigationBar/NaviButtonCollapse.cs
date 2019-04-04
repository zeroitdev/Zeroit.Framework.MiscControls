// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonCollapse.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a collapsible button.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviButton" />
    [ToolboxItem(false)]
   public partial class NaviButtonCollapse : NaviButton
   {
        #region Fields

        /// <summary>
        /// The collapsed
        /// </summary>
        bool collapsed;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NavigationBarButton
        /// </summary>
        public NaviButtonCollapse()
      {
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether the buttons should be drawn in minimized mode or not
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        [
        Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      ]
      public override bool Collapsed
      {
         get { return collapsed; }
         set
         {
            // We need an explicit override with Invalidate otherwise the control is not 
            // invalidated properly. 
            collapsed = value;
            Invalidate();
         }
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         renderer.DrawCollapseButton(e.Graphics, ClientRectangle, inputState,
            RightToLeft == RightToLeft.Yes, collapsed);
      }

      #endregion
   }
}