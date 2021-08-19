using System;
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
            //List<int[][]> list_grid = new List<int[][]>();
            //list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 } });
            //list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } });
            //list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 1, 0 } });
            //list_grid.Add(new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 } });
            //list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 0, 0 } });
            //list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 0, 1 } });
            //list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } });
            //list_grid.Add(new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 } });
            //list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 0, 0 } });
            //list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } });
            //list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 1, 0 } });
            //list_grid.Add(new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 } });
            //list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 } });
            //list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 } });
            //list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 } });
            //list_grid.Add(new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 } });
            //list_grid.Add(new int[][] {
            //  new int[] { 1,0,1 }
            //, new int[] { 0,0,0 }
            //, new int[] { 0,1,1 }});
            //list_grid.Add(new int[][] { 
            //  new int[] { 0, 0, 0, 0, 0, 0, 0 }
            //, new int[] { 0, 1, 1, 1, 1, 0, 0 }
            //, new int[] { 0, 1, 0, 0, 1, 0, 0 }
            //, new int[] { 1, 0, 1, 0, 1, 0, 0 }
            //, new int[] { 0, 1, 0, 0, 1, 0, 0 }
            //, new int[] { 0, 1, 0, 0, 1, 0, 0 }
            //, new int[] { 0, 1, 1, 1, 1, 0, 0 }});
            //list_grid.ForEach(delegate(int[][] grid)
            //{
            //    Console.WriteLine(Problems.LargestIsland(grid)); //113
            //});

            //Problems.ListNode l1_result = new Problems.ListNode(0), l1 = l1_result;
            //l1.next = new Problems.ListNode(1);
            //l1 = l1.next;
            //l1.next = new Problems.ListNode(2);
            //l1 = l1.next;
            //l1.next = new Problems.ListNode(4);
            //Problems.ListNode l2_result = new Problems.ListNode(0), l2 = l2_result;
            //l2.next = new Problems.ListNode(1);
            //l2 = l2.next;
            //l2.next = new Problems.ListNode(3);
            //l2 = l2.next;
            //l2.next = new Problems.ListNode(4);
            //Console.WriteLine(Problems.MergeTwoLists(l1_result.next, l2_result.next));

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

            //Console.WriteLine(Problems.PlusOne(new int[] { 9 }));
            //Console.WriteLine(Problems.LengthOfLastWord("Hello World"));
            //Console.WriteLine(Problems.AddBinary("11", "1"));
            //Console.WriteLine(Problems.MySqrt(5));
            //Console.WriteLine(Problems.ClimbStairs(35));


        }


    }
}
