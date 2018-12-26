using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b)
        { 
            return a + b;
        }
        
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Taking a limit for the argument, and returning an odd number starting from zero up to that limit
        // This returns an IEnumerable collection
        public IEnumerable<int> GetOddNumbers(int limit) 
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i; 
        }
    }
}