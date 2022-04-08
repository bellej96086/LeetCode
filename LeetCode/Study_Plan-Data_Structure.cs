using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace LeetCode
{
    internal class Data_Structure_I
    {
        //Definition for singly-linked list.
        public class ListNode 
        {
             public int val;
             public ListNode next;
             public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
             }
        }
        
        //Definition for a binary tree node.
        public class TreeNode 
        {
             public int val;
             public TreeNode left;
             public TreeNode right;
             public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                 this.val = val;
                 this.left = left;
                 this.right = right;
             }
        }
        // Day 1 Array
        /// <summary>
        /// Problems 217. Contains Duplicate
        /// </summary>
        public static bool ContainsDuplicate(int[] nums)
        {
            // 416ms, 46.3MB
            //HashSet<int> numsSet = new HashSet<int>(nums);
            //return nums.Length != numsSet.Count;

            // 184ms, 52MB
            Hashtable hashtable = new Hashtable();
            foreach (int num in nums)
            {
                if (hashtable.ContainsKey(num)) return true;
                else hashtable[num] = true;
            }
            return false;

            // 220ms, 46.6MB
            //HashSet<int> numsSet = new HashSet<int>();
            //foreach (int num in nums)
            //{
            //    if (numsSet.Contains(num)) return true;
            //    else numsSet.Add(num);
            //}
            //return false;
        }
        /// <summary>
        /// Problems 53. Maximum Subarray
        /// </summary>
        public static int MaxSubArray(int[] nums)
        {
            // 303ms, 49.1MB
            //int result = nums[0], min = nums[0], subtotal = nums[0];
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    subtotal += nums[i];
            //    result = Math.Max(subtotal, Math.Max(subtotal - min, result));
            //    min = Math.Min(min, subtotal);
            //}
            //return result;

            // 188ms, 49.1MB
            int sum = nums[0],
                maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                sum = sum > nums[i] ? sum : nums[i];
                maxSum = maxSum > sum ? maxSum : sum;
            }
            return maxSum;

            // 241ms, 48MB
            //int maxSum = nums[0];
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    nums[i] = nums[i - 1] + nums[i] > nums[i] ? nums[i - 1] + nums[i] : nums[i];
            //    maxSum = maxSum > nums[i] ? maxSum : nums[i];
            //}
            //return maxSum;
        }
        // Day 2
        /// <summary>
        /// Problems 1. Two Sum
        /// </summary>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> targetDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (targetDic.ContainsKey(nums[i])) return new int[] { i, targetDic[nums[i]] }; // Get target i
                targetDic[target - nums[i]] = i; // target-num[i]=target i
            }
            throw new ArgumentException("Exactly one solution");
        }
        /// <summary>
        /// Problems 88. Merge Sorted Array
        /// </summary>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // Join & Sort, 279ms, 41.4MB
            //for (int i = m; i < m + n; i++)
            //{
            //    nums1[i] = nums2[i - m];
            //}
            //Array.Sort(nums1);

            // Put & Compare, 241ms, 41.3MB
            for (int i = nums1.Length - 1; i < m + n; i--)
            {
                if (n == 0) break; // Merge end
                nums1[i] = m == 0 ? nums2[--n] :
                           nums2[n - 1] > nums1[m - 1] ? nums2[--n] : nums1[--m];
            }
        }
        // Day 3
        /// <summary>
        /// Problems 350. Intersection of Two Arrays II
        /// </summary>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            //Array.Sort(nums1);
            //Array.Sort(nums2);
            //int i1 = 0,
            //    i2 = 0;
            //List<int> result = new List<int>();
            //while (i1 < nums1.Length && i2 < nums2.Length)
            //{
            //    if (nums1[i1] == nums2[i2])
            //    {
            //        result.Add(nums1[i1]);
            //        i1++;
            //        i2++;
            //    }
            //    else if (nums1[i1] > nums2[i2]) i2++;
            //    else i1++;                
            //}
            //return result.ToArray();

            Hashtable nums1Table = new Hashtable();
            List<int> result = new List<int>();
            foreach (int num in nums1)
            {
                nums1Table[num] = nums1Table.ContainsKey(num) ? (int)nums1Table[num] + 1 : 1;
            }
            foreach (int num in nums2)
            {
                if (nums1Table.ContainsKey(num))
                {
                    result.Add(num);
                    nums1Table[num] = (int)nums1Table[num] - 1;
                    if ((int)nums1Table[num] == 0) nums1Table.Remove(num);
                    if (nums1Table.Count == 0) break;
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Problems 121. Best Time to Buy and Sell Stock
        /// </summary>
        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 0; i < prices.Length; i++) // min/buy
            {
                for (int j = i + 1; j < prices.Length; j++) // max/sell
                {
                    if (prices[j] <= prices[i]) i = j; // more low 
                    else if (prices[j] - prices[i] > profit) profit = prices[j] - prices[i];
                }                
            }
            return profit;
        }
        // Day 4
        /// <summary>
        /// Problems 566. Reshape the Matrix
        /// </summary>
        public static int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int mat_r = mat.Length,
                mat_c = mat[0].Length;
            if (mat_r * mat_c != r * c) return mat;
            
            int[][] matrix = new int[r][];
            for (int i = 0; i < mat_r * mat_c; i++)
            {
                if (i % c == 0) matrix[i / c] = new int[c];
                matrix[i / c][i % c] = mat[i / mat_c][i % mat_c];
            }
            return matrix;
        }
        /// <summary>
        /// Problems 118. Pascal's Triangle
        /// </summary>
        public static IList<IList<int>> Generate(int numRows)
        {
            //int[][] result = new int[numRows][];
            //for (int row = 0; row < numRows; row++)
            //{
            //    result[row] = new int[row + 1];
            //    for (int col = 0; col < row + 1; col++)
            //    {
            //        result[row][col] = col == 0 || col == row ? 1 : result[row - 1][col - 1] + result[row - 1][col];
            //    }
            //}
            //return result;

            IList<IList<int>> result = new List<IList<int>>();
            for (int row = 0; row < numRows; row++)
            {
                IList<int> level = new List<int>();
                for (int col = 0; col < row + 1; col++)
                {
                    level.Add(col == 0 || col == row ? 1 : result[row - 1][col - 1] + result[row - 1][col]);
                }
                result.Add(level);
            }
            return result;
        }
        // Day 5
        /// <summary>
        /// Problems 36. Valid Sudoku
        /// </summary>
        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<char> rowSet = new HashSet<char>(),
                          colSet = new HashSet<char>(),
                          subboxSet = new HashSet<char>();
            char temp;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    temp = board[row][col]; // row
                    //Console.WriteLine(row.ToString() + "," + col.ToString());
                    if (temp != '.')
                        if (!rowSet.Contains(temp)) rowSet.Add(temp);
                        else return false;

                    temp = board[col][row]; // col
                    //Console.WriteLine(row.ToString() + "," + col.ToString());
                    if (temp != '.')
                        if (!colSet.Contains(temp)) colSet.Add(temp);
                        else return false;

                    temp = board[col / 3 + row / 3 * 3][col % 3 + row % 3 * 3]; // sub-boxes
                    //Console.WriteLine((sub_box / 3 + box / 3 * 3).ToString() + "," + (sub_box % 3 + box % 3 * 3).ToString());
                    if (temp != '.')
                        if (!subboxSet.Contains(temp)) subboxSet.Add(temp);
                        else return false;
                }
                rowSet.Clear();
                colSet.Clear();
                subboxSet.Clear();
            }
            return true;
        }
        /// <summary>
        /// Problems 74. Search a 2D Matrix
        /// </summary>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            // 遍歷
            //for (int row = 0; row < matrix.Length; row++)
            //{
            //    for (int col = 0; col < matrix[0].Length; col++)
            //    {
            //        if (matrix[row][col] == target) return true;
            //        else if (matrix[row][col] > target) return false;
            //    }
            //}
            //return false;

            // 二分法
            int m = matrix.Length,
                n = matrix[0].Length,
                left = 0,
                right = m * n - 1,
                mid,
                curr;
            if (m * n == 1) return matrix[0][0] == target;
            while (left + 1 < right)
            {
                mid = (left + right) / 2;
                curr = matrix[mid / n][mid % n];
                if (curr == target) return true;
                if (curr > target) right = mid;
                else if (curr < target) left = mid;
            }
            return matrix[right / n][right % n] == target || matrix[left / n][left % n] == target ? true : false;
        }
        // Day 6
        /// <summary>
        /// Problems 387. First Unique Character in a String
        /// </summary>
        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> dicS = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dicS.ContainsKey(s[i])) dicS[(s[i])]++;
                else dicS.Add(s[i], 1);
            }
            var temp = dicS.Where(x => x.Value == 1);
            int index = temp.Count() > 0 ? s.IndexOf(temp.First().Key) : -1;
            return index;
        }
        /// <summary>
        /// Problems 383. Ransom Note
        /// </summary>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            //Dictionary<char, int> magazineDic = new Dictionary<char, int>();
            //foreach (char letter in magazine)
            //{
            //    if (magazineDic.ContainsKey(letter)) magazineDic[letter]++;
            //    else magazineDic[letter] = 1;
            //}
            //foreach (char c in ransomNote)
            //{
            //    if (magazineDic.ContainsKey(c))
            //        if (magazineDic[c] == 0) return false;
            //        else magazineDic[c]--;
            //    else return false;
            //}
            int[] letter = new int[26];
            for (int i = 0; i < magazine.Length; i++)
            {
                letter[magazine[i] - 'a']++;
            }
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (--letter[ransomNote[i] - 'a'] < 0) return false;
            }
            return true;
        }
        /// <summary>
        /// Problems 242. Valid Anagram
        /// </summary>
        public static bool IsAnagram(string s, string t)
        {
            int[] letter = new int[26];
            if (s.Length != t.Length) return false;
            for (int i = 0; i < s.Length; i++)
            {
                letter[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (--letter[t[i] - 'a'] < 0) return false;
            }
            return true;
        }
        // Day 7
        /// <summary>
        /// Problems 141. Linked List Cycle
        /// </summary>
        public static bool HasCycle(ListNode head)
        {
            int count = 0;
            while (head != null)
            {
                if (count > 10000) return true; // 改head的value並確認也可以，不該改變未clone的ListNode(說不定還在使用?)
                count++;
                head = head.next;
            }
            return false;
        }
        /// <summary>
        /// Problems 21. Merge Two Sorted Lists
        /// </summary>
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode merge_list = new ListNode(0),
                root = merge_list,
                list;
            while (list1 != null || list2 != null)
            {
                if (list1 == null) list = list2;
                else if (list2 == null) list = list1;
                else list = list2.val > list1.val ? list1 : list2;
                root.next = new ListNode(list.val);
                root = root.next;
                if (list.Equals(list1)) list1 = list1.next;
                else if (list.Equals(list2)) list2 = list2.next;
            }
            return merge_list.next;
        }
        /// <summary>
        /// Problems 203. Remove Linked List Elements
        /// </summary>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode root = new ListNode(0, head),
                curr = root;
            while (curr.next != null)
            {
                if (curr.next.val == val) 
                {
                    curr.next = curr.next.next;
                    continue;
                }
                curr = curr.next;
            }    
            return root.next;
        }
        // Day 8
        /// <summary>
        /// Problems 206. Reverse Linked List
        /// </summary>
        public static ListNode ReverseList(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }
            ListNode reverse = new ListNode(0),
                curr = reverse;
            while (stack.Count > 0)
            {
                curr.next = new ListNode(stack.Pop());
                curr = curr.next;
            }
            return reverse.next;
        }
        /// <summary>
        /// Problems 83. Remove Duplicates from Sorted List
        /// </summary>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode root = new ListNode(-101, head),
                curr = root;
            while (curr.next != null)
            {
                if (curr.next.val == curr.val)
                    curr.next = curr.next.next;
                else
                    curr = curr.next;
            }
            return root.next;
        }
        // Day 9
        /// <summary>
        /// Problems 20. Valid Parentheses
        /// </summary>
        public static bool IsValid(string s)
        {
            if (s.Length % 2 == 1) return false;

            Stack<char> left_stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(') left_stack.Push(')');
                else if (c == '[') left_stack.Push(']');
                else if (c == '{') left_stack.Push('}');
                else if (left_stack.Count == 0 || left_stack.Pop() != c) return false;
            }
            return left_stack.Count == 0;
        }
        /// <summary>
        /// Problems 232. Implement Queue using Stacks
        /// </summary>
        public class MyQueue
        {
            private Stack<int> stack;
            private bool statu; // F = stack, T = Queue
            private void Switch() // Queue <--> Stack
            {
                stack = new Stack<int>(stack);
                statu = !statu;
            }

            public MyQueue()
            {
                stack = new Stack<int>();
                statu = false;
            }

            public void Push(int x)
            {
                if (statu) Switch();
                stack.Push(x);
            }

            public int Pop()
            {
                if (!statu) Switch();
                return stack.Pop();
            }

            public int Peek()
            {
                if (!statu) Switch();
                return stack.Peek();
            }

            public bool Empty()
            {
                return stack.Count == 0;
            }
        }
        // Day 10
        /// <summary>
        /// Problems 144. Binary Tree Preorder Traversal
        /// </summary>
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            TreeNode curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr.right);
                    result.Add(curr.val);
                    curr = curr.left;
                }
                if (stack.Count > 0) curr = stack.Pop();
            }
            return result;
        }
        /// <summary>
        /// Problems 94. Binary Tree Inorder Traversal
        /// </summary>
        public static IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            TreeNode curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                if (stack.Count > 0)
                {
                    curr = stack.Pop();
                    result.Add(curr.val);
                    curr = curr.right;
                }
            }
            return result;
        }
        /// <summary>
        /// Problems 145. Binary Tree Postorder Traversal
        /// </summary>
        public static IList<int> PostorderTraversal(TreeNode root)
        {
            TreeNode curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> result = new Stack<int>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr.left);
                    result.Push(curr.val);
                    curr = curr.right;
                }
                curr = stack.Pop();
            }
            return result.ToList();
        }
        // Day 11
        /// <summary>
        /// Problems 102. Binary Tree Level Order Traversal
        /// </summary>
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> level = new List<int>();
            Stack<TreeNode> curr = new Stack<TreeNode>(),
                next = new Stack<TreeNode>();
            if (root != null) curr.Push(root);
            while (curr.Count > 0)
            {
                while (curr.Count > 0)
                {
                    TreeNode currTree = curr.Pop();
                    level.Add(currTree.val);
                    if (currTree.left != null) next.Push(currTree.left);
                    if (currTree.right != null) next.Push(currTree.right);
                }
                if (curr.Count == 0)
                {
                    curr = new Stack<TreeNode>(next);
                    next.Clear();
                    result.Add(level);
                    level = new List<int>();
                }
            }
            return result;
        }
        /// <summary>
        /// Problems 104. Maximum Depth of Binary Tree
        /// </summary>
        public static int MaxDepth(TreeNode root)
        {
            Stack<TreeNode> curr = new Stack<TreeNode>(),
                next = new Stack<TreeNode>();
            if (root != null) curr.Push(root);
            int level = 0;
            while (curr.Count > 0)
            {
                level++;
                while (curr.Count > 0)
                {
                    TreeNode currTree = curr.Pop();
                    if (currTree.left != null) next.Push(currTree.left);
                    if (currTree.right != null) next.Push(currTree.right);
                }
                if (next.Count > 0)
                {
                    curr = new Stack<TreeNode>(next);
                    next.Clear();
                }
            }
            return level;
        }
        /// <summary>
        /// Problems 101. Symmetric Tree
        /// </summary>
        public static bool IsSymmetric(TreeNode root)
        {
            TreeNode lRoot = root.left,
                rRoot = root.right;
            Stack<TreeNode> lCurr = new Stack<TreeNode>(),
                lNext = new Stack<TreeNode>(),
                rCurr = new Stack<TreeNode>(),
                rNext = new Stack<TreeNode>();
            if (lRoot != null && rRoot != null)
            {
                lCurr.Push(lRoot);
                rCurr.Push(rRoot);
            }
            else if (lRoot == null ^ rRoot == null) return false;
            else return true;
            while (lCurr.Count > 0 || rCurr.Count > 0)
            {
                while (lCurr.Count > 0 || rCurr.Count > 0)
                {
                    TreeNode lCurrTree = lCurr.Pop(),
                        rCurrTree = rCurr.Pop();
                    if (lCurrTree.val == rCurrTree.val)
                    {
                        if (lCurrTree.left != null && rCurrTree.right != null)
                        {
                            lNext.Push(lCurrTree.left);
                            rNext.Push(rCurrTree.right);
                        }
                        else if (lCurrTree.left == null ^ rCurrTree.right == null) return false;
                        if (lCurrTree.right != null && rCurrTree.left != null)
                        {
                            lNext.Push(lCurrTree.right);
                            rNext.Push(rCurrTree.left);
                        }
                        else if (lCurrTree.right == null ^ rCurrTree.left == null) return false;
                    }
                    else return false;
                }
                if (lNext.Count > 0)
                {
                    lCurr = new Stack<TreeNode>(lNext);
                    rCurr = new Stack<TreeNode>(rNext);
                    lNext.Clear();
                    rNext.Clear();
                }
            }
            return true;
        }
        // Day 12
        /// <summary>
        /// Problems 226. Invert Binary Tree
        /// </summary>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode invert = new TreeNode(root.val),
                currInvert = invert,
                currTree = root;
            Stack<TreeNode> stackRoot = new Stack<TreeNode>(),
                stackInvert = new Stack<TreeNode>();
            if (root != null)
            {
                stackRoot.Push(root);
                stackInvert.Push(currInvert);
            }
            while (stackRoot.Count > 0)
            {
                currTree = stackRoot.Pop();
                currInvert = stackInvert.Pop();
                if (currTree.left != null)
                {
                    currInvert.right = new TreeNode(currTree.left.val);
                    stackInvert.Push(currInvert.right);
                    stackRoot.Push(currTree.left);
                }
                if (currTree.right != null)
                {
                    currInvert.left = new TreeNode(currTree.right.val);
                    stackInvert.Push(currInvert.left);
                    stackRoot.Push(currTree.right);
                }
            }
            return invert;
        }
        /// <summary>
        /// Problems 112. Path Sum
        /// </summary>
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            TreeNode curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    if (curr.left != null) curr.left.val += curr.val;
                    if (curr.right != null) curr.right.val += curr.val;
                    if (curr.left == null && curr.right == null && curr.val == targetSum) 
                        return true;
                    curr = curr.left;
                }
                if (stack.Count > 0) curr = stack.Pop().right;
            }
            return false;
        }
        // Day 13
        /// <summary>
        /// Problems 700. Search in a Binary Search Tree
        /// </summary>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            // BST(Binary Search Tree):left.val < root.val < right.val
            TreeNode curr = root;
            while (curr != null)
            {
                if (curr.val == val) return curr;
                curr = curr.val > val ? curr.left : curr.right;
            }
            return null;
        }
        /// <summary>
        /// Problems 701. Insert into a Binary Search Tree
        /// </summary>
        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            // BST(Binary Search Tree):left.val < root.val < right.val
            if (root == null) return new TreeNode(5);
            TreeNode curr = root;
            while (curr != null)
            {
                if (curr.val > val)
                {
                    if (curr.left == null)
                    {
                        curr.left = new TreeNode(val);
                        break;
                    }
                    curr = curr.left;
                }
                else
                {
                    if (curr.right == null)
                    {
                        curr.right = new TreeNode(val);
                        break;
                    }
                    curr = curr.right;
                }
            }
            return root;
        }
        // Day 14
        /// <summary>
        /// Problems 98. Validate Binary Search Tree
        /// </summary>
        public static bool IsValidBST(TreeNode root)
        {
            return helper(root);

            bool helper(TreeNode treeNode, long min = long.MinValue, long max = long.MaxValue)
            {
                if (treeNode == null) return true;
                if (treeNode.val <= min || treeNode.val >= max) return false;
                return helper(treeNode.left, min, treeNode.val) && helper(treeNode.right, treeNode.val, max);
            }
        }
        /// <summary>
        /// Problems 653. Two Sum IV - Input is a BST
        /// </summary>
        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> hs = new HashSet<int>();
            TreeNode curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    if (hs.Contains(curr.val)) return true;
                    hs.Add(k - curr.val);
                    curr = curr.left;
                }
                if (stack.Count > 0) curr = stack.Pop().right;
            }
            return false;
        }
        /// <summary>
        /// Problems 235. Lowest Common Ancestor of a Binary Search Tree
        /// </summary>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (p.val < root.val && q.val < root.val) root = root.left;
                else if (p.val > root.val && q.val > root.val) root = root.right;
                else return root;
            }
            return null;
        }
    }
    internal class Data_Structure_II
    {
        // Day 1
        /// <summary>
        /// Problems 136. Single Number
        /// </summary>
        public int SingleNumber(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>();
            foreach (int num in nums)
            {
                if (numSet.Contains(num)) numSet.Remove(num);
                else numSet.Add(num);
            }
            // return numList[0];
            return numSet.First();

            // 公式解:XOR(^)
            //int sum = 0;
            //Array.ForEach(nums, num => sum ^= num);
            //return sum;
        }
        /// <summary>
        /// Problems 169. Majority Element
        /// </summary>        
        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numDic = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (numDic.ContainsKey(num)) numDic[num]++;
                else numDic[num] = 1;
            }
            return numDic.OrderByDescending(x => x.Value).FirstOrDefault().Key;
        }
        /// <summary>
        /// Problems 15. 3Sum
        /// </summary>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            nums = nums.OrderBy(x => x).ToArray();
            IList<IList<int>> list = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i !=0 && nums[i] == nums[i - 1]) continue;

                int j = i + 1, // left
                    k = nums.Length - 1; // right
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > 0)
                        k--;
                    else if (sum < 0)
                        j++;
                    else
                    {
                        list.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        while (j < k && nums[j] == nums[j + 1])
                            j++;
                        while (k < nums.Length - 1 && nums[k] == nums[k + 1])
                            k--;
                        j++;
                    }
                }
            }
            return list;
        }
        // Day 2
        /// <summary>
        /// Problems 75. Sort Colors
        /// </summary>
        public static void SortColors(int[] nums)
        {
            int left = 0,
                right = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = nums[left];
                    nums[left++] = 0;
                }
            }
            for (int i = right; left <= i; i--)
            {
                if (nums[i] == 2)
                {
                    nums[i] = nums[right];
                    nums[right--] = 2;
                }
            }
        }
        /// <summary>
        /// Problems 56. Merge Intervals
        /// </summary>        
        public static int[][] Merge(int[][] intervals)
        {
            List<int[]> list = intervals.OrderBy(x => x[0]).ToList();
            for (int i = 1; i < list.Count;i++)
            {
                while (i < list.Count && list[i - 1][0] <= list[i][0] && list[i][0] <= list[i - 1][1])
                {
                    list[i - 1][1] = Math.Max(list[i - 1][1], list[i][1]);
                    list.RemoveAt(i);
                }
            }
            return list.ToArray();
        }
        /// <summary>
        /// Problems 706. Design HashMap
        /// </summary>
        public class MyHashMap
        {
            // 題目限定最多動作一萬次(包含初始值)，也可以用listnode
            private const int maxValue = 1000001; // limit + 1
            private int[] map;            
            public MyHashMap()
            {
                map = new int[maxValue];
                for (int i = 0; i < map.Length; i++)
                {
                    map[i] = -1;
                }
            }

            public void Put(int key, int value)
            {
                map[key] = value;
            }

            public int Get(int key)
            {
                return map[key];
            }

            public void Remove(int key)
            {
                map[key] = -1;
            }
        }
        // Day 3
        /// <summary>
        /// Problems 119. Pascal's Triangle II
        /// </summary>
        public static IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return new List<int>() { 1 };
            else if (rowIndex == 1) return new List<int>() { 1, 1 };

            List<int> list = new List<int>() { 1, 1 };
            for (int i = 2; i <= rowIndex; i++)
            {
                list.Add(1);
                for (int j = list.Count - 2; j > 0; j--)
                {
                    list[j] = list[j - 1] + list[j];
                }
            }
            return list;
        }
        /// <summary>
        /// Problems 48. Rotate Image
        /// </summary>        
        public static void Rotate(int[][] matrix)
        {
            int n = matrix.Length; // n x n matrix
            for (int row = 0; row < n / 2; row++)
            {
                for (int col = row; col < n - 1 - row; col++)
                {
                    int temp = matrix[row][col];
                    matrix[row][col] = matrix[n - 1 - col][row]; // 左上>左下
                    matrix[n - 1 - col][row] = matrix[n - 1 - row][n - 1 - col]; // 左下>右下
                    matrix[n - 1 - row][n - 1 - col] = matrix[col][n - 1 - row]; // 右下>右上
                    matrix[col][n - 1 - row] = temp; // 右上>左上
                }
            }
        }
        /// <summary>
        /// Problems 59. Spiral Matrix II
        /// </summary>
        public static int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            //int row = 0,
            //    col = 0;
            //for (int i = 1; i <= n * n; i++)
            //{
            //    matrix[row][col] = i;
            //    if ((row == n - 1 || matrix[row + 1][col] != 0) 
            //        && (col > 0 && matrix[row][col - 1] == 0)) // ←
            //        col--;
            //    else if ((col == n - 1 || matrix[row][col + 1] != 0) 
            //        && (row < matrix.Length - 1 && matrix[row + 1][col] == 0)) // ↓
            //        row++;
            //    else if (row > 0 && matrix[row - 1][col] == 0) // ↑
            //        row--;
            //    else // →
            //        col++;
            //}
            int left = 0,
                top = 0,
                right = n - 1,
                bottom = n - 1,
                number = 1;
            while (number <= n * n)
            {
                if (number == n * n) // n % 2 == 1
                {
                    matrix[left][top] = number;
                    return matrix;
                }

                for (int i = left; i < right; i++)
                {
                    matrix[left][i] = number++;
                }
                left++;

                for (int i = top; i < bottom; i++)
                {
                    matrix[i][n - 1 - top] = number++;
                }
                top++;

                for (int i = right; i >= left; i--)
                {
                    matrix[right][i] = number++;
                }
                right--;

                for (int i = bottom; i >= top; i--)
                {
                    matrix[i][n - 1 - bottom] = number++;
                }
                bottom--;
            }
            return matrix;
        }
        // Day 4
        /// <summary>
        /// Problems 240. Search a 2D Matrix II
        /// </summary>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][0] > target)
                    break;
                else if (matrix[row][matrix[0].Length - 1] < target)
                    continue;
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] > target)
                        break;
                    else if (matrix[row][col] == target)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Problems 435. Non-overlapping Intervals
        /// </summary>
        public int EraseOverlapIntervals(int[][] intervals)
        {

        }
        // Day 5
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>        

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 6
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 7
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 8
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 9
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 10
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary> 

        // Day 11
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary> 

        // Day 12
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>   

        // Day 13
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>   

        // Day 14
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>        

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 15
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>        

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 16
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>        

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 17
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>   

        // Day 18
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>  

        // Day 19
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>        

        /// <summary>
        /// Problems 
        /// </summary>

        // Day 20
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary>  

        // Day 21
        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// Problems 
        /// </summary> 

    }

}
