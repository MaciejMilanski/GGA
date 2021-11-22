using System;
using System.Linq;
using System.Collections.Generic;

namespace kd_drzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = DataReader.GetPoints();
            var pointsX = points.OrderBy(p => p.x).ToList();
            var pointsY = points.OrderBy(p => p.y).ToList();
            
        }
        public static Node createNode(List<Point> pointsX, List<Point> pointsY, int level) 
        {
            var midPointXIndex = pointsX.Count / 2;
            Point midPointX = pointsX[midPointXIndex];
            var leftListX = pointsX.Take(midPointXIndex).ToList();
            var rightListX = pointsX.Skip(midPointXIndex).ToList();

            var leftListY = new List<Point>();
            var rightListY = new List<Point>();
            for (int i = 0; i < pointsY.Count; i++)//Tutaj następuje podział listy posortowanej po Y według kryterium kolejności z listy posortowanej po X.                             
            {                                      //Tzn.MidPoint to punkt środkowy listy posortowanej po X. Jeżeli współrzędna X punktu listy posortowanej
                if (pointsY[i].x <= midPointX.x)    // po Y jest mniejsza równa, ląduje w w nowej lisćie "leftListY", w przeciwnym razie w "rightListY"
                {
                    leftListY.Add(pointsY[i]);
                }
                else
                {
                    rightListY.Add(pointsY[i]);
                }
            }

            Node root = new Node();

            root.LeftLeaf = createNode(leftListX, leftListY, level + 1);
            root.RightLeaf = createNode(rightListX, rightListY, level + 1);

            return null;
        }
    }
}
