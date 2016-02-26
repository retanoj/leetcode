using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class KthSmallestInBST
    { 
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count != 0)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    cur = stack.Pop();

                    if (--k == 0)
                    {
                        stack.Clear();
                        return cur.val; 
                    }
                    cur = cur.right;
                }
            }
            return -1;
        }
    }
}
