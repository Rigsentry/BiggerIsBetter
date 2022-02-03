using System;
using System.Linq;

namespace BiggerIsBetter3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");

            var word = "dkhc";

            var charList = word.ToCharArray();

            var reversedCharList = charList.Reverse().ToList();

            Console.WriteLine(reversedCharList[0]);
        }
    }
}
