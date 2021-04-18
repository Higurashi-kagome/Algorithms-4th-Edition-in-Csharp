﻿// 分析一下第一个问题。
// 首先插入了一个比队列中所有元素都大的元素。
// 那么这个元素必定会被移动到堆顶部（即 Swim 操作）
// 把移动轨迹上的元素单独拿出来，假设为  a1, a2, ..., ak
// Swim 操作就等于把这个序列循环右移一位，变为 ak, a1, a2, ..., ak-1
// 然后调用 delMax，序列变为 ak-1, a1, a2, ..., ak-2, ak
// 然后进行 Sink() 操作，ak-1 会按原路下沉到最后，堆恢复原状。
// 原路返回的原因也很简单，原来路径上的元素为 a1, a2, ..., ak-1。
// 显然 a1 是最大值（根结点），ak-1 一定会和它做交换
// 由于堆中的所有子树也是堆，那么同理 a2...ak-1 分别是所在子树的最大值
// 于是 ak-1 会按照原路返回到原位置，堆恢复原状。

// 第二问的顺序是 insert() insert() delMax() delMax()
// 已经证明插入最大元素后直接删除不会改变堆，因此中间两个操作抵消
// insert() delMax()
// 同理，再次抵消，堆不发生改变。

return;