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

            List<ResultRepository> resultRepositories = new List<ResultRepository>();
            List<Point> result = new List<Point>();

            AVLTree activeSectors = new AVLTree();

            for (int i = 0; i < orderedPoints.Count; i++) 
            {
                if (orderedPoints[i].ParentSectorDirection == "h" && orderedPoints[i].Extreme == "b")
                {
                    activeSectors.root = activeSectors.insert(activeSectors.root, orderedPoints[i].Sector);
                }
                else if (orderedPoints[i].ParentSectorDirection == "h" && orderedPoints[i].Extreme == "e")
                {
                    activeSectors.root = activeSectors.deleteNode(activeSectors.root, orderedPoints[i].Sector);
                }
                else
                {
                    int height = activeSectors.height(activeSectors.root);

                    //activeSectors.search(activeSectors.root, orderedPoints[i].Sector);

                    activeSectors.getCrossedElements(activeSectors.root, orderedPoints[i].Sector);
                    var allHorizontal = activeSectors.allSectors;
                    activeSectors.clearAllList();

                    if(allHorizontal.Count > 0) 
                    {
                        ResultRepository resultRepository = new ResultRepository();
                        resultRepository.XCoordSectors = allHorizontal.ToList();
                        resultRepository.YCoord = orderedPoints[i];
                        resultRepositories.Add(resultRepository);
                    }                    
                }
            }

            foreach (var repo in resultRepositories) 
            {
                result.AddRange(repo.GetCrossings());
            }

            foreach (var crossing in result) 
            {
                Console.WriteLine(crossing.ToString());                
            }
            Console.WriteLine(result.Count.ToString());

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
