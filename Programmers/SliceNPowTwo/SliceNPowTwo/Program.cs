using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SliceNPowTwo
{
	class Program
	{
		public class Solution
		{
			public int[] solution(int n, long left, long right)
			{
				int[] answer = new int[right - left + 1];
				for (long i = left; i <= right; i++)
				{
					long row = i / n;
					long col = i % n;
					answer[i - left] = (int)Math.Max(row, col) + 1;
				}
				return answer;
			}
		}
		static void Main(string[] args)
		{
		}
	}
}
