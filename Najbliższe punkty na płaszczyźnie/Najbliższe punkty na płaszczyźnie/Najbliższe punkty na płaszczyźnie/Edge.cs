using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najbliższe_punkty_na_płaszczyźnie
{
    public class Edge
    {
        public Edge() { }
        public Edge(Point _begin, Point _end)
        {
            Begin = _begin;
            End = _end;
        }
        public Point Begin { get; set; }
        public Point End { get; set; }
        public double GetDistance() 
        {
            return Math.Sqrt(Math.Pow((End.x - Begin.x), 2) + Math.Pow((End.y - Begin.y), 2));
        }
    }
}
