# Homework №2

## Versions and how .NET works

### Theory
.NET &amp; C# history
 1. [The journey to one .net | .Net 5 and beyond | Microsoft build 2020](https://www.youtube.com/watch?v=oyF6RGKlvi8)
 2. [The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history)
 3. [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-1-0)
 
CIL
 
 4. [CIL programming tutorial – The Basics Part I](https://dolinkamark.wordpress.com/2015/10/21/cil-programming-tutorial-the-basics/)
 5. [CIL programming tutorial – The Basics Part II](https://dolinkamark.wordpress.com/2016/04/24/cil-programming-tutorial-the-basics-part-ii/)
 6. [What can you do in MSIL that you cannot do in C# or VB.NET?](https://stackoverflow.com/questions/541936/what-can-you-do-in-msil-that-you-cannot-do-in-c-sharp-or-vb-net)

JIT

 7. [The RyuJIT transition is complete](https://devblogs.microsoft.com/dotnet/the-ryujit-transition-is-complete/)
 8. [Егор Богатов — Как устроен JIT-компилятор в CoreCLR](https://www.youtube.com/watch?v=H1ksFnLjLoY)
 9. [Tiered compilation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#tiered-compilation)
 10. [Choosing the right defaults for tiered compilation](https://github.com/dotnet/runtime/issues/12515) 

### Questions
 1. What is the difference between .NET Framework, .NET Core, .NET 5, .NET 6 and .NET Standard?
 2. What kinds of applications can be developed in C# starting with .NET 5?
 3. What language does JIT work with?
 4. Why should a .NET developer be able to read CIL?
 5. What does the CLR do?
 6. What is CTS (Common Type System). What does it mean that code is CLS compliant?
 7. Is it possible to connect to a C# assembly an assembly written in another managed language if the assembly is not CLS-compatible?
 8. Explain to a freshman how JIT compilation works in .NET in no more than 3 minutes.
 9. What is Tiered compilation? What is the tradeoff of JIT compilation?

### Practice
 1. Rewrite the Calculate and Parse methods in IL using the Microsoft.NET.Sdk.IL project type
 2. Main and tests can stay in C#