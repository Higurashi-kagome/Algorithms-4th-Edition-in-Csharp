﻿using System;

namespace Measurement;

/// <summary>
/// 用二分查找优化的方法寻找数组中和为零的三元组。
/// </summary>
public static class ThreeSumFast
{
    /// <summary>
    /// 输出所有和为零的三元组。
    /// </summary>
    /// <param name="a">输入数组。</param>
    public static void PrintAll(int[] a)
    {
        var n = a.Length;
        Array.Sort(a);
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var k = Array.BinarySearch(a, -(a[i] + a[j]));
                if (k > j)
                {
                    Console.WriteLine(a[i] + " " + a[j] + " " + a[k]);
                }
            }
        }
    }

    /// <summary>
    /// 计算和为零的三元组的数量。
    /// </summary>
    /// <param name="a">输入数组。</param>
    /// <returns>和为零的三元组的数量。</returns>
    public static int Count(int[] a)
    {
        var n = a.Length;
        var count = 0;
        Array.Sort(a);
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var k = Array.BinarySearch(a, -(a[i] + a[j]));
                if (k > j)
                {
                    count++;
                }
            }
        }
        return count;
    }
}