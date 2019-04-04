// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CBitmapOps.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.MiscControls
{
    #region CBitmapOps

    /// <summary>
    /// Class CBitmapOps.
    /// </summary>
    public class CBitmapOps
    {

        /// <summary>
        /// Does the bit ops for bitmap.
        /// </summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <param name="ops">The ops.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap DoBitOpsForBitmap(Bitmap m1, Bitmap m2, string ops)
        {
            //assuming m1 and m2 are same width and height
            //direct bit manipulation

            //get the max size, fill default white
            int m3h, m3w;
            m3h = (m1.Height > m2.Height ? m1.Height : m2.Height);
            m3w = (m1.Width > m2.Width ? m1.Width : m2.Width);

            Bitmap m3 = new Bitmap(m3w, m3h, m1.PixelFormat);
            Graphics.FromImage(m3).FillRectangle(new SolidBrush(Color.White), 0, 0, m3w, m3h);

            Rectangle rect1 = new Rectangle(0, 0, m1.Width, m1.Height);
            Rectangle rect2 = new Rectangle(0, 0, m2.Width, m2.Height);
            Rectangle rect3 = new Rectangle(0, 0, m3.Width, m3.Height);

            BitmapData bmpData1 =
                     m1.LockBits(rect1, ImageLockMode.ReadOnly,
                     m1.PixelFormat);
            BitmapData bmpData2 =
                     m2.LockBits(rect2, ImageLockMode.ReadOnly,
                     m2.PixelFormat);
            BitmapData bmpData3 =
                     m3.LockBits(rect3, ImageLockMode.ReadWrite,
                     m3.PixelFormat);
            IntPtr ptr1 = bmpData1.Scan0;
            IntPtr ptr2 = bmpData2.Scan0;
            IntPtr ptr3 = bmpData3.Scan0;

            int bytes1 = m1.Width * m1.Height * 4;
            int bytes2 = m2.Width * m2.Height * 4;
            int bytes3 = m3.Width * m3.Height * 4;

            byte[] rgbValues1 = new byte[bytes1];
            byte[] rgbValues2 = new byte[bytes2];
            byte[] rgbValues3 = new byte[bytes3];



            //byte r = 0, g = 0, b = 0;
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr1, rgbValues1, 0, bytes1);
            System.Runtime.InteropServices.Marshal.Copy(ptr2, rgbValues2, 0, bytes2);
            System.Runtime.InteropServices.Marshal.Copy(ptr3, rgbValues3, 0, bytes3);
            /*
            if(ops.Equals("xor"))
            for (int j = 0; j < m1.Height; j++)
                for (int i = 0; i < m1.Width; i++)
                {

                    int index = CoordsToIndex(i, j, bmpData1.Stride);
                    rgbValues3[index] = (byte)((int)rgbValues1[index] ^ (int)rgbValues2[index]);
                    rgbValues3[index + 1] = (byte)((int)rgbValues1[index+1] ^ (int)rgbValues2[index+1]); 
                    rgbValues3[index + 2] = (byte)((int)rgbValues1[index+2] ^ (int)rgbValues2[index+2]);
                    rgbValues3[index + 3] = (byte)((int)rgbValues1[index + 3]) ; 
                }
            */
            //  if (ops.Equals("AND"))
            //  {
            for (int j = 0; j < m1.Height; j++)
                for (int i = 0; i < m1.Width; i++)
                {

                    int index = CoordsToIndex(i, j, bmpData1.Stride);
                    int index3 = CoordsToIndex(i, j, bmpData3.Stride);

                    rgbValues3[index3] = rgbValues1[index];
                    rgbValues3[index3 + 1] = rgbValues1[index + 1];
                    rgbValues3[index3 + 2] = rgbValues1[index + 2];
                    rgbValues3[index3 + 3] = rgbValues1[index + 3];
                }

            for (int j = 0; j < m2.Height; j++)
                for (int i = 0; i < m2.Width; i++)
                {

                    int index = CoordsToIndex(i, j, bmpData2.Stride);
                    int index3 = CoordsToIndex(i, j, bmpData3.Stride);

                    switch (ops)
                    {
                        case "AND":
                            rgbValues3[index3] = (byte)((int)rgbValues3[index3] & (int)rgbValues2[index]);
                            rgbValues3[index3 + 1] = (byte)((int)rgbValues3[index3 + 1] & (int)rgbValues2[index + 1]);
                            rgbValues3[index3 + 2] = (byte)((int)rgbValues3[index3 + 2] & (int)rgbValues2[index + 2]);
                            rgbValues3[index3 + 3] = (byte)((int)rgbValues2[index + 3]);
                            break;
                        case "OR":
                            rgbValues3[index3] = (byte)((int)rgbValues3[index3] | (int)rgbValues2[index]);
                            rgbValues3[index3 + 1] = (byte)((int)rgbValues3[index3 + 1] | (int)rgbValues2[index + 1]);
                            rgbValues3[index3 + 2] = (byte)((int)rgbValues3[index3 + 2] | (int)rgbValues2[index + 2]);
                            rgbValues3[index3 + 3] = (byte)((int)rgbValues2[index + 3]);
                            break;


                    }
                }


            // }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues3, 0, ptr3, bytes3);
            // Unlock the bits.
            m1.UnlockBits(bmpData1);
            m2.UnlockBits(bmpData2);
            m3.UnlockBits(bmpData3);
            return m3;
        }

        //for argb color pixel format
        /// <summary>
        /// Coordses to index.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="stride">The stride.</param>
        /// <returns>System.Int32.</returns>
        private static int CoordsToIndex(int x, int y, int stride)
        {
            return (stride * y) + (x * 4);
        }

        /// <summary>
        /// Does the invert bitmap.
        /// </summary>
        /// <param name="bm">The bm.</param>
        public static void DoInvertBitmap(Bitmap bm)
        {
            //direct bit manipulation
            Rectangle rect = new Rectangle(0, 0, bm.Width, bm.Height);
            BitmapData bmpData =
                     bm.LockBits(rect, ImageLockMode.ReadWrite,
                     bm.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bm.Width * bm.Height * 4;
            byte[] rgbValues = new byte[bytes];
            //byte r = 0, g = 0, b = 0;
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);


            for (int j = 0; j < bm.Height; j++)
                for (int i = 0; i < bm.Width; i++)
                {

                    int index = CoordsToIndex(i, j, bmpData.Stride);
                    rgbValues[index] = (byte)(255 - rgbValues[index]);
                    rgbValues[index + 1] = (byte)(255 - rgbValues[index + 1]);
                    rgbValues[index + 2] = (byte)(255 - rgbValues[index + 2]);


                }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            // Unlock the bits.
            bm.UnlockBits(bmpData);

        }

    }

    #endregion
}
