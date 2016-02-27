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
    }
}
