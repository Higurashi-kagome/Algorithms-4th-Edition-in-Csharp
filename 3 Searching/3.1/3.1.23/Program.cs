﻿// 这里的右移操作可以理解为 「小数点前移一位」
// 即数字依次向右退一位，个位上的数字被舍弃。
// 对于十进制，小数点前移一位会使 n  变为 [n/10]
// 同样对于二进制就会使 n 变为 [n/2]
// 当需要除以 2 的 k 次幂的时候，可以用右移 k 位代替并减少时间开销。
// 同理可以用左移 k 位来代替乘以 2 的 k 次幂。
// 注：
// 这样会降低程序可读性，
// 并且某些语言（C/C++）的编译器已经可以自动执行这项优化了。
// 请充分考虑你的代码受众之后再决定是否采用这种写法。
// 
// 二分查找的最大查找次数 = [lgN] + 1 （见 3.1.20 的证明）
// 一个数最多被左移的次数也正好等于 [lgN]+1
// （任意正整数都能被表示为 2^k + m 的形式，即 k + 1 位二进制数）
// 一次二分查找所需的最大比较次数正好是 N 的二进制表示的位数。

return;

