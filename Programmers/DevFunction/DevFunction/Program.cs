using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFunction
{
    public class Solution
    {
        public List<int> solution(int[] progresses, int[] speeds)
        {
            int length = progresses.Length;
            List<int> answer = new List<int>();
            Queue q = new Queue();
            for (int i = 0; i < length; i++)
            {
                q.enQueue(progresses[i], speeds[i]);
            }
            while (!q.isEmpty())
            {
                answer.Add(q.timeGoesOnAndSomeWorkFinished());
            }
            answer.RemoveAll(s => s == 0);
            return answer;
        }
    }
    public class Queue
    {
        Node head { get; set; }
        Node tail { get; set; }
        int size {get; set;}

        internal Queue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        class Node
        {
            internal Node next { get; set; }
            internal int progress { get; set; }
            internal int speed { get; set; }

            internal Node(int progress, int speed)
            {
                this.next = null;
                this.progress = progress;
                this.speed = speed;
            }
        }

        internal void enQueue(int progress, int speed)
        {
            Node newNode = new Node(progress, speed);
            if (this.size == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.next = newNode;
                this.tail = newNode;
            }
            this.size++;
        }

        void deQueue()
        {
            this.head = this.head.next;
            this.size--;
        }

        internal int timeGoesOnAndSomeWorkFinished()
        {
            int tempSize = this.size;
            Node tempNode = this.head;
            int goneWorks = 0;
            while (tempSize > 0)
            {
                tempNode.progress += tempNode.speed;
                if (this.head == tempNode && tempNode.progress >= 100)
                {
                    deQueue();
                    goneWorks++;
                }
                tempNode = tempNode.next;
                tempSize--;
            }
            return goneWorks;
        }

        internal bool isEmpty()
        {
            return this.size == 0 ? true : false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] progresses = { 93, 30, 55 };
            int[] speeds = { 1, 30, 5 };
            foreach(int n in s.solution(progresses, speeds))
                Console.Write(n + " ");
        }
    }
}
