// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-07-2018
// ***********************************************************************
// <copyright file="IconEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Zusammenfassung für IconEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class IconEditor:UITypeEditor
	{
        #region variables
        /// <summary>
        /// The filedialog
        /// </summary>
        private FileDialog _filedialog;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="IconEditor"/> class.
        /// </summary>
        public IconEditor(){}
        #region overrides
        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if ((provider == null) ||
				(provider.GetService(typeof(IWindowsFormsEditorService)) == null))
				return value;
			if(_filedialog==null)
			{
				_filedialog=new OpenFileDialog();
				_filedialog.Filter="Icons(*.ico)|*.ico";
			}
			if(_filedialog.ShowDialog()==DialogResult.OK)
			{
				try
				{
					using(FileStream stream=new FileStream(_filedialog.FileName,
							  FileMode.Open,
							  FileAccess.Read,
							  FileShare.Read))
					{
						byte[] buffer=new byte[stream.Length];
						stream.Read(buffer,0,buffer.Length);
						using(MemoryStream mstr=new MemoryStream(buffer))
						{
							value=new IconEncoder(mstr);
						}
					}
				}
				catch{}
			}
			return value;
		}
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			return true;
		}
        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
		{
			if(e.Value is IconEncoder)
			{
				IconEncoder icn=(IconEncoder)e.Value;
				Rectangle bounds=e.Bounds;
				bounds.Width--;
				bounds.Height--;
				if(icn.Images.Count>0)
					e.Graphics.DrawImage(icn.Images[0].Bitmap,bounds);
				e.Graphics.DrawRectangle(SystemPens.WindowFrame,bounds);
			}
		}

		#endregion
	}
}
