﻿/*
 * 
 * 当有多个元素需要修改的时候，这个直观算法可能会出现错误。
 * 例如如下情况：
 * index 0 1 2 3 4 5 6 7 8 9
 * id    0 0 0 0 0 5 5 5 5 5
 * 
 * 输入 0, 5
 * i = 0 时，id[i] == id[p]，此时 id[i] = id[q]。
 * 数组变为 5 0 0 0 0 5 5 5 5 5
 * i = 1 时，id[i] != id[p]，算法出现错误。
 * 
 * 如果在 id[p] 之后还有需要修改的元素，那么这个算法就会出现错误。
 * 
 */

return;