// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomPanelColors.cs" company="Zeroit Dev Technologies">
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
using System;
using System.ComponentModel;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region CustomPanelColors
    /// <summary>
    /// Class for the custom colors at a Panel control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitProCustomColors" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class CustomPanelColors : ZeroitProCustomColors
    {
        #region FieldsPrivate
        /// <summary>
        /// The m caption selected gradient begin
        /// </summary>
        private Color m_captionSelectedGradientBegin = System.Windows.Forms.ProfessionalColors.ButtonSelectedGradientBegin;
        /// <summary>
        /// The m caption selected gradient end
        /// </summary>
        private Color m_captionSelectedGradientEnd = System.Windows.Forms.ProfessionalColors.ButtonSelectedGradientEnd;
        /// <summary>
        /// The m collapsed caption text
        /// </summary>
        private Color m_collapsedCaptionText = SystemColors.ControlText;
        /// <summary>
        /// The m content gradient begin
        /// </summary>
        private Color m_contentGradientBegin = System.Windows.Forms.ProfessionalColors.ToolStripContentPanelGradientBegin;
        /// <summary>
        /// The m content gradient end
        /// </summary>
        private Color m_contentGradientEnd = System.Windows.Forms.ProfessionalColors.ToolStripContentPanelGradientEnd;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the starting color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        /// <value>The caption selected gradient begin.</value>
        [Description("The starting color of the hover icon in the captionbar on the Panel.")]
        public virtual Color CaptionSelectedGradientBegin
        {
            get { return this.m_captionSelectedGradientBegin; }
            set
            {
                if (value.Equals(this.m_captionSelectedGradientBegin) == false)
                {
                    this.m_captionSelectedGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        /// <value>The caption selected gradient end.</value>
        [Description("The end color of the hover icon in the captionbar on the Panel.")]
        public virtual Color CaptionSelectedGradientEnd
        {
            get { return this.m_captionSelectedGradientEnd; }
            set
            {
                if (value.Equals(this.m_captionSelectedGradientEnd) == false)
                {
                    this.m_captionSelectedGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the text color of a Panel when it's collapsed.
        /// </summary>
        /// <value>The collapsed caption text.</value>
        [Description("The text color of a Panel when it's collapsed.")]
        public virtual Color CollapsedCaptionText
        {
            get { return this.m_collapsedCaptionText; }
            set
            {
                if (value.Equals(this.m_collapsedCaptionText) == false)
                {
                    this.m_collapsedCaptionText = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used in the Panel.
        /// </summary>
        /// <value>The content gradient begin.</value>
        [Description("The starting color of the gradient used in the Panel.")]
        public virtual Color ContentGradientBegin
        {
            get { return this.m_contentGradientBegin; }
            set
            {
                if (value.Equals(this.m_contentGradientBegin) == false)
                {
                    this.m_contentGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used in the Panel.
        /// </summary>
        /// <value>The content gradient end.</value>
        [Description("The end color of the gradient used in the Panel.")]
        public virtual Color ContentGradientEnd
        {
            get { return this.m_contentGradientEnd; }
            set
            {
                if (value.Equals(this.m_contentGradientEnd) == false)
                {
                    this.m_contentGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        #endregion
    }
    #endregion
}
