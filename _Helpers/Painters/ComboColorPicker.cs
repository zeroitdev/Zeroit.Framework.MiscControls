// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ComboColorPicker.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a color picker which combines the web, system, and custom color pickers.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker" />
    public partial class ComboColorPicker : BaseColorPicker // UserControl
    {
        /// <summary>
        /// Constructor with no starting color.
        /// </summary>
        public ComboColorPicker() : this(Color.Empty)
        {
        }

        /// <summary>
        /// Constructor with starting color.
        /// </summary>
        /// <param name="color">Starting color.</param>
		public ComboColorPicker(Color color)
		{
            InitializeComponent();
			SetColor(color);
		}

        /// <summary>
        /// Set current selected color.
        /// </summary>
        /// <param name="color">Current color.</param>
        /// <returns><c>True</c>.</returns>
		public override bool SetColor(Color color)
		{
			customColorPicker.SetColor(color);
			if (webColorPicker.SetColor(color))
			{
				tabControl.SelectedTab = tabPageWeb;
			}
			else if (systemColorPicker.SetColor(color))
			{
				tabControl.SelectedTab = tabPageSystem;
			}
			else
			{
				tabControl.SelectedTab = tabPageCustom;
			}
            return true;
		}

        /// <summary>
        /// Handles the ColorSelected event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="ColorSelectedEventArgs"/> instance containing the event data.</param>
        private void tab_ColorSelected(object sender, ColorSelectedEventArgs args)
        {
			SelectColor(args);
        }
	}
}
