using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Writer;

namespace ConsoleApp.Writer
{

    internal class Writer: IWriter
    {
        public void Write()
        {
            Console.WriteLine("I'm writing!");
        }
    }
}
