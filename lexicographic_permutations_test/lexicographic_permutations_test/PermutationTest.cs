using NUnit.Framework;
using System.Collections.Generic;

using permutations;

namespace permutations.tests
{
    public class Tests
    {

        private Permutations<int> _permutations;

        [SetUp]
        public void Setup()
        {
            _permutations = new Permutations<int>();
        }

        [Test]
        public void TestThatListWithSingleValueHasOnePermutation()
        {
            List<int> input_with_single_value = new List<int>() { 1 };

            List<List<int>> permutations = _permutations.getPermutations(input_with_single_value);

            Assert.That(permutations, Is.EqualTo(new List<List<int>>() { new List<int>() { 1 } }));
        }

        [Test]
        public void TestThatListWithTwoValuesHasTwoPermutations()
        {
            List<int> input_with_two_values = new List<int>() { 1, 2 };
           

            List<List<int>> permutations = _permutations.getPermutations(input_with_two_values);

            Assert.That(permutations, Is.EquivalentTo(new List<List<int>>() { new List<int>() { 1,2 }, new List<int>() { 2, 1 } }));
        }

        [Test]
        public void TestThatListWithThreeValuesHasSixPermutations()
        {
            List<int> input_with_three_values = new List<int>() { 1, 2, 3 };


            List<List<int>> permutations = _permutations.getPermutations(input_with_three_values);

            Assert.That(permutations, Is.EquivalentTo(new List<List<int>>() { 
                new List<int>() { 1, 2, 3 }, 
                new List<int>() { 1, 3, 2 },
                new List<int>() { 2, 1, 3 },
                new List<int>() { 2, 3, 1 },
                new List<int>() { 3, 1, 2 },
                new List<int>() { 3, 2, 1 }
            }));
        }

        [Test]
        public void TestThatListWithFourValuesHas24Permutations()
        {
            List<int> input_with_three_values = new List<int>() { 1, 2, 3, 4 };


            List<List<int>> permutations = _permutations.getPermutations(input_with_three_values);

            Assert.That(permutations, Is.EquivalentTo(new List<List<int>>() {
                new List<int>() { 1, 2, 3, 4 },
                new List<int>() { 1, 2, 4, 3 },
                new List<int>() { 1, 3, 2, 4 },
                new List<int>() { 1, 3, 4, 2 },
                new List<int>() { 1, 4, 2, 3 },
                new List<int>() { 1, 4, 3, 2 },
                new List<int>() { 2, 1, 3, 4 },
                new List<int>() { 2, 1, 4, 3 },
                new List<int>() { 2, 3, 1, 4 },
                new List<int>() { 2, 3, 4, 1 },
                new List<int>() { 2, 4, 1, 3 },
                new List<int>() { 2, 4, 3, 1 },
                new List<int>() { 3, 1, 2, 4 },
                new List<int>() { 3, 1, 4, 2 },
                new List<int>() { 3, 2, 1, 4 },
                new List<int>() { 3, 2, 4, 1 },
                new List<int>() { 3, 4, 1, 2 },
                new List<int>() { 3, 4, 2, 1 },
                new List<int>() { 4, 1, 2, 3 },
                new List<int>() { 4, 1, 3, 2 },
                new List<int>() { 4, 2, 1, 3 },
                new List<int>() { 4, 2, 3, 1 },
                new List<int>() { 4, 3, 1, 2 },
                new List<int>() { 4, 3, 2, 1 },
            }));
        }
    }
}