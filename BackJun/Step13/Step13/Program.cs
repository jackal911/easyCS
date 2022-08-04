using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step13
{
    class Program
    {
        static void Main(string[] args)
        {
			/*
            // Q1085 - 직사각형에서 탈출
            List<int> xywh = Console.ReadLine().Split().ToList().ConvertAll(s => int.Parse(s));
            Console.WriteLine(Math.Min(Math.Min(xywh[0], xywh[2] - xywh[0]), Math.Min(xywh[1], xywh[3] - xywh[1])));
            
            // Q3009 - 네번째 점
            List<int> xs = new List<int>();
            List<int> ys = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> inp = Console.ReadLine().Split().ToList().ConvertAll(s => int.Parse(s));
                if (xs.Contains(inp[0]))
                {
                    xs.Remove(inp[0]);
                }
                else
                {
                    xs.Add(inp[0]);
                }
                if (ys.Contains(inp[1]))
                {
                    ys.Remove(inp[1]);
                }
                else
                {
                    ys.Add(inp[1]);
                }
            }
            Console.WriteLine("{0} {1}", xs[0], ys[0]);
            
            for (string inp; (inp = Console.ReadLine()) != "0 0 0"; )
            {
                int[] nums = Array.ConvertAll(inp.Split(), s => int.Parse(s));
                Array.Sort(nums);
                if (Math.Pow(nums[0], 2) + Math.Pow(nums[1], 2) == Math.Pow(nums[2], 2))
                {
                    Console.WriteLine("right");
                }
                else
                {
                    Console.WriteLine("wrong");
                }
            }
            
            // Q2477 - 참외밭
            int k = int.Parse(Console.ReadLine());
            int ewMax = 0;
            int snMax = 0;
            int smallSquare = 0;
            int[] pattern = { 4, 2, 3, 1, 4 }; // 첫원소와 끝원소를 잇기위해
            int[][] allSave = new int[7][];
            for (int i = 0; i < 6; i++)
            {
                int[] inp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                allSave[i] = new int[2]{inp[0], inp[1]};
                if (i == 0)
                {
                    allSave[6] = allSave[0]; // 첫원소와 끝원소를 잇기위해
                }

                if (inp[0] == 1 || inp[0] == 2)
                {
                    ewMax = Math.Max(inp[1], ewMax);
                }
                else
                {
                    snMax = Math.Max(inp[1], snMax);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int curSide = Array.IndexOf(pattern, allSave[i][0]);
                int shouldNextSide = pattern[curSide+1];
                if (shouldNextSide != allSave[i+1][0])
                {
                    smallSquare = allSave[i][1] * allSave[i+1][1] * k;
                }
            }
            Console.WriteLine(ewMax * snMax * k - smallSquare);
            
            int R = int.Parse(Console.ReadLine());
            Console.WriteLine("{0:F6}", R * R * Math.PI);
            Console.WriteLine("{0:F6}", 4 * R * R / 2);
            */
            // Q1002 - 터렛
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                double[] inp = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
                double[] bigCircle = new double[3];
                double[] smallCircle = new double[3];
                if (inp[2] >= inp[5])
                {
                    Array.Copy(inp, bigCircle, 3);
                    Array.Copy(inp, 3, smallCircle, 0, 3);
                }
                else
                {
                    Array.Copy(inp, smallCircle, 3);
                    Array.Copy(inp, 3, bigCircle, 0, 3);
                }
                double distance = Math.Sqrt(Math.Pow(inp[0] - inp[3], 2) + Math.Pow(inp[1] - inp[4], 2));
                if (distance < bigCircle[2])
                {
                    if (bigCircle.SequenceEqual(smallCircle))
                    {
                        Console.WriteLine(-1);
                    }
                    else if (distance < bigCircle[2] - smallCircle[2])
                    {
                        Console.WriteLine(0);
                    }
                    else if (distance == bigCircle[2] - smallCircle[2])
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
                else
                {
                    if (distance > bigCircle[2] + smallCircle[2])
                    {
                        Console.WriteLine(0);
                    }
                    else if (distance == bigCircle[2] + smallCircle[2])
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
            }
        }
    }
}
