using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carpet
{
	// 카펫 - https://school.programmers.co.kr/learn/courses/30/lessons/42842
	class Program
	{
		public class Solution
		{
			public int[] solution(int brown, int yellow)
			{
				List<int[]> DynamicDuo = new List<int[]>();
				for (int i = 1; i <= Math.Sqrt(yellow); i++)
				{
					if (yellow % i == 0)
					{
						DynamicDuo.Add(new int[] { yellow / i + 2, i + 2 });
					}
				}
				foreach (int[] duo in DynamicDuo)
				{
					if ((duo[0] + duo[1]) * 2 - 4 == brown)
					{
						return duo;
					}
				}
				return null;
			}
		}
		static void Main(string[] args)
		{
		}
	}
}
