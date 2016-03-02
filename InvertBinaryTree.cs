using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class InvertBinaryTree
    {
         public class TreeNode {
             public int val;
             public TreeNode left;
             public TreeNode right;
             public TreeNode(int x) { val = x; }
         }
        TreeNode invert(TreeNode r1, TreeNode r2)
        {
            if (r1 == null) { return null; }
            r2 = new TreeNode(r1.val);

            r2.right = invert(r1.left, r2.right);
            r2.left = invert(r1.right, r2.left);
            return r2;
        }
        public TreeNode InvertTree(TreeNode root)
        {
            TreeNode root2 = invert(root, null);
            return root2;
        }
    }
}
