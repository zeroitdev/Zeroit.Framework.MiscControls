// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Blur.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a blur control.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    public partial class ZeroitBlurControl : Component
    {

        /// <summary>
        /// The control
        /// </summary>
        private Control control = new Control();
        /// <summary>
        /// The panel
        /// </summary>
        private Panel panel = new Panel();

        /// <summary>
        /// The blur level
        /// </summary>
        private int blurLevel = 4;

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control
        {
            get { return control; }
            set
            {
                control = value;
                //DrawBlur();
                control.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the blur.
        /// </summary>
        /// <value>The blur.</value>
        public int Blur
        {
            get { return blurLevel; }
            set
            {
                blurLevel = value;
                //DrawBlur();
                control.Invalidate();
            }
        }

        /// <summary>
        /// Draws the blur.
        /// </summary>
        public void DrawBlur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(control);
            BitmapFilter.GaussianBlur(bmp, blurLevel);

            PictureBox pb = new PictureBox();
            pb.Size = control.Size;
            pb.Location = control.Location;
            
            control.FindForm().Controls.Add(pb);
            
            //panel1.Controls.Add(pb);
            pb.Image = bmp;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            //pb.Dock = DockStyle.Fill;
            pb.BringToFront();
            //panel.BringToFront();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBlurControl" /> class.
        /// </summary>
        public ZeroitBlurControl()
        {
            //control.Paint += Control_Paint;
            
        }

        /// <summary>
        /// Handles the Paint event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Control_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //DrawBlur();
        }
    }



    /// <summary>
    /// Class ConvMatrix.
    /// </summary>
    public class ConvMatrix
    {
        /// <summary>
        /// The top left
        /// </summary>
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        /// <summary>
        /// The mid left
        /// </summary>
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        /// <summary>
        /// The bottom left
        /// </summary>
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        /// <summary>
        /// The factor
        /// </summary>
        public int Factor = 1;
        /// <summary>
        /// The offset
        /// </summary>
        public int Offset = 0;
        /// <summary>
        /// Sets all.
        /// </summary>
        /// <param name="nVal">The n value.</param>
        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }

    /// <summary>
    /// Class BitmapFilter.
    /// </summary>
    public class BitmapFilter
    {
        /// <summary>
        /// Conv3x3s the specified b.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="m">The m.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        /// <summary>
        /// Gaussians the blur.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="nWeight">The n weight.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return BitmapFilter.Conv3x3(b, m);
        }
    }

    /// <summary>
    /// Class Screenshot.
    /// </summary>
    class Screenshot
    {
        /// <summary>
        /// Takes the snapshot.
        /// </summary>
        /// <param name="ctl">The control.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap TakeSnapshot(Control ctl)
        {
            Bitmap bmp = new Bitmap(ctl.Size.Width, ctl.Size.Height);
            using (Graphics g = System.Drawing.Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(
                    ctl.PointToScreen(ctl.ClientRectangle.Location),
                    new Point(0, 0), ctl.ClientRectangle.Size
                );
            }
            return bmp;
        }
    }
}