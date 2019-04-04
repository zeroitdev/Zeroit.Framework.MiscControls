// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HeaderLabel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Header Label    
    /// <summary>
    /// A class collection for rendering a Header.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public class ZeroitLabelHeader : Label
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelHeader" /> class.
        /// </summary>
        public ZeroitLabelHeader()
        {
            Font = new Font("Segoe UI", 25, FontStyle.Regular);
            ForeColor = Color.FromArgb(80, 80, 80);
            BackColor = Color.Transparent;
        }
    }

    #endregion
}
