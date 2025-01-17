﻿using System;
using PriorityQueue;

// 用一个变量单独保存中位数
// 小于中位数的数存到最大堆中去
// 大于中位数的数存到最小堆中去
// 如果两个堆的大小差距大于 1 就更新中位数
var input = new[] { 1, 3, 5, 7, 9, 10 };
var pq = new MedianPq<int>(input);
Console.WriteLine(pq.DelMedian());
Console.WriteLine(pq.DelMedian());