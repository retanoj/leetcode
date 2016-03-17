using System;

namespace leetcode
{
	public class LongestCommonPrefixCls
	{
		public string LongestCommonPrefix (string[] strs)
		{
			int strs_num = strs.GetLength (0);
			if(strs_num == 0) {return "";}

			string prefix = strs[0];
			for (int i = 1; i < strs_num; i++) {
				string tmp = "";
				int p = 0;
				while (p < strs[i].Length && p < prefix.Length && prefix [p] == strs [i] [p]) {
					tmp += prefix [p];
					p++;
				}
				prefix = tmp;
			}

			return prefix;
		}
	}
}

