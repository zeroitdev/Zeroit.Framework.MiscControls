// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RichTextBoxDefault.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region RichTextBox    
    /// <summary>
    /// A class collection for rendering a rich textbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.RichTextBox" />
    public class ZeroitRichTBox : RichTextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRichTBox" /> class.
        /// </summary>
        public ZeroitRichTBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }



    }

    #endregion
}
