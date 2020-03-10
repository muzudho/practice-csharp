using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCSharp.Examples
{
    public delegate bool HitCallback<T>(T item);

    static class ListExtensions
    {
        public static T GetAtRandom<T>(this IReadOnlyList<T> anyList, HitCallback<T> hitCallback, Random random)
        {
            var distribution = new int[anyList.Count];
            var rest = anyList.Count;

            // Random shot!
            while (0 < rest)
            {
                var index = random.Next(anyList.Count);
                distribution[index]++;

                var item = anyList[index];
                if (hitCallback(item))
                {
                    // Hit!
                    return item;
                }
                else if (distribution[index] < 2)
                {
                    rest--;
                    if (rest < 1)
                    {
                        // There was nothing!
                        break;
                    }
                }
            }

            // Disappointed.
            return default(T);
        }
    }

    public static class DistributionOfRandomApplication2
    {
        /// <summary>
        /// This is a target type.
        /// </summary>
        private class AnyObject
        {
            public int Age { get; private set; }

            public AnyObject(int age)
            {
                this.Age = age;
            }
        }

        public static void Go()
        {
            var random = new System.Random();
            var size = random.Next(2, 1000000);

            // Fill the dammy with list.
            //List<AnyObject> anyList = Enumerable.Repeat(new AnyObject(5963), size).ToList();
            AnyObject[] anyList = Enumerable.Repeat(new AnyObject(5963), size).ToArray();

            // This is a hit. Age 13.
            var expected = random.Next(0, size - 1);
            anyList[expected] = new AnyObject(13);

            Console.WriteLine("Try");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(@$"Size               = {size,10}");

            // This is a search algorithm.
            var actual = anyList.GetAtRandom((item) => item.Age == 13, random);

            // Assert!
            Console.WriteLine("Result");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(@$"Age = {actual?.Age}");
        }
    }
}
