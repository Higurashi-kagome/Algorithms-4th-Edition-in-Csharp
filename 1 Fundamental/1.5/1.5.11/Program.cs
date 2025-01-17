﻿using System;
using System.IO;
using _1._5._11;
using TestCase;
using UnionFind;

char[] split = { '\n', '\r' };
var input = File.ReadAllText(DataFiles.MediumUf).Split(split, StringSplitOptions.RemoveEmptyEntries);
var size = int.Parse(input[0]);

var quickFind = new QuickFindUf(size);
var weightedQuickFind = new WeightedQuickFindUf(size);
for (var i = 1; i < size; i++)
{
    var pair = input[i].Split(' ');
    var p = int.Parse(pair[0]);
    var q = int.Parse(pair[1]);
    quickFind.Union(p, q);
    weightedQuickFind.Union(p, q);
}

Console.WriteLine("quick-find: " + quickFind.ArrayVisitCount);
Console.WriteLine("weighted quick-find: " + weightedQuickFind.ArrayVisitCount);