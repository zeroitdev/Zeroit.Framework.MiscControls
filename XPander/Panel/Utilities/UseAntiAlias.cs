// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UseAntiAlias.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    #region UseAntiAlias
    /// <summary>
    /// Set the SmoothingMode=AntiAlias until instance disposed.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UseAntiAlias : IDisposable
    {
        #region FieldsPrivate

        /// <summary>
        /// The m graphics
        /// </summary>
        private Graphics m_graphics;
        /// <summary>
        /// The m smoothing mode
        /// </summary>
        private SmoothingMode m_smoothingMode;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the UseAntiAlias class.
        /// </summary>
        /// <param name="graphics">Graphics instance.</param>
        /// <exception cref="System.ArgumentNullException">graphics</exception>
        public UseAntiAlias(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentException,
                    "graphics"));
            }

            this.m_graphics = graphics;
            this.m_smoothingMode = m_graphics.SmoothingMode;
            this.m_graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
        /// <summary>
        /// destructor of the UseAntiAlias class.
        /// </summary>
        ~UseAntiAlias()
        {
            Dispose(false);
        }
        /// <summary>
        /// Releases all resources used by the class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                //Revert the SmoothingMode back to original setting.
                this.m_graphics.SmoothingMode = this.m_smoothingMode;
            }
        }
        #endregion
    }
    #endregion
}
