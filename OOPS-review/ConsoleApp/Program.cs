using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Window bob = new Window();
            bob.Manufacturer = "don all glass windows";
            Console.WriteLine($"{bob.Manufacturer}");
        }
    }
}
