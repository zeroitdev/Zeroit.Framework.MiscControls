// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="CommandManager.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class CommandManager.
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// The maximum history length
        /// </summary>
        readonly int maxHistoryLength = 200;
        /// <summary>
        /// The history
        /// </summary>
        LimitedStack<UndoableCommand> history;
        /// <summary>
        /// The redo stack
        /// </summary>
        Stack<UndoableCommand> redoStack = new Stack<UndoableCommand>();
        /// <summary>
        /// Gets the text source.
        /// </summary>
        /// <value>The text source.</value>
        public TextSource TextSource{ get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether [undo redo stack is enabled].
        /// </summary>
        /// <value><c>true</c> if [undo redo stack is enabled]; otherwise, <c>false</c>.</value>
        public bool UndoRedoStackIsEnabled { get; set; }

        /// <summary>
        /// Occurs when [redo completed].
        /// </summary>
        public event EventHandler RedoCompleted = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandManager"/> class.
        /// </summary>
        /// <param name="ts">The ts.</param>
        public CommandManager(TextSource ts)
        {
            history = new LimitedStack<UndoableCommand>(maxHistoryLength);
            TextSource = ts;
            UndoRedoStackIsEnabled = true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        public virtual void ExecuteCommand(Command cmd)
        {
            if (disabledCommands > 0)
                return;

            //multirange ?
            if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode)
            if (cmd is UndoableCommand)
                //make wrapper
                cmd = new MultiRangeCommand((UndoableCommand)cmd);


            if (cmd is UndoableCommand)
            {
                //if range is ColumnRange, then create wrapper
                (cmd as UndoableCommand).autoUndo = autoUndoCommands > 0;
                history.Push(cmd as UndoableCommand);
            }

            try
            {
                cmd.Execute();
            }
            catch (ArgumentOutOfRangeException)
            {
                //OnTextChanging cancels enter of the text
                if (cmd is UndoableCommand)
                    history.Pop();
            }
            //
            if (!UndoRedoStackIsEnabled)
                ClearHistory();
            //
            redoStack.Clear();
            //
            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public void Undo()
        {
            if (history.Count > 0)
            {
                var cmd = history.Pop();
                //
                BeginDisableCommands();//prevent text changing into handlers
                try
                {
                    cmd.Undo();
                }
                finally
                {
                    EndDisableCommands();
                }
                //
                redoStack.Push(cmd);
            }

            //undo next autoUndo command
            if (history.Count > 0)
            {
                if (history.Peek().autoUndo)
                    Undo();
            }

            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        /// <summary>
        /// The disabled commands
        /// </summary>
        protected int disabledCommands = 0;

        /// <summary>
        /// Ends the disable commands.
        /// </summary>
        private void EndDisableCommands()
        {
            disabledCommands--;
        }

        /// <summary>
        /// Begins the disable commands.
        /// </summary>
        private void BeginDisableCommands()
        {
            disabledCommands++;
        }

        /// <summary>
        /// The automatic undo commands
        /// </summary>
        int autoUndoCommands = 0;

        /// <summary>
        /// Ends the automatic undo commands.
        /// </summary>
        public void EndAutoUndoCommands()
        {
            autoUndoCommands--;
            if (autoUndoCommands == 0)
                if (history.Count > 0)
                    history.Peek().autoUndo = false;
        }

        /// <summary>
        /// Begins the automatic undo commands.
        /// </summary>
        public void BeginAutoUndoCommands()
        {
            autoUndoCommands++;
        }

        /// <summary>
        /// Clears the history.
        /// </summary>
        internal void ClearHistory()
        {
            history.Clear();
            redoStack.Clear();
            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        internal void Redo()
        {
            if (redoStack.Count == 0)
                return;
            UndoableCommand cmd;
            BeginDisableCommands();//prevent text changing into handlers
            try
            {
                cmd = redoStack.Pop();
                if (TextSource.CurrentTB.Selection.ColumnSelectionMode)
                    TextSource.CurrentTB.Selection.ColumnSelectionMode = false;
                TextSource.CurrentTB.Selection.Start = cmd.sel.Start;
                TextSource.CurrentTB.Selection.End = cmd.sel.End;
                cmd.Execute();
                history.Push(cmd);
            }
            finally
            {
                EndDisableCommands();
            }

            //call event
            RedoCompleted(this, EventArgs.Empty);

            //redo command after autoUndoable command
            if (cmd.autoUndo)
                Redo();

            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        /// <summary>
        /// Gets a value indicating whether [undo enabled].
        /// </summary>
        /// <value><c>true</c> if [undo enabled]; otherwise, <c>false</c>.</value>
        public bool UndoEnabled 
        { 
            get
            {
                return history.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [redo enabled].
        /// </summary>
        /// <value><c>true</c> if [redo enabled]; otherwise, <c>false</c>.</value>
        public bool RedoEnabled
        {
            get
            {
                return redoStack.Count > 0;
            }
        }
    }

    /// <summary>
    /// Class Command.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The ts
        /// </summary>
        public TextSource ts;
        /// <summary>
        /// Executes this instance.
        /// </summary>
        public abstract void Execute();
    }

    /// <summary>
    /// Class RangeInfo.
    /// </summary>
    internal class RangeInfo
    {
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public Place Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public Place End { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeInfo"/> class.
        /// </summary>
        /// <param name="r">The r.</param>
        public RangeInfo(Range r)
        {
            Start = r.Start;
            End = r.End;
        }

        /// <summary>
        /// Gets from x.
        /// </summary>
        /// <value>From x.</value>
        internal int FromX
        {
            get
            {
                if (End.iLine < Start.iLine) return End.iChar;
                if (End.iLine > Start.iLine) return Start.iChar;
                return Math.Min(End.iChar, Start.iChar);
            }
        }
    }

    /// <summary>
    /// Class UndoableCommand.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Command" />
    public abstract class UndoableCommand : Command
    {
        /// <summary>
        /// The sel
        /// </summary>
        internal RangeInfo sel;
        /// <summary>
        /// The last sel
        /// </summary>
        internal RangeInfo lastSel;
        /// <summary>
        /// The automatic undo
        /// </summary>
        internal bool autoUndo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoableCommand"/> class.
        /// </summary>
        /// <param name="ts">The ts.</param>
        public UndoableCommand(TextSource ts)
        {
            this.ts = ts;
            sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public virtual void Undo()
        {
            OnTextChanged(true);
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            lastSel = new RangeInfo(ts.CurrentTB.Selection);
            OnTextChanged(false);
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="invert">if set to <c>true</c> [invert].</param>
        protected virtual void OnTextChanged(bool invert)
        {
            bool b = sel.Start.iLine < lastSel.Start.iLine;
            if (invert)
            {
                if (b)
                    ts.OnTextChanged(sel.Start.iLine, sel.Start.iLine);
                else
                    ts.OnTextChanged(sel.Start.iLine, lastSel.Start.iLine);
            }
            else
            {
                if (b)
                    ts.OnTextChanged(sel.Start.iLine, lastSel.Start.iLine);
                else
                    ts.OnTextChanged(lastSel.Start.iLine, lastSel.Start.iLine);
            }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>UndoableCommand.</returns>
        public abstract UndoableCommand Clone();
    }
}