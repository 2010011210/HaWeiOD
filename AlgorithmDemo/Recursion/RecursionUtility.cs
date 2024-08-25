using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDemo.Recursion
{
    /// <summary>
    /// 递归调用
    /// </summary>
    public static class RecursionUtility
    {
        /// <summary>
        /// 斐波那契数列。指的是这样一个数列：1、1、2、3、5、8、13、21、34、……在数学上，斐波那契数
        /// 获取斐波那契数列第n个值
        /// </summary>
        /// <param name="n"></param>
        public static int Fib(int n) 
        {
            if (n <= 0) 
            {
                return 0;
            }

            if ( n < 3) 
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        
        }
    }
}
