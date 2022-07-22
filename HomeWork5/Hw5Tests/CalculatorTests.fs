module Hw5Tests.CalculatorTests

open Hw5
open Microsoft.FSharp.Core
open Xunit

let epsilon: decimal = 0.001m
        
[<Theory>]
[<InlineData(15, 5, CalculatorOperation.Plus, 20)>]
[<InlineData(15, 5, CalculatorOperation.Minus, 10)>]
[<InlineData(15, 5, CalculatorOperation.Multiply, 75)>]
[<InlineData(15, 5, CalculatorOperation.Divide, 3)>]
let ``TestCalculatorAllOperationsInt`` (value1 : int, value2: int, operation, expectedValue : int) =
    //act
    let actual = Calculator.calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)

[<Theory>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``TestCalculatorAllOperationsFloat`` (value1 : float, value2: float, operation, expectedValue : float) =
    //act
    let actual = abs (expectedValue - Calculator.calculate value1 operation value2)
        
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<Theory>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``TestCalculatorAllOperationsDouble`` (value1 : double, value2: double, operation, expectedValue : double) =
    //act
    let actual = abs (expectedValue - Calculator.calculate value1 operation value2)
    
    //assert
    Assert.True(actual |> decimal < epsilon)
    
[<Theory>]
[<InlineData(15.6, 5.6, CalculatorOperation.Plus, 21.2)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Minus, 10)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Multiply, 87.36)>]
[<InlineData(15.6, 5.6, CalculatorOperation.Divide, 2.7857)>]
let ``TestCalculatorAllOperationsDecimal`` (value1 : decimal, value2: decimal, operation, expectedValue : decimal) =
    //act
    let actual = abs (expectedValue - Calculator.calculate value1 operation value2)
    
    //assert
    Assert.True(actual < epsilon)

