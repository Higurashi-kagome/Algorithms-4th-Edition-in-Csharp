﻿// 根据书中已经给出的归纳关系式（中文版P255 / 英文版P403）：
//    
// CN = N - 1 + (C0 + C(N - 1)) / N + (C1 + C(N - 2)) / N + ... + (C(N - 1) + C0) / N
//    
// 整理得：
//    
// CN = N - 1 + (C0 + C1 + ... + C(N - 1))/ N + (C(N - 1) + ... + C1 + C0) / N
//    
// 这和快速排序的式子基本一致，只是 N + 1 变成了 N - 1。

// 遵循相同的推导过程，我们可以获得类似的结果，两边同乘以 N：
//    
// NCN = N(N - 1) + 2(C0 + C1 + ... + C(N - 1))
//
// 用 N + 1 时的等式减去该式得：
//    
// (N + 1)C(N + 1) - NCN = 2N + 2CN
// (N + 1)C(N + 1) = 2N + (N + 2)CN 
// C(N + 1) / (N + 2) = 2N / [(N + 1)(N + 2)] + CN / (N + 1)
//
// 令 TN = CN / (N + 1)，得到：
//    
// T(N + 1) = 2N / [(N + 1)(N + 2)]+TN 
// T(N + 1)-T(N) = 2N / [(N + 1)(N + 2)]
//
// 归纳得：
//
// TN = 2Σ[(i - 1) / i(i + 1)]
// CN = 2(N + 1)Σ[(i - 1) / i(i + 1))] 
// CN = 2(N + 1)Σ{(i - 1)[(1 / i) - 1 / (i + 1)]} 
// CN = 2(N + 1)(HN - 1) - 2(N - 1)
// CN ~ 2(N + 1)(lnN + γ) - 4N
//
// 于是根据书中的公式，平均成本为 1 + CN / N ~ 2lnN + 2γ - 3 。

return;