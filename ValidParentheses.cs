using System;
using System.Collections.Generic;

namespace leetcode
{
	public class ValidParentheses
	{
		public bool IsValid (string s)
		{
			Stack<char> stk = new Stack<char> ();
			int length = s.Length;

			for (int i = 0; i < length; i++) {
				if (stk.Count == 0 || s [i] == '(' || s [i] == '[' || s [i] == '{') {
					stk.Push (s [i]);
					continue;
				} else if (s [i] == ')' && stk.Peek () == '(') {
					stk.Pop ();
					continue;
				} else if (s [i] == ']' && stk.Peek () == '[') {
					stk.Pop ();
					continue;
				} else if (s [i] == '}' && stk.Peek () == '{') {
					stk.Pop ();
					continue;
				}
				return false;
			}

			if (stk.Count == 0) {
				return true;
			}
			return false;
		}
	}
}

