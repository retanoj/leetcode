using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class RecoverBinarySearchTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; left = null; right = null; }
        }

        TreeNode pre, first, second;

        //中序遍历，检查上一个Node(pre)的值是否大于当前Node(root)的值。
        //如果大于，即发生错误，记录为first 和 second。
        void recovery(TreeNode root)
        {
            if (root == null) { return; }
            recovery(root.left);
            if (pre != null && pre.val > root.val)
            {
                if (first == null) { first = pre; }
                second = root;
            }
            
            pre = root;
            recovery(root.right);
        }
        
        public void RecoverTree(TreeNode root)
        {
            recovery(root);
            if (first != null && second != null)
            {
                int v = first.val;
                first.val = second.val;
                second.val = v;
            }
        }
    }
}
