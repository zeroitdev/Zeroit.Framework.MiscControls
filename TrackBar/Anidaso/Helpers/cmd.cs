// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="cmd.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;

namespace Zeroit.Framework.MiscControls.Helper
{

    /// <summary>
    /// Class cmd.
    /// </summary>
    [DebuggerStepThrough]
    internal static class cmd
    {
        /// <summary>
        /// The process 0
        /// </summary>
        private static Process process_0;

        /// <summary>
        /// Executecmds the specified command.
        /// </summary>
        /// <param name="CMD">The command.</param>
        internal static void EXECUTECMD(string CMD)
        {
            cmd.process_0 = new Process();
            cmd.process_0.StartInfo.FileName = "CMD.exe";
            cmd.process_0.StartInfo.Arguments = string.Concat("/C ", CMD);
            cmd.process_0.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.process_0.Start();
            cmd.process_0.WaitForExit();
        }
    }

}
