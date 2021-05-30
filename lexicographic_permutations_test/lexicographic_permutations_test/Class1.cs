using lexicographic_permutations;
using NSubstitute;
using NUnit.Framework;
using permutations;
using System.Collections.Generic;

namespace lexicographic_permutations_test
{
    public class LexicographicPermuationCalculatorTest
    {
        private IPermutations<int> _permutationCalculator;
        private LexicographicPermutationCalculator<int> _lexicographicPermutationCalculator;

        [SetUp]
        public void SetUp()
        {
            _permutationCalculator = Substitute.For<IPermutations<int>>();
            _lexicographicPermutationCalculator = new LexicographicPermutationCalculator<int>(_permutationCalculator);
        }

        [Test]
        public void testThatLexicographicPermutationOfSingleValueIsTheSameValue()
        {
            _permutationCalculator.getPermutations(Arg.Is<List<int>>(x => x.Count == 1 && x[0] == 1)).Returns(new List<List<int>>() { new List<int>() { 1 } });

            List<string> lexicographicPermutations = _lexicographicPermutationCalculator.getLexicographicPermutations("1");

            Assert.That(lexicographicPermutations, Is.EqualTo(new List<string>() { "1" }));
        }

        [Test]
        public void testThatLexicographicPermutationOfTwoValueIsTheSameValue()
        {
            _permutationCalculator.getPermutations(Arg.Is<List<int>>(x => x.Count == 2 && x[0] == 1 && x[1] == 2))
                .Returns(new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 2, 1 } });

            List<string> lexicographicPermutations = _lexicographicPermutationCalculator.getLexicographicPermutations("12");

            Assert.That(lexicographicPermutations, Is.EqualTo(new List<string>() { "12", "21" }));
        }

        [Test]
        public void testThatLexicographicOrderingIsCorrectIfPermutationsAreNotOrderedByLexicographicOrder()
        {
            _permutationCalculator.getPermutations(Arg.Is<List<int>>(x => x.Count == 3 && x[0] == 0 && x[1] == 1 && x[2] == 2))
                .Returns(new List<List<int>>() {
                    new List<int>() { 2, 1, 0 }, 
                    new List<int>() { 0, 1, 2 }, 
                    new List<int>() { 0, 2, 1 }, 
                    new List<int>() { 1, 0, 2 }, 
                    new List<int>() { 1, 2, 0 }, 
                    new List<int>() { 2, 0, 1 }
                });

            List<string> lexicographicPermutations = _lexicographicPermutationCalculator.getLexicographicPermutations("012");

            Assert.That(lexicographicPermutations, Is.EqualTo(new List<string>() { "012",   "021"   , "102"   ,"120"   ,"201" ,  "210" }));
        }
    }
}
