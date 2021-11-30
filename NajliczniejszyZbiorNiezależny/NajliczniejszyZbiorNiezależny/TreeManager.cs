using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajliczniejszyZbiorNiezależny
{
    public class TreeManager
    {
        public static Node createTree(List<RawNode> rawNodesNM, List<RawNode> rawNodes, RawNode parent) 
        {
            Node root = new Node();
            root.SubNodes = new List<Node>();
            //rawNodes.OrderBy(n => n.ID);          

            var childNodes = rawNodes.Where(n => n.ParentID == parent.ID).ToList();
            rawNodes.RemoveAll(n => n.ParentID == parent.ID);

            if (childNodes.Count() < 1)
            {
                Node leaf = new Node();
                leaf.ID = parent.ID;
                leaf.ParentId = rawNodesNM.SingleOrDefault(n => n.ID == leaf.ID).ParentID;                             
                return leaf;
            }
            root.ID = parent.ID;
            root.ParentId = parent.ParentID;

            foreach (var childNode in childNodes) 
            {
                root.SubNodes.Add(createTree(rawNodesNM, rawNodes.ToList(), childNode));
            }
            return root;
        }
    }
}
