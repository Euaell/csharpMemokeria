using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
namespace memokeria
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            // int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            // List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            // int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            // List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();
            
            Solution a = new Solution();
            // int[] arr = new[] {5, 4, -1, 7, 8};
            // Console.WriteLine(a.MaxSubArray(arr));
            int[] arr1 = new[] {100, 90, 90, 80, 75, 60};
            int[] arr2 = new[] {50, 65, 77, 90, 102};
            int[] arr3 = new[] {5, 1, 2, 2, 3, 4, 5};
            Solution.PrintColl(arr3.ToList());
            // Solution.printColl(a.compareTriplets(arr1.ToList(), arr2.ToList()));
            
            // Solution.ClimbingLeaderboard(arr1.ToList(), arr2.ToList());
            
        }
    }
}

