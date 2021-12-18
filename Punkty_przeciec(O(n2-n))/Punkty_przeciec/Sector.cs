using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkty_przeciec
{
    public class Sector
    {
        public Sector() 
        {
            Begin = new Point();
            End = new Point();
        }
        public Point Begin { get; set; }
        public Point End { get; set; }
        public string Direction { get; set; }
    }
}
