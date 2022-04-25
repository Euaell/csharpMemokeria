using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace memokeria
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
        { 
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    
    class Solution {
        
        public static void PrintColl<T>(IEnumerable<T> x) // prints any collections
        {
            foreach (var va in x)
                Console.Write($" {va} ");
            
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
                    string temp = String.Concat(Enumerable.Repeat(DecodeString(s.Substring(i, pass)), int.Parse(inp)));
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

            for (int i = re.Length - 1; i >= 0; i--)
                tobeReturned += re[i];
            Int32.TryParse(tobeReturned, out retr);
            return retr;
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
        
        public int[] SearchRange(int[] nums, int target) // works
        {
            int[] ret = {-1, -1};
            if (nums.Length == 0)
                return ret;

            int left = 0;
            int right = nums.Length - 1;
            int mid = left;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] == target)
                {
                    ret[0] = mid;
                    ret[1] = mid;
                    break;
                }
            }

            if (ret[0] == -1) return ret;
            
            int right1 = mid;
            int left1 = mid;
            // Find the starting
            while (left <= right1)
            {
                mid = left + (right1 - left) / 2;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right1 = mid - 1;
            }

            ret[0] = left;
            // Find the ending
            while (left1 <= right)
            {
                mid = left1 + (right1 - left1) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left1 = mid + 1;
            }

            ret[1] = right;
            return ret;
        }
        
        public int[] TwoSum(int[] numbers, int target) // works
        {
            int[] ret = new int[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                int expected = target - numbers[i];
                ret[0] = i + 1; // 1 - INDEXED
                int left = i + 1;
                int right = numbers.Length - 1;
                
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (numbers[mid] < expected)
                        left = mid + 1;
                    else if (numbers[mid] > expected)
                        right = mid - 1;
                    else
                    {
                        ret[1] = mid + 1;
                        return ret;
                    }
                }
            }
            
            return ret;
        }
        
        public bool CheckIfExist(int[] arr) // works
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                int left;
                int right;
                int mid;
                if (arr[i] < 0)
                {
                    left = 0;
                    right = i + 1;
                    mid = right;
                }
                else
                {
                    left = i + 1;
                    right = arr.Length - 1;
                    mid = left;
                }
                
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (arr[mid] < arr[i] * 2)
                        left = mid + 1;
                    if (arr[mid] > arr[i] * 2)
                        right = mid - 1;
                    if (arr[mid] == arr[i] * 2)
                        break;
                }

                if (arr[mid] == arr[i] * 2) return true;
            }

            return false;
        }
        
        public int NthUglyNumber(int n, int a, int b, int c) // doesn't work
        {
            int uglyNo = a;
            int counter = 0;
            int index = 2;
            while (counter < n)
            {
                if (index % a == 0 || index % b == 0 || index % c == 0)
                {
                    uglyNo = index;
                    counter++;
                }

                index++;
            }
            // Console.Write("ugly numbers:  ");
            // PrintColl(uglyNo);
            return uglyNo;
        }
        
        public bool SearchMatrix(int[][] matrix, int target) // works
        {
            foreach (var rw in matrix)
            {
                int left = 0;
                int right = rw.Length - 1;
                int mid = 0;
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (rw[mid] < target)
                        left = mid + 1;
                    if (rw[mid] > target)
                        right = mid - 1;
                    if (rw[mid] == target)
                        break;
                }

                if (rw[mid] == target) return true;
            }

            return false;
        }
        
        public bool SearchMatrixII(int[][] matrix, int target) // works
        {
            foreach (var t in matrix)
                foreach (var va in t)
                        if (va == target) return true;

            return false;
        }
        
        public int DominantIndex(int[] nums) // works
        {
            int max = nums[0];
            int maxIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] * 2 > max)
                    return -1;
            }

            return maxIndex;
        }
        
        public int FindFinalValue(int[] nums, int original) // works
        {
            Array.Sort(nums);
            while (true)
            {
                int left = 0;
                int right = nums.Length - 1;
                int mid = left;
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (nums[mid] < original)
                        left = mid + 1;
                    if (nums[mid] > original)
                        right = mid - 1;
                    if (nums[mid] == original)
                        break;
                }
                if (nums[mid] == original) original *= 2;
                else break;
            }
            return original;
        }
        
        public void SortColors(int[] nums) // works well
        {
            int[] freq = {0, 0, 0};
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) // works
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
            ListNode temp = new ListNode(sum[0]);
            ListNode ret = temp;
            for (int i = 1; i < sum.Count; i++)
            {
                temp.next = new ListNode(sum[i]);
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
                var temp = new ListNode(sum);
                
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
            ListNode temp = new ListNode(sum[0]);
            ListNode ret = temp;
            for (int i = 1; i < sum.Count; i++)
            {
                temp.next = new ListNode(sum[i]);
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
        
        public int RemoveDuplicatesTwo(int[] nums) 
        {
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
        
        public IList<string> FizzBuzz(int n)
        {
            var ret = new List<string>();
            for (var i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    ret.Add("FizzBuzz");
                else if (i % 3 == 0)
                    ret.Add("Fizz");
                else if (i % 5 == 0)
                    ret.Add("Buzz");
                else
                    ret.Add(i.ToString());
            }

            return ret;
        }
        
        public string KthLargestNumber(string[] nums, int k)
        {
            List<int> x = new List<int>(); // stores digit number from 1 to 100
            foreach (var v in nums)
                x[nums.Length] += 1;

            int tempK = k;
            x.Reverse();
            int dig = 0;
            for (int i = x.Count - 1; i >= 0; i--)
            {
                tempK -= x[i];
                if (tempK <= 0)
                {
                    dig = i;
                }
            }
            for (var i = 0; i < 100; i++)
            {
                k -= x[i];
                if (k <= 0)
                    dig = 100 - i;
            }

            var xdig = new List<string>(100 - dig);
            xdig.AddRange(nums.Where(vNum => vNum.Length == dig));
            xdig.Sort();

            return xdig[xdig.Capacity - k];
        }

        public int MinSetSize(int[] arr)
        {
            var freq = new Dictionary<int, int>(arr.Max());
            foreach (var va in arr)
            {
                if (freq.ContainsKey(va))
                    freq[va]++;
                else
                    freq.Add(va, 1);
            }
                
            int ret = 0;
            while (ret < arr.Length)
            {
                int max = freq.Values.Max();
                int key = freq.Max(kvp => kvp.Key);
                ret += 1;
                freq.Remove(key);
            }
            return ret;
        }
        
        public int Fib(int n) // works (slow, use array to store calculated results)
        {
            
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Fib(n - 1) + Fib(n - 2);
            }
        }
        
        Dictionary<Tuple<int, int>, int> _winnerDp = new Dictionary<Tuple<int, int>, int>();
        int Rec(int [] nums, int sINd, int eInd)
        {
            if (!_winnerDp.ContainsKey(new Tuple<int, int>(sINd + 1, eInd)))
                _winnerDp.Add(new Tuple<int, int>(sINd + 1, eInd),Rec(nums, sINd + 1, eInd));
            if (!_winnerDp.ContainsKey(new Tuple<int, int>(sINd, eInd - 1)))
                _winnerDp.Add(new Tuple<int, int>(sINd, eInd - 1),Rec(nums, sINd, eInd - 1));
                
            // return sINd == eInd ? nums[sINd] : Math.Max(nums[sINd] - dp[new []{sINd + 1, eInd}], nums[eInd] - dp[new []{sINd, eInd - 1}]);
            return sINd > eInd
                ? 0
                : Math.Max(nums[sINd] - _winnerDp[new Tuple<int, int>(sINd + 1, eInd)], nums[eInd] - _winnerDp[new Tuple<int, int>(sINd, eInd - 1)]);
        }
        public bool PredictTheWinner(int[] nums)
        {
            return Rec(nums, 0, nums.Length - 1) >= 0;
        }
        
        
        public ListNode[] SplitListToParts(ListNode head, int k) // works
        {
            ListNode slow = head;
            int size = 0;
            while (slow != null){
                size++;
                slow = slow.next;
            }

            ListNode [] ret = new ListNode[k];
            slow = head;

            for (int i = 0; i < k; i++)
            {
                ListNode prev = slow;
                ret[i] = slow;
                for (int j = 0; j < size / k + (i >= size % k ? 0 : 1); j++)
                {
                    prev = slow;
                    slow = slow?.next;
                }
                if (prev != null) prev.next = null;
            }
            return ret;
        }
        
        public ListNode OddEvenList(ListNode head) // works
        {
            if (head == null)
                return null;
            ListNode odd = head;
            ListNode even = head.next;
        
            ListNode evenHead = even;
        
            while (even?.next != null){
                odd.next = even.next;
                odd = odd.next;
            
                even.next = odd.next;
                even = even.next;
            }
        
            odd.next = evenHead;
            return head;
        }
        
        public ListNode RemoveElements(ListNode head, int val) // works
        {
            ListNode temp = head;
            ListNode prev = null;
        
            while(temp != null && head != null){
                // Console.WriteLine(temp.val);
                if (temp.val == val){
                    if (prev == null){
                        head = head.next;
                        temp = head;
                    }
                    else{
                        prev.next = temp.next;
                        temp = temp.next;
                    }
                    continue;
                }
                
                prev = temp;
                temp = temp.next;
            }
            return head;
        }
        
        public bool IsPalindrome(int x) // works
        {
            string y = x.ToString();
            char[] charArray = y.ToCharArray();
            Array.Reverse( charArray );
            return y == new string( charArray );
        }
        
        public bool IsPalindrome(ListNode head) // works
        {
            Stack<int> x = new Stack<int>();
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next?.next != null)
            {
                x.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }
            x.Push(slow.val);
            // for even length choose the next node as a middle
            if (fast.next != null && fast.next.next == null)
                slow = slow.next;

            // slow is equal to the middle of the list
            while (slow != null)
            {
                // Console.WriteLine($"{slow.val}");
                if (x.Count() != 0 && x.Pop() != slow.val)
                    return false;
                slow = slow.next;
            }

            return true;
        }
        
        public ListNode MergeNodes(ListNode head) //??
        {
            int tempSum = 0;
            ListNode temp = head;
            ListNode b = new ListNode();
            ListNode bTemp = b;
            
            while (head != null)
            {
                if (head.val == 0) 
                {
                    if (tempSum != 0) // closing zero
                    {
                        bTemp.val = tempSum;
                        tempSum = 0;
                    }
                    if (head.next != null) // zero in the middle
                        bTemp = bTemp.next = new ListNode();
                }

                tempSum += temp.val;
                head = head.next;
            }

            return b;
        }

        public int PairSum(ListNode head) // works
        {
            Stack<int> x = new Stack<int>();
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next?.next != null)
            {
                x.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }
            x.Push(slow.val);
            // for even length choose the next node as a middle
            if (fast.next != null && fast.next.next == null)
                slow = slow.next;
            
            // slow is equal to the middle of the list
            int mts = 0;
            while (slow != null)
            {
                int temp = x.Pop() + slow.val;
                mts = temp > mts ? temp : mts;
                slow = slow.next;
            }

            return mts;
        }
        
        public ListNode ReverseList(ListNode head) // works
        {
            ListNode prev = null;
           
            while (head != null)
            {
                var temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }
            return prev;
        }
        
        public ListNode ReverseBetween(ListNode head, int left, int right) //??
        {
            ListNode currNode = head.next;
            ListNode prevNode = head;
            // ListNode nextNode = head.next;
            int count = right - left;
            while (currNode != null)
            {
                left--;
                if (left == 0)
                {
                    
                }
                
                currNode = currNode.next;
            }

            return null;
        }
        
        public int NumComponents(ListNode head, int[] nums) //works
        {
            HashSet<int> x = nums.ToHashSet();
            int count = 0;
            int cur = 0;
            while (head != null)
            {
                if (x.Contains(head.val))
                    cur++;
                else
                    if (cur > 0)
                    {
                        count++;
                        cur = 0;
                    }
                head = head.next;
            }

            return cur > 0 ? count + 1 : count;
        }
        
        public void Rotate(int[] nums, int k) // works
        {
            if (nums == null)
                return;
            int[] ret = new int[nums.Length];
            Array.Copy(nums, ret, nums.Length);
            int r = k % nums.Length;
            int startInd = nums.Length - r;
            int c = 0;
            for (int i = startInd; i < nums.Length; i++)
                nums[c++] = ret[i];
            for (int i = 0; i < startInd; i++)
                nums[c++] = ret[i];
        }
        
        public ListNode RotateRight(ListNode head, int k) // works
        {
            if (head == null)
                return null;
            int size = 0;
            ListNode tempNode = head;
            
            while (tempNode != null)
            {
                size++;
                tempNode = tempNode.next;
            }
            
            int i = k%size;
            tempNode = head;
            ListNode prevNode = null;
            ListNode newStart = head;
            
            while (i-- > 0)
            {
                while (tempNode.next != null)
                {
                    prevNode = tempNode;
                    tempNode = tempNode.next;
                }
                if ( tempNode == newStart) break;
                tempNode.next = newStart;
                newStart = tempNode;
                if (prevNode != null) prevNode.next = null;
            }

            return tempNode;
        }
        
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) // works
        {
            var ret = new ListNode();
            var last = ret;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    last.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    last.next = list2;
                    list2 = list2.next;
                }
                last = last.next;
            }

            if (list1 != null)
                last.next = list1;
            if (list2 != null)
                last.next = list2;
            return ret.next;
        }
        
        public ListNode MiddleNode(ListNode head) // works
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast.next != null && fast.next.next == null)
                slow = slow.next;

            return slow;
        }
        
        public ListNode DeleteMiddle(ListNode head) // works
        {
            if (head.next == null)
                return null;
            
            ListNode fast = head;
            ListNode slow = head;
            ListNode prevSlow = slow;
            
            while (fast.next?.next != null)
            {
                prevSlow = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast.next != null && fast.next.next == null){
                prevSlow = slow;
                slow = slow.next;
            }
            
            prevSlow.next = slow.next;

            return head;
        }
        
        public void ReorderList(ListNode head) // works
        {
            ListNode first = head;
            ListNode mid = ReverseList(MiddleNode(head));

            while (first != null && mid != null)
            {
                ListNode temp = first.next;
                first.next = mid;
                first = temp;
            
                temp = mid.next;
                mid.next = first;
                mid = temp;
            }
            if(first!= null)
                first.next=null ;
        }
        
        public int[] SortedSquares(int[] nums) // works
        {
            int left = 0;
            int right = nums.Length - 1;
            int[] ret = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                    ret[i] = nums[left] * nums[left++];
                else
                    ret[i] = nums[right] * nums[right--];
            }

            return ret;
        }
        
        public ListNode SortList(ListNode head) // works
        {
            if (head?.next == null)
                return head;
            ListNode fast = head;
            ListNode slow = head;
            ListNode hold = head;
            while (fast.next?.next != null)
            {
                hold = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast.next != null && fast.next.next == null)
            {
                hold = slow;
                slow = slow.next;
            }

            hold.next = null; // separate the two lists
            return MergeTwoLists(SortList(head), SortList(slow));
        }
        
        public bool HasCycle(ListNode head) // works
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();
            while (head != null)
            {
                if (visited.Contains(head))
                    return true;
                visited.Add(head);
                head = head.next;
            }

            return false;
        }
        
        public ListNode DetectCycle(ListNode head) // works
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();
            while (head != null)
            {
                if (visited.Contains(head))
                    return head;
                visited.Add(head);
                head = head.next;
            }

            return null;
        }
        
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) // works
        {
            ListNode temp = headA;
            HashSet<ListNode> visited = new HashSet<ListNode>();
            while (temp != null)
            {
                visited.Add(temp);
                temp = temp.next;
            }

            temp = headB;
            while (temp != null)
            {
                if (visited.Contains(temp))
                    return temp;
                temp = temp.next;
            }

            return null;
        }
        
        public string[] FindRestaurant(string[] list1, string[] list2) // works
        {
            List<string> ret = new List<string>();
            Dictionary<string, int> shared =
                list1.Select((v, i) => new {Key = v, Value = i}).ToDictionary(o => o.Key, o => o.Value);
            // HashSet<string> shared = list1.ToHashSet();
            int min = int.MaxValue;
            for (int i = 0; i < list2.Length; i++)
            {
                if (shared.ContainsKey(list2[i]))
                {
                    int temp = shared[list2[i]] + i;
                    if (min > temp)
                    {
                        min = temp;
                        ret.Clear();
                        ret.Add(list2[i]);
                    }
                    else if (min == temp)
                        ret.Add(list2[i]);
                }
            }
            
            return ret.ToArray();
        }
        
        public int MinMutation(string start, string end, string[] bank) // doesn't work
        {
            HashSet<string> bank1 = bank.ToHashSet();
            bank1.Add(start);
            char[] s = start.ToCharArray();
            int counter = 0;
            for (int i = 0; i < 8; i++)
            {
                if (s[i] != end[i])
                {
                    s[i] = end[i];
                    if (bank1.Contains(new string(s)))
                        counter++;
                    else
                        for (int j = 0; j < 8; j++)
                        {
                             
                        }
                }
            }

            return counter;
        }
        
        public int MySqrt(int x) //works 
        {
            long left = 1;
            long right = x;
            while (left < right){
                int mid = (int)(left + (right - left) / 2);
                long squr = (long)mid * mid;
                // Console.WriteLine($"Left: {left} Right: {right}");
                if (squr == x)
                    return mid;
                if (squr < x)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (left == right)
                return left * left > x ? (int)left - 1 : (int)left;
            
            return (int)right;
        }
        
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) // works
        {
            int count = 0;
            foreach(var va in arr1)
            {
                if (arr2.Any(vb => Math.Abs(va - vb) <= d))
                    count--;
                count++;
            }
            return count;
        }

        private int[] digitize(int n)
        {
            int[] digits = new int[10];
            
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = n / (int) Math.Pow(10, i + 1);
                n %= (int) Math.Pow(10, i);
            }

            return digits;
        }
        private Dictionary<int, int> _happyDp = new Dictionary<int, int>();
        public bool IsHappy(int n) // works
        {
            while (true)
            {
                if (n == 1) return true;

                if (_happyDp.ContainsKey(n))
                    return false;
                
                _happyDp.Add(n, digitize(n).Sum(va => va * va));
                n = _happyDp[n];
            }
        }
        
        public int FindPeakElement(int[] nums) // works
        {
            int left = 0;
            int right = nums.Length - 1;
        
            while (left < right)
            {
                int mid = (right + left) / 2;
                if (nums[mid] < nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }
        
        public static int[] FindPeakGrid(int[][] mat) //??
        {
            int[] ret = {0, 0};
            for (int i = 0; i < mat.Length; i++){
                int left = 0;
                int right = mat[i].Length - 1;
                int mid = (right + left) / 2;
                
                while ( left <= right  && mid < mat[i].Length - 1){
                    mid = (right + left) / 2;

                    if (mat[i][mid] < mat[i][mid + 1])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                Console.WriteLine($"mat[i][mid] : {mat[i][mid]}");
                if (i == 0 && i == mat.Length - 1)
                    return new[] {i, mid};
                if (i == 0 && mat[i + 1][mid] < mat[i][mid])
                    return new []{i, mid};
                if (i == mat.Length - 1 && mat[i - 1][mid] < mat[i][mid])
                    return new[] {i, mid};
                if (mat[i][mid] > mat[i + 1][mid] && mat[i][mid] > mat[i - 1][mid])
                    return new[] {i, mid};
            }

            return ret;
        }
        
        public char NextGreatestLetter(char[] letters, char target) // works
        {
            int size = letters.Length;
        
            int left = 0;
            int right = size - 1;
            int ret = left;
        
            while (left <= right){
                int mid = (right + left) / 2;
            
                if (letters[mid] > target) {
                    ret = mid;
                    right = mid - 1;
                }
                else
                {
                    if (mid == size - 1)
                        ret = 0;
                    left = mid + 1;
                }

            }
            return letters[ret];
        }
        
        public int CountElements(int[] nums) // works
        {
            Array.Sort(nums);
            
            int min = nums[0];
            int max = nums[nums.Length - 1];
            int ret = 0;
            
            for (int i = 1; i < nums.Length - 1; i++)
                ret = nums[i] > min && nums[i] < max ? ret + 1 : ret;
            

            return ret;
        }

        private bool IsPatMatch(string x, string p)
        {
            Dictionary<char, char> pattern = new Dictionary<char, char>();
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < p.Length; i++)
            {
                if (!pattern.ContainsKey(p[i]))
                {
                    if (seen.Contains(x[i])) return false;
                    seen.Add(x[i]);
                    pattern.Add(p[i], x[i]);
                }
                else if(pattern[p[i]] != x[i])
                    return false;
            }

            return true;
        }
        public IList<string> FindAndReplacePattern(string[] words, string pattern) // works
        {
            return words.Where(word => IsPatMatch(word, pattern)).ToList();
        }
        
        public int[][] Merge(int[][] intervals)
        {
            // var x = intervals.ToList();
            // x.Sort();
            for (int i = 0; i < intervals.Length; i++)
            {
                
            }

            return null;
        }
        public int CountNegatives(int[][] grid) // works
        {
            return grid.Sum(gr => gr.Count(va => va < 0));
        }
        
        public int MaxIncreaseKeepingSkyline(int[][] grid) // ??
        {
            int n = grid.Length;
            int[] rowMaxes = new int[n];
            int[] colMaxes = new int[n];

            for (int r = 0; r < n; ++r)
                for (int c = 0; c < n; ++c) {
                    rowMaxes[r] = Math.Max(rowMaxes[r], grid[r][c]);
                    colMaxes[c] = Math.Max(colMaxes[c], grid[r][c]);
                }

            int ans = 0;
            for (int r = 0; r < n; ++r)
                for (int c = 0; c < n; ++c)
                    ans += Math.Min(rowMaxes[r], colMaxes[c]) - grid[r][c];

            return ans;
        }
        
        public bool CheckPossibility(int[] nums)
        {
            int count = 0;
            int min = int.MinValue;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (nums[i + 1] > min) count++;
                    else return false;
                }
                else min = nums[i];
                
                
                if (count > 1) break;
            }
            
            return count <= 1;
        }
        
        public int MissingNumber(int[] nums) // works
        {
            int sum = nums.Length * (nums.Length + 1) / 2;
            return nums.Aggregate(sum, (current, i) => current - i);
        }

        private HashSet<int> fmp;
        private void incRet(ref int ret)
        {
            while (fmp.Contains(++ret)) ;
        }
        public int FirstMissingPositive(int[] nums) // works
        {
            fmp = nums.ToHashSet();
            int ret = 1;
            foreach (var t in nums)
                if (t > 0 && t == ret)
                    incRet(ref ret);

            return ret;
        }
        
        public int FindDuplicate(int[] nums) // doesn't work
        {
            int sum = nums.Length * (nums.Length - 1) / 2;
            return nums.Sum() - sum;
        }

        public char FindTheDifference(string s, string t) // doesn't work
        {
            HashSet<char> x = s.ToHashSet();
            foreach(var c in t){
                if (!x.Contains(c))
                    return c;
                x.Remove(c);
            }

            return '\0';
        }
        
        public int SingleNumber(int[] nums) 
        {
            Array.Sort(nums);
            int ret = nums[0];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) continue;
                ret = nums[i];
                break;
            }

            return ret;
        }

        private (int, int)[] direction = {(1, 0), (0, 1), (-1, 0), (0, -1)};
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) // works
        {
            int maxRow = image.Length;
            int maxCol = image[0].Length;

            bool isValid(int row, int col)
            {
                return row < maxRow && row >= 0 && col < maxCol && col >= 0;
            }

            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            Queue<(int, int)> x = new Queue<(int, int)>();
            int oldColor = image[sr][sc];
            
            x.Enqueue((sr, sc));
            
            while (x.Count != 0)
            {
                var (r, c) = x.Dequeue();
                image[r][c] = newColor;
                visited.Add((r, c));
                
                foreach (var (t1, t2) in direction)
                    if (isValid(r + t1, c + t2) && image[r + t1][c + t2] == oldColor && !visited.Contains((r + t1, c + t2))) x.Enqueue((r + t1, c + t2));

            }

            return image;
        }
        
        private Dictionary<int, List<int>> dia = new Dictionary<int, List<int>>();
        private void SDia(int row, int col, int[][] mat)
        {
            dia.Add(row - col, new List<int>());
            while(row < mat.Length && col < mat[0].Length)
                dia[row - col].Add(mat[row++][col++]);
            dia[row - col].Sort();
        }
        private void fillDia(int row, int col, int[][] ret)
        {
            foreach (var va in dia[row - col])
                ret[row++][col++] = va;
        }
        public int[][] DiagonalSort(int[][] mat) //works
        {
            for (int i = 0; i < mat.Length; i++)
            {
                SDia(i, 0, mat);
                fillDia(i, 0, mat);
            }
            for (int i = 1; i < mat[0].Length; i++)
            {
                SDia(0, i, mat);
                fillDia(0, i, mat);
            }

            return mat;
        }
        
        public int[] KWeakestRows(int[][] mat, int k) // works
        {
            List<int> weaks = new List<int>();
            HashSet<int> vis = new HashSet<int>();
            int j = 0;
            while (j++ < mat.Length)
            {
                int weak = 0;
                while (vis.Contains(weak))
                    weak++;

                for (int i = 1; i < mat.Length; i++)
                {
                    if (vis.Contains(i)) continue;
                    
                    int cW = mat[weak].Count(x => x == 1);
                    int cI = mat[i].Count(x => x == 1);
                    if (cW > cI || (cW == cI && i < weak))
                    {
                        weak = i;
                    }
                }

                vis.Add(weak);
                weaks.Add(weak);
            }
            
            return weaks.ToArray();
        }

        // BINARY SEARCH TREE
        public TreeNode InsertIntoBST(TreeNode root, int val) // works
        {
            if (root == null)
                return new TreeNode(val);
            if (root.val > val)
            {
                // go to left
                if (root.left == null)
                    root.left = new TreeNode(val);
                else
                    InsertIntoBST(root.left, val);
            }
            else
            {
                // go to right
                if (root.right == null)
                    root.right = new TreeNode(val);
                else
                    InsertIntoBST(root.right, val);
            }

            return root;
        }

        public TreeNode SearchBST(TreeNode root, int val) // works
        {
            while (true)
            {
                if (root == null) return null;

                if (root.val > val)
                {
                    root = root.left;
                    continue;
                }

                if (root.val == val) return root;
                
                root = root.right;
            }
        }
        
    }
}