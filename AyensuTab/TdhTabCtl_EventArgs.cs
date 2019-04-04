// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabCtl_EventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls.Tabs																				
{                                                                                                           
    #region Define EventHandler Delegates Class/Control

    																			
    /// <summary>
    /// Delegate TabEventsDelegate
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="TabEventArgs"/> instance containing the event data.</param>
    public delegate void TabEventsDelegate(object sender, TabEventArgs e);          

    // . ZeroitAyensuTabPage-ReorderEvent																			// 1.0.003
    /// <summary>
    /// Delegate TabsReorderedEventDelegate
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="TabsReorderedEventArgs"/> instance containing the event data.</param>
    public delegate void TabsReorderedEventDelegate(object sender, TabsReorderedEventArgs e);   // 1.0.003

    #endregion

    #region Class:  TabEventArgs : System.EventArgs
    /// <summary>
    /// Class TabEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TabEventArgs : System.EventArgs															
	{
        /// <summary>
        /// Enum TabEvents
        /// </summary>
        public enum TabEvents																				
		{                                                                                                   
                                                                                                            /// <summary>
                                                                                                            /// The tab added
                                                                                                            /// </summary>
            TabAdded,                                                                                       
                                                                                                            /// <summary>
                                                                                                            /// The tab add rejected
                                                                                                            /// </summary>
            TabAddRejected,                                                                                 
                                                                                                            /// <summary>
                                                                                                            /// The tab removed
                                                                                                            /// </summary>
            TabRemoved,                                                                                     
                                                                                                            /// <summary>
                                                                                                            /// The tab renamed
                                                                                                            /// </summary>
            TabRenamed,                                                                                     
                                                                                                            /// <summary>
                                                                                                            /// The tabs reordered
                                                                                                            /// </summary>
            TabsReordered,                                                                                  // 1.0.003
                                                                                                            /// <summary>
                                                                                                            /// The undefined
                                                                                                            /// </summary>
            undefined                                                                                       
        }                                                                                                   


        /// <summary>
        /// The tab index
        /// </summary>
        protected int _TabIndex = -1;
        /// <summary>
        /// The old tab index
        /// </summary>
        protected int _oldTabIndex = -1;                                                                    // 1.0.003
                                                                                                            /// <summary>
                                                                                                            /// The tab page
                                                                                                            /// </summary>
        protected System.Windows.Forms.TabPage _TabPage = null;                                             // 1.0.010
                                                                                                            /// <summary>
                                                                                                            /// The tab event
                                                                                                            /// </summary>
        protected TabEventArgs.TabEvents _TabEvent = TabEventArgs.TabEvents.undefined;  

        #region Class Constructore
        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        public TabEventArgs()																				// 1.0.003
		{																									// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theTabIndex">Index of the tab.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(
			int theTabIndex, 
			TabEventArgs.TabEvents theTabEvent)													
		{
			this._TabIndex = theTabIndex;
			this._TabEvent = theTabEvent;																	
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				// 1.0.010
			System.Windows.Forms.TabPage theTabPage, 														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				
			ZeroitAyensuTabPage theTabPage, 																
			TabEventArgs.TabEvents theTabEvent)													
		{																									
			this._TabPage = theTabPage;																		
			this._TabEvent = theTabEvent;																	
		}                                                                                                   

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theTabIndex">Index of the tab.</param>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				// 1.0.010
			int theTabIndex,																				// 1.0.010
			System.Windows.Forms.TabPage theTabPage,														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabIndex = theTabIndex;																	// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theTabIndex">Index of the tab.</param>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				
			int theTabIndex,																				
			ZeroitAyensuTabPage theTabPage,																
			TabEventArgs.TabEvents theTabEvent)													
		{																									
			this._TabIndex = theTabIndex;																	
			this._TabPage = theTabPage;																		
			this._TabEvent = theTabEvent;																	
		}                                                                                                   

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theNewTabIndex">Index of the new tab.</param>
        /// <param name="theOldTabIndex">Index of the old tab.</param>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				// 1.0.010
			int theNewTabIndex, int theOldTabIndex, 														// 1.0.010
			System.Windows.Forms.TabPage theTabPage,														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabIndex = theNewTabIndex;																// 1.0.010
			this._oldTabIndex = theOldTabIndex;																// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Initializes a new instance of the <see cref="TabEventArgs"/> class.
        /// </summary>
        /// <param name="theNewTabIndex">Index of the new tab.</param>
        /// <param name="theOldTabIndex">Index of the old tab.</param>
        /// <param name="theTabPage">The tab page.</param>
        /// <param name="theTabEvent">The tab event.</param>
        public TabEventArgs(																				// 1.0.003
			int theNewTabIndex, int theOldTabIndex, 														// 1.0.003
			ZeroitAyensuTabPage theTabPage,																// 1.0.003
			TabEventArgs.TabEvents theTabEvent)													// 1.0.003
		{																									// 1.0.003
			this._TabIndex = theNewTabIndex;																// 1.0.003
			this._oldTabIndex = theOldTabIndex;																// 1.0.003
			this._TabPage = theTabPage;																		// 1.0.003
			this._TabEvent = theTabEvent;																	// 1.0.003
		}                                                                                                   // 1.0.003
        #endregion

        /// <summary>
        /// Get/Set the tab index value where the close button is clicked
        /// </summary>
        /// <value>The index of the tab.</value>
        public int TabIndex 
		{
			get {return this._TabIndex;}
		}

        /// <summary>
        /// Gets the tab index new.
        /// </summary>
        /// <value>The tab index new.</value>
        public int TabIndexNew																				// 1.0.003
		{																									// 1.0.003
			get {return this._TabIndex;}																	// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Gets the tab index old.
        /// </summary>
        /// <value>The tab index old.</value>
        public int TabIndexOld																				// 1.0.003
		{																									// 1.0.003
			get {return this._oldTabIndex;}																	// 1.0.003
		}                                                                                                   // 1.0.003


        /// <summary>
        /// Gets a value indicating whether [tab page is TDH tab page].
        /// </summary>
        /// <value><c>true</c> if [tab page is TDH tab page]; otherwise, <c>false</c>.</value>
        public bool TabPage_IsTdhTabPage																	// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				if( (this._TabPage != null)																	// 1.0.010
				&&( (this._TabPage.GetType() == typeof(ZeroitAyensuTabPage))								// 1.0.010
					|| this._TabPage.GetType().IsSubclassOf(typeof(ZeroitAyensuTabPage))					// 1.0.010
					)																						// 1.0.010
				)																							// 1.0.010
				{																							// 1.0.010
					return true;																			// 1.0.010
				}																							// 1.0.010
				return false;																				// 1.0.010
			}																								// 1.0.010
		}                                                                                                   // 1.0.010

        /// <summary>
        /// Gets the tab page.
        /// </summary>
        /// <value>The tab page.</value>
        public System.Windows.Forms.TabPage TabPage															// 1.0.010
		{																									
			get {return this._TabPage;}																		
		}                                                                                                   

        /// <summary>
        /// Gets the zeroit ayensu tab page.
        /// </summary>
        /// <value>The zeroit ayensu tab page.</value>
        public ZeroitAyensuTabPage ZeroitAyensuTabPage																// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				if( (this._TabPage != null)																	// 1.0.010
				&&( (this._TabPage.GetType() == typeof(ZeroitAyensuTabPage))								// 1.0.010
					|| this._TabPage.GetType().IsSubclassOf(typeof(ZeroitAyensuTabPage))					// 1.0.010
					)																						// 1.0.010
				)																							// 1.0.010
				{																							// 1.0.010
					return (ZeroitAyensuTabPage)this._TabPage;												// 1.0.010
				}																							// 1.0.010
				return null;																				// 1.0.010
			}																								// 1.0.010
		}                                                                                                   // 1.0.010


        /// <summary>
        /// Gets the tab event.
        /// </summary>
        /// <value>The tab event.</value>
        public TabEventArgs.TabEvents TabEvent													
		{																									
			get {return this._TabEvent;}																	
		}																									
	}
    #endregion

    #region Class:  TabsReorderedEventArgs : TabEventArgs
    /// <summary>
    /// Class TabsReorderedEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Tabs.TabEventArgs" />
    public class TabsReorderedEventArgs : TabEventArgs											// 1.0.003
	{
        /// <summary>
        /// The al tab order
        /// </summary>
        protected System.Collections.ArrayList _alTabOrder = new System.Collections.ArrayList();            // 1.0.003

        /// <summary>
        /// Initializes a new instance of the <see cref="TabsReorderedEventArgs"/> class.
        /// </summary>
        public TabsReorderedEventArgs()																		// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Initializes a new instance of the <see cref="TabsReorderedEventArgs"/> class.
        /// </summary>
        /// <param name="alTabOrder">The al tab order.</param>
        public TabsReorderedEventArgs(System.Collections.ArrayList alTabOrder)								// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
			if (alTabOrder != null) 																		// 1.0.003
			{																								// 1.0.003
				this._alTabOrder = alTabOrder;																// 1.0.003
			}																								// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Initializes a new instance of the <see cref="TabsReorderedEventArgs"/> class.
        /// </summary>
        /// <param name="intTabOrder">The int tab order.</param>
        public TabsReorderedEventArgs(int[] intTabOrder)													// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
			if( (intTabOrder != null)																		// 1.0.003
			&& (intTabOrder.Length > 0) )																	// 1.0.003
			{																								// 1.0.003
				this._alTabOrder = new System.Collections.ArrayList(intTabOrder.Length);					// 1.0.003
				this._alTabOrder.AddRange(intTabOrder);														// 1.0.003
			}																								// 1.0.003
		}                                                                                                   // 1.0.003



        /// <summary>
        /// Gets the tab order.
        /// </summary>
        /// <value>The tab order.</value>
        public System.Collections.ArrayList TabOrder														// 1.0.003
		{																									// 1.0.003
			get {return this._alTabOrder;}																	// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Gets the tab order int.
        /// </summary>
        /// <value>The tab order int.</value>
        public int[] TabOrder_int																			// 1.0.003
		{																									// 1.0.003
			get																								// 1.0.003
			{																								// 1.0.003
				if (this._alTabOrder.Count > 0)																// 1.0.003
				{																							// 1.0.003
					return (int[])this._alTabOrder.ToArray(typeof(int));									// 1.0.003
				}																							// 1.0.003
				return new int[]{};																			// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003
	}
	#endregion 
}																											