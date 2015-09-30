using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DualMode_Sample
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        //const int SW_SHOW = 5;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [STAThread]
        public static void Main(string[] argv)
        {
            //http://stackoverflow.com/questions/493536/can-one-executable-be-both-a-console-and-gui-application
            if (argv.Length == 0)
            {
                LaunchAsGui();
            }
            else
            {
                var args = new MainArgs(argv, help: true, version: "1.0.0", exit: true);
                if (args.OptGui)
                {
                    LaunchAsGui();
                }
                else if (args.OptCli)
                {
                    RunInConsole(args);
                }
            }
        }

        private static void LaunchAsGui()
        {
            if (IsInConsole())
            {
                //relaunch as separate process
                var currentProcess = Process.GetCurrentProcess().MainModule.FileName;
                Process.Start(currentProcess);
            }
            else
            {
                var handle = GetConsoleWindow();

                // Hide
                ShowWindow(handle, SW_HIDE);

                App.Main();
            }
        }

        private static bool IsInConsole()
        {
            // Get uppermost window process
            IntPtr ptr = GetForegroundWindow();
            int u;
            GetWindowThreadProcessId(ptr, out u);
            Process process = Process.GetProcessById(u);

            // Check if it is console?
            return process.ProcessName == "cmd" || process.ProcessName == "powershell";
        }

        private static void RunInConsole(MainArgs args)
        {
            Console.WriteLine("I'm a console App");
        }
    }
}
