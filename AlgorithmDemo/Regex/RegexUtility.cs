using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgorithmDemo.RegexUtility
{
    public class RegexUtility
    {
        // 获取所有数字
        public static void GetNumbers(string input) 
        {
            // 1.提取单个数字 。 "我是123的好几倍".提取123
            string message = "我是123的好几倍";
            string result = System.Text.RegularExpressions.Regex.Replace(message, @"[^0-9]+", "");

            // 2.提取多个数字
            var str = "第一个数字123，第二个数字456";
            string pattern = @"[0-9]+";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时

            MatchCollection mc = reg.Matches(str);//设定要查找的字符串
            foreach (Match matchItem in mc) 
            {
                Console.WriteLine(matchItem.Groups[0].Value);
            }

            //订单23051957734356,23423432432状态已取消
            string pattern2 = @"订单[0-9]+状态已取消";

            string pattern3 = @"订单[0-9]+,*[0-9]+状态已取消";
            string str2 = "订单23051957734356状态已取消";
            string str3 = "订单23051957734356,23423432432状态已取消";
            reg = new Regex(pattern2, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str2);//设定要查找的字符串
            //foreach (Match match in mc)
            //{
            //    Console.WriteLine(match.Groups[0].Value);
            //}

            reg = new Regex(pattern3, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str3);//设定要查找的字符串
            //foreach (Match match in mc)
            //{
            //    Console.WriteLine(match.Groups[0].Value);
            //}

            string pattern4 = @"订单.*状态已取消";
            reg = new Regex(pattern4, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str3);//设定要查找的字符串

            string pattern5 = @"(?<=订单).*(?=状态已取消)"; 
            reg = new Regex(pattern5, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str3);//设定要查找的字符串  //提取到23051957734356,23423432432

            string pattern6 = @"(?<=订单)([0-9]+,*)(?=状态已取消)";
            reg = new Regex(pattern6, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str3);//设定要查找的字符串  //提取到23051957734356,23423432432

            string str4 = "发货失败，错误原因：订单23042819857350,2342343243状态已取消";
            string pattern7 = @"订单(?<orderIds>.*)状态已取消";
            reg = new Regex(pattern7, RegexOptions.IgnoreCase | RegexOptions.Singleline, TimeSpan.FromSeconds(2));//2秒后超时
            mc = reg.Matches(str4);//设定要查找的字符串  //提取到23051957734356,23423432432
            var match = reg.Match(str4);
            if (match.Success)
            {
                var orderIdsMatch = match.Groups["orderIds"].Value;
                if (string.IsNullOrEmpty(orderIdsMatch))
                {
                    return ;
                }
                var orderIds = orderIdsMatch.Split(",").ToList();
            }
            // 3.提取有小数点的数字
            string str9 = "提取123.11abc提取"; //我们抓取当前字符当中的123.11
            if (Regex.IsMatch(str9, @"^[+-]?\d*[.]?\d*$")) 
            {
                decimal result9 = decimal.Parse(str);
            }
            //foreach (Match match in mc)
            //{
            //    Console.WriteLine(match.Groups[0].Value);
            //}

        }
    }
}
