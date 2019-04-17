﻿using System;
using System.Linq;
using System.Diagnostics;
using PriorityQueue;

namespace _2._4._38
{
    
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int n = 200000;
            int repeatTimes = 5;
            int doubleTimes = 4;
            for (int i = 0; i < doubleTimes; i++)
            {
                Console.WriteLine("n=" + n);
                // 升序数组
                long totalTime = 0;
                Console.Write("Ascending:\t");
                for (int j = 0; j < repeatTimes; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    int[] data = GetAscending(n);
                    long time = Test(pq, data);
                    Console.Write(time + "\t");
                    totalTime += time;
                }
                Console.WriteLine("Average:" + totalTime / repeatTimes);
                // 降序数组
                totalTime = 0;
                Console.Write("Descending:\t");
                for (int j = 0; j < repeatTimes; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    int[] data = GetDescending(n);
                    long time = Test(pq, data);
                    Console.Write(time + "\t");
                    totalTime += time;
                }
                Console.WriteLine("Average:" + totalTime / repeatTimes);
                // 全部元素相同
                totalTime = 0;
                Console.Write("All Same:\t");
                for (int j = 0; j < repeatTimes; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    int[] data = GetSame(n, 17763);
                    long time = Test(pq, data);
                    Console.Write(time + "\t");
                    totalTime += time;
                }
                Console.WriteLine("Average:" + totalTime / repeatTimes);
                // 只有两个值
                totalTime = 0;
                Console.Write("Binary Dist.:\t");
                for (int j = 0; j < repeatTimes; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    int[] data = GetBinary(n, 15254, 17763);
                    long time = Test(pq, data);
                    Console.Write(time + "\t");
                    totalTime += time;
                }
                Console.WriteLine("Average:" + totalTime / repeatTimes);
                n *= 2;
            }
        }

        static long Test(MaxPQ<int> pq, int[] data)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < data.Length; i++)
            {
                pq.Insert(data[i]);
            }
            for (int i = 0; i < data.Length; i++)
            {
                pq.DelMax();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        static int[] GetAscending(int n)
        {
            int[] ascending = new int[n];
            for (int i = 0; i < n; i++)
                ascending[i] = random.Next();
            Array.Sort(ascending);
            return ascending;
        }

        static int[] GetDescending(int n)
        {
            int[] descending = GetAscending(n);
            descending = descending.Reverse().ToArray();
            return descending;
        }

        static int[] GetSame(int n, int v)
        {
            int[] same = new int[n];
            for (int i = 0; i < n; i++)
            {
                same[i] = v;
            }
            return same;
        }

        static int[] GetBinary(int n, int a, int b)
        {
            int[] binary = new int[n];
            for (int i = 0; i < n; i++)
            {
                binary[i] = random.NextDouble() > 0.5 ? a : b;
            }
            return binary;
        }
    }
}
