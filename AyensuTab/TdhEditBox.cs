// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhEditBox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;																				// 1.0.001

namespace Zeroit.Framework.MiscControls.Tabs																	// 1.0.001
{                                                                                                           // 1.0.001
    #region Class:  internal class AyensuEditBox. : System.ComponentModel.Component
    /// <summary>
    /// // 1.0.001
    /// Summary description for AyensuEditBox..																	// 1.0.001
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]																					// 1.0.001
	internal class AyensuEditBox : System.ComponentModel.Component												// 1.0.001
	{
        #region Windows Component Designer generated instantiation of components

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
        #endregion


        #region Class variables 
        /// <summary>
        /// Occurs when [on edit complete].
        /// </summary>
        public event EditComplete OnEditComplete;                           // 1.0.001
                                                                            /// <summary>
                                                                            /// The FRM edit box
                                                                            /// </summary>
        private frmEditBox _frmEditBox;                                                         // 1.0.001
        #endregion

        #region AyensuEditBox. class constructor (and Dispose), etc
        // public AyensuEditBox.(System.ComponentModel.IContainer container)
        // public AyensuEditBox.()
        // public AyensuEditBox.(AyensuEditBox..EditComplete delegate_OnEditComplete)
        // 
        // protected override void Dispose( bool disposing )
        // 
        /// <summary>
        /// Initializes a new instance of the <see cref="AyensuEditBox"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AyensuEditBox(System.ComponentModel.IContainer container)											// 1.0.001
		{																									// 1.0.001
			///																								// 1.0.001
			/// Required for Windows.Forms Class Composition Designer support								// 1.0.001
			///																								// 1.0.001
			container.Add(this);																			// 1.0.001
			InitializeComponent();																			// 1.0.001
			//																								// 1.0.001
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.001
			//																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Initializes a new instance of the <see cref="AyensuEditBox"/> class.
        /// </summary>
        public AyensuEditBox()																					// 1.0.001
		{																									// 1.0.001
			///																								// 1.0.001
			/// Required for Windows.Forms Class Composition Designer support								// 1.0.001
			///																								// 1.0.001
			InitializeComponent();																			// 1.0.001
			//																								// 1.0.001
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.001
			//																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Initializes a new instance of the <see cref="AyensuEditBox"/> class.
        /// </summary>
        /// <param name="delegate_OnEditComplete">The delegate on edit complete.</param>
        public AyensuEditBox(EditComplete delegate_OnEditComplete)									// 1.0.001
		{																									// 1.0.001
			///																								// 1.0.001
			/// Required for Windows.Forms Class Composition Designer support								// 1.0.001
			///																								// 1.0.001
			InitializeComponent();																			// 1.0.001
			//																								// 1.0.001
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.001
			//																								// 1.0.001
			if (delegate_OnEditComplete != null)															// 1.0.001
			{																								// 1.0.001
//this.OnEditComplete -= this.OnEditComplete;
////this.OnEditComplete = null;

				this.OnEditComplete = delegate_OnEditComplete;												// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// // 1.0.001
        /// Clean up any resources being used.																// 1.0.001
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose( bool disposing )													// 1.0.001
		{																									// 1.0.001
			if( disposing )																					// 1.0.001
			{																								// 1.0.001
				if(components != null)																		// 1.0.001
				{																							// 1.0.001
					components.Dispose();																	// 1.0.001
				}																							// 1.0.001
				
				if( (this._frmEditBox != null)																// 1.0.001
				&& !this._frmEditBox.Disposing																// 1.0.001
				&& !this._frmEditBox.IsDisposed																// 1.0.001
				//&& this._frmEditBox.Created																	// 1.0.001
				)																							// 1.0.001
				{																							// 1.0.001
					this._frmEditBox.Close();																// 1.0.001
					this._frmEditBox.Dispose();																// 1.0.001
				}																							// 1.0.001
				this._frmEditBox = null;																	// 1.0.001

			}																								// 1.0.001
			base.Dispose( disposing );																		// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion


        #region Component-Internal EventHandler -- [private void EditComplete(...)]
        // private void EditComplete(object sender, ZeroitAyensuTab.ZeroitAyensuTabEditBox.EditEventArgs editArgs)
        // 
        /// <summary>
        /// Edits the complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="editArgs">The <see cref="EditEventArgs"/> instance containing the event data.</param>
        private void EditComplete(object sender, EditEventArgs editArgs)							// 1.0.001
		{																									// 1.0.001
			this._dialogResult = editArgs.DialogResult;														// 1.0.001
			this._editAccepted = editArgs.EditAccepted;														// 1.0.001
			this._editText = editArgs.EditText;																// 1.0.001
			this._editTextChanged = editArgs.EditTextChanged;												// 1.0.001

			if (this.OnEditComplete != null)																// 1.0.001
			{																								// 1.0.001
				this.OnEditComplete(sender, editArgs);														// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region Public Properties
        // public System.Windows.Forms.DialogResult DialogResult {get}
        // public bool EditAccepted {get} {set}
        // public string EditText {get} {set}
        // public bool EditTextChanged {get} {set}
        // 
        /// <summary>
        /// The dialog result
        /// </summary>
        private System.Windows.Forms.DialogResult _dialogResult = System.Windows.Forms.DialogResult.None;   // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets the dialog result.
                                                                                                            /// </summary>
                                                                                                            /// <value>The dialog result.</value>
        public System.Windows.Forms.DialogResult DialogResult												// 1.0.001
		{																									// 1.0.001
			get  																							// 1.0.001
			{ 																								// 1.0.001
				//if( (this._frmEditBox != null)															// 1.0.001
				//&& !this._frmEditBox.Disposing															// 1.0.001
				//&& !this._frmEditBox.IsDisposed															// 1.0.001
				////&& this._frmEditBox.Created																// 1.0.001
				//)																							// 1.0.001
				//{																							// 1.0.001
				//	return this._frmEditBox.DialogResult;													// 1.0.001
				//}																							// 1.0.001
				//return System.Windows.Forms.DialogResult.None;											// 1.0.001

				return this._dialogResult;																	// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// The edit accepted
        /// </summary>
        private bool _editAccepted = false;                                                                 // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets a value indicating whether [edit accepted].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [edit accepted]; otherwise, <c>false</c>.</value>
        public bool EditAccepted																			// 1.0.001
		{																									// 1.0.001
			get 																							// 1.0.001
			{																								// 1.0.001
				//if( (this._frmEditBox != null)															// 1.0.001
				//&& !this._frmEditBox.Disposing															// 1.0.001
				//&& !this._frmEditBox.IsDisposed															// 1.0.001
				////&& this._frmEditBox.Created																// 1.0.001
				//)																							// 1.0.001
				//{																							// 1.0.001
				//	//return this._frmEditBox.EditAccepted;													// 1.0.001
				//	return this._frmEditBox._editAccepted;													// 1.0.001
				//}																							// 1.0.001
				//return false;																				// 1.0.001

				return this._editAccepted;																	// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// The edit text
        /// </summary>
        private string _editText = "";                                                                      // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets the edit text.
                                                                                                            /// </summary>
                                                                                                            /// <value>The edit text.</value>
        public string EditText																				// 1.0.001
		{																									// 1.0.001
			get  																							// 1.0.001
			{ 																								// 1.0.001
				//if( (this._frmEditBox != null)															// 1.0.001
				//&& !this._frmEditBox.Disposing															// 1.0.001
				//&& !this._frmEditBox.IsDisposed															// 1.0.001
				////&& this._frmEditBox.Created																// 1.0.001
				//)																							// 1.0.001
				//{																							// 1.0.001
				//	//return this._frmEditBox.EditText;														// 1.0.001
				//	return this._frmEditBox._editText;														// 1.0.001
				//}																							// 1.0.001
				//return "";																				// 1.0.001

				return this._editText;																		// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// The edit text changed
        /// </summary>
        private bool _editTextChanged = false;                                                              // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Gets a value indicating whether [edit text changed].
                                                                                                            /// </summary>
                                                                                                            /// <value><c>true</c> if [edit text changed]; otherwise, <c>false</c>.</value>
        public bool EditTextChanged																			// 1.0.001
		{																									// 1.0.001
			get 																							// 1.0.001
			{																								// 1.0.001
				//if( (this._frmEditBox != null)																// 1.0.001
				//&& !this._frmEditBox.Disposing																// 1.0.001
				//&& !this._frmEditBox.IsDisposed																// 1.0.001
				////&& this._frmEditBox.Created																// 1.0.001
				//)																							// 1.0.001
				//{																							// 1.0.001
				//	//return this._frmEditBox.EditTextChanged;												// 1.0.001
				//	return this._frmEditBox._editTextChanged;												// 1.0.001
				//}																							// 1.0.001
				//return false;																				// 1.0.001

				return this._editTextChanged;																// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region Public Methods -- [.Show(...)] and [.ShowDialog(...)]
        // public void Show(System.Windows.Forms.Control control, string editText)
        // public void Show(System.Drawing.Point ptShow, int height, int width, string editText)
        // public void ShowDialog(System.Windows.Forms.Control control, string editText)
        // public void ShowDialog(System.Drawing.Point ptShow, int height, int width, string editText)
        // 
        // private void ShowIt(bool showDialog, System.Windows.Forms.Control control, string editText)
        // private void ShowIt(bool showDialog, System.Drawing.Point ptShow, int height, int width, string editText)
        // 
        /// <summary>
        /// Shows the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="editText">The edit text.</param>
        public void Show(System.Windows.Forms.Control control, string editText)								// 1.0.003
		{																									// 1.0.003
			ShowIt(false, control, editText);																// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Shows the specified pt show.
        /// </summary>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        public void Show(System.Drawing.Point ptShow, int height, int width, string editText)				// 1.0.001
		{																									// 1.0.001
			ShowIt(false, ptShow, height, width, editText);													// 1.0.003
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="editText">The edit text.</param>
        public void ShowDialog(System.Windows.Forms.Control control, string editText)						// 1.0.003
		{																									// 1.0.003
			ShowIt(true, control, editText);																// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        public void ShowDialog(System.Drawing.Point ptShow, int height, int width, string editText)			// 1.0.003
		{																									// 1.0.003
			ShowIt(true, ptShow, height, width, editText);													// 1.0.003
		}                                                                                                   // 1.0.003


        /// <summary>
        /// Shows it.
        /// </summary>
        /// <param name="showDialog">if set to <c>true</c> [show dialog].</param>
        /// <param name="control">The control.</param>
        /// <param name="editText">The edit text.</param>
        private void ShowIt(bool showDialog, System.Windows.Forms.Control control, string editText)			// 1.0.003
		{																									// 1.0.003
			System.Drawing.Point argPoint = new System.Drawing.Point(control.ClientRectangle.X, control.ClientRectangle.Y);	// 1.0.003
			argPoint = control.PointToScreen(argPoint);														// 1.0.003
			int argHeight = control.ClientRectangle.Height;													// 1.0.003
			int argWidth = control.ClientRectangle.Width;													// 1.0.003
			#region For certain types of Controls: Recompute [argPoint] [argHeight] [argWidth]
			if( (control.GetType() == typeof(System.Windows.Forms.TabPage))									// 1.0.003
			|| (control.GetType().IsSubclassOf(typeof(System.Windows.Forms.TabPage)) )						// 1.0.003
			)																								// 1.0.003
			{																								// 1.0.003
				System.Windows.Forms.TabPage tabPage = (System.Windows.Forms.TabPage)control;				// 1.0.003
				//System.Windows.Forms.Control tabParent = tabPage.GetContainerControl();					// 1.0.003
				System.Windows.Forms.Control tabParent = tabPage.Parent;									// 1.0.003
				if( (tabParent != null)																		// 1.0.003
					&&( (tabParent.GetType() == typeof(System.Windows.Forms.TabControl))					// 1.0.003
					|| (tabParent.GetType().IsSubclassOf(typeof(System.Windows.Forms.TabControl)) )			// 1.0.003
					)																						// 1.0.003
				)																							// 1.0.003
				{																							// 1.0.003
					System.Windows.Forms.TabControl tabCtl = (System.Windows.Forms.TabControl)tabParent;	// 1.0.003
					//int idx = tabPage.TabIndex;			// Assumes [tabPage.TabIndex] is correct value	// 1.0.003
					int idx = tabCtl.TabPages.IndexOf(tabPage);												// 1.0.003
					System.Drawing.RectangleF tabRect = (System.Drawing.RectangleF)tabCtl.GetTabRect(idx);	// 1.0.003
					argPoint = tabCtl.PointToScreen(new System.Drawing.Point((int)tabRect.X, (int)tabRect.Y));// 1.0.003
					argHeight = (int)tabRect.Height;														// 1.0.003
					argWidth = (int)tabRect.Width;															// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.003
			#endregion 
			string argEditText = editText.Trim();															// 1.0.003
			if (argEditText.Length <= 0)																	// 1.0.003
			{																								// 1.0.003
				argEditText = control.Text.Trim();															// 1.0.003
			}																								// 1.0.003

			ShowIt(showDialog, argPoint, argHeight, argWidth, argEditText);									// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Shows it.
        /// </summary>
        /// <param name="showDialog">if set to <c>true</c> [show dialog].</param>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        private void ShowIt(bool showDialog, System.Drawing.Point ptShow, int height, int width, string editText)	// 1.0.003
		{																									// 1.0.003
			this._dialogResult = System.Windows.Forms.DialogResult.None;									// 1.0.001
			this._editAccepted = false;																		// 1.0.001
			this._editText = "";																			// 1.0.001
			this._editTextChanged = false;																	// 1.0.001

			#region Create [this._frmEditBox]
			if( (this._frmEditBox == null)																	// 1.0.001
			|| this._frmEditBox.Disposing																	// 1.0.001
			|| this._frmEditBox.IsDisposed																	// 1.0.001
			|| !this._frmEditBox.Created																	// 1.0.001
			)																								// 1.0.001
			{																								// 1.0.001
				this._frmEditBox = new frmEditBox(												// 1.0.001
					new EditComplete(this.EditComplete)					// 1.0.001
					);																						// 1.0.001
			}																								// 1.0.001
			#endregion 

			if (showDialog)																					// 1.0.003
			{																								// 1.0.003
				this._frmEditBox.ShowDialog(ptShow, height, width, editText);								// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			{																								// 1.0.003
				this._frmEditBox.Show(ptShow, height, width, editText);										// 1.0.001
			}																								// 1.0.003
		}																									// 1.0.003
		#endregion 
	}
    #endregion

    #region Class:  internal class frmEditBox : System.Windows.Forms.Form
    /// <summary>
    /// Class frmEditBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [ToolboxItem(false)]																					// 1.0.001
	internal class frmEditBox : System.Windows.Forms.Form													// 1.0.001
	{                                                                                                       // 1.0.001
        #region Windows Component Designer generated instantiation of components

        /// <summary>
        /// The text edit text box
        /// </summary>
        private System.Windows.Forms.TextBox txtEditTextBox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.txtEditTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtEditTextBox
			// 
			this.txtEditTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEditTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEditTextBox.Location = new System.Drawing.Point(0, 0);
			this.txtEditTextBox.Name = "txtEditTextBox";
			this.txtEditTextBox.TabIndex = 0;
			this.txtEditTextBox.TabStop = false;
			this.txtEditTextBox.Text = "";
			// 
			// EditBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(100, 20);
			this.ControlBox = false;
			this.Controls.Add(this.txtEditTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditBox";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);

		}
        #endregion


        #region Class variables 
        /// <summary>
        /// The is show dialog
        /// </summary>
        private bool _IsShowDialog = false;                                                                 // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// The is show dialog setup
                                                                                                            /// </summary>
        private bool _IsShowDialogSetup = false;                                                            // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Occurs when [on edit complete].
                                                                                                            /// </summary>
        internal event EditComplete OnEditComplete;                                             // 1.0.001
        #endregion

        #region (Form) frmEditBox class constructor (and Dispose), etc
        // internal frmEditBox() 
        //     : this(null, new System.Drawing.Point(0, 0), 20, 100, "")
        // internal frmEditBox(ZeroitAyensuTab.ZeroitAyensuTabEditBox.EditComplete delegate_OnEditComplete) 
        //     : this(delegate_OnEditComplete, null, new System.Drawing.Point(0, 0), 20, 100, "")
        // internal frmEditBox(
        //     ZeroitAyensuTab.ZeroitAyensuTabEditBox.EditComplete delegate_OnEditComplete, 
        //     System.Drawing.Point ptShow, int height, int width, string editText
        // )
        // 
        // protected override void Dispose( bool disposing )
        // 
        // protected override void OnActivated(System.EventArgs e)
        // 
        //internal frmEditBox()																				// 1.0.001
        //	: this(null, new System.Drawing.Point(0, 0), 20, 100, "")										// 1.0.001
        //{																									// 1.0.001
        //}																									// 1.0.001

        /// <summary>
        /// Initializes a new instance of the <see cref="frmEditBox"/> class.
        /// </summary>
        /// <param name="delegate_OnEditComplete">The delegate on edit complete.</param>
        internal frmEditBox(EditComplete delegate_OnEditComplete)								// 1.0.001
			: this(delegate_OnEditComplete, new System.Drawing.Point(0, 0), 20, 100, "")					// 1.0.001
		{																									// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Initializes a new instance of the <see cref="frmEditBox"/> class.
        /// </summary>
        /// <param name="delegate_OnEditComplete">The delegate on edit complete.</param>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        internal frmEditBox(                                                                                // 1.0.001
            EditComplete delegate_OnEditComplete,												// 1.0.001
			System.Drawing.Point ptShow, int height, int width, string editText								// 1.0.001
		)																									// 1.0.001
		{																									// 1.0.001
			//																								// 1.0.001
			// Required for Windows Form Designer support													// 1.0.001
			//																								// 1.0.001
			InitializeComponent();																			// 1.0.001
			//																								// 1.0.001
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.001
			//																								// 1.0.001
			this.DialogResult = System.Windows.Forms.DialogResult.None;										// 1.0.001
			this._editAccepted = false;																		// 1.0.001
			this._editTextChanged = false;																	// 1.0.001

			if (delegate_OnEditComplete != null)															// 1.0.001
			{																								// 1.0.001
				//this.OnEditComplete -= delegate_OnEditComplete;											// 1.0.001
				//this.OnEditComplete += delegate_OnEditComplete;											// 1.0.001
				this.OnEditComplete = delegate_OnEditComplete;												// 1.0.001
			}																								// 1.0.001

			//this.Location = this.PointToScreen(ptShow);													// 1.0.001
			this.Location = ptShow;																			// 1.0.001
			this.Height = height;																			// 1.0.001
			this.Width = width;																				// 1.0.001

			this.EditText = editText;																		// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// // 1.0.001
        /// Clean up any resources being used.																// 1.0.001
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose( bool disposing )													// 1.0.001
		{																									// 1.0.001
			if( disposing )																					// 1.0.001
			{																								// 1.0.001
				if(components != null)																		// 1.0.001
				{																							// 1.0.001
					components.Dispose();																	// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
			base.Dispose( disposing );																		// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// The on activated once
        /// </summary>
        private bool _onActivatedOnce = false;                                                              // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Raises the <see cref="E:System.Windows.Forms.Form.Activated" /> event.
                                                                                                            /// </summary>
                                                                                                            /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(System.EventArgs e)												// 1.0.001
		{																									// 1.0.001
			// This Form's [internal void ShowDialog(...)] method causes the [OnActivated] Event to be fired// 1.0.001
			// twice.  This is because setting [this.Width] and [this.Height] doesn't seem to work when the	// 1.0.001
			// form is not visible -- therefore, [this.ShowDialog(...)] temporarily makes the Form visible	// 1.0.001
			// (at which time [this.Width] and [this.Height] are set) before invoking [base.ShowDialog()]	// 1.0.001
			base.OnActivated(e);																			// 1.0.001

			if (!this._IsShowDialogSetup 																	// 1.0.001
			&& !_onActivatedOnce)																			// 1.0.001
			{																								// 1.0.001
				_onActivatedOnce = true;																	// 1.0.001
				SetEventHandlers(true);																		// 1.0.003

				this.DialogResult = System.Windows.Forms.DialogResult.None;									// 1.0.001
				this._editAccepted = false;																	// 1.0.001
				this._editTextChanged = false;																// 1.0.001

				this.txtEditTextBox.SelectAll();															// 1.0.001
				this.txtEditTextBox.Focus();																// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region EventHandlers (etc) -- Intercept/Process [Keys.Tab] [Keys.Return] and [Keys.Escape]
        // protected override bool ProcessTabKey(bool forward)
        // 
        // private void txtEditTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        // 
        // private void frmEditBox_Click(object sender, System.EventArgs e)
        // private void frmEditBox_Deactivate(object sender, System.EventArgs e)
        // 
        /// <summary>
        /// Processes the tab key.
        /// </summary>
        /// <param name="forward">true to cycle forward through the controls in the <see cref="T:System.Windows.Forms.ContainerControl" />; otherwise, false.</param>
        /// <returns>true if a control is selected; otherwise, false.</returns>
        protected override bool ProcessTabKey(bool forward)													// 1.0.001
		{																									// 1.0.001
			// We can intercept the [Keys.Tab] via this method.												// 1.0.001

			// Done: Accept Edit Action																		// 1.0.001
			this.DialogResult = System.Windows.Forms.DialogResult.OK;										// 1.0.001
			this._editAccepted = true;																		// 1.0.001
			this.Hide();																					// 1.0.001

			//return base.ProcessTabKey(forward);			// One would normally do this					// 1.0.001
			return true;									// But we want to intercept [Keys.Tab]			// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// Handles the KeyPress event of the txtEditTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtEditTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)		// 1.0.001
		{																									// 1.0.001
		//	// The [Keys.Tab] doesn't manage to make it into this method.									// 1.0.001
		//	// If [Keys.Tab], Done: Accept Edit Action														// 1.0.001
		//	if (e.KeyChar == (char)9)		// [Keys.Tab] doesn't make it into the method					// 1.0.001
		//	{																								// 1.0.001
		//		// Done: Accept Edit Action																	// 1.0.001
		//		this.DialogResult = System.Windows.Forms.DialogResult.OK;									// 1.0.001
		//		this._editAccepted = true;																	// 1.0.001
		//		e.Handled = true;																			// 1.0.001
		//		this.Hide();																				// 1.0.001
		//	}																								// 1.0.001
		//	else																							// 1.0.001
			// If [Keys.Return], Done: Accept Edit Action													// 1.0.001
			if (e.KeyChar == (char)13)		// [Keys.Return]												// 1.0.001
			{																								// 1.0.001
				// Done: Accept Edit Action																	// 1.0.001
				this.DialogResult = System.Windows.Forms.DialogResult.OK;									// 1.0.001
				this._editAccepted = true;																	// 1.0.001
				e.Handled = true;																			// 1.0.001
				this.Hide();																				// 1.0.001
			}																								// 1.0.001
			else																							// 1.0.001
			// If [Keys.Escape], Done: Reject Edit Action													// 1.0.001
			if (e.KeyChar == (char)27)		// [Keys.Escape]												// 1.0.001
			{																								// 1.0.001
				// Done: Reject Edit Action																	// 1.0.001
				this.txtEditTextBox.Text = this._editText;													// 1.0.001
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;								// 1.0.001
				this._editAccepted = false;																	// 1.0.001
				//e.Handled = true;																			// 1.0.001
				e.Handled = false;																			// 1.0.001
				this.Hide();																				// 1.0.001
			}																								// 1.0.001
			else																							// 1.0.001
			{																								// 1.0.001
				this._editTextChanged = true;																// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001


        /// <summary>
        /// Handles the Click event of the frmEditBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmEditBox_Click(object sender, System.EventArgs e)									// 1.0.003
		{																									// 1.0.003
			if (this._IsShowDialog)																			// 1.0.003
			{																								// 1.0.003
				#region Play a "beep" sound
				// Reference: Microsoft.VisualBasic.DLL														// 1.0.003
				//   (eg: C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\Microsoft.VisualBasic.dll)			// 1.0.003
				Microsoft.VisualBasic.Interaction.Beep();													// 1.0.003
				#endregion 
			}																								// 1.0.003
			else																							// 1.0.003
			{																								// 1.0.003
				// Done: Not-Accept Edit Action																// 1.0.003
				this.DialogResult = System.Windows.Forms.DialogResult.None;									// 1.0.003
				this._editAccepted = false;																	// 1.0.003
				this.Hide();								// Trigger [this.frmEditBox_Deactivate()]		// 1.0.003
			}																								// 1.0.003
		}                                                                                                   // 1.0.003

        /// <summary>
        /// Handles the Deactivate event of the frmEditBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void frmEditBox_Deactivate(object sender, System.EventArgs e)								// 1.0.001
		{																									// 1.0.001
			#region (Conditionally) Play a "beep" sound
			if( (this.DialogResult != System.Windows.Forms.DialogResult.Cancel)	// Already did a sound		// 1.0.003
			&& (this.DialogResult != System.Windows.Forms.DialogResult.OK) )	// No sound needed			// 1.0.003
			{																								// 1.0.003
				// Reference: Microsoft.VisualBasic.DLL														// 1.0.003
				//   (eg: C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\Microsoft.VisualBasic.dll)			// 1.0.003
				Microsoft.VisualBasic.Interaction.Beep();													// 1.0.003
			}																								// 1.0.003
			#endregion 

			// If [this._IsShowDialog] - Event [this.OnDeactivate] doesn't raise [this.OnEditComplete()]	// 1.0.001
			//   unless either [this.DialogResult != System.Windows.Forms.DialogResult.Cancel]				// 1.0.001
			//   or [this.DialogResult != System.Windows.Forms.DialogResult.OK]								// 1.0.001
			// If [!this._IsShowDialog] - Event [this.OnDeactivate] raises [this.OnEditComplete()]			// 1.0.001
			// If [!this._IsShowDialogSetup] - Don't raise [this.OnEditComplete()] during setup				// 1.0.001
			if( (this._IsShowDialog							// [this.ShowDialog()] else [this.Show()]		// 1.0.001
				&& (this.DialogResult != System.Windows.Forms.DialogResult.Cancel)							// 1.0.001
				&& (this.DialogResult != System.Windows.Forms.DialogResult.OK)								// 1.0.001
				)																							// 1.0.001
			|| this._IsShowDialogSetup)						// Still doing [this.ShowDialog()] setup?		// 1.0.001
			{																								// 1.0.001
				return;																						// 1.0.001
			}																								// 1.0.001

			// One way or another, we're done here:															// 1.0.001
			//   Hide the [AyensuEditBox..frmEditBox] and notify the parent [AyensuEditBox..AyensuEditBox.]				// 1.0.001
			this.Hide();																					// 1.0.001

			this.EditText = this.txtEditTextBox.Text.Trim();												// 1.0.001
			if (this.OnEditComplete != null)																// 1.0.001
			{																								// 1.0.001
				this.OnEditComplete(																		// 1.0.001
					this,																					// 1.0.001
					new EditEventArgs(this.DialogResult, this._editAccepted, this._editText, this._editTextChanged)	// 1.0.001
					);																						// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region Internal Properties
        // internal bool EditAccepted {get} {set}
        // internal string EditText {get} {set}
        // internal bool EditTextChanged {get} {set}
        // 
        /// <summary>
        /// The edit accepted
        /// </summary>
        internal bool _editAccepted = false;                                                                // 1.0.001
                                                                                                            //internal bool EditAccepted																		// 1.0.001
                                                                                                            //{																									// 1.0.001
                                                                                                            //	get {return this._editAccepted;}																// 1.0.001
                                                                                                            //}																									// 1.0.001

        /// <summary>
        /// The edit text
        /// </summary>
        internal string _editText = "";                                                                     // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// Sets the edit text.
                                                                                                            /// </summary>
                                                                                                            /// <value>The edit text.</value>
        internal string EditText																			// 1.0.001
		{																									// 1.0.001
			//get {return this._editText;}																	// 1.0.001
			set																								// 1.0.001
			{																								// 1.0.001
				this._editText = value.Trim();																// 1.0.001
				this.txtEditTextBox.Text = this._editText;													// 1.0.001
			}																								// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// The edit text changed
        /// </summary>
        internal bool _editTextChanged = false;                                                             // 1.0.001
                                                                                                            //internal bool EditTextChanged																		// 1.0.001
                                                                                                            //{																									// 1.0.001
                                                                                                            //	get {return this._editTextChanged;}																// 1.0.001
                                                                                                            //}																									// 1.0.001
        #endregion

        #region Internal Methods -- [.Show(...)] and [.ShowDialog(...)]
        // internal void Show(System.Drawing.Point ptShow, int height, int width, string editText)
        // internal void ShowDialog(System.Drawing.Point ptShow, int height, int width, string editText)
        // 
        /// <summary>
        /// Shows the specified pt show.
        /// </summary>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        internal void Show(System.Drawing.Point ptShow, int height, int width, string editText)				// 1.0.001
		{																									// 1.0.001
			this._IsShowDialog = false;																		// 1.0.001
			this._IsShowDialogSetup = false;																// 1.0.001
			SetEventHandlers(false);																		// 1.0.003

			this.EditText = editText;																		// 1.0.001
			this.DialogResult = System.Windows.Forms.DialogResult.None;										// 1.0.001
			this._editAccepted = false;																		// 1.0.001
			this._editTextChanged = false;																	// 1.0.001

			_onActivatedOnce = false;						// Allow one-time code in [OnActivated()]		// 1.0.001
			base.Show();																					// 1.0.001
			this.Location = ptShow;																			// 1.0.001
			this.Height = height;																			// 1.0.001
			this.Width = width;																				// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="editText">The edit text.</param>
        internal void ShowDialog(System.Drawing.Point ptShow, int height, int width, string editText)		// 1.0.001
		{																									// 1.0.001
			this._IsShowDialog = true;																		// 1.0.001
			this._IsShowDialogSetup = true;																	// 1.0.001
			SetEventHandlers(false);																		// 1.0.003

			this.EditText = editText;																		// 1.0.001
			this.DialogResult = System.Windows.Forms.DialogResult.None;										// 1.0.001
			this._editAccepted = false;																		// 1.0.001
			this._editTextChanged = false;																	// 1.0.001

			_onActivatedOnce = true;						// DISAllow one-time code in [OnActivated()]	// 1.0.001
			//base.Show();			// We do this so [this.Width = width;] [this.Width = width;] will work	// 1.0.001
			this.Visible = true;	// We do this so [this.Width = width;] [this.Width = width;] will work	// 1.0.001
			this.Location = ptShow;																			// 1.0.001
			this.Height = height;																			// 1.0.001
			this.Width = width;																				// 1.0.001
			this.Visible = false;							// We didn't mean [this.Visible = true;]		// 1.0.001

			this._IsShowDialogSetup = false;																// 1.0.001
			_onActivatedOnce = false;						// Allow one-time code in [OnActivated()]		// 1.0.001
			base.ShowDialog();																				// 1.0.001
		}                                                                                                   // 1.0.001
        #endregion

        #region Private Methods
        // private void SetEventHandlers(bool setHandlers)
        // 
        /// <summary>
        /// Sets the event handlers.
        /// </summary>
        /// <param name="setHandlers">if set to <c>true</c> [set handlers].</param>
        private void SetEventHandlers(bool setHandlers)														// 1.0.003
		{																									// 1.0.003
			#region "Unset" the EventHandlers -- Ensure they are attached only one time
			//this.Leave -= new System.EventHandler(this.frmEditBox_Deactivate);							// 1.0.003
			this.Deactivate -= new System.EventHandler(this.frmEditBox_Deactivate);							// 1.0.003
			this.Click -= new System.EventHandler(this.frmEditBox_Click);									// 1.0.003

			this.txtEditTextBox.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtEditTextBox_KeyPress);	// 1.0.001
			#endregion 
			if (setHandlers)																				// 1.0.003
			{																								// 1.0.003
				//this.Leave += new System.EventHandler(this.frmEditBox_Deactivate);						// 1.0.001
				this.Deactivate += new System.EventHandler(this.frmEditBox_Deactivate);						// 1.0.001
				this.Click += new System.EventHandler(this.frmEditBox_Click);								// 1.0.003

				this.txtEditTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditTextBox_KeyPress);	// 1.0.001
			}																								// 1.0.003
		}																									// 1.0.003
		#endregion
	}                                                                                                       // 1.0.001
    #endregion

    #region Define EventHandler Delegates for Class/Form 

    // Enable the [AyensuEditBox..AyensuEditBox.] instance to notify the "parent class" of the [EditComplete] event	// 1.0.001
    /// <summary>
    /// Delegate EditComplete
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="editArgs">The <see cref="EditEventArgs"/> instance containing the event data.</param>
    public delegate void EditComplete(object sender, EditEventArgs editArgs);   // 1.0.001

    #endregion

    #region Class:  EditEventArgs : System.EventArgs
    /// <summary>
    /// Class EditEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class EditEventArgs : System.EventArgs															// 1.0.001
	{                                                                                                       // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// The dialog result
                                                                                                            /// </summary>
        private System.Windows.Forms.DialogResult _dialogResult = System.Windows.Forms.DialogResult.None;   // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// The edit accepted
                                                                                                            /// </summary>
        private bool _editAccepted = false;                                                                 // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// The edit text
                                                                                                            /// </summary>
        private string _editText = "";                                                                      // 1.0.001
                                                                                                            /// <summary>
                                                                                                            /// The edit text changed
                                                                                                            /// </summary>
        private bool _editTextChanged = false;                                                              // 1.0.001

        /// <summary>
        /// Initializes a new instance of the <see cref="EditEventArgs"/> class.
        /// </summary>
        /// <param name="dialogResult">The dialog result.</param>
        /// <param name="editAccepted">if set to <c>true</c> [edit accepted].</param>
        /// <param name="editText">The edit text.</param>
        /// <param name="editTextChanged">if set to <c>true</c> [edit text changed].</param>
        public EditEventArgs(																				// 1.0.001
			System.Windows.Forms.DialogResult dialogResult,													// 1.0.001
			bool editAccepted, string editText, bool editTextChanged										// 1.0.001
		)																									// 1.0.001
		{																									// 1.0.001
			this._dialogResult = dialogResult;																// 1.0.001
			this._editAccepted = editAccepted;																// 1.0.001
			this._editText = editText;																		// 1.0.001
			this._editTextChanged = editTextChanged;														// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Gets the dialog result.
        /// </summary>
        /// <value>The dialog result.</value>
        public System.Windows.Forms.DialogResult DialogResult												// 1.0.001
		{																									// 1.0.001
			get {return this._dialogResult;}																// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Gets a value indicating whether [edit accepted].
        /// </summary>
        /// <value><c>true</c> if [edit accepted]; otherwise, <c>false</c>.</value>
        public bool EditAccepted																			// 1.0.001
		{																									// 1.0.001
			get {return this._editAccepted;}																// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Gets the edit text.
        /// </summary>
        /// <value>The edit text.</value>
        public string EditText																				// 1.0.001
		{																									// 1.0.001
			get {return this._editText;}																	// 1.0.001
		}                                                                                                   // 1.0.001

        /// <summary>
        /// Gets a value indicating whether [edit text changed].
        /// </summary>
        /// <value><c>true</c> if [edit text changed]; otherwise, <c>false</c>.</value>
        public bool EditTextChanged																			// 1.0.001
		{																									// 1.0.001
			get {return this._editTextChanged;}																// 1.0.001
		}																									// 1.0.001
	}																										// 1.0.001
	#endregion 
}																											// 1.0.001
