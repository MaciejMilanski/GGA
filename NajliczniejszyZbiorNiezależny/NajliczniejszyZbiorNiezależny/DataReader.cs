using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace NajliczniejszyZbiorNiezależny
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
            var interResults = data.Split(";").ToList();
            
                return points;
        }
        public static void createTree(List<string> result)
        {
            var level0 = result.SingleOrDefault()
        }

    }
}
