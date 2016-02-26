using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class PatchingArrayCls
    {
        public int MinPatches(int[] nums, int n)
        {
            //利用[1,known_sum) 表示已知连续和序列
            //if nums[i] > known_sum，那么添加known_sum以扩充区间为[1, known_sum * 2 )
            //if nums[i] <= known_sum，那么利用nums[i]以扩充区间[1, known_sum + nums[i] )

            int patchNum = 0;
            int i = 0;
            for (long known_sum = 1; known_sum <= n; ) //坑点，< n+1可能溢出，要用<= n
            {
                if (i < nums.Count() && nums[i] <= known_sum) { known_sum += nums[i]; i++; }
                else { known_sum <<= 1; patchNum++; }
            }

            return patchNum;
        }
    }
}
