using System;
using System.Collections.Generic;
namespace leetcode
{
	public class ZigZagConversion
	{
		public string Convert (string s, int numRows)
		{
			HashSet<int> nums = new HashSet<int> ();
			Queue<int> q = new Queue<int>();
			string res = "";

			//init
			int n = numRows * 2 - 2;
			if (n == 0) {
				return s;
			}
			for(int i=0; i<s.Length+n; i+= n){
				q.Enqueue(i);
				nums.Add(i);
			}

			while(q.Count != 0){
				int i = q.Dequeue();
				if (i < s.Length) {
					res += s [i];
				}

				//enqueue i-1 i+1
				if(i-1 >= 0 && nums.Contains(i-1) == false){
					q.Enqueue(i-1);
					nums.Add(i-1);
				}

				if(i+1 < s.Length && nums.Contains(i+1) == false){
					q.Enqueue(i+1);
					nums.Add(i+1);
				}
			}

			return res;
		}
	}
}

