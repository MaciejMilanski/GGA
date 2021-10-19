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
            var ymax = polygon.CheckMaxs(polygonMaxs).y;
            var ymin = polygon.CheckMins(polygonMins).y;

            if (ymin > ymax)
                Console.WriteLine("Istnieje jądro");
            else
                Console.WriteLine("Nie istnieje Jądro");
        }
    }
}
