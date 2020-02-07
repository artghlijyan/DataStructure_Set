using System;

namespace DataStructure_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };

            Set<int> instance1 = new Set<int>(arr);
            Set<int> instance2 = new Set<int>(arr1);

            bool res = instance1.IsSubSet(instance2);

            Console.WriteLine(res);
        }
    }
}
