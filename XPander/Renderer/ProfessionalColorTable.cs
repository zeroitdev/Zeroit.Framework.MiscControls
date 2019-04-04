// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ProfessionalColorTable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ProfessionalColorTable
    /// <summary>
    /// Provides colors used for Microsoft Office display elements.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ProfessionalColorTable" />
    public class ProfessionalColorTable : System.Windows.Forms.ProfessionalColorTable
    {
        #region Enums
        /// <summary>
        /// Gets or sets the KnownColors appearance of the ProfessionalColorTable.
        /// </summary>
        public enum KnownColors
        {
            /// <summary>
            /// The border color to use with the <see cref="ButtonPressedGradientBegin" />, <see cref="ButtonPressedGradientMiddle" />, and <see cref="ButtonPressedGradientEnd" /> colors.
            /// </summary>
            ButtonPressedBorder,
            /// <summary>
            /// The starting color of the gradient used when the button is pressed down.
            /// </summary>
            ButtonPressedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when the button is pressed down.
            /// </summary>
            ButtonPressedGradientEnd,
            /// <summary>
            /// The middle color of the gradient used when the button is pressed down.
            /// </summary>
            ButtonPressedGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used when the button is selected.
            /// </summary>
            ButtonSelectedGradientBegin,
            /// <summary>
            /// The border color to use with the ButtonSelectedGradientBegin,
            /// ButtonSelectedGradientMiddle,
            /// and ButtonSelectedGradientEnd colors.
            /// </summary>
            ButtonSelectedBorder,
            /// <summary>
            /// The end color of the gradient used when the button is selected.
            /// </summary>
            ButtonSelectedGradientEnd,
            /// <summary>
            /// The middle color of the gradient used when the button is selected.
            /// </summary>
            ButtonSelectedGradientMiddle,
            /// <summary>
            /// The border color to use with ButtonSelectedHighlight.
            /// </summary>
            ButtonSelectedHighlightBorder,
            /// <summary>
            /// The solid color to use when the check box is selected and gradients are being used.
            /// </summary>
            CheckBackground,
            /// <summary>
            /// The solid color to use when the check box is selected and gradients are being used.
            /// </summary>
			CheckSelectedBackground,
            /// <summary>
            /// The color to use for shadow effects on the grip or move handle.
            /// </summary>
            GripDark,
            /// <summary>
            /// The color to use for highlight effects on the grip or move handle.
            /// </summary>
            GripLight,
            /// <summary>
            /// The starting color of the gradient used in the image margin
            /// of a ToolStripDropDownMenu.
            /// </summary>
            ImageMarginGradientBegin,
            /// <summary>
            /// The border color or a MenuStrip.
            /// </summary>
            MenuBorder,
            /// <summary>
            /// The border color to use with a ToolStripMenuItem.
            /// </summary>
            MenuItemBorder,
            /// <summary>
            /// The starting color of the gradient used when a top-level
            /// ToolStripMenuItem is pressed down.
            /// </summary>
            MenuItemPressedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when a top-level
            /// ToolStripMenuItem is pressed down.
            /// </summary>
            MenuItemPressedGradientEnd,
            /// <summary>
            /// The middle color of the gradient used when a top-level
            /// ToolStripMenuItem is pressed down.
            /// </summary>
            MenuItemPressedGradientMiddle,
            /// <summary>
            /// The solid color to use when a ToolStripMenuItem other
            /// than the top-level ToolStripMenuItem is selected.
            /// </summary>
			MenuItemSelected,
            /// <summary>
            /// The starting color of the gradient used when the ToolStripMenuItem is selected.
            /// </summary>
			MenuItemSelectedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when the ToolStripMenuItem is selected.
            /// </summary>
            MenuItemSelectedGradientEnd,
            /// <summary>
            /// The text color of a top-level ToolStripMenuItem.
            /// </summary>
            MenuItemText,
            /// <summary>
            /// The border color used when a top-level
            /// ToolStripMenuItem is selected.
            /// </summary>
            MenuItemTopLevelSelectedBorder,
            /// <summary>
            /// The starting color of the gradient used when a top-level
            /// ToolStripMenuItem is selected.
            /// </summary>
            MenuItemTopLevelSelectedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when a top-level
            /// ToolStripMenuItem is selected.
            /// </summary>
            MenuItemTopLevelSelectedGradientEnd,
            /// <summary>
            /// The middle color of the gradient used when a top-level
            /// ToolStripMenuItem is selected.
            /// </summary>
            MenuItemTopLevelSelectedGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used in the MenuStrip.
            /// </summary>
            MenuStripGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the MenuStrip.
            /// </summary>
            MenuStripGradientEnd,
            /// <summary>
            /// The starting color of the gradient used in the ToolStripOverflowButton.
            /// </summary>
            OverflowButtonGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the ToolStripOverflowButton.
            /// </summary>
            OverflowButtonGradientEnd,
            /// <summary>
            /// The middle color of the gradient used in the ToolStripOverflowButton.
            /// </summary>
            OverflowButtonGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used in the ToolStripContainer.
            /// </summary>
            RaftingContainerGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the ToolStripContainer.
            /// </summary>
            RaftingContainerGradientEnd,
            /// <summary>
            /// The color to use to for shadow effects on the ToolStripSeparator.
            /// </summary>
            SeparatorDark,
            /// <summary>
            /// The color to use to for highlight effects on the ToolStripSeparator.
            /// </summary>
            SeparatorLight,
            /// <summary>
            /// The starting color of the gradient used on the StatusStrip.
            /// </summary>
            StatusStripGradientBegin,
            /// <summary>
            /// The end color of the gradient used on the StatusStrip.
            /// </summary>
            StatusStripGradientEnd,
            /// <summary>
            /// The text color used on the StatusStrip.
            /// </summary>
			StatusStripText,
            /// <summary>
            /// The border color to use on the bottom edge of the ToolStrip.
            /// </summary>
            ToolStripBorder,
            /// <summary>
            /// The starting color of the gradient used in the ToolStripContentPanel.
            /// </summary>
            ToolStripContentPanelGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the ToolStripContentPanel.
            /// </summary>
            ToolStripContentPanelGradientEnd,
            /// <summary>
            /// The solid background color of the ToolStripDropDown.
            /// </summary>
            ToolStripDropDownBackground,
            /// <summary>
            /// The starting color of the gradient used in the ToolStrip background.
            /// </summary>
            ToolStripGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the ToolStrip background.
            /// </summary>
            ToolStripGradientEnd,
            /// <summary>
            /// The middle color of the gradient used in the ToolStrip background.
            /// </summary>
            ToolStripGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used in the ToolStripPanel.
            /// </summary>
            ToolStripPanelGradientBegin,
            /// <summary>
            /// The end color of the gradient used in the ToolStripPanel.
            /// </summary>
            ToolStripPanelGradientEnd,
            /// <summary>
            /// The text color used on the ToolStrip.
            /// </summary>
            ToolStripText,
            /// <summary>
            /// The last known color
            /// </summary>
            LastKnownColor = SeparatorLight
        }

        #endregion

        #region FieldsPrivate

        /// <summary>
        /// The m dictionary RGB table
        /// </summary>
        private Dictionary<KnownColors, Color> m_dictionaryRGBTable;
        /// <summary>
        /// The m panel color table
        /// </summary>
        private PanelColors m_panelColorTable;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the border color to use with the <see cref="ButtonPressedGradientBegin" />, <see cref="ButtonPressedGradientMiddle" />, and <see cref="ButtonPressedGradientEnd" /> colors.
        /// </summary>
        /// <value>A <see cref="System.Drawing.Color" /> that is the border color to use with the <see cref="ButtonPressedGradientBegin" />, <see cref="ButtonPressedGradientMiddle" />, and <see cref="ButtonPressedGradientEnd" /> colors.</value>
        public override Color ButtonPressedBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonPressedBorder);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the button is pressed down.
        /// </summary>
        /// <value>The button pressed gradient begin.</value>
        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonPressedGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the button is pressed down.
        /// </summary>
        /// <value>The button pressed gradient end.</value>
        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonPressedGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the button is pressed down.
        /// </summary>
        /// <value>The button pressed gradient middle.</value>
        public override Color ButtonPressedGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonPressedGradientMiddle);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected border.</value>
        public override Color ButtonSelectedBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonSelectedBorder);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient begin.</value>
        public override Color ButtonSelectedGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonSelectedGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient end.</value>
        public override Color ButtonSelectedGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonSelectedGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the button is selected.
        /// </summary>
        /// <value>The button selected gradient middle.</value>
        public override Color ButtonSelectedGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonSelectedGradientMiddle);
            }
        }

        /// <summary>
        /// Gets the border color to use with ButtonSelectedHighlight.
        /// </summary>
        /// <value>The button selected highlight border.</value>
        public override Color ButtonSelectedHighlightBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.ButtonSelectedHighlightBorder);
            }
        }
        /// <summary>
        /// Gets the solid color to use when the check box is selected and gradients are being used.
        /// </summary>
        /// <value>The check background.</value>
        public override Color CheckBackground
        {
            get
            {
                return this.FromKnownColor(KnownColors.CheckBackground);
            }
        }
        /// <summary>
        /// Gets the solid color to use when the check box is selected and gradients are being used.
        /// </summary>
        /// <value>The check selected background.</value>
        public override Color CheckSelectedBackground
        {
            get
            {
                return this.FromKnownColor(KnownColors.CheckSelectedBackground);
            }
        }
        /// <summary>
        /// Gets the color to use for shadow effects on the grip or move handle.
        /// </summary>
        /// <value>The grip dark.</value>
        public override Color GripDark
        {
            get
            {
                return this.FromKnownColor(KnownColors.GripDark);
            }
        }
        /// <summary>
        /// Gets the color to use for highlight effects on the grip or move handle.
        /// </summary>
        /// <value>The grip light.</value>
        public override Color GripLight
        {
            get
            {
                return this.FromKnownColor(KnownColors.GripLight);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the image margin of a ToolStripDropDownMenu.
        /// </summary>
        /// <value>The image margin gradient begin.</value>
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ImageMarginGradientBegin);
            }
        }
        /// <summary>
        /// Gets the border color or a MenuStrip.
        /// </summary>
        /// <value>The menu border.</value>
        public override Color MenuBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuBorder);
            }
        }
        /// <summary>
        /// Gets the border color to use with a ToolStripMenuItem.
        /// </summary>
        /// <value>The menu item border.</value>
        public override Color MenuItemBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemBorder);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        /// <value>The menu item pressed gradient begin.</value>
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemPressedGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        /// <value>The menu item pressed gradient end.</value>
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemPressedGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        /// <value>The menu item pressed gradient middle.</value>
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemPressedGradientMiddle);
            }
        }
        /// <summary>
        /// Gets the solid color to use when a ToolStripMenuItem other than the top-level ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item selected.</value>
        public override Color MenuItemSelected
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemSelected);
            }
        }
        /// <summary>
        /// Gets the text color of a top-level ToolStripMenuItem.
        /// </summary>
        /// <value>The menu item text.</value>
        public virtual Color MenuItemText
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemText);
            }
        }
        /// <summary>
        /// Gets the border color used when a top-level
        /// ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item top level selected border.</value>
        public virtual Color MenuItemTopLevelSelectedBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemTopLevelSelectedBorder);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when a top-level
        /// ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item top level selected gradient begin.</value>
        public virtual Color MenuItemTopLevelSelectedGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used when a top-level
        /// ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item top level selected gradient end.</value>
        public virtual Color MenuItemTopLevelSelectedGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when a top-level
        /// ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item top level selected gradient middle.</value>
        public virtual Color MenuItemTopLevelSelectedGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemTopLevelSelectedGradientMiddle);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item selected gradient begin.</value>
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemSelectedGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the ToolStripMenuItem is selected.
        /// </summary>
        /// <value>The menu item selected gradient end.</value>
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuItemSelectedGradientEnd);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the MenuStrip.
        /// </summary>
        /// <value>The menu strip gradient begin.</value>
        public override Color MenuStripGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuStripGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the MenuStrip.
        /// </summary>
        /// <value>The menu strip gradient end.</value>
        public override Color MenuStripGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.MenuStripGradientEnd);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        /// <value>The overflow button gradient begin.</value>
        public override Color OverflowButtonGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.OverflowButtonGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        /// <value>The overflow button gradient end.</value>
        public override Color OverflowButtonGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.OverflowButtonGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        /// <value>The overflow button gradient middle.</value>
        public override Color OverflowButtonGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.OverflowButtonGradientMiddle);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripContainer.
        /// </summary>
        /// <value>The rafting container gradient begin.</value>
        public override Color RaftingContainerGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.RaftingContainerGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripContainer.
        /// </summary>
        /// <value>The rafting container gradient end.</value>
        public override Color RaftingContainerGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.RaftingContainerGradientEnd);
            }
        }
        /// <summary>
        /// Gets the color to use to for shadow effects on the ToolStripSeparator.
        /// </summary>
        /// <value>The separator dark.</value>
        public override Color SeparatorDark
        {
            get
            {
                return this.FromKnownColor(KnownColors.SeparatorDark);
            }
        }
        /// <summary>
        /// Gets the color to use to for highlight effects on the ToolStripSeparator.
        /// </summary>
        /// <value>The separator light.</value>
        public override Color SeparatorLight
        {
            get
            {
                return this.FromKnownColor(KnownColors.SeparatorLight);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used on the StatusStrip.
        /// </summary>
        /// <value>The status strip gradient begin.</value>
        public override Color StatusStripGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.StatusStripGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used on the StatusStrip.
        /// </summary>
        /// <value>The status strip gradient end.</value>
        public override Color StatusStripGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.StatusStripGradientEnd);
            }
        }
        /// <summary>
        /// Gets the text color used on the StatusStrip.
        /// </summary>
        /// <value>The status strip text.</value>
        public virtual Color StatusStripText
        {
            get
            {
                return this.FromKnownColor(KnownColors.StatusStripText);
            }
        }
        /// <summary>
        /// Gets the border color to use on the bottom edge of the ToolStrip.
        /// </summary>
        /// <value>The tool strip border.</value>
        public override Color ToolStripBorder
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripBorder);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripContentPanel.
        /// </summary>
        /// <value>The tool strip content panel gradient begin.</value>
        public override Color ToolStripContentPanelGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripContentPanelGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripContentPanel.
        /// </summary>
        /// <value>The tool strip content panel gradient end.</value>
        public override Color ToolStripContentPanelGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripContentPanelGradientEnd);
            }
        }
        /// <summary>
        /// Gets the solid background color of the ToolStripDropDown.
        /// </summary>
        /// <value>The tool strip drop down background.</value>
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripDropDownBackground);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStrip background.
        /// </summary>
        /// <value>The tool strip gradient begin.</value>
        public override Color ToolStripGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the ToolStrip background.
        /// </summary>
        /// <value>The tool strip gradient end.</value>
        public override Color ToolStripGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripGradientEnd);
            }
        }
        /// <summary>
        /// Gets the middle color of the gradient used in the ToolStrip background.
        /// </summary>
        /// <value>The tool strip gradient middle.</value>
        public override Color ToolStripGradientMiddle
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripGradientMiddle);
            }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripPanel.
        /// </summary>
        /// <value>The tool strip panel gradient begin.</value>
        public override Color ToolStripPanelGradientBegin
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripPanelGradientBegin);
            }
        }
        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripPanel.
        /// </summary>
        /// <value>The tool strip panel gradient end.</value>
        public override Color ToolStripPanelGradientEnd
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripPanelGradientEnd);
            }
        }
        /// <summary>
        /// Gets the text color used on the ToolStrip.
        /// </summary>
        /// <value>The tool strip text.</value>
        public virtual Color ToolStripText
        {
            get
            {
                return this.FromKnownColor(KnownColors.ToolStripText);
            }
        }
        /// <summary>
        /// Gets the associated ColorTable for the XPanderControls
        /// </summary>
        /// <value>The panel color table.</value>
        public virtual PanelColors PanelColorTable
        {
            get
            {
                if (this.m_panelColorTable == null)
                {
                    this.m_panelColorTable = new PanelColors();
                }
                return this.m_panelColorTable;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether to use System.Drawing.SystemColors rather than colors that match the current visual style.
        /// </summary>
        /// <value><c>true</c> if [use system colors]; otherwise, <c>false</c>.</value>
        public new bool UseSystemColors
        {
            get { return base.UseSystemColors; }
            set
            {
                if (value.Equals(base.UseSystemColors) == false)
                {
                    base.UseSystemColors = value;
                    if (this.m_dictionaryRGBTable != null)
                    {
                        this.m_dictionaryRGBTable.Clear();
                        this.m_dictionaryRGBTable = null;
                    }
                }
            }
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
                    if ((this.UseSystemColors == true) || (ToolStripManager.VisualStylesEnabled == false))
                    {
                        InitBaseColors(this.m_dictionaryRGBTable);
                    }
                    else
                    {
                        InitColors(this.m_dictionaryRGBTable);
                    }
                }
                return this.m_dictionaryRGBTable;
            }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the ProfessionalColorTable class.
        /// </summary>
        public ProfessionalColorTable()
        {
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
            rgbTable[KnownColors.ButtonPressedBorder] = base.ButtonPressedBorder;
            rgbTable[KnownColors.ButtonPressedGradientBegin] = base.ButtonPressedGradientBegin;
            rgbTable[KnownColors.ButtonPressedGradientEnd] = base.ButtonPressedGradientEnd;
            rgbTable[KnownColors.ButtonPressedGradientMiddle] = base.ButtonPressedGradientMiddle;
            rgbTable[KnownColors.ButtonSelectedBorder] = base.ButtonSelectedBorder;
            rgbTable[KnownColors.ButtonSelectedGradientBegin] = base.ButtonSelectedGradientBegin;
            rgbTable[KnownColors.ButtonSelectedGradientEnd] = base.ButtonSelectedGradientEnd;
            rgbTable[KnownColors.ButtonSelectedGradientMiddle] = base.ButtonSelectedGradientMiddle;
            rgbTable[KnownColors.ButtonSelectedHighlightBorder] = base.ButtonSelectedHighlightBorder;
            rgbTable[KnownColors.CheckBackground] = base.CheckBackground;
            rgbTable[KnownColors.CheckSelectedBackground] = base.CheckSelectedBackground;
            rgbTable[KnownColors.GripDark] = base.GripDark;
            rgbTable[KnownColors.GripLight] = base.GripLight;
            rgbTable[KnownColors.ImageMarginGradientBegin] = base.ImageMarginGradientBegin;
            rgbTable[KnownColors.MenuBorder] = base.MenuBorder;
            rgbTable[KnownColors.MenuItemBorder] = base.MenuItemBorder;
            rgbTable[KnownColors.MenuItemPressedGradientBegin] = base.MenuItemPressedGradientBegin;
            rgbTable[KnownColors.MenuItemPressedGradientEnd] = base.MenuItemPressedGradientEnd;
            rgbTable[KnownColors.MenuItemPressedGradientMiddle] = base.MenuItemPressedGradientMiddle;
            rgbTable[KnownColors.MenuItemSelected] = base.MenuItemSelected;
            rgbTable[KnownColors.MenuItemSelectedGradientBegin] = base.MenuItemSelectedGradientBegin;
            rgbTable[KnownColors.MenuItemSelectedGradientEnd] = base.MenuItemSelectedGradientEnd;
            rgbTable[KnownColors.MenuItemText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.MenuItemTopLevelSelectedBorder] = base.MenuItemBorder;
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientBegin] = base.MenuItemSelected;
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientEnd] = base.MenuItemSelected;
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientMiddle] = base.MenuItemSelected;
            rgbTable[KnownColors.MenuStripGradientBegin] = base.MenuStripGradientBegin;
            rgbTable[KnownColors.MenuStripGradientEnd] = base.MenuStripGradientEnd;
            rgbTable[KnownColors.OverflowButtonGradientBegin] = base.OverflowButtonGradientBegin;
            rgbTable[KnownColors.OverflowButtonGradientEnd] = base.OverflowButtonGradientEnd;
            rgbTable[KnownColors.OverflowButtonGradientMiddle] = base.OverflowButtonGradientMiddle;
            rgbTable[KnownColors.RaftingContainerGradientBegin] = base.RaftingContainerGradientBegin;
            rgbTable[KnownColors.RaftingContainerGradientEnd] = base.RaftingContainerGradientEnd;
            rgbTable[KnownColors.SeparatorDark] = base.SeparatorDark;
            rgbTable[KnownColors.SeparatorLight] = base.SeparatorLight;
            rgbTable[KnownColors.StatusStripGradientBegin] = base.StatusStripGradientEnd;
            rgbTable[KnownColors.StatusStripGradientEnd] = base.StatusStripGradientBegin;
            rgbTable[KnownColors.StatusStripText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.ToolStripBorder] = base.ToolStripBorder;
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = base.ToolStripContentPanelGradientBegin;
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = base.ToolStripContentPanelGradientEnd;
            rgbTable[KnownColors.ToolStripDropDownBackground] = base.ToolStripDropDownBackground;
            rgbTable[KnownColors.ToolStripGradientBegin] = base.ToolStripGradientBegin;
            rgbTable[KnownColors.ToolStripGradientEnd] = base.ToolStripGradientEnd;
            rgbTable[KnownColors.ToolStripGradientMiddle] = base.ToolStripGradientMiddle;
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = base.ToolStripPanelGradientBegin;
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = base.ToolStripPanelGradientEnd;
            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);
        }

        #endregion
    }
    #endregion
}
