using System;
using System.Linq;

namespace Task3
{
    public class ArrayProcessor
    {
        // заглушка, проблема при сборке без нее не работает
        public static void Main(String[] args) {}

        public int[] SortAndFilter(int[] a)
        {
            if (a == null)
                throw new ArgumentNullException();
            return a.Where(c => (c > 999 && c < 10000)).OrderBy(c => c).ToArray();
        }
    }
}