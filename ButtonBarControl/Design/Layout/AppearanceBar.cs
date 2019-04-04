// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="AppearanceBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class responsible to store appearance information of a <see cref="ZeroitToxicButton" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [TypeConverter(typeof (GenericConverter<AppearanceBar>))]
    public class AppearanceBar : ICloneable, IXmlSerializable
    {
        #region Private Fields

        /// <summary>
        /// The back style
        /// </summary>
        private readonly ColorPair backStyle;
        /// <summary>
        /// The appearance border
        /// </summary>
        private AppearanceBorder appearanceBorder;
        /// <summary>
        /// The corner radius
        /// </summary>
        private int cornerRadius;
        /// <summary>
        /// The disabled mask
        /// </summary>
        private Color disabledMask;
        /// <summary>
        /// The focused border
        /// </summary>
        private Color focusedBorder;
        /// <summary>
        /// The normal border
        /// </summary>
        private Color normalBorder;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize new default instance.
        /// </summary>
        public AppearanceBar()
        {
            backStyle = new ColorPair();
            backStyle.AppearanceChanged += OnAppearanceChanged;
            appearanceBorder = new AppearanceBorder();
            appearanceBorder.AppearanceChanged += OnAppearanceChanged;
            Reset();
        }

        #endregion

        #region Public Property

        /// <summary>
        /// Gets background style of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The back style.</value>
        [Editor(typeof (ColorPair.ColorPairEditor), typeof (UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorPair BackStyle
        {
            get { return backStyle; }
        }

        /// <summary>
        /// Gets or Sets Normal border color of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The normal border.</value>
        public Color NormalBorder
        {
            get { return normalBorder; }
            set
            {
                if (normalBorder == value)
                    return;
                normalBorder = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// Gets or Sets disabled mask color of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The disabled mask.</value>
        public Color DisabledMask
        {
            get { return disabledMask; }
            set
            {
                if (disabledMask == value)
                    return;
                disabledMask = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// Gets or Sets focused border color of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The focused border.</value>
        public Color FocusedBorder
        {
            get { return focusedBorder; }
            set
            {
                if (focusedBorder == value)
                    return;
                focusedBorder = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// Gets border appearance of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The appearance border.</value>
        public AppearanceBorder AppearanceBorder
        {
            get { return appearanceBorder; }
            set
            {
                if (appearanceBorder == value)
                    return;
                appearanceBorder = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// Gets corner radius of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The corner radius.</value>
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                if (cornerRadius == value)
                    return;
                cornerRadius = value;
                OnAppearanceChanged();
            }
        }

        /// <summary>
        /// Indicates current object is Empty or not.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return backStyle.IsEmpty && appearanceBorder.IsEmpty && cornerRadius == 0 && focusedBorder.IsEmpty &&
                       normalBorder.IsEmpty && disabledMask.IsEmpty;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when properties related to drawing has been modified.
        /// </summary>
        public event GenericEventHandler<AppearanceAction> AppearanceChanged;

        #endregion

        /// <summary>
        /// Fires <see cref="AppearanceChanged" /> event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="tArgs">Object having event information.</param>
        protected virtual void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, tArgs);
            }
        }

        /// <summary>
        /// Fires <see cref="AppearanceChanged" /> event.
        /// </summary>
        protected virtual void OnAppearanceChanged()
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
            }
        }

        /// <summary>
        /// Get wether default values of the object has been modified.
        /// </summary>
        /// <returns>Returns true if default values has been modified for current object.</returns>
        public virtual bool DefaultChanged()
        {
            return ShouldSerializeBackStyle() || ShouldSerializeAppearanceBorder() || ShouldSerializeCornerRadius() ||
                   ShouldSerializeFocusedBorder() || ShouldSerializeNormalBorder() || ShouldSerializeDisabledMask();
        }

        #region Should Serialize and Reset Implementation

        /// <summary>
        /// Resets all properties to default value.
        /// </summary>
        public void Reset()
        {
            ResetBackStyle();
            ResetAppearanceBorder();
            ResetCornerRadius();
            ResetFocusedBorder();
            ResetNormalBorder();
            ResetDisabledMask();
        }

        /// <summary>
        /// Assigns Values of supplied <see cref="AppearanceBar" /> to current object.
        /// </summary>
        /// <param name="app"><see cref="AppearanceBar" /> object whose value is to be assigned.</param>
        public void Assign(AppearanceBar app)
        {
            backStyle.Assign(app.BackStyle);
            focusedBorder = app.FocusedBorder;
            normalBorder = app.NormalBorder;
            appearanceBorder.Assign(app.AppearanceBorder);
            cornerRadius = app.cornerRadius;
            disabledMask = app.disabledMask;
        }

        /// <summary>
        /// Resets <see cref="BackStyle" /> to default value.
        /// </summary>
        protected virtual void ResetBackStyle()
        {
            backStyle.Reset();
        }

        /// <summary>
        /// Resets <see cref="NormalBorder" /> to default value.
        /// </summary>
        protected virtual void ResetNormalBorder()
        {
            normalBorder = Color.Empty;
        }

        /// <summary>
        /// Resets <see cref="DisabledMask" /> to default value.
        /// </summary>
        protected virtual void ResetDisabledMask()
        {
            disabledMask = Color.Empty;
        }

        /// <summary>
        /// Resets <see cref="FocusedBorder" /> to default value.
        /// </summary>
        protected virtual void ResetFocusedBorder()
        {
            focusedBorder = Color.Empty;
        }

        /// <summary>
        /// Resets <see cref="AppearanceBorder" /> to default value.
        /// </summary>
        protected internal virtual void ResetAppearanceBorder()
        {
            appearanceBorder.Reset();
        }

        /// <summary>
        /// Resets <see cref="CornerRadius" /> to default value.
        /// </summary>
        protected internal virtual void ResetCornerRadius()
        {
            cornerRadius = 0;
        }

        /// <summary>
        /// Indicates wether <see cref="BackStyle" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeBackStyle()
        {
            return backStyle.DefaultChanged();
        }

        /// <summary>
        /// Indicates wether <see cref="NormalBorder" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeNormalBorder()
        {
            return normalBorder != Color.Empty;
        }

        /// <summary>
        /// Indicates wether <see cref="DisabledMask" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeDisabledMask()
        {
            return disabledMask != Color.Empty;
        }

        /// <summary>
        /// Indicates wether <see cref="FocusedBorder" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeFocusedBorder()
        {
            return focusedBorder != Color.Empty;
        }

        /// <summary>
        /// Indicates wether <see cref="AppearanceBorder" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeAppearanceBorder()
        {
            return appearanceBorder.DefaultChanged();
        }

        /// <summary>
        /// Indicates wether <see cref="CornerRadius" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected virtual bool ShouldSerializeCornerRadius()
        {
            return cornerRadius != 0;
        }

        #endregion

        #region Implementation of ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var app = new AppearanceBar();
            app.BackStyle.Assign((ColorPair) BackStyle.Clone());
            app.AppearanceBorder.Assign((AppearanceBorder) AppearanceBorder.Clone());
            app.CornerRadius = CornerRadius;
            app.DisabledMask = DisabledMask;
            app.FocusedBorder = FocusedBorder;
            app.NormalBorder = NormalBorder;
            return app;
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

            if (doc.GetElementsByTagName("BackStyle").Count > 0)
            {
                var xml = "<ColorPair>" + doc.GetElementsByTagName("BackStyle")[0].InnerXml + "</ColorPair>";
                BackStyle.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("NormalBorder").Count > 0)
                NormalBorder = PaintUtility.GetColor(doc.GetElementsByTagName("NormalBorder")[0].InnerText);

            if (doc.GetElementsByTagName("DisabledMask").Count > 0)
                DisabledMask = PaintUtility.GetColor(doc.GetElementsByTagName("DisabledMask")[0].InnerText);

            if (doc.GetElementsByTagName("FocusedBorder").Count > 0)
                FocusedBorder = PaintUtility.GetColor(doc.GetElementsByTagName("FocusedBorder")[0].InnerText);

            if (doc.GetElementsByTagName("AppearanceBorder").Count > 0)
            {
                var xml = "<AppearanceBorder>" + doc.GetElementsByTagName("AppearanceBorder")[0].InnerXml +
                          "</AppearanceBorder>";
                AppearanceBorder.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }

            if (doc.GetElementsByTagName("CornerRadius").Count > 0)
                CornerRadius = Convert.ToInt32(doc.GetElementsByTagName("CornerRadius")[0].InnerText);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("BackStyle");
            BackStyle.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteElementString("NormalBorder", PaintUtility.GetString(NormalBorder));
            writer.WriteElementString("DisabledMask", PaintUtility.GetString(DisabledMask));
            writer.WriteElementString("FocusedBorder", PaintUtility.GetString(FocusedBorder));

            writer.WriteStartElement("AppearanceBorder");
            AppearanceBorder.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteElementString("CornerRadius", CornerRadius.ToString());
        }

        #endregion
    }
}