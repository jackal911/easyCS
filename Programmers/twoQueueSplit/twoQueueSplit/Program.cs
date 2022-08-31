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
 			private int shuffleCount = 0;
 			private long maxCount;
			private Queue<long> q1;
			private Queue<long> q2;
			public int solution(int[] queue1, int[] queue2)
			{
				q1 = new Queue<long>(Array.ConvertAll(queue1, s => (long)s));
				q2 = new Queue<long>(Array.ConvertAll(queue2, s => (long)s));
				maxCount = q1.Count + q2.Count;
				return doShuffle(q1, q2);
			}
			private int doShuffle(Queue<long> q1, Queue<long> q2)
			{
				while (q1.Sum() != q2.Sum())
				{
					if (q1.Sum() > q2.Sum())
					{
						q2.Enqueue(q1.Dequeue());
					}
					else
					{
						q1.Enqueue(q2.Dequeue());
					}
					shuffleCount++;
					if (shuffleCount > maxCount)
					{
						return -1;
					}
				}
				return shuffleCount;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] queue1 = new int[] { 1, 1 };
			int[] queue2 = new int[] { 1, 5 };
			Console.WriteLine(s.solution(queue1, queue2));
		}
	}
}
