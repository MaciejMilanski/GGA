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
                if (pointsX.Count < 3) 
                {
                    root.LeftLeaf = new Node();
                    root.RightLeaf = new Node();
                    root.LeftLeaf.Point = pointsX[0];
                    if (pointsX.Count > 1)
                        root.RightLeaf.Point = pointsX[1];
                    root.Level = level;
                    return root;
                }
                var midPointXIndex = pointsX.Count / 2;
                Point midPointX = pointsX[midPointXIndex];

                var leftListX = pointsX.Take(midPointXIndex).ToList();
                var rightListX = pointsX.Skip(midPointXIndex).ToList();
                var leftListY = new List<Point>();
                var rightListY = new List<Point>();

                for (int i = 0; i < pointsY.Count; i++)
                {
                    if (pointsY[i].x < midPointX.x)
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
                if (pointsY.Count < 3)
                {
                    root.LeftLeaf = new Node();
                    root.RightLeaf = new Node();
                    root.LeftLeaf.Point = pointsY[0];
                    if(pointsY.Count > 1)
                        root.RightLeaf.Point = pointsY[1];
                    root.Level = level;
                    return root;
                }

                var midPointYIndex = pointsY.Count / 2;
                Point midPointY = pointsY[midPointYIndex];

                var leftListY = pointsY.Take(midPointYIndex).ToList();
                var rightListY = pointsY.Skip(midPointYIndex).ToList();
                var leftListX = new List<Point>();
                var rightListX = new List<Point>();

                for (int i = 0; i < pointsX.Count; i++)
                {
                    if (pointsX[i].y < midPointY.y)
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
