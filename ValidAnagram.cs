using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) { return false; }
            
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int length = s.Length;
            
            for (int i = 0; i < length; i++)
            {
                if (dict.ContainsKey(s[i])) { dict[s[i]]++; }
                else { dict.Add(s[i], 1); }

                if (dict.ContainsKey(t[i])) { dict[t[i]]--; }
                else { dict.Add(t[i], -1); }
            }
            foreach (var item in dict)
            {
                if (item.Value != 0) { return false; }
            }
            return true;
        }
    }
}
