// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="WebColorPicker.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
using System.Drawing;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Implements a categorized color picker using web colors.
    /// <para>
    /// The color groups were blatantly copied from www.wikipedia.org/en/web_colors.
    /// </para>
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.CatColorPicker" />
    public partial class WebColorPicker : CatColorPicker
    {
        /// <summary>
        /// The red colors
        /// </summary>
        private ColorGroup redColors    = null;
        /// <summary>
        /// The pink colors
        /// </summary>
        private ColorGroup pinkColors   = null;
        /// <summary>
        /// The orange colors
        /// </summary>
        private ColorGroup orangeColors = null;
        /// <summary>
        /// The yellow colors
        /// </summary>
        private ColorGroup yellowColors = null;
        /// <summary>
        /// The purple colors
        /// </summary>
        private ColorGroup purpleColors = null;
        /// <summary>
        /// The green colors
        /// </summary>
        private ColorGroup greenColors  = null;
        /// <summary>
        /// The blue colors
        /// </summary>
        private ColorGroup blueColors   = null;
        /// <summary>
        /// The brown colors
        /// </summary>
        private ColorGroup brownColors  = null;
        /// <summary>
        /// The white colors
        /// </summary>
        private ColorGroup whiteColors  = null;
        /// <summary>
        /// The gray colors
        /// </summary>
        private ColorGroup grayColors   = null;

        /// <summary>
        /// Generate color groups.
        /// </summary>
        /// <returns>Array of color groups.</returns>
		public override ColorGroup[] GenerateColorGroups()
		{
    		redColors = new ColorGroup("Red Colors");
			redColors.Add(Color.IndianRed);
			redColors.Add(Color.LightCoral);
			redColors.Add(Color.Salmon);
			redColors.Add(Color.DarkSalmon);
			redColors.Add(Color.LightSalmon);
			redColors.Add(Color.Red);
			redColors.Add(Color.Crimson);
			redColors.Add(Color.Firebrick);
			redColors.Add(Color.DarkRed);

            pinkColors = new ColorGroup("Pink Colors");
			pinkColors.Add(Color.Pink);
			pinkColors.Add(Color.LightPink);
			pinkColors.Add(Color.HotPink);
			pinkColors.Add(Color.DeepPink);
			pinkColors.Add(Color.MediumVioletRed);
			pinkColors.Add(Color.PaleVioletRed);

			orangeColors = new ColorGroup("Orange Colors");
			orangeColors.Add(Color.LightSalmon);
			orangeColors.Add(Color.Coral);
			orangeColors.Add(Color.Tomato);
			orangeColors.Add(Color.OrangeRed);
			orangeColors.Add(Color.DarkOrange);
			orangeColors.Add(Color.Orange);

			yellowColors = new ColorGroup("Yellow Colors");
			yellowColors.Add(Color.Gold);
			yellowColors.Add(Color.Yellow);
			yellowColors.Add(Color.LightYellow);
			yellowColors.Add(Color.LemonChiffon);
			yellowColors.Add(Color.LightGoldenrodYellow);
			yellowColors.Add(Color.PapayaWhip);
			yellowColors.Add(Color.Moccasin);
			yellowColors.Add(Color.PeachPuff);
			yellowColors.Add(Color.PaleGoldenrod);
			yellowColors.Add(Color.Khaki);
			yellowColors.Add(Color.DarkKhaki);

			purpleColors = new ColorGroup("Purple Colors");
			purpleColors.Add(Color.Lavender);
			purpleColors.Add(Color.Thistle);
			purpleColors.Add(Color.Plum);
			purpleColors.Add(Color.Violet);
			purpleColors.Add(Color.Orchid);
			purpleColors.Add(Color.Fuchsia);
			purpleColors.Add(Color.Magenta);
			purpleColors.Add(Color.MediumOrchid);
			purpleColors.Add(Color.MediumPurple);
			purpleColors.Add(Color.BlueViolet);
			purpleColors.Add(Color.DarkViolet);
			purpleColors.Add(Color.DarkOrchid);
			purpleColors.Add(Color.DarkMagenta);
			purpleColors.Add(Color.Purple);
			purpleColors.Add(Color.Indigo);
			purpleColors.Add(Color.DarkSlateBlue);
			purpleColors.Add(Color.SlateBlue);
			purpleColors.Add(Color.MediumSlateBlue);

			greenColors = new ColorGroup("Green Colors");
			greenColors.Add(Color.GreenYellow);
			greenColors.Add(Color.Chartreuse);
			greenColors.Add(Color.LawnGreen);
			greenColors.Add(Color.Lime);
			greenColors.Add(Color.LimeGreen);
			greenColors.Add(Color.PaleGreen);
			greenColors.Add(Color.LightGreen);
			greenColors.Add(Color.MediumSpringGreen);
			greenColors.Add(Color.SpringGreen);
			greenColors.Add(Color.MediumSeaGreen);
			greenColors.Add(Color.SeaGreen);
			greenColors.Add(Color.ForestGreen);
			greenColors.Add(Color.Green);
			greenColors.Add(Color.DarkGreen);
			greenColors.Add(Color.YellowGreen);
			greenColors.Add(Color.OliveDrab);
			greenColors.Add(Color.Olive);
			greenColors.Add(Color.DarkOliveGreen);
			greenColors.Add(Color.MediumAquamarine);
			greenColors.Add(Color.DarkSeaGreen);
			greenColors.Add(Color.LightSeaGreen);
			greenColors.Add(Color.DarkCyan);
			greenColors.Add(Color.Teal);

			blueColors = new ColorGroup("Blue Colors");
			blueColors.Add(Color.Cyan);
			blueColors.Add(Color.LightCyan);
			blueColors.Add(Color.PaleTurquoise);
			blueColors.Add(Color.Aquamarine);
			blueColors.Add(Color.Turquoise);
			blueColors.Add(Color.MediumTurquoise);
			blueColors.Add(Color.DarkTurquoise);
			blueColors.Add(Color.CadetBlue);
			blueColors.Add(Color.SteelBlue);
			blueColors.Add(Color.LightSteelBlue);
			blueColors.Add(Color.PowderBlue);
			blueColors.Add(Color.LightBlue);
			blueColors.Add(Color.SkyBlue);
			blueColors.Add(Color.LightSkyBlue);
			blueColors.Add(Color.DeepSkyBlue);
			blueColors.Add(Color.DodgerBlue);
			blueColors.Add(Color.CornflowerBlue);
			blueColors.Add(Color.RoyalBlue);
			blueColors.Add(Color.Blue);
			blueColors.Add(Color.MediumBlue);
			blueColors.Add(Color.DarkBlue);
			blueColors.Add(Color.Navy);
			blueColors.Add(Color.MidnightBlue);

    		brownColors = new ColorGroup("Brown Colors");
			brownColors.Add(Color.Cornsilk);
			brownColors.Add(Color.BlanchedAlmond);
			brownColors.Add(Color.Bisque);
			brownColors.Add(Color.NavajoWhite);
			brownColors.Add(Color.Wheat);
			brownColors.Add(Color.BurlyWood);
			brownColors.Add(Color.Tan);
			brownColors.Add(Color.RosyBrown);
			brownColors.Add(Color.SandyBrown);
			brownColors.Add(Color.Goldenrod);
			brownColors.Add(Color.DarkGoldenrod);
			brownColors.Add(Color.Peru);
			brownColors.Add(Color.Chocolate);
			brownColors.Add(Color.SaddleBrown);
			brownColors.Add(Color.Sienna);
			brownColors.Add(Color.Brown);
			brownColors.Add(Color.Maroon);

			whiteColors = new ColorGroup("White Colors");
			whiteColors.Add(Color.White);
			whiteColors.Add(Color.Snow);
			whiteColors.Add(Color.Honeydew);
			whiteColors.Add(Color.MintCream);
			whiteColors.Add(Color.Azure);
			whiteColors.Add(Color.AliceBlue);
			whiteColors.Add(Color.GhostWhite);
			whiteColors.Add(Color.WhiteSmoke);
			whiteColors.Add(Color.SeaShell);
			whiteColors.Add(Color.Beige);
			whiteColors.Add(Color.OldLace);
			whiteColors.Add(Color.FloralWhite);
			whiteColors.Add(Color.Ivory);
			whiteColors.Add(Color.AntiqueWhite);
			whiteColors.Add(Color.Linen);
			whiteColors.Add(Color.LavenderBlush);
			whiteColors.Add(Color.MistyRose);

			grayColors = new ColorGroup("Gray Colors");
			grayColors.Add(Color.Gainsboro);
			grayColors.Add(Color.LightGray);
			grayColors.Add(Color.Silver);
			grayColors.Add(Color.DarkGray);
			grayColors.Add(Color.Gray);
			grayColors.Add(Color.DimGray );
			grayColors.Add(Color.LightSlateGray);
			grayColors.Add(Color.SlateGray);
			grayColors.Add(Color.DarkSlateGray);
			grayColors.Add(Color.Black);

			return new ColorGroup[]
						{
							redColors,
							pinkColors,
							orangeColors,
							yellowColors,
							purpleColors,
							greenColors,
							blueColors,
							brownColors,
							whiteColors,
							grayColors
						};
		}

        /// <summary>
        /// Returns maximum number of columns (3).
        /// </summary>
        /// <returns>Maximum number of columns.</returns>
		public override int GetMaxColumnCount()
		{
			return 3;
		}

        /// <summary>
        /// Organizes the color groups depending on the number of columns being displayed.
        /// </summary>
        /// <param name="groups">Array of array of color groups.</param>
        /// <remarks>REALLY need an example!</remarks>
		public override void SplitColorGroups(ColorGroup[][] groups)
		{
			switch (groups.Length)
			{
			case 1 : groups[0] = new ColorGroup[10]; break;
			case 2 : groups[0] = new ColorGroup[6];
					 groups[1] = new ColorGroup[4]; break;
			case 3 : groups[0] = new ColorGroup[5];
					 groups[1] = new ColorGroup[2];
					 groups[2] = new ColorGroup[3]; break;
            default: Debug.Assert(true); break;
			}
			
			AddColorGroup(redColors);
			AddColorGroup(pinkColors);
			AddColorGroup(orangeColors);
			AddColorGroup(yellowColors);
			AddColorGroup(purpleColors);
			AddColorGroup(greenColors);
			AddColorGroup(blueColors);
			AddColorGroup(brownColors);
			AddColorGroup(whiteColors);
			AddColorGroup(grayColors);
		}
    }
}
