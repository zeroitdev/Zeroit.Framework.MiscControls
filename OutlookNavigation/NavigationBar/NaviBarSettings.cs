// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBarSettings.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBarSettings.
    /// </summary>
    [XmlRoot("settings")]
   public class NaviBarSettings
   {
        /// <summary>
        /// Gets or sets the band settings.
        /// </summary>
        /// <value>The band settings.</value>
        [XmlElement("band")]
      public List<NaviBandSetting> BandSettings { get; set; }

        /// <summary>
        /// Gets or sets the visible buttons.
        /// </summary>
        /// <value>The visible buttons.</value>
        [XmlElement("visibleButtons")]
      public int VisibleButtons { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NaviBarSettings"/> is collapsed.
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        [XmlElement("collapsed")]
      public bool Collapsed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviBarSettings"/> class.
        /// </summary>
        public NaviBarSettings()
      {
         BandSettings = new List<NaviBandSetting>();
      }
   }
}
