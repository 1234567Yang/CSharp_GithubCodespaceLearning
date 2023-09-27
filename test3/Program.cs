using System;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(66666);
            stack.Push("vevd");
            // stack.Add(533);

            stack.Pop();
            Console.WriteLine(stack.Peek());

            foreach(var i in stack){
                Console.WriteLine(i);
            }
            Console.WriteLine("***End***");
        }
    }
}