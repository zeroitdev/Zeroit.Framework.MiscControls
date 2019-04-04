// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UseAntiAlias.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
