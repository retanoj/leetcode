using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            int min = int.MinValue;
            int mid = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (mid != int.MinValue && nums[i] > mid) { return true; }
                if (min != int.MinValue && nums[i] > min) { mid = nums[i]; }
                if (min == int.MinValue || nums[i] < min) { min = nums[i]; }
            }

            return false;
        }
    }
}
