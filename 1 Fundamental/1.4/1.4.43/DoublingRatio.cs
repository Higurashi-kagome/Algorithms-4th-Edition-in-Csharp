﻿using System;
using System.IO;
using Measurement;
using TestCase;

namespace _1._4._43;

internal static class DoublingRatio
{
    /// <summary>
    /// 从指定字符串中读入按行分割的整型数据。
    /// </summary>
    /// <param name="inputString">源字符串。</param>
    /// <returns>读入的整型数组</returns>
    private static int[] ReadAllInts(string inputString)
    {
        var split = new[] { '\n' };
        var input = inputString.Split(split, StringSplitOptions.RemoveEmptyEntries);
        var a = new int[input.Length];
        for (var i = 0; i < a.Length; i++)
        {
            a[i] = int.Parse(input[i]);
        }
        return a;
    }

    /// <summary>
    /// 使用给定的数组对链栈进行一次测试，返回耗时（毫秒）。
    /// </summary>
    /// <param name="a">测试用的数组。</param>
    /// <returns>耗时（毫秒）。</returns>
    public static double TimeTrialLinkedStack(int[] a)
    {
        var stack = new LinkedStack<int>();
        var n = a.Length;
        var timer = new Stopwatch();
        for (var i = 0; i < n; i++)
        {
            stack.Push(a[i]);
        }
        for (var i = 0; i < n; i++)
        {
            stack.Pop();
        }
        return timer.ElapsedTimeMillionSeconds();
    }

    /// <summary>
    /// 使用给定的数组对数组栈进行一次测试，返回耗时（毫秒）。
    /// </summary>
    /// <param name="a">测试用的数组。</param>
    /// <returns>耗时（毫秒）。</returns>
    public static double TimeTrialDoublingStack(int[] a)
    {
        var stack = new DoublingStack<int>();
        var n = a.Length;
        var timer = new Stopwatch();
        for (var i = 0; i < n; i++)
        {
            stack.Push(a[i]);
        }
        for (var i = 0; i < n; i++)
        {
            stack.Pop();
        }
        return timer.ElapsedTimeMillionSeconds();
    }

    /// <summary>
    /// 对链栈和基于大小可变的数组栈做测试。
    /// </summary>
    public static void Test()
    {
        Console.WriteLine("数据量\t链栈\t数组\t比值\t单位：毫秒");
        // 16K
        var a = ReadAllInts(File.ReadAllText(DataFiles._16KInts));
        var linkedTime = TimeTrialLinkedStack(a);
        var arrayTime = TimeTrialDoublingStack(a);
        Console.WriteLine($"16000\t{linkedTime}\t{arrayTime}\t{linkedTime / arrayTime}");

        // 32K
        a = ReadAllInts(File.ReadAllText(DataFiles._32KInts));
        linkedTime = TimeTrialLinkedStack(a);
        arrayTime = TimeTrialDoublingStack(a);
        Console.WriteLine($"32000\t{linkedTime}\t{arrayTime}\t{linkedTime / arrayTime}");

        // 1M
        a = ReadAllInts(File.ReadAllText(DataFiles._1MInts));
        linkedTime = TimeTrialLinkedStack(a);
        arrayTime = TimeTrialDoublingStack(a);
        Console.WriteLine($"1000000\t{linkedTime}\t{arrayTime}\t{linkedTime / arrayTime}");
    }
}