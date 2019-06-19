﻿using System;

namespace _1._1._18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"mystery(2, 25): {mystery(2, 25)}");
            Console.WriteLine($"mystery(3, 11): {mystery(3, 11)}");

            Console.WriteLine($"mysteryChanged(2, 8): {mysteryChanged(2, 8)}");
            Console.WriteLine($"mysteryChanged(3, 2): {mysteryChanged(3, 2)}");
        }

        // mystery(a, b) = a * b
        // 利用等式：a * b = 2a * b/2 = (2a * (b-1) / 2) + a
        // 示例：
        // mystery(2, 25) =
        // mystery(2 + 2, 12) + 2 =
        // mystery(4 + 4, 6) + 2 =
        // mystery(8 + 8, 3) =
        // mystery(16 + 16, 1) + 16 + 2 =
        // mystery(32 + 32, 0) + 32 + 16 + 2 =
        // 0 + 32 + 16 + 2 =
        // 50
        public static int mystery(int a, int b)
        {
            if (b == 0) return 0;
            if (b % 2 == 0) return mystery(a + a, b / 2);
            return mystery(a + a, b / 2) + a;
        }

        // mysteryChanged(a, b) = a ^ b
        // 同理（乘方与乘法，乘法与加法之间具有类似的性质）
        // a ^ b = (a ^ 2) ^ (b / 2) = (a ^ 2) ^ ((b - 1) / 2) * a
        public static int mysteryChanged(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0) return mysteryChanged(a * a, b / 2);
            return mysteryChanged(a * a, b / 2) * a;
        }
    }
}