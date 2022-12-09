using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnrollBasics;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Globals.Init();
            Console.WriteLine(Globals.Courses[0].sections.Count);
        }
    }
}
