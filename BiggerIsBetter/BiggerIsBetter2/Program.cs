using System;
using System.Collections.Generic;
using System.Linq;

namespace BiggerIsBetter2
{
    class Program
    {
        static void Main(string[] args)
        {

            var word1 = "ab";
            var word2 = "bb";
            var word3 = "hefg";
            var word4 = "dhck";
            var word5 = "dkhc";

            Console.WriteLine("Example #1:");
            Console.WriteLine(word1 + " - " + FindNextWord(word1));
            Console.WriteLine(word2 + " - " + FindNextWord(word2));
            Console.WriteLine(word3 + " - " + FindNextWord(word3));
            Console.WriteLine(word4 + " - " + FindNextWord(word4));
            Console.WriteLine(word5 + " - " + FindNextWord(word5));
            Console.WriteLine();

            var word6 = "lmno";
            var word7 = "dcba";
            var word8 = "dcbb";
            var word9 = "abdc";
            var word10 = "abcd";
            var word11 = "fedcbabcd";
            //var word12 = "hfjsdhfjhgajhgjuadhfgkjadhgakjg";

            Console.WriteLine("Example #2:");
            Console.WriteLine(word6 + " - " + FindNextWord(word6));
            Console.WriteLine(word7 + " - " + FindNextWord(word7));
            Console.WriteLine(word8 + " - " + FindNextWord(word8));
            Console.WriteLine(word9 + " - " + FindNextWord(word9));
            Console.WriteLine(word10 + " - " + FindNextWord(word10));
            Console.WriteLine(word11 + " - " + FindNextWord(word11));
            //Console.WriteLine(word12 + " - " + FindNextWord(word12));
            Console.WriteLine();

        }

        public static string FindNextWord (string word)
        {
            //Starting backwards, find the first letter that goes descending
            var charList = word.ToCharArray();
            var pivotChar = ' ';
            var pivotIndex = -1;
            var result = "";
            

            for (var i = word.Length - 1; i > 0; i--)
            {
                if (charList[i].CompareTo(charList[i - 1]) > 0)
                {
                    pivotChar = charList[i - 1];
                    pivotIndex = i - 1;
                    break;
                }
            }

            if (pivotIndex == -1)
            {
                return "No Answer";
            }

            //after finding the pivot letter, find the the next alphabetical letter in the remainnig letters after the pivot
            
            var swapIndex = 0;
            var alphabeticalDifference = 1000;
            var nextLetter = ' ';

            for (var i = pivotIndex + 1; i < charList.Length; i++)
            {
                nextLetter = charList[i];

                if (nextLetter > pivotChar)
                {
                    if ((int)nextLetter - (int)pivotChar <= alphabeticalDifference)
                    {
                        alphabeticalDifference = (int)nextLetter - (int)pivotChar;
                        swapIndex = i;
                    }
                }
            }

            //swap pivot with the next alphabetical letter
            charList[pivotIndex] = charList[swapIndex];
            charList[swapIndex] = pivotChar;

            //reorganize the remaning letter alphabetically except the pivot letter and everything that is behind it
            List<char> letterList = new List<char>();
            for (var i = pivotIndex + 1; i < charList.Length; i++)
            {
                letterList.Add(charList[i]);
            }

            letterList.Sort();
            var iteration = 1;
            foreach (var letter in letterList)
            {
                charList[pivotIndex + iteration] = letter;
                iteration++;
            }

            result = new string(charList);
            return result;

        }
    }
}