using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSzpitali
{
    public class Point
    {
        public Point() 
        {
            NeighboursDistances = new List<NeighboursDistances>();
            IsHospital = false;
        }
        public int x { get; set; }
        public int y { get; set; }
        public List<NeighboursDistances> NeighboursDistances { get; set; }
        public Point ClosestHospital { get; set; }
        public double DistanceFromHospital { get; set; }
        public bool IsHospital { get; set; }
        public string ToString()
        {
            return x + "," + y + " Najbliższy szpital: " + DistanceFromHospital.ToString();
        }
        public double GetDistance(Point neighbour)
        {
            return Math.Sqrt(Math.Pow((neighbour.x - x), 2) + Math.Pow((neighbour.y - y), 2));
        }
        public static bool operator == (Point a, Point b)
        {
            if (!(a is null) && !(b is null) && a.x == b.x && a.y == b.y)
                return true;
            else
                return false;
        }
        public static bool operator != (Point a, Point b)
        {
            if ((a is null) && (b is null) && a.x == b.x && a.y == b.y)
                return false;
            else
                return true;
        }
    }
}
