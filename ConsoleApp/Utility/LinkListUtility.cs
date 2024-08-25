using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    public class LinkListUtility
    {
        // 链表
        public static void GetDefindeNode() 
        {
            LinkedList<int> linkList = new LinkedList<int>();
            int count = Convert.ToInt32(Console.ReadLine());
            string line = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine());
            var lineArr = line.Split(" ");
            for (int i = 0; i < count; i++) 
            {
                int num = int.Parse(lineArr[i]);
                linkList.AddLast(num);
            }

            int first = Convert.ToInt32(lineArr[0]);

            int itemIndex = (int)linkList.LongCount() - k;
            LinkedListNode<int> node = linkList.Find(first);
            for (int i = 1; i <= itemIndex; i++) 
            {
                node = node.Next;
            }

            Console.WriteLine(node.Value);
        }
    }
}
