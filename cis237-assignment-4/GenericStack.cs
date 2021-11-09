//Skyler Dare
//CIS237
//11/9/21
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
        /// <summary>
        /// pushes data onto the stack
        /// </summary>
        /// <param name="Data">generic data to be added to the stack</param>
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
        /// <summary>
        /// removes data from the stack
        /// </summary>
        public void Pop()
        {
            if (_top == null)
            {
                Console.WriteLine("Stack Empty");
                return;
            }

            _top = _top.Next;
        }
        /// <summary>
        /// checks the top of the stack
        /// </summary>
        /// <returns>data at the top of the stack</returns>
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
    }
}
