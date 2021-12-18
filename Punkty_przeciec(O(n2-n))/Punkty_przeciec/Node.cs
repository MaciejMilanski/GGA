using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkty_przeciec
{
    public class Node
    {
        public int height;
        public Node left;
        public Node right;
        public Sector key;

        public Node(Sector s)
        {
            key = s;
            height = 1;
        }
    }
}
