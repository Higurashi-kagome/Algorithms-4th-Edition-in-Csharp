﻿using System;
using System.Diagnostics;

namespace Quick
{
    /// <summary>
    /// 三向切分的快速排序。
    /// </summary>
    public class Quick3Way : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Quick3Way() { }

        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Shuffle(a);
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
        /// </summary>
        /// <typeparam name="T">需要排序的数组类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="lo">排序范围的起始下标。</param>
        /// <param name="hi">排序范围的结束下标。</param>
        private void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)                   // 别越界
                return;

            // 三向切分
            int lt = lo, i = lo + 1, gt = hi;
            T v = a[lo];
            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0)
                    Exch(a, lt++, i++);
                else if (cmp > 0)
                    Exch(a, i, gt--);
                else
                    i++;
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        private void Shuffle<T>(T[] a)
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
    }
}
