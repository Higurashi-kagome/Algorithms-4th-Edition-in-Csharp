﻿using System;
using Quick;

// 每次只让枢轴变为已排序，这就是最坏情况。
// 这种时候枢轴是当前子数组的最大值/最小值。
// 由于在我们的实现中总是取子数组的第一个元素作为枢轴。
// 因此一个已排序的数组可以达到最坏情况，比较次数达到 O(n^2)。
// 如果换作取最后一个元素，最坏情况会变成逆序数组。
// 我们的实现中如果碰到与枢轴相等的元素也会停止循环，
// 因此如果数组中有重复的元素会减少比较次数。
//
// 答案：
// 1 2 3 4 5 6 7 8 9 10
// 2 3 4 5 6 7 8 9 10 11
// 3 4 5 6 7 8 9 10 11 12
// 4 5 6 7 8 9 10 11 12 13
// 5 6 7 8 9 10 11 12 13 14
// 6 7 8 9 10 11 12 13 14 15
var quick = new QuickSortAnalyze
{
    NeedShuffle = false // 关闭开始的打乱操作。
};
var a = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
quick.Sort(a);
Console.WriteLine(quick.CompareCount);