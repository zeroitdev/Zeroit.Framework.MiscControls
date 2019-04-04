// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Hints.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Collection of Hints.
    /// This is temporary buffer for currently displayed hints.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{Zeroit.Framework.MiscControls.FastControls.Hint}" />
    /// <seealso cref="System.IDisposable" />
    public class Hints : ICollection<Hint>, IDisposable
    {
        /// <summary>
        /// The tb
        /// </summary>
        ZeroitCodeTextBox tb;
        /// <summary>
        /// The items
        /// </summary>
        List<Hint> items = new List<Hint>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Hints"/> class.
        /// </summary>
        /// <param name="tb">The tb.</param>
        public Hints(ZeroitCodeTextBox tb)
        {
            this.tb = tb;
            tb.TextChanged += OnTextBoxTextChanged;
            tb.KeyDown += OnTextBoxKeyDown;
            tb.VisibleRangeChanged += OnTextBoxVisibleRangeChanged;
        }

        /// <summary>
        /// Handles the <see cref="E:TextBoxKeyDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextBoxKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape && e.Modifiers == System.Windows.Forms.Keys.None)
                Clear();
        }

        /// <summary>
        /// Handles the <see cref="E:TextBoxTextChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            tb.TextChanged -= OnTextBoxTextChanged;
            tb.KeyDown -= OnTextBoxKeyDown;
            tb.VisibleRangeChanged -= OnTextBoxVisibleRangeChanged;
        }

        /// <summary>
        /// Handles the <see cref="E:TextBoxVisibleRangeChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnTextBoxVisibleRangeChanged(object sender, EventArgs e)
        {
            if (items.Count == 0)
                return;

            tb.NeedRecalc(true);
            foreach (var item in items)
            {
                LayoutHint(item);
                item.HostPanel.Invalidate();
            }
        }

        /// <summary>
        /// Layouts the hint.
        /// </summary>
        /// <param name="hint">The hint.</param>
        private void LayoutHint(Hint hint)
        {
            if (hint.Inline)
            {
                if (hint.Range.Start.iLine < tb.LineInfos.Count - 1)
                    hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
                else
                    hint.HostPanel.Top = tb.TextHeight + tb.Paddings.Top - hint.HostPanel.Height - tb.VerticalScroll.Value;
            }
            else
            {
                if (hint.Range.Start.iLine > tb.LinesCount - 1) return;
                if (hint.Range.Start.iLine == tb.LinesCount - 1)
                {
                    var y = tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value + tb.CharHeight;

                    if (y + hint.HostPanel.Height + 1 > tb.ClientRectangle.Bottom)
                    {
                        hint.HostPanel.Top = Math.Max(0, tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value - hint.HostPanel.Height);
                    }
                    else
                        hint.HostPanel.Top = y;

                }
                else
                {
                    hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.VerticalScroll.Value;
                    if (hint.HostPanel.Bottom > tb.ClientRectangle.Bottom)
                        hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.CharHeight - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
                }
            }

            if (hint.Dock == DockStyle.Fill)
            {
                hint.Width = tb.ClientSize.Width - tb.LeftIndent - 2;
                hint.HostPanel.Left = tb.LeftIndent;
            }
            else
            {
                var p1 = tb.PlaceToPoint(hint.Range.Start);
                var p2 = tb.PlaceToPoint(hint.Range.End);
                var cx = (p1.X + p2.X) / 2;
                var x = cx - hint.HostPanel.Width / 2;
                hint.HostPanel.Left = Math.Max( tb.LeftIndent, x);
                if(hint.HostPanel.Right > tb.ClientSize.Width)
                    hint.HostPanel.Left = Math.Max(tb.LeftIndent, x - (hint.HostPanel.Right - tb.ClientSize.Width));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Hint> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Clears all displayed hints
        /// </summary>
        public void Clear()
        {
            items.Clear();
            if (tb.Controls.Count != 0)
            {
                var toDelete = new List<Control>();
                foreach (Control item in tb.Controls)
                    if (item is UnfocusablePanel)
                        toDelete.Add(item);

                foreach (var item in toDelete)
                    tb.Controls.Remove(item);

                for (int i = 0; i < tb.LineInfos.Count; i++)
                {
                    var li = tb.LineInfos[i];
                    li.bottomPadding = 0;
                    tb.LineInfos[i] = li;
                }
                tb.NeedRecalc();
                tb.Invalidate();
                tb.Select();
                tb.ActiveControl = null;
            }
        }

        /// <summary>
        /// Add and shows the hint
        /// </summary>
        /// <param name="hint">The hint.</param>
        public void Add(Hint hint)
        {
            items.Add(hint);

            if (hint.Inline/* || hint.Range.Start.iLine >= tb.LinesCount - 1*/)
            {
                var li = tb.LineInfos[hint.Range.Start.iLine];
                hint.TopPadding = li.bottomPadding;
                li.bottomPadding += hint.HostPanel.Height;
                tb.LineInfos[hint.Range.Start.iLine] = li;
                tb.NeedRecalc(true);
            }

            LayoutHint(hint);

            tb.OnVisibleRangeChanged();

            hint.HostPanel.Parent = tb;

            tb.Select();
            tb.ActiveControl = null;
            tb.Invalidate();
        }

        /// <summary>
        /// Is collection contains the hint?
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        public bool Contains(Hint item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(Hint[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Count of hints
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Remove(Hint item)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Hint of FastColoredTextbox
    /// </summary>
    public class Hint 
    {
        /// <summary>
        /// Text of simple hint
        /// </summary>
        /// <value>The text.</value>
        public string Text { get { return HostPanel.Text; } set { HostPanel.Text = value; } }
        /// <summary>
        /// Linked range
        /// </summary>
        /// <value>The range.</value>
        public Range Range { get; set; }
        /// <summary>
        /// Backcolor
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor { get { return HostPanel.BackColor; } set { HostPanel.BackColor = value; } }
        /// <summary>
        /// Second backcolor
        /// </summary>
        /// <value>The back color2.</value>
        public Color BackColor2 { get { return HostPanel.BackColor2; } set { HostPanel.BackColor2 = value; } }
        /// <summary>
        /// Border color
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor { get { return HostPanel.BorderColor; } set { HostPanel.BorderColor = value; } }
        /// <summary>
        /// Fore color
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor { get { return HostPanel.ForeColor; } set { HostPanel.ForeColor = value; } }
        /// <summary>
        /// Text alignment
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment { get { return HostPanel.TextAlignment; } set { HostPanel.TextAlignment = value; } }
        /// <summary>
        /// Font
        /// </summary>
        /// <value>The font.</value>
        public Font Font { get { return HostPanel.Font; } set { HostPanel.Font = value; } }
        /// <summary>
        /// Occurs when user click on simple hint
        /// </summary>
        public event EventHandler Click 
        {
            add { HostPanel.Click += value; }
            remove { HostPanel.Click -= value; }
        }
        /// <summary>
        /// Inner control
        /// </summary>
        /// <value>The inner control.</value>
        public Control InnerControl { get; set; }
        /// <summary>
        /// Docking (allows None and Fill only)
        /// </summary>
        /// <value>The dock.</value>
        public DockStyle Dock { get; set; }
        /// <summary>
        /// Width of hint (if Dock is None)
        /// </summary>
        /// <value>The width.</value>
        public int Width { get { return HostPanel.Width; } set { HostPanel.Width = value; } }
        /// <summary>
        /// Height of hint
        /// </summary>
        /// <value>The height.</value>
        public int Height { get { return HostPanel.Height; } set { HostPanel.Height = value; } }
        /// <summary>
        /// Host panel
        /// </summary>
        /// <value>The host panel.</value>
        public UnfocusablePanel HostPanel { get; private set; }

        /// <summary>
        /// Gets or sets the top padding.
        /// </summary>
        /// <value>The top padding.</value>
        internal int TopPadding { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        /// <value>The tag.</value>
        public object Tag { get; set; }
        /// <summary>
        /// Cursor
        /// </summary>
        /// <value>The cursor.</value>
        public Cursor Cursor { get { return HostPanel.Cursor; } set { HostPanel.Cursor = value; } }
        /// <summary>
        /// Inlining. If True then hint will moves apart text.
        /// </summary>
        /// <value><c>true</c> if inline; otherwise, <c>false</c>.</value>
        public bool Inline{get; set;}

        /// <summary>
        /// Scroll textbox to the hint
        /// </summary>
        public virtual void DoVisible()
        {
            Range.tb.DoRangeVisible(Range, true);
            Range.tb.DoVisibleRectangle(HostPanel.Bounds);
            
            Range.tb.Invalidate();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hint"/> class.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="innerControl">The inner control.</param>
        /// <param name="text">The text.</param>
        /// <param name="inline">if set to <c>true</c> [inline].</param>
        /// <param name="dock">if set to <c>true</c> [dock].</param>
        private Hint(Range range, Control innerControl, string text, bool inline, bool dock)
        {
            this.Range = range;
            this.Inline = inline;
            this.InnerControl = innerControl;

            Init();

            Dock = dock ? DockStyle.Fill : DockStyle.None;
            Text = text;
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="text">Text for simple hint</param>
        /// <param name="inline">Inlining. If True then hint will moves apart text</param>
        /// <param name="dock">Docking. If True then hint will fill whole line</param>
        public Hint(Range range, string text, bool inline, bool dock) 
            : this(range, null, text, inline, dock)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="text">Text for simple hint</param>
        public Hint(Range range, string text)
            : this(range, null, text, true, true)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="innerControl">Inner control</param>
        /// <param name="inline">Inlining. If True then hint will moves apart text</param>
        /// <param name="dock">Docking. If True then hint will fill whole line</param>
        public Hint(Range range, Control innerControl, bool inline, bool dock)
            : this(range, innerControl, null, inline, dock)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="innerControl">Inner control</param>
        public Hint(Range range, Control innerControl)
            : this(range, innerControl, null, true, true)
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected virtual void Init()
        {
            HostPanel = new UnfocusablePanel();
            HostPanel.Click += OnClick;

            Cursor = Cursors.Default;
            BorderColor = Color.Silver;
            BackColor2 = Color.White;
            BackColor = InnerControl == null ? Color.Silver : SystemColors.Control;
            ForeColor = Color.Black;
            TextAlignment = StringAlignment.Near;
            Font = Range.tb.Parent == null ? Range.tb.Font : Range.tb.Parent.Font;

            if (InnerControl != null)
            {
                HostPanel.Controls.Add(InnerControl);
                var size = InnerControl.GetPreferredSize(InnerControl.Size);
                HostPanel.Width = size.Width + 2;
                HostPanel.Height = size.Height + 2;
                InnerControl.Dock = DockStyle.Fill;
                InnerControl.Visible = true;
                BackColor = SystemColors.Control;
            }
            else
            {
                HostPanel.Height = Range.tb.CharHeight + 5;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(object sender, EventArgs e)
        {
            Range.tb.OnHintClick(this);
        }
    }
}
