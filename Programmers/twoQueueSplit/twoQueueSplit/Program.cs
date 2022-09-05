using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace twoQueueSplit
{
	class Program
	{
		public class Solution
		{
			public int solution(long[] first, long[] second)
			{
				List<long> totalQueue = first.Union(second).ToList();				
				int firstCount = first.Length;
				int secondCount = second.Length;
				int minCount = int.MaxValue;
				long totalSum = totalQueue.Sum();
				if (totalSum % 2 == 1)
				{
					return -1;
				}
				long halfSum = totalSum / 2;
				for (int i = 0; i < totalQueue.Count; i++)
				{
					int cycleIndex = i;
					long curSum = 0;					
					for (int j = 0; j < totalQueue.Count; j++)
					{
						curSum += totalQueue[cycleIndex];
						if (curSum > halfSum)
						{
							break;
						}
						else if (curSum == halfSum)
						{
							minCount = Math.Min(minCount, calCount(i, cycleIndex, firstCount, secondCount));
							break;
						}
						else
						{
							cycleIndex = cycleIndex == totalQueue.Count - 1 ? 0 : cycleIndex + 1;
						}
					}
				}
				return minCount == int.MaxValue ? -1 : minCount;
			}
			private int calCount(int startPoint, int endPoint, int firstCount, int secondCount)
			{
				int totalCount = firstCount + secondCount;
				if (startPoint >= firstCount)
				{
					startPoint = startPoint - firstCount;
					endPoint = (endPoint - firstCount + totalCount) % totalCount;
					int temp = firstCount;
					firstCount = secondCount;
					secondCount = temp;					
				}
				if (endPoint < firstCount)
				{
					return ((endPoint + 1) + secondCount + startPoint) % totalCount;
				}
				else
				{
					return ((endPoint + 1) + secondCount + startPoint + (endPoint - firstCount + 1)) % totalCount;
				}
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			long[] queue1 = new long[] { 1, 2, 3, 4, 5, 6, 7 };
			long[] queue2 = new long[] { 10, 11, 12, 13, 14 };
			Console.WriteLine(s.solution(queue1, queue2));
		}
	}
}
