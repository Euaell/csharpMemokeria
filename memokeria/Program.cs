using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace memokeria
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution a = new Solution();
            // int[] arr = new[] {5, 4, -1, 7, 8};
            // Console.WriteLine(a.MaxSubArray(arr));
            int[] arr1 = new[] {100, 90, 90, 80, 75, 60};
            int[] arr2 = new[] {50, 65, 77, 90, 102};
            // Solution.printColl(a.compareTriplets(arr1.ToList(), arr2.ToList()));
            Solution.ClimbingLeaderboard(arr1.ToList(), arr2.ToList());

            
        }
    }
}

