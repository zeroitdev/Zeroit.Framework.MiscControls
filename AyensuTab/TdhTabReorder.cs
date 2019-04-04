// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TdhTabReorder.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs																				
{
    /// <summary>
    /// Summary description for ZeroitAyensuTabReorder.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [System.ComponentModel.ToolboxItem(false)]																
	internal class ZeroitAyensuTabReorder : System.Windows.Forms.Form												
	{
        #region Windows Component Designer generated instantiation of components
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The track bar move to
        /// </summary>
        private System.Windows.Forms.TrackBar trackBarMoveTo;
        /// <summary>
        /// The text move to
        /// </summary>
        private System.Windows.Forms.TextBox txtMoveTo;
        /// <summary>
        /// The BTN reorder left full
        /// </summary>
        private System.Windows.Forms.Button btnReorder_LeftFull;
        /// <summary>
        /// The BTN reorder left
        /// </summary>
        private System.Windows.Forms.Button btnReorder_Left;
        /// <summary>
        /// The BTN reorder right
        /// </summary>
        private System.Windows.Forms.Button btnReorder_Right;
        /// <summary>
        /// The BTN reorder right full
        /// </summary>
        private System.Windows.Forms.Button btnReorder_RightFull;
        /// <summary>
        /// The PNL reorder controls
        /// </summary>
        private System.Windows.Forms.Panel pnlReorderControls;
        /// <summary>
        /// The PNL tab images
        /// </summary>
        private System.Windows.Forms.Panel pnlTabImages;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private System.Windows.Forms.Button btnOK;
        /// <summary>
        /// The tool tip1
        /// </summary>
        private System.Windows.Forms.ToolTip toolTip1;

        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ZeroitAyensuTabReorder));
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlReorderControls = new System.Windows.Forms.Panel();
			this.trackBarMoveTo = new System.Windows.Forms.TrackBar();
			this.btnReorder_RightFull = new System.Windows.Forms.Button();
			this.btnReorder_Right = new System.Windows.Forms.Button();
			this.btnReorder_Left = new System.Windows.Forms.Button();
			this.btnReorder_LeftFull = new System.Windows.Forms.Button();
			this.txtMoveTo = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlTabImages = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnlReorderControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarMoveTo)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = Properties.Resources.Cross16;/* ((System.Drawing.Bitmap)(resources.GetObject("btnCancel.Image")));*/
			this.btnCancel.Location = new System.Drawing.Point(324, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(24, 24);
			this.btnCancel.TabIndex = 1;
			this.toolTip1.SetToolTip(this.btnCancel, "Reject all TabPage reordering");
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlReorderControls
			// 
			this.pnlReorderControls.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlReorderControls.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.trackBarMoveTo,
																							 this.btnReorder_RightFull,
																							 this.btnReorder_Right,
																							 this.btnReorder_Left,
																							 this.btnReorder_LeftFull,
																							 this.txtMoveTo,
																							 this.btnOK,
																							 this.btnCancel});
			this.pnlReorderControls.Location = new System.Drawing.Point(0, 28);
			this.pnlReorderControls.Name = "pnlReorderControls";
			this.pnlReorderControls.Size = new System.Drawing.Size(350, 32);
			this.pnlReorderControls.TabIndex = 0;
			this.pnlReorderControls.TabStop = true;
			// 
			// trackBarMoveTo
			// 
			this.trackBarMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trackBarMoveTo.Location = new System.Drawing.Point(82, -2);
			this.trackBarMoveTo.Name = "trackBarMoveTo";
			this.trackBarMoveTo.Size = new System.Drawing.Size(93, 45);
			this.trackBarMoveTo.TabIndex = 10;
			this.toolTip1.SetToolTip(this.trackBarMoveTo, "Move selected TabPage to the given position");
			this.trackBarMoveTo.Scroll += new System.EventHandler(this.trackBarMoveTo_Scroll);
			// 
			// btnReorder_RightFull
			// 
			this.btnReorder_RightFull.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnReorder_RightFull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_RightFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_RightFull.Location = new System.Drawing.Point(258, 0);
			this.btnReorder_RightFull.Name = "btnReorder_RightFull";
			this.btnReorder_RightFull.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_RightFull.TabIndex = 4;
			this.btnReorder_RightFull.Text = ">>|";
			this.toolTip1.SetToolTip(this.btnReorder_RightFull, "Move selected TabPage to End");
			this.btnReorder_RightFull.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_Right
			// 
			this.btnReorder_Right.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnReorder_Right.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_Right.Location = new System.Drawing.Point(217, 0);
			this.btnReorder_Right.Name = "btnReorder_Right";
			this.btnReorder_Right.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_Right.TabIndex = 3;
			this.btnReorder_Right.Text = ">";
			this.toolTip1.SetToolTip(this.btnReorder_Right, "Move selected TabPage one position to the right");
			this.btnReorder_Right.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_Left
			// 
			this.btnReorder_Left.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_Left.Location = new System.Drawing.Point(41, 0);
			this.btnReorder_Left.Name = "btnReorder_Left";
			this.btnReorder_Left.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_Left.TabIndex = 2;
			this.btnReorder_Left.Text = "<";
			this.toolTip1.SetToolTip(this.btnReorder_Left, "Move selected TabPage one position to the left");
			this.btnReorder_Left.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_LeftFull
			// 
			this.btnReorder_LeftFull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_LeftFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_LeftFull.Name = "btnReorder_LeftFull";
			this.btnReorder_LeftFull.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_LeftFull.TabIndex = 1;
			this.btnReorder_LeftFull.Text = "|<<";
			this.toolTip1.SetToolTip(this.btnReorder_LeftFull, "Move selected TabPage to Start");
			this.btnReorder_LeftFull.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// txtMoveTo
			// 
			this.txtMoveTo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtMoveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMoveTo.Location = new System.Drawing.Point(176, 0);
			this.txtMoveTo.MaxLength = 5;
			this.txtMoveTo.Name = "txtMoveTo";
			this.txtMoveTo.Size = new System.Drawing.Size(40, 20);
			this.txtMoveTo.TabIndex = 11;
			this.txtMoveTo.Text = "";
			this.txtMoveTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.txtMoveTo, "Move selected TabPage to the given position");
			this.txtMoveTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMoveTo_MouseDown);
			this.txtMoveTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveTo_KeyPress);
			this.txtMoveTo.Leave += new System.EventHandler(this.txtMoveTo_Leave);
			this.txtMoveTo.Enter += new System.EventHandler(this.txtMoveTo_Enter);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = Properties.Resources.Check16;/* ((System.Drawing.Bitmap)(resources.GetObject("btnOK.Image")));*/
			this.btnOK.Location = new System.Drawing.Point(299, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(24, 24);
			this.btnOK.TabIndex = 0;
			this.toolTip1.SetToolTip(this.btnOK, "Accept TabPage current reordering");
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// pnlTabImages
			// 
			this.pnlTabImages.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlTabImages.AutoScroll = true;
			this.pnlTabImages.Name = "pnlTabImages";
			this.pnlTabImages.Size = new System.Drawing.Size(350, 28);
			this.pnlTabImages.TabIndex = 10;
			// 
			// ZeroitAyensuTabReorder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(348, 58);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlReorderControls,
																		  this.pnlTabImages});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ZeroitAyensuTabReorder";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.pnlReorderControls.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBarMoveTo)).EndInit();
			this.ResumeLayout(false);

		}
        #endregion


        #region Class variables 
        /// <summary>
        /// The tab control
        /// </summary>
        private ZeroitAyensuTab _theTabCtl = null;
        /// <summary>
        /// The al tab images
        /// </summary>
        System.Collections.ArrayList _alTabImages = new System.Collections.ArrayList();
        /// <summary>
        /// The al tab pointers
        /// </summary>
        System.Collections.ArrayList _alTabPointers = new System.Collections.ArrayList();
        /// <summary>
        /// The index PBX active
        /// </summary>
        private int _idxPbxActive = -1;

        /// <summary>
        /// The text move to text at enter
        /// </summary>
        private string _txtMoveTo_TextAtEnter = "";
        /// <summary>
        /// The text move to regex filter
        /// </summary>
        private string _txtMoveTo_regexFilter = @"^\d+$";
        /// <summary>
        /// The regex filter
        /// </summary>
        private System.Text.RegularExpressions.Regex _regexFilter = null;
        #endregion

        #region (Form) ZeroitAyensuTabReorder class constructor (and Dispose), etc
        // public ZeroitAyensuTabReorder(
        //     ZeroitAyensuTab.ZeroitAyensuTab theTabCtl, int activeTabPage_Idx, 
        //     System.Drawing.Point ptShow, int height, int width 
        // )
        // 
        // protected override void Dispose( bool disposing )
        // 
        // protected override void OnActivated(System.EventArgs e)
        // 
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAyensuTabReorder"/> class.
        /// </summary>
        /// <param name="theTabCtl">The tab control.</param>
        /// <param name="activeTabPage_Idx">Index of the active tab page.</param>
        /// <param name="ptShow">The pt show.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        public ZeroitAyensuTabReorder(																				
			ZeroitAyensuTab theTabCtl, int activeTabPage_Idx,											
			System.Drawing.Point ptShow, int height, int width												
		)																									
		{																									
			//																								
			// Required for Windows Form Designer support													
			//																								
			InitializeComponent();																			
			//																								
			// TODO: Add any constructor code after InitializeComponent call								
			//																								
			this.DialogResult = System.Windows.Forms.DialogResult.None;										

			//this.Location = this.PointToScreen(ptShow);													
			this.Location = ptShow;																			

			this.ClientSize = new System.Drawing.Size(348, 58);												// 1.0.004
			if (height >= 60)																				
			{																								
				this.Height = height;																		
			}																								
			if (width >= 350)																				// 1.0.004
			{																								
				this.Width = width;																			
			}																								

			this._idxPbxActive = activeTabPage_Idx;															
			this._theTabCtl = theTabCtl;																	
			trackBarMoveTo_SetProperties(this._theTabCtl.TabCount);											

			pbxWork_X_Build(activeTabPage_Idx);																
			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												
			this.trackBarMoveTo.Focus();																	
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


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(System.EventArgs e)												// 1.0.001
		{																									// 1.0.001
			base.OnActivated(e);																			// 1.0.001

			this.DialogResult = System.Windows.Forms.DialogResult.None;										

			//this.pnlTabImages.Controls[this._idxPbxActive].Select();										
			this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);		

			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												
			this.trackBarMoveTo.Focus();																	
		}
        #endregion

        #region Navigation EventHandlers (and related Methods) -- for [trackBarMoveTo] and [txtMoveTo]
        // private void trackBarMoveTo_Scroll(object sender, System.EventArgs e)
        // private int trackBarMoveTo_SetValue(int setValue)
        // private void trackBarMoveTo_SetProperties(int nbrTabPages)
        // 
        // private void txtMoveTo_Enter(object sender, System.EventArgs e)
        // private void txtMoveTo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        // private void txtMoveTo_Leave(object sender, System.EventArgs e)
        // private void txtMoveTo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        // 
        /// <summary>
        /// Handles the Scroll event of the trackBarMoveTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void trackBarMoveTo_Scroll(object sender, System.EventArgs e)								
		{																									
			Reorder_Work(trackBarMoveTo.Value.ToString());													// 1.0.004
		}

        /// <summary>
        /// Tracks the bar move to set value.
        /// </summary>
        /// <param name="setValue">The set value.</param>
        /// <returns>System.Int32.</returns>
        private int trackBarMoveTo_SetValue(int setValue)													// 1.0.004
		{																									
			if (setValue <= 0)																				
			{																								
				trackBarMoveTo.Value = 1;																	
			}																								
			else																							
			if (setValue >= trackBarMoveTo.Maximum)															
			{																								
				trackBarMoveTo.Value = trackBarMoveTo.Maximum;												
			}																								
			else																							
			{																								
				trackBarMoveTo.Value = setValue;															
			}																								
			txtMoveTo.Text = trackBarMoveTo.Value.ToString();												

			return trackBarMoveTo.Value;																	// 1.0.004
		}

        /// <summary>
        /// Tracks the bar move to set properties.
        /// </summary>
        /// <param name="nbrTabPages">The NBR tab pages.</param>
        private void trackBarMoveTo_SetProperties(int nbrTabPages)											
		{																									
			this.trackBarMoveTo.Minimum = 1;																
			this.trackBarMoveTo.Maximum = System.Math.Max(1, nbrTabPages);									

			if (this.trackBarMoveTo.Maximum <= 40)															
			{																								
				this.trackBarMoveTo.LargeChange = System.Math.Max(1, (int)(this.trackBarMoveTo.Maximum / 10));	
				if (this.trackBarMoveTo.Maximum <= 25)														
				{																							
					this.trackBarMoveTo.TickFrequency = 1;													
				}																							
				else																						
				{																							
					this.trackBarMoveTo.TickFrequency = 2;													
				}																							
			}																								
			else																							
			{																								
				this.trackBarMoveTo.LargeChange = System.Math.Max(1, (int)(this.trackBarMoveTo.Maximum / 15));	
				this.trackBarMoveTo.TickFrequency = 5;														
			}																								
			this.trackBarMoveTo.SmallChange = 1;															
		}


        /// <summary>
        /// Handles the Enter event of the txtMoveTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtMoveTo_Enter(object sender, System.EventArgs e)										
		{																									
			if (this._txtMoveTo_TextAtEnter.Length <= 0)													// 1.0.004
			{																								// 1.0.004
				this._txtMoveTo_TextAtEnter = this.txtMoveTo.Text;											
				if (this.txtMoveTo.SelectionLength <= 0)													
				{																							
					this.txtMoveTo.SelectAll();																
				}																							
			}																								// 1.0.004
		}

        /// <summary>
        /// Handles the KeyPress event of the txtMoveTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtMoveTo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)			
		{																									
			#region Done: If [Keys.Escape] Or [Keys.Return]
			// If [Keys.Escape] restore [this.txtMoveTo.Text]												
			if (e.KeyChar == (char)27)		// Keys.Escape													
			{																								
				this.txtMoveTo.Text = this._txtMoveTo_TextAtEnter;											
				this.txtMoveTo.SelectAll();																	
				e.Handled = true;																			
				return;																						
			}																								

			// If [Keys.Return] use value of [this.txtMoveTo.Text] at NewLocation for TabPage				
			if (e.KeyChar == (char)13)		// Keys.Return													
			{																								
				e.Handled = true;																			
				Reorder_Work(this.txtMoveTo.Text);															// 1.0.004
				return;																						
			}																								
			#endregion 

			string _KeyChar = e.KeyChar.ToString();															

			// If the typed character is a backspace, then do not bother matching.							
			if (_KeyChar == "\b")																			
			{																								
				return;																						
			}																								

			// Create a string to represent what the text will be if the input is successful,				
			// so that we can test it to see if it is valid.												
			string inputText = this.txtMoveTo.Text;															
			// If some text is selected, then remove the selected text. We are replacing it.				
			if (this.txtMoveTo.SelectionLength > 0)															
			{																								
				inputText = inputText.Remove(this.txtMoveTo.SelectionStart, this.txtMoveTo.SelectionLength);
			}																								
			// Add the typed character after the cursor.													
			inputText = inputText.Insert(this.txtMoveTo.SelectionStart, _KeyChar);							

			if (this._regexFilter == null)																	
			{																								
				// Set up a regular expression class with [_txtMoveTo_TextAtEnter] as the regular expression.
				this._regexFilter = new System.Text.RegularExpressions.Regex(this._txtMoveTo_regexFilter);	
			}																								
			// If the current text, plus the typed character, does not fit into the regular expression,		
			// then set handled to true (thus, the typed character is rejected).							
			if (!this._regexFilter.IsMatch(inputText))														
			//if (!this._regexFilter.IsMatch(_KeyChar))	// Validate only the individual typed character		
			{																								
				e.Handled = true;																			
			}																								
		}

        /// <summary>
        /// Handles the Leave event of the txtMoveTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtMoveTo_Leave(object sender, System.EventArgs e)										
		{																									
			//this._txtMoveTo_TextAtEnter = "";																// 1.0.004
			Reorder_Work(this.txtMoveTo.Text);																// 1.0.004
		}

        /// <summary>
        /// Handles the MouseDown event of the txtMoveTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void txtMoveTo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)				
		{																									
			txtMoveTo_Enter(sender, System.EventArgs.Empty);
		}
        #endregion

        #region EventHandlers 
        // private void btnCancel_Click(object sender, System.EventArgs e)
        // private void btnOK_Click(object sender, System.EventArgs e)
        // 
        // private void pbxWork_X_Click(object sender, System.EventArgs e)
        // 
        // private void btnReorder_X_Click(object sender, System.EventArgs e)
        // 
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, System.EventArgs e)										
		{																									
			// Done: Reject Edit Action																		
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;									
			this.Hide();																					
		}

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, System.EventArgs e)											
		{																									
			// Done: Accept Edit Action																		
			this.DialogResult = System.Windows.Forms.DialogResult.OK;										
			this.Hide();																					
		}


        /// <summary>
        /// Handles the Click event of the pbxWork_X control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void pbxWork_X_Click(object sender, System.EventArgs e)										
		{																									
			int idxPbxDeactive = this._idxPbxActive;						// idx to old active PictureBox	
			System.Windows.Forms.PictureBox pbxDeactive = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[idxPbxDeactive];	
			int idxTabDeactive = (int)this._alTabPointers[idxPbxDeactive];	// Pointer to actual TabPage	
			System.Drawing.Bitmap imgDeactive = Create_TabPageImage(idxTabDeactive, false);	// Get TabImage	
			_alTabImages[idxPbxDeactive] = imgDeactive;						// Replace TabImage in ArrayList
			pbxDeactive.Image = imgDeactive;								// Assign TabImage to PictureBox

			System.Windows.Forms.PictureBox pbxActive = (System.Windows.Forms.PictureBox)sender;			
			int idxPbxActive = pbxActive.TabIndex;							// idx to new active PictureBox	
			int idxTabActive = (int)this._alTabPointers[idxPbxActive];		// Pointer to actual TabPage	
			System.Drawing.Bitmap imgActive = Create_TabPageImage(idxTabActive, true);		// Get TabImage	
			_alTabImages[idxPbxActive] = imgActive;							// Replace TabImage in ArrayList
			pbxActive.Image = imgActive;									// Assign TabImage to PictureBox

			this._idxPbxActive = idxPbxActive;				// Keep idx to this new active PictureBox		
			//pbxWork_X_Assignments();						// Not necessary here (it's effectively done)	
			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												
			this.trackBarMoveTo.Focus();																	
		}


        /// <summary>
        /// Handles the Click event of the btnReorder_X control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReorder_X_Click(object sender, System.EventArgs e)									
		{																									
			#region Validate Pointer to current active selection
			// This particular situation should never occur													
			if (!ActivePointerIsValid())																	
			{																								
				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.004
				this.txtMoveTo.Focus();																		// 1.0.004
				//this.trackBarMoveTo.Focus();																// 1.0.004
				return;																						
			}																								
			#endregion 

			#region Build old/current and new position pointers
			int idxOldPosition = this._idxPbxActive;	// Pointer to current active selection, or index to	
			int idxNewPosition = -1;					//   [this._alTabPointers] and [this._alTabImages]	
			System.Windows.Forms.Button btnSender = (System.Windows.Forms.Button)sender;					
			if (btnSender == btnReorder_LeftFull)															
			{																								
				idxNewPosition = 0;																			
			}																								
			else																							
			if (btnSender == btnReorder_Left)																
			{																								
				idxNewPosition = idxOldPosition - 1;														
			}																								
			else																							
			if (btnSender == btnReorder_Right)																
			{																								
				idxNewPosition = idxOldPosition + 1;														
			}																								
			else																							
			if (btnSender == btnReorder_RightFull)															
			{																								
				idxNewPosition = this._alTabPointers.Count;													
			}																								
			#endregion 
			Reorder_Work(idxOldPosition, idxNewPosition);													// 1.0.004
		}
        #endregion

        #region Private Functions/Methods
        // private bool ActivePointerIsValid()
        // 
        // private System.Drawing.Bitmap Create_TabPageImage(int idxTabPage, bool asActive)
        // 
        // private void pbxWork_X_Assignments()
        // private void pbxWork_X_Build(int activeTabPage_Idx)
        // 
        // private void Reorder_Work(string parmMoveTo)
        // private void Reorder_Work(int idxOldPosition, int idxNewPosition)
        // 
        /// <summary>
        /// Actives the pointer is valid.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ActivePointerIsValid()																	
		{																									
			// Validate Pointer to current active selection													
			// This particular situation should never occur													
			if ((this._idxPbxActive < 0) || (this._idxPbxActive >= this._alTabPointers.Count))				
			{																								
				this._idxPbxActive = 0;						// It's bad; Reset it							
				pbxWork_X_Build(0);							// Rebuild everything							

				//this.pnlTabImages.Controls[this._idxPbxActive].Select();									
				this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);	

				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											
				this.trackBarMoveTo.Focus();																

				return false;																				
			}																								
			return true;																					
		}


        /// <summary>
        /// Creates the tab page image.
        /// </summary>
        /// <param name="idxTabPage">The index tab page.</param>
        /// <param name="asActive">if set to <c>true</c> [as active].</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        private System.Drawing.Bitmap Create_TabPageImage(int idxTabPage, bool asActive)					
		{																									
			// Create TabPage images																		
			#region Create/Set working variables 
			System.Drawing.Point ptMouse = new System.Drawing.Point(0, 0);	// mouse pseudo-location		

			System.Drawing.RectangleF tabRectDraw = this._theTabCtl.TabRect_ByIdx(idxTabPage);				
			System.Drawing.Bitmap bmImage = new System.Drawing.Bitmap(										
				(int)tabRectDraw.Width, (int)tabRectDraw.Height,											
				System.Drawing.Imaging.PixelFormat.Format32bppRgb);											
			System.Drawing.RectangleF rectImage = new System.Drawing.RectangleF(0f, 0f, tabRectDraw.Width, tabRectDraw.Height);	

			System.Drawing.Graphics gfxImage = System.Drawing.Graphics.FromImage(bmImage);					
			gfxImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;						
			#endregion  
			ZeroitAyensuTab.TabRect_DrawTabRect(														
				this._theTabCtl, ptMouse,																	
				this._theTabCtl.ZeroitAyensuTabPages[true, idxTabPage],												// 1.0.010
				idxTabPage, asActive,																		
				gfxImage, rectImage																			
			);																								
			gfxImage.Dispose();																				

			return bmImage;																					
		}


        /// <summary>
        /// PBXs the work x assignments.
        /// </summary>
        private void pbxWork_X_Assignments()																
		{																									
			// Set [pbxWork.Image] and [pbxWork.Size] and [pbxWork.Location]								
			this.pnlTabImages.SuspendLayout();																
			// Setting [pnlTabImages.AutoScrollPosition] allows setting proper relative [pbxWork.Location]	
			this.pnlTabImages.AutoScrollPosition = new System.Drawing.Point(0, 0);							
			int locOffset = 1;																				
			for (int idx = 0; idx < this._alTabImages.Count; idx++)											
			{																								
				System.Drawing.Bitmap bmpWork = (System.Drawing.Bitmap)_alTabImages[idx];					

				System.Windows.Forms.PictureBox pbxWork = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[idx];	
				pbxWork.Image = bmpWork;																	
				pbxWork.Size = new System.Drawing.Size(bmpWork.Width, bmpWork.Height);						
				pbxWork.Location = new System.Drawing.Point(locOffset, 0);									

				locOffset += pbxWork.Width + 1;																
			}																								
			this.pnlTabImages.ResumeLayout(false);															
			//this.pnlTabImages.Invalidate();																
		}

        /// <summary>
        /// PBXs the work x build.
        /// </summary>
        /// <param name="activeTabPage_Idx">Index of the active tab page.</param>
        private void pbxWork_X_Build(int activeTabPage_Idx)													
		{																									
			this._idxPbxActive = activeTabPage_Idx;															

			#region Create TabPage Images; Store in ArrayList [_alTabImages.Add(image)]; 
			// Create TabPage images; Create PictureBox controls to display TabPage images					
			this._alTabImages = new System.Collections.ArrayList(this._theTabCtl.TabCount);					
			this._alTabPointers = new System.Collections.ArrayList(this._theTabCtl.TabCount);				

			this.pnlTabImages.Controls.Clear();																
			this.pnlTabImages.SuspendLayout();																
			for (int idx = 0; idx < this._theTabCtl.TabCount; idx++)										
			{																								
				#region Create TabPage image; Store in ArrayList [_alTabImages.Add(image);]
				bool asActive = false;																		
				if (idx == this._idxPbxActive)				// Show this as the active TabPage?				
				{																							
					asActive = true;																		
				}																							
				// Create the TabPage image; Store in ArrayList [_alTabImages.Add(image);]					
				this._alTabImages.Add(this.Create_TabPageImage(idx, asActive));								// 1.0.010
				this._alTabPointers.Add(idx);	// Index of current TabPage order (reordering will change this)	
				#endregion 

				#region Create PictureBox controls to display TabPage images [this.pnlTabImages.Controls.Add(pbxWork);]
				System.Windows.Forms.PictureBox pbxWork = new System.Windows.Forms.PictureBox();			
				pbxWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;							
				pbxWork.Name = "pbxWork_"+ idx.ToString();													
				pbxWork.TabIndex = idx;		// Index to original TabPage order (this will not change)		
				pbxWork.Tag = idx;																			
				pbxWork.TabStop = false;																	
				pbxWork.Click += new System.EventHandler(this.pbxWork_X_Click);								

				this.pnlTabImages.Controls.Add(pbxWork);													
				#endregion 
			}																								
			this.pnlTabImages.ResumeLayout(false);															
			#endregion 
			#region Assign TabPage Images to PictureBoxes in [this.pnlTabImages]
			// Set [pbxWork.Image] and [pbxWork.Size] and [pbxWork.Location]								
			pbxWork_X_Assignments();																		
			#endregion 

			#region Ensure [this.Height] is sufficient to display the PictureBoxes in [this.pnlTabImages]
			// Ensure [this.Height] is sufficient to display the PictureBoxes in [this.pnlTabImages]
			System.Windows.Forms.PictureBox pbxLast = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[this.pnlTabImages.Controls.Count - 1];	
			if( ((pbxLast.Location.X + pbxLast.Width) > this.pnlTabImages.Width)							
			&& (this.pnlTabImages.Height < (pbxLast.Height + SystemInformation.HorizontalScrollBarHeight))	// 1.0.011
			)																								
			{																								
				this.Height += SystemInformation.HorizontalScrollBarHeight;	// Add .Height for ScrollBar	// 1.0.011
			}																								
			pbxLast = null;																					
			#endregion 
		}


        /// <summary>
        /// Reorders the work.
        /// </summary>
        /// <param name="parmMoveTo">The parm move to.</param>
        private void Reorder_Work(string parmMoveTo)														// 1.0.004
		{																									
			this._txtMoveTo_TextAtEnter = "";																// 1.0.004
			#region Validate Pointer to current active selection
			// This particular situation should never occur													// 1.0.004
			if (!ActivePointerIsValid())																	// 1.0.004
			{																								// 1.0.004
				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.004
				this.txtMoveTo.Focus();																		// 1.0.004
				//this.trackBarMoveTo.Focus();																// 1.0.004
				return;																						// 1.0.004
			}																								// 1.0.004
			#endregion 

			int moveTo = 0;																					
			double dummyDouble = 0.0;																		
			// Actually, the RegularExpression will guarantee that [parmMoveTo] is numeric					// 1.0.004
			if (StringIs.Numeric(parmMoveTo, out moveTo, out dummyDouble) )									// 1.0.004
			{																								
				moveTo = trackBarMoveTo_SetValue(moveTo);													// 1.0.004
				//this.trackBarMoveTo.Focus();																

				// Build old/current and new position pointers												// 1.0.004
				int idxOldPosition = this._idxPbxActive;// Pointer to current active selection, or index to	// 1.0.004
				int idxNewPosition = moveTo - 1;		//   [this._alTabPointers] and [this._alTabImages]	// 1.0.004
				Reorder_Work(idxOldPosition, idxNewPosition);												// 1.0.004
			}																								
		}

        /// <summary>
        /// Reorders the work.
        /// </summary>
        /// <param name="idxOldPosition">The index old position.</param>
        /// <param name="idxNewPosition">The index new position.</param>
        private void Reorder_Work(int idxOldPosition, int idxNewPosition)									// 1.0.004
		{																									// 1.0.004
			if(( (idxNewPosition > -1)								// Can't move leftmost to the left		
				|| (idxOldPosition > 0) )																	// 1.0.004
			&&( (idxOldPosition != this._alTabPointers.Count - 1)	// Can't move rightmost to the right	
				|| (idxNewPosition < this._alTabPointers.Count) )											
			)																								
			{																								
				#region If we let a value [ (idxNewPosition < 0) ] into this code-block, fix the value
				if (idxNewPosition < 0)																		// 1.0.004
				{																							// 1.0.004
					idxNewPosition = 0;																		// 1.0.004
				}																							// 1.0.004
				#endregion 

				#region "Move" the TabPage (i.e. move its Pointer and TabRect Image within the respective ArrayLists)
				object pointer = this._alTabPointers[idxOldPosition];	// Pointer to the actual TabPage	
				object image = this._alTabImages[idxOldPosition];		// Image of the TabPage TabRect		

				this._alTabPointers.RemoveAt(idxOldPosition);												
				this._alTabImages.RemoveAt(idxOldPosition);													
				if (idxNewPosition >= this._alTabPointers.Count)											
				{																							
					this._alTabPointers.Add(pointer);														
					this._alTabImages.Add(image);															
					this._idxPbxActive = this._alTabPointers.Count - 1;										
				}																							
				else																						
				{																							
					this._alTabPointers.Insert(idxNewPosition, pointer);									
					this._alTabImages.Insert(idxNewPosition, image);										
					this._idxPbxActive = idxNewPosition;													
				}																							
				#endregion 

				pbxWork_X_Assignments();																	

				//this.pnlTabImages.Controls[this._idxPbxActive].Select();									
				this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);	

				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											
				this.trackBarMoveTo.Focus();																
			}																								
		}                                                                                                   // 1.0.004
        #endregion

        #region Public Properties
        // public int[] TabOrder_int {get}
        // 
        /// <summary>
        /// Gets the tab order int.
        /// </summary>
        /// <value>The tab order int.</value>
        public int[] TabOrder_int																			
		{																									
			get																								
			{																								
				if (this._alTabPointers.Count > 0)															
				{																							
					return (int[])this._alTabPointers.ToArray(typeof(int));									

					// The above does essentially the following:											
					//int[] intTabOrder = new int[this._alTabPointers.Count];								
					//for (int idx = 0; idx < this._alTabPointers.Count; idx++)								
					//{																						
					//	intTabOrder[idx] = (int)this._alTabPointers[idx];									
					//}																						
					//return intTabOrder;																	
				}																							
				return new int[]{};																			
			}																								
		}																									
		#endregion 
	}

    #region Class:  StringIs
    // internal class StringIs 
    //   public static bool Numeric(string parmString, out int outInt, out double outDouble)
    //   
    /// <summary>
    /// Class StringIs.
    /// </summary>
    internal class StringIs
	{
        /// <summary>
        /// Numerics the specified parm string.
        /// </summary>
        /// <param name="parmString">The parm string.</param>
        /// <param name="outInt">The out int.</param>
        /// <param name="outDouble">The out double.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Numeric(string parmString, out int outInt, out double outDouble)
		{
			bool interimNumeric = false;
			bool foundDecimal = false;
			bool foundMinus = false;
			bool foundPlus = false;

			int tempInt = 0;
			double tempDouble = 0.0;
			double tempDoubleDivisor = 1.0;
			int digit;

			string tempString = parmString.Trim();
			if (tempString.Length > 0)
			{
				interimNumeric = true;
				for (int ix = 0; (interimNumeric) && (ix < tempString.Length); ix++)
				{
					char oneChar = tempString[ix];
					//if( (tempString[ix] == '-') || (tempString[ix] == '+') )
					if( (oneChar == '-') || (oneChar == '+') )
					{
						if( foundMinus || foundPlus || ((ix > 0) && (ix < tempString.Length -1)) )
						{
							interimNumeric = false;
							continue;
						}
						else
						{
							if (oneChar == '-')
							{
								foundMinus = true;
							}
							else if (oneChar == '+')
							{
								foundPlus = true;
							}
							continue;
						}
					}
					//if (tempString[ix] == ',')
					if (oneChar == ',')
					{
						continue;
					}
					//if (tempString[ix] == '.')
					if (oneChar == '.')
					{
						if (foundDecimal)
						{
							interimNumeric = false;
							continue;
						}
						else
						{
							foundDecimal = true;
							continue;
						}
					}
					//if( (tempString[ix] < '0') || (tempString[ix] > '9') )
					if( (oneChar < '0') || (oneChar > '9') )
					//if( !Char.IsNumber(tempString[ix]) )
					//if( !Char.IsNumber(oneChar) )
					{
						interimNumeric = false;
						continue;
					}
					//digit = Int32.Parse((string)tempString[ix]);
					digit = Int32.Parse(tempString.Substring(ix,1));
					if (foundDecimal)
					{
						tempDouble = (tempDouble * 10.0) + (double)digit;
						tempDoubleDivisor = (tempDoubleDivisor * 10.0);
					}
					else
					{
						tempInt = (tempInt * 10) + digit;
					}
				}

				tempDouble = (tempDouble/tempDoubleDivisor) + (double)tempInt;
			}

			if (foundMinus)
			{
				outInt = -1 * tempInt;
				outDouble = -1.0 * tempDouble;
			}
			else
			{
				outInt = tempInt;
				outDouble = tempDouble;
			}
			return interimNumeric;
		}

	}
	#endregion 
}																											
