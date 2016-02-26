using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class QuickSort
    {
        public void qsort(int[] nums, int left, int right)
        {
            if (left >= right) { return; }

            int l = left, r = right;
            int key = nums[l];

            while (l < r)
            {
                while (l < r && key <= nums[r]) { r--; }
                nums[l] = nums[r];

                while (l < r && key >= nums[l]) { l++; }
                nums[r] = nums[l];
            }
            nums[l] = key;
            qsort(nums, left, l - 1);
            qsort(nums, l + 1, right);
        }
    }
}
