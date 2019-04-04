// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBarSettings.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
