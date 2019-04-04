// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Utils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Utility class for useful methods.
    /// </summary>
	public static class Utils
	{
        /// <summary>
        /// Position form so that it is centered beneath a control, adjusted to that it
        /// is entirely on the screen if possible.
        /// </summary>
        /// <param name="f">Form to position.</param>
        /// <param name="c">Control under which to position the form.</param>
        public static void SetStartPositionBelowControl(Form f, Control c)
		{
			// Get location so that f is on screen just below the center of c
			Point middleBottom = c.PointToScreen(new Point(c.Size.Width / 2, c.Size.Height));
			SetStartPosition(f, middleBottom);
		}

        /// <summary>
        /// Position form such that the center of the top edge is at a particular point,
        /// adjusted so that it is entirely on the screen if possible.
        /// </summary>
        /// <param name="f">Form to position.</param>
        /// <param name="p">Point at which to center the top edge of the form.</param>
		public static void SetStartPosition(Form f, Point p)
		{
			Screen screen = Screen.FromPoint(p);

			int left = p.X - f.Width/2;
			int right = left + f.Width;
			int top = p.Y;
			int bottom = p.Y + f.Height;

			// Adjust right then left, so that left edge is always on screen.
			if (right > screen.WorkingArea.Right)
			{
				left -= (right - screen.WorkingArea.Right - 1);
			}
			if (left < screen.WorkingArea.Left)
			{
				left = screen.WorkingArea.Left;
			}

			// Adjust bottom then top, so that top edge is always on screen
			if (bottom > screen.WorkingArea.Bottom)
			{
				top -= (bottom - screen.WorkingArea.Bottom - 1);
			}
			if (top < screen.WorkingArea.Top)
			{
				top = screen.WorkingArea.Top;
			}

			f.StartPosition = FormStartPosition.Manual;
			f.Location = new Point(left, top);
		}

        /// <summary>
        /// Generate a default color blend (red, green, blue)
        /// </summary>
        /// <returns>Default color blend.</returns>
		public static ColorBlend GetDefaultColorBlend()
		{
			ColorBlend cb = new ColorBlend(3);
			cb.Positions[0] = 0.0f;
			cb.Positions[1] = 0.5f;
			cb.Positions[2] = 1.0f;
			cb.Colors[0] = Color.FromArgb(255, Color.Red);
			cb.Colors[1] = Color.FromArgb(220, Color.Green);
			cb.Colors[2] = Color.FromArgb(255, Color.Blue);
			return cb;
		}

        /// <summary>
        /// Generate a <c>ColorBlend</c> object from two colors.
        /// </summary>
        /// <param name="color1">Starting color.</param>
        /// <param name="color2">Ending color.</param>
        /// <returns>New <c>ColorBlend</c> object.</returns>
		public static ColorBlend NewColorBlend(Color color1, Color color2)
		{
			return NewColorBlend(new Color[] { color1, color2 },
								 new float[] { 0.0f, 1.0f } );
		}

        /// <summary>
        /// Copy a <c>ColorBlend</c> object.
        /// </summary>
        /// <param name="cb">Source object to copy.</param>
        /// <returns>New <c>ColorBlend</c> object.  <c>Null</c> if source was <c>null</c>.</returns>
		public static ColorBlend CloneColorBlend(ColorBlend cb)
		{
			if (cb == null)
			{
				return null;
			}
			ColorBlend clone = new ColorBlend();
			clone.Colors = (Color[])cb.Colors.Clone();
			clone.Positions = (float[])cb.Positions.Clone();
			return clone;
		}

        /// <summary>
        /// Generate a <c>ColorBlend</c> object from an array of colors and array of positions.
        /// </summary>
        /// <param name="colors">Array of colors.</param>
        /// <param name="positions">Array of positions.</param>
        /// <returns>New <c>ColorBlend</c> object.</returns>
        /// <exception cref="ArgumentNullException">
        /// colors
        /// or
        /// positions
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="colors" /> or <paramref name="positions" /> is null.</exception>
		public static ColorBlend NewColorBlend(Color[] colors, float[] positions)
		{
			if (colors == null)
			{
				throw new ArgumentNullException("colors");
			}
			if (positions == null)
			{
				throw new ArgumentNullException("positions");
			}
			ColorBlend cb = new ColorBlend();
			cb.Colors = colors;
			cb.Positions = positions;
			return cb;
		}


        /// <summary>
        /// Generate a <c>ColorBlend</c> object from subsection of an existing color blend.
        /// </summary>
        /// <param name="cb"><c>ColorBlend</c> object.</param>
        /// <param name="minPos">Start position in <c>cb</c> of the subsection.</param>
        /// <param name="maxPos">End position in <c>cb</c> of the subsection.</param>
        /// <returns>New color blend.</returns>
        /// <exception cref="ArgumentNullException">cb</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// minPos - minPos must not be negative and must be less than maxPos
        /// or
        /// maxPos - maxPos must not be greater than one
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="cb" /> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="minPos" /> is less than zero,
        /// <paramref name="maxPos" /> is greater than one, or
        /// <paramref name="maxPos" /> is less than <paramref name="minPos" />.</exception>
		public static ColorBlend CalcSubColorBlend(ColorBlend cb, float minPos, float maxPos)
		{
			if (cb == null)
			{
				throw new ArgumentNullException("cb");
			}
			if (minPos < 0.0f || minPos >= maxPos)
			{
				throw new ArgumentOutOfRangeException("minPos", "minPos must not be negative and must be less than maxPos");
			}
			if (maxPos > 1.0f)
			{
				throw new ArgumentOutOfRangeException("maxPos", "maxPos must not be greater than one");
			}

			int minIdx = -1;
			for (int i = 0; i < cb.Positions.Length - 1; i++)
			{
				if (minPos < cb.Positions[i + 1])
				{
					minIdx = i;
					break;
				}
			}

			int maxIdx = -1;
			for (int i = cb.Positions.Length - 2; i >= 0; i--)
			{
				if (maxPos > cb.Positions[i])
				{
					maxIdx = i + 1;
					break;
				}
			}

			int count = maxIdx - minIdx + 1;
			Color[] colors = new Color[count];
			float[] positions = new float[count];

			float diffPos = maxPos - minPos;
			positions[0] = 0.0f;
			colors[0] = CalcColor(cb.Colors[minIdx], cb.Colors[minIdx + 1],
								  (minPos - cb.Positions[minIdx]) / (cb.Positions[minIdx + 1] - cb.Positions[minIdx]));
			for (int i = 1; i < count - 2; i++)
			{
				positions[i] = (cb.Positions[i] - minPos) / diffPos;
				colors[i] = cb.Colors[i];
			}
			positions[count - 1] = 1.0f;
			colors[count - 1] = CalcColor(cb.Colors[maxIdx - 1], cb.Colors[maxIdx],
										  (maxPos - cb.Positions[maxIdx - 1]) / (cb.Positions[maxIdx] - cb.Positions[maxIdx - 1]));

			return NewColorBlend(colors, positions);
		}

        /// <summary>
        /// Calculate the color for a particular position in a <c>ColorBlend</c> object.
        /// </summary>
        /// <param name="cb"><c>ColorBlend</c> object.</param>
        /// <param name="pos">Position in <c>cb</c>.</param>
        /// <returns>Color at position.</returns>
        /// <exception cref="ArgumentNullException">cb</exception>
        /// <exception cref="ArgumentOutOfRangeException">pos - pos must be greater than or equal to zero and less than or equal to one</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="cb" /> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="pos" /> is less than zero, or reater than one.</exception>
        public static Color CalcGradientColor(ColorBlend cb, float pos)
		{
			if (cb == null)
			{
				throw new ArgumentNullException("cb");
			}
			if (pos < 0.0f || pos > 1.0f)
			{
				throw new ArgumentOutOfRangeException("pos", "pos must be greater than or equal to zero and less than or equal to one");
			}

			// Find bordering values in cb
			int idx = 0;
			while (idx < cb.Positions.Length - 2)
			{
				if (pos <= cb.Positions[idx + 1])
				{
					break;
				}
				idx++;
			}

			// Positions[idx] >= pos >= Positions[idx+1]
			float ratio = (pos - cb.Positions[idx]) / (cb.Positions[idx + 1] - cb.Positions[idx]);
			return CalcColor(cb.Colors[idx], cb.Colors[idx + 1], ratio);
		}

        /// <summary>
        /// Generate a new color from a weighted combination of two other colors.
        /// </summary>
        /// <param name="color1">First color.</param>
        /// <param name="color2">Second color.</param>
        /// <param name="ratio">Ratio between first and second color.</param>
        /// <returns>New <c>Color</c> object.</returns>
		public static Color CalcColor(Color color1, Color color2, float ratio)
		{
			return Color.FromArgb(color1.A + (int)((float)(color2.A - color1.A) * ratio),
								  color1.R + (int)((float)(color2.R - color1.R) * ratio),
								  color1.G + (int)((float)(color2.G - color1.G) * ratio),
								  color1.B + (int)((float)(color2.B - color1.B) * ratio));
		}

        /// <summary>
        /// Generate a new <c>ColorBlend</c> which is a flipped version of an existing blend.
        /// </summary>
        /// <param name="oldcb">Blend to flip</param>
        /// <returns>New <c>ColorBlend</c> object.</returns>
		public static ColorBlend Flip(ColorBlend oldcb)
		{
			int count = oldcb.Colors.Length;
			ColorBlend newcb = new ColorBlend(count);
			for (int i = 0; i < count; i++)
			{
				newcb.Positions[i] = 1.0f - oldcb.Positions[count - i - 1];
				newcb.Colors[i] = oldcb.Colors[count - i - 1];
			}
			return newcb;
		}
	}
}
