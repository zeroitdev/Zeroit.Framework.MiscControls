// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomColorPickerDialog.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Represents a dialog that enables the user to select a customized color.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CustomColorPickerDialog : Form
    {
        /// <summary>
        /// Constructor with no starting color and default window position.
        /// </summary>
        public CustomColorPickerDialog() : this(Color.Empty)
        {
		}

        /// <summary>
        /// Constructor with starting color and default window position.
        /// </summary>
        /// <param name="color">Starting color.</param>
        public CustomColorPickerDialog(Color color)
        {
            InitializeComponent();
			customColorPicker.SetColor(color);
        }

        /// <summary>
        /// Constructor with no starting color and starting position beneath specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public CustomColorPickerDialog(Control c) : this(Color.Empty, c)
		{
		}

        /// <summary>
        /// Constructor with starting color and starting position beneath specified control.
        /// </summary>
        /// <param name="color">Starting color.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public CustomColorPickerDialog(Color color, Control c)
		{
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
			customColorPicker.SetColor(color);
		}

        /// <summary>
        /// Consructor with no starting color and starting position.
        /// </summary>
        /// <param name="p">Starting position.</param>
		public CustomColorPickerDialog(Point p) : this(Color.Empty, p)
		{
		}

        /// <summary>
        /// Constructor with starting color and starting position.
        /// </summary>
        /// <param name="color">Starting color.</param>
        /// <param name="p">Starting position.</param>
		public CustomColorPickerDialog(Color color, Point p)
		{
            InitializeComponent();
			Utils.SetStartPosition(this, p);
			customColorPicker.SetColor(color);
		}

        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// Gets or sets selected color.
        /// </summary>
        /// <value>Selected color.</value>
        public Color Color
		{
			get { return color; }
			set	{ customColorPicker.SetColor(value); }
		}

        /// <summary>
        /// The color name
        /// </summary>
        private string colorName;
        /// <summary>
        /// Gets name of selected color.
        /// </summary>
        /// <value>Name of selected color.</value>
        public string ColorName
		{
			get { return colorName; }
		}

        /// <summary>
        /// Override to capture Esc key.
        /// </summary>
        /// <param name="keyCode">Key.</param>
        /// <returns><c>True</c> if key handled, <c>false</c> otherwise.</returns>
		protected override bool ProcessDialogKey(Keys keyCode)
		{
			if (keyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
                return true;
			}
            return false;
		}

        /// <summary>
        /// Handles the ColorSelected event of the customColorPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.ColorSelectedEventArgs"/> instance containing the event data.</param>
        private void customColorPicker_ColorSelected(object sender, Zeroit.Framework.MiscControls.HelperControls.Widgets.ColorSelectedEventArgs args)
        {
			color = args.Color;
			colorName = args.ColorName;
            DialogResult = DialogResult.OK;
        }
    }
}
