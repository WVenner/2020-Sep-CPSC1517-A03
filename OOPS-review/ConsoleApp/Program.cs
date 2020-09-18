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
            //create an instance of the window class using the default constructor
            //the system calls you class constructor via the "new" command
            //the "new" will use the indicated constructor
            //the "new" actually makes the call to the constructor adn returns
            // the instance of the class
            //your code never calls the constructor directly
            Window myDefaultInstance = new Window();

            //results of the default constructor

            Console.WriteLine($"Width {myDefaultInstance.Width};" +
                $"Panes {myDefaultInstance.NumberofPanes}; " +
                $"Manufacturer >{myDefaultInstance.Manufacturer}<");
            
            //change the contents of an instance by using  the instance class properties
            //and/.or methods
            //to reference a property/method within an instance, use the dot operator
            myDefaultInstance.Height = 2.75m;
            myDefaultInstance.Width = 1.9m;
            myDefaultInstance.NumberofPanes = 3;
            myDefaultInstance.Manufacturer = "See Thru Holes";

            //Greedy constructor
            Window myGreedyInstance = new Window(2.75m, 1.9m, 3, "See Thru Holes");

            Console.WriteLine($"Width {myDefaultInstance.Width};" +
                $"Height {myDefaultInstance.Height};" +
                $"Panes {myDefaultInstance.NumberofPanes}; " +
                $"Manufacturer >{myDefaultInstance.Manufacturer}<");

            //decimal price = myGreedyInstance.WindowCost(5.76m);
            //decimal area = myDefaultInstance.WindowArea();

            Console.WriteLine("\n\n");

            UsingClasses();

            Console.ReadKey();
        }

        static void UsingClasses()
        {
            //the purpose of this method is to calculate the cost
            //of painting a room
            //the room will have several windows and walls with a
            //single door
            //all data for windows, walls, and doors will be collected and stored 
            //in an instance of room

            //What does Room need
            //declare a set of List<T> for the components of the room
            List<Wall> walls = new List<Wall>();
            List<Window> Windows = new List<Window>();
            List<Door> Doors = new List<Door>();
            Room room = new Room(); //default constructor

            //read and collect the data for he room
            //creates a reusable pointer variable to each of the components
            //of a room
            //these pointers are created outside of my input layers
            Wall wall = null;
            Window window = null;
            Door door = null;

            //collect the data for all of the walls in the room
            //loop of prompt/input/validation for each wall

            //after validation of data, create an instance of the 
            //needed class

            wall = new Wall();
            //load data into the instance
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) 
            //to save the data
            walls.Add(wall);

            //end of the wall collection loop

            //assume the loop collected and stored the following
            //pass 2
            wall = new Wall();
            //load data into the instance
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) 
            //to save the data
            walls.Add(wall);

            //pass 3
            wall = new Wall();
            //load data into the instance
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) 
            //to save the data
            walls.Add(wall);

            //pass 4
            wall = new Wall();
            //load data into the instance
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) 
            //to save the data
            walls.Add(wall);

            //door loop
            //collect the data for all of the doors in the room
            //loop of prompt/input/validation for each door
            //assume in this example that the literals were actully in variables
            //door = new Door(inputWidth, inputHeight, inputRL, inputMaterial);
            door = new Door(0.85m, 2.0m, "R", "Composite Pressed Wood");
            Doors.Add(door);

            //end of door loop

            //Window loop
            //prompt/input/validate
            //store
            window = new Window(1.3m, 1.3m, 2, "Fancy WIndows");
        }

    }
}
