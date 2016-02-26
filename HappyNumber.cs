using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class HappyNumber
    {
        int square_sum(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }
            return sum;
        }
        public bool IsHappy(int n)
        {
            HashSet<int> s = new HashSet<int>();
            if (n <= 0) { return false; }

            s.Add(n);
            while (n != 1)
            {
                n = square_sum(n);

                if (s.Contains(n)) { return false; }

                s.Add(n);
            }
            return true;
        }
    }
}
