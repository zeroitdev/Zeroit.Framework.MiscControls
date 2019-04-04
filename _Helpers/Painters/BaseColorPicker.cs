// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="BaseColorPicker.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Base class for a color selection control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public class BaseColorPicker : UserControl
	{
        /// <summary>
        /// Represents the method that will handle the <c>ColorSelected</c> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <c>ColorSelectedEventArgs</c> that contains the event data.</param>
        public delegate void ColorSelectedEventHandler(object sender, ColorSelectedEventArgs e);

        /// <summary>
        /// Occurs when the user has selected a color in the derived class.
        /// </summary>
		public event ColorSelectedEventHandler ColorSelected;

        /// <summary>
        /// Specify that a color has been selected.
        /// </summary>
        /// <param name="c">Selected color.</param>
		protected void SelectColor(Color c)
		{
			if (ColorSelected != null)
			{
				ColorSelected(this, new ColorSelectedEventArgs(c, c.Name));
			}
		}

        /// <summary>
        /// Specify that a color has been selected.
        /// </summary>
        /// <param name="args">Color selected event args.</param>
		protected void SelectColor(ColorSelectedEventArgs args)
		{
			if (ColorSelected != null)
			{
				ColorSelected(this, args);
			}
		}

        /// <summary>
        /// Set current color.
        /// Derived class should override this method.
        /// </summary>
        /// <param name="c">Color.</param>
        /// <returns><c>True</c> if color is known by the derived class and was set, <c>false</c> otherwise.</returns>
        public virtual bool SetColor(Color c)
        {
            return true;
        }
	}

    /// <summary>
    /// Provides data for the <c>ColorSelected</c> event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
	public class ColorSelectedEventArgs : EventArgs
	{
        /// <summary>
        /// Initializes a new instance of the <c>ColorSelectedEventArgs</c> class.
        /// </summary>
        /// <param name="color">Selected color.</param>
        /// <param name="colorName">Name of selected color (for displaying).</param>
        public ColorSelectedEventArgs(Color color, string colorName)
		{
			Color = color;
			ColorName = colorName;
		}

        /// <summary>
        /// Selected color.
        /// </summary>
		public readonly Color Color;

        /// <summary>
        /// Name of selected color.
        /// </summary>
        public readonly string ColorName;
	}
}
