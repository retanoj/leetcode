using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class UglyNumberII
    {
        public int NthUglyNumber(int n)
        {
            int l2, l3, l5;
            int count;
            int[] ugly = new int[n];

            l2 = l3 = l5 = 0;
            ugly[0] = 1;
            count = 1;
            while (count < n)
            {
                int next = Math.Min(2 * ugly[l2], Math.Min(3 * ugly[l3], 5 * ugly[l5]));
                ugly[count++] = next;
                if (2 * ugly[l2] == next) l2++;
                if (3 * ugly[l3] == next) l3++;
                if (5 * ugly[l5] == next) l5++;
            }
            return ugly[n - 1];
        }
    }
}
