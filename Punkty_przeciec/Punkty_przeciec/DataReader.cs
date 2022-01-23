using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Punkty_przeciec
{
    public class DataReader
    {
        private static readonly string _inputPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "\\Data2.txt";
        public DataReader() 
        {
        }
        public static List<Sector> GetSectors()
        {
            List<Sector> sectors = new List<Sector>();
            string data = "";
            using (StreamReader streamReader = new StreamReader(_inputPath))
            {
                data = streamReader.ReadToEnd();
            }
            data = Regex.Replace(data, @"\s", "");
            var interResults = data.Split("\\n");
           
            foreach (var result in interResults)
            {
                if (result != "")
                {
                    Sector sector = new Sector();
                    sector.Begin.x = Convert.ToInt32(result.Split(";")[0].Split(",")[0]);
                    sector.Begin.y = Convert.ToInt32(result.Split(";")[0].Split(",")[1]);
                    sector.Begin.Extreme = "b";
                    sector.End.x = Convert.ToInt32(result.Split(";")[1].Split(",")[0]);
                    sector.End.y = Convert.ToInt32(result.Split(";")[1].Split(",")[1]);
                    sector.End.Extreme = "e";
                    sector.Direction = result.Split(";")[2];
                    sector.Begin.ParentSectorDirection = result.Split(";")[2];
                    sector.End.ParentSectorDirection = result.Split(";")[2];
                    sector.Begin.Sector = sector;
                    sector.End.Sector = sector;
                    sectors.Add(sector);
                }
            }
            return sectors;
        }

    }
}

