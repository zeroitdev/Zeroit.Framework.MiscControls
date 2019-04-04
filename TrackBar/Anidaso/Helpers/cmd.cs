// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="cmd.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
