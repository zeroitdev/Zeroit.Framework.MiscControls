// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ExpandCollapseEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Class PiperExpandCollapseEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PiperExpandCollapseEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PiperExpandCollapseEventArgs"/> class.
        /// </summary>
        /// <param name="isExpanded">if set to <c>true</c> [is expanded].</param>
        public PiperExpandCollapseEventArgs(bool isExpanded)
        {
            IsExpanded = isExpanded;
        }
    }
}
