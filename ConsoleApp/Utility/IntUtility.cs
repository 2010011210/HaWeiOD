using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    public  class IntUtility
    {
        // 十六进制转十进制
        public static void Data16Convert() 
        {
            string n = System.Console.ReadLine();
            var result = Convert.ToInt32(n, 16);
            Console.WriteLine(result);
        }

        // 四舍5入
        public static void MathRound()
        {
            decimal n = decimal.Parse(System.Console.ReadLine());
            var result = Math.Round(n, MidpointRounding.AwayFromZero);
            // var result = Convert.ToInt16(n);
            Console.WriteLine(result);
        }

        // 数字倒着输出，去除重复的项
        public static void ReverseAndRemoveDuplicate() 
        {
            int inputNum = Convert.ToInt32(System.Console.ReadLine());
            HashSet<int> result = new HashSet<int>();

            while (inputNum >= 10) 
            {
                int s = inputNum % 10;
                if (result.Add(s))
                {
                    Console.Write(s);
                }
                inputNum = inputNum / 10;
            }

            if (result.Add(inputNum))
            {
                Console.Write(inputNum);
            }
        }

        // 输出二进制中1的位数
        public static void GetByteOneCount()
        {
            int inputNum = Convert.ToInt32(System.Console.ReadLine());
            int count = 0;
            while (inputNum > 0)
            {
                int s = inputNum % 2;
                if (s == 1)
                {
                    count++;
                }
                inputNum = inputNum / 2;
            }

            Console.Write(count);
        }

        // 空汽水瓶
        public static void EmptyBottle() 
        {
            int inputCount = 10;
            while (inputCount > 0) {
                var n = Convert.ToInt32(Console.ReadLine());
                if (n == 0) 
                {
                    break;
                }

                int count = 0;  //总共能喝多少汽水
                while (n > 2)
                {
                    int num = n / 3;  // 换到的汽水的数量
                    count += num;
                    n = num + n % 3;  //空瓶加换到的汽水的数量
                }

                if (n == 2)
                {
                    count++;
                }

                Console.WriteLine(count);
                inputCount--;
            }
        }

        // 求最小公倍数
        public static void MinCommonMultiple() 
        {
            string line = System.Console.ReadLine();
            int a = Convert.ToInt32(line.Split(" ")[0]);
            int b = Convert.ToInt32(line.Split(" ")[1]);

            if (a > b) 
            {
                for (int i = 1; i < a; i++) 
                {
                    if (a*i%b == 0) 
                    {
                        Console.WriteLine(a * i);
                        break;
                    } 
                }
            }
            else
            {
                for (int i = 1; i < b; i++)
                {
                    if (b * i % a == 0)
                    {
                        Console.WriteLine(b * i);
                        break;
                    }
                }
            }

        }

        // 素数的乘积
        public static HashSet<int> numberSets = new HashSet<int>();
        public static void PrimeNumber() 
        {
            int line = Convert.ToInt32(System.Console.ReadLine());

            if (line <= 3)
            {
                Console.WriteLine("-1 -1");
            }

            int sqrt = (int)Math.Sqrt(line);
            bool isSuccess = false;
            for (int i = 3; i <= sqrt; i++ ) 
            {
                if (sqrt % i != 0) 
                {
                    continue;
                }

                if (numberSets.Contains(i) || Check(i)) //i是素数
                {
                    int d = line / i;
                    if (numberSets.Contains(d)) // d也是素数
                    {
                        isSuccess = true;
                        Console.WriteLine($"{i} {d}");
                        break;
                    }
                    else if(Check(d)) 
                    {
                        isSuccess = true;
                        Console.WriteLine($"{i} {d}");
                        break;
                    }
                }
            }

            if (!isSuccess) 
            {
                Console.WriteLine("-1 -1");
            }
        }

        public static bool Check(int n) 
        {
            int sqrt = (int)Math.Sqrt(n);
            for (int i = 2; i <= sqrt; i++) 
            {
                if ( n%i == 0) 
                {
                    return false;
                }
            }
            numberSets.Add(n);
            return true;
        }

        // 数字， 连续的数字相加
        public static void NumberPlus() 
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> numbers = new List<int>();
            int count = 0;
            int sum = 0;
            for (int i = n; i > 0; i--) 
            {
                numbers.Clear();
                numbers.Add(i);
                sum = i;
                if (sum == n) 
                {
                    count++;
                    LogNumbers(n, numbers);
                }

                for (int j = i-1; j > 0; j--) 
                {
                    numbers.Add(j);
                    sum += j;
                    if (sum > n) 
                    {
                        break;
                    }

                    if (sum == n) 
                    {
                        count++;
                        LogNumbers(n, numbers);
                    }
                }
            }

            Console.WriteLine($"Result:{count}");

        }

        public static void LogNumbers(int n, List<int> lists) 
        {
            Console.WriteLine($"{n}={string.Join("+", lists.Order())}");
        }

        //十进制转二进制
        public static void IntToBinary() 
        {
            int s = int.Parse(Console.ReadLine());
            var b = Convert.ToString(s, 2);  
            Console.WriteLine(b);
        }

        // 二进制转十进制
        public static void BinaryToInt()
        {
            string s = Console.ReadLine();
            var b = Convert.ToInt32(s, 2);
            var b2 = Convert.ToInt32("0xAA", 16);  // 16进制转十进制
            Console.WriteLine(b);
            Console.WriteLine(b2);
        }


    }
}
