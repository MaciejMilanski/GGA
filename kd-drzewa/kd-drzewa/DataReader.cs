using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace kd_drzewa
{
    public class DataReader
    {
        private static readonly string _inputPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "\\Data1.txt";
        public DataReader() 
        {
        }
        public static List<Point> GetPoints() 
        {
            List<Point> points = new List<Point>();
            string data = "";
            using (StreamReader streamReader = new StreamReader(_inputPath)) 
            {
                data = streamReader.ReadToEnd();
            }
            data = Regex.Replace(data, @"\s", "");
            var interResults = data.Split(";");
            foreach (var result in interResults)
            {
                if (result != "")
                {
                    Point point = new Point();
                    point.x = Convert.ToInt32(result.Split(",")[0]);
                    point.y = Convert.ToInt32(result.Split(",")[1]);
                    points.Add(point);
                }
            }
                return points; 
        }

    }
}
