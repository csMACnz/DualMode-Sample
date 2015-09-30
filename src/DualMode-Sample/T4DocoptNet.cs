
using System.Collections;
using System.Collections.Generic;
using DocoptNet;

namespace DualMode_Sample
{
    // Generated class for Main.usage.txt
    public class MainArgs
    {
        public const string USAGE = @"Example usage for T4 Docopt.NET

Usage:
  prog [--gui]
  prog --cli
  prog --version
  prog --help

Options:
 -h,--help     Help
 -v,--version  Version
 --cli         Run in console mode
 --gui         Run in gui mode

Explanation:
 This program runs in console and gui mode.
";
        private readonly IDictionary<string, ValueObject> _args;
        public MainArgs(ICollection<string> argv, bool help = true,
                                                      object version = null, bool optionsFirst = false, bool exit = false)
        {
            _args = new Docopt().Apply(USAGE, argv, help, version, optionsFirst, exit);
        }

        public IDictionary<string, ValueObject> Args
        {
            get { return _args; }
        }

		public bool OptGui { get { return _args["--gui"].IsTrue; } }
		public bool OptCli { get { return _args["--cli"].IsTrue; } }
		public bool OptVersion { get { return _args["--version"].IsTrue; } }
		public bool OptHelp { get { return _args["--help"].IsTrue; } }
    }

}

