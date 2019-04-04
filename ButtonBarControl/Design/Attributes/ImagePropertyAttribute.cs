// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="ImagePropertyAttribute.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Indicates Image property for indexing. e.g. If parent contains image list use "Parent.ImageList".
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal sealed class ImagePropertyAttribute : Attribute
    {
        /// <summary>
        /// The property name
        /// </summary>
        private readonly string propertyName;

        /// <summary>
        /// Crate instance of the <see cref="ImagePropertyAttribute" />
        /// </summary>
        /// <param name="relatedImageList">The related image list.</param>
        public ImagePropertyAttribute(string relatedImageList)
        {
            propertyName = relatedImageList;
        }

        /// <summary>
        /// Gets the name of the property which is to be used for imagelist.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName
        {
            get { return propertyName; }
        }
    }
}