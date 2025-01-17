﻿using System;
using System.Diagnostics;
// ReSharper disable UnusedLocalFunctionReturnValue

long binarySearchCompare;
long interpolationSearchCompare;

// 原文：1, 2 and 10 times faster
// 也就是一样快，快一倍和快十倍

// 对于均匀分布的数组，插值查找的平均需要 lg(lgN)) 次比较
// 解方程 
// lg(lgN)) = lgN, N = 0.8..
// 2lg(lgN)) = lgN, N = 4
// 10lg(lgN)) = lgN, N = 58
Console.WriteLine("n\tist(compare/time)\tbst(compare/time)\tratio(compare/time)");
Test(1, 10000000);
Test(4, 10000000);
Test(58, 10000000);

void Test(int n, int trial)
{
    binarySearchCompare = 0;
    interpolationSearchCompare = 0;
    Console.Write(n + "\t");

    var sw = new Stopwatch();

    var data = new int[n];
    var dataSorted = new int[n];
    var dataQuery = new int[trial];
    for (var i = 0; i < n; i++)
    {
        dataSorted[i] = i;
        data[i] = i;
    }

    Shuffle(data);
    for (var i = 0; i < trial; i++)
    {
        dataQuery[i] = new Random().Next(0, n);
    }


    // 测试 ist
    sw.Start();
    for (var i = 0; i < trial; i++)
    {
        InterpolationSearch(data, dataQuery[i]);
    }

    sw.Stop();
    var istTime = sw.ElapsedMilliseconds;
    Console.Write(interpolationSearchCompare + "/" + istTime + "\t\t");

    // 测试 bst
    sw.Restart();
    for (var i = 0; i < trial; i++)
    {
        BinarySearch(dataSorted, dataQuery[i]);
    }

    sw.Stop();

    var bstTime = sw.ElapsedMilliseconds;
    Console.Write(binarySearchCompare + "/" + bstTime + "\t\t");

    // 比例
    Console.WriteLine((float)interpolationSearchCompare / binarySearchCompare + "/" + (float)istTime / bstTime);
}

void Shuffle<T>(T[] array)
{
    for (var i = 0; i < array.Length; i++)
    {
        var p = i + new Random().Next(array.Length - i);
        var temp = array[p];
        array[p] = array[i];
        array[i] = temp;
    }
}

int BinarySearch(int[] a, int key)
{
    int lo = 0, hi = a.Length - 1;
    while (lo <= hi)
    {
        var mid = (lo + hi) / 2;
        var compare = a[mid].CompareTo(key);
        binarySearchCompare++;
        if (compare > 0)
            hi = mid - 1;
        else if (compare < 0)
            lo = mid + 1;
        else
            return mid;
    }

    return -1;
}

int InterpolationSearch(int[] a, int key)
{
    int lo = 0, hi = a.Length - 1;
    while (lo <= hi)
    {
        double percent = a[hi] == a[lo] ? 0 : (key - a[lo]) / (a[hi] - a[lo]);
        var index = lo + (int)Math.Floor((hi - lo) * percent);
        if (percent < 0)
            index = lo;
        if (percent > 1)
            index = hi;

        var compare = a[index].CompareTo(key);
        interpolationSearchCompare++;
        if (compare > 0)
            hi = index - 1;
        else if (compare < 0)
            lo = index + 1;
        else
            return index;
    }

    return -1;
}