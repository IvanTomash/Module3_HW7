using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_3_7
{
    /// <summary>
    /// Main class.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Args.</param>
        public static void Main(string[] args)
        {
            Appliction appliction = new Appliction();
            appliction.Run();
            Console.WriteLine("Finish.");
        }
    }
}
