using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class SortColorsCls
    {
        public void SortColors(int[] nums)
        {
            int zerop = 0, onep = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[zerop++] = 0;

                    //填充0后，指针1在指针0的后面，则同步
                    if (onep < zerop) { onep = zerop; }
                    //填充0后，指针1不在指针0的后面，则填充的0覆盖了原有的1，则指针1向前补一位
                    else { nums[onep++] = 1; }
                }
                else if (nums[i] == 1)
                {
                    nums[onep++] = 1;
                }
            }

            //后续填充2
            for (int i = onep; i < nums.Length;)
            {
                nums[i++] = 2;
            }
        }
    }
}
