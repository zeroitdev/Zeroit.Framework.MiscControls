// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Range.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class Range.
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Gets the target wrapper.
        /// </summary>
        /// <value>The target wrapper.</value>
        public ITextBoxWrapper TargetWrapper { get; private set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public int Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public int End { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="targetWrapper">The target wrapper.</param>
        public Range(ITextBoxWrapper targetWrapper)
        {
            this.TargetWrapper = targetWrapper;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                var text = TargetWrapper.Text;
                
                if (string.IsNullOrEmpty(text))
                    return "";
                if (Start >= text.Length)
                    return "";
                if (End > text.Length)
                    return "";

                return TargetWrapper.Text.Substring(Start, End - Start);
            }

            set
            {
                TargetWrapper.SelectionStart = Start;
                TargetWrapper.SelectionLength = End - Start;
                TargetWrapper.SelectedText = value;
            }
        }
    }
}
