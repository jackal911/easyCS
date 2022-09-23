using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightShift
{
	class Program
	{
		public class Solution
		{
			public long solution(int n, int[] works)
			{
				int workLength = works.Length;
				if (n >= works.Sum())
				{
					return 0;
				}
				while (n >= workLength)
				{
					double avg = works.Average();
					bool isChanged = false;
					for (int i = 0; i < workLength; i++)
					{
						if (works[i] > avg)
						{
							works[i]--;
							n--;
							isChanged = true;
						}
					}
					if (isChanged == false)
					{
						break;
					}
				}
				long[] longworks = works.Select(s => (long)(s - n / workLength)).ToArray();
				n -= (n / workLength) * workLength;
				for (int i = 0; i < n; i++)
				{
					longworks[i]--;
				}
				return longworks.Aggregate(0, (acc, val) => acc + val * val);

				while (n > 0)
				{

				}
				return 1;
// 				int workLength = works.Length;
// 				if (n >= works.Sum())
// 				{
// 					return 0;
// 				}
// 				while (n >= workLength)
// 				{
// 					double avg = works.Average();
// 					bool isChanged = false;
// 					for(int i=0;i<workLength;i++)
// 					{
// 						if (works[i] > avg)
// 						{
// 							works[i]--;
// 							n--;
// 							isChanged = true;
// 						}
// 					}
// 					if (isChanged==false)
// 					{
// 						break;
// 					}
// 				}
// 				works = works.Select(s => s - n / workLength).ToArray();
// 				n -= (n / workLength) * workLength;
// 				for (int i = 0; i < n; i++)
// 				{
// 					works[i]--;
// 				}
// 				return works.Aggregate(0, (acc, val) => acc + val * val);
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] works = { 150, 40, 3 };
			int n = 170;
			Console.WriteLine(s.solution(n, works));
		}
	}
}
