using System;
using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    public class Stack<T>
    {
        private readonly List<T> _list = new List<T>();

        public int Count => _list.Count; // Returns the number of objects in the stack

        public void Push(T obj) // Add object on top of stack
        {
            if (obj == null)
                throw new ArgumentNullException();
            
            _list.Add(obj);
        }

        public T Pop() // Removes object on top of stack and returns it
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            var result = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);

            return result; 
        }


        public T Peek() // Returns object on top of stack without removing it
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            
            return _list[_list.Count - 1];
        }
    }
}