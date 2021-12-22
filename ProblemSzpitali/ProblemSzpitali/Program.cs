using System;

namespace ProblemSzpitali
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = DataReader.GetPoints();

            for (int i = 0; i < points.Count; i++) 
            {
                var neighbours = points[i].NeighboursDistances;
                for (int j = 0; j < points.Count; j++) 
                {
                    var distance = points[i].GetDistance(points[j]);
                    if (distance != 0)
                    {
                        neighbours.Add(distance);
                    }
                }
            }

            foreach (var point in points) 
            {
                Console.WriteLine("");
                Console.WriteLine(point.ToString());
                foreach (var distances in point.NeighboursDistances)
                {
                    Console.WriteLine(distances.ToString());
                } 
            }
        }
    }
}
