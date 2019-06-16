﻿using System;
using System.Collections.Generic;
using Geometry;

namespace _1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Type the value of N:");
            int N = int.Parse(Console.ReadLine());
            List<Point2D> pointlist = new List<Point2D>();
            Random random = new Random();

            if (N <= 2)
            {
                Console.WriteLine("Make sure there are 2 points at least");
                return;
            }

            // random.NextDouble() 返回一个 0~1 之间的 double 值
            for (int i = 0; i < N; i++)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                pointlist.Add(new Point2D(x, y));
            }

            double min = pointlist[0].DistanceTo(pointlist[1]);
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    double temp = pointlist[i].DistanceTo(pointlist[j]);
                    Console.WriteLine($"Checking Distance({i}, {j}): {temp}");
                    if (temp < min)
                    {
                        min = temp;
                    }
                }
            }

            Console.WriteLine($"\nThe minimal distance is {min}");
        }
    }
}