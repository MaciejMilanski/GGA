using System;
using System.Collections.Generic;
using System.Linq;

namespace Punkty_przeciec
{
    class Program
    {
        static void Main(string[] args)
        {
            var sectors = DataReader.GetSectors();
            var vertSectors = sectors.Where(s => s.Direction == "v");
            var orderedPoints = orderPoints(sectors);

            List<Point> result = new List<Point>();

            List<Sector> activeSectors = new List<Sector>();

            for (int i = 0; i < orderedPoints.Count; i++) 
            {
                if (orderedPoints[i].ParentSectorDirection == "h" && orderedPoints[i].Extreme == "b")
                {
                    activeSectors.Add(orderedPoints[i].Sector);
                }
                else if (orderedPoints[i].ParentSectorDirection == "h" && orderedPoints[i].Extreme == "e")
                {
                    activeSectors.Remove(orderedPoints[i].Sector);
                }
                else
                {
                    foreach (var sector in activeSectors) 
                    {
                        Point crossing = new Point(orderedPoints[i].x, sector.Begin.y);
                        result.Add(crossing);
                    }
                }
            }

            foreach (var crossing in result) 
            {
                Console.WriteLine(crossing.ToString());
            }

        }
        public static List<Point> orderPoints(List<Sector> sectors)
        {
            List<Point> result = new List<Point>();

            List<Point> HorizSectorBegins = new List<Point>();
            List<Point> VertSectors = new List<Point>();
            List<Point> HorizSectorEnds = new List<Point>();

            var horizSectors = sectors.Where(x => x.Direction == "h").ToList();
            var vertSectors = sectors.Where(x => x.Direction == "v").ToList();

            foreach (var sector in sectors) 
            {
                if (sector.Direction == "h")
                {
                    HorizSectorBegins.Add(sector.Begin);
                    HorizSectorEnds.Add(sector.End);
                }
                else
                {
                    VertSectors.Add(sector.Begin);
                }
            }
            result.AddRange(HorizSectorBegins);
            result.AddRange(VertSectors);
            result.AddRange(HorizSectorEnds);

            result = result.OrderBy(p => p.x).ToList();

            return result;
        }        
    }
}
