using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Quickstart
{
    /// <summary>
    /// Control class for executing commands on the CLI
    /// </summary>
    internal class CLIController
    {
        /// <summary>
        /// Runs the command string and returns the result.
        /// </summary>
        /// <param name="command">The command to execute on the command line.</param>
        /// <returns>Result of the command with success or failure, any output and the error if applicable.</returns>
        public static CLIResult Run(string command)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = $"/C {command}";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            try
            {
                cmd.Start();
            }
            catch (Exception ex)
            {
                new CLIResult { Error = ex, Success = false };
            }

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            return new CLIResult
            {
                Success = true,
                Output = cmd.StandardOutput.ReadToEnd()
            };
        }
    }

    internal struct CLIResult
    {
        public Exception Error { get; set; }
        public string Output { get; set; }
        public bool Success { get; set; }
    }
}
