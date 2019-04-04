// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FormLoadFileEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    #region FormLoadFileEditor

    #region Control
    /// <summary>
    /// Class FormLoadFileEditor.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    internal partial class FormLoadFileEditor : System.Windows.Forms.Form
    {

        /// <summary>
        /// The filename
        /// </summary>
        public string filename = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="FormLoadFileEditor"/> class.
        /// </summary>
        public FormLoadFileEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FormLoadFileEditor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormLoadFileEditor_Load(object sender, EventArgs e)
        {
            this.Hide();
            // openFileDialog1.InitialDirectory = Application.LocalUserAppDataPath;
            openFileDialog1.Filter = "Shape Files|*.shp.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            this.Close();
        }
    }

    /// <summary>
    /// Class FileLoadEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class FileLoadEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoadEditor"/> class.
        /// </summary>
        public FileLoadEditor()
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

                FormLoadFileEditor lfeditor = new FormLoadFileEditor();
                edSvc.ShowDialog(lfeditor);

                //if (value.GetType() == typeof(Color))
                //    return sfeditor.color;
                return lfeditor.filename;

            }
            return value;
        }


    }

    #endregion

    #region Designer Generated Code

    partial class FormLoadFileEditor
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormLoadFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 192);
            this.Name = "FormLoadFileEditor";
            this.Text = "FormLoadFileEditor";
            this.Load += new System.EventHandler(this.FormLoadFileEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The open file dialog1
        /// </summary>
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }

    #endregion

    #endregion
}
