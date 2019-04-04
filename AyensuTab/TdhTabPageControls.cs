// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabPageControls.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.MiscControls.Tabs																				
{
    /// <summary>
    /// Summary description for ZeroitAyensuTabPageControls.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control.ControlCollection" />
    [System.ComponentModel.ToolboxItem(false)]																
	public class ZeroitAyensuTabPageControls : System.Windows.Forms.Control.ControlCollection						
	{
        #region pseudo-[Component Designer generated instantiation of components]

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region pseudo-[Component Designer generated code]
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()																	
		{																									
			components = new System.ComponentModel.Container();												
		}
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
        private ZeroitAyensuTab _owner = null;
        #endregion

        #region Class Constructor (and Dispose)
        // public ZeroitAyensuTabPageControls(Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTab owner)
        //     : base((System.Windows.Forms.Control)owner)
        // 
        // protected void Dispose( bool disposing )
        // 
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabPageControls"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public ZeroitAyensuTabPageControls(ZeroitAyensuTab owner)									
			: base((System.Windows.Forms.Control)owner)														
		{																									
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000

			_owner = owner;																					
		}


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        //protected override void Dispose( bool disposing )													
        protected void Dispose( bool disposing )															
		{																									
			if( disposing )																					
			{																								
				if(components != null)																		
				{																							
					components.Dispose();																	
				}																							
			}																								
			//base.Dispose( disposing );																	
		}
        #endregion

        #region New/Override Properties
        // public new System.Windows.Forms.Control this[int index]
        // public new int Count {get}
        // public new bool IsReadOnly {get}
        //
        // the .Item (.TabPage) indexer
        /// <summary>
        /// Gets the <see cref="System.Windows.Forms.Control"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Windows.Forms.Control.</returns>
        public new System.Windows.Forms.Control this[int index]												
		{																									
			get																								
			{																								
				int idx = 0;																				
				if (index > 0)																				
				{																							
					idx = index;																			
				}																							
				if (idx >= this.Count)																		
				{																							
					idx = this.Count - 1;																	
				}																							

				if (idx < 0)																				
				{																							
					return null;																			
				}																							
				return (base[idx] as System.Windows.Forms.Control);											
			}																								
		}

        //public new int Count																				
        //{																									
        //	get { return base.Count; }																		
        //}																									
        //
        //public new bool IsReadOnly																			
        //{																									
        //	get { return base.IsReadOnly; }																	
        //}																									
        #endregion

        #region New/Override and Novel Methods/Functions 
        // public override void Add(System.Windows.Forms.Control control)
        // public override void AddRange(System.Windows.Forms.Control[] controls)
        //     public new void AddRange(params System.Windows.Forms.Control[] controls)
        // 
        /// <summary>
        /// Adds the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        public override void Add(System.Windows.Forms.Control control)										
		{																									
//			if( (control.GetType() == typeof(ZeroitAyensuTab.ZeroitAyensuTabPage))											
//			|| control.GetType().IsSubclassOf(typeof(ZeroitAyensuTab.ZeroitAyensuTabPage))									
//			)																								
//			{																								
//				_owner.TabPages.Add((ZeroitAyensuTab.ZeroitAyensuTabPage)control);											
//			}																								
//			else																							
//			{																								
//				base.Add(control);																			
//			}																								

			if( (control.GetType() == typeof(System.Windows.Forms.TabPage))									// 1.0.020
			|| control.GetType().IsSubclassOf(typeof(System.Windows.Forms.TabPage)) 						// 1.0.020
			)																								// 1.0.020
			{																								// 1.0.020
				_owner.TabPages.Add((System.Windows.Forms.TabPage)control);									// 1.0.020
			}																								// 1.0.020

		}

        //public new void AddRange(params System.Windows.Forms.Control[] controls)							
        /// <summary>
        /// Adds an array of control objects to the collection.
        /// </summary>
        /// <param name="controls">An array of <see cref="T:System.Windows.Forms.Control" /> objects to add to the collection.</param>
        public override void AddRange(System.Windows.Forms.Control[] controls)								// 1.0.020
		{																									
			foreach (System.Windows.Forms.Control _control in controls)										
			{																								
				//if( (_control.GetType() == typeof(ZeroitAyensuTab.ZeroitAyensuTabPage))									
				//|| control.GetType().IsSubclassOf(typeof(ZeroitAyensuTab.ZeroitAyensuTabPage))							
				//)																							
				//{																							
				//	_owner.TabPages.Add((ZeroitAyensuTab.ZeroitAyensuTabPage)_control);									
				//}																							
				//else																						
				//{																							
				//	base.Add(control);																		
				//}																							
				this.Add(_control);																			
			}																								
		}																									
		#endregion 
	}																										
}																											