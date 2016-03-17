using System;
using System.Collections.Generic; 

namespace leetcode
{
	public class IsIsomorphicCls
	{
		public bool IsIsomorphic (string s, string t)
		{
			int length = s.Length;
			Dictionary<char, char> dict = new Dictionary<char, char> ();

			for (int i = 0; i < length; i++) {
				if (dict.ContainsKey (s [i]) == true && dict [s [i]] != t [i]) {
					return false;
				} else if (dict.ContainsKey (s [i]) == false && dict.ContainsValue(t[i]) == true) {
					return false;
				} else {
					if (dict.ContainsKey (s [i]) == false) {
						dict.Add (s [i], t [i]);
					}
				}
			}
			return true;
		}
	}
}

