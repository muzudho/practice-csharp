using System;

namespace PracticeCSharp.Examples
{
    public static class DistributionOfRandomLesson2
    {
        public static void Go()
        {
            var random = new System.Random();
            var size = random.Next(2, 1000000);
            var expected = random.Next(0, size-1);
            DistributionOfRandomLesson2.Go(size, expected, random);
        }

        private static void Go(int size, int expected, Random random)
        {
            var distribution = new int[size];
            var rest = size;

            // Random shot!
            while (0<rest)
            {
                var index = random.Next(size);
                distribution[index]++;

                if (expected == index)
                {
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
            Console.WriteLine(@$"Hit?               = {0 < distribution[expected],10}");
            Console.WriteLine(@$"Total              = {total,10}");
            Console.WriteLine(@$"Size               = {size,10}");
            Console.WriteLine(@$"Total < Size ?     = {total < size,10}");
            Console.WriteLine(@$"Total / Size       = {(float)total / (float)size, 10:F1}");
            Console.WriteLine(@$"Total / Size * 2.7 = {System.Math.Ceiling(total / size * 2.7),10} <-- Probably smaller than Max! Unless your luck is bad.");
            Console.WriteLine(@$"Max                = {max,10}");
        }
    }
}
