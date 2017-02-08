using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitPlayground
{
    class Program
    {
        /// <summary>
        /// An application's entry point that will start the execution on the main thread
        /// </summary>
        static void Main(string[] args)
        {
            StringProcessor sp = new AsyncStringProcessor();
            sp.Process();

            sp = new TaskStringProcessor();
            sp.Process();
            Console.ReadLine();
        }

    }
}
