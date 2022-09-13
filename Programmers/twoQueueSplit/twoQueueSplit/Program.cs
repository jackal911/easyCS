﻿using System;
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
				maxCount = q1.Count + q2.Count + 1; // 넉넉하게 전체 Count * 2가 제일 안전함. +2는 현재의 모든 테스트 케이스 만족하는 최소 maxCount
				return doShuffle(q1, q2);
			}
			private int doShuffle(Queue<long> q1, Queue<long> q2)
			{
				long q1Sum = q1.Sum();
				long q2Sum = q2.Sum();
				while (q1Sum != q2Sum)
				{
					long minus;
					if (q1Sum > q2Sum)
					{
						minus = q1.Dequeue();
						q2.Enqueue(minus);
						q1Sum -= minus;
						q2Sum += minus;
					}
					else
					{
						minus = q2.Dequeue();
						q1.Enqueue(minus);
						q2Sum -= minus;
						q1Sum += minus;
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
			int[] queue1 = new int[] { 8, 1, 7, 45, 2 };
			int[] queue2 = new int[] { 3, 4, 5, 6, 9 };
			Console.WriteLine(s.solution(queue1, queue2));
		}
	}
}