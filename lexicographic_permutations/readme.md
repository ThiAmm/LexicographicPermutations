# Lexicographic permutations calculator

## Build
To build the application, run
```
docker build --no-cache -t lexicographic-permutations -f Dockerfile .
```

## Run
To run the application, run
```
docker run -it --rm lexicographic-permutations
```
You will then prompted to enter the digits for which the lexicographic permutations has 
to be calculated. In addition, you also have to enter the index of the 
lexicographic permutations.
For example, the lexicographic permutations of `0`,`1`,`2` is 
`(012,021,102,120,201,210)`. In this case, you enter `012` and `1` as index and you 
will receive `012` as output. 
