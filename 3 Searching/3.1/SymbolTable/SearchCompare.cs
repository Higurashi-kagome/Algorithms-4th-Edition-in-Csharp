﻿using System;
using System.Diagnostics;
using System.Text;

namespace SymbolTable
{
    /// <summary>
    /// 静态类，提供一系列用于测试符号表的方法。
    /// </summary>
    public static class SearchCompare
    {
        private static Random random = new Random();

        /// <summary>
        /// 用指定的数据测试符号表，返回 <see cref="FrequencyCounter"/> 用去的时间。
        /// </summary>
        /// <param name="st">用于测试的空符号表。</param>
        /// <param name="filename">读入字符串的存放文件路径。</param>
        /// <returns>计算一次最常出现单词的时间。（毫秒）</returns>
        public static long Time<TKey>(IST<TKey, int> st, TKey[] keys)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            FrequencyCounter.MostFrequentlyKey(st, keys);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 对符号表进行性能测试，先 <see cref="IST{TKey, TValue}.Put(TKey, TValue)"/> <paramref name="n"/> 个字符串，
        /// 再进行若干次 <see cref="IST{TKey, TValue}.Get(TKey)"/>，
        /// 使得每个元素被平均访问 <paramref name="averageHit"/> 次，
        /// 以及同样多的未命中访问。
        /// </summary>
        /// <param name="st">需要进行性能测试的符号表。</param>
        /// <param name="n">需要插入符号表中的字符串数量。</param>
        /// <param name="averageHit">平均每个元素被查询的次数。</param>
        /// <returns>测试耗时，单位为毫秒。</returns>
        public static long Performance(IST<string, int> st, int n, int averageHit)
        {
            string[] keys = GetRandomArrayString(n, 2, 50);
            string keyNotExist = GetRandomString(51, 52);
            Stopwatch sw = Stopwatch.StartNew();
            // 构建
            for (int i = 0; i < n; i++)
                st.Put(keys[i], i);
            // 查询
            for (int i = 0; i < averageHit; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    st.Get(keys[j]);
                    st.Get(keyNotExist);
                }
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 生成包含 <paramref name="n"/> 个元素的随机整数数组，
        /// 整数范围为 [<paramref name="min"/>, <paramref name="max"/>)。
        /// </summary>
        /// <param name="n">生成的数组长度。</param>
        /// <param name="min">生成的整数的包含下限。</param>
        /// <param name="max">生成的整数的上限。</param>
        /// <returns>包含 <paramref name="n"/> 个元素的随机整数数组。</returns>
        public static long[] GetRandomArrayLong(int n, long min, long max)
        {
            long[] result = new long[n];
            for (int i = 0; i < n; i++)
                result[i] = min + (long)(random.NextDouble() * (max - min));
            return result;
        }

        /// <summary>
        /// 生成非负 <see cref="double"/> 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>大小为 <paramref name="n"/> 的非负 <see cref="double"/> 数组。</returns>
        public static double[] GetRandomArrayDouble(int n)
        {
            double[] data = new double[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = double.MaxValue * random.NextDouble();
            }
            return data;
        }

        /// <summary>
        /// 生成随机字符串数组，每个字符串的长度大于等于 <paramref name="minLength"/>，小于 <paramref name="maxLength"/>。
        /// </summary>
        /// <param name="n">生成字符串数组的大小。</param>
        /// <param name="minLength">随机字符串的最小长度。</param>
        /// <param name="maxLength">随机字符串的最大长度。</param>
        /// <returns>一个包含随机字符串的数组。</returns>
        public static string[] GetRandomArrayString(int n, int minLength, int maxLength)
        {
            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = GetRandomString(minLength, maxLength);
            }
            return result;
        }

        /// <summary>
        /// 生成只包含字母和数字的随机字符串，长度大于等于 <paramref name="minLength"/>，小于 <paramref name="maxLength"/>。
        /// </summary>
        /// <param name="minLength">随机字符串的最小长度。</param>
        /// <param name="maxLength">随机字符串的最大长度。</param>
        /// <returns>一个随机字符串。</returns>
        public static string GetRandomString(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                double choice = random.NextDouble();
                if (choice < 0.333)
                    sb.Append((char)random.Next('A', 'Z'));
                else if (choice < 0.666)
                    sb.Append((char)random.Next('a', 'z'));
                else
                    sb.Append((char)random.Next('0', '9'));
            }
            return sb.ToString();
        }
    }
}
