﻿using System;

namespace _2._2._18
{
    
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> a = new LinkedList<int>();
            MergeShuffle shuffle = new MergeShuffle();
            a.Insert(1);
            a.Insert(2);
            a.Insert(3);
            a.Insert(4);
            a.Insert(5);
            a.Insert(6);
            for (int i = 0; i < 200; i++)
            {
                shuffle.Shuffle(a);
                Console.WriteLine(a.ToString());
            }
        }
    }
}
