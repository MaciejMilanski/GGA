using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajliczniejszyZbiorNiezależny
{
    public class TreeManager
    {
        public static Node CreateTree(List<RawNode> rawNodesNM, List<RawNode> rawNodes, RawNode parent) 
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
                root.SubNodes.Add(CreateTree(rawNodesNM, rawNodes.ToList(), childNode));
            }
            return root;
        }
        public static int GetMaxPower(Node tree) 
        {
            if (tree.SubNodes is null) //jeżeli jest liściem XML2 U2-1A
            {
                return 1;
            }
            else
            {
                List<int> powers = new List<int>(){1, 0}; //1 plus suma
                foreach (var child in tree.SubNodes) 
                {
                    if (child.SubNodes is not null) 
                    {
                        foreach (var grandChild in child.SubNodes)
                        {
                            powers[0] += GetMaxPower(grandChild);
                        }
                    }                   
                    powers[1] += GetMaxPower(child);
                }
                tree.Power = powers.Max();
                return powers.Max();               
            }
        }
    }
}
