// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviToolstripOffice07ColorTable.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviToolstripOffice07ColorTable.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ProfessionalColorTable" />
    public class NaviToolstripOffice07ColorTable : ProfessionalColorTable
   {
        /// <summary>
        /// Overriden. Gets the color of the border of an menu item
        /// </summary>
        /// <value>The menu item border.</value>
        public override Color MenuItemBorder
      {
         get { return Color.FromArgb(255, 189, 105); }
      }

        /// <summary>
        /// Overriden. Gets the color of selected menu item
        /// </summary>
        /// <value>The menu item selected.</value>
        public override Color MenuItemSelected
      {
         get { return Color.FromArgb(255, 231, 162); }
      }

        /// <summary>
        /// Overriden. Gets the color of the image margin
        /// </summary>
        /// <value>The image margin gradient begin.</value>
        public override Color ImageMarginGradientBegin
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

        /// <summary>
        /// Overriden. Gets the color of the image margin
        /// </summary>
        /// <value>The image margin gradient middle.</value>
        public override Color ImageMarginGradientMiddle
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

        /// <summary>
        /// Overriden. Gets the color of image margin
        /// </summary>
        /// <value>The image margin gradient end.</value>
        public override Color ImageMarginGradientEnd
      {
         get { return Color.FromArgb(233, 238, 238); }
      }

        /// <summary>
        /// Overriden. Gets the background color of an menu item check
        /// </summary>
        /// <value>The check background.</value>
        public override Color CheckBackground
      {
         get { return Color.FromArgb(255, 189, 105); }
      }

        /// <summary>
        /// Overriden. Gets the background color of an pressed menu item check
        /// </summary>
        /// <value>The check pressed background.</value>
        public override Color CheckPressedBackground
      {
         get { return Color.FromArgb(251, 140, 60); }
      }

        /// <summary>
        /// Overriden. Gets the background color of an selected menu item check
        /// </summary>
        /// <value>The check selected background.</value>
        public override Color CheckSelectedBackground
      {
         get { return Color.FromArgb(251, 140, 60); }
      }

        /// <summary>
        /// Overriden. Gets the color of the border of the item check
        /// </summary>
        /// <value>The button selected border.</value>
        public override Color ButtonSelectedBorder
      {
         get { return Color.FromArgb(255, 0, 0); }
      }      
   }
}