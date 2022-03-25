using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace LeetCode
{
    internal class Algorithm_I
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        // Day 1
        /// <summary>
        /// Problems 704. Binary Search
        /// </summary>
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            // nums.Length >= 2
            int max_i = nums.Length - 1,
                min_i = 0,
                curr_i = (max_i + min_i) / 2;

            while (min_i + 1 != max_i)
            {
                curr_i = (max_i + min_i) / 2;
                if (nums[curr_i] == target) return curr_i; // Equal
                if (nums[curr_i] > target) max_i = curr_i;
                else min_i = curr_i;
            }
            return nums[max_i] == target ? max_i :
                   nums[min_i] == target ? min_i : -1;
        }
        /// <summary>
        /// Problems 278. First Bad Version
        /// </summary>
        private static int BadVersion = 0;
        private static bool IsBadVersion(int version)
        {
            return version >= BadVersion;
        }
        public static int FirstBadVersion(int n, int bad) // 題目不包含bad
        {
            BadVersion = bad; // 題目，非解答

            if (n <= 2) return IsBadVersion(1) ? 1 : 2;
            int minVersion = 0,
                maxVersion = n,
                currVersion = (minVersion + maxVersion) / 2;
            while (maxVersion - minVersion > 1)
            {
                if (IsBadVersion(currVersion)) maxVersion = currVersion;
                else minVersion = currVersion;
                currVersion = (int)(((long)minVersion + (long)maxVersion) / 2); // int limit
            };
            return maxVersion;
        }
        /// <summary>
        /// Problems 35.Search Insert Position
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            if (nums[nums.Length - 1] < target) return nums.Length;
            else if (target <= nums[0]) return 0;

            int minlimit = 0,
                maxlimit = nums.Length - 1,
                index = (minlimit + maxlimit) / 2;
            while (maxlimit - minlimit > 1)
            {
                if (nums[index] == target) return index;

                if (target < nums[index]) maxlimit = index;
                else if (nums[index] < target) minlimit = index;
                index = (minlimit + maxlimit) / 2;
            }
            return maxlimit;
        }
        // Day 2
        /// <summary>
        /// Problems 977. Squares of a Sorted Array
        /// </summary>
        public static int[] SortedSquares(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = (int)Math.Pow(nums[i], 2);
            }
            Array.Sort(nums);
            return nums;
        }
        /// <summary>
        /// Problems 189. Rotate Array
        /// </summary>
        public static void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            if (k == 0 || nums.Length == 1) return;

            Queue<int> delay = new Queue<int>();
            for (int i = nums.Length - k; i < nums.Length; i++) // k~
            {
                delay.Enqueue(nums[i]);
            }
            for (int i = 0; i < nums.Length - k; i++) // ~k
            {
                delay.Enqueue(nums[i]);
            }

            for (int i = 0; delay.Count > 0; i++)
            {
                nums[i] = delay.Dequeue();
            }
        }
        // Day 3
        /// <summary>
        /// Problems 283. Move Zeroes
        /// </summary>
        public void MoveZeroes(int[] nums)
        {
            int n_point = 0, temp;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) continue;
                
                temp = nums[n_point];
                nums[n_point] = nums[i];
                nums[i] = temp;
                n_point++;
            }
        }
        /// <summary>
        /// Problems 167. Two Sum II - Input Array Is Sorted
        /// </summary>
        public int[] TwoSum(int[] numbers, int target)
        {
            // numbers為升序，可以再快
            //Hashtable ht = new Hashtable();
            //for (int i = 0; i <= numbers.Length; i++)
            //{
            //    if (ht.ContainsKey(numbers[i])) return new int[] { (int)ht[numbers[i]] + 1, i + 1 };
            //    ht[target - numbers[i]] = i;
            //}
            //return null;
            int left = 0, 
                right = numbers.Length - 1;
            while (left < right && numbers[left] + numbers[right] != target)
            {
                if (target - numbers[right] - numbers[left] > 0)
                    left++;
                else
                    right--;
            }
            return new int[] { left + 1, right + 1 };
        }
        // Day 4
        /// <summary>
        /// Problems 344. Reverse String
        /// </summary>
        public void ReverseString(char[] s)
        {
            char temp;
            for (int i = 0; i < s.Length / 2; i++)
            {
                temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }
        /// <summary>
        /// Problems 557. Reverse Words in a String III
        /// </summary>
        public static string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in s.Split(' '))
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sb.Append(word[i]);
                }
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }
        // Day 5
        /// <summary>
        /// Problems 876. Middle of the Linked List
        /// </summary>
        public ListNode MiddleNode(ListNode head)
        {
            // 只求一半
            ListNode half = head, 
                full = head;
            while (full != null && full.next != null)
            {
                half = half.next;
                full = full.next.next;
            }
            return half;

            // 字典，可求任何位置
            //Hashtable ht = new Hashtable();
            //int index = 0;
            //while (head != null)
            //{
            //    ht[index++] = head;
            //    head = head.next;
            //}
            //return (ListNode)ht[index / 2];
        }
        /// <summary>
        /// Problems 19. Remove Nth Node From End of List
        /// </summary>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // 找到length+得到node的list，刪除nth node
            //ListNode curr = head;
            //Hashtable ht = new Hashtable();
            //int length = 0;
            //while (curr != null)
            //{
            //    ht[length++] = curr;
            //    curr = curr.next;
            //}
            //if (length == n) return head.next;
            //ListNode remove = (ListNode)ht[length - n - 1];
            //remove.next = remove.next.next;
            //return head;

            // length=n+剩下的(length-n)，先推n再推到length得到(length-n)
            ListNode end = head,
                before_nth = head;
            for (int i = 0; i < n; i++) // n
                end = end.next;
            if (end == null) return head.next; // n = head[0]
            while (end.next != null) // (length-n)
            {
                before_nth = before_nth.next;
                end = end.next;
            }
            before_nth.next = before_nth.next.next; // Remove Nth
            return head;
        }
        // Day 6
        /// <summary>
        /// Problems 3. Longest Substring Without Repeating Characters
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1) return s.Length;
            int maxlength = 1, 
                left = 0;
            for (int right = left + 1; right < s.Length; right++)
            {
                if (s.Substring(left, right - left).Contains(s[right])) // repeat
                {
                    if (maxlength < right - left) 
                        maxlength = right - left;
                    while (s[left] != s[right]) { left++; }
                    left++;
                }
            }
            return maxlength;
        }
        /// <summary>
        /// Problems 567. Permutation in String
        /// </summary>
        public static bool CheckInclusion(string s1, string s2)
        {
            //if (s1.Length > s2.Length) return false;

            //Dictionary<char, int> dicInclusion = new Dictionary<char, int>();
            //foreach (char c in s1)
            //{
            //    if (dicInclusion.ContainsKey(c)) dicInclusion[c]++;
            //    else dicInclusion.Add(c, 1);
            //}
            //int right = 0;
            //for (int left = 0; left < s2.Length; left++)
            //{
            //    if (left > right) right = left;
            //    for (right = right; right < s2.Length; right++)
            //    {
            //        if (dicInclusion.ContainsKey(s2[right]))
            //            if (dicInclusion[s2[right]] > 0) dicInclusion[s2[right]]--;
            //            else break;
            //        else break;
            //        if (dicInclusion.Values.Sum(x => x) == 0) return true;
            //    }
            //    if (dicInclusion.ContainsKey(s2[left])) dicInclusion[s2[left]]++; // 有dics1當初始值，不會失真
            //}
            //return false;

            if (s1.Length > s2.Length) return false;
            int[] total = new int[26];
            foreach (char c in s1)
            {
                total[c - 'a']++;
            }
            int right = 0;
            for (int left = 0; left < s2.Length; left++)
            {
                right = right < left ? left : right;
                for (right = right; right < s2.Length; right++)
                {
                    if (s1.Contains(s2[right]) && total[s2[right] - 'a'] > 0) 
                        total[s2[right] - 'a']--;
                    else 
                        break;
                    if (total.Sum() == 0) 
                        return true;
                }
                if (s1.Contains(s2[left])) 
                    total[s2[left] - 'a']++;
            }
            return false;
        }
        // Day 7
        /// <summary>
        /// Problems 733. Flood Fill
        /// </summary>
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;
            int oldColor = image[sr][sc];
            image[sr][sc] = newColor;
            if (sr - 1 > -1 && image[sr - 1][sc] == oldColor) FloodFill(image, sr - 1, sc, newColor);
            if (sr + 1 < image.Length && image[sr + 1][sc] == oldColor) FloodFill(image, sr + 1, sc, newColor);
            if (sc - 1 > -1 &&image[sr][sc - 1] == oldColor) FloodFill(image, sr, sc - 1, newColor);
            if (sc + 1 < image[0].Length && image[sr][sc + 1] == oldColor) FloodFill(image, sr, sc + 1, newColor);
            return image;
        }
        /// <summary>
        /// Problems 695. Max Area of Island
        /// </summary>
        public static int MaxAreaOfIsland(int[][] grid)
        {
            int maxSize = 0;
            for (int row = 0; row < grid.Length; row++) 
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                        maxSize = Math.Max(maxSize, sizeOfIsland(row, col));                    
                }
            }
            return maxSize;
            int sizeOfIsland(int row, int col)
            {
                if (row < 0 || row == grid.Length || 
                    col < 0 || col == grid[0].Length || grid[row][col] == 0)
                    return 0;
                grid[row][col] = 0;               
                return 1 + sizeOfIsland(row - 1, col) + sizeOfIsland(row + 1, col) + sizeOfIsland(row, col - 1) + sizeOfIsland(row, col + 1);
            }
        }
        // Day 8
        /// <summary>
        /// Problems 617. Merge Two Binary Trees
        /// </summary>
        public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null) return root2;
            if (root2 == null) return root1;
            TreeNode root = new TreeNode(root1.val + root2.val);            
            root.left = MergeTrees(root1.left, root2.left);
            root.right = MergeTrees(root1.right, root2.right);
            return root;
        }
        /// <summary>
        /// Problems 116. Populating Next Right Pointers in Each Node
        /// </summary>
        public static Node Connect(Node root)
        {
            if (root == null) return null;
            int count = 1, level = 1;
            Queue<Node> curr = new Queue<Node>();
            curr.Enqueue(root);
            while (curr.Count > 0)
            {
                count++;
                Node node = curr.Dequeue();
                if (curr.Count > 0 && count < Math.Pow(2, level)) node.next = curr.Peek();
                else level++;
                if (node.left != null)
                {
                    curr.Enqueue(node.left);
                    curr.Enqueue(node.right);
                }
            }
            return root;
        }
        // Day 9
        /// <summary>
        /// Problems 542. 01 Matrix
        /// </summary>
        public static int[][] UpdateMatrix(int[][] mat)
        {
            for (int row = 0; row < mat.Length; row++) // start on (0,0)
            {
                for (int col = 0; col < mat[0].Length; col++)
                {
                    if (mat[row][col] == 1)
                    {
                        mat[row][col] = int.MaxValue - 1; // Overflow: (0,0) = MaxValue, (0,1),(1,0) = MinValue
                        if (row != 0)
                            mat[row][col] = Math.Min(mat[row][col], 1 + mat[row - 1][col]);
                        if (col != 0)
                            mat[row][col] = Math.Min(mat[row][col], 1 + mat[row][col - 1]);
                    }
                }
            }

            for (int row = mat.Length - 1; row >= 0; row--) // start on (mat.length - 1, mat.[0].length - 1)
            {
                for (int col = mat[0].Length - 1; col >= 0 ; col--)
                {
                    if (mat[row][col] > 1)
                    {
                        if (row != mat.Length - 1)
                            mat[row][col] = Math.Min(mat[row][col], 1 + mat[row + 1][col]);
                        if (col != mat[0].Length - 1)
                            mat[row][col] = Math.Min(mat[row][col], 1 + mat[row][col + 1]);
                    }
                }
            }
            return mat;
        }
        /// <summary>
        /// Problems 994. Rotting Oranges
        /// </summary>
        public static int OrangesRotting(int[][] grid)
        {
            // 0:空，1:好橘子，2:壞橘子
            // 檢查好橘子周圍有無壞橘子，檢查有無壞橘子
            int freshCount = 0;
            Queue<int[]> rot = new Queue<int[]>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                        freshCount++;
                    else if (grid[row][col] == 2)
                        rot.Enqueue(new int[] { row, col });
                }
            }
            if (freshCount == 0) return 0;

            int min = -1;
            int[][] dirs = new int[4][];
            dirs[0] = new int[] { 0, -1 };
            dirs[1] = new int[] { -1, 0 };
            dirs[2] = new int[] { 0, 1 };
            dirs[3] = new int[] { 1, 0 };
            while (rot.Count > 0)
            {
                int rotCount = rot.Count;
                min++;
                for (int i = 0; i < rotCount; i++)
                {
                    int[] local = rot.Dequeue();
                    foreach (int[] dir in dirs)
                    {
                        int row = local[0] + dir[0],
                            col = local[1] + dir[1];
                        if (row >= 0 && row <= grid.Length - 1 && 
                            col >= 0 && col <= grid[0].Length - 1 && grid[row][col] == 1)
                        {
                            rot.Enqueue(new int[] {row, col});
                            grid[row][col] = 2;
                            freshCount--;
                        }
                    }
                }
            }
            return freshCount == 0 ? min : -1;
        }
        // Day 10
        /// <summary>
        /// Problems 21. Merge Two Sorted Lists
        /// </summary>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode(0),
                root = head;
            while (list1 != null || list2 != null)
            {
                ListNode list = list1 == null ? list2 :
                         list2 == null ? list1 :
                         list2.val < list1.val ? list2 : list1;
                root.next = new ListNode(list.val);
                root = root.next;
                if (list.Equals(list2)) list2 = list2.next; 
                else if (list.Equals(list1)) list1 = list1.next;
            }
            return head.next;
        }
        // Merge K Lists
        public ListNode MergeKLists(ListNode[] list)
        {
            ListNode head = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                head = MergeTwoLists(head, list[i]);
            }
            return head;
        }
        /// <summary>
        /// Problems 206. Reverse Linked List
        /// </summary>
        public static ListNode ReverseList(ListNode head)
        {
            ListNode curr = head,
                     temp = null;
            if (head == null) return null;
            while (curr.next != null) // 從下個開始，每個都往前移
            {                
                temp = curr.next; // 下個~
                curr.next = temp.next; // 第一個>下下個~
                temp.next = head; // 下個>第一>下下個~
                head = temp; // 排列好的還給head
            }
            return head;

            //Stack<int> stack = new Stack<int>();
            //while (head != null)
            //{
            //    stack.Push(head.val);
            //    head = head.next;
            //}
            //ListNode reverse = new ListNode(0),
            //    curr = reverse;
            //while (stack.Count > 0)
            //{
            //    curr.next = new ListNode(stack.Pop());
            //    curr = curr.next;
            //}
            //return reverse.next;
        }
        // Day 11
        /// <summary>
        /// Problems 77. Combinations
        /// </summary>
        public static IList<IList<int>> Combine(int n, int k)
        {
            // 1-n, 取k個的所有排列組合
            IList<IList<int>> lists = new List<IList<int>>();
            IList<int> list = new int[k].ToList();
            int i = 0;
            while (i >= 0)
            {
                list[i]++;
                if (list[i] > n) i--;
                else if (i == k - 1) lists.Add(new List<int>(list));
                else list[++i] = list[i - 1];
            }
            return lists;
        }
        /// <summary>
        /// Problems 46. Permutations
        /// </summary>
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int>() { nums[0] });
            for (int i = 1; i < nums.Length; i++) // nums of pos
            {
                while (list[0].Count <= i)
                {
                    for (int pos = 0; pos <= i; pos++)
                    {
                        List<int> temp = new List<int>(list[0]);
                        temp.Insert(pos, nums[i]);
                        list.Add(temp);
                    }
                    list.RemoveAt(0);
                }
            }
            return list;
        }
        /// <summary>
        /// Problems 784. Letter Case Permutation
        /// </summary>
        public static IList<string> LetterCasePermutation(string s)
        {
            IList<string> list = new List<string>();
            list.Add(s);
            int count = 1;
            for (int i = 0; i < s.Length; i++) // s of pos
            {
                if (char.IsLetter(s[i])) 
                {
                    for (int i2 = 0; i2 < count; i2++)
                    {
                        string another = list[i2];
                        if (char.IsUpper(s[i]))
                            list.Add(another.Remove(i, 1).Insert(i, char.ToLower(s[i]).ToString()));
                        else
                            list.Add(another.Remove(i, 1).Insert(i, char.ToUpper(s[i]).ToString()));
                    }
                    count *= 2;
                }
            }
            return list;
        }
        // Day 12
        /// <summary>
        /// Problems 70. Climbing Stairs
        /// </summary>
        public static int ClimbStairs(int n)
        {
            // 爬樓梯：N階每次1或2步
            // 排列組合，C=n!/k!(n-k)!、N=所有元素、K=2的元素，循環n/2次加總
            // 降低負荷：從N乘到K+1除(N-K)!
            // VS Studio可以用long，LeetCode會overflow要用double
            double way = 0;
            for (int k = n / 2; k >= 0; k--) // 2步可以出現幾個
            {
                int count = n - k;
                way += factorial(count) / factorial(k) / factorial(count - k); // C=n!/(k!(n-k)!)
            }
            return Convert.ToInt32(way);
            
            double factorial(int level)
            {
                double ans = 1;
                for (int i = 2; i <= level; i++)
                    ans *= i;
                return ans;
            }
            /* 數學解:
             * 已知
             * n=0, result=0
             * n=1, result=1 *(由此開始)
             * n=2, result=2
             * n=3, result=3
             * n=4, result=5
             * n=5, result=8
             * 符合 斐波那契數(Fibonacci) 的定義:
             * F(0)=0
             * F(1)=1
             * F(n)=F(n-1)+F(n-2), n>=2
             * 此題則變成實現數學解
            */
            if (n <= 2) return n;
            int f0 = 1,
                f1 = 2,
                result = f0 + f1;
            for (int i = 3; i <= n; i++)
            {
                result = f0 + f1;
                f0 = f1;
                f1 = result;
            }
            return result;
        }
        /// <summary>
        /// Problems 198. House Robber
        /// </summary>
        public static int Rob(int[] nums)
        {
            Dictionary<int, int[]> dicNums = new Dictionary<int, int[]>();
            dicNums.Add(nums.Length, nums);
            while (dicNums.Keys.Max() > 1)
            {
                int currLen = dicNums.Keys.Max();
                int[] currNums = dicNums[currLen].ToArray();
                // next index
                if (!dicNums.ContainsKey(currLen - 1))
                    dicNums.Add(currLen - 1, currNums.Skip(1).ToArray());
                else if (currNums[1] > dicNums[currLen - 1][0])
                    dicNums[currLen - 1] = currNums.Skip(1).ToArray();
                // index == 2
                if (currLen == 2)
                    dicNums[1][0] = Math.Max(dicNums[1][0], currNums[0]);
                // index >= 3
                if (currLen >= 3)
                {
                    currNums[2] += currNums[0];
                    if (!dicNums.ContainsKey(currLen - 2))
                        dicNums.Add(currLen - 2, currNums.Skip(2).ToArray());
                    else if (currNums[2] > dicNums[currLen - 2][0])
                        dicNums[currLen - 2] = currNums.Skip(2).ToArray();
                }
                // index >= 4
                if (currLen >= 4)
                {
                    currNums[3] += currNums[0] > currNums[1] ? currNums[0] : currNums[1];
                    if (!dicNums.ContainsKey(currLen - 3))
                        dicNums.Add(currLen - 3, currNums.Skip(3).ToArray());
                    else if (currNums[3] > dicNums[currLen - 3][0])
                        dicNums[currLen - 3] = currNums.Skip(3).ToArray();
                }
                dicNums.Remove(currLen);
            }
            return dicNums[1][0];
        }
        /// <summary>
        /// Problems 120. Triangle
        /// </summary>
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int[] currTotal = new int[triangle.Count];
            for (int row = 0; row < triangle.Count; row++)
            {
                if (row != 0)
                    currTotal[triangle[row].Count - 1] = currTotal[triangle[row].Count - 2] + triangle[row][triangle[row].Count - 1];
                for (int col = triangle[row].Count - 2; col > 0; col--)
                {
                    currTotal[col] = triangle[row][col] + Math.Min(currTotal[col], currTotal[col - 1]);
                }
                currTotal[0] += triangle[row][0];
            }
            return currTotal.Min();
        }
        // Day 13
        /// <summary>
        /// Problems 231. Power of Two
        /// </summary>
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false;
            else if (n == 1) return true;

            int curr = n;
            while (curr > 0)
            {
                if (curr % 2 == 1) return false;
                curr /= 2;
                if (curr == 1 || curr == 2) break;
            }
            return true;
        }
        /// <summary>
        /// Problems 191. Number of 1 Bits
        /// </summary>
        public static int HammingWeight(uint n)
            => Convert.ToString(n, 2).Replace("0", string.Empty).Length;
        // Day 14
        /// <summary>
        /// Problems 190. Reverse Bits
        /// </summary>
        public static uint reverseBits(uint n)
        {
            string result = "";
            foreach (char c in Convert.ToString(n, 2).PadLeft(32, '0'))
            {
                result = c + result;
            }
            return Convert.ToUInt32(result, 2);
        }
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
    }
}
