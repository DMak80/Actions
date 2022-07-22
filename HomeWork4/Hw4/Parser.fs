module Hw4.Parser

open System
open Hw4
open System.Runtime.InteropServices

let isArgLengthSupported (args : string[]) = args.Length = 3

let parseOperation (arg : string) =
    match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> InvalidOperationException() |> raise
    
let parseCalcArguments(args : string[], [<Out>] val1 : double byref, [<Out>] operation : CalculatorOperation byref, [<Out>] val2 : double byref) =
    let couldParseArg0, parsedArg0 = Double.TryParse(args[0])
    let couldParseArg2, parsedArg2 = Double.TryParse(args[2])
    if (isArgLengthSupported(args) = false || couldParseArg0 = false || couldParseArg2 = false) then
        ArgumentException() |> raise
    else
        val1 <- parsedArg0
        val2 <- parsedArg2
        operation <- parseOperation(args[1]);
