// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabCtl_Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region using ...
using System;																								

using System.ComponentModel;																				



using System.Windows.Forms;																					



#endregion 

namespace Zeroit.Framework.MiscControls.Tabs																				
{
    /// <summary>
    /// Class ZeroitAyensuTab_Designer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    internal class ZeroitAyensuTab_Designer : System.Windows.Forms.Design.ParentControlDesigner					
	{
        #region Class Private Fields
        //private System.ComponentModel.Design.DesignerVerbCollection _Verbs;								
        /// <summary>
        /// The verbs
        /// </summary>
        private System.ComponentModel.Design.DesignerVerbCollection _Verbs = new System.ComponentModel.Design.DesignerVerbCollection();
        /// <summary>
        /// The verb add TDH tab page
        /// </summary>
        private System.ComponentModel.Design.DesignerVerb _Verb_Add_TdhTabPage;                             // 1.0.021
                                                                                                            /// <summary>
                                                                                                            /// The verb add tab page
                                                                                                            /// </summary>
        private System.ComponentModel.Design.DesignerVerb _Verb_Add_TabPage;                                // 1.0.021
                                                                                                            /// <summary>
                                                                                                            /// The verb remove tab page
                                                                                                            /// </summary>
        private System.ComponentModel.Design.DesignerVerb _Verb_Remove_TabPage;                             // 1.0.021

        /// <summary>
        /// The designer host
        /// </summary>
        private System.ComponentModel.Design.IDesignerHost _DesignerHost;
        /// <summary>
        /// The selection service
        /// </summary>
        private System.ComponentModel.Design.ISelectionService _SelectionService;
        #endregion

        #region Class construcor and destructor
        /// <summary>
        /// Prevents a default instance of the <see cref="ZeroitAyensuTab_Designer"/> class from being created.
        /// </summary>
        ZeroitAyensuTab_Designer() : base()																		
		{																									
			Verbs_Build();								// Build a new list of context menu items			
		}

        /// <summary>
        /// Finalizes an instance of the <see cref="ZeroitAyensuTab_Designer"/> class.
        /// </summary>
        ~ZeroitAyensuTab_Designer()																				
		{																									
			_Verb_Add_TdhTabPage = null;																	// 1.0.021
			_Verb_Add_TabPage = null;																		// 1.0.021
			_Verb_Remove_TabPage = null;																	// 1.0.021
			_Verbs.Clear();																					
			_Verbs = null;																					

			_DesignerHost = null;																			
			_SelectionService = null;																		
		}
        #endregion

        #region EventHandlers -- Add/Remove TabPages
        // private void OnAdd_TdhTabPage(object sender, System.EventArgs e) 
        // private void OnAdd_TabPage(object sender, System.EventArgs e)
        // private void OnRemove_TabPage(object sender, System.EventArgs e)
        // 
        /// <summary>
        /// Handles the <see cref="E:AddTdhTabPage" /> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnAdd_TdhTabPage(object sender, System.EventArgs e)									
		{																									
			ZeroitAyensuTab ParentControl = (ZeroitAyensuTab)this.Control;	
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				

			string newTab_Name = "Page"+ (ParentControl.TabCount + 1).ToString();							
			ZeroitAyensuTabPage newTab =														
				(ZeroitAyensuTabPage)DesignerHost.CreateComponent(								
					typeof(ZeroitAyensuTabPage)												
				);																							
			#region Commented out -- alternate creation of the new TabPage
			// This signature supplies the actual name of the control being created ... however, if there	
			// is already a control by that name (this can easily happen if a TabPage is added and then		
			// removed from the collection), an exception is thrown.  So, it's better to instead allow		
			// the default name to be generated/used.														
			//Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTabPage newTab =														
			//	(Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTabPage)DesignerHost.CreateComponent(								
			//		typeof(Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTabPage), 												
			//		newTab_Name																				
			//	);																							
			#endregion 
			//newTab.Text = newTab.Name;					// Set .Text to the auto-generated name			
			newTab.Text = newTab_Name;																		
			ParentControl.TabPages.Add(newTab);																

			RaiseComponentChanged(																			
				System.ComponentModel.TypeDescriptor.GetProperties(ParentControl)["TabPages"],				
				oldTabs,																					
				ParentControl.TabPages																		
			);																								
			ParentControl.SelectedTab = newTab;																

			Verbs_Set();																					
		}

        /// <summary>
        /// Handles the <see cref="E:AddTabPage" /> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnAdd_TabPage(object sender, System.EventArgs e)										
		{																									
			ZeroitAyensuTab ParentControl = (ZeroitAyensuTab)this.Control;	
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				

			string newTab_Name = "Page"+ (ParentControl.TabCount + 1).ToString();							
			System.Windows.Forms.TabPage newTab =															
				(System.Windows.Forms.TabPage)DesignerHost.CreateComponent(									
					typeof(System.Windows.Forms.TabPage)													
				);																							
			#region Commented out -- alternate creation of the new TabPage
			// This signature supplies the actual name of the control being created ... however, if there	
			// is already a control by that name (this can easily happen if a TabPage is added and then		
			// removed from the collection), an exception is thrown.  So, it's better to instead allow		
			// the default name to be generated/used.														
			//System.Windows.Forms.TabPage newTab =															
			//	(System.Windows.Forms.TabPage)DesignerHost.CreateComponent(									
			//		typeof(System.Windows.Forms.TabPage), 													
			//		newTab_Name																				
			//	);																							
			#endregion 
			//newTab.Text = newTab.Name;					// Set .Text to the auto-generated name			
			newTab.Text = newTab_Name;																		
			ParentControl.TabPages.Add(newTab);																

			RaiseComponentChanged(																			
				System.ComponentModel.TypeDescriptor.GetProperties(ParentControl)["TabPages"],				
				oldTabs,																					
				ParentControl.TabPages																		
			);																								
			ParentControl.SelectedTab = newTab;																

			Verbs_Set();																					
		}

        /// <summary>
        /// Handles the <see cref="E:RemoveTabPage" /> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnRemove_TabPage(object sender, System.EventArgs e)									
		{																									
			ZeroitAyensuTab ParentControl = (ZeroitAyensuTab)this.Control;	
			if (ParentControl.SelectedIndex < 0)															
			{																								
				Verbs_Set();																				
				MessageBox.Show("No TabPage selected.");													
				return;																						
			}																								
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				
			DesignerHost.DestroyComponent(ParentControl.TabPages[ParentControl.SelectedIndex]);				
			RaiseComponentChanged(																			
				TypeDescriptor.GetProperties(ParentControl)["TabPages"],									
				oldTabs,																					
				ParentControl.TabPages																		
			);																								

			SelectionService.SetSelectedComponents(															
				new IComponent[] {ParentControl},															
				//System.ComponentModel.Design.SelectionTypes.Auto		// .Auto is undefined				
				System.ComponentModel.Design.SelectionTypes.Normal											
				);																							

			Verbs_Set();																					
		}
        #endregion

        #region Over-ridden Methods
        // protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)
        // public override System.Windows.Forms.Design.SelectionRules SelectionRules {get}
        // 
        /// <summary>
        /// Called when the control that the designer is managing has painted its surface so the designer can paint any additional adornments on top of the control.
        /// </summary>
        /// <param name="pe">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that provides data for the event.</param>
        protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)					
		{																									
			// Don't want DrawGrid dots on the TabControl itself.											
		}

        /// <summary>
        /// Gets the selection rules that indicate the movement capabilities of a component.
        /// </summary>
        /// <value>The selection rules.</value>
        public override System.Windows.Forms.Design.SelectionRules SelectionRules							
		{																									
			get																								
			{																								
				//Fix the AllSizable selectionrule on DockStyle.Fill										
				if (this.Control.Dock == System.Windows.Forms.DockStyle.Fill)								
				{																							
					return System.Windows.Forms.Design.SelectionRules.Visible;								
				}																							
				return base.SelectionRules;																	
			}																								
		}
        #endregion

        #region Properties
        // public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        // public System.ComponentModel.Design.IDesignerHost DesignerHost
        // public System.ComponentModel.Design.ISelectionService SelectionService
        // 
        /// <summary>
        /// Gets the design-time verbs supported by the component that is associated with the designer.
        /// </summary>
        /// <value>The verbs.</value>
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs							
		{																									
			get																								
			{																								
				if( (_Verbs == null)					// The Constructor should have built the .Verbs		
				|| (_Verbs.Count <= 0) )																	
				{																							
					Verbs_Build();						// Build a new list of context menu items			
				}																							

				#region Enable/Disable the "Remove Tab" MenuItem
				//if (_Verbs.Count == 3)																	
				//{																							
				//	//Verbs_Set();						// This causes a stack overflow when used here		
				//
				//	Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTab ParentControl = (Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTab)this.Control;	
				//	if (ParentControl.TabCount > 0)															
				//	{																						
				//		_Verbs[2].Enabled = true;															
				//	}																						
				//	else																					
				//	{																						
				//		_Verbs[2].Enabled = false;															
				//	}																						
				//}																							

				if (_Verb_Remove_TabPage != null)															// 1.0.021
				{																							// 1.0.021
					Verbs_Set();																			// 1.0.021

//					Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTab ParentControl = (Zeroit.Framework.MiscControls.Tabs.ZeroitAyensuTab)this.Control;	// 1.0.021
//					if (ParentControl.TabCount > 0)															// 1.0.021
//					{																						// 1.0.021
//						//_Verbs[2].Enabled = true;															// 1.0.021
//						_Verb_Remove_TabPage.Enabled = true;												// 1.0.021
//					}																						// 1.0.021
//					else																					// 1.0.021
//					{																						// 1.0.021
//						//_Verbs[2].Enabled = false;														// 1.0.021
//						_Verb_Remove_TabPage.Enabled = false;												// 1.0.021
//					}																						// 1.0.021
				}																							// 1.0.021
				#endregion 

				return _Verbs;																				
			}																								
		}


        /// <summary>
        /// Gets the designer host.
        /// </summary>
        /// <value>The designer host.</value>
        public System.ComponentModel.Design.IDesignerHost DesignerHost										
		{																									
			get																								
			{																								
				if (_DesignerHost == null)																	
				{																							
					_DesignerHost = (System.ComponentModel.Design.IDesignerHost)(GetService(typeof(System.ComponentModel.Design.IDesignerHost)));	
				}																							
				return _DesignerHost;																		
			}																								
		}


        /// <summary>
        /// Gets the selection service.
        /// </summary>
        /// <value>The selection service.</value>
        public System.ComponentModel.Design.ISelectionService SelectionService
		{
			get
			{
				if (_SelectionService == null)
				{
					_SelectionService = (System.ComponentModel.Design.ISelectionService)(this.GetService(typeof(System.ComponentModel.Design.ISelectionService)));
				}
				return _SelectionService;
			}
		}
        #endregion

        #region Private Methods
        // private void Verbs_Build()
        // private void Verbs_Set()
        // 
        /// <summary>
        /// Verbses the build.
        /// </summary>
        private void Verbs_Build()																			
		{																									
			// Build a new list of context menu items														
			if (_Verbs == null)																				
			{																								
				_Verbs = new System.ComponentModel.Design.DesignerVerbCollection();							
			}																								
			else																							// 1.0.021
			{																								// 1.0.021
				_Verbs.Clear();																				// 1.0.021
			}																								// 1.0.021
			//if (_Verbs.Count <= 0)																		
			{																								
				#region Create the .Verbs [ _Verbs.AddRange(...) ]
				//_Verbs.AddRange(																			
				//	new System.ComponentModel.Design.DesignerVerb[]											
				//		{																					
				//			new System.ComponentModel.Design.DesignerVerb(									
				//				"Add ZeroitAyensuTabPage",															
				//				new System.EventHandler(OnAdd_TdhTabPage)									
				//			),																				
				//			new System.ComponentModel.Design.DesignerVerb(									
				//				"Add TabPage",																
				//				new System.EventHandler(OnAdd_TabPage)										
				//			),																				
				//			new System.ComponentModel.Design.DesignerVerb(									
				//				"Remove Tab",																
				//				new System.EventHandler(OnRemove_TabPage)									
				//			)																				
				//		}																					
				//	);																						

				_Verb_Add_TdhTabPage = new System.ComponentModel.Design.DesignerVerb(						// 1.0.021
					"Add ZeroitAyensuTabPage",																		// 1.0.021
					new System.EventHandler(OnAdd_TdhTabPage)												// 1.0.021
					);																						// 1.0.021
				_Verb_Add_TabPage = new System.ComponentModel.Design.DesignerVerb(							// 1.0.021
					"Add TabPage",																			// 1.0.021
					new System.EventHandler(OnAdd_TabPage)													// 1.0.021
					);																						// 1.0.021
				_Verb_Remove_TabPage = new System.ComponentModel.Design.DesignerVerb(						// 1.0.021
					"Remove Tab",																			// 1.0.021
					new System.EventHandler(OnRemove_TabPage)												// 1.0.021
					);																						// 1.0.021

				_Verbs.AddRange(																			// 1.0.021
					new System.ComponentModel.Design.DesignerVerb[]											// 1.0.021
						{																					// 1.0.021
							_Verb_Add_TdhTabPage, 															// 1.0.021
							_Verb_Add_TabPage,																// 1.0.021
							_Verb_Remove_TabPage															// 1.0.021
						}																					// 1.0.021
					);																						// 1.0.021
				#endregion 
			}																								
		}

        /// <summary>
        /// Verbses the set.
        /// </summary>
        private void Verbs_Set()																			
		{																									
			// Enable/Disable the "Remove Tab" MenuItem														
			if (_Verb_Remove_TabPage != null)																// 1.0.021
			{																								// 1.0.021
				ZeroitAyensuTab ParentControl = (ZeroitAyensuTab)this.Control;	
				//switch (ParentControl.TabPages.Count)														
				switch (ParentControl.TabCount)																
				{																							
					case 0:																					
						//Verbs[2].Enabled = false;															
						_Verb_Remove_TabPage.Enabled = false;												// 1.0.021
						break;																				
					default:																				
						//Verbs[2].Enabled = true;															
						_Verb_Remove_TabPage.Enabled = true;												// 1.0.021
						break;																				
				}																							
			}																								// 1.0.021
		}
        #endregion


        #region [WndProc(...)] and [GetHitTest(...)] -- Design-time mouse interactivity

        // The code in this section allows design-time selection of the TabControl and individual TabPages	
        // via mouse-clicks.  When this section of code isn't included in the [ZeroitAyensuTab_Designer] class,	
        // the class still works, but it doesn't properly interact with the mouse at design-time.			

        /// <summary>
        /// Enum TabControlHitTest
        /// </summary>
        private enum TabControlHitTest																		
		{
            /// <summary>
            /// The TCHT nowhere
            /// </summary>
            TCHT_NOWHERE = 1,
            /// <summary>
            /// The TCHT onitemicon
            /// </summary>
            TCHT_ONITEMICON = 2,
            /// <summary>
            /// The TCHT onitemlabel
            /// </summary>
            TCHT_ONITEMLABEL = 4,
            /// <summary>
            /// The TCHT onitem
            /// </summary>
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL												
		}

        /// <summary>
        /// Struct TCHITTESTINFO
        /// </summary>
        private struct TCHITTESTINFO																		
		{
            /// <summary>
            /// The pt
            /// </summary>
            public System.Drawing.Point pt;
            /// <summary>
            /// The flags
            /// </summary>
            public TabControlHitTest flags;																	
		}


        #region Constants
        /// <summary>
        /// The httransparent
        /// </summary>
        private const int HTTRANSPARENT = -1;
        /// <summary>
        /// The htclient
        /// </summary>
        private const int HTCLIENT = 1;
        /// <summary>
        /// The TCM hittest
        /// </summary>
        private const int TCM_HITTEST = 0x130D;
        /// <summary>
        /// The wm nchittest
        /// </summary>
        private const int WM_NCHITTEST = 0x84;

        //		//internal const int WM_MOUSEMOVE = 0x200;															
        //		internal const int WM_LBUTTONDOWN = 0x0201;															
        //		internal const int WM_LBUTTONUP = 0x0202;															
        //		internal const int WM_LBUTTONDBLCLK = 0x0203;														
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        internal const int WM_RBUTTONDOWN = 0x0204;
        //		internal const int WM_RBUTTONUP = 0x0205;															
        //		//internal const int WM_RBUTTONDBLCLK = 0x206;														
        //		//internal const int WM_MBUTTONDOWN = 0x207;														
        //		//internal const int WM_MBUTTONUP = 0x208;															
        //		//internal const int WM_MBUTTONDBLCLK = 0x209;														
        //		//internal const int WM_MOUSEWHEEL = 0x20A;		// = 522;	// ???									
        #endregion

        /// <summary>
        /// Processes Windows messages and optionally routes them to the control.
        /// </summary>
        /// <param name="m">The <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)									
		{																									
			base.WndProc(ref m);																			

			if (m.Msg == WM_NCHITTEST)																		
			{																								
				// Select TabControl when TabControl clicked outside of TabItem.							
				if (m.Result.ToInt32() == HTTRANSPARENT)													
				{																							
					m.Result = (IntPtr)HTCLIENT;															
				}																							
			}																								
			else																							
			if (m.Msg == WM_RBUTTONDOWN)																	
			{																								
				// The method [Verbs_Set()] isn't executed by the custom [TabControlDesigner] class.		
				// This is a kludge to achieve almost that by intercepting the mouse right-click			
				Verbs_Set();																				
			}																								
		}


        /// <summary>
        /// Indicates whether a mouse click at the specified point should be handled by the control.
        /// </summary>
        /// <param name="point">A <see cref="T:System.Drawing.Point" /> indicating the position at which the mouse was clicked, in screen coordinates.</param>
        /// <returns>true if a click at the specified point is to be handled by the control; otherwise, false.</returns>
        protected override bool GetHitTest(System.Drawing.Point point)										
		{																									
			if (this.SelectionService.PrimarySelection == this.Control)										
			{																								
				TCHITTESTINFO hti = new TCHITTESTINFO();													

				hti.pt = this.Control.PointToClient(point);													
				hti.flags = 0;																				

				System.Windows.Forms.Message m = new System.Windows.Forms.Message();						
				m.HWnd = this.Control.Handle;																
				m.Msg = TCM_HITTEST;																		

				IntPtr lparam = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(hti));	
				System.Runtime.InteropServices.Marshal.StructureToPtr(hti, lparam, false);					
				m.LParam = lparam;																			

				base.WndProc(ref m);																		
				System.Runtime.InteropServices.Marshal.FreeHGlobal(lparam);									

				if (m.Result.ToInt32() != -1)																
				{																							
					return hti.flags != TabControlHitTest.TCHT_NOWHERE;										
				}																							
			}																								
			return false;																					
		}																									
		#endregion 
	}																										
}																											