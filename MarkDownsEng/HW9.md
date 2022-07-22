# Homework №9 - Expression Trees

## Theory
 1. [Деревья выражений в enterprise](https://habr.com/ru/company/jugru/blog/423891/) ([repository with example](https://github.com/max-arshinov/Beyond-LINQ-Using-Expression-Trees-in-.NET))
 2. *Additional:* [*Async as surrogate IO*](https://blog.ploeh.dk/2016/04/11/async-as-surrogate-io/)

## Questions
 1. What is the difference between IQueryable<T> and IEnumerable<T>?
 2. What are the types of lambda expressions in IQueryable methods.Where and IEnumerable.Where
 3. How to make delegate from Expression?
 4. How to make Expression from delegate?
 5. What are the main scenarios for using Expressions in application development.
 6. Why you need to stop using Activator.CreateInstance and is it necessary?
 
## Practice
 1. Change the input parameters of the calculator - pass a string with an expression, for example
 `(2+3) / 12 * 7 + 8 * 9`, convert a string to an Expression Tree
 2. To parse the tree, use [ExpressionVisitor](https://docs.microsoft.com/en-us/dotnet/api/system.linq.expressions.expressionvisitor?view=net-6.0)
 3. All operations that can be performed in parallel are performed in parallel. Collect the result using [Task.WhenAll](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.whenall?view=net-6.0). (В докладе Дмитрия Иванова про Async/Await есть подсказка как запрограммировать такой алгоритм)
 4. Client in C#, integration tests
 5. To test || requests, add an artificial delay of 1000ms on the backend
 ### Example of an execution
    2 + 3  
    —---- / 12  
    —----—---- * 7  
    8 * 9  
    —----—-------- +
### Additional task
1.  Create AsyncEitherBuilder, issue a client on F#, working on the basis of AsyncEitherBuilder