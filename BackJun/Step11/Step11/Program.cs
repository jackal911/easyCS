using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Step11 - 정렬 https://www.acmicpc.net/step/9

namespace Step11
{
    class Program
    {
        // Q2751 - 수 정렬하기 2
        // 합병정렬 ver
        /*
        static List<int> mergeSort(List<int> lst)
        {
            if (lst.Count < 2)
            {
                return lst;
            }
            else if (lst.Count == 2)
            {
                if (lst[0] > lst[1])
                {
                    int temp = lst[1];
                    lst[1] = lst[0];
                    lst[0] = temp;
                }
                return lst;
            }
            else
            {
                List<int> divided1 = lst.GetRange(0, lst.Count / 2);
                lst.RemoveAll(s => divided1.Contains(s));
                divided1 = mergeSort(divided1);
                lst = mergeSort(lst);
                List<int> newList = new List<int>();
                while (divided1.Count != 0 || lst.Count != 0)
                {
                    if (divided1.Count != 0)
                    {
                        if (lst.Count != 0)
                        {
                            if (lst[0] > divided1[0])
                            {
                                newList.Add(divided1[0]);
                                divided1.RemoveAt(0);
                            }
                            else
                            {
                                newList.Add(lst[0]);
                                lst.RemoveAt(0);
                            }
                        }
                        else
                        {
                            newList.Add(divided1[0]);
                            divided1.RemoveAt(0);
                        }
                    }
                    else
                    {
                        newList.Add(lst[0]);
                        lst.RemoveAt(0);
                    }
                }
                return newList;
            }
        }
        */
        static void Main(string[] args)
        {
            /*
            // Q2750 - 수 정렬하기
            // 버블정렬 ver
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int j = N-1; j > 0; j--)
            {
                for (int k = 0; k < N - 1; k++)
                {
                    if (nums[k] > nums[k + 1])
                    {
                        int temp = nums[k];
                        nums[k] = nums[k + 1];
                        nums[k + 1] = temp;
                    }
                }
            }
            for (int l = 0; l < N; l++)
                Console.WriteLine(nums[l]);
            
            // 삽입정렬 ver
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 1; i < N; i++)
            {
                int key = nums[i];
                int insert = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (key < nums[j])
                    {
                        nums[j + 1] = nums[j];
                        insert = j;
                    }
                    else
                    {
                        insert = j + 1;
                        break;
                    }
                }
                nums[insert] = key;
            }
            for (int k = 0; k < N; k++)
                Console.WriteLine(nums[k]);
            
            // Q2751 - 수 정렬하기 2
            // 합병정렬 ver - 시간초과
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }
            nums = mergeSort(nums);

            StringBuilder sb = new StringBuilder(String.Join("\n", nums));
            
            Console.WriteLine(sb);

            // 내장함수 ver
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }
            nums.Sort();
            for (int i = 0; i < N; i++)
            {
                sb.Append(String.Format("{0}\n", nums[i]));
            }
            Console.WriteLine(sb.ToString());
            
            // Q10989 - 수 정렬하기 3
            // 카운팅 정렬 ver - 메모리초과
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }
            int max = nums.Max();
            List<int> count = Enumerable.Repeat(0, max + 1).ToList();

            foreach (var num in nums)
                count[num]++;

            
            for (int i = 0; i < max; i++)
            {
                count[i + 1] += count[i];
            }
            int[] result = new int[N];
            foreach (var num in nums)
            {
                result[count[num]-1] = num;
                count[num]--;
            }

            StringBuilder sb = new StringBuilder(String.Join("\n", result));

            Console.WriteLine(sb);
            
            // 내장함수 ver - 시간초과 or 메모리초과 - 해결
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(reader.ReadLine());
            int[] count = new int[10001];
            for (int i = 0; i < N; i++)
            {
                count[int.Parse(reader.ReadLine())]++;
            }

            reader.Close();

            for (int j = 1; j < 10001;)
            {
                if (count[j] == 0)
                {
                    j++;
                    continue;
                }
                writer.Write("{0}\n", j);
                count[j]--;
//                 if (count[j] > 0)
//                 {
//                     //sb.Append(String.Format("{0}\n", curIndex));
//                     writer.Write(String.Join("", Enumerable.Repeat(String.Format("{0}\n", j), count[j])));
//                     writer.Flush();
//                 }                
            }            

            writer.Close();
            */
            // Q25305 - 커트라인
            int k = int.Parse(Console.ReadLine().Split()[1]);
            int[] xs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(xs);
            Array.Reverse(xs);
            Console.Write(xs[k - 1]);
            
            /*
            // Q2108 - 통계학
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string temp = reader.ReadLine();
            int cnt = int.Parse(temp);

            int[] arr = new int[cnt];

            for (int i = 0; i < cnt; i++)
            {
                temp = reader.ReadLine();
                arr[i] = int.Parse(temp);
            }

            Array.Sort(arr);

            List<int> choibin = new List<int>();
            int choibinResult = 0;
            int count = 0;
            foreach (var item in arr.GroupBy(s => s))
            {
                if (item.Count() > count)
                {
                    count = item.Count();
                    choibin.Clear();
                    choibin.Add(item.Key);
                }
                else if (item.Count() == count)
                {
                    choibin.Add(item.Key);
                }
            }

            choibinResult = choibin.Count > 1 ? choibin[1] : choibin[0];
            writer.WriteLine(Math.Round(arr.Average()) == -0 ? 0 : Math.Round(arr.Average())); // -0 처리 없으면 틀림
            writer.WriteLine(arr[arr.Length / 2]);
            writer.WriteLine(choibinResult);
            writer.WriteLine(arr.Max() - arr.Min());

            writer.Close();
            reader.Close();
            
            // Q1427 - 소트인사이드
            char[] chars = Console.ReadLine().ToArray();
            Array.Sort(chars);
            Array.Reverse(chars);
            Console.WriteLine(String.Join("", chars));
            
            // Q11650 - 좌표 정렬하기
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int N = int.Parse(sr.ReadLine());
            Tuple<int, int>[] lst = new Tuple<int, int>[N];
            for (int i = 0; i < N; i++)
            {
                int[] inp = sr.ReadLine().Split().ToList().ConvertAll(int.Parse).ToArray();
                lst[i] = new Tuple<int, int>(inp[0], inp[1]);
            }
            sr.Close();
            Array.Sort(lst);
            for (int i = 0; i < N; i++)
            {
                sw.WriteLine("{0} {1}", lst[i].Item1, lst[i].Item2);
            }
            sw.Close();
            
            // Q11651 - 좌표 정렬하기 2
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int N = int.Parse(sr.ReadLine());
            Tuple<int, int>[] lst = new Tuple<int, int>[N];
            for (int i = 0; i < N; i++)
            {
                int[] inp = sr.ReadLine().Split().ToList().ConvertAll(int.Parse).ToArray();
                lst[i] = new Tuple<int, int>(inp[1], inp[0]);
            }
            sr.Close();
            Array.Sort(lst);
            for (int i = 0; i < N; i++)
            {
                sw.WriteLine("{0} {1}", lst[i].Item2, lst[i].Item1);
            }
            sw.Close();
            
            // Q1181 - 단어 정렬
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                string inp = Console.ReadLine();
                dict[inp] = inp.Length;
            }
            var sortedDict = from item in dict orderby item.Key orderby item.Value select item;
            foreach (var item in sortedDict)
            {
                Console.WriteLine(item.Key);
            }
            
            // Q10814 - 나이순 정렬
            int N = int.Parse(Console.ReadLine());
            string[][] people = new string[N][];
            for (int i = 0; i < N; i++)
            {
                people[i] = Console.ReadLine().Split();
            }

            var orderedPeople = from person in people orderby int.Parse(person[0]) select person;
            foreach (var person in orderedPeople)
            {
                Console.WriteLine("{0} {1}", person[0], person[1]);
            }
            
            // Q18870 - 좌표 압축
            // dictionary 활용 - 시간 초과            
            StringBuilder sb = new StringBuilder();
            Console.ReadLine();
            List<int> nums = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
            List<int> orderedNums = nums.Distinct().ToList();
            orderedNums.Sort();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if(dict.ContainsKey(num)){
                    sb.Append(String.Format("{0} ", dict[num]));
                }else{
                    int idx = orderedNums.IndexOf(num);
                    sb.Append(String.Format("{0} ", idx));
                    dict[num] = idx;
                }                
            }
            Console.Write(sb);
            */
            // lower bound 알고리즘 활용
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine();
            List<int> nums = sr.ReadLine().Split().ToList().ConvertAll(int.Parse);
            List<int> orderedNums = nums.Distinct().ToList();
            orderedNums.Sort();
            foreach (var num in nums)
            {
                int left = 0;
                int right = orderedNums.Count - 1;
                while (left < right) // lower bound를 그냥 while문으로 씀
                {
                    int mid = (right + left) / 2;
                    if (num > orderedNums[mid])
                    {
                        left = mid+1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                sw.Write("{0} ", right);
            }
            sw.Close();
        }
    }
}
