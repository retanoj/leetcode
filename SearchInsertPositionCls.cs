using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class SearchInsertPositionCls
    {
        public int SearchInsert(int[] nums, int target)
        {
            int x, y, m;
            x = 0;
            y = nums.Count();  

            while (x < y)
            {
                m = x + (y - x) / 2;
                if (nums[m] == target) { return m; }
                else if (nums[m] > target) { y = m; }
                else { x = m + 1; }
            }
            return y;
        }
    }
}
