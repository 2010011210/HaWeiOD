using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    internal class DataStructure
    {
        public static void DataStruct() 
        {
            #region 数组

            Console.WriteLine("************* 数组 ***************");
            // 数组都是连续摆放的
            int[] intArray = new int[3];
            intArray[0] = 123;

            string[] stringArr = new string[] { "first", "second" };

            Console.WriteLine("************* ArrayList ***************");
            // 底层也是一个数组 new object[];
            /*
                // Constructs a ArrayList with a given initial capacity. The list is
                // initially empty, but will have room for the given number of elements
                // before any reallocations are required.
                //
                public ArrayList(int capacity)
                {
                    if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), SR.Format(SR.ArgumentOutOfRange_MustBeNonNegNum, nameof(capacity)));
 
                    if (capacity == 0)
                        _items = Array.Empty<object>();
                    else
                        _items = new object[capacity];
                }
             */
            ArrayList arrList = new ArrayList();
            arrList.Add(123);
            arrList.Add(456);
            arrList.Add("ocelot");
            arrList.Add("ocelot");
            arrList.Add(new int[] { 89 });

            var index = arrList.IndexOf("ocelot");  // index = 2
            arrList.Remove("ocelot"); // 移除第一个匹配的

            /*
                // Removes the element at the given index. The size of the list is
                // decreased by one.
                //
                public virtual void Remove(object? obj)
                {
                    int index = IndexOf(obj);
                    if (index >= 0)
                        RemoveAt(index);
                }
 
                // Removes the element at the given index. The size of the list is
                // decreased by one.
                //
                public virtual void RemoveAt(int index)
                {
                    if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException(nameof(index), SR.ArgumentOutOfRange_IndexMustBeLess);
 
                    _size--;
                    if (index < _size)
                    {
                        Array.Copy(_items, index + 1, _items, index, _size - index);
                    }
                    _items[_size] = null;
                    _version++;
                }
             */

            arrList.RemoveAt(1);

            Console.WriteLine("************* List<T> ***************");
            List<int> intList = new List<int> { 123 };
            intList.Add(456);

            #endregion

            #region 链表
            Console.WriteLine("************* LinkList ***************");
            LinkedList<int> linkList = new LinkedList<int>();
            linkList.AddFirst(123);
            linkList.AddFirst(1234);
            linkList.AddLast(789);

            bool isContains = linkList.Contains(123);
            LinkedListNode<int> node = linkList.Find(123);
            int v = node.Value;
            v = node.Next.Value;      // node的下一个value
            v = node.Previous.Value;  // node的上一个value

            linkList.AddAfter(node, 9);
            linkList.AddBefore(node, 1);
            /*
             * private void InternalInsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
                {
                    newNode.next = node;
                    newNode.prev = node.prev;
                    node.prev!.next = newNode;
                    node.prev = newNode;
                    version++;
                    count++;
                }
             */

            linkList.Remove(9);
            linkList.Remove(node);
            linkList.RemoveFirst();
            linkList.RemoveLast();

            Console.WriteLine("************* Queue ***************");
            // 底层是数组，但是不实现IList<T>接口，不能使用下标 [index]
            /*
                // Creates a queue with room for capacity objects. The default initial
                // capacity and grow factor are used.
                public Queue()
                {
                    _array = Array.Empty<T>();
                }
 
                // Creates a queue with room for capacity objects. The default grow factor
                // is used.
                public Queue(int capacity)
                {
                    ArgumentOutOfRangeException.ThrowIfNegative(capacity);
                    _array = new T[capacity];
                }
             */
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("one1");
            queue.Enqueue("one2");
            queue.Enqueue("one3");
            queue.Enqueue("one4");
            queue.Enqueue("one5");
            /*
             * Increments the index wrapping it if necessary.
                private void MoveNext(ref int index)
                {
                    // It is tempting to use the remainder operator here but it is actually much slower
                    // than a simple comparison and a rarely taken branch.
                    // JIT produces better code than with ternary operator ?:
                    int tmp = index + 1;
                    if (tmp == _array.Length)
                    {
                        tmp = 0;
                    }
                    index = tmp;
                }
             */

            foreach (var item in queue)
            {
                Console.WriteLine($"{item}\n");
            }

            var firstQueue = queue.Peek();
            var queueNode = queue.Dequeue();
            queueNode = queue.Dequeue();

            Console.WriteLine("************* stack ***************");
            // 底层是对数组的封装，但是不能使用下表获取元素

            Stack<string> stack = new Stack<string>();
            stack.Push("one");
            stack.Push("one1");
            stack.Push("one2");
            stack.Push("one3");
            stack.Push("one4");
            stack.Push("one5");
            /*
             // Pushes an item to the top of the stack.
                public void Push(T item)
                {
                    int size = _size;
                    T[] array = _array;
 
                    if ((uint)size < (uint)array.Length)
                    {
                        array[size] = item;
                        _version++;
                        _size = size + 1;
                    }
                    else
                    {
                        PushWithResize(item);
                    }
                }
             */

            foreach (var item in stack)
            {
                Console.WriteLine($"{item}\n");
            }

            var stackItem = stack.Peek(); // 只返回，不移除
            stackItem = stack.Pop();
            stackItem = stack.Pop();
            stack.Clear();

            #endregion

            #region HashSet
            Console.WriteLine("************* HashSet ***************");
            // 用于去重
            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("dog");
            hashSet.Add("cat");
            hashSet.Add("fish");
            hashSet.Add("cat");  // 有重复，不会添加
            foreach (var item in hashSet)
            {
                Console.WriteLine($"{item}\n");
            }

            HashSet<string> hashSet2 = new HashSet<string>();
            hashSet2.Add("tiger");
            hashSet2.Add("bird");
            hashSet2.Add("dog");

            //hashSet.UnionWith(hashSet2);  //并
            //hashSet.ExceptWith(hashSet2); //差
            //hashSet.SymmetricExceptWith(hashSet2); //补。共有的去除
            hashSet.IntersectWith(hashSet2);  //交集


            Console.WriteLine("************* SortedSet ***************");
            SortedSet<string> sortedSet = new SortedSet<string>();    // 带排序的Set
            sortedSet.Add("123");
            sortedSet.Add("345");
            sortedSet.Add("234");
            sortedSet.Add("87698");
            sortedSet.Add("87698");
            sortedSet.Add("87698");

            #endregion

            Console.WriteLine("************* HashTable ***************");

            Hashtable hashtable = new Hashtable();
            hashtable.Add("123", "dog");
            hashtable[345] = "cat";
            hashtable[123] = "tiger";  // 不会覆盖“123”，因为这是数字

            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"Hashtable：{item.Key.ToString()},{item.Value!.ToString()}");
            }

            Console.WriteLine("************* Dictionary ***************");
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "dog");
            dic.Add(3, "cat");
            dic.Add(2, "panda");
            //dic.Add(1,"123d"); //会报错，key值不能重复
            foreach (var item in dic)
            {
                Console.WriteLine($"Dictionary：{item.Key.ToString()},{item.Value!.ToString()}");
            }

            Console.WriteLine("************* SortDictionary ***************");
            SortedDictionary<int, string> dic2 = new SortedDictionary<int, string>();
            dic2.Add(1, "dog");
            dic2.Add(3, "cat");
            dic2.Add(2, "panda");
            //dic2.Add(1, "123d"); //会报错，key值不能重复
            foreach (var item in dic2)
            {
                Console.WriteLine($"SortedDictionary：{item.Key.ToString()},{item.Value!.ToString()}");

            }
        }
    }
}
