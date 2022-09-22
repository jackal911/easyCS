using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpinBracket
{
	class Program
	{
		public class Solution
		{
			public int solution(string s)
			{
				int n = 0;
				int count = 0;
				while (n < s.Length)
				{
					string str = s.Substring(n) + s.Substring(0, n);
					int countMid = 0;
					int countLarge = 0;
					int countSmall = 0;
					for (int i = 0; i < str.Length; i++)
					{
						if (str[i] == '}' || str[i] == ']' || str[i] == ')')
						{
							
						}
					}
				}
			}
		}
		static void Main(string[] args)
		{
		}
	}
}
