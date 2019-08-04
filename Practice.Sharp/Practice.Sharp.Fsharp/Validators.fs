module Validators
open Monads
open System
open Constants

let evaluateType (number: string) = match Int64.TryParse(number) with
                                        | true, num -> Success (num |> int)
                                        | false, _ -> Failure InvalidIntType

let evaluateRange (number: int) = match number >= 1 && number <= 2147483647 with
                                        |true -> Success number
                                        |false -> Failure InvalidRange