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
            { { ')', '(' }, { ']', '[' }, { '}', '{' } }; //字典
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
        /// Problems 8. String to Integer (atoi)
        /// </summary>
        public static int MyAtoi(string s)
        {
            s = s.Trim();
            if (string.IsNullOrWhiteSpace(s)) return 0;
            int sign = 1, index = 0;
            if (s[index] == '+' || s[index] == '-')
            {
                sign = s[index] == '-' ? -1 : 1;
                index++;
            }
            long result = 0;
            while (index < s.Length)
            {
                if (!char.IsNumber(s[index])) break;
                result = result * 10 + int.Parse(s[index].ToString());
                if (result * sign <= Int32.MinValue) return Int32.MinValue;
                if (result * sign >= Int32.MaxValue) return Int32.MaxValue;
                index++;
            }
            return (int)result * sign;
        }
        /// <summary>
        /// Problems 65. Valid Number
        /// </summary>
        public static bool IsNumber(string s)
        {
            // 's' must consist of values in [a-z A-Z .-+ 0-9] only
            /*
            Regex error = new Regex("[a-df-zA-DF-Z]");
            if (error.IsMatch(s)) return false;

            Regex number = new Regex("^(\\+|-)?(\\d+(\\.\\d+)?|\\.\\d+|\\d+\\.|\\d+(\\.\\d+)?(E|e)(\\+|-)?\\d+|\\.\\d+?(E|e)(\\+|-)?\\d+|\\d+\\.(E|e)(\\+|-)?\\d+)$");
            if (number.IsMatch(s)) return true;
            else return false;
            */
            return Regex.IsMatch(s, @"^(\+|-)?(\d+(\.\d+)?|\.\d+|\d+\.)((E|e)(\+|-)?\d+)?$");
        }
        /// <summary>
        /// Problems 168. Excel Sheet Column Title
        /// </summary>
        public static string ConvertToTitle(int columnNumber)
        {
            string res = "";
            int mod = 0;
            while (columnNumber > 0)
            {
                mod = columnNumber % 26 == 0 ? 26 : columnNumber % 26;
                columnNumber = columnNumber - mod;
                res = ColumnNumber(mod) + res;
                columnNumber = columnNumber / 26;                
            }
            return res;
        }
        private static string ColumnNumber(int Number)
        {
            return ((char)(64 + Number)).ToString();
        }
        /// <summary>
        /// Problems 171. Excel Sheet Column Number
        /// </summary>
        public static int TitleToNumber(string columnTitle)
        {
            int res = 0;
            foreach (char column in columnTitle)
            {
                res = res * 26 + ColumnName(column);
            }
            return res;
        }
        private static int ColumnName(char name)
        {
            return ((int)name - 64);
        }
        /// <summary>
        /// Problems 38. Count and Say
        /// </summary>
        public static string CountAndSay(int n)
        {
            string res = "1";
            if (n == 1) return res;
            do
            {
                string before_res = res;
                res = "";
                int time = 1;
                for (int i = 0; i < before_res.Length; i++)
                {
                    if (i != before_res.Length - 1 && before_res[i + 1] == before_res[i])
                        time++;
                    else
                    {
                        res += time.ToString() + before_res[i];
                        time = 1;
                    }
                }
            } while (--n > 1);
            return res;
        }
        /// <summary>
        /// Problems 443. String Compression
        /// </summary>
        public static int Compress(char[] chars)
        {
            int pos_chars = 0, pos_push = 0;
            for (int i = 1; i <= chars.Length; i++)
            {
                if (i == chars.Length || chars[i - 1] != chars[i])
                {
                    chars[pos_push++] = chars[i - 1];
                    if ((i - pos_chars) != 1)
                    {
                        char[] temps = (i - pos_chars).ToString().ToCharArray();
                        foreach (char temp in temps) { chars[pos_push++] = temp; }
                    }
                    pos_chars = i;
                }
            }
            return pos_push;
        }
        /// <summary>
        /// Problems 1415. The k-th Lexicographical String of All Happy Strings of Length n
        /// </summary>
        public static string GetHappyString(int n, int k)
        {
            //Math.Pow(2, 10); 2^10
            //Math.Log(k, 2);  2^x=10，求幕次
            //(int)Math.Ceiling(Math.Log(k, 2)); >=最小整數值
            //(int)Math.Floor(Math.Log(k, 2)); <=最大整數值
            if (k > 3 * Math.Pow(2, (n - 1))) return "";
            else if (n == 1) return ABC_not_equal(k - 1);
            k--;

            string res = "";
            int carry = (int)Math.Pow(2, n - 1);
            res = ABC_not_equal(k / carry);
            k = k - k / carry * carry;
            while (res.Length < n)
            {
                carry = carry / 2;
                res += ABC_not_equal(k / carry, res[res.Length - 1]);
                k = k - k / carry * carry;
            }

            /*
            Stack<int> res_number = new Stack<int>();
            do
            {
                res_number.Push(res_number.Count + 1 < n ? k % 2 : k % 3);
                k = (k - res_number.Peek()) / 2;
            } while (res_number.Count < n);
            do
            {
                if (res == "") res = ABC_not_equal(res_number.Pop());
                else res += ABC_not_equal(res_number.Pop(), res[res.Length - 1]);
            } while (res_number.Count > 0);
            */
            return res;
        }
        private static string ABC_not_equal(int plus, char repeat = new char())
        {
            char[] letters = new char[] { 'a', 'b', 'c' };
            List<char> letter_list = new List<char>();
            letter_list.AddRange(letters);
            letter_list.Remove(repeat);
            return letter_list[plus].ToString();
        }
        /// <summary>
        /// Problems 1032. Stream of Characters
        /// </summary>
        public class StreamChecker
        {
            private string[] Check_Words;
            private int Check_Word_Max_Length = 0;
            private string Stream_Word = "";
            public StreamChecker(string[] words)
            {
                Check_Words = words;
                foreach (string word in words)
                {
                    Check_Word_Max_Length = Check_Word_Max_Length < word.Length ? word.Length : Check_Word_Max_Length;
                }
            }

            public bool Query(char letter)
            {
                Stream_Word += letter;
                Stream_Word = Stream_Word.Length > Check_Word_Max_Length ? Stream_Word.Substring(Stream_Word.Length - 1 - Check_Word_Max_Length) : Stream_Word;
                foreach (string word in Check_Words)
                {
                    if (word.Length > Stream_Word.Length) continue;
                    if (word == Stream_Word.Substring(Stream_Word.Length - word.Length)) return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Problems 1832. Check if the Sentence Is Pangram
        /// </summary>
        public static bool CheckIfPangram(string sentence)
        {
            //if (sentence.Length < 26) return false; // 沒有變快
            HashSet<char> letters = new HashSet<char>();
            int count = 0;
            foreach (char letter in sentence)
            {
                if (letters.Contains(letter)) continue;
                letters.Add(letter);
                count++;
                if (count == 26) return true;
            }
            return false;
        }
        /// <summary>
        /// Problems 1003. Check If Word Is Valid After Substitutions
        /// </summary>
        public static bool IsValid_1003(string s)
        {
            string t = "abc";
            while (s.Contains(t))
            {
                s = s.Replace(t, "");
            }
            return s.Length == 0 ? true : false;
        }
        /// <summary>
        /// Problems 1604. Alert Using Same Key-Card Three or More Times in a One Hour Period
        /// </summary>
        public static IList<string> AlertNames(string[] keyName, string[] keyTime)
        {
            Dictionary<string, List<int>> record = new Dictionary<string, List<int>>();
            for (int i = 0; i < keyName.Length; i++)
            {
                if (!record.ContainsKey(keyName[i])) record.Add(keyName[i], new List<int>());
                record[keyName[i]].Add(Convert.ToInt32(keyTime[i].Substring(0, 2)) * 60 + Convert.ToInt32(keyTime[i].Substring(3, 2))); // minute
            }
            List<string> names = new List<string>();
            foreach (string name in record.Keys)
            {
                List<int> times = record[name];
                if (times.Count < 3) continue;
                times.Sort();
                for (int i = 0; i + 2 < times.Count; i++)
                {
                    if (times[i+2] - times[i] <= 60)
                    {
                        names.Add(name);
                        break;
                    }
                }
            }
            names.Sort();
            return names;
        }
        /// <summary>
        /// Problems 1299. Replace Elements with Greatest Element on Right Side
        /// </summary>
        public static int[] ReplaceElements(int[] arr)
        {
            //O(n^2)
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = -1;
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        arr[i] =  arr[i] < arr[j] ? arr[j] : arr[i];
            //    }
            //}

            //O(n - 1)
            int current_max = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int before_max = current_max;
                current_max = (current_max > arr[i]) ? current_max : arr[i];
                arr[i] = (i == arr.Length - 1) ? -1 : before_max;
            }
            return arr;
        }
        /// <summary>
        /// Problems 283. Move Zeroes
        /// </summary>
        public static void MoveZeroes(int[] nums)
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
        /// Problems 905. Sort Array By Parity
        /// </summary>
        public static int[] SortArrayByParity(int[] nums)
        {
            int point = 0, temp;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    temp = nums[i];
                    //nums[i] = nums[nums.Length - point - 1];
                    //nums[nums.Length - point - 1] = temp;

                    nums[i] = nums[point];
                    nums[point] = temp;

                    point++;
                }
            }
            return nums;
        }
        /// <summary>
        /// Problems 421. Maximum XOR of Two Numbers in an Array
        /// </summary>
        public static int FindMaximumXOR(int[] nums)
        {
            int mask = 0, currMax = 0;
            // 從最大~最小位數，取可能最大值，確認現在最大值
            for (int currDigits = Convert.ToString(nums.Max(), 2).Length; currDigits >= 0; currDigits--) 
            // 最大~最小位數，int:range=2^32,value=-2^31~+2^31-1
            {
                mask = mask | (1 << currDigits); // 上次的mask+這次的位數，100>110>111

                // 找出所有當前mask的對應可能(像trie)
                HashSet<int> currSet = new HashSet<int>(); 
                foreach (int num in nums)
                {
                    currSet.Add(mask & num);
                }
                if (currSet.Count == 1) continue; // 沒有對應的位數

                // 找出當前期望最大值是否存在
                int currWish = currMax | (1 << currDigits); // 上次最大值+這位數=現在期望最大值
                foreach (int currNum in currSet)
                {
                    if (currSet.Contains(currNum ^ currWish)) // 到目前為止的位數有互補(可以XOR)
                    {
                        currMax = currWish; // 現在期望最大值
                        break;
                    }
                }
            }
            return currMax;
        }
        /// <summary>
        /// Problems 211. Design Add and Search Words Data Structure
        /// </summary>
        public class WordDictionary
        {
            // 359ms, 59.6MB
            private Dictionary<int, HashSet<string>> dicWord = new Dictionary<int,HashSet<string>>();
            public void AddWord(string word)
            {
                if (dicWord.TryGetValue(word.Length, out HashSet<string> setWord))
                    setWord.Add(word);
                else
                {
                    setWord = new HashSet<string>();
                    setWord.Add(word);
                    dicWord.Add(word.Length, setWord);
                }
            }
            public bool Search(string word)
            {
                if (dicWord.TryGetValue(word.Length, out HashSet<string> setWord) == null)
                    return false;

                foreach (string currWord in setWord)
                {
                    for (int pos = 0; pos < word.Length; pos++)
                    {
                        if (word[pos] != '.' && word[pos] != currWord[pos]) break;
                        else if (pos == word.Length - 1) return true;
                    }
                }
                return false;
            }            
            // 244ms, 66.4MB
            /*
            private class WordNode
            {
                public WordNode[] next { get; } = new WordNode[26]; // A-Z
                public bool isWord { get; set; } // Right word end
            }

            private readonly WordNode root = new WordNode();
            public void AddWord(string word)
            {
                // 遍歷(加總,每個),最後一個.isLetter = true
                word.Aggregate(root, (node, letter) =>
                node.next[letter - 'a'] = node.next[letter - 'a'] == null ? new WordNode() : node.next[letter - 'a']).isWord = true;
            }
            public bool Search(string word)
            {
                return reSearch(word, 0, root); // 尋找WordNode
            }
            private bool reSearch(string word, int index, WordNode node)
            {
                if (word.Length == index) return node.isWord; // 長度正確

                return word[index] == '.' // any or not
                    ? node.next.Where(n => n != null).Any(n => reSearch(word, index + 1, n)) // 遍歷所有可能的WordNode
                    : node.next[word[index] - 'a'] != null && reSearch(word, index + 1, node.next[word[index] - 'a']); // 尋找下一個WordNode
            }
            */
        }
        /// <summary>
        /// Problems 258. Add Digits
        /// </summary>
        public static int AddDigits(int num)
        {
            // 迴圈
            //do { num = num.ToString().ToArray().Sum(letter => int.Parse(letter.ToString())); }
            //while (num > 9);
            //return num;

            // 數根(Digital root):所有位數相加直到剩下個位數,超過10就在繼續相加,也就是num%9
            // num>10,num%9>0,return num%9
            //             =0,return 9
            // num<10,return num
            return num == 0 ? 0 : num % 9 == 0 ? 9 : num % 9;
        }
        /// <summary>
        /// Problems 532. K-diff Pairs in an Array
        /// </summary>
        public static int FindPairs(int[] nums, int k)
        {
            if (nums.Length == 1) return 0;

            int count = 0; // k-pair
            if (k == 0)
            {
                Array.Sort(nums);
                bool same = false;
                for(int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] == nums[i - 1])
                    {
                        if (same) continue;
                        count++;
                        same = true;
                    }
                    else same = false;
                }

                //Dictionary<int, int> numDic = new Dictionary<int, int>();// 已有的num
                //foreach (int num in nums)
                //{
                //    if (numDic.ContainsKey(num)) numDic[num]++;
                //    else numDic.Add(num, 1);
                //}
                //foreach (int i in numDic.Values)
                //{
                //    if (i >= 2) count++;
                //}
            }
            else
            {
                HashSet<int> numSet = new HashSet<int>(nums);// num of unique 
                foreach (int num in numSet)
                {
                    if (numSet.Contains(num + k)) count++;
                }                
            }
            return count;
        }
        /// <summary>
        /// Problems 560. Subarray Sum Equals K
        /// </summary>
        public static int SubarraySum(int[] nums, int k)
        {
            //int count = 0;
            //for (int left = 0; left < nums.Length; left++)
            //{
            //    int sum = 0;
            //    for (int right = left; right < nums.Length; right++)
            //    {
            //        sum += nums[right];
            //        count += sum == k ? 1 : 0;
            //    }
            //}
            //return count;

            int sum = 0,
                count = 0;
            Hashtable sumTable = new Hashtable(); // sum, count
            sumTable[0] = 1; // sum == k
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sumTable.ContainsKey(sum - k)) count += (int)sumTable[sum - k];
                sumTable[sum] = sumTable.ContainsKey(sum) ? (int)sumTable[sum] + 1 : 1; // k = 0會重複計數,擺在count之後
            }
            return count;
        }
        /// <summary>
        /// Problems 567. Permutation in String
        /// </summary>
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            Dictionary<char, int> dicInclusion = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (dicInclusion.ContainsKey(c)) dicInclusion[c]++;
                else dicInclusion.Add(c, 1);
            }
            int right = 0;
            for (int left = 0; left < s2.Length; left++)
            {
                if (left > right) right = left;
                for (right = right; right < s2.Length; right++)
                {
                    if (dicInclusion.ContainsKey(s2[right]))
                        if (dicInclusion[s2[right]] > 0) dicInclusion[s2[right]]--;
                        else break;
                    else break;
                    if (dicInclusion.Values.Sum(x => x) == 0) return true;
                }
                if (dicInclusion.ContainsKey(s2[left])) dicInclusion[s2[left]]++; // 有dics1當初始值，不會失真
            }
            return false;
        }
        /// <summary>
        /// Problems 104. Maximum Depth of Binary Tree
        /// </summary>
        public static int MaxDepth(TreeNode root)
        {
            // Preorder Traversal
            int level = 0,
                maxLevel = 0;
            TreeNode currentTN = root;
            Stack<TreeNode> TNStack = new Stack<TreeNode>();
            Stack<int> levelStack = new Stack<int>();
            while (currentTN != null || TNStack.Count > 0)
            {
                while (currentTN != null)
                {
                    level++;
                    maxLevel = level > maxLevel ? level : maxLevel;
                    levelStack.Push(level);
                    TNStack.Push(currentTN);
                    currentTN = currentTN.left;
                }
                if (TNStack.Count > 0)
                {
                    level = levelStack.Pop();
                    currentTN = TNStack.Pop();
                    currentTN = currentTN.right;
                }
            }
            return maxLevel;
        }
        /// <summary>
        /// Problems 136. Single Number
        /// </summary>
        public int SingleNumber(int[] nums)
        {
            //List<int> numList = new List<int>();
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
        /// Problems 39. Combination Sum
        /// </summary>
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            //Array.Sort(candidates);
            //IList<IList<int>> combinationList = new List<IList<int>>(); // sum == target
            //Queue<int[]> maybeQueue = new Queue<int[]>();// sum < target
            //if (candidates[0] > target) return combinationList; // 如果candidates為正序
            //else
            //{
            //    for (int i = 0; i < candidates.Length; i++)
            //    {
            //        int[] temp = { candidates[i] };
            //        if (candidates[i] == target) combinationList.Add(temp);
            //        else if (candidates[i] < target) maybeQueue.Enqueue(temp);
            //    }
            //}
            //while (maybeQueue.Count > 0)
            //{
            //    List<int> maybeList = new List<int>(maybeQueue.Dequeue());
            //    for (int i = Array.IndexOf(candidates, maybeList.Max()); i < candidates.Length; i++)
            //    {
            //        List<int> currMaybeList = new List<int>(maybeList);
            //        currMaybeList.Add(candidates[i]);
            //        int sum = currMaybeList.Sum();
            //        if (sum == target) combinationList.Add(currMaybeList);
            //        else if (sum < target) maybeQueue.Enqueue(currMaybeList.ToArray());
            //    }
            //}
            //return combinationList;

            Array.Sort(candidates); // candidates為正序
            IList<IList<int>> combinationList = new List<IList<int>>(); // sum == target
            GetCombination(new List<int>(), 0, target);
            return combinationList;

            // 新增candidates[i]>移除candidates[last item]>增加candidates[++i]>直到i==candidates.length
            void GetCombination(List<int> currList, int candidates_pos = 0, int remaining = 0) 
            {
                if (remaining == 0)
                {
                    List<int> temp = new List<int>(currList); // deep copy
                    combinationList.Add(temp);
                    return;
                }

                for (int i = candidates_pos; i < candidates.Length && candidates[i] <= remaining; i++)
                {
                    currList.Add(candidates[i]);
                    remaining -= candidates[i];                    
                    if (remaining >= 0) GetCombination(currList, i, remaining);
                    currList.RemoveAt(currList.Count - 1);
                    remaining += candidates[i];
                }
            }
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
    }
    public class Topic
    {
        //1
        //2，一次給滿l1和l2
    }
    //DataTpye
}
