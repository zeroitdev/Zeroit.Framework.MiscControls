// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="gGlowBox.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitGlowBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class ZeroitGlowBox : System.Windows.Forms.Panel
	{
        //Control overrides dispose to clean up the component list.
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Required by the Control Designer
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Component Designer
        // It can be modified using the Component Designer.  Do not modify it
        // using the code editor.
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
//INSTANT C# NOTE: Converted design-time event handler wireups:
			this.Layout += new LayoutEventHandler(gZeroitGlowBox_Layout);
			this.Resize += new System.EventHandler(gZeroitGlowBox_Resize);
			this.ControlAdded += new ControlEventHandler(gZeroitGlowBox_ControlAdded);
		}

	}


}