﻿using System;
using System.Diagnostics;
using Quick;
// ReSharper disable CognitiveComplexity

namespace _2._3._27;

/// <summary>
/// 快速排序类。
/// </summary>
public class QuickSortIgnore : BaseSort
{
    /// <summary>
    /// 切换到插入排序的阈值。
    /// </summary>
    public int M { get; set; }

    /// <summary>
    /// 默认构造函数。
    /// </summary>
    public QuickSortIgnore()
    {
        M = 10;
    }

    /// <summary>
    /// 用快速排序对数组 a 进行升序排序。
    /// </summary>
    /// <typeparam name="T">需要排序的类型。</typeparam>
    /// <param name="a">需要排序的数组。</param>
    public override void Sort<T>(T[] a)
    {
        Shuffle(a);
        Sort(a, 0, a.Length - 1);

        // 插入排序处理小数组
        for (var i = 0; i < a.Length; i++)
        for (var j = i; j > 0 && Less(a[j], a[j - 1]); j--)
            Exch(a, j, j - 1);

        Debug.Assert(IsSorted(a));
    }

    /// <summary>
    /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
    /// </summary>
    /// <typeparam name="T">需要排序的数组类型。</typeparam>
    /// <param name="a">需要排序的数组。</param>
    /// <param name="lo">排序范围的起始下标。</param>
    /// <param name="hi">排序范围的结束下标。</param>
    protected void Sort<T>(T[] a, int lo, int hi) where T: IComparable<T>
    {
        if (hi <= lo)                   // 别越界
            return;
        if (hi - lo <= M)
        {
            return;     // 直接忽略
        }
        var j = Partition(a, lo, hi);
        Sort(a, lo, j - 1);
        Sort(a, j + 1, hi);
    }

    /// <summary>
    /// 对数组进行切分，返回枢轴位置。
    /// </summary>
    /// <typeparam name="T">需要切分的数组类型。</typeparam>
    /// <param name="a">需要切分的数组。</param>
    /// <param name="lo">切分的起始点。</param>
    /// <param name="hi">切分的末尾点。</param>
    /// <returns>枢轴下标。</returns>
    private int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        int i = lo, j = hi + 1;
        var v = a[lo];
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
    private void Shuffle<T>(T[] a)
    {
        var random = new Random();
        for (var i = 0; i < a.Length; i++)
        {
            var r = i + random.Next(a.Length - i);
            var temp = a[i];
            a[i] = a[r];
            a[r] = temp;
        }
    }
}