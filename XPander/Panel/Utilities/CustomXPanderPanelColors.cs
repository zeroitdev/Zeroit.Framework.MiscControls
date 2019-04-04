// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomXPanderPanelColors.cs" company="Zeroit Dev Technologies">
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

    #region CustomXPanderPanelColors
    /// <summary>
    /// Class for the custom colors at a XPanderPanel control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitProCustomColors" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class CustomXPanderPanelColors : ZeroitProCustomColors
    {
        #region FieldsPrivate
        /// <summary>
        /// The m back color
        /// </summary>
        private Color m_backColor = SystemColors.Control;
        /// <summary>
        /// The m flat caption gradient begin
        /// </summary>
        private Color m_flatCaptionGradientBegin = System.Windows.Forms.ProfessionalColors.ToolStripGradientMiddle;
        /// <summary>
        /// The m flat caption gradient end
        /// </summary>
        private Color m_flatCaptionGradientEnd = System.Windows.Forms.ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// The m caption pressed gradient begin
        /// </summary>
        private Color m_captionPressedGradientBegin = System.Windows.Forms.ProfessionalColors.ButtonPressedGradientBegin;
        /// <summary>
        /// The m caption pressed gradient end
        /// </summary>
        private Color m_captionPressedGradientEnd = System.Windows.Forms.ProfessionalColors.ButtonPressedGradientEnd;
        /// <summary>
        /// The m caption pressed gradient middle
        /// </summary>
        private Color m_captionPressedGradientMiddle = System.Windows.Forms.ProfessionalColors.ButtonPressedGradientMiddle;
        /// <summary>
        /// The m caption checked gradient begin
        /// </summary>
        private Color m_captionCheckedGradientBegin = System.Windows.Forms.ProfessionalColors.ButtonCheckedGradientBegin;
        /// <summary>
        /// The m caption checked gradient end
        /// </summary>
        private Color m_captionCheckedGradientEnd = System.Windows.Forms.ProfessionalColors.ButtonCheckedGradientEnd;
        /// <summary>
        /// The m caption checked gradient middle
        /// </summary>
        private Color m_captionCheckedGradientMiddle = System.Windows.Forms.ProfessionalColors.ButtonCheckedGradientMiddle;
        /// <summary>
        /// The m caption selected gradient begin
        /// </summary>
        private Color m_captionSelectedGradientBegin = System.Windows.Forms.ProfessionalColors.ButtonSelectedGradientBegin;
        /// <summary>
        /// The m caption selected gradient end
        /// </summary>
        private Color m_captionSelectedGradientEnd = System.Windows.Forms.ProfessionalColors.ButtonSelectedGradientEnd;
        /// <summary>
        /// The m caption selected gradient middle
        /// </summary>
        private Color m_captionSelectedGradientMiddle = System.Windows.Forms.ProfessionalColors.ButtonSelectedGradientMiddle;
        /// <summary>
        /// The m caption selected text
        /// </summary>
        private Color m_captionSelectedText = SystemColors.ControlText;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the backcolor of a XPanderPanel.
        /// </summary>
        /// <value>The color of the back.</value>
        [Description("The backcolor of a XPanderPanel.")]
        public virtual Color BackColor
        {
            get { return this.m_backColor; }
            set
            {
                if (value.Equals(this.m_backColor) == false)
                {
                    this.m_backColor = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient on a flat XPanderPanel captionbar.
        /// </summary>
        /// <value>The flat caption gradient begin.</value>
        [Description("The starting color of the gradient on a flat XPanderPanel captionbar.")]
        public virtual Color FlatCaptionGradientBegin
        {
            get { return this.m_flatCaptionGradientBegin; }
            set
            {
                if (value.Equals(this.m_flatCaptionGradientBegin) == false)
                {
                    this.m_flatCaptionGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient on a flat XPanderPanel captionbar.
        /// </summary>
        /// <value>The flat caption gradient end.</value>
        [Description("The end color of the gradient on a flat XPanderPanel captionbar.")]
        public virtual Color FlatCaptionGradientEnd
        {
            get { return this.m_flatCaptionGradientEnd; }
            set
            {
                if (value.Equals(this.m_flatCaptionGradientEnd) == false)
                {
                    this.m_flatCaptionGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The caption pressed gradient begin.</value>
        [Description("The starting color of the gradient used when the XPanderPanel is pressed down.")]
        public virtual Color CaptionPressedGradientBegin
        {
            get { return this.m_captionPressedGradientBegin; }
            set
            {
                if (value.Equals(this.m_captionPressedGradientBegin) == false)
                {
                    this.m_captionPressedGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The caption pressed gradient end.</value>
        [Description("The end color of the gradient used when the XPanderPanel is pressed down.")]
        public virtual Color CaptionPressedGradientEnd
        {
            get { return this.m_captionPressedGradientEnd; }
            set
            {
                if (value.Equals(this.m_captionPressedGradientEnd) == false)
                {
                    this.m_captionPressedGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the middle color of the gradient used when the XPanderPanel is pressed down.
        /// </summary>
        /// <value>The caption pressed gradient middle.</value>
        [Description("The middle color of the gradient used when the XPanderPanel is pressed down.")]
        public virtual Color CaptionPressedGradientMiddle
        {
            get { return this.m_captionPressedGradientMiddle; }
            set
            {
                if (value.Equals(this.m_captionPressedGradientMiddle) == false)
                {
                    this.m_captionPressedGradientMiddle = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The caption checked gradient begin.</value>
        [Description("The starting color of the gradient used when the XPanderPanel is checked.")]
        public virtual Color CaptionCheckedGradientBegin
        {
            get { return this.m_captionCheckedGradientBegin; }
            set
            {
                if (value.Equals(this.m_captionCheckedGradientBegin) == false)
                {
                    this.m_captionCheckedGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The caption checked gradient end.</value>
        [Description("The end color of the gradient used when the XPanderPanel is checked.")]
        public virtual Color CaptionCheckedGradientEnd
        {
            get { return this.m_captionCheckedGradientEnd; }
            set
            {
                if (value.Equals(this.m_captionCheckedGradientEnd) == false)
                {
                    this.m_captionCheckedGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the middle color of the gradient used when the XPanderPanel is checked.
        /// </summary>
        /// <value>The caption checked gradient middle.</value>
        [Description("The middle color of the gradient used when the XPanderPanel is checked.")]
        public virtual Color CaptionCheckedGradientMiddle
        {
            get { return this.m_captionCheckedGradientMiddle; }
            set
            {
                if (value.Equals(this.m_captionCheckedGradientMiddle) == false)
                {
                    this.m_captionCheckedGradientMiddle = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The caption selected gradient begin.</value>
        [Description("The starting color of the gradient used when the XPanderPanel is selected.")]
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
        /// Gets or sets the end color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The caption selected gradient end.</value>
        [Description("The end color of the gradient used when the XPanderPanel is selected.")]
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
        /// Gets or sets the middle color of the gradient used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The caption selected gradient middle.</value>
        [Description("The middle color of the gradient used when the XPanderPanel is selected.")]
        public virtual Color CaptionSelectedGradientMiddle
        {
            get { return this.m_captionSelectedGradientMiddle; }
            set
            {
                if (value.Equals(this.m_captionSelectedGradientMiddle) == false)
                {
                    this.m_captionSelectedGradientMiddle = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the text color used when the XPanderPanel is selected.
        /// </summary>
        /// <value>The caption selected text.</value>
        [Description("The text color used when the XPanderPanel is selected.")]
        public virtual Color CaptionSelectedText
        {
            get { return this.m_captionSelectedText; }
            set
            {
                if (value.Equals(this.m_captionSelectedText) == false)
                {
                    this.m_captionSelectedText = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        #endregion
    }
    #endregion

}
