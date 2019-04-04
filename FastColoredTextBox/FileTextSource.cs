// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="FileTextSource.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// This class contains the source text (chars and styles).
    /// It stores a text lines, the manager of commands, undo/redo stack, styles.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.TextSource" />
    /// <seealso cref="System.IDisposable" />
    public class FileTextSource : TextSource, IDisposable
    {
        /// <summary>
        /// The source file line positions
        /// </summary>
        List<int> sourceFileLinePositions = new List<int>();
        /// <summary>
        /// The fs
        /// </summary>
        FileStream fs;
        /// <summary>
        /// The file encoding
        /// </summary>
        Encoding fileEncoding;
        /// <summary>
        /// The timer
        /// </summary>
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Occurs when need to display line in the textbox
        /// </summary>
        public event EventHandler<LineNeededEventArgs> LineNeeded;

        /// <summary>
        /// Occurs when need to save line in the file
        /// </summary>
        public event EventHandler<LinePushedEventArgs> LinePushed;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTextSource"/> class.
        /// </summary>
        /// <param name="currentTB">The current tb.</param>
        public FileTextSource(ZeroitCodeTextBox currentTB)
            : base(currentTB)
        {
            timer.Interval = 10000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;

            SaveEOL = Environment.NewLine;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            try
            {
                UnloadUnusedLines();
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        /// <summary>
        /// Unloads the unused lines.
        /// </summary>
        private void UnloadUnusedLines()
        {
            const int margin = 2000;
            var iStartVisibleLine = CurrentTB.VisibleRange.Start.iLine;
            var iFinishVisibleLine = CurrentTB.VisibleRange.End.iLine;

            int count = 0;
            for (int i = 0; i < Count; i++)
                if (base.lines[i] != null && !base.lines[i].IsChanged && Math.Abs(i - iFinishVisibleLine) > margin)
                {
                    base.lines[i] = null;
                    count++;
                }
            #if debug
            Console.WriteLine("UnloadUnusedLines: " + count);
            #endif
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="enc">The enc.</param>
        public void OpenFile(string fileName, Encoding enc)
        {
            Clear();

            if (fs != null)
                fs.Dispose();

            SaveEOL = Environment.NewLine;

            //read lines of file
            fs = new FileStream(fileName, FileMode.Open);
            var length = fs.Length;
            //read signature
            enc = DefineEncoding(enc, fs);
            int shift = DefineShift(enc);
            //first line
            sourceFileLinePositions.Add((int)fs.Position);
            base.lines.Add(null);
            //other lines
            sourceFileLinePositions.Capacity = (int)(length/7 + 1000);

            //int prev = 0;
            //while(fs.Position < length)
            //{
            //    var b = fs.ReadByte();

            //    if (b == 10)// \n
            //    {
            //        sourceFileLinePositions.Add((int)(fs.Position) + shift);
            //        base.lines.Add(null);
            //    }else
            //    if (prev == 13)// \r (Mac format)
            //    {
            //        sourceFileLinePositions.Add((int)(fs.Position - 1) + shift);
            //        base.lines.Add(null);
            //        SaveEOL = "\r";
            //    }

            //    prev = b;
            //}

            //if (prev == 13)
            //{
            //    sourceFileLinePositions.Add((int)(fs.Position) + shift);
            //    base.lines.Add(null);
            //}

            int prev = 0;
            int prevPos = 0;
            BinaryReader br = new BinaryReader(fs, enc);
            while (fs.Position < length)
            {
                prevPos = (int)fs.Position;
                var b = br.ReadChar();

                if (b == 10)// \n
                {
                    sourceFileLinePositions.Add((int)fs.Position);
                    base.lines.Add(null);
                }
                else
                if (prev == 13)// \r (Mac format)
                {
                    sourceFileLinePositions.Add((int)prevPos);
                    base.lines.Add(null);
                    SaveEOL = "\r";
                }

                prev = b;
            }

            if (prev == 13)
            {
                sourceFileLinePositions.Add((int)prevPos);
                base.lines.Add(null);
            }

            if(length > 2000000)
                GC.Collect();

            Line[] temp = new Line[100];

            var c = base.lines.Count;
            base.lines.AddRange(temp);
            base.lines.TrimExcess();
            base.lines.RemoveRange(c, temp.Length);


            int[] temp2 = new int[100];
            c = base.lines.Count;
            sourceFileLinePositions.AddRange(temp2);
            sourceFileLinePositions.TrimExcess();
            sourceFileLinePositions.RemoveRange(c, temp.Length);
            

            fileEncoding = enc;

            OnLineInserted(0, Count);
            //load first lines for calc width of the text
            var linesCount = Math.Min(lines.Count, CurrentTB.ClientRectangle.Height/CurrentTB.CharHeight);
            for (int i = 0; i < linesCount; i++)
                LoadLineFromSourceFile(i);
            //
            NeedRecalc(new TextChangedEventArgs(0, linesCount - 1));
            if (CurrentTB.WordWrap)
                OnRecalcWordWrap(new TextChangedEventArgs(0, linesCount - 1));
        }

        /// <summary>
        /// Defines the shift.
        /// </summary>
        /// <param name="enc">The enc.</param>
        /// <returns>System.Int32.</returns>
        private int DefineShift(Encoding enc)
        {
            if (enc.IsSingleByte)
                return 0;

            if (enc.HeaderName == "unicodeFFFE")
                return 0;//UTF16 BE

            if (enc.HeaderName == "utf-16")
                return 1;//UTF16 LE

            if (enc.HeaderName == "utf-32BE")
                return 0;//UTF32 BE

            if (enc.HeaderName == "utf-32")
                return 3;//UTF32 LE

            return 0;
        }

        /// <summary>
        /// Defines the encoding.
        /// </summary>
        /// <param name="enc">The enc.</param>
        /// <param name="fs">The fs.</param>
        /// <returns>Encoding.</returns>
        private static Encoding DefineEncoding(Encoding enc, FileStream fs)
        {
            int bytesPerSignature = 0;
            byte[] signature = new byte[4];
            int c = fs.Read(signature, 0, 4);
            if (signature[0] == 0xFF && signature[1] == 0xFE && signature[2] == 0x00 && signature[3] == 0x00 && c >= 4)
            {
                enc = Encoding.UTF32;//UTF32 LE
                bytesPerSignature = 4;
            }
            else
            if (signature[0] == 0x00 && signature[1] == 0x00 && signature[2] == 0xFE && signature[3] == 0xFF)
            {
                enc = new UTF32Encoding(true, true);//UTF32 BE
                bytesPerSignature = 4;
            }
            else
            if (signature[0] == 0xEF && signature[1] == 0xBB && signature[2] == 0xBF)
            {
                enc = Encoding.UTF8;//UTF8
                bytesPerSignature = 3;
            }
            else
            if (signature[0] == 0xFE && signature[1] == 0xFF)
            {
                enc = Encoding.BigEndianUnicode;//UTF16 BE
                bytesPerSignature = 2;
            }
            else
            if (signature[0] == 0xFF && signature[1] == 0xFE)
            {
                enc = Encoding.Unicode;//UTF16 LE
                bytesPerSignature = 2;
            }

            fs.Seek(bytesPerSignature, SeekOrigin.Begin);

            return enc;
        }

        /// <summary>
        /// Closes the file.
        /// </summary>
        public void CloseFile()
        {
            if(fs!=null)
                try
                {
                    fs.Dispose();
                }
                catch
                {
                    ;
                }
            fs = null;
        }

        /// <summary>
        /// End Of Line characters used for saving
        /// </summary>
        /// <value>The save eol.</value>
        public string SaveEOL { get; set; }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="enc">The enc.</param>
        public override void SaveToFile(string fileName, Encoding enc)
        {
            //
            var newLinePos = new List<int>(Count);
            //create temp file
            var dir = Path.GetDirectoryName(fileName);
            var tempFileName = Path.Combine(dir, Path.GetFileNameWithoutExtension(fileName) + ".tmp");

            StreamReader sr = new StreamReader(fs, fileEncoding);
            using (FileStream tempFs = new FileStream(tempFileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(tempFs, enc))
            {
                sw.Flush();

                for (int i = 0; i < Count; i++)
                {
                    newLinePos.Add((int)tempFs.Length);

                    var sourceLine = ReadLine(sr, i);//read line from source file
                    string line;

                    bool lineIsChanged = lines[i] != null && lines[i].IsChanged;

                    if (lineIsChanged)
                        line = lines[i].Text;
                    else
                        line = sourceLine;

                    //call event handler
                    if (LinePushed != null)
                    {
                        var args = new LinePushedEventArgs(sourceLine, i, lineIsChanged ? line : null);
                        LinePushed(this, args);

                        if(args.SavedText != null)
                            line = args.SavedText;
                    }

                    //save line to file
                    sw.Write(line);

                    if (i < Count - 1)
                        sw.Write(SaveEOL);

                    sw.Flush();
                }
            }

            //clear lines buffer
            for (int i = 0; i < Count; i++)
                lines[i] = null;
            //deattach from source file
            sr.Dispose();
            fs.Dispose();
            //delete target file
            if (File.Exists(fileName))
                File.Delete(fileName);
            //rename temp file
            File.Move(tempFileName, fileName);

            //binding to new file
            sourceFileLinePositions = newLinePos;
            fs = new FileStream(fileName, FileMode.Open);
            this.fileEncoding = enc;
        }

        /// <summary>
        /// Reads the line.
        /// </summary>
        /// <param name="sr">The sr.</param>
        /// <param name="i">The i.</param>
        /// <returns>System.String.</returns>
        private string ReadLine(StreamReader sr, int i)
        {
            string line;
            var filePos = sourceFileLinePositions[i];
            if (filePos < 0)
                return "";
            fs.Seek(filePos, SeekOrigin.Begin);
            sr.DiscardBufferedData();
            line = sr.ReadLine();
            return line;
        }

        /// <summary>
        /// Clears the is changed.
        /// </summary>
        public override void ClearIsChanged()
        {
            foreach (var line in lines)
                if(line!=null)
                    line.IsChanged = false;
        }

        /// <summary>
        /// Gets or sets the <see cref="Line"/> with the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Line.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Line this[int i]
        {
            get 
            {
                if (base.lines[i] != null)
                    return lines[i];
                else
                    LoadLineFromSourceFile(i);

                return lines[i];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Loads the line from source file.
        /// </summary>
        /// <param name="i">The i.</param>
        private void LoadLineFromSourceFile(int i)
        {
            var line = CreateLine();
            fs.Seek(sourceFileLinePositions[i], SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs, fileEncoding);

            var s = sr.ReadLine();
            if (s == null)
                s = "";

            //call event handler
            if(LineNeeded!=null)
            {
                var args = new LineNeededEventArgs(s, i);
                LineNeeded(this, args);
                s = args.DisplayedLineText;
                if (s == null)
                    return;
            }

            foreach (var c in s)
                line.Add(new Char(c));
            base.lines[i] = line;

            if (CurrentTB.WordWrap)
                OnRecalcWordWrap(new TextChangedEventArgs(i, i));
        }

        /// <summary>
        /// Inserts the line.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="line">The line.</param>
        public override void InsertLine(int index, Line line)
        {
            sourceFileLinePositions.Insert(index, -1);
            base.InsertLine(index, line);
        }

        /// <summary>
        /// Removes the line.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public override void RemoveLine(int index, int count)
        {
            sourceFileLinePositions.RemoveRange(index, count);
            base.RemoveLine(index, count);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// Gets the length of the line.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>System.Int32.</returns>
        public override int GetLineLength(int i)
        {
            if (base.lines[i] == null)
                return 0;
            else
                return base.lines[i].Count;
        }

        /// <summary>
        /// Lines the has folding start marker.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool LineHasFoldingStartMarker(int iLine)
        {
            if (lines[iLine] == null)
                return false;
            else
                return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
        }

        /// <summary>
        /// Lines the has folding end marker.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool LineHasFoldingEndMarker(int iLine)
        {
            if (lines[iLine] == null)
                return false;
            else
                return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            if (fs != null)
                fs.Dispose();

            timer.Dispose();
        }

        /// <summary>
        /// Unloads the line.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        internal void UnloadLine(int iLine)
        {
            if (lines[iLine] != null && !lines[iLine].IsChanged)
                lines[iLine] = null;
        }
    }

    /// <summary>
    /// Class LineNeededEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class LineNeededEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the source line text.
        /// </summary>
        /// <value>The source line text.</value>
        public string SourceLineText { get; private set; }
        /// <summary>
        /// Gets the index of the displayed line.
        /// </summary>
        /// <value>The index of the displayed line.</value>
        public int DisplayedLineIndex { get; private set; }
        /// <summary>
        /// This text will be displayed in textbox
        /// </summary>
        /// <value>The displayed line text.</value>
        public string DisplayedLineText { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineNeededEventArgs"/> class.
        /// </summary>
        /// <param name="sourceLineText">The source line text.</param>
        /// <param name="displayedLineIndex">Index of the displayed line.</param>
        public LineNeededEventArgs(string sourceLineText, int displayedLineIndex)
        {
            this.SourceLineText = sourceLineText;
            this.DisplayedLineIndex = displayedLineIndex;
            this.DisplayedLineText = sourceLineText;
        }
    }

    /// <summary>
    /// Class LinePushedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class LinePushedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the source line text.
        /// </summary>
        /// <value>The source line text.</value>
        public string SourceLineText { get; private set; }
        /// <summary>
        /// Gets the index of the displayed line.
        /// </summary>
        /// <value>The index of the displayed line.</value>
        public int DisplayedLineIndex { get; private set; }
        /// <summary>
        /// This property contains only changed text.
        /// If text of line is not changed, this property contains null.
        /// </summary>
        /// <value>The displayed line text.</value>
        public string DisplayedLineText { get; private set; }
        /// <summary>
        /// This text will be saved in the file
        /// </summary>
        /// <value>The saved text.</value>
        public string SavedText { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinePushedEventArgs"/> class.
        /// </summary>
        /// <param name="sourceLineText">The source line text.</param>
        /// <param name="displayedLineIndex">Index of the displayed line.</param>
        /// <param name="displayedLineText">The displayed line text.</param>
        public LinePushedEventArgs(string sourceLineText, int displayedLineIndex, string displayedLineText)
        {
            this.SourceLineText = sourceLineText;
            this.DisplayedLineIndex = displayedLineIndex;
            this.DisplayedLineText = displayedLineText;
            this.SavedText = displayedLineText;
        }
    }

    /// <summary>
    /// Class CharReader.
    /// </summary>
    /// <seealso cref="System.IO.TextReader" />
    class CharReader : TextReader
    {
        /// <summary>
        /// Reads the next character from the text reader and advances the character position by one character.
        /// </summary>
        /// <returns>The next character from the text reader, or -1 if no more characters are available. The default implementation returns -1.</returns>
        public override int Read()
        {
            return base.Read();
        }
    }
}
