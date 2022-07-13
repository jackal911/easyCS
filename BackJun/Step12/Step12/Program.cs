﻿using System;
using System.IO;

// Step12 - 집합과 맵 https://www.acmicpc.net/step/49

namespace Step12
{

    class Program
    {
        // Q10815 - 숫자 카드
        // 바이너리 서치
        static int binarySearch(int toFind, int[] where)
        {
            int left = 0;
            int right = where.Length - 1;
            while (left < right)
            {
                int mid = (right + left) / 2;
                if (where[left] == toFind || where[mid] == toFind)
                    return 1;
                if (where[mid] < toFind)
                    left = mid + 1;
                else
                    right = mid;
            }
            return where[right]==toFind ? 1 : 0;
        }
        static void Main(string[] args)
        {
            /*
            // Q10815 - 숫자 카드
            // 바이너리 서치 - 시간 초과
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine(); // 노필요
            int[] card = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Array.Sort(card);
            sr.ReadLine(); // 노필요
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            foreach (var num in nums)
            {
                sw.Write("{0} ", binarySearch(num, card));
            }
            sw.Close();
            
            // 카운트 소팅
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine(); // 노필요
            int[] card = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Array.Sort(card);
            sr.ReadLine(); // 노필요
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            bool[] yesOrNo = new bool[20000001];
            foreach (var num in card)
                yesOrNo[num + 10000000] = true;
            foreach (var num in nums)
            {
                sw.Write("{0} ", yesOrNo[num + 10000000] ? 1 : 0);
            }
            sw.Close();
            */
            // Q14425 - 문자열 집합
            // 푼 사람이 없다. - 실패(22.7.13)
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int[] NM = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            string[] strSet = new string[NM[0]];
            int count = 0;
            for (int i = 0; i < NM[0]; i++)
            {
                strSet[i] = sr.ReadLine();
            }
            for (int j = 0; j < NM[1]; j++)
            {
                string inp = sr.ReadLine();
                if (Array.Exists(strSet, s => s == inp))
                    count++;
            }
            sw.Write(count);
            sw.Close();
        }
    }
}