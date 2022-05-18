using System;
using System.Collections.Generic;
using System.Linq;

namespace memokeria
{
    public class BST
    {
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
        
        public int CountNodes(TreeNode root) // works
        {
            if (root == null) return 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int count = 1;

            while (q.Count != 0)
            {
                int size = q.Count;
                count += size;
                for (int i = 0; i < size; i++)
                {
                    var x = q.Dequeue();
                    if (x.left != null) q.Enqueue(x.left);
                    if (x.right != null) q.Enqueue(x.right);
                }
            }

            return count;
        }
        
        public int SingleNonDuplicate(int[] nums) // works
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right){
                int mid = left + (right - left) / 2;
                if (mid % 2 == 1) mid--;
            
                if (nums[mid] != nums[mid + 1])
                    right = mid;
                else
                    left = mid + 2;
            }
        
            return nums[right];
        }
        
        public int FindDuplicate(int[] nums) // works
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
                if (nums[i - 1] == nums[i]) return nums[i];
            
            return 0;
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
            return matrix.Any(t => t.Any(va => va == target));
        }
        
        public int SearchInsert(int[] nums, int target) // works
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = 0;
            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > target)
                    right = mid - 1;
                if (nums[mid] < target)
                    left = mid + 1;
            }

            return nums[left] >= target ? left : left + 1;
        }
        
        public IList<int> FindClosestElements(int[] arr, int k, int x) // works
        {
            (int l, int r) = (0, arr.Length - 1);
            while (r - l + 1 > k)
            {
                if (Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
                    r--;
                else
                    l++;
            }

            return arr.Skip(l).Take(r - l + 1).ToArray(); // arr[l .. (r + 1)]
        }
        
        public int FindClosestNumber(int[] nums) // works
        {
            int ret = nums[0];
            foreach (var vNum in nums)
            {
                int t = Math.Abs(vNum);
                int r = Math.Abs(ret);
                if (t < r) ret = vNum;
                else if (t == r) ret = Math.Max(ret, vNum);
            }

            return ret;
        }
        
        public ListNode RemoveNthFromEnd(ListNode head, int n) // works
        {
            int s = 0;
            ListNode x = head;
            while (x != null)
            {
                x = x.next;
                s++;
            }
            s -= n;
            
            ListNode temp = head;
            ListNode prev = null;
        
            while (s-- > 0){
                prev = temp;
                temp = temp.next;
            }
            if (prev != null) prev.next = temp.next;
            else head = head.next;
        
            return head;
        }
        
        public ListNode SwapNodes(ListNode head, int k) // works
        {
            int s = 0;
            ListNode x = head;
            while (x != null)
            {
                x = x.next;
                s++;
            }
            s -= k;

            ListNode t = head;
            while (s-- > 0)
                t = t.next;
            ListNode tB = head;
            while (k-- > 1)
                tB = tB.next;
            (t.val, tB.val) = (tB.val, t.val);
            return head;
        }
        
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;
            ListNode nxt = head.next;
            if (nxt == null) return head;
            
            (head.next, nxt.next) = (nxt.next, head);
            
            if (head.next != null)
                head.next = SwapPairs(head.next);

            return nxt;
        }
        
        
    }
}