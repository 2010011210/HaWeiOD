using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace ConsoleApp.Utility
{
    public class ArrayUtility
    {
        #region 输入几个数字，去重并排序。
        public static void GetSortArray() 
        {
            // 用list，最简单
            int n = System.Convert.ToInt32(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++) { 
                int num = Convert.ToInt32(Console.ReadLine());
                list.Add(num);
            }

            list = list.Distinct().ToList();
            list.Sort();
            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine(list[i]);
            }
        }

        public static void GetSortArrayByArrayIndex()
        {
            // 用list，最简单
            int n = System.Convert.ToInt32(Console.ReadLine());
            int[] array = new int[1001];
            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                array[num] = 1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1) 
                {
                    Console.WriteLine(i);
                }
            }
        }

        /// <summary>
        /// 背包装物品的问题， 华为机试
        /// https://www.nowcoder.com/practice/f9c6f980eeec43ef85be20755ddbeaf4?tpId=37&tqId=21239&rp=1&ru=/exam/oj/ta&qru=/exam/oj/ta&sourceUrl=%2Fexam%2Foj%2Fta%3Fpage%3D1%26tpId%3D37%26type%3D37&difficulty=undefined&judgeStatus=undefined&tags=&title=
        /// </summary>
        public static void BagQuestion() 
        {
            var inputs = Console.ReadLine();
            var money = Convert.ToInt32(inputs.Split(" ")[0]);
            var n = Convert.ToInt32(inputs.Split(" ")[1]);

            Good[] goods = new Good[n + 1]; 
            for (int i = 1; i <= n; i++)
            {
                goods[i] = new Good();
            }

            for (int i = 1; i <= n; i++) 
            {
                string goodString = Console.ReadLine();
                ProcessGoods(i, goodString, goods);
            }

            PrintResult(money, goods);
        }

        public static void ProcessGoods(int i, string goodString, Good[] goods) 
        {
            var goodsArr = goodString.Split(" ");
            int v = Convert.ToInt32(goodsArr[0]);
            int p = Convert.ToInt32(goodsArr[1]);
            int q = Convert.ToInt32(goodsArr[2]);
            goods[i].v = v;
            goods[i].p = p;
            goods[i].q = q;

            if (q > 1) 
            {
                if (goods[q].a1 == 0) 
                {
                    goods[q].SetA1(i);
                }
                else
                {
                    goods[q].SetA2(i);
                }
            }
        }

        public static void PrintResult(int N, Good[] A)
        {
            int[,] dp = new int[A.Length , N+1];
            for (int i = 1, len = A.Length; i < len; i++)
            {
                int v = -1, v1 = -1, v2 = -1, v3 = -1, tempDp = -1,
                tempDp1 = -1, tempDp2 = -1, tempDp3 = -1;
                v = A[i].v;
                tempDp = v * A[i].p;
                if (A[i].a1 != 0)
                {  //主件+附件1
                    v1 = v + A[A[i].a1].v;
                    tempDp1 = tempDp + A[A[i].a1].v * A[A[i].a1].p;
                }
                if (A[i].a2 != 0)
                {   //主件+附件2
                    v2 = v + A[A[i].a2].v;
                    tempDp2 = tempDp + A[A[i].a2].v * A[A[i].a2].p;
                }
                if (A[i].a1 != 0 && A[i].a2 != 0)
                {  //主件+附件1+附件2
                    v3 = v + A[A[i].a1].v + A[A[i].a2].v;
                    tempDp3 = tempDp + A[A[i].a1].v * A[A[i].a1].p + A[A[i].a2].v * A[A[i].a2].p;
                }
                for (int j = 1; j <= N; j++)
                {
                    if (A[i].q > 0)
                    {   //当物品i是附件时,相当于跳过
                        dp[i,j] = dp[i - 1,j];
                    }
                    else
                    {
                        dp[i,j] = dp[i - 1,j];
                        if (j >= v && v != -1)
                            dp[i,j] = Math.Max(dp[i - 1,j], dp[i - 1,j - v] + tempDp);
                        if (j >= v1 && v1 != -1)
                            dp[i,j] = Math.Max(dp[i,j], dp[i - 1,j - v1] + tempDp1);
                        if (j >= v2 && v2 != -1)
                            dp[i,j] = Math.Max(dp[i,j], dp[i - 1,j - v2] + tempDp2);
                        if (j >= v3 && v3 != -1)
                            dp[i,j] = Math.Max(dp[i,j], dp[i - 1,j - v3] + tempDp3);
                    }
                }
            }
            Console.WriteLine(dp[A.Length - 1,N]);
            return;
        }


        public class Good
        {   //物品内部类
            public int v;  //物品的价格
            public int p;  //物品的重要度
            public int q;
            public int a1 = 0;  //附件1的编号
            public int a2 = 0;  //附件2的编号

            public void SetA1(int a1)
            {
                this.a1 = a1;
            }

            public void SetA2(int a2)
            {
                this.a2 = a2;
            }
        }

        #endregion

        /// <summary>
        /// 1.鼠标移动
        /// </summary>
        public static void MoveCursor()
        {
            string line = Console.ReadLine();
            int[,] origin = new int[1, 2] { { 0, 0 } };
            var commondLines = line.Split(";");
            for (int i = 0; i < commondLines.Length-1; i++)
            {
                string cmdLine = commondLines[i];
                //bool isMatch = Regex.IsMatch(cmdLine, "[WSAD][0-9]{1,2}");  //或者用正则表达式
                //if (!isMatch) 
                //{
                //    continue;
                //}

                string direct = cmdLine.Substring(0, 1);
                string valString = cmdLine.Substring(1);
                if (int.TryParse(valString, out int val))
                {
                    switch (direct)
                    {
                        case "W": origin[0, 1] += val; break;
                        case "S": origin[0, 1] -= val; break;
                        case "A": origin[0, 0] -= val; break;
                        case "D": origin[0, 0] += val; break;
                        default: break;
                    }
                }
            }

            Console.WriteLine($"{origin[0, 0]},{origin[0, 1]}");
        }

        /// <summary>
        /// 2一天只能处理一个任务
        /// </summary>
        public static void ProcessTask() 
        {
            int n = Convert.ToInt32( Console.ReadLine() );
            int count = 0;
            int[,] tasks = new int[n,2];
            for (int i = 0; i < n; i++) {
                string taskDays = Console.ReadLine();
                int start = Convert.ToInt32(taskDays.Split(" ")[0]);
                int end = Convert.ToInt32(taskDays.Split(" ")[1]);
                tasks[i, 0] = start;
                tasks[i, 1] = end;
            }

            for (int i = 0; i < n; i++) 
            {
                int isProcessTaskCount = 0;
                for (int j = 0; j < tasks.GetLength(0); j++) 
                {
                    if (tasks[j, 0] == 1 && isProcessTaskCount ==0)  //1天处理一个任务
                    {
                        count++;
                        isProcessTaskCount++;
                        tasks[j, 0] -= 1;  //减1
                        tasks[j, 1] -= 1;  //减1
                        Console.WriteLine();
                    }
                    else 
                    {
                        if (tasks[j, 0] == 1)
                        {
                            if (tasks[j, 1] <= 1)  //只剩一天可以处理这个任务了
                            {
                                tasks[j, 0] = 0;
                                tasks[j, 1] -= 1;
                            }
                            else 
                            {
                                tasks[j, 1] -= 1;
                            }
                        }
                        else 
                        {
                            tasks[j, 0] -= 1;  //该任务当天还不能处理，减1
                            tasks[j, 1] -= 1;  //该任务剩余多少天处理 减1
                        };  
                    }
                }
            }

            Console.WriteLine(count);
        }

        // 3吃披萨
        public static void Pizza() 
        {
            var n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n]; 
            for (int i = 0; i < n; i++) 
            {
                int area = Convert.ToInt32(Console.ReadLine());
                arr[i] = area;
            }

            int maxEatAres = 0;
            int[] newArr;
            for (int i = 0; i < n; i++) 
            {
                int eatArea = arr[i];
                if (i == 0)  //第一块
                {
                    newArr = arr.Skip(1).Take(n-1).ToArray();
                }
                else if (i == n - 1)  //先拿最后一块
                {
                    newArr = arr.Take(n - 1).ToArray();
                }
                else  //拿中间的第i块
                {
                    int[] leftArr = arr.Take(i).ToArray();
                    int[] rightArr = arr.Skip(i + 1).Take(n - i).ToArray();
                    newArr = leftArr.Concat(rightArr).ToArray();
                }
                eatArea += GetPizza(newArr);
                Console.WriteLine($"{i}, area:{eatArea}");
                maxEatAres = Math.Max(maxEatAres, eatArea);
            }

            Console.WriteLine(maxEatAres);
        }

        public static int GetPizza(int[] arr) 
        {
            int eatAres = 0;
            if (arr.Length <= 1)  // 偶数，一次取两个，不可能出现1.
            {
                return 0;
            }

            if (arr.Length == 2)
            {
                return Math.Min(arr[0], arr[1]);
            }

            int[] newArr;
            if (arr[0] > arr[arr.Length -1])  // 第一个比最后一个大， "馋嘴"拿最大的，剩下的"吃货"拿
            {
                newArr = arr.Skip(1).Take(arr.Length-1).ToArray();
            }
            else 
            {
                newArr = arr.Take(arr.Length - 1).ToArray();
            }

            int[] nextArr;
            if (newArr[0] > newArr[newArr.Length - 1])  // 第一个比最后一个大， "吃货"拿最大的
            {
                eatAres = newArr[0];
                nextArr = newArr.Skip(1).Take(newArr.Length - 1).ToArray();
            }
            else 
            {
                eatAres = newArr[newArr.Length - 1];
                nextArr = newArr.Take(newArr.Length - 1).ToArray();
            }

            eatAres += GetPizza(nextArr);
            return eatAres;
        }

        //吃披萨，动态规划
        public static int[] pizzaArr;

        public static int[,] dp;
        public static void PizzaByDynamicPlan() 
        {
            var n = Convert.ToInt32(Console.ReadLine());
            pizzaArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int area = Convert.ToInt32(Console.ReadLine());
                pizzaArr[i] = area;
            }

            int maxEat = 0;

            dp = new int[n,n];

            for (int i = 0; i < n; i++) 
            {
                maxEat = Math.Max(maxEat, pizzaArr[i] + GetPizzaByDP(i+1, i-1 +n, n));
            }

            Console.WriteLine(maxEat);
        }

        public static int GetPizzaByDP(int x, int y, int n) 
        {
            x = (x + n) % n;
            y = (y+n) % n;
            if (pizzaArr[x] > pizzaArr[y])
            {
                x = (x + 1) % n;
            }
            else 
            {
                y = (y - 1 + n)%n;
            }

            if (dp[x, y] != 0) 
            {
                return dp[x, y];
            }

            if (x == y) 
            {
                return pizzaArr[x];
            }

            dp[x,y] = Math.Max(pizzaArr[x] + GetPizzaByDP(x+1, y, n), pizzaArr[y] + GetPizzaByDP(x,y-1,n));
            return dp[x, y];
        
        }

        // 4转盘寿司
        public static void ZhuanPanShouSi() 
        {
            var line = Console.ReadLine();
            List<int> arr = new List<int>();
            string[] lines = line.Split(" ");
            List<int> result = new List<int>();
            //bool isFind = false;
            for (int i = 0; i < lines.Length; i++) 
            {
                arr.Add(Convert.ToInt32(lines[i]));
            }

            for (int i = 0; i < arr.Count; i++) 
            {
                bool isFind = false;
                for (int j = i + 1; j <= arr.Count - 1; j++)   // 从i后面找
                {
                    if ( arr[j] < arr[i]) 
                    {
                        result.Add(arr[j] + arr[i]);
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)   // 在i下标之前的数组中找
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] < arr[i])
                        {
                            result.Add(arr[j] + arr[i]);
                            isFind = true;
                            break;
                        }
                    }
                }

                if (!isFind)  // 没有找到
                {
                    result.Add((int)arr[i]);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }

        // 5身高体重 排序
        public static void SortedByHeightAndWeight() 
        {
            int studentCount = Convert.ToInt32(Console.ReadLine());
            var heightContent = Console.ReadLine();
            var weightContent = Console.ReadLine();

            var heightArr = heightContent.Split(" ");
            var weightArr = weightContent.Split(" ");
            List<int> orderIndexs = new List<int>();
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentCount; i++) 
            {
                students.Add(new Student(i+1, Convert.ToInt32(heightArr[i]), Convert.ToInt32(weightArr[i])));
            }

            Array.Sort(students.ToArray(), (a, b) => a.Weight > b.Weight ? 1: 0);

            students = students.OrderBy(i => i.Height).ThenBy(i => i.Weight).ThenBy(i => i.Index).ToList();
            for (int i = 0; i < students.Count; i++) 
            {
                var item = students[i];
                orderIndexs.Add(item.Index);
            }

            Console.WriteLine(string.Join(" ", orderIndexs));
        }

        public class Student 
        {
            public Student(int index, int height, int weight) 
            {
                this.Index = index;
                this.Height = height;
                this.Weight = weight;
            
            }
            public int Index { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
        }

        //6. 山峰有几个

        public static void GetPeakCount() 
        {
            string line  = Console.ReadLine();
            List<int> lineList = JsonSerializer.Deserialize<List<int>>(line);

            List<int> peakList = new List<int>();
            int peakCount = 0; //山峰的数量
            if (lineList.Count() < 2) 
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < lineList.Count(); i++) 
            {
                if (i == 0)  //第一个
                {
                    if (lineList[0] > lineList[1]) 
                    {
                        peakList.Add(i);
                        peakCount++;
                    }
                }
                else if( i == line.Count() - 1)  // 最后一个
                {
                    if (lineList[line.Count() - 2] < lineList[line.Count() - 1])
                    {
                        peakCount++;
                        peakList.Add(i);
                    }
                }
                else  //中间的山峰
                {
                    if (lineList[i] > lineList[i - 1] && lineList[i] > lineList[i + 1]) //一定是山峰
                    {
                        peakCount++;
                        peakList.Add(i);
                    }
                    else if((lineList[i] == lineList[i - 1] && lineList[i] > lineList[i + 1]) || (lineList[i] > lineList[i - 1] && lineList[i] == lineList[i + 1]))
                    {
                        peakCount++;
                        peakList.Add(i);
                    }
                }
            }

            Console.WriteLine(peakCount);
            Console.WriteLine(string.Join(" ", peakList));

        }

        //7 完成多少任务
        public static void CompleteMaxTasks() 
        {
            var processAbility = Convert.ToInt32(Console.ReadLine()); //每秒处理能力
            var arrLength = Convert.ToInt32(Console.ReadLine());      //数组长度
            var taskListString = Console.ReadLine();
            List<int> taskList = new List<int>();
            taskListString.Split(" ").ToList().ForEach(i => taskList.Add(Convert.ToInt32(i)));
            int processSeconds = 0;

            int lastSecondNotProcessTaskCount = 0;  //上一秒没有处理完的task； 
            for (int i = 0; i < taskList.Count(); i++) 
            {
                int taskCount = taskList[i] + lastSecondNotProcessTaskCount;
                if (taskCount <= processAbility)  //1秒处理不完，留到下一秒处理
                {
                    lastSecondNotProcessTaskCount = 0;
                }
                else 
                {
                    lastSecondNotProcessTaskCount = Math.Max(0, taskCount - processAbility);
                }
            }

            if (lastSecondNotProcessTaskCount == 0)
            {
                processSeconds = taskList.Count();
            }
            else 
            {
                int addSeconds = lastSecondNotProcessTaskCount / processAbility;
                if (lastSecondNotProcessTaskCount % processAbility != 0) 
                {
                    addSeconds++;
                }

                processSeconds = taskList.Count() + addSeconds;
            }

            Console.WriteLine(processSeconds);
        }

        //8. 压缩存储，只保留转折节点
        public static void CompressSaveNode() 
        {
            var line  = Console.ReadLine();
            List<PonitContent> pointList = new List<PonitContent>();
            List<string> list = line.Split(" ").ToList();
            for (int i = 0; i < list.Count(); i =i+2) 
            {
               int y = Convert.ToInt32(list[i]);
               int x = Convert.ToInt32(list[i+1]);
               pointList.Add(new PonitContent(x, y));
            }

            if (pointList.Count() <= 2) 
            {
                LogPoint(pointList);
                return;
            }

            List<PonitContent> removePoints = new List<PonitContent>();
            for (int i = 0; i < pointList.Count(); i++) 
            {
                if (i == 0 || i == pointList.Count() - 1) //第一个节点和最后一个保留
                {
                    continue;
                } 
                else 
                {
                    var beforePoint = pointList[i - 1];
                    var currentPoint = pointList[i];
                    var afterPoint = pointList[i + 1];

                    var spnBeforeX = currentPoint.X - beforePoint.X;
                    var spnBeforeY = currentPoint.Y - beforePoint.Y;

                    var spnAfterX = afterPoint.X - currentPoint.X;
                    var spnAfertY = afterPoint.Y - currentPoint.Y;

                    if (spnBeforeX == spnAfterX && spnBeforeY== spnAfertY) 
                    {
                        removePoints.Add(currentPoint);
                    }
                }
            }

            if (removePoints.Count() > 0) 
            {
                foreach (var point in removePoints) 
                {
                    pointList.Remove(point);
                }
            }

            LogPoint(pointList);
        }

        public static void LogPoint(List<PonitContent> points) 
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < points.Count(); i++) 
            {
                var point = points[i];
                sb.Append($"{point.Y} {point.X} ");
            }

            Console.WriteLine(sb.ToString());
        }

        // 9. 手头剪刀布(200分的题)
        public static void ShitouJiandaoBu() 
        {
            List<string[]> inputs = new List<string[]>();
            string line;
            while ((line = Console.ReadLine()) != null) 
            {
                if (line =="" || line == null) 
                {
                    break;
                }
                var lines = line.Split(" ");
                inputs.Add(new string[] { lines[0], lines[1]});
            }

            List<string> aPerson = new List<string>();
            List<string> bPerson = new List<string>();
            List<string> cPerson = new List<string>();
            for (int i = 0; i < inputs.Count; i++) 
            {
                var person = inputs[i];
                if (person[1] == "A")
                {
                    aPerson.Add(person[0]);

                } else if (person[1] == "B")
                {
                    bPerson.Add(person[0]);
                } 
                else if (person[1] == "C") 
                {
                    cPerson.Add(person[0]);
                }
            }

            bool hasA = aPerson.Count > 0;
            bool hasB = bPerson.Count > 0;
            bool hasC = cPerson.Count > 0;

            if (hasA && hasB && hasC)  // A B C都有
            {
                Console.WriteLine("NULL");
            } 
            else if ((hasA && !hasB &&!hasC) || (!hasA && hasB && !hasC) || (!hasA && !hasB && hasC))  //只有 A B C中的一个
            {
                Console.WriteLine("NULL");
            } 
            else if (hasA && hasB && !hasC)  // A赢
            {
                LogSuccessPerson(aPerson);
            }
            else if (!hasA && hasB && hasC)  // B赢
            {
                LogSuccessPerson(bPerson);
            }
            else if (hasA && !hasB && hasC)  // C赢
            {
                LogSuccessPerson(cPerson);
            }
        }

        /// <summary>
        /// 打印赢的人
        /// </summary>
        /// <param name="persons"></param>
        public static void LogSuccessPerson(List<string> persons) 
        {
            foreach (string person in persons) 
            {
                Console.WriteLine(person);
            }
        }

        // 10.CPU算力
        public static void CPUSwitch() 
        {
            //1. 输入A和B两组CPU的数量
            var arrDivs = Console.ReadLine();
            var aCount = Convert.ToInt32(arrDivs.Split(" ")[0]);
            var bCount = Convert.ToInt32(arrDivs.Split(" ")[1]);

            int[] aGroup = new int[aCount];
            int[] bGroup = new int[bCount];
            // 录入A的算力
            var aLine = Console.ReadLine();
            string[] aLineArr = aLine.Split(" ");
            for (int i = 0; i < aLineArr.Length; i++) 
            {
                aGroup[i] = Convert.ToInt32(aLineArr[i]);
            }

            var bLine = Console.ReadLine();
            var bLineArr = bLine.Split(" ");
            for (int i = 0; i < bLineArr.Length; i++) 
            {
                bGroup[i] = Convert.ToInt32(bLineArr[i]);
            }

            //2. 计算两组算力的差值
            int aSum = 0;
            int bSum = 0;
            for (int i = 0; i < aGroup.Length; i++) 
            {
                aSum += aGroup[i];
            }

            for (int i = 0; i < bGroup.Length; i++)
            {
                bSum += bGroup[i];
            }

            int diff = (aSum - bSum)/2; //算力总差值

            // 3寻找需要交换的CPU
            bool isExchanged = false;
            int aCPU = 0;
            int bCPU = 0;
            var sortedAGroup = aGroup.OrderBy(i => i).ToArray();
            Array.Sort(bGroup);
            for (int i = 0; i < aGroup.Length; i++) 
            {
                aCPU = sortedAGroup[i];
                int target = aCPU - diff;
                if (Array.BinarySearch(bGroup, target) >=0)  //直接二分查找， b要先排序。 这样就不用循环查找了
                {
                    bCPU = target;
                    break;
                }
            }
            Console.WriteLine($"{aCPU} {bCPU}");
        }

        // 11内存冷热标记
        public static void HotColdFlag() 
        {
            int arrCount = Convert.ToInt32(Console.ReadLine());
            string[] receiveFlags = Console.ReadLine().Split(" ");
            int max = Convert.ToInt32(Console.ReadLine());         //阈值

            int[] receivePageArr = new int[arrCount];
            for (int i = 0; i < receiveFlags.Length; i++) 
            {
                receivePageArr[i] = int.Parse(receiveFlags[i]);
            }


            Dictionary<int, int> requestLogDic = new Dictionary<int, int>();
            for (int i = 0; i < receivePageArr.Length; i++) 
            {
                int pageNo = receivePageArr[i];
                if (requestLogDic.ContainsKey(pageNo))
                {
                    requestLogDic[pageNo] += 1;
                }
                else 
                {
                    requestLogDic.Add(pageNo, 1);
                }
            }

            List<int> requestLagerThanMaxPages = new List<int>();
            foreach (var item in requestLogDic) 
            {
                if (item.Value >= max) 
                {
                    requestLagerThanMaxPages.Add(item.Key);
                }
            }

            if (requestLagerThanMaxPages.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            requestLagerThanMaxPages = requestLagerThanMaxPages.Order().ToList();
            for (int i = 0; i < requestLagerThanMaxPages.Count(); i++ )
            {
                Console.WriteLine(requestLagerThanMaxPages[i]);
            }
        }

        /// <summary>
        /// 获取最大和最小数量的乘积
        /// </summary>
        public static void GetMaxAndMinSum() 
        {
            string line = Console.ReadLine();
            string arrContent = Console.ReadLine();
            int m = int.Parse(Console.ReadLine());

            string[] arrString = arrContent.Split(" ");
            int[] arr = new int[arrString.Length];
            for (int i = 0; i < arrString.Length; i++) 
            {
                arr[i] = int.Parse(arrString[i]);
            }
            List<int> lists = arr.ToList();
            lists = lists.Distinct().Order().ToList();

            if (lists.Count < 2*m) 
            {
                Console.WriteLine(-1);
                return;
            }

            int minSum = lists.Take(m).ToList().Sum(i => i); 

            int maxSum = lists.Skip(lists.Count - m).Take(m).Sum(i => i);

            Console.WriteLine(minSum + maxSum);
        }

        /// <summary>
        /// 路线轨迹
        /// </summary>
        public static void GetRoadPoint() 
        {
            string line = Console.ReadLine();
            string[] lineArr = line.Split(" ");
            int w = int.Parse(lineArr[0]);
            int h = int.Parse(lineArr[1]);
            int x = int.Parse(lineArr[2]);
            int y = int.Parse(lineArr[3]);
            int sx = int.Parse(lineArr[4]);
            int sy = int.Parse(lineArr[5]);
            int t = int.Parse(lineArr[6]);

            int[,] mapArr = new int[h,w];
            string linePoints = string.Empty;
            int lineCount = 0;
            while (lineCount < h) 
            {
                if (string.IsNullOrEmpty(linePoints)) 
                {
                    break;
                }

                for (int i = 0; i < linePoints.Length; i++) 
                {
                    mapArr[lineCount,i]= int.Parse(linePoints[i].ToString());
                }

                lineCount++;
            }

            int sumCount = 0;
            if (mapArr[y, x] == 1)  //初始点是不是1
            {
                sumCount++;
            }

            for (int i = 0; i < t; i++) 
            {
                // 走到下一秒的位置
                x = x + sx;
                y = y + sy;
                Console.WriteLine($"第{i+1}秒，x:{x}, y:{y},值：{mapArr[y, x]}，sumCount:{sumCount + 1}");
                if (mapArr[y,x] == 1) 
                {
                    sumCount++;
                }

                // 判断边界， x速度反转， y速度反转
                // 1. x速度反转
                if ( x ==0 && sx < 0 || x == w-1 && sx > 0) 
                {
                    sx = -sx;
                }

                // 2. y速度反转
                if (y == 0 && sy < 0 || y == h-1 && sy > 0) 
                {
                    sy = -sy;
                }
            }

            Console.WriteLine(sumCount);
        }

        // 空格走位
        public static void FangGeZi() 
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(" ");
            int n = Convert.ToInt32(inputArr[0]);  // n为横向格子的数量
            int m = Convert.ToInt32(inputArr[1]);  // m为竖向格子的数量

            int totalRoads = GetRoads(n, m);
            Console.WriteLine($"total:{totalRoads}");
        }

        public static int GetRoads(int x, int y) 
        {
            Console.WriteLine($"x:{x},y:{y}");
            if (x ==0) 
            {
                return 1;
            }

            if (y == 0) 
            {
                return 1;
            }

            return GetRoads(x-1, y) + GetRoads(x, y-1);
        }

        //蛇型矩阵
        public static void SnakeTable() 
        {
            int d = int.Parse(Console.ReadLine());
            int[,] arr = new int[d,d];

            int num = 0;
            // 输入
            for (int i = 0; i < d; i++) 
            {
                for (int j = 0; j < i; j++) 
                {
                    num++;
                    arr[i - j, j] = num;
                }
            }

            List<int> numberList = new List<int>();
            // 输出
            for (int i = 0; i < d; i++) 
            {
                for (int j = 0; j < d; j++) 
                {
                    if (arr[i, j] == 0)
                    {
                        Console.WriteLine(string.Join(" ", numberList));
                        numberList.Clear();
                        break;
                    }
                    else 
                    {
                        numberList.Add(arr[i, j]);
                    }
                }
            }

        }

        // 滑动窗口
        public static void SlideWindow() 
        {
            int musicLength = int.Parse(Console.ReadLine());  // 歌曲列表长度
            string cmds = Console.ReadLine();                 // 命令

            ProcessCommond(cmds, musicLength);
        }

        /// <summary>
        /// 处理命令行
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="l"></param>
        public static void ProcessCommond(string cmds, int length) 
        {
            int endIndext = Math.Min(length, 4);
            int startIndex = 1;

            int cuorIndex = 1; //光标位置
            for (int i = 0; i < cmds.Length; i++) 
            {
                string cmd = cmds[i].ToString();
                if (cmd == "U")
                {
                    cuorIndex = (cuorIndex - 1 + length - 1) % length + 1;

                }
                else if (cmd == "D") 
                {
                    cuorIndex = cuorIndex % length + 1;
                }

                if ( cuorIndex < startIndex) 
                {
                    startIndex = cuorIndex;
                    endIndext = startIndex + 3;
                }

                if (cuorIndex> endIndext) 
                {
                    startIndex = cuorIndex - 3;
                    endIndext = cuorIndex;
                }
            }

            List<int> musicIndex = new List<int>();
            for (int i = startIndex; i <= endIndext; i++) 
            {
                musicIndex.Add(i);
            }

            Console.WriteLine(string.Join(" ", musicIndex));
            Console.WriteLine(cuorIndex);
        }

        //动态规划,最长递增字符串个数  递归+递归结论缓存,已经算过的缓存下来，不用重复计算
        public static void GetLongestIncreArr() 
        {
            int num = int.Parse(Console.ReadLine());
            string arrStringContent = Console.ReadLine();
            string[] arrString = arrStringContent.Split(" ");
            int[] arr = new int[arrString.Length];
            for (int i = 0; i < arrString.Length; i++) 
            {
                arr[i] = int.Parse(arrString[i]);
            }
            // 准备数据
            int[] dp = new int[arrString.Length];
            for (int i = 0; i < arrString.Length; i++) 
            {
                dp[i] = 1;
            }

            // 
            for(int i = 0; i < arrString.Length; i++) 
            {
                for (int j = 0; j < i; j++) 
                {
                    if (arr[i] > arr[j]) 
                    {
                        dp[i] = Math.Max(dp[i], dp[j] +1 );
                    }
                }
            }

            int max = dp.ToList().Max();
            Console.WriteLine(max);
        }

        // 迷宫路径 广度优先bfs 深度优先dfs
        public static void MiGong() 
        {
            string arrWeightAndHeight = Console.ReadLine();
            int h = int.Parse(arrWeightAndHeight.Split(" ")[0]);
            int w = int.Parse(arrWeightAndHeight.Split(" ")[1]);
            int[,] arr = new int[h,w];

            for (int i = 0; i< h; i++) 
            {
                string points = Console.ReadLine();
                string[] arrPoints = points.Split(" ");
                for (int j = 0; j < arrPoints.Length; j++) 
                {
                    arr[i, j] = int.Parse(arrPoints[j]);
                }
            }

            List<Point> paths = new List<Point>();
            FindRoadPoint(0, 0, arr, paths);

            for (int i = 0; i < paths.Count; i++) 
            {
                var p = paths[i];
                Console.WriteLine($"({p.X},{p.Y})");
            }
        }

        public static bool FindRoadPoint(int x, int y, int[,] arr, List<Point> paths) 
        {
            var newPoint = new Point(x, y);
            paths.Add(newPoint);
            arr[x, y] = 1;
            int h = arr.GetLength(0);
            int w = arr.GetLength(1);

            if ( x == w -1 && y == h -1 ) 
            {
                return true;
            }

            // 1.上
            if ( x > 0 && arr[x-1, y] == 0) 
            {
                if (FindRoadPoint(x - 1, y, arr, paths)) 
                {
                    return true;
                };
            }

            // 2.下
            if (x < h-1 && arr[x + 1, y] == 0)
            {
                if (FindRoadPoint(x + 1, y, arr, paths)) 
                {
                    return true;
                };
            }

            // 3.左
            if (y > 0 && arr[x, y-1] == 0)
            {
                if (FindRoadPoint(x, y - 1, arr, paths)) 
                {
                    return true;
                };
            }


            // 4.右
            if (y < w-1 && arr[x, y + 1] == 0)
            {
                if (FindRoadPoint(x, y + 1, arr, paths)) 
                {
                    return true;
                };
            }

            paths.RemoveAt(paths.Count - 1);
            arr[x,y] = 0;
            return false;
        }


        public class Point 
        {
            public Point(int x, int y) 
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

    }

    public class PonitContent
    {
        public PonitContent()
        {

        }

        public PonitContent(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

    }
}
