using System;
using System.Collections.Generic;
using System.Linq;

namespace permutations
{
    public interface IPermutations<T>
    {
        List<List<T>> getPermutations(List<T> values);
    }


    public class Permutations<T> : IPermutations<T>
    {
        public List<List<T>> getPermutations(List<T> values)
        {
            List<Tuple<int, T>> indexedValues = new List<Tuple<int, T>>();
            int index = 0;
            indexedValues = values.ConvertAll(value => new Tuple<int, T>(index++, value));

            List<List<Tuple<int, T>>> indexedPermutations = getIndexedPermutations(indexedValues);

            return indexedPermutations.ConvertAll<List<T>>(indexedPermutation => 
                indexedPermutation.ConvertAll<T>(
                    new Converter<Tuple<int,T>, T>(indexedValue => indexedValue.Item2)
                ));
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
