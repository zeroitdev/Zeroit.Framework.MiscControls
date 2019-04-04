// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="XPPanelTypeConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitPandaPanelTypeConverter


    /// <summary>
    /// ZeroitPandaPanelTypeConverter provides an <see cref="InstanceDescriptor" /> used
    /// for designer code generation. This allows an alternate constructor to
    /// be used that allows the value of <see cref="ZeroitPandaPanel.ExpandedHeight" /> to
    /// be specified prior to other properties (such as <see cref="System.Windows.Forms.Control.Size" />)
    /// which could interfere with correct sizing
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
	public class ZeroitPandaPanelTypeConverter : TypeConverter
    {
        /// <summary>
        /// Create an <c>ZeroitPandaPanelTypeConverter</c>
        /// </summary>
        public ZeroitPandaPanelTypeConverter() { }

        /// <summary>
        /// Signal that we can convert to an <see cref="InstanceDescriptor" /> (if asked...)
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="destinationType">Target type</param>
        /// <returns><see langword="true" /> if the designer asks for an <see cref="InstanceDescriptor" />,
        /// otherwise whatever the base class says</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Convert to an <see cref="InstanceDescriptor" /> if requested
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="culture">globalization</param>
        /// <param name="value">the instance to convert</param>
        /// <param name="destinationType">The target type</param>
        /// <returns>An <see cref="InstanceDescriptor" /> if requested, otherwise whatever
        /// the base class returns</returns>
        public override object ConvertTo(
                ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture,
                object value,
                Type destinationType
                )
        {
            // the designer wants an InstanceDescriptor
            if ((destinationType == typeof(InstanceDescriptor)) && (value is ZeroitPandaPanel))
            {
                ZeroitPandaPanel xpPanel = value as ZeroitPandaPanel;
                // Get our ZeroitPandaPanel(int) constructor
                ConstructorInfo ctorInfo = typeof(ZeroitPandaPanel).GetConstructor(new Type[] { typeof(int) });
                if (ctorInfo != null)
                {
                    // use this constructor and pass in the ExpandedHeight value. Use false to say that
                    // initialization is NOT complete
                    return new InstanceDescriptor(ctorInfo, new object[] { xpPanel.ExpandedHeight }, false);
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion
}
