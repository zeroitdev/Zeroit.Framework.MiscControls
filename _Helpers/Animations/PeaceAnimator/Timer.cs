// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Timer.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The timer class, will execute your code in specific time frames
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// The timer thread
        /// </summary>
        private static Thread _timerThread;

        /// <summary>
        /// The lock handle
        /// </summary>
        private static readonly object LockHandle = new object();

        /// <summary>
        /// The start time as ms
        /// </summary>
        private static readonly long StartTimeAsMs = DateTime.Now.Ticks;

        /// <summary>
        /// The subscribers
        /// </summary>
        private static readonly List<Timer> Subscribers = new List<Timer>();

        /// <summary>
        /// The callback
        /// </summary>
        private readonly Action<ulong> _callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer" /> class.
        /// </summary>
        /// <param name="callback">The callback to be executed at each tick</param>
        /// <param name="fpsKnownLimit">The max ticks per second</param>
        public Timer(Action<ulong> callback, FPSLimiterKnownValues fpsKnownLimit = FPSLimiterKnownValues.LimitThirty)
            : this(callback, (int) fpsKnownLimit)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer" /> class.
        /// </summary>
        /// <param name="callback">The callback to be executed at each tick</param>
        /// <param name="fpsLimit">The max ticks per second</param>
        /// <exception cref="ArgumentNullException">callback</exception>
        public Timer(Action<ulong> callback, int fpsLimit)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            _callback = callback;
            FrameLimiter = fpsLimit;
            lock (LockHandle)
            {
                if (_timerThread == null)
                {
                    (_timerThread = new Thread(ThreadCycle) {IsBackground = true}).Start();
                }
            }
        }

        /// <summary>
        /// Gets the time of the last frame/tick related to the global-timer start reference
        /// </summary>
        /// <value>The last tick.</value>
        public long LastTick { get; private set; }

        /// <summary>
        /// Gets or sets the maximum frames/ticks per second
        /// </summary>
        /// <value>The frame limiter.</value>
        public int FrameLimiter { get; set; }

        /// <summary>
        /// Gets the time of the first frame/tick related to the global-timer start reference
        /// </summary>
        /// <value>The first tick.</value>
        public long FirstTick { get; private set; }


        /// <summary>
        /// Ticks this instance.
        /// </summary>
        private void Tick()
        {
            if ((1000/FrameLimiter) < (GetTimeDifferenceAsMs() - LastTick))
            {
                LastTick = GetTimeDifferenceAsMs();
                _callback((ulong) (LastTick - FirstTick));
            }
        }

        /// <summary>
        /// Gets the time difference as ms.
        /// </summary>
        /// <returns>System.Int64.</returns>
        private static long GetTimeDifferenceAsMs()
        {
            return (DateTime.Now.Ticks - StartTimeAsMs)/10000;
        }

        /// <summary>
        /// Threads the cycle.
        /// </summary>
        private static void ThreadCycle()
        {
            while (true)
            {
                try
                {
                    bool hibernate;
                    lock (Subscribers)
                    {
                        hibernate = Subscribers.Count == 0;
                        if (!hibernate)
                        {
                            foreach (var t in Subscribers.ToList())
                            {
                                t.Tick();
                            }
                        }
                    }

                    Thread.Sleep(hibernate ? 50 : 1);
                }
                catch
                {
                    // ignored
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// The method to reset the time of the starting frame/tick
        /// </summary>
        public void ResetClock()
        {
            FirstTick = GetTimeDifferenceAsMs();
        }

        /// <summary>
        /// The method to resume the timer after stopping it
        /// </summary>
        public void Resume()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick += GetTimeDifferenceAsMs() - LastTick;
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        /// The method to start the timer from the beginning
        /// </summary>
        public void Start()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick = GetTimeDifferenceAsMs();
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        /// The method to stop the timer from generating any new ticks/frames
        /// </summary>
        public void Stop()
        {
            lock (Subscribers)
                if (Subscribers.Contains(this))
                {
                    Subscribers.Remove(this);
                }
        }
    }
}