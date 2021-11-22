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
            var pointsX = SortX(points);
            var pointsY = SortY(points);//Tutaj następuje posortowanie Tablicy.
            foreach (var point in points)
            {
                Console.WriteLine("(" + point.x + "," + point.y + ")");
            }
            Edge result = findEdge(pointsX, pointsY, points.Count);
            Console.WriteLine("Najkrótsza krawędź: (" + result.Begin.x + "," + result.Begin.y + ")" + "(" + result.End.x + "," + result.End.y + ")" + " długość: " + result.GetDistance());
        }
        public static List<Point> SortX(List<Point> points)
        {
            points = points.OrderBy(p => p.x).ToList();
            return points;
        }
        public static List<Point> SortY(List<Point> points)
        {
            points = points.OrderBy(p => p.y).ToList();
            return points;
        }
        public static Edge findEdge(List<Point> pointsX, List<Point> pointsY, int count)
        {
            int midPointIndex = count / 2;
            Point midPoint = pointsX[midPointIndex];

            if (pointsX.Count <= 3) 
            {
                return getMindDistEdge(pointsX);
            }

            var leftListX = pointsX.Take(midPointIndex).ToList();
            var rightListX = pointsX.Skip(midPointIndex).ToList();
            var leftListY = new List<Point>();
            var rightListY = new List<Point>();
            for (int i = 0; i < pointsY.Count; i++)//Tutaj następuje podział listy posortowanej po Y według kryterium kolejności z listy posortowanej po X.                             
            {                                      //Tzn.MidPoint to punkt środkowy listy posortowanej po X. Jeżeli współrzędna X punktu listy posortowanej
                if (pointsY[i].x <= midPoint.x)    // po Y jest mniejsza równa, ląduje w w nowej lisćie "leftListY", w przeciwnym razie w "rightListY"
                {
                    leftListY.Add(pointsY[i]);
                }
                else
                {
                    rightListY.Add(pointsY[i]);
                }
            }

            var dl = findEdge(leftListX, leftListY, count / 2);
            var dr = findEdge(rightListX, leftListY, count / 2);

            var d = getMin(dl, dr);

            List<Point> closerPoints = new List<Point>();

            foreach (var point in pointsY) 
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
        public static Edge getCloser(List<Point> closerPointsSort, double minDist)
        {
            double min = minDist;
            Edge minDistEdge = new Edge();

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
