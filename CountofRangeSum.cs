using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class CountofRangeSum
    {
        public class TreeNode
        {
            public Int64 val;
            public int treeSize;
            public TreeNode left = null;
            public TreeNode right = null;
            public TreeNode(Int64 x) { 
                val = x;
                treeSize = 1;
            }
        }
        Int64[] buildPrefixSum(int[] nums)
        {
            Int64[] res = new Int64[nums.Length + 1];
            res[0] = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res[i + 1] = res[i] + nums[i];
            }
            return res;
        }
        
        TreeNode InsertBinarySearchTree(TreeNode root, Int64 val)
        {
            if (root == null)
            {
                root = new TreeNode(val);
                return root;
            }
            if (root.val < val)
            {
                root.right = InsertBinarySearchTree(root.right, val);
            }
            else if (root.val > val)
            {
                root.left = InsertBinarySearchTree(root.left, val);
            }
            root.treeSize++;
            return root;
        }

        int countGE(TreeNode root, Int64 val)
        {
            TreeNode ptr = root;
            int count = 0;
            while (ptr != null)
            {
                if (val > ptr.val)
                {
                    ptr = ptr.right;
                }
                else if (val < ptr.val)
                {
                    count += ptr.treeSize;
                    count -= ptr.left == null ? 0 : ptr.left.treeSize;
                    ptr = ptr.left;
                }
                else
                {
                    count += ptr.treeSize;
                    count -= ptr.left == null ? 0 : ptr.left.treeSize;
                    break;
                }
            }

            return count;
        }

        int boundCount(TreeNode root, Int64 lower, Int64 upper)
        {
            return countGE(root, lower) - countGE(root, upper);
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int length = nums.Length;
            if (length == 0) { return 0; }

            Int64[] preSum = buildPrefixSum(nums);

            TreeNode root = null;
            int count = 0;
            for (int i = length; i >= 1; i--)
            {
                root = InsertBinarySearchTree(root, preSum[i]);
                count += boundCount(root,
                                    preSum[i - 1] + lower,
                                    preSum[i - 1] + upper + 1);
            }

            return count;
        }
    }
}
