﻿using System;
using System.Diagnostics;

namespace _2._5._23
{
    /*
     * 2.5.23
     * 
     * 选择的取样：实验使用取样来改进 select() 函数的想法。
     * 提示：使用中位数可能并不总是有效。
     * 
     */
    class Program
    {
        // 使用 Floyd–Rivest 方法进行优化。
        static void Main(string[] args)
        {
            const int n = 1000000;                  // 数组大小
            const int repeatTime = 50;              // 重复次数
            const int toFind = (int)(n * 0.8);      // 需要寻找的 k 值

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i;
            Shuffle(a);

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Normal:");
            for (int i = 0; i < repeatTime; i++)
            {
                sw.Start();
                int result = Select(a, toFind);
                sw.Stop();

                Shuffle(a);
            }
            Console.WriteLine(sw.ElapsedMilliseconds / repeatTime);

            Console.WriteLine("Sampled:");
            sw.Reset();
            for (int i = 0; i < repeatTime; i++)
            {
                sw.Start();
                int result = Select(a, 0, a.Length - 1, toFind);
                sw.Stop();

                Shuffle(a);
            }
            Console.WriteLine(sw.ElapsedMilliseconds / repeatTime);
        }

        /// <summary>
        /// 令 a[k] 变成第 k 小的元素。
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="k">序号</param>
        /// <returns></returns>
        public static T Select<T>(T[] a, int k) where T : IComparable<T>
        {
            if (k < 0 || k > a.Length)
                throw new IndexOutOfRangeException("Select elements out of bounds");
            int lo = 0, hi = a.Length - 1;
            while (hi > lo)
            {
                int i = Partition(a, lo, hi);
                if (i > k)
                    hi = i - 1;
                else if (i < k)
                    lo = i + 1;
                else
                    return a[i];
            }
            return a[lo];
        }

        /// <summary>
        /// Floyd–Rivest 方法优化，令 a[k] 变成第 k 小的元素。
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="k">序号</param>
        /// <returns></returns>
        static T Select<T>(T[] a, int lo, int hi, int k) where T : IComparable<T>
        {
            if (k < 0 || k > a.Length)
                throw new IndexOutOfRangeException("Select elements out of bounds");          
            while (hi > lo)
            {
                if (hi - lo > 600)
                {
                    int n = hi - lo + 1;
                    int i = k - lo + 1;
                    int z = (int)Math.Log(n);
                    int s = (int)(Math.Exp(2 * z / 3) / 2);
                    int sd = (int)Math.Sqrt(z * s * (n - s) / n) * Math.Sign(i - n / 2) / 2;
                    int newLo = Math.Max(lo, k - i * s / n + sd);
                    int newHi = Math.Min(hi, k + (n - i) * s / n + sd);
                    Select(a, newLo, newHi, k);
                }
                Exch(a, lo, k);
                int j = Partition(a, lo, hi);
                if (j > k)
                    hi = j - 1;
                else if (j < k)
                    lo = j + 1;
                else
                    return a[j];
            }
            return a[lo];
        }

        /// <summary>
        /// 对数组进行切分，返回枢轴位置。
        /// </summary>
        /// <typeparam name="T">需要切分的数组类型。</typeparam>
        /// <param name="a">需要切分的数组。</param>
        /// <param name="lo">切分的起始点。</param>
        /// <param name="hi">切分的末尾点。</param>
        /// <returns>枢轴下标。</returns>
        static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, a[--j]))
                    if (j == lo)
                        break;
                if (i >= j)
                    break;
                Exch(a, i, j);
            }
            Exch(a, lo, j);
            return j;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        private static void Shuffle<T>(T[] a)
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int r = i + random.Next(a.Length - i);
                T temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// 比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <param name="v">第一个参数。</param>
        /// <param name="w">第二个参数。</param>
        /// <returns>如果第一个参数小于第二个参数则返回 true，
        /// 否则返回 false。</returns>
        static bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 交换数组中下标为 i, j 的两个元素。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="a">元素所在的数组。</param>
        /// <param name="i">需要交换的第一个元素。</param>
        /// <param name="j">需要交换的第二个元素。</param>
        static void Exch<T>(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
