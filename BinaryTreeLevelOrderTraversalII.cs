using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class BinaryTreeLevelOrderTraversalII
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        void visit(TreeNode node, IList<IList<int>> res, int level)
        {
            if (node == null) { return; }
            if (res.Count <= level)
            {
                res.Add(new List<int>());
            }
            res[level].Add(node.val);
            visit(node.left, res, level+1);
            visit(node.right, res, level+1);
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            visit(root, res, 0);
            res = res.ToArray().Reverse().ToList();
            return res;
        }
    }
}
