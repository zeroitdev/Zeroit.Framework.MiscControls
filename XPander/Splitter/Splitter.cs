// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Splitter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Splitter

    #region Control
    /// <summary>
    /// Represents a splitter control that enables the user to resize docked controls.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Splitter" />
    /// <copyright>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    /// <remarks>The splitter control supports in difference to the <see cref="System.Windows.Forms.Splitter" /> the using
    /// of a transparent backcolor.</remarks>
    [DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Splitter))]
    public partial class ZeroitProSplitter : System.Windows.Forms.Splitter
    {
        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the Splitter class.
        /// </summary>
        public ZeroitProSplitter()
        {
            //The System.Windows.Forms.Splitter doesn't suports a transparent backcolor
            //With this, the using of a transparent backcolor is possible
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        #endregion
    }
    #endregion

    #region Designer Generated Code
    partial class ZeroitProSplitter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
    #endregion

    #endregion
}
