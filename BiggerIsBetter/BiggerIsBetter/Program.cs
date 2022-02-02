using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BiggerIsBetter
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
            Console.WriteLine(word1 + " - " + NextWord(word1));
            Console.WriteLine(word2 + " - " + NextWord(word2));
            Console.WriteLine(word3 + " - " + NextWord(word3));
            Console.WriteLine(word4 + " - " + NextWord(word4));
            Console.WriteLine(word5 + " - " + NextWord(word5));
            Console.WriteLine();

            var word6 = "lmno";
            var word7 = "dcba";
            var word8 = "dcbb";
            var word9 = "abdc";
            var word10 = "abcd";
            var word11 = "fedcbabcd";

            Console.WriteLine("Example #2:");
            Console.WriteLine(word6 + " - " + NextWord(word6));
            Console.WriteLine(word7 + " - " + NextWord(word7));
            Console.WriteLine(word8 + " - " + NextWord(word8));
            Console.WriteLine(word9 + " - " + NextWord(word9));
            Console.WriteLine(word10 + " - " + NextWord(word10));
            Console.WriteLine(word11 + " - " + NextWord(word11));
            Console.WriteLine();

        }

        public static void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }

        public static string NextWord(string word)
        {
            List<string> listWords = new List<string>();

            foreach (List<char> perm in Permutate(word.ToCharArray().ToList(), word.Length))
            {
                string s = new string(perm.ToArray());
                listWords.Add(s);
            }
            var uniqueListWords = listWords.Distinct().ToList();
            uniqueListWords.Sort();
            int index = uniqueListWords.IndexOf(word);
            if (index + 1 < uniqueListWords.Count)
            {
                return (uniqueListWords[index + 1]);
            }
            else { return "no answer"; }
            
        }
    }
}
