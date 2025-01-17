﻿using System;
using _1._4._40;

// 数学模型
// 
// N 个数可组成的三元组的总数为：
// C(N, 3) = N(N-1)(N-2)/3! = ~ (N^3)/6 （组合数公式）
// [-M, M]中随机 N 次，有 (2M+1)^N 种随机序列（每次随机都有 2M+1 种可能）
// 按照分步计数方法，将随机序列分为和为零的三元组和其余 N-3 个数
// 这些序列中，和为零的三元组有 3M^2 + 3M + 1 种可能。
// 其他不为零的 N-3 个位置有 (2M+1)^(N-3) 种可能。
// 总共有 ((N^3)/6) * (3M^2 + 3M + 1) * (2M+1)^(N-3) 种可能性
// 平均值为：
// [((N^3)/6) * (3M^2 + 3M + 1) * (2M+1)^(N-3)] / (2M+1)^N
// (N^3) * (3M^2 + 3M + 1) / 6 * (2M+1)^3
// ~ N^3 * 3M^2 / 6 * 8M^3
// N^3/16M
const int m = 10000;

for (var n = 125; n < 10000; n += n)
{
    var random = new Random();
    var a = new int[n];
    for (var i = 0; i < n; i++)
    {
        a[i] = random.Next(2 * m) - m;
    }

    Console.WriteLine($"N={n}, 计算值={Math.Pow(n, 3) / (16 * m)}, 实际值={ThreeSum.Count(a)}");
}