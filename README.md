![.NET](https://github.com/Giviruk/Actions/actions/workflows/dotnet.yml/badge.svg)
[![codecov](https://codecov.io/gh/DMak80/Actions/branch/HW3/graph/badge.svg?token=AJ1EHK3XZH)](https://codecov.io/gh/DMak80/Actions)
# Домашняя работа №3 - Memory model

## Теория

Гольдштейн и Фретёр
Смотрим независимо от потока. Там есть .NET-специфика, но большая часть материала не привязана к
конкретной платформе. К тому же у них материал проще, чем у Шипелёва, поэтому начинаем с них. 
 1. [The C++ and CLR Memory Models](https://habr.com/ru/company/jugru/blog/541362/) ([презентация](https://2016.dotnext-piter.ru/talks/goldshtein2/))
 2. [Multithreading Deep Dive](https://habr.com/ru/company/jugru/blog/543380/) ([презентация](https://2016.dotnext-moscow.ru/talks/multithreading-deep-dive/))

*Java-поток может пропустить разделы про .NET*
 
Шипелёв
Смотрим независимо от потока. .NET Memory Model очень похожа на Java Memory Model. Концепция гонок и правила расстановки volatile почти одинаковые для двух платформ (за исключением неявных барьеров о которых рассказывал Гольдштейн). Концепции acquire/release и happens before специфичны для платформ, но пока просто познакомимся с тем, что они существуют и не будет разбирать детали.

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

## Вопросы к семинару
1. Дайте определение понятиям “атомарность”, “эксклюзивность” и “изменение порядка”
2. Гарантирует ли атомарность -&gt; эксклюзивность, эксклюзивность -&gt; атомарность, атомарность -&gt;
выполнение по порядку?
3. Что такое “спекулятивное исполнение программы”?
4. В чем заключается уязвимость meltdown, как ее устранили?
5. Что такое branch prediction?
6. Что такое “модель памяти” применительно к процессору?
7. Что такое “модель памяти” применительно к языку программирования?
8. Что такое “барьер памяти”? Какие бывают виды барьеров?
9. Только .NET Какие неявные барьеры существуют в .NET?
10. Что такое SC-DRF?
11. Вы знаете, что в определенной версии JVM/CLR многопоточность реализована не совсем так, как указано в спецификации ECMA CLI/JMM. Использование этой особенности может дать вашей программе выигрыш в производительности. Будете использовать?
12. Предложите потокобезопасную реализацию Singleton
13. Какие переменные в реализации Lazy должны быть final/volatile? Почему?
14. Объясните концепцию “счастливого плато JMM, смертельно-безопасных гонок и моря отчаяния”
15. Каким “репертуаром” следует обзавестись разработчику?

## Практика
Нет практической работы. Уложите в голове теорию.