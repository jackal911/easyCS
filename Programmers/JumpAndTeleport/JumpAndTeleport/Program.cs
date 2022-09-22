using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpAndTeleport
{
	class Program
	{
		class Solution
		{
			public int solution(int n)
			{
				int count = 0;
				while (n > 0)
				{
					if (n % 2 == 0)
					{
						n /= 2;
					}
					else
					{
						n -= 1;
						count++;
					}
				}
				return count;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution(999999));
		}
	}
}
