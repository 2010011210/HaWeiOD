using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDemo.Search
{
    public static class SearchUtility
    {
        #region 二分查找
        /// <summary>
        /// 二分查找，折半查找  必须是有序的, 假如是升序
        /// </summary>
        public static int BinarySearch(int[] array, int target) 
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right) 
            {
                int mid = left +  (right - left) / 2;
                if (array[mid] == target)
                {
                    return mid;
                }
                else if(array[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分查找，递归调用
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearchRecursive(int[] array, int left, int right, int target)
        {
            if (left > right)
                return -1;

            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;

            if (array[mid] > target)
                return BinarySearchRecursive(array, left, mid - 1, target);
            else
                return BinarySearchRecursive(array, mid + 1, right, target);
        }

        #endregion
    }
}
