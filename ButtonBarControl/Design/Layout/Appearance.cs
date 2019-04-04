// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="Appearance.cs" company="Zeroit Dev Technologies">
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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class hollding appearance information of <see cref="ZeroitToxicButton" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]public class Appearance : ICloneable, IXmlSerializable
    {
        /// <summary>
        /// The bar
        /// </summary>
        private readonly AppearanceBar bar;
        /// <summary>
        /// The item
        /// </summary>
        private readonly AppearanceItem item;

        #region Events

        /// <summary>
        /// Occurs when properties related to drawing has been modified.
        /// </summary>
        public event GenericEventHandler<AppearanceAction> AppearanceChanged;

        #endregion

        /// <summary>
        /// Initializes new instance of <see cref="Appearance" />
        /// </summary>
        public Appearance()
        {
            bar = new AppearanceBar();
            bar.AppearanceChanged += OnAppearanceChanged;
            item = new AppearanceItem();
            item.AppearanceChanged += OnAppearanceChanged;
        }

        /// <summary>
        /// Gets appearance of <see cref="BarItem" />
        /// </summary>
        /// <value>The bar.</value>
        public AppearanceBar Bar
        {
            get { return bar; }
        }

        /// <summary>
        /// Gets appearance of <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The item.</value>
        public AppearanceItem Item
        {
            get { return item; }
        }

        /// <summary>
        /// Indicates Appearence is Empty or not.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get { return bar.IsEmpty && item.IsEmpty; }
        }

        #region Implementation of ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var app = new Appearance();
            app.Bar.Assign((AppearanceBar) bar.Clone());
            app.Item.Assign((AppearanceItem) item.Clone());
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

            if (doc.GetElementsByTagName("Bar").Count > 0)
            {
                var xml = "<AppearanceBar>" + doc.GetElementsByTagName("Bar")[0].InnerXml + "</AppearanceBar>";
                Bar.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }

            if (doc.GetElementsByTagName("Item").Count > 0)
            {
                var xml = "<AppearanceItem>" + doc.GetElementsByTagName("Item")[0].InnerXml + "</AppearanceItem>";
                Item.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Bar");
            Bar.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteStartElement("Item");
            Item.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion

        /// <summary>
        /// Fires <see cref="AppearanceChanged" /> event.
        /// </summary>
        /// <param name="sender">Sender of argument</param>
        /// <param name="tArgs">Object containing event data.</param>
        protected virtual void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, tArgs);
            }
        }

        /// <summary>
        /// Gets wether default property values has been changed or not.
        /// </summary>
        /// <returns>Returns true if properties are not changed.</returns>
        protected virtual bool DefaultChanged()
        {
            return bar.DefaultChanged() || item.DefaultChanged();
        }

        /// <summary>
        /// Resets properties ans its properties to default value.
        /// </summary>
        public void Reset()
        {
            Bar.Reset();
            Item.Reset();
        }

        /// <summary>
        /// Assigns Values of supplied <see cref="Appearance" /> to current object.
        /// </summary>
        /// <param name="appearance"><see cref="Appearance" /> object whose value is to be assigned.</param>
        public void Assign(Appearance appearance)
        {
            Bar.Assign(appearance.Bar);
            Item.Assign(appearance.Item);
        }
    }
}