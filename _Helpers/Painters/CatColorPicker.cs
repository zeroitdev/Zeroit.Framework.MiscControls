// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="CatColorPicker.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Base class for a categorized color picker control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker" />
    /// <remarks>Colors are categorized into color groups, represented by the <c>ColorGroup</c> class.
    /// For each group, the group title is displayed, followed by each of the colors in the group.
    /// Each color is displayed in a color box followed by the name of the color.
    /// The groups can optionally be displayed using multiple columns.</remarks>
    public abstract partial class CatColorPicker : BaseColorPicker
    {
        /// <summary>
        /// Constructor with no starting color.
        /// </summary>
        public CatColorPicker() : this(Color.Empty)
        { }

        /// <summary>
        /// Constructor with starting color.
        /// </summary>
        /// <param name="color">Starting color.</param>
        public CatColorPicker(Color color)
        {
            InitializeComponent();

			panel.SetInputKeys(new Keys[] { Keys.Up,
											Keys.Down,
											Keys.Left,
											Keys.Right,
											Keys.PageUp,
											Keys.PageDown,
											Keys.Home,
											Keys.End,
											Keys.Enter,
											Keys.Space });

			colorGroupList = GenerateColorGroups();

			RecalcLayout();

			SetColor(color);

			panel.Focus();
        }

        /// <summary>
        /// The color group list
        /// </summary>
        private ColorGroup[] colorGroupList = null;

        /// <summary>
        /// Gets the current selected color.
        /// </summary>
        /// <value>Current selected color.</value>
		public Color Color
		{
			get
			{
				if (selGroup != null)
				{
					return selGroup.Colors[selIndex];
				}
				return Color.Empty;
			}
		}

        /// <summary>
        /// Gets the name of current selected color.
        /// </summary>
        /// <value>Name of current selected color.</value>
		public string ColorName
		{
			get 
			{
				Color c = this.Color;
				if (c.IsEmpty)
				{
					return string.Empty;
				}
				return c.Name;
			}
		}

        /// <summary>
        /// Set current selected color.
        /// </summary>
        /// <param name="color">Current color.</param>
        /// <returns><c>True</c> if <c>color</c> exists, <c>false</c> otherwise.</returns>
		public override bool SetColor(Color color)
		{
			for (int column = 0; column < columnCount; column++)
			{
				for (int gi = 0; gi < colorGroups[column].Length; gi++)
				{
					for (int ci = 0; ci < colorGroups[column][gi].Colors.Length; ci++)
					{
						if (colorGroups[column][gi].Colors[ci].ToArgb() == color.ToArgb())
						{
							selGroup = colorGroups[column][gi];
							selIndex = ci;
							ScrollToMakeSelColorVisible();
							panel.Invalidate();
							return true;
						}
					}
				}
			}
			selGroup = null;
			selIndex = -1;
			return false;
		}

        /// <summary>
        /// The title font
        /// </summary>
        private Font titleFont = new Font(Control.DefaultFont.Name,
										  Control.DefaultFont.Size,
										  Control.DefaultFont.Style | FontStyle.Bold);

        /// <summary>
        /// Gets or sets the font to be used for group titles.
        /// </summary>
        /// <value>Group title text font.</value>
        /// <exception cref="ArgumentNullException">TitleFont</exception>
        [Category("Appearance")]
		public Font TitleFont
		{
			get { return titleFont; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("TitleFont");
				}
				titleFont = value;
				RecalcLayout();
				Invalidate();
			}
		}

        /// <summary>
        /// The title color
        /// </summary>
        private Color titleColor = Color.DarkGray;
        /// <summary>
        /// Gets or sets the color to be used for group titles.
        /// </summary>
        /// <value>Group title text color.</value>
        [Category("Appearance"), DefaultValue("DarkGray")]
		public Color TitleColor
		{
			get { return titleColor; }
			set
			{
				if (titleColor.ToArgb() != value.ToArgb())
				{
					titleColor = value;
					ClearTitleBrush();
					Invalidate();
				}
			}
		}

        /// <summary>
        /// The color font
        /// </summary>
        private Font colorFont = Control.DefaultFont;
        /// <summary>
        /// Gets or sets the font to be used for color names.
        /// </summary>
        /// <value>Color name text font.</value>
        /// <exception cref="ArgumentNullException">ColorFont</exception>
        [Category("Appearance")]
		public Font ColorFont
		{
			get { return colorFont; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("ColorFont");
				}
				colorFont = value;
				RecalcLayout();
				Invalidate();
			}
		}

        /// <summary>
        /// The color box width
        /// </summary>
        private int colorBoxWidth = 40;
        /// <summary>
        /// Gets or sets the pixel width of the color box.
        /// The color box is displayed beside the color name.
        /// </summary>
        /// <value>Pixel width of color box.</value>
        [Category("Appearance"), DefaultValue("40")]
		public int ColorBoxWidth
		{
			get { return colorBoxWidth; }
			set
			{
				int val = Math.Max(8, value);
				if (val != colorBoxWidth)
				{
					colorBoxWidth = val;
					RecalcLayout();
					Invalidate();
				}
			}
		}

        /// <summary>
        /// The color box offset
        /// </summary>
        private int colorBoxOffset = 2;
        /// <summary>
        /// Gets or set the color box pixel offset.
        /// This is the number of pixels of space on all sides of the color box.
        /// </summary>
        /// <value>Color box pixel offset.</value>
        [Category("Appearance"), DefaultValue("2")]
		public int ColorBoxOffset
		{
			get { return colorBoxOffset; }
			set
			{
				int val = Math.Max(0, value);
				if (val != colorBoxOffset)
				{
					colorBoxOffset = val;
					RecalcLayout();
					Invalidate();
				}
			}
		}

        /// <summary>
        /// The minimum column width
        /// </summary>
        private int minColumnWidth = 0;
        /// <summary>
        /// The row height
        /// </summary>
        private int rowHeight = 0;

        /// <summary>
        /// The column count
        /// </summary>
        private int columnCount = 0;
        /// <summary>
        /// The column width
        /// </summary>
        private int[] columnWidth;
        /// <summary>
        /// The column x
        /// </summary>
        private int[] columnX;
        /// <summary>
        /// The color groups
        /// </summary>
        private ColorGroup[][] colorGroups = null;
        /// <summary>
        /// The row count
        /// </summary>
        private int[] rowCount = null;

        /// <summary>
        /// The maximum row count
        /// </summary>
        private int maxRowCount;
        /// <summary>
        /// The full rows displayed
        /// </summary>
        private int fullRowsDisplayed;
        /// <summary>
        /// The partial rows displayed
        /// </summary>
        private int partialRowsDisplayed;

        /// <summary>
        /// The color text offset
        /// </summary>
        private int colorTextOffset;

        /// <summary>
        /// The sel group
        /// </summary>
        private ColorGroup selGroup;
        /// <summary>
        /// The sel index
        /// </summary>
        private int selIndex; // index of selGroup.Colors[] for selected color

        /// <summary>
        /// Recalcs the layout.
        /// </summary>
        private void RecalcLayout()
		{
			if (colorGroupList == null)
			{
				return;
			}

			colorTextOffset = colorBoxOffset + colorBoxWidth + colorBoxOffset;

			Graphics g = CreateGraphics();

			minColumnWidth = 0;
			rowHeight = 0;

			foreach (ColorGroup group in colorGroupList)
			{
				CalcSizes(g, group);
			}

			g.Dispose();

			RecalcLayout2();
		}

        /// <summary>
        /// Recalcs the layout2.
        /// </summary>
        private void RecalcLayout2()
		{
			if (colorGroupList == null || minColumnWidth == 0)
			{
				return;
			}

			int twoColumnWidth = 2 * minColumnWidth;
			columnCount = 1;
			if (panel.ClientSize.Width >= twoColumnWidth && GetMaxColumnCount() > 1)
			{
				columnCount++;
				int threeColumnWidth = twoColumnWidth + minColumnWidth;
				if (panel.ClientSize.Width >= threeColumnWidth && GetMaxColumnCount() > 2)
				{
					columnCount++;
				}
			}

			int columnSpace = panel.ClientSize.Width;
			columnWidth = new int[columnCount];
			columnX = new int[columnCount];
			columnWidth[0] = columnSpace / columnCount;
			columnX[0] = 0;
			if (columnCount > 1)
			{
				columnSpace -= columnWidth[0];
				columnWidth[1] = columnSpace / (columnCount - 1);
				columnX[1] = columnWidth[0];
				if (columnCount > 2)
				{
					columnWidth[2] = columnSpace - columnWidth[1];
					columnX[2] = columnX[1] + columnWidth[1];
				}
			}

			// Break up list of color groups into columns

			colorGroups = new ColorGroup[columnCount][];
			SplitColorGroups(colorGroups);

			maxRowCount = 0;
			rowCount = new int[columnCount];
			for (int c = 0; c < columnCount; c++)
			{
				rowCount[c] = 0;
				for (int s = 0; s < colorGroups[c].Length; s++)
				{
					rowCount[c] += colorGroups[c][s].Colors.Length + 1; // + 1 for title
				}
				maxRowCount = Math.Max(maxRowCount, rowCount[c]);
			}

			fullRowsDisplayed = Math.Min(maxRowCount, panel.ClientSize.Height / rowHeight);
			partialRowsDisplayed = ((panel.ClientSize.Height % rowHeight) > 0) ? 1 : 0;

			int large;
			if ((fullRowsDisplayed + partialRowsDisplayed) == 1)
			{
				large = 1;
			}
			else
			{
				large = fullRowsDisplayed + partialRowsDisplayed - 1;
			}
            int maxVal = Math.Max(0, maxRowCount - large);

			// Update scroll bar max
			vScrollBar.Maximum = maxRowCount - 1;
			vScrollBar.LargeChange = large;
			if (vScrollBar.Value > maxVal)
			{
				vScrollBar.Value = maxVal;
			}
			vScrollBar.Enabled = (fullRowsDisplayed < maxRowCount);
		}

        /// <summary>
        /// Add color group.
        /// Intended to be called by the derived class from within an overridden <c>SplitColorGroups</c>.
        /// </summary>
        /// <param name="colorGroup"><c>ColorGroup</c> object to add.</param>
		protected void AddColorGroup(ColorGroup colorGroup)
		{
			for (int c = 0; c < colorGroups.Length; c++)
			{
				for (int s = 0; s < colorGroups[c].Length; s++)
				{
					if (colorGroups[c][s] == null)
					{
						colorGroups[c][s] = colorGroup;
						return;
					}
				}
			}
			Debug.Assert(false);
		}

        /// <summary>
        /// Scrolls to make sel color visible.
        /// </summary>
        private void ScrollToMakeSelColorVisible()
		{
			int column = -1;
			int row = -1;
			int gi = 0;
			int ci = -1;

			if (GetSelColorLocation(ref column, ref row, ref gi, ref ci))
			{
				if (row < vScrollBar.Value)
				{
					vScrollBar.Value = row;
				}
				else if (row >= vScrollBar.Value + fullRowsDisplayed)
				{
					vScrollBar.Value = row - fullRowsDisplayed + 1;
				}
                panel.Invalidate();
			}
		}

        /// <summary>
        /// Handles the SizeChanged event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void panel_SizeChanged(object sender, EventArgs e)
        {
			RecalcLayout2();
			panel.Invalidate();
        }

        /// <summary>
        /// Handles the Scroll event of the vScrollBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
			panel.Invalidate();
        }

        /// <summary>
        /// Handles the KeyDown event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void panel_KeyDown(object sender, KeyEventArgs e)
        {
			if (   e.KeyCode == Keys.Up
				|| e.KeyCode == Keys.Down
			    || e.KeyCode == Keys.Left
			    || e.KeyCode == Keys.Right
			    || e.KeyCode == Keys.PageUp
			    || e.KeyCode == Keys.PageDown
			    || e.KeyCode == Keys.Home
			    || e.KeyCode == Keys.End)
		    {
                ChangeSelKey(e.KeyCode);
				e.Handled = true;
		    }
			else if (   e.KeyCode == Keys.Enter
					 || e.KeyCode == Keys.Space)
			{
				if (selGroup != null)
				{
                    SelectColor(selGroup.Colors[selIndex]);
				}
				e.Handled = true;
			}
			else
			{
				e.Handled = false;
			}
		}

        /// <summary>
        /// Changes the sel key.
        /// </summary>
        /// <param name="key">The key.</param>
        private void ChangeSelKey(Keys key)
		{
			int column = -1;
			int row = -1;
			int gi = -1;
			int ci = -1;
			bool blankLine = false;

			if (!GetSelColorLocation(ref column, ref row, ref gi, ref ci))
			{
				column = 0;
				gi = 0;
				ci = 0;
			}
			else if (key == Keys.Up)
			{
				if (ci > 0 || gi > 0) // go up only if not at first row
				{
					PrevRow(column, ref gi, ref ci);
					if (ci == -1) // if we hit title line, go up another line
					{
						PrevRow(column, ref gi, ref ci);
					}
				}
			}
			else if (key == Keys.Down)
			{
				if (gi < colorGroups[column].Length - 1 || ci < colorGroups[column][gi].Colors.Length - 1) // go down only if not at last row
				{
					NextRow(column, ref gi, ref ci, ref blankLine);
					if (ci == -1) // if we hit title line, go down another line
					{
						NextRow(column, ref gi, ref ci, ref blankLine);
					}
				}
			}
			else if (key == Keys.Home) // goto top of current column
			{
				gi = 0;
				ci = 0;
			}
			else if (key == Keys.End) // goto bottom of current column
			{
				gi = colorGroups[column].Length - 1;
				ci = colorGroups[gi][ci].Colors.Length - 1;
			}
			else if (key == Keys.PageUp) // goto top of previous group
			{
				gi = Math.Max(0, gi - 1);
				ci = 0;
			}
			else if (key == Keys.PageDown) // goto top of next group
			{
				gi = Math.Min(colorGroups[column].Length - 1, gi + 1);
				ci = 0;
			}
			else // Left or Right
			{
				if (key == Keys.Left && column > 0)
				{
					column--;
				}
				else if (key == Keys.Right && column < columnCount - 1)
				{
					column++;
				}

				gi = 0;
				ci = -1;
				for (int r = 0; r < row; r++)
				{
					NextRow(column, ref gi, ref ci, ref blankLine);
				}

				if (blankLine || ci == -1) // if gone too far, or hit title line, go back up one line
				{
					PrevRow(column, ref gi, ref ci);
				}
			}

			selGroup = colorGroups[column][gi];
			selIndex = ci;
			ScrollToMakeSelColorVisible();
        }

        /// <summary>
        /// Handles the MouseClick event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
			int row = e.Y / rowHeight;
			int col = 0;
			for (col = columnCount - 1; col >= 0; col--)
			{
				if (e.X >= columnX[col])
				{
					break;
				}
			}

			// Find color for this row and col
			int gi = 0;
			int ci = -1;
			bool blankLine = false;
			for (int r = 0; r < vScrollBar.Value + row; r++)
			{
				NextRow(col, ref gi, ref ci, ref blankLine);
			}

			if (ci == -1 || blankLine)
			{
				return;
			}

            SelectColor(colorGroups[col][gi].Colors[ci]);
        }

        /// <summary>
        /// The title brush
        /// </summary>
        private SolidBrush titleBrush = null;

        /// <summary>
        /// Allocs the title brush.
        /// </summary>
        private void AllocTitleBrush()
		{
			if (titleBrush == null)
			{
				titleBrush = new SolidBrush(titleColor);
			}
		}

        /// <summary>
        /// Clears the title brush.
        /// </summary>
        private void ClearTitleBrush()
		{
			if (titleBrush != null)
			{
				titleBrush.Dispose();
				titleBrush = null;
			}
		}

        /// <summary>
        /// Handles the Paint event of the panel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
			if (minColumnWidth == 0 || rowHeight == 0)
			{
				return;
			}

			AllocTitleBrush();

			// Paint each column
			for (int c = 0; c < columnCount; c++)
			{
				// Find starting row in this column
				int gi = 0;
				int ci = -1;
				bool blankLine = false;

				for (int r = 0; r < vScrollBar.Value; r++)
				{
					NextRow(c, ref gi, ref ci, ref blankLine);
				}

				// Paint each visible row
				for (int r = 0; r < fullRowsDisplayed + partialRowsDisplayed; r++)
				{
					Rectangle rect = new Rectangle(columnX[c],
												   rowHeight * r,
												   columnWidth[c],
												   rowHeight);

                    if (blankLine)
                    {
	                    e.Graphics.FillRectangle(SystemBrushes.Window, rect);
                        continue;
                    }
												   
					ColorGroup g = colorGroups[c][gi];

					if (ci == -1 )
					{
	                    e.Graphics.FillRectangle(SystemBrushes.Window, rect);
						e.Graphics.DrawString(g.Title, titleFont, titleBrush, rect, StringFormat.GenericDefault);
					}
					else
					{
						Color color = g.Colors[ci];
						bool sel = (selGroup == g) && (selIndex == ci);

						// Background color
	                    e.Graphics.FillRectangle(sel ? SystemBrushes.Highlight : SystemBrushes.Window, rect);

						// Draw color box
						Brush colorBrush = new SolidBrush(color);
						Rectangle colorRect = new Rectangle(rect.X + colorBoxOffset,
															rect.Y + colorBoxOffset,
															colorBoxWidth,
															rect.Height - 2 * colorBoxOffset);
						e.Graphics.FillRectangle(colorBrush, colorRect);
						e.Graphics.DrawRectangle(SystemPens.WindowText, colorRect);
						colorBrush.Dispose();

						// Text
						Rectangle textRect = new Rectangle(rect.X + colorTextOffset,
														   rect.Y,
														   rect.Width - colorTextOffset,
														   rect.Height);
						e.Graphics.DrawString(" " + color.Name, colorFont,
											  sel ? SystemBrushes.HighlightText : SystemBrushes.WindowText,
											  textRect, StringFormat.GenericDefault);
					}

					NextRow(c, ref gi, ref ci, ref blankLine);
				}
			}
        }

        /// <summary>
        /// Gets the sel color location.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <param name="gi">The gi.</param>
        /// <param name="ci">The ci.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool GetSelColorLocation(ref int column, ref int row, ref int gi, ref int ci)
		{
			if (selGroup == null)
			{
				return false;
			}
			for (column = 0; column < columnCount; column++)
			{
				row = 0;
				for (gi = 0; gi < colorGroups[column].Length; gi++)
				{
					if (colorGroups[column][gi] == selGroup)
					{
						ci = selIndex;
						row += selIndex + 1;
						return true;
					}
					row += colorGroups[column][gi].Colors.Length + 1; // +1 for title
				}
			}
			return false;
		}

        // column is the first index:
        //   colorGroups[column]
        // gi is the group index for the column
        //   colorGroups[column][gi]
        // ci is the color index
        //   title if ci == -1, else
        //   colorGroups[column][gi].Colors[ci]

        /// <summary>
        /// Previouses the row.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="gi">The gi.</param>
        /// <param name="ci">The ci.</param>
        private void PrevRow(int column, ref int gi, ref int ci)
		{
			if (ci >= 0)
			{
				ci--;
			}
			else if (gi > 0)
			{
				gi--;
				ci = colorGroups[column][gi].Colors.Length - 1;
			}
		}

        /// <summary>
        /// Nexts the row.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="gi">The gi.</param>
        /// <param name="ci">The ci.</param>
        /// <param name="blankLine">if set to <c>true</c> [blank line].</param>
        private void NextRow(int column, ref int gi, ref int ci, ref bool blankLine)
		{
			if (!blankLine)
			{
				ci++;
				if (ci >= colorGroups[column][gi].Colors.Length)
				{
					gi++;
					ci = -1;
					if (gi >= colorGroups[column].Length)
					{
						blankLine = true;
					}
				}
			}
		}

        /// <summary>
        /// Calculates the sizes.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="group">The group.</param>
        private void CalcSizes(Graphics g, ColorGroup group)
		{
			if (group == null)
			{
				return;
			}

			SizeF sf = g.MeasureString(group.Title + " ", titleFont);
			minColumnWidth = Math.Max(minColumnWidth, (int)Math.Ceiling(sf.Width));
			rowHeight = Math.Max(rowHeight, (int)Math.Ceiling(sf.Height));

			for (int c = 0; c < group.Colors.Length; c++)
			{
				sf = g.MeasureString(" " + group.Colors[c].Name + " ", colorFont);
				minColumnWidth = Math.Max(minColumnWidth, colorTextOffset + (int)Math.Ceiling(sf.Width));
				rowHeight = Math.Max(rowHeight, (int)Math.Ceiling(sf.Height));
			}
		}

        // Methods implemented by derived class...

        /// <summary>
        /// Generate array of color groups.
        /// Implemented by derived class.
        /// </summary>
        /// <returns>Array of <c>ColorGroup</c> objects.</returns>
        abstract public ColorGroup[] GenerateColorGroups();

        /// <summary>
        /// Return maximum number of columns which may be displayed.
        /// </summary>
        /// <returns>Maximum number of columns which may be displayed.</returns>
		abstract public int GetMaxColumnCount();

        /// <summary>
        /// Return organization of color groups for a particular number of display columns.
        /// <para>
        /// The number of columns is <c>groups.Length</c>.
        /// The derived class must allocate the <c>ColorGroup</c> arrays for each column index,
        /// and then call <c>AddColorGroup</c> to add each group in order.
        /// </para>
        /// </summary>
        /// <param name="groups">Array of arrays of <c>ColorGroup</c> objects.</param>
        /// <remarks>REALLY need an example!</remarks>
		abstract public void SplitColorGroups(ColorGroup[][] groups);
    }

    /// <summary>
    /// Class representing a color group.
    /// </summary>
	public class ColorGroup
	{
        /// <summary>
        /// Constructor with title.
        /// </summary>
        /// <param name="title">Title of color group.</param>
        public ColorGroup(string title)
		{
			this.title = title;
			this.colors = new List<Color>();
		}

        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// Gets the title of this color group.
        /// </summary>
        /// <value>Title of this color group.</value>
        public string Title
		{
			get { return title; }
		}

        /// <summary>
        /// The colors
        /// </summary>
        private List<Color> colors;
        /// <summary>
        /// Add color to this group.
        /// </summary>
        /// <param name="color">Color to add.</param>
        public void Add(Color color)
		{
			colors.Add(color);
		}

        /// <summary>
        /// Gets the current array of colors in this group.
        /// </summary>
        /// <value>Array of colors in this group.</value>
        public Color[] Colors
		{
			get { return colors.ToArray(); }
		}

        /// <summary>
        /// Returns a string representation of this color group.
        /// </summary>
        /// <returns>Display string.</returns>
		public override string ToString()
		{
			return string.Format("ColorGroup {0} [{1} items]", title, colors.Count);
		}
    }
}
