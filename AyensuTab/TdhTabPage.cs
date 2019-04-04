// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabPage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region using ...

#endregion 

namespace Zeroit.Framework.MiscControls.Tabs																				// 1.0.000
{
    /// <summary>
    /// Summary description for ZeroitAyensuTabPage.																	// 1.0.000
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabPage" />

    // I've read that if one doesn't supply a custom TabPageDesigner for a custom TabPage,					// 1.0.020
    // it will misbehave in the VS2005 design environment.													// 1.0.020
    // Fortunately, we can use [.ScrollableControlDesigner] rather than writing one							// 1.0.020
    [System.ComponentModel.Designer(typeof(System.Windows.Forms.Design.ScrollableControlDesigner))]			// 1.0.020

	[System.ComponentModel.DesignTimeVisible(true)]															// 1.0.000
	[System.ComponentModel.ToolboxItem(false)]																// 1.0.000

	public class ZeroitAyensuTabPage : System.Windows.Forms.TabPage													// 1.0.000
	{
        #region pseudo-[Windows Component Designer generated instantiation of components]

        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.Container components = null;
        private System.ComponentModel.IContainer components;                                                // 1.0.001
        #endregion

        #region pseudo-[Component Designer generated code]
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
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

        #region ZeroitAyensuTabPage class constructor (and Dispose), etc
        // public ZeroitAyensuTabPage(System.ComponentModel.IContainer container)
        // public ZeroitAyensuTabPage()
        // 
        // protected override void Dispose( bool disposing )
        // 
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabPage"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ZeroitAyensuTabPage(System.ComponentModel.IContainer container)										// 1.0.000
		{
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			if (gblRunModeIs_DesignMode)																	// 1.0.001
			{																								// 1.0.001
				container.Add(this);
			}																								// 1.0.001
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabPage"/> class.
        /// </summary>
        public ZeroitAyensuTabPage()																					// 1.0.000
		{
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
         
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        #endregion

        #region New and Over-ridden Fields/Properties
        // public override string Text {get} {set}
        // 
        /// <summary>
        /// Gets or sets the text to display on the tab.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
		{
			get {return base.Text;}																			// 1.0.001
			set
			{
				// This is awkward; It seems to be the only way to ensure space on the Tabs for the buttons	// 1.0.001
				if (value == null)																			// 1.0.001
				{																							// 1.0.001
					base.Text = "		";																	// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				if (this._tabShowCloseButton || this._tabShowMenuButton)									// 1.0.001
				{																							// 1.0.001
					if (this._tabShowCloseButton && this._tabShowMenuButton)								// 1.0.001
					{																						// 1.0.001
						//base.Text = " "+ value.Trim() +"             ";									// 1.0.001
						base.Text = value.Trim() +"              ";											// 1.0.010
					}																						// 1.0.001
					else																					// 1.0.001
					{																						// 1.0.001
						//base.Text = " "+ value.Trim() +"      ";											// 1.0.001
						base.Text = value.Trim() +"       ";												// 1.0.010
					}																						// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					//base.Text = " "+ value.Trim();														// 1.0.001
					base.Text = value.Trim();																// 1.0.010
				}																							// 1.0.001
			}
		}
        #endregion

        #region Novel Fields/Properties
        // public bool TabAllowClose {get} {set}
        // public bool TabAllowContextMenu {get} {set}
        // public bool TabConfirmOnClose {get} {set}
        // public bool TabShowCloseButton {get} {set}
        // public bool TabShowMenuButton {get} {set}
        // 
        /// <summary>
        /// The tab allow close
        /// </summary>
        private bool _tabAllowClose = true;                                                                 // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets or sets a value indicating whether [tab allow close].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [tab allow close]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether to allow closing of the ZeroitAyensuTabPage.")]		// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabAllowClose																			// 1.0.001
		{																									// 1.0.001
			get {return this._tabAllowClose;}																// 1.0.001
			set																								// 1.0.001
			{																								// 1.0.001
				this._tabAllowClose = value;																// 1.0.001
				//this._tabShowCloseButton = value;															// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// The tab allow context menu
        /// </summary>
        private bool _tabAllowContextMenu = true;                                                           // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets or sets a value indicating whether [tab allow context menu].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [tab allow context menu]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether a ContextMenu may be displayed by right-clicking Tab of the ZeroitAyensuTabPage.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabAllowContextMenu																		// 1.0.001
		{																									// 1.0.001
			get	{return this._tabAllowContextMenu;}															// 1.0.001
			set {this._tabAllowContextMenu = value;}														// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// The tab confirm on close
        /// </summary>
        private bool _tabConfirmOnClose = true;                                                             // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets or sets a value indicating whether [tab confirm on close].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [tab confirm on close]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether confirmation is required before closing the ZeroitAyensuTabPage.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabConfirmOnClose																		// 1.0.001
		{																									// 1.0.001
			get {return this._tabConfirmOnClose;}															// 1.0.001
			set {this._tabConfirmOnClose = value;}															// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// The tab show close button
        /// </summary>
        private bool _tabShowCloseButton = true;                                                            // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets or sets a value indicating whether [tab show close button].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [tab show close button]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Category("Appearance")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether a Close Button may be displayed on the ZeroitAyensuTabPage.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabShowCloseButton																		// 1.0.001
		{																									// 1.0.001
			get	{return this._tabShowCloseButton;}															// 1.0.001
			set 																							// 1.0.001
			{																								// 1.0.001
				//this._tabAllowClose = value;																// 1.0.001
				this._tabShowCloseButton = value;															// 1.0.001

				this.Text = this.Text;																		// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// The tab show menu button
        /// </summary>
        private bool _tabShowMenuButton = true;                                                             // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets or sets a value indicating whether [tab show menu button].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [tab show menu button]; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Category("Appearance")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether a Menu Button may be displayed on the ZeroitAyensuTabPage.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabShowMenuButton																		// 1.0.001
		{																									// 1.0.001
			get	{return this._tabShowMenuButton;}															// 1.0.001
			set 																							// 1.0.001
			{																								// 1.0.001
				this._tabShowMenuButton = value;															// 1.0.001

				this.Text = this.Text;																		// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001
		#endregion  
	}
}
