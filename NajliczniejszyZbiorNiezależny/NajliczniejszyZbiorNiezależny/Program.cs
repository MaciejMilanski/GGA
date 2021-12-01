using System;
using System.Collections.Generic;
using System.Linq;

namespace NajliczniejszyZbiorNiezależny
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowNodes = DataReader.GetRowNodes();
            var tree = TreeManager.CreateTree(rowNodes.ToList(), rowNodes, new RawNode(1));
            var maxPower = TreeManager.GetMaxPower(tree);
            Console.WriteLine("Rozmiar największego zbioru niezależnego: " + maxPower.ToString());
        }
    }
}
