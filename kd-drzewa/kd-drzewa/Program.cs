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

            var tree = createNode(pointsX, pointsY, 0, "root");
            var a = 1;
        }
        public static Node createNode(List<Point> pointsX, List<Point> pointsY, int level, string side) 
        {

            Node root = new Node();
            if (level % 2 == 0)
            {
                if (pointsX.Count < 2) 
                {
                    if (pointsX.Count > 0)
                    {
                        root.Point = pointsX.First();
                        root.Level = level;
                    }
                    return root;
                }
                root.Level = level;
                var midPointXIndex = pointsX.Count / 2;
                if (pointsY.Count % 2 == 0) midPointXIndex -= 1; //jeżeli ilość parzysta narysuj kreskę na mniejszym elemencie
                Point midPointX = pointsX[midPointXIndex];

                var leftListX = new List<Point>();
                var rightListX = new List<Point>();
                for (int i = 0; i < pointsX.Count; i++) 
                {
                    if (pointsX[i].x <= midPointX.x)
                    {
                        leftListX.Add(pointsX[i]);
                    }
                    else
                    {
                        rightListX.Add(pointsX[i]);
                    }
                }                

                var leftListY = new List<Point>();
                var rightListY = new List<Point>();
                for (int i = 0; i < pointsY.Count; i++)
                {
                    if (pointsY[i].x <= midPointX.x)
                    {
                        leftListY.Add(pointsY[i]);
                    }
                    else
                    {
                        rightListY.Add(pointsY[i]);
                    }
                }

                root.LeftLeaf = createNode(leftListX, leftListY, level + 1, "left");
                root.RightLeaf = createNode(rightListX, rightListY, level + 1, "right");
            }
            else 
            {
                if (pointsY.Count < 2)
                {
                    if (pointsY.Count > 0)
                    {
                        root.Point = pointsY.First();
                        root.Level = level;
                    }
                    return root;
                }
                root.Level = level;
                var midPointYIndex = pointsY.Count / 2;
                if (pointsY.Count % 2 == 0) midPointYIndex -= 1; //jeżeli ilość parzysta narysuj kreskę na mniejszym elemencie
                Point midPointY = pointsY[midPointYIndex];

                var leftListY = new List<Point>();
                var rightListY = new List<Point>();
                for (int i = 0; i < pointsY.Count; i++)
                {
                    if (pointsY[i].y <= midPointY.y)
                    {
                        leftListY.Add(pointsY[i]);
                    }
                    else
                    {
                        rightListY.Add(pointsY[i]);
                    }
                }

                var leftListX = new List<Point>();
                var rightListX = new List<Point>();
                for (int i = 0; i < pointsX.Count; i++)
                {
                    if (pointsX[i].y <= midPointY.y)
                    {
                        leftListX.Add(pointsX[i]);
                    }
                    else
                    {
                        rightListX.Add(pointsX[i]);
                    }
                }

                root.LeftLeaf = createNode(leftListX, leftListY, level + 1, "left");
                root.RightLeaf = createNode(rightListX, rightListY, level + 1, "right");

            }
            return root;
        }
    }
}
