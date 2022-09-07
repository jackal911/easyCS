using System;
using System.Collections.Generic;
using System.Linq;

namespace twoQueueSplit
{
	class Program
	{
		public class Solution
		{
			public int solution(int[] first, int[] second)
			{
				List<long> firstQueue = first.ToList().ConvertAll(s => (long)s);
				List<long> secondQueue = second.ToList().ConvertAll(s => (long)s);
				List<long> totalQueue = first.Concat(second).ToList().ConvertAll(s => (long)s);
				int firstCount = first.Length;
				int secondCount = second.Length;

				int minCount = int.MaxValue;
				long totalSum = totalQueue.Sum();
				if (totalSum % 2 == 1)
				{
					return -1;
				}
				else if (totalSum / 2 == firstQueue.Sum())
				{
					return 0;
				}
				long halfSum = totalSum / 2;
				for (int i = 0; i < totalQueue.Count; i++)
				{
					int cycleIndex = i;
					long curSum = 0;
					for (int j = 0; j < totalQueue.Count; j++, cycleIndex = cycleIndex == totalQueue.Count - 1 ? 0 : cycleIndex + 1)
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
					if (endPoint == firstCount - 1)
					{
						return startPoint;
					}
					else
					{
						return ((endPoint + 1) + secondCount + startPoint);
					}
				}
				else
				{
					return startPoint + (endPoint - firstCount + 1);
				}
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] queue1 = new int[] { 1, 2, 20, 51, 5, 6 };
			int[] queue2 = new int[] { 7, 8, 9, 10, 11, 12};
// 			int[] queue1 = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
// 			int[] queue2 = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
			Console.WriteLine(s.solution(queue1, queue2));
		}
	}
}
