﻿namespace _2._3._13
{
    class Program
    {
        static void Main(string[] args)
        {
            // 最坏情况，每次都只能排除枢轴，总共需要切分 N-1 次，因此总深度为 N-1
            // 最好情况，每次都正好二分，因此总深度为 logN
            // 平均情况，将其视为用 N 个元素随机构造一棵 BST，
            // 这样的 BST 平均深度为 O(logN) 级（注意不是等于 logN），
            // 这个结论可以参见《算法导论》定理 12.4
        }
    }
}