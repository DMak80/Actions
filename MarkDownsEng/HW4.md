# Homework №4

## Functional programming in F#

### Theory
 1. [Материалы лекции](https://docs.google.com/presentation/d/1wNLLm4mgdve8BnMIxaEajKHLV401-l_8PR0vg91UBqs/edit#slide=id.p100)
 2. [F# syntax in 60 seconds](https://fsharpforfunandprofit.com/posts/fsharp-in-60-seconds/)
 3. [Learning F#](https://fsharpforfunandprofit.com/learning-fsharp/)
 4. [Troubleshooting F#](https://fsharpforfunandprofit.com/troubleshooting-fsharp/)
 5. [F# for C# Programmers](https://fsharpforfunandprofit.com/csharp/)
 6. [The power of composition](https://www.youtube.com/watch?v=oquuPOkz8xo) (up to and including monads
 7. *Additional: [Category theory](https://en.wikipedia.org/wiki/Category_theory)*

### Questions
 1. What are the main differences between the functional paradigm and OOP?
 2. What is functional composition, what advantages does it provide?
 3. Define Higher Order Functions. What HOF support does C# have?
 4. What is referential transparency? Why is this concept important?
 5. What is currying and partial application? What is the difference between these concepts?
 6. Why is FP well suited for multiprocessor and distributed computing?
 7. What data types are called "algebraic"? Why are they called that? What algebraic data types are supported in C# and F#? What only in F#?
 8. *Question for +1 point at the seminar: compare Discriminated Unions in F#, [*Sealed classes*](https://kotlinlang.org/docs/sealed-classes.html), [Enum classes](https://kotlinlang.org/docs/enum-classes.html ) in Kotlin. How are they similar? What is the difference?*

### Practice
 1. Rewrite Calculator in F#
 2. There should still be 100% coverage. The easiest way is to see how F# functions are compiled to IL. Existing tests will need to be edited quite a bit.
 3. Tests can be left in C# or rewritten in F# (optional)