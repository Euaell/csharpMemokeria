using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace memokeria
{
    class Solution {
        
        public static void PrintColl<T>(List<T> x) // prints any collections
        {
            foreach (var va in x)
            {
                Console.Write($" {va} ");
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
            string re = x.ToString();
            bool isNeg = false;
            string tobeReturned = "";
            if (re.StartsWith("-"))
                isNeg = true;
            if (isNeg)
            {
                for (int i = re.Length - 1; i >= 1; i--)
                    tobeReturned += re[i];
                Int32.TryParse(tobeReturned, out retr);
                return retr * -1;
            }
            else
            {
                for (int i = re.Length - 1; i >= 0; i--)
                    tobeReturned += re[i];
                Int32.TryParse(tobeReturned, out retr);
                return retr;
            }
        }

        public int MaxSubArray(int[] nums) // bungled but work in progress
        {
            int sum = 0;

            

            return sum;
        }
        
        public int PickingNumbers(List<int> a)
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
        
        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player) // Wrong Answer
        {
            var returnRank = new List<int>();
            var prevRank = new List<int>();
            prevRank.Add(1);
            int rankCounter = 1;
            for (int i = 1; i < ranked.Count; i++)
            {
                if(ranked[i] == ranked[i - 1])
                    prevRank.Add(rankCounter);
                else
                    prevRank.Add(++rankCounter);
            }
            int playerCount = player.Count;
            // to make the loop faster, used a reversed for loop
            int iter = 0;
            for (var index = player.Count - 1; index >= 0; index--)
            {
                var va = player[index];
                for (; iter < ranked.Count; iter++)
                    if (va >= ranked[iter])
                    {
                        returnRank.Add(prevRank[iter]);
                        playerCount--;
                        break;
                    }
            }
            // i think this is the problem
            while (playerCount > 0)
            {
                int itemp = playerCount - 1;
                if (itemp == 0)
                    returnRank.Add(rankCounter);
                else if (player[itemp] == player[itemp - 1])
                    returnRank.Add(rankCounter);
                else 
                    returnRank.Add(++rankCounter);
                playerCount--;
            }
            // returnRank.reverse();
            List<int> reReturnRank = new List<int>();
            for (int i = returnRank.Count - 1; i >= 0; i--)
            {
                reReturnRank.Add(returnRank[i]);
            }
            PrintColl(reReturnRank);
            return reReturnRank;
        }
        
        public int[] TopKFrequent(int[] nums, int k) // wrong answer
        {
            var retu = new int[k];
            
            var freq = new SortedDictionary<int, int> {{nums[0], 1}}; // value, frequency
            for(var i = 1; i < nums.Length - 1; i++){
                if(nums[i] == nums[i - 1])
                    freq[nums[i]]++;
                else
                    freq.Add(nums[i], 1);
            }

            var frequency = freq.Values.ToArray();
            while (k > 0)
            {
                retu[k] = freq.Last().Key;
                freq.Remove(frequency[k]);
                k--;
            }

            return retu;
        }
        
        public static List<int> gradingStudents(List<int> grades) // works well
        {
            var ret = new List<int>();
            foreach (var va in grades)
            {
                if (va < 38)
                    ret.Add(va);
                else
                {
                    int temp = 5 - (va % 5);
                    if (temp >= 3)
                        ret.Add(va);
                    else
                        ret.Add(va + temp);
                }
            }
            return ret;
        }
        
        public static void countSwaps(List<int> a) // works well
        {
            int swapCount = 0;
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = i + 1; j < a.Count; j++)
                {
                    if (a[i] > a[j])
                    {
                        (a[i], a[j]) = (a[j], a[i]); // deconstructor swap
                        // int temp = a[i];
                        // a[i] = a[j];
                        // a[j] = temp;
                        swapCount++;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {swapCount} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a.Last()}");
            
        }
        
        public static int countingValleys(int steps, string path) // done easily
        {
            int valley = 0;
            int ic = 0;
            foreach (var v in path)
            {
                if (v == 'U')
                {
                    ic += 1;
                    if (ic == 0)
                        valley += 1;
                }else if (v == 'D')
                    ic -= 1;
            }
            return valley;
        }
        
        public static void insertionSort1(int n, List<int> arr) // works
        {
            int x = arr.Last();
            for (var i = arr.Count - 2; i >= 0; i--)
            {
                if (arr[i] < x)
                {
                    arr[i + 1] = x;
                    foreach (var va in arr)
                        Console.Write($" {va}");
                }
                else if (i == 0 && arr[i] >= x)
                {
                    arr[i + 1] = arr[i];
                    foreach (var va in arr)
                        Console.Write($" {va}");
                    Console.WriteLine();
                    arr[i] = x;
                    foreach (var va in arr)
                        Console.Write($" {va}");
                }
                else
                    arr[i + 1] = arr[i];

                foreach (var va in arr)
                    Console.Write($" {va}");
                Console.WriteLine();
            }
        }
        
        public static List<int> countingSort(List<int> arr) // works well: save for further improvement
        {
            int max = arr.Max();
            List<int> freq = new List<int>();
            for (int i = 0; i < max + 1; i++)
                freq.Add(0);
            
            // int[] freq = new int[max + 1];
            foreach (var t in arr)
                freq[t] += 1;
            // var ret = new List<int>();// returns the sorrtrr
            // for (int i = 0; i < freq.Length; i++)
            //     for (int j = 0; j < freq[i]; j++)
            //             ret.Add(i);

            return freq;
        }
    }
}