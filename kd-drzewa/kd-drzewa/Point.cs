﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kd_drzewa
{
    public class Point
    {
        public Point() { }
        public Point(string input)
        {
            x = Convert.ToInt32(input.Split(",")[0]);
            y = Convert.ToInt32(input.Split(",")[1]);
        }
        public string ToString() 
        {
            return x + "," + y;
        }
        public int x { get; set; }
        public int y { get; set; }
        public static bool operator == (Point a, Point b)
        {
            if (!(a is null) && !(b is null) && a.x == b.x && a.y == b.y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Point a, Point b)
        {
            if ((a is null) && (b is null) && a.x == b.x && a.y == b.y)
                return false;
            else
                return true;
        }
    }
}
