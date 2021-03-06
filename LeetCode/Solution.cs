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
    public partial class Solution : Form
    {
        public Solution()
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
            //string[] keyName = { "daniel", "daniel", "daniel", "luis", "luis", "luis", "luis" }
            //, keyTime = { "10:00", "10:40", "11:00", "09:00", "11:00", "13:00", "15:00" };
            //Console.WriteLine(Problems.SortArrayByParity(new int[] { 3,1,2,4 }));
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

            //[[841,185],[295,946],[928,450],[55,806],[714,89],[787,380],[663,323],[814,265],[581,581],[850,486],[390,491],[560,678],[311,283],[145,772],[987,471],[465,611],[926,367],[782,532],[299,317],[605,260],[751,735],[614,746],[747,904],[267,653]]
            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 1,2,3 };
            matrix[1] = new int[3] { 4,5,6 };
            matrix[2] = new int[3] { 7,8,9 };
            Data_Structure_II.GenerateMatrix(1);
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
