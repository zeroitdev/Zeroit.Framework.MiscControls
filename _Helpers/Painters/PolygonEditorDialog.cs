// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PolygonEditorDialog.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a dialog which allows design and editing of a <c>Polygon</c> object.
    /// May be used in designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PolygonEditorDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> with an empty polygon
        /// and default window position.
        /// </summary>
        public PolygonEditorDialog() : this((Polygon)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> using an existing polygon
        /// and default window position.
        /// </summary>
        /// <param name="poly">Existing <c>Polygon</c>.</param>
        public PolygonEditorDialog(Polygon poly)
        {
            InitializeComponent();
			Init(poly);
		}

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> with an empty polygon
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public PolygonEditorDialog(Control c) : this(null, c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> using an existing polygon
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="poly">Existing <c>Polygon</c>.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public PolygonEditorDialog(Polygon poly, Control c)
        {
            InitializeComponent();
			Utils.SetStartPositionBelowControl(this, c);
			Init(poly);
        }

        /// <summary>
        /// Initializes the specified poly.
        /// </summary>
        /// <param name="poly">The poly.</param>
        private void Init(Polygon poly)
		{
			gridPen = new Pen(Color.LimeGreen);
			gridPen.DashStyle = DashStyle.Dot;
			axesPen = new Pen(Color.Snow);
			polyPen = new Pen(Color.Cyan, 3.0f);
			markPen = new Pen(Color.White);

			zoomTrackBar.Minimum = 0;
			zoomTrackBar.Maximum = zooms.Length - 1;
			zoomTrackBar.Value = defaultZoomIndex;
			UpdateZoom();

			// Fill in list of coordinates - select first one
			if (poly.Count > 0)
			{
				string[] cols = new string[2];
				for (int i = 0; i < poly.Count; i++)
				{
					cols[colX.Index] = poly[i].X.ToString("F2");
					cols[colY.Index] = poly[i].Y.ToString("F2");
					grid.Rows.Add(cols);
				}
				grid.Rows[0].Cells[0].Selected = true;
			}

			UpdatePoly();
			UpdateControls();
        }

        /// <summary>
        /// The zooms
        /// </summary>
        private static float[] zooms = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f,
										 0.6f, 0.7f, 0.8f, 0.9f, 1.0f,
										 1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
										 2.0f, 2.2f, 2.5f, 3.0f, 3.5f,
										 4.0f, 5.0f, 6.0f, 7.0f, 8.0f };

        /// <summary>
        /// The default zoom index
        /// </summary>
        private const int defaultZoomIndex = 9;

        /// <summary>
        /// The points
        /// </summary>
        private PointF[] points;

        /// <summary>
        /// The bad cells
        /// </summary>
        private bool badCells;

        /// <summary>
        /// Gets the polygon designed by the user.
        /// </summary>
        /// <value>The polygon designed by the user.</value>
		public Polygon Polygon
		{
            get { return new Polygon(points); }
		}

        /// <summary>
        /// Updates the zoom.
        /// </summary>
        private void UpdateZoom()
        {
            zoomLabel.Text = zooms[zoomTrackBar.Value].ToString("F1");
        }

        /// <summary>
        /// Updates the poly.
        /// </summary>
        private void UpdatePoly()
		{
			badCells = false;

			List<PointF> list = new List<PointF>();
			foreach (DataGridViewRow row in grid.Rows)
			{
				float x, y;
				if (Single.TryParse(row.Cells[colX.Index].FormattedValue.ToString(), out x) &&
					Single.TryParse(row.Cells[colY.Index].FormattedValue.ToString(), out y))
				{
					list.Add(new PointF(x, y));
				}
				else
				{
					badCells = true;
				}

			}
			points = list.ToArray();

			UpdateImage();
		}

        /// <summary>
        /// Updates the image.
        /// </summary>
        private void UpdateImage()
		{
			imagePanel.Invalidate();
		}

        /// <summary>
        /// Updates the controls.
        /// </summary>
        private void UpdateControls()
		{
			int sel = grid.SelectedCells.Count;

			delButton.Enabled  = (sel == 1);
			upButton.Enabled   = (sel == 1) && (grid.SelectedCells[0].RowIndex > 0);
			downButton.Enabled = (sel == 1) && (grid.SelectedCells[0].RowIndex < grid.Rows.Count - 1);

            okButton.Enabled = !badCells;
		}

        /// <summary>
        /// Handles the ValueChanged event of the zoomTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateZoom();
			UpdateImage();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the axesCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void axesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			UpdateImage();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the gridCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			UpdateImage();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
			UpdateImage();
			UpdateControls();
        }

        /// <summary>
        /// Handles the Click event of the addButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
			string[] cols = new string[grid.Columns.Count];
			if (grid.Rows.Count > 0)
			{
				cols[colX.Index] = grid.Rows[grid.Rows.Count - 1].Cells[colX.Index].FormattedValue.ToString();
				cols[colY.Index] = grid.Rows[grid.Rows.Count - 1].Cells[colY.Index].FormattedValue.ToString();
			}
			else
			{
				cols[colX.Index] = "0.0";
				cols[colY.Index] = "0.0";
			}
			int rowIndex = grid.Rows.Add(cols);

			UpdatePoly();
			grid.Rows[rowIndex].Cells[colX.Index].Selected = true;
			UpdateControls();

			grid.Focus();
        }

        /// <summary>
        /// Handles the Click event of the delButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void delButton_Click(object sender, EventArgs e)
        {
			int selRow = grid.SelectedCells[0].RowIndex;
			int selCol = grid.SelectedCells[0].ColumnIndex;

			grid.Rows.RemoveAt(selRow);
			if (grid.Rows.Count > 0)
			{
				if (grid.Rows.Count <= selRow)
				{
					selRow--;
				}
				grid.Rows[selRow].Cells[selCol].Selected = true;
			}

			UpdatePoly();

			grid.Focus();
        }

        /// <summary>
        /// Handles the Click event of the upButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void upButton_Click(object sender, EventArgs e)
        {
			DataGridViewCell sel = grid.SelectedCells[0];
			SwapRows(sel.RowIndex - 1);
			grid.Rows[sel.RowIndex - 1].Cells[sel.ColumnIndex].Selected = true;
			UpdatePoly();
        }

        /// <summary>
        /// Handles the Click event of the downButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void downButton_Click(object sender, EventArgs e)
        {
			DataGridViewCell sel = grid.SelectedCells[0];
			SwapRows(sel.RowIndex);
			grid.Rows[sel.RowIndex + 1].Cells[sel.ColumnIndex].Selected = true;
			UpdatePoly();
        }

        /// <summary>
        /// Swaps the rows.
        /// </summary>
        /// <param name="topRow">The top row.</param>
        private void SwapRows(int topRow)
		{
			SwapCells(topRow, colX.Index);
			SwapCells(topRow, colY.Index);
		}

        /// <summary>
        /// Swaps the cells.
        /// </summary>
        /// <param name="topRow">The top row.</param>
        /// <param name="col">The col.</param>
        private void SwapCells(int topRow, int col)
		{
			object o = grid.Rows[topRow].Cells[col].Value;
			grid.Rows[topRow].Cells[col].Value = grid.Rows[topRow + 1].Cells[col].Value;
			grid.Rows[topRow + 1].Cells[col].Value = o;
		}

        /// <summary>
        /// Handles the CellValidating event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellValidatingEventArgs"/> instance containing the event data.</param>
        private void grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
			float val;
			bool good = Single.TryParse(e.FormattedValue.ToString(), out val);
			grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = good ? DataGridView.DefaultBackColor : Color.LightCoral;
        }

        /// <summary>
        /// Handles the CellValidated event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void grid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
			UpdatePoly();
			UpdateControls();
        }

        /// <summary>
        /// The grid pen
        /// </summary>
        private Pen gridPen;
        /// <summary>
        /// The axes pen
        /// </summary>
        private Pen axesPen;
        /// <summary>
        /// The poly pen
        /// </summary>
        private Pen polyPen;
        /// <summary>
        /// The mark pen
        /// </summary>
        private Pen markPen;

        /// <summary>
        /// The mark radius
        /// </summary>
        private float markRadius = 5.0f;

        /// <summary>
        /// The zoom
        /// </summary>
        private float zoom;
        /// <summary>
        /// The mx
        /// </summary>
        private int mx;
        /// <summary>
        /// My
        /// </summary>
        private int my;

        /// <summary>
        /// Togs the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>PointF.</returns>
        private PointF Tog(PointF p)
		{
			return Tog(p.X, p.Y);
		}

        /// <summary>
        /// Togs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>PointF.</returns>
        private PointF Tog(float x, float y)
		{
			return new PointF((float)mx + x * zoom, (float)my - y * zoom);
		}

        /// <summary>
        /// Handles the Paint event of the imagePanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void imagePanel_Paint(object sender, PaintEventArgs e)
        {
			const int gridSize = 10;

			Graphics g = e.Graphics;
			Size cs = imagePanel.ClientSize;

            zoom = zooms[zoomTrackBar.Value] * gridSize;
			mx = cs.Width / 2;
            my = cs.Height / 2;

			if (gridCheckBox.Checked)
			{
				int gx = mx % gridSize;
				while (gx < cs.Width)
				{
					g.DrawLine(gridPen, gx, 0, gx, cs.Height - 1);
					gx += gridSize;
				}

				int gy = my % gridSize;
				while (gy < cs.Height)
				{
					g.DrawLine(gridPen, 0, gy, cs.Width - 1, gy);
					gy += gridSize;
				}
			}

			if (axesCheckBox.Checked)
			{
				g.DrawLine(axesPen, mx, 0, mx, cs.Height - 1);
				g.DrawLine(axesPen, 0, my, cs.Width - 1, my);
			}

            if (points.Length > 0)
            {
				PointF p1 = Tog(points[0]);
				if (points.Length == 1)
				{
                    g.DrawLine(polyPen, p1, p1);
				}
				else
				{
	                for (int i = 1; i < points.Length; i++)
    	            {
						PointF p2 = Tog(points[i]);
            	        g.DrawLine(polyPen, p1, p2);
						p1 = p2;
					}
                }

				if (grid.SelectedCells.Count == 1)
				{
					int row = grid.SelectedCells[0].RowIndex;
					PointF p = Tog(points[row]);
					float diam = 2.0f * markRadius;
					RectangleF r = new RectangleF(p.X - markRadius, p.Y - markRadius, diam, diam);
					g.DrawArc(markPen, r, 0.0f, 360.0f);
				}
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the imagePanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void imagePanel_SizeChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
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
    }

    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>Polygon</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly.</remarks>

    public class PolygonEditor : System.Drawing.Design.UITypeEditor
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
        /// Creates and displays a <c>PolygonEditorDialog</c> dialog if <c>value</c> is a <c>Polygon</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Polygon</c> being edited.</param>
        /// <returns>The new value of the <c>Polygon</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
										 System.IServiceProvider provider,
										 object value)
		{
			if (value is Polygon)
			{
				PolygonEditorDialog dialog = new PolygonEditorDialog((Polygon)value);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.Polygon;
				}
			}
			return value;
		}
	}
}
