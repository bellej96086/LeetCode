using System;
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
    }
}
