using System;

namespace leetcode
{
	public class CountAndSayCls
	{
		public string CountAndSay(int n) {
			string res = "1";
			string tmp = null;
			while(n > 1){
				tmp = "";
				for(int i=0; i<res.Length;){
					int cnt = 1;
					while(i+cnt < res.Length && res[i+cnt] == res[i]){
						cnt++;
					}
					tmp += Convert.ToString(cnt) + res[i];
					i += cnt;
				}
				res = tmp;
				n--;
			}
			return res;
		}
	}
}

