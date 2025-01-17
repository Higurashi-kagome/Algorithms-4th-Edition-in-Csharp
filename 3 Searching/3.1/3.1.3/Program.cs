﻿using System;
using SymbolTable;

var input = "S E A R C H E X A M P L E".Split(' ');
var orderedSt = new OrderedSequentialSearchSt<string, int>();

for (var i = 0; i < input.Length; i++)
{
    orderedSt.Put(input[i], i);
}

foreach (var s in orderedSt.Keys())
{
    Console.WriteLine(s + " " + orderedSt.Get(s));
}