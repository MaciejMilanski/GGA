using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najbliższe_punkty_na_płaszczyźnie
{
    public class Point
    {
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
