using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AlgorithmDemo.RateLimit
{
    public class SlidingWindowRateLimit
    {
        private Queue<DateTime> RequestQueue = new Queue<DateTime>();
        private int requestCount = 0;  // 计数器，记录当前时间段内的请求次数
        private int limitCount = 0;    // 限制的次数
        private int windowSize = 0;    // 窗口大小,毫秒
        private readonly TimeSpan _windowSize;

        public SlidingWindowRateLimit(int limitSize, int windowSize) 
        {
            this.limitCount = limitSize;
            this.windowSize = windowSize;
        }

        public SlidingWindowRateLimit(int limitSize, TimeSpan windowSize)
        {
            this.limitCount = limitSize;
            this._windowSize = windowSize;
        }

        #region 主动检查队列
        public bool IsLimit() 
        {
            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            for (int i = 0; i < 50; i++) 
            {
                Thread.Sleep(120-(i%10)*2);
                CheckRequest();
            }
            return true;
        }

        public bool CheckRequest()
        {
            DateTime now = DateTime.Now;
            RequestQueue.Enqueue(now);  // 将当前时间加入队列
            requestCount++;  // 更新计数器
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}:请求次数：" + requestCount);
            
            return true;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            while (RequestQueue.Count > 0 && (now - RequestQueue.Peek()).TotalMilliseconds >= windowSize)
            {
                RequestQueue.Dequeue();
                requestCount--;
            }  // 清空队列和计数器
            if (requestCount > limitCount)  // 判断当前时间段内的请求次数是否超过限制
            {
                Console.WriteLine($"请求超过限制,窗口内请求{RequestQueue.Count}次");
            }

            Console.WriteLine($"没有触发限流,窗口内请求{RequestQueue.Count}次 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")},");
        }
        #endregion

        #region 被动清空队列

        public bool IsAllow() 
        {
            DateTime now = DateTime.Now;
            
            while (RequestQueue.Count > 0 && now - RequestQueue.Peek() >= _windowSize)
            {
                RequestQueue.Dequeue();
            }  // 清空队列和计数器

            if (RequestQueue.Count > limitCount)  // 判断当前时间段内的请求次数是否超过限制
            {
                Console.WriteLine($"请求超过限制,窗口内请求{RequestQueue.Count}次");
                return false;
            }

            RequestQueue.Enqueue(now);
            Console.WriteLine($"没有触发限流,窗口内请求{RequestQueue.Count}次 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")},");
            return true;
        }

        #endregion

    }


}

