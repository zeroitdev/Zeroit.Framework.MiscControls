// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AlterLabel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitLabelAlter    
    /// <summary>
    /// A class collection for rendering a Label.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public class ZeroitLabelAlter : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelAlter" /> class.
        /// </summary>
        public ZeroitLabelAlter()
        {
            ForeColor = Color.FromArgb(100, 100, 100);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8);
        }
    }
    #endregion
}
