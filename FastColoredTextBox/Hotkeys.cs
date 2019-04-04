// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Hotkeys.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using KEYS = System.Windows.Forms.Keys;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Dictionary of shortcuts for FCTB
    /// </summary>
    /// <seealso cref="System.Collections.Generic.SortedDictionary{System.Windows.Forms.Keys, Zeroit.Framework.MiscControls.FastControls.FCTBAction}" />
    public class HotkeysMapping : SortedDictionary<Keys, FCTBAction>
    {
        /// <summary>
        /// Initializes the default.
        /// </summary>
        public virtual void InitDefault()
        {
            this[KEYS.Control | KEYS.G] = FCTBAction.GoToDialog;
            this[KEYS.Control | KEYS.F] = FCTBAction.FindDialog;
            this[KEYS.Alt | KEYS.F] = FCTBAction.FindChar;
            this[KEYS.F3] = FCTBAction.FindNext;
            this[KEYS.Control | KEYS.H] = FCTBAction.ReplaceDialog;
            this[KEYS.Control | KEYS.C] = FCTBAction.Copy;
            this[KEYS.Control | KEYS.Shift | KEYS.C] = FCTBAction.CommentSelected;
            this[KEYS.Control | KEYS.X] = FCTBAction.Cut;
            this[KEYS.Control | KEYS.V] = FCTBAction.Paste;
            this[KEYS.Control | KEYS.A] = FCTBAction.SelectAll;
            this[KEYS.Control | KEYS.Z] = FCTBAction.Undo;
            this[KEYS.Control | KEYS.R] = FCTBAction.Redo;
            this[KEYS.Control | KEYS.U] = FCTBAction.UpperCase;
            this[KEYS.Shift | KEYS.Control | KEYS.U] = FCTBAction.LowerCase;
            this[KEYS.Control | KEYS.OemMinus] = FCTBAction.NavigateBackward;
            this[KEYS.Control | KEYS.Shift | KEYS.OemMinus] = FCTBAction.NavigateForward;
            this[KEYS.Control | KEYS.B] = FCTBAction.BookmarkLine;
            this[KEYS.Control | KEYS.Shift | KEYS.B] = FCTBAction.UnbookmarkLine;
            this[KEYS.Control | KEYS.N] = FCTBAction.GoNextBookmark;
            this[KEYS.Control | KEYS.Shift | KEYS.N] = FCTBAction.GoPrevBookmark;
            this[KEYS.Alt | KEYS.Back] = FCTBAction.Undo;
            this[KEYS.Control | KEYS.Back] = FCTBAction.ClearWordLeft;
            this[KEYS.Insert] = FCTBAction.ReplaceMode;
            this[KEYS.Control | KEYS.Insert] = FCTBAction.Copy;
            this[KEYS.Shift | KEYS.Insert] = FCTBAction.Paste;
            this[KEYS.Delete] = FCTBAction.DeleteCharRight;
            this[KEYS.Control | KEYS.Delete] = FCTBAction.ClearWordRight;
            this[KEYS.Shift | KEYS.Delete] = FCTBAction.Cut;
            this[KEYS.Left] = FCTBAction.GoLeft;
            this[KEYS.Shift | KEYS.Left] = FCTBAction.GoLeftWithSelection;
            this[KEYS.Control | KEYS.Left] = FCTBAction.GoWordLeft;
            this[KEYS.Control | KEYS.Shift | KEYS.Left] = FCTBAction.GoWordLeftWithSelection;
            this[KEYS.Alt | KEYS.Shift | KEYS.Left] = FCTBAction.GoLeft_ColumnSelectionMode;
            this[KEYS.Right] = FCTBAction.GoRight;
            this[KEYS.Shift | KEYS.Right] = FCTBAction.GoRightWithSelection;
            this[KEYS.Control | KEYS.Right] = FCTBAction.GoWordRight;
            this[KEYS.Control | KEYS.Shift | KEYS.Right] = FCTBAction.GoWordRightWithSelection;
            this[KEYS.Alt | KEYS.Shift | KEYS.Right] = FCTBAction.GoRight_ColumnSelectionMode;
            this[KEYS.Up] = FCTBAction.GoUp;
            this[KEYS.Shift | KEYS.Up] = FCTBAction.GoUpWithSelection;
            this[KEYS.Alt | KEYS.Shift | KEYS.Up] = FCTBAction.GoUp_ColumnSelectionMode;
            this[KEYS.Alt | KEYS.Up] = FCTBAction.MoveSelectedLinesUp;
            this[KEYS.Control | KEYS.Up] = FCTBAction.ScrollUp;
            this[KEYS.Down] = FCTBAction.GoDown;
            this[KEYS.Shift | KEYS.Down] = FCTBAction.GoDownWithSelection;
            this[KEYS.Alt | KEYS.Shift | KEYS.Down] = FCTBAction.GoDown_ColumnSelectionMode;
            this[KEYS.Alt | KEYS.Down] = FCTBAction.MoveSelectedLinesDown;
            this[KEYS.Control | KEYS.Down] = FCTBAction.ScrollDown;
            this[KEYS.PageUp] = FCTBAction.GoPageUp;
            this[KEYS.Shift | KEYS.PageUp] = FCTBAction.GoPageUpWithSelection;
            this[KEYS.PageDown] = FCTBAction.GoPageDown;
            this[KEYS.Shift | KEYS.PageDown] = FCTBAction.GoPageDownWithSelection;
            this[KEYS.Home] = FCTBAction.GoHome;
            this[KEYS.Shift | KEYS.Home] = FCTBAction.GoHomeWithSelection;
            this[KEYS.Control | KEYS.Home] = FCTBAction.GoFirstLine;
            this[KEYS.Control | KEYS.Shift | KEYS.Home] = FCTBAction.GoFirstLineWithSelection;
            this[KEYS.End] = FCTBAction.GoEnd;
            this[KEYS.Shift | KEYS.End] = FCTBAction.GoEndWithSelection;
            this[KEYS.Control | KEYS.End] = FCTBAction.GoLastLine;
            this[KEYS.Control | KEYS.Shift | KEYS.End] = FCTBAction.GoLastLineWithSelection;
            this[KEYS.Escape] = FCTBAction.ClearHints;
            this[KEYS.Control | KEYS.M] = FCTBAction.MacroRecord;
            this[KEYS.Control | KEYS.E] = FCTBAction.MacroExecute;
            this[KEYS.Control | KEYS.Space] = FCTBAction.AutocompleteMenu;
            this[KEYS.Tab] = FCTBAction.IndentIncrease;
            this[KEYS.Shift | KEYS.Tab] = FCTBAction.IndentDecrease;
            this[KEYS.Control | KEYS.Subtract] = FCTBAction.ZoomOut;
            this[KEYS.Control | KEYS.Add] = FCTBAction.ZoomIn;
            this[KEYS.Control | KEYS.D0] = FCTBAction.ZoomNormal;
            this[KEYS.Control | KEYS.I] = FCTBAction.AutoIndentChars;   
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var cult = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder();
            var kc = new KeysConverter();
            foreach (var pair in this)
            {
                sb.AppendFormat("{0}={1}, ", kc.ConvertToString(pair.Key), pair.Value);
            }

            if (sb.Length > 1)
                sb.Remove(sb.Length - 2, 2);
            Thread.CurrentThread.CurrentUICulture = cult;

            return sb.ToString();
        }

        /// <summary>
        /// Parses the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>HotkeysMapping.</returns>
        public static HotkeysMapping Parse(string s)
        {
            var result = new HotkeysMapping();
            result.Clear();
            var cult = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            var kc = new KeysConverter();
            
            foreach (var p in s.Split(','))
            {
                var pp = p.Split('=');
                var k = (Keys)kc.ConvertFromString(pp[0].Trim());
                var a = (FCTBAction)Enum.Parse(typeof(FCTBAction), pp[1].Trim());
                result[k] = a;
            }

            Thread.CurrentThread.CurrentUICulture = cult;

            return result;
        }
    }

    /// <summary>
    /// Actions for shortcuts
    /// </summary>
    public enum FCTBAction
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The autocomplete menu
        /// </summary>
        AutocompleteMenu,
        /// <summary>
        /// The automatic indent chars
        /// </summary>
        AutoIndentChars,
        /// <summary>
        /// The bookmark line
        /// </summary>
        BookmarkLine,
        /// <summary>
        /// The clear hints
        /// </summary>
        ClearHints,
        /// <summary>
        /// The clear word left
        /// </summary>
        ClearWordLeft,
        /// <summary>
        /// The clear word right
        /// </summary>
        ClearWordRight,
        /// <summary>
        /// The comment selected
        /// </summary>
        CommentSelected,
        /// <summary>
        /// The copy
        /// </summary>
        Copy,
        /// <summary>
        /// The cut
        /// </summary>
        Cut,
        /// <summary>
        /// The delete character right
        /// </summary>
        DeleteCharRight,
        /// <summary>
        /// The find character
        /// </summary>
        FindChar,
        /// <summary>
        /// The find dialog
        /// </summary>
        FindDialog,
        /// <summary>
        /// The find next
        /// </summary>
        FindNext,
        /// <summary>
        /// The go down
        /// </summary>
        GoDown,
        /// <summary>
        /// The go down with selection
        /// </summary>
        GoDownWithSelection,
        /// <summary>
        /// The go down column selection mode
        /// </summary>
        GoDown_ColumnSelectionMode,
        /// <summary>
        /// The go end
        /// </summary>
        GoEnd,
        /// <summary>
        /// The go end with selection
        /// </summary>
        GoEndWithSelection,
        /// <summary>
        /// The go first line
        /// </summary>
        GoFirstLine,
        /// <summary>
        /// The go first line with selection
        /// </summary>
        GoFirstLineWithSelection,
        /// <summary>
        /// The go home
        /// </summary>
        GoHome,
        /// <summary>
        /// The go home with selection
        /// </summary>
        GoHomeWithSelection,
        /// <summary>
        /// The go last line
        /// </summary>
        GoLastLine,
        /// <summary>
        /// The go last line with selection
        /// </summary>
        GoLastLineWithSelection,
        /// <summary>
        /// The go left
        /// </summary>
        GoLeft,
        /// <summary>
        /// The go left with selection
        /// </summary>
        GoLeftWithSelection,
        /// <summary>
        /// The go left column selection mode
        /// </summary>
        GoLeft_ColumnSelectionMode,
        /// <summary>
        /// The go page down
        /// </summary>
        GoPageDown,
        /// <summary>
        /// The go page down with selection
        /// </summary>
        GoPageDownWithSelection,
        /// <summary>
        /// The go page up
        /// </summary>
        GoPageUp,
        /// <summary>
        /// The go page up with selection
        /// </summary>
        GoPageUpWithSelection,
        /// <summary>
        /// The go right
        /// </summary>
        GoRight,
        /// <summary>
        /// The go right with selection
        /// </summary>
        GoRightWithSelection,
        /// <summary>
        /// The go right column selection mode
        /// </summary>
        GoRight_ColumnSelectionMode,
        /// <summary>
        /// The go to dialog
        /// </summary>
        GoToDialog,
        /// <summary>
        /// The go next bookmark
        /// </summary>
        GoNextBookmark,
        /// <summary>
        /// The go previous bookmark
        /// </summary>
        GoPrevBookmark,
        /// <summary>
        /// The go up
        /// </summary>
        GoUp,
        /// <summary>
        /// The go up with selection
        /// </summary>
        GoUpWithSelection,
        /// <summary>
        /// The go up column selection mode
        /// </summary>
        GoUp_ColumnSelectionMode,
        /// <summary>
        /// The go word left
        /// </summary>
        GoWordLeft,
        /// <summary>
        /// The go word left with selection
        /// </summary>
        GoWordLeftWithSelection,
        /// <summary>
        /// The go word right
        /// </summary>
        GoWordRight,
        /// <summary>
        /// The go word right with selection
        /// </summary>
        GoWordRightWithSelection,
        /// <summary>
        /// The indent increase
        /// </summary>
        IndentIncrease,
        /// <summary>
        /// The indent decrease
        /// </summary>
        IndentDecrease,
        /// <summary>
        /// The lower case
        /// </summary>
        LowerCase,
        /// <summary>
        /// The macro execute
        /// </summary>
        MacroExecute,
        /// <summary>
        /// The macro record
        /// </summary>
        MacroRecord,
        /// <summary>
        /// The move selected lines down
        /// </summary>
        MoveSelectedLinesDown,
        /// <summary>
        /// The move selected lines up
        /// </summary>
        MoveSelectedLinesUp,
        /// <summary>
        /// The navigate backward
        /// </summary>
        NavigateBackward,
        /// <summary>
        /// The navigate forward
        /// </summary>
        NavigateForward,
        /// <summary>
        /// The paste
        /// </summary>
        Paste,
        /// <summary>
        /// The redo
        /// </summary>
        Redo,
        /// <summary>
        /// The replace dialog
        /// </summary>
        ReplaceDialog,
        /// <summary>
        /// The replace mode
        /// </summary>
        ReplaceMode,
        /// <summary>
        /// The scroll down
        /// </summary>
        ScrollDown,
        /// <summary>
        /// The scroll up
        /// </summary>
        ScrollUp,
        /// <summary>
        /// The select all
        /// </summary>
        SelectAll,
        /// <summary>
        /// The unbookmark line
        /// </summary>
        UnbookmarkLine,
        /// <summary>
        /// The undo
        /// </summary>
        Undo,
        /// <summary>
        /// The upper case
        /// </summary>
        UpperCase,
        /// <summary>
        /// The zoom in
        /// </summary>
        ZoomIn,
        /// <summary>
        /// The zoom normal
        /// </summary>
        ZoomNormal,
        /// <summary>
        /// The zoom out
        /// </summary>
        ZoomOut,
        /// <summary>
        /// The custom action1
        /// </summary>
        CustomAction1,
        /// <summary>
        /// The custom action2
        /// </summary>
        CustomAction2,
        /// <summary>
        /// The custom action3
        /// </summary>
        CustomAction3,
        /// <summary>
        /// The custom action4
        /// </summary>
        CustomAction4,
        /// <summary>
        /// The custom action5
        /// </summary>
        CustomAction5,
        /// <summary>
        /// The custom action6
        /// </summary>
        CustomAction6,
        /// <summary>
        /// The custom action7
        /// </summary>
        CustomAction7,
        /// <summary>
        /// The custom action8
        /// </summary>
        CustomAction8,
        /// <summary>
        /// The custom action9
        /// </summary>
        CustomAction9,
        /// <summary>
        /// The custom action10
        /// </summary>
        CustomAction10,
        /// <summary>
        /// The custom action11
        /// </summary>
        CustomAction11,
        /// <summary>
        /// The custom action12
        /// </summary>
        CustomAction12,
        /// <summary>
        /// The custom action13
        /// </summary>
        CustomAction13,
        /// <summary>
        /// The custom action14
        /// </summary>
        CustomAction14,
        /// <summary>
        /// The custom action15
        /// </summary>
        CustomAction15,
        /// <summary>
        /// The custom action16
        /// </summary>
        CustomAction16,
        /// <summary>
        /// The custom action17
        /// </summary>
        CustomAction17,
        /// <summary>
        /// The custom action18
        /// </summary>
        CustomAction18,
        /// <summary>
        /// The custom action19
        /// </summary>
        CustomAction19,
        /// <summary>
        /// The custom action20
        /// </summary>
        CustomAction20
    }

    /// <summary>
    /// Class HotkeysEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    internal class HotkeysEditor : UITypeEditor
    {
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
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((provider != null) && (((IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService))) != null))
            {
                var form = new HotkeysEditorForm(HotkeysMapping.Parse(value as string));

                if (form.ShowDialog() == DialogResult.OK)
                    value = form.GetHotkeys().ToString();
            }
            return value;
        }
    }
}
