using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class SymmetricTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        bool iterativelyTest(TreeNode root)
        {
            if (root == null) { return true; }
            
            TreeNode left = root.left, right = root.right;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count != 0 || left != null || right != null )
            {
                while (left != null || right != null)
                {
                    if (left == null || right == null) { return false; }
                    if (left.val != right.val) { return false; }
                    //先压左边，再压右边
                    stack.Push(left); stack.Push(right);
                    left = left.left; right = right.right;
                }
                if (stack.Count != 0)
                {
                    //先弹右边，再弹左边
                    right = stack.Pop(); left = stack.Pop();
                    //左侧数先序遍历，即mid-left-right
                    left = left.right;
                    //右侧树按mid-right-left遍历
                    right = right.left;
                }
            }
            return true;
        }

        bool CompareTree(TreeNode left, TreeNode right)
        {
            if (left != null || right != null)
            {
                if (left == null || right == null) { return false; }
                return CompareTree(left.left, right.right) && CompareTree(left.right, right.left) && left.val == right.val ;
            }
            return true;
        }
        bool recursivelyTest(TreeNode root)
        {
            if (root == null) { return true; }
            TreeNode left = root.left, right = root.right;
            return CompareTree(left, right);
        }

        public bool IsSymmetric(TreeNode root)
        {
            return iterativelyTest(root) && recursivelyTest(root);
        }
    }
}
