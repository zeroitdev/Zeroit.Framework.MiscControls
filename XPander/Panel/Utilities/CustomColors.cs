// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomColors.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region CustomColors !!!!Already Exists
    /// <summary>
    /// Base class for the custom colors at a panel or xpanderpanel control.
    /// </summary>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    /// <remarks>If you use the <see cref="ZeroitProColorScheme.Custom" /> ZeroitProColorScheme, this is the base class for the custom colors.</remarks>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Description("The colors used in a panel")]
    public class ZeroitProCustomColors
    {
        #region Events
        /// <summary>
        /// Occurs when the value of the CustomColors property changes.
        /// </summary>
        [Description("Occurs when the value of the CustomColors property changes.")]
        public event EventHandler<EventArgs> CustomColorsChanged;
        #endregion

        #region FieldsPrivate
        /// <summary>
        /// The m border color
        /// </summary>
        private Color m_borderColor = System.Windows.Forms.ProfessionalColors.GripDark;
        /// <summary>
        /// The m caption close icon
        /// </summary>
        private Color m_captionCloseIcon = SystemColors.ControlText;
        /// <summary>
        /// The m caption expand icon
        /// </summary>
        private Color m_captionExpandIcon = SystemColors.ControlText;
        /// <summary>
        /// The m caption gradient begin
        /// </summary>
        private Color m_captionGradientBegin = System.Windows.Forms.ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// The m caption gradient end
        /// </summary>
        private Color m_captionGradientEnd = System.Windows.Forms.ProfessionalColors.ToolStripGradientEnd;
        /// <summary>
        /// The m caption gradient middle
        /// </summary>
        private Color m_captionGradientMiddle = System.Windows.Forms.ProfessionalColors.ToolStripGradientMiddle;
        /// <summary>
        /// The m caption text
        /// </summary>
        private Color m_captionText = SystemColors.ControlText;
        /// <summary>
        /// The m inner border color
        /// </summary>
        private Color m_innerBorderColor = System.Windows.Forms.ProfessionalColors.GripLight;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the border color of a Panel or XPanderPanel.
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("The border color of a Panel or XPanderPanel.")]
        public virtual Color BorderColor
        {
            get { return this.m_borderColor; }
            set
            {
                if (value.Equals(this.m_borderColor) == false)
                {
                    this.m_borderColor = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the forecolor of a close icon in a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption close icon.</value>
        [Description("The forecolor of a close icon in a Panel or XPanderPanel.")]
        public virtual Color CaptionCloseIcon
        {
            get { return this.m_captionCloseIcon; }
            set
            {
                if (value.Equals(this.m_captionCloseIcon) == false)
                {
                    this.m_captionCloseIcon = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the forecolor of an expand icon in a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption expand icon.</value>
        [Description("The forecolor of an expand icon in a Panel or XPanderPanel.")]
        public virtual Color CaptionExpandIcon
        {
            get { return this.m_captionExpandIcon; }
            set
            {
                if (value.Equals(this.m_captionExpandIcon) == false)
                {
                    this.m_captionExpandIcon = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient at the caption on a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption gradient begin.</value>
        [Description("The starting color of the gradient at the caption on a Panel or XPanderPanel.")]
        public virtual Color CaptionGradientBegin
        {
            get { return this.m_captionGradientBegin; }
            set
            {
                if (value.Equals(this.m_captionGradientBegin) == false)
                {
                    this.m_captionGradientBegin = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient at the caption on a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption gradient end.</value>
        [Description("The end color of the gradient at the caption on a Panel or XPanderPanel")]
        public virtual Color CaptionGradientEnd
        {
            get { return this.m_captionGradientEnd; }
            set
            {
                if (value.Equals(this.m_captionGradientEnd) == false)
                {
                    this.m_captionGradientEnd = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the middle color of the gradient at the caption on a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption gradient middle.</value>
        [Description("The middle color of the gradient at the caption on a Panel or XPanderPanel.")]
        public virtual Color CaptionGradientMiddle
        {
            get { return this.m_captionGradientMiddle; }
            set
            {
                if (value.Equals(this.m_captionGradientMiddle) == false)
                {
                    this.m_captionGradientMiddle = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the text color at the caption on a Panel or XPanderPanel.
        /// </summary>
        /// <value>The caption text.</value>
        [Description("The text color at the caption on a Panel or XPanderPanel.")]
        public virtual Color CaptionText
        {
            get { return this.m_captionText; }
            set
            {
                if (value.Equals(this.m_captionText) == false)
                {
                    this.m_captionText = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the inner border color of a Panel.
        /// </summary>
        /// <value>The color of the inner border.</value>
        [Description("The inner border color of a Panel.")]
        public virtual Color InnerBorderColor
        {
            get { return this.m_innerBorderColor; }
            set
            {
                if (value.Equals(this.m_innerBorderColor) == false)
                {
                    this.m_innerBorderColor = value;
                    OnCustomColorsChanged(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the CustomColors changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnCustomColorsChanged(object sender, EventArgs e)
        {
            if (this.CustomColorsChanged != null)
            {
                this.CustomColorsChanged(sender, e);
            }
        }
        #endregion
    }
    #endregion
}
