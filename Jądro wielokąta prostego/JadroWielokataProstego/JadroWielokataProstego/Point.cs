using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadroWielokataProstego
{
    public class Point
    {
        public string ToString() 
        {
            return x + "," + y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
