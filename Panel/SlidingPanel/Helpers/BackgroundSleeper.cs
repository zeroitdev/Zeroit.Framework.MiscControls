// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BackgroundSleeper.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a background sleeper.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
    public class ZeroitBackgroundSleeper : Component
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBackgroundSleeper" /> class.
        /// </summary>
        public ZeroitBackgroundSleeper()
		{

		}

        /// <summary>
        /// Sleeps for a specified time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        public void Sleep(int milliseconds)
		{
			DateTime dateTime = DateTime.Now.AddMilliseconds((double)milliseconds);
			while (DateTime.Now < dateTime)
			{
				Application.DoEvents();
			}
		}

	}
}