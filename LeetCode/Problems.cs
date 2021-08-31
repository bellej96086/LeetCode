using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace LeetCode
{
    public class Problems
    {
        //Definition
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
        // Topic: Algorithms
        /// <summary>
        /// Problems 1
        /// </summary>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i1 = 0; i1 < nums.Length - 1; i1++)
            {
                if (target < nums[i1]) continue;
                for (int i2 = i1 + 1; i2 < nums.Length; i2++)
                {
                    if (target - nums[i1] == nums[i2])
                        return new int[] { i1, i2 };
                }
            }
            return new int[] { 0, 0 };
            //throw new IllegalArgumentException("No two sum solution");             
        }
        /// <summary>
        /// Problems 2
        /// </summary>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) //topic
        {
            // 把下一位數塞進next形成巢狀結構
            ListNode result = new ListNode(0); //完整
            ListNode answer = result; //前一位數
            int overflow = 0; //進位
            while (l1 != null | l2 != null | overflow != 0) //如果l1|l2|進位還有值
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + overflow; //如果l1有+如果l2有+進位
                overflow = sum / 10; //下一個進位
                answer.next = new ListNode(sum % 10); //這一位數總和
                answer = answer.next; //下一位數的位置
                if (l1 != null)
                    l1 = l1.next; //下一個l1
                if (l2 != null)
                    l2 = l2.next; //下一個l2
            }
            return result.next; //answer從前一位數開始，所以取下一位
        }
        /// <summary>
        /// Problems 3
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2)
                return s.Length;
            int answer = 0, index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                index = i;
                for (int j = i + 1; j < s.Length; j++)
                {
                    bool repeat = s.Substring(index, j - index).IndexOf(Convert.ToChar(s.Substring(j, 1))) != -1;
                    if (repeat && answer < j- index)
                    {
                        answer = j - index;
                        index = j;
                    }
                    else if (repeat)
                    {
                        break;
                    }
                    else if (j == s.Length-1 && answer < s.Length - index)
                    {
                        answer = s.Length - index;
                        index = j;
                    }
                }
            }
            return answer;
        }
        /// <summary>
        /// Problems 7
        /// </summary>
        public static int Reverse(int x)
        {
            string sign = x > 0 ? "+" : "-", source = (x > 0 ? x : -x).ToString(), after = string.Empty;
            foreach (char c in source)
            {
                after = after.Insert(0, c.ToString());
            }
            after = sign + after;
            if (Int32.TryParse(after, out int result)) return result;
            else return 0;
        }
        /// <summary>
        /// Problems 9
        /// </summary>
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x.ToString() == new string(x.ToString().Reverse().ToArray())) return true;
            else return false;
        }
        /// <summary>
        /// Problems 13
        /// </summary>
        public static int RomanToInt(string s)
        {
            int result = 0;
            int[] convert = Array.ConvertAll(s.Replace("I", "1,").Replace("V", "5,").Replace("X", "10,").Replace("L", "50,").Replace("C", "100,").Replace("D", "500,").Replace("M", "1000,").TrimEnd(',').Split(','), int.Parse);
            for (int i = 0; i < convert.Length; i++)
            {
                result += (i == convert.Length - 1) ? convert[i] : convert[i] >= convert[i + 1] ? convert[i] : -convert[i];
            }
            return result;
        }
        /// <summary>
        /// Problems 14
        /// </summary>
        public static string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            int min_len = strs.Select(s => s.Length).Min();
            for (int i = 0; i < min_len; i++)
            {
                foreach (string s in strs.Select(s => s.Substring(i, 1)).ToList())
                {
                    if (s != strs[0].Substring(i, 1)) return result;
                }
                result += strs[0].Substring(i, 1);
            }
            return result;
        }
        /// <summary>
        /// Problems 20
        /// </summary>
        public static bool IsValid(string s)
        {
            /* new data type:queue
             * 先進先出
             * ex:排隊
             * new data type:stack
             * 先進後出
             * ex:箱子
             */
            if (s.Length % 2 == 1) return false;
            Dictionary<char, char> Parentheses = new Dictionary<char, char>()
            { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            Stack stack = new Stack();
            foreach(char c in s)
            {
                if (Parentheses.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0 || !stack.Pop().Equals(Parentheses[c]))
                {
                    return false;
                }
            }
            if (stack.Count == 0) return true;
            else return false;

            //// 低效
            //while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            //{
            //    s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
            //}
            //return true;
        }
        /// <summary>
        /// Problems 21
        /// </summary>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0), result_merge = result;
            while (l1 != null || l2 != null)
            {
                if (l1 != null && (l1 == null ? 101 : l1.val) < (l2 == null ? 101 : l2.val))
                {
                    result_merge.next = new ListNode(l1.val);
                    result_merge = result_merge.next;
                    l1 = l1.next;
                }
                else if (l2 != null)
                {
                    result_merge.next = new ListNode(l2.val);
                    result_merge = result_merge.next;
                    l2 = l2.next;
                }
            }
            return result.next;
        }
        /// <summary>
        /// Problems 26
        /// </summary>
        public static int RemoveDuplicates(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    nums[i - 1] = 101;
                    len--;
                }
            }
            Array.Sort(nums);
            return len;
        }
        /// <summary>
        /// Problems 27.Remove Element
        /// </summary>
        public static int RemoveElement(int[] nums, int val)
        {
            //LeetCode上無法使用
            //nums = nums.Where(w => w != val).ToArray();
            //return nums.Length;

            int len = 0;
            foreach (int num in nums)
            {
                if (num != val)
                {
                    nums[len] = num;
                    len++;
                }
            }
            return len;
        }
        /// <summary>
        /// Problems 28.Implement strStr()
        /// </summary>
        public static int StrStr(string haystack, string needle)
        {
            if (needle == "") return 0;
            int tl = haystack.Length - needle.Length, nl = needle.Length;
            for (int i1 = 0; i1 <= tl; i1++)
            {
                if (haystack[i1] == needle[0])
                    if (haystack.Substring(i1, nl) == needle)
                        return i1;
            }
            return -1;
        }
        /// <summary>
        /// Problems 35.Search Insert Position
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            int minlimit = 0, maxlimit = nums.Length - 1, index = 0;            
            while (true)
            {
                index = (minlimit + maxlimit) / 2;
                if (nums[index] == target) return index;
                else if (index == maxlimit && nums[maxlimit] > target && nums[minlimit] > target) return index;
                else if ((index == minlimit && nums[minlimit] < target && nums[maxlimit] >= target) || (index == maxlimit && nums[maxlimit] < target)) return index + 1;
                else if ((index == minlimit && nums[minlimit] > target) || (index == maxlimit && nums[maxlimit] > target)) return index;
                else if (index == minlimit && nums[minlimit] < target && nums[maxlimit] < target) return index + 2;
                else if (nums[index] > target) maxlimit = index;
                else if (nums[index] < target) minlimit = index;
            }
        }
        /// <summary>
        /// Problems 53.Maximum Subarray
        /// </summary>
        public static int MaxSubArray(int[] nums)
        {
            int result = nums[0], min = nums[0], subtotal = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                subtotal += nums[i];
                result = Math.Max(subtotal, Math.Max(subtotal - min, result));
                min = Math.Min(min, subtotal);
            }
            return result;
        }
        /// <summary>
        /// Problems 58. Length of Last Word
        /// </summary>
        public static int LengthOfLastWord(string s)
        {
            s = s.Trim();
            return s.Length - s.LastIndexOf(' ') - 1;            
        }
        /// <summary>
        /// Problems 66. Plus One
        /// </summary>
        public static int[] PlusOne(int[] digits)
        {            
            digits[digits.Length - 1] += 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 10) break;
                else if (i > 0)
                {
                    digits[i] = 0;
                    digits[i - 1] += 1;
                }
                else
                {
                    int[] new_digits = new int[digits.Length + 1];
                    new_digits[0] = 1;
                    new_digits[1] = 0;
                    for (int j = 2; j < new_digits.Length; j++)
                    {
                        new_digits[j] = digits[j - 1];
                    }
                    digits = new_digits;
                }
            }
            return digits;
        }
        /// <summary>
        /// Problems 67. Add Binary
        /// </summary>
        public static string AddBinary(string a, string b)
        {
            string sum = "";
            int total = 0, carry = 0;
            if (a.Length - b.Length > 0) b = b.ToString().PadLeft(a.Length, '0');
            else if (a.Length - b.Length < 0) a = a.ToString().PadLeft(b.Length, '0');
            char[] array_a = a.ToArray(), array_b = b.ToArray();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                total = int.Parse(array_a[i].ToString()) + int.Parse(array_b[i].ToString()) + carry;
                carry = total > 1 ? 1 : 0;
                sum = (total > 1 ? total - 2 : total).ToString() + sum;
            }
            sum = carry == 1 ? "1" + sum : sum;
            return sum;
        }
        /// <summary>
        /// Problems 69. Sqrt(x)
        /// </summary>
        public static int MySqrt(int x)
        {
            // 直接
            //long result = x == 0 ? 0 : 1;
            //for (int i = 0; i < (x.ToString().Length - 1) / 2; i ++)
            //{
            //    result = result * 10;
            //}
            //while (result * result < x)
            //{
            //    result++;
            //}
            //if (result * result != x) result--;
            //return (int)result;
            // 二分法，找頭尾
            if (x == 0) return 0;
            else if (x <= 3) return 1;

            long min = 1, max = x, mid = 0;
            for (int i = 0; i < (x.ToString().Length - 1) / 2; i++)
            {
                min = min * 10;
            }
            while (min <= max)
            {
                mid = min + (max - min) / 2;
                if (mid * mid > x) max = mid - 1;
                else if (mid * mid < x) min = mid + 1;
                else return (int)mid;
            }
            return (int)max;
        }
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
        }
        private static double factorial(int n)
        {
            double result = 1;
            for (int i = n; i > 1; i--)
                result = result * i;
            return result;
        }
        /// <summary>
        /// Problems 83. Remove Duplicates from Sorted List
        /// </summary>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode result = new ListNode(-101); //完整
            ListNode answer = result; //前一位數
            while (head != null)
            {
                if (answer.val != head.val)
                { 
                    answer.next = new ListNode(head.val);
                    answer = answer.next;
                }
                head = head.next; //下一個l1
            }
            return result.next; //answer從前一位數開始，所以取下一位
        }
        /// <summary>
        /// Problems 94. Binary Tree Inorder Traversal
        /// </summary>
        public static IList<int> InorderTraversal(TreeNode root)
        {
            //Left>Mid>Rigft
            List<int> result = new List<int>();
            TreeNode currentTN = root;
            Stack<TreeNode> TN_seq = new Stack<TreeNode>();
            while (currentTN != null || TN_seq.Count > 0)
            {
                while (currentTN != null)
                {
                    TN_seq.Push(currentTN);
                    currentTN = currentTN.left;
                }
                if (TN_seq.Count > 0)
                {
                    currentTN = TN_seq.Pop();
                    result.Add(currentTN.val);
                    currentTN = currentTN.right;
                }
            }
            return result;
        }
        /// <summary>
        /// Problems 144. Binary Tree Preorder Traversal
        /// </summary>
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            //Mid>Left>Right
            List<int> result = new List<int>();
            TreeNode currentTN = root;
            Stack<TreeNode> TN_seq = new Stack<TreeNode>();
            while (currentTN != null || TN_seq.Count > 0)
            {
                while (currentTN != null)
                {
                    TN_seq.Push(currentTN);
                    result.Add(currentTN.val);
                    currentTN = currentTN.left;
                }
                if (TN_seq.Count > 0)
                {
                    currentTN = TN_seq.Pop();
                    currentTN = currentTN.right;
                }
            }
            return result;
        }
        /// <summary>
        /// Problems 145. Binary Tree Postorder Traversal
        /// </summary>
        public static IList<int> PostorderTraversal(TreeNode root)
        {
            //Left>Right>Mid
            List<int> result = new List<int>();
            TreeNode currentTN = root;
            Stack<TreeNode> TN_seq = new Stack<TreeNode>();
            while (currentTN != null || TN_seq.Count > 0)
            {
                while (currentTN != null)
                {
                    TN_seq.Push(currentTN);
                    result.Insert(0, currentTN.val);
                    currentTN = currentTN.right;
                }
                if (TN_seq.Count > 0)
                {
                    currentTN = TN_seq.Pop();
                    currentTN = currentTN.left;
                }
            }
            return result;
        }
        /// <summary>
        /// Problems 100. Same Tree
        /// </summary>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            TreeNode current_p = p, current_q = q;
            Stack<TreeNode> p_seq = new Stack<TreeNode>(), q_seq = new Stack<TreeNode>();
            while (current_p != null || current_q != null || p_seq.Count > 0 || q_seq.Count > 0)
            {
                while (current_p != null)
                {
                    p_seq.Push(current_p);
                    current_p = current_p.left;
                }
                while (current_q != null)
                {
                    q_seq.Push(current_q);
                    current_q = current_q.left;
                }
                if (p_seq.Count != q_seq.Count)
                    return false;
                else if (p_seq.Count > 0 || q_seq.Count > 0)
                {
                    current_p = p_seq.Pop();
                    current_q = q_seq.Pop();
                    if (current_p.val != current_q.val) return false;
                    current_p = current_p.right;
                    current_q = current_q.right;
                }
            }
            return true;
        }


        /// <summary>
        /// Problems 
        /// </summary>

        /// <summary>
        /// !未完成!，Problems 827，有一次機會把0改成1連接島嶼，找出可能做出的最大島數
        /// </summary>
        public static int LargestIsland(int[][] grid)
        {
            int Largest = 0, land = 0, grid_size = grid.Length, sum = 0;
            //嘗試連接島嶼
            for (int r = 0; r < grid_size; r++)
                for (int c = 0; c < grid_size; c++)
                {
                    if (grid[r][c] == 0)
                    {
                        grid[r][c] = 1;
                        land = FindLand(grid);
                        Largest = land > Largest ? land : Largest;
                        grid[r][c] = 0;
                    }
                    else sum++;
                }
            if (sum == grid_size * grid_size) return grid_size * grid_size;            
            return Largest;
        }
        private static int FindLand(int[][] grid)
        {
            int Largest = 0, land = 0, grid_size = grid.Length;
            int[,] grid_copy = new int[grid_size, grid_size];
            bool left, right, top, bottom;
            for (int r = 0; r < grid_size; r++)
                for (int c = 0; c < grid_size; c++)
                {
                    grid_copy[r, c] = grid[r][c];
                }
            //找出最大島嶼數，遍歷島嶼
            for (int r = 0; r < grid_size; r++)
                for (int c = 0; c < grid_size; c++)
                {
                    //找到島嶼和附近的島嶼
                    if (grid_copy[r, c] == 1)
                    {
                        land++;
                        grid_copy[r, c] = 2;
                        //比較附近的島嶼，先右後下，讓它不會再被數到
                        for (int dy = r; dy < grid_size; dy++)
                        {
                            int first = 0;
                            if (dy == r) first = c + 1;
                            for (int dx = first; dx < grid_size; dx++)
                            {
                                if (grid_copy[dy, dx] == 1)
                                {
                                    left = dx - 1 >= 0;
                                    if (left) left = grid_copy[dy, dx - 1] == 0;
                                    right = dx + 1 < grid_size;
                                    if (right) right = grid_copy[dy, dx + 1] > 0;
                                    top = dy - 1 >= 0;
                                    if (top) top = grid_copy[dy - 1, dx] == 2;
                                    bottom = dy + 1 < grid_size;
                                    if (bottom) bottom = grid_copy[dy + 1, dx] > 0;
                                    //和本島嶼有相連
                                    if (left || right || top || bottom)
                                    {
                                        land++;
                                        grid_copy[dy, dx] = 2;
                                    }
                                }
                            }
                        }
                    }
                    //找到的島嶼數是否為最大
                    if (Largest < land) Largest = land;
                    land = 0;
                }
            return Largest;
        }

        // Topic: Database
        /// <summary>
        /// Problems 175. Combine Two Tables
        /// </summary>
        public static string Combine_Two_Tables(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"Select FirstName, LastName, City, State From Person p, Address a Where p.PersonId = a.PersonId(+)";
                    break;
                case "MYSQL":
                    return @"Select FirstName, LastName, City, State From Person left join Address on Address.PersonId = Person.PersonId";
                    break;
                case "MSSQL":
                    return @"Select FirstName, LastName, City, State From Person left join Address on Address.PersonId = Person.PersonId";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 176. Second Highest Salary
        /// </summary>
        public static string Second_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"Select case when count(Salary) < 2 then Max(Salary) else null end SecondHighestSalary 
From
    (Select rownum rn, Salary
    From
        (Select Salary
        From Employee
        Group by Salary
        Order by Salary desc))
Where rn = 2";
                    break;
                case "MYSQL":
                    return @"Select case when count(Salary) = 2 then Min(Salary) else null end SecondHighestSalary 
From
    (Select Salary
    From
        (Select Salary
        From Employee
        Group by Salary
        Order by Salary desc) e
    Limit 2) e";
                    break;
                case "MSSQL":
                    return @"Select case when count(Salary) = 2 then Min(Salary) else null end SecondHighestSalary 
From    
    (Select Top 2 Salary
    From Employee
    Group by Salary
    Order by Salary desc) Employee";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 177. Nth Highest Salary
        /// </summary>
        public static string Nth_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(N IN NUMBER) RETURN NUMBER IS
result NUMBER;
BEGIN
    /* Write your PL/SQL query statement below */
    Select case when count(Salary) = 1 then Min(Salary) else null end INTO result 
    From
        (Select rownum rn, Salary
        From
            (Select Salary
            From Employee
            Group by Salary
            Order by Salary desc))
    Where rn = N;

    RETURN result;
END;";
                    break;
                case "MYSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  RETURN (
      # Write your MySQL query statement below.
      Select case when count(Salary) = N then Min(Salary) else null end SecondHighestSalary 
      From
        (Select Salary
        From
            (Select Salary
            From Employee
            Group by Salary
            Order by Salary desc) e
        Limit N) e    
  );
END";
                    break;
                case "MSSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        /* Write your T-SQL query statement below. */
        Select case when count(Salary) = @N then Min(Salary) else null end SecondHighestSalary 
        From    
            (Select Top (@N) Salary
            From Employee
            Group by Salary
            Order by Salary desc) Employee
    );
END";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 178. Rank Scores
        /// </summary>
        public static string Rank_Scores(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select A.score, B.rk as Rank
from Scores A
    , (select score, rownum rk 
        from (SELECT score 
              FROM Scores 
              GROUP BY score
              ORDER BY Score DESC)) B
where A.score = B.score(+)
ORDER BY Score DESC";
                    break;
                case "MYSQL":
                    return @"select A.score, B.rk `Rank`
from Scores A
    left join (select score, ROW_NUMBER() OVER(ORDER BY Score desc) rk 
                from (SELECT score 
                      FROM Scores 
                      GROUP BY score
                      ORDER BY Score DESC) B) B on A.score = B.score
ORDER BY Score DESC";
                    break;
                case "MSSQL":
                    return @"select top 10000 A.score, B.rk as Rank
from Scores A
    left join (select top 10000 score, ROW_NUMBER() OVER(ORDER BY Score desc) rk 
                from (SELECT top 10000 score 
                      FROM Scores 
                      GROUP BY score
                      ORDER BY Score DESC) B) B on A.score = B.score
ORDER BY Score DESC";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 180. Consecutive Numbers
        /// </summary>
        public static string Consecutive_Numbers(string Language) 
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select distinct num ConsecutiveNums 
                    from
                        (select logs.*
                            , case when num != nvl(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
                            , case when num != nvl(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
                        from Logs
                        order by id asc) logs
                    where next = 1 and back = 1";
                    break;
                case "MYSQL":
                    return @"select distinct num ConsecutiveNums 
from
    (select logs.*
        , case when num != IFNULL(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
        , case when num != IFNULL(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
    from Logs
    order by id asc) logs
where next = 1 and back = 1";
                    break;
                case "MSSQL":
                    return @"select distinct num ConsecutiveNums 
from
    (select top 10000 logs.*
        , case when num != ISNULL(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
        , case when num != ISNULL(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
    from Logs
    order by id asc) logs
where next = 1 and back = 1";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 181. Employees Earning More Than Their Managers
        /// </summary>
        public static string Employees_Earning_More_Than_Their_Managers(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
                case "MYSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
                case "MSSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 182. Duplicate Emails
        /// </summary>
        public static string Duplicate_Emails(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
                case "MYSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
                case "MSSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 183. Customers Who Never Order
        /// </summary>
        public static string Customers_Who_Never_Order(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name as Customers
from customers c
    , orders o
where c.id = o.customerid(+)
    and o.id is null";
                    break;
                case "MYSQL":
                    return @"select name as Customers
from customers c
    left join orders o on c.id = o.customerid
where o.id is null";
                    break;
                case "MSSQL":
                    return @"select name as Customers
from customers c
    left join orders o on c.id = o.customerid
where o.id is null";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 184. Department Highest Salary
        /// </summary>
        public static string Department_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
    , Department d
    , (select d.id, max(e.salary) salary
        from Employee e, Department d
        where e.departmentid = d.id(+)
        group by d.id) hs
where e.departmentid = d.id(+)
    and e.salary = hs.salary
    and d.id = hs.id";
                    break;
                case "MYSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select d.id, max(e.salary) salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary and d.id = hs.id";
                    break;
                case "MSSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select d.id, max(e.salary) salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary and d.id = hs.id";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 185. Department Top Three Salaries
        /// </summary>
        public static string Department_Top_Three_Salaries(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
    , Department d
    , (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
        from Employee e, Department d
        where e.departmentid = d.id(+) 
        group by d.id, e.salary) hs
where e.departmentid = d.id(+)
    and e.salary = hs.salary
    and d.id = hs.id
    and hs.rank3 <= 3";
                    break;
                case "MYSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id, e.salary) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary 
    and d.id = hs.id
    and hs.rank3 <= 3";
                    break;
                case "MSSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id, e.salary) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary 
    and d.id = hs.id
    and hs.rank3 <= 3";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 196. Delete Duplicate Emails
        /// </summary>
        public static string Delete_Duplicate_Emails(string Language)
        {
            switch (Language)
            {
                case "MYSQL":
                    return @"delete from person
where id in (select p.id
             from (select id, rank() over(partition by email order by id asc) rank2
                   from person) p
             where p.rank2 >= 2)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 197. Rising Temperature
        /// </summary>
        public static string Rising_Temperature(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select id
from (select id, recordDate, temperature, nvl(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and recordDate - 1 in (select recordDate from weather)";
                    break;
                case "MYSQL":
                    return @"select id
from (select id, recordDate, temperature, ifnull(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and date_sub(recordDate, interval 1 day) in (select recordDate from weather)";
                    break;
                case "MSSQL":
                    return @"select id
from (select top 10000 id, recordDate, temperature, isnull(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and dateadd(day, -1, recordDate) in (select recordDate from weather)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 262. Trips and Users
        /// </summary>
        public static string Trips_and_Users(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0 else 1 end) / count(status), 2) as ""Cancellation Rate""
from trips t
    , users c
    , users d
where t.client_id = c.users_id(+)
    and t.driver_id = d.users_id(+)
    and c.banned = 'No'
    and d.banned = 'No'
    and to_date(request_at, 'yyyy-mm-dd') between TO_DATE('2013-10-01', 'yyyy-mm-dd') and TO_DATE('2013-10-03', 'yyyy-mm-dd')
group by request_at
order by request_at asc";
                    break;
                case "MYSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0 else 1 end) / count(status), 2) as ""Cancellation Rate""
from trips t
    right
join users c on t.client_id = c.users_id

right
join users d on t.driver_id = d.users_id
where c.banned = 'No'
    and d.banned = 'No'
    and DATE_FORMAT(request_at, '%Y-%m-%d') between DATE_FORMAT('2013-10-01', '%Y-%m-%d') and DATE_FORMAT('2013-10-03', '%Y-%m-%d')
group by request_at
order by request_at asc";
                    break;
                case "MSSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0.0 else 1.0 end) / count(*), 2) as ""Cancellation Rate""
from trips t
    right
join users c on t.client_id = c.users_id

right
join users d on t.driver_id = d.users_id
where c.banned = 'No'
    and d.banned = 'No'
    and CONVERT(DATETIME, request_at) between CONVERT(DATETIME, '2013-10-01') and CONVERT(DATETIME, '2013-10-03')
group by request_at
order by request_at asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 595. Big Countries
        /// </summary>
        public static string Big_Countries(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
                case "MYSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
                case "MSSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 596. Classes More Than 5 Students
        /// </summary>
        public static string Classes_More_Than_5_Students(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
                    break;
                case "MYSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
                    break;
                case "MSSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 601. Human Traffic of Stadium
        /// </summary>
        public static string Human_Traffic_of_Stadium(string Language)
        {
            switch (Language)
            {
                case "PLSQL"://不能submit
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
                case "MYSQL":
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
                case "MSSQL":
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 620. Not Boring Movies
        /// </summary>
        public static string Not_Boring_Movies(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and mod(id, 2) = 1
order by rating desc";
                    break;
                case "MYSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and mod(id, 2) = 1
order by rating desc";
                    break;
                case "MSSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and id % 2 = 1
order by rating desc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 626. Exchange Seats
        /// </summary>
        public static string Exchange_Seats(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when mod(id, 2) = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
                case "MYSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when mod(id, 2) = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
                case "MSSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when id % 2 = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 627. Swap Salary
        /// </summary>
        public static string Swap_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"update salary
set sex = decode(sex, 'm', 'f'
                    , 'f', 'm')";
                    break;
                case "MYSQL":
                    return @"update salary
set sex = case sex when 'm' then 'f' when 'f' then 'm' end";
                    break;
                case "MSSQL":
                    return @"update salary
set sex = case sex when 'm' then 'f' when 'f' then 'm' end";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 1179. Reformat Department Table
        /// </summary>
        public static string Reformat_Department_Table(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
                case "MYSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
                case "MSSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
            }
            return "Fault Language";
        }

        /// <summary>
        /// Problems 
        /// </summary>
        public static string A(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"";
                    break;
                case "MYSQL":
                    return @"";
                    break;
                case "MSSQL":
                    return @"";
                    break;
            }
            return "Fault Language";
        }


    }
    public class Topic
    {
        //1
        //2，一次給滿l1和l2
    }
    //DataTpye
}
