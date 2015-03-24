using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.SimShell
{
    internal class SimRound
    {
        private String _pathToOptimizer = String.Empty;
        private String _argements = String.Empty;

        private String _result;

        internal SimRound(String arguments, String exePath)
        {
            this._argements = arguments;
            this._pathToOptimizer = exePath;

            this._result = String.Empty;
        }

        internal void Execute()
        {
            String result = String.Empty;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            startInfo.FileName = this._pathToOptimizer;
            startInfo.Arguments = this._argements;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;

            process.EnableRaisingEvents = true;

            process.Start();

            process.WaitForExit();
        }

        internal String Result
        {
            get
            {
                return this._result;
            }
        }
    }
}
