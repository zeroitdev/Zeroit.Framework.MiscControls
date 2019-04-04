// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabPageCollection.cs" company="Zeroit Dev Technologies">
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
#region using ...

// 1.0.001
// 1.0.001
// 1.0.001
// 1.0.001

// 1.0.001
#endregion 

namespace Zeroit.Framework.MiscControls.Tabs																				// 1.0.001
{                                                                                                           // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// // 1.0.001
                                                                                                            /// Summary description for ZeroitAyensuTabPageCollection.														// 1.0.001
                                                                                                            /// </summary>
                                                                                                            /// <seealso cref="System.Windows.Forms.TabControl.TabPageCollection" />
    [System.ComponentModel.ToolboxItem(false)]																// 1.0.001
	public class ZeroitAyensuTabPageCollection : System.Windows.Forms.TabControl.TabPageCollection					// 1.0.001
	{                                                                                                       // 1.0.001
        #region pseudo-[Component Designer generated instantiation of components]

        /// <summary>
        /// // 1.0.001
        /// Required designer variable.																		// 1.0.001
        /// </summary>
        private System.ComponentModel.Container components = null;                                          // 1.0.001

        #endregion

        #region pseudo-[Component Designer generated code]
        /// <summary>
        /// // 1.0.001
        /// Required method for Designer support - do not modify											// 1.0.001
        /// the contents of this method with the code editor.												// 1.0.001
        /// </summary>
        private void InitializeComponent()																	// 1.0.001
		{																									// 1.0.001
			components = new System.ComponentModel.Container();												// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion


        #region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
        /// <summary>
        /// The GBL run mode is debug mode
        /// </summary>
        private bool gblRunModeIs_DebugMode = false;                                                        // 1.0.000
                                                                                                            /// <summary>
                                                                                                            /// The GBL run mode is design mode
                                                                                                            /// </summary>
        private bool gblRunModeIs_DesignMode = true;                                                        // 1.0.000

        /// <summary>
        /// Initializes the GBL run mode is.
        /// </summary>
        private void Initialize_gblRunModeIs()																// 1.0.000
		{																									// 1.0.000
			#region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
			gblRunModeIs_DebugMode = System.Diagnostics.Debugger.IsAttached;								// 1.0.000

			//gblRunModeIs_DesignMode = false;																// 1.0.000
			//try						// the try-catch method can detect 'DesignMode' in the Constructor	// 1.0.000
			//{																								// 1.0.000
			//	//string dummy = System.Reflection.Assembly.GetEntryAssembly().Location.ToString();			// 1.0.000
			//	string dummy = System.Reflection.Assembly.GetEntryAssembly().FullName;						// 1.0.000
			//}																								// 1.0.000
			//catch (System.NullReferenceException ex)														// 1.0.000
			//{																								// 1.0.000
			//	gblRunModeIs_DesignMode = true;																// 1.0.000
			//}																								// 1.0.000

			// In the Constructor, [this.DesignMode] always returns false.									// 1.0.000
			// Also, [this.DesignMode] is applicable only to the class that actually invokes it.			// 1.0.000
			// Thus, in the code of the base class, it will return false.									// 1.0.000
			//gblRunModeIs_DesignMode = this.DesignMode;													// 1.0.000

			// Determine whether the class is in DesignMode by examining the .ProcessName of the current Process	// 1.0.000
			if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv")			// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = true;																// 1.0.000
			}																								// 1.0.000
			else																							// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = false;															// 1.0.000
			}																								// 1.0.000
			#endregion
		}                                                                                                   // 1.0.000
        #endregion

        #region Private Fields and Properties 
        /// <summary>
        /// The owner
        /// </summary>
        private ZeroitAyensuTab _owner = null;                                                          // 1.0.001
        #endregion

        #region Class Constructor (and Dispose)
        // 
        // public ZeroitAyensuTabPageCollection(ZeroitAyensuTab owner) : base((System.Windows.Forms.TabControl)owner)
        // 
        // protected void Dispose( bool disposing )
        // 
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabPageCollection"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public ZeroitAyensuTabPageCollection(ZeroitAyensuTab owner) : base((System.Windows.Forms.TabControl)owner)	// 1.0.001
		{																									// 1.0.001
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000
			///																								// 1.0.001
			/// Required for Windows.Forms Class Composition Designer support								// 1.0.001
			///																								// 1.0.001
			InitializeComponent();																			// 1.0.001
			//																								// 1.0.001
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.001
			//																								// 1.0.001
//_owner = owner;																					// 1.0.001
if (!gblRunModeIs_DesignMode)																	// 1.0.001
{																								// 1.0.001
	_owner = owner;																				// 1.0.001
}																								// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// // 1.0.001
        /// Clean up any resources being used.																// 1.0.001
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        //protected override void Dispose( bool disposing )													// 1.0.001
        protected void Dispose( bool disposing )															// 1.0.001
		{																									// 1.0.001
			if( disposing )																					// 1.0.001
			{																								// 1.0.001
				if(components != null)																		// 1.0.001
				{																							// 1.0.001
					components.Dispose();																	// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
			//base.Dispose( disposing );																	// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region Public New/Override and Novel Properties
        // public new ZeroitAyensuTabPage this[int index] {get} {set}
        // public System.Windows.Forms.TabPage this[bool alwaysAsBase, int index] {get}
        // public ZeroitAyensuTabPage this[string text] {get}
        // public System.Windows.Forms.TabPage this[bool alwaysAsBase, string text] {get}
        // 
        // public new int Count {get}
        // public new bool IsReadOnly {get}
        //

        // the .Item (.TabPage) indexer
        /// <summary>
        /// Indexer which returns the ZeroitAyensuTabPage at a particular index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>ZeroitAyensuTabPage.</returns>
        public new ZeroitAyensuTabPage this[int index]														// 1.0.001
		{																									// 1.0.001
			get																								// 1.0.001
			{																								// 1.0.001
				int idx = 0;																				// 1.0.001
				if (index > 0)																				// 1.0.001
				{																							// 1.0.001
					idx = index;																			// 1.0.001
				}																							// 1.0.001
				if (idx >= this.Count)																		// 1.0.001
				{																							// 1.0.001
					idx = this.Count - 1;																	// 1.0.001
				}																							// 1.0.001

				if( (idx < 0)																				// 1.0.001
				||( (base[index].GetType() != typeof(ZeroitAyensuTabPage))									// 1.0.010
					&& !base[index].GetType().IsSubclassOf(typeof(ZeroitAyensuTabPage))					// 1.0.010
					)																						// 1.0.010
				)																							// 1.0.001
				{																							// 1.0.001
					return null;																			// 1.0.001
				}																							// 1.0.001
				return (base[idx] as ZeroitAyensuTabPage);													// 1.0.001

			}																								// 1.0.001
			set																								// 1.0.003
			{																								// 1.0.003
				if( (index >= 0) && (index < this.Count) )	// Replace an existing TabPage with [value]?	// 1.0.003
				{																							// 1.0.003
					#region These statements don't quite do what we'd want done.
					// These statements don't quite do what we'd want done.									// 1.0.003

					//base[index] = value;	// TEST			// (contents of TabPage temporarily hidden)		// 1.0.003

					//base.RemoveAt(index);	// TEST															// 1.0.003
					//base.Add(value);		// TEST			// New TabPage appended, not inserted			// 1.0.003
					#endregion 

					InsertRange(true, index, value);		// Replace TabPage at [index] with [value]		// 1.0.004
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					base.Add(value);						// Add [value] as a new TabPage					// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.003
		}                                                                                                   // 1.0.001


        /// <summary>
        /// Indexer which (regardless of value of 'alwaysAsBase') returns the TabPage at a particular index.
        /// </summary>
        /// <param name="alwaysAsBase">if set to <c>true</c> [always as base].</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Windows.Forms.TabPage.</returns>
        public System.Windows.Forms.TabPage this[bool alwaysAsBase, int index]								// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				int idx = 0;																				// 1.0.001
				if (index > 0)																				// 1.0.001
				{																							// 1.0.001
					idx = index;																			// 1.0.001
				}																							// 1.0.001
				if (idx >= this.Count)																		// 1.0.001
				{																							// 1.0.001
					idx = this.Count - 1;																	// 1.0.001
				}																							// 1.0.001

				if (idx < 0)																				// 1.0.001
				{																							// 1.0.001
					return null;																			// 1.0.001
				}																							// 1.0.001
				return (base[idx] as System.Windows.Forms.TabPage);											// 1.0.001
			}																								// 1.0.010
			set																								// 1.0.010
			{																								// 1.0.010
				if( (index >= 0) && (index < this.Count) )	// Replace an existing TabPage with [value]?	// 1.0.003
				{																							// 1.0.003
					InsertRange(true, index, value);		// Replace TabPage at [index] with [value]		// 1.0.004
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					base.Add(value);						// Add [value] as a new TabPage					// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Indexer which returns the ZeroitAyensuTabPage with a particular .Text value.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ZeroitAyensuTabPage.</returns>
        public ZeroitAyensuTabPage this[string text]														// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				// Search for a TabPage with a matching .Text value											// 1.0.010
				string trimText = text.Trim();																// 1.0.010
				for (int idx = 0; idx < this.Count; idx++)													// 1.0.010
				{																							// 1.0.010
					if( ((base[idx].GetType() == typeof(ZeroitAyensuTabPage))								// 1.0.010
						|| base[idx].GetType().IsSubclassOf(typeof(ZeroitAyensuTabPage))					// 1.0.010
						)																					// 1.0.010
					&& (base[idx].Text.Trim() == trimText)													// 1.0.010
					)																						// 1.0.010
					{																						// 1.0.010
						return (base[idx] as ZeroitAyensuTabPage);											// 1.0.010
						//return (base[idx] as System.Windows.Forms.TabPage);								// 1.0.010
					}																						// 1.0.010
				}																							// 1.0.010
				return null;																				// 1.0.010
			}																								// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Indexer which (regardless of value of 'alwaysAsBase') returns the TabPage with a particular .Text value.
        /// </summary>
        /// <param name="alwaysAsBase">if set to <c>true</c> [always as base].</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Windows.Forms.TabPage.</returns>
        public System.Windows.Forms.TabPage this[bool alwaysAsBase, string text]							// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				// Search for a TabPage with a matching .Text value											// 1.0.010
				string trimText = text.Trim();																// 1.0.010
				for (int idx = 0; idx < this.Count; idx++)													// 1.0.010
				{																							// 1.0.010
					if (base[idx].Text.Trim() == trimText)													// 1.0.010
					{																						// 1.0.010
						//return (base[idx] as ZeroitAyensuTabPage);										// 1.0.010
						return (base[idx] as System.Windows.Forms.TabPage);									// 1.0.010
					}																						// 1.0.010
				}																							// 1.0.010
				return null;																				// 1.0.010
			}																								// 1.0.010
		}                                                                                                   // 1.0.010


        //public new int Count																				// 1.0.003
        //{																									// 1.0.003
        //	get { return base.Count; }																		// 1.0.003
        //}																									// 1.0.003
        //
        //public new bool IsReadOnly																			// 1.0.003
        //{																									// 1.0.003
        //	get { return base.IsReadOnly; }																	// 1.0.003
        //}																									// 1.0.003
        #endregion

        #region Public New/Override and Novel Methods/Functions 
        // public bool IsTdhTabPage(int index)
        // 
        // public new void Clear()
        // 
        // public bool Contains(ZeroitAyensuTabPage theTabPage)
        // public new bool Contains(System.Windows.Forms.TabPage theTabPage)
        // 
        // public void Add(ZeroitAyensuTabPage theTabPage)
        // public new void Add(System.Windows.Forms.TabPage theTabPage)
        // public void AddRange(params ZeroitAyensuTabPage[] theTabPages)
        // public new void AddRange(params System.Windows.Forms.TabPage[] theTabPages)
        // 
        // public void Insert(int index, ZeroitAyensuTabPage theTabPage)
        // public void Insert(int index, System.Windows.Forms.TabPage theTabPage)
        // public void InsertRange(int index, params ZeroitAyensuTabPage[] theTabPages)
        // public void InsertRange(int index, params System.Windows.Forms.TabPage[] theTabPages)
        // 
        // public bool RemoveRange(int indexStart, int indexEnd)
        // 
        /// <summary>
        /// Determines whether [is TDH tab page] [the specified index].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns><c>true</c> if [is TDH tab page] [the specified index]; otherwise, <c>false</c>.</returns>
        public bool IsTdhTabPage(int index)																	// 1.0.010
		{																									// 1.0.010
			if( (index > -1)																				// 1.0.010
			&& (index < this.Count)																			// 1.0.010
			&&( (base[index].GetType() == typeof(ZeroitAyensuTabPage))										// 1.0.010
				|| base[index].GetType().IsSubclassOf(typeof(ZeroitAyensuTabPage))							// 1.0.010
				)																							// 1.0.010
			)																								// 1.0.010
			{																								// 1.0.010
				return true;																				// 1.0.010
			}																								// 1.0.010
			return false;																					// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Removes all the tab pages from the collection.
        /// </summary>
        public new void Clear()																				// 1.0.001
		{																									// 1.0.001
			_owner.cmnuTabRect_Built = false;																// 1.0.001
			base.Clear();																					// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// Determines whether [contains] [the specified the tab page].
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        /// <returns><c>true</c> if [contains] [the specified the tab page]; otherwise, <c>false</c>.</returns>
        public bool Contains(ZeroitAyensuTabPage theTabPage)												// 1.0.001
		{																									// 1.0.001
			return base.Contains(theTabPage);																// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Determines whether [contains] [the specified the tab page].
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        /// <returns><c>true</c> if [contains] [the specified the tab page]; otherwise, <c>false</c>.</returns>
        public new bool Contains(System.Windows.Forms.TabPage theTabPage)									// 1.0.010
		{																									// 1.0.010
			return base.Contains(theTabPage);																// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Adds the specified the tab page.
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        public void Add(ZeroitAyensuTabPage theTabPage)													// 1.0.001
		{																									// 1.0.001
			// Any special processing may be done here														// 1.0.001
			//																								// 1.0.001
			_owner.cmnuTabRect_Built = false;																// 1.0.001
			base.Add(theTabPage);																			// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Adds the specified the tab page.
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        public new void Add(System.Windows.Forms.TabPage theTabPage)										// 1.0.010
		{																									// 1.0.010
			// Any special processing may be done here														// 1.0.010
			//																								// 1.0.010
			_owner.cmnuTabRect_Built = false;																// 1.0.010
			base.Add(theTabPage);																			// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="theTabPages">The tab pages.</param>
        public void AddRange(params ZeroitAyensuTabPage[] theTabPages)										// 1.0.001
		{																									// 1.0.001
			//_owner.cmnuTabRect_Built = false;																// 1.0.001
			//base.AddRange(theTabPages);																	// 1.0.001
			foreach (ZeroitAyensuTabPage _theTabPage in theTabPages)										// 1.0.001
			{																								// 1.0.001
				this.Add(_theTabPage);																		// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="theTabPages">The tab pages.</param>
        public new void AddRange(params System.Windows.Forms.TabPage[] theTabPages)							// 1.0.010
		{																									// 1.0.010
			//_owner.cmnuTabRect_Built = false;																// 1.0.010
			//base.AddRange(theTabPages);																	// 1.0.010
			foreach (System.Windows.Forms.TabPage _theTabPage in theTabPages)								// 1.0.010
			{																								// 1.0.010
				this.Add(_theTabPage);																		// 1.0.010
			}																								// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="theTabPage">The tab page.</param>
        public void Insert(int index, ZeroitAyensuTabPage theTabPage)										// 1.0.004
		{																									// 1.0.004
			InsertRange(false, index, theTabPage);			// Insert [theTabPage] at [index] 				// 1.0.004
		}                                                                                                   // 1.0.004

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="theTabPage">The tab page.</param>
        public void Insert(int index, System.Windows.Forms.TabPage theTabPage)								// 1.0.010
		{																									// 1.0.010
			InsertRange(false, index, theTabPage);			// Insert [theTabPage] at [index] 				// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="theTabPages">The tab pages.</param>
        public void InsertRange(int index, params ZeroitAyensuTabPage[] theTabPages)						// 1.0.004
		{																									// 1.0.004
			InsertRange(false, index, theTabPages);			// Insert [theTabPages] at [index] 				// 1.0.004
		}                                                                                                   // 1.0.004

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="theTabPages">The tab pages.</param>
        public void InsertRange(int index, params System.Windows.Forms.TabPage[] theTabPages)				// 1.0.010
		{																									// 1.0.010
			InsertRange(false, index, theTabPages);			// Insert [theTabPages] at [index] 				// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="indexStart">The index start.</param>
        /// <param name="indexEnd">The index end.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveRange(int indexStart, int indexEnd)												// 1.0.012
		{																									// 1.0.012
			//int idxStart = System.Math.Min(indexStart, indexEnd);											// 1.0.012
			int idxStart = System.Math.Max(System.Math.Min(indexStart, indexEnd), 0);						// 1.0.012
			//int idxEnd = System.Math.Max(indexStart, indexEnd);											// 1.0.012
			int idxEnd = System.Math.Min(System.Math.Max(indexStart, indexEnd), this.Count - 1);			// 1.0.012
			if (idxEnd < idxStart)																			// 1.0.012
			{																								// 1.0.012
				return false;																				// 1.0.012
			}																								// 1.0.012

			for (int idx = idxEnd; idx >= idxStart; idx--)													// 1.0.012
			{																								// 1.0.012
				base.RemoveAt(idx);																			// 1.0.012
			}																								// 1.0.012

			return true;																					// 1.0.012
		}                                                                                                   // 1.0.012
        #endregion

        #region Private Methods
        // private void InsertRange(bool replace, int index, params System.Windows.Forms.TabPage[] theTabPages)
        // 
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="replace">if set to <c>true</c> [replace].</param>
        /// <param name="index">The index.</param>
        /// <param name="theTabPages">The tab pages.</param>
        private void InsertRange(bool replace, int index, params System.Windows.Forms.TabPage[] theTabPages)// 1.0.010
		{																									// 1.0.004
			#region Put existing [base.TabPages] into an ArrayList sequenced in the present order
			System.Collections.ArrayList alTabPages = new System.Collections.ArrayList(this.Count);			// 1.0.003
			for (int idx = 0; idx < this.Count; idx++)														// 1.0.003
			{																								// 1.0.003
				alTabPages.Add(base[idx]);																	// 1.0.010
			}																								// 1.0.003
			#endregion 
			#region Add/Insert [theTabPages] at appropriate location in the ArrayList
			if (replace									// Replace TabPage at [index] with [theTabPages]?	// 1.0.004
			&& ((index >= 0) && (index < alTabPages.Count)) )												// 1.0.004
			{																								// 1.0.004
				alTabPages.RemoveAt(index);																	// 1.0.004
			}																								// 1.0.004
			if ((index >= 0) && (index < alTabPages.Count))													// 1.0.004
			{																								// 1.0.004
				alTabPages.InsertRange(index, theTabPages);													// 1.0.004
			}																								// 1.0.004
			else																							// 1.0.004
			{																								// 1.0.004
				alTabPages.AddRange(theTabPages);															// 1.0.004
			}																								// 1.0.004
			#endregion 
			#region Rebuild the [base.TabPages] Collection
			_owner.SuspendLayout();																			// 1.0.003
			base.Clear();																					// 1.0.003
			for (int idxNew = 0; idxNew < alTabPages.Count; idxNew++)										// 1.0.003
			{																								// 1.0.003
				System.Windows.Forms.TabPage aTabPage = (System.Windows.Forms.TabPage)alTabPages[idxNew];	// 1.0.010
				aTabPage.TabIndex = idxNew;																	// 1.0.003
				base.Add(aTabPage);																			// 1.0.003
			}																								// 1.0.003
			alTabPages.Clear();																				// 1.0.003
			_owner.ResumeLayout(false);																		// 1.0.003
			_owner.Invalidate();																			// 1.0.003
			#endregion 
		}																									// 1.0.004
		#endregion 
	}																										// 1.0.001
}																											// 1.0.001