﻿using System;

namespace _1._1._21
{
    class Program
    {
        /*
         * 输入示例：
         * 
         * 3
         * hi 1 2
         * hey 1 3
         * hello 1 4
         * 
         */
        static void Main(string[] args)
        {
            int columns = 2;
            int rows = int.Parse(Console.ReadLine());   // 行号

            string[] names = new string[rows];          // 姓名
            int[,] array = new int[rows, columns];      // 输入的两个整数
            double[] results = new double[rows];        // 计算结果

            for (int i = 0; i < rows; i++)
            {
                string temp = Console.ReadLine();
                names[i] = temp.Split(' ')[0];
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = int.Parse(temp.Split(' ')[j + 1]);
                }
                results[i] = (double)array[i, 0] / array[i, 1];
            }

            PrintArray2D(names, array, results);
        }

        static void PrintArray2D(string[] names, int[,] array, double[] results)
        {
            int rows = array.GetLength(0);// 获取行数
            int columns = array.GetLength(1);// 获取列数

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"\t{names[i]}");
                for (int j = 0; j < columns - 1; j++)
                {
                    Console.Write($"\t{array[i, j]}");
                }
                Console.Write($"\t{array[i, columns - 1]}");
                Console.Write($"\t{results[i]:N3}");    // 变量名:N3 保留三位小数
                Console.Write("\n");
            }
        }
    }
}