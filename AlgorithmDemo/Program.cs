// See https://aka.ms/new-console-template for more information
using AlgorithmDemo.RateLimit;
using AlgorithmDemo.Recursion;
using AlgorithmDemo.RegexUtility;
using AlgorithmDemo.Search;
using AlgorithmDemo.Sort;

Console.WriteLine("Hello, World!");

var address = "河南省-郑州市-郑州经济技术开发区".Replace("-", "");
Console.WriteLine(address);
// 正则表达式
//RegexUtility.GetNumbers("");

//// 滑动窗口限流
//SlidingWindowRateLimit slidingWindowRateLimitTest = new SlidingWindowRateLimit(5, 1000);
////slidingWindowRateLimitTest.IsLimit();

//SlidingWindowRateLimit slidingWindowRateLimitTest2 = new SlidingWindowRateLimit(2, TimeSpan.FromSeconds(5));
//for (int i = 0; i < 30; i++) 
//{
//    Thread.Sleep(1000);
//    slidingWindowRateLimitTest2.IsAllow();
//}

var r = RecursionUtility.Fib(5);
var nStr = Console.ReadLine();
var n = Int32.Parse(nStr); 
r = RecursionUtility.Fib(n);
Console.WriteLine($"r:{r}");


int[] arr = new int[] { 8, 1, 3, 10, 5, 7, 3, 5, 4, 9, 6 };
//SortUtility.InsertionSort(arr);  // 插入排序 PopSort
//SortUtility.PopSort(arr);  // 冒泡排序 
var sortedArr = arr.OrderBy(i => i).ToArray();
var index = SearchUtility.BinarySearch(sortedArr, 2);  // BinarySearchRecursive 
var index2 = SearchUtility.BinarySearchRecursive(sortedArr,0, 10, 2);  // BinarySearchRecursive 

//int[] arr2 = new int[] { 8, 1, 2, 7, 3, 5, 4, 9, 10 };
//SortUtility.InsertionSortWithSentinel(arr2);  //InsertionSortWithSentinel

Console.ReadLine();