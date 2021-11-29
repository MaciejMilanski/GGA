using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajliczniejszyZbiorNiezależny
{
    class Node
    {
        public Node() { }      
        public List<Node> Leafs;
        public int Level { get; set; }
        //public Point Point { get; set; }
        public double Value { get; set; }
    }
}
