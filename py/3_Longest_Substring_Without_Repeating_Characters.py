# coding:utf-8

class Solution(object):
    def lengthOfLongestSubstring(self, s):
        """
        :type s: str
        :rtype: int
        """
        s_dict = {}
        pre = 0
        ans = 0
        for suf in xrange(len(s)):
            if s[suf] in s_dict:
                pre = (s_dict[s[suf]] + 1) if (s_dict[s[suf]] + 1) > pre else pre
            ans = (suf - pre + 1) if (suf - pre + 1) > ans else ans
            s_dict[s[suf]] = suf

        return ans
