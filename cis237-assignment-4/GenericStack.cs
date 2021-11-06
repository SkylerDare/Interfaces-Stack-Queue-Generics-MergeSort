using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class GenericStack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _top;

        public bool IsEmpty
        {
            get
            {
                return _top == null;
            }
        }

        public void Push(T Data)
        {
            Node temp = new Node();

            if (temp == null)
            {
                Console.WriteLine("Heap Overload");
                return;
            }

            temp.Data = Data;

            temp.Next = _top;

            _top = temp;
        }

        public void Pop()
        {
            if (_top == null)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            _top = _top.Next;
        }

        public T Peek()
        {
            if (!IsEmpty)
            {
                return _top.Data;
            }
            else
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
        }

        public void Display()
        {
            if (_top == null)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                Node current = _top;
                while(current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }

    }
}
