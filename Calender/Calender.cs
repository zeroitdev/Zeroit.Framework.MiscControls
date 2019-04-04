// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Calender.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Zeroit.Framework.MiscControls
{
    #region Calender Control

    #region Design

    #region Attributes

    #region MinMaxAttribute

    /// <summary>
    /// Class ZeroitMonthCalanderMinMaxAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    internal class ZeroitMonthCalanderMinMaxAttribute : Attribute
    {
        /// <summary>
        /// The default
        /// </summary>
        public static readonly MinMaxAttribute Default = new MinMaxAttribute(0, 255);
        /// <summary>
        /// The maximum value
        /// </summary>
        private readonly int maxValue;
        /// <summary>
        /// The minimum value
        /// </summary>
        private readonly int minValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderMinMaxAttribute"/> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public ZeroitMonthCalanderMinMaxAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public int MinValue
        {
            get { return minValue; }
        }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaxValue
        {
            get { return maxValue; }
        }

        /// <summary>
        /// Returns a value that indicates whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An <see cref="T:System.Object"></see> to compare with this instance or null.</param>
        /// <returns>true if obj equals the type and value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var attribute = obj as ZeroitMonthCalanderMinMaxAttribute;
            if (attribute != null)
            {
                return attribute.minValue.Equals(minValue) && attribute.maxValue.Equals(maxValue);
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.
        /// </summary>
        /// <returns>true if this instance is the default attribute for the class; otherwise, false.</returns>
        public override bool IsDefaultAttribute()
        {
            return Default.Equals(this);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</returns>
        public override string ToString()
        {
            return "Minimum allowed value : " + minValue + " , Maximum allowed value : " + maxValue;
        }
    }

    #endregion

    #endregion

    #region Designer

    #region MonthCalenderDesigner

    /// <summary>
    /// Class ZeroitMonthCalanderDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    internal class ZeroitMonthCalanderDesigner : ParentControlDesigner
    {
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                var list = new DesignerActionListCollection { new ZeroitMonthCalanderDesignerActionList(Component) };
                return list;
            }
        }

        #region Nested type: ZeroitMonthCalanderDesignerActionList

        /// <summary>
        /// Class ZeroitMonthCalanderDesignerActionList.
        /// </summary>
        /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
        internal class ZeroitMonthCalanderDesignerActionList : DesignerActionList
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitMonthCalanderDesignerActionList"/> class.
            /// </summary>
            /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
            public ZeroitMonthCalanderDesignerActionList(IComponent component) : base(component)
            {
            }

            /// <summary>
            /// Gets the calander.
            /// </summary>
            /// <value>The calander.</value>
            private ZeroitMonthCalander Calander
            {
                get { return (ZeroitMonthCalander)Component; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether the smart tag panel should automatically be displayed when it is created.
            /// </summary>
            /// <value><c>true</c> if [automatic show]; otherwise, <c>false</c>.</value>
            public override bool AutoShow
            {
                get { return true; }
                set { base.AutoShow = true; }
            }

            /// <summary>
            /// Gets the appearance.
            /// </summary>
            /// <value>The appearance.</value>
            [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderAppearance>))]
            [Editor(typeof(ZeroitMonthCalanderAppearanceEditor), typeof(UITypeEditor))]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ZeroitMonthCalanderAppearance Appearance
            {
                get { return Calander.Appearance; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [use theme].
            /// </summary>
            /// <value><c>true</c> if [use theme]; otherwise, <c>false</c>.</value>
            public bool UseTheme
            {
                get { return Calander.ZeroitMonthCalanderThemeProperty.UseTheme; }
                set
                {
                    Calander.ZeroitMonthCalanderThemeProperty.UseTheme = value;
                    Calander.SetThemeDefaults();
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [draw focused].
            /// </summary>
            /// <value><c>true</c> if [draw focused]; otherwise, <c>false</c>.</value>
            public bool DrawFocused
            {
                get { return Calander.DrawFocused; }
                set
                {
                    if (Calander.DrawFocused != value)
                    {
                        Calander.DrawFocused = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [hot appearance].
            /// </summary>
            /// <value><c>true</c> if [hot appearance]; otherwise, <c>false</c>.</value>
            public bool HotAppearance
            {
                get { return Calander.HotAppearance; }
                set
                {
                    if (Calander.HotAppearance != value)
                    {
                        Calander.HotAppearance = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            /// <summary>
            /// Gets or sets the back ground image alpha.
            /// </summary>
            /// <value>The back ground image alpha.</value>
            [Editor(typeof(ZeroitMonthCalanderRangeEditor), typeof(UITypeEditor))]
            [MinMax(0, 100)]
            public int BackGroundImageAlpha
            {
                get { return Calander.BackGroundImageAlpha; }
                set
                {
                    if (Calander.BackGroundImageAlpha != value)
                    {
                        Calander.BackGroundImageAlpha = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            /// <summary>
            /// Gets or sets the back ground image.
            /// </summary>
            /// <value>The back ground image.</value>
            public Image BackGroundImage
            {
                get { return Calander.BackgroundImage; }
                set
                {
                    if (Calander.BackgroundImage != value)
                    {
                        Calander.BackgroundImage = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            /// <summary>
            /// Gets or sets the background image layout.
            /// </summary>
            /// <value>The background image layout.</value>
            public ImageLayout BackgroundImageLayout
            {
                get { return Calander.BackgroundImageLayout; }
                set
                {
                    if (Calander.BackgroundImageLayout != value)
                    {
                        Calander.BackgroundImageLayout = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            /// <summary>
            /// Gets or sets the number font.
            /// </summary>
            /// <value>The number font.</value>
            [TypeConverter(typeof(ZeroitMonthCalanderFontConverter)), Editor(typeof(ZeroitMonthCalanderFontEditor), typeof(UITypeEditor))]
            public string NumberFont
            {
                get { return Calander.NumberFont; }
                set
                {
                    Calander.NumberFont = value;
                    Calander.SetThemeDefaults();
                }
            }

            /// <summary>
            /// Gets or sets the caption font.
            /// </summary>
            /// <value>The caption font.</value>
            [TypeConverter(typeof(ZeroitMonthCalanderFontConverter)), Editor(typeof(ZeroitMonthCalanderFontEditor), typeof(UITypeEditor))]
            public string CaptionFont
            {
                get { return Calander.CaptionFont; }
                set
                {
                    Calander.CaptionFont = value;
                    Calander.SetThemeDefaults();
                }
            }

            /// <summary>
            /// Gets or sets the zeroit month calander color scheme.
            /// </summary>
            /// <value>The zeroit month calander color scheme.</value>
            public ZeroitMonthCalanderColorScheme ZeroitMonthCalanderColorScheme
            {
                get { return Calander.ZeroitMonthCalanderThemeProperty.ZeroitMonthCalanderColorScheme; }
                set
                {
                    Calander.ZeroitMonthCalanderThemeProperty.ZeroitMonthCalanderColorScheme = value;
                    Calander.SetThemeDefaults();
                }
            }

            /// <summary>
            /// Applies the template.
            /// </summary>
            internal void ApplyTemplate()
            {
                object currentValue = Calander.Appearance;
                var editor = new ZeroitMonthCalanderAppearanceEditor.AppearanceEditor((ZeroitMonthCalanderAppearance)currentValue);
                editor.ShowDialog();
                Calander.Appearance.Assign(editor.Value);
                Calander.SetThemeDefaults();
            }

            /// <summary>
            /// Resets this instance.
            /// </summary>
            internal void Reset()
            {
                Calander.Appearance.Reset();
                Calander.SetThemeDefaults();
                Calander.Invalidate();
            }

            /// <summary>
            /// Saves the style.
            /// </summary>
            internal void SaveStyle()
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (XmlWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8))
                    {
                        var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                        serializer.Serialize(writer, Calander.Appearance);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }

            /// <summary>
            /// Loads the style.
            /// </summary>
            internal void LoadStyle()
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                        var app = (ZeroitMonthCalanderAppearance)serializer.Deserialize(fs);
                        Calander.Appearance.Assign(app);
                    }
                }
                Calander.SetThemeDefaults();
                Calander.Invalidate();
            }

            /// <summary>
            /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
            /// </summary>
            /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                var collection = new DesignerActionItemCollection
                                     {
                                         new DesignerActionPropertyItem("Appearance", "Appearance", "Appearance"),
                                         new DesignerActionPropertyItem("ZeroitMonthCalanderColorScheme", "ZeroitMonthCalanderColorScheme", "Appearance"),
                                         new DesignerActionPropertyItem("UseTheme", "UseTheme", "Appearance"),
                                         new DesignerActionPropertyItem("HotAppearance", "HotAppearance", "Appearance"),
                                         new DesignerActionPropertyItem("DrawFocused", "DrawFocused", "Appearance"),
                                         new DesignerActionPropertyItem("BackGroundImage", "BackGroundImage",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("BackgroundImageLayout", "BackgroundImageLayout",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("BackGroundImageAlpha", "BackGroundImageAlpha",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("CaptionFont", "CaptionFont", "Appearance"),
                                         new DesignerActionPropertyItem("NumberFont", "NumberFont", "Appearance"),
                                         new DesignerActionMethodItem(this, "ApplyTemplate", "Apply Template",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "Reset", "Reset Appearance",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "SaveStyle", "Save Theme",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "LoadStyle", "Load Theme",
                                                                      "Appearance", true)
                                     };
                return collection;
            }
        }

        #endregion
    }

    #endregion

    #endregion

    #region Editors


    #region FontConverter

    /// <summary>
    /// Class ZeroitMonthCalanderFontConverter. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public sealed class ZeroitMonthCalanderFontConverter : TypeConverter
    {
        /// <summary>
        /// The values
        /// </summary>
        private readonly StandardValuesCollection values;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderFontConverter"/> class.
        /// </summary>
        public ZeroitMonthCalanderFontConverter()
        {
            var fontNames = new string[FontFamily.Families.Length];
            for (var i = 0; i < FontFamily.Families.Length; i++)
                fontNames[i] = FontFamily.Families[i].Name;
            Array.Sort(fontNames, Comparer.Default);
            values = new StandardValuesCollection(fontNames);
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return GetName((string)value);
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> that holds a standard set of valid values, or null if the data type does not support a standard set of values.</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return values;
        }

        /// <summary>
        /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exclusive list of possible values, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exhaustive list of possible values; false if other values are possible.</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> should be called to find a common set of values the object supports; otherwise, false.</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        private string GetName(string name)
        {
            string str = null;
            foreach (var fontName in values)
            {
                if (fontName.ToString().Equals(name, StringComparison.InvariantCulture))
                {
                    return fontName.ToString();
                }
                if (fontName.ToString().StartsWith(name, StringComparison.InvariantCulture) &&
                    ((str == null) || (fontName.ToString().Length <= str.Length)))
                {
                    str = fontName.ToString();
                }
            }
            if (str == null)
            {
                str = name;
            }
            return str;
        }
    }

    #endregion

    #region FontEditor
    /// <summary>
    /// Class ZeroitMonthCalanderFontEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class ZeroitMonthCalanderFontEditor : UITypeEditor
    {
        /// <summary>
        /// The LBX
        /// </summary>
        private readonly ImageIndexUI lbx = new ImageIndexUI();

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="bounds">The bounds.</param>
        private static void Draw(Graphics g, FontFamily fontFamily, Rectangle bounds)
        {
            Font font = GetFont(fontFamily, bounds.Height);
            try
            {
                g.DrawString("ab", font, SystemBrushes.ActiveCaptionText, bounds);
            }
            finally
            {
                font.Dispose();
            }
        }

        /// <summary>
        /// Gets the font.
        /// </summary>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="height">The height.</param>
        /// <returns>Font.</returns>
        private static Font GetFont(FontFamily fontFamily, int height)
        {
            FontStyle style = FontStyle.Regular;
            if (fontFamily.IsStyleAvailable(FontStyle.Regular))
            {
                style = FontStyle.Regular;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Italic))
            {
                style = FontStyle.Italic;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Bold))
            {
                style = FontStyle.Bold;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Italic | FontStyle.Bold))
            {
                style = FontStyle.Italic | FontStyle.Bold;
            }
            return new Font(fontFamily, (float)(height / 1.3), style, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            var name = e.Value as string;
            if (!string.IsNullOrEmpty(name))
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                try
                {
                    var fontFamily = new FontFamily(name);
                    Draw(e.Graphics, fontFamily, e.Bounds);
                }
                catch
                {
                }
                e.Graphics.DrawLine(SystemPens.WindowFrame, e.Bounds.Right, e.Bounds.Y, e.Bounds.Right, e.Bounds.Bottom);
            }
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc == null)
                {
                    return value;
                }
                lbx.Items.Clear();
                TypeConverter.StandardValuesCollection values =
                    context.PropertyDescriptor.Converter.GetStandardValues(context);
                foreach (object v in values)
                {
                    lbx.Items.Add(v);
                    if (v.Equals(value))
                        lbx.SelectedItem = v;
                }
                lbx.SelectedIndexChanged += delegate { edSvc.CloseDropDown(); };
                edSvc.DropDownControl(lbx);
                value = lbx.SelectedItem;
            }
            return value;
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        #region Nested type: ImageIndexUI

        /// <summary>
        /// Class ImageIndexUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.ListBox" />
        private class ImageIndexUI : ListBox
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ImageIndexUI"/> class.
            /// </summary>
            public ImageIndexUI()
            {
                ItemHeight = 20;
                Height = 20 * 10;
                DrawMode = DrawMode.OwnerDrawFixed;
                Dock = DockStyle.Fill;
                BorderStyle = BorderStyle.None;
            }

            /// <summary>
            /// Handles the <see cref="E:DrawItem" /> event.
            /// </summary>
            /// <param name="die">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
            protected override void OnDrawItem(DrawItemEventArgs die)
            {
                base.OnDrawItem(die);
                if (die.Index != -1)
                {
                    string s = Items[die.Index].ToString();
                    Brush brush = new SolidBrush(die.ForeColor);
                    die.DrawBackground();
                    die.Graphics.FillRectangle(SystemBrushes.ActiveCaption,
                                               new Rectangle(die.Bounds.X + 1, die.Bounds.Y + 1, 34, 18));
                    try
                    {
                        var fontFamily = new FontFamily(s);
                        Font font = GetFont(fontFamily, die.Bounds.Height);
                        try
                        {
                            die.Graphics.DrawString("ab", font, SystemBrushes.ActiveCaptionText, die.Bounds.X,
                                                    die.Bounds.Y);
                        }
                        finally
                        {
                            font.Dispose();
                        }
                    }
                    catch
                    {
                    }
                    die.Graphics.DrawString(s, die.Font, brush, die.Bounds.X + 36,
                                            die.Bounds.Y + ((die.Bounds.Height - die.Font.Height) / 2));

                    brush.Dispose();
                }
            }

            /// <summary>
            /// Processes a dialog key.
            /// </summary>
            /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
            /// <returns>true if the key was processed by the control; otherwise, false.</returns>
            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (((keyData & Keys.KeyCode) == Keys.Return) && ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
                {
                    OnClick(EventArgs.Empty);
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
        }

        #endregion
    }
    #endregion

    #region GradientAngleEditor
    /// <summary>
    /// Class ZeroitMonthCalanderGradientAngleEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    internal class ZeroitMonthCalanderGradientAngleEditor : UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            ZeroitMonthCalanderGradientEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (!(value is int && (int)value < 360 && (int)value >= 0))
                {
                    value = 0;
                }
                if (editorService != null)
                {
                    var currentValue = (int)value;
                    editor = new ZeroitMonthCalanderGradientEditorUI(currentValue) { Dock = DockStyle.Fill };
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: GradientEditorUI

        /// <summary>
        /// Class ZeroitMonthCalanderGradientEditorUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.UserControl" />
        internal class ZeroitMonthCalanderGradientEditorUI : UserControl
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private readonly IContainer components;

            /// <summary>
            /// The diameter
            /// </summary>
            private int diameter;
            /// <summary>
            /// The hover value
            /// </summary>
            private int hoverValue;
            /// <summary>
            /// The midx
            /// </summary>
            private int midx;
            /// <summary>
            /// The midy
            /// </summary>
            private int midy;
            /// <summary>
            /// The value
            /// </summary>
            private int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGradientEditorUI"/> class.
            /// </summary>
            internal ZeroitMonthCalanderGradientEditorUI()
            {
                value = 0;
                InitializeComponent();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGradientEditorUI"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            internal ZeroitMonthCalanderGradientEditorUI(int value)
            {
                this.value = value;
                InitializeComponent();
            }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public int Value
            {
                get { return value; }
                set
                {
                    if (value != this.value)
                    {
                        this.value = value;
                        OnValueChanged();
                    }
                }
            }

            /// <summary>
            /// Occurs when [value changed].
            /// </summary>
            internal event EventHandler ValueChanged;

            /// <summary>
            /// Called when [value changed].
            /// </summary>
            internal virtual void OnValueChanged()
            {
                if (ValueChanged != null)
                {
                    ValueChanged(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
            protected override void OnPaint(PaintEventArgs e)
            {
                PaintValue(e);
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (HitTest(e.Location))
                {
                    int angle = GetAngle(e.Location);
                    if (angle != -1)
                    {
                        value = angle;
                        OnValueChanged();
                    }
                    Invalidate();
                }
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (HitTest(e.Location))
                {
                    int angle = GetAngle(e.Location);
                    if (angle != -1)
                    {
                        hoverValue = angle;
                    }
                    Invalidate(new Rectangle((int)(Width - diameter * 0.25), 1, (int)(0.25 * diameter),
                                             (int)(2 * Font.SizeInPoints)));
                }
            }

            /// <summary>
            /// Hits the test.
            /// </summary>
            /// <param name="point">The point.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            private bool HitTest(Point point)
            {
                var distance = (int)Math.Sqrt((point.X - midx) * (point.X - midx) + (point.Y - midy) * (point.Y - midy));
                return distance <= (diameter * 0.7) / 2;
            }

            /// <summary>
            /// Gets the angle.
            /// </summary>
            /// <param name="p">The p.</param>
            /// <returns>System.Int32.</returns>
            private int GetAngle(Point p)
            {
                if ((p.X - midx) != 0)
                {
                    var ret = (int)((Math.Atan((p.Y - midy) / (float)(p.X - midx))) * (180) / Math.PI);
                    if ((p.Y - midy) >= 0 && (p.X - midx) <= 0)
                    {
                        ret = 180 + ret;
                    }
                    else if ((p.Y - midy) <= 0 && (p.X - midx) <= 0)
                    {
                        ret = 180 + ret;
                    }
                    else if ((p.Y - midy) <= 0 && (p.X - midx) >= 0)
                    {
                        ret = 360 + ret;
                    }
                    return ret;
                }
                if ((p.Y - midy) > 0)
                {
                    return 90;
                }
                if ((p.Y - midy) < 0)
                {
                    return 270;
                }
                return -1;
            }

            /// <summary>
            /// Paints the value.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void PaintValue(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                diameter = Math.Min(Height, Width);
                midx = ClientSize.Width / 2;
                midy = ClientSize.Height / 2;
                DrawFrame(e);
                e.Graphics.DrawString(value.ToString(), Font, Brushes.Red, 1, 1);
                e.Graphics.DrawString(hoverValue.ToString(), Font, Brushes.Green, (float)(Width - diameter * 0.25), 1);
                DrawLine(e, value, Color.Red);
                if (HitTest(MousePosition))
                {
                    DrawLine(e, hoverValue, Color.Green);
                }
            }

            /// <summary>
            /// Draws the line.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            /// <param name="val">The value.</param>
            /// <param name="color">The color.</param>
            private void DrawLine(PaintEventArgs e, int val, Color color)
            {
                var p = new Pen(color, 2);
                var current = GetCurrentPoint(val);
                e.Graphics.DrawLine(p, midx, midy, current.X, current.Y);
            }

            /// <summary>
            /// Gets the current point.
            /// </summary>
            /// <param name="val">The value.</param>
            /// <returns>Point.</returns>
            private Point GetCurrentPoint(int val)
            {
                return new Point((int)(midx + Math.Cos(val * Math.PI / 180) * diameter * 0.8 / 2),
                                 (int)(midy + Math.Sin(val * Math.PI / 180) * diameter * 0.8 / 2));
            }

            /// <summary>
            /// Processes a command key.
            /// </summary>
            /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"></see>, passed by reference, that represents the window message to process.</param>
            /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
            /// <returns>true if the character was processed by the control; otherwise, false.</returns>
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if ((Enabled) && ((msg.Msg == 0x100) || (msg.Msg == 260)))
                {
                    switch (keyData)
                    {
                        case Keys.Left:
                            if (value > 0)
                            {
                                value--;
                            }
                            break;

                        case Keys.Up:
                            if (value < 360)
                            {
                                value++;
                            }
                            break;

                        case Keys.Right:
                            if (value < 360)
                            {
                                value++;
                            }
                            break;

                        case Keys.Down:
                            if (value > 0)
                            {
                                value--;
                            }
                            break;
                    }
                    OnValueChanged();
                }
                if (value == 360)
                {
                    value = 0;
                }
                Invalidate();
                return base.ProcessCmdKey(ref msg, keyData);
            }

            /// <summary>
            /// Draws the frame.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void DrawFrame(PaintEventArgs e)
            {
                var p = new Pen(Color.Black, 2);
                var drawRect = new Rectangle((int)(midx - 0.7 * diameter / 2), (int)(midy - 0.7 * diameter / 2),
                                             (int)(0.7 * diameter), (int)(0.7 * diameter));
                e.Graphics.DrawEllipse(p, drawRect);
                drawRect.Inflate(1, 1);
                e.Graphics.TranslateClip(1, 1);
                e.Graphics.DrawEllipse(Pens.Gray, drawRect);
                e.Graphics.DrawLine(Pens.Black, midx, midy - diameter / 2, midx, midy + diameter / 2);
                e.Graphics.DrawLine(Pens.Black, midx - diameter / 2, midy, midx + diameter / 2, midy);
                e.Graphics.DrawString("0", Font, Brushes.LimeGreen, (float)(midx + 0.8 * diameter / 2), midy);
                e.Graphics.DrawString("180", Font, Brushes.LimeGreen, (midx - diameter / 2), midy);
                e.Graphics.DrawString("90", Font, Brushes.LimeGreen, midx, (float)(midy + 0.8 * diameter / 2));
                e.Graphics.DrawString("270", Font, Brushes.LimeGreen, midx, (midy - diameter / 2));
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>System.Int32.</returns>
            internal int GetValue()
            {
                return value;
            }

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Component Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // GradientEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.Window;
                this.Name = "GradientEditorUI";
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
    #endregion

    #region ZeroitMonthCalanderAppearanceEditor
    /// <summary>
    /// Class ZeroitMonthCalanderAppearanceEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    internal class ZeroitMonthCalanderAppearanceEditor : UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            AppearanceEditor editor;

            if (context != null && context.Instance != null && provider != null)
            {
                object currentValue = value;
                if (value is string)
                {
                    var convet = new ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderAppearance>();
                    currentValue = convet.ConvertTo(value, typeof(ZeroitMonthCalanderAppearance));
                }
                editor = new AppearanceEditor((ZeroitMonthCalanderAppearance)currentValue);
                editor.ShowDialog();
                value = editor.Value;
                if (context.Instance is ZeroitMonthCalander)
                {
                    ((ZeroitMonthCalander)context.Instance).Appearance.Assign(editor.Value);
                    ((ZeroitMonthCalander)context.Instance).SetThemeDefaults();
                }
            }
            return value;
        }

        #region Nested type: AppearanceEditor

        /// <summary>
        /// Class AppearanceEditor.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Form" />
        internal class AppearanceEditor : System.Windows.Forms.Form
        {
            /// <summary>
            /// The appearance
            /// </summary>
            private readonly ZeroitMonthCalanderAppearance appearance;

            /// <summary>
            /// Required designer variable.
            /// </summary>
            private readonly IContainer components;

            /// <summary>
            /// The BTN cancel
            /// </summary>
            private Button btnCancel;
            /// <summary>
            /// The BTN ok
            /// </summary>
            private Button btnOK;
            /// <summary>
            /// The cal preview
            /// </summary>
            private ZeroitMonthCalander calPreview;
            /// <summary>
            /// The label apply
            /// </summary>
            private LinkLabel lblApply;
            /// <summary>
            /// The label available theme
            /// </summary>
            private Label lblAvailableTheme;
            /// <summary>
            /// The label current style
            /// </summary>
            private Label lblCurrentStyle;
            /// <summary>
            /// The label load
            /// </summary>
            private LinkLabel lblLoad;
            /// <summary>
            /// The label preview
            /// </summary>
            private Label lblPreview;
            /// <summary>
            /// The label reset
            /// </summary>
            private LinkLabel lblReset;
            /// <summary>
            /// The label save
            /// </summary>
            private LinkLabel lblSave;
            /// <summary>
            /// The LBX template
            /// </summary>
            private ListBox lbxTemplate;
            /// <summary>
            /// The PGRD main
            /// </summary>
            private PropertyGrid pgrdMain;
            /// <summary>
            /// The PNL bottom
            /// </summary>
            private Panel pnlBottom;
            /// <summary>
            /// The PNL left
            /// </summary>
            private Panel pnlLeft;
            /// <summary>
            /// The PNL right
            /// </summary>
            private Panel pnlRight;
            /// <summary>
            /// The PNL top
            /// </summary>
            private Panel pnlTop;

            /// <summary>
            /// Initializes a new instance of the <see cref="AppearanceEditor"/> class.
            /// </summary>
            /// <param name="appearance">The appearance.</param>
            public AppearanceEditor(ZeroitMonthCalanderAppearance appearance)
            {
                this.appearance = (ZeroitMonthCalanderAppearance)appearance.Clone();
                InitializeComponent();
                pgrdMain.SelectedObject = appearance;
                lbxTemplate.Items.AddRange(new object[]
                                               {
                                                   "VS2005",
                                                   "Classic",
                                                   "Blue",
                                                   "OliveGreen",
                                                   "Royale",
                                                   "Silver"
                                               });
                lbxTemplate.SelectedIndex = 0;
                calPreview.Appearance.Assign(appearance);
                calPreview.ZeroitMonthCalanderThemeProperty.UseTheme = false;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <value>The value.</value>
            public ZeroitMonthCalanderAppearance Value
            {
                get
                {
                    return ((DialogResult == DialogResult.OK)
                                ? (ZeroitMonthCalanderAppearance)pgrdMain.SelectedObject
                                : appearance);
                }
            }

            /// <summary>
            /// Handles the <see cref="E:ApplyClick" /> event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
            private void OnApplyClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                switch (lbxTemplate.SelectedItem.ToString())
                {
                    case "VS2005":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.VS2005);
                        break;
                    case "Classic":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Classic);
                        break;
                    case "Blue":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Blue);
                        break;
                    case "OliveGreen":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.OliveGreen);
                        break;
                    case "Royale":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Royale);
                        break;
                    case "Silver":
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Silver);
                        break;
                }
                pgrdMain.Refresh();
            }

            /// <summary>
            /// Sets the colors.
            /// </summary>
            /// <param name="schemeDefinition">The scheme definition.</param>
            private void SetColors(ZeroitMonthCalanderColorSchemeDefinition schemeDefinition)
            {
                var appearance = (ZeroitMonthCalanderAppearance)pgrdMain.SelectedObject;
                appearance.SelectedDateAppearance.Assign(new BorderAppearance());
                appearance.ActiveTextColor = schemeDefinition.CaptionTextColor;
                appearance.InactiveTextColor = schemeDefinition.InactiveTextColor;
                appearance.SelectedDateTextColor = schemeDefinition.DayMarker;
                appearance.TodayBorderColor = schemeDefinition.SelectedDateBorderColor;
                appearance.ButtonBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.CaptionBackColor));
                appearance.SelectedBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.SelectedBackColor));
                appearance.ArrowColor = schemeDefinition.ArrowColor;
                appearance.CaptionBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.CaptionBackColor));
                appearance.CaptionTextColor = schemeDefinition.CaptionTextColor;
                appearance.HoverColor = schemeDefinition.HoverColor;
                appearance.ControlBorderColor = schemeDefinition.ControlBorderColor;
                appearance.TodayColor = schemeDefinition.TodayColor;
                appearance.DayMarker = schemeDefinition.DayMarker;
                appearance.ControlBackColor = schemeDefinition.ControlBackColor;
                appearance.DateDaySaperatorColor = schemeDefinition.DateDaySaperatorColor;
                appearance.Radius = 2;
                appearance.ArrowHoverColor = schemeDefinition.ArrowHoverColor;
                appearance.DisabledMask = schemeDefinition.TodayColor;
                calPreview.Appearance.Assign(appearance);
            }

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            /// <summary>
            /// Handles the <see cref="E:SaveClick" /> event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
            private void OnSaveClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (XmlWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8))
                    {
                        var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                        serializer.Serialize(writer, pgrdMain.SelectedObject);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }

            /// <summary>
            /// Handles the <see cref="E:LoadClick" /> event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
            private void OnLoadClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                        var app = (ZeroitMonthCalanderAppearance)serializer.Deserialize(fs);
                        var appearance = (ZeroitMonthCalanderAppearance)pgrdMain.SelectedObject;
                        appearance.Assign(app);
                    }
                }
            }

            /// <summary>
            /// Handles the <see cref="E:ResetClick" /> event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
            private void OnResetClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                var appearance = (ZeroitMonthCalanderAppearance)pgrdMain.SelectedObject;
                appearance.Reset();
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.pnlTop = new System.Windows.Forms.Panel();
                this.pnlRight = new System.Windows.Forms.Panel();
                this.lblCurrentStyle = new System.Windows.Forms.Label();
                this.pgrdMain = new System.Windows.Forms.PropertyGrid();
                this.pnlLeft = new System.Windows.Forms.Panel();
                this.lblReset = new System.Windows.Forms.LinkLabel();
                this.lblSave = new System.Windows.Forms.LinkLabel();
                this.lblLoad = new System.Windows.Forms.LinkLabel();
                this.lblPreview = new System.Windows.Forms.Label();
                this.calPreview = new ZeroitMonthCalander();
                this.lblAvailableTheme = new System.Windows.Forms.Label();
                this.lblApply = new System.Windows.Forms.LinkLabel();
                this.lbxTemplate = new System.Windows.Forms.ListBox();
                this.pnlBottom = new System.Windows.Forms.Panel();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnOK = new System.Windows.Forms.Button();
                this.pnlTop.SuspendLayout();
                this.pnlRight.SuspendLayout();
                this.pnlLeft.SuspendLayout();
                this.pnlBottom.SuspendLayout();
                this.SuspendLayout();
                // 
                // pnlTop
                // 
                this.pnlTop.Controls.Add(this.pnlRight);
                this.pnlTop.Controls.Add(this.pnlLeft);
                this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
                this.pnlTop.Location = new System.Drawing.Point(0, 0);
                this.pnlTop.Name = "pnlTop";
                this.pnlTop.Size = new System.Drawing.Size(420, 393);
                this.pnlTop.TabIndex = 0;
                // 
                // pnlRight
                // 
                this.pnlRight.Controls.Add(this.lblCurrentStyle);
                this.pnlRight.Controls.Add(this.pgrdMain);
                this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlRight.Location = new System.Drawing.Point(179, 0);
                this.pnlRight.Name = "pnlRight";
                this.pnlRight.Size = new System.Drawing.Size(241, 393);
                this.pnlRight.TabIndex = 1;
                // 
                // lblCurrentStyle
                // 
                this.lblCurrentStyle.AutoSize = true;
                this.lblCurrentStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                    ((System.Drawing.FontStyle)
                                                                     ((System.Drawing.FontStyle.Bold |
                                                                       System.Drawing.FontStyle.Underline))),
                                                                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblCurrentStyle.Location = new System.Drawing.Point(6, 9);
                this.lblCurrentStyle.Name = "lblCurrentStyle";
                this.lblCurrentStyle.Size = new System.Drawing.Size(80, 13);
                this.lblCurrentStyle.TabIndex = 0;
                this.lblCurrentStyle.Text = "Current Style";
                // 
                // pgrdMain
                // 
                this.pgrdMain.CommandsVisibleIfAvailable = false;
                this.pgrdMain.HelpVisible = false;
                this.pgrdMain.Location = new System.Drawing.Point(6, 26);
                this.pgrdMain.Name = "pgrdMain";
                this.pgrdMain.PropertySort = System.Windows.Forms.PropertySort.NoSort;
                this.pgrdMain.Size = new System.Drawing.Size(237, 361);
                this.pgrdMain.TabIndex = 1;
                this.pgrdMain.ToolbarVisible = false;
                // 
                // pnlLeft
                // 
                this.pnlLeft.Controls.Add(this.lblReset);
                this.pnlLeft.Controls.Add(this.lblSave);
                this.pnlLeft.Controls.Add(this.lblLoad);
                this.pnlLeft.Controls.Add(this.lblPreview);
                this.pnlLeft.Controls.Add(this.calPreview);
                this.pnlLeft.Controls.Add(this.lblAvailableTheme);
                this.pnlLeft.Controls.Add(this.lblApply);
                this.pnlLeft.Controls.Add(this.lbxTemplate);
                this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
                this.pnlLeft.Location = new System.Drawing.Point(0, 0);
                this.pnlLeft.Name = "pnlLeft";
                this.pnlLeft.Size = new System.Drawing.Size(179, 393);
                this.pnlLeft.TabIndex = 0;
                // 
                // lblReset
                // 
                this.lblReset.AutoSize = true;
                this.lblReset.Location = new System.Drawing.Point(6, 194);
                this.lblReset.Name = "lblReset";
                this.lblReset.Size = new System.Drawing.Size(35, 13);
                this.lblReset.TabIndex = 7;
                this.lblReset.TabStop = true;
                this.lblReset.Text = "&Reset";
                this.lblReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnResetClick);
                // 
                // lblSave
                // 
                this.lblSave.AutoSize = true;
                this.lblSave.Location = new System.Drawing.Point(6, 175);
                this.lblSave.Name = "lblSave";
                this.lblSave.Size = new System.Drawing.Size(68, 13);
                this.lblSave.TabIndex = 6;
                this.lblSave.TabStop = true;
                this.lblSave.Text = "&Save Theme";
                this.lblSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSaveClick);
                // 
                // lblLoad
                // 
                this.lblLoad.AutoSize = true;
                this.lblLoad.Location = new System.Drawing.Point(6, 156);
                this.lblLoad.Name = "lblLoad";
                this.lblLoad.Size = new System.Drawing.Size(67, 13);
                this.lblLoad.TabIndex = 5;
                this.lblLoad.TabStop = true;
                this.lblLoad.Text = "&Load Theme";
                this.lblLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLoadClick);
                // 
                // lblPreview
                // 
                this.lblPreview.AutoSize = true;
                this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                               ((System.Drawing.FontStyle)
                                                                ((System.Drawing.FontStyle.Bold |
                                                                  System.Drawing.FontStyle.Underline))),
                                                               System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblPreview.Location = new System.Drawing.Point(6, 219);
                this.lblPreview.Name = "lblPreview";
                this.lblPreview.Size = new System.Drawing.Size(52, 13);
                this.lblPreview.TabIndex = 3;
                this.lblPreview.Text = "Preview";
                // 
                // calPreview
                // 
                this.calPreview.Location = new System.Drawing.Point(7, 235);
                this.calPreview.Name = "calPreview";
                this.calPreview.Size = new System.Drawing.Size(164, 152);
                this.calPreview.TabIndex = 4;
                this.calPreview.Text = "monthCalander1";
                this.calPreview.ZeroitMonthCalanderThemeProperty.UseTheme = false;
                // 
                // lblAvailableTheme
                // 
                this.lblAvailableTheme.AutoSize = true;
                this.lblAvailableTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                      ((System.Drawing.FontStyle)
                                                                       ((System.Drawing.FontStyle.Bold |
                                                                         System.Drawing.FontStyle.Underline))),
                                                                      System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblAvailableTheme.Location = new System.Drawing.Point(6, 8);
                this.lblAvailableTheme.Name = "lblAvailableTheme";
                this.lblAvailableTheme.Size = new System.Drawing.Size(103, 13);
                this.lblAvailableTheme.TabIndex = 0;
                this.lblAvailableTheme.Text = "Available themes";
                // 
                // lblApply
                // 
                this.lblApply.AutoSize = true;
                this.lblApply.Location = new System.Drawing.Point(6, 137);
                this.lblApply.Name = "lblApply";
                this.lblApply.Size = new System.Drawing.Size(117, 13);
                this.lblApply.TabIndex = 2;
                this.lblApply.TabStop = true;
                this.lblApply.Text = "&Apply to current Theme";
                this.lblApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnApplyClick);
                // 
                // lbxTemplate
                // 
                this.lbxTemplate.FormattingEnabled = true;
                this.lbxTemplate.Location = new System.Drawing.Point(7, 26);
                this.lbxTemplate.Name = "lbxTemplate";
                this.lbxTemplate.Size = new System.Drawing.Size(165, 108);
                this.lbxTemplate.TabIndex = 1;
                // 
                // pnlBottom
                // 
                this.pnlBottom.Controls.Add(this.btnCancel);
                this.pnlBottom.Controls.Add(this.btnOK);
                this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlBottom.Location = new System.Drawing.Point(0, 393);
                this.pnlBottom.Name = "pnlBottom";
                this.pnlBottom.Size = new System.Drawing.Size(420, 33);
                this.pnlBottom.TabIndex = 1;
                // 
                // btnCancel
                // 
                this.btnCancel.Anchor =
                    ((System.Windows.Forms.AnchorStyles)
                     ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnCancel.Location = new System.Drawing.Point(333, 6);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 1;
                this.btnCancel.Text = "&Cancel";
                this.btnCancel.UseVisualStyleBackColor = true;
                // 
                // btnOK
                // 
                this.btnOK.Anchor =
                    ((System.Windows.Forms.AnchorStyles)
                     ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.btnOK.Location = new System.Drawing.Point(252, 6);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(75, 23);
                this.btnOK.TabIndex = 0;
                this.btnOK.Text = "&Ok";
                this.btnOK.UseVisualStyleBackColor = true;
                // 
                // AppearanceEditor
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(420, 426);
                this.Controls.Add(this.pnlBottom);
                this.Controls.Add(this.pnlTop);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Name = "AppearanceEditor";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Appearance Editor";
                this.pnlTop.ResumeLayout(false);
                this.pnlRight.ResumeLayout(false);
                this.pnlRight.PerformLayout();
                this.pnlLeft.ResumeLayout(false);
                this.pnlLeft.PerformLayout();
                this.pnlBottom.ResumeLayout(false);
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
    #endregion

    #region RangeEditor
    /// <summary>
    /// Class ZeroitMonthCalanderRangeEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class ZeroitMonthCalanderRangeEditor : UITypeEditor
    {
        /// <summary>
        /// The default value
        /// </summary>
        private int defaultValue = 128;
        /// <summary>
        /// The maximum
        /// </summary>
        private int max = 255;
        /// <summary>
        /// The minimum
        /// </summary>
        private int min;

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            OpacityEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                SetMinMaxValue(context);
                if (!(value is int && (int)value >= min && (int)value <= max))
                {
                    value = defaultValue;
                }
                if (editorService != null)
                {
                    var currentValue = (int)value;
                    editor = new OpacityEditorUI(currentValue, min, max);
                    editor.Dock = DockStyle.Fill;
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        /// <summary>
        /// Sets the minimum maximum value.
        /// </summary>
        /// <param name="context">The context.</param>
        private void SetMinMaxValue(ITypeDescriptorContext context)
        {
            var attribute = context.PropertyDescriptor.Attributes[typeof(ZeroitMonthCalanderMinMaxAttribute)] as ZeroitMonthCalanderMinMaxAttribute;
            if (attribute != null)
            {
                min = attribute.MinValue;
                max = attribute.MaxValue;
            }
            if (max <= min)
            {
                min = 0;
                max = 100;
                defaultValue = 0;
            }
            var defaultVal =
                context.PropertyDescriptor.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
            if (defaultVal != null && defaultVal.Value is int)
            {
                defaultValue = (int)defaultVal.Value;
            }
            else
            {
                if (defaultValue > max)
                {
                    defaultValue = max;
                }
                if (defaultValue < min)
                {
                    defaultValue = min;
                }
            }
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: OpacityEditorUI

        /// <summary>
        /// Class OpacityEditorUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.UserControl" />
        [ToolboxItem(false)]
        private class OpacityEditorUI : UserControl
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private IContainer components = null;

            /// <summary>
            /// The current value
            /// </summary>
            private int currentValue;
            /// <summary>
            /// The TRK main
            /// </summary>
            private TrackBar trkMain;

            /// <summary>
            /// Initializes a new instance of the <see cref="OpacityEditorUI"/> class.
            /// </summary>
            /// <param name="currentValue">The current value.</param>
            /// <param name="min">The minimum.</param>
            /// <param name="max">The maximum.</param>
            protected internal OpacityEditorUI(int currentValue, int min, int max)
            {
                InitializeComponent();
                this.currentValue = currentValue;
                trkMain.Minimum = min;
                trkMain.Maximum = max;
                trkMain.Value = currentValue;
                trkMain.TickFrequency = (max - min) / 10;
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>System.Object.</returns>
            public object GetValue()
            {
                return currentValue;
            }

            /// <summary>
            /// Handles the ValueChanged event of the trkMain control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void trkMain_ValueChanged(object sender, EventArgs e)
            {
                currentValue = trkMain.Value;
            }

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Component Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new Container();
                this.trkMain = new System.Windows.Forms.TrackBar();
                ((System.ComponentModel.ISupportInitialize)(this.trkMain)).BeginInit();
                this.SuspendLayout();
                // 
                // trkMain
                // 
                this.trkMain.AutoSize = false;
                this.trkMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.trkMain.Location = new System.Drawing.Point(0, 0);
                this.trkMain.Name = "trkMain";
                this.trkMain.RightToLeftLayout = true;
                this.trkMain.Size = new System.Drawing.Size(150, 37);
                this.trkMain.TabIndex = 0;
                this.trkMain.TickFrequency = 16;
                this.trkMain.ValueChanged += new System.EventHandler(this.trkMain_ValueChanged);
                // 
                // OpacityEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.Controls.Add(this.trkMain);
                this.Name = "OpacityEditorUI";
                this.Size = new System.Drawing.Size(150, 37);
                ((System.ComponentModel.ISupportInitialize)(this.trkMain)).EndInit();
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
    #endregion

    #endregion

    #region Entity

    #region ColorPair
    /// <summary>
    /// Represents two color pair with gradient angle.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Editor(typeof(ZeroitMonthCalanderColorPairEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderColorPair>))]
    //[Serializable]
    public class ZeroitMonthCalanderColorPair : ICloneable, IXmlSerializable
    {
        #region Fields

        /// <summary>
        /// The current default gradient
        /// </summary>
        private readonly int currentDefaultGradient = 90;
        /// <summary>
        /// The back color1
        /// </summary>
        private Color backColor1;
        /// <summary>
        /// The back color2
        /// </summary>
        private Color backColor2;
        /// <summary>
        /// The gradient
        /// </summary>
        private int gradient;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderColorPair" /> class.
        /// </summary>
        public ZeroitMonthCalanderColorPair()
        {
            backColor1 = Color.Empty;
            backColor2 = Color.Empty;
            gradient = 90;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderColorPair" /> class.
        /// </summary>
        /// <param name="backColor1">Start color.</param>
        /// <param name="backColor2">End color</param>
        /// <param name="gradient">Gradient of the brush.</param>
        public ZeroitMonthCalanderColorPair(Color backColor1, Color backColor2, int gradient)
        {
            this.backColor1 = backColor1;
            this.backColor2 = backColor2;
            this.gradient = gradient;
            currentDefaultGradient = gradient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderColorPair"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitMonthCalanderColorPair(Color color)
        {
            backColor1 = color;
            backColor2 = color;
            gradient = 0;
        }

        #endregion

        #region Override

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</returns>
        public override string ToString()
        {
            return "BackColor1 : " + backColor1 + ";" + "BackColor2 : " + backColor2 + ";" + "Gradient : " + gradient;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"></see>.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var pair = obj as ZeroitMonthCalanderColorPair;
            if (pair != null)
            {
                return pair.BackColor1.Equals(backColor1) && pair.BackColor2.Equals(backColor2) &&
                       pair.Gradient.Equals(gradient);
            }
            return false;
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets Start color.
        /// </summary>
        /// <value>The back color1.</value>
        public Color BackColor1
        {
            get { return backColor1; }
            set
            {
                if (!backColor1.Equals(value))
                {
                    backColor1 = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets End color.
        /// </summary>
        /// <value>The back color2.</value>
        public Color BackColor2
        {
            get { return backColor2; }
            set
            {
                if (!backColor2.Equals(value))
                {
                    backColor2 = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets Gradient.
        /// </summary>
        /// <value>The gradient.</value>
        [Editor(typeof(ZeroitMonthCalanderGradientAngleEditor), typeof(UITypeEditor))]
        public int Gradient
        {
            get { return gradient; }
            set
            {
                if (!gradient.Equals(value))
                {
                    gradient = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        #endregion

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ZeroitMonthCalanderColorPair p1, ZeroitMonthCalanderColorPair p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            return p1.Equals(p2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ZeroitMonthCalanderColorPair p1, ZeroitMonthCalanderColorPair p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Occurs when [appearance changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<ZeroitMonthCalanderAppearanceAction> AppearanceChanged;

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnAppearanceChanged(ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        /// <summary>
        /// Gets the brush.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Brush.</returns>
        public Brush GetBrush(Rectangle rect)
        {
            return new LinearGradientBrush(rect, BackColor1, BackColor2, gradient);
        }

        /// <summary>
        /// Assigns the specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        public void Assign(ZeroitMonthCalanderColorPair color)
        {
            backColor1 = color.backColor1;
            backColor2 = color.backColor2;
            gradient = color.gradient;
        }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            if (doc.GetElementsByTagName("BackColor1").Count > 0)
                BackColor1 = GetColor(doc.GetElementsByTagName("BackColor1")[0].InnerText);
            if (doc.GetElementsByTagName("BackColor2").Count > 0)
                BackColor2 = GetColor(doc.GetElementsByTagName("BackColor2")[0].InnerText);
            if (doc.GetElementsByTagName("Gradient").Count > 0)
                Gradient = Convert.ToInt32(doc.GetElementsByTagName("Gradient")[0].InnerText);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BackColor1", GetString(BackColor1));
            writer.WriteElementString("BackColor2", GetString(BackColor2));
            writer.WriteElementString("Gradient", Gradient.ToString());
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        private static Color GetColor(string c)
        {
            if (c.IndexOf(',') > 0)
            {
                var parts = c.Split(',');
                return Color.FromArgb(Convert.ToInt32(parts[0].Trim()), Convert.ToInt32(parts[1].Trim()),
                                      Convert.ToInt32(parts[2].Trim()),
                                      Convert.ToInt32(parts[3].Trim()));
            }
            return Color.FromName(c);
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        private static string GetString(Color c)
        {
            if (c.IsNamedColor || c.IsKnownColor || c.IsSystemColor)
                return c.Name;
            if (c.IsEmpty)
                return string.Empty;
            return c.A + ", " + c.R + ", " + c.G + ", " + c.B;
        }

        #endregion

        #region IClonable member

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var pair = new ZeroitMonthCalanderColorPair { backColor1 = backColor1, backColor2 = backColor2, gradient = gradient };
            return pair;
        }

        #endregion

        #region Reset methods used by IDE

        /// <summary>
        /// Resets the back color1.
        /// </summary>
        public void ResetBackColor1()
        {
            backColor1 = Color.Empty;
        }

        /// <summary>
        /// Resets the back color2.
        /// </summary>
        public void ResetBackColor2()
        {
            backColor2 = Color.Empty;
        }

        /// <summary>
        /// Resets the gradient.
        /// </summary>
        public void ResetGradient()
        {
            gradient = 90;
        }

        #endregion

        #region Should Serialize methods used by IDE

        /// <summary>
        /// Shoulds the serialize back color1.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBackColor1()
        {
            return !backColor1.IsEmpty;
        }

        /// <summary>
        /// Shoulds the serialize back color2.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBackColor2()
        {
            return !backColor2.IsEmpty;
        }

        /// <summary>
        /// Shoulds the serialize gradient.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeGradient()
        {
            return gradient != currentDefaultGradient;
        }

        #endregion

        #region Nested class

        #region Nested type: ColorPairEditor

        /// <summary>
        /// UITypeEditor for <see cref="ZeroitMonthCalanderColorPair" /> type.
        /// </summary>
        /// <seealso cref="System.Drawing.Design.UITypeEditor" />
        public class ZeroitMonthCalanderColorPairEditor : UITypeEditor
        {
            #region Fields

            /// <summary>
            /// The display
            /// </summary>
            private DisplayStyleUI display;

            #endregion

            #region Override

            /// <summary>
            /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
            /// <param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
            /// <param name="value">The object to edit.</param>
            /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (provider != null)
                {
                    var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                    if (edSvc == null)
                    {
                        return value;
                    }
                    if (display == null)
                    {
                        display = new DisplayStyleUI();
                    }
                    display.Start(value);
                    edSvc.DropDownControl(display);
                    value = display.Value;
                    display.End();
                }
                return value;
            }

            /// <summary>
            /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
            /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }

            /// <summary>
            /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
            /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.</returns>
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            /// <summary>
            /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see>.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see> that indicates what to paint and where to paint it.</param>
            public override void PaintValue(PaintValueEventArgs e)
            {
                base.PaintValue(e);
                var pair = e.Value as ZeroitMonthCalanderColorPair;
                if (pair != null)
                {
                    var br = new LinearGradientBrush(e.Bounds, pair.BackColor1, pair.BackColor2, pair.Gradient);
                    e.Graphics.FillRectangle(br, e.Bounds);
                }
            }

            #endregion
        }

        #endregion

        #region Nested type: DisplayStyleUI

        /// <summary>
        /// Class DisplayStyleUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.UserControl" />
        [ToolboxItem(false)]
        private class DisplayStyleUI : UserControl
        {
            #region Fields

            /// <summary>
            /// The grad UI
            /// </summary>
            private ZeroitMonthCalanderGradientAngleEditor.ZeroitMonthCalanderGradientEditorUI gradUI;
            /// <summary>
            /// The label back1
            /// </summary>
            private Label lblBack1;
            /// <summary>
            /// The label back2
            /// </summary>
            private Label lblBack2;
            /// <summary>
            /// The label current
            /// </summary>
            private Label lblCurrent;
            /// <summary>
            /// The label grad
            /// </summary>
            private Label lblGrad;
            /// <summary>
            /// The label new
            /// </summary>
            private Label lblNew;
            /// <summary>
            /// The label old grad
            /// </summary>
            private Label lblOldGrad;
            /// <summary>
            /// The label preview
            /// </summary>
            private Label lblPreview;
            /// <summary>
            /// The PNL new back1
            /// </summary>
            private Panel pnlNewBack1;
            /// <summary>
            /// The PNL new back2
            /// </summary>
            private Panel pnlNewBack2;
            /// <summary>
            /// The PNL old back1
            /// </summary>
            private Panel pnlOldBack1;
            /// <summary>
            /// The PNL old back2
            /// </summary>
            private Panel pnlOldBack2;
            /// <summary>
            /// The PNL preview
            /// </summary>
            private Panel pnlPreview;
            /// <summary>
            /// The value
            /// </summary>
            private ZeroitMonthCalanderColorPair value;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="DisplayStyleUI"/> class.
            /// </summary>
            internal DisplayStyleUI()
            {
                InitializeComponent();
            }

            #endregion

            #region Private Methods

            /// <summary>
            /// Paints the panel.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void PaintPanel(PaintEventArgs e)
            {
                var brush1 = new LinearGradientBrush(pnlPreview.ClientRectangle, value.BackColor1, value.BackColor2,
                                                     value.Gradient);
                e.Graphics.FillRectangle(brush1, pnlPreview.ClientRectangle);
            }

            #endregion

            #region Public property

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <value>The value.</value>
            public ZeroitMonthCalanderColorPair Value
            {
                get { return value; }
            }

            #endregion

            #region Designer generated code

            /// <summary>
            /// Initializes the component.
            /// </summary>
            private void InitializeComponent()
            {
                this.pnlPreview = new System.Windows.Forms.Panel();
                this.lblPreview = new System.Windows.Forms.Label();
                this.lblBack1 = new System.Windows.Forms.Label();
                this.lblBack2 = new System.Windows.Forms.Label();
                this.lblGrad = new System.Windows.Forms.Label();
                this.pnlOldBack1 = new System.Windows.Forms.Panel();
                this.pnlOldBack2 = new System.Windows.Forms.Panel();
                this.lblOldGrad = new System.Windows.Forms.Label();
                this.lblCurrent = new System.Windows.Forms.Label();
                this.lblNew = new System.Windows.Forms.Label();
                this.pnlNewBack2 = new System.Windows.Forms.Panel();
                this.pnlNewBack1 = new System.Windows.Forms.Panel();
                gradUI = new ZeroitMonthCalanderGradientAngleEditor.ZeroitMonthCalanderGradientEditorUI();
                this.SuspendLayout();
                // 
                // pnlPreview
                // 
                this.pnlPreview.Location = new System.Drawing.Point(3, 20);
                this.pnlPreview.Name = "pnlPreview";
                this.pnlPreview.Size = new System.Drawing.Size(64, 136);
                this.pnlPreview.TabIndex = 0;
                this.pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
                // 
                // lblPreview
                // 
                this.lblPreview.AutoSize = true;
                this.lblPreview.Location = new System.Drawing.Point(0, 4);
                this.lblPreview.Name = "lblPreview";
                this.lblPreview.Size = new System.Drawing.Size(69, 13);
                this.lblPreview.TabIndex = 1;
                this.lblPreview.Text = "&Preview area";
                // 
                // lblBack1
                // 
                this.lblBack1.AutoSize = true;
                this.lblBack1.Location = new System.Drawing.Point(73, 20);
                this.lblBack1.Name = "lblBack1";
                this.lblBack1.Size = new System.Drawing.Size(62, 13);
                this.lblBack1.TabIndex = 2;
                this.lblBack1.Text = "BackColor1";
                // 
                // lblBack2
                // 
                this.lblBack2.AutoSize = true;
                this.lblBack2.Location = new System.Drawing.Point(73, 45);
                this.lblBack2.Name = "lblBack2";
                this.lblBack2.Size = new System.Drawing.Size(62, 13);
                this.lblBack2.TabIndex = 3;
                this.lblBack2.Text = "BackColor2";
                // 
                // lblGrad
                // 
                this.lblGrad.AutoSize = true;
                this.lblGrad.Location = new System.Drawing.Point(73, 102);
                this.lblGrad.Name = "lblGrad";
                this.lblGrad.Size = new System.Drawing.Size(47, 13);
                this.lblGrad.TabIndex = 4;
                this.lblGrad.Text = "Gradient";
                // 
                // pnlOldBack1
                // 
                this.pnlOldBack1.BorderStyle = BorderStyle.FixedSingle;
                this.pnlOldBack1.Location = new System.Drawing.Point(169, 20);
                this.pnlOldBack1.Name = "pnlOldBack1";
                this.pnlOldBack1.Size = new System.Drawing.Size(13, 13);
                this.pnlOldBack1.TabIndex = 5;
                // 
                // pnlOldBack2
                // 
                this.pnlOldBack2.BorderStyle = BorderStyle.FixedSingle;
                this.pnlOldBack2.Location = new System.Drawing.Point(169, 45);
                this.pnlOldBack2.Name = "pnlOldBack2";
                this.pnlOldBack2.Size = new System.Drawing.Size(13, 13);
                this.pnlOldBack2.TabIndex = 6;
                // 
                // lblOldGrad
                // 
                this.lblOldGrad.AutoSize = true;
                this.lblOldGrad.Location = new System.Drawing.Point(166, 69);
                this.lblOldGrad.Name = "lblOldGrad";
                this.lblOldGrad.Size = new System.Drawing.Size(0, 13);
                this.lblOldGrad.TabIndex = 7;
                // 
                // lblCurrent
                // 
                this.lblCurrent.AutoSize = true;
                this.lblCurrent.Location = new System.Drawing.Point(145, 4);
                this.lblCurrent.Name = "lblCurrent";
                this.lblCurrent.Size = new System.Drawing.Size(70, 13);
                this.lblCurrent.TabIndex = 8;
                this.lblCurrent.Text = "&Current value";
                // 
                // lblNew
                // 
                this.lblNew.AutoSize = true;
                this.lblNew.Location = new System.Drawing.Point(243, 4);
                this.lblNew.Name = "lblNew";
                this.lblNew.Size = new System.Drawing.Size(58, 13);
                this.lblNew.TabIndex = 12;
                this.lblNew.Text = "&New value";
                // 
                // pnlNewBack2
                // 
                this.pnlNewBack2.BorderStyle = BorderStyle.FixedSingle;
                this.pnlNewBack2.Location = new System.Drawing.Point(269, 45);
                this.pnlNewBack2.Name = "pnlNewBack2";
                this.pnlNewBack2.Size = new System.Drawing.Size(13, 13);
                this.pnlNewBack2.TabIndex = 10;
                this.pnlNewBack2.Click += new System.EventHandler(this.pnlNewBack2_Click);
                // 
                // pnlNewBack1
                // 
                this.pnlNewBack1.BorderStyle = BorderStyle.FixedSingle;
                this.pnlNewBack1.Location = new System.Drawing.Point(269, 20);
                this.pnlNewBack1.Name = "pnlNewBack1";
                this.pnlNewBack1.Size = new System.Drawing.Size(13, 13);
                this.pnlNewBack1.TabIndex = 9;
                this.pnlNewBack1.Click += new System.EventHandler(this.pnlNewBack1_Click);
                // 
                // gradUI
                // 
                this.gradUI.AutoSize = true;
                this.gradUI.Location = new System.Drawing.Point(169, 64);
                this.gradUI.Name = "gradUI";
                this.gradUI.Size = new System.Drawing.Size(113, 90);
                this.gradUI.TabIndex = 14;
                this.gradUI.ValueChanged += new EventHandler(label1_ValueChanged);
                // 
                // DisplayStyleUI
                // 
                this.Controls.Add(this.gradUI);
                this.Controls.Add(this.lblNew);
                this.Controls.Add(this.pnlNewBack2);
                this.Controls.Add(this.pnlNewBack1);
                this.Controls.Add(this.lblCurrent);
                this.Controls.Add(this.lblOldGrad);
                this.Controls.Add(this.pnlOldBack2);
                this.Controls.Add(this.pnlOldBack1);
                this.Controls.Add(this.lblGrad);
                this.Controls.Add(this.lblBack2);
                this.Controls.Add(this.lblBack1);
                this.Controls.Add(this.lblPreview);
                this.Controls.Add(this.pnlPreview);
                this.Name = "DisplayStyleUI";
                this.Size = new System.Drawing.Size(314, 159);
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion

            #region Public Method

            /// <summary>
            /// Starts the specified value.
            /// </summary>
            /// <param name="val">The value.</param>
            public void Start(object val)
            {
                value = val as ZeroitMonthCalanderColorPair;
                if (value == null)
                    return;
                pnlOldBack1.BackColor = value.BackColor1;
                pnlOldBack2.BackColor = value.BackColor2;
                pnlNewBack1.BackColor = value.BackColor1;
                pnlNewBack2.BackColor = value.BackColor2;
                lblOldGrad.Text = value.Gradient.ToString();
                gradUI.Value = value.Gradient;
                pnlPreview.Refresh();
            }

            /// <summary>
            /// Ends this instance.
            /// </summary>
            public void End()
            {
                value = null;
            }

            #endregion

            #region Event handler

            /// <summary>
            /// Handles the Paint event of the panel1 control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                PaintPanel(e);
            }

            /// <summary>
            /// Handles the Click event of the pnlNewBack2 control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void pnlNewBack2_Click(object sender, EventArgs e)
            {
                var dlg = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    Color = value.BackColor2,
                    FullOpen = true
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    value.BackColor2 = dlg.Color;
                    pnlNewBack2.BackColor = dlg.Color;
                }
                pnlPreview.Refresh();
            }

            /// <summary>
            /// Handles the Click event of the pnlNewBack1 control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void pnlNewBack1_Click(object sender, EventArgs e)
            {
                var dlg = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    Color = value.BackColor1,
                    FullOpen = true
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    value.BackColor1 = dlg.Color;
                    pnlNewBack1.BackColor = dlg.Color;
                }
                pnlPreview.Refresh();
            }

            /// <summary>
            /// Handles the ValueChanged event of the label1 control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void label1_ValueChanged(object sender, EventArgs e)
            {
                value.Gradient = gradUI.GetValue();
                pnlPreview.Refresh();
            }

            #endregion
        }

        #endregion

        #endregion
    }
    #endregion

    #region ColorSchemeDefinition
    /// <summary>
    /// Class ZeroitMonthCalanderThemeProperty.
    /// </summary>
    [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderThemeProperty>))]
    public class ZeroitMonthCalanderThemeProperty
    {
        /// <summary>
        /// The color scheme
        /// </summary>
        private ZeroitMonthCalanderColorScheme colorScheme;
        /// <summary>
        /// The use theme
        /// </summary>
        private bool useTheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderThemeProperty"/> class.
        /// </summary>
        public ZeroitMonthCalanderThemeProperty()
        {
            Reset();
        }

        /// <summary>
        /// Gets or sets the zeroit month calander color scheme.
        /// </summary>
        /// <value>The zeroit month calander color scheme.</value>
        public ZeroitMonthCalanderColorScheme ZeroitMonthCalanderColorScheme
        {
            get { return colorScheme; }
            set
            {
                if (colorScheme != value)
                {
                    colorScheme = value;
                    OnThemeChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use theme].
        /// </summary>
        /// <value><c>true</c> if [use theme]; otherwise, <c>false</c>.</value>
        public bool UseTheme
        {
            get { return useTheme; }
            set
            {
                if (useTheme != value)
                {
                    useTheme = value;
                    OnThemeChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Occurs when [theme changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<ZeroitMonthCalanderAppearanceAction> ThemeChanged;

        /// <summary>
        /// Called when [theme changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnThemeChanged(ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged(this, e);
            }
        }

        /// <summary>
        /// Defaults the changed.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DefaultChanged()
        {
            return ShouldSerializeColorScheme() || ShouldSerializeUseTheme();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        internal void Reset()
        {
            ResetColorScheme();
            ResetUseTheme();
        }

        /// <summary>
        /// Shoulds the serialize use theme.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeUseTheme()
        {
            return useTheme != true;
        }


        /// <summary>
        /// Shoulds the serialize color scheme.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeColorScheme()
        {
            return colorScheme != ZeroitMonthCalanderColorScheme.Default;
        }

        /// <summary>
        /// Resets the use theme.
        /// </summary>
        private void ResetUseTheme()
        {
            useTheme = true;
        }


        /// <summary>
        /// Resets the color scheme.
        /// </summary>
        private void ResetColorScheme()
        {
            colorScheme = ZeroitMonthCalanderColorScheme.Default;
        }
    }

    /// <summary>
    /// Enum representing the color scheme to use for <c><see cref="ZeroitMonthCalander" /></c>.
    /// </summary>
    public enum ZeroitMonthCalanderColorScheme
    {
        /// <summary>
        /// The default
        /// </summary>
        Default,
        /// <summary>
        /// The classic
        /// </summary>
        Classic,
        /// <summary>
        /// The blue
        /// </summary>
        Blue,
        /// <summary>
        /// The olive green
        /// </summary>
        OliveGreen,
        /// <summary>
        /// The royale
        /// </summary>
        Royale,
        /// <summary>
        /// The silver
        /// </summary>
        Silver,
        /// <summary>
        /// The v S2005
        /// </summary>
        VS2005
    }

    /// <summary>
    /// Class ZeroitMonthCalanderColorSchemeDefinition.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ZeroitMonthCalanderColorSchemeDefinition : IDisposable
    {
        /// <summary>
        /// The blue
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition blue;
        /// <summary>
        /// The classic
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition classic;
        /// <summary>
        /// The default
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition @default;
        /// <summary>
        /// The olive green
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition oliveGreen;
        /// <summary>
        /// The royale
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition royale;
        /// <summary>
        /// The silver
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition silver;
        /// <summary>
        /// The v S2005
        /// </summary>
        private static ZeroitMonthCalanderColorSchemeDefinition vS2005;
        /// <summary>
        /// The base color scheme
        /// </summary>
        private readonly ZeroitMonthCalanderColorScheme baseColorScheme;
        /// <summary>
        /// The color scheme
        /// </summary>
        private ZeroitMonthCalanderColorScheme colorScheme;
        /// <summary>
        /// The color table
        /// </summary>
        private Hashtable colorTable;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderColorSchemeDefinition"/> class.
        /// </summary>
        /// <param name="baseColorScheme">The base color scheme.</param>
        protected ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme baseColorScheme)
        {
            this.baseColorScheme = baseColorScheme;
            Initialize();
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        /// <summary>
        /// Gets the color of the selected back.
        /// </summary>
        /// <value>The color of the selected back.</value>
        public virtual Color SelectedBackColor
        {
            get { return (Color)colorTable[ColorIndex.SelectedBackColor]; }
        }

        /// <summary>
        /// Gets the color of the selected date border.
        /// </summary>
        /// <value>The color of the selected date border.</value>
        public virtual Color SelectedDateBorderColor
        {
            get { return (Color)colorTable[ColorIndex.SelectedDateBorderColor]; }
        }

        /// <summary>
        /// Gets the color of the arrow hover.
        /// </summary>
        /// <value>The color of the arrow hover.</value>
        public virtual Color ArrowHoverColor
        {
            get { return (Color)colorTable[ColorIndex.ArrowHoverColor]; }
        }

        /// <summary>
        /// Gets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public virtual Color HoverColor
        {
            get { return (Color)colorTable[ColorIndex.HoverColor]; }
        }

        /// <summary>
        /// Gets the color of the arrow.
        /// </summary>
        /// <value>The color of the arrow.</value>
        public virtual Color ArrowColor
        {
            get { return (Color)colorTable[ColorIndex.ArrowColor]; }
        }

        /// <summary>
        /// Gets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        public virtual Color CaptionTextColor
        {
            get { return (Color)colorTable[ColorIndex.CaptionTextColor]; }
        }

        /// <summary>
        /// Gets the color of the inactive text.
        /// </summary>
        /// <value>The color of the inactive text.</value>
        public virtual Color InactiveTextColor
        {
            get { return (Color)colorTable[ColorIndex.InactiveTextColor]; }
        }

        /// <summary>
        /// Gets the color of the caption back.
        /// </summary>
        /// <value>The color of the caption back.</value>
        public virtual Color CaptionBackColor
        {
            get { return (Color)colorTable[ColorIndex.CaptionBackColor]; }
        }

        /// <summary>
        /// Gets the day marker.
        /// </summary>
        /// <value>The day marker.</value>
        public virtual Color DayMarker
        {
            get { return (Color)colorTable[ColorIndex.DayMarker]; }
        }

        /// <summary>
        /// Gets the color of the control back.
        /// </summary>
        /// <value>The color of the control back.</value>
        public virtual Color ControlBackColor
        {
            get { return (Color)colorTable[ColorIndex.ControlBackColor]; }
        }

        /// <summary>
        /// Gets the color of the control border.
        /// </summary>
        /// <value>The color of the control border.</value>
        public virtual Color ControlBorderColor
        {
            get { return (Color)colorTable[ColorIndex.ControlBorderColor]; }
        }

        /// <summary>
        /// Gets the color of the date day saperator.
        /// </summary>
        /// <value>The color of the date day saperator.</value>
        public virtual Color DateDaySaperatorColor
        {
            get { return (Color)colorTable[ColorIndex.DateDaySaperatorColor]; }
        }

        /// <summary>
        /// Gets the color of the today.
        /// </summary>
        /// <value>The color of the today.</value>
        public virtual Color TodayColor
        {
            get { return (Color)colorTable[ColorIndex.TodayColor]; }
        }

        /// <summary>
        /// Gets the base color scheme.
        /// </summary>
        /// <value>The base color scheme.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ZeroitMonthCalanderColorScheme BaseColorScheme
        {
            get { return baseColorScheme; }
        }

        /// <summary>
        /// Gets the zeroit month calander color scheme.
        /// </summary>
        /// <value>The zeroit month calander color scheme.</value>
        public ZeroitMonthCalanderColorScheme ZeroitMonthCalanderColorScheme
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
                if (!ZeroitMonthCalanderUXTHEME.IsThemeActive())
                {
                    return null;
                }
                var builder = new StringBuilder(255);
                var builder2 = new StringBuilder(255);
                ZeroitMonthCalanderUXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
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
                ZeroitMonthCalanderUXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets the default color scheme.
        /// </summary>
        /// <value>The default color scheme.</value>
        public static ZeroitMonthCalanderColorScheme DefaultColorScheme
        {
            get
            {
                const ZeroitMonthCalanderColorScheme colorScheme1 = ZeroitMonthCalanderColorScheme.Classic;
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
                    return ZeroitMonthCalanderColorScheme.Classic;
                }
                if (!string.IsNullOrEmpty(currentTheme))
                {
                    if (string.Compare(themeFile, "HOMESTEAD", true) != 0)
                    {
                        return ZeroitMonthCalanderColorScheme.OliveGreen;
                    }
                    if (string.Compare(themeFile, "METALLIC", true) != 0)
                    {
                        return ZeroitMonthCalanderColorScheme.Silver;
                    }
                }
                return ZeroitMonthCalanderColorScheme.Blue;
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
                        return ZeroitMonthCalanderUXTHEME.IsThemeActive();
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the v S2005.
        /// </summary>
        /// <value>The v S2005.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition VS2005
        {
            get
            {
                if (vS2005 == null)
                {
                    vS2005 = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.VS2005);
                }
                return vS2005;
            }
        }

        /// <summary>
        /// Gets the classic.
        /// </summary>
        /// <value>The classic.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition Classic
        {
            get
            {
                if (classic == null)
                {
                    classic = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.Classic);
                }
                return classic;
            }
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>The default.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition Default
        {
            get
            {
                if (@default == null)
                {
                    @default = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.Default);
                }
                return @default;
            }
        }

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition Blue
        {
            get
            {
                if (blue == null)
                {
                    blue = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.Blue);
                }
                return blue;
            }
        }

        /// <summary>
        /// Gets the olive green.
        /// </summary>
        /// <value>The olive green.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition OliveGreen
        {
            get
            {
                if (oliveGreen == null)
                {
                    oliveGreen = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.OliveGreen);
                }
                return oliveGreen;
            }
        }

        /// <summary>
        /// Gets the royale.
        /// </summary>
        /// <value>The royale.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition Royale
        {
            get
            {
                if (royale == null)
                {
                    royale = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.Royale);
                }
                return royale;
            }
        }

        /// <summary>
        /// Gets the silver.
        /// </summary>
        /// <value>The silver.</value>
        public static ZeroitMonthCalanderColorSchemeDefinition Silver
        {
            get
            {
                if (silver == null)
                {
                    silver = new ZeroitMonthCalanderColorSchemeDefinition(ZeroitMonthCalanderColorScheme.Silver);
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
        /// Initializes the silver.
        /// </summary>
        private void InitializeSilver()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(75, 75, 111);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(75, 75, 111);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(186, 185, 206);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(212, 212, 226);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(110, 109, 143);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(255, 255, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// Initializes the royale.
        /// </summary>
        private void InitializeRoyale()
        {
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(51, 94, 168);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(51, 94, 168);
            colorTable[ColorIndex.ArrowColor] = Color.FromArgb(153, 175, 212);
            colorTable[ColorIndex.ArrowHoverColor] = Color.FromArgb(194, 207, 229);
            colorTable[ColorIndex.SelectedBackColor] = Color.FromArgb(226, 229, 238);
            colorTable[ColorIndex.CaptionTextColor] = Color.FromArgb(0, 0, 0);
            colorTable[ColorIndex.InactiveTextColor] = Color.FromArgb(176, 175, 179);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(238, 238, 238);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(235, 233, 237);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(200, 200, 200);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(193, 193, 196);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(255, 255, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// Initializes the olive green.
        /// </summary>
        private void InitializeOliveGreen()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(63, 93, 56);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(63, 93, 56);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(176, 194, 140);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(218, 227, 187);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(244, 247, 222);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// Initializes the blue.
        /// </summary>
        private void InitializeBlue()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(0, 0, 128);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(0, 0, 128);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(127, 177, 250);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(186, 211, 245);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(59, 97, 156);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(106, 140, 203);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(241, 249, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// Initializes the v S2005.
        /// </summary>
        private void InitializeVS2005()
        {
            Color control = SystemColors.Control;
            Color controlDark = SystemColors.ControlDark;
            Color highlight = SystemColors.Highlight;
            Color window = SystemColors.Window;
            Color controlText = SystemColors.ControlText;
            Color controlLightLight = SystemColors.ControlLightLight;
            CalculateColor(control, window, 0.23f);
            CalculateColor(control, window, 0.5f);
            colorTable[ColorIndex.HoverColor] = highlight;
            colorTable[ColorIndex.SelectedDateBorderColor] = highlight;
            colorTable[ColorIndex.ArrowColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window,
                                                               0.55f);
            colorTable[ColorIndex.ArrowHoverColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window, 0.7f);
            colorTable[ColorIndex.SelectedBackColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window,
                                                                      0.85f);
            colorTable[ColorIndex.CaptionTextColor] = controlText;
            colorTable[ColorIndex.InactiveTextColor] = controlDark;
            colorTable[ColorIndex.ControlBackColor] = CalculateColor(controlDark, window, 0.25f);
            colorTable[ColorIndex.CaptionBackColor] = control;
            colorTable[ColorIndex.TodayColor] = CalculateColor(control, window, 0.165f);
            colorTable[ColorIndex.ControlBorderColor] = CalculateColor(controlDark, window, 0.3f);
            colorTable[ColorIndex.DateDaySaperatorColor] = controlLightLight;
            colorTable[ColorIndex.DayMarker] = controlLightLight;
        }

        /// <summary>
        /// Initializes the misc.
        /// </summary>
        private void InitializeMisc()
        {
            colorTable[ColorIndex.ControlBackColor] = CalculateColor(SystemColors.ControlDark, SystemColors.Window, 0.7f);
            colorTable[ColorIndex.TodayColor] = SystemColors.ControlDark;
        }

        /// <summary>
        /// Gets the color scheme.
        /// </summary>
        /// <param name="_colorScheme">The color scheme.</param>
        /// <returns>ZeroitMonthCalanderColorSchemeDefinition.</returns>
        public static ZeroitMonthCalanderColorSchemeDefinition GetColorScheme(ZeroitMonthCalanderColorScheme _colorScheme)
        {
            switch (_colorScheme)
            {
                case ZeroitMonthCalanderColorScheme.Classic:
                    return Classic;

                case ZeroitMonthCalanderColorScheme.Blue:
                    return Blue;

                case ZeroitMonthCalanderColorScheme.OliveGreen:
                    return OliveGreen;

                case ZeroitMonthCalanderColorScheme.Royale:
                    return Royale;

                case ZeroitMonthCalanderColorScheme.Silver:
                    return Silver;

                case ZeroitMonthCalanderColorScheme.VS2005:
                    return VS2005;
            }
            return Default;
        }

        /// <summary>
        /// Initializes the common colors.
        /// </summary>
        private void InitializeCommonColors()
        {
            colorTable[ColorIndex.ArrowColor] = Color.FromArgb(254, 128, 62);
            colorTable[ColorIndex.ArrowHoverColor] = Color.FromArgb(255, 238, 194);
            colorTable[ColorIndex.SelectedBackColor] = Color.FromArgb(255, 192, 111);
            colorTable[ColorIndex.CaptionTextColor] = Color.FromArgb(0, 0, 0);
            colorTable[ColorIndex.InactiveTextColor] = Color.FromArgb(141, 141, 141);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            colorScheme = baseColorScheme;
            if (colorScheme == ZeroitMonthCalanderColorScheme.Default)
            {
                colorScheme = DefaultColorScheme;
            }
            colorTable = new Hashtable();
            switch (colorScheme)
            {
                case ZeroitMonthCalanderColorScheme.Blue:
                    InitializeBlue();
                    break;

                case ZeroitMonthCalanderColorScheme.OliveGreen:
                    InitializeOliveGreen();
                    break;

                case ZeroitMonthCalanderColorScheme.Royale:
                    InitializeRoyale();
                    break;

                case ZeroitMonthCalanderColorScheme.Silver:
                    InitializeSilver();
                    break;

                case ZeroitMonthCalanderColorScheme.VS2005:
                    InitializeVS2005();
                    if (DefaultColorScheme != ZeroitMonthCalanderColorScheme.Silver)
                    {
                        InitializeMisc();
                        break;
                    }
                    InitializeSilver();
                    break;

                default:
                    InitializeVS2005();
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
            var r = (byte)(color1.R - ((color1.R - color2.R) * percentage));
            var g = (byte)(color1.G - ((color1.G - color2.G) * percentage));
            var b = (byte)(color1.B - ((color1.B - color2.B) * percentage));
            return Color.FromArgb(r, g, b);
        }

        #region Nested type: ColorIndex

        /// <summary>
        /// Enum ColorIndex
        /// </summary>
        private enum ColorIndex
        {
            /// <summary>
            /// The caption back color
            /// </summary>
            CaptionBackColor = 1,
            /// <summary>
            /// The today color
            /// </summary>
            TodayColor = 2,
            /// <summary>
            /// The control border color
            /// </summary>
            ControlBorderColor = 3,
            /// <summary>
            /// The date day saperator color
            /// </summary>
            DateDaySaperatorColor = 4,
            /// <summary>
            /// The day marker
            /// </summary>
            DayMarker = 5,
            /// <summary>
            /// The hover color
            /// </summary>
            HoverColor = 6,
            /// <summary>
            /// The selected date border color
            /// </summary>
            SelectedDateBorderColor = 7,
            /// <summary>
            /// The arrow color
            /// </summary>
            ArrowColor = 8,
            /// <summary>
            /// The arrow hover color
            /// </summary>
            ArrowHoverColor = 9,
            /// <summary>
            /// The selected back color
            /// </summary>
            SelectedBackColor = 10,
            /// <summary>
            /// The caption text color
            /// </summary>
            CaptionTextColor = 11,
            /// <summary>
            /// The inactive text color
            /// </summary>
            InactiveTextColor = 12,
            /// <summary>
            /// The control back color
            /// </summary>
            ControlBackColor = 13,
        }

        #endregion
    }
    #endregion

    #region CornerShape
    /// <summary>
    /// Class ZeroitMonthCalanderCornerShape.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderCornerShape>))]
    public class ZeroitMonthCalanderCornerShape : ICloneable, IXmlSerializable
    {
        /// <summary>
        /// The bottom left
        /// </summary>
        private ZeroitMonthCalanderCornerType bottomLeft;
        /// <summary>
        /// The bottom right
        /// </summary>
        private ZeroitMonthCalanderCornerType bottomRight;
        /// <summary>
        /// The top left
        /// </summary>
        private ZeroitMonthCalanderCornerType topLeft;
        /// <summary>
        /// The top right
        /// </summary>
        private ZeroitMonthCalanderCornerType topRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderCornerShape"/> class.
        /// </summary>
        public ZeroitMonthCalanderCornerShape()
        {
            topLeft = ZeroitMonthCalanderCornerType.Round;
            topRight = ZeroitMonthCalanderCornerType.Round;
            bottomLeft = ZeroitMonthCalanderCornerType.Round;
            bottomRight = ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderCornerShape"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ZeroitMonthCalanderCornerShape(ZeroitMonthCalanderCornerType type)
        {
            topLeft = type;
            topRight = type;
            bottomLeft = type;
            bottomRight = type;
        }

        /// <summary>
        /// Gets or sets the bottom left.
        /// </summary>
        /// <value>The bottom left.</value>
        public ZeroitMonthCalanderCornerType BottomLeft
        {
            get { return bottomLeft; }
            set
            {
                if (bottomLeft != value)
                {
                    bottomLeft = value;
                    OnBorderCornerChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the bottom right.
        /// </summary>
        /// <value>The bottom right.</value>
        public ZeroitMonthCalanderCornerType BottomRight
        {
            get { return bottomRight; }
            set
            {
                if (bottomRight != value)
                {
                    bottomRight = value;
                    OnBorderCornerChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is all squared.
        /// </summary>
        /// <value><c>true</c> if this instance is all squared; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsAllSquared
        {
            get
            {
                return ((((topLeft == ZeroitMonthCalanderCornerType.Square) && (topRight == ZeroitMonthCalanderCornerType.Square)) &&
                         (bottomLeft == ZeroitMonthCalanderCornerType.Square)) && (bottomRight == ZeroitMonthCalanderCornerType.Square));
            }
        }

        /// <summary>
        /// Gets or sets the top left.
        /// </summary>
        /// <value>The top left.</value>
        public ZeroitMonthCalanderCornerType TopLeft
        {
            get { return topLeft; }
            set
            {
                if (topLeft != value)
                {
                    topLeft = value;
                    OnBorderCornerChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the top right.
        /// </summary>
        /// <value>The top right.</value>
        public ZeroitMonthCalanderCornerType TopRight
        {
            get { return topRight; }
            set
            {
                if (topRight != value)
                {
                    topRight = value;
                    OnBorderCornerChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public virtual object Clone()
        {
            var shape = new ZeroitMonthCalanderCornerShape();
            shape.TopLeft = topLeft;
            shape.TopRight = topRight;
            shape.BottomLeft = bottomLeft;
            shape.BottomRight = bottomRight;
            return shape;
        }

        #endregion

        #region Should serialize implementation

        /// <summary>
        /// Shoulds the serialize bottom left.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBottomLeft()
        {
            return bottomLeft != ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Shoulds the serialize bottom right.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBottomRight()
        {
            return bottomRight != ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Shoulds the serialize top left.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeTopLeft()
        {
            return topLeft != ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Shoulds the serialize top right.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeTopRight()
        {
            return topRight != ZeroitMonthCalanderCornerType.Round;
        }

        #endregion

        #region Reset implementation

        /// <summary>
        /// Resets the bottom left.
        /// </summary>
        public void ResetBottomLeft()
        {
            bottomLeft = ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Resets the bottom right.
        /// </summary>
        public void ResetBottomRight()
        {
            bottomRight = ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Resets the top left.
        /// </summary>
        public void ResetTopLeft()
        {
            topLeft = ZeroitMonthCalanderCornerType.Round;
        }

        /// <summary>
        /// Resets the top right.
        /// </summary>
        public void ResetTopRight()
        {
            topRight = ZeroitMonthCalanderCornerType.Round;
        }

        #endregion

        /// <summary>
        /// Occurs when [border corner changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<ZeroitMonthCalanderAppearanceAction> BorderCornerChanged;

        /// <summary>
        /// Defaults the changed.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DefaultChanged()
        {
            return ((topLeft != ZeroitMonthCalanderCornerType.Round) ||
                    ((topRight != ZeroitMonthCalanderCornerType.Round) ||
                     ((bottomLeft != ZeroitMonthCalanderCornerType.Round) || (bottomRight != ZeroitMonthCalanderCornerType.Round))));
        }

        /// <summary>
        /// Called when [border corner changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnBorderCornerChanged(ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            if (BorderCornerChanged != null)
            {
                BorderCornerChanged(this, e);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var shape = obj as ZeroitMonthCalanderCornerShape;
            if (shape != null)
            {
                return shape.bottomLeft == bottomLeft && shape.bottomRight == bottomRight && shape.topLeft == topLeft &&
                       shape.topRight == topRight;
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Assigns the specified shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public void Assign(ZeroitMonthCalanderCornerShape shape)
        {
            TopLeft = shape.topLeft;
            TopRight = shape.topRight;
            BottomLeft = shape.bottomLeft;
            BottomRight = shape.bottomRight;
        }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            if (doc.GetElementsByTagName("BottomLeft").Count > 0)
                BottomLeft =
                    (ZeroitMonthCalanderCornerType)Enum.Parse(typeof(ZeroitMonthCalanderCornerType), doc.GetElementsByTagName("BottomLeft")[0].InnerText);
            if (doc.GetElementsByTagName("BottomRight").Count > 0)
                BottomRight =
                    (ZeroitMonthCalanderCornerType)Enum.Parse(typeof(ZeroitMonthCalanderCornerType), doc.GetElementsByTagName("BottomRight")[0].InnerText);
            if (doc.GetElementsByTagName("TopLeft").Count > 0)
                TopLeft = (ZeroitMonthCalanderCornerType)Enum.Parse(typeof(ZeroitMonthCalanderCornerType), doc.GetElementsByTagName("TopLeft")[0].InnerText);
            if (doc.GetElementsByTagName("TopRight").Count > 0)
                TopRight =
                    (ZeroitMonthCalanderCornerType)Enum.Parse(typeof(ZeroitMonthCalanderCornerType), doc.GetElementsByTagName("TopRight")[0].InnerText);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BottomLeft", BottomLeft.ToString());
            writer.WriteElementString("BottomRight", BottomRight.ToString());
            writer.WriteElementString("TopLeft", TopLeft.ToString());
            writer.WriteElementString("TopRight", TopRight.ToString());
        }

        #endregion
    }
    #endregion

    #endregion

    #region Enums

    #region AppearanceAction

    /// <summary>
    /// Enum representing the rendering action  for <c><see cref="ZeroitMonthCalander" /></c>.
    /// </summary>
    public enum ZeroitMonthCalanderAppearanceAction
    {
        /// <summary>
        /// The recreate
        /// </summary>
        Recreate,
        /// <summary>
        /// The repaint
        /// </summary>
        Repaint,
        /// <summary>
        /// The update
        /// </summary>
        Update
    }
    #endregion

    #region CornerType
    /// <summary>
    /// Enum representing the corner type to use for <c><see cref="ZeroitMonthCalander" /></c>.
    /// </summary>
    public enum ZeroitMonthCalanderCornerType
    {
        /// <summary>
        /// The sliced
        /// </summary>
        Sliced,
        /// <summary>
        /// The round
        /// </summary>
        Round,
        /// <summary>
        /// The square
        /// </summary>
        Square
    }
    #endregion

    #endregion

    #region Generics

    #region GenericCancelEventArgs

    /// <summary>
    /// Delegate ZeroitMonthCalanderGenericCancelEventHandler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">The sender.</param>
    /// <param name="tArgs">The t arguments.</param>
    public delegate void ZeroitMonthCalanderGenericCancelEventHandler<T>(object sender, ZeroitMonthCalanderGenericCancelEventArgs<T> tArgs);

    /// <summary>
    /// Class ZeroitMonthCalanderGenericCancelEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.CancelEventArgs" />
    public class ZeroitMonthCalanderGenericCancelEventArgs<T> : CancelEventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCancelEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ZeroitMonthCalanderGenericCancelEventArgs(T value) : base(false)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCancelEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cancel">if set to <c>true</c> [cancel].</param>
        public ZeroitMonthCalanderGenericCancelEventArgs(T value, bool cancel) : base(cancel)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
    #endregion

    #region GenericChangeEventArgs
    /// <summary>
    /// Delegate ZeroitMonthCalanderGenericValueChangingHandler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    public delegate void ZeroitMonthCalanderGenericValueChangingHandler<T>(object sender, ZeroitMonthCalanderGenericChangeEventArgs<T> e);

    /// <summary>
    /// Class ZeroitMonthCalanderGenericChangeEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.CancelEventArgs" />
    public class ZeroitMonthCalanderGenericChangeEventArgs<T> : CancelEventArgs
    {
        /// <summary>
        /// The old value
        /// </summary>
        private readonly T oldValue;
        /// <summary>
        /// The new value
        /// </summary>
        private T newValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericChangeEventArgs{T}"/> class.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public ZeroitMonthCalanderGenericChangeEventArgs(T oldValue, T newValue) : base(false)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericChangeEventArgs{T}"/> class.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="cancel">if set to <c>true</c> [cancel].</param>
        public ZeroitMonthCalanderGenericChangeEventArgs(T oldValue, T newValue, bool cancel) : base(cancel)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// Gets the old value.
        /// </summary>
        /// <value>The old value.</value>
        public T OldValue
        {
            get { return oldValue; }
        }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>The new value.</value>
        public T NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }
    }
    #endregion

    #region GenericClickEventArgs

    /// <summary>
    /// Delegate ZeroitMonthCalanderGenericClickEventHandler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    public delegate void ZeroitMonthCalanderGenericClickEventHandler<T>(object sender, ZeroitMonthCalanderGenericClickEventArgs<T> e);

    /// <summary>
    /// Class ZeroitMonthCalanderGenericClickEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitMonthCalanderGenericEventArgs{T}" />
    public class ZeroitMonthCalanderGenericClickEventArgs<T> : ZeroitMonthCalanderGenericEventArgs<T>
    {
        /// <summary>
        /// The button
        /// </summary>
        private readonly MouseButtons button;
        /// <summary>
        /// The position
        /// </summary>
        private readonly Point position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericClickEventArgs{T}"/> class.
        /// </summary>
        public ZeroitMonthCalanderGenericClickEventArgs()
        {
            button = MouseButtons.None;
            position = Point.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericClickEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="button">The button.</param>
        /// <param name="position">The position.</param>
        public ZeroitMonthCalanderGenericClickEventArgs(T value, MouseButtons button, Point position) : base(value)
        {
            this.button = MouseButtons.None;
            this.position = Point.Empty;
            this.button = button;
            this.position = position;
        }

        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>The button.</value>
        public MouseButtons Button
        {
            get { return button; }
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>The position.</value>
        public Point Position
        {
            get { return position; }
        }
    }
    #endregion

    #region GenericCollection
    /// <summary>
    /// Class ZeroitMonthCalanderGenericCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.CollectionBase" />
    /// <seealso cref="System.Runtime.Serialization.IDeserializationCallback" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.Runtime.Serialization.ISerializable" />
    public class ZeroitMonthCalanderGenericCollection<T> : CollectionBase, IDeserializationCallback, IDisposable, ISerializable
    {
        #region Delegates

        /// <summary>
        /// Delegate ZeroitMonthCalanderCollectionChangedHandler
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public delegate void ZeroitMonthCalanderCollectionChangedHandler(int index, T value);

        /// <summary>
        /// Delegate ZeroitMonthCalanderCollectionChangingHandler
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public delegate void ZeroitMonthCalanderCollectionChangingHandler(int index, ZeroitMonthCalanderGenericCancelEventArgs<T> value);

        /// <summary>
        /// Delegate ZeroitMonthCalanderCollectionClearHandler
        /// </summary>
        public delegate void ZeroitMonthCalanderCollectionClearHandler();

        /// <summary>
        /// Delegate ZeroitMonthCalanderCollectionClearingHandler
        /// </summary>
        /// <param name="value">The value.</param>
        public delegate void ZeroitMonthCalanderCollectionClearingHandler(ZeroitMonthCalanderGenericCancelEventArgs<ZeroitMonthCalanderGenericCollection<T>> value);

        /// <summary>
        /// Delegate ZeroitMonthCalanderItemChangeHandler
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public delegate void ZeroitMonthCalanderItemChangeHandler(int index, T oldValue, T newValue);

        /// <summary>
        /// Delegate ZeroitMonthCalanderItemChangingHandler
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="e">The e.</param>
        public delegate void ZeroitMonthCalanderItemChangingHandler(int index, ZeroitMonthCalanderGenericChangeEventArgs<T> e);

        /// <summary>
        /// Delegate ZeroitMonthCalanderValidateHandle
        /// </summary>
        /// <param name="value">The value.</param>
        public delegate void ZeroitMonthCalanderValidateHandle(T value);

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCollection{T}"/> class.
        /// </summary>
        public ZeroitMonthCalanderGenericCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCollection{T}"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public ZeroitMonthCalanderGenericCollection(object owner)
        {
            this.owner = owner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCollection{T}"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected ZeroitMonthCalanderGenericCollection(SerializationInfo info, StreamingContext context)
        {
            siInfo = info;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCollection{T}"/> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public ZeroitMonthCalanderGenericCollection(IEnumerable<T> items) : this()
        {
            foreach (T barItem in items)
            {
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsert(InnerList.Count, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                InnerList.Add(barItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsertComplete(InnerList.Count - 1, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericCollection{T}"/> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public ZeroitMonthCalanderGenericCollection(ZeroitMonthCalanderGenericCollection<T> items) : this()
        {
            foreach (T item in items)
            {
                var newItem = (T)(item is ICloneable ? (item as ICloneable).Clone() : item);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsert(InnerList.Count, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                InnerList.Add(newItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsertComplete(InnerList.Count - 1, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public T this[int index]
        {
            get { return (T)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [cleared].
        /// </summary>
        public event ZeroitMonthCalanderCollectionClearHandler Cleared;

        /// <summary>
        /// Occurs when [clearing].
        /// </summary>
        public event ZeroitMonthCalanderCollectionClearingHandler Clearing;

        /// <summary>
        /// Occurs when [inserted].
        /// </summary>
        public event ZeroitMonthCalanderCollectionChangedHandler Inserted;

        /// <summary>
        /// Occurs when [inserting].
        /// </summary>
        public event ZeroitMonthCalanderCollectionChangingHandler Inserting;

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        public event ZeroitMonthCalanderCollectionChangedHandler Removed;

        /// <summary>
        /// Occurs when [removing].
        /// </summary>
        public event ZeroitMonthCalanderCollectionChangingHandler Removing;

        /// <summary>
        /// Occurs when [changing].
        /// </summary>
        public event ZeroitMonthCalanderItemChangingHandler Changing;

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        public event ZeroitMonthCalanderItemChangeHandler Changed;

        /// <summary>
        /// Occurs when [validating].
        /// </summary>
        public event ZeroitMonthCalanderValidateHandle Validating;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the end of the collection.
        /// </summary>
        /// <param name="item">The item to be added to the end of the Collection. The value can be null.</param>
        /// <returns>The index at which the value has been added.</returns>
        public int Add(T item)
        {
            OnInsert(InnerList.Count, item);
            int index = InnerList.Add(item);
            OnInsertComplete(InnerList.Count, item);
            return index;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(T[] items)
        {
            foreach (T item in items)
            {
                OnInsert(InnerList.Count, item);
                InnerList.Add(item);
                OnInsertComplete(InnerList.Count, item);
            }
        }

        /// <summary>
        /// Adds an item(s) to the end of the collection.
        /// </summary>
        /// <param name="items">The item to be added to the end of the Collection. The value can be null.</param>
        public void Add(T[] items)
        {
            foreach (T item in items)
            {
                OnInsert(InnerList.Count, item);
                InnerList.Add(item);
                OnInsertComplete(InnerList.Count, item);
            }
        }

        /// <summary>
        /// Inserts an element into the Collection at the specified index.
        /// </summary>
        /// <param name="index">Index at which item has to be inserted.</param>
        /// <param name="item">Item to be inserted</param>
        public void Insert(int index, T item)
        {
            OnInsert(index, item);
            InnerList.Insert(index, item);
            OnInsertComplete(index, item);
        }

        /// <summary>
        /// Removes item from the collection.
        /// </summary>
        /// <param name="item">Item to be removed.</param>
        public void Remove(T item)
        {
            int index = IndexOf(item);
            OnRemove(index, item);
            InnerList.Remove(item);
            OnRemoveComplete(index, item);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item)
        {
            return InnerList.LastIndexOf(item);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item, int startIndex)
        {
            return InnerList.LastIndexOf(item, startIndex);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item, int startIndex, int count)
        {
            return InnerList.LastIndexOf(item, startIndex, count);
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public void InsertRange(int index, ZeroitMonthCalanderGenericCollection<T> items)
        {
            InnerList.InsertRange(index, items);
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public bool Contains(T item)
        {
            return InnerList.Contains(item);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value)
        {
            return InnerList.IndexOf(value);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value, int startIndex)
        {
            return InnerList.IndexOf(value, startIndex);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value, int startIndex, int count)
        {
            return InnerList.IndexOf(value, startIndex, count);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        protected override void OnClear()
        {
            var e = new ZeroitMonthCalanderGenericCancelEventArgs<ZeroitMonthCalanderGenericCollection<T>>(this);
            if (Clearing != null)
            {
                Clearing(e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnClear();
        }

        /// <summary>
        /// Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        protected override void OnClearComplete()
        {
            base.OnClearComplete();
            if (Cleared != null)
            {
                Cleared();
            }
        }

        /// <summary>
        /// Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert value.</param>
        /// <param name="value">The new value of the element at index.</param>
        protected override void OnInsert(int index, object value)
        {
            var e = new ZeroitMonthCalanderGenericCancelEventArgs<T>((T)value);
            if (Inserting != null)
            {
                Inserting(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnInsert(index, value);
        }

        /// <summary>
        /// Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert value.</param>
        /// <param name="value">The new value of the element at index.</param>
        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
            if (Inserted != null)
            {
                Inserted(index, (T)value);
            }
        }

        /// <summary>
        /// Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which value can be found.</param>
        /// <param name="value">The value of the element to remove from index.</param>
        protected override void OnRemove(int index, object value)
        {
            var e = new ZeroitMonthCalanderGenericCancelEventArgs<T>((T)value);
            if (Removing != null)
            {
                Removing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnRemove(index, value);
        }

        /// <summary>
        /// Performs additional custom processes after removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which value can be found.</param>
        /// <param name="value">The value of the element to remove from index.</param>
        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
            if (Removed != null)
            {
                Removed(index, (T)value);
            }
        }

        /// <summary>
        /// Performs additional custom processes when validating a value.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void OnValidate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (Validating != null)
            {
                Validating((T)value);
            }
            base.OnValidate(value);
        }

        /// <summary>
        /// Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which oldValue can be found.</param>
        /// <param name="oldValue">The value to replace with newValue.</param>
        /// <param name="newValue">The new value of the element at index.</param>
        protected override void OnSet(int index, object oldValue, object newValue)
        {
            var e = new ZeroitMonthCalanderGenericChangeEventArgs<T>((T)oldValue, (T)newValue);
            if (Changing != null)
            {
                Changing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnSet(index, oldValue, newValue);
        }

        /// <summary>
        /// Performs additional custom processes after setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which oldValue can be found.</param>
        /// <param name="oldValue">The value to replace with newValue.</param>
        /// <param name="newValue">The new value of the element at index.</param>
        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
            if (Changed != null)
            {
                Changed(index, (T)oldValue, (T)newValue);
            }
        }

        #endregion

        /// <summary>
        /// The owner
        /// </summary>
        private object owner;

        /// <summary>
        /// The si information
        /// </summary>
        private SerializationInfo siInfo;

        #region IDeserializationCallback Members

        /// <summary>
        /// Runs when the entire object graph has been deserialized.
        /// </summary>
        /// <param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented.</param>
        public void OnDeserialization(object sender)
        {
            if (siInfo != null)
            {
                Clear();
                if (siInfo.GetInt32("Count") != 0)
                {
                    Clear();
                    int num = siInfo.GetInt32("Count");
                    for (int i = 0; i < num; i++)
                    {
                        Add((T)siInfo.GetValue("Items" + i, typeof(T)));
                    }
                }
                siInfo = null;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            owner = null;
            List.Clear();
            InnerList.Clear();
            siInfo = null;
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        /// <exception cref="ArgumentNullException">info</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Count", Count);
            if (Count != 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    info.AddValue("Items" + i, this[i]);
                }
            }
        }

        #endregion

        /// <summary>
        /// Sets the index of the child.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        public void SetChildIndex(T item, int index)
        {
            if (List.Count > 0)
            {
                int num = IndexOf(item);
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= List.Count)
                {
                    index = List.Count - 1;
                }
                if ((index >= 0) && (index < List.Count))
                {
                    if (num < index)
                    {
                        for (int i = num; i < index; i++)
                        {
                            List[i] = List[i + 1];
                        }
                        List[index] = item;
                    }
                    else if (num > index)
                    {
                        for (int j = num; j > index; j--)
                        {
                            List[j] = List[j - 1];
                        }
                        List[index] = item;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public void Sort(IComparer comparer)
        {
            if ((List.Count > 0) && (comparer != null))
            {
                var array = new object[List.Count];
                for (int i = 0; i < List.Count; i++)
                {
                    array[i] = List[i];
                }
                Array.Sort(array, comparer);
                List.Clear();
                for (int j = 0; j < array.Length; j++)
                {
                    List.Add(array[j]);
                }
            }
        }
    }
    #endregion

    #region GenericConverter
    /// <summary>
    /// Class ZeroitMonthCalanderGenericConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class ZeroitMonthCalanderGenericConverter<T> : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            if (context.PropertyDescriptor != null)
                return !context.PropertyDescriptor.IsReadOnly;
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                   Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(T), attributes);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;
            if (text == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            string text2 = text.Trim();

            if (context == null)
            {
                return null;
            }
            if (text2.Length == 0)
            {
                return null;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            char ch = culture.TextInfo.ListSeparator[0];
            string[] textArray = text2.Split(new[] { ch });
            PropertyInfo[] properties = typeof(T).GetProperties();
            object instance = Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[0]);
            int current = 0;
            if (constructor != null)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].CanWrite)
                    {
                        continue;
                    }
                    string s = TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertToString(context, culture,
                                                                                                       properties[i].
                                                                                                           GetValue(
                                                                                                           instance,
                                                                                                           null));
                    int count = s.Split(new[] { ch }).Length;
                    string tmpString = string.Empty;
                    for (int j = 0; j < count; j++)
                    {
                        tmpString += textArray[current + j] + ch;
                    }
                    current += count;
                    string[] parts = tmpString.Trim(new[] { ch }).Split(new[] { "=" }, StringSplitOptions.None);
                    if (TypeDescriptor.GetConverter(properties[i].PropertyType).CanConvertFrom(typeof(string)))
                    {
                        if (parts.Length == 2)
                        {
                            object val =
                                TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertFromString(
                                    parts[1].Trim(new[] { '[', ']' }));
                            properties[i].SetValue(instance, val, new object[0]);
                        }
                        else
                        {
                            string strings = tmpString.Replace(parts[0], string.Empty).Trim('=');
                            object val =
                                TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertFromString(context,
                                                                                                          culture,
                                                                                                          strings);
                            properties[i].SetValue(instance, val, new object[0]);
                        }
                    }
                    else
                    {
                        object val = properties[i].GetValue(context.PropertyDescriptor.GetValue(context.Instance), null);
                        properties[i].SetValue(instance, val, new object[0]);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter" /> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary" /> of new property values.</param>
        /// <returns>An <see cref="T:System.Object" /> representing the given <see cref="T:System.Collections.IDictionary" />, or null if the object cannot be created. This method always returns null.</returns>
        /// <exception cref="ArgumentNullException">propertyValues</exception>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object instance = Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (!properties[i].CanWrite)
                {
                    continue;
                }
                if (propertyValues[properties[i].Name] == null)
                {
                    continue;
                }
                properties[i].SetValue(instance, propertyValues[properties[i].Name], new object[0]);
            }
            return instance;
        }

        //public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        //{
        //    if (destinationType == null)
        //    {
        //        throw new ArgumentNullException("destinationType");
        //    }
        //    if (value is T)
        //    {
        //        return value.ToString();
        //    }
        //    return base.ConvertTo(context, culture, value, destinationType);
        //}

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <exception cref="ArgumentNullException">destinationType</exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is ZeroitMonthCalanderGenericCollection<T>)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            if (value is T)
            {
                if (destinationType == typeof(string))
                {
                    var tVal = (T)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    PropertyInfo[] properties = tVal.GetType().GetProperties();
                    string separator = culture.TextInfo.ListSeparator[0].ToString();
                    var textArray = new string[properties.Length];
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].CanWrite)
                        {
                            textArray[i] = properties[i].Name + "=[" +
                                           TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertToString(
                                               context, culture, properties[i].GetValue(value, null)) + "]";
                        }
                    }
                    string retVal = string.Empty;
                    for (int i = 0; i < textArray.Length; i++)
                    {
                        if (textArray[i] != null)
                        {
                            retVal += textArray[i] + separator;
                        }
                    }
                    return retVal.TrimEnd(new[] { separator[0] });
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    return new InstanceDescriptor(typeof(T).GetConstructor(new Type[0]), null, false);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    #endregion

    #region GenericEventArgs
    /// <summary>
    /// Delegate ZeroitMonthCalanderGenericEventHandler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">The sender.</param>
    /// <param name="tArgs">The t arguments.</param>
    public delegate void ZeroitMonthCalanderGenericEventHandler<T>(object sender, ZeroitMonthCalanderGenericEventArgs<T> tArgs);

    /// <summary>
    /// Class ZeroitMonthCalanderGenericEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitMonthCalanderGenericEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericEventArgs{T}"/> class.
        /// </summary>
        public ZeroitMonthCalanderGenericEventArgs()
        {
            value = default(T);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderGenericEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ZeroitMonthCalanderGenericEventArgs(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
    #endregion

    #region ReadOnlyConverter
    /// <summary>
    /// Class ZeroitMonthCalanderReadOnlyConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class ZeroitMonthCalanderReadOnlyConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                   Attribute[] attributes)
        {
            var init = TypeDescriptor.GetProperties(value.GetType(), attributes);
            var pds = new PropertyDescriptor[init.Count];
            for (var i = 0; i < init.Count; i++)
            {
                if (!init[i].IsBrowsable)
                    continue;
                var attrs = new List<Attribute>();
                for (var j = 0; j < attributes.Length; j++)
                {
                    attrs.Add(attributes[j]);
                }
                attrs.Add(new ReadOnlyAttribute(true));
                if (init[i].Converter == null || !init[i].Converter.GetType().Assembly.GlobalAssemblyCache)
                {
                    attrs.Add(new TypeConverterAttribute(typeof(ZeroitMonthCalanderReadOnlyConverter)));
                }
                attrs.Add(new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden));
                pds[i] = new PD(init[i].ComponentType, init[i].Name, init[i].PropertyType, attrs.ToArray());
            }
            return new PropertyDescriptorCollection(pds);
        }

        #region Nested type: PD

        /// <summary>
        /// Class PD.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter.SimplePropertyDescriptor" />
        private class PD : SimplePropertyDescriptor
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PD"/> class.
            /// </summary>
            /// <param name="componentType">A <see cref="T:System.Type" /> that represents the type of component to which this property descriptor binds.</param>
            /// <param name="name">The name of the property.</param>
            /// <param name="propertyType">A <see cref="T:System.Type" /> that represents the data type for this property.</param>
            /// <param name="attributes">An <see cref="T:System.Attribute" /> array with the attributes to associate with the property.</param>
            public PD(Type componentType, string name, Type propertyType, Attribute[] attributes)
                : base(componentType, name, propertyType, attributes)
            {
            }

            #region Overrides of PropertyDescriptor

            /// <summary>
            /// When overridden in a derived class, gets the current value of the property on a component.
            /// </summary>
            /// <param name="component">The component with the property for which to retrieve the value.</param>
            /// <returns>The value of a property for a given component.</returns>
            public override object GetValue(object component)
            {
                return component.GetType().GetProperty(Name).GetValue(component, null);
            }

            /// <summary>
            /// When overridden in a derived class, sets the value of the component to a different value.
            /// </summary>
            /// <param name="component">The component with the property value that is to be set.</param>
            /// <param name="value">The new value.</param>
            public override void SetValue(object component, object value)
            {
            }

            #endregion
        }

        #endregion
    }
    #endregion

    #endregion

    #region HitTest

    #region HitTestArea

    /// <summary>
    /// Enum ZeroitMonthCalanderHitTestArea
    /// </summary>
    public enum ZeroitMonthCalanderHitTestArea
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The left button
        /// </summary>
        LeftButton,
        /// <summary>
        /// The right button
        /// </summary>
        RightButton,
        /// <summary>
        /// The month text
        /// </summary>
        MonthText,
        /// <summary>
        /// The year text
        /// </summary>
        YearText,
        /// <summary>
        /// The days
        /// </summary>
        Days,
        /// <summary>
        /// The day marker
        /// </summary>
        DayMarker,
        /// <summary>
        /// The month
        /// </summary>
        Month,
        /// <summary>
        /// The year
        /// </summary>
        Year,
        /// <summary>
        /// The years range
        /// </summary>
        YearsRange,
        /// <summary>
        /// The today bar
        /// </summary>
        TodayBar,
        /// <summary>
        /// The client
        /// </summary>
        Client
    }

    #endregion

    #region MonthCalenderHitTestInfo

    /// <summary>
    /// Class ZeroitMonthCalanderHitTestInfo.
    /// </summary>
    public class ZeroitMonthCalanderHitTestInfo
    {
        /// <summary>
        /// The area
        /// </summary>
        private ZeroitMonthCalanderHitTestArea area;
        /// <summary>
        /// The day
        /// </summary>
        private DateTime? day;
        /// <summary>
        /// The marker day
        /// </summary>
        private DayOfWeek? markerDay;
        /// <summary>
        /// The month
        /// </summary>
        private int month = -1;
        /// <summary>
        /// The year
        /// </summary>
        private int year = -1;
        /// <summary>
        /// The year range end
        /// </summary>
        private int yearRangeEnd = -1;
        /// <summary>
        /// The year range start
        /// </summary>
        private int yearRangeStart = -1;

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public ZeroitMonthCalanderHitTestArea Area
        {
            get { return area; }
            protected internal set { area = value; }
        }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public DateTime? Day
        {
            get { return day; }
            protected internal set { day = value; }
        }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public int Month
        {
            get { return month; }
            protected internal set { month = value; }
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get { return year; }
            protected internal set { year = value; }
        }

        /// <summary>
        /// Gets or sets the year range start.
        /// </summary>
        /// <value>The year range start.</value>
        public int YearRangeStart
        {
            get { return yearRangeStart; }
            protected internal set { yearRangeStart = value; }
        }

        /// <summary>
        /// Gets or sets the year range end.
        /// </summary>
        /// <value>The year range end.</value>
        public int YearRangeEnd
        {
            get { return yearRangeEnd; }
            protected internal set { yearRangeEnd = value; }
        }

        /// <summary>
        /// Gets or sets the marker day.
        /// </summary>
        /// <value>The marker day.</value>
        public DayOfWeek? MarkerDay
        {
            get { return markerDay; }
            protected internal set { markerDay = value; }
        }
    }

    #endregion

    #endregion

    #region Layout

    #region BorderAppearance

    /// <summary>
    /// Class BorderAppearance.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<BorderAppearance>))]
    public class BorderAppearance : ICloneable, IDisposable, IXmlSerializable
    {
        /// <summary>
        /// The border line style
        /// </summary>
        private DashStyle borderLineStyle = DashStyle.Solid;
        /// <summary>
        /// The border visibility
        /// </summary>
        private ToolStripStatusLabelBorderSides borderVisibility = ToolStripStatusLabelBorderSides.All;
        /// <summary>
        /// The corner shape
        /// </summary>
        private ZeroitMonthCalanderCornerShape cornerShape;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderAppearance"/> class.
        /// </summary>
        public BorderAppearance()
        {
            cornerShape = new ZeroitMonthCalanderCornerShape();
        }

        /// <summary>
        /// Gets the zeroit month calander corner shape.
        /// </summary>
        /// <value>The zeroit month calander corner shape.</value>
        [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderCornerShape>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZeroitMonthCalanderCornerShape ZeroitMonthCalanderCornerShape
        {
            get { return cornerShape; }
        }

        /// <summary>
        /// Gets or sets the border line style.
        /// </summary>
        /// <value>The border line style.</value>
        public DashStyle BorderLineStyle
        {
            get { return borderLineStyle; }
            set
            {
                if (borderLineStyle != value)
                {
                    borderLineStyle = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the border visibility.
        /// </summary>
        /// <value>The border visibility.</value>
        public ToolStripStatusLabelBorderSides BorderVisibility
        {
            get { return borderVisibility; }
            set
            {
                if (borderVisibility != value)
                {
                    borderVisibility = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Recreate));
                }
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public virtual object Clone()
        {
            var borderAppearance = new BorderAppearance();
            borderAppearance.ZeroitMonthCalanderCornerShape.Assign((ZeroitMonthCalanderCornerShape)cornerShape.Clone());
            borderAppearance.BorderLineStyle = borderLineStyle;
            borderAppearance.BorderVisibility = borderVisibility;
            return borderAppearance;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (cornerShape != null)
            {
                cornerShape.BorderCornerChanged -= OnBorderCornerChanged;
            }
        }

        #endregion

        /// <summary>
        /// Occurs when [appearance changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<ZeroitMonthCalanderAppearanceAction> AppearanceChanged;

        /// <summary>
        /// Defaults the changed.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DefaultChanged()
        {
            return borderLineStyle != DashStyle.Solid || borderVisibility != ToolStripStatusLabelBorderSides.All ||
                   ZeroitMonthCalanderCornerShape.DefaultChanged();
        }

        /// <summary>
        /// Called when [border corner changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void OnBorderCornerChanged(object sender, ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            OnAppearanceChanged(e);
        }

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnAppearanceChanged(ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public virtual void Reset()
        {
            cornerShape = new ZeroitMonthCalanderCornerShape();
            borderLineStyle = DashStyle.Solid;
            borderVisibility = ToolStripStatusLabelBorderSides.All;
        }

        /// <summary>
        /// Assigns the specified border appearance.
        /// </summary>
        /// <param name="borderAppearance">The border appearance.</param>
        internal void Assign(BorderAppearance borderAppearance)
        {
            ZeroitMonthCalanderCornerShape.Assign((ZeroitMonthCalanderCornerShape)borderAppearance.cornerShape.Clone());
            BorderLineStyle = borderAppearance.borderLineStyle;
            BorderVisibility = borderAppearance.borderVisibility;
        }

        #region Should serialize implementation used by designer

        /// <summary>
        /// Shoulds the serialize corner shape.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCornerShape()
        {
            return cornerShape.DefaultChanged();
        }

        /// <summary>
        /// Shoulds the serialize border line style.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBorderLineStyle()
        {
            return borderLineStyle != DashStyle.Solid;
        }

        /// <summary>
        /// Shoulds the serialize border visibility.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBorderVisibility()
        {
            return borderVisibility != ToolStripStatusLabelBorderSides.All;
        }

        #endregion

        #region Reset implementation used by designer

        /// <summary>
        /// Resets the corner shape.
        /// </summary>
        public void ResetCornerShape()
        {
            cornerShape = new ZeroitMonthCalanderCornerShape();
        }

        /// <summary>
        /// Resets the border line style.
        /// </summary>
        public void ResetBorderLineStyle()
        {
            borderLineStyle = DashStyle.Solid;
        }

        /// <summary>
        /// Resets the border visibility.
        /// </summary>
        public void ResetBorderVisibility()
        {
            borderVisibility = ToolStripStatusLabelBorderSides.All;
        }

        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            if (doc.GetElementsByTagName("BorderLineStyle").Count > 0)
                BorderLineStyle =
                    (DashStyle)Enum.Parse(typeof(DashStyle), doc.GetElementsByTagName("BorderLineStyle")[0].InnerText);
            if (doc.GetElementsByTagName("BorderVisibility").Count > 0)
                BorderVisibility =
                    (ToolStripStatusLabelBorderSides)
                    Enum.Parse(typeof(ToolStripStatusLabelBorderSides),
                               doc.GetElementsByTagName("BorderVisibility")[0].InnerText);
            if (doc.GetElementsByTagName("ZeroitMonthCalanderCornerShape").Count > 0)
            {
                string xml = "<ZeroitMonthCalanderCornerShape>" + doc.GetElementsByTagName("ZeroitMonthCalanderCornerShape")[0].InnerXml + "</ZeroitMonthCalanderCornerShape>";
                ZeroitMonthCalanderCornerShape.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BorderLineStyle", BorderLineStyle.ToString());
            writer.WriteElementString("BorderVisibility", BorderVisibility.ToString());
            writer.WriteStartElement("ZeroitMonthCalanderCornerShape");
            ZeroitMonthCalanderCornerShape.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }

    #endregion

    #region MonthCalenderAppearance

    /// <summary>
    /// Class ZeroitMonthCalanderAppearance.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderAppearance>))]
    public class ZeroitMonthCalanderAppearance : ICloneable, IXmlSerializable
    {
        /// <summary>
        /// The active text color
        /// </summary>
        private Color activeTextColor;
        /// <summary>
        /// The arrow color
        /// </summary>
        private Color arrowColor;
        /// <summary>
        /// The arrow hover color
        /// </summary>
        private Color arrowHoverColor;
        /// <summary>
        /// The button back color
        /// </summary>
        private ZeroitMonthCalanderColorPair buttonBackColor;
        /// <summary>
        /// The caption back color
        /// </summary>
        private ZeroitMonthCalanderColorPair captionBackColor;
        /// <summary>
        /// The caption text color
        /// </summary>
        private Color captionTextColor;
        /// <summary>
        /// The control back color
        /// </summary>
        private Color controlBackColor;
        /// <summary>
        /// The control border color
        /// </summary>
        private Color controlBorderColor;
        /// <summary>
        /// The date day saperator color
        /// </summary>
        private Color dateDaySaperatorColor;
        /// <summary>
        /// The day marker
        /// </summary>
        private Color dayMarker;
        /// <summary>
        /// The disabled mask
        /// </summary>
        private Color disabledMask;
        /// <summary>
        /// The focused border
        /// </summary>
        private Color focusedBorder;
        /// <summary>
        /// The hover color
        /// </summary>
        private Color hoverColor;
        /// <summary>
        /// The inactive text color
        /// </summary>
        private Color inactiveTextColor;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius;
        /// <summary>
        /// The selected back color
        /// </summary>
        private ZeroitMonthCalanderColorPair selectedBackColor;
        /// <summary>
        /// The selected date appearance
        /// </summary>
        private BorderAppearance selectedDateAppearance;
        /// <summary>
        /// The selected date border color
        /// </summary>
        private Color selectedDateBorderColor;
        /// <summary>
        /// The selected date color
        /// </summary>
        private Color selectedDateColor;
        /// <summary>
        /// The today color
        /// </summary>
        private Color todayColor;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalanderAppearance"/> class.
        /// </summary>
        public ZeroitMonthCalanderAppearance()
        {
            Reset();
            buttonBackColor.AppearanceChanged += OnAppearanceChanged;
            captionBackColor.AppearanceChanged += OnAppearanceChanged;
            selectedBackColor.AppearanceChanged += OnAppearanceChanged;
            selectedDateAppearance.AppearanceChanged += OnAppearanceChanged;
        }

        /// <summary>
        /// Gets or sets the focused border.
        /// </summary>
        /// <value>The focused border.</value>
        public Color FocusedBorder
        {
            get { return focusedBorder; }
            set
            {
                if (focusedBorder != value)
                {
                    focusedBorder = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the disabled mask.
        /// </summary>
        /// <value>The disabled mask.</value>
        public Color DisabledMask
        {
            get { return disabledMask; }
            set
            {
                if (disabledMask != value)
                {
                    disabledMask = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the arrow hover.
        /// </summary>
        /// <value>The color of the arrow hover.</value>
        public Color ArrowHoverColor
        {
            get { return arrowHoverColor; }
            set
            {
                if (arrowHoverColor != value)
                {
                    arrowHoverColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the control back.
        /// </summary>
        /// <value>The color of the control back.</value>
        public Color ControlBackColor
        {
            get { return controlBackColor; }
            set
            {
                if (controlBackColor != value)
                {
                    controlBackColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets the selected date appearance.
        /// </summary>
        /// <value>The selected date appearance.</value>
        [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<BorderAppearance>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BorderAppearance SelectedDateAppearance
        {
            get { return selectedDateAppearance; }
        }

        /// <summary>
        /// Gets or sets the color of the today border.
        /// </summary>
        /// <value>The color of the today border.</value>
        public Color TodayBorderColor
        {
            get { return selectedDateBorderColor; }
            set
            {
                if (selectedDateBorderColor != value)
                {
                    selectedDateBorderColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the active text.
        /// </summary>
        /// <value>The color of the active text.</value>
        public Color ActiveTextColor
        {
            get { return activeTextColor; }
            set
            {
                if (activeTextColor != value)
                {
                    activeTextColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the today.
        /// </summary>
        /// <value>The color of the today.</value>
        public Color TodayColor
        {
            get { return todayColor; }
            set
            {
                if (todayColor != value)
                {
                    todayColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the inactive text.
        /// </summary>
        /// <value>The color of the inactive text.</value>
        public Color InactiveTextColor
        {
            get { return inactiveTextColor; }
            set
            {
                if (inactiveTextColor != value)
                {
                    inactiveTextColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected date text.
        /// </summary>
        /// <value>The color of the selected date text.</value>
        public Color SelectedDateTextColor
        {
            get { return selectedDateColor; }
            set
            {
                if (selectedDateColor != value)
                {
                    selectedDateColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the button back.
        /// </summary>
        /// <value>The color of the button back.</value>
        public ZeroitMonthCalanderColorPair ButtonBackColor
        {
            get { return buttonBackColor; }
            set
            {
                if (buttonBackColor != value)
                {
                    buttonBackColor = value;
                    buttonBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets the day marker.
        /// </summary>
        /// <value>The day marker.</value>
        public Color DayMarker
        {
            get { return dayMarker; }
            set
            {
                if (dayMarker != value)
                {
                    dayMarker = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected back.
        /// </summary>
        /// <value>The color of the selected back.</value>
        public ZeroitMonthCalanderColorPair SelectedBackColor
        {
            get { return selectedBackColor; }
            set
            {
                if (selectedBackColor != value)
                {
                    selectedBackColor = value;
                    selectedBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the arrow.
        /// </summary>
        /// <value>The color of the arrow.</value>
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                if (arrowColor != value)
                {
                    arrowColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption back.
        /// </summary>
        /// <value>The color of the caption back.</value>
        public ZeroitMonthCalanderColorPair CaptionBackColor
        {
            get { return captionBackColor; }
            set
            {
                if (captionBackColor != value)
                {
                    captionBackColor = value;
                    captionBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        public Color CaptionTextColor
        {
            get { return captionTextColor; }
            set
            {
                if (captionTextColor != value)
                {
                    captionTextColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                if (hoverColor != value)
                {
                    hoverColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the control border.
        /// </summary>
        /// <value>The color of the control border.</value>
        public Color ControlBorderColor
        {
            get { return controlBorderColor; }
            set
            {
                if (controlBorderColor != value)
                {
                    controlBorderColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the date day saperator.
        /// </summary>
        /// <value>The color of the date day saperator.</value>
        public Color DateDaySaperatorColor
        {
            get { return dateDaySaperatorColor; }
            set
            {
                if (dateDaySaperatorColor != value)
                {
                    dateDaySaperatorColor = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnAppearanceChanged(new ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction>(ZeroitMonthCalanderAppearanceAction.Repaint));
                }
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var obj = new ZeroitMonthCalanderAppearance
            {
                ActiveTextColor = activeTextColor,
                ArrowColor = arrowColor,
                ArrowHoverColor = arrowHoverColor,
                CaptionTextColor = captionTextColor,
                ControlBackColor = controlBackColor,
                ControlBorderColor = controlBorderColor,
                DateDaySaperatorColor = dateDaySaperatorColor,
                DayMarker = dayMarker,
                DisabledMask = disabledMask,
                FocusedBorder = focusedBorder,
                HoverColor = hoverColor,
                InactiveTextColor = inactiveTextColor,
                Radius = radius,
                TodayBorderColor = selectedDateBorderColor,
                SelectedDateTextColor = selectedDateColor,
                TodayColor = todayColor
            };
            SelectedDateAppearance.Assign((BorderAppearance)selectedDateAppearance.Clone());
            ButtonBackColor.Assign((ZeroitMonthCalanderColorPair)buttonBackColor.Clone());
            CaptionBackColor.Assign((ZeroitMonthCalanderColorPair)captionBackColor.Clone());
            SelectedBackColor.Assign((ZeroitMonthCalanderColorPair)selectedBackColor.Clone());
            return obj;
        }

        #endregion

        /// <summary>
        /// Occurs when [appearance changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<ZeroitMonthCalanderAppearanceAction> AppearanceChanged;

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="tArgs">The t arguments.</param>
        private void OnAppearanceChanged(object sender, ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> tArgs)
        {
            OnAppearanceChanged(tArgs);
        }

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnAppearanceChanged(ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        /// <summary>
        /// Defaults the changed.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DefaultChanged()
        {
            return ShouldSerializeActiveTextColor() && ShouldSerializeArrowColor() || ShouldSerializeButtonBackColor() ||
                   ShouldSerializeCaptionTextColor() || ShouldSerializeControlBorderColor() ||
                   ShouldSerializeDateDaySaperatorColor() || ShouldSerializeControlBackColor()
                   || ShouldSerializeDayMarker() || ShouldSerializeHoverColor() || ShouldSerializeInactiveTextColor() ||
                   ShouldSerializeRadius() || ShouldSerializeSelectedBackColor() ||
                   ShouldSerializeSelectedDateAppearance() || ShouldSerializeSelectedDateBorderColor()
                   || ShouldSerializeSelectedDateColor() || ShouldSerializeTodayColor() ||
                   ShouldSerializeCaptionBackColor() || ShouldSerializeArrowHoverColor() ||
                   ShouldSerializeDisabledMask() || ShouldSerializeFocusedBorder();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            ResetSelectedDateAppearance();
            ResetActiveTextColor();
            ResetInactiveTextColor();
            ResetSelectedDateColor();
            ResetSelectedDateBorderColor();
            ResetButtonBackColor();
            ResetSelectedBackColor();
            ResetArrowColor();
            ResetCaptionBackColor();
            ResetCaptionTextColor();
            ResetHoverColor();
            ResetControlBorderColor();
            ResetControlBackColor();
            ResetTodayColor();
            ResetDayMarker();
            ResetDateDaySaperatorColor();
            ResetRadius();
            ResetArrowHoverColor();
            ResetDisabledMask();
            ResetFocusedBorder();
        }

        /// <summary>
        /// Assigns the specified appearance.
        /// </summary>
        /// <param name="appearance">The appearance.</param>
        public void Assign(ZeroitMonthCalanderAppearance appearance)
        {
            ActiveTextColor = appearance.activeTextColor;
            ArrowColor = appearance.arrowColor;
            ArrowHoverColor = appearance.arrowHoverColor;
            ButtonBackColor.Assign(appearance.buttonBackColor);
            CaptionBackColor.Assign(appearance.captionBackColor);
            CaptionTextColor = appearance.captionTextColor;
            ControlBackColor = appearance.controlBackColor;
            ControlBorderColor = appearance.controlBorderColor;
            DateDaySaperatorColor = appearance.dateDaySaperatorColor;
            DayMarker = appearance.dayMarker;
            DisabledMask = appearance.disabledMask;
            FocusedBorder = appearance.focusedBorder;
            HoverColor = appearance.hoverColor;
            InactiveTextColor = appearance.inactiveTextColor;
            Radius = appearance.radius;
            SelectedBackColor.Assign(appearance.selectedBackColor);
            SelectedDateAppearance.Assign((BorderAppearance)appearance.selectedDateAppearance.Clone());
            TodayBorderColor = appearance.selectedDateBorderColor;
            SelectedDateTextColor = appearance.selectedDateColor;
            TodayColor = appearance.todayColor;
        }

        #region ShouldSerialize implementation

        /// <summary>
        /// Shoulds the serialize focused border.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeFocusedBorder()
        {
            return focusedBorder != SystemColors.Highlight;
        }

        /// <summary>
        /// Shoulds the serialize disabled mask.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeDisabledMask()
        {
            return disabledMask != SystemColors.Highlight;
        }

        /// <summary>
        /// Shoulds the color of the serialize arrow hover.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeArrowHoverColor()
        {
            return arrowHoverColor != SystemColors.Highlight;
        }

        /// <summary>
        /// Shoulds the serialize radius.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeRadius()
        {
            return radius != 2;
        }

        /// <summary>
        /// Shoulds the color of the serialize date day saperator.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeDateDaySaperatorColor()
        {
            return dateDaySaperatorColor != SystemColors.ActiveBorder;
        }

        /// <summary>
        /// Shoulds the serialize day marker.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeDayMarker()
        {
            return dayMarker != SystemColors.ActiveCaption;
        }

        /// <summary>
        /// Shoulds the color of the serialize today.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeTodayColor()
        {
            return todayColor != SystemColors.ControlText;
        }

        /// <summary>
        /// Shoulds the color of the serialize control border.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeControlBorderColor()
        {
            return controlBorderColor != SystemColors.ControlText;
        }

        /// <summary>
        /// Shoulds the color of the serialize control back.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeControlBackColor()
        {
            return controlBackColor != SystemColors.Window;
        }

        /// <summary>
        /// Shoulds the color of the serialize hover.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeHoverColor()
        {
            return hoverColor != SystemColors.MenuHighlight;
        }

        /// <summary>
        /// Shoulds the color of the serialize caption text.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeCaptionTextColor()
        {
            return captionTextColor != SystemColors.Window;
        }

        /// <summary>
        /// Shoulds the color of the serialize caption back.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeCaptionBackColor()
        {
            return captionBackColor != new ZeroitMonthCalanderColorPair(SystemColors.HotTrack);
        }

        /// <summary>
        /// Shoulds the color of the serialize arrow.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeArrowColor()
        {
            return arrowColor != SystemColors.Window;
        }

        /// <summary>
        /// Shoulds the color of the serialize selected back.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSelectedBackColor()
        {
            return selectedBackColor != new ZeroitMonthCalanderColorPair(SystemColors.HotTrack, SystemColors.HotTrack, 0);
        }

        /// <summary>
        /// Shoulds the color of the serialize button back.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeButtonBackColor()
        {
            return buttonBackColor != new ZeroitMonthCalanderColorPair(SystemColors.Control, SystemColors.Control, 0);
        }

        /// <summary>
        /// Shoulds the color of the serialize selected date border.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSelectedDateBorderColor()
        {
            return selectedDateBorderColor != Color.Red;
        }

        /// <summary>
        /// Shoulds the color of the serialize selected date.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSelectedDateColor()
        {
            return selectedDateColor != SystemColors.Window;
        }

        /// <summary>
        /// Shoulds the color of the serialize inactive text.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeInactiveTextColor()
        {
            return inactiveTextColor != SystemColors.ControlLight;
        }

        /// <summary>
        /// Shoulds the color of the serialize active text.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeActiveTextColor()
        {
            return activeTextColor != SystemColors.ControlText;
        }

        /// <summary>
        /// Shoulds the serialize selected date appearance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeSelectedDateAppearance()
        {
            return selectedDateAppearance.DefaultChanged();
        }

        #endregion

        #region Reset Implementation

        /// <summary>
        /// Resets the focused border.
        /// </summary>
        private void ResetFocusedBorder()
        {
            focusedBorder = SystemColors.Highlight;
        }

        /// <summary>
        /// Resets the disabled mask.
        /// </summary>
        private void ResetDisabledMask()
        {
            disabledMask = SystemColors.Highlight;
        }

        /// <summary>
        /// Resets the color of the arrow hover.
        /// </summary>
        private void ResetArrowHoverColor()
        {
            arrowHoverColor = SystemColors.Highlight;
        }

        /// <summary>
        /// Resets the radius.
        /// </summary>
        private void ResetRadius()
        {
            radius = 2;
        }

        /// <summary>
        /// Resets the color of the date day saperator.
        /// </summary>
        private void ResetDateDaySaperatorColor()
        {
            dateDaySaperatorColor = SystemColors.ActiveBorder;
        }

        /// <summary>
        /// Resets the day marker.
        /// </summary>
        private void ResetDayMarker()
        {
            dayMarker = SystemColors.ActiveCaption;
        }

        /// <summary>
        /// Resets the color of the today.
        /// </summary>
        private void ResetTodayColor()
        {
            todayColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Resets the color of the control border.
        /// </summary>
        private void ResetControlBorderColor()
        {
            controlBorderColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Resets the color of the control back.
        /// </summary>
        private void ResetControlBackColor()
        {
            controlBackColor = SystemColors.Window;
        }

        /// <summary>
        /// Resets the color of the hover.
        /// </summary>
        private void ResetHoverColor()
        {
            hoverColor = SystemColors.MenuHighlight;
        }

        /// <summary>
        /// Resets the color of the caption text.
        /// </summary>
        private void ResetCaptionTextColor()
        {
            captionTextColor = SystemColors.Window;
        }

        /// <summary>
        /// Resets the color of the caption back.
        /// </summary>
        private void ResetCaptionBackColor()
        {
            captionBackColor = new ZeroitMonthCalanderColorPair(SystemColors.HotTrack);
        }

        /// <summary>
        /// Resets the color of the arrow.
        /// </summary>
        private void ResetArrowColor()
        {
            arrowColor = SystemColors.Window;
        }

        /// <summary>
        /// Resets the color of the selected back.
        /// </summary>
        private void ResetSelectedBackColor()
        {
            selectedBackColor = new ZeroitMonthCalanderColorPair(SystemColors.HotTrack, SystemColors.HotTrack, 0);
        }

        /// <summary>
        /// Resets the color of the button back.
        /// </summary>
        private void ResetButtonBackColor()
        {
            buttonBackColor = new ZeroitMonthCalanderColorPair(SystemColors.Control, SystemColors.Control, 0);
        }

        /// <summary>
        /// Resets the color of the selected date border.
        /// </summary>
        private void ResetSelectedDateBorderColor()
        {
            selectedDateBorderColor = Color.Red;
        }

        /// <summary>
        /// Resets the color of the selected date.
        /// </summary>
        private void ResetSelectedDateColor()
        {
            selectedDateColor = SystemColors.Window;
        }

        /// <summary>
        /// Resets the color of the inactive text.
        /// </summary>
        private void ResetInactiveTextColor()
        {
            inactiveTextColor = SystemColors.ControlLight;
        }

        /// <summary>
        /// Resets the color of the active text.
        /// </summary>
        private void ResetActiveTextColor()
        {
            activeTextColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Resets the selected date appearance.
        /// </summary>
        private void ResetSelectedDateAppearance()
        {
            selectedDateAppearance = new BorderAppearance();
            selectedDateAppearance.AppearanceChanged += OnAppearanceChanged;
        }

        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            if (doc.GetElementsByTagName("FocusedBorder").Count > 0)
                FocusedBorder = GetColor(doc.GetElementsByTagName("FocusedBorder")[0].InnerText);
            if (doc.GetElementsByTagName("DisabledMask").Count > 0)
                DisabledMask = GetColor(doc.GetElementsByTagName("DisabledMask")[0].InnerText);
            if (doc.GetElementsByTagName("ArrowHoverColor").Count > 0)
                ArrowHoverColor = GetColor(doc.GetElementsByTagName("ArrowHoverColor")[0].InnerText);
            if (doc.GetElementsByTagName("ControlBackColor").Count > 0)
                ControlBackColor = GetColor(doc.GetElementsByTagName("ControlBackColor")[0].InnerText);
            if (doc.GetElementsByTagName("CaptionTextColor").Count > 0)
                CaptionTextColor = GetColor(doc.GetElementsByTagName("CaptionTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("HoverColor").Count > 0)
                HoverColor = GetColor(doc.GetElementsByTagName("HoverColor")[0].InnerText);
            if (doc.GetElementsByTagName("ControlBorderColor").Count > 0)
                ControlBorderColor = GetColor(doc.GetElementsByTagName("ControlBorderColor")[0].InnerText);
            if (doc.GetElementsByTagName("DateDaySaperatorColor").Count > 0)
                DateDaySaperatorColor = GetColor(doc.GetElementsByTagName("DateDaySaperatorColor")[0].InnerText);
            if (doc.GetElementsByTagName("DayMarker").Count > 0)
                DayMarker = GetColor(doc.GetElementsByTagName("DayMarker")[0].InnerText);
            if (doc.GetElementsByTagName("ArrowColor").Count > 0)
                ArrowColor = GetColor(doc.GetElementsByTagName("ArrowColor")[0].InnerText);
            if (doc.GetElementsByTagName("TodayBorderColor").Count > 0)
                TodayBorderColor = GetColor(doc.GetElementsByTagName("TodayBorderColor")[0].InnerText);
            if (doc.GetElementsByTagName("ActiveTextColor").Count > 0)
                ActiveTextColor = GetColor(doc.GetElementsByTagName("ActiveTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("TodayColor").Count > 0)
                TodayColor = GetColor(doc.GetElementsByTagName("TodayColor")[0].InnerText);
            if (doc.GetElementsByTagName("InactiveTextColor").Count > 0)
                InactiveTextColor = GetColor(doc.GetElementsByTagName("InactiveTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("SelectedDateTextColor").Count > 0)
                SelectedDateTextColor = GetColor(doc.GetElementsByTagName("SelectedDateTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("Radius").Count > 0)
                Radius = Convert.ToInt32(doc.GetElementsByTagName("Radius")[0].InnerText);
            if (doc.GetElementsByTagName("SelectedDateAppearance").Count > 0)
            {
                var xml = "<BorderAppearance>" + doc.GetElementsByTagName("SelectedDateAppearance")[0].InnerXml +
                          "</BorderAppearance>";
                SelectedDateAppearance.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("ButtonBackColor").Count > 0)
            {
                var xml = "<ZeroitMonthCalanderColorPair>" + doc.GetElementsByTagName("ButtonBackColor")[0].InnerXml + "</ZeroitMonthCalanderColorPair>";
                ButtonBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("SelectedBackColor").Count > 0)
            {
                var xml = "<ZeroitMonthCalanderColorPair>" + doc.GetElementsByTagName("SelectedBackColor")[0].InnerXml + "</ZeroitMonthCalanderColorPair>";
                SelectedBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("CaptionBackColor").Count > 0)
            {
                var xml = "<ZeroitMonthCalanderColorPair>" + doc.GetElementsByTagName("CaptionBackColor")[0].InnerXml + "</ZeroitMonthCalanderColorPair>";
                CaptionBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("FocusedBorder", GetString(FocusedBorder));
            writer.WriteElementString("DisabledMask", GetString(DisabledMask));
            writer.WriteElementString("ArrowHoverColor", GetString(ArrowHoverColor));
            writer.WriteElementString("ControlBackColor", GetString(ControlBackColor));
            writer.WriteStartElement("SelectedDateAppearance");
            SelectedDateAppearance.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("TodayBorderColor", GetString(TodayBorderColor));
            writer.WriteElementString("ActiveTextColor", GetString(ActiveTextColor));
            writer.WriteElementString("TodayColor", GetString(TodayColor));
            writer.WriteElementString("InactiveTextColor", GetString(InactiveTextColor));
            writer.WriteElementString("SelectedDateTextColor", GetString(SelectedDateTextColor));
            writer.WriteStartElement("ButtonBackColor");
            ButtonBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("DayMarker", GetString(DayMarker));
            writer.WriteStartElement("SelectedBackColor");
            SelectedBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("ArrowColor", GetString(ArrowColor));
            writer.WriteStartElement("CaptionBackColor");
            CaptionBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("CaptionTextColor", GetString(CaptionTextColor));
            writer.WriteElementString("HoverColor", GetString(HoverColor));
            writer.WriteElementString("ControlBorderColor", GetString(ControlBorderColor));
            writer.WriteElementString("DateDaySaperatorColor", GetString(DateDaySaperatorColor));
            writer.WriteElementString("Radius", Radius.ToString());
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        private static string GetString(Color c)
        {
            if (c.IsNamedColor || c.IsKnownColor || c.IsSystemColor)
                return c.Name;
            if (c.IsEmpty)
                return string.Empty;
            return c.A + ", " + c.R + ", " + c.G + ", " + c.B;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        private static Color GetColor(string c)
        {
            if (c.IndexOf(',') > 0)
            {
                var parts = c.Split(',');
                return Color.FromArgb(Convert.ToInt32(parts[0].Trim()), Convert.ToInt32(parts[1].Trim()),
                                      Convert.ToInt32(parts[2].Trim()),
                                      Convert.ToInt32(parts[3].Trim()));
            }
            return Color.FromName(c);
        }

        #endregion
    }

    #endregion

    #endregion

    #region Utility

    #region PaintUtility
    /// <summary>
    /// Class ZeroitMonthCalanderPaintUtility.
    /// </summary>
    public static class ZeroitMonthCalanderPaintUtility
    {
        /// <summary>
        /// The themed
        /// </summary>
        public static bool themed;
        /// <summary>
        /// The theme name
        /// </summary>
        public static string ThemeName = string.Empty;
        /// <summary>
        /// The xp theme name
        /// </summary>
        public static string xpThemeName = string.Empty;

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="startColor">The start color.</param>
        /// <param name="endColor">The end color.</param>
        /// <param name="level">The level.</param>
        /// <param name="swapColors">if set to <c>true</c> [swap colors].</param>
        /// <returns>Color.</returns>
        public static Color ChangeColor(Color startColor, Color endColor, int level, bool swapColors)
        {
            if (swapColors)
            {
                Color color = startColor;
                startColor = endColor;
                endColor = color;
            }
            if (level == -1)
            {
                return endColor;
            }
            int r = startColor.R;
            int g = startColor.G;
            int b = startColor.B;
            if (r < endColor.R)
            {
                if ((r + level) < endColor.R)
                {
                    r += level;
                }
                else
                {
                    r = endColor.R;
                }
            }
            else if ((r - level) > endColor.R)
            {
                r -= level;
            }
            else
            {
                r = endColor.R;
            }
            if (r < endColor.G)
            {
                if ((g + level) < endColor.G)
                {
                    g += level;
                }
                else
                {
                    g = endColor.G;
                }
            }
            else if ((g - level) > endColor.G)
            {
                g -= level;
            }
            else
            {
                g = endColor.G;
            }
            if (b < endColor.B)
            {
                if ((b + level) < endColor.B)
                {
                    b += level;
                }
                else
                {
                    b = endColor.B;
                }
            }
            else if ((b - level) > endColor.B)
            {
                b -= level;
            }
            else
            {
                b = endColor.B;
            }
            return Color.FromArgb(0xff, r, g, b);
        }

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="fillBrush">The fill brush.</param>
        /// <param name="bShape">The b shape.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="excRegion">The exc region.</param>
        public static void DrawBackground(Graphics g, RectangleF rect, Brush fillBrush, ZeroitMonthCalanderCornerShape bShape,
                                          int cornerRadius, Region excRegion)
        {
            if (excRegion != null)
            {
                g.ExcludeClip(excRegion);
            }
            GraphicsPath path = GetDrawingPath(rect, bShape, cornerRadius);
            g.FillPath(fillBrush, path);
            fillBrush.Dispose();
            path.Dispose();
        }

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="bShape">The b shape.</param>
        /// <param name="bVisibility">The b visibility.</param>
        /// <param name="bLineStyle">The b line style.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borderBrush">The border brush.</param>
        /// <param name="excRegion">The exc region.</param>
        public static void DrawBorder(Graphics g, RectangleF rect, ZeroitMonthCalanderCornerShape bShape,
                                      ToolStripStatusLabelBorderSides bVisibility, DashStyle bLineStyle,
                                      int cornerRadius, Brush borderBrush, Region excRegion)
        {
            DrawBorder(g, rect, bShape, bVisibility, bLineStyle, cornerRadius, Color.Empty, borderBrush, excRegion);
        }

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="bShape">The b shape.</param>
        /// <param name="bVisibility">The b visibility.</param>
        /// <param name="bLineStyle">The b line style.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="borderBrush">The border brush.</param>
        /// <param name="excRegion">The exc region.</param>
        internal static void DrawBorder(Graphics g, RectangleF rect, ZeroitMonthCalanderCornerShape bShape,
                                        ToolStripStatusLabelBorderSides bVisibility, DashStyle bLineStyle,
                                        int cornerRadius, Color borderColor, Brush borderBrush, Region excRegion)
        {
            if (bVisibility == ToolStripStatusLabelBorderSides.None)
            {
                return;
            }
            if (excRegion != null)
            {
                g.ExcludeClip(excRegion);
            }
            Pen pen;
            if (borderBrush != null)
            {
                pen = new Pen(borderBrush, 1f);
            }
            else
            {
                pen = new Pen(borderColor, 1f);
            }
            SmoothingMode smoothingMode = g.SmoothingMode;
            pen.DashStyle = bLineStyle;
            int num = 2 * cornerRadius;
            if (bVisibility == ToolStripStatusLabelBorderSides.All)
            {
                GraphicsPath path = GetDrawingPath(rect, bShape, cornerRadius);
                g.DrawPath(pen, path);
                path.Dispose();
                g.SmoothingMode = smoothingMode;
                pen.Dispose();
                return;
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, (rect.Y + rect.Height) - cornerRadius);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + cornerRadius, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + rect.Width, rect.Y + cornerRadius, rect.X + rect.Width,
                           (rect.Y + rect.Height) - cornerRadius);
            }
            if ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) > ToolStripStatusLabelBorderSides.None)
            {
                g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, (rect.X + rect.Width) - cornerRadius,
                           rect.Y + rect.Height);
            }
            if (((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None) ||
                ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None))
            {
                switch (bShape.TopLeft)
                {
                    case ZeroitMonthCalanderCornerType.Sliced:
                        g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
                        break;

                    case ZeroitMonthCalanderCornerType.Square:
                        if (((bVisibility & ToolStripStatusLabelBorderSides.Left) <=
                             ToolStripStatusLabelBorderSides.None) ||
                            ((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None))
                        {
                            if (((bVisibility & ToolStripStatusLabelBorderSides.Left) <=
                                 ToolStripStatusLabelBorderSides.None) &&
                                ((bVisibility & ToolStripStatusLabelBorderSides.Top) >
                                 ToolStripStatusLabelBorderSides.None))
                            {
                                g.DrawLine(pen, rect.X, rect.Y, rect.X + cornerRadius, rect.Y);
                            }
                            else
                            {
                                g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, rect.Y);
                                g.DrawLine(pen, rect.X, rect.Y, rect.X + cornerRadius, rect.Y);
                            }
                        }
                        else
                        {
                            g.DrawLine(pen, rect.X, rect.Y + cornerRadius, rect.X, rect.Y);
                        }
                        break;
                }
                if (((bVisibility & ToolStripStatusLabelBorderSides.Top) > ToolStripStatusLabelBorderSides.None) ||
                    ((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None))
                {
                    switch (bShape.TopRight)
                    {
                        case ZeroitMonthCalanderCornerType.Sliced:
                            g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                       rect.Y + cornerRadius);
                            break;
                        case ZeroitMonthCalanderCornerType.Square:
                            if (((bVisibility & ToolStripStatusLabelBorderSides.Right) >
                                 ToolStripStatusLabelBorderSides.None) ||
                                ((bVisibility & ToolStripStatusLabelBorderSides.Top) <=
                                 ToolStripStatusLabelBorderSides.None))
                            {
                                if (((bVisibility & ToolStripStatusLabelBorderSides.Right) >
                                     ToolStripStatusLabelBorderSides.None) &&
                                    ((bVisibility & ToolStripStatusLabelBorderSides.Top) <=
                                     ToolStripStatusLabelBorderSides.None))
                                {
                                    g.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width,
                                               rect.Y + cornerRadius);
                                }
                                else
                                {
                                    g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                               rect.Y);
                                    g.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width,
                                               rect.Y + cornerRadius);
                                }
                            }
                            else
                            {
                                g.DrawLine(pen, (rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                           rect.Y);
                            }
                            break;
                    }
                    if (((bVisibility & ToolStripStatusLabelBorderSides.Right) > ToolStripStatusLabelBorderSides.None) ||
                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) > ToolStripStatusLabelBorderSides.None))
                    {
                        switch (bShape.BottomRight)
                        {
                            case ZeroitMonthCalanderCornerType.Sliced:
                                g.DrawLine(pen, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                           (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                                break;

                            case ZeroitMonthCalanderCornerType.Square:
                                if (((bVisibility & ToolStripStatusLabelBorderSides.Right) <=
                                     ToolStripStatusLabelBorderSides.None) ||
                                    ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                                     ToolStripStatusLabelBorderSides.None))
                                {
                                    if (((bVisibility & ToolStripStatusLabelBorderSides.Right) <=
                                         ToolStripStatusLabelBorderSides.None) &&
                                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                                         ToolStripStatusLabelBorderSides.None))
                                    {
                                        g.DrawLine(pen, (rect.X + rect.Width), (rect.Y + rect.Height),
                                                   (rect.X + rect.Width) - cornerRadius, (rect.Y + rect.Height));
                                    }
                                    else
                                    {
                                        g.DrawLine(pen, (rect.X + rect.Width), ((rect.Y + rect.Height) - cornerRadius),
                                                   rect.X + rect.Width, (rect.Y + rect.Height));
                                        g.DrawLine(pen, (rect.X + rect.Width), (rect.Y + rect.Height),
                                                   (rect.X + rect.Width) - cornerRadius, (rect.Y + rect.Height));
                                    }
                                }
                                else
                                {
                                    g.DrawLine(pen, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                               rect.X + rect.Width, rect.Y + rect.Height);
                                }
                                break;
                        }
                        if (((bVisibility & ToolStripStatusLabelBorderSides.Bottom) >
                             ToolStripStatusLabelBorderSides.None) ||
                            ((bVisibility & ToolStripStatusLabelBorderSides.Left) > ToolStripStatusLabelBorderSides.None))
                        {
                            switch (bShape.BottomLeft)
                            {
                                case ZeroitMonthCalanderCornerType.Sliced:
                                    g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                               (rect.Y + rect.Height) - cornerRadius);
                                    g.SmoothingMode = smoothingMode;
                                    pen.Dispose();
                                    return;

                                case ZeroitMonthCalanderCornerType.Square:
                                    if (((bVisibility & ToolStripStatusLabelBorderSides.Left) >
                                         ToolStripStatusLabelBorderSides.None) ||
                                        ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) <=
                                         ToolStripStatusLabelBorderSides.None))
                                    {
                                        if (((bVisibility & ToolStripStatusLabelBorderSides.Left) >
                                             ToolStripStatusLabelBorderSides.None) &&
                                            ((bVisibility & ToolStripStatusLabelBorderSides.Bottom) <=
                                             ToolStripStatusLabelBorderSides.None))
                                        {
                                            g.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X,
                                                       (rect.Y + rect.Height) - cornerRadius);
                                        }
                                        else
                                        {
                                            g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                                       rect.Y + rect.Height);
                                            g.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X,
                                                       (rect.Y + rect.Height) - cornerRadius);
                                        }
                                    }
                                    else
                                    {
                                        g.DrawLine(pen, rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                                   rect.Y + rect.Height);
                                    }
                                    g.SmoothingMode = smoothingMode;
                                    pen.Dispose();
                                    return;
                            }
                            g.DrawArc(pen, rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                        }
                        g.DrawArc(pen, (rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                    }
                    g.DrawArc(pen, (rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                }
                g.DrawArc(pen, rect.X, rect.Y, num, num, 180f, 90f);
            }
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="img">The img.</param>
        /// <param name="alpha">The alpha.</param>
        public static void DrawImage(Graphics g, Rectangle rect, Image img, int alpha)
        {
            if (img != null)
            {
                if (alpha == 0xff)
                {
                    g.DrawImage(img, rect);
                }
                else
                {
                    var imageAttr = new ImageAttributes();
                    imageAttr.SetColorMatrix(MakeTransparentImage(alpha));
                    g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttr);
                    imageAttr.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets the drawing path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="bShape">The b shape.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GetDrawingPath(RectangleF rect, ZeroitMonthCalanderCornerShape bShape, int cornerRadius)
        {
            var path = new GraphicsPath();
            int num = 2 * cornerRadius;
            if (bShape.TopLeft == ZeroitMonthCalanderCornerType.Square)
            {
                if (bShape.TopRight == ZeroitMonthCalanderCornerType.Square)
                {
                    path.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                }
                else
                {
                    path.AddLine(rect.X, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
                    if (bShape.TopRight == ZeroitMonthCalanderCornerType.Round)
                    {
                        path.AddArc((rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                    }
                    else
                    {
                        path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                     rect.Y + cornerRadius);
                    }
                }
            }
            else if (bShape.TopRight == ZeroitMonthCalanderCornerType.Square)
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, rect.X + rect.Width, rect.Y);
            }
            else
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, (rect.X + rect.Width) - cornerRadius, rect.Y);
                if (bShape.TopRight == ZeroitMonthCalanderCornerType.Round)
                {
                    path.AddArc((rect.X + rect.Width) - num, rect.Y, num, num, 270f, 90f);
                }
                else
                {
                    path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y, rect.X + rect.Width,
                                 rect.Y + cornerRadius);
                }
            }
            if (bShape.TopRight == ZeroitMonthCalanderCornerType.Square)
            {
                if (bShape.BottomRight == ZeroitMonthCalanderCornerType.Square)
                {
                    path.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius);
                    if (bShape.BottomRight == ZeroitMonthCalanderCornerType.Round)
                    {
                        path.AddArc((rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                    }
                    else
                    {
                        path.AddLine(rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                     (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                    }
                }
            }
            else if (bShape.BottomRight == ZeroitMonthCalanderCornerType.Square)
            {
                path.AddLine(rect.X + rect.Width, rect.Y + cornerRadius, (rect.X + rect.Width), (rect.Y + rect.Height));
            }
            else
            {
                path.AddLine(rect.X + rect.Width, rect.Y + cornerRadius, (rect.X + rect.Width),
                             ((rect.Y + rect.Height) - cornerRadius));
                if (bShape.BottomRight == ZeroitMonthCalanderCornerType.Round)
                {
                    path.AddArc((rect.X + rect.Width) - num, (rect.Y + rect.Height) - num, num, num, 0f, 90f);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, (rect.Y + rect.Height) - cornerRadius,
                                 (rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height);
                }
            }
            if (bShape.BottomRight == ZeroitMonthCalanderCornerType.Square)
            {
                if (bShape.BottomLeft == ZeroitMonthCalanderCornerType.Square)
                {
                    path.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
                }
                else
                {
                    path.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X + cornerRadius, rect.Y + rect.Height);
                    if (bShape.BottomLeft == ZeroitMonthCalanderCornerType.Round)
                    {
                        path.AddArc(rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                    }
                    else
                    {
                        path.AddLine(rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                     (rect.Y + rect.Height) - cornerRadius);
                    }
                }
            }
            else if (bShape.BottomLeft == ZeroitMonthCalanderCornerType.Square)
            {
                path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
            }
            else
            {
                path.AddLine((rect.X + rect.Width) - cornerRadius, rect.Y + rect.Height, rect.X + cornerRadius,
                             rect.Y + rect.Height);
                if (bShape.BottomLeft == ZeroitMonthCalanderCornerType.Round)
                {
                    path.AddArc(rect.X, (rect.Y + rect.Height) - num, num, num, 90f, 90f);
                }
                else
                {
                    path.AddLine(rect.X + cornerRadius, rect.Y + rect.Height, rect.X,
                                 (rect.Y + rect.Height) - cornerRadius);
                }
            }
            if (bShape.BottomLeft == ZeroitMonthCalanderCornerType.Square)
            {
                if (bShape.TopLeft == ZeroitMonthCalanderCornerType.Square)
                {
                    path.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y);
                    return path;
                }
                path.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y + cornerRadius);
                if (bShape.TopLeft == ZeroitMonthCalanderCornerType.Round)
                {
                    path.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
                    return path;
                }
                path.AddLine(rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
                return path;
            }
            if (bShape.TopLeft == ZeroitMonthCalanderCornerType.Square)
            {
                path.AddLine(rect.X, (rect.Y + rect.Height) - cornerRadius, rect.X, rect.Y);
                return path;
            }
            path.AddLine(rect.X, (rect.Y + rect.Height) - cornerRadius, rect.X, rect.Y + cornerRadius);
            if (bShape.TopLeft == ZeroitMonthCalanderCornerType.Round)
            {
                path.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
                return path;
            }
            path.AddLine(rect.X, rect.Y + cornerRadius, rect.X + cornerRadius, rect.Y);
            return path;
        }

        /// <summary>
        /// Makes the transparent image.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns>ColorMatrix.</returns>
        public static ColorMatrix MakeTransparentImage(int alpha)
        {
            var matrix = new ColorMatrix();
            matrix.Matrix00 = 1f;
            matrix.Matrix11 = 1f;
            matrix.Matrix22 = 1f;
            matrix.Matrix33 = alpha / 255f;
            matrix.Matrix44 = 1f;
            return matrix;
        }
    }
    #endregion

    #region UXTHEME

    /// <summary>
    /// Class ZeroitMonthCalanderUXTHEME.
    /// </summary>
    internal static class ZeroitMonthCalanderUXTHEME
    {
        /// <summary>
        /// Gets the name of the current theme.
        /// </summary>
        /// <param name="pszThemeFileName">Name of the PSZ theme file.</param>
        /// <param name="dwMaxNameChars">The dw maximum name chars.</param>
        /// <param name="pszColorBuff">The PSZ color buff.</param>
        /// <param name="cchMaxColorChars">The CCH maximum color chars.</param>
        /// <param name="pszSizeBuff">The PSZ size buff.</param>
        /// <param name="cchMaxSizeChars">The CCH maximum size chars.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        internal static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars,
                                                       StringBuilder pszColorBuff, int cchMaxColorChars,
                                                       StringBuilder pszSizeBuff, int cchMaxSizeChars);

        /// <summary>
        /// Determines whether [is theme active].
        /// </summary>
        /// <returns><c>true</c> if [is theme active]; otherwise, <c>false</c>.</returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsThemeActive();
    }

    #endregion

    #endregion

    #region MonthCalender

    #region Private Methods

    partial class ZeroitMonthCalander
    {
        /// <summary>
        /// Sets the theme defaults.
        /// </summary>
        internal void SetThemeDefaults()
        {
            currentAppearance.Reset();
            if (!themeProperty.UseTheme)
            {
                currentAppearance.SelectedDateAppearance.Assign(appearance.SelectedDateAppearance);
                currentAppearance.ActiveTextColor = appearance.ActiveTextColor;
                currentAppearance.InactiveTextColor = appearance.InactiveTextColor;
                currentAppearance.SelectedDateTextColor = appearance.SelectedDateTextColor;
                currentAppearance.TodayBorderColor = appearance.TodayBorderColor;
                currentAppearance.ButtonBackColor.Assign(appearance.ButtonBackColor);
                currentAppearance.SelectedBackColor.Assign(appearance.SelectedBackColor);
                currentAppearance.ArrowColor = appearance.ArrowColor;
                currentAppearance.ArrowHoverColor = appearance.ArrowHoverColor;
                currentAppearance.CaptionBackColor.Assign(appearance.CaptionBackColor);
                currentAppearance.CaptionTextColor = appearance.CaptionTextColor;
                currentAppearance.HoverColor = appearance.HoverColor;
                currentAppearance.ControlBorderColor = appearance.ControlBorderColor;
                currentAppearance.TodayColor = appearance.TodayColor;
                currentAppearance.DayMarker = appearance.DayMarker;
                currentAppearance.ControlBackColor = appearance.ControlBackColor;
                currentAppearance.DateDaySaperatorColor = appearance.DateDaySaperatorColor;
                currentAppearance.Radius = 2;
                currentAppearance.DisabledMask = appearance.DisabledMask;
            }
            else
            {
                switch (themeProperty.ZeroitMonthCalanderColorScheme)
                {
                    case ZeroitMonthCalanderColorScheme.VS2005:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.VS2005);
                        break;
                    case ZeroitMonthCalanderColorScheme.Classic:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Classic);
                        break;
                    case ZeroitMonthCalanderColorScheme.Blue:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Blue);
                        break;
                    case ZeroitMonthCalanderColorScheme.Default:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.GetColorScheme(ZeroitMonthCalanderColorScheme.Default));
                        break;
                    case ZeroitMonthCalanderColorScheme.OliveGreen:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.OliveGreen);
                        break;
                    case ZeroitMonthCalanderColorScheme.Royale:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Royale);
                        break;
                    case ZeroitMonthCalanderColorScheme.Silver:
                        SetColors(ZeroitMonthCalanderColorSchemeDefinition.Silver);
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="schemeDefinition">The scheme definition.</param>
        private void SetColors(ZeroitMonthCalanderColorSchemeDefinition schemeDefinition)
        {
            currentAppearance.SelectedDateAppearance.Assign(new BorderAppearance());
            currentAppearance.ActiveTextColor = schemeDefinition.CaptionTextColor;
            currentAppearance.InactiveTextColor = schemeDefinition.InactiveTextColor;
            currentAppearance.SelectedDateTextColor = schemeDefinition.DayMarker;
            currentAppearance.TodayBorderColor = schemeDefinition.SelectedDateBorderColor;
            currentAppearance.ButtonBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.CaptionBackColor));
            currentAppearance.SelectedBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.SelectedBackColor));
            currentAppearance.ArrowColor = schemeDefinition.ArrowColor;
            currentAppearance.CaptionBackColor.Assign(new ZeroitMonthCalanderColorPair(schemeDefinition.CaptionBackColor));
            currentAppearance.CaptionTextColor = schemeDefinition.CaptionTextColor;
            currentAppearance.HoverColor = schemeDefinition.HoverColor;
            currentAppearance.ControlBorderColor = schemeDefinition.ControlBorderColor;
            currentAppearance.TodayColor = schemeDefinition.TodayColor;
            currentAppearance.DayMarker = schemeDefinition.DayMarker;
            currentAppearance.ControlBackColor = schemeDefinition.ControlBackColor;
            currentAppearance.DateDaySaperatorColor = schemeDefinition.DateDaySaperatorColor;
            currentAppearance.Radius = 2;
            currentAppearance.ArrowHoverColor = schemeDefinition.ArrowHoverColor;
            currentAppearance.DisabledMask = schemeDefinition.TodayColor;
        }

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="tArgs">The t arguments.</param>
        private void OnAppearanceChanged(object sender, ZeroitMonthCalanderGenericEventArgs<ZeroitMonthCalanderAppearanceAction> tArgs)
        {
            SetThemeDefaults();
            Invalidate();
        }

        /// <summary>
        /// Calculates the days.
        /// </summary>
        private void CalculateDays()
        {
            for (var i = 0; i < days.Length; i++)
            {
                days[i] = firstDate.AddDays(i);
            }
        }

        /// <summary>
        /// Calculates the first date.
        /// </summary>
        private void CalculateFirstDate()
        {
            firstDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            if (firstDate == DateTime.MinValue) return;
            firstDate = firstDate.DayOfWeek == DayOfWeek.Sunday ? firstDate.AddDays(-7.0) : firstDate.AddDays((-(double)firstDate.DayOfWeek));
        }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        private void SetDefaults()
        {
            Font = new Font("Arial", 9f, FontStyle.Regular);

            if (captionFont == null)
            {
                captionFont = new Font("Arial", 9f, FontStyle.Bold);
            }
        }

        /// <summary>
        /// Creates the memory bitmap.
        /// </summary>
        private void CreateMemoryBitmap()
        {
            if (((bmp != null) && (bmp.Width == Width)) && (bmp.Height == Height))
                return;
            bmp = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            leftRectangle = new Rectangle(ArrowButtonOffset.Width, ArrowButtonOffset.Height, ArrowButtonSize.Width, ArrowButtonSize.Height);
            rightRectangle = new Rectangle(((Width - ArrowButtonOffset.Width) - ArrowButtonSize.Width) - 1, ArrowButtonOffset.Height, ArrowButtonSize.Width, ArrowButtonSize.Height);
            leftArrow[0].X = ArrowPointsOffset.Width;
            leftArrow[0].Y = ArrowPointsOffset.Height + (ArrowPointsSize.Height / 2);
            leftArrow[1].X = leftArrow[0].X + ArrowPointsSize.Width;
            leftArrow[1].Y = ArrowPointsOffset.Height;
            leftArrow[2].X = leftArrow[1].X;
            leftArrow[2].Y = leftArrow[1].Y + ArrowPointsSize.Height;
            rightArrow = (Point[])leftArrow.Clone();
            rightArrow[0].X = Width - ArrowPointsOffset.Width;
            rightArrow[1].X = rightArrow[2].X = rightArrow[0].X - ArrowPointsSize.Width;
        }

        /// <summary>
        /// Displays the month menu.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void DisplayMonthMenu(int x, int y)
        {
            ctmMonths.Show(this, new Point(x, y));
        }

        /// <summary>
        /// Gets the index of the cell at.
        /// </summary>
        /// <param name="cellIndex">Index of the cell.</param>
        /// <returns>Point.</returns>
        private Point GetCellAtIndex(int cellIndex)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    return new Point(DaysGrid.X + ((cellIndex % NumCols) * DaysCell.Width), DaysGrid.Y + ((cellIndex / NumCols) * (DaysCell.Height + 1)));
                case DisplayType.Monthes:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
                case DisplayType.Years:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
                case DisplayType.YearsRange:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
            }
            return new Point(0, 0);
        }

        /// <summary>
        /// Gets the index of the cell.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.Int32.</returns>
        private int GetCellIndex(DateTime date)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    return (int)date.Subtract(firstDate).TotalDays;
                case DisplayType.Monthes:
                    return date.Month - 1;
                case DisplayType.Years:
                    return date.Year - 12 * (selectedDate.Year / 12);
                case DisplayType.YearsRange:
                    return (date.Year - (100 * (selectedDate.Year / 100))) / 100;
            }
            return -1;
        }

        /// <summary>
        /// Gets the index of the cell.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        private int GetCellIndex(int x, int y)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    var rectangle = new Rectangle(0, DaysGrid.Y, NumCols * DaysCell.Width, BottomLabelsPos.Y);
                    if (!rectangle.Contains(x, y))
                    {
                        return -1;
                    }
                    int day = (x / DaysCell.Width) + (((y - DaysGrid.Y) / (DaysCell.Height + 1)) * NumCols);
                    return day >= 42 ? -1 : day;
                case DisplayType.Monthes:
                case DisplayType.Years:
                case DisplayType.YearsRange:
                    var rectangle2 = new Rectangle(0, DaysGrid.Y, 4 * MonthCell.Width, BottomLabelsPos.Y);
                    if (!rectangle2.Contains(x, y))
                    {
                        return -1;
                    }
                    return (x / MonthCell.Width) + (((y - DaysGrid.Y) / (MonthCell.Height + 1)) * 4);
            }
            return -1;
        }

        /// <summary>
        /// Initializes the month context menu.
        /// </summary>
        private void InitMonthContextMenu()
        {
            ctmMonths = new ContextMenu();
            var s = "1/1/2000";
            for (var i = 1; i <= 12; i++)
            {
                var item = new MenuItem();
                ctmMonths.MenuItems.Add(item);
                item.Click += OnMonthMenuClick;
                item.Text = DateTime.Parse(s).ToString("MMMM");
                s = DateTime.Parse(s).AddMonths(1).ToString();
            }
            ctmMonths.Popup += OnMonthMenuPopup;
        }

        /// <summary>
        /// Handles the <see cref="E:MonthMenuClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnMonthMenuClick(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
                return;
            var day = selectedDate.Day;
            var time = DateTime.Parse(string.Format("{0}, {1} {2}", item.Text, 1, selectedDate.Year));
            if (day > DateTime.DaysInMonth(selectedDate.Year, time.Month))
            {
                day = DateTime.DaysInMonth(selectedDate.Year, time.Month);
            }
            var newDate = DateTime.Parse(string.Format("{0}, {1} {2}", item.Text, day, selectedDate.Year));
            UpdateSelected(newDate);
        }

        /// <summary>
        /// Handles the <see cref="E:MonthMenuPopup" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnMonthMenuPopup(object sender, EventArgs e)
        {
            foreach (MenuItem item in ctmMonths.MenuItems)
            {
                item.Checked = false;
            }
            if ((currentMonth > 0) && (currentMonth <= 12))
            {
                ctmMonths.MenuItems[currentMonth - 1].Checked = true;
            }
        }

        /// <summary>
        /// Updates the selected.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        private void UpdateSelected(DateTime newDate)
        {
            hoverDate = newDate;
            var valChange = selectedDate != newDate && hoverDate != DateTime.MinValue;
            if (valChange)
            {
                var args = new ZeroitMonthCalanderGenericChangeEventArgs<DateTime>(selectedDate, newDate, false);
                OnValueChanging(args);
                if (!args.Cancel)
                {
                    selectedDate = newDate;
                    OnValueChanged();
                }
            }
            Refresh();
            Update();
        }

        /// <summary>
        /// Updates the hover cell.
        /// </summary>
        /// <param name="newIndex">The new index.</param>
        private void UpdateHoverCell(int newIndex)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    if ((newIndex < 0) || (newIndex >= days.Length))
                    {
                        var g = CreateGraphics();
                        DrawHoverSelection(g, hoverDate, false);
                        DrawTodaySelection(g);
                        g.Dispose();
                        hoverDate = DateTime.MinValue;
                    }
                    else if (hoverDate != days[newIndex])
                    {
                        var graphics2 = CreateGraphics();
                        DrawHoverSelection(graphics2, hoverDate, false);
                        DrawHoverSelection(graphics2, days[newIndex], true);
                        DrawTodaySelection(graphics2);
                        graphics2.Dispose();
                        hoverDate = days[newIndex];
                    }
                    break;
                case DisplayType.Monthes:
                case DisplayType.Years:
                case DisplayType.YearsRange:
                    if (lastIndex != newIndex)
                    {
                        Graphics graphics2 = CreateGraphics();
                        DrawHoverSelection(graphics2, lastIndex, false);
                        DrawHoverSelection(graphics2, newIndex, true);
                        DrawTodaySelection(graphics2);
                        graphics2.Dispose();
                        lastIndex = newIndex;
                    }
                    break;
            }
        }

        /// <summary>
        /// Updates the hover cell.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void UpdateHoverCell(int x, int y)
        {
            var dayIndex = GetCellIndex(x, y);
            if (dayIndex < 0 && hotAppearance)
            {
                var g = CreateGraphics();
                g.FillPolygon(new SolidBrush((leftRectangle.Contains(x, y)) ? currentAppearance.ArrowHoverColor : CurrentAppearance.ArrowColor), leftArrow);
                g.FillPolygon(new SolidBrush(rightRectangle.Contains(x, y) ? currentAppearance.ArrowHoverColor : currentAppearance.ArrowColor), rightArrow);
                g.Dispose();
            }
            UpdateHoverCell(dayIndex);
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>ZeroitMonthCalanderHitTestInfo.</returns>
        public ZeroitMonthCalanderHitTestInfo HitTest(Point p)
        {
            var info = new ZeroitMonthCalanderHitTestInfo();
            if (leftRectangle.Contains(p))
                info.Area = ZeroitMonthCalanderHitTestArea.LeftButton;
            else if (rightRectangle.Contains(p))
                info.Area = ZeroitMonthCalanderHitTestArea.RightButton;
            else if (monthRectangle.Contains(p))
                info.Area = ZeroitMonthCalanderHitTestArea.MonthText;
            else if (yearRectangle.Contains(p))
                info.Area = ZeroitMonthCalanderHitTestArea.YearText;
            else if (MarkerRectangle.Contains(p))
            {
                info.Area = ZeroitMonthCalanderHitTestArea.DayMarker;
                int dayIndx = (p.X - MarkerRectangle.X) / (MarkerRectangle.Width / 7);
                info.MarkerDay = ((DayOfWeek)dayIndx);
            }
            else
            {
                int indx = GetCellIndex(p.X, p.Y);
                if (indx >= 0)
                {
                    switch (displayType)
                    {
                        case DisplayType.Dates:
                            info.Area = ZeroitMonthCalanderHitTestArea.Days;
                            info.Day = days[indx];
                            break;
                        case DisplayType.Monthes:
                            info.Area = ZeroitMonthCalanderHitTestArea.Month;
                            info.Month = indx + 1;
                            break;
                        case DisplayType.Years:
                            info.Area = ZeroitMonthCalanderHitTestArea.Year;
                            info.Year = 10 * (selectedDate.Year / 10) + indx;
                            break;
                        case DisplayType.YearsRange:
                            info.Area = ZeroitMonthCalanderHitTestArea.YearsRange;
                            info.YearRangeStart = 100 * (selectedDate.Year / 100) + indx * 100;
                            info.YearRangeEnd = info.YearRangeStart + 99;
                            break;
                    }
                }
                else
                {
                    var rect = new Rectangle(BottomLabelsPos.X, BottomLabelsPos.Y, Width - BottomLabelsPos.X, Height - BottomLabelsPos.Y);
                    if (rect.Contains(p))
                        info.Area = ZeroitMonthCalanderHitTestArea.TodayBar;
                    else if (ClientRectangle.Contains(p))
                        info.Area = ZeroitMonthCalanderHitTestArea.Client;
                }
            }
            return info;
        }

        /// <summary>
        /// Shoulds the serialize theme property.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeThemeProperty()
        {
            return themeProperty.DefaultChanged();
        }

        /// <summary>
        /// Resets the theme property.
        /// </summary>
        private void ResetThemeProperty()
        {
            themeProperty.Reset();
        }

        /// <summary>
        /// Shoulds the serialize appearance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeAppearance()
        {
            return Appearance.DefaultChanged();
        }

        /// <summary>
        /// Resets the appearance.
        /// </summary>
        public void ResetAppearance()
        {
            Appearance.Reset();
            Invalidate();
        }

        /// <summary>
        /// Shoulds the serialize font.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeFont()
        {
            return Font.FontFamily.Name != "Arial" && Font.Size != 9f && Font.Style != FontStyle.Regular;
        }

        /// <summary>
        /// Resets the <see cref="P:System.Windows.Forms.Control.Font" /> property to its default value.
        /// </summary>
        private new void ResetFont()
        {
            Font = new Font("Arial", 9f, FontStyle.Regular);
        }

        /// <summary>
        /// Saves the theme.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SaveTheme(string fileName)
        {
            try
            {
                using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                    serializer.Serialize(writer, Appearance);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// Loads the theme.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LoadTheme(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(ZeroitMonthCalanderAppearance));
                    var app = (ZeroitMonthCalanderAppearance)serializer.Deserialize(fs);
                    var appearance = Appearance;
                    appearance.Assign(app);
                    Invalidate();
                    return true;
                }
            }
            catch { }
            return false;
        }
    }

    #endregion

    #region Overrides
    partial class ZeroitMonthCalander
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SystemColorsChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            SetThemeDefaults();
        }

        /// <summary>
        /// Gets a value indicating whether the control should display focus rectangles.
        /// </summary>
        /// <value><c>true</c> if [show focus cues]; otherwise, <c>false</c>.</value>
        protected override bool ShowFocusCues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user interface is in the appropriate state to show or hide keyboard accelerators.
        /// </summary>
        /// <value><c>true</c> if [show keyboard cues]; otherwise, <c>false</c>.</value>
        protected override bool ShowKeyboardCues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the character was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            int dayAdvance = 0;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    dayAdvance = -1;
                    break;

                case Keys.Up:
                    dayAdvance = (displayType == DisplayType.Dates) ? -NumCols : -4;
                    break;

                case Keys.Right:
                    dayAdvance = 1;
                    break;

                case Keys.Down:
                    dayAdvance = (displayType == DisplayType.Dates) ? NumCols : 4;
                    break;
            }
            if (dayAdvance != 0)
            {
                DateTime newDate = selectedDate;
                if (displayType == DisplayType.Dates)
                    newDate = selectedDate.AddDays(dayAdvance);
                if (displayType == DisplayType.Monthes)
                    newDate = selectedDate.AddMonths(dayAdvance);
                if (displayType == DisplayType.Years)
                    newDate = selectedDate.AddYears(dayAdvance);
                if (displayType == DisplayType.YearsRange)
                    newDate = selectedDate.AddYears(dayAdvance * 100 - 1);

                if (selectedDate.Month != newDate.Month)
                {
                    UpdateSelected(newDate);
                }
                else
                {
                    Graphics g = CreateGraphics();
                    DrawDay(g, selectedDate, false);
                    DrawDay(g, newDate, true);
                    g.Dispose();
                    UpdateHoverCell(GetCellIndex(newDate));
                    if (selectedDate != newDate)
                    {
                        var args = new ZeroitMonthCalanderGenericChangeEventArgs<DateTime>(selectedDate, newDate, false);
                        OnValueChanging(args);
                        if (!args.Cancel)
                        {
                            selectedDate = newDate;
                            OnValueChanged();
                            Invalidate();
                        }
                    }
                }
                e.Handled = true;
            }
            if (e.KeyData == Keys.Enter)
            {
                if (displayType == DisplayType.YearsRange)
                {
                    displayType = DisplayType.Years;
                }
                else if (displayType == DisplayType.Years)
                {
                    displayType = DisplayType.Monthes;
                }
                else if (displayType == DisplayType.Monthes)
                {
                    displayType = DisplayType.Dates;
                }
                Invalidate();
                e.Handled = true;
            }
            if (e.KeyData == Keys.Space)
            {
                if (displayType == DisplayType.Dates)
                {
                    displayType = DisplayType.Monthes;
                }
                else if (displayType == DisplayType.Monthes)
                {
                    displayType = DisplayType.Years;
                }
                else if (displayType == DisplayType.Years)
                {
                    displayType = DisplayType.YearsRange;
                }
                Invalidate();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape && displayType != DisplayType.Dates)
            {
                displayType = DisplayType.Dates;
                Invalidate();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            hoverDate = DateTime.MinValue;
            lastIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (CanSelect)
                Select();
            if (leftRectangle.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (displayType == DisplayType.Dates)
                {
                    UpdateSelected(selectedDate.AddMonths(-1));
                }
                else if (displayType == DisplayType.Monthes)
                {
                    UpdateSelected(selectedDate.AddYears(-1));
                }
                else if (displayType == DisplayType.Years)
                {
                    UpdateSelected(selectedDate.AddYears(-12));
                }
                else if (displayType == DisplayType.YearsRange)
                {
                    UpdateSelected(selectedDate.AddYears(-100));
                }
                Invalidate();
            }
            else if (rightRectangle.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (displayType == DisplayType.Dates)
                {
                    UpdateSelected(selectedDate.AddMonths(1));
                }
                else if (displayType == DisplayType.Monthes)
                {
                    UpdateSelected(selectedDate.AddYears(1));
                }
                else if (displayType == DisplayType.Years)
                {
                    UpdateSelected(selectedDate.AddYears(12));
                }
                else if (displayType == DisplayType.YearsRange)
                {
                    UpdateSelected(selectedDate.AddYears(100));
                }
                Invalidate();
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (monthRectangle.Contains(e.X, e.Y) || (yearRectangle.Contains(e.X, e.Y)))
                    {
                        DisplayMonthMenu(e.X, e.Y);
                    }
                    int dayIndex = GetCellIndex(e.X, e.Y);
                    if (dayIndex > 0)
                    {
                        if (displayType == DisplayType.YearsRange)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Dates;
                        }
                        Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (monthRectangle.Contains(e.X, e.Y))
                    {
                        if (displayType == DisplayType.Dates)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.YearsRange;
                        }
                        Invalidate();
                    }
                    else if (yearRectangle.Contains(e.X, e.Y))
                    {
                        if (displayType == DisplayType.Dates)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.YearsRange;
                        }
                        Invalidate();
                    }
                    else if (e.Y >= BottomLabelsPos.Y)
                    {
                        displayType = DisplayType.Dates;
                        UpdateSelected(DateTime.Now);
                    }
                    else
                    {
                        int dayIndex = GetCellIndex(e.X, e.Y);
                        if (displayType == DisplayType.YearsRange)
                        {
                            int startYear = 100 * (selectedDate.Year / 100);
                            selectedDate = selectedDate.AddYears(startYear + dayIndex * 100 - selectedDate.Year);
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            int startYear = 10 * (selectedDate.Year / 10);
                            selectedDate = selectedDate.AddYears(startYear + dayIndex - selectedDate.Year);
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            selectedDate = selectedDate.AddMonths(dayIndex - selectedDate.Month + 1);
                            hoverDate = selectedDate;
                            displayType = DisplayType.Dates;
                            Invalidate();
                        }
                        else if (displayType == DisplayType.Dates)
                        {
                            dayIndex = GetCellIndex(hoverDate);
                            if ((dayIndex >= 0) && (dayIndex < days.Length))
                            {
                                UpdateSelected(hoverDate);
                            }
                        }
                        UpdateHoverCell(e.X, e.Y);
                        UpdateSelected(selectedDate);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            UpdateHoverCell(e.X, e.Y);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            CreateMemoryBitmap();
            //SetDefaults();
            CalculateFirstDate();
            graphics.Clear(currentAppearance.ControlBackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawCaption(graphics);
            switch (displayType)
            {
                case DisplayType.Dates:
                    DrawDaysOfWeek(graphics);
                    DrawDays(graphics);
                    break;
                case DisplayType.Monthes:
                    DrawMonths(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
                case DisplayType.Years:
                    DrawYears(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
                case DisplayType.YearsRange:
                    DrawYearRange(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
            }
            DrawCurSelection();
            DrawTodaySelection(graphics);
            DrawBottomLabels(graphics);
            graphics.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), 0, 0, Width - 1, Height - 1);
            if (!Enabled)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, currentAppearance.DisabledMask)), 0, 0, Width - 1, Height - 1);
            if (Focused && drawFocused)
                graphics.DrawRectangle(new Pen(currentAppearance.FocusedBorder), 0, 0, Width - 1, Height - 1);
            ZeroitMonthCalanderPaintUtility.DrawImage(e.Graphics, new Rectangle(0, 0, bmp.Width, bmp.Height), bmp, (int)(BackgroundImage == null ? 100 * 2.55 : backGroundImageAlpha * 2.55));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
    }
    #endregion

    #region Paint
    partial class ZeroitMonthCalander
    {
        /// <summary>
        /// Draws the bottom labels.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBottomLabels(Graphics g)
        {
            var s = string.Format("Today: {0}", DateTime.Now.ToShortDateString());
            g.DrawString(s, captionFont, new SolidBrush(currentAppearance.TodayColor), BottomLabelsPos.X, BottomLabelsPos.Y);
        }

        /// <summary>
        /// Draws the caption.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawCaption(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width, CaptionHeight);
            g.FillRectangle(currentAppearance.CaptionBackColor.GetBrush(rect), rect);
            switch (displayType)
            {
                case DisplayType.Dates:
                    {
                        var text = selectedDate.ToString("MMMM, yyyy");
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        text = selectedDate.ToString("MMMM");
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle.X = num;
                        monthRectangle.Y = num2;
                        monthRectangle.Width = size2.Width;
                        monthRectangle.Height = size2.Height;
                        text = selectedDate.ToString("yyyy");
                        size2 = g.MeasureString(text, captionFont).ToSize();
                        yearRectangle.X = (num + size.Width) - size2.Width;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.Monthes:
                    {
                        var text = selectedDate.ToString("yyyy");
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.Years:
                    {
                        var startYear = (10 * (selectedDate.Year / 10));
                        var text = startYear.ToString().PadLeft(4, '0') + " - " + (startYear + 11).ToString().PadLeft(4, '0');
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.YearsRange:
                    {
                        var startYear = (100 * (selectedDate.Year / 100));
                        var text = startYear.ToString().PadLeft(4, '0') + " - " + (startYear + 100 * 12 - 1).ToString().PadLeft(4, '0');
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
            }
            g.FillRectangle(currentAppearance.ButtonBackColor.GetBrush(leftRectangle), leftRectangle);
            g.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), leftRectangle);
            g.FillPolygon(new SolidBrush(currentAppearance.ArrowColor), leftArrow);
            g.FillRectangle(currentAppearance.ButtonBackColor.GetBrush(rightRectangle), rightRectangle);
            g.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), rightRectangle);
            g.FillPolygon(new SolidBrush(currentAppearance.ArrowColor), rightArrow);
        }

        /// <summary>
        /// Draws the current selection.
        /// </summary>
        private void DrawCurSelection()
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    {
                        var dayIndex = GetCellIndex(selectedDate);
                        var dayCellPosition = GetCellAtIndex(dayIndex);
                        var rect = new Rectangle(dayCellPosition.X - 4, dayCellPosition.Y + 1, DaysCell.Width - 1, DaysCell.Height - 1);
                        ZeroitMonthCalanderPaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.Radius, null);
                        if (selectedDate.Day < 10)
                        {
                            dayCellPosition.X += 4;
                        }
                        graphics.DrawString(selectedDate.Day.ToString(), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), dayCellPosition.X, dayCellPosition.Y);
                    }
                    break;
                case DisplayType.Monthes:
                    {
                        var monthPosition = GetCellAtIndex(selectedDate.Month - 1);
                        var rect = new Rectangle(monthPosition.X - 5, monthPosition.Y, MonthCell.Width, MonthCell.Height);
                        ZeroitMonthCalanderPaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.Radius, null);
                        graphics.DrawString(selectedDate.ToString("MMM"), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), monthPosition.X, monthPosition.Y + MonthCell.Height / 2 - Font.Height / 2);
                    }
                    break;
                case DisplayType.Years:
                    {
                        var startYear = 10 * (selectedDate.Year / 10);
                        var yearPosition = GetCellAtIndex(selectedDate.Year - startYear);
                        var rect = new Rectangle(yearPosition.X - 5, yearPosition.Y, MonthCell.Width, MonthCell.Height);
                        ZeroitMonthCalanderPaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.Radius, null);
                        graphics.DrawString(selectedDate.ToString("yyyy"), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), yearPosition.X, yearPosition.Y + MonthCell.Height / 2 - Font.Height / 2);
                    }
                    break;
                case DisplayType.YearsRange:
                    {
                        var startYear = 100 * (selectedDate.Year / 100);
                        var rangePosition = GetCellAtIndex((selectedDate.Year - startYear) / 100);
                        GetCellIndex(selectedDate);
                        var rect = new Rectangle(rangePosition.X - 5, rangePosition.Y, MonthCell.Width, MonthCell.Height);
                        ZeroitMonthCalanderPaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.Radius, null);
                        var text = (startYear + (100 * ((selectedDate.Year - startYear) / 100))).ToString().PadLeft(4, '0') + "-\n" + (startYear + (100 * ((selectedDate.Year - startYear) / 100)) + 99).ToString().PadLeft(4, '0');
                        graphics.DrawString(text, Font, new SolidBrush(currentAppearance.SelectedDateTextColor), rangePosition.X, rangePosition.Y);
                    }
                    break;
            }
        }

        /// <summary>
        /// Draws the day.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="day">The day.</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        private void DrawDay(Graphics g, DateTime day, bool selected)
        {
            var dayIndex = GetCellIndex(day);
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 4, dayCellPosition.Y + 1, DaysCell.Width - 1, DaysCell.Height - 1);
            var br = selected ? currentAppearance.SelectedBackColor.GetBrush(rect) : currentAppearance.ButtonBackColor.GetBrush(rect);
            ZeroitMonthCalanderPaintUtility.DrawBackground(g, rect, br, currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.Radius, null);
            if (day.Day < 10)
            {
                dayCellPosition.X += 4;
            }
            g.DrawString(day.Day.ToString(), Font, new SolidBrush(((selected) ? currentAppearance.SelectedDateTextColor : currentAppearance.ActiveTextColor)), dayCellPosition.X, dayCellPosition.Y);
        }

        /// <summary>
        /// Draws the days.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawDays(Graphics g)
        {
            if ((selectedDate.Month != currentMonth) || (selectedDate.Year != currentYear))
            {
                CalculateDays();
                currentMonth = selectedDate.Month;
                currentYear = selectedDate.Year;
            }
            var daysGrid = DaysGrid;
            for (var i = 0; i < NumRows; i++)
            {
                for (var j = 0; j < NumCols; j++)
                {
                    var time = days[(i * 7) + j];
                    var num = (time.Day < 10) ? 4 : 0;
                    g.DrawString(time.Day.ToString(), Font, new SolidBrush((time.Month == currentMonth) ? currentAppearance.ActiveTextColor : currentAppearance.InactiveTextColor), daysGrid.X + num, daysGrid.Y);
                    daysGrid.X += DaysCell.Width;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += DaysCell.Height + 1;
            }
        }

        /// <summary>
        /// Draws the months.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawMonths(Graphics g)
        {
            var daysGrid = DaysGrid;
            var s = "1/1/2001";
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var text = DateTime.Parse(s).ToString("MMM");
                    s = DateTime.Parse(s).AddMonths(1).ToString();
                    g.DrawString(text, Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y + MonthCell.Height / 2 - Font.Height / 2);
                    daysGrid.X += MonthCell.Width;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        /// <summary>
        /// Draws the years.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawYears(Graphics g)
        {
            var daysGrid = DaysGrid;
            var startYear = 10 * (selectedDate.Year / 10);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    g.DrawString(startYear.ToString().PadLeft(4, '0'), Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y + MonthCell.Height / 2 - Font.Height / 2);
                    daysGrid.X += MonthCell.Width;
                    startYear++;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        /// <summary>
        /// Draws the year range.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawYearRange(Graphics g)
        {
            var daysGrid = DaysGrid;
            var startYear = 100 * (selectedDate.Year / 100);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    g.DrawString(startYear.ToString().PadLeft(4, '0') + "-\n" + (startYear + 99).ToString().PadLeft(4, '0'), Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y);
                    daysGrid.X += MonthCell.Width;
                    startYear += 100;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        /// <summary>
        /// Draws the days of week.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawDaysOfWeek(Graphics g)
        {
            var point = new Point(DaysGrid.X + 3, CaptionHeight);
            const string s = "SMTWTFS";
            foreach (var ch in s)
            {
                g.DrawString(ch.ToString(), captionFont, new SolidBrush(currentAppearance.DayMarker), point.X, point.Y);
                point.X += DaysCell.Width;
            }
            MarkerRectangle = new Rectangle(DaysGrid.X + 3, CaptionHeight, 7 * DaysCell.Width, CaptionHeight / 2);
            g.DrawLine(new Pen(currentAppearance.DateDaySaperatorColor), DaysGrid.X, DaysGrid.Y - 1, Width - DaysGrid.X, DaysGrid.Y - 1);
        }

        /// <summary>
        /// Draws the hover selection.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="index">The index.</param>
        /// <param name="drawOrErase">if set to <c>true</c> [draw or erase].</param>
        private void DrawHoverSelection(Graphics g, int index, bool drawOrErase)
        {
            if (!hotAppearance)
                return;
            if ((index < 0) || (index >= 12))
                return;
            var rangeCellPosition = GetCellAtIndex(index);
            var rect = new Rectangle(rangeCellPosition.X - 5, rangeCellPosition.Y, MonthCell.Width, MonthCell.Height);
            var br = new SolidBrush(drawOrErase ? currentAppearance.HoverColor : currentAppearance.ControlBackColor);
            ZeroitMonthCalanderPaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }

        /// <summary>
        /// Draws the hover selection.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="date">The date.</param>
        /// <param name="drawOrErase">if set to <c>true</c> [draw or erase].</param>
        private void DrawHoverSelection(Graphics g, DateTime date, bool drawOrErase)
        {
            if (!hotAppearance)
                return;
            var dayIndex = GetCellIndex(date);
            if ((dayIndex < 0) || (dayIndex >= days.Length))
                return;
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 5, dayCellPosition.Y, DaysCell.Width, DaysCell.Height);
            var br = new SolidBrush(drawOrErase ? currentAppearance.HoverColor : currentAppearance.ControlBackColor);
            ZeroitMonthCalanderPaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }

        /// <summary>
        /// Draws the today selection.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawTodaySelection(Graphics g)
        {
            if (displayType != DisplayType.Dates)
                return;
            var dayIndex = GetCellIndex(DateTime.Now);
            if (((dayIndex < 0) || (dayIndex >= days.Length)) || (DateTime.Now.Month != selectedDate.Month))
                return;
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 5, dayCellPosition.Y, DaysCell.Width, DaysCell.Height);
            var br = new SolidBrush(currentAppearance.TodayBorderColor);
            ZeroitMonthCalanderPaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.ZeroitMonthCalanderCornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }
    }
    #endregion

    #region Public Properties
    partial class ZeroitMonthCalander
    {
        /// <summary>
        /// Gets or sets the selected date.
        /// </summary>
        /// <value>The selected date.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (value != selectedDate)
                {
                    UpdateSelected(value);
                }
                /// <summary>
                /// Class ZeroitMonthCalander.
                /// </summary>
                /// <seealso cref="System.Windows.Forms.Control" />
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [hot appearance].
        /// </summary>
        /// <value><c>true</c> if [hot appearance]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool HotAppearance
        {
            get { return hotAppearance; }
            set
            {
                if (hotAppearance != value)
                {
                    hotAppearance = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets the back ground image alpha.
        /// </summary>
        /// <value>The back ground image alpha.</value>
        [Editor(typeof(ZeroitMonthCalanderRangeEditor), typeof(UITypeEditor))]
        [MinMax(0, 100)]
        [Category("Appearance")]
        [DefaultValue(90)]
        public int BackGroundImageAlpha
        {
            get { return backGroundImageAlpha; }
            set
            {
                if (backGroundImageAlpha != value)
                {
                    backGroundImageAlpha = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [draw focused].
        /// </summary>
        /// <value><c>true</c> if [draw focused]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool DrawFocused
        {
            get { return drawFocused; }
            set
            {
                if (drawFocused != value)
                {
                    drawFocused = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets the zeroit month calander theme property.
        /// </summary>
        /// <value>The zeroit month calander theme property.</value>
        [Category("Appearance")]
        [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderThemeProperty>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZeroitMonthCalanderThemeProperty ZeroitMonthCalanderThemeProperty
        {
            get { return themeProperty; }
        }
        /// <summary>
        /// Gets the current appearance.
        /// </summary>
        /// <value>The current appearance.</value>
        [Category("Appearance")]
        [TypeConverter(typeof(ReadOnlyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZeroitMonthCalanderAppearance CurrentAppearance
        {
            get { return currentAppearance; }
        }
        /// <summary>
        /// Gets the appearance.
        /// </summary>
        /// <value>The appearance.</value>
        [Category("Appearance")]
        [Editor(typeof(ZeroitMonthCalanderAppearanceEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ZeroitMonthCalanderGenericConverter<ZeroitMonthCalanderAppearance>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZeroitMonthCalanderAppearance Appearance
        {
            get { return appearance; }
        }
        /// <summary>
        /// Gets or sets the caption font.
        /// </summary>
        /// <value>The caption font.</value>
        [DefaultValue("Arial")]
        [Category("Appearance")]
        [TypeConverter(typeof(ZeroitMonthCalanderFontConverter)), Editor(typeof(ZeroitMonthCalanderFontEditor), typeof(UITypeEditor))]
        public string CaptionFont
        {
            get { return captionFont.FontFamily.Name; }
            set
            {
                if (captionFont.FontFamily.Name != value)
                {
                    captionFont = new Font(value, 9f, FontStyle.Bold);
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets the number font.
        /// </summary>
        /// <value>The number font.</value>
        [Category("Appearance")]
        [DefaultValue("Arial")]
        [TypeConverter(typeof(ZeroitMonthCalanderFontConverter)), Editor(typeof(ZeroitMonthCalanderFontEditor), typeof(UITypeEditor))]
        public string NumberFont
        {
            get { return base.Font.FontFamily.Name; }
            set
            {
                if (base.Font.FontFamily.Name != value)
                {
                    base.Font = new Font(value, 9f, FontStyle.Regular);
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }
        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <value>The margin.</value>
        [Browsable(false)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }
        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The maximum size.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MaximumSize
        {
            get { return new Size(164, 152); }
            set { base.MaximumSize = new Size(164, 152); }
        }
        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The minimum size.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MinimumSize
        {
            get { return new Size(164, 152); }
            set { base.MinimumSize = value; }
        }
    }
    #endregion

    #region Control
    /// <summary>
    /// A class collection for rendering a monthly calender
    /// </summary>
    [Designer(typeof(ZeroitMonthCalanderDesigner))]
    public partial class ZeroitMonthCalander : Control
    {
        #region Constants

        private const int BottomLabelHeight = 12;
        /// <summary>
        /// The caption height
        /// </summary>
        private const int CaptionHeight = 28;
        /// <summary>
        /// The control width
        /// </summary>
        private const int ControlWidth = 164;
        /// <summary>
        /// The number cols
        /// </summary>
        private const int NumCols = 7;
        /// <summary>
        /// The number rows
        /// </summary>
        private const int NumRows = 6;

        #endregion

        #region Field Declaration

        /// <summary>
        /// The arrow button offset
        /// </summary>
        private static Size ArrowButtonOffset = new Size(6, 6);
        /// <summary>
        /// The arrow button size
        /// </summary>
        private static Size ArrowButtonSize = new Size(20, 15);
        /// <summary>
        /// The arrow points offset
        /// </summary>
        private static Size ArrowPointsOffset = new Size(13, 9);
        /// <summary>
        /// The arrow points size
        /// </summary>
        private static Size ArrowPointsSize = new Size(5, 10);
        /// <summary>
        /// The bottom labels position
        /// </summary>
        private static Point BottomLabelsPos = new Point(6, 135);
        /// <summary>
        /// The days cell
        /// </summary>
        private static Size DaysCell = new Size(23, 14);
        /// <summary>
        /// The days grid
        /// </summary>
        private static Point DaysGrid = new Point(6, 43);
        /// <summary>
        /// The marker rectangle
        /// </summary>
        private static Rectangle MarkerRectangle = Rectangle.Empty;
        /// <summary>
        /// The month cell
        /// </summary>
        private static Size MonthCell = new Size(40, 28);
        /// <summary>
        /// The appearance
        /// </summary>
        private readonly ZeroitMonthCalanderAppearance appearance;
        /// <summary>
        /// The current appearance
        /// </summary>
        private readonly ZeroitMonthCalanderAppearance currentAppearance = new ZeroitMonthCalanderAppearance();
        /// <summary>
        /// The days
        /// </summary>
        private readonly DateTime[] days = new DateTime[42];
        /// <summary>
        /// The left arrow
        /// </summary>
        private readonly Point[] leftArrow = new Point[3];
        /// <summary>
        /// The theme property
        /// </summary>
        private readonly ZeroitMonthCalanderThemeProperty themeProperty;
        /// <summary>
        /// The back ground image alpha
        /// </summary>
        private int backGroundImageAlpha = 90;
        /// <summary>
        /// The BMP
        /// </summary>
        private Bitmap bmp;
        /// <summary>
        /// The caption font
        /// </summary>
        private Font captionFont;
        /// <summary>
        /// The CTM months
        /// </summary>
        private ContextMenu ctmMonths;
        /// <summary>
        /// The current month
        /// </summary>
        private int currentMonth = -1;
        /// <summary>
        /// The current year
        /// </summary>
        private int currentYear = -1;
        /// <summary>
        /// The display type
        /// </summary>
        private DisplayType displayType = DisplayType.Dates;
        /// <summary>
        /// The draw focused
        /// </summary>
        private bool drawFocused = true;
        /// <summary>
        /// The first date
        /// </summary>
        private DateTime firstDate;
        /// <summary>
        /// The graphics
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// The hot appearance
        /// </summary>
        private bool hotAppearance = true;
        /// <summary>
        /// The hover date
        /// </summary>
        private DateTime hoverDate = DateTime.Now;
        /// <summary>
        /// The last index
        /// </summary>
        private int lastIndex;
        /// <summary>
        /// The left rectangle
        /// </summary>
        private Rectangle leftRectangle = Rectangle.Empty;
        /// <summary>
        /// The month rectangle
        /// </summary>
        private Rectangle monthRectangle = Rectangle.Empty;
        /// <summary>
        /// The right arrow
        /// </summary>
        private Point[] rightArrow = new Point[3];
        /// <summary>
        /// The right rectangle
        /// </summary>
        private Rectangle rightRectangle = Rectangle.Empty;
        /// <summary>
        /// The selected date
        /// </summary>
        private DateTime selectedDate = DateTime.Now;
        /// <summary>
        /// The year rectangle
        /// </summary>
        private Rectangle yearRectangle = Rectangle.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMonthCalander"/> class.
        /// </summary>
        public ZeroitMonthCalander()
        {
            InitMonthContextMenu();
            Location = new Point(0, 0);
            selectedDate = DateTime.Now;
            Size = new Size(ControlWidth, (BottomLabelsPos.Y + BottomLabelHeight) + 5);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, true);
            themeProperty = new ZeroitMonthCalanderThemeProperty();
            appearance = new ZeroitMonthCalanderAppearance();
            appearance.AppearanceChanged += OnAppearanceChanged;
            themeProperty.ThemeChanged += OnAppearanceChanged;
            CreateMemoryBitmap();
            SetDefaults();
            SetThemeDefaults();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ZeroitMonthCalanderGenericEventHandler<DateTime> ValueChanged;

        /// <summary>
        /// Occurs when [value changing].
        /// </summary>
        public event ZeroitMonthCalanderGenericValueChangingHandler<DateTime> ValueChanging;

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Called when [value changing].
        /// </summary>
        /// <param name="e">The e.</param>
        protected virtual void OnValueChanging(ZeroitMonthCalanderGenericChangeEventArgs<DateTime> e)
        {
            if (ValueChanging != null)
            {
                ValueChanging(this, e);
            }
        }

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new ZeroitMonthCalanderGenericEventArgs<DateTime>(SelectedDate));
            }
        }

        #endregion

        #region Nested Class

        /// <summary>
        /// Enum DisplayType
        /// </summary>
        private enum DisplayType
        {
            /// <summary>
            /// The dates
            /// </summary>
            Dates,
            /// <summary>
            /// The monthes
            /// </summary>
            Monthes,
            /// <summary>
            /// The years
            /// </summary>
            Years,
            /// <summary>
            /// The years range
            /// </summary>
            YearsRange,
        }

        #endregion
    }
    #endregion

    
    #endregion

    #endregion

    #endregion
}
