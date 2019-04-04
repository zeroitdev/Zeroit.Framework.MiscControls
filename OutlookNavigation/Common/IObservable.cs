// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="IObservable.cs" company="Zeroit Dev Technologies">
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


using System.Collections.Generic;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents an object which can be observed by <see cref="IObserver" /> objects.
    /// </summary>
    /// <remarks>The IObservable object is responsible for notifying the objects that observes
    /// the object by calling the Notify method</remarks>
    public interface IObservable
   {
        /// <summary>
        /// Contains the observers currently observing this object
        /// </summary>
        /// <value>The observers.</value>
        List<IObserver> Observers { get; }


        /// <summary>
        /// Notifies the observer in the available in the list <see cref="Observers" />
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional arguments</param>
        void NotifyObservers(IObservable obj, string id, object arguments);
   }
}
