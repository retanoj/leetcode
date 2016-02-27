using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0,0,1,0,0,1};
            SortColorsCls s = new SortColorsCls();
            s.SortColors(nums);
            foreach (int n in nums)
            {
                Console.WriteLine(n);
            }
        }
    }
}
