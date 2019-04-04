// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RendererBase.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Renderer Base
    /// <summary>
    /// Class ToggleSwitchRendererBase.
    /// </summary>
    public abstract class ToggleSwitchRendererBase
    {
        #region Private Members

        /// <summary>
        /// The toggle switch
        /// </summary>
        private ZeroitToggleSwitch _toggleSwitch;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleSwitchRendererBase"/> class.
        /// </summary>
        protected ToggleSwitchRendererBase()
        { }

        /// <summary>
        /// Sets the toggle switch.
        /// </summary>
        /// <param name="toggleSwitch">The toggle switch.</param>
        internal void SetToggleSwitch(ZeroitToggleSwitch toggleSwitch)
        {
            _toggleSwitch = toggleSwitch;
        }

        /// <summary>
        /// Gets the toggle switch.
        /// </summary>
        /// <value>The toggle switch.</value>
        internal ZeroitToggleSwitch ToggleSwitch
        {
            get { return _toggleSwitch; }
        }

        #endregion Constructor

        #region Render Methods

        /// <summary>
        /// Renders the background.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RenderBackground(PaintEventArgs e)
        {
            if (_toggleSwitch == null)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle controlRectangle = new Rectangle(0, 0, _toggleSwitch.Width, _toggleSwitch.Height);

            FillBackground(e.Graphics, controlRectangle);
            RenderBorder(e.Graphics, controlRectangle);
        }

        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RenderControl(PaintEventArgs e)
        {
            if (_toggleSwitch == null)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle buttonRectangle = GetButtonRectangle();
            int totalToggleFieldWidth = ToggleSwitch.Width - buttonRectangle.Width;

            if (buttonRectangle.X > 0)
            {
                Rectangle leftRectangle = new Rectangle(0, 0, buttonRectangle.X, ToggleSwitch.Height);

                if (leftRectangle.Width > 0)
                    RenderLeftToggleField(e.Graphics, leftRectangle, totalToggleFieldWidth);
            }

            if (buttonRectangle.X + buttonRectangle.Width < e.ClipRectangle.Width)
            {
                Rectangle rightRectangle = new Rectangle(buttonRectangle.X + buttonRectangle.Width, 0, ToggleSwitch.Width - buttonRectangle.X - buttonRectangle.Width, ToggleSwitch.Height);

                if (rightRectangle.Width > 0)
                    RenderRightToggleField(e.Graphics, rightRectangle, totalToggleFieldWidth);
            }

            RenderButton(e.Graphics, buttonRectangle);
        }

        /// <summary>
        /// Fills the background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="controlRectangle">The control rectangle.</param>
        public void FillBackground(Graphics g, Rectangle controlRectangle)
        {
            Color backColor = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? ToggleSwitch.BackColor.ToGrayScale() : ToggleSwitch.BackColor;

            using (Brush backBrush = new SolidBrush(backColor))
            {
                g.FillRectangle(backBrush, controlRectangle);
            }
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="borderRectangle">The border rectangle.</param>
        public abstract void RenderBorder(Graphics g, Rectangle borderRectangle);
        /// <summary>
        /// Renders the left toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="leftRectangle">The left rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public abstract void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth);
        /// <summary>
        /// Renders the right toggle field.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rightRectangle">The right rectangle.</param>
        /// <param name="totalToggleFieldWidth">Total width of the toggle field.</param>
        public abstract void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth);
        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="buttonRectangle">The button rectangle.</param>
        public abstract void RenderButton(Graphics g, Rectangle buttonRectangle);

        #endregion Render Methods

        #region Helper Methods

        /// <summary>
        /// Gets the width of the button.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public abstract int GetButtonWidth();
        /// <summary>
        /// Gets the button rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetButtonRectangle();
        /// <summary>
        /// Gets the button rectangle.
        /// </summary>
        /// <param name="buttonWidth">Width of the button.</param>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle GetButtonRectangle(int buttonWidth);

        #endregion Helper Methods
    }
    #endregion
}
