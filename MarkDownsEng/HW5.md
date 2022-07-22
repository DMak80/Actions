# Homework №5

## Monads

### Theory
 1. [Материалы лекции](https://docs.google.com/presentation/d/1wNLLm4mgdve8BnMIxaEajKHLV401-l_8PR0vg91UBqs/edit#slide=id.p100)
 2. [The power of composition](https://www.youtube.com/watch?v=oquuPOkz8xo) (monads)
 3. [Функторы, аппликативные функторы и монады в картинках, без картинок](https://habr.com/ru/post/183150/)
 4. [Understanding map and apply, Understanding bind, Using the core functions in practice](https://fsharpforfunandprofit.com/posts/elevated-world/)
 5. [Composition with an Either computation expression](https://blog.ploeh.dk/2016/03/21/composition-with-an-either-computation-expression/)
 6. [Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/) ([extended version with >=>](https://fsharpforfunandprofit.com/posts/recipe-part2/))

### Questions
 1. Choose one word ending in *-able* to describe the essence of monads.
 2. What do the monadic types Option, Seq, Task have in common? What is the difference?
 3. What function can be used to express functional composition for monadic types?
 4. How to get a map using bind and return?
 5. How to get bind using map and return?
 6. How are side effects, referential transparency, and function purity related? Why are Haskell functions pure by default?
 7. How to return early from a function in F# without using exceptions?

### Practice
 1. Use [Result Computation Expression](https://fsharpforfunandprofit.com/posts/computation-expressions-intro/) to handle F# calculator errors. The program must not throw exceptions.
 2. Add tests for operations with int, float, double, decimal types). It is acceptable to use multiple builders, inline functions, generics like ' or ^ and other F# features. Preference should be given to solutions with minimal code duplication.