using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajliczniejszyZbiorNiezależny
{
    public class Node
    {
        public Node() { }
        public Node(int _ID) 
        {
            ID = _ID;
        }
        public List<Node> SubNodes { get; set; }
        //public int _power
        public int Power { get; set; }
            //get
            //{ 
            //    if()
            //}
            //set 
            //{
            //    _power = value;
            //}
        //}
        public int Level { get; set; }
        //public Point Point { get; set; }
        public int Value { get; set; }
        public int ParentId { get; set; }
        public int ID { get; set; }        
    }
}
