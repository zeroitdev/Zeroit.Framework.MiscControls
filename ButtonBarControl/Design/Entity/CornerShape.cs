// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="CornerShape.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// Class responsible to store information corner style of a <see cref="ZeroitToxicButton" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    [TypeConverter(typeof (GenericConverter<CornerShape>))]
    public class CornerShape : ICloneable, IXmlSerializable
    {
        /// <summary>
        /// The bottom left
        /// </summary>
        private CornerType bottomLeft;
        /// <summary>
        /// The bottom right
        /// </summary>
        private CornerType bottomRight;
        /// <summary>
        /// The top left
        /// </summary>
        private CornerType topLeft;
        /// <summary>
        /// The top right
        /// </summary>
        private CornerType topRight;

        /// <summary>
        /// Initializes a new instance of <see cref="CornerShape" />
        /// </summary>
        public CornerShape()
        {
            topLeft = CornerType.Round;
            topRight = CornerType.Round;
            bottomLeft = CornerType.Round;
            bottomRight = CornerType.Round;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CornerShape" />
        /// </summary>
        /// <param name="type"><see cref="CornerType" /> for all corners.</param>
        public CornerShape(CornerType type)
        {
            topLeft = type;
            topRight = type;
            bottomLeft = type;
            bottomRight = type;
        }

        /// <summary>
        /// Gets or Sets <see cref="CornerType" /> for bottom left corner.
        /// </summary>
        /// <value>The bottom left.</value>
        public CornerType BottomLeft
        {
            get { return bottomLeft; }
            set
            {
                if (bottomLeft != value)
                {
                    bottomLeft = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets or Sets <see cref="CornerType" /> for bottom right corner.
        /// </summary>
        /// <value>The bottom right.</value>
        public CornerType BottomRight
        {
            get { return bottomRight; }
            set
            {
                if (bottomRight != value)
                {
                    bottomRight = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets wether all corner are squared or not
        /// </summary>
        /// <value><c>true</c> if this instance is all squared; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsAllSquared
        {
            get
            {
                return ((((topLeft == CornerType.Square) && (topRight == CornerType.Square)) &&
                         (bottomLeft == CornerType.Square)) && (bottomRight == CornerType.Square));
            }
        }

        /// <summary>
        /// Gets or Sets <see cref="CornerType" /> for top left corner.
        /// </summary>
        /// <value>The top left.</value>
        public CornerType TopLeft
        {
            get { return topLeft; }
            set
            {
                if (topLeft != value)
                {
                    topLeft = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        /// <summary>
        /// Gets or Sets <see cref="CornerType" /> for top right corner.
        /// </summary>
        /// <value>The top right.</value>
        public CornerType TopRight
        {
            get { return topRight; }
            set
            {
                if (topRight != value)
                {
                    topRight = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
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
                return !ShouldSerializeBottomLeft() && !ShouldSerializeBottomRight() && !ShouldSerializeTopLeft() &&
                       !ShouldSerializeTopRight();
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public virtual object Clone()
        {
            var shape = new CornerShape();
            shape.TopLeft = topLeft;
            shape.TopRight = topRight;
            shape.BottomLeft = bottomLeft;
            shape.BottomRight = bottomRight;
            return shape;
        }

        #endregion

        #region Should serialize implementation

        /// <summary>
        /// Indicates wether designer needs to serialize <see cref="BottomLeft" /> property.
        /// </summary>
        /// <returns>Returns true if <see cref="BottomLeft" /> property needs to be serialized.</returns>
        protected virtual bool ShouldSerializeBottomLeft()
        {
            return bottomLeft != CornerType.Round;
        }

        /// <summary>
        /// Indicates wether designer needs to serialize <see cref="BottomRight" /> property.
        /// </summary>
        /// <returns>Returns true if <see cref="BottomRight" /> property needs to be serialized.</returns>
        protected virtual bool ShouldSerializeBottomRight()
        {
            return bottomRight != CornerType.Round;
        }

        /// <summary>
        /// Indicates wether designer needs to serialize <see cref="TopLeft" /> property.
        /// </summary>
        /// <returns>Returns true if <see cref="TopLeft" /> property needs to be serialized.</returns>
        protected virtual bool ShouldSerializeTopLeft()
        {
            return topLeft != CornerType.Round;
        }

        /// <summary>
        /// Indicates wether designer needs to serialize <see cref="TopRight" /> property.
        /// </summary>
        /// <returns>Returns true if <see cref="TopRight" /> property needs to be serialized.</returns>
        protected virtual bool ShouldSerializeTopRight()
        {
            return topRight != CornerType.Round;
        }

        #endregion

        #region Reset implementation

        /// <summary>
        /// Resets value of <see cref="BottomLeft" /> to default value.
        /// </summary>
        protected virtual void ResetBottomLeft()
        {
            bottomLeft = CornerType.Round;
        }

        /// <summary>
        /// Resets value of <see cref="BottomRight" /> to default value.
        /// </summary>
        protected virtual void ResetBottomRight()
        {
            bottomRight = CornerType.Round;
        }

        /// <summary>
        /// Resets value of <see cref="TopLeft" /> to default value.
        /// </summary>
        protected virtual void ResetTopLeft()
        {
            topLeft = CornerType.Round;
        }

        /// <summary>
        /// Resets value of <see cref="TopRight" /> to default value.
        /// </summary>
        protected virtual void ResetTopRight()
        {
            topRight = CornerType.Round;
        }

        #endregion

        /// <summary>
        /// Occurs when <see cref="CornerType" /> of any corner changes.
        /// </summary>
        public event GenericEventHandler<AppearanceAction> BorderCornerChanged;

        /// <summary>
        /// Get wether default values of the object has been modified.
        /// </summary>
        /// <returns>Returns true if default values has been modified for current object.</returns>
        public virtual bool DefaultChanged()
        {
            return ((topLeft != CornerType.Round) ||
                    ((topRight != CornerType.Round) ||
                     ((bottomLeft != CornerType.Round) || (bottomRight != CornerType.Round))));
        }

        /// <summary>
        /// Fires <see cref="BorderCornerChanged" /> event.
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnBorderCornerChanged(GenericEventArgs<AppearanceAction> e)
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
            var shape = obj as CornerShape;
            if (shape != null)
            {
                return shape.bottomLeft == bottomLeft && shape.bottomRight == bottomRight && shape.topLeft == topLeft &&
                       shape.topRight == topRight;
            }
            return false;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Assigns Values of supplied <see cref="CornerShape" /> to current object.
        /// </summary>
        /// <param name="shape"><see cref="CornerShape" /> object whose value is to be assigned.</param>
        public void Assign(CornerShape shape)
        {
            TopLeft = shape.topLeft;
            TopRight = shape.topRight;
            BottomLeft = shape.bottomLeft;
            BottomRight = shape.bottomRight;
        }

        /// <summary>
        /// Resets all the property to default value of current <see cref="CornerShape" /> instance.
        /// </summary>
        public void Reset()
        {
            ResetBottomLeft();
            ResetBottomRight();
            ResetTopLeft();
            ResetTopRight();
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
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("BottomLeft")[0].InnerText);
            if (doc.GetElementsByTagName("BottomRight").Count > 0)
                BottomRight =
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("BottomRight")[0].InnerText);
            if (doc.GetElementsByTagName("TopLeft").Count > 0)
                TopLeft = (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("TopLeft")[0].InnerText);
            if (doc.GetElementsByTagName("TopRight").Count > 0)
                TopRight =
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("TopRight")[0].InnerText);
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
}