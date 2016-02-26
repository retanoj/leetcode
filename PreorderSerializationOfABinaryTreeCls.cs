using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class PreorderSerializationOfABinaryTreeCls
    {
        public bool IsValidSerialization(string preorder)
        {
            string[] tree = preorder.Split(',');

            int ret = PreOrderSearch(tree, 0);

            return ret == tree.Count()-1;
        }

        public int PreOrderSearch(string[] tree, int cur)
        {
            if (cur >= tree.Count()) { return -1; }

            if (tree[cur] == "#") { return cur; }

            int retl = PreOrderSearch(tree, cur + 1);
            if (retl == -1) { return retl; }

            int retr = PreOrderSearch(tree, retl + 1);

            return retr;
        }

        public bool IsValidSerialization2(string preorder)
        {
            string[] tree = preorder.Split(',');

            if (tree.Count() == 0) { return true; }
            if (tree[0] == "#")
            {
                if (tree.Count() == 1) { return true; }
                else { return false; }
            }

            int count = 2;
            
            for (int i = 1; i < tree.Count(); i++)
            {
                if (tree[i] == "#") count--;
                else count++;

                if (count < 0) return false;
                if (count == 0 && i != tree.Count()-1) return false;
            }

            return count == 0;
        }
    }
}
