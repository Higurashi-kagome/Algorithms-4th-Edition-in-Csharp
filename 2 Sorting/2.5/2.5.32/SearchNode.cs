﻿using System;

namespace _2._5._32;

/// <summary>
/// 用于搜索的结点，记录到当前状态和使用的步数。
/// </summary>
internal class SearchNode : IComparable<SearchNode>
{
    public int[] Status;
    public int Steps = 0;

    public int CompareTo(SearchNode other)
    {
        return Steps.CompareTo(other.Steps);
    }
}