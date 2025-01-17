﻿using System;
using SymbolTable;
using FrequencyCounter = _3._1._9.FrequencyCounter;

// tale.txt:https://introcs.cs.princeton.edu/java/data/tale.txt
// FrequencyCounter:https://algs4.cs.princeton.edu/31elementary/FrequencyCounter.java.html
// 已删除末尾的版权许可。
Console.WriteLine("MinLength = 1");
FrequencyCounter.MostFrequentlyWord("tale.txt", 1, new St<string, int>());
Console.WriteLine("MinLength = 8");
FrequencyCounter.MostFrequentlyWord("tale.txt", 8, new St<string, int>());
Console.WriteLine("MinLength = 10");
FrequencyCounter.MostFrequentlyWord("tale.txt", 10, new St<string, int>());