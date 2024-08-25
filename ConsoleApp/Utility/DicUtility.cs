using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    public class DicUtility
    {
        public static void  SortedDic() 
        {
            int loop = Convert.ToInt32(Console.ReadLine()); 
            var dic = new SortedDictionary<int, int>();
            for (int i = 0; i < loop; i++)
            {
                string inputs = Console.ReadLine();
                List<string> inputArr = inputs.Split(" ").ToList();

                int key  = Convert.ToInt32(inputArr[0]);
                int v = Convert.ToInt32(inputArr[1]);
                if (dic.ContainsKey(key))
                {
                    dic[key] += v;
                }
                else 
                {
                    dic.Add(key, v);
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        //防沉迷
        public static void GetAppTimeSpan() 
        {
            int appCount = Convert.ToInt32(Console.ReadLine());
            List<App> apps = new List<App>();
            for (int i = 0; i < appCount; i++) 
            {
                string appContent = Console.ReadLine();
                string[] appArr = appContent.Split(" ");
                App app = new App(appArr[0], int.Parse(appArr[1]), appArr[2], appArr[3]);
                AddApp(apps, app);
            }

            string dateTime = Console.ReadLine();
            HandleTime(apps, dateTime);
        }

        public static void AddApp(List<App> apps, App app) 
        {
            if (apps.Count() == 0) 
            {
                apps.Add(app);
                return;
            }

            int failCount = 0;
            List<App> needRemoveApps = new List<App>();  //需要移除的时间范围
            for (int i = 0; i < apps.Count(); i++) 
            {
                var currentApp = apps[i];
                if (IsTimeOver(currentApp, app)) 
                {
                    if (currentApp.Priority >= app.Priority)
                    {
                        failCount++;
                        break;
                    }
                    else 
                    {
                        needRemoveApps.Add(currentApp);
                    }
                }
            }

            if (failCount == 0)
            {
                apps.Add(app);
            }

            if (needRemoveApps.Count() > 0) 
            {
                foreach (var item in needRemoveApps) 
                {
                    apps.Remove(item);
                }
            }
        }

        /// <summary>
        /// 是否时间重叠
        /// </summary>
        /// <param name="currentApp"></param>
        /// <param name="addedApp"></param>
        /// <returns></returns>
        public static bool  IsTimeOver(App currentApp, App addedApp) 
        {
            TimeSpanContent currentTimeSpan = currentApp.TimeSpan;
            TimeSpanContent addedTimeSpan = addedApp.TimeSpan;

            if (currentTimeSpan.End < addedTimeSpan.Start || currentTimeSpan.Start > addedTimeSpan.End) 
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断是否命中防沉迷
        /// </summary>
        /// <param name="apps"></param>
        /// <param name="time"></param>
        public static void HandleTime(List<App> apps, string time) 
        {
            DateTime dateTime = GetDateFormat(time);
            bool isSuccess = false;
            foreach (var app in apps) 
            {
                if (app.TimeSpan.Start <= dateTime && app.TimeSpan.End >= dateTime) 
                {
                    isSuccess = true;
                    Console.WriteLine(app.Name);
                    break;
                }
            }

            if (!isSuccess) 
            {
                Console.WriteLine("NA");
            }
        }

        public class App 
        {
            public App(string name, int priority, string start, string end) 
            {
                this.Name = name;
                this.Priority = priority;

                this.TimeSpan = new TimeSpanContent(start, end);

            }

            public string Name { get; set; }

            public int Priority { get; set; }

            public TimeSpanContent TimeSpan { get; set; }
        }

        public class TimeSpanContent
        {
            public TimeSpanContent(string start, string end) 
            {
                this.StartTimeString = start;
                this.EndTimeString = end;
            }

            public string StartTimeString { get; set; }
            public string EndTimeString { get; set; }
            public DateTime Start 
            {
                get 
                {
                    return GetDateFormat(StartTimeString);
                }
            }

            public DateTime End
            {
                get
                {
                    return GetDateFormat(EndTimeString);
                }
            }
        }

        public static DateTime GetDateFormat(string dateTime) 
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            string fullTime = $"{date} {dateTime}:00";
            return DateTime.Parse(fullTime);
        }

    }
}
