// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AnalogSaz.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Analogue Clock

    #region Enums

    /// <summary>
    /// Enum representing the clock hour format  for <c><see cref="ZeroitClockAnalogSaz" /></c>.
    /// </summary>
    public enum ClockFormat
    {
        /// <summary>
        /// The twenty four hour
        /// </summary>
        TwentyFourHour,
        /// <summary>
        /// The twelve hour
        /// </summary>
        TwelveHour
    };

    /// <summary>
    /// Enum representing the type of Clock for <c><see cref="ZeroitClockAnalogSaz" /></c>.
    /// </summary>
    public enum ClockType
    {
        /// <summary>
        /// The analog clock
        /// </summary>
        AnalogClock,
        /// <summary>
        /// The stop watch
        /// </summary>
        StopWatch,
        /// <summary>
        /// The count down
        /// </summary>
        CountDown,
        /// <summary>
        /// The freeze
        /// </summary>
        Freeze
    };

    #endregion

    #region Control

    /// <summary>
    /// A class collection for rendering an analog clock.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitClockAnalogSaz : System.Windows.Forms.UserControl
    {
        #region Events and delegates

        //delegates called when the count down is finished
        /// <summary>
        /// Delegate CountDown
        /// </summary>
        public delegate void CountDown();

        /// <summary>
        /// Occurs when count down is done.
        /// </summary>
        public event CountDown CountDownDone = null;

        //delegates called when the alarm time is set
        /// <summary>
        /// Delegate Alarm
        /// </summary>
        public delegate void Alarm();

        /// <summary>
        /// Occurs when the control raises alarm.
        /// </summary>
        public event Alarm RaiseAlarm = null;


        #endregion

        #region Private Fields
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// The face radius
        /// </summary>
        private int FaceRadius;
        /// <summary>
        /// The current time
        /// </summary>
        private DateTime currentTime;
        /// <summary>
        /// The B24 HRS
        /// </summary>
        private bool b24Hrs = false;
        /// <summary>
        /// The font
        /// </summary>
        private Font font = new Font("Courier New", 72);
        /// <summary>
        /// The x
        /// </summary>
        float x, y;
        /// <summary>
        /// The number HRS
        /// </summary>
        private int numHrs;
        //set format of the clock, default 24 hr format
        /// <summary>
        /// The clock format
        /// </summary>
        private ClockFormat clockFormat = ClockFormat.TwentyFourHour;
        //type of the clock to display
        /// <summary>
        /// The clock type
        /// </summary>
        private ClockType clockType = ClockType.AnalogClock;
        //initial value for stop watch
        /// <summary>
        /// The stop watch
        /// </summary>
        private DateTime stopWatch = DateTime.Now;
        //initial value for count down
        /// <summary>
        /// The count down
        /// </summary>
        int countDown = 10000;
        /// <summary>
        /// The count down to
        /// </summary>
        private DateTime countDownTo;
        /// <summary>
        /// The sec hand color
        /// </summary>
        private Color secHandColor = Color.Black;
        /// <summary>
        /// The hr hand color
        /// </summary>
        private Color hrHandColor = Color.Red;
        /// <summary>
        /// The minimum hand color
        /// </summary>
        private Color minHandColor = Color.Blue;
        /// <summary>
        /// The hour
        /// </summary>
        int hour, min, sec, ms;
        /// <summary>
        /// The am pm
        /// </summary>
        char am_pm;
        /// <summary>
        /// The alarm times
        /// </summary>
        private ArrayList AlarmTimes = new ArrayList();
        /// <summary>
        /// The timer clock
        /// </summary>
        private System.Windows.Forms.Timer timerClock;
        /// <summary>
        /// The deg
        /// </summary>
        private int deg;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the count down time.
        /// </summary>
        /// <value>The count down time.</value>
        public int CountDownTime
        {
            get
            {
                return countDown;
            }
            set
            {
                if (value < 1000)
                {
                    MessageBox.Show("Count Down time cannot be less than 1000");
                }
                else
                {
                    countDown = value;
                }
            }
        }

        //set the alarm time        
        /// <summary>
        /// Sets the alarm time.
        /// </summary>
        /// <value>The alarm time.</value>
        public DateTime AlarmTime
        {
            set
            {
                if (value < DateTime.Now)
                {
                    MessageBox.Show("Alarm time cannot be earlier", "Information");
                }
                else
                {
                    AlarmTimes.Add(value);
                }
            }
        }

        /// <summary>
        /// Sets the clock display.
        /// </summary>
        /// <value>The clock display.</value>
        public ClockFormat ClockDisplay
        {
            set
            {
                this.ClockDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of clock.
        /// </summary>
        /// <value>The type of clock.</value>
        public ClockType SetClockType
        {
            get
            {
                return clockType;
            }
            set
            {
                clockType = value;
                switch (clockType)
                {
                    case ClockType.StopWatch:
                        stopWatch = DateTime.Now;
                        break;

                    case ClockType.CountDown:
                        countDownTo = DateTime.Now.AddMilliseconds(countDown);
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the seconds hand.
        /// </summary>
        /// <value>The color of the sec hand.</value>
        public Color SecHandColor
        {
            get { return secHandColor; }
            set
            {
                secHandColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the hour hand.
        /// </summary>
        /// <value>The color of the hour hand.</value>
        public Color HourHandColor
        {
            get { return hrHandColor; }
            set
            {
                hrHandColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the mini hand.
        /// </summary>
        /// <value>The color of the mini hand.</value>
        public Color MinHandColor
        {
            get { return minHandColor; }
            set
            {
                minHandColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitClockAnalogSaz" /> class.
        /// </summary>
        public ZeroitClockAnalogSaz()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            // TODO: Add any initialization after the InitComponent call
            //BackColor = Color.Bisque;
            //ForeColor = Color.Black;

            //update the clock by timer
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            timer.Interval = 500;
            timer.Enabled = true;
            this.Invalidate();
            timerClock.Start();




        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerClock.Stop();
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
            timerClock.Dispose();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            SetScale(g);
            DrawFace(g);
            DrawTime(g, true);
        }


        /// <summary>
        /// Handles the <see cref="E:Timer" /> event.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        public void OnTimer(object source, ElapsedEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            SetScale(g);
            DrawFace(g);
            DrawTime(g, false);
            DisplayTime(g);
            g.Dispose();
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // Clock
            // 
            this.Name = "Clock";
            this.Size = new System.Drawing.Size(40, 40);

        }
        #endregion

        /// <summary>
        /// Sets the scale.
        /// </summary>
        /// <param name="g">The g.</param>
        private void SetScale(Graphics g)
        {
            //if the width of the control is too small, do nothing
            if (Width == 0 || Height == 0)
            {
                return;
            }

            //set the origin at the center
            g.TranslateTransform(Width / 2, Height / 2);

            //set inches to the minimum width or height divide by dots per inches

            float inches = Math.Min(Width / g.DpiX, Height / g.DpiX);

            //set the scale to grid of 2000 by 2000 units
            g.ScaleTransform(inches * g.DpiX / 2000, inches * g.DpiY / 2000);
        }

        /// <summary>
        /// Draws the face.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawFace(Graphics g)
        {
            //numbers are in the forecolor except flash number in green as the seconds go by
            Brush brush = new SolidBrush(ForeColor);
            numHrs = b24Hrs ? 24 : 12;
            deg = 360 / numHrs;
            FaceRadius = 700;
            //For each hours on the clock face 
            for (int i = 1; i <= numHrs; i++)
            {
                //i=hour 30 degrees =offset per hour
                //+90 to make 12 straight up
                x = GetCos(i * deg + 90) * FaceRadius;
                y = GetSin(i * deg + 90) * FaceRadius;

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                g.DrawString(i.ToString(), font, brush, -x, -y, format);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void OnResize(object source, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SetScale(g);
            DrawFace(g);
            DrawTime(g, true);
        }

        /// <summary>
        /// Draws the time.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="forceDraw">if set to <c>true</c> [force draw].</param>
        private void DrawTime(Graphics g, bool forceDraw)
        {
            //length of the hands
            float hrLength = FaceRadius * 0.5f;
            float minLength = FaceRadius * 0.7f;
            float secLength = FaceRadius * 0.9f;

            //set to backcolor to erase old hands first

            Pen hrPen = new Pen(BackColor);
            Pen minPen = new Pen(BackColor);
            Pen secPen = new Pen(BackColor);

            //set the arrow heads
            hrPen.EndCap = LineCap.ArrowAnchor;

            minPen.EndCap = LineCap.ArrowAnchor;

            secPen.EndCap = LineCap.ArrowAnchor;


            //hour hand is thicker
            hrPen.Width = 20;
            minPen.Width = 10;

            //second hand
            Brush secBrush = new SolidBrush(BackColor);
            const int EllipseSize = 80;

            GraphicsState state;
            //state 1. Delete the old time
            //delete the old second hand
            //figure out how far around to rotate to draw the second hand
            //save the current state, rotate, draw, and then restore it.
            float rotation = GetSecondRotation();
            state = g.Save();
            g.RotateTransform(rotation);
            //g.FillEllipse(secBrush, -(EllipseSize / 2), -secLength, EllipseSize, EllipseSize);
            g.Restore(state);

            DateTime newTime = DateTime.Now;
            bool newMin = false; //Has the minute changed?

            //if the minute is changed set the new flag
            if (newTime.Minute != currentTime.Minute)
                newMin = true;

            //if the minute has changed or you must draw any way then 
            //you must first delete the old minute and hour hand

            if (newMin || forceDraw)
            {
                //figure out how far around to rotate to draw the min hand
                //save the current state, draw, rotate and then restore the state

                rotation = GetMinuteRotation();
                state = g.Save();
                g.RotateTransform(rotation);
                g.DrawLine(minPen, 0, 0, 0, -minLength);
                g.Restore(state);

                //figure out how far around to rotate to draw the hour hand 
                //save the current state, draw, rotate and then
                //restore the state

                rotation = GetHourRotation();
                state = g.Save();
                g.RotateTransform(rotation);
                g.DrawLine(hrPen, 0, 0, 0, -hrLength);
                g.Restore(state);
            }
            //step 2. draw the new time
            currentTime = newTime;

            hrPen.Color = hrHandColor;
            minPen.Color = minHandColor;
            secPen.Color = secHandColor;
            secBrush = new SolidBrush(secHandColor);

            //draw the new second hand
            //figure out how far around to rotate to draw the second hand
            //save the current state, draw, rotate and then 
            //restore the state

            state = g.Save();
            rotation = GetSecondRotation();
            g.RotateTransform(rotation);
            g.DrawLine(secPen, 0, 0, 0, -secLength);
            //g.FillEllipse(secBrush, -(EllipseSize / 2), -secLength, EllipseSize, EllipseSize);
            g.Restore(state);

            //if the min hand is changed you must draw anyway the new
            //minute hand and hour hand
            if (newMin || forceDraw)
            {

                //figure out how far around to rotate to draw the second hand 
                //save the current state, draw, rotate, and then 
                //restore the state
                rotation = GetMinuteRotation();
                state = g.Save();
                g.RotateTransform(rotation);
                g.DrawLine(minPen, 0, 0, 0, -minLength);
                g.Restore(state);


                //figure out how far around to rotate to draw the second hand 
                //save the current state, draw, rotate, and then 
                //restore the state
                rotation = GetHourRotation();
                state = g.Save();
                g.RotateTransform(rotation);
                g.DrawLine(hrPen, 0, 0, 0, -hrLength);
                g.Restore(state);
            }
        }

        /// <summary>
        /// Gets the hour rotation.
        /// </summary>
        /// <returns>System.Single.</returns>
        private float GetHourRotation()
        {
            //degrees depend on 24 vs 12 hour clock
            float deg = b24Hrs ? 24 : 12;
            return (360f * currentTime.Hour / numHrs + deg * currentTime.Minute / 60f);
        }

        /// <summary>
        /// Gets the minute rotation.
        /// </summary>
        /// <returns>System.Single.</returns>
        private float GetMinuteRotation()
        {
            return (360f * currentTime.Minute / 60f);
        }
        /// <summary>
        /// Gets the second rotation.
        /// </summary>
        /// <returns>System.Single.</returns>
        private float GetSecondRotation()
        {
            return (360f * currentTime.Second / 60f);
        }
        /// <summary>
        /// Gets the sin.
        /// </summary>
        /// <param name="degAngle">The deg angle.</param>
        /// <returns>System.Single.</returns>
        private static float GetSin(float degAngle)
        {
            return (float)Math.Sin(Math.PI * degAngle / 180f);
        }
        /// <summary>
        /// Gets the cos.
        /// </summary>
        /// <param name="degAngle">The deg angle.</param>
        /// <returns>System.Single.</returns>
        private static float GetCos(float degAngle)
        {
            return (float)Math.Cos(Math.PI * degAngle / 180f);
        }

        /// <summary>
        /// Handles the Tick event of the timerClock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timerClock_Tick(object sender, System.EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            //SetScale(g);
            //DrawFace(g);
            //DrawTime(g, false);
            DisplayTime(g);
            g.Dispose();
            Invalidate();
        }
        /// <summary>
        /// Displays the time.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DisplayTime(Graphics g)
        {
            DateTime dt = DateTime.Now;
            if (clockType != ClockType.Freeze)
            {
                hour = dt.Hour;
                min = dt.Minute;
                sec = dt.Second;
                am_pm = ' ';
            }

            TimeSpan ts = TimeSpan.Zero;

            //check if alarm is set, raise them
            for (int i = 0; i < AlarmTimes.Count; i++)
            {
                if (dt > (DateTime)AlarmTimes[i] && RaiseAlarm != null)
                {
                    AlarmTimes.RemoveAt(i);
                    RaiseAlarm();
                }
                switch (clockType)
                {
                    case ClockType.AnalogClock:
                        if (clockFormat == ClockFormat.TwelveHour)
                            hour = dt.Hour % 12;
                        if (hour == 0)
                            hour = 12;
                        switch (clockFormat)
                        {
                            case ClockFormat.TwentyFourHour:
                                break;
                            case ClockFormat.TwelveHour:
                                am_pm = (dt.Hour / 12 > 0) ? 'P' : 'A';
                                break;
                        }
                        break;
                    case ClockType.CountDown:
                        ts = countDownTo.Subtract(dt);
                        if (ts < TimeSpan.Zero)
                        {
                            clockType = ClockType.AnalogClock;
                            ts = TimeSpan.Zero;
                            if (CountDownDone != null)
                            {
                                CountDownDone();
                            }
                        }
                        break;
                    case ClockType.StopWatch:
                        ts = dt.Subtract(this.stopWatch);
                        break;
                }
                if (am_pm == ' ')
                {

                }
            }
        } 
        #endregion
    }

    #endregion

    #endregion
}
