using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    public class StringUtility
    {
        #region 1. 字符串最后一个单词的长度
        public static void GetLastWordLength() 
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            { 
                string[] letters = line.Split(" ");
                System.Console.WriteLine(letters[letters.Length-1].Length);
            }
        }

        #endregion

        #region 2. 获取单词出现的次数,不区分大小写
        public static void GetWordCount()
        {
            string line = Console.ReadLine();
            string letter = Console.ReadLine();
            var lowerLine = line.ToLower();
            var lowerLetter = letter.ToLower();
            var count = lowerLine.Length - lowerLine.Replace(lowerLetter, "").Length;
            Console.WriteLine(count);
        }
        #endregion

        #region 字符串每次输出8个字符。 小于8的，后面补齐0，筹够8个

        public static void Get8Letter() 
        {
            string line = Console.ReadLine();
            while (line.Length > 8) 
            {
                var splitStr = line.Substring(0, 8);
                Console.WriteLine(splitStr);
                line = line.Substring(8);
            }

            if (line.Length < 8 && line.Length > 0) 
            {
                line += "00000000";
                line = line.Substring(0, 8);
                Console.WriteLine(line);
            }
        }


        #endregion

        //3 获取单词出现的数量
        public static void GetLetterCount()
        {
            string line = Console.ReadLine();
            HashSet<char> hashSet = new HashSet<char>();

            for (int i = 0; i < line.Length; i++) 
            {
                hashSet.Add(line[i]);
            }
            Console.WriteLine(hashSet.Count());

        }

        //4 字符串反转
        public static void ReverseStr() 
        {
            string line = Console.ReadLine();
            for (int i = line.Length - 1; i > 0; i--)
            {
                Console.Write(line[i].ToString());
            }
        }

        //5 句子的单词反转
        public static void ReverseWords()
        {
            string line = Console.ReadLine();
            List<string> words = line.Split(" ").ToList();
            words.Reverse();
            Console.WriteLine(string.Join(" ", words));
        }

        //6 单词反转，只要不是a-zA-Z的都算间隔
        public static void ReverseWordsByNotLetterSplit()
        {
            string line = Console.ReadLine();
            string rawLine = line;
            string space = " ";
            for (int i = 0; i < line.Length; i++) 
            {
                char c = line[i];
                if (!IsLetter(c))   // 或者直接用char类自带的方法 char.IsLetter(c)
                {
                    rawLine = rawLine.Replace(c.ToString(), space);
                }
            
            }
            var rawlineList = rawLine.Split(space).ToList();

            rawlineList.Reverse();
            Console.WriteLine(string.Join(" ", rawlineList));
        }


        //7 字符是不是英文字母，大小写都算。
        public static bool IsLetter(Char c) 
        {
            char.IsLetter(c);
            bool isLetter = (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
            return isLetter;
        }

        /// <summary>
        ///8 移除字符串中出现次数最少的单词
        /// </summary>
        public static void RemoveLeastLetter() 
        {
            string line = Console.ReadLine();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < line.Length; i++) 
            {
                var letter = line[i].ToString();
                if (dict.ContainsKey(letter)) 
                {
                    dict[letter]++;
                }
                else
                {
                    dict.Add(letter, 1);
                }
            }

            int minCount = dict.Values.Min();  //获取出现最少的次数
            foreach (var key in dict.Keys) 
            {
                if (dict[key] == minCount) 
                {
                    line = line.Replace(key ,"");
                }
            }

            Console.WriteLine(line);
        }

        //9 简单密码
        public static void SimplePassWord() 
        {
            const string inputStr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string outputStr ="22233344455566677778889999bcdefghijklmnopqrstuvwxyza0123456789";
            List<string> rawLetters = new List<string>();
            List<string> processLetters = new List<string>();
            for (int i = 0; i < inputStr.Length; i++) 
            {
                rawLetters.Add(inputStr[i].ToString());
            }

            for (int i = 0; i < outputStr.Length; i++)
            {
                processLetters.Add(outputStr[i].ToString());
            }

            string line = Console.ReadLine();
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < line.Length; i++) 
            {
                var letter = line[i].ToString(); 
                int index = rawLetters.IndexOf(letter);
                if (index != -1)
                {
                    res.Append(processLetters[index]);
                }
                else 
                {
                    res.Append(letter);
                }
            }

            Console.WriteLine(res.ToString());
        }

        #region 动态规划，最多的背包重量
        public static void GetTest() 
        {
            var m_n = Console.ReadLine().Split(' ');
            int m = int.Parse(m_n[0]); // money
            int n = int.Parse(m_n[1]); // input items count

            Good[] allGoods = new Good[n + 1];

            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                int price = int.Parse(input[0]);
                int value = int.Parse(input[1]) * price;
                int index = int.Parse(input[2]); // refer to main good index in allGoods array
                Good good = new Good(price, value, index);
                allGoods[i] = good;
            }

            // assign all main good with its sub good index
            for (int i = 1; i < allGoods.Length; i++)
            {
                Good t_good = allGoods[i];
                if (t_good.MainIndex == 0)
                {
                    continue;
                }
                else
                {
                    Good t_mainGood = allGoods[t_good.MainIndex];
                    if (t_mainGood.G1 == 0)
                    {
                        t_mainGood.G1 = i;
                    }
                    else
                    {
                        t_mainGood.G2 = i;
                    }
                }
            }

            Good[] mainGoods = allGoods.Where(g => g != null && g.MainIndex == 0).ToArray();
            int[,] dp = new int[mainGoods.Length + 1, m / 10 + 1]; // dp state

            // if a dp state value is -1, a new dp state can't transfer from it
            for (int i = 0; i <= mainGoods.Length; i++)
            {
                for (int j = 0; j <= m / 10; j++)
                {
                    dp[i, j] = -1;
                }
            }

            dp[0, 0] = 0; // init dp state

            for (int i = 1; i <= mainGoods.Length; i++)
            {
                Good g = mainGoods[i - 1];
                for (int j = m / 10; j >= 0; j--)
                {
                    // no main good
                    if (dp[i - 1, j] != -1)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }

                    int sumPrice;
                    int sumValue;

                    // a main good
                    sumPrice = g.Price / 10;
                    sumValue = g.Value;
                    if (j - sumPrice >= 0 && dp[i - 1, j - sumPrice] >= 0)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j - sumPrice] + sumValue, dp[i - 1, j]);
                    }

                    // a main good and a sub good
                    if (g.G1 != 0)
                    {
                        sumPrice = g.Price / 10 + allGoods[g.G1].Price / 10;
                        sumValue = g.Value + allGoods[g.G1].Value;
                        if (j - sumPrice >= 0 && dp[i - 1, j - sumPrice] >= 0)
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j - sumPrice] + sumValue, dp[i, j]);
                        }
                    }
                    if (g.G2 != 0)
                    {
                        sumPrice = g.Price / 10 + allGoods[g.G2].Price / 10;
                        sumValue = g.Value + allGoods[g.G2].Value;
                        if (j - sumPrice >= 0 && dp[i - 1, j - sumPrice] >= 0)
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j - sumPrice] + sumValue, dp[i, j]);
                        }
                    }

                    // a main good and 2 sub good
                    if (g.G1 != 0 && g.G2 != 0)
                    {
                        sumPrice = g.Price / 10 + allGoods[g.G1].Price / 10 + allGoods[g.G2].Price / 10;
                        sumValue = g.Value + allGoods[g.G1].Value + allGoods[g.G2].Value;
                        if (j - sumPrice >= 0 && dp[i - 1, j - sumPrice] >= 0)
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j - sumPrice] + sumValue, dp[i, j]);
                        }
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < dp.GetLength(1); i++)
            {
                result = Math.Max(result, dp[dp.GetLength(0) - 1, i]);
            }

            Console.WriteLine(result);
        }

        #endregion


        // 错误日志和行号的问题

        #region 验证密码
        // 验证密码，
        // 1.长度大于8，
        // 2.有大写字母，消息字符，数字，特殊字符，中的最少3种。
        // 3.不能有长度大于2的包含公共元素的子串重复 （注：其他符号不含空格或换行）
        public static void VerifyCode()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.Length < 8)
                {
                    Console.WriteLine("NG");
                    return;
                }

                //  有大写字母，数字，特殊字符，中的最少3种
                if (!IsContainThreeType(line))
                {
                    Console.WriteLine("NG");
                    return;
                }

                if (IsContainDupliacteWord(line))
                {
                    Console.WriteLine("NG");
                    return;
                }
                Console.WriteLine("OK");
            }
        }

        // 是否包含3种类型的符号
        public static bool IsContainThreeType(string content)
        {
            int a = 0, b = 0, c = 0, d = 0;
            if (Regex.IsMatch(content, "[A-Z]"))
            {
                a = 1;
            }

            if (Regex.IsMatch(content, "[a-z]"))
            {
                b = 1;
            }

            if (Regex.IsMatch(content, "[0-9]"))
            {
                c = 1;
            }

            if (Regex.IsMatch(content, "[^0-9a-zA-Z]"))
            {
                d = 1;
            }

            return (a + b + c + d) >= 3;
        }

        public static bool IsContainDupliacteWord(string content)
        {
            if (content.Length < 4)
            {
                return false;
            }

            for (int i = 0; i < content.Length - 4; i++)
            {
                string leftLetters = content.Substring(i, 3);
                string rightLetters = content.Substring(i + 3);
                bool isContains = rightLetters.Contains(leftLetters);
                if (isContains)
                {
                    return isContains;
                }
            }

            return false;
        }

        #endregion

        /// <summary>
        ///10 对称密码
        /// </summary>
        public static void GetSymmetryCount() 
        {
            string line = Console.ReadLine();

            int res = 0;
            for (int i = 0; i < line.Length; i++ ) 
            {
                var longestOne = GetLongest(line, i, i);
                var longestTwo = GetLongest(line, i, i+1);

                res = Math.Max(res , Math.Max(longestOne, longestTwo));
            }

            Console.WriteLine(res);
        }

        public static int GetLongest(string content, int l, int r) 
        {
            while ( l >= 0 && r < content.Length && content[l] == content[r]) 
            {
                l--;
                r++;
            }

            return r - l - 1;
        }


        //11 分割均衡字符串
        public static void GetSubString()
        {
            var line = Console.ReadLine();

            List<string> strList = new List<string>();
            int index = 0;
            int xCnt = 0;
            int yCnt = 0;
            int length = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'X')
                {
                    xCnt++;
                }
                else
                {
                    yCnt++;
                }
                length++;

                if (yCnt == xCnt)
                {
                    string s = line.Substring(index, length);
                    strList.Add(s);
                    index = i + 1;
                    xCnt = 0;
                    yCnt = 0;
                    length = 0;
                }
            }

            Console.WriteLine(strList.Count());

        }


        //12 万能字符串
        public static void MultiString()
        {
            var wordCount = Convert.ToInt32(Console.ReadLine());
            List<string> letterList = new List<string>();
            for (int i = 0; i < wordCount; i++)
            {
                string letter = Console.ReadLine();
                letterList.Add(letter);
            }

            string commonWords = Console.ReadLine();

            List<string> successWords = new List<string>();
            for (int i = 0; i < letterList.Count(); i++)
            {
                var letter = letterList[i];
                for (int j = 0; j < letter.Length; j++)
                {
                    char c = letter[j];
                    int charIndex = commonWords.IndexOf(c);
                    int charMultiIndex = commonWords.IndexOf("?");
                    if (charIndex > -1)
                    {
                        commonWords = commonWords.Remove(charIndex, 1);
                    }
                    else if (charMultiIndex > -1)
                    {
                        commonWords =commonWords.Remove(charMultiIndex, 1);  //万能符号
                    }
                    else
                    {
                        continue;
                    }

                    if (j == letter.Length - 1)
                    {
                        successWords.Add(letter);
                    }
                }
            }

            Console.WriteLine(successWords.Count);
            Console.WriteLine(string.Join(" ", successWords));
        }

        //13 获取最少停车的车辆
        public static void GetMinParkPosition() 
        {
            string car = "#";
            var line = Console.ReadLine();
            line = line.Replace(",","");
            line = line.Replace("111", "#"); // 卡车
            line = line.Replace("11", "#");  // 货车
            line = line.Replace("1", "#");  // 小车

            int carNum = 0;
            for (int i = 0; i < line.Length; i++) 
            {
                if (line[i] == '#') 
                {
                    carNum++;
                }
            }

            Console.WriteLine(carNum);
        }

        //14 火星文 #优先级高于$
        public static void FireStartLetter() 
        {
            var input = Console.ReadLine();

            string[] splitContent = input.Split("$");
            if (splitContent.Length == 1) 
            {
                int num = GetNumber(splitContent[0]);
                Console.WriteLine(num);
                return;
            }
            int result = 0;
            for (int i = 0; i < splitContent.Length-1; i++) 
            {
                int y = GetNumber(splitContent[i+1]);
                if (i == 0) 
                {
                    result = GetNumber(splitContent[i]);
                    i++;
                }

                result = 2 * result + y + 3;
            }

            Console.WriteLine(result);
        }

        public static int GetNumber(string content) 
        {
            if (content.IndexOf("#") != -1)
            {
                string[] contentArr = content.Split("#");

                int x = 0;
                for (int i = 0; i < contentArr.Length-1; i++) 
                {
                    int y = int.Parse(contentArr[i + 1]);
                    if (i == 0) 
                    {
                        x = int.Parse(contentArr[i]);
                    }
                    
                    x = 4*x+ 3*y + 2;
                }
                return x;
            }
            else 
            {
                return int.Parse(content);
            }
        
        }


        // 15  最长子字符串 o x l都是偶数个
        public static void GetLongestString() 
        {
            string input = Console.ReadLine();
            int length = input.Length;

            //char.IsLetter;
            //char.IsDigit;

            var result = Regex.Replace(input,"[a-zA-z]","");
            Console.WriteLine(result);

            string concatString = input + input;

            int maxLength = 0;
            string maxString = "";
            for (int i = 0; i < length; i++) 
            {
                for (int j = 0; j < input.Length; j++) 
                {
                    var splitStr = concatString.Substring(i, j+1);
                    int currentLength = splitStr.Length;
                    int oCount = currentLength - splitStr.Replace("o","").Length;
                    int lCount = currentLength - splitStr.Replace("l","").Length;
                    int xCount = currentLength - splitStr.Replace("x","").Length;
                    if ((oCount %2 == 0) && (lCount % 2 == 0) && (xCount % 2 == 0)) 
                    {
                        if (currentLength > maxLength)
                        {
                            maxString = splitStr;
                            maxLength = currentLength;
                        }
                    }
                }
            }

            System.Console.WriteLine(maxString);
            System.Console.WriteLine(maxLength);
        }

        public static void Get() 
        {
            string a = "123";
            a = a.Replace("[A-Z]", "");
            int s = a.LastIndexOf("2");  //最后一次出现的
            a = Regex.Replace(a, "[A-Z]", "");
;       }

        public static void CharOrderByAscil() 
        {
            string stringInput = Console.ReadLine();
            int[] chars = new int[128];
            for (int i = 0; i < stringInput.Length; i++) 
            {
                char c = stringInput[i];
                chars[(int)c]++;
            }

            int max = 0;
            for (int i = 0; i < 128; i++) 
            {
                if (chars[i] >= max) 
                {
                    max = chars[i];
                }
            }

            StringBuilder strBuilder = new StringBuilder();
            while (max > 0) 
            {
                for (int i = 0; i < 128; i++) 
                {
                    if (chars[i] == max) 
                    {
                        strBuilder.Append((Char)i);
                    }
                }
                max--;
            }

            Console.WriteLine(strBuilder.ToString());
        }

    }
    public class Good
    {
        public int Price
        {
            get;
        }
        public int Value
        {
            get;
        }
        public int MainIndex
        {
            get;
        }

        public int G1
        {
            get;
            set;
        } = 0;
        public int G2
        {
            get;
            set;
        } = 0;

        public Good(int price, int value, int mainIndex)
        {
            Price = price;
            Value = value;
            MainIndex = mainIndex;
        }
    }





}
