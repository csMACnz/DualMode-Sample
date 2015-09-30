using System;

namespace DualMode_Sample
{
    public class Program
    {
        [System.STAThread]
        public static void Main(string[] argv)
        {
            if (argv.Length == 0)
            {
                App.Main();
            }
            else
            {
                var args = new MainArgs(argv, help: true, version: "1.0.0", exit: true);
                if (args.OptGui)
                {
                    App.Main();
                }
                else if (args.OptCli)
                {
                    Console.WriteLine("I'm a console App");
                }
            }
        }
    }
}
