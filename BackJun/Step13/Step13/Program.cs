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
            */
            // Q2477 - 참외밭

        }
    }
}
