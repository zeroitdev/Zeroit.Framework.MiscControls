// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="ColorSchemeDefinition.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ColorSchemeDefinition.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    internal class ColorSchemeDefinition : IDisposable
    {
        /// <summary>
        /// The blue
        /// </summary>
        private static ColorSchemeDefinition blue;
        /// <summary>
        /// The classic
        /// </summary>
        private static ColorSchemeDefinition classic;
        /// <summary>
        /// The default
        /// </summary>
        private static ColorSchemeDefinition @default;
        /// <summary>
        /// The olive green
        /// </summary>
        private static ColorSchemeDefinition oliveGreen;
        /// <summary>
        /// The royale
        /// </summary>
        private static ColorSchemeDefinition royale;
        /// <summary>
        /// The silver
        /// </summary>
        private static ColorSchemeDefinition silver;
        /// <summary>
        /// The v S2005
        /// </summary>
        private static ColorSchemeDefinition vS2005;
        /// <summary>
        /// The base color scheme
        /// </summary>
        private readonly ColorScheme baseColorScheme;
        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme colorScheme;
        /// <summary>
        /// The color table
        /// </summary>
        private Hashtable colorTable;


        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSchemeDefinition"/> class.
        /// </summary>
        /// <param name="baseColorScheme">The base color scheme.</param>
        protected ColorSchemeDefinition(ColorScheme baseColorScheme)
        {
            this.baseColorScheme = baseColorScheme;
            Initialize();
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        /// <summary>
        /// Gets the bar back style.
        /// </summary>
        /// <value>The bar back style.</value>
        public virtual ColorPair BarBackStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.BarBackStyle]; }
        }

        /// <summary>
        /// Gets the back style.
        /// </summary>
        /// <value>The back style.</value>
        public virtual ColorPair BackStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.BackStyle]; }
        }

        /// <summary>
        /// Gets the click style.
        /// </summary>
        /// <value>The click style.</value>
        public virtual ColorPair ClickStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.ClickStyle]; }
        }

        /// <summary>
        /// Gets the focused border.
        /// </summary>
        /// <value>The focused border.</value>
        public virtual Color FocusedBorder
        {
            get { return (Color) colorTable[ColorIndex.FocusedBorder]; }
        }

        /// <summary>
        /// Gets the bar focused border.
        /// </summary>
        /// <value>The bar focused border.</value>
        public virtual Color BarFocusedBorder
        {
            get { return (Color) colorTable[ColorIndex.BarFocusedBorder]; }
        }

        /// <summary>
        /// Gets the bar normal border.
        /// </summary>
        /// <value>The bar normal border.</value>
        public virtual Color BarNormalBorder
        {
            get { return (Color) colorTable[ColorIndex.BarNormalBorder]; }
        }

        /// <summary>
        /// Gets the selected border.
        /// </summary>
        /// <value>The selected border.</value>
        public virtual Color SelectedBorder
        {
            get { return (Color) colorTable[ColorIndex.SelectedBorder]; }
        }

        /// <summary>
        /// Gets the disabled mask.
        /// </summary>
        /// <value>The disabled mask.</value>
        public virtual Color DisabledMask
        {
            get { return (Color) colorTable[ColorIndex.DisabledMask]; }
        }

        /// <summary>
        /// Gets the gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public virtual int GradientMode
        {
            get { return 90; }
        }

        /// <summary>
        /// Gets the hover border.
        /// </summary>
        /// <value>The hover border.</value>
        public virtual Color HoverBorder
        {
            get { return (Color) colorTable[ColorIndex.HoverBorder]; }
        }

        /// <summary>
        /// Gets the hover fore ground.
        /// </summary>
        /// <value>The hover fore ground.</value>
        public virtual Color HoverForeGround
        {
            get { return (Color) colorTable[ColorIndex.HoverForeGround]; }
        }

        /// <summary>
        /// Gets the hover style.
        /// </summary>
        /// <value>The hover style.</value>
        public virtual ColorPair HoverStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.HoverStyle]; }
        }

        /// <summary>
        /// Gets the normal border.
        /// </summary>
        /// <value>The normal border.</value>
        public virtual Color NormalBorder
        {
            get { return (Color) colorTable[ColorIndex.NormalBorder]; }
        }

        /// <summary>
        /// Gets the normal fore ground.
        /// </summary>
        /// <value>The normal fore ground.</value>
        public virtual Color NormalForeGround
        {
            get { return (Color) colorTable[ColorIndex.NormalForeGround]; }
        }

        /// <summary>
        /// Gets the selected fore ground.
        /// </summary>
        /// <value>The selected fore ground.</value>
        public virtual Color SelectedForeGround
        {
            get { return (Color) colorTable[ColorIndex.SelectedForeGround]; }
        }

        /// <summary>
        /// Gets the selected hover style.
        /// </summary>
        /// <value>The selected hover style.</value>
        public virtual ColorPair SelectedHoverStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.SelectedHoverStyle]; }
        }

        /// <summary>
        /// Gets the selected style.
        /// </summary>
        /// <value>The selected style.</value>
        public virtual ColorPair SelectedStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.SelectedStyle]; }
        }

        /// <summary>
        /// Gets the disabled style.
        /// </summary>
        /// <value>The disabled style.</value>
        public virtual ColorPair DisabledStyle
        {
            get { return (ColorPair) colorTable[ColorIndex.DisabledStyle]; }
        }

        /// <summary>
        /// Gets the disabled border.
        /// </summary>
        /// <value>The disabled border.</value>
        public virtual Color DisabledBorder
        {
            get { return (Color) colorTable[ColorIndex.DisabledBorder]; }
        }

        /// <summary>
        /// Gets the disabled fore ground.
        /// </summary>
        /// <value>The disabled fore ground.</value>
        public virtual Color DisabledForeGround
        {
            get { return (Color) colorTable[ColorIndex.DisabledForeGround]; }
        }

        /// <summary>
        /// Gets the base color scheme.
        /// </summary>
        /// <value>The base color scheme.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ColorScheme BaseColorScheme
        {
            get { return baseColorScheme; }
        }

        /// <summary>
        /// Gets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
        }

        /// <summary>
        /// Gets the current visual style color scheme.
        /// </summary>
        /// <value>The current visual style color scheme.</value>
        private static string CurrentVisualStyleColorScheme
        {
            get
            {
                if (!UXTHEME.IsThemeActive())
                {
                    return null;
                }
                var builder = new StringBuilder(255);
                var builder2 = new StringBuilder(255);
                UXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
                return builder2.ToString();
            }
        }

        /// <summary>
        /// Gets the name of the current visual style theme file.
        /// </summary>
        /// <value>The name of the current visual style theme file.</value>
        private static string CurrentVisualStyleThemeFileName
        {
            get
            {
                if (!IsThemeActive)
                {
                    return null;
                }
                var builder = new StringBuilder(255);
                var builder2 = new StringBuilder(255);
                UXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets the default color scheme.
        /// </summary>
        /// <value>The default color scheme.</value>
        public static ColorScheme DefaultColorScheme
        {
            get
            {
                const ColorScheme colorScheme1 = ColorScheme.Classic;
                if (!IsThemeActive)
                {
                    return colorScheme1;
                }
                string themeFile = Path.GetFileName(CurrentVisualStyleThemeFileName);
                string currentTheme = CurrentVisualStyleColorScheme;
                if (string.Compare(themeFile, "LUNA.MSSTYLES", true) != 0)
                {
                    if (string.Compare(themeFile, "Aero.msstyles", true) != 0)
                    {
                        return colorScheme1;
                    }
                    return ColorScheme.Classic;
                }
                if (!string.IsNullOrEmpty(currentTheme))
                {
                    if (string.Compare(themeFile, "HOMESTEAD", true) != 0)
                    {
                        return ColorScheme.OliveGreen;
                    }
                    if (string.Compare(themeFile, "METALLIC", true) != 0)
                    {
                        return ColorScheme.Silver;
                    }
                }
                return ColorScheme.Blue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is theme active.
        /// </summary>
        /// <value><c>true</c> if this instance is theme active; otherwise, <c>false</c>.</value>
        internal static bool IsThemeActive
        {
            get
            {
                if (Environment.OSVersion.Version >= new Version(5, 1))
                {
                    while (OSFeature.Feature.GetVersionPresent(OSFeature.Themes) != null)
                    {
                        return UXTHEME.IsThemeActive();
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the v S2005.
        /// </summary>
        /// <value>The v S2005.</value>
        public static ColorSchemeDefinition VS2005
        {
            get
            {
                if (vS2005 == null)
                {
                    vS2005 = new ColorSchemeDefinition(ColorScheme.VS2005);
                }
                return vS2005;
            }
        }

        /// <summary>
        /// Gets the classic.
        /// </summary>
        /// <value>The classic.</value>
        public static ColorSchemeDefinition Classic
        {
            get
            {
                if (classic == null)
                {
                    classic = new ColorSchemeDefinition(ColorScheme.Classic);
                }
                return classic;
            }
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>The default.</value>
        public static ColorSchemeDefinition Default
        {
            get
            {
                if (@default == null)
                {
                    @default = new ColorSchemeDefinition(ColorScheme.Default);
                }
                return @default;
            }
        }

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public static ColorSchemeDefinition Blue
        {
            get
            {
                if (blue == null)
                {
                    blue = new ColorSchemeDefinition(ColorScheme.Blue);
                }
                return blue;
            }
        }

        /// <summary>
        /// Gets the olive green.
        /// </summary>
        /// <value>The olive green.</value>
        public static ColorSchemeDefinition OliveGreen
        {
            get
            {
                if (oliveGreen == null)
                {
                    oliveGreen = new ColorSchemeDefinition(ColorScheme.OliveGreen);
                }
                return oliveGreen;
            }
        }

        /// <summary>
        /// Gets the royale.
        /// </summary>
        /// <value>The royale.</value>
        public static ColorSchemeDefinition Royale
        {
            get
            {
                if (royale == null)
                {
                    royale = new ColorSchemeDefinition(ColorScheme.Royale);
                }
                return royale;
            }
        }

        /// <summary>
        /// Gets the silver.
        /// </summary>
        /// <value>The silver.</value>
        public static ColorSchemeDefinition Silver
        {
            get
            {
                if (silver == null)
                {
                    silver = new ColorSchemeDefinition(ColorScheme.Silver);
                }
                return silver;
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            colorTable = null;
        }

        #endregion

        /// <summary>
        /// Handles the <see cref="E:UserPreferenceChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UserPreferenceChangedEventArgs"/> instance containing the event data.</param>
        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Color)
            {
                Initialize();
            }
        }

        /// <summary>
        /// Initializes the common.
        /// </summary>
        private void InitializeCommon()
        {
            colorTable[ColorIndex.ClickStyle] = new ColorPair(Color.FromArgb(251, 147, 64), Color.FromArgb(255, 208, 99));
            colorTable[ColorIndex.SelectedHoverStyle] = new ColorPair(Color.FromArgb(241, 164, 34),
                                                                      Color.FromArgb(251, 231, 156));
            colorTable[ColorIndex.SelectedStyle] = new ColorPair(Color.FromArgb(251, 231, 156),
                                                                 Color.FromArgb(240, 163, 34));
            colorTable[ColorIndex.HoverStyle] = new ColorPair(Color.FromArgb(255, 254, 216),
                                                              Color.FromArgb(255, 216, 106));
        }

        /// <summary>
        /// Initializes the silver.
        /// </summary>
        private void InitializeSilver()
        {
            colorTable[ColorIndex.BarBackStyle] = new ColorPair(Color.FromArgb(222, 223, 234),
                                                                Color.FromArgb(152, 150, 179));
            colorTable[ColorIndex.BackStyle] = new ColorPair(Color.FromArgb(222, 223, 234),
                                                             Color.FromArgb(152, 150, 179));
            colorTable[ColorIndex.FocusedBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.SelectedBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.HoverBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.HoverForeGround] = Color.DarkGray;
            colorTable[ColorIndex.NormalBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.NormalForeGround] = Color.Gray;
            colorTable[ColorIndex.SelectedForeGround] = Color.Gray;
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(Color.Transparent, Color.Transparent);
            colorTable[ColorIndex.DisabledBorder] = Color.FromArgb(197, 199, 199);
            colorTable[ColorIndex.DisabledForeGround] = Color.Gray;
            colorTable[ColorIndex.BarNormalBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.BarFocusedBorder] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.DisabledMask] = Color.FromArgb(222, 223, 234);
        }

        /// <summary>
        /// Initializes the royale.
        /// </summary>
        private void InitializeRoyale()
        {
            colorTable[ColorIndex.BarBackStyle] = new ColorPair(Color.FromArgb(233, 236, 248),
                                                                Color.FromArgb(218, 221, 225));
            colorTable[ColorIndex.BackStyle] = new ColorPair(Color.FromArgb(233, 236, 248),
                                                             Color.FromArgb(218, 221, 225));
            colorTable[ColorIndex.FocusedBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.SelectedBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.HoverBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.HoverForeGround] = Color.DarkGray;
            colorTable[ColorIndex.NormalBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.NormalForeGround] = Color.Gray;
            colorTable[ColorIndex.SelectedForeGround] = Color.Gray;
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(Color.Transparent, Color.Transparent);
            colorTable[ColorIndex.DisabledBorder] = Color.FromArgb(219, 224, 231);
            colorTable[ColorIndex.DisabledForeGround] = Color.Gray;
            colorTable[ColorIndex.BarNormalBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.BarFocusedBorder] = Color.FromArgb(111, 112, 116);
            colorTable[ColorIndex.DisabledMask] = Color.FromArgb(233, 236, 248);
        }

        /// <summary>
        /// Initializes the olive green.
        /// </summary>
        private void InitializeOliveGreen()
        {
            colorTable[ColorIndex.BarBackStyle] = new ColorPair(Color.FromArgb(232, 238, 205),
                                                                Color.FromArgb(179, 194, 142));
            colorTable[ColorIndex.BackStyle] = new ColorPair(Color.FromArgb(232, 238, 205),
                                                             Color.FromArgb(179, 194, 142));
            colorTable[ColorIndex.FocusedBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.SelectedBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.HoverBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.HoverForeGround] = Color.DarkGreen;
            colorTable[ColorIndex.NormalBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.NormalForeGround] = Color.DarkGreen;
            colorTable[ColorIndex.SelectedForeGround] = Color.DarkOliveGreen;
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(Color.Transparent, Color.Transparent);
            colorTable[ColorIndex.DisabledBorder] = Color.FromArgb(217, 217, 167);
            colorTable[ColorIndex.DisabledForeGround] = Color.Olive;
            colorTable[ColorIndex.BarNormalBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.BarFocusedBorder] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.DisabledMask] = Color.FromArgb(232, 238, 205);
        }

        /// <summary>
        /// Initializes the blue.
        /// </summary>
        private void InitializeBlue()
        {
            colorTable[ColorIndex.BarBackStyle] = new ColorPair(Color.FromArgb(0xdd, 0xec, 0xfe),
                                                                Color.FromArgb(0x81, 0xa9, 0xe2));
            colorTable[ColorIndex.BackStyle] = new ColorPair(Color.FromArgb(0xdd, 0xec, 0xfe),
                                                             Color.FromArgb(0x81, 0xa9, 0xe2));
            colorTable[ColorIndex.FocusedBorder] = Color.Blue;
            colorTable[ColorIndex.SelectedBorder] = Color.Blue;
            colorTable[ColorIndex.HoverBorder] = Color.FromArgb(0xb3, 0xb0, 0xd0);
            colorTable[ColorIndex.HoverForeGround] = Color.Blue;
            colorTable[ColorIndex.NormalBorder] = Color.FromArgb(0xb3, 0xb0, 0xd0);
            colorTable[ColorIndex.NormalForeGround] = Color.Black;
            colorTable[ColorIndex.SelectedForeGround] = Color.DarkBlue;
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(Color.Transparent, Color.Transparent);
            colorTable[ColorIndex.DisabledBorder] = Color.FromArgb(0xb3, 0xb0, 0xd0);
            colorTable[ColorIndex.DisabledForeGround] = Color.Gray;
            colorTable[ColorIndex.BarNormalBorder] = Color.FromArgb(0xb3, 0xb0, 0xd0);
            colorTable[ColorIndex.BarFocusedBorder] = Color.FromArgb(0xb3, 0xb0, 0xd0);
            colorTable[ColorIndex.DisabledMask] = Color.FromArgb(0xdd, 0xec, 0xfe);
        }

        /// <summary>
        /// Initializes the v S2005.
        /// </summary>
        private void InitializeVS2005()
        {
            Color controlLight = SystemColors.ControlLight;
            Color highlight = SystemColors.Highlight;
            Color controlText = SystemColors.ControlText;
            Color inactiveCaptionText = SystemColors.InactiveCaptionText;
            Color gradientInactiveCaption = SystemColors.GradientInactiveCaption;
            Color inactiveCaption = SystemColors.InactiveCaption;

            colorTable[ColorIndex.BarBackStyle] = new ColorPair(controlLight, controlLight);
            colorTable[ColorIndex.BackStyle] = new ColorPair(controlLight, controlLight);
            colorTable[ColorIndex.ClickStyle] = new ColorPair(inactiveCaption, inactiveCaption);
            colorTable[ColorIndex.FocusedBorder] = highlight;
            colorTable[ColorIndex.SelectedBorder] = highlight;
            colorTable[ColorIndex.HoverBorder] = highlight;
            colorTable[ColorIndex.HoverForeGround] = controlText;
            colorTable[ColorIndex.HoverStyle] = new ColorPair(inactiveCaptionText, inactiveCaptionText);
            colorTable[ColorIndex.NormalBorder] = highlight;
            colorTable[ColorIndex.NormalForeGround] = controlText;
            colorTable[ColorIndex.SelectedForeGround] = controlText;
            colorTable[ColorIndex.SelectedHoverStyle] = new ColorPair(inactiveCaptionText, inactiveCaptionText);
            colorTable[ColorIndex.SelectedStyle] = new ColorPair(gradientInactiveCaption, gradientInactiveCaption);
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(controlLight, controlLight);
            colorTable[ColorIndex.DisabledBorder] = highlight;
            colorTable[ColorIndex.DisabledForeGround] = SystemColors.GrayText;
            colorTable[ColorIndex.BarNormalBorder] = highlight;
            colorTable[ColorIndex.BarFocusedBorder] = highlight;
            colorTable[ColorIndex.DisabledMask] = controlLight;
        }

        /// <summary>
        /// Initializes the classic.
        /// </summary>
        private void InitializeClassic()
        {
            Color control = SystemColors.Control;
            Color controlText = SystemColors.ControlText;
            Color buttonFace = SystemColors.ButtonFace;
            Color buttonShadow = SystemColors.ButtonShadow;

            colorTable[ColorIndex.BarBackStyle] = new ColorPair(control, control);
            colorTable[ColorIndex.BackStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.ClickStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.FocusedBorder] = buttonShadow;
            colorTable[ColorIndex.SelectedBorder] = controlText;
            colorTable[ColorIndex.HoverBorder] = buttonShadow;
            colorTable[ColorIndex.HoverForeGround] = controlText;
            colorTable[ColorIndex.HoverStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.NormalBorder] = buttonShadow;
            colorTable[ColorIndex.NormalForeGround] = controlText;
            colorTable[ColorIndex.SelectedForeGround] = controlText;
            colorTable[ColorIndex.SelectedHoverStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.SelectedStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.DisabledStyle] = new ColorPair(buttonFace, buttonFace);
            colorTable[ColorIndex.DisabledBorder] = buttonShadow;
            colorTable[ColorIndex.DisabledForeGround] = SystemColors.GrayText;
            colorTable[ColorIndex.BarNormalBorder] = controlText;
            colorTable[ColorIndex.BarFocusedBorder] = controlText;
            colorTable[ColorIndex.DisabledMask] = control;
        }

        /// <summary>
        /// Gets the color scheme.
        /// </summary>
        /// <param name="_colorScheme">The color scheme.</param>
        /// <returns>ColorSchemeDefinition.</returns>
        public static ColorSchemeDefinition GetColorScheme(ColorScheme _colorScheme)
        {
            switch (_colorScheme)
            {
                case ColorScheme.Classic:
                    return Classic;

                case ColorScheme.Blue:
                    return Blue;

                case ColorScheme.OliveGreen:
                    return OliveGreen;

                case ColorScheme.Royale:
                    return Royale;

                case ColorScheme.Silver:
                    return Silver;

                case ColorScheme.VS2005:
                    return VS2005;
            }
            return Default;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            colorScheme = baseColorScheme;
            if (colorScheme == ColorScheme.Default)
            {
                colorScheme = DefaultColorScheme;
            }
            colorTable = new Hashtable();
            InitializeCommon();
            switch (colorScheme)
            {
                case ColorScheme.Blue:
                    InitializeBlue();
                    break;

                case ColorScheme.OliveGreen:
                    InitializeOliveGreen();
                    break;

                case ColorScheme.Royale:
                    InitializeRoyale();
                    break;

                case ColorScheme.Silver:
                    InitializeSilver();
                    break;

                case ColorScheme.VS2005:
                    InitializeVS2005();
                    break;

                case ColorScheme.Classic:
                    InitializeClassic();
                    break;
                case ColorScheme.Default:
                    break;
            }
        }

        /// <summary>
        /// Calculates the color.
        /// </summary>
        /// <param name="color1">The color1.</param>
        /// <param name="color2">The color2.</param>
        /// <param name="percentage">The percentage.</param>
        /// <returns>Color.</returns>
        public static Color CalculateColor(Color color1, Color color2, float percentage)
        {
            var r = (byte) (color1.R - ((color1.R - color2.R)*percentage));
            var g = (byte) (color1.G - ((color1.G - color2.G)*percentage));
            var b = (byte) (color1.B - ((color1.B - color2.B)*percentage));
            return Color.FromArgb(r, g, b);
        }

        #region Nested type: ColorIndex

        /// <summary>
        /// Enum ColorIndex
        /// </summary>
        private enum ColorIndex
        {
            /// <summary>
            /// The bar back style
            /// </summary>
            BarBackStyle = 0,
            /// <summary>
            /// The back style
            /// </summary>
            BackStyle = 1,
            /// <summary>
            /// The click style
            /// </summary>
            ClickStyle = 2,
            /// <summary>
            /// The focused border
            /// </summary>
            FocusedBorder = 3,
            /// <summary>
            /// The selected border
            /// </summary>
            SelectedBorder = 4,
            /// <summary>
            /// The hover border
            /// </summary>
            HoverBorder = 5,
            /// <summary>
            /// The hover fore ground
            /// </summary>
            HoverForeGround = 6,
            /// <summary>
            /// The hover style
            /// </summary>
            HoverStyle = 7,
            /// <summary>
            /// The normal border
            /// </summary>
            NormalBorder = 8,
            /// <summary>
            /// The normal fore ground
            /// </summary>
            NormalForeGround = 9,
            /// <summary>
            /// The selected fore ground
            /// </summary>
            SelectedForeGround = 10,
            /// <summary>
            /// The selected hover style
            /// </summary>
            SelectedHoverStyle = 11,
            /// <summary>
            /// The selected style
            /// </summary>
            SelectedStyle = 12,
            /// <summary>
            /// The disabled style
            /// </summary>
            DisabledStyle = 13,
            /// <summary>
            /// The disabled border
            /// </summary>
            DisabledBorder = 14,
            /// <summary>
            /// The disabled fore ground
            /// </summary>
            DisabledForeGround = 15,
            /// <summary>
            /// The bar focused border
            /// </summary>
            BarFocusedBorder = 16,
            /// <summary>
            /// The bar normal border
            /// </summary>
            BarNormalBorder = 17,
            /// <summary>
            /// The disabled mask
            /// </summary>
            DisabledMask = 18
        }

        #endregion
    }
}