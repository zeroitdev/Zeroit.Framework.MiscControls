// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Enums.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region Enums

    /// <summary>
    /// Enumeration used for ExtendedPanel collapsing/expanding
    /// </summary>
    public enum Animation { No = 0, Yes = 1 };

    /// <summary>
    /// Enumeration for ExtendedPanel control to referr the 3 different status the control can be in
    /// </summary>
    public enum ExtendedPanelState { Expanded = 0, Collapsed = 1, Collapsing = 2, Expanding = 3 };

    /// <summary>
    /// How the corners are being rendered ; (used by CaptionCtrl to draw the borders
    /// </summary>
    public enum CornerStyle { Normal = 0, Rounded = 1 };

    /// <summary>
    /// Used by DirectionCtrl for drawing itself
    /// </summary>
    public enum DirectionStyle { Left = (int)(RotateFlipType.Rotate180FlipNone), Up = (int)(RotateFlipType.Rotate270FlipNone), Right = (int)(RotateFlipType.RotateNoneFlipNone), Down = (int)(RotateFlipType.Rotate90FlipNone) };

    /// <summary>
    /// Used in caption control and frametext for the background
    /// </summary>
    public enum BrushType { Solid = 0, Gradient = 1 };

    /// <summary>
    /// Defines the way text should be animated
    /// </summary>
    public enum TextAnimationMode { None = 0, Fading = 1, Typing = 2 };


    #endregion
}
