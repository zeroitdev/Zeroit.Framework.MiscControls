// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Steps.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region Steps

    /// <summary>
    /// Class ZeroitSpiralTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class ZeroitSpiralTrackBar
    {
        // Control returns step-wise values, not continuous values.
        // Pre-calc all step values

        // All step arrays are the same length (# values)
        /// <summary>
        /// The step value
        /// </summary>
        private double[] stepValue;
        /// <summary>
        /// The step angle
        /// </summary>
        private double[] stepAngle;
        /// <summary>
        /// The step point
        /// </summary>
        private PointD[] stepPoint;
        /// <summary>
        /// The step slope
        /// </summary>
        private PointD[] stepSlope;

        /// <summary>
        /// The minimum last set
        /// </summary>
        private bool minimumLastSet; // was max the last one set? false if min

        // RecalcRange
        // - called when Minimum, Maximum, StepSize changed
        /// <summary>
        /// Recalcs the range.
        /// </summary>
        private void RecalcRange()
        {
            double range = maximum - minimum;
            double rem = range % stepSize;
            if (rem != 0.0)
            {
                double newRange = stepSize * Math.Ceiling(range / stepSize);
                if (minimumLastSet)
                {
                    maximum = minimum + newRange;
                }
                else
                {
                    minimum = maximum - newRange;
                }
            }
            stepCount = (int)((maximum - minimum) / stepSize) + 1;

            stepValue = new double[stepCount];
            stepValue[0] = minimum;
            stepValue[stepCount - 1] = maximum;
            for (int i = 1; i < stepCount - 1; i++)
            {
                stepValue[i] = minimum + i * stepSize;
            }
            RecalcValue(val);
        }

        // RecalcValue
        // - called when Minimum, Maximum, StepSize or Value changed
        // - always want Value to be matched to a stepValue
        /// <summary>
        /// Recalcs the value.
        /// </summary>
        /// <param name="oldVal">The old value.</param>
        private void RecalcValue(double oldVal)
        {
            if (oldVal <= minimum)
            {
                valueIndex = 0;
            }
            else if (oldVal >= maximum)
            {
                valueIndex = stepCount - 1;
            }
            else
            {
                // Use binary search
                // Most efficient?  Probably not, but avoids the problem of round off
                // errors while trying to calculate the index...
                // 
                // Improving this section left as an excerise for the reader.
                int iLo = 0;
                int iHi = stepCount - 1;
                while (iHi - iLo > 1)
                {
                    int iMid = (iHi + iLo) / 2;
                    if (oldVal >= stepValue[iMid])
                    {
                        iLo = iMid;
                    }
                    else
                    {
                        iHi = iMid;
                    }
                }

                // oldVal is between stepValue[iLo] and stepValue[iHi]
                // latch on to closest value
                double dLo = Math.Abs(oldVal - stepValue[iLo]);
                double dHi = Math.Abs(oldVal - stepValue[iHi]);
                if (dLo <= dHi)
                {
                    valueIndex = iLo;
                }
                else
                {
                    valueIndex = iHi;
                }
            }
            ValueIndexChanged();
            RecalcLayout();
        }

        /// <summary>
        /// The value index
        /// </summary>
        private int valueIndex; // "Value" as index into stepValue[]

        /// <summary>
        /// Values the index changed.
        /// </summary>
        private void ValueIndexChanged()
        {
            val = stepValue[valueIndex];
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
            DisposeMarkerPath();
        }

        // Calculate stepAngles / Points / Slopes
        /// <summary>
        /// Calculates the steps.
        /// </summary>
        private void CalcSteps()
        {
            stepAngle = new double[stepCount];
            stepAngle[0] = StartAngle;
            stepAngle[stepCount - 1] = StopAngle;

            if (stepCount > 2)
            {
                if (tickSpacing == SpiralTrackBarTickSpacing.Angular)
                {
                    // In angular mode - calc the angles 
                    double stepInc = (StopAngle - StartAngle) / (double)(stepCount - 1);
                    for (int i = 1; i < stepCount - 1; i++)
                    {
                        stepAngle[i] = startAngle + i * stepInc;
                    }
                }
                else
                {
                    // In arclength mode
                    double posInc = 1.0 / (stepCount - 1);
                    for (int i = 1; i < stepCount - 1; i++)
                    {
                        double pos = i * posInc;
                        stepAngle[i] = CalcAngle(pos);
                    }
                }
            }

            stepPoint = new PointD[stepCount];
            stepSlope = new PointD[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                stepPoint[i] = CalcPoint(stepAngle[i]);
                stepSlope[i] = CalcSlope(stepAngle[i], stepPoint[i]);
            }
        }
    }

    #endregion
}
