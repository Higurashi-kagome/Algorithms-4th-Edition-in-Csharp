﻿using System;

namespace _1._3._35
{
    /// <summary>
    /// 随机队列。
    /// </summary>
    /// <typeparam name="Item">队列中要存放的元素。</typeparam>
    public class RandomQueue<Item>
    {
        private Item[] queue;
        private int count;

        /// <summary>
        /// 新建一个随机队列。
        /// </summary>
        public RandomQueue()
        {
            this.queue = new Item[2];
            this.count = 0;
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 为队列重新分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException();
            }

            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; i++)
            {
                temp[i] = this.queue[i];
            }

            this.queue = temp;
        }

        /// <summary>
        /// 向队列中添加一个元素。
        /// </summary>
        /// <param name="item">要向队列中添加的元素。</param>
        public void Enqueue(Item item)
        {
            if (this.queue.Length == this.count)
            {
                Resize(this.count * 2);
            }

            this.queue[this.count] = item;
            this.count++;
        }

        /// <summary>
        /// 从队列中随机删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Random random = new Random(DateTime.Now.Millisecond);
            int index = random.Next(this.count);

            Item temp = this.queue[index];
            this.queue[index] = this.queue[this.count - 1];
            this.queue[this.count - 1] = temp;

            this.count--;

            if (this.count < this.queue.Length / 4)
            {
                Resize(this.queue.Length / 2);
            }

            return temp;
        }

        /// <summary>
        /// 随机返回一个队列中的元素。
        /// </summary>
        /// <returns></returns>
        public Item Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Random random = new Random();
            int index = random.Next(this.count);

            return this.queue[index];
        }
    }
}
