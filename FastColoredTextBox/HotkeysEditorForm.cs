// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HotkeysEditorForm.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class HotkeysEditorForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class HotkeysEditorForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// The wrappers
        /// </summary>
        BindingList<HotkeyWrapper> wrappers = new BindingList<HotkeyWrapper>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeysEditorForm"/> class.
        /// </summary>
        /// <param name="hotkeys">The hotkeys.</param>
        public HotkeysEditorForm(HotkeysMapping hotkeys)
        {
            InitializeComponent();
            BuildWrappers(hotkeys);
            dgv.DataSource = wrappers;
        }

        /// <summary>
        /// Comperes the keys.
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="key2">The key2.</param>
        /// <returns>System.Int32.</returns>
        int CompereKeys(Keys key1, Keys key2)
        {
            var res = ((int)key1 & 0xff).CompareTo((int)key2 & 0xff);
            if (res == 0)
                res = key1.CompareTo(key2);

            return res;
        }

        /// <summary>
        /// Builds the wrappers.
        /// </summary>
        /// <param name="hotkeys">The hotkeys.</param>
        private void BuildWrappers(HotkeysMapping hotkeys)
        {
            var keys = new List<Keys>(hotkeys.Keys);
            keys.Sort(CompereKeys);

            wrappers.Clear();
            foreach (var k in keys)
                wrappers.Add(new HotkeyWrapper(k, hotkeys[k]));
        }

        /// <summary>
        /// Returns edited hotkey map
        /// </summary>
        /// <returns>HotkeysMapping.</returns>
        public HotkeysMapping GetHotkeys()
        {
            var result = new HotkeysMapping();
            foreach (var w in wrappers)
                result[w.ToKeyData()] = w.Action;

            return result;
        }

        /// <summary>
        /// Handles the Click event of the btAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btAdd_Click(object sender, EventArgs e)
        {
            wrappers.Add(new HotkeyWrapper(Keys.None, FCTBAction.None));
        }

        /// <summary>
        /// Handles the RowsAdded event of the dgv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowsAddedEventArgs"/> instance containing the event data.</param>
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var cell = (dgv[0, e.RowIndex] as DataGridViewComboBoxCell);
            if(cell.Items.Count == 0)
            foreach(var item in new string[]{"", "Ctrl", "Ctrl + Shift", "Ctrl + Alt", "Shift", "Shift + Alt", "Alt", "Ctrl + Shift + Alt"})
                cell.Items.Add(item);

            cell = (dgv[1, e.RowIndex] as DataGridViewComboBoxCell);
            if (cell.Items.Count == 0)
            foreach (var item in Enum.GetValues(typeof(Keys)))
                cell.Items.Add(item);

            cell = (dgv[2, e.RowIndex] as DataGridViewComboBoxCell);
            if (cell.Items.Count == 0)
            foreach (var item in Enum.GetValues(typeof(FCTBAction)))
                cell.Items.Add(item);
        }

        /// <summary>
        /// Handles the Click event of the btResore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btResore_Click(object sender, EventArgs e)
        {
            HotkeysMapping h = new HotkeysMapping();
            h.InitDefault();
            BuildWrappers(h);
        }

        /// <summary>
        /// Handles the Click event of the btRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btRemove_Click(object sender, EventArgs e)
        {
            for (int i = dgv.RowCount - 1; i >= 0; i--)
                if (dgv.Rows[i].Selected) dgv.Rows.RemoveAt(i);
        }

        /// <summary>
        /// Handles the FormClosing event of the HotkeysEditorForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void HotkeysEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var actions = GetUnAssignedActions();
                if (!string.IsNullOrEmpty(actions))
                {
                    if (MessageBox.Show("Some actions are not assigned!\r\nActions: " + actions + "\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Gets the un assigned actions.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetUnAssignedActions()
        {
            StringBuilder sb = new StringBuilder();
            var dic = new Dictionary<FCTBAction, FCTBAction>();

            foreach (var w in wrappers)
                dic[w.Action] = w.Action;

            foreach (var item in Enum.GetValues(typeof(FCTBAction)))
            if ((FCTBAction)item != FCTBAction.None)
            if(!((FCTBAction)item).ToString().StartsWith("CustomAction"))
            {
                if(!dic.ContainsKey((FCTBAction)item))
                    sb.Append(item+", ");
            }

            return sb.ToString().TrimEnd(' ', ',');
        }
    }

    /// <summary>
    /// Class HotkeyWrapper.
    /// </summary>
    internal class HotkeyWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyWrapper"/> class.
        /// </summary>
        /// <param name="keyData">The key data.</param>
        /// <param name="action">The action.</param>
        public HotkeyWrapper(Keys keyData, FCTBAction action)
        {
            KeyEventArgs a = new KeyEventArgs(keyData);
            Ctrl = a.Control;
            Shift = a.Shift;
            Alt = a.Alt;

            Key = a.KeyCode;
            Action = action;
        }

        /// <summary>
        /// To the key data.
        /// </summary>
        /// <returns>Keys.</returns>
        public Keys ToKeyData()
        {
            var res = Key;
            if (Ctrl) res |= Keys.Control;
            if (Alt) res |= Keys.Alt;
            if (Shift) res |= Keys.Shift;

            return res;
        }

        /// <summary>
        /// The control
        /// </summary>
        bool Ctrl;
        /// <summary>
        /// The shift
        /// </summary>
        bool Shift;
        /// <summary>
        /// The alt
        /// </summary>
        bool Alt;

        /// <summary>
        /// Gets or sets the modifiers.
        /// </summary>
        /// <value>The modifiers.</value>
        public string Modifiers
        {
            get
            {
                var res = "";
                if (Ctrl) res += "Ctrl + ";
                if (Shift) res += "Shift + ";
                if (Alt) res += "Alt + ";

                return res.Trim(' ', '+');
            }
            set
            {
                if (value == null)
                {
                    Ctrl = Alt = Shift = false;
                }
                else
                {
                    Ctrl = value.Contains("Ctrl");
                    Shift = value.Contains("Shift");
                    Alt = value.Contains("Alt");
                }
            }
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public Keys Key { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public FCTBAction Action { get; set; }
    }
}
