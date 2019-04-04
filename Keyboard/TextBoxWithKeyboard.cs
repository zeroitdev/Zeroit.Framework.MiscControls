// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TextBoxWithKeyboard.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Text Keyboard

    /// <summary>
    /// A class collection for rendering a textbox with a keyboard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TextBox" />
    public class ZeroitTextKeyboard : TextBox
    {
        /// <summary>
        /// The number form width
        /// </summary>
        private const int numFormWidth = 200; // width of the form with Numeric keyboard
        /// <summary>
        /// The number form height
        /// </summary>
        private const int numFormHeight = 180;// height of the form with Numeric keyboard

        /// <summary>
        /// The FRM kb name
        /// </summary>
        private const string frmKbName = "OnScreenKeyboardForm";
        /// <summary>
        /// The kb control name
        /// </summary>
        private const string kbControlName = "virtualKeyboard";

        /// <summary>
        /// The kf
        /// </summary>
        private static KeyboardFilter kf = null;
        /// <summary>
        /// The is shown
        /// </summary>
        private bool isShown = false;
        /// <summary>
        /// The is caps lock
        /// </summary>
        private bool isCapsLock = false;
        /// <summary>
        /// The is number lock
        /// </summary>
        private bool isNumLock = false;
        /// <summary>
        /// The is alt
        /// </summary>
        private bool isAlt = false;
        /// <summary>
        /// The is shift
        /// </summary>
        private bool isShift = false;
        /// <summary>
        /// The is control
        /// </summary>
        private bool isCtrl = false;

        /// <summary>
        /// The location point
        /// </summary>
        Point locationPoint;

        /// <summary>
        /// Checks If the keyboard Is Numeric
        /// </summary>
        /// <value><c>true</c> if this instance is numeric; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("TextBox with Virtual Keyboard"), Description("Checks If the keyboard Is Numeric")]
        public bool IsNumeric
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTextKeyboard" /> class.
        /// </summary>
        public ZeroitTextKeyboard()
        {
            if (kf == null)
            {
                kf = new KeyboardFilter();
                Application.AddMessageFilter(kf);
            }
            kf.MouseDown += kf_MouseDown;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            ToggleForm();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.PreviewKeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PreviewKeyDownEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Focus();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

        }



        /// <summary>
        /// Gets a value indicating whether [form visible].
        /// </summary>
        /// <value><c>true</c> if [form visible]; otherwise, <c>false</c>.</value>
        private bool FormVisible
        {
            get
            {
                var f = FindKeyboardForm();
                if (f != null)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Finds the keyboard form.
        /// </summary>
        /// <returns>System.Windows.Forms.Form.</returns>
        private System.Windows.Forms.Form FindKeyboardForm()
        {
            var formName = frmKbName;

            FormCollection fc = Application.OpenForms;
            foreach (System.Windows.Forms.Form frm in fc)
            {
                if (frm.Name == formName)
                {
                    return frm;
                    break;
                }
            }

            return null;
        }



        /// <summary>
        /// Kfs the mouse down.
        /// </summary>
        private void kf_MouseDown()
        {
            if (FormVisible)
            {
                var f = FindKeyboardForm() as OnScreenKeyboardForm;

                ZeroitVirtualKeyboard kb = f.Controls.Find(kbControlName, true).FirstOrDefault() as ZeroitVirtualKeyboard;

                if (!this.RectangleToScreen(this.ClientRectangle).Contains(Cursor.Position) &&
                !kb.RectangleToScreen(kb.ClientRectangle).Contains(Cursor.Position))
                {
                    isShown = false;

                }
                else
                {
                    isShown = true;
                }


                ToggleForm();
            }
        }

        /// <summary>
        /// Toggles the form.
        /// </summary>
        private void ToggleForm()
        {
            if (FormVisible)
            {
                if (!isShown)
                {
                    CloseForm();
                }
            }
            else
            {
                ShowKeyboard();
            }
        }

        /// <summary>
        /// Shows the keyboard.
        /// </summary>
        private void ShowKeyboard()
        {

            var popup = new OnScreenKeyboardForm(IsNumeric, isCapsLock, isNumLock, isShift, isAlt, isCtrl);
            int posX;

            if (IsNumeric)
            {
                posX = Left;
                locationPoint = GetPosition(posX, popup);
                popup.Width = numFormWidth;
                popup.Height = numFormHeight;
            }
            else
            {
                posX = (Left + Width / 2) - popup.Width / 2;
                locationPoint = GetPosition(posX, popup);
            }

            popup.LocationPoint = locationPoint;
            popup.Show();

        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="posX">The position x.</param>
        /// <param name="popup">The popup.</param>
        /// <returns>Point.</returns>
        private Point GetPosition(int posX, System.Windows.Forms.Form popup)
        {
            Screen Srn = Screen.PrimaryScreen;
            const int startPanelHeight = 45;
            Point location;
            location = (this.Parent.PointToScreen(new Point(posX, Bottom)));

            int x = 0;
            int y = 0;

            if (location.X + popup.Width > Srn.Bounds.Width)
            {
                x = popup.Width - (Srn.Bounds.Width - location.X);
            }
            else if (location.X < 0)
            {
                x = location.X;
            }
            else
            {
                x = 0;
            }

            if (location.Y + popup.Height > (Srn.Bounds.Height - startPanelHeight))
            {
                y = popup.Height + this.Height + 5;
            }

            location = new Point((location.X - x), location.Y - y);

            return location;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            var form = FindKeyboardForm() as OnScreenKeyboardForm;

            if (form != null)
            {
                ZeroitVirtualKeyboard kb = form.Controls.Find(kbControlName, true).FirstOrDefault() as ZeroitVirtualKeyboard;
                isCapsLock = kb.CapsLockState;
                isNumLock = kb.NumLockState;
                isShift = kb.ShiftState;
                isAlt = kb.AltState;
                isCtrl = kb.CtrlState;

                form.Close();
                form.Dispose();
            }

        }



        /// <summary>
        /// Class KeyboardFilter.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.IMessageFilter" />
        private class KeyboardFilter : IMessageFilter
        {

            /// <summary>
            /// Delegate LeftButtonDown
            /// </summary>
            public delegate void LeftButtonDown();
            /// <summary>
            /// Occurs when [mouse down].
            /// </summary>
            public event LeftButtonDown MouseDown;

            /// <summary>
            /// Delegate KeyPressUp
            /// </summary>
            /// <param name="target">The target.</param>
            public delegate void KeyPressUp(IntPtr target);
            /// <summary>
            /// Occurs when [key up].
            /// </summary>
            public event KeyPressUp KeyUp;

            /// <summary>
            /// The wm keyup
            /// </summary>
            private const int WM_KEYUP = 0x101;
            /// <summary>
            /// The wm lbuttondown
            /// </summary>
            private const int WM_LBUTTONDOWN = 0x201;

            /// <summary>
            /// Filters out a message before it is dispatched.
            /// </summary>
            /// <param name="m">The message to be dispatched. You cannot modify this message.</param>
            /// <returns>true to filter the message and stop it from being dispatched; false to allow the message to continue to the next filter or control.</returns>
            bool IMessageFilter.PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    // raises our KeyUp() event whenever a key is released 
                    case WM_KEYUP:
                        if (KeyUp != null)
                        {
                            KeyUp(m.HWnd);
                        }
                        break;

                    // raises our MouseDown() event whenever the mouse is left clicked 
                    case WM_LBUTTONDOWN:
                        if (MouseDown != null)
                        {
                            MouseDown();
                        }
                        break;
                }
                return false;
            }
        }
    }

    #endregion


}
