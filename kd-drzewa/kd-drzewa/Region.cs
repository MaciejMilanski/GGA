using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kd_drzewa
{
    public class Region
    {
        public Region(int _yMax, int _yMin, int _xMax, int _xMin) 
        {
            yMax = _yMax;
            yMin = _yMin;
            xMax = _xMax;
            xMin = _xMin;
        }         
        public int xMin { get; set; }
        public int yMin { get; set; }
        public int xMax { get; set; }
        public int yMax { get; set; }
    }
}
