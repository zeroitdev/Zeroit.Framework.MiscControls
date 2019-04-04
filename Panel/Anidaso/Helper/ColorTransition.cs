// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorTransition.cs" company="Zeroit Dev Technologies">
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
using System.Threading;

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class ZeroitAnidasoColorTransition.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
    public class ZeroitAnidasoColorTransition : Component
    {
        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0;

        /// <summary>
        /// The color 0
        /// </summary>
        private Color color_0 = Color.White;

        /// <summary>
        /// The color 1
        /// </summary>
        private Color color_1 = Color.White;

        /// <summary>
        /// The color 2
        /// </summary>
        private Color color_2 = Color.White;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;

        /// <summary>
        /// Gets or sets the color1.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the color2.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the progess value.
        /// </summary>
        /// <value>The progess value.</value>
        public int ProgessValue
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public Color Value
        {
            get
            {
                return this.color_2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoColorTransition"/> class.
        /// </summary>
        public ZeroitAnidasoColorTransition()
        {
            this.method_1();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoColorTransition"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ZeroitAnidasoColorTransition(IContainer container)
        {
            container.Add(this);
            this.method_1();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the color scale.
        /// </summary>
        /// <param name="Passentage">The passentage.</param>
        /// <param name="startColor">The start color.</param>
        /// <param name="endColor">The end color.</param>
        /// <returns>Color.</returns>
        public static Color getColorScale(int Passentage, Color startColor, Color endColor)
        {
            Color color;
            try
            {
                double num = Math.Round((double)startColor.R + (double)((endColor.R - startColor.R) * Passentage) * 0.01, 0);
                int num1 = int.Parse(num.ToString());
                num = Math.Round((double)startColor.G + (double)((endColor.G - startColor.G) * Passentage) * 0.01, 0);
                int num2 = int.Parse(num.ToString());
                num = Math.Round((double)startColor.B + (double)((endColor.B - startColor.B) * Passentage) * 0.01, 0);
                int num3 = int.Parse(num.ToString());
                color = Color.FromArgb(255, num1, num2, num3);
            }
            catch (Exception exception)
            {
                color = startColor;
            }
            return color;
        }

        /// <summary>
        /// Methods the 0.
        /// </summary>
        private void method_0()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            Color colorScale = ZeroitAnidasoColorTransition.getColorScale(this.ProgessValue, this.Color1, this.Color2);
            if (colorScale != this.Value)
            {
                this.color_2 = colorScale;
                if (this.eventHandler_0 == null)
                {
                    do
                    {
                        if (num != num1)
                        {
                            break;
                        }
                        num1 = 1;
                        num2 = num;
                        num = 1;
                    }
                    while (1 <= num2);
                    return;
                }
                this.eventHandler_0(this, new EventArgs());
                return;
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Methods the 1.
        /// </summary>
        private void method_1()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        /// <summary>
        /// Occurs when [on value change].
        /// </summary>
        public event EventHandler OnValueChange
        {
            add
            {
                EventHandler eventHandler;
                EventHandler eventHandler0 = this.eventHandler_0;
                do
                {
                    eventHandler = eventHandler0;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
                    eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
                }
                while ((object)eventHandler0 != (object)eventHandler);
            }
            remove
            {
                EventHandler eventHandler;
                EventHandler eventHandler0 = this.eventHandler_0;
                do
                {
                    eventHandler = eventHandler0;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
                    eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
                }
                while ((object)eventHandler0 != (object)eventHandler);
            }
        }
    }


}
