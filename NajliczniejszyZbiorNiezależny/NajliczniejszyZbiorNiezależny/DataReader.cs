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
        public static List<RawNode> GetRowNodes()
        {
            List<RawNode> rawNodes = new List<RawNode>();
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
                    RawNode rawNode = new RawNode();
                    rawNode.ID = Convert.ToInt32(result.Split(",")[0]);
                    rawNode.ParentID = Convert.ToInt32(result.Split(",")[1]);
                    rawNodes.Add(rawNode);
                }
            }
            return rawNodes;
        }

    }
}

