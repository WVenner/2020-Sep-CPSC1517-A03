﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Wall
    {
        // height, width

        //height and width > 0.0

        //height has a defualt of 2.5, width is 4.25

        //Area

        //throw exceptions for invalid data

        private decimal _Height;
        private decimal _Width;

        public decimal Height
        {
            get { return _Height; }
            set
            {
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
        public decimal Width
        {
            get { return _Width; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new Exception("Width can not be 0 or less than 0");
                }
                else
                {
                    _Width = value;
                }
            }
        }

        public Wall()
        {
            Height = 2.5m;
            Width = 4.25m;
        }

        public decimal WallArea()
        {
            return Height * Width;
        }
    }
}
