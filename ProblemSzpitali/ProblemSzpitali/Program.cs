using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace ProblemSzpitali
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = DataReader.GetPoints();
            List<Point> result = new List<Point>();

            //for (int i = 0; i < points.Count; i++) 
            //{
                ////var neighbours = points[i].NeighboursDistances;
                ////for (int j = 0; j < points.Count; j++) 
                ////{
                ////    var distance = 0;// points[i].GetDistance(points[j]);
                ////    if (distance != 0)
                ////    {
                ////        NeighboursDistances neighboursDistances = new NeighboursDistances(points[j],distance);
                ////        neighbours.Add(neighboursDistances);
                ////    }
                ////}
                //points[i].NeighboursDistances = points[i].NeighboursDistances.OrderByDescending(n => n.Distance).ToList();
            //}
            Console.Write("Podaj k: ");
            int kRange = Convert.ToInt32(Console.ReadLine());

            Point firstPoint = getFirstPointRandomly(points);
            firstPoint.IsHospital = true;
            result.Add(firstPoint);
            //points.Remove(firstPoint);

            foreach (var point in points) 
            {
                point.DistanceFromHospital = point.GetDistance(firstPoint);
            }
            //odległośc każdego punktu od pierwszego szpitala.
            

            for (int i = 0; i < kRange-1; i++)
            {
                var maxDist = points.MaxBy(p => p.DistanceFromHospital).First();
                var nextPoint = points.FirstOrDefault(p => p.DistanceFromHospital == maxDist.DistanceFromHospital);
                nextPoint.IsHospital = true;
                result.Add(nextPoint);
                foreach (var point in points) 
                {
                    if (point.IsHospital)
                    {
                        point.DistanceFromHospital = 0;
                    }
                    else 
                    {
                        if(point.DistanceFromHospital > point.GetDistance(nextPoint))
                            point.DistanceFromHospital = point.GetDistance(nextPoint);
                    }                    
                }
                //var nextPoint = result.Last().NeighboursDistances.SingleOrDefault(n => n.Distance == result.Last().NeighboursDistances.Max(d => d.Distance)).Point;
                //nextPoint.IsHospital = true;                                
                //result.Add(nextPoint);
                //result.Last().NeighboursDistances.RemoveAll(nd => nd.Point.IsHospital == true);
            }
            printPoints(result);
            Console.WriteLine("____________");
            printPoints(points);
        }
        public static Point getFirstPointRandomly(List<Point> points) 
        {
            Random rnd = new Random();
            var index = rnd.Next(0, points.Count);
            
            //return points[index];
            return points.SingleOrDefault(p => p.x == 1 && p.y == 2);
        }
        public static void printPointsDistances(List<Point> points) 
        {
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
        public static void printPoints(List<Point> points)
        {
            foreach (var point in points) 
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}
