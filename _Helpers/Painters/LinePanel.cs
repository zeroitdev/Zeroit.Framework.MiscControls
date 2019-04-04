// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LinePanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Represents a control for displaying a line.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class LinePanel : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinePanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.UserPaint, true);

			this.UpdateStyles();

			line = new Line();
        }

        /// <summary>
        /// The line
        /// </summary>
        private Line line;
        /// <summary>
        /// Get line displayed in panel.
        /// </summary>
        /// <value>Line displayed in panel.</value>
        public Line Line
		{
			get { return line; }
			set
			{
				line = value;
				Invalidate();
			}
		}

        /// <summary>
        /// The orient
        /// </summary>
        private Orientation orient;
        /// <summary>
        /// Get display orientation of line.
        /// </summary>
        /// <value>Display orientation of line.</value>
        public Orientation Orientation
		{
			get { return orient; }
			set 
			{
				orient = value;
				Invalidate();
			}
		}

        /// <summary>
        /// Handles the Paint event of the LinePanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void LinePanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = line.GetPen();
			if (orient == Orientation.Horizontal)
			{
	            int y = ClientSize.Height / 2;
    	        e.Graphics.DrawLine(pen, 0, y, ClientSize.Width - 1, y);
			}
			else
			{
				int x = ClientSize.Width / 2;
				e.Graphics.DrawLine(pen, x, 0, x, ClientSize.Height - 1);
			}
        }
    }
}
