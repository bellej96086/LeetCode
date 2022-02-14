﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace LeetCode
{
    internal class Study_Plan_Data_Structure
    {
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

        /// <summary>
        /// Problems 36. Valid Sudoku
        /// </summary>
        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<char> validSet = new HashSet<char>();
            // Row
            for (int row = 0; row < board.Length; row++) 
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    char temp = board[row][col];
                    if (temp != '.')
                        if (!validSet.Contains(temp)) validSet.Add(temp);
                        else return false;

                }
                validSet.Clear();
            }
            // Column
            for (int col = 0; col < board.GetLength(1); col++)
            {
                for (int row = 0; row < board.Length; row++)
                {
                    char temp = board[row][col];
                    if (temp != '.')
                        if (!validSet.Contains(temp)) validSet.Add(temp);
                        else return false;

                }
                validSet.Clear();
            }
            // Sub-Boxes 3*3


            return true;
        }
    }
}