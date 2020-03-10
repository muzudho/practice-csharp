using System;
using System.Diagnostics;
using System.Linq;
using PracticeCSharp.Examples;
using PracticeCSharp.OthersProduction;

namespace PracticeCSharp.SpeedMeasurement
{
    public static class DistributionOfRandomSpeedMeasurement
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
            var size = random.Next(2, 100000);
            var trial = 1000;

            Console.WriteLine("Reguration");
            Console.WriteLine("----------------------------");
            Console.WriteLine(@$"Size          = {size,12}");
            Console.WriteLine(@$"Trial         = {trial,12}");
            Console.WriteLine(".");

            DistributionOfRandomSpeedMeasurement.GoMuzudho(size, trial, random);
            DistributionOfRandomSpeedMeasurement.GoGAzuma(size, trial, random);
        }

        static void GoMuzudho(int size, int trial, Random random)
        {
            var failureCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i=0; i< trial; i++)
            {

                // Fill the dammy with list.
                //List<AnyObject> anyList = Enumerable.Repeat(new AnyObject(5963), size).ToList();
                AnyObject[] anyList = Enumerable.Repeat(new AnyObject(5963), size).ToArray();

                // This is a hit. Age 13.
                var expected = random.Next(0, size - 1);
                anyList[expected] = new AnyObject(13);

                // This is a search algorithm.
                var actual = anyList.GetAtRandom((item) => item.Age == 13, random);

                // Assert!
                if (actual?.Age!=13)
                {
                    failureCount++;
                }
            }
            sw.Stop();
            Console.WriteLine("Result Muzudho");
            Console.WriteLine("----------------------------");
            Console.WriteLine(@$"Failure count = {failureCount,12}");
            Console.WriteLine(@$"Time          = {sw.Elapsed.Hours,2}:{sw.Elapsed.Minutes,2}:{sw.Elapsed.Seconds,2}'{sw.Elapsed.Milliseconds,3}");
            Console.WriteLine(".");
        }

        static void GoGAzuma(int size, int trial, Random random)
        {
            var failureCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < trial; i++)
            {

                // Fill the dammy with list.
                //List<AnyObject> anyList = Enumerable.Repeat(new AnyObject(5963), size).ToList();
                AnyObject[] anyList = Enumerable.Repeat(new AnyObject(5963), size).ToArray();

                // This is a hit. Age 13.
                var expected = random.Next(0, size - 1);
                anyList[expected] = new AnyObject(13);

                // This is a search algorithm.
                var actual = anyList.GetAtRandom((item) => item.Age == 13);

                // Assert!
                if (actual?.Age != 13)
                {
                    failureCount++;
                }
            }
            sw.Stop();
            Console.WriteLine("Result GAzuma");
            Console.WriteLine("----------------------------");
            Console.WriteLine(@$"Failure count = {failureCount,12}");
            Console.WriteLine(@$"Time          = {sw.Elapsed.Hours,2}:{sw.Elapsed.Minutes,2}:{sw.Elapsed.Seconds,2}'{sw.Elapsed.Milliseconds,3}");
            Console.WriteLine(".");
        }
    }
}
