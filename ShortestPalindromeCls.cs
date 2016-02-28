using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class ShortestPalindromeCls
    {
        bool isEqual(string s1, int begin1, string s2, int begin2, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (s1[begin1++] != s2[begin2++]) { return false; }
            }
            return true;
        }

        public string ShortestPalindrome(string s)
        {
            int length = s.Length;
            char[] arr = new char[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = s[length - 1 - i];
            }
            string revs = new String(arr);
            
            //eg.
            //      abcde
            //      edcba
            //      ^^^
            //     edcba
            //      ^^
            //    edcba
            //      ^^
            //   edcba
            //      ^
            //  edcba
            //      ^

            for (int i = 0; i < s.Length; i++)
            {
                if( isEqual(s, 0, revs, i, (length - i + 1) / 2 ) )
                {
                    return revs.Substring(0, i) + s;
                }
            }
            return s == "" ? s : revs.Substring(0, revs.Length - 1);
        }
    }
}
