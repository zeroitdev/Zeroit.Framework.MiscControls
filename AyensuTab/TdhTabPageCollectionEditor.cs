// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabPageCollectionEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls.Tabs																				
{

    #region [ internal class ZeroitAyensuTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
    // The code for the [ZeroitAyensuTabPageCollectionEditor] class is based on code posted in a comment here:		
    //   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html					

    /// <summary>
    /// Class ZeroitAyensuTabPageCollectionEditor.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
    internal class ZeroitAyensuTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor				
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabPageCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
        public ZeroitAyensuTabPageCollectionEditor(System.Type type) : base(type)									
		{																									
		}

        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm" /> to provide as the user interface for editing the collection.</returns>
        protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()	
		{																									
			CollectionForm baseForm = base.CreateCollectionForm();											
			baseForm.Text = "ZeroitAyensuTabPage Collection Editor";													
			return baseForm;																				
		}

        /// <summary>
        /// Gets the data type that this collection contains.
        /// </summary>
        /// <returns>The data type of the items in the collection, or an <see cref="T:System.Object" /> if no Item property can be located on the collection.</returns>
        protected override System.Type CreateCollectionItemType()											
		{																									
			return typeof(ZeroitAyensuTabPage);												
		}

        /// <summary>
        /// Gets the data types that this collection editor can contain.
        /// </summary>
        /// <returns>An array of data types that this collection can contain.</returns>
        protected override System.Type[] CreateNewItemTypes()												
		{																									
			return new System.Type[] {																		
										typeof(ZeroitAyensuTabPage), 							
										typeof(System.Windows.Forms.TabPage)								
									 };																		
		}																									
	}
    #endregion

    #region [ internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
    // The code for the [TabPageCollectionEditor] class is based on code posted in a comment here:			
    //   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html					

    /// <summary>
    /// Class TabPageCollectionEditor.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
    internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor					
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TabPageCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
        public TabPageCollectionEditor(System.Type type) : base(type)										
		{																									
		}

        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm" /> to provide as the user interface for editing the collection.</returns>
        protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()	
		{																									
			CollectionForm baseForm = base.CreateCollectionForm();											
			baseForm.Text = "TabPage Collection Editor";													
			return baseForm;																				
		}

        /// <summary>
        /// Gets the data type that this collection contains.
        /// </summary>
        /// <returns>The data type of the items in the collection, or an <see cref="T:System.Object" /> if no Item property can be located on the collection.</returns>
        protected override System.Type CreateCollectionItemType()											
		{																									
			return typeof(System.Windows.Forms.TabPage); 													
		}

        /// <summary>
        /// Gets the data types that this collection editor can contain.
        /// </summary>
        /// <returns>An array of data types that this collection can contain.</returns>
        protected override System.Type[] CreateNewItemTypes()												
		{																									
			return new System.Type[] {																		
										typeof(System.Windows.Forms.TabPage), 								
										typeof(ZeroitAyensuTabPage)							
									 };																		
		}																									
	}																										
	#endregion 
}																											