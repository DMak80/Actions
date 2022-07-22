# Homework №3

## Memory model 

### Theory
Goldstein and Freter
We look regardless of direction (Java or .NET). There's .NET specifics in there, but most of the stuff isn't tied to
specific platform. In addition, their material is simpler than that of Shipelev, so we start with them.
 1. [The C++ and CLR Memory Models](https://www.youtube.com/watch?v=6wZVpg2SyJQ) ([presentation](https://2016.dotnext-piter.ru/talks/goldshtein2/))
 2. [Multithreading Deep Dive](https://habr.com/ru/company/jugru/blog/543380/) ([презентация](https://2016.dotnext-moscow.ru/talks/multithreading-deep-dive/))

*Java thread may skip .NET sections*
 
Shipelev
We look regardless of direction (Java or .NET). The .NET Memory Model is very similar to the Java Memory Model. The concept of races and volatile placement rules are almost the same for the two platforms (with the exception of the implicit barriers that Goldstein talked about). The concepts of acquire/release and happens before are platform-specific, but for now, let's just get to know that they exist and won't get into the details.

 3. [Java Memory Model Pragmatics](https://shipilev.net/#jmm)
 4. [Java Memory Model, Close Encounters](https://shipilev.net/#jmm-close-encounters)
 5. [Java Memory Model, Unlearning Experience](https://shipilev.net/#jmm-unlearning-experience)

.NET

 1. [Singleton](https://csharpindepth.com/articles/singleton)
 2. [ECMA CLI specification](https://www.ecma-international.org/wp-content/uploads/ECMA-335_5th_edition_december_2010.pdf)
 3. [ECMA C# language specification](https://www.ecma-international.org/publications-and-standards/standards/ecma-334/)
 4. [CLR 2.0 memory model](http://joeduffyblog.com/2007/11/10/clr-20-memory-model/)
 5. [PART 4: ADVANCED THREADING](https://www.albahari.com/threading/part4.aspx)

JAVA

 1. [JMM Spec](https://download.oracle.com/otndocs/jcp/memory_model-1.0-pfd-spec-oth-JSpec/)
 2. [The Java Memory Model](http://www.cs.umd.edu/~pugh/java/memoryModel/)

### Questions
 1. Define the terms “atomicity”, “exclusivity” and “reordering”
 2. Does atomicity guarantee -&gt; exclusivity, exclusivity -&gt; atomicity, atomicity -&gt; execution in order?
 3. What is “speculative program execution”?
 4. What is the meltdown vulnerability and how was it fixed?
 5. What is branch prediction?
 6. What is a “memory model” in relation to a processor?
 7. What is a "memory model" in relation to a programming language?
 8. What is a "memory barrier"? What are the types of barriers?
 9. .NET only What implicit barriers exist in .NET?
 10. What is SC-DRF?
 11. You know that in a certain version of the JVM/CLR, multithreading is not implemented exactly as specified in the ECMA CLI/JMM specification. Using this feature can give your program a performance benefit. Will you use?
 12. Suggest a thread-safe Singleton implementation
 13. Which variables in Lazy implementation should be final/volatile? Why?
 14. Explain the concept of “JMM's happy plateau, death-safe racing and a sea of ​​despair”
 15. What “repertoire” should a developer acquire?

### Practice
There is no practical work. Study the theory in detail.