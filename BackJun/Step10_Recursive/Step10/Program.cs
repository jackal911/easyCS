using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step10 - 재귀 https://www.acmicpc.net/step/19

namespace Step10_Recursive
{
	class Program
	{
		// Q10872 - 팩토리얼
		static int facto(int n)
		{
			if (n < 2)
			{
				return 1;
			}
			else
			{
				return n * facto(n - 1);
			}
		}
		// Q10870 - 피보나치 수 5
		static int pibo(int n)
		{
			if (n == 0)
				return 0;
			else if (n == 1)
				return 1;
			else
				return pibo(n - 1) + pibo(n - 2);
		}
		// Q25501 - 재귀의 귀재 https://www.acmicpc.net/problem/25501
		class GOSUOfRecursion
		{
			public int callCount = 0;
			private int recursion(string str, int head, int tail)
			{
				callCount++;
				if (head >= tail) return 1;
				else if (str[head] != str[tail]) return 0;
				else return recursion(str, head + 1, tail - 1);
			}
			public int isPalindrome(string str)
			{
				return recursion(str, 0, str.Length - 1);
			}
		}

		// Q24060 - 알고리즘 수업 - 병합 정렬 1 https://www.acmicpc.net/problem/24060
		class MergeSort
		{
			public int[] A;
			public int[] tmp;
			public int countSave;
			public int limit;
			public MergeSort(int[] A, int limit)
			{
				this.A = A;
				this.tmp = new int[A.Length];
				this.countSave = 0;
				this.limit = limit;
			}

			public void printA()
			{
				foreach (int a in A)
				{
					Console.Write(a + " ");
				}
				Console.WriteLine();
			}

			public void merge_sort(int p, int r)
			{
				if (p < r)
				{
					int q = (p + r) / 2;
					merge_sort(p, q);
					merge_sort(q + 1, r);
					merge(p, q, r);
				}
			}

			private void merge(int p, int q, int r)
			{
				int i = p;
				int j = q + 1;
				int t = 0;
				while (i <= q && j <= r)
				{
					if (A[i] <= A[j])
					{
						tmp[t++] = A[i++];
					}
					else
					{
						tmp[t++] = A[j++];
					}
				}
				while (i <= q)
				{
					tmp[t++] = A[i++];
				}
				while (j <= r)
				{
					tmp[t++] = A[j++];
				}
				i = p;
				t = 0;
				while (i <= r)
				{
					A[i++] = tmp[t++];
					if (++countSave == limit)
					{
						Console.WriteLine(A[i-1]);
						Environment.Exit(0);
					}
					//printA();
				}
			}
		}
		
		// Q17478 - 재귀함수가 뭔가요?
		static void whatIsRecursiveFunction(int n, int i = 0)
		{
			string bar = new String('_', 4 * i);
			Console.WriteLine(@"{0}""재귀함수가 뭔가요?""", bar);

			if (n > 0)
			{
				Console.WriteLine(@"{0}""잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.
{0}마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.
{0}그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.""", bar);
				whatIsRecursiveFunction(n - 1, i + 1);
			}
			else
			{
				Console.WriteLine(@"{0}""재귀함수는 자기 자신을 호출하는 함수라네""", bar);
			}
			Console.WriteLine(@"{0}라고 답변하였지.", bar);

		}
		// Q2447 - 별 찍기 - 10
		static List<string> drawStar(int n)
		{
			if (n == 1)
				return new List<string>() { "*" };

			List<string> stars = drawStar(n / 3);
			List<string> L = new List<string>();

			foreach (string star in stars)
				L.Add(String.Join("", Enumerable.Repeat(star, 3)));
			foreach (string star in stars)
				L.Add(star + String.Join("", Enumerable.Repeat(" ", n / 3)) + star);
			foreach (string star in stars)
				L.Add(String.Join("", Enumerable.Repeat(star, 3)));

			return L;
		}

		// Q11729 - 하노이 탑 이동 순서
		static List<string> move(int n, int start, int end)
		{
			List<string> moves = new List<string>();
			if (n == 1)
			{
				moves.Add(String.Format("{0} {1}", start, end));
				return moves;
			}
			moves.AddRange(move(n - 1, start, 6 - end - start));
			moves.AddRange(move(1, start, end));
			moves.AddRange(move(n - 1, 6 - end - start, end));

			return moves;
		}
		static void Main(string[] args)
		{
			// Q10872 - 팩토리얼
			/*
			Console.WriteLine(facto(int.Parse(Console.ReadLine())));
            
			// Q10870 - 피보나치 수 5
			Console.WriteLine(pibo(int.Parse(Console.ReadLine())));
			
			// Q25501 - 재귀의 귀재 https://www.acmicpc.net/problem/25501
			int T = int.Parse(Console.ReadLine());
			for (int i = 0; i < T; i++)
			{
				string str = Console.ReadLine();
				GOSUOfRecursion gosu = new GOSUOfRecursion();
				Console.WriteLine("{0} {1}", gosu.isPalindrome(str), gosu.callCount);
			}
			*/
			// Q24060 - 알고리즘 수업 - 병합 정렬 1 https://www.acmicpc.net/problem/24060
			int[] AK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			MergeSort ms = new MergeSort(A, AK[1]);
			ms.merge_sort(0, AK[0] - 1);
			Console.WriteLine(-1);
			//ms.printA();
			
            /*
			// Q17478 - 재귀함수가 뭔가요?
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
			whatIsRecursiveFunction(n);
            
			// Q2447 - 별 찍기 - 10
			Console.WriteLine(String.Join("\n", drawStar(int.Parse(Console.ReadLine()))));
			
			// Q11729 - 하노이 탑 이동 순서
			int N = int.Parse(Console.ReadLine());
			Console.WriteLine((int)Math.Pow((double)2, (double)N) - 1);
			Console.WriteLine(String.Join("\n", move(N, 1, 3)));
			*/
		}
	}
}