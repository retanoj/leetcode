using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class RangeSumQuery_Immutable
    {
        int[] segTree;
        int numsLength = 0;
        public void NumArray(int[] nums) {
            numsLength = nums.Length;
            segTree = new int[numsLength * 4 + 10];
            
            build(1, 0, numsLength-1, nums);
        }

        void build(int node, int begin, int end, int[] nums)
        {
            if (begin > end){
                return;
            }else if (begin == end){
                segTree[node] = nums[begin];
            }else{
                build(node * 2, begin, (begin + end) / 2, nums);
                build(node * 2 + 1, (begin + end) / 2 + 1, end, nums);

                segTree[node] = segTree[node * 2] + segTree[node * 2 + 1];
            }
        }

        public int SumRange(int i, int j) {
            return query(1, 0, numsLength - 1, i, j);

        }
        int query(int node, int begin, int end, int left, int right)
        {
            if (left > end || right < begin) { return 0; }

            if (left <= begin && end <= right) { return segTree[node]; }

            int p1 = query(node * 2, begin, (begin + end) / 2, left, right);
            int p2 = query(node * 2 + 1, (begin + end) / 2 + 1, end, left, right);

            return p1 + p2;
        }
    }
}
