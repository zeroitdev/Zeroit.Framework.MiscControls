// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBandClientArea.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBandClientArea.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [ToolboxItem(false)]
   public partial class NaviBandClientArea : ContainerControl
   {
        #region Fields

        /// <summary>
        /// The renderer
        /// </summary>
        NaviBandRenderer renderer;

        #endregion

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        public NaviBandClientArea()
      {
         InitializeComponent();
         Initialize();
      }

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        /// <param name="container">The container.</param>
        public NaviBandClientArea(IContainer container)
      {
         container.Add(this);
         InitializeComponent();
         Initialize();
      }

        #region Methods

        /// <summary>
        /// Initializes the control for the first time.
        /// </summary>
        private void Initialize()
      {
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ResizeRedraw, true);

         renderer = new NaviBandRendererOff7();
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         renderer.DrawBackground(e.Graphics, ClientRectangle);
      }

      #endregion
   }
}
