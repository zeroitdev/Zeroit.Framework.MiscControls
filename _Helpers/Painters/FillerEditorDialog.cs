// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FillerEditorDialog.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a dialog which allows design and editing of a <c>Filler</c> object.
    /// May be used in designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FillerEditorDialog : Form
    {
        /// <summary>
        /// The gradient linear
        /// </summary>
        private const int gradientLinear = 0;
        /// <summary>
        /// The gradient path rect
        /// </summary>
        private const int gradientPathRect = 1;
        /// <summary>
        /// The gradient path radial
        /// </summary>
        private const int gradientPathRadial = 2;

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an empty <c>Filler</c>
        /// at the default window position.
        /// </summary>
        public FillerEditorDialog() : this(Filler.Empty())
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an existing <c>Filler</c>
        /// at the default window position.
        /// </summary>
        /// <param name="filler">Existing <c>Filler</c> object.</param>
        /// <exception cref="ArgumentNullException">filler</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public FillerEditorDialog(Filler filler)
        {
			if (filler == null)
			{
				throw new ArgumentNullException("filler");
			}

            InitializeComponent();
			FillGradientComboBox();
			AdjustDialogSize();
			SetControlsToInitialValues(filler);
        }

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an empty <c>Filler</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public FillerEditorDialog(Control c) : this(Filler.Empty(), c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an existing <c>Filler</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="filler">Existing <c>Filler</c> object.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public FillerEditorDialog(Filler filler, Control c) : this(filler)
        {
			Utils.SetStartPositionBelowControl(this, c);
        }

        /// <summary>
        /// Fills the gradient ComboBox.
        /// </summary>
        private void FillGradientComboBox()
		{
			gradientTypeComboBox.Items.Clear();
			gradientTypeComboBox.Items.Add("Linear");
			gradientTypeComboBox.Items.Add("Path Rect");
			gradientTypeComboBox.Items.Add("Path Radial");
		}

        /// <summary>
        /// Adjusts the size of the dialog.
        /// </summary>
        private void AdjustDialogSize()
		{
			// Three different possible group boxes - move them all to one coordinate
			int x = solidGroupBox.Location.X;
			int y = typeGroupBox.Location.Y;

			solidGroupBox.Location = new Point(x, y);
			hatchGroupBox.Location = new Point(x, y);
			gradientGroupBox.Location = new Point(x, y);

			int bottomY = Math.Max(solidGroupBox.Bounds.Bottom,
					      Math.Max(hatchGroupBox.Bounds.Bottom,
					   	  Math.Max(gradientGroupBox.Bounds.Bottom,
								   typeGroupBox.Bounds.Bottom)));

			int newHeight = bottomY + typeGroupBox.Location.Y;

			this.Size = new Size(Size.Width, Size.Height - (ClientSize.Height - newHeight));
		}

        /// <summary>
        /// Sets the controls to initial values.
        /// </summary>
        /// <param name="filler">The filler.</param>
        private void SetControlsToInitialValues(Filler filler)
		{
			// Fill with defaults
			Init(filler.SolidColor, solidColorLabel, solidAlphaNud);
			Init(filler.HatchColor, hatchColorLabel, hatchAlphaNud);
			Init(filler.BackColor, backColorLabel, backAlphaNud);
            gradientEditor.Blend = filler.GradientColors;

			if (filler.FillType == FillerType.PathGradient)
			{
				if (filler.PathGradientType == PathGradientType.Rect)
				{
					gradientTypeComboBox.SelectedIndex = gradientPathRect;
				}
				else
				{
					gradientTypeComboBox.SelectedIndex = gradientPathRadial;
				}
			}
			else
			{
				gradientTypeComboBox.SelectedIndex = gradientLinear;
				gradientAngleNud.Value = (decimal)filler.LinearGradientAngle;
			}
			UpdateGradient();

			hatchComboBox.SelectedIndex = 0;
			for (int i = 0; i < hatchComboBox.Items.Count; i++)
			{
				if (filler.HatchStyle == (HatchStyle)(hatchComboBox.Items[i]))
				{
					hatchComboBox.SelectedIndex = i;
				}
			}
			UpdateHatch();

			UpdateSolid();

			if (filler.FillType == FillerType.None)
			{
				noneRadioButton.Checked = true;
			}
			else if (filler.FillType == FillerType.Solid)
			{
				solidRadioButton.Checked = true;
			}
            else if (filler.FillType == FillerType.Hatch)
			{
				hatchRadioButton.Checked = true;
			}
            else
			{
				gradientRadioButton.Checked = true;
			}
		}

        /// <summary>
        /// Initializes the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="label">The label.</param>
        /// <param name="alphaNud">The alpha nud.</param>
        private void Init(Color c, Label label, NumericUpDown alphaNud)
		{
			label.BackColor = RGB(c);
			alphaNud.Value = (decimal)c.A;
		}

        /// <summary>
        /// Froms the label nud.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="alphaNud">The alpha nud.</param>
        /// <returns>Color.</returns>
        private Color FromLabelNud(Label label, NumericUpDown alphaNud)
		{
			return Color.FromArgb((int)alphaNud.Value, label.BackColor);
		}

        /// <summary>
        /// RGBs the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        private Color RGB(Color c)
		{
			return Color.FromArgb(255, c);
		}

        /// <summary>
        /// The filler
        /// </summary>
        private Filler filler;
        /// <summary>
        /// Gets current filler.
        /// </summary>
        /// <value>Current filler.</value>
        public Filler Filler
		{
			get { return filler; }
		}

        /// <summary>
        /// Updates the solid.
        /// </summary>
        private void UpdateSolid()
		{
			sampleSolidPanel.BackColor = FromLabelNud(solidColorLabel, solidAlphaNud);
		}

        /// <summary>
        /// Updates the hatch.
        /// </summary>
        private void UpdateHatch()
		{
			sampleHatchPanel.Set(hatchComboBox.SelectedHatchStyle,
								 FromLabelNud(hatchColorLabel, hatchAlphaNud),
								 FromLabelNud(backColorLabel, backAlphaNud));
		}

        /// <summary>
        /// Updates the gradient.
        /// </summary>
        private void UpdateGradient()
		{
			gradientAngleTextLabel.Enabled = gradientTypeComboBox.SelectedIndex == gradientLinear;
			gradientAngleNud.Enabled       = gradientTypeComboBox.SelectedIndex == gradientLinear;
		}

        /// <summary>
        /// Handles the Click event of the solidColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(solidColorLabel.BackColor, solidColorButton);
			if (d.ShowDialog() == DialogResult.OK)
			{
				solidColorLabel.BackColor = d.Color;
			}
			UpdateSolid();
        }

        /// <summary>
        /// Handles the ValueChanged event of the solidAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void solidAlphaNud_ValueChanged(object sender, EventArgs e)
        {
			UpdateSolid();
        }

        /// <summary>
        /// Handles the Click event of the hatchColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(hatchColorLabel.BackColor, hatchColorButton);
			if (d.ShowDialog() == DialogResult.OK)
			{
				hatchColorLabel.BackColor = Color.FromArgb((int)hatchAlphaNud.Value, d.Color);
			}
			UpdateHatch();
        }

        /// <summary>
        /// Handles the ValueChanged event of the hatchAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchAlphaNud_ValueChanged(object sender, EventArgs e)
        {
			UpdateHatch();
        }

        /// <summary>
        /// Handles the Click event of the backColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backColorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(backColorLabel.BackColor, backColorButton);
			if (d.ShowDialog() == DialogResult.OK)
			{
				backColorLabel.BackColor = d.Color;
			}
			UpdateHatch();
        }

        /// <summary>
        /// Handles the ValueChanged event of the backAlphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void backAlphaNud_ValueChanged(object sender, EventArgs e)
        {
			UpdateHatch();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the hatchComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hatchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			UpdateHatch();
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of the gradientTypeComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gradientTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateGradient();
        }

        /// <summary>
        /// Fillers the type changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void fillerTypeChanged(object sender, EventArgs e)
        {
			solidGroupBox.Visible = false;
			hatchGroupBox.Visible = false;
			gradientGroupBox.Visible = false;

			if (solidRadioButton.Checked)
			{
				solidGroupBox.Visible = true;
			}
			else if (hatchRadioButton.Checked)
			{
				hatchGroupBox.Visible = true;
			}
			else if (gradientRadioButton.Checked)
			{
				gradientGroupBox.Visible = true;
			}
        }

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
			if (solidRadioButton.Checked)
			{
				filler = new Filler(FromLabelNud(solidColorLabel, solidAlphaNud));
			}
			else if (hatchRadioButton.Checked)
			{
				filler = new Filler(hatchComboBox.SelectedHatchStyle,
									 FromLabelNud(hatchColorLabel, hatchAlphaNud),
									 FromLabelNud(backColorLabel, backAlphaNud));
			}
			else if (gradientRadioButton.Checked)
			{
				if (gradientTypeComboBox.SelectedIndex == gradientLinear)
				{
					filler = new Filler((float)gradientAngleNud.Value, gradientEditor.Blend);
				}
				else if (gradientTypeComboBox.SelectedIndex == gradientPathRect)
				{
					filler = new Filler(PathGradientType.Rect, gradientEditor.Blend);
				}
				else
				{
					filler = new Filler(PathGradientType.Radial, gradientEditor.Blend);
				}
			}
			else
			{
				filler = Filler.Empty();
			}
			DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the cancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
        }
    }

    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>Filler</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly</remarks>
	public class FillerEditor : System.Drawing.Design.UITypeEditor
	{
        /// <summary>
        /// Gets the editor style used by the <c>EditValue</c> method.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>UITypeEditorEditStyle.Modal</c></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

        /// <summary>
        /// Creates and displays a <c>FillerEditorDialog</c> dialog if <c>value</c> is a <c>Filler</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Filler</c> being edited.</param>
        /// <returns>The new value of the <c>Filler</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
										 System.IServiceProvider provider,
										 object value)
		{
			if (value is Filler)
			{
				FillerEditorDialog dialog = new FillerEditorDialog((Filler)value);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.Filler;
				}
			}
			return value;
		}

        /// <summary>
        /// Indicates that painting is supported.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>true</c>.</returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

        /// <summary>
        /// Paint a representation of the simple filler (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
		{   
			if (e.Value is Filler)
			{
				Brush br = ((Filler)e.Value).GetUITypeEditorBrush(e.Bounds);
				if (br != null)
				{
					e.Graphics.FillRectangle(br, e.Bounds /*r*/);
				}
			}
		}
	}
}
