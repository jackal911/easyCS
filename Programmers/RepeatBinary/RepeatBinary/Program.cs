using System;
using System.Linq;

namespace RepeatBinary
{
	// 이진 변환 반복하기 - https://school.programmers.co.kr/learn/courses/30/lessons/70129
	class Program
	{
		public class Solution
		{
			public int[] solution(string s)
			{
				int zeroCount = 0;
				int convertCount = 0;
				while (s != "1")
				{
					zeroCount += s.Count(x => x == '0');
					int countOne = s.Count(x => x == '1');
					s = Convert.ToString(countOne, 2);
					convertCount++;
				}
				return new int[] { convertCount, zeroCount };
			}
		}
		static void Main(string[] args)
		{
			Solution sol = new Solution();
			string s = "110010101001";
			int[] result = sol.solution(s);			
			Console.WriteLine("[{0},{1}]", result[0], result[1]);
		}
	}
}
