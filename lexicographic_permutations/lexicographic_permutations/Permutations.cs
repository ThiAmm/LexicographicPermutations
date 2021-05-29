using System;
using System.Collections.Generic;
using System.Linq;

namespace permutations
{
    public class Permutations<T>
    {
        public List<List<T>> getPermutations(List<T> values)
        {
            List<Tuple<int, T>> indexedValues = new List<Tuple<int, T>>();
            for (int i = 0; i < values.Count; i++)
            {
                indexedValues.Add(new Tuple<int, T>(i, values.ElementAt(i)));
            }
            List<List<Tuple<int, T>>> indexedPermutations = getIndexedPermutations(indexedValues);

            List<List<T>> permutations = new List<List<T>>();
            foreach(List<Tuple<int,T>> indexedPermutation in indexedPermutations)
            {
                List<T> permutation = new List<T>();
                foreach (Tuple<int,T> eintragInIndexPermutation in indexedPermutation)
                {
                    permutation.Add(eintragInIndexPermutation.Item2);
                }
                permutations.Add(permutation);
            }
            return permutations;
        }

        private List<List<Tuple<int, T>>> getIndexedPermutations(List<Tuple<int, T>> indexedValues)
        {
            if (indexedValues.Count == 1)
            {
                return new List<List<Tuple<int, T>>>() { indexedValues };
            }
            var query = from x in indexedValues
                        from y in getIndexedPermutations(indexedValues.Where(indexedValue => indexedValue != x).ToList())
                        where !y.Any(indexedPermuation => indexedPermuation.Item1 == x.Item1)
                        select new { x, y };
            List<List<Tuple<int,T>>> indexedPermutations = new List<List<Tuple<int,T>>>();
            foreach (var value in query)
            {
                List<Tuple<int, T>> indexedPermuation = new List<Tuple<int, T>>();
                indexedPermuation.Add(value.x);
                foreach (Tuple<int,T> indexedValueInPermutation in value.y)
                {
                    indexedPermuation.Add(indexedValueInPermutation);
                }
                indexedPermutations.Add(indexedPermuation);
            }
            return indexedPermutations;
        }
    }
}
