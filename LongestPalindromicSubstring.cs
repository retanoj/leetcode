using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            int length = s.Length;
            if (length < 2) { return s; }

            int start = 0, end = 0;
            int x = 0, maxLength = 0;
            for (int i = 0; i < length; i++)
            {
                //整体考虑连续相同的字符串
                start = end = i;
                while (i < length - 1 && s[i + 1] == s[i])
                {
                    i++;
                }
                end = i;

                //start|end向左右扩张寻找回文串
                while (start >= 0 && end < length && s[start] == s[end])
                {
                    start--; end++;
                }
                start++; end--;

                if (end - start + 1 > maxLength)
                {
                    maxLength = end - start + 1;
                    x = start;
                }
            }

            return s.Substring(x, maxLength);
        }
    }
}
