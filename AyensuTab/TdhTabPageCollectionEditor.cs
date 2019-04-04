// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabPageCollectionEditor.cs" company="Zeroit Dev Technologies">
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