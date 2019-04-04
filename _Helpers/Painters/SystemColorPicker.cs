// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SystemColorPicker.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a categorized color picker using system colors.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.CatColorPicker" />
    public partial class SystemColorPicker : CatColorPicker
    {
        /// <summary>
        /// The system colors
        /// </summary>
        private ColorGroup systemColors = null;

        /// <summary>
        /// Generate color groups.
        /// </summary>
        /// <returns>Array of color groups.</returns>
		public override ColorGroup[] GenerateColorGroups()
		{
    		systemColors = new ColorGroup("System Colors");

			systemColors.Add(SystemColors.ActiveBorder);
			systemColors.Add(SystemColors.ActiveCaption);
			systemColors.Add(SystemColors.ActiveCaptionText);
			systemColors.Add(SystemColors.AppWorkspace);
			systemColors.Add(SystemColors.ButtonFace);
			systemColors.Add(SystemColors.ButtonHighlight);
			systemColors.Add(SystemColors.ButtonShadow);
			systemColors.Add(SystemColors.Control);
			systemColors.Add(SystemColors.ControlDark);
			systemColors.Add(SystemColors.ControlDarkDark);
			systemColors.Add(SystemColors.ControlLight);
			systemColors.Add(SystemColors.ControlLightLight);
			systemColors.Add(SystemColors.ControlText);
			systemColors.Add(SystemColors.Desktop);
			systemColors.Add(SystemColors.GradientActiveCaption);
			systemColors.Add(SystemColors.GradientInactiveCaption);
			systemColors.Add(SystemColors.GrayText);
			systemColors.Add(SystemColors.Highlight);
			systemColors.Add(SystemColors.HighlightText);
			systemColors.Add(SystemColors.HotTrack);
			systemColors.Add(SystemColors.InactiveBorder);
			systemColors.Add(SystemColors.InactiveCaption);
			systemColors.Add(SystemColors.InactiveCaptionText);
			systemColors.Add(SystemColors.Info);
			systemColors.Add(SystemColors.InfoText);
			systemColors.Add(SystemColors.Menu);
			systemColors.Add(SystemColors.MenuBar);
			systemColors.Add(SystemColors.MenuHighlight);
			systemColors.Add(SystemColors.MenuText);
			systemColors.Add(SystemColors.ScrollBar);
			systemColors.Add(SystemColors.Window);
			systemColors.Add(SystemColors.WindowFrame);
			systemColors.Add(SystemColors.WindowText);

            return new ColorGroup[] { systemColors };
		}

        /// <summary>
        /// Returns maximum number of columns (1).
        /// </summary>
        /// <returns>Maximum number of columns.</returns>
		public override int GetMaxColumnCount()
		{
			return 1;
		}

        /// <summary>
        /// Organizes the color groups depending on the number of columns being displayed.
        /// </summary>
        /// <param name="groups">Array of array of color groups.</param>
        /// <remarks>REALLY need an example!</remarks>
		public override void SplitColorGroups(ColorGroup[][] groups)
		{
			groups[0] = new ColorGroup[1];
			
			AddColorGroup(systemColors);
		}
    }
}

