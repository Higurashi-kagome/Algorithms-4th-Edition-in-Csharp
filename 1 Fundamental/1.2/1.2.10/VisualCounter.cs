﻿using System.Drawing;

namespace _1._2._10
{
    /// <summary>
    /// 可视化计数器
    /// </summary>
    class VisualCounter
    {
        private readonly string name;
        private int count;
        private int max;
        private int operatorTimes;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">计数器的名称。</param>
        /// <param name="max">计数器的最大值。</param>
        /// <param name="operatorTimes">计数器的最大操作数。</param>
        public VisualCounter(string id, int max, int operatorTimes)
        {
            this.name = id;
            this.max = max;
            this.operatorTimes = operatorTimes;
        }

        /// <summary>
        /// 计数器加一。
        /// </summary>
        public bool Increment()
        {
            if (this.operatorTimes <= 0)
                return false;
            if (this.count < this.max)
            {
                this.count++;
                this.operatorTimes--;
            }
            return true;
        }

        /// <summary>
        /// 计数器减一。
        /// </summary>
        public bool Decreasement()
        {
            if (this.operatorTimes <= 0)
                return false;
            if (this.count > 0)
            {
                this.count--;
                this.operatorTimes--;
            }
            return true;
        }

        /// <summary>
        /// 获取当前计数值。
        /// </summary>
        /// <returns>返回计数值。</returns>
        public int Tally()
        {
            return this.count;
        }

        /// <summary>
        /// 返回形如 “1 counter” 的字符串。
        /// </summary>
        /// <returns>返回形如 “1 counter” 的字符串。</returns>
        public override string ToString()
        {
            return this.count + " " + this.name;
        }

        /// <summary>
        /// 绘制计数器的图形。
        /// </summary>
        /// <param name="g">画布。</param>
        /// <param name="width">绘图区宽度。</param>
        /// <param name="height">绘图区高度。</param>
        /// <param name="font">显示的字体。</param>
        public void Draw(Graphics g, int width, int height, Font font)
        {
            // 空画布
            g.Clear(SystemColors.Control);
            // 画布分为上 1/3 和下 2/3
            RectangleF headPart = new RectangleF(0, 0, width, height / 3);
            Rectangle bodyPart = new Rectangle(0, height / 3, (height * 2) / 3, (height * 2) / 3);

            // 绘图
            g.DrawString($"计数：{this.count} 剩余操作数：{this.operatorTimes} 最大值：{this.max}", font, Brushes.Black, headPart);
            g.FillPie(Brushes.Blue, bodyPart, 0, 360 * (float)this.count / this.max);
        }
    }
}
