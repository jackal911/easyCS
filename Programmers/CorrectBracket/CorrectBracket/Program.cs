using System;
using System.Linq;

namespace CorrectBracket
{
	// 올바른 괄호 - https://school.programmers.co.kr/learn/courses/30/lessons/12909
	class Program
	{
		public class Solution
		{
			public bool solution(string s)
			{
				int openClose = 0;
				foreach (char ch in s)
				{
					openClose = ch == '(' ? openClose + 1 : openClose - 1;
					if (openClose < 0)
					{
						return false;
					}
				}				
				return openClose == 0 ? true : false;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			string str = "(())()";
			Console.WriteLine(s.solution(str));
		}
	}
}
