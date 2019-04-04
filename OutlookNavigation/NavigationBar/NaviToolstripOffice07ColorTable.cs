// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviToolstripOffice07ColorTable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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