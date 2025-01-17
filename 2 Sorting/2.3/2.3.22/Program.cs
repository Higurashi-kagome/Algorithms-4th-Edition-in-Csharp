﻿using System;
using Quick;

var quickNormal = new QuickSort();
var quickBentleyMcIlroy = new QuickBentleyMcIlroy();
var arraySize = 800000; // 初始数组大小。
const int trialTimes = 1; // 每次实验的重复次数。
const int trialLevel = 8; // 双倍递增的次数。

Console.WriteLine("n\t\t3way\tnormal\tratio");
for (var i = 0; i < trialLevel; i++)
{
    double timeBentleyMcIlroy = 0;
    double timeNormal = 0;
    for (var j = 0; j < trialTimes; j++)
    {
        var a = SortCompare.GetRandomArrayInt(arraySize);
        var b = new int[a.Length];
        a.CopyTo(b, 0);
        timeNormal += SortCompare.Time(quickNormal, b);
        timeBentleyMcIlroy += SortCompare.Time(quickBentleyMcIlroy, a);

    }

    timeBentleyMcIlroy /= trialTimes;
    timeNormal /= trialTimes;
    if (arraySize < 10000000)
        Console.WriteLine(
            arraySize + "\t\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
    else
        Console.WriteLine(
            arraySize + "\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
    arraySize *= 2;
}