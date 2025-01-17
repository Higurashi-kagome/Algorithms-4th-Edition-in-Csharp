﻿using System;
using System.Diagnostics;
using SymbolTable;
// ReSharper disable CoVariantArrayConversion

var n = 100000;
Console.WriteLine("n=" + n);
var sst = new SequentialSearchSt<string, int>[4];
var bst = new BinarySearchSt<string, int>[4];
for (var i = 0; i < 4; i++)
{
    bst[i] = new BinarySearchSt<string, int>();
    sst[i] = new SequentialSearchSt<string, int>();
}

Console.WriteLine("BinarySearch");
Test(bst, n);
Console.WriteLine();
Console.WriteLine("SequentialSearch");
Test(sst, n);

static void Test(ISt<string, int>[] sts, int n)
{
    var sw = new Stopwatch();
    var data = SearchCompare.GetRandomArrayString(n, 3, 10);
    var item1 = "item1";
    Array.Sort(data);

    // 有序的数组
    Console.Write("Sorted Array: ");
    sw.Start();
    for (var i = 0; i < n; i++)
    {
        sts[0].Put(data[i], i);
    }

    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);

    // 逆序的数组
    Console.Write("Sorted Array Reversed: ");
    sw.Restart();
    for (var i = n - 1; i >= 0; i--)
    {
        sts[1].Put(data[i], i);
    }

    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);

    // 只有一种键
    Console.Write("One Distinct Key: ");
    sw.Restart();
    for (var i = 0; i < n; i++)
    {
        sts[2].Put(item1, i);
    }

    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);

    // 只有两种值
    Console.Write("Two Distinct Values: ");
    sw.Restart();
    for (var i = 0; i < n; i++)
    {
        sts[3].Put(data[i], i % 2);
    }

    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
}