using System;
using System.Collections.Generic;
using System.Linq;

namespace memokeria
{
    class Solution {
        public void printColl<T>(List<T> x)
        {
            foreach (var Va in x)
            {
                Console.Write($" {Va} ");
            }
            Console.WriteLine(" ");
        }
        public string DecodeString(string s) // works
        {
            string x = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    string inp = "";
                    while (s[i] != '[')
                    {
                        inp = inp.Insert(inp.Length, s[i].ToString());
                        i++;
                    }
                    i++;
                    int cou = 0;
                    int pass = 0;
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[j] == '[')
                            cou--;
                        else if (s[j] == ']')
                            cou++;
                        if (cou > 0 || j == s.Length - 1)
                            break;

                        pass++;
                    }
                    string temp = String.Concat(Enumerable.Repeat(DecodeString(s.Substring(i, pass)), Int32.Parse(inp)));
                    i += pass;
                    x = x.Insert(x.Length, temp);
                } 
                else if (Char.IsLetter(s[i]))
                    x = x.Insert(x.Length, s[i].ToString());
            }
            
            return x;
        }
    
        public IList<IList<int>> MinimumAbsDifference(int[] arr) // Doesn't work, Needs some tweek
        {
            // IList<IList<int>> retList = new Collection<IList<int>>();
            IList<IList<int>> retList = new List<IList<int>>();
            // List<List<int>> retList = new List<List<int>>();
            int smalldiff = Math.Abs(arr[0] - arr[1]);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) < smalldiff)
                    {
                        smalldiff = Math.Abs(arr[i] - arr[j]);
                        retList.Clear();
                        IList<int> tobepassed = new List<int>();
                        tobepassed.Add(arr[i]);
                        tobepassed.Add(arr[j]);
                        retList.Add(tobepassed);
                    } else if (Math.Abs(arr[i] - arr[j]) == smalldiff)
                    {
                        IList<int> tobepassed = new List<int>();
                        tobepassed.Add(arr[i]);
                        tobepassed.Add(arr[j]);
                        retList.Add(tobepassed);
                    }
                }
                
            }

            // return (IList<IList<int>>)differ;
            return retList;
        }
        
        public bool ContainsDuplicate(int[] nums) // works very slowly 200ms
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i] == nums[i + 1])
                    return true;
            return false;
        }
        
        public bool ContainsNearbyDuplicate(int[] nums, int k) // works , but very slow
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length && Math.Abs(i - j) <= k; j++)
                    if (nums[i] == nums[j])
                        return true;
            }

            return false;
        }
        
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) // barely acceptable
        {
            if (t == 0)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length && Math.Abs(i - j) <= k; j++)
                        if (nums[i] == nums[j])
                            return true;
                }
                
                return false;
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length && Math.Abs(i - j) <= k; j++)
                {
                    Int64 x = nums[i];
                    Int64 y = nums[j];
                    if (Math.Abs(x - y) <= t)
                        return true;
                }
                    
            }
            return false;
        }
        
        public int Reverse(int x) // works well
        {
            int retr;
            string RE = x.ToString();
            bool isNeg = false;
            string tobeReturned = "";
            if (RE.StartsWith("-"))
                isNeg = true;
            if (isNeg)
            {
                for (int i = RE.Length - 1; i >= 1; i--)
                    tobeReturned += RE[i];
                Int32.TryParse(tobeReturned, out retr);
                return retr * -1;
            }
            else
            {
                for (int i = RE.Length - 1; i >= 0; i--)
                    tobeReturned += RE[i];
                Int32.TryParse(tobeReturned, out retr);
                return retr;
            }
        }

        public int MaxSubArray(int[] nums) // bungled but work in progress
        {
            int sum = 0;

            

            return sum;
        }
        
        public int pickingNumbers(List<int> a)
        {
            int max = 0;
            int counter = 0;
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < a.Count; j++)
                    if (a[j] == a[i] - 1 || a[j] == a[i])
                        counter++;

                max = counter > max ? counter : max;
                // Console.WriteLine($"counter for {a[i]} is {counter}");
                counter = 0;
            }
            return max;
        }
        
        public List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> points = new List<int>();
            points.Add(0);
            points.Add(0);
            for(int i = 0; i < a.Count; i++){
                if (a[i] > b[i])
                    points[0]++;
                else if (b[i] > a[i])
                    points[1]++;
            }
            return points;
        }
        
    }
}