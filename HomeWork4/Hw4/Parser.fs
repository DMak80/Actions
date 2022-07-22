module Hw4.Parser

open Hw4
open System.Runtime.InteropServices

let parseCalcArguments(args : string[], [<Out>] val1 : double byref, [<Out>] operation : CalculatorOperation byref, [<Out>] val2 : double byref) =
    