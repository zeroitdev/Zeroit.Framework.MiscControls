// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="TypeDescriptor.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class FCTBDescriptionProvider.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeDescriptionProvider" />
    /// These classes are required for correct data binding to Text property of FastColoredTextbox
    class FCTBDescriptionProvider : TypeDescriptionProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FCTBDescriptionProvider"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public FCTBDescriptionProvider(Type type)
            : base(GetDefaultTypeProvider(type))
        {
        }

        /// <summary>
        /// Gets the default type provider.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>TypeDescriptionProvider.</returns>
        private static TypeDescriptionProvider GetDefaultTypeProvider(Type type)
        {
            return TypeDescriptor.GetProvider(type);
        }



        /// <summary>
        /// Gets a custom type descriptor for the given type and object.
        /// </summary>
        /// <param name="objectType">The type of object for which to retrieve the type descriptor.</param>
        /// <param name="instance">An instance of the type. Can be null if no instance was passed to the <see cref="T:System.ComponentModel.TypeDescriptor" />.</param>
        /// <returns>An <see cref="T:System.ComponentModel.ICustomTypeDescriptor" /> that can provide metadata for the type.</returns>
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor defaultDescriptor = base.GetTypeDescriptor(objectType, instance);
            return new FCTBTypeDescriptor(defaultDescriptor, instance);
        }
    }

    /// <summary>
    /// Class FCTBTypeDescriptor.
    /// </summary>
    /// <seealso cref="System.ComponentModel.CustomTypeDescriptor" />
    class FCTBTypeDescriptor : CustomTypeDescriptor
    {
        /// <summary>
        /// The parent
        /// </summary>
        ICustomTypeDescriptor parent;
        /// <summary>
        /// The instance
        /// </summary>
        object instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="FCTBTypeDescriptor"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="instance">The instance.</param>
        public FCTBTypeDescriptor(ICustomTypeDescriptor parent, object instance)
            : base(parent)
        {
            this.parent = parent;
            this.instance = instance;
        }

        /// <summary>
        /// Returns the name of the class represented by this type descriptor.
        /// </summary>
        /// <returns>A <see cref="T:System.String" /> containing the name of the component instance this type descriptor is describing. The default is null.</returns>
        public override string GetComponentName()
        {
            var ctrl = (instance as Control);
            return ctrl == null ? null : ctrl.Name;
        }

        /// <summary>
        /// Returns a collection of event descriptors for the object represented by this type descriptor.
        /// </summary>
        /// <returns>An <see cref="T:System.ComponentModel.EventDescriptorCollection" /> containing the event descriptors for the object represented by this type descriptor. The default is <see cref="F:System.ComponentModel.EventDescriptorCollection.Empty" />.</returns>
        public override EventDescriptorCollection GetEvents()
        {
            var coll = base.GetEvents();
            var list = new EventDescriptor[coll.Count];

            for (int i = 0; i < coll.Count; i++)
                if (coll[i].Name == "TextChanged")//instead of TextChanged slip BindingTextChanged for binding
                    list[i] = new FooTextChangedDescriptor(coll[i]);
                else
                    list[i] = coll[i];

            return new EventDescriptorCollection(list);
        }
    }

    /// <summary>
    /// Class FooTextChangedDescriptor.
    /// </summary>
    /// <seealso cref="System.ComponentModel.EventDescriptor" />
    class FooTextChangedDescriptor : EventDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FooTextChangedDescriptor"/> class.
        /// </summary>
        /// <param name="desc">The desc.</param>
        public FooTextChangedDescriptor(MemberDescriptor desc)
            : base(desc)
        {
        }

        /// <summary>
        /// When overridden in a derived class, binds the event to the component.
        /// </summary>
        /// <param name="component">A component that provides events to the delegate.</param>
        /// <param name="value">A delegate that represents the method that handles the event.</param>
        public override void AddEventHandler(object component, Delegate value)
        {
            (component as ZeroitCodeTextBox).BindingTextChanged += value as EventHandler;
        }

        /// <summary>
        /// When overridden in a derived class, gets the type of component this event is bound to.
        /// </summary>
        /// <value>The type of the component.</value>
        public override Type ComponentType
        {
            get { return typeof(ZeroitCodeTextBox); }
        }

        /// <summary>
        /// When overridden in a derived class, gets the type of delegate for the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public override Type EventType
        {
            get { return typeof(EventHandler); }
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the event delegate is a multicast delegate.
        /// </summary>
        /// <value><c>true</c> if this instance is multicast; otherwise, <c>false</c>.</value>
        public override bool IsMulticast
        {
            get { return true; }
        }

        /// <summary>
        /// When overridden in a derived class, unbinds the delegate from the component so that the delegate will no longer receive events from the component.
        /// </summary>
        /// <param name="component">The component that the delegate is bound to.</param>
        /// <param name="value">The delegate to unbind from the component.</param>
        public override void RemoveEventHandler(object component, Delegate value)
        {
            (component as ZeroitCodeTextBox).BindingTextChanged -= value as EventHandler;
        }
    }
}
