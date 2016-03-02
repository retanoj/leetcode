using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class MaxSubSequence
    {
        public int MaxSubSeq(int[] nums)
        {
            int MaxSum = 0;
            int NowSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                NowSum += nums[i];
                if (NowSum > MaxSum) { MaxSum = NowSum; }
                if (NowSum < 0) { NowSum = 0; }
            }
            return NowSum;
        }

        public int SubSeqSum(int[] nums, int l, int r)
        {
            if (l == r) { return nums[l] > 0 ? nums[l] : 0; }

            int mid = (l + r) / 2;
            int leftSum = SubSeqSum(nums, l, mid);
            int rightSum = SubSeqSum(nums, mid + 1, r);

            int lefts = 0, leftMax = 0;
            for (int i = mid; i >= l; i--)
            {
                lefts += nums[i];
                if (lefts > leftMax) { leftMax = lefts; }
            }

            int rights = 0, rightMax = 0;
            for (int i = mid + 1; i <= r; i++)
            {
                rights += nums[i];
                if (rights > rightMax) { rightMax = rights; }
            }

            int lrMax = leftMax + rightMax;
            if (leftSum > lrMax) { return leftSum; }
            if (rightSum > lrMax) { return rightSum; }
            return lrMax;
        }

        public int MaxSubSeq2(int[] nums)
        {
            return SubSeqSum(nums, 0, nums.Length - 1);
        }
    }
}
