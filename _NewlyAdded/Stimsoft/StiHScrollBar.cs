// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="StiHScrollBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a standard Windows horizontal scroll bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.HScrollBar" />
	[ToolboxItem(false)]
	public class StiHScrollBar : HScrollBar
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
        /// Does the left.
        /// </summary>
        public void DoLeft()
		{
			if (this.Value - this.SmallChange < 0)SetValue(0);
			else SetValue(this.Value - this.SmallChange);
		}

        /// <summary>
        /// Does the right.
        /// </summary>
        public void DoRight()
		{
			if (this.Value + this.SmallChange > (Maximum - LargeChange + 1))
				SetValue(Math.Max(Maximum - LargeChange + 1, Minimum));
			else SetValue(this.Value + this.SmallChange);
		}

        /// <summary>
        /// Does the page left.
        /// </summary>
        public void DoPageLeft()
		{
			if (this.Value - this.SmallChange < 0)SetValue(0);
			else SetValue(this.Value - this.SmallChange);
		}

        /// <summary>
        /// Does the page right.
        /// </summary>
        public void DoPageRight()
		{
			if (this.Value + this.SmallChange > Maximum - LargeChange)
				SetValue(Maximum - LargeChange);
			else SetValue(this.Value + this.SmallChange);
		}

        /// <summary>
        /// Does the left edge.
        /// </summary>
        public void DoLeftEdge()
		{
			SetValue(0);
			Invalidate();
		}

        /// <summary>
        /// Does the right edge.
        /// </summary>
        public void DoRightEdge()
		{
			SetValue(this.Maximum - this.LargeChange);
		}
	}
}
