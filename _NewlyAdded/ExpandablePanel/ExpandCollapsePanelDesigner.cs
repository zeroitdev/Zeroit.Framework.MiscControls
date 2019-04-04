// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ExpandCollapsePanelDesigner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Designer for the ExpandCollapsePanel control with support for a smart tag panel.
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms171829.aspx</remarks>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ScrollableControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPiperExCollapsePanelDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu. 
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(
                        new ZeroitPiperExCollapsePanelActionList(this.Component));
                }
                return actionLists;
            }
        }
    }
}