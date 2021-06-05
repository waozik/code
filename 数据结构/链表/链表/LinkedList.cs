using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表
{
    public class LinkedList<T> where T : class
    {
        private Node<T> linkedList = new Node<T>();
        public LinkedList<T> MakeEmpty()
        {
            linkedList = new Node<T>();
            return this;
        }

        public void Add(T t)
        {
            //如果列表为空
            if (linkedList.t == null)
            {
                this.linkedList.t = t;

            }
            else
            {
                Node<T> node = new Node<T>(t);
                this.linkedList.nextNode = node;
            }
        }
        public int Find(T t)
        {
            Node<T> node = this.linkedList;
            int i = 1;
            while (node.t != t && node.nextNode != null)
            {
                node = node.nextNode;
                i++;
            }
            if (node.t == t)
            {
                return i;
            }
            else
                return -1;
        }

        public int Insert(int index, T t)
        {
            if (index <= 0)
                throw (new ArgumentException("参数index不能小于等于0"));
            Node<T> n = new Node<T>(t);
            Node<T> node = this.linkedList;
            int i = 1;
            while (node.nextNode != null && i < index)
            {
                node = node.nextNode;
                i++;
            }

            //插入在首结点
            if (i == 1)
            {
                n.nextNode = this.linkedList;
                this.linkedList = n;
            }
            //跳出循环是因为插入的结点位置大于结点总数
            else if (node.nextNode == null)
            {
                this.Add(t);
            }
            //插入的节点在 链表的中间
            else
            {
                n.nextNode = this.linkedList.nextNode;
                this.linkedList.nextNode = n;

            }
            return i;

        }
    }



    public class Node<T> where T : class
    {
        public Node()
        {
            nextNode = null;
            t = null;
        }
        public Node(T t)
        {
            this.nextNode = null;
            this.t = t;
        }
        public Node<T> nextNode { get; set; }
        public T t { get; set; }
    }
}





