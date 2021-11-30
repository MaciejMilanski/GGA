using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajliczniejszyZbiorNiezależny
{
    public class RawNode
    {
        public RawNode() { }
        public RawNode(int _ID)
        {
            ID = _ID;
        }
        public int ID { get; set; }
        public int ParentID { get; set; }
    }
}
