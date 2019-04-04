// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="Commands.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Insert single char
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    /// <remarks>This operation includes also insertion of new line and removing char by backspace</remarks>
    public class InsertCharCommand : UndoableCommand
    {
        /// <summary>
        /// The c
        /// </summary>
        public char c;
        /// <summary>
        /// The deleted character
        /// </summary>
        char deletedChar = '\x0';

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <param name="c">Inserting char</param>
        public InsertCharCommand(TextSource ts, char c): base(ts)
        {
            this.c = c;
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            ts.OnTextChanging();
            switch (c)
            {
                case '\n': MergeLines(sel.Start.iLine, ts); break;
                case '\r': break;
                case '\b':
                    ts.CurrentTB.Selection.Start = lastSel.Start;
                    char cc = '\x0';
                    if (deletedChar != '\x0')
                    {
                        ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
                        InsertChar(deletedChar, ref cc, ts);
                    }
                    break;
                case '\t':
                    ts.CurrentTB.ExpandBlock(sel.Start.iLine);
                    for (int i = sel.FromX; i < lastSel.FromX; i++)
                        ts[sel.Start.iLine].RemoveAt(sel.Start.iChar);
                    ts.CurrentTB.Selection.Start = sel.Start;
                    break;
                default:
                    ts.CurrentTB.ExpandBlock(sel.Start.iLine);
                    ts[sel.Start.iLine].RemoveAt(sel.Start.iChar);
                    ts.CurrentTB.Selection.Start = sel.Start;
                    break;
            }

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(sel.Start.iLine, sel.Start.iLine));

            base.Undo();
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public override void Execute()
        {
            ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
            string s = c.ToString();
            ts.OnTextChanging(ref s);
            if (s.Length == 1)
                c = s[0];

            if (String.IsNullOrEmpty(s))
                throw new ArgumentOutOfRangeException();


            if (ts.Count == 0)
                InsertLine(ts);
            InsertChar(c, ref deletedChar, ts);

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(ts.CurrentTB.Selection.Start.iLine, ts.CurrentTB.Selection.Start.iLine));
            base.Execute();
        }

        /// <summary>
        /// Inserts the character.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="deletedChar">The deleted character.</param>
        /// <param name="ts">The ts.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Cant insert this char in ColumnRange mode
        /// or
        /// Cant insert this char in ColumnRange mode
        /// </exception>
        internal static void InsertChar(char c, ref char deletedChar, TextSource ts)
        {
            var tb = ts.CurrentTB;

            switch (c)
            {
                case '\n':
                    if (!ts.CurrentTB.AllowInsertRemoveLines)
                        throw new ArgumentOutOfRangeException("Cant insert this char in ColumnRange mode");
                    if (ts.Count == 0)
                        InsertLine(ts);
                    InsertLine(ts);
                    break;
                case '\r': break;
                case '\b'://backspace
                    if (tb.Selection.Start.iChar == 0 && tb.Selection.Start.iLine == 0)
                        return;
                    if (tb.Selection.Start.iChar == 0)
                    {
                        if (!ts.CurrentTB.AllowInsertRemoveLines)
                            throw new ArgumentOutOfRangeException("Cant insert this char in ColumnRange mode");
                        if (tb.LineInfos[tb.Selection.Start.iLine - 1].VisibleState != VisibleState.Visible)
                            tb.ExpandBlock(tb.Selection.Start.iLine - 1);
                        deletedChar = '\n';
                        MergeLines(tb.Selection.Start.iLine - 1, ts);
                    }
                    else
                    {
                        deletedChar = ts[tb.Selection.Start.iLine][tb.Selection.Start.iChar - 1].c;
                        ts[tb.Selection.Start.iLine].RemoveAt(tb.Selection.Start.iChar - 1);
                        tb.Selection.Start = new Place(tb.Selection.Start.iChar - 1, tb.Selection.Start.iLine);
                    }
                    break;
                case '\t':
                    int spaceCountNextTabStop = tb.TabLength - (tb.Selection.Start.iChar % tb.TabLength);
                    if (spaceCountNextTabStop == 0)
                        spaceCountNextTabStop = tb.TabLength;

                    for (int i = 0; i < spaceCountNextTabStop; i++)
                        ts[tb.Selection.Start.iLine].Insert(tb.Selection.Start.iChar, new Char(' '));

                    tb.Selection.Start = new Place(tb.Selection.Start.iChar + spaceCountNextTabStop, tb.Selection.Start.iLine);
                    break;
                default:
                    ts[tb.Selection.Start.iLine].Insert(tb.Selection.Start.iChar, new Char(c));
                    tb.Selection.Start = new Place(tb.Selection.Start.iChar + 1, tb.Selection.Start.iLine);
                    break;
            }
        }

        /// <summary>
        /// Inserts the line.
        /// </summary>
        /// <param name="ts">The ts.</param>
        internal static void InsertLine(TextSource ts)
        {
            var tb = ts.CurrentTB;

            if (!tb.Multiline && tb.LinesCount > 0)
                return;

            if (ts.Count == 0)
                ts.InsertLine(0, ts.CreateLine());
            else
                BreakLines(tb.Selection.Start.iLine, tb.Selection.Start.iChar, ts);

            tb.Selection.Start = new Place(0, tb.Selection.Start.iLine + 1);
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Merge lines i and i+1
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="ts">The ts.</param>
        internal static void MergeLines(int i, TextSource ts)
        {
            var tb = ts.CurrentTB;

            if (i + 1 >= ts.Count)
                return;
            tb.ExpandBlock(i);
            tb.ExpandBlock(i + 1);
            int pos = ts[i].Count;
            //
            /*
            if(ts[i].Count == 0)
                ts.RemoveLine(i);
            else*/
            if (ts[i + 1].Count == 0)
                ts.RemoveLine(i + 1);
            else
            {
                ts[i].AddRange(ts[i + 1]);
                ts.RemoveLine(i + 1);
            }
            tb.Selection.Start = new Place(pos, i);
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Breaks the lines.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <param name="pos">The position.</param>
        /// <param name="ts">The ts.</param>
        internal static void BreakLines(int iLine, int pos, TextSource ts)
        {
            Line newLine = ts.CreateLine();
            for(int i=pos;i<ts[iLine].Count;i++)
                newLine.Add(ts[iLine][i]);
            ts[iLine].RemoveRange(pos, ts[iLine].Count - pos);
            //
            ts.InsertLine(iLine+1, newLine);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new InsertCharCommand(ts, c);
        }
    }

    /// <summary>
    /// Insert text
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class InsertTextCommand : UndoableCommand
    {
        /// <summary>
        /// The inserted text
        /// </summary>
        public string InsertedText;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <param name="insertedText">Text for inserting</param>
        public InsertTextCommand(TextSource ts, string insertedText): base(ts)
        {
            this.InsertedText = insertedText;
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            ts.CurrentTB.Selection.Start = sel.Start;
            ts.CurrentTB.Selection.End = lastSel.Start;
            ts.OnTextChanging();
            ClearSelectedCommand.ClearSelected(ts);
            base.Undo();
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            ts.OnTextChanging(ref InsertedText);
            InsertText(InsertedText, ts);
            base.Execute();
        }

        /// <summary>
        /// Inserts the text.
        /// </summary>
        /// <param name="insertedText">The inserted text.</param>
        /// <param name="ts">The ts.</param>
        internal static void InsertText(string insertedText, TextSource ts)
        {
            var tb = ts.CurrentTB;
            try
            {
                tb.Selection.BeginUpdate();
                char cc = '\x0';
                
                if (ts.Count == 0)
                {
                    InsertCharCommand.InsertLine(ts);
                    tb.Selection.Start = Place.Empty;
                }
                tb.ExpandBlock(tb.Selection.Start.iLine);
                var len = insertedText.Length;
                for (int i = 0; i < len; i++)
                {
                    var c = insertedText[i];
                    if(c == '\r' && (i >= len - 1 || insertedText[i + 1] != '\n'))
                        InsertCharCommand.InsertChar('\n', ref cc, ts);
                    else
                        InsertCharCommand.InsertChar(c, ref cc, ts);
                }
                ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
            }
            finally {
                tb.Selection.EndUpdate();
            }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new InsertTextCommand(ts, InsertedText);
        }
    }

    /// <summary>
    /// Insert text into given ranges
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class ReplaceTextCommand : UndoableCommand
    {
        /// <summary>
        /// The inserted text
        /// </summary>
        string insertedText;
        /// <summary>
        /// The ranges
        /// </summary>
        List<Range> ranges;
        /// <summary>
        /// The previous text
        /// </summary>
        List<string> prevText = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <param name="ranges">List of ranges for replace</param>
        /// <param name="insertedText">Text for inserting</param>
        public ReplaceTextCommand(TextSource ts, List<Range> ranges, string insertedText)
            : base(ts)
        {
            //sort ranges by place
            ranges.Sort((r1, r2)=>
                {
                    if (r1.Start.iLine == r2.Start.iLine)
                        return r1.Start.iChar.CompareTo(r2.Start.iChar);
                    return r1.Start.iLine.CompareTo(r2.Start.iLine);
                });
            //
            this.ranges = ranges;
            this.insertedText = insertedText;
            lastSel = sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            var tb = ts.CurrentTB;

            ts.OnTextChanging();
            tb.BeginUpdate();

            tb.Selection.BeginUpdate();
            for (int i = 0; i<ranges.Count; i++)
            {
                tb.Selection.Start = ranges[i].Start;
                for (int j = 0; j < insertedText.Length; j++)
                    tb.Selection.GoRight(true);
                ClearSelected(ts);
                InsertTextCommand.InsertText(prevText[prevText.Count - i - 1], ts);
            }
            tb.Selection.EndUpdate();
            tb.EndUpdate();

            if (ranges.Count > 0)
                ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;
            prevText.Clear();

            ts.OnTextChanging(ref insertedText);

            tb.Selection.BeginUpdate();
            tb.BeginUpdate();
            for (int i = ranges.Count - 1; i >= 0; i--)
            {
                tb.Selection.Start = ranges[i].Start;
                tb.Selection.End = ranges[i].End;
                prevText.Add(tb.Selection.Text);
                ClearSelected(ts);
                if (insertedText  != "")
                    InsertTextCommand.InsertText(insertedText, ts);
            }
            if(ranges.Count > 0)
                ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
            tb.EndUpdate();
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new ReplaceTextCommand(ts, new List<Range>(ranges), insertedText);
        }

        /// <summary>
        /// Clears the selected.
        /// </summary>
        /// <param name="ts">The ts.</param>
        internal static void ClearSelected(TextSource ts)
        {
            var tb = ts.CurrentTB;

            tb.Selection.Normalize();

            Place start = tb.Selection.Start;
            Place end = tb.Selection.End;
            int fromLine = Math.Min(end.iLine, start.iLine);
            int toLine = Math.Max(end.iLine, start.iLine);
            int fromChar = tb.Selection.FromX;
            int toChar = tb.Selection.ToX;
            if (fromLine < 0) return;
            //
            if (fromLine == toLine)
                ts[fromLine].RemoveRange(fromChar, toChar - fromChar);
            else
            {
                ts[fromLine].RemoveRange(fromChar, ts[fromLine].Count - fromChar);
                ts[toLine].RemoveRange(0, toChar);
                ts.RemoveLine(fromLine + 1, toLine - fromLine - 1);
                InsertCharCommand.MergeLines(fromLine, ts);
            }
        }
    }

    /// <summary>
    /// Clear selected text
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class ClearSelectedCommand : UndoableCommand
    {
        /// <summary>
        /// The deleted text
        /// </summary>
        string deletedText;

        /// <summary>
        /// Construstor
        /// </summary>
        /// <param name="ts">The ts.</param>
        public ClearSelectedCommand(TextSource ts): base(ts)
        {
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            ts.CurrentTB.Selection.Start = new Place(sel.FromX, Math.Min(sel.Start.iLine, sel.End.iLine));
            ts.OnTextChanging();
            InsertTextCommand.InsertText(deletedText, ts);
            ts.OnTextChanged(sel.Start.iLine, sel.End.iLine);
            ts.CurrentTB.Selection.Start = sel.Start;
            ts.CurrentTB.Selection.End = sel.End;
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public override void Execute()
        {
            var tb = ts.CurrentTB;

            string temp = null;
            ts.OnTextChanging(ref temp);
            if (temp == "")
                throw new ArgumentOutOfRangeException();

            deletedText = tb.Selection.Text;
            ClearSelected(ts);
            lastSel = new RangeInfo(tb.Selection);
            ts.OnTextChanged(lastSel.Start.iLine, lastSel.Start.iLine);
        }

        /// <summary>
        /// Clears the selected.
        /// </summary>
        /// <param name="ts">The ts.</param>
        internal static void ClearSelected(TextSource ts)
        {
            var tb = ts.CurrentTB;

            Place start = tb.Selection.Start;
            Place end = tb.Selection.End;
            int fromLine = Math.Min(end.iLine, start.iLine);
            int toLine = Math.Max(end.iLine, start.iLine);
            int fromChar = tb.Selection.FromX;
            int toChar = tb.Selection.ToX;
            if (fromLine < 0) return;
            //
            if (fromLine == toLine)
                ts[fromLine].RemoveRange(fromChar, toChar - fromChar);
            else
            {
                ts[fromLine].RemoveRange(fromChar, ts[fromLine].Count - fromChar);
                ts[toLine].RemoveRange(0, toChar);
                ts.RemoveLine(fromLine + 1, toLine - fromLine - 1);
                InsertCharCommand.MergeLines(fromLine, ts);
            }
            //
            tb.Selection.Start = new Place(fromChar, fromLine);
            //
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(fromLine, toLine));
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new ClearSelectedCommand(ts);
        }
    }

    /// <summary>
    /// Replaces text
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class ReplaceMultipleTextCommand : UndoableCommand
    {
        /// <summary>
        /// The ranges
        /// </summary>
        List<ReplaceRange> ranges;
        /// <summary>
        /// The previous text
        /// </summary>
        List<string> prevText = new List<string>();

        /// <summary>
        /// Class ReplaceRange.
        /// </summary>
        public class ReplaceRange
        {
            /// <summary>
            /// Gets or sets the replaced range.
            /// </summary>
            /// <value>The replaced range.</value>
            public Range ReplacedRange { get; set; }
            /// <summary>
            /// Gets or sets the replace text.
            /// </summary>
            /// <value>The replace text.</value>
            public String ReplaceText { get; set; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">Underlaying textsource</param>
        /// <param name="ranges">List of ranges for replace</param>
        public ReplaceMultipleTextCommand(TextSource ts, List<ReplaceRange> ranges)
            : base(ts)
        {
            //sort ranges by place
            ranges.Sort((r1, r2) =>
            {
                if (r1.ReplacedRange.Start.iLine == r2.ReplacedRange.Start.iLine)
                    return r1.ReplacedRange.Start.iChar.CompareTo(r2.ReplacedRange.Start.iChar);
                return r1.ReplacedRange.Start.iLine.CompareTo(r2.ReplacedRange.Start.iLine);
            });
            //
            this.ranges = ranges;
            lastSel = sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            var tb = ts.CurrentTB;

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            for (int i = 0; i < ranges.Count; i++)
            {
                tb.Selection.Start = ranges[i].ReplacedRange.Start;
                for (int j = 0; j < ranges[i].ReplaceText.Length; j++)
                    tb.Selection.GoRight(true);
                ClearSelectedCommand.ClearSelected(ts);
                var prevTextIndex = ranges.Count - 1 - i;
                InsertTextCommand.InsertText(prevText[prevTextIndex], ts);
                ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.Start.iLine);
            }
            tb.Selection.EndUpdate();

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;
            prevText.Clear();

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            for (int i = ranges.Count - 1; i >= 0; i--)
            {
                tb.Selection.Start = ranges[i].ReplacedRange.Start;
                tb.Selection.End = ranges[i].ReplacedRange.End;
                prevText.Add(tb.Selection.Text);
                ClearSelectedCommand.ClearSelected(ts);
                InsertTextCommand.InsertText(ranges[i].ReplaceText, ts);
                ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.End.iLine);
            }
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new ReplaceMultipleTextCommand(ts, new List<ReplaceRange>(ranges));
        }
    }

    /// <summary>
    /// Removes lines
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class RemoveLinesCommand : UndoableCommand
    {
        /// <summary>
        /// The i lines
        /// </summary>
        List<int> iLines;
        /// <summary>
        /// The previous text
        /// </summary>
        List<string> prevText = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">The ts.</param>
        /// <param name="iLines">The i lines.</param>
        public RemoveLinesCommand(TextSource ts, List<int> iLines)
            : base(ts)
        {
            //sort iLines
            iLines.Sort();
            //
            this.iLines = iLines;
            lastSel = sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            var tb = ts.CurrentTB;

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            //tb.BeginUpdate();
            for (int i = 0; i < iLines.Count; i++)
            {
                var iLine = iLines[i];

                if(iLine < ts.Count)
                    tb.Selection.Start = new Place(0, iLine);
                else
                    tb.Selection.Start = new Place(ts[ts.Count - 1].Count, ts.Count - 1);

                InsertCharCommand.InsertLine(ts);
                tb.Selection.Start = new Place(0, iLine);
                var text = prevText[prevText.Count - i - 1];
                InsertTextCommand.InsertText(text, ts);
                ts[iLine].IsChanged = true;
                if (iLine < ts.Count - 1)
                    ts[iLine + 1].IsChanged = true;
                else
                    ts[iLine - 1].IsChanged = true;
                if(text.Trim() != string.Empty)
                    ts.OnTextChanged(iLine, iLine);
            }
            //tb.EndUpdate();
            tb.Selection.EndUpdate();

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;
            prevText.Clear();

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            for(int i = iLines.Count - 1; i >= 0; i--)
            {
                var iLine = iLines[i];
                
                prevText.Add(ts[iLine].Text);//backward
                ts.RemoveLine(iLine);
                //ts.OnTextChanged(ranges[i].Start.iLine, ranges[i].End.iLine);
            }
            tb.Selection.Start = new Place(0, 0);
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            return new RemoveLinesCommand(ts, new List<int>(iLines));
        }
    }

    /// <summary>
    /// Wrapper for multirange commands
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class MultiRangeCommand : UndoableCommand
    {
        /// <summary>
        /// The command
        /// </summary>
        private UndoableCommand cmd;
        /// <summary>
        /// The range
        /// </summary>
        private Range range;
        /// <summary>
        /// The commands by ranges
        /// </summary>
        private List<UndoableCommand> commandsByRanges = new List<UndoableCommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiRangeCommand"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public MultiRangeCommand(UndoableCommand command):base(command.ts)
        {
            this.cmd = command;
            range = ts.CurrentTB.Selection.Clone();
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            commandsByRanges.Clear();
            var prevSelection = range.Clone();
            var iChar = -1;
            var iStartLine = prevSelection.Start.iLine;
            var iEndLine = prevSelection.End.iLine;
            ts.CurrentTB.Selection.ColumnSelectionMode = false;
            ts.CurrentTB.Selection.BeginUpdate();
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.AllowInsertRemoveLines = false;
            try
            {
                if (cmd is InsertTextCommand)
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertTextCommand).InsertedText);
                else
                if (cmd is InsertCharCommand && (cmd as InsertCharCommand).c != '\x0' && (cmd as InsertCharCommand).c != '\b')//if not DEL or BACKSPACE
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertCharCommand).c.ToString());
                else
                    ExecuteCommand(ref iChar);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            finally
            {
                ts.CurrentTB.AllowInsertRemoveLines = true;
                ts.CurrentTB.EndUpdate();

                ts.CurrentTB.Selection = range;
                if (iChar >= 0)
                {
                    ts.CurrentTB.Selection.Start = new Place(iChar, iStartLine);
                    ts.CurrentTB.Selection.End = new Place(iChar, iEndLine);
                }
                ts.CurrentTB.Selection.ColumnSelectionMode = true;
                ts.CurrentTB.Selection.EndUpdate();
            }
        }

        /// <summary>
        /// Executes the insert text command.
        /// </summary>
        /// <param name="iChar">The i character.</param>
        /// <param name="text">The text.</param>
        private void ExecuteInsertTextCommand(ref int iChar, string text)
        {
            var lines = text.Split('\n');
            var iLine = 0;
            foreach (var r in range.GetSubRanges(true))
            {
                var line = ts.CurrentTB[r.Start.iLine];
                var lineIsEmpty = r.End < r.Start && line.StartSpacesCount == line.Count;
                if (!lineIsEmpty)
                {
                    var insertedText = lines[iLine%lines.Length];
                    if (r.End < r.Start && insertedText!="")
                    {
                        //add forwarding spaces
                        insertedText = new string(' ', r.Start.iChar - r.End.iChar) + insertedText;
                        r.Start = r.End;
                    }
                    ts.CurrentTB.Selection = r;
                    var c = new InsertTextCommand(ts, insertedText);
                    c.Execute();
                    if (ts.CurrentTB.Selection.End.iChar > iChar)
                        iChar = ts.CurrentTB.Selection.End.iChar;
                    commandsByRanges.Add(c);
                }
                iLine++;
            }
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="iChar">The i character.</param>
        private void ExecuteCommand(ref int iChar)
        {
            foreach (var r in range.GetSubRanges(false))
            {
                ts.CurrentTB.Selection = r;
                var c = cmd.Clone();
                c.Execute();
                if (ts.CurrentTB.Selection.End.iChar > iChar)
                    iChar = ts.CurrentTB.Selection.End.iChar;
                commandsByRanges.Add(c);
            }
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public override void Undo()
        {
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.Selection.BeginUpdate();
            try
            {
                for (int i = commandsByRanges.Count - 1; i >= 0; i--)
                    commandsByRanges[i].Undo();
            }
            finally
            {
                ts.CurrentTB.Selection.EndUpdate();
                ts.CurrentTB.EndUpdate();
            }
            ts.CurrentTB.Selection = range.Clone();
            ts.CurrentTB.OnTextChanged(range);
            ts.CurrentTB.OnSelectionChanged();
            ts.CurrentTB.Selection.ColumnSelectionMode = true;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override UndoableCommand Clone()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Remembers current selection and restore it after Undo
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.UndoableCommand" />
    public class SelectCommand : UndoableCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectCommand"/> class.
        /// </summary>
        /// <param name="ts">The ts.</param>
        public SelectCommand(TextSource ts):base(ts)
        {
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            //remember selection
            lastSel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="invert">if set to <c>true</c> [invert].</param>
        protected override void OnTextChanged(bool invert)
        {
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public override void Undo()
        {
            //restore selection
            ts.CurrentTB.Selection = new Range(ts.CurrentTB, lastSel.Start, lastSel.End);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public override UndoableCommand Clone()
        {
            var result = new SelectCommand(ts);
            if(lastSel!=null)
                result.lastSel = new RangeInfo(new Range(ts.CurrentTB, lastSel.Start, lastSel.End));
            return result;
        }
    }
}
