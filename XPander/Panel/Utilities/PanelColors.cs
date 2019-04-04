// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PanelColors.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region PanelColors
    /// <summary>
    /// Provides <see cref="Color" /> structures that are colors of a Panel or XPanderPanel display element.
    /// </summary>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class PanelColors
    {
        #region Enums
        /// <summary>
        /// Gets or sets the KnownColors appearance of the ProfessionalColorTable.
        /// </summary>
        public enum KnownColors
        {
            /// <summary>
            /// The border color of the panel.
            /// </summary>
            BorderColor,
            /// <summary>
            /// The forecolor of a close icon in a Panel.
            /// </summary>
            PanelCaptionCloseIcon,
            /// <summary>
            /// The forecolor of a expand icon in a Panel.
            /// </summary>
			PanelCaptionExpandIcon,
            /// <summary>
            /// The starting color of the gradient of the Panel.
            /// </summary>
            PanelCaptionGradientBegin,
            /// <summary>
            /// The end color of the gradient of the Panel.
            /// </summary>
            PanelCaptionGradientEnd,
            /// <summary>
            /// The middle color of the gradient of the Panel.
            /// </summary>
            PanelCaptionGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used when the hover icon in the captionbar on the Panel is selected.
            /// </summary>
            PanelCaptionSelectedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when the hover icon in the captionbar on the Panel is selected.
            /// </summary>
            PanelCaptionSelectedGradientEnd,
            /// <summary>
            /// The starting color of the gradient used in the Panel.
            /// </summary>
            PanelContentGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the Panel.
            /// </summary>
            PanelContentGradientEnd,
            /// <summary>
            /// The text color of a Panel.
            /// </summary>
            PanelCaptionText,
            /// <summary>
            /// The text color of a Panel when it's collapsed.
            /// </summary>
            PanelCollapsedCaptionText,
            /// <summary>
            /// The inner border color of a Panel.
            /// </summary>
            InnerBorderColor,
            /// <summary>
            /// The backcolor of a XPanderPanel.
            /// </summary>
            XPanderPanelBackColor,
            /// <summary>
            /// The forecolor of a close icon in a XPanderPanel.
            /// </summary>
            XPanderPanelCaptionCloseIcon,
            /// <summary>
            /// The forecolor of a expand icon in a XPanderPanel.
            /// </summary>
            XPanderPanelCaptionExpandIcon,
            /// <summary>
            /// The text color of a XPanderPanel.
            /// </summary>
            XPanderPanelCaptionText,
            /// <summary>
            /// The starting color of the gradient of the XPanderPanel.
            /// </summary>
            XPanderPanelCaptionGradientBegin,
            /// <summary>
            /// The end color of the gradient of the XPanderPanel.
            /// </summary>
            XPanderPanelCaptionGradientEnd,
            /// <summary>
            /// The middle color of the gradient of the XPanderPanel.
            /// </summary>
            XPanderPanelCaptionGradientMiddle,
            /// <summary>
            /// The starting color of the gradient of a flat XPanderPanel.
            /// </summary>
            XPanderPanelFlatCaptionGradientBegin,
            /// <summary>
            /// The end color of the gradient of a flat XPanderPanel.
            /// </summary>
            XPanderPanelFlatCaptionGradientEnd,
            /// <summary>
            /// The starting color of the gradient used when the XPanderPanel is pressed down.
            /// </summary>
            XPanderPanelPressedCaptionBegin,
            /// <summary>
            /// The end color of the gradient used when the XPanderPanel is pressed down.
            /// </summary>
            XPanderPanelPressedCaptionEnd,
            /// <summary>
            /// The middle color of the gradient used when the XPanderPanel is pressed down.
            /// </summary>
            XPanderPanelPressedCaptionMiddle,
            /// <summary>
            /// The starting color of the gradient used when the XPanderPanel is checked.
            /// </summary>
            XPanderPanelCheckedCaptionBegin,
            /// <summary>
            /// The end color of the gradient used when the XPanderPanel is checked.
            /// </summary>
            XPanderPanelCheckedCaptionEnd,
            /// <summary>
            /// The middle color of the gradient used when the XPanderPanel is checked.
            /// </summary>
            XPanderPanelCheckedCaptionMiddle,
            /// <summary>
            /// The starting color of the gradient used when the XPanderPanel is selected.
            /// </summary>
			XPanderPanelSelectedCaptionBegin,
            /// <summary>
            /// The end color of the gradient used when the XPanderPanel is selected.
            /// </summary>
            XPanderPanelSelectedCaptionEnd,
            /// <summary>
            /// The middle color of the gradient used when the XPanderPanel is selected.
            /// </summary>
            XPanderPanelSelectedCaptionMiddle,
            /// <summary>
            /// The text color used when the XPanderPanel is selected.
            /// </summary>
            XPanderPanelSelectedCaptionText
        }
        #endregion

        #region FieldsPrivate

        /// <summary>
        /// The m base panel
        /// </summary>
        private BasePanel m_basePanel;
        /// <summary>
        /// The m professional color table
        /// </summary>
        private System.Windows.Forms.ProfessionalColorTable m_professionalColorTable;
        /// <summary>
        /// The m dictionary RGB table
        /// </summary>
        private Dictionary<KnownColors, Color> m_dictionaryRGBTable;
        /// <summary>
        /// The m b use system colors
        /// </summary>
        private bool m_bUseSystemColors;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the border color of a Panel or XPanderPanel.
        /// </summary>
        /// <value>The color of the border.</value>
        public virtual Color BorderColor
        {
            get { return this.FromKnownColor(KnownColors.BorderColor); }
        }
        /// <summary>
        /// Gets the forecolor of a close icon in a Panel.
        /// </summary>
        /// <value>The panel caption close icon.</value>
        public virtual Color PanelCaptionCloseIcon
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionCloseIcon); }
        }
        /// <summary>
        /// Gets the forecolor of an expand icon in a Panel.
        /// </summary>
        /// <value>The panel caption expand icon.</value>
        public virtual Color PanelCaptionExpandIcon
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionExpandIcon); }
        }
        /// <summary>
        /// Gets the starting color of the gradient of the Panel.
        /// </summary>
        /// <value>The panel caption gradient begin.</value>
        public virtual Color PanelCaptionGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient of the Panel.
        /// </summary>
        /// <value>The panel caption gradient end.</value>
        public virtual Color PanelCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionGradientEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient of the Panel.
        /// </summary>
        /// <value>The panel caption gradient middle.</value>
        public virtual Color PanelCaptionGradientMiddle
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionGradientMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        /// <value>The panel caption selected gradient begin.</value>
        public virtual Color PanelCaptionSelectedGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionSelectedGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        /// <value>The panel caption selected gradient end.</value>
        public virtual Color PanelCaptionSelectedGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionSelectedGradientEnd); }
        }
        /// <summary>
        /// Gets the text color of a Panel.
        /// </summary>
        /// <value>The panel caption text.</value>
        public virtual Color PanelCaptionText
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionText); }
        }
        /// <summary>
        /// Gets the text color of a Panel when it's collapsed.
        /// </summary>
        /// <value>The panel collapsed caption text.</value>
        public virtual Color PanelCollapsedCaptionText
        {
            get { return this.FromKnownColor(KnownColors.PanelCollapsedCaptionText); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the Panel.
        /// </summary>
        /// <value>The panel content gradient begin.</value>
        public virtual Color PanelContentGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanelContentGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the Panel.
        /// </summary>
        /// <value>The panel content gradient end.</value>
        public virtual Color PanelContentGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanelContentGradientEnd); }
        }
        /// <summary>
        /// Gets the inner border color of a Panel.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public virtual Color InnerBorderColor
        {
            get { return this.FromKnownColor(KnownColors.InnerBorderColor); }
        }
        /// <summary>
        /// Gets the backcolor of a XPanderPanel.
        /// </summary>
        /// <value>The color of the x pander panel back.</value>
        public virtual Color XPanderPanelBackColor
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelBackColor); }
        }
        /// <summary>
        /// Gets the forecolor of a close icon in a XPanderPanel.
        /// </summary>
        /// <value>The x pander panel caption close icon.</value>
        public virtual Color XPanderPanelCaptionCloseIcon
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionCloseIcon); }
        }
        /// <summary>
        /// Gets the forecolor of an expand icon in a XPanderPanel.
        /// </summary>
        /// <value>The x pander panel caption expand icon.</value>
        public virtual Color XPanderPanelCaptionExpandIcon
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionExpandIcon); }
        }
        /// <summary>
        /// Gets the starting color of the gradient of the XPanderPanel.
        /// </summary>
        /// <value>The x pander panel caption gradient begin.</value>
        public virtual Color XPanderPanelCaptionGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient of the XPanderPanel.
        /// </summary>
        /// <value>The x pander panel caption gradient end.</value>
        public virtual Color XPanderPanelCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionGradientEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient on the XPanderPanel captionbar.
        /// </summary>
        /// <value>The x pander panel caption gradient middle.</value>
        public virtual Color XPanderPanelCaptionGradientMiddle
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionGradientMiddle); }
        }
        /// <summary>
        /// Gets the text color of a XPanderPanel.
        /// </summary>
        /// <value>The x pander panel caption text.</value>
        public virtual Color XPanderPanelCaptionText
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCaptionText); }
        }
        /// <summary>
        /// Gets the starting color of the gradient on a flat XPanderPanel captionbar.
        /// </summary>
        /// <value>The x pander panel flat caption gradient begin.</value>
        public virtual Color XPanderPanelFlatCaptionGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelFlatCaptionGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient on a flat XPanderPanel captionbar.
        /// </summary>
        /// <value>The x pander panel flat caption gradient end.</value>
        public virtual Color XPanderPanelFlatCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelFlatCaptionGradientEnd); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The x pander panel pressed caption begin.</value>
        public virtual Color XPanderPanelPressedCaptionBegin
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelPressedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The x pander panel pressed caption end.</value>
        public virtual Color XPanderPanelPressedCaptionEnd
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelPressedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The x pander panel pressed caption middle.</value>
        public virtual Color XPanderPanelPressedCaptionMiddle
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelPressedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The x pander panel checked caption begin.</value>
        public virtual Color XPanderPanelCheckedCaptionBegin
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCheckedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The x pander panel checked caption end.</value>
        public virtual Color XPanderPanelCheckedCaptionEnd
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCheckedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The x pander panel checked caption middle.</value>
        public virtual Color XPanderPanelCheckedCaptionMiddle
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelCheckedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The x pander panel selected caption begin.</value>
        public virtual Color XPanderPanelSelectedCaptionBegin
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelSelectedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The x pander panel selected caption end.</value>
        public virtual Color XPanderPanelSelectedCaptionEnd
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelSelectedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The x pander panel selected caption middle.</value>
        public virtual Color XPanderPanelSelectedCaptionMiddle
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelSelectedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the text color used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The x pander panel selected caption text.</value>
        public virtual Color XPanderPanelSelectedCaptionText
        {
            get { return this.FromKnownColor(KnownColors.XPanderPanelSelectedCaptionText); }
        }
        /// <summary>
        /// Gets the associated PanelStyle for the XPanderControls
        /// </summary>
        /// <value>The panel style.</value>
        public virtual PanelStyle PanelStyle
        {
            get { return PanelStyle.Default; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether to use System.Drawing.SystemColors rather than colors that match the current visual style.
        /// </summary>
        /// <value><c>true</c> if [use system colors]; otherwise, <c>false</c>.</value>
        public bool UseSystemColors
        {
            get { return this.m_bUseSystemColors; }
            set
            {
                if (value.Equals(this.m_bUseSystemColors) == false)
                {
                    this.m_bUseSystemColors = value;
                    this.m_professionalColorTable.UseSystemColors = this.m_bUseSystemColors;
                    Clear();
                }
            }
        }
        /// <summary>
        /// Gets or sets the panel or xpanderpanel
        /// </summary>
        /// <value>The zeroit pro panel.</value>
        public BasePanel ZeroitProPanel
        {
            get { return this.m_basePanel; }
            set { this.m_basePanel = value; }
        }
        /// <summary>
        /// Froms the color of the known.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color.</returns>
        internal Color FromKnownColor(KnownColors color)
        {
            return (Color)this.ColorTable[color];
        }
        /// <summary>
        /// Gets the color table.
        /// </summary>
        /// <value>The color table.</value>
        private Dictionary<KnownColors, Color> ColorTable
        {
            get
            {
                if (this.m_dictionaryRGBTable == null)
                {
                    this.m_dictionaryRGBTable = new Dictionary<KnownColors, Color>(0xd4);
                    if ((this.m_basePanel != null) && (this.m_basePanel.ZeroitProColorScheme == ZeroitProColorScheme.Professional))
                    {
                        if ((this.m_bUseSystemColors == true) || (ToolStripManager.VisualStylesEnabled == false))
                        {
                            InitBaseColors(this.m_dictionaryRGBTable);
                        }
                        else
                        {
                            InitColors(this.m_dictionaryRGBTable);
                        }
                    }
                    else
                    {
                        InitCustomColors(this.m_dictionaryRGBTable);
                    }
                }
                return this.m_dictionaryRGBTable;
            }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the PanelColors class.
        /// </summary>
        public PanelColors()
        {
            this.m_professionalColorTable = new System.Windows.Forms.ProfessionalColorTable();
        }
        /// <summary>
        /// Initialize a new instance of the PanelColors class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or xpanderpanel control.</param>
        public PanelColors(BasePanel basePanel) : this()
        {
            this.m_basePanel = basePanel;
        }
        /// <summary>
        /// Clears the current color table
        /// </summary>
		public void Clear()
        {
            ResetRGBTable();
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected virtual void InitColors(Dictionary<KnownColors, Color> rgbTable)
        {
            InitBaseColors(rgbTable);
        }
        #endregion

        #region MethodsPrivate

        /// <summary>
        /// Initializes the base colors.
        /// </summary>
        /// <param name="rgbTable">The RGB table.</param>
        private void InitBaseColors(Dictionary<KnownColors, Color> rgbTable)
        {
            rgbTable[KnownColors.BorderColor] = this.m_professionalColorTable.GripDark;
            rgbTable[KnownColors.InnerBorderColor] = this.m_professionalColorTable.GripLight;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCaptionExpandIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientBegin;
            rgbTable[KnownColors.PanelCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientEnd;
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = this.m_professionalColorTable.ButtonSelectedGradientBegin;
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = this.m_professionalColorTable.ButtonSelectedGradientEnd;
            rgbTable[KnownColors.PanelContentGradientBegin] = this.m_professionalColorTable.ToolStripContentPanelGradientBegin;
            rgbTable[KnownColors.PanelContentGradientEnd] = this.m_professionalColorTable.ToolStripContentPanelGradientEnd;
            rgbTable[KnownColors.PanelCaptionText] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCollapsedCaptionText] = SystemColors.ControlText;
            rgbTable[KnownColors.XPanderPanelBackColor] = this.m_professionalColorTable.ToolStripContentPanelGradientBegin;
            rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.XPanderPanelCaptionText] = SystemColors.ControlText;
            rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientBegin;
            rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientEnd;
            rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientBegin;
            rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = this.m_professionalColorTable.ButtonPressedGradientBegin;
            rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = this.m_professionalColorTable.ButtonPressedGradientEnd;
            rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = this.m_professionalColorTable.ButtonPressedGradientMiddle;
            rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = this.m_professionalColorTable.ButtonCheckedGradientBegin;
            rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = this.m_professionalColorTable.ButtonCheckedGradientEnd;
            rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = this.m_professionalColorTable.ButtonCheckedGradientMiddle;
            rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = this.m_professionalColorTable.ButtonSelectedGradientBegin;
            rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = this.m_professionalColorTable.ButtonSelectedGradientEnd;
            rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = this.m_professionalColorTable.ButtonSelectedGradientMiddle;
            rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = SystemColors.ControlText;
        }

        /// <summary>
        /// Initializes the custom colors.
        /// </summary>
        /// <param name="rgbTable">The RGB table.</param>
        private void InitCustomColors(Dictionary<KnownColors, Color> rgbTable)
        {
            ZeroitProPanel panel = this.m_basePanel as ZeroitProPanel;
            if (panel != null)
            {
                rgbTable[KnownColors.BorderColor] = panel.CustomColors.BorderColor;
                rgbTable[KnownColors.InnerBorderColor] = panel.CustomColors.InnerBorderColor;
                rgbTable[KnownColors.PanelCaptionCloseIcon] = panel.CustomColors.CaptionCloseIcon;
                rgbTable[KnownColors.PanelCaptionExpandIcon] = panel.CustomColors.CaptionExpandIcon;
                rgbTable[KnownColors.PanelCaptionGradientBegin] = panel.CustomColors.CaptionGradientBegin;
                rgbTable[KnownColors.PanelCaptionGradientEnd] = panel.CustomColors.CaptionGradientEnd;
                rgbTable[KnownColors.PanelCaptionGradientMiddle] = panel.CustomColors.CaptionGradientMiddle;
                rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = panel.CustomColors.CaptionSelectedGradientBegin;
                rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = panel.CustomColors.CaptionSelectedGradientEnd;
                rgbTable[KnownColors.PanelContentGradientBegin] = panel.CustomColors.ContentGradientBegin;
                rgbTable[KnownColors.PanelContentGradientEnd] = panel.CustomColors.ContentGradientEnd;
                rgbTable[KnownColors.PanelCaptionText] = panel.CustomColors.CaptionText;
                rgbTable[KnownColors.PanelCollapsedCaptionText] = panel.CustomColors.CollapsedCaptionText;
            }

            XPanderPanel xpanderPanel = this.m_basePanel as XPanderPanel;
            if (xpanderPanel != null)
            {
                rgbTable[KnownColors.BorderColor] = xpanderPanel.CustomColors.BorderColor;
                rgbTable[KnownColors.InnerBorderColor] = xpanderPanel.CustomColors.InnerBorderColor;
                rgbTable[KnownColors.XPanderPanelBackColor] = xpanderPanel.CustomColors.BackColor;
                rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = xpanderPanel.CustomColors.CaptionCloseIcon;
                rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = xpanderPanel.CustomColors.CaptionExpandIcon;
                rgbTable[KnownColors.XPanderPanelCaptionText] = xpanderPanel.CustomColors.CaptionText;
                rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = xpanderPanel.CustomColors.CaptionGradientBegin;
                rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = xpanderPanel.CustomColors.CaptionGradientEnd;
                rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = xpanderPanel.CustomColors.CaptionGradientMiddle;
                rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = xpanderPanel.CustomColors.FlatCaptionGradientBegin;
                rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = xpanderPanel.CustomColors.FlatCaptionGradientEnd;
                rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = xpanderPanel.CustomColors.CaptionPressedGradientBegin;
                rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = xpanderPanel.CustomColors.CaptionPressedGradientEnd;
                rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = xpanderPanel.CustomColors.CaptionPressedGradientMiddle;
                rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = xpanderPanel.CustomColors.CaptionCheckedGradientBegin;
                rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = xpanderPanel.CustomColors.CaptionCheckedGradientEnd;
                rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = xpanderPanel.CustomColors.CaptionCheckedGradientMiddle;
                rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = xpanderPanel.CustomColors.CaptionSelectedGradientBegin;
                rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = xpanderPanel.CustomColors.CaptionSelectedGradientEnd;
                rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = xpanderPanel.CustomColors.CaptionSelectedGradientMiddle;
                rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = xpanderPanel.CustomColors.CaptionSelectedText;
            }
        }

        /// <summary>
        /// Resets the RGB table.
        /// </summary>
        private void ResetRGBTable()
        {
            if (this.m_dictionaryRGBTable != null)
            {
                this.m_dictionaryRGBTable.Clear();
            }
            this.m_dictionaryRGBTable = null;
        }

        #endregion
    }
    #endregion
}
