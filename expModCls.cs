using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class expModCls
    {
        // calculate x^y % k
        //快速幂取模
        //即x^7 = x^4 * x^2 * x^1
        public int expMod(int x, int y, int k)
        {
            const uint mask = 0xffffffff;
            int tx = x % k;
            int res = 1;

            while ((y & mask) != 0)
            {
                if ((y & 1) == 1) { res = res * tx % k; }
                y >>= 1;
                tx = tx * tx % k;
            }
            return res;
        }
    }
}
