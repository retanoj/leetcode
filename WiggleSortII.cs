using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class WiggleSortII
    {
        public void WiggleSort(int[] nums)
        {
            //对数组排序
            List<int> sortNums = nums.ToList();
            sortNums.Sort();
            sortNums.Reverse(); 

            // len|1 是为保证n是奇数，这样在i的循环下，产生1 3 5 0 2 4 的效果
            int i = 0, n = sortNums.Count | 1;
            foreach (int value in sortNums)
            {
                nums[(i++ * 2 + 1) % n] = value;
            }
        }
    }
}
