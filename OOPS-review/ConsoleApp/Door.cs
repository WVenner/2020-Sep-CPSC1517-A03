using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Door
    {
        //height, width, material (nullable), right or left swing door
        //height and width > 0.0
        //height has a default of 1.75, width is 1.2
        //right or left are indiciated with an R or L
        //Area and Perimeter
        //throw exceptions for invalid data
        private decimal _Width;
        private decimal _Height;
        private string _Material;
        private string _Swing;

        public string Swing
        {
            get { return _Swing}
            set
            {
                if (value.ToUpper().Equals("R") || value.ToUpper().Equals("L"))
                {
                    _Swing
                }
            }
        }

        public decimal Width
        {
            get 
        }

        //string.IsNullOrEmpty

        public Door()
        {
            Width = 1.2m;
            Height = 1.75m;

        }

        public decimal DoorArea()
        {
      

            return Height * Width
        }
        public decimal DoorPerimeter()
        {
            return 2 * (Height + Width);
        }
        //public decimal Width
        //{
        //    get { return _Width}
        //    set
        //    {
        //        if ()
        //    }
        //}


        //public char Swing
        //{
        //    get { return _Swing}
        //    set
        //    {
        //        if (value != 'R' && value != 'L')
        //        {
        //            throw new Exception("Directional door swing can only be R or L");
        //        }
        //        else
        //        {
        //            _Swing = value;
        //        }
        //    }
        //}

        //public Door()
        //{
        //    Width = 1.2m;
        //    Height = 1.75m;
        //    Material = null;
        //}
    }
}
