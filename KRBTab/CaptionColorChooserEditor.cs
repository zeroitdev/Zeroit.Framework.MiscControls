// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CaptionColorChooserEditor.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.Tabs.ZeroitKRBTab
{
    /// <summary>
    /// Class ZeroitKRBTab.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    partial class ZeroitKRBTab
    {
        /// <summary>
        /// Class CaptionColorChooserEditor.
        /// </summary>
        /// <seealso cref="System.Drawing.Design.UITypeEditor" />
        class CaptionColorChooserEditor : UITypeEditor
        {
            #region Destructor

            /// <summary>
            /// Finalizes an instance of the <see cref="CaptionColorChooserEditor"/> class.
            /// </summary>
            ~CaptionColorChooserEditor()
            {
                GC.SuppressFinalize(this);
            }

            #endregion

            #region Override Methods

            /// <summary>
            /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
            /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
            public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(
                System.ComponentModel.ITypeDescriptorContext context)
            {
                // We will use a window for property editing.
                return UITypeEditorEditStyle.Modal;
            }

            /// <summary>
            /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
            /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
            /// <param name="value">The object to edit.</param>
            /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
            public override object EditValue(
                System.ComponentModel.ITypeDescriptorContext context,
                System.IServiceProvider provider, object value)
            {
                ICaptionRandomizer current;
                using (CaptionColorChooser frm = new CaptionColorChooser())
                {
                    // Set currently objects to the form.
                    frm.Randomizer = (ICaptionRandomizer)value;
                    frm.contextInstance = context.Instance as ZeroitKRBTab;

                    if (frm.ShowDialog() == DialogResult.OK)
                        current = frm.Randomizer;
                    else
                        current = (ICaptionRandomizer)value;
                }

                return current;
            }

            /// <summary>
            /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
            /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
            public override bool GetPaintValueSupported(
                System.ComponentModel.ITypeDescriptorContext context)
            {
                // No special thumbnail will be shown for the grid.
                return false;
            }

            #endregion
        }
    }
}