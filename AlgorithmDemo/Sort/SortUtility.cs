using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDemo.Sort
{
    public class SortUtility
    {
        #region 插入排序
        // 1.插入排序
        public static void InsertionSort(int[] arr)
        {
            int count = 0;
            Console.WriteLine($"原始:{string.Join(",", arr)}");
            for (int i = 1; i < arr.Length; i++)
            {
                Console.WriteLine($"i:{i}");
                int key = arr[i];
                int j = i - 1;
                count++;
                while (j >= 0 && arr[j] > key)
                {
                    Console.WriteLine($"第{j}个:{arr[j]}=> 第{j+1}个:{arr[j + 1]}");
                    arr[j + 1] = arr[j];
                    Console.WriteLine($"{string.Join(",", arr)}");
                    Console.WriteLine($"arr[{j}]是{arr[j]}: key是{key}，arr[j]是否小于key：{arr[j] > key}");
                    j--;
                }
                Console.WriteLine($"第{j+1}个:{key}=> 第{j + 1}个");
                arr[j + 1] = key;   // 把最初下标是i的那个数字，赋值给最后一个比arr[i]大的那个数字
                Console.WriteLine($"第{i}个循环结束：{string.Join(",", arr)}");
            }

            Console.WriteLine($"Finish:{string.Join(",", arr)}");
            Console.WriteLine($"总次数：{count}");
        }

        // 插入排序的哨兵模式，先找到最小的放在最左边，防止越界。就不用判断j》=0了。
        public static void InsertionSortWithSentinel(int[] arr)
        {
            int n = arr.Length;

            // 将第一个元素作为哨兵
            int sentinelIndex = 0;
            for (int i = 1; i < n; i++) 
            {
                if (arr[i] < arr[sentinelIndex])
                {
                    sentinelIndex = i;
                }
            }
            
            int temp = arr[0];
            arr[0] = arr[sentinelIndex];
            arr[sentinelIndex] = temp;

            // 排序
            for (int i = 2; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                   
                }
                arr[j + 1] = key;
                Console.WriteLine($"{string.Join(",", arr)}");
            }

            Console.WriteLine($"Finish:{string.Join(",", arr)}");
        }

        #endregion

        #region 冒泡排序

        public static void PopSort(int[] arr) 
        {
            int count = 0;
            Console.WriteLine($"初始：{string.Join(",", arr)}");
            for (int i = 0; i < arr.Length; i++) 
            {
                for (int j = 0; j < arr.Length- i -1; j ++) 
                {
                    count++;
                    var first = arr[j];
                    var second = arr[j+1];
                    if (first > second) 
                    {
                        arr[j+1] = first;
                        arr[j] = second;
                        Console.WriteLine($"i:{i},j:{j}，数组：{string.Join(",", arr)}");
                    }
                }
            }
            Console.WriteLine($"结束：{string.Join(",", arr)}");
            Console.WriteLine($"总次数：{count}");

        }


        #endregion


    }
}
