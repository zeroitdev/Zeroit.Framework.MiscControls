// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapseAnimation.cs" company="Zeroit Dev Technologies">
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
using System.Threading;

namespace Zeroit.Framework.MiscControls
{
    #region Collapse Animation

    /// <summary>
    /// Event raised during animation notifying the new size for the panel
    /// </summary>
    /// <param name="sender">the object sending the notification</param>
    /// <param name="size">the new size for the window collasping/expanding</param>
    internal delegate void NotifyAnimationEvent(object sender, int size);

    /// <summary>
    /// Event raised when animation is finished
    /// </summary>
    /// <param name="sender">The sender.</param>
    internal delegate void NotifyAnimationFinishedEvent(object sender);

    /// <summary>
    /// Defines a class that creates a worker thread handling the collapsing/expanding animation
    /// </summary>
    internal class CollapseAnimation
    {
        #region Members

        /// <summary>
        /// The step used in collapsing/exapanding animation
        /// </summary>
        protected int step = 0;

        /// <summary>
        /// minimum size
        /// </summary>
        protected int minimum = 0;

        /// <summary>
        /// maximum size
        /// </summary>
        protected int maximum = 0;

        /// <summary>
        /// THe worker thread
        /// </summary>
        protected Thread thread = null;

        /// <summary>
        /// a wait handel used in starting the worker thread
        /// </summary>
        protected ManualResetEvent threadStart = new ManualResetEvent(false);

        /// <summary>
        /// handler for notifying the size has changed
        /// </summary>
        public event NotifyAnimationEvent NotifyAnimation = null;

        /// <summary>
        /// handler for notifying the animation has finished
        /// </summary>
        public event NotifyAnimationFinishedEvent NotifyAnimationFinished = null;
        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseAnimation"/> class.
        /// </summary>
        internal CollapseAnimation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseAnimation"/> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="minimum">The minimum.</param>
        /// <param name="maximum">The maximum.</param>
        internal CollapseAnimation(int step, int minimum, int maximum)
        {
            this.step = step;
            this.minimum = minimum;
            this.maximum = maximum;
        }

        #endregion

        #region Public

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// Step can not be zero!
        /// or
        /// Invalid parameters
        /// </exception>
        public void Start()
        {
            if (step == 0)
            {
                throw new InvalidOperationException("Step can not be zero!");
            }
            if (minimum >= maximum)
            {
                throw new InvalidOperationException("Invalid parameters");
            }
            //create the working thread
            threadStart.Reset();
            thread = new Thread(new ThreadStart(Animate));
            thread.IsBackground = true;
            thread.Start();
            //waint until the thread has actually started
            threadStart.WaitOne();
        }

        #endregion

        #region Protected

        /// <summary>
        /// The processing method for the worker thread. Performs the "animation"
        /// </summary>
        protected void Animate()
        {
            //signal the calling thread that the worker started
            threadStart.Set();
            if (null != NotifyAnimation)
            {
                if (step > 0)
                {
                    while (maximum > minimum)
                    {
                        maximum -= step;
                        if (maximum < minimum)
                        {
                            maximum = minimum;
                        }
                        NotifyAnimation(this, maximum);
                        Thread.Sleep(20);
                    }
                    if (NotifyAnimationFinished != null)
                    {
                        NotifyAnimationFinished(this);
                    }
                }
                else
                {
                    while (maximum > minimum)
                    {
                        minimum -= step;
                        if (maximum < minimum)
                        {
                            minimum = maximum;
                        }
                        NotifyAnimation(this, minimum);
                        Thread.Sleep(20);
                    }
                    if (NotifyAnimationFinished != null)
                    {
                        NotifyAnimationFinished(this);
                    }
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Get/Set the animation step
        /// </summary>
        /// <value>The step.</value>
        public int Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }

        /// <summary>
        /// Get/Set minimum value allowed for size
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return minimum;
            }

            set
            {
                minimum = value;
            }
        }

        /// <summary>
        /// Get/Set maximum value allowed for size
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                maximum = value;
            }
        }
        #endregion
    }

    #endregion
}
