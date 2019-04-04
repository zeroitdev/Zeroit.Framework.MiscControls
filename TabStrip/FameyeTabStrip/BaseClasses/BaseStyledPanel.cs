// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-12-2018
// ***********************************************************************
// <copyright file="BaseStyledPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class BaseStyledPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [ToolboxItem(false)]
    public class BaseStyledPanel : ContainerControl
    {
        #region Fields

        /// <summary>
        /// The renderer
        /// </summary>
        private static ToolStripProfessionalRenderer renderer;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [theme changed].
        /// </summary>
        public event EventHandler ThemeChanged;

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes static members of the <see cref="BaseStyledPanel" /> class.
        /// </summary>
        static BaseStyledPanel()
        {
            renderer = new ToolStripProfessionalRenderer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStyledPanel" /> class.
        /// </summary>
        public BaseStyledPanel()
        {
            // Set painting style for better performance.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SystemColorsChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            UpdateRenderer();
            Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:ThemeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnThemeChanged(EventArgs e)
        {
            if (ThemeChanged != null)
                ThemeChanged(this, e);
        }

        /// <summary>
        /// Updates the renderer.
        /// </summary>
        private void UpdateRenderer()
        {
            if (!UseThemes)
            {
                renderer.ColorTable.UseSystemColors = true;
            }
            else
            {
                renderer.ColorTable.UseSystemColors = false;
            }
        }

        #endregion

        #region Props        
        /// <summary>
        /// Gets the tool strip renderer.
        /// </summary>
        /// <value>The tool strip renderer.</value>
        [Browsable(false)]
        public ToolStripProfessionalRenderer ToolStripRenderer
        {
            get { return renderer; }
        }

        /// <summary>
        /// Gets a value indicating whether to use themes.
        /// </summary>
        /// <value><c>true</c> if use themes; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Browsable(false)]
        public bool UseThemes
        {
            get
            {
                return VisualStyleRenderer.IsSupported && VisualStyleInformation.IsSupportedByOS && Application.RenderWithVisualStyles;
            }
        }

        #endregion
    }
}
