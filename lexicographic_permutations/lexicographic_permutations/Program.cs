using System;
using permutations;

namespace lexicographic_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            IPermutations<int> permutationsCalculator = new Permutations<int>();
            LexicographicPermutationCalculator<int> lexicographicPermutationCalculator = new LexicographicPermutationCalculator<int>(permutationsCalculator);
            Console.WriteLine("Program to calculate the lexicographic order of numbers");
            Console.WriteLine("Enter digits as string");
            string digits = Console.ReadLine();
            Console.WriteLine("Enter index");
            string index = Console.ReadLine();
            Console.Write(lexicographicPermutationCalculator.getLexicographicPermutations(digits)[Int32.Parse(index)-1]);
        }
    }
}
