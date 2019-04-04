// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PanelColorsOffice.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region PanelColorsOffice
    /// <summary>
    /// Class PanelColorsOffice.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.PanelColors" />
	public class PanelColorsOffice : PanelColors
    {
        #region Properties
        /// <summary>
        /// Gets the associated PanelStyle for the XPanderControls
        /// </summary>
        /// <value>The panel style.</value>
        public override PanelStyle PanelStyle
        {
            get { return PanelStyle.Office2007; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice class.
        /// </summary>
        public PanelColorsOffice()
            : base()
        {
        }
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or xpanderpanel control.</param>
		public PanelColorsOffice(BasePanel basePanel)
            : base(basePanel)
        {
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined Office2007 colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<KnownColors, System.Drawing.Color> rgbTable)
        {
            base.InitColors(rgbTable);
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(255, 255, 220);
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(247, 193, 94);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = Color.FromArgb(255, 217, 170);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = Color.FromArgb(254, 225, 122);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = Color.FromArgb(255, 171, 63);
            rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = Color.FromArgb(254, 211, 100);
            rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = Color.FromArgb(251, 140, 60);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(255, 252, 222);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(255, 230, 158);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(255, 215, 103);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.Black;
        }
        #endregion
    }
    #endregion
}
