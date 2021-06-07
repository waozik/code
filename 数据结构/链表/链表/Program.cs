using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linked = new LinkedList<string>();
            linked.Add("111");
            linked.Add("2222");
            string a = linked[1];
            int index2 = linked.Find("2222");
            linked.Delete(index2);
            foreach(var t in linked)
            {
                Console.WriteLine(t);
            }
            

        }
    }
}
