using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JadroWielokataProstego
{
    public class Polygon
    {
        public Polygon(List<Point> polygon) 
        {
            _Polygon = polygon;
        }
        public Point GetMax() 
        {
            List<Point> polygon = _Polygon;
            Point min = new Point();
            min = polygon[0];
            foreach (var point in polygon)
            {
                if (point.y > min.y)
                    min = point;
            }
            return min;
        }
        public Point GetMin()
        {
            List<Point> polygon = _Polygon;
            Point max = polygon[0];
            foreach (var point in polygon)
            {
                if (point.y < max.y)
                    max = point;
            }
            return max;
        }
        public List<Point> GetLocalMins()
        {
            List<Point> result = new List<Point>();

            for (int i = 0; i < _Polygon.Count - 2; i++)
            {
                if ((_Polygon[i].y >= _Polygon[i + 1].y && _Polygon[i + 1].y <= _Polygon[i + 2].y) && checkIfRightOrientation(_Polygon[i], _Polygon[i + 1], _Polygon[i + 2]))
                {
                    Point newMin = new Point();
                    newMin = _Polygon[i + 1];
                    result.Add(newMin);
                }
            }

            return result;
        }
        public List<Point> GetLocalMaxs()
        {
            List<Point> result = new List<Point>();

            for (int i = 0; i < _Polygon.Count - 2; i++)
            {
                if ((_Polygon[i].y <= _Polygon[i + 1].y && _Polygon[i + 1].y >= _Polygon[i + 2].y) && checkIfRightOrientation(_Polygon[i], _Polygon[i + 1], _Polygon[i + 2]))
                {
                    Point newMax = new Point();
                    newMax = _Polygon[i + 1];
                    result.Add(newMax);
                }
            }

            return result;
        }
        private bool checkIfRightOrientation(Point vp, Point v, Point vn)
        {
            var result = (vp.x * v.y) + (vp.y * vn.x) + (v.x * vn.y) - ((v.y * vn.x) + (vp.x * vn.y) + (vp.y * v.x));
            if (result < 0)            
                return true;            
            else            
                return false;            
        }
        public Point CheckMins(List<Point> points) 
        {
            Point result = new Point();
            result = points[0];
            foreach (var point in points)
            {
                if (result.y > point.y)
                    result = point;
            }
            return result;
        }
        public Point CheckMaxs(List<Point> points)
        {
            Point result = new Point();
            result = points[0];
            foreach (var point in points)
            {
                if (result.y < point.y)
                    result = point;
            }
            return result;
        }
        public List<Point> GetRightSiteOfCore(Point localMin, Point localMax) 
        {
            bool addFlag = false;
            List<Point> rightSite = new List<Point>();
            for (int i = 0; i < _Polygon.Count-1; i++) 
            {
                if (_Polygon[i] == localMax)
                    addFlag = true;
                
                if (addFlag) 
                {
                    if (_Polygon[i].y >= localMax.y && _Polygon[i].y <= localMin.y)
                    {
                        rightSite.Add(_Polygon[i]);
                    }
                }
                if (_Polygon[i] == localMin && addFlag == true)
                    break;
            }
            return rightSite;
        }
        public List<Point> GetLeftSiteOfCore(Point localMin, Point localMax)
        {
            bool addFlag = false;
            List<Point> leftSite = new List<Point>();
            List<Point> totalPath = new List<Point>();
            List<Point> secondCircuit = new List<Point>();

            totalPath = _Polygon.ToList();
            secondCircuit = _Polygon.ToList();
            secondCircuit.RemoveRange(0, 1);
            totalPath.AddRange(secondCircuit);
            for (int i = 0; i < totalPath.Count-1; i++)
            {
                if (totalPath[i] == localMin)
                    addFlag = true;
                if (totalPath[i] == localMax && addFlag == true)
                    break;
                if (addFlag)
                {
                    if (totalPath[i].y <= localMin.y && totalPath[i].y >= localMax.y)
                    {
                        leftSite.Add(totalPath[i]);
                    }
                }
            }
            return leftSite;
        }
        public double GetCoreCircuit(Point localMin, Point localMax)
        {
            List<Point> leftSite = new List<Point>();
            List<Point> rightSite = new List<Point>();
            leftSite = GetLeftSiteOfCore(localMin, localMax);
            rightSite = GetRightSiteOfCore(localMin, localMax);
            leftSite.AddRange(rightSite);

            var core = leftSite;
            double circuit = 0;
            for (int i = 0; i < core.Count -1 ; i++) 
            {
                circuit += Math.Sqrt(Math.Pow((core[i + 1].x - core[i].x),2) + Math.Pow((core[i + 1].y - core[i].y), 2));
            }
            return circuit;
        }
        //public int GetCoreCircuit(Point localMin, Point localMax)
        //{
        //    var topPoints = _Polygon.Where(p => p.y == localMin.y);
        //    var bottomPoints = _Polygon.Where(p => p.y == localMax.y);
        //    List<int> xTopTab = new List<int>();
        //    List<int> xBottomTab = new List<int>();
        //    foreach (Point point in topPoints)
        //    {
        //        xTopTab.Add(point.x);
        //    }
        //    foreach (Point point in bottomPoints)
        //    {
        //        xBottomTab.Add(point.x);
        //    }
        //    var bottomMinX = xBottomTab.Min();
        //    var BottomMaxX = xBottomTab.Max();

        //    var topMinX = xTopTab.Min();
        //    var topMaxX = xTopTab.Max();

        //    List<Point> corePolygon = new List<Point>();

        //    var leftTop = _Polygon.Where(p => p.x == )

        //}
        private List<Point> _Polygon { get; set; }        
    }
}
