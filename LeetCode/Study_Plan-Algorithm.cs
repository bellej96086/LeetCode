using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Study_Plan_Algorithm
    {
        /// <summary>
        /// Problems 704. Binary Search
        /// </summary>
        public static int Search(int[] nums, int target)
        {
            // 
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
        public static int BadVersion = 0;
        public static bool IsBadVersion(int version)
        {
            return version >= BadVersion;
        }
        public static int FirstBadVersion(int n, int bad) // 問題呼叫不包含bad
        {
            BadVersion = bad; // 不包含

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
    }
}
