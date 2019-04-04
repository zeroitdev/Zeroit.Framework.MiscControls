// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="GradientSplitter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering splitter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
   public partial class GradientSplitter : Component
   {
        /// <summary>
        /// Initializes a new instance of the <see cref="GradientSplitter"/> class.
        /// </summary>
        public GradientSplitter()
      {
         InitializeComponent();
      }

        /// <summary>
        /// Initializes a new instance of the <see cref="GradientSplitter"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public GradientSplitter(IContainer container)
      {
         container.Add(this);

         InitializeComponent();
      }
   }
}
