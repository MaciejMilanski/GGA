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
        private List<Point> _Polygon { get; set; }        
    }
}
