module Hw4.Calculator

let calculate (value1 : double) (operation : CalculatorOperation) (value2 : double) =
    let mutable result = System.Double.NaN
    match operation with
    | CalculatorOperation.Plus -> result <- value1 + value2
    | CalculatorOperation.Minus -> result <- value1 - value2
    | CalculatorOperation.Multiply -> result <- value1  * value2
    | CalculatorOperation.Divide -> result <- value1 / value2
    result
