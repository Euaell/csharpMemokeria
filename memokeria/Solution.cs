using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public int MaxSubArray(int[] nums) // Kadane's Algorithm
        {
            int sum = 0;
            int curSum = 0;
            foreach (var va in nums)
            {
                curSum += va;
                if (curSum > sum)
                    sum = curSum;
                if (curSum < 0)
                    curSum = 0;
            }

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
            List<int> freq = new List<int>(100);
            for (int i = 0; i < 100; i++)
                freq.Add(0);
            
            foreach (var t in arr)
                freq[t] += 1;

            return freq;
        }
        
        public string SortSentence(string s) // works but is slow
        {
            List<string> temp = s.Split(' ').ToList();
            SortedDictionary<int, string> temp2 = new SortedDictionary<int, string>();
            foreach (var va in temp)
            {
                int x;
                Int32.TryParse(va.Last().ToString(), out x);
                temp2.Add(x, va.Remove(va.Length - 1));
            }
            var y = temp2.Values.ToList();
            
            return String.Join(" ", y);
        }
        
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] x = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                    if (nums[j] < nums[i] && i != j)
                        x[i]++;
            }

            return x;
        }
        
        public IList<int> TargetIndices(int[] nums, int target)// work really fast with bad memory usage
        {
            int max = nums.Max();
            List<int> freq = new List<int>();
            for (int i = 0; i < max + 1; i++)
                freq.Add(0);
            foreach (var t in nums)
                freq[t] += 1;
            var ret = new List<int>();// returns the sorted array
            for (int i = 0; i < freq.Count; i++)
                for (int j = 0; j < freq[i]; j++)
                        ret.Add(i);
            
            var ret1 = new List<int>();
            for (int i = 0; i < ret.Count; i++)
                if (ret[i] == target)
                    ret1.Add(i);
            
            return ret1;
        }
        
        public int[] SearchRange(int[] nums, int target) // works well
        {
            int[] x = new[] {-1, -1};
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target && count == 0)
                {
                    x[0] = i;
                    x[1] = i;
                    count++;
                }
                else if (nums[i] != target && count > 0)
                {
                    x[1] = i - 1;
                    break;
                }
                else if (nums[i] == target && i == nums.Length -1)
                {
                    if (count == 0)
                    {
                        x[0] = i;
                        x[1] = i;
                    }
                    else
                        x[1] = i;
                }
            }

            return x;
        }
        
        public void SortColors(int[] nums) // works well
        {
            int[] freq = new[] {0, 0, 0};
            foreach (var va in nums)
                freq[va]++;

            for (int i = 0, j = 0; i < nums.Length; i++)
            {
                if (freq[j] > 0)
                    nums[i] = j;
                else
                {
                    j++;
                    i--;
                }
            }
            
        }
        
        public int[][] KClosest(int[][] points, int k)
        {
            List<int[]> x = points.ToList();
            int[][] ret = new int[k][];
            for (int i = 0; i < points.Length; i++)
            {
                double pDis = Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2);
                for (int j = i + 1; j < points.Length; j++)
                {
                    double sDis = Math.Pow(points[j][0], 2) + Math.Pow(points[j][1], 2);
                    if (pDis > sDis)
                    {
                        (points[i], points[j]) = (points[j], points[i]);
                        // int[] temp = points[i];
                        // points[i] = points[j];
                        // points[j] = temp;
                        break;
                    }
                }
            }

            for (int i = 0; i < ret.Length; i++)
                ret[i] = points[i];
            

            return ret;
        }
        
        public int MostWordsFound(string[] sentences) // very easy
        {
            List<string> temp = sentences[0].Split(' ').ToList();
            int max = temp.Count;
            for (int i = 1; i < sentences.Length; i++)
            {
                temp = sentences[i].Split(' ').ToList();
                max = temp.Count > max ? temp.Count : max;
            }

            return max;
        }

        public bool cusChecker(int[] arr, int start, int end) // companion function for the next one
        {
            List<int> temp = new List<int>();
            for (int i = start; i < end; i++)
                temp.Add(arr[i]);
            temp.Sort();
            int dif = temp[1] - temp[0];
            for (int i = 2; i < temp.Count; i++)
                if (temp[i] - temp[i -1] != dif)
                    return false;
            return true;
        }
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r) // works well
        {
            List<bool> ret = new List<bool>();
            for (int i = 0; i < l.Length; i++)
            {
                bool x = cusChecker(nums, l[i], r[i]);
                ret[i] = x;
            }

            return ret;
        }
        
        public int NumIdenticalPairs(int[] nums) // works well
        {
            int goodPairs = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[j] == nums[i])
                        goodPairs++;
            }
            return goodPairs;
        }
        
        public int ShortestSubarray(int[] nums, int k)
        {
            int st = k;
            int currCounter = -1;
            int newCounter = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    st -= nums[j];
                    newCounter++;
                    if (st == 0 )
                        break;
                }

                if (st == 0)
                {
                    currCounter = newCounter < currCounter ? newCounter + 1 : currCounter;
                    continue;
                }
                st = k;
                currCounter = newCounter;
                
                newCounter = -1;
            }

            return currCounter;
        }

        public static int diagonalDifference(List<List<int>> arr) // easyly works
        {
            int sumR = 0;
            for (int i = 0; i < arr.Count; i++)
                sumR += arr[i][i];
            int sumL = 0;
            for (int i = arr.Count - 1; i >= 0; i--)
                sumL += arr[(arr.Count - 1) - i][i];
            
            return Math.Abs(sumR - sumL);
        }
        
        public static void plusMinus(List<int> arr) // works
        {
            int negative = 0;
            int positive = 0;
            int zero = 0;
            foreach (var va in arr)
            {
                if (va < 0)
                    negative++;
                else if (va > 0)
                    positive++;
                else
                    zero++;
            }

            double neg = (double)negative / arr.Count;
            Console.WriteLine(neg.ToString("F6"));
            double pos = (double)positive / arr.Count;
            Console.WriteLine(pos.ToString("F6"));
            double zer = (double)zero / arr.Count;
            Console.WriteLine(zer.ToString("F6"));
        }
        
        public static void staircase(int n) // solved
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(j >= n - i - 1 ? "#" : " ");
                Console.WriteLine();
            }
        }
        
        // given an array of 5 integers calculate the min and max sum of any four elements
        public static void miniMaxSum(List<int> arr) // works
        {
            arr.Sort();
            ulong min = 0;
            ulong max = 0;
            for (int i = 0; i < arr.Count - 1; i++)
                min += (ulong)arr[i];
            for (int i = 1; i < arr.Count; i++)
                max += (ulong)arr[i];
            Console.WriteLine($"{min} {max}");
        }
        
        public static string timeConversion(string s) // works
        {
            string ds = s.Substring(8);
            string tm = s.Substring(0, 8);
            List<int> tim = tm.Split(':').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            tim[0] = tim[0] % 12;
            string mm = tim[1].ToString("D2");
            string ss = tim[2].ToString("D2");
            string hh = ds == "PM" ? (tim[0] + 12).ToString("D2") : tim[0].ToString("D2");
            
            return $"{hh}:{mm}:{ss}";
        }

        public class ListNode // companion class for the below function
        {
            public int val;
            public ListNode next;
            
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) // ACCEPTED
        {
            List<int> first = new List<int>();
            while (l1 != null)
            {
                first.Add(l1.val);
                l1 = l1.next;
            }

            List<int> second = new List<int>();
            while (l2 != null)
            {
                second.Add(l2.val);
                l2 = l2.next;
            }

            List<int> sum = new List<int>();
            int carry = 0;
            for (int i = 0; i < first.Count || i < second.Count; i++)
            {
                if (i >= first.Count || i >= second.Count)
                {
                    if (i >= first.Count) // if the first list has ended
                    {
                        var su = second[i] + carry;
                        carry = su >= 10 ? 1 : 0;
                        su = carry == 1 ? su - 10 : su;
                        sum.Add(su);
                    }
                    else // if the second end has ended before the first
                    {
                        var su = first[i] + carry;
                        carry = su >= 10 ? 1 : 0;
                        su = carry == 1 ? su - 10 : su;
                        sum.Add(su);
                    }
                }
                else
                {
                    var su = first[i] + second[i] + carry;
                    carry = su >= 10 ? 1 : 0;
                    su = carry == 1 ? su - 10 : su;
                    sum.Add(su);
                }
            }

            if (carry == 1)
                sum.Add(1);
            ListNode temp = new ListNode(sum[0], null);
            ListNode ret = temp;
            for (int i = 1; i < sum.Count; i++)
            {
                temp.next = new ListNode(sum[i], null);
                temp = temp.next;
            }
            
            return ret;
        }
        public ListNode improvedAddTwoNumbers(ListNode l1, ListNode l2) // faster version of the above code
        {
            ListNode ret = null;
            ListNode currNode = null;
            int carry = 0;
            
            while (l1 != null || l2 != null)
            {
                int one = l1?.val ?? 0;
                int two = l2?.val ?? 0;
                // int one = l1 == null ? 0 : l1.val; // longer version of the above 2 lines of code
                // int two = l2 == null ? 0 : l2.val;
                int sum = one + two + carry;

                carry = sum / 10;
                sum %= 10;
                var temp = new ListNode(sum, null);
                
                if (ret == null)
                {
                    currNode = temp;
                    ret = temp;
                }
                else
                {
                    currNode.next = temp;
                    currNode = temp;
                }
                
                l1 = l1?.next;
                l2 = l2?.next;
                // if (l1 != null) // longer version of the 2 line code above
                //     l1 = l1.next;
                // if (l2 != null)
                //     l2 = l2.next;
            }
            if (carry == 1 && currNode != null) 
                currNode.next = new ListNode(1);
            
            return ret;
        }
        public ListNode AddTwoNumbersTwo(ListNode l1, ListNode l2) // accepted
        {
            List<int> first = new List<int>();
            while (l1 != null)
            {
                first.Add(l1.val);
                l1 = l1.next;
            }

            first.Reverse();
            
            List<int> second = new List<int>();
            while (l2 != null)
            {
                second.Add(l2.val);
                l2 = l2.next;
            }

            second.Reverse();

            List<int> sum = new List<int>();
            int carry = 0;
            for (int i = 0; i < first.Count || i < second.Count; i++)
            {
                if (i >= first.Count || i >= second.Count)
                {
                    if (i >= first.Count) // if the first list has ended
                    {
                        var su = second[i] + carry;
                        carry = su >= 10 ? 1 : 0;
                        su = carry == 1 ? su - 10 : su;
                        sum.Add(su);
                    }
                    else // if the second end has ended before the first
                    {
                        var su = first[i] + carry;
                        carry = su >= 10 ? 1 : 0;
                        su = carry == 1 ? su - 10 : su;
                        sum.Add(su);
                    }
                }
                else
                {
                    var su = first[i] + second[i] + carry;
                    carry = su >= 10 ? 1 : 0;
                    su = carry == 1 ? su - 10 : su;
                    sum.Add(su);
                }
            }

            if (carry == 1)
                sum.Add(1);
            sum.Reverse();
            ListNode temp = new ListNode(sum[0], null);
            ListNode ret = temp;
            for (int i = 1; i < sum.Count; i++)
            {
                temp.next = new ListNode(sum[i], null);
                temp = temp.next;
            }
            
            return ret;
        }
        
        public int RemoveDuplicates(int[] nums) // works
        {
            int j = 0;
            for (int i = 1; i < nums.Length && j < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i - 1])
                    nums[++j] = nums[i];
            }

            int ret = nums.Length > 0 ? ++j : 0;
            for (; j < nums.Length; j++)
                nums[j] = -101;

            return ret;
        }
        
        public int RemoveDuplicatesTwo(int[] nums) {
            int j = 0;
            int counter = 0;
            for (int i = 1; i < nums.Length && j < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i - 1] && counter < 2)
                {
                    nums[++j] = nums[i];
                    counter++;
                }
                else if (nums[i] == nums[i - 1] && counter > 2)
                    continue;
                else
                {
                    counter = 0;
                    nums[++j] = nums[i];
                }
            }

            int ret = nums.Length > 0 ? ++j : 0;
            for (; j < nums.Length; j++)
                nums[j] = -101;

            return ret;
        }
        
        public static int lonelyinteger(List<int> a) // works
        {
            var temp1 = new Dictionary<int, int>();
            foreach (var va in a)
            {
                if (temp1.ContainsKey(va))
                    temp1[va]++;
                else
                    temp1.Add(va, 1);
            }
            return (from va in temp1 where va.Value == 1 select va.Key).FirstOrDefault();
        }
        
        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[arr.Count / 2];
        }
        
        public static int flippingMatrix(List<List<int>> matrix) // don't know how to do it ???
        {
            
            return 0;
        }
        
    }
}