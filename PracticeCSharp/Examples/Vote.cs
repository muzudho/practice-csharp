using System;
using System.Collections.Generic;

namespace PracticeCSharp
{
    public static class Vote
    {
        /// <summary>
        /// Result
        /// ----------------
        /// ChocoMint  =  31
        /// Curry      =  24
        /// Miso       =  16
        /// Salty      =  14
        /// SoySauce   =  15
        /// </summary>
        public static void Go()
        {
            var random = new System.Random();
            var flavors = new string[] { "SoySauce", "Salty", "Miso", "Curry", "ChocoMint" };
            var summary = new SortedDictionary<string, int>();

            // Vote!
            for(var i=0; i<100; i++)
            {
                var flavor = flavors[random.Next(flavors.Length)];
                if (summary.ContainsKey(flavor))
                {
                    summary[flavor] += 1;
                }
                else
                {
                    summary[flavor] = 1;
                }
            }

            // Result!
            Console.WriteLine("Result");
            Console.WriteLine("----------------");
            foreach (var item in summary)
            {
                Console.WriteLine(@$"{item.Key,-10} = {item.Value,3}");
            }
        }
    }
}
