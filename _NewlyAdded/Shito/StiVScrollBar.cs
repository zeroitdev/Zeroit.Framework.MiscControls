// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="StiVScrollBar.cs" company="Zeroit Dev Technologies">
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

using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a standard Windows vertical scroll bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.VScrollBar" />
    [ToolboxItem(false)]
	public class StiVScrollBar : VScrollBar
	{
        /// <summary>
        /// Gets a value indicating whether this instance is start.
        /// </summary>
        /// <value><c>true</c> if this instance is start; otherwise, <c>false</c>.</value>
        public bool IsStart
		{
			get
			{
				return Value == 0;
			}
		}


        /// <summary>
        /// Gets a value indicating whether this instance is end.
        /// </summary>
        /// <value><c>true</c> if this instance is end; otherwise, <c>false</c>.</value>
        public bool IsEnd
		{
			get
			{
				return Value == (Maximum - LargeChange);
			}
		}

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        private void SetValue(int value)
		{
			if (value < 0)this.Value = 0;
			else this.Value = value;
		}


        /// <summary>
        /// Does up.
        /// </summary>
        public void DoUp()
		{
			if (this.Value - this.SmallChange < 0)SetValue(0);
			else SetValue(this.Value - this.SmallChange);
		}

        /// <summary>
        /// Does down.
        /// </summary>
        public void DoDown()
		{
			if (this.Value + this.SmallChange > (Maximum - LargeChange + 1))
				SetValue(Maximum - LargeChange + 1);
			else SetValue(this.Value + this.SmallChange);
		}

        /// <summary>
        /// Does the page up.
        /// </summary>
        public void DoPageUp()
		{
			if (this.Value - this.LargeChange < 0)SetValue(0);
			else SetValue(this.Value - this.LargeChange);
		}

        /// <summary>
        /// Does the page down.
        /// </summary>
        public void DoPageDown()
		{
			if (this.Value + this.LargeChange >= this.Maximum - this.LargeChange)
				SetValue(this.Maximum - this.LargeChange);
			else SetValue(this.Value + this.LargeChange);
		}

        /// <summary>
        /// Does the top.
        /// </summary>
        public void DoTop()
		{
			SetValue(0);
			Invalidate();
		}

        /// <summary>
        /// Does the bottom.
        /// </summary>
        public void DoBottom()
		{
			SetValue(this.Maximum - this.LargeChange);
		}
	}
}
