using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class FindtheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {
            int length = nums.Length;
            int low = 0, high = length - 1;

            while (low < high)
            {
                int count = 0;
                int mid = ( low + high ) / 2;
                foreach (int n in nums)
                {
                    if (mid < n && n <= high) { count++; }
                }

                if (count > high - mid ) { low = mid + 1; }
                else { high = mid; }
            }

            return high;
        }
    }
}
