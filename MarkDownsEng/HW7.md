# Homework №7

## Reflection

### Theory
 1. Read the entire Reflection section (including the Serialization section) on [docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection)
 2. Пройти весь раздел [Relflection на Ulearn](https://ulearn.me/course/basicprogramming2/Refleksiya_Klass_Type_8386b127-ea69-465d-87ba-24e08df9f6d2)
 3. Learn to work with [html-forms](https://www.w3schools.com/html/html_forms.asp)

### Questions
 1. How to create an object whose type is unknown at compile time, but known at run time? Example: var typeName = "MyClass"; var instance = new typeName();".
 2. What is meta information? What meta-information can be obtained using reflection in .NET?
 3. When should a developer use Reflection, and when should they not? What factors need to be considered?
 4. Why if you specify the type of the model through @model type is not necessary to pass an instance of the class. And if you do not specify, then you need to. What type is used if @model is not specified.

### Practice
 1. Write analogues of the @Html.EditorForModel extension method. Data types must be supported: numbers, strings, enum. For enums, output dropdowns (select tag).
 2. All heirs of [ValidationAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-5.0) must be supported: already written and to be written in the future.
 3. If the Display(Name=) attribute is not specified, then split the property name by CamelCase. For example FirstName => First Name.
                