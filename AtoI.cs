using System;

namespace leetcode
{
	public class AtoI
	{
		bool isNumeric(char c){
			return c >= '0' && c <= '9';
		}
		public int MyAtoi(string str) {
			str = str.Trim ();
			if (str == "") {
				return 0;
			}

			long res = 0;
			int p = 0;
			int length = str.Length;
			bool isNegative = false;
			if (str [0] == '+' || str [0] == '-') {
				if (str [0] == '-') {
					isNegative = true;
				}
				p = 1;
			}

			for (; p < length; p++) {
				if (isNumeric (str[p]) == false) {
					break;
				}
				res *= 10;
				res += str [p] - '0';

				if (isNegative) {
					if (-res < Int32.MinValue) {
						return Int32.MinValue;
					}
				} else {
					if (res > Int32.MaxValue) {
						return Int32.MaxValue;
					} 
				}
			}
			return (int)(isNegative ? -res : res);
		}
	}
}

