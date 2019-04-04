// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ExtendedPanel.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Extended Panel

    #region Panel

    #region Control

    /// <summary>
    /// A class collection for rendering a panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxBitmapAttribute(typeof(ZeroitExtendedPanel), "ExDotNet.ico")]
    [Designer(typeof(ZeroitExtendedPanelDesigner))]
    public class ZeroitExtendedPanel : System.Windows.Forms.Panel
    {
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Gradient
        /// <summary>
        /// The m color start color
        /// </summary>
        private Color m_color_StartColor = Color.FromKnownColor(KnownColor.InactiveCaptionText);
        /// <summary>
        /// The m color end color
        /// </summary>
        private Color m_color_EndColor = Color.FromKnownColor(KnownColor.InactiveCaption);
        /// <summary>
        /// The m gradient mode
        /// </summary>
        private System.Drawing.Drawing2D.LinearGradientMode m_GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the starting color of the gradient background.
        /// </summary>
        /// <value>The gradient start.</value>
        [Description("The starting color of the gradient background"), Category("_Gradient"), Browsable(true)]
        public Color GradientStart
        {
            get
            {
                return m_color_StartColor;
            }
            set
            {
                m_color_StartColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end color of the gradient background.
        /// </summary>
        /// <value>The gradient end.</value>
        [Description("The end color of the gradient background"), Category("_Gradient"), Browsable(true)]
        public Color GradientEnd
        {
            get
            {
                return m_color_EndColor;
            }
            set
            {
                m_color_EndColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient direction.
        /// </summary>
        /// <value>The gradient direction.</value>
        [Description("The gradient direction"), Category("_Gradient"), Browsable(true)]
        public System.Drawing.Drawing2D.LinearGradientMode GradientDirection
        {
            get
            {
                return m_GradientMode;
            }
            set
            {
                m_GradientMode = value;
                Invalidate();
            }
        }
        #endregion

        #region Border
        /// <summary>
        /// The m border style
        /// </summary>
        private ExtendedBorderStyle m_BorderStyle = ExtendedBorderStyle.Single;
        /// <summary>
        /// The m int border width
        /// </summary>
        private int m_int_BorderWidth = 1;
        /// <summary>
        /// The m bool border
        /// </summary>
        private bool m_bool_Border = true;
        /// <summary>
        /// The m color border color
        /// </summary>
        private Color m_color_BorderColor = Color.FromKnownColor(KnownColor.ActiveCaption);

        /// <summary>
        /// Gets or sets the style of the border.
        /// </summary>
        /// <value>The style style of the border.</value>
        [Description("The style of the border"), Category("_Border"), Browsable(true)]
        public ExtendedBorderStyle Style
        {
            get
            {
                return m_BorderStyle;
            }
            set
            {
                m_BorderStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Description("The width in pixels of the border"), Category("_Border"), Browsable(true)]
        public int BorderWidth
        {
            get
            {
                return m_int_BorderWidth;
            }
            set
            {
                m_int_BorderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedPanel" /> should have its border drawn.
        /// </summary>
        /// <value><c>true</c> if border; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable border"), Category("_Border"), Browsable(true)]
        public bool Border
        {
            get
            {
                return m_bool_Border;
            }
            set
            {
                m_bool_Border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("The color of the border"), Category("_Border"), Browsable(true)]
        public Color BorderColor
        {
            get
            {
                return m_color_BorderColor;
            }
            set
            {
                m_color_BorderColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Caption

        /// <summary>
        /// The m string caption
        /// </summary>
        private String m_str_Caption = "Panel";
        /// <summary>
        /// The m bool caption
        /// </summary>
        private bool m_bool_Caption = true;
        /// <summary>
        /// The m int caption height
        /// </summary>
        private int m_int_CaptionHeight = 24;
        /// <summary>
        /// The m color caption begin color
        /// </summary>
        private Color m_color_CaptionBeginColor = Color.FromArgb(255, 225, 155);
        /// <summary>
        /// The m color caption end color
        /// </summary>
        private Color m_color_CaptionEndColor = Color.FromArgb(255, 165, 78);
        /// <summary>
        /// The m color caption text color
        /// </summary>
        private Color m_color_CaptionTextColor = Color.FromArgb(0, 0, 0);
        /// <summary>
        /// The m bool antialias
        /// </summary>
        private bool m_bool_Antialias = true;
        /// <summary>
        /// The m caption gradient mode
        /// </summary>
        private System.Drawing.Drawing2D.LinearGradientMode m_CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        /// <summary>
        /// The m string alignment
        /// </summary>
        private System.Drawing.StringAlignment m_StringAlignment = System.Drawing.StringAlignment.Near;

        /// <summary>
        /// Gets or sets the caption text alignment.
        /// </summary>
        /// <value>The caption text alignment.</value>
        [Description("The gradient direction"), Category("_Caption"), Browsable(true)]
        public System.Drawing.StringAlignment CaptionTextAlignment
        {
            get
            {
                return m_StringAlignment;
            }
            set
            {
                m_StringAlignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the caption gradient direction.
        /// </summary>
        /// <value>The caption gradient direction.</value>
        [Description("The gradient direction"), Category("_Caption"), Browsable(true)]
        public System.Drawing.Drawing2D.LinearGradientMode CaptionGradientDirection
        {
            get
            {
                return m_CaptionGradientMode;
            }
            set
            {
                m_CaptionGradientMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether text anti-alias to be enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if text antialias; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable antialiasing"), Category("_Caption"), Browsable(true)]
        public bool TextAntialias
        {
            get
            {
                return m_bool_Antialias;
            }
            set
            {
                m_bool_Antialias = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the caption text.
        /// </summary>
        /// <value>The caption text.</value>
        [Description("The caption"), Category("_Caption"), Browsable(true)]
        public String CaptionText
        {
            get
            {
                return m_str_Caption;
            }
            set
            {
                m_str_Caption = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedPanel" /> should enable/disable caption.
        /// </summary>
        /// <value><c>true</c> if caption; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable the caption"), Category("_Caption"), Browsable(true)]
        public bool Caption
        {
            get
            {
                return m_bool_Caption;
            }
            set
            {
                m_bool_Caption = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the caption.
        /// </summary>
        /// <value>The height of the caption.</value>
        [Description("Change the caption height"), Category("_Caption"), Browsable(true)]
        public int CaptionHeight
        {
            get
            {
                return m_int_CaptionHeight;
            }
            set
            {
                m_int_CaptionHeight = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption's begining.
        /// </summary>
        /// <value>The color of the caption begin.</value>
        [Description("Change the caption begincolor"), Category("_Caption"), Browsable(true)]
        public Color CaptionBeginColor
        {
            get
            {
                return m_color_CaptionBeginColor;
            }
            set
            {
                m_color_CaptionBeginColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end color of the caption.
        /// </summary>
        /// <value>The end color of the caption.</value>
        [Description("Change the caption endcolor"), Category("_Caption"), Browsable(true)]
        public Color CaptionEndColor
        {
            get
            {
                return m_color_CaptionEndColor;
            }
            set
            {
                m_color_CaptionEndColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        [Description("Change the caption textcolor"), Category("_Caption"), Browsable(true)]
        public Color CaptionTextColor
        {
            get
            {
                return m_color_CaptionTextColor;
            }
            set
            {
                m_color_CaptionTextColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Description("Change the caption textcolor"), Category("_Caption"), Browsable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }


        #endregion

        #region Icon

        /// <summary>
        /// The m icon
        /// </summary>
        private System.Drawing.Icon m_Icon = null;
        /// <summary>
        /// The m bool icon
        /// </summary>
        private bool m_bool_Icon = false;

        /// <summary>
        /// Gets or sets the panel icon to display in the title.
        /// </summary>
        /// <value>The panel icon.</value>
        [Description("The icon to display in the title"), Category("_Icon"), Browsable(true)]
        public Icon PanelIcon
        {
            get
            {
                return m_Icon;
            }
            set
            {
                m_Icon = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show icon or not.
        /// </summary>
        /// <value><c>true</c> if icon visible; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable the icon"), Category("_Icon"), Browsable(true)]
        public bool IconVisible
        {
            get
            {
                return m_bool_Icon;
            }
            set
            {
                if (value == true && m_Icon == null)
                {
                    MessageBox.Show("Make sure you choose an icon before you select this option. \n \n" +
                        "A default icon will be selected at this point. Change it to your preferred icon. \n \n" +
                        "Happy Coding.");
                    m_Icon = Properties.Resources.help;
                }
                m_bool_Icon = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor        

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitExtendedPanel" /> class.
        /// </summary>
        public ZeroitExtendedPanel()
        {
            InitializeComponent();

            this.Font = new Font("Arial", 14);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }

        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        #region Painting
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // The painting with shadow is slightly different...
            if (m_BorderStyle == ExtendedBorderStyle.Shadow)
            {
                // fill the background
                System.Drawing.Drawing2D.LinearGradientBrush brsh = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, this.Width - 5, this.Height - 5), m_color_StartColor, m_color_EndColor, m_GradientMode);
                e.Graphics.FillRectangle(brsh, 0, 0, this.Width - 5, this.Height - 5);

                // draw the border
                System.Drawing.Pen pen = new Pen(m_color_BorderColor);
                for (int i = 0; i < m_int_BorderWidth; i++)
                {
                    e.Graphics.DrawRectangle(pen, i, i, this.Width - 6 - (i * 2), this.Height - 6 - (i * 2));
                }

                // draw the caption bar
                if (m_bool_Caption)
                {
                    if (m_bool_Antialias) e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    System.Drawing.Drawing2D.LinearGradientBrush brsh_Caption = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(m_int_BorderWidth, m_int_BorderWidth, this.Width - 5 - (m_int_BorderWidth * 2), m_int_CaptionHeight), m_color_CaptionBeginColor, m_color_CaptionEndColor, m_CaptionGradientMode);
                    e.Graphics.FillRectangle(brsh_Caption, m_int_BorderWidth, m_int_BorderWidth, this.Width - 5 - (m_int_BorderWidth * 2), m_int_CaptionHeight);
                    StringFormat format = new StringFormat();
                    format.FormatFlags = StringFormatFlags.NoWrap;
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = m_StringAlignment;
                    format.Trimming = StringTrimming.EllipsisCharacter;
                    e.Graphics.DrawString(
                        m_str_Caption,
                        this.Font,
                        new SolidBrush(m_color_CaptionTextColor),
                        new Rectangle(
                        // LEFT
                        (m_BorderStyle != ExtendedBorderStyle.None) ?
                        (m_bool_Icon ?
                        m_int_BorderWidth + m_Icon.Width + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2))
                        :
                        m_int_BorderWidth)
                        :
                        (m_bool_Icon ?
                        m_Icon.Width + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2))
                        :
                        0),
                        // TOP
                        (m_BorderStyle != ExtendedBorderStyle.None) ?
                    m_int_BorderWidth
                        :
                        0,
                        // WIDTH
                        (m_BorderStyle != ExtendedBorderStyle.None) ?
                        (m_bool_Icon ?
                        this.Width - (m_int_BorderWidth * 2) - ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)) - m_Icon.Width - 5
                        :
                        this.Width - (m_int_BorderWidth * 2)) - 5
                        :
                        (m_bool_Icon ?
                        this.Width - ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)) - m_Icon.Width - 5
                        :
                        this.Width) - 5,
                        // HEIGHT
                        m_int_CaptionHeight)
                        , format);
                }

                // draw the shadow
                Pen pen1 = new Pen(Color.FromArgb(142, 142, 142), 1.0f);
                Pen pen2 = new Pen(Color.FromArgb(171, 171, 171), 1.0f);
                Pen pen3 = new Pen(Color.FromArgb(212, 212, 212), 1.0f);
                Pen pen4 = new Pen(Color.FromArgb(241, 241, 241), 1.0f);

                e.Graphics.DrawLine(pen1, this.Width - 5, 2, this.Width - 5, this.Height - 5);
                e.Graphics.DrawLine(pen2, this.Width - 4, 4, this.Width - 4, this.Height - 4);
                e.Graphics.DrawLine(pen3, this.Width - 3, 6, this.Width - 3, this.Height - 3);
                e.Graphics.DrawLine(pen4, this.Width - 2, 8, this.Width - 2, this.Height - 2);

                e.Graphics.DrawLine(pen1, 2, this.Height - 5, this.Width - 5, this.Height - 5);
                e.Graphics.DrawLine(pen2, 4, this.Height - 4, this.Width - 4, this.Height - 4);
                e.Graphics.DrawLine(pen3, 6, this.Height - 3, this.Width - 3, this.Height - 3);
                e.Graphics.DrawLine(pen4, 8, this.Height - 2, this.Width - 2, this.Height - 2);
            }
            else
            {
                // fill the background
                System.Drawing.Drawing2D.LinearGradientBrush brsh = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), m_color_StartColor, m_color_EndColor, m_GradientMode);
                e.Graphics.FillRectangle(brsh, 0, 0, this.Width, this.Height);

                // draw the border
                switch (m_BorderStyle)
                {
                    case ExtendedBorderStyle.Single:
                        {
                            System.Drawing.Pen pen = new Pen(m_color_BorderColor);
                            for (int i = 0; i < m_int_BorderWidth; i++)
                            {
                                e.Graphics.DrawRectangle(pen, i, i, this.Width - 1 - (i * 2), this.Height - 1 - (i * 2));
                            }
                            break;
                        }
                    case ExtendedBorderStyle.Raised3D:
                        {
                            break;
                        }
                }

                // draw caption bar
                if (m_bool_Caption)
                {
                    if (m_bool_Antialias) e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    System.Drawing.Drawing2D.LinearGradientBrush brsh_Caption = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle((m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0, (m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0, (m_BorderStyle != ExtendedBorderStyle.None) ? this.Width - (m_int_BorderWidth * 2) : this.Width, m_int_CaptionHeight), m_color_CaptionBeginColor, m_color_CaptionEndColor, m_CaptionGradientMode);
                    e.Graphics.FillRectangle(brsh_Caption, (m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0, (m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0, (m_BorderStyle != ExtendedBorderStyle.None) ? this.Width - (m_int_BorderWidth * 2) : this.Width, m_int_CaptionHeight);
                    StringFormat format = new StringFormat();
                    format.FormatFlags = StringFormatFlags.NoWrap;
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = m_StringAlignment;
                    format.Trimming = StringTrimming.EllipsisCharacter;
                    e.Graphics.DrawString(
                        m_str_Caption,
                        this.Font,
                        new SolidBrush(m_color_CaptionTextColor),
                        new Rectangle(
                            // LEFT
                            (m_BorderStyle != ExtendedBorderStyle.None) ?
                            (m_bool_Icon ?
                                m_int_BorderWidth + m_Icon.Width + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2))
                                :
                                m_int_BorderWidth)
                            :
                            (m_bool_Icon ?
                                m_Icon.Width + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2))
                                :
                                0),
                            // TOP
                            (m_BorderStyle != ExtendedBorderStyle.None) ?
                                m_int_BorderWidth
                                :
                                0,
                            // WIDTH
                            (m_BorderStyle != ExtendedBorderStyle.None) ?
                                (m_bool_Icon ?
                                    this.Width - (m_int_BorderWidth * 2) - ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)) - m_Icon.Width
                                    :
                                    this.Width - (m_int_BorderWidth * 2))
                                :
                                (m_bool_Icon ?
                                    this.Width - ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)) - m_Icon.Width
                                    :
                                    this.Width),
                            // HEIGHT
                            m_int_CaptionHeight)
                            , format);
                }
            }

            // draw the icon
            if (m_bool_Icon && m_bool_Caption)
            {
                e.Graphics.DrawIcon(m_Icon, ((m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0) + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)), ((m_BorderStyle != ExtendedBorderStyle.None) ? m_int_BorderWidth : 0) + ((m_int_CaptionHeight / 2) - (m_Icon.Height / 2)));
            }

            base.OnPaint(e);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitExtendedPanelDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitExtendedPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitExtendedPanelDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitExtendedPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitExtendedPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitExtendedPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitExtendedPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitExtendedPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitExtendedPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitExtendedPanel;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedPanelSmartTagActionList"/> is border.
        /// </summary>
        /// <value><c>true</c> if border; otherwise, <c>false</c>.</value>
        public bool Border
        {
            get
            {
                return colUserControl.Border;
            }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedPanelSmartTagActionList"/> is caption.
        /// </summary>
        /// <value><c>true</c> if caption; otherwise, <c>false</c>.</value>
        public bool Caption
        {
            get
            {
                return colUserControl.Caption;
            }
            set
            {
                GetPropertyByName("Caption").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text antialias].
        /// </summary>
        /// <value><c>true</c> if [text antialias]; otherwise, <c>false</c>.</value>
        public bool TextAntialias
        {
            get
            {
                return colUserControl.TextAntialias;
            }
            set
            {
                GetPropertyByName("TextAntialias").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [icon visible].
        /// </summary>
        /// <value><c>true</c> if [icon visible]; otherwise, <c>false</c>.</value>
        public bool IconVisible
        {
            get
            {
                return colUserControl.IconVisible;
            }
            set
            {
                GetPropertyByName("IconVisible").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public ExtendedBorderStyle Style
        {
            get
            {
                return colUserControl.Style;
            }
            set
            {
                GetPropertyByName("Style").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return colUserControl.BorderWidth;
            }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption text alignment.
        /// </summary>
        /// <value>The caption text alignment.</value>
        public System.Drawing.StringAlignment CaptionTextAlignment
        {
            get
            {
                return colUserControl.CaptionTextAlignment;
            }
            set
            {
                GetPropertyByName("CaptionTextAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption gradient direction.
        /// </summary>
        /// <value>The caption gradient direction.</value>
        public System.Drawing.Drawing2D.LinearGradientMode CaptionGradientDirection
        {
            get
            {
                return colUserControl.CaptionGradientDirection;
            }
            set
            {
                GetPropertyByName("CaptionGradientDirection").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption text.
        /// </summary>
        /// <value>The caption text.</value>
        public String CaptionText
        {
            get
            {
                return colUserControl.CaptionText;
            }
            set
            {
                GetPropertyByName("CaptionText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the caption.
        /// </summary>
        /// <value>The height of the caption.</value>
        public int CaptionHeight
        {
            get
            {
                return colUserControl.CaptionHeight;
            }
            set
            {
                GetPropertyByName("CaptionHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption begin.
        /// </summary>
        /// <value>The color of the caption begin.</value>
        public Color CaptionBeginColor
        {
            get
            {
                return colUserControl.CaptionBeginColor;
            }
            set
            {
                GetPropertyByName("CaptionBeginColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the end color of the caption.
        /// </summary>
        /// <value>The end color of the caption.</value>
        public Color CaptionEndColor
        {
            get
            {
                return colUserControl.CaptionEndColor;
            }
            set
            {
                GetPropertyByName("CaptionEndColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        public Color CaptionTextColor
        {
            get
            {
                return colUserControl.CaptionTextColor;
            }
            set
            {
                GetPropertyByName("CaptionTextColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the panel icon.
        /// </summary>
        /// <value>The panel icon.</value>
        public Icon PanelIcon
        {
            get
            {
                return colUserControl.PanelIcon;
            }
            set
            {
                GetPropertyByName("PanelIcon").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("Border",
                                 "Border", "Appearance",
                                 "Set to enable the border."));

            items.Add(new DesignerActionPropertyItem("Caption",
                                 "Caption", "Appearance",
                                 "Set to enable caption."));

            items.Add(new DesignerActionPropertyItem("TextAntialias",
                                 "Text Anti alias", "Appearance",
                                 "Set to text anti anti alias."));

            items.Add(new DesignerActionPropertyItem("IconVisible",
                                 "Icon Visible", "Appearance",
                                 "Set to enable icon."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("CaptionBeginColor",
                                 "Caption Begin Color", "Appearance",
                                 "Sets to caption color."));

            items.Add(new DesignerActionPropertyItem("CaptionEndColor",
                                 "Caption End Color", "Appearance",
                                 "Sets the caption color."));

            items.Add(new DesignerActionPropertyItem("CaptionTextColor",
                                 "Caption Text Color", "Appearance",
                                 "Sets the caption text color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("Style",
                                 "Style", "Appearance",
                                 "Sets the style of the panel."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "Border Width", "Appearance",
                                 "Sets the border width."));

            items.Add(new DesignerActionPropertyItem("CaptionTextAlignment",
                                 "Caption Text Alignment", "Appearance",
                                 "Sets the caption text alignment."));

            items.Add(new DesignerActionPropertyItem("CaptionGradientDirection",
                                 "Caption Gradient Direction", "Appearance",
                                 "Sets the caption gradient direction."));

            items.Add(new DesignerActionPropertyItem("CaptionText",
                                 "Caption Text", "Appearance",
                                 "Sets the caption text."));

            items.Add(new DesignerActionPropertyItem("CaptionHeight",
                                 "Caption Height", "Appearance",
                                 "Sets the caption height."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the font."));

            items.Add(new DesignerActionPropertyItem("PanelIcon",
                                 "Panel Icon", "Appearance",
                                 "Select the icon to use."));


            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion

    #region Enums

    /// <summary>
    /// Enum representing Extended BorderStyle
    /// </summary>
    public enum ExtendedBorderStyle
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The single
        /// </summary>
        Single,
        /// <summary>
        /// The raised3 d
        /// </summary>
        Raised3D,
        /// <summary>
        /// The sunken3 d
        /// </summary>
        Sunken3D,
        /// <summary>
        /// The shadow
        /// </summary>
        Shadow
    };

    /// <summary>
    /// Enum representing the Extended Orientation
    /// </summary>
    public enum ExtendedOrientation
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical
    };

    #endregion

    #region Progress Bar

    //#region Enum
    ////#####
    //public enum ProgressCaptionMode
    //{
    //    None,
    //    Percent,
    //    Value,
    //    Custom
    //}
    ////#####
    //public enum ProgressFloodStyle
    //{
    //    Standard,
    //    Horizontal
    //}
    ////#####
    //public enum ProgressBarEdge
    //{
    //    None,
    //    Rectangle,
    //    Rounded
    //}
    ////#####
    //public enum ProgressBarDirection
    //{
    //    Horizontal,
    //    Vertical
    //}
    ////#####
    //public enum ProgressStyle
    //{
    //    Dashed,
    //    Solid
    //}
    ////#####
    //#endregion

    //#region Control
    //[ToolboxBitmapAttribute(typeof(ZeroitExtendedProgressBar), "ExDotNet.ico")]
    //public class ZeroitExtendedProgressBar : System.Windows.Forms.UserControl
    //{
    //    private System.ComponentModel.Container components = null;

    //    #region Direction
    //    //#####
    //    private bool m_bool_Invert = false;
    //    [Description("Invert the progress direction")]
    //    [Category("_Orientation")]
    //    [Browsable(true)]
    //    public bool Invert
    //    {
    //        get
    //        {
    //            return m_bool_Invert;
    //        }
    //        set
    //        {
    //            m_bool_Invert = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private ProgressBarDirection m_Direction = ProgressBarDirection.Horizontal;
    //    [Description("Set the progress control horizontal or vertical")]
    //    [Category("_Orientation")]
    //    [Browsable(true)]
    //    public ProgressBarDirection Orientation
    //    {
    //        get
    //        {
    //            return m_Direction;
    //        }
    //        set
    //        {
    //            m_Direction = value;
    //            Invalidate();
    //        }
    //    }
    //    #endregion

    //    #region Edge
    //    //#####
    //    private ProgressBarEdge m_Edge = ProgressBarEdge.Rounded;
    //    [Description("Set the edge of the control")]
    //    [Category("_Edge")]
    //    [Browsable(true)]
    //    public ProgressBarEdge Edge
    //    {
    //        get
    //        {
    //            return m_Edge;
    //        }
    //        set
    //        {
    //            m_Edge = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_EdgeColor = Color.FromKnownColor(KnownColor.Gray);
    //    [Description("Set the edge color")]
    //    [Category("_Edge")]
    //    [Browsable(true)]
    //    public Color EdgeColor
    //    {
    //        get
    //        {
    //            return m_EdgeColor;
    //        }
    //        set
    //        {
    //            m_EdgeColor = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_EdgeLightColor = Color.FromKnownColor(KnownColor.LightGray);
    //    [Description("Set the edge light color")]
    //    [Category("_Edge")]
    //    [Browsable(true)]
    //    public Color EdgeLightColor
    //    {
    //        get
    //        {
    //            return m_EdgeLightColor;
    //        }
    //        set
    //        {
    //            m_EdgeLightColor = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private int m_EdgeWidth = 1;
    //    [Description("Set the edge width")]
    //    [Category("_Edge")]
    //    [Browsable(true)]
    //    public int EdgeWidth
    //    {
    //        get
    //        {
    //            return m_EdgeWidth;
    //        }
    //        set
    //        {
    //            m_EdgeWidth = value;
    //            if (m_EdgeWidth < 0) m_EdgeWidth = 0;
    //            if (m_EdgeWidth > Int16.MaxValue) m_EdgeWidth = Int16.MaxValue;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    #endregion

    //    #region Progress
    //    //#####
    //    private ProgressFloodStyle m_FloodStyle = ProgressFloodStyle.Standard;
    //    [Description("Set the floodstyle. Standard draws a standard xp-themed progressbar, and with Horizontal you can create a horizontal flood bar (for the best effect, set FloodPercentage to 1.0.")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public ProgressFloodStyle FloodStyle
    //    {
    //        get
    //        {
    //            return m_FloodStyle;
    //        }
    //        set
    //        {
    //            m_FloodStyle = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private float m_float_BarFlood = 0.20f;
    //    [Description("Set the percentage of the flood color, a value between 0.0 and 1.0.")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public float FloodPercentage
    //    {
    //        get
    //        {
    //            return m_float_BarFlood;
    //        }
    //        set
    //        {
    //            m_float_BarFlood = value;
    //            if (m_float_BarFlood < 0.0f) m_float_BarFlood = 0.0f;
    //            if (m_float_BarFlood > 1.0f) m_float_BarFlood = 1.0f;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private int m_int_BarOffset = 1;
    //    [Description("Set the offset for the left, top, right and bottom")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public int BarOffset
    //    {
    //        get
    //        {
    //            return m_int_BarOffset;
    //        }
    //        set
    //        {
    //            m_int_BarOffset = value;
    //            if (m_int_BarOffset < 0) m_int_BarOffset = 0;
    //            if (m_int_BarOffset > Int16.MaxValue) m_int_BarOffset = Int16.MaxValue;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private int m_int_DashWidth = 5;
    //    [Description("Set the width of a dash if Dashed mode")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public int DashWidth
    //    {
    //        get
    //        {
    //            return m_int_DashWidth;
    //        }
    //        set
    //        {
    //            m_int_DashWidth = value;
    //            if (m_int_DashWidth < 0) m_int_DashWidth = 0;
    //            if (m_int_DashWidth > Int16.MaxValue) m_int_DashWidth = Int16.MaxValue;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private int m_int_DashSpace = 2;
    //    [Description("Set the space between every dash if Dashed mode")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public int DashSpace
    //    {
    //        get
    //        {
    //            return m_int_DashSpace;
    //        }
    //        set
    //        {
    //            m_int_DashSpace = value;
    //            if (m_int_DashSpace < 0) m_int_DashSpace = 0;
    //            if (m_int_DashSpace > Int16.MaxValue) m_int_DashSpace = Int16.MaxValue;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private ProgressStyle m_Style = ProgressStyle.Dashed;
    //    [Description("Set progressbar style")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public ProgressStyle ProgressBarStyle
    //    {
    //        get
    //        {
    //            return m_Style;
    //        }
    //        set
    //        {
    //            m_Style = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_Color1 = Color.FromArgb(0, 255, 0);
    //    [Description("Set the main color")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public Color MainColor
    //    {
    //        get
    //        {
    //            return m_Color1;
    //        }
    //        set
    //        {
    //            m_Color1 = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_Color2 = Color.FromKnownColor(KnownColor.White);
    //    [Description("Set the second color")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public Color SecondColor
    //    {
    //        get
    //        {
    //            return m_Color2;
    //        }
    //        set
    //        {
    //            m_Color2 = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_color_Back = Color.FromKnownColor(KnownColor.White);
    //    [Description("Set the background color")]
    //    [Category("_Progress")]
    //    [Browsable(true)]
    //    public Color ProgressBackColor
    //    {
    //        get
    //        {
    //            return m_color_Back;
    //        }
    //        set
    //        {
    //            m_color_Back = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    #endregion

    //    #region Properties
    //    private int m_int_Minimum = 0;
    //    [Description("Set the minimum value of this progress control")]
    //    [Category("Properties")]
    //    [Browsable(true)]
    //    public int Minimum
    //    {
    //        get
    //        {
    //            return m_int_Minimum;
    //        }
    //        set
    //        {
    //            if (value < m_int_Maximum) m_int_Minimum = value;
    //            Invalidate();
    //        }
    //    }
    //    private int m_int_Maximum = 100;
    //    [Description("Set the maximum value of this progress control")]
    //    [Category("Properties")]
    //    [Browsable(true)]
    //    public int Maximum
    //    {
    //        get
    //        {
    //            return m_int_Maximum;
    //        }
    //        set
    //        {
    //            if (value > m_int_Minimum) m_int_Maximum = value;
    //            Invalidate();
    //        }
    //    }
    //    private int m_int_Value = 33;
    //    [Description("Set the current value of this progress control")]
    //    [Category("Properties")]
    //    [Browsable(true)]
    //    public int Value
    //    {
    //        get
    //        {
    //            return m_int_Value;
    //        }
    //        set
    //        {
    //            m_int_Value = value;
    //            if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
    //            if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
    //            Invalidate();
    //        }
    //    }
    //    private int m_int_Step = 1;
    //    [Description("Set the step value")]
    //    [Category("Properties")]
    //    [Browsable(true)]
    //    public int Step
    //    {
    //        get
    //        {
    //            return m_int_Step;
    //        }
    //        set
    //        {
    //            m_int_Step = value;
    //            Invalidate();
    //        }
    //    }
    //    #endregion

    //    #region Constructor
    //    public ZeroitExtendedProgressBar()
    //    {
    //        InitializeComponent();

    //        this.SetStyle(ControlStyles.UserPaint, true);
    //        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //        this.SetStyle(ControlStyles.DoubleBuffer, true);
    //    }
    //    #endregion

    //    #region Caption
    //    [Description("Change the font")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public override Font Font
    //    {
    //        get
    //        {
    //            return base.Font;
    //        }
    //        set
    //        {
    //            base.Font = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private bool m_bool_Shadow = true;
    //    [Description("Enable/Disable shadow")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public bool Shadow
    //    {
    //        get
    //        {
    //            return m_bool_Shadow;
    //        }
    //        set
    //        {
    //            m_bool_Shadow = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private int m_int_ShadowOffset = 1;
    //    [Description("Set shadow offset")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public int ShadowOffset
    //    {
    //        get
    //        {
    //            return m_int_ShadowOffset;
    //        }
    //        set
    //        {
    //            m_int_ShadowOffset = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private bool m_bool_Antialias = true;
    //    [Description("Enable/Disable antialiasing")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public bool TextAntialias
    //    {
    //        get
    //        {
    //            return m_bool_Antialias;
    //        }
    //        set
    //        {
    //            m_bool_Antialias = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_color_Shadow = Color.FromKnownColor(KnownColor.White);
    //    [Description("Set the caption shadow color.")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public Color CaptionShadowColor
    //    {
    //        get
    //        {
    //            return m_color_Shadow;
    //        }
    //        set
    //        {
    //            m_color_Shadow = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private Color m_color_Caption = Color.FromKnownColor(KnownColor.Black);
    //    [Description("Set the caption color.")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public Color CaptionColor
    //    {
    //        get
    //        {
    //            return m_color_Caption;
    //        }
    //        set
    //        {
    //            m_color_Caption = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private ProgressCaptionMode m_CaptionMode = ProgressCaptionMode.Percent;
    //    [Description("Set the caption mode.")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public ProgressCaptionMode CaptionMode
    //    {
    //        get
    //        {
    //            return m_CaptionMode;
    //        }
    //        set
    //        {
    //            m_CaptionMode = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    private String m_str_Caption = "Progress";
    //    [Description("Set the caption.")]
    //    [Category("_Caption")]
    //    [Browsable(true)]
    //    public String Caption
    //    {
    //        get
    //        {
    //            return m_str_Caption;
    //        }
    //        set
    //        {
    //            m_str_Caption = value;
    //            Invalidate();
    //        }
    //    }
    //    //#####
    //    #endregion

    //    #region Custom
    //    //#####
    //    private bool m_bool_ChangeByMouse = false;
    //    [Description("Allows the user to change the value by clicking the mouse")]
    //    [Category("_Custom")]
    //    [Browsable(true)]
    //    public bool ChangeByMouse
    //    {
    //        get
    //        {
    //            return m_bool_ChangeByMouse;
    //        }
    //        set
    //        {
    //            m_bool_ChangeByMouse = value;
    //            Invalidate();
    //        }
    //    }
    //    #endregion

    //    #region GetCustomCaption
    //    private String GetCustomCaption(String caption)
    //    {
    //        float float_Percentage = ((float)(m_int_Value - m_int_Minimum) / (float)(m_int_Maximum - m_int_Minimum)) * 100.0f;

    //        String toReturn = caption.Replace("<VALUE>", m_int_Value.ToString());
    //        toReturn = caption.Replace("<PERCENTAGE>", float_Percentage.ToString());

    //        return toReturn;
    //    }
    //    #endregion

    //    #region User Methods
    //    public void PerformStep()
    //    {
    //        m_int_Value += m_int_Step;
    //        if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
    //        if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
    //    }

    //    public void Increment(int val)
    //    {
    //        m_int_Value += val;
    //        if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
    //        if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
    //    }
    //    #endregion

    //    #region Overrides
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        #region OnPaint - Draw Background
    //        SolidBrush brsh = new SolidBrush(m_color_Back);
    //        e.Graphics.FillRectangle(brsh, 0, 0, this.Width, this.Height);
    //        #endregion

    //        #region OnPaint - Draw ProgressBar
    //        switch (m_Direction)
    //        {
    //            #region Horizontal
    //            case ProgressBarDirection.Horizontal:
    //                {
    //                    float float_ProgressHeight = (float)(this.Height - m_EdgeWidth * 2 - m_int_BarOffset * 2);
    //                    float float_ProgressTotalWidth = this.Width - m_EdgeWidth * 2 - m_int_BarOffset * 2;
    //                    float float_ProgressDrawWidth = float_ProgressTotalWidth / (float)(m_int_Maximum - m_int_Minimum) * (float)(m_int_Value - m_int_Minimum);

    //                    int int_NumberOfDashes = (int)(float_ProgressDrawWidth / (float)(m_int_DashWidth + m_int_DashSpace));
    //                    int int_TotalDashes = (int)(float_ProgressTotalWidth / (float)(m_int_DashWidth + m_int_DashSpace));

    //                    Rectangle rect_Bar2 = new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset, (int)float_ProgressTotalWidth, (int)float_ProgressHeight);
    //                    Rectangle rect_Bar;
    //                    if (m_bool_Invert)
    //                    {
    //                        rect_Bar = new Rectangle(
    //                                  m_EdgeWidth + m_int_BarOffset + (int)(float_ProgressTotalWidth - float_ProgressDrawWidth)
    //                                , m_EdgeWidth + m_int_BarOffset
    //                                , (int)float_ProgressDrawWidth
    //                                , (int)float_ProgressHeight);
    //                    }
    //                    else
    //                    {
    //                        rect_Bar = new Rectangle(
    //                                  m_EdgeWidth + m_int_BarOffset
    //                                , m_EdgeWidth + m_int_BarOffset
    //                                , (int)float_ProgressDrawWidth
    //                                , (int)float_ProgressHeight);
    //                    }

    //                    LinearGradientBrush brsh_Bar = new LinearGradientBrush(rect_Bar2, m_Color2, m_Color1, (m_FloodStyle == ProgressFloodStyle.Standard) ? 90.0f : 0.0f);
    //                    float[] factors = { 0.0f, 1.0f, 1.0f, 0.0f };
    //                    float[] positions = { 0.0f, m_float_BarFlood, 1.0f - m_float_BarFlood, 1.0f };

    //                    Blend blend = new Blend();
    //                    blend.Factors = factors;
    //                    blend.Positions = positions;
    //                    brsh_Bar.Blend = blend;

    //                    switch (m_Style)
    //                    {
    //                        case ProgressStyle.Solid:
    //                            {
    //                                e.Graphics.FillRectangle(brsh_Bar, rect_Bar);
    //                                break;
    //                            }
    //                        case ProgressStyle.Dashed:
    //                            {
    //                                if (m_bool_Invert)
    //                                {
    //                                    if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
    //                                    for (int i = 0; i < int_NumberOfDashes + 1; i++)
    //                                    {
    //                                        int j = i + (int_TotalDashes - int_NumberOfDashes);
    //                                        e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset + (j * (m_int_DashWidth + m_int_DashSpace)), m_EdgeWidth + m_int_BarOffset, m_int_DashWidth, (int)float_ProgressHeight));
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
    //                                    for (int i = 0; i < int_NumberOfDashes + 1; i++)
    //                                    {
    //                                        e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset + (i * (m_int_DashWidth + m_int_DashSpace)), m_EdgeWidth + m_int_BarOffset, m_int_DashWidth, (int)float_ProgressHeight));
    //                                    }
    //                                }
    //                                break;
    //                            }
    //                    }
    //                    brsh_Bar.Dispose();
    //                    break;
    //                }
    //            #endregion
    //            #region Vertical
    //            case ProgressBarDirection.Vertical:
    //                {
    //                    float float_ProgressWidth = (float)(this.Width - m_EdgeWidth * 2 - m_int_BarOffset * 2);
    //                    float float_ProgressTotalHeight = this.Height - m_EdgeWidth * 2 - m_int_BarOffset * 2;
    //                    float float_ProgressDrawHeight = float_ProgressTotalHeight / (float)(m_int_Maximum - m_int_Minimum) * (float)(m_int_Value - m_int_Minimum);

    //                    int int_NumberOfDashes = (int)(float_ProgressDrawHeight / (float)(m_int_DashWidth + m_int_DashSpace));
    //                    int int_TotalDashes = (int)(float_ProgressTotalHeight / (float)(m_int_DashWidth + m_int_DashSpace));

    //                    Rectangle rect_Bar2 = new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset, (int)float_ProgressWidth, (int)float_ProgressTotalHeight);
    //                    Rectangle rect_Bar;
    //                    if (m_bool_Invert)
    //                    {
    //                        rect_Bar = new Rectangle(
    //                              m_EdgeWidth + m_int_BarOffset
    //                            , m_EdgeWidth + m_int_BarOffset + (int)(float_ProgressTotalHeight - float_ProgressDrawHeight)
    //                            , (int)float_ProgressWidth
    //                            , (int)float_ProgressDrawHeight);
    //                    }
    //                    else
    //                    {
    //                        rect_Bar = new Rectangle(
    //                              m_EdgeWidth + m_int_BarOffset
    //                            , m_EdgeWidth + m_int_BarOffset
    //                            , (int)float_ProgressWidth
    //                            , (int)float_ProgressDrawHeight);
    //                    }

    //                    LinearGradientBrush brsh_Bar = new LinearGradientBrush(rect_Bar2, m_Color2, m_Color1, (m_FloodStyle == ProgressFloodStyle.Standard) ? 0.0f : 90.0f);
    //                    float[] factors = { 0.0f, 1.0f, 1.0f, 0.0f };
    //                    float[] positions = { 0.0f, m_float_BarFlood, 1.0f - m_float_BarFlood, 1.0f };

    //                    Blend blend = new Blend();
    //                    blend.Factors = factors;
    //                    blend.Positions = positions;
    //                    brsh_Bar.Blend = blend;

    //                    switch (m_Style)
    //                    {
    //                        case ProgressStyle.Solid:
    //                            {
    //                                e.Graphics.FillRectangle(brsh_Bar, rect_Bar);
    //                                break;
    //                            }
    //                        case ProgressStyle.Dashed:
    //                            {
    //                                if (m_bool_Invert)
    //                                {
    //                                    if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
    //                                    for (int i = 0; i < int_NumberOfDashes + 1; i++)
    //                                    {
    //                                        int j = i + (int_TotalDashes - int_NumberOfDashes);
    //                                        e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset + (j * (m_int_DashWidth + m_int_DashSpace)), (int)float_ProgressWidth, m_int_DashWidth));
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
    //                                    for (int i = 0; i < int_NumberOfDashes + 1; i++)
    //                                    {
    //                                        e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset + (i * (m_int_DashWidth + m_int_DashSpace)), (int)float_ProgressWidth, m_int_DashWidth));
    //                                    }
    //                                }
    //                                break;
    //                            }
    //                    }
    //                    brsh_Bar.Dispose();
    //                    break;
    //                }
    //                #endregion
    //        }
    //        #endregion

    //        #region OnPaint - Draw Edge
    //        switch (m_Edge)
    //        {
    //            case ProgressBarEdge.Rectangle:
    //                {
    //                    Pen pen = new Pen(m_EdgeColor);
    //                    Pen pen3 = new Pen(m_EdgeLightColor);
    //                    for (int i = 0; i < m_EdgeWidth; i++)
    //                    {
    //                        e.Graphics.DrawRectangle(pen, 0 + i, 0 + i, this.Width - 1 - i * 2, this.Height - 1 - i * 2);
    //                    }
    //                    e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth, this.Width - 1 - m_EdgeWidth, m_EdgeWidth);
    //                    e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth, m_EdgeWidth, this.Height - 1 - m_EdgeWidth);
    //                    break;
    //                }
    //            case ProgressBarEdge.Rounded:
    //                {
    //                    Pen pen = new Pen(m_EdgeColor);
    //                    Pen pen2 = new Pen(this.BackColor);
    //                    Pen pen3 = new Pen(m_EdgeLightColor);
    //                    for (int i = 0; i < m_EdgeWidth; i++)
    //                    {
    //                        e.Graphics.DrawRectangle(pen, 0 + i, 0 + i, this.Width - 1 - i * 2, this.Height - 1 - i * 2);
    //                    }
    //                    e.Graphics.DrawLine(pen2, 0, 0, 1, 0);
    //                    e.Graphics.DrawLine(pen2, 0, 0, 0, 1);
    //                    e.Graphics.DrawLine(pen2, 0, this.Height - 1, 1, this.Height - 1);
    //                    e.Graphics.DrawLine(pen2, 0, this.Height - 1, 0, this.Height - 2);
    //                    e.Graphics.DrawLine(pen2, this.Width - 2, 0, this.Width - 1, 0);
    //                    e.Graphics.DrawLine(pen2, this.Width - 1, 0, this.Width - 1, 1);
    //                    e.Graphics.DrawLine(pen2, this.Width - 2, this.Height - 1, this.Width - 1, this.Height - 1);
    //                    e.Graphics.DrawLine(pen2, this.Width - 1, this.Height - 2, this.Width - 1, this.Height - 1);

    //                    e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), m_EdgeWidth, m_EdgeWidth, 1, 1);
    //                    e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), m_EdgeWidth, this.Height - 1 - m_EdgeWidth, 1, 1);
    //                    e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), this.Width - 1 - m_EdgeWidth, m_EdgeWidth, 1, 1);
    //                    e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), this.Width - 1 - m_EdgeWidth, this.Height - 1 - m_EdgeWidth, 1, 1);

    //                    e.Graphics.DrawLine(pen3, m_EdgeWidth + 1, m_EdgeWidth, this.Width - 2 - m_EdgeWidth, m_EdgeWidth);
    //                    e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth + 1, m_EdgeWidth, this.Height - 2 - m_EdgeWidth);

    //                    break;
    //                }
    //        }
    //        #endregion

    //        #region OnPaint - Draw Caption
    //        if (m_bool_Antialias) e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    //        StringFormat format = new StringFormat();
    //        format.LineAlignment = StringAlignment.Center;
    //        format.Alignment = StringAlignment.Center;
    //        format.Trimming = StringTrimming.EllipsisCharacter;
    //        switch (m_CaptionMode)
    //        {
    //            case ProgressCaptionMode.Value:
    //                {
    //                    if (m_bool_Shadow)
    //                    {
    //                        e.Graphics.DrawString(m_int_Value.ToString(), this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
    //                    }
    //                    e.Graphics.DrawString(m_int_Value.ToString(), this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
    //                    break;
    //                }
    //            case ProgressCaptionMode.Percent:
    //                {
    //                    float float_Percentage = ((float)(m_int_Value - m_int_Minimum) / (float)(m_int_Maximum - m_int_Minimum)) * 100.0f;
    //                    if (m_bool_Shadow)
    //                    {
    //                        e.Graphics.DrawString(float_Percentage.ToString() + "%", this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
    //                    }
    //                    e.Graphics.DrawString(float_Percentage.ToString() + "%", this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
    //                    break;
    //                }
    //            case ProgressCaptionMode.Custom:
    //                {
    //                    if (m_bool_Shadow)
    //                    {
    //                        e.Graphics.DrawString(GetCustomCaption(m_str_Caption), this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
    //                    }
    //                    e.Graphics.DrawString(GetCustomCaption(m_str_Caption), this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
    //                    break;
    //                }
    //        }
    //        #endregion

    //        base.OnPaint(e);
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        Invalidate();
    //        base.OnResize(e);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (components != null)
    //            {
    //                components.Dispose();
    //            }
    //        }
    //        base.Dispose(disposing);
    //    }
    //    #endregion

    //    #region Component Designer generated code
    //    /// <summary> 
    //    /// Required method for Designer support - do not modify 
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        // 
    //        // ProgressBar
    //        // 
    //        this.Name = "ProgressBar";
    //        this.Size = new System.Drawing.Size(256, 24);
    //        this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseUp);
    //        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseMove);
    //        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseDown);

    //    }
    //    #endregion

    //    #region ChangeByMouse
    //    private void ProgressBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    //    {
    //        /**/
    //    }

    //    private void ProgressBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    //    {
    //        if (m_bool_ChangeByMouse && e.Button == MouseButtons.Left)
    //        {
    //            if (m_Direction == ProgressBarDirection.Horizontal)
    //            {
    //                int int_ProgressWidth = this.Width - m_int_BarOffset * 2 - m_EdgeWidth * 2;
    //                int int_MousePos = e.X - m_int_BarOffset - m_EdgeWidth;

    //                float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

    //                int int_Range = m_int_Maximum - m_int_Minimum;
    //                int int_NewValue = (int)((float)int_Range * percentageClick);
    //                if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
    //                int_NewValue += m_int_Minimum;
    //                if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
    //                if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
    //                m_int_Value = int_NewValue;
    //            }
    //            else
    //            {
    //                int int_ProgressWidth = this.Height - m_int_BarOffset * 2 - m_EdgeWidth * 2;
    //                int int_MousePos = e.Y - m_int_BarOffset - m_EdgeWidth;

    //                float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

    //                int int_Range = m_int_Maximum - m_int_Minimum;
    //                int int_NewValue = (int)((float)int_Range * percentageClick);
    //                if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
    //                int_NewValue += m_int_Minimum;
    //                if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
    //                if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
    //                m_int_Value = int_NewValue;
    //            }
    //            Invalidate();
    //        }
    //    }

    //    private void ProgressBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    //    {
    //        if (m_bool_ChangeByMouse)
    //        {
    //            if (m_Direction == ProgressBarDirection.Horizontal)
    //            {
    //                int int_ProgressWidth = this.Width - m_int_BarOffset * 2 - m_EdgeWidth * 2;
    //                int int_MousePos = e.X - m_int_BarOffset - m_EdgeWidth;

    //                float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

    //                int int_Range = m_int_Maximum - m_int_Minimum;
    //                int int_NewValue = (int)((float)int_Range * percentageClick);
    //                if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
    //                int_NewValue += m_int_Minimum;
    //                if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
    //                if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
    //                m_int_Value = int_NewValue;
    //            }
    //            else
    //            {
    //                int int_ProgressWidth = this.Height - m_int_BarOffset * 2 - m_EdgeWidth * 2;
    //                int int_MousePos = e.Y - m_int_BarOffset - m_EdgeWidth;

    //                float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

    //                int int_Range = m_int_Maximum - m_int_Minimum;
    //                int int_NewValue = (int)((float)int_Range * percentageClick);
    //                if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
    //                int_NewValue += m_int_Minimum;
    //                if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
    //                if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
    //                m_int_Value = int_NewValue;
    //            }
    //            Invalidate();
    //        }
    //    }
    //    #endregion
    //}


    //#endregion

    #endregion

    #region Info

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        public Info()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    #endregion

    #endregion
}
