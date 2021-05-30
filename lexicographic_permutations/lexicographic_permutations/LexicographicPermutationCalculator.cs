using permutations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace lexicographic_permutations
{
    public class LexicographicPermutationCalculator<T>
    {
        private IPermutations<int> permutationCalculator;

        public LexicographicPermutationCalculator(IPermutations<int> permutationCalculator)
        {
            this.permutationCalculator = permutationCalculator;
        }

        public List<string> getLexicographicPermutations(string v)
        {
            List<int> valuesToPermutate = v.Select(i => int.Parse(i.ToString())).ToList();
            List<List<int>> permutations = this.permutationCalculator.getPermutations(valuesToPermutate);
            permutations.Sort(delegate (List<int> x, List<int> y)
            {
                for(int i = 0; i< x.Count; i++)
                {
                    if (x[i] < y[i])
                    {
                        return -1;
                    }
                    else
                    {
                        if(x[i] > y[i])
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            });
            return permutations.ConvertAll(permutation => string.Join(string.Empty, permutation));
        }
    }
}