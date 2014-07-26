using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRGSS
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Debug = args.Length > 0 && args[0] == "debug" ? true : false;
            engine.Run();
        }
    }
}
