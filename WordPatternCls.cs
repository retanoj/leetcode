using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class WordPatternCls
    {
        public bool WordPattern(string pattern, string str)
        {
            if (pattern.Length != str.Split(' ').Length) { return false; }
            string[] lStr = str.Split(' ');
            for (int i = 0; i < pattern.Length; i++)
            {
                for (int j = i + 1; j < pattern.Length; j++)
                {
                    if (pattern[i] == pattern[j] && lStr[i] != lStr[j]) { return false; }
                    else
                    {
                        if (pattern[i] != pattern[j] && lStr[i] == lStr[j]) { return false; }
                    }

                }
            }
            return true;
        }

        public bool WordPattern2(string pattern, string str)
        {
            if (pattern.Length != str.Split(' ').Length) { return false; }
            Dictionary<char, string> dict = new Dictionary<char, string>();
            string[] lStr = str.Split(' ');

            for (int i = 0; i < pattern.Length; i++)
            {
                if (dict.ContainsKey(pattern[i]))
                {
                    if (dict[pattern[i]] != lStr[i]) { return false; }
                }
                else
                {
                    if(dict.ContainsValue(lStr[i])){ return false; }
                }
                dict[pattern[i]] = lStr[i];
            }

                return true;
        }
    }
}
