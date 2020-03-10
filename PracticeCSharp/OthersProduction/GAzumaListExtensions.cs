using System;
using System.Collections.Generic;
using Object = System.Object;
// using Random = UnityEngine.Random; // ←無い☆（＾～＾）

namespace PracticeCSharp.OthersProduction
{
    public static class IReadOnlyListExtensions
    {
        /// <summary>
        /// 追加☆（＾～＾）
        /// </summary>
        private static Random random = new Random();

        private static readonly int[] TempIndices = new int[1024];
        private static readonly Object LockObject = new Object();

        /// <summary>
        /// 候補が空のときはdefault値を返します
        /// </summary>
        public static T GetAtRandom<T>(this IReadOnlyList<T> ir, Func<T, bool> predicate)
        {
            lock (LockObject)
            {
                int count = 0;
                // 条件に一致する要素のindexを取得します
                for (int i = 0; i < ir.Count; i++)
                {
                    if (predicate(ir[i]))
                    {
                        TempIndices[count] = i;
                        count++;
                    }
                }

                if (count == 0)
                {
                    return default;
                }

                // 抽出したindexから抽選して返します
                // 変更☆（＾～＾）
                // int randomIndex = TempIndices[Random.Range(0, TempIndices.Length)];
                int randomIndex = TempIndices[random.Next(0, TempIndices.Length - 1)];
                return ir[randomIndex];
            }
        }
    }
}
