using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class GenericQueue<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T Data)
            {
                this.Data = Data;
                this.Next = null;
            }
        }

        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public T Head
        {
            get
            {
                if (IsEmpty)
                {
                    return default(T);
                }
                return _head.Data;
            }
        }

        public void Enqueue(T Data)
        {
            Node temp = new Node(Data);

            if (_size == 0)
            {
                _head = temp;
            }
            else
            {
                _tail.Next = temp;
            }

            _tail = temp;
            _size++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Queue is Empty");
                return default(T);
            }

            T Data = _head.Data;

            _head = _head.Next;
            _size--;
            if (_size == 0)
            {
                _tail = null;
            }
            return Data;
        }

        public void Display()
        {
            if (_head == null)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            if (_tail == null)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                Node currentHead = _head;
                Node currentTail = _tail;
                Console.WriteLine("Head: " + currentHead.Data);
                Console.WriteLine("Tail: " + currentTail.Data);
                Console.WriteLine();
            }
        }
    }
}
