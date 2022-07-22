module Hw4Tests.ParserTests

open System
open Hw4
open Xunit
        
[<Theory>]
[<InlineData("+", CalculatorOperation.Plus)>]
[<InlineData("-", CalculatorOperation.Minus)>]
[<InlineData("*", CalculatorOperation.Multiply)>]
[<InlineData("/", CalculatorOperation.Divide)>]
let ``TestCorrectOperations`` (operation, operationExpected) =
    //arrange
    let args = [|"15";operation;"5"|]
    let mutable actualVal1 = 0 : double
    let mutable actualOperation = CalculatorOperation.Undefined
    let mutable actualVal2 = 0 : double
    
    //act
    Parser.parseCalcArguments(args, &actualVal1, &actualOperation, &actualVal2)
    
    //assert
    Assert.Equal(15 |> double, actualVal1)
    Assert.Equal(operationExpected, actualOperation)
    Assert.Equal(5 |> double, actualVal2); 
    
[<Theory>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``TestParserWrongValues`` (val1, operation, val2) =
    // arrange
    let args = [|val1;operation;val2|]
    let mutable actualVal1 = 0 : double
    let mutable actualOperation = CalculatorOperation.Undefined
    let mutable actualVal2 = 0 : double
    
    //assert
    Assert.Throws<ArgumentException>(fun () -> Parser.parseCalcArguments(args, &actualVal1, &actualOperation, &actualVal2));

[<Fact>]
let ``TestParserWrongOperation``() =
    // arrange
    let args = [|"3";".";"4"|]
    let mutable actualVal1 = 0 : double
    let mutable actualOperation = CalculatorOperation.Undefined
    let mutable actualVal2 = 0 : double
    
    //assert
    Assert.Throws<InvalidOperationException>(fun () -> Parser.parseCalcArguments(args, &actualVal1, &actualOperation, &actualVal2));

[<Fact>]
let ``TestParserWrongLength``() =
    // arrange
    let args = [|"3"; "."; "4"; "5"|]
    let mutable actualVal1 = 0 : double
    let mutable actualOperation = CalculatorOperation.Undefined
    let mutable actualVal2 = 0 : double
    
    //assert
    Assert.Throws<ArgumentException>(fun () -> Parser.parseCalcArguments(args, &actualVal1, &actualOperation, &actualVal2));