using System;
using System.Linq;
using System.Collections.Generic;

namespace Najbliższe_punkty_na_płaszczyźnie
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = DataReader.GetPoints();
            points = SortX(points);
            foreach (var point in points)
            {
                Console.WriteLine("(" + point.x + "," + point.y + ")");
            }
            Edge result = findEdge(SortX(points), points.Count);
            Console.WriteLine("Najkrótsza krawędź: (" + result.Begin.x + "," + result.Begin.y + ")" + "(" + result.End.x + "," + result.End.y + ")" + " długość: " + result.GetDistance());
        }
        public static List<Point> SortX(List<Point> points)
        {
            points = points.OrderBy(p => p.x).ToList();
            return points;
        }
        public static Edge findEdge(List<Point> points, int count)
        {
            int midPointIndex = count / 2;
            Point midPoint = points[midPointIndex];

            if (points.Count <= 3) 
            {
                return getMindDistEdge(points);
            }

            var leftList = points.Take(midPointIndex).ToList();
            var rightList = points.Skip(midPointIndex).ToList();

            var dl = findEdge(leftList, count / 2);
            var dr = findEdge(rightList, count / 2);

            var d = getMin(dl, dr);

            List<Point> closerPoints = new List<Point>();

            foreach (var point in points) 
            {
                if (Math.Abs(point.x - midPoint.x) < d.GetDistance())
                {
                    closerPoints.Add(point);
                }
            }
            var closerPointsMin = getCloser(closerPoints, d.GetDistance());
            var minDistEdge = getMin(d, closerPointsMin);
            return minDistEdge;
        }
        public static Edge getMin(Edge e1, Edge e2)
        {
            if (e1.Begin is null || e1.End is null)
                return e2;
            else if (e2.Begin is null || e2.End is null)
                return e1;
            else
                return (e1.GetDistance() > e2.GetDistance()) ? e2 : e1;       
        }
        public static Edge getCloser(List<Point> closerPoints, double minDist)
        {
            double min = minDist;
            Edge minDistEdge = new Edge();
            var closerPointsSort = closerPoints.OrderBy(p => p.y).ToList();

            for (int i = 0; i < closerPointsSort.Count; i++) 
            {
                for (int j = i + 1; j < closerPointsSort.Count && (closerPointsSort[j].y - closerPointsSort[i].y) < min; j++)
                {
                    Edge tmpEdge = new Edge(closerPointsSort[i], closerPointsSort[j]);
                    if (tmpEdge.GetDistance() < min)
                    {
                        minDistEdge = tmpEdge;
                        min = tmpEdge.GetDistance();
                    }
                }
            }
            return minDistEdge;
        }
        public static Edge getMindDistEdge(List<Point> points)
        {
            double min = Double.MaxValue;
            Edge minDistEdge = new Edge();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    Edge tmpEdge = new Edge(points[i], points[j]);
                    if (tmpEdge.GetDistance() < min)
                    {
                        minDistEdge = tmpEdge;
                        min = tmpEdge.GetDistance();
                    }
                }
            }
            return minDistEdge;
        }
    }
}
