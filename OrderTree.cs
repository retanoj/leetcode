using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class OrderTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        void visit(TreeNode node)
        {
            Console.WriteLine(node.val);
        }
        
        void InOrderTree1(TreeNode root)
        {
            if (root == null) { return; }
            InOrderTree1(root.left);
            visit(root);
            InOrderTree1(root.right);
        }

        void PreOrderTree1(TreeNode root)
        {
            if (root == null) { return; }
            visit(root);
            PreOrderTree1(root.left);
            PreOrderTree1(root.right);
        }

        void PostOrderTree1(TreeNode root)
        {
            if(root == null){return ;}
            PostOrderTree1(root.left);
            PostOrderTree1(root.right);
            visit(root);
        }
        

        void InOrderTree2(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            
            TreeNode p = root;
            while (stk.Count != 0 || p != null)
            {
                while (p != null)
                {
                    stk.Push(p);
                    p = p.left;
                }
                if (stk.Count != 0)
                {
                    p = stk.Pop();
                    visit(p);
                    p = p.right;
                }
            }
        }

        void PreOrderTree2(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode p = root;
            while (stk.Count != 0 || p != null)
            {
                if (p != null)
                {
                    visit(p);
                    stk.Push(p);
                    p = p.left;
                }
                if (stk.Count != 0)
                {
                    p = stk.Pop();
                    p = p.right;
                }
            }
        }

        void PostOrderTree2(TreeNode root)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode pre = null;
            TreeNode tmp = null;
            stk.Push(root);
            while (stk.Count != 0)
            {
                tmp = stk.First();
                if ((tmp.left == null && tmp.right == null) ||
                    (pre != null && (pre == tmp.left || pre == tmp.right)))
                {
                    tmp = stk.Pop();
                    visit(tmp);
                    pre = tmp;
                }
                else
                {
                    if (tmp.right != null) { stk.Push(tmp.right); }
                    if (tmp.left != null) { stk.Push(tmp.left); }
                }
            }
        }
        
        public void test()
        {
            int[] nums = new int[] { 1, 2, 2, -1, 3, -1, 3 }; //-1 is stand for null
            Queue<TreeNode> v = new Queue<TreeNode>();
            TreeNode root = new TreeNode(nums[0]);
            v.Enqueue(root);
            for (int i = 1; i < nums.Length; i+=2)
            {
                TreeNode tmp = v.Dequeue();
                if (i < nums.Length)
                {
                    if (nums[i] != -1)
                    {
                        tmp.left = new TreeNode(nums[i]);
                        v.Enqueue(tmp.left);
                    }
                    else
                    {
                        tmp.left = null;
                    }
                }
                if (i + 1 < nums.Length)
                {
                    if (nums[i+1] != -1)
                    {
                        tmp.right = new TreeNode(nums[i+1]);
                        v.Enqueue(tmp.right);
                    }
                    else
                    {
                        tmp.right = null;
                    }
                }
            }

            InOrderTree1(root);
            InOrderTree2(root);
        }
    }
}
