// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageCollectionEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;

namespace Zeroit.Framework.MiscControls
{
    #region ImageCollectionEditor
    /// <summary>
    /// Simple <see cref="UITypeEditor" /> which forwards to the standard <see cref="CollectionEditor" />
    /// for <see cref="Image" /> types
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
    public class ImageCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        /// <summary>
        /// Create an <c>ImageCollectionEditor</c>
        /// </summary>
        public ImageCollectionEditor() : base(typeof(ImageCollection)) { }

        /// <summary>
        /// Forward to base class implementation
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="provider">designer service provider</param>
        /// <param name="value">value to be edited</param>
        /// <returns>The edited value</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return base.EditValue(context, provider, value);
        }

        /// <summary>
        /// Forward to the normal <see cref="Image" /> editor
        /// </summary>
        /// <param name="ItemType">ignored</param>
        /// <returns>A new <see cref="Image" /></returns>
        protected override object CreateInstance(Type ItemType)
        {
            UITypeEditor editor = ((UITypeEditor)TypeDescriptor.GetEditor(typeof(Image), typeof(UITypeEditor)));
            return ((Image)editor.EditValue(base.Context, null));
        }
    }
    #endregion
}
