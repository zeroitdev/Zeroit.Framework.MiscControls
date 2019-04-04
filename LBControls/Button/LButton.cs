// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LButton.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region LButton

    #region Control
    /// <summary>
    /// A class collection for rendering a button.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
    public partial class ZeroitLBButton : ZeroitLBIndustrialCtrlBase
    {
        #region (* Enumeratives *)
        /// <summary>
        /// Button styles
        /// </summary>
        public enum ButtonStyle
        {
            /// <summary>
            /// The circular
            /// </summary>
            Circular = 0,
            /// <summary>
            /// The rectangular
            /// </summary>
            Rectangular = 1,
            /// <summary>
            /// The elliptical
            /// </summary>
            Elliptical = 2,
        }

        /// <summary>
        /// Button states
        /// </summary>
        public enum ButtonState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal = 0,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
        }
        #endregion

        #region (* Properties variables *)
        /// <summary>
        /// The button style
        /// </summary>
        private ButtonStyle buttonStyle = ButtonStyle.Circular;
        /// <summary>
        /// The button state
        /// </summary>
        private ButtonState buttonState = ButtonState.Normal;
        /// <summary>
        /// The button color
        /// </summary>
        private Color buttonColor = Color.Red;
        /// <summary>
        /// The label
        /// </summary>
        private string label = String.Empty;
        /// <summary>
        /// The enable repeat state
        /// </summary>
        private bool enableRepeatState = false;
        /// <summary>
        /// The start repeat interval
        /// </summary>
        private int startRepeatInterval = 500;
        /// <summary>
        /// The repeat interval
        /// </summary>
        private int repeatInterval = 100;
        #endregion

        #region (* Variables *)
        /// <summary>
        /// The TMR repeat
        /// </summary>
        private System.Windows.Forms.Timer tmrRepeat = null;
        #endregion

        #region (* Constructor *)        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBButton" /> class.
        /// </summary>
        public ZeroitLBButton()
        {
            // Initialization
            InitializeComponent();

            // Properties initialization
            this.buttonColor = Color.Red;
            this.Size = new Size(50, 50);

            // Timer 
            this.tmrRepeat = new System.Windows.Forms.Timer();
            this.tmrRepeat.Enabled = false;
            this.tmrRepeat.Interval = this.startRepeatInterval;
            this.tmrRepeat.Tick += this.Timer_Tick;
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBButtonRenderer();
        }
        #endregion

        #region (* Properties *)        
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [
            Category("Button"),
            Description("Style of the button")
        ]
        public ButtonStyle Style
        {
            set
            {
                this.buttonStyle = value;
                this.CalculateDimensions();
            }
            get { return this.buttonStyle; }
        }

        /// <summary>
        /// Gets or sets the color of the button.
        /// </summary>
        /// <value>The color of the button.</value>
        [
            Category("Button"),
            Description("Color of the body of the button")
        ]
        public Color ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The label.</value>
        [
            Category("Button"),
            Description("Label of the button"),
        ]
        public string Label
        {
            get { return this.label; }
            set
            {
                this.label = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [
            Category("Button"),
            Description("State of the button")
        ]
        public ButtonState State
        {
            set
            {
                this.buttonState = value;
                this.Invalidate();
            }
            get { return this.buttonState; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to repeat state.
        /// </summary>
        /// <value><c>true</c> if repeat state; otherwise, <c>false</c>.</value>
        [
            Category("Button"),
            Description("Enable/Disable the repetition of the event if the button is pressed")
        ]
        public bool RepeatState
        {
            set { this.enableRepeatState = value; }
            get { return this.enableRepeatState; }
        }

        /// <summary>
        /// Gets or sets the Interval to wait in ms for starting the repetition.
        /// </summary>
        /// <value>The start repeat interval.</value>
        [
            Category("Button"),
            Description("Interval to wait in ms for start the repetition")
        ]
        public int StartRepeatInterval
        {
            set { this.startRepeatInterval = value; }
            get { return this.startRepeatInterval; }
        }

        /// <summary>
        /// Gets or sets the interval in ms for the repetition.
        /// </summary>
        /// <value>The repeat interval.</value>
        [
            Category("Button"),
            Description("Interval in ms for the repetition")
        ]
        public int RepeatInterval
        {
            set { this.repeatInterval = value; }
            get { return this.repeatInterval; }
        }
        #endregion

        #region (* Events delegates *)
        /// <summary>
        /// Timer event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Timer_Tick(object sender, EventArgs e)
        {
            this.tmrRepeat.Enabled = false;

            // Update the interval
            if (tmrRepeat.Interval == this.startRepeatInterval)
                this.tmrRepeat.Interval = this.repeatInterval;

            // Call the delagate
            LBButtonEventArgs ev = new LBButtonEventArgs();
            ev.State = this.State;
            this.OnButtonRepeatState(ev);

            this.tmrRepeat.Enabled = true;
        }

        /// <summary>
        /// Mouse down event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            // Change the state
            this.State = ButtonState.Pressed;
            this.Invalidate();

            // Call the delagates
            LBButtonEventArgs ev = new LBButtonEventArgs();
            ev.State = this.State;
            this.OnButtonChangeState(ev);

            // Enable the repeat timer
            if (this.RepeatState != false)
            {
                this.tmrRepeat.Interval = this.StartRepeatInterval;
                this.tmrRepeat.Enabled = true;
            }
        }

        /// <summary>
        /// Mouse up event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMuoseUp(object sender, MouseEventArgs e)
        {
            // Change the state
            this.State = ButtonState.Normal;
            this.Invalidate();

            // Call the delagates
            LBButtonEventArgs ev = new LBButtonEventArgs();
            ev.State = this.State;
            this.OnButtonChangeState(ev);

            // Disable the timer
            this.tmrRepeat.Enabled = false;
        }
        #endregion

        #region (* Fire events *)
        /// <summary>
        /// Event for the state changed
        /// </summary>
        public event ButtonChangeState ButtonChangeState;

        /// <summary>
        /// Method for call the delagetes
        /// </summary>
        /// <param name="e">The <see cref="LBButtonEventArgs"/> instance containing the event data.</param>
        protected virtual void OnButtonChangeState(LBButtonEventArgs e)
        {
            if (this.ButtonChangeState != null)
                this.ButtonChangeState(this, e);
        }

        /// <summary>
        /// Event for the repetition of state
        /// </summary>
        public event ButtonRepeatState ButtonRepeatState;

        /// <summary>
        /// Method for call the delagetes
        /// </summary>
        /// <param name="e">The <see cref="LBButtonEventArgs"/> instance containing the event data.</param>
        protected virtual void OnButtonRepeatState(LBButtonEventArgs e)
        {
            if (this.ButtonRepeatState != null)
                this.ButtonRepeatState(this, e);
        }
        #endregion
    }

    #region (* Classes for event and event delagates args *)

    #region (* Event args class *)
    /// <summary>
    /// Class for events delegates
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class LBButtonEventArgs : EventArgs
    {
        /// <summary>
        /// The state
        /// </summary>
        private ZeroitLBButton.ButtonState state;

        /// <summary>
        /// Initializes a new instance of the <see cref="LBButtonEventArgs"/> class.
        /// </summary>
        public LBButtonEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ZeroitLBButton.ButtonState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
    }
    #endregion

    #region (* Delegates *)
    /// <summary>
    /// Delegate ButtonChangeState
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="LBButtonEventArgs"/> instance containing the event data.</param>
    public delegate void ButtonChangeState(object sender, LBButtonEventArgs e);
    /// <summary>
    /// Delegate ButtonRepeatState
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="LBButtonEventArgs"/> instance containing the event data.</param>
    public delegate void ButtonRepeatState(object sender, LBButtonEventArgs e);
    #endregion

    #endregion
    #endregion

    #region Designer Generated
    partial class ZeroitLBButton
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LBButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LBButton";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMuoseUp);
            this.ResumeLayout(false);
        }
    }
    #endregion

    #endregion


}
