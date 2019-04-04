// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageCollectionEditor.cs" company="Zeroit Dev Technologies">
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
