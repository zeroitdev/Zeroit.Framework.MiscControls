// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-12-2018
// ***********************************************************************
// <copyright file="BaseStyledPanel.cs" company="Zeroit Dev Technologies">
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
