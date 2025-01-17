﻿namespace _1._4._10;

/// <summary>
/// 二分查找。
/// </summary>
public class BinarySearch
{
    /// <summary>
    /// 用递归方法进行二分查找。
    /// </summary>
    /// <param name="key">关键字。</param>
    /// <param name="a">查找范围。</param>
    /// <param name="lo">查找的起始下标。</param>
    /// <param name="hi">查找的结束下标。</param>
    /// <returns>返回下标，如果没有找到则返回 -1。</returns>
    public static int Rank(int key, int[] a, int lo, int hi)
    {
        if (hi < lo)
            return -1;
        var mid = (hi - lo) / 2 + lo;
        if (a[mid] == key)
        {
            var mini = Rank(key, a, lo, mid - 1);
            if (mini != -1)
                return mini;
            return mid;
        }

        if (a[mid] < key)
        {
            return Rank(key, a, mid + 1, hi);
        }
        return Rank(key, a, lo, mid - 1);
    }
}