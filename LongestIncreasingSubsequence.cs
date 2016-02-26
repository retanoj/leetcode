using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class LongestIncreasingSubsequence
    {
        int lower_bound(List<int> nums, int l, int r, int goal)
        {
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] >= goal) { r = mid; }
                else { l = mid + 1; }
            }
            return l;
        }
        public int LengthOfLIS(int[] nums)
        {
            List<int> result = new List<int>();
            
            foreach (int n in nums)
            {
                if (result.Count == 0 || n > result[result.Count - 1]) { result.Add(n); }
                else {
                    int index = lower_bound(result, 0, result.Count, n);
                    result[index] = n;
                }
            }
            return result.Count;
        }
    }
}
