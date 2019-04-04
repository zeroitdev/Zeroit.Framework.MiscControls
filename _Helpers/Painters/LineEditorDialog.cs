// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LineEditorDialog.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a dialog which allows design and editing of a <c>Line</c> object.
    /// May be used in designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LineEditorDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of <c>LineEditorDialog</c> with a default <c>Line</c>
        /// and default window position.
        /// </summary>
        public LineEditorDialog() : this((Line)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>LineEditorDialog</c> using an existing <c>Line</c>
        /// and default window position.
        /// </summary>
        /// <param name="line">Existing <c>Line</c>.</param>
        public LineEditorDialog(Line line)
        {
            InitializeComponent();
			SetLine(line);
            ShowLine();
        }

        /// <summary>
        /// Initializes a new instance of <c>LineEditorDialog</c> with a default <c>Line</c>
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public LineEditorDialog(Control c) : this(null, c)
		{
		}

        /// <summary>
        /// Initializes a new instance of <c>LineEditorDialog</c> using an existing <c>Line</c>
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="line">Existing <c>Line</c>.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
		public LineEditorDialog(Line line, Control c)
		{
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
			SetLine(line);
		}

        /// <summary>
        /// Sets the line.
        /// </summary>
        /// <param name="line">The line.</param>
        private void SetLine(Line line)
		{
			if (line == null)
			{
				line = new Line();
			}
			colorLabel.BackColor = Color.FromArgb(255, line.Color);
			alphaNud.Value = (decimal)line.Color.A;
			dashStyleComboBox.SelectedDashStyle = line.DashStyle;
			widthNud.Value = (decimal)line.Width;
            ShowLine();
		}

        /// <summary>
        /// Gets the line selected by the user.
        /// </summary>
        /// <value>The line selected by the user.</value>
		public Line Line
		{
			get { return new Line(Color.FromArgb((int)alphaNud.Value, colorLabel.BackColor),
								  (float)widthNud.Value,
								  dashStyleComboBox.SelectedDashStyle); }
		}

        /// <summary>
        /// Shows the line.
        /// </summary>
        private void ShowLine()
		{
			Line line = Line;
			linePanel1.Line = line;
			linePanel2.Line = line;
		}

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Handles the Click event of the colorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            ComboColorPickerDialog d = new ComboColorPickerDialog(colorLabel.BackColor, colorButton);
            if (d.ShowDialog() == DialogResult.OK)
            {
                colorLabel.BackColor = d.Color;
				ShowLine();
            }
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of the dashStyleComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dashStyleComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
			ShowLine();
        }

        /// <summary>
        /// Handles the ValueChanged event of the widthNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void widthNud_ValueChanged(object sender, EventArgs e)
        {
			ShowLine();
        }

        /// <summary>
        /// Handles the ValueChanged event of the alphaNud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
            ShowLine();
        }
    }

    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>Line</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly</remarks>
	public class LineEditor : System.Drawing.Design.UITypeEditor
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
        /// Creates and displays a <c>LineEditorDialog</c> dialog if <c>value</c> is a <c>Line</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Line</c> being edited.</param>
        /// <returns>The new value of the <c>Line</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
										 System.IServiceProvider provider,
										 object value)
		{
			if (value is Line)
			{
				LineEditorDialog dialog = new LineEditorDialog((Line)value);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.Line;
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
        /// Paint a representation of the line (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
		{   
			if (e.Value is Line)
			{
				int y = e.Bounds.Height / 2;
				Pen pen = ((Line)e.Value).GetPen();
				if (pen != null)
				{
					e.Graphics.DrawLine(pen, e.Bounds.X, y, e.Bounds.X + e.Bounds.Width - 1, y);
				}
			}
		}
	}
}
