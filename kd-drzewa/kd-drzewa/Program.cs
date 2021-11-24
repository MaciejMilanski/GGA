using System;
using System.Linq;
using System.Collections.Generic;


namespace kd_drzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            foundedPoints = new List<Point>();
            var points = DataReader.GetPoints();
            var pointsX = points.OrderBy(p => p.x).ToList();
            var pointsY = points.OrderBy(p => p.y).ToList();

            var tree = createNode(pointsX, pointsY, 0, "root");

            Console.WriteLine("Budowa skończona");
            Console.Write("Podaj punkt od: ");
            var From = Console.ReadLine();

            Console.Write("Podaj punkt do: ");
            var To = Console.ReadLine();

            Point FromPoint = new Point(From);
            Point ToPoint = new Point(To);

            Region region = new Region(ToPoint.y, FromPoint.y, ToPoint.x, FromPoint.x);

            search(tree, region);

            if (foundedPoints.Count > 0)
            {
                foreach (var element in foundedPoints)
                {
                    Console.WriteLine("(" + element.x + "," + element.y + ")");
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono pasujących elementów");
            }
            

        }

        public static void search(Node tree, Region region) 
        {
            if ((tree.Point is not null) && (tree.Point.x >= region.xMin && tree.Point.x <= region.xMax) && (tree.Point.y >= region.yMin && tree.Point.y <= region.yMax))
            {
                foundedPoints.Add(tree.Point);
                return;
            }
            if (tree.Region is not null)
            {
                if ((tree.Region.xMin >= region.xMin && tree.Region.yMin >= region.yMin) && (tree.Region.xMax <= region.xMax && tree.Region.yMax <= region.yMax))
                {
                    getAllElements(tree);
                    return;
                }
                else //((tree.Region.xMin >= region.xMin && tree.Region.yMin >= region.yMin) || (tree.Region.xMax <= region.xMax && tree.Region.yMax <= region.yMax))
                {
                    if(tree.LeftLeaf is not null)
                        search(tree.LeftLeaf, region);
                    if(tree.RightLeaf is not null)
                        search(tree.RightLeaf, region);
                }
            }

        }
        public static void getAllElements(Node tree) 
        {
            if (tree.Point is not null)
            {
                foundedPoints.Add(tree.Point);
                return;
            }
            else 
            {
                if (tree.LeftLeaf is not null)
                    getAllElements(tree.LeftLeaf);
                if (tree.RightLeaf is not null)
                    getAllElements(tree.RightLeaf);
            }
        }
        public static Node createNode(List<Point> pointsX, List<Point> pointsY, int level, string side) 
        {

            Node root = new Node();
            if(pointsX.Count > 0)
                root.Region = new Region(pointsY.Last().y, pointsY.First().y, pointsX.Last().x, pointsX.First().x);            
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
        public static List<Point> foundedPoints { get; set; }
    }
}
