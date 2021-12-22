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
            // Grid bav = new Grid(11, 11);
            // bav.RCandD();
            // // bav.StrLine();
            // bav.DisplayGrid();

            Solution a = new Solution();
            // int[] arr = new[] {5, 4, -1, 7, 8};
            // Console.WriteLine(a.MaxSubArray(arr));
            int[] arr1 = new[] {3, 2, 1};
            int[] arr2 = new[] {1, 2, 3};
            a.printColl(a.compareTriplets(arr1.ToList(), arr2.ToList()));
            

        }
    }
}