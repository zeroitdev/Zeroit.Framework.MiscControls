// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="RangeEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class RangeEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    internal class RangeEditor : UITypeEditor
    {
        /// <summary>
        /// The default value
        /// </summary>
        private int defaultValue = 128;
        /// <summary>
        /// The maximum
        /// </summary>
        private int max = 255;
        /// <summary>
        /// The minimum
        /// </summary>
        private int min;

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            OpacityEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                SetMinMaxValue(context);
                if (!(value is int && (int) value >= min && (int) value <= max))
                {
                    value = defaultValue;
                }
                if (editorService != null)
                {
                    var currentValue = (int) value;
                    editor = new OpacityEditorUI(currentValue, min, max);
                    editor.Dock = DockStyle.Fill;
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        /// <summary>
        /// Sets the minimum maximum value.
        /// </summary>
        /// <param name="context">The context.</param>
        private void SetMinMaxValue(ITypeDescriptorContext context)
        {
            var attribute = context.PropertyDescriptor.Attributes[typeof (MinMaxAttribute)] as MinMaxAttribute;
            if (attribute != null)
            {
                min = attribute.MinValue;
                max = attribute.MaxValue;
            }
            if (max <= min)
            {
                min = 0;
                max = 100;
                defaultValue = 0;
            }
            var defaultVal =
                context.PropertyDescriptor.Attributes[typeof (DefaultValueAttribute)] as DefaultValueAttribute;
            if (defaultVal != null && defaultVal.Value is int)
            {
                defaultValue = (int) defaultVal.Value;
            }
            else
            {
                if (defaultValue > max)
                {
                    defaultValue = max;
                }
                if (defaultValue < min)
                {
                    defaultValue = min;
                }
            }
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: OpacityEditorUI

        /// <summary>
        /// Class OpacityEditorUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.UserControl" />
        [ToolboxItem(false)]
        private class OpacityEditorUI : UserControl
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private IContainer components = null;

            /// <summary>
            /// The current value
            /// </summary>
            private int currentValue;
            /// <summary>
            /// The TRK main
            /// </summary>
            private TrackBar trkMain;

            /// <summary>
            /// Initializes a new instance of the <see cref="OpacityEditorUI"/> class.
            /// </summary>
            /// <param name="currentValue">The current value.</param>
            /// <param name="min">The minimum.</param>
            /// <param name="max">The maximum.</param>
            protected internal OpacityEditorUI(int currentValue, int min, int max)
            {
                InitializeComponent();
                this.currentValue = currentValue;
                trkMain.Minimum = min;
                trkMain.Maximum = max;
                trkMain.Value = currentValue;
                trkMain.TickFrequency = (max - min)/10;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>System.Object.</returns>
            public object GetValue()
            {
                return currentValue;
            }

            /// <summary>
            /// Handles the ValueChanged event of the trkMain control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void trkMain_ValueChanged(object sender, EventArgs e)
            {
                currentValue = trkMain.Value;
            }

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

            #region Component Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new Container();
                this.trkMain = new System.Windows.Forms.TrackBar();
                ((System.ComponentModel.ISupportInitialize) (this.trkMain)).BeginInit();
                this.SuspendLayout();
                // 
                // trkMain
                // 
                this.trkMain.AutoSize = false;
                this.trkMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.trkMain.Location = new System.Drawing.Point(0, 0);
                this.trkMain.Name = "trkMain";
                this.trkMain.RightToLeftLayout = true;
                this.trkMain.Size = new System.Drawing.Size(150, 37);
                this.trkMain.TabIndex = 0;
                this.trkMain.TickFrequency = 16;
                this.trkMain.ValueChanged += new System.EventHandler(this.trkMain_ValueChanged);
                // 
                // OpacityEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.Controls.Add(this.trkMain);
                this.Name = "OpacityEditorUI";
                this.Size = new System.Drawing.Size(150, 37);
                ((System.ComponentModel.ISupportInitialize) (this.trkMain)).EndInit();
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
}