// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="EaseFunction.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Utils
{
    /// <summary>
    /// Enum EaseFunctionType
    /// </summary>
    public enum EaseFunctionType
    {
        /// <summary>
        /// The linear
        /// </summary>
        Linear,
        /// <summary>
        /// The quadratic
        /// </summary>
        Quadratic,
        /// <summary>
        /// The sine
        /// </summary>
        Sine,
        /// <summary>
        /// The cubic
        /// </summary>
        Cubic
    }

    /// <summary>
    /// Enum EaseMode
    /// </summary>
    public enum EaseMode
    {
        /// <summary>
        /// The in
        /// </summary>
        In,
        /// <summary>
        /// The out
        /// </summary>
        Out,
        /// <summary>
        /// The in out
        /// </summary>
        InOut
    }

    /// <summary>
    /// Delegate Func
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="percent">The percent.</param>
    /// <returns>T.</returns>
    public delegate T Func<T>(T percent);

    /// <summary>
    /// Class EaseFunction.
    /// </summary>
    public class EaseFunction
    {
        /// <summary>
        /// The m type
        /// </summary>
        private EaseFunctionType m_type = EaseFunctionType.Linear;
        /// <summary>
        /// The m d length
        /// </summary>
        private double m_dLength = 1000;//in ms
        /// <summary>
        /// The m d from
        /// </summary>
        private double m_dFrom = 0;
        /// <summary>
        /// The m d to
        /// </summary>
        private double m_dTo = 0;
        /// <summary>
        /// The m function
        /// </summary>
        private Func<double> m_function;

        /// <summary>
        /// Gets to value.
        /// </summary>
        /// <value>To value.</value>
        public double ToValue
        {
            get { return m_dTo; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EaseFunction"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="lengthMs">The length ms.</param>
        /// <param name="fromValue">From value.</param>
        /// <param name="toValue">To value.</param>
        public EaseFunction(EaseFunctionType type, EaseMode mode, double lengthMs, double fromValue, double toValue)
        {
            m_type = type;
            m_dLength = lengthMs;
            m_dFrom = fromValue;
            m_dTo = toValue;

            m_function = GetEasingFunction(m_type);
            if (mode != EaseMode.InOut)
            {
                m_function = TransformEase(m_function, (mode == EaseMode.In));
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="curMs">The current ms.</param>
        /// <returns>System.Double.</returns>
        /// <exception cref="ArgumentOutOfRangeException">curMs</exception>
        public double GetValue(double curMs)
        {
            if (curMs > m_dLength)
            {
                throw new ArgumentOutOfRangeException("curMs");
            }

            //compute what percentage (0 - 1) we are through the function
            double percentEase = curMs / m_dLength;
            double percentValue = m_function(percentEase);

            //be sure to return a value within from/to range
            double dValue = m_dFrom + ((m_dTo - m_dFrom) * percentValue);
            if (m_dFrom <= m_dTo)
            {
                dValue = Math.Min(dValue, m_dTo);
            }
            else
            {
                dValue = Math.Max(dValue, m_dTo);
            }

            return dValue;
        }

        /// <summary>
        /// Return a function that maps the percentage of the easing function
        /// to the percentage between the begin and end values. This function
        /// is a EaseInOut function that can be transformed to EaseIn or EaseOut
        /// <para>
        /// The function returned MUST MEET 3 REQUIREMENTS:
        /// 1) f(0) = 0
        /// 2) f(1/2) = 1/2
        /// 3) f(1) = 1
        /// </para>
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Func&lt;System.Double&gt;.</returns>
        /// <exception cref="NotImplementedException">Easing function not supported</exception>
        private static Func<double> GetEasingFunction(EaseFunctionType type)
        {
            Func<double> func = null;

            switch (type)
            {
                case EaseFunctionType.Linear:
                    func = d => d;
                    break;
                case EaseFunctionType.Quadratic:
                    func = GetPowerEase(2);
                    break;
                case EaseFunctionType.Cubic:
                    func = GetPowerEase(3);
                    break;
                case EaseFunctionType.Sine:
                    func = d => (Math.Sin((d - .5) * Math.PI) + 1) / 2d;
                    break;
                default:
                    throw new NotImplementedException("Easing function not supported");
            }

            return func;
        }

        /// <summary>
        /// Gets the power ease.
        /// </summary>
        /// <param name="power">The power.</param>
        /// <returns>Func&lt;System.Double&gt;.</returns>
        private static Func<double> GetPowerEase(int power)
        {
            return d =>
            {
                double dReturn = 0;

                if (d <= .5)
                {
                    dReturn = Math.Pow((d * 2), power) / 2d;
                }
                else
                {
                    double opposite = Math.Pow(((1 - d) * 2), power) / 2d;
                    dReturn = 1 - opposite;
                }

                return dReturn;
            };
        }

        /// <summary>
        /// Transforms the ease.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="bToEaseIn">if set to <c>true</c> [b to ease in].</param>
        /// <returns>Func&lt;System.Double&gt;.</returns>
        private static Func<double> TransformEase(Func<double> original, bool bToEaseIn)
        {
            Func<double> newFunc = null;

            if (bToEaseIn)
            {
                //use the first half of the function ([0, .5])
                newFunc = percent =>
                {
                    return original(percent / 2d) * 2d;
                };
            }
            else
            {
                //use the second half of the function ([.5, 1])
                newFunc = percent =>
                {
                    return (original((percent / 2d) + .5d) -.5d) * 2d;
                };
            }

            return newFunc;
        }
    }
}
