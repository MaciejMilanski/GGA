using System;

namespace JadroWielokataProstego
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DataReader.GetPoints();
            Polygon polygon = new Polygon(result);
            var globalMax = polygon.GetMax();
            var globalMin = polygon.GetMin();
            Console.WriteLine("Max: " + globalMax.ToString() + "\n" + "Min: " + globalMin.ToString());

            var polygonMins = polygon.GetLocalMins();
            int i = 1;
            foreach (var min in polygonMins) 
            {
                Console.WriteLine("Lokalne minimum nr: " + i.ToString() + " = " + min.ToString());
                i++;
            }

            var polygonMaxs = polygon.GetLocalMaxs();
            i = 1;
            foreach (var max in polygonMaxs)
            {
                Console.WriteLine("Lokalne maksimum nr: " + i.ToString() + " = " + max.ToString());
                i++;
            }
            //polygonMaxs.Add(globalMax);
            //polygonMins.Add(globalMin);
            Point newLocalMin = new Point();
            Point newLocalMax = new Point();
            int ymax;
            int ymin;
            if (polygonMaxs.Count < 1)
            {
                newLocalMax = globalMin;
                ymax = newLocalMax.y;
            }
            else
            {
                newLocalMax = polygon.CheckMaxs(polygonMaxs);
                ymax = newLocalMax.y;
            }


            if (polygonMins.Count < 1)
            {
                newLocalMin = globalMax;
                ymin = newLocalMin.y;
            }

            else
            {
                newLocalMin = polygon.CheckMins(polygonMins);
                ymin = newLocalMin.y;
            }
            

            if (ymin >= ymax)
            {
                Console.WriteLine("Istnieje jądro");
                Console.WriteLine("Obwód: " + polygon.GetCoreCircuit(newLocalMin, newLocalMax).ToString());
            }
            else
                Console.WriteLine("Nie istnieje Jądro");
        }
    }
}
