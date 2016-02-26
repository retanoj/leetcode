using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            int y = 0;
            int devx = 1;
            //从右往左取x的每一位数放入y
            //devx是当取到一半长度时会停止
            //大于0是防止x为负数
            while(x / devx > 0){
                y = y * 10 + x % 10;
                x /= 10;
                devx *= 10;
            }

            if (x * 10 > y) { return y == x; }
            else { return y / 10 == x; }
        }
    }
}
