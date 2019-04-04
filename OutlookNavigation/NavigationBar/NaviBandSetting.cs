// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBandSetting.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Xml.Serialization;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBandSetting.
    /// </summary>
    public class NaviBandSetting
   {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute("name")]
      public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [XmlAttribute("order")]
      public int Order { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NaviBandSetting"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [XmlAttribute("visible")]
      public bool Visible { get; set; }
   }
}
