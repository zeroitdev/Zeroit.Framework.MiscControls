// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AdvancedFlowLayoutPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// FlowLayoutPanel with additional utillity behaviour
    /// </summary>
    /// <seealso cref="System.Windows.Forms.FlowLayoutPanel" />
    public class ZeroitPiperFlowPanel : FlowLayoutPanel
    {
        /// <summary>
        /// Handle the resize of panel
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(System.EventArgs e)
        {
            // for each child control
            foreach (Control c in Controls)
            {
                FillControlWidth(c); // scale the width to fill free horizontal space
            }

            // get all another resize stuff from base class
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Scale the width to fill free horizontal space of current panel
        /// </summary>
        /// <param name="c">control for scalling</param>
        protected void FillControlWidth(Control c)
        {
            c.Size = new System.Drawing.Size(ClientSize.Width - c.Margin.Left - c.Margin.Right, c.Height);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
