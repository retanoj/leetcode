using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class BinarySearchCls
    {
        //init x=0, y=nums.Length

        //返回第一个出现的位置，或应插入的位置
        public int binSearch_lowerBound(int[] nums, int goal, int x, int y)
        {
            while(x < y)
            {
                int mid = x + (y - x) / 2;
                if (goal <= nums[mid]) { y = mid; }
                else { x = mid + 1; }
            }
            return x;
        }
        //返回最后出现位置的后一个位置，或应插入的位置
        public int binSearch_upperBound(int[] nums, int goal, int x, int y)
        {
            while (x < y)
            {
                int mid = x + (y - x) / 2;
                if (goal < nums[mid]) { y = mid; }
                else { x = mid + 1; }
            }
            return x;
        }

        public int binSearch(int[] nums, int goal, int x, int y)
        {
            while(x<y)
            {
                int mid = x + (y - x) / 2;
                if (goal == nums[mid]) { return mid; }
                else if (goal < nums[mid]) { y = mid; }
                else { x = mid + 1; }
            }
            return -1;
        }
    }
}
