using System;
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
            int[] arr = new[] {5, 4, -1, 7, 8};
            Console.WriteLine(a.MaxSubArray(arr));

        }
    }
}