// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="ColorPair.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents two color pair with gradient angle.
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Editor(typeof (ColorPairEditor), typeof (UITypeEditor))]
    [TypeConverter(typeof (GenericConverter<ColorPair>))]
    public class ColorPair : ICloneable, IXmlSerializable
    {
        #region Fields

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
        /// Initializes a new instance of the <see cref="ColorPair" /> class.
        /// </summary>
        public ColorPair()
        {
            backColor1 = Color.Empty;
            backColor2 = Color.Empty;
            gradient = 90;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPair" /> class.
        /// </summary>
        /// <param name="backColor1">Start color.</param>
        /// <param name="backColor2">End color</param>
        /// <param name="gradient">Gradient of the brush.</param>
        public ColorPair(Color backColor1, Color backColor2, int gradient)
        {
            this.backColor1 = backColor1;
            this.backColor2 = backColor2;
            this.gradient = gradient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPair" /> class.
        /// </summary>
        /// <param name="backColor1">Start Color.</param>
        /// <param name="backColor2">End Color</param>
        public ColorPair(Color backColor1, Color backColor2)
        {
            this.backColor1 = backColor1;
            this.backColor2 = backColor2;
            gradient = 90;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPair" /> class.
        /// </summary>
        /// <param name="color">Color to be used for initialization it will be set as both <see cref="BackColor1" /> and <see cref="BackColor2" />. <see cref="Gradient" /> will be set as 0</param>
        public ColorPair(Color color)
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
            var pair = obj as ColorPair;
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
                if (backColor1.Equals(value)) return;
                backColor1 = value;
                OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
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
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        /// <summary>
        /// Gets or sets Gradient.
        /// </summary>
        /// <value>The gradient.</value>
        [Editor(typeof (GradientAngleEditor), typeof (UITypeEditor))]
        public int Gradient
        {
            get { return gradient; }
            set
            {
                if (!gradient.Equals(value))
                {
                    gradient = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        #endregion

        /// <summary>
        /// Indicates current object is Empty or not.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get { return BackColor1.IsEmpty && BackColor2.IsEmpty && Gradient == 90; }
        }

        /// <summary>
        /// Compares two <see cref="ColorPair" /> objects
        /// </summary>
        /// <param name="p1">First <see cref="ColorPair" /> to compare</param>
        /// <param name="p2">First <see cref="ColorPair" /> to compare</param>
        /// <returns>Returns true if both have same property values.</returns>
        public static bool operator ==(ColorPair p1, ColorPair p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            return p1.Equals(p2);
        }

        /// <summary>
        /// Compares two <see cref="ColorPair" /> objects
        /// </summary>
        /// <param name="p1">First <see cref="ColorPair" /> to compare</param>
        /// <param name="p2">First <see cref="ColorPair" /> to compare</param>
        /// <returns>Returns true if both have different property values.</returns>
        public static bool operator !=(ColorPair p1, ColorPair p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Occurs when properties related to drawing has been modified.
        /// </summary>
        public event GenericEventHandler<AppearanceAction> AppearanceChanged;

        /// <summary>
        /// Fiers <see cref="AppearanceChanged" /> event.
        /// </summary>
        /// <param name="e">Object containing Event data.</param>
        protected virtual void OnAppearanceChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        /// <summary>
        /// Gets <see cref="LinearGradientBrush" /> brush for specified rectangle using this object.
        /// </summary>
        /// <param name="rect">Rectangle for which brush is required.</param>
        /// <returns>A<see cref="LinearGradientBrush" /> for supplied rectangle.</returns>
        public Brush GetBrush(Rectangle rect)
        {
            return new LinearGradientBrush(rect, BackColor1, BackColor2, gradient);
        }

        /// <summary>
        /// Assigns Values of supplied <see cref="ColorPair" /> to current object.
        /// </summary>
        /// <param name="color"><see cref="ColorPair" /> object whose value is to be assigned.</param>
        public void Assign(ColorPair color)
        {
            backColor1 = color.backColor1;
            backColor2 = color.backColor2;
            gradient = color.gradient;
        }

        /// <summary>
        /// Gets <see cref="LinearGradientBrush" /> brush for specified rectangle using this object.
        /// </summary>
        /// <param name="rect">Rectangle for which brush is required.</param>
        /// <returns>A<see cref="LinearGradientBrush" /> for supplied rectangle.</returns>
        public Brush GetBrush(RectangleF rect)
        {
            return new LinearGradientBrush(rect, BackColor1, BackColor2, gradient);
        }

        /// <summary>
        /// Indicates wether Default Values of this object has been changed or not.
        /// </summary>
        /// <returns>Returns true if Default values has been changed.</returns>
        public bool DefaultChanged()
        {
            return ShouldSerializeBackColor1() || ShouldSerializeBackColor2() || ShouldSerializeGradient();
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
                BackColor1 = PaintUtility.GetColor(doc.GetElementsByTagName("BackColor1")[0].InnerText);
            if (doc.GetElementsByTagName("BackColor2").Count > 0)
                BackColor2 = PaintUtility.GetColor(doc.GetElementsByTagName("BackColor2")[0].InnerText);
            if (doc.GetElementsByTagName("Gradient").Count > 0)
                Gradient = Convert.ToInt32(doc.GetElementsByTagName("Gradient")[0].InnerText);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BackColor1", PaintUtility.GetString(BackColor1));
            writer.WriteElementString("BackColor2", PaintUtility.GetString(BackColor2));
            writer.WriteElementString("Gradient", Gradient.ToString());
        }



        #endregion

        #region IClonable member

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var pair = new ColorPair {backColor1 = backColor1, backColor2 = backColor2, gradient = gradient};
            return pair;
        }

        #endregion

        #region Reset methods used by IDE

        /// <summary>
        /// Resets <see cref="BackColor1" /> to default value.
        /// </summary>
        protected void ResetBackColor1()
        {
            backColor1 = Color.Empty;
        }

        /// <summary>
        /// Resets <see cref="BackColor2" /> to default value.
        /// </summary>
        protected void ResetBackColor2()
        {
            backColor2 = Color.Empty;
        }

        /// <summary>
        /// Resets <see cref="Gradient" /> to default value.
        /// </summary>
        protected void ResetGradient()
        {
            gradient = 90;
        }

        /// <summary>
        /// Resets Property to default value.
        /// </summary>
        public void Reset()
        {
            ResetBackColor1();
            ResetBackColor2();
            ResetGradient();
        }

        #endregion

        #region Should Serialize methods used by IDE

        /// <summary>
        /// Indicates wether <see cref="BackColor1" /> needs to be serialized.
        /// </summary>
        /// <returns>Returns true if <see cref="BackColor1" /> needs to be serialized.</returns>
        protected bool ShouldSerializeBackColor1()
        {
            return !backColor1.IsEmpty;
        }

        /// <summary>
        /// Indicates wether <see cref="BackColor2" /> needs to be serialized.
        /// </summary>
        /// <returns>Returns true if <see cref="BackColor2" /> needs to be serialized.</returns>
        protected bool ShouldSerializeBackColor2()
        {
            return !backColor2.IsEmpty;
        }

        /// <summary>
        /// Indicates wether <see cref="Gradient" /> needs to be serialized.
        /// </summary>
        /// <returns>Returns true if <see cref="Gradient" /> needs to be serialized.</returns>
        protected bool ShouldSerializeGradient()
        {
            return gradient != 90;
        }

        #endregion

        #region Nested class

        #region Nested type: ColorPairEditor

        /// <summary>
        /// UITypeEditor for <see cref="ColorPair" /> type.
        /// </summary>
        /// <seealso cref="System.Drawing.Design.UITypeEditor" />
        internal class ColorPairEditor : UITypeEditor
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
                    var edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
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
                return UITypeEditorEditStyle.Modal;
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
                var pair = e.Value as ColorPair;
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
            private GradientAngleEditor.GradientEditorUI gradUI;
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
            private ColorPair value;

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
            public ColorPair Value
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
                gradUI = new GradientAngleEditor.GradientEditorUI();
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
                value = val as ColorPair;
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
}