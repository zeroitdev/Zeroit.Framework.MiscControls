// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TransparentRadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region RadioButton Transparent    
    /// <summary>
    /// A class collection for rendering a transparent radio button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.RadioButton" />
    public class ZeroitRadioButtonTransparent : RadioButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRadioButtonTransparent" /> class.
        /// </summary>
        public ZeroitRadioButtonTransparent()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }
    }
    #endregion
}
