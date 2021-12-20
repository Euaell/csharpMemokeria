using System;
using System.Collections.Generic;

namespace lela
{
    public class Day_8
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        int c = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < c; i++)
        {
            string[] temp = Console.ReadLine().Trim().Split(' ');
            if (temp.Length >= 2)
            {
                phoneBook.Add(temp[0], temp[1]);
            }
        }

        List<string> enq = new List<string>();
            while (c > 0)
        {
            enq.Add(Console.ReadLine());
            c--;
        }

        foreach (var VARIABLE in enq)
        {
            if (phoneBook.ContainsKey(VARIABLE))
            {
                Console.WriteLine($"{VARIABLE}={phoneBook[VARIABLE]}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}