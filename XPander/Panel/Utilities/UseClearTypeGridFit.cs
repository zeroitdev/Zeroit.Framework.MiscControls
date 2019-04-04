// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UseClearTypeGridFit.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Text;

namespace Zeroit.Framework.MiscControls
{
    #region UseClearTypeGridFit
    /// <summary>
    /// Set the TextRenderingHint.ClearTypeGridFit until instance disposed.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UseClearTypeGridFit : IDisposable
    {
        #region FieldsPrivate
        /// <summary>
        /// The m graphics
        /// </summary>
        private Graphics m_graphics;
        /// <summary>
        /// The m text rendering hint
        /// </summary>
        private TextRenderingHint m_textRenderingHint;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the UseClearTypeGridFit class.
        /// </summary>
        /// <param name="graphics">Graphics instance.</param>
        /// <exception cref="System.ArgumentNullException">graphics</exception>
        public UseClearTypeGridFit(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    Properties.Resources.IDS_ArgumentException,
                    "graphics"));
            }

            this.m_graphics = graphics;
            this.m_textRenderingHint = this.m_graphics.TextRenderingHint;
            this.m_graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
        /// <summary>
        /// destructor of the UseClearTypeGridFit class.
        /// </summary>
        ~UseClearTypeGridFit()
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
                //Revert the TextRenderingHint back to original setting.
                this.m_graphics.TextRenderingHint = this.m_textRenderingHint;
            }
        }
        #endregion
    }
    #endregion
}
