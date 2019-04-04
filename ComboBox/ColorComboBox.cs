// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ColorComboBox    
    /// <summary>
    /// A class collection for rendering a combo box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    public class ZeroitComboBoxColor : System.Windows.Forms.ComboBox
    {

        #region Variables

        /// <summary>
        /// The color array
        /// </summary>
        private string[] ColorArray = {

            "AliceBlue",
            "AntiqueWhite",
            "Aqua",
            "Aquamarine",
            "Azure",
            "Beige",
            "Bisque",
            "Black",
            "BlanchedAlmond",
            "Blue",
            "BlueViolet",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "CornflowerBlue",
            "Cornsilk",
            "Crimson",
            "Cyan",
            "DarkBlue",
            "DarkCyan",
            "DarkGoldenrod",
            "DarkGray",
            "DarkGreen",
            "DarkKhaki",
            "DarkMagenta",
            "DarkOliveGreen",
            "DarkOrange",
            "DarkOrchid",
            "DarkRed",
            "DarkSalmon",
            "DarkSeaGreen",
            "DarkSlateBlue",
            "DarkSlateGray",
            "DarkTurquoise",
            "DarkViolet",
            "DeepPink",
            "DeepSkyBlue",
            "DimGray",
            "DodgerBlue",
            "Firebrick",
            "FloralWhite",
            "ForestGreen",
            "Fuchsia",
            "Gainsboro",
            "GhostWhite",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "GreenYellow",
            "Honeydew",
            "HotPink",
            "IndianRed",
            "Indigo",
            "Ivory",
            "Khaki",
            "Lavender",
            "LavenderBlush",
            "LawnGreen",
            "LemonChiffon",
            "LightBlue",
            "LightCoral",
            "LightCyan",
            "LightGoldenrodYellow",
            "LightGray",
            "LightGreen",
            "LightPink",
            "LightSalmon",
            "LightSeaGreen",
            "LightSkyBlue",
            "LightSlateGray",
            "LightSteelBlue",
            "LightYellow",
            "Lime",
            "LimeGreen",
            "Linen",
            "Magenta",
            "Maroon",
            "MediumAquamarine",
            "MediumBlue",
            "MediumOrchid",
            "MediumPurple",
            "MediumSeaGreen",
            "MediumSlateBlue",
            "MediumSpringGreen",
            "MediumTurquoise",
            "MediumVioletRed",
            "MidnightBlue",
            "MintCream",
            "MistyRose",
            "Moccasin",
            "NavajoWhite",
            "Navy",
            "OldLace",
            "Olive",
            "OliveDrab",
            "Orange",
            "OrangeRed",
            "Orchid",
            "PaleGoldenrod",
            "PaleGreen",
            "PaleTurquoise",
            "PaleVioletRed",
            "PapayaWhip",
            "PeachPuff",
            "Peru",
            "Pink",
            "Plum",
            "PowderBlue",
            "Purple",
            "Red",
            "RosyBrown",
            "RoyalBlue",
            "SaddleBrown",
            "Salmon",
            "SandyBrown",
            "SeaGreen",
            "SeaShell",
            "Sienna",
            "Silver",
            "SkyBlue",
            "SlateBlue",
            "SlateGray",
            "Snow",
            "SpringGreen",
            "SteelBlue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Transparent",
            "Turquoise",
            "Violet",
            "Wheat",
            "White",
            "WhiteSmoke",
            "YellowGreen"
            
		// The colors that will be added to the ComboBox control. You can add your own colors to the ComboBox using "Colors" Property (look below) from the designer.
	};
        // This declaration is used to retrieve the color name and value from the color array, and also used to draw the color rectangle inside the ComboBox.
        /// <summary>
        /// The color
        /// </summary>
        private Color _Color;

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public string[] Colors
        {
            // This is a control property which can be modified from the control's property panel to add your own colors to the ComboBox.
            // By default, the colors in [ColorArray] are added. You can remove them if not desired.
            get
            {
                return ColorArray;
            }
            set
            {
                int ValNum = value.Length;
                ColorArray = new string[ValNum - 1 + 1];
                for (int i = 0; i <= ValNum - 1; i++)
                {
                    ColorArray[i] = value[i].ToString();
                }
                this.Items.Clear();
                InitializeComboBox();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitComboBoxColor" /> class.
        /// </summary>
        public ZeroitComboBoxColor()
        {
            // Initialize the control once it's added to the form designer.
            InitializeComboBox();
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = System.Windows.Forms.FlatStyle.System;
            BeginUpdate();
            InitializeComboBox();
            EndUpdate();
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            // Draw the selection background.
            if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
            {
                e.DrawBackground();
            }

            if (e.Index == -1)
            {
                return;
            }

            Graphics G = e.Graphics;

            // Get the color names of each item in the ComboBox. This is used to draw the string value in the ComboBox.
            _Color = Color.FromName((string)base.Items[e.Index]);

            // Draw rectangle which will contain the colors of the control's ColorArray.
            G.FillRectangle(new SolidBrush(_Color), 5, e.Bounds.Top + 2, 25, e.Bounds.Height - 5);
            // Draw a border around the color rectangle. You can remove the line below if you don't want a border to be drawn.
            G.DrawRectangle(Pens.Black, 5, e.Bounds.Top + 2, 25, e.Bounds.Height - 5);
            // Draw the string value of the chosen color depending on the selected item.
            G.DrawString(_Color.Name, e.Font, new SolidBrush(ForeColor), 33, ((e.Bounds.Height - this.Font.Height) / 2) + e.Bounds.Top);

            // Me.Invalidate() --> Makes the control more interactive by creating a dynamic hover-like pre-selection. You can remove this line if not desired.
            //                 +-> However, using [Invalidate] means that the control will keep on redrawing itself. Therefore, using it on Flat and Popup styles will cause the control to flicker.
        }

        /// <summary>
        /// Initializes the ComboBox.
        /// </summary>
        private void InitializeComboBox()
        {
            // Update the control.
            if (ColorArray == null)
            {
                return;
            }
            foreach (string Item in ColorArray)
            {
                try
                {
                    if (Color.FromName(Item).IsKnownColor)
                    {
                        this.Items.Add(Item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thrown Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        } 
        #endregion

    }
    #endregion
}
