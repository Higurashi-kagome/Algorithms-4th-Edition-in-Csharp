﻿using System;
using Measurement;

namespace _1._4._41
{
    public delegate int Count(int[] a);
    static class DoublingRatio
    {
        /// <summary>
        /// 从指定字符串中读入按行分割的整型数据。
        /// </summary>
        /// <param name="inputString">源字符串。</param>
        /// <returns>读入的整型数组</returns>
        private static int[] ReadAllInts(string inputString)
        {
            char[] split = new char[1] { '\n' };
            string[] input = inputString.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[input.Length];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(input[i]);
            }
            return a;
        }

        /// <summary>
        /// 使用给定的数组进行一次测试，返回耗时（毫秒）。
        /// </summary>
        /// <param name="Count">要测试的方法。</param>
        /// <param name="a">测试用的数组。</param>
        /// <returns>耗时（秒）。</returns>
        public static double TimeTrial(Count Count, int[] a)
        {
            Stopwatch timer = new Stopwatch();
            Count(a);
            return timer.ElapsedTimeMillionSeconds();
        }

        /// <summary>
        /// 对 TwoSum、TwoSumFast、ThreeSum 或 ThreeSumFast 的 Count 方法做测试。
        /// </summary>
        /// <param name="Count">相应类的 Count 方法。</param>
        /// <returns>随着数据量倍增，方法耗时增加的比率。</returns>
        public static double Test(Count Count)
        {
            double ratio = 0;
            double times = 3;

            // 1K
            int[] a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            double prevTime = TimeTrial(Count, a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"1000\t{prevTime / 1000}\t");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            double time = TimeTrial(Count, a);
            Console.WriteLine($"2000\t{time / 1000}\t{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = TimeTrial(Count, a);
            Console.WriteLine($"4000\t{time / 1000}\t{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = TimeTrial(Count, a);
            Console.WriteLine($"8000\t{time / 1000}\t{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            return ratio / times;
        }

        /// <summary>
        /// 对 TwoSumFast 的 Count 方法做测试。
        /// </summary>
        /// <param name="Count">TwoSumFast 的 Count 方法</param>
        /// <returns>随着数据量倍增，方法耗时增加的比率。</returns>
        public static double TestTwoSumFast(Count Count)
        {
            double ratio = 0;
            double times = 2;

            // 8K
            int[] a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            double prevTime = TimeTrial(Count, a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"8000\t{prevTime / 1000}\t");

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            double time = TimeTrial(Count, a);
            Console.WriteLine($"16000\t{time / 1000}\t{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = TimeTrial(Count, a);
            Console.WriteLine($"32000\t{time / 1000}\t{time / prevTime}");
            if (prevTime != 0)
            {
                ratio += time / prevTime;
            }
            else
            {
                times--;
            }
            prevTime = time;

            return ratio / times;
        }
    }
}
