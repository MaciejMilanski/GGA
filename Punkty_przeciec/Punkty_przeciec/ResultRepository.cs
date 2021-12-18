using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkty_przeciec
{
    public class ResultRepository
    {
        public ResultRepository()
        {
            //XCoordSectors = new List<Sector>();
            //YCoord = new Point();
        }
        public List<Sector> XCoordSectors { get; set; }
        public Point YCoord { get; set; }

        public List<Point> GetCrossings() 
        {
            List<Point> result = new List<Point>();
            foreach (var sector in XCoordSectors) 
            {
                Point point = new Point(YCoord.x, sector.Begin.y);
                result.Add(point);
            }
            return result;
        }        
    }
}
