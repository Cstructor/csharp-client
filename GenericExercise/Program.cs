using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExercise
{
    public class MyStack<T> // generic class
    {
        T[] stack = new T[10]; // T refers to generic type
        int sp;

        public void Push(T item)
        {
            stack[sp++] = item;
        }

        public T Pop()
        {
            return stack[--sp];
        }

        public bool IsEmpty
        {
            get
            {
                return sp == 0;
            }
        }

    }

    class Program
    {
        static void Main()
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);

            while (!stack.IsEmpty)
            {
                int number = stack.Pop();
                Console.WriteLine("Last value popped = {0}", number);
            }

            Console.ReadLine();
        }
    }
}
