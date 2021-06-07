using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表
{
    public class Node<T> where T : class
    {
        public Node()
        {
        }
        public Node(T t)
        {
            this.t = t;
        }

        /// <summary>
        /// 存储下一个节点
        /// </summary>
        public Node<T> nextNode { get; set; }
        /// <summary>
        /// 存储的数据
        /// </summary>
        public T t { get; set; }
    }
}
