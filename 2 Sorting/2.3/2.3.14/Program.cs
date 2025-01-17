﻿// 假设 i < j
// 首先，在快速排序中两个元素要发生比较，意味着其中一个被选为了枢轴。
// 因此如果数组的元素各不相同，那么两个特定元素的比较最多只能发生一次。
// 考虑一个极限情况，i = 1，j = n
// 也就是说是最大值和最小值比较的概率。
// 那么一旦枢轴是这两者之外的元素，
// 最大值和最小值会被分在两个不同的子数组中，
// 永远也不可能发生比较了。
// 因此，在这种特例中，
// 发生比较的概率 = 枢轴是最大值或者最小值的概率 = 2/n = 2/(j-i+1)
// 接下来进行扩展，只要枢轴不选为比 i 小或者比 j 大的元素。
// 那么第 i 大和第 j 大的元素就会被分到同一个子数组中，重复上述过程
// 因此概率只跟 i 和 j 之间的元素有关，概率为 2/(j-i+1)
//
// 现在我们已经得到了某两个元素比较的概率 Xij，
// 接下来我们求每两个元素之间比较的概率 X。
// 令 i 从 1 到 n，j 从 i+1 到 n。
// E(X) = Σ( Σ( E( Xij ) ) )
// E(X) = 2(1/2 + 1/3 + 1/4 + ... + 1/(n-i+1))
// 根据调和级数的性质
// E(X) ≤ 2nln(n)

return;