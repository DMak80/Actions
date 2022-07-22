# Homework №6

## Async await and ASP.NET Core basics

### Theory
 1. [TPL](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl)
 2. [Async/await и механизм реализации в C# 5.0](https://habr.com/ru/post/260217/) (*обратите внимание на рекомендованные в комментариях видео докладов: они крутые, в идеале - посмотрите и законспектируйте все до конца семестра*)
 3. [Async/await in C#: pitfalls](https://enterprisecraftsmanship.com/posts/pitfalls-of-async-await/)
 4. [Async programming in .NET: Best practices](https://www.youtube.com/watch?v=wM-h6P1BJRk), ([расшифровка](https://habr.com/ru/company/jugru/blog/491236/)). *В этом докладе подсказка как выполнить одно
из предстоящих практических заданий*
 5. [Jeffrey Richter — Building responsive and scalable applications](https://www.youtube.com/watch?v=xGSabgBo-S8)
 6. [Get started with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-3.1&amp%3Btabs=windows&tabs=windows)
 7. [Middleware в ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-3.1)

 *Additional task:*
 8. [Asynchronous C# and F# (II.): How do they differ?](http://tomasp.net/blog/async-csharp-differences.aspx/)
 9. [Роман Елизаров — Корутины в Kotlin](https://www.youtube.com/watch?v=rB5Q3y73FTo)
 10. [Андрей Бреслав — Асинхронно, но понятно. Сопрограммы в Kotlin](https://www.youtube.com/watch?v=ffIVVWHpups)

### Questions
 1. Asynchronous and parallel - are they the same thing or not? Why?
 2. In library code, you should always write .ConfigureAwait(false). Yes or no? Why?
 3. Where can Task.Result be used and where not? Why?
 4. Write Middleware execution chain as function signatures.
 5. Is it the same or not?
	var r1 = await Task.Run(() =&gt; File.ReadAll(fileName));
	var r2 = await File.ReadAllAsync(fileName);
 6. When should you use TaskCompletionSourсe?
 7. What is the default task scheduler? How to change it?
 8. What is CancellationToken used for?
 9. How to organize deadlock with tasks?
 10. What is the difference between IO-bound operations and CPU-bound operations?

### Practice
 1. Move calculator to ASP.NET Core app using [Giraffe](https://github.com/giraffe-fsharp/Giraffe) to F#
 2. Write integration tests for calculator in C# using [WebApplicationFactory](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0#basic-tests-with-the-default-webapplicationfactory). All calls
server methods must be executed with async/await
 3. Using [Reflector](https://en.wikipedia.org/wiki/.NET_Reflector) or [DotPeek](https://www.jetbrains.com/decompiler/) decompile F# and C# parts of the program, study the code obtained after decompilation, using the “do not use async / await constructs” setting when decompiling.