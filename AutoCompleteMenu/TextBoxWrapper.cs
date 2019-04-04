// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="TextBoxWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Wrapper over the control like TextBox.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ITextBoxWrapper" />
    public class TextBoxWrapper : ITextBoxWrapper
    {
        /// <summary>
        /// The target
        /// </summary>
        private Control target;
        /// <summary>
        /// The selection start
        /// </summary>
        private PropertyInfo selectionStart;
        /// <summary>
        /// The selection length
        /// </summary>
        private PropertyInfo selectionLength;
        /// <summary>
        /// The selected text
        /// </summary>
        private PropertyInfo selectedText;
        /// <summary>
        /// The readonly property
        /// </summary>
        private PropertyInfo readonlyProperty;
        /// <summary>
        /// The get position from character index
        /// </summary>
        private MethodInfo getPositionFromCharIndex;
        /// <summary>
        /// Occurs when [RTB scroll].
        /// </summary>
        private event ScrollEventHandler RTBScroll;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxWrapper"/> class.
        /// </summary>
        /// <param name="targetControl">The target control.</param>
        private TextBoxWrapper(Control targetControl)
        {
            this.target = targetControl;
            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected virtual void Init()
        {
            var t = target.GetType();
            selectedText = t.GetProperty("SelectedText");
            selectionLength = t.GetProperty("SelectionLength");
            selectionStart = t.GetProperty("SelectionStart");
            readonlyProperty = t.GetProperty("ReadOnly");
            getPositionFromCharIndex = t.GetMethod("GetPositionFromCharIndex") ?? t.GetMethod("PositionToPoint");

            if (target is RichTextBox)
                (target as RichTextBox).VScroll += new EventHandler(TextBoxWrapper_VScroll);
        }

        /// <summary>
        /// Handles the VScroll event of the TextBoxWrapper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void TextBoxWrapper_VScroll(object sender, EventArgs e)
        {
            if (RTBScroll != null)
                RTBScroll(sender, new ScrollEventArgs(ScrollEventType.EndScroll, 0, 1));
        }

        /// <summary>
        /// Creates the specified target control.
        /// </summary>
        /// <param name="targetControl">The target control.</param>
        /// <returns>TextBoxWrapper.</returns>
        public static TextBoxWrapper Create(Control targetControl)
        {
            var result = new TextBoxWrapper(targetControl);

            if (result.selectedText == null || result.selectionLength == null || result.selectionStart == null ||
                result.getPositionFromCharIndex == null)
                return null;

            return result;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual string Text
        {
            get { return target.Text; }
            set { target.Text = value; }
        }

        /// <summary>
        /// Gets or sets the selected text.
        /// </summary>
        /// <value>The selected text.</value>
        public virtual string SelectedText
        {
            get { return (string) selectedText.GetValue(target, null); }
            set { selectedText.SetValue(target, value, null); }
        }

        /// <summary>
        /// Gets or sets the length of the selection.
        /// </summary>
        /// <value>The length of the selection.</value>
        public virtual int SelectionLength
        {
            get { return (int) selectionLength.GetValue(target, null); }
            set { selectionLength.SetValue(target, value, null); }
        }

        /// <summary>
        /// Gets or sets the selection start.
        /// </summary>
        /// <value>The selection start.</value>
        public virtual int SelectionStart
        {
            get { return (int) selectionStart.GetValue(target, null); }
            set { selectionStart.SetValue(target, value, null); }
        }

        /// <summary>
        /// Gets the index of the position from character.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>Point.</returns>
        public virtual Point GetPositionFromCharIndex(int pos)
        {
            return (Point) getPositionFromCharIndex.Invoke(target, new object[] {pos});
        }


        /// <summary>
        /// Finds the form.
        /// </summary>
        /// <returns>System.Windows.Forms.Form.</returns>
        public virtual System.Windows.Forms.Form FindForm()
        {
            return target.FindForm();
        }

        /// <summary>
        /// Occurs when [lost focus].
        /// </summary>
        public virtual event EventHandler LostFocus
        {
            add { target.LostFocus += value; }
            remove { target.LostFocus -= value; } 
        }

        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        public virtual event ScrollEventHandler Scroll 
        {
            add { 
                if(target is RichTextBox)
                    RTBScroll += value;
                else
                    if(target is ScrollableControl)(target as ScrollableControl).Scroll += value;

            }
            remove {
                if (target is RichTextBox)
                    RTBScroll -= value;
                else
                    if(target is ScrollableControl)(target as ScrollableControl).Scroll -= value;
            }
        }

        /// <summary>
        /// Occurs when [key down].
        /// </summary>
        public virtual event KeyEventHandler KeyDown
        {
            add { target.KeyDown += value; }
            remove { target.KeyDown -= value; }
        }

        /// <summary>
        /// Occurs when [mouse down].
        /// </summary>
        public virtual event MouseEventHandler MouseDown 
        {
            add { target.MouseDown += value; }
            remove { target.MouseDown -= value; } 
        }

        /// <summary>
        /// Gets the target control.
        /// </summary>
        /// <value>The target control.</value>
        public virtual Control TargetControl
        {
            get { return target; }
        }


        /// <summary>
        /// Gets a value indicating whether this <see cref="ITextBoxWrapper" /> is readonly.
        /// </summary>
        /// <value><c>true</c> if readonly; otherwise, <c>false</c>.</value>
        public bool Readonly
        {
            get { return (bool) readonlyProperty.GetValue(target, null);  }
        }
    }
}
