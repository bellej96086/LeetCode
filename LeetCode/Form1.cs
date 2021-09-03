using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeetCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Console.WriteLine(Problems.PlusOne(new int[] { 9 }));
            //Console.WriteLine(Problems.LengthOfLastWord("Hello World"));
            //Console.WriteLine(Problems.AddBinary("11", "1"));
            //Console.WriteLine(Problems.MySqrt(5));
            //Console.WriteLine(Problems.ClimbStairs(35));
            //IsSameTree();
            string[] keyName = { "daniel", "daniel", "daniel", "luis", "luis", "luis", "luis" }
            , keyTime = { "10:00", "10:40", "11:00", "09:00", "11:00", "13:00", "15:00" };
            Console.WriteLine(Problems.SortArrayByParity(new int[] { 3,1,2,4 }));
            //Problems.MoveZeroes(new int[] { 1, 0, 0, 3, 12 });
            //Problems.StreamChecker streamChecker = new Problems.StreamChecker(new string[] { "cd", "f", "kl" });
            //streamChecker.Query('a'); // return False
            //streamChecker.Query('b'); // return False
            //streamChecker.Query('c'); // return False
            //streamChecker.Query('d'); // return True, because 'cd' is in the wordlist
            //streamChecker.Query('e'); // return False
            //streamChecker.Query('f'); // return True, because 'f' is in the wordlist
            //streamChecker.Query('g'); // return False
            //streamChecker.Query('h'); // return False
            //streamChecker.Query('i'); // return False
            //streamChecker.Query('j'); // return False
            //streamChecker.Query('k'); // return False
            //streamChecker.Query('l'); // return True, because 'kl' is in the wordlist





        }

        private void MergeTwoLists() // Ex.21
        {
            Problems.ListNode l1_result = new Problems.ListNode(0), l1 = l1_result;
            l1.next = new Problems.ListNode(1);
            l1 = l1.next;
            l1.next = new Problems.ListNode(2);
            l1 = l1.next;
            l1.next = new Problems.ListNode(4);
            Problems.ListNode l2_result = new Problems.ListNode(0), l2 = l2_result;
            l2.next = new Problems.ListNode(1);
            l2 = l2.next;
            l2.next = new Problems.ListNode(3);
            l2 = l2.next;
            l2.next = new Problems.ListNode(4);
            Console.WriteLine(Problems.MergeTwoLists(l1_result.next, l2_result.next));
        }
        private void DeleteDuplicates() // Ex.83
        {
            Problems.ListNode head_result = new Problems.ListNode(0), head = head_result;
            head.next = new Problems.ListNode(0);
            head = head.next;
            head.next = new Problems.ListNode(0);
            head = head.next;
            head.next = new Problems.ListNode(0);
            head = head.next;
            head.next = new Problems.ListNode(0);
            head = head.next;
            head.next = new Problems.ListNode(0);
            Console.WriteLine(Problems.DeleteDuplicates(head_result.next));
        }
        private void InorderTraversal() // Ex.94
        {
            object[] testcase = new object[] { 1, null, 2, 3, 4, 5, 6, null, null, null, null, 8 };
            Problems.TreeNode root, root_now;
            if (testcase.Length == 0)
                root = null;
            else
                root = new Problems.TreeNode((int)testcase[0], null, null);
            Queue<Problems.TreeNode> root_seq = new Queue<Problems.TreeNode>();
            root_seq.Enqueue(root);
            int now = 1;
            while (testcase.Length > now)
            {
                root_now = root_seq.Dequeue();
                if (testcase[now] != null)
                {
                    root_now.left = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.left);
                }
                else
                    root_now.left = null;

                now++;
                if (testcase.Length <= now) break;

                if (testcase[now] != null)
                {
                    root_now.right = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.right);
                }
                else
                    root_now.right = null;
                now++;
            }
            while (root_seq.Count > 0)
            {
                root_now = root_seq.Dequeue();
                root_now = null;
            }
            Console.WriteLine(Problems.InorderTraversal(root));
        }
        private void PreorderTraversal() // Ex.144
        {
            object[] testcase = new object[] { 1, null, 2, 3, 4, 5, 6, null, null, null, null, 8 };
            Problems.TreeNode root, root_now;
            if (testcase.Length == 0)
                root = null;
            else
                root = new Problems.TreeNode((int)testcase[0], null, null);
            Queue<Problems.TreeNode> root_seq = new Queue<Problems.TreeNode>();
            root_seq.Enqueue(root);
            int now = 1;
            while (testcase.Length > now)
            {
                root_now = root_seq.Dequeue();
                if (testcase[now] != null)
                {
                    root_now.left = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.left);
                }
                else
                    root_now.left = null;

                now++;
                if (testcase.Length <= now) break;

                if (testcase[now] != null)
                {
                    root_now.right = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.right);
                }
                else
                    root_now.right = null;
                now++;
            }
            while (root_seq.Count > 0)
            {
                root_now = root_seq.Dequeue();
                root_now = null;
            }
            Console.WriteLine(Problems.PreorderTraversal(root));
        }
        private void PostorderTraversal() // Ex.145
        {
            object[] testcase = new object[] { 1, null, 2, 3, 4, 5, 6, null, null, null, null, 8 };
            Problems.TreeNode root, root_now;
            if (testcase.Length == 0)
                root = null;
            else
                root = new Problems.TreeNode((int)testcase[0], null, null);
            Queue<Problems.TreeNode> root_seq = new Queue<Problems.TreeNode>();
            root_seq.Enqueue(root);
            int now = 1;
            while (testcase.Length > now)
            {
                root_now = root_seq.Dequeue();
                if (testcase[now] != null)
                {
                    root_now.left = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.left);
                }
                else
                    root_now.left = null;

                now++;
                if (testcase.Length <= now) break;

                if (testcase[now] != null)
                {
                    root_now.right = new Problems.TreeNode((int)testcase[now], null, null);
                    root_seq.Enqueue(root_now.right);
                }
                else
                    root_now.right = null;
                now++;
            }
            while (root_seq.Count > 0)
            {
                root_now = root_seq.Dequeue();
                root_now = null;
            }
            Console.WriteLine(Problems.PostorderTraversal(root));
        }
        private void IsSameTree() // Ex.100
        {
            object[] testcase_p = new object[] {  }
                , testcase_q = new object[] { 0 };
            Problems.TreeNode p, p_now, q, q_now;
            Queue<Problems.TreeNode> p_seq = new Queue<Problems.TreeNode>()
                , q_seq = new Queue<Problems.TreeNode>();

            if (testcase_p.Length == 0)
                p = null;
            else
                p = new Problems.TreeNode((int)testcase_p[0], null, null);            
            p_seq.Enqueue(p);
            int now = 1;
            while (testcase_p.Length > now)
            {
                p_now = p_seq.Dequeue();
                if (testcase_p[now] != null)
                {
                    p_now.left = new Problems.TreeNode((int)testcase_p[now], null, null);
                    p_seq.Enqueue(p_now.left);
                }
                else
                    p_now.left = null;

                now++;
                if (testcase_p.Length <= now) break;

                if (testcase_p[now] != null)
                {
                    p_now.right = new Problems.TreeNode((int)testcase_p[now], null, null);
                    p_seq.Enqueue(p_now.right);
                }
                else
                    p_now.right = null;
                now++;
            }
            while (p_seq.Count > 0)
            {
                p_now = p_seq.Dequeue();
                p_now = null;
            }

            if (testcase_q.Length == 0)
                q = null;
            else
                q = new Problems.TreeNode((int)testcase_q[0], null, null);
            q_seq.Enqueue(q);
            now = 1;
            while (testcase_q.Length > now)
            {
                q_now = q_seq.Dequeue();
                if (testcase_q[now] != null)
                {
                    q_now.left = new Problems.TreeNode((int)testcase_q[now], null, null);
                    q_seq.Enqueue(q_now.left);
                }
                else
                    q_now.left = null;

                now++;
                if (testcase_q.Length <= now) break;

                if (testcase_q[now] != null)
                {
                    q_now.right = new Problems.TreeNode((int)testcase_q[now], null, null);
                    q_seq.Enqueue(q_now.right);
                }
                else
                    q_now.right = null;
                now++;
            }
            while (q_seq.Count > 0)
            {
                q_now = q_seq.Dequeue();
                q_now = null;
            }
            Console.WriteLine(Problems.IsSameTree(p, q));
        }

        private void LargestIsland() // Ex.827
        {
            List<int[][]> list_grid = new List<int[][]>();
            list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 } });
            list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } });
            list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 1, 0 } });
            list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 } });
            list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 0, 0 } });
            list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 0, 1 } });
            list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } });
            list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 } });
            list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 0, 0 } });
            list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } });
            list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 1, 0 } });
            list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 } });
            list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 } });
            list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 } });
            list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 } });
            list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 } });
            list_grid.Add(new int[][] {
              new int[] { 1,0,1 }
            , new int[] { 0,0,0 }
            , new int[] { 0,1,1 }});
            list_grid.Add(new int[][] {
              new int[] { 0, 0, 0, 0, 0, 0, 0 }
            , new int[] { 0, 1, 1, 1, 1, 0, 0 }
            , new int[] { 0, 1, 0, 0, 1, 0, 0 }
            , new int[] { 1, 0, 1, 0, 1, 0, 0 }
            , new int[] { 0, 1, 0, 0, 1, 0, 0 }
            , new int[] { 0, 1, 0, 0, 1, 0, 0 }
            , new int[] { 0, 1, 1, 1, 1, 0, 0 }});
            list_grid.ForEach(delegate (int[][] grid)
            {
                Console.WriteLine(Problems.LargestIsland(grid)); //113
            });
        }
    }
}
