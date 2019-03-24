﻿namespace _3._1._11
{
    /*
     * 3.1.11
     * 
     * 给出用 BinarySearchST 将键 E A S Y Q U E S T I O N 插入一个空符号表的过程的轨迹。
     * 一共进行了多少次比较？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // k v  list                                    compare
            // E 0  E0                                      0
            // A 1  A1 E0                                   1
            // S 2  A1 E0 S2                                2
            // Y 3  A1 E0 S2 Y3                             2
            // Q 4  A1 E0 Q4 S2 Y3                          2
            // U 5  A1 E0 Q4 S2 U5 Y3                       3
            // E 6  A1 E6 Q4 S2 U5 Y3                       3
            // S 7  A1 E6 Q4 S7 U5 Y3                       3
            // T 8  A1 E6 Q4 S7 T8 U5 Y3                    3
            // I 9  A1 E6 I9 Q4 S7 T8 U5 Y3                 3
            // O 10 A1 E6 I9 O10 Q4 S7 T8 U5 Y3             3
            // N 11 A1 E6 I9 N11 O10 Q4 S7 T8 U5 Y3         4
            // 
            // 共比较 29 次。
        }
    }
}
