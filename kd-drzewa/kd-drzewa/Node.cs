using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kd_drzewa
{
    class Node
    {
        public Node() { }
        public Node(Node leftLeaf, Node rightLeaf, int level)
        {
            LeftLeaf = leftLeaf;
            RightLeaf = rightLeaf;
            Level = level;
        }
        public Node LeftLeaf { get; set; }
        public Node RightLeaf { get; set; }
        public int Level { get; set; }
        public Point Point { get; set; }
        public Region Region {get; set;}
    }
}
