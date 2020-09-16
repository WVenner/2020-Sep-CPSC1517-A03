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
            //Window bob = new Window();
            //bob.Manufacturer = "don all glass windows";
            //Console.WriteLine($"{bob.Manufacturer}");

            //default constructor
            Window myDefaultInstance = new Window();

            myDefaultInstance.Height = 2.75m;
            myDefaultInstance.Width = 1.9m;
            myDefaultInstance.NumberofPanes = 3;
            myDefaultInstance.Manufacturer = "See Thru Holes";

            //Greedy constructor
            Window myGreedyInstance = new Window(2.75m, 1.9m, 3, "See Thru Holes");

            decimal price = myGreedyInstance.WindowCost(5.76m);
            decimal area = myDefaultInstance.WindowArea();

        }
    }
}
