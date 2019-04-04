// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="MacrosManager.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// This class records, stores and executes the macros.
    /// </summary>
    public class MacrosManager
    {
        /// <summary>
        /// The macro
        /// </summary>
        private readonly List<object> macro = new List<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MacrosManager"/> class.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        internal MacrosManager(ZeroitCodeTextBox ctrl)
        {
            UnderlayingControl = ctrl;
            AllowMacroRecordingByUser = true;
        }

        /// <summary>
        /// Allows to user to record macros
        /// </summary>
        /// <value><c>true</c> if [allow macro recording by user]; otherwise, <c>false</c>.</value>
        public bool AllowMacroRecordingByUser { get;set; }

        /// <summary>
        /// The is recording
        /// </summary>
        private bool isRecording;

        /// <summary>
        /// Returns current recording state. Set to True/False to start/stop recording programmatically.
        /// </summary>
        /// <value><c>true</c> if this instance is recording; otherwise, <c>false</c>.</value>
        public bool IsRecording
        {
            get { return isRecording; }
            set { isRecording = value; UnderlayingControl.Invalidate(); }
        }

        /// <summary>
        /// FCTB
        /// </summary>
        /// <value>The underlaying control.</value>
        public ZeroitCodeTextBox UnderlayingControl { get; private set; }

        /// <summary>
        /// Executes recorded macro
        /// </summary>
        public void ExecuteMacros()
        {
            IsRecording = false;
            UnderlayingControl.BeginUpdate();
            UnderlayingControl.Selection.BeginUpdate();
            UnderlayingControl.BeginAutoUndo();
            foreach (var item in macro)
            {
                if (item is Keys)
                {
                    UnderlayingControl.ProcessKey((Keys)item);
                }
                if (item is KeyValuePair<char, Keys>)
                {
                    var p = (KeyValuePair<char, Keys>)item;
                    UnderlayingControl.ProcessKey(p.Key, p.Value);
                }
                
            }
            UnderlayingControl.EndAutoUndo();
            UnderlayingControl.Selection.EndUpdate();
            UnderlayingControl.EndUpdate();
        }

        /// <summary>
        /// Adds the char to current macro
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="modifiers">The modifiers.</param>
        public void AddCharToMacros(char c, Keys modifiers)
        {
            macro.Add(new KeyValuePair<char, Keys>(c, modifiers));
        }

        /// <summary>
        /// Adds keyboard key to current macro
        /// </summary>
        /// <param name="keyData">The key data.</param>
        public void AddKeyToMacros(Keys keyData)
        {
            macro.Add(keyData);
        }

        /// <summary>
        /// Clears last recorded macro
        /// </summary>
        public void ClearMacros()
        {
            macro.Clear();
        }


        /// <summary>
        /// Processes the key.
        /// </summary>
        /// <param name="keyData">The key data.</param>
        internal void ProcessKey(Keys keyData)
        {
            if (IsRecording)
                AddKeyToMacros(keyData);
        }

        /// <summary>
        /// Processes the key.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="modifiers">The modifiers.</param>
        internal void ProcessKey(char c, Keys modifiers)
        {
            if (IsRecording)
                AddCharToMacros(c, modifiers);
        }

        /// <summary>
        /// Returns True if last macro is empty
        /// </summary>
        /// <value><c>true</c> if [macro is empty]; otherwise, <c>false</c>.</value>
        public bool MacroIsEmpty { get { return macro.Count == 0; }}

        /// <summary>
        /// Macros as string.
        /// </summary>
        /// <value>The macros.</value>
        public string Macros
        {
            get
            {
                var cult = Thread.CurrentThread.CurrentUICulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                var kc = new KeysConverter();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<macros>");
                foreach (var item in macro)
                {
                    if (item is Keys)
                    {
                        sb.AppendFormat("<item key='{0}' />\r\n", kc.ConvertToString((Keys)item));
                    }
                    else if (item is KeyValuePair<char, Keys>)
                    {
                        var p = (KeyValuePair<char, Keys>)item;
                        sb.AppendFormat("<item char='{0}' key='{1}' />\r\n", (int)p.Key, kc.ConvertToString(p.Value));
                    }
                }
                sb.AppendLine("</macros>");

                Thread.CurrentThread.CurrentUICulture = cult;

                return sb.ToString();
            }

            set 
            {
                isRecording = false;
                ClearMacros();

                if (string.IsNullOrEmpty(value))
                    return;

                var doc = new XmlDocument();
                doc.LoadXml(value);
                var list = doc.SelectNodes("./macros/item");

                var cult = Thread.CurrentThread.CurrentUICulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                var kc = new KeysConverter();

                if(list != null)
                foreach (XmlElement node in list)
                {
                    var ca = node.GetAttributeNode("char");
                    var ka = node.GetAttributeNode("key");
                    if (ca != null)
                    {
                        if(ka!=null)
                            AddCharToMacros((char)int.Parse(ca.Value), (Keys)kc.ConvertFromString(ka.Value));
                        else
                            AddCharToMacros((char)int.Parse(ca.Value), Keys.None);
                    }else
                    if(ka!=null)
                            AddKeyToMacros((Keys)kc.ConvertFromString(ka.Value));
                }

                Thread.CurrentThread.CurrentUICulture = cult;
            }
        }
    }
}