using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            int length = nums.Length;
            k %= length;
            int[] tail = new int[k];
            for (int i = 0; i < k; i++)
            {
                tail[i] = nums[length - k + i];
            }
            for (int i = length - 1 - k; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }
            for (int i = 0; i < k; i++)
            {
                nums[i] = tail[i];
            }
        }
    }
}
