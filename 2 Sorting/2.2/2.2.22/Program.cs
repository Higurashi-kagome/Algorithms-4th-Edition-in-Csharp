﻿using System;
using Merge;

var mergeSortThreeWay = new MergeSortThreeWay();
var n = 131072;
var trialTime = 5;
double previousTime = 1;
Console.WriteLine("数组\t耗时\t比率");
for (var i = 0; i < 6; i++)
{
    var time = SortCompare.TimeRandomInput(mergeSortThreeWay, n, trialTime);
    time /= trialTime;
    if (i == 0)
        Console.WriteLine(n + "\t" + time + "\t----");
    else
        Console.WriteLine(n + "\t" + time + "\t" + time / previousTime);
    previousTime = time;
    n *= 2;
}