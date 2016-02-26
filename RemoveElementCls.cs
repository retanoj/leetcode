using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    class RemoveElementCls
    {
        public int RemoveElement(int[] nums, int val)
        {
            int pos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val) { nums[pos++] = nums[i]; }
            }
            return pos;
        }
    }
}
