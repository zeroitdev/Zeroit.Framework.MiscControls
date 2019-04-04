// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ThemeProperty.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class holding theme information for <see cref="ZeroitToxicButton" />
    /// </summary>
    [TypeConverter(typeof (GenericConverter<ThemeProperty>))]
    public class ThemeProperty
    {
        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme colorScheme;
        /// <summary>
        /// The use theme
        /// </summary>
        private bool useTheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeProperty" /> class.
        /// </summary>
        public ThemeProperty()
        {
            Reset();
        }

        /// <summary>
        /// Gets or Sets which color theme should be used.
        /// This is only applicable when <see cref="UseTheme" /> is set to true.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set
            {
                if (colorScheme != value)
                {
                    colorScheme = value;
                    OnThemeChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or Sets wether predefined themes should be used or not.
        /// </summary>
        /// <value><c>true</c> if [use theme]; otherwise, <c>false</c>.</value>
        public bool UseTheme
        {
            get { return useTheme; }
            set
            {
                if (useTheme != value)
                {
                    useTheme = value;
                    OnThemeChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Occurs when properties of <see cref="ThemeProperty" /> has been changed.
        /// </summary>
        public event GenericEventHandler<AppearanceAction> ThemeChanged;

        /// <summary>
        /// Triggers <see cref="ThemeChanged" /> event.
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnThemeChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged(this, e);
            }
        }

        /// <summary>
        /// Get wether default values of the object has been modified.
        /// </summary>
        /// <returns>Returns true if default values has been modified for current object.</returns>
        public virtual bool DefaultChanged()
        {
            return ShouldSerializeColorScheme() || ShouldSerializeUseTheme();
        }

        /// <summary>
        /// Resets current object to use default value for each property.
        /// </summary>
        public void Reset()
        {
            ResetColorScheme();
            ResetUseTheme();
        }

        /// <summary>
        /// Shoulds the serialize use theme.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeUseTheme()
        {
            return useTheme != true;
        }

        /// <summary>
        /// Shoulds the serialize color scheme.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeColorScheme()
        {
            return colorScheme != ColorScheme.Default;
        }

        /// <summary>
        /// Resets the use theme.
        /// </summary>
        private void ResetUseTheme()
        {
            useTheme = true;
        }

        /// <summary>
        /// Resets the color scheme.
        /// </summary>
        private void ResetColorScheme()
        {
            colorScheme = ColorScheme.Default;
        }
    }
}