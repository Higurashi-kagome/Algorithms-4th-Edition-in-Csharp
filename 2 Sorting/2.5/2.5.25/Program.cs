﻿using System;
using SortApplication;

// 官方解答：https://algs4.cs.princeton.edu/25applications/Point2D.java.html
var points = new Point2D[6];
for (var i = 0; i < points.Length; i++)
{
    points[i] = new Point2D(i, points.Length - i);
}

Console.WriteLine("X-Order");
Array.Sort(points, Point2D.XOrder);
PrintArray(points);

Console.WriteLine("Y-Order");
Array.Sort(points, Point2D.YOrder);
PrintArray(points);

Console.WriteLine("R-Order");
Array.Sort(points, Point2D.ROrder);
PrintArray(points);

var origin = new Point2D(0, 0);
Console.WriteLine("Distance to Origin");
Array.Sort(points, origin.DistanceTo_Order());
PrintArray(points);

Console.WriteLine("Polor angle to Origin");
Array.Sort(points, origin.Polar_Order());
PrintArray(points);

static void PrintArray(Point2D[] points)
{
    foreach (var p in points)
        Console.Write("(" + p.X + ", " + p.Y + ") ");
    Console.WriteLine();
}