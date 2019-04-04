// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviForm.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a customized form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NaviForm : System.Windows.Forms.Form
   {
        /// <summary>
        /// The layout style
        /// </summary>
        NaviLayoutStyle layoutStyle;
        /// <summary>
        /// The layout style changed
        /// </summary>
        EventHandler layoutStyleChanged;

        /// <summary>
        /// The thread lock
        /// </summary>
        protected readonly object threadLock = new object();

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NaviForm
        /// </summary>
        public NaviForm()
      {
         InitializeComponent();
      }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates how the control is presented to the user
        /// </summary>
        /// <value>The layout style.</value>
        public NaviLayoutStyle LayoutStyle
      {
         get { return layoutStyle; }
         set
         {
            layoutStyle = value;
            OnLayoutStyleChanged(new EventArgs());
         }
      }

        #endregion

        #region Events

        /// <summary>
        /// Occurs after the layout style has been changed
        /// </summary>
        public event EventHandler LayoutStyleChanged
      {
         add { lock (threadLock) { layoutStyleChanged += value; } }
         remove { lock (threadLock) { layoutStyleChanged -= value; } }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the LayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected virtual void OnLayoutStyleChanged(EventArgs e)
      {
         EventHandler handler = layoutStyleChanged;
         if (handler != null)
            handler(this, e);
      }

      #endregion
   }
}
