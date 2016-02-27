using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class TwoSumCls
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];

            if(nums.Length == 0 || nums.Length == 1){return result;}
            for (int i = 0; i < nums.Length; i++)
            {
                if(dict.ContainsKey(target-nums[i])){
                    result[0] = i;
                    result[1] = dict[target - nums[i]];
                    return result;
                }
                else
                {
                    if (dict.ContainsKey(nums[i]) == false)
                    {
                        dict.Add(nums[i], i);
                    }
                }
            }
            return result;
        }
    }
}
