# Homework 8

## Dependency Inversion

### Theory

1. [Dependency inversion](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
2. Embedded in ASP.NET Core techniques [dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
3. [From dependency injection to dependency rejection](https://www.youtube.com/watch?v=xG5qP5AWQws) ([Text version](https://blog.ploeh.dk/2017/01/27/from-dependency-injection-to-dependency-rejection/))
4. [Anti-pattern ServiceLocator](https://blog.ploeh.dk/2015/10/26/service-locator-violates-encapsulation/)

### Questions

1. What problem does the dependency injection technique solve?
2. Which keyword will not need to be used if all dependencies will be created with IOC-container?
3. How did you understand the phrase that dependency injection is “really just a pretentious way to say 'taking an argument'”?
4. When should you implement Singleton yourself, and when should you use the appropriate lifestyle if your application is built on the basis of an IOC-container?
5. What is the problem with Service Locator?
6. Which scope exists by default in ASP.NET Core application?
7. How to “reach” scoped dependencies in such code? `Task.Run(() => { // scoped-dependencies });`

### Practice

1. Arrange the calculator as a class, pass the calculator class as a dependency. It is acceptable to use Giraffe, ASP.NET Core Controller or self-written Middleware. Giraffe and ASP.NET Core is also Middleware.
2. Write tests using [XUnit Theory](https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/) and [integration tests](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0) in C#
