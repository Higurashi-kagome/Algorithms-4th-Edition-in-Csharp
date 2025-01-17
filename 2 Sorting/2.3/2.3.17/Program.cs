﻿using System;
using _2._3._17;
using Quick;

var quick = new QuickSort();
var quickSortX = new QuickSortX();
var arrayLength = 1000000;
var a = SortCompare.GetRandomArrayInt(arrayLength);
var b = new int[arrayLength];
a.CopyTo(b, 0);

var time1 = SortCompare.Time(quick, a);
var time2 = SortCompare.Time(quickSortX, b);
Console.WriteLine("QSort\tQSort with Sentinels\t");
Console.WriteLine(time1 + "\t" + time2 + "\t");