using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //a class represents the 
    // defined characteristics of an item
    // an item can be a physical thing, concept, or represent a collection of data and/or methods
    // visual studio creates your classes without a specific access type
    // the default type for a class is private
    // code outside of a private class cannot use the contents of the private class
    //for the class to be used by an outside user (program it must be public

    public class Window
    {
        //the class can have data that is open to the user 
        //by defining it as a public datatype
        // the class can have data (local variables) that is restricted from the user
        // by defining it as a private datatype
        //the class can create a property that can be used to
        // interface between the user and the private data member
        //this interface is a public property

        //private data member
        private string _Manufacturer;
        private decimal _Height;

        //Properties
        //optional
        //properties can be implemented in two ways
        //a) Fully implemented Property
        //   used because there is additional code/logic use 
        //   in processing the data
        //b) Auto Implemented Property
        //  used when there is no need for additional code/logic,
        // when the data is simply saved (stored)

        //fully implemented property
        public string Manufacturer
        {
            //assume the manufacturer is a nullable string
            //3 possibilities
            // a) there are characters in the string
            // b)string has no data
            // c)there is a physical string but no characters other than the end of string character
            // there will be additional code/logic to ensure only case a amd b exists for the data
            // this requires a private data member to hold the data and a property to manage the data content

            //imagine an assignment statement   receiving variable (left side) = sending data (right side)
            get
            {
                //returns data via the property to the outside user of that property
                //right side of an assignment statement
                //the data that is being return will normally come from a private data member
                return _Manufacturer;
            }
            set
            {
                //stores data via the property to the outside user of that property
                //left side of an assignment statement
                //stores the data into your private data member
                //internal to the property is a common variable that will hold the incoming data
                //this variable is called value
                // a property is associated with a single data member
                //a property has no parameter list
                if (string.IsNullOrEmpty(value)){
                    //case b and c
                    _Manufacturer = null;
                }
                else
                {
                    //case a
                    _Manufacturer = value; //value holds the incoming data
                }

                //alternative way of coding set
                //ternary operator
                //syntax:   condition(s) ? true value : false value
                //_Manufacturer = string.IsNullOrEmpty(value) ? null : value;

            }
        }

        //auto implemented properties
        //auto implemented properties can be used when there is no need for 
        //additional processimg against the incoming data
        //no internal private data member is required for this property
        //the system will internally generate a data area for the data
        //accessing this stored data (getting or setting) can only be done via the property

        public decimal Width { get; set; }

        //one can still code an auto implement property as a fully implemented property
        //private decimal _Width;
        
        //public decimal Width
        //{
        //    get { return _Width}
        //    set { _Width = value; }
        //}

        //what if, the data coming in is invalid?
        //Will there be additional logic/code needed?
        //What property implementation is needed
        public decimal Height
        {
            get { return _Height; }
            set
            {
                //the m on the literal indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height can not be 0 or less than 0");
                }
                else
                {
                    _Height = value;
                }
            }
        }

        //nullable numerics
        //Why do we not need to fully implement a nullable numeric?
        //numerics have a default of zero
        //numerics can only store a numeric value (unless nullable)
        //numerics can be null if declared as nullable
        //the only 2 possibilities for a nullable numeric is a number or null
        //IF the numeric has additional criteria THEN you can code
        //the property as a fully implemented property
        public int? NumberofPanes { get; set; }

        //Constructors
        //a constructor is "a method-like procedure" that guarantees that the newly
        //created instance of this class will always be created in
        // "a known state"

        //syntax
        //public constructorname([list of parameters is optional])
        //{
        //        your code
        //}

        //the constructorname is the class name
        //NOTE: there is no return datatype

        //constructor(s) are called on your behalfwhen an instance of the class
        //is requested by the program
        //you can not call a constructor directly like a method

        //constructor(s) are OPTIONAL
        //if a class does not have a constructor then the system 
        //will generate the class instance using the datatpe defaults
        //fo your private data members and auto implemented properties
        //this situation of no constructor(s) is often refeerred to as 
        //using a "system" constructor
        
        //if you code a constructor, then you must code any and all constructor(s)
        // need by your class as used in your programming

        //there are two common types of constructors
        // default constructor
        // Greedy Constructor

        //Default
        //this version of the constructor takes no parameters
        //this version usually simulates the "system" constructor
        //you can if you wish assign values to your 
        //class data members/properties that are no the system 
        //default for the datatype

        public Window()
        {
            //technically numerics are set to zero wen they are declared
            //logically in this class the numeric fields should not be zero
            //therefore, we will set the numeric fields to a 
            //literal not equal to zero

            //one could assign a value directly to a private data member 
            //within the class
            //a preferred method is to use the properties instead
            //why?  that property may have validtaion to ensure an acceptable value exists
            //      for the data
            //aslo, auto implemented properties have bno direct private data members

            Height = 0.9m;   //assume the window height is .9 meters
            //_Height = 0.0m
            Width = 1.2m;
            NumberofPanes = 1;
            Manufacturer = null; //this is optional as a string is default to null

        }

        //Greedy
        //akes in a value for each data member/property in the class
        //each data member/property is assigned the appropriate incoming 
        //parameter value

        public Window(decimal width, decimal height, int? numberofpanes, string manufacturer)
        {
            Width = width;
            Height = height;
            NumberofPanes = numberofpanes;
            Manufacturer = manufacturer;
        }

        //behaviours (methods)
    }
}
