// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SaveFileEditor.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    #region FormSaveFileEditor

    #region Control
    /// <summary>
    /// Class FormSaveFileEditor.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    internal partial class FormSaveFileEditor : System.Windows.Forms.Form
    {
        /// <summary>
        /// The filename
        /// </summary>
        public string filename = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="FormSaveFileEditor"/> class.
        /// </summary>
        public FormSaveFileEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FormSaveFileEditor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormSaveFileEditor_Load(object sender, EventArgs e)
        {
            this.Hide();
            // saveFileDialog1.InitialDirectory = Application.LocalUserAppDataPath;
            saveFileDialog1.Filter = "Shape Files|*.shp.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }
            this.Close();
        }
    }

    /// <summary>
    /// Class FileSaveEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class FileSaveEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSaveEditor"/> class.
        /// </summary>
        public FileSaveEditor()
        {
        }

        // Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
        // drop down dialog, or no UI outside of the properties window.
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;


        }

        // Displays the UI for value selection.
        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {

            //if( value.GetType() != typeof(Color))
            //    return value;

            // Uses the IWindowsFormsEditorService to display a 
            // drop-down UI in the Properties window.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                //ColorEditorControl editor = new ColorEditorControl((Color)value);
                //edSvc.DropDownControl(editor);

                //// Return the value in the appropraite data format.
                //if (value.GetType() == typeof(Color))
                //    return editor.color;

                FormSaveFileEditor sfeditor = new FormSaveFileEditor();
                edSvc.ShowDialog(sfeditor);

                //if (value.GetType() == typeof(Color))
                //    return sfeditor.color;
                return sfeditor.filename;

            }
            return value;
        }

        ////  Draws a representation of the property's value.
        // [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        // public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        // {

        //    // e.Graphics.FillRectangle(new SolidBrush((Color)e.Value), 1, 1, e.Bounds.Width, e.Bounds.Height);
        //     e.Graphics.FillRectangle(new SolidBrush(Color.Red), 1, 1, e.Bounds.Width, e.Bounds.Height);
        //     string path =Application.UserAppDataPath +"\\debug.txt";
        //       //using (StreamWriter sw = File.AppendText(path))
        //       //{
        //       //    sw.WriteLine("Value:"+ e.Value.ToString() );
        //       //}

        // }

        // // Indicates whether the UITypeEditor supports painting a 
        // // representation of a property's value.
        // [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        // public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        // {
        //     return true;
        // }
    }


    #endregion

    #region Designer Generated Code

    partial class FormSaveFileEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // FormSaveFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 144);
            this.Name = "FormSaveFileEditor";
            this.Text = "FormSaveFileEditor";
            this.Load += new System.EventHandler(this.FormSaveFileEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The save file dialog1
        /// </summary>
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }

    #endregion

    #endregion
}
