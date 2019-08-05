module Validators
open Monads
open System
open Constants

let evaluateType (number: string) = match Int32.TryParse(number) with
                                        | true, num -> Success (num)
                                        | false, _ -> Failure InvalidIntType

let evaluateRange   (min: int) 
                    (max: int) 
                    (number: int) = match number >= min && number <= max with
                                        |true  -> Success number
                                        |false -> Failure InvalidRange

let evaluateArrayLength (min: int)
                        (max: int)
                        (arr: int[])  =
    match arr.Length >= min && arr.Length <= max with
    | true -> Success arr
    | false -> Failure InvalidArrayRange

let evaluateArrayMax    (max: int) 
                        (arr: int[]) =
    Array.max arr
        |> function
            | n when n <= max -> Success arr
            | _ -> Failure InvalidArrayMax

let evaluateArrayMin    (min: int) 
                        (arr: int[]) =
  Array.min arr
        |> function
            | n when n >= min -> Success arr
            | _ -> Failure InvalidArrayMin