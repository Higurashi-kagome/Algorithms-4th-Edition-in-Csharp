﻿using System;

namespace _2._2._14
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>();
            for (int i = 1; i < 10; i += 2)
            {
                q1.Enqueue(i);
            }
            Queue<int> q2 = new Queue<int>();
            for (int i = 2; i <= 10; i += 2)
            {
                q2.Enqueue(i);
            }

            Queue<int> sorted = Merge(q1, q2);
            int n = sorted.Size();
            for (int i = 0; i < n; i++)
            {
                Console.Write(sorted.Dequeue() + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 归并两个有序队列。输入队列将被清空。
        /// </summary>
        /// <typeparam name="T">有序队列的元素类型。</typeparam>
        /// <param name="a">需要归并的队列。</param>
        /// <param name="b">需要归并的队列。</param>
        /// <returns>归并后的新队列。</returns>
        static Queue<T> Merge<T>(Queue<T> a, Queue<T> b) where T : IComparable<T>
        {
            Queue<T> sortedQueue = new Queue<T>();
            while (!a.IsEmpty() && !b.IsEmpty())
            {
                if (a.Peek().CompareTo(b.Peek()) < 0)
                    sortedQueue.Enqueue(a.Dequeue());
                else
                    sortedQueue.Enqueue(b.Dequeue());
            }

            while (!a.IsEmpty())
                sortedQueue.Enqueue(a.Dequeue());
            while (!b.IsEmpty())
                sortedQueue.Enqueue(b.Dequeue());

            return sortedQueue;
        }
    }
}
