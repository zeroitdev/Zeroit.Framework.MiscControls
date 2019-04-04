// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandDesigner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBandDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    public class NaviBandDesigner : ParentControlDesigner
   {
        /// <summary>
        /// The designing component
        /// </summary>
        NaviBand designingComponent;

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(System.ComponentModel.IComponent component)
      {
         base.Initialize(component);
         if (component is NaviBand)
            designingComponent = (NaviBand)component;

         EnableDesignMode(designingComponent.ClientArea, "ClientArea");
      }
   }
}
