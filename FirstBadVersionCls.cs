using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class FirstBadVersionCls
    {
        public bool IsBadVersion(int m)
        {
            int[] nums = new int[] { 0, 0, 0, 0, 0 };
            return 1 == nums[m];
        }
        public int FirstBadVersion(int n)
        {
            int x = 1;
            int y = n;
            while (x < y)
            {
                int m = x + (y - x) / 2;
                if (IsBadVersion(m) == true)
                {
                    y = m;
                }
                else if (IsBadVersion(m) == false)
                {
                    x = m + 1;
                }
            }
            
            return y;
        }
    }
}
