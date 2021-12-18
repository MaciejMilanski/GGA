using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkty_przeciec
{
    public class Node
    {
        public Node() { }
        public Node(int _ID) 
        {
            ID = _ID;
        }
        public Node SubNodes { get; set; }
        public int Power { get; set; }
        public int Level { get; set; }
        public Point Point { get; set; }
        public int Value { get; set; }
        public int ParentId { get; set; }
        public int ID { get; set; }
    }
}
