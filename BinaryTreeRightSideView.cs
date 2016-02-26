using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class BinaryTreeRightSideView
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        int count = 0;
        void MRL(TreeNode node, List<int> l, int layer)
        {
            if (node == null) { return; }
            if (layer == count) { l.Add(node.val); count++; }
            
            MRL(node.right, l, layer+1);
            MRL(node.left, l, layer+1);
        }
        
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> l = new List<int>();
            MRL(root, l, 0);
            return l;
        }
    }
}
