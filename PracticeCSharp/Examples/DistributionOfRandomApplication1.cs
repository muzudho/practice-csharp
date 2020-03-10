using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCSharp.Examples
{
    public static class DistributionOfRandomApplication1
    {
        private delegate bool HitCallback(int index);

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
            List<Object> anyList = Enumerable.Repeat((Object)new AnyObject(5963), size).ToList();

            // This is a hit. Age 13.
            var expected = random.Next(0, size - 1);
            anyList[expected] = new AnyObject(13);

            // This is a search algorithm.
            var actual = DistributionOfRandomApplication1.RandomIndexOf(anyList.Count, (index)=> (anyList[index] as AnyObject)?.Age == 13, random);

            // Assert!
            Console.WriteLine(@$"Expected={expected} Actual={actual}");
        }

        private static int RandomIndexOf(int size, HitCallback hitCallback, Random random)
        {
            var distribution = new int[size];
            var rest = size;
            var expectedIndex = -1;

            // Random shot!
            while (0<rest)
            {
                var index = random.Next(size);
                distribution[index]++;

                if (hitCallback(index))
                {
                    expectedIndex = index;
                    break;
                }
                else if (distribution[index]<2)
                {
                    rest--;
                    if (rest < 1)
                    {
                        break;
                    }
                }
            }

            // Result!
            Console.WriteLine("Result");
            Console.WriteLine("----------------");
            var i = 0;
            var total = 0;
            var max = 0;
            foreach (var item in distribution)
            {
                if (i < 100)
                {
                    Console.WriteLine(@$"[{i,3}] = {item,3}");
                }
                else if(i==100)
                {
                    Console.WriteLine("...");
                }

                total += item;
                if (max < item)
                {
                    max = item;
                }
                i++;
            }
            Console.WriteLine(@$"Hit?               = {-1!=expectedIndex,10}");
            Console.WriteLine(@$"Total              = {total,10}");
            Console.WriteLine(@$"Size               = {size,10}");
            Console.WriteLine(@$"Total < Size ?     = {total < size,10}");
            Console.WriteLine(@$"Total / Size       = {(float)total / (float)size, 10:F1}");
            Console.WriteLine(@$"Total / Size * 2.7 = {System.Math.Ceiling(total / size * 2.7),10} <-- Probably smaller than Max! Unless your luck is bad.");
            Console.WriteLine(@$"Max                = {max,10}");

            return expectedIndex;
        }
    }
}
