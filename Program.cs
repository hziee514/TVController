using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVController
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (TestAdb()) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmDevices());
            }
            else
            {
                MessageBox.Show("请先将adb.exe所在路径加入环境变量PATH");
            }
        }

        public static Tuple<int, string> ExecuteCommand(string format, params object[] args) {
            string cmd = string.Format(format, args);
            return Run("cmd.exe", "/c " + cmd);
        }

        static bool TestAdb()
        {
            try
            {
                Run("adb", "version");
                return true;
            }
            catch (Win32Exception) {
                return false;
            }
        }

        private static Tuple<int, string> Run(string app, string args) {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = app;
            psi.Arguments = args;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = false;
            psi.RedirectStandardInput = false;

            Process process = Process.Start(psi);

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit(500);

            int exitCode = process.ExitCode;

            process.Close();

            return new Tuple<int, string>(exitCode, output);
        }
    }
}
