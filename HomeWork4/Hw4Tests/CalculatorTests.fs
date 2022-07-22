module Hw4Tests.CalculatorTests

open System
open Hw4
open Xunit
        
[<Theory>]
[<InlineData(15, 5, CalculatorOperation.Plus, 20)>]
[<InlineData(15, 5, CalculatorOperation.Minus, 10)>]
[<InlineData(15, 5, CalculatorOperation.Multiply, 75)>]
[<InlineData(15, 5, CalculatorOperation.Divide, 3)>]
let ``TestAllOperations`` (value1, value2, operation, expectedValue) =
    // act
    let actual = Calculator.calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)
    
[<Fact>]
let ``TestInvalidOperation`` () =
    //assert
    Assert.Throws<ArgumentOutOfRangeException>(fun () -> Calculator.calculate 15 CalculatorOperation.Undefined 5 |> ignore)
    
[<Fact>]
let ``TestDividingNonZeroByZero`` () =
    //act 
    let actual = Calculator.calculate 0 CalculatorOperation.Divide 10
    
    //assert
    Assert.Equal(0 |> double, actual)
    
[<Fact>]
let ``TestDividingZeroByNonZero`` () =
    //act 
    let actual = Calculator.calculate 10 CalculatorOperation.Divide 0
    
    //assert
    Assert.Equal(Double.PositiveInfinity, actual)
    
[<Fact>]
let ``TestDividingZeroByZero`` () =
    //act 
    let actual = Calculator.calculate 0 CalculatorOperation.Divide 0
    
    //assert
    Assert.Equal(Double.NaN, actual)
    

