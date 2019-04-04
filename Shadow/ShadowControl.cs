// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ShadowControl.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Class ShadowControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    class ShadowControl : Control
    {

        /// <summary>
        /// The shadow opacity
        /// </summary>
        private float shadowOpacity = 10;
        /// <summary>
        /// The shadow size
        /// </summary>
        private int shadowSize = 2;
        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor = Color.Black;
        /// <summary>
        /// The angle
        /// </summary>
        private int angle = 0;
        /// <summary>
        /// The shadow distance
        /// </summary>
        private int shadowDistance = 20;
        /// <summary>
        /// The main background color
        /// </summary>
        private Color mainBackgroundColor = Color.White;

        /// <summary>
        /// The main loc
        /// </summary>
        Point mainLoc;

        /// <summary>
        /// The mainrect
        /// </summary>
        Size mainrect;

        /// <summary>
        /// Gets or sets the shadow opacity.
        /// </summary>
        /// <value>The shadow opacity.</value>
        public float ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                shadowOpacity = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the shadow.
        /// </summary>
        /// <value>The size of the shadow.</value>
        public int ShadowSize
        {
            get { return shadowSize; }
            set
            {
                shadowSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        public int Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow distance.
        /// </summary>
        /// <value>The shadow distance.</value>
        public int ShadowDistance
        {
            get { return shadowDistance; }
            set
            {
                shadowDistance = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the main background.
        /// </summary>
        /// <value>The color of the main background.</value>
        public Color MainBackgroundColor
        {
            get { return mainBackgroundColor; }
            set
            {
                mainBackgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowControl" /> class.
        /// </summary>
        public ShadowControl()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            mainrect = new Size(Width, Height);
            mainLoc = ClientRectangle.Location;

        }

        /// <summary>
        /// Creates the shadow.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void CreateShadow(PaintEventArgs e)
        {
            //High quality graphic
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            #region Creating Maximum Alpha

            int temp1 = (int)((shadowOpacity / 100) * 255);

            int needalpha = 0;

            if (temp1 % shadowSize == 0)
            {
                needalpha = temp1;
            }
            else
            {
                needalpha = shadowSize * (temp1 / shadowSize);
            }

            #endregion

            #region Create Graphic for drawing Shadow

            Bitmap bms = new Bitmap(this.Size.Width, this.Size.Height);

            Graphics gp = Graphics.FromImage(bms);
            gp.SmoothingMode = SmoothingMode.HighQuality;


            #endregion

            #region Draw Shadow

            //Draw main control with shadow color

            gp.FillRectangle(new SolidBrush(Color.FromArgb(needalpha, shadowColor)),
                new Rectangle(shadowSize,shadowSize,mainrect.Width, mainrect.Height));

            //Draw Blur effect shadow

            for(int i = 0; i < shadowSize; i++)
            {
                // Blur left Shadow
                gp.FillRectangle(new SolidBrush(Color.FromArgb(needalpha / shadowSize, shadowColor)),
                    new Rectangle(i,shadowSize, shadowSize - i, mainrect.Height));

                // Blur right Shadow
                gp.FillRectangle(new SolidBrush(Color.FromArgb(needalpha / shadowSize, shadowColor)),
                    new Rectangle(mainrect.Width + shadowSize, shadowSize, shadowSize - i, mainrect.Height));

                // Blur top Shadow
                gp.FillRectangle(new SolidBrush(Color.FromArgb(needalpha / shadowSize, shadowColor)),
                    new Rectangle(shadowSize,i, mainrect.Width, shadowSize - i));
                
                // Blur bottom Shadow
                gp.FillRectangle(new SolidBrush(Color.FromArgb(needalpha / shadowSize, shadowColor)),
                    new Rectangle(shadowSize, mainrect.Height + shadowSize, mainrect.Width, shadowSize - i));

                // Blur bottom right corner
                gp.DrawArc(new Pen(new SolidBrush(Color.FromArgb((needalpha / shadowSize) * i, shadowColor)), 1),
                    mainrect.Width + i, mainrect.Height + i, shadowSize * 2 - 2 * i, shadowSize * 2 - 2 * i, 0, 90);


                // Blur top left corner
                gp.DrawArc(new Pen(new SolidBrush(Color.FromArgb((needalpha / shadowSize) * i, shadowColor)), 1),
                    i,i, shadowSize * 2 - 2 * i, shadowSize * 2 - 2 * i, 180, 90);


                // Blur bottom left corner
                gp.DrawArc(new Pen(new SolidBrush(Color.FromArgb((needalpha / shadowSize) * i, shadowColor)), 1),
                    i, mainrect.Height + i, shadowSize * 2 - 2 * i, shadowSize * 2 - 2 * i, 90, 90);

                // Blur top right corner
                gp.DrawArc(new Pen(new SolidBrush(Color.FromArgb((needalpha / shadowSize) * i, shadowColor)), 1),
                    mainrect.Width + i, i, shadowSize * 2 - 2 * i, shadowSize * 2 - 2 * i, 270, 90);


            }

            #endregion

            #region Draw Shadow on Control

            //Convert angle to distance

            switch (angle)
            {
                case 0:
                    e.Graphics.DrawImage(bms, mainLoc.X - shadowSize + shadowDistance, mainLoc.Y - shadowSize);
        
                    break;

                case 90:
                    e.Graphics.DrawImage(bms, mainLoc.X - shadowSize, mainLoc.Y - shadowSize + shadowDistance);
                    break;

                case 180:
                    e.Graphics.DrawImage(bms, mainLoc.X - shadowSize - shadowDistance, mainLoc.Y - shadowSize);
                    break;

                case 270:
                    e.Graphics.DrawImage(bms, mainLoc.X - shadowSize, mainLoc.Y - shadowSize - shadowDistance);
                    break;
                default:

                    if(angle < 90)
                    {
                        e.Graphics.DrawImage(bms, mainLoc.X - shadowSize + ((shadowDistance * (90 - angle)) / 90),
                            mainLoc.Y - shadowSize + ((angle * shadowDistance) / 90));
             
                    }

                    else if(angle < 180)
                    {
                        e.Graphics.DrawImage(bms, mainLoc.X - shadowSize - ((shadowDistance * (angle - 90)) / 90),
                            mainLoc.Y - shadowSize + (shadowDistance * (180 - angle) / 90));
                    }

                    else if(angle < 270)
                    {
                        e.Graphics.DrawImage(bms, mainLoc.X - shadowSize - (((270 - angle) * shadowDistance) / 90), 
                            mainLoc.Y - shadowSize - ((angle - 180) * shadowDistance) / 90);
                    }

                    else
                    {
                        e.Graphics.DrawImage(bms, mainLoc.X - shadowSize + (shadowDistance * (angle - 270)) / 90, 
                            mainLoc.Y - shadowSize - ((360 - angle) * shadowDistance) / 90);
                    }

                    break;
            }
            #endregion

            #region Draw Main Control

            e.Graphics.FillRectangle(new SolidBrush(mainBackgroundColor), new Rectangle(mainLoc, mainrect));

            #endregion
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CreateShadow(e);
        }
    }
        
}
