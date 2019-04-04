// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ThemedColors.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.MiscControls.Tabs
{

    /// <summary>
    /// Class ThemedColors. This class cannot be inherited.
    /// </summary>
    internal sealed class ThemedColors
	{

        #region "    Variables and Constants "

        /// <summary>
        /// The normal color
        /// </summary>
        private const string NormalColor = "NormalColor";
        /// <summary>
        /// The home stead
        /// </summary>
        private const string HomeStead = "HomeStead";
        /// <summary>
        /// The metallic
        /// </summary>
        private const string Metallic = "Metallic";
        /// <summary>
        /// The no theme
        /// </summary>
        private const string NoTheme = "NoTheme";

        /// <summary>
        /// The tool border
        /// </summary>
        private static Color[] _toolBorder;
        #endregion

        #region "    Properties "

        /// <summary>
        /// Gets the index of the current theme.
        /// </summary>
        /// <value>The index of the current theme.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public static ColorScheme CurrentThemeIndex {
			get { return ThemedColors.GetCurrentThemeIndex(); }
		}

        /// <summary>
        /// Gets the tool border.
        /// </summary>
        /// <value>The tool border.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public static Color ToolBorder {
			get { return ThemedColors._toolBorder[(int)ThemedColors.CurrentThemeIndex]; }
		}

        #endregion

        #region "    Constructors "

        /// <summary>
        /// Initializes static members of the <see cref="ThemedColors"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static ThemedColors() {
			ThemedColors._toolBorder = new Color[] {Color.FromArgb(127, 157, 185), Color.FromArgb(164, 185, 127), Color.FromArgb(165, 172, 178), Color.FromArgb(132, 130, 132)};
		}

        /// <summary>
        /// Prevents a default instance of the <see cref="ThemedColors"/> class from being created.
        /// </summary>
        private ThemedColors(){}

        #endregion

        /// <summary>
        /// Gets the index of the current theme.
        /// </summary>
        /// <returns>ColorScheme.</returns>
        private static ColorScheme GetCurrentThemeIndex()
		{
			ColorScheme theme = ColorScheme.NoTheme;

			if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
			{


				switch (VisualStyleInformation.ColorScheme) {
					case NormalColor:
						theme = ColorScheme.NormalColor;
						break;
					case HomeStead:
						theme = ColorScheme.HomeStead;
						break;
					case Metallic:
						theme = ColorScheme.Metallic;
						break;
					default:
						theme = ColorScheme.NoTheme;
						break;
				}
			}

			return theme;
		}

        /// <summary>
        /// Enum ColorScheme
        /// </summary>
        public enum ColorScheme
		{
            /// <summary>
            /// The normal color
            /// </summary>
            NormalColor = 0,
            /// <summary>
            /// The home stead
            /// </summary>
            HomeStead = 1,
            /// <summary>
            /// The metallic
            /// </summary>
            Metallic = 2,
            /// <summary>
            /// The no theme
            /// </summary>
            NoTheme = 3
		}

	}

}
