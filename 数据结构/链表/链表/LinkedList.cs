using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表
{
    /// <summary>
    /// 从1开始
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>:IEnumerable<T>  where T : class
    {
        /// <summary>
        /// 储存一个起始结点
        /// </summary>
        private Node<T> linkedList = new Node<T>();
        /// <summary>
        /// 索引器 从1开始
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                Node<T> node = this.linkedList;
                for (int i = 1; i < index; i++)
                {
                    if (node.nextNode != null)
                    {
                        node = this.linkedList;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }
                return node.t;
            }
            set
            {
                Node<T> node = this.linkedList;
                for (int i = 1; i < index; i++)
                {
                    if (node.nextNode != null)
                    {
                        node = this.linkedList;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }
                node.t = value;
            }
        }
        /// <summary>
        /// 使链接为空
        /// </summary>
        /// <returns></returns>
        public LinkedList<T> MakeEmpty()
        {
            linkedList = new Node<T>();
            return this;
        }

        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="t"></param>
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
        /// <summary>
        /// 在结点中搜索第一个匹配的值
        /// </summary>
        /// <param name="t">要搜索的值</param>
        /// <returns>搜索值的位置</returns>
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

        public void Insert(int index, T t)
        {
            if (index <= 0)
                throw (new ArgumentException("参数index不能小于等于0"));
            Node<T> insertNode = new Node<T>(t);
            if (index == 1)
            {

                insertNode.nextNode = linkedList;
                this.linkedList = insertNode;

            }
            else
            {
                Node<T> node = this.linkedList;
                //让node保存要插入位置的上个结点
                for (int i = 1; i < index - 1; i++)
                {
                    if (node.nextNode == null)
                        throw new ArgumentOutOfRangeException();
                    node = node.nextNode;
                }
                //当插入的地方刚好位于链表的末尾时
                if (node.nextNode == null)
                    node.nextNode = insertNode;
                else
                {
                    insertNode.nextNode = node.nextNode;
                    node.nextNode = insertNode;
                    this.linkedList = node;
                }
            }
        }

        public bool Delete(int index)
        {
            if (index <= 0)
                throw (new ArgumentException("参数index不能小于等于0"));
            if (index == 1)
            {
                this.linkedList = linkedList.nextNode;
                return true;
            }
            else
            {
                Node<T> node = this.linkedList;
                for (int i = 1; i < index-1; i++)
                {
                    if (node.nextNode == null)
                        throw new ArgumentOutOfRangeException();
                    node = node.nextNode;
                }
                
                node.nextNode = node.nextNode.nextNode;
                return true;
            }
        }


      

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> node = this.linkedList;
            yield return node.t;
            while (node.nextNode != null)
            {
                node = node.nextNode;
                yield return node.t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return null;
        }

      
    }



   
}





