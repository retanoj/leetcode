using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    class MoveZeroesCls
    {
        //从from起找首次出现零的位置
        public int findZero(int[] nums, int from)
        {
            int to = from;
            while (to < nums.Length && nums[to] != 0) { to++; }
            return to;
        }
        //从from起找首次非零位置
        public int findNoneZero(int[] nums, int from)
        {
            int to = from;
            while (to < nums.Length && nums[to] == 0 ) { to++; }
            return to;
        }

        public void swap(int[] nums, int a, int b)
        {
            int c = nums[a];
            nums[a] = nums[b];
            nums[b] = c;
        }

        public void MoveZeroes(int[] nums)
        {
            int len = nums.Length;
            int zeroPnt = 0;
            int realNumPnt = 0;

            zeroPnt = findZero(nums, 0);
            realNumPnt = findNoneZero(nums, zeroPnt);

            while (realNumPnt < len)
            {
                swap(nums, zeroPnt, realNumPnt);
                zeroPnt = findZero(nums, zeroPnt);
                realNumPnt = findNoneZero(nums, realNumPnt);
            }

        }

        public void MoveZeroes2(int[] nums)
        {
            int pos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0) { nums[pos++] = nums[i]; }
            }
            while (pos < nums.Length) { nums[pos++] = 0; }
        }
    }
}
