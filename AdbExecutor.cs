using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVController
{
    class AdbExecutor : IDisposable, IExecutor
    {
        private Process process;

        public AdbExecutor() {
        }

        public void Prepare(string device)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "adb.exe";
            psi.Arguments = string.Format("-s {0} shell", device);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = false;
            psi.RedirectStandardInput = true;

            process = Process.Start(psi);
        }

        public void Execute(string format, params object[] args) {
            string cmd = string.Format(format, args);
            process.StandardInput.WriteLine(cmd);
        }

        public void Dispose()
        {
            if (process != null) {
                process.StandardInput.WriteLine("exit");
                process.Kill();
                process.WaitForExit(100);
                process.Close();
                process = null;
            }
        }
    }
}
