// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="HitTestInfo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents class holding information relatedd to hittest.
    /// </summary>
    public class HitTestInfo
    {
        /// <summary>
        /// The area
        /// </summary>
        private readonly HitArea area;
        /// <summary>
        /// The button index
        /// </summary>
        private readonly int buttonIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="HitTestInfo" /> class.
        /// </summary>
        /// <param name="buttonIndex">Index of button</param>
        /// <param name="area"><see cref="HitArea" /> representing what was hit area of a given point.</param>
        public HitTestInfo(int buttonIndex, HitArea area)
        {
            this.buttonIndex = buttonIndex;
            this.area = area;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HitTestInfo" /> class.
        /// </summary>
        /// <param name="area"><see cref="HitArea" /> representing what was hit area of a given point.</param>
        public HitTestInfo(HitArea area)
        {
            buttonIndex = -1;
            this.area = area;
        }

        /// <summary>
        /// Gets Index of <see cref="BarItem" /> in <see cref="ZeroitToxicButton" /> as per hitest result. Returs -1 if there is no button at given point.
        /// </summary>
        /// <value>The index of the button.</value>
        public int ButtonIndex
        {
            get { return buttonIndex; }
        }

        /// <summary>
        /// <see cref="HitArea" /> representing what was hit area of a given point.
        /// </summary>
        /// <value>The area.</value>
        public HitArea Area
        {
            get { return area; }
        }
    }
}