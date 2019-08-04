module Validators
open Monads
open System
open Constants

let evaluateType (number: string) = match Int32.TryParse(number) with
                                        | true, num -> Success (num)
                                        | false, _ -> Failure InvalidIntType

let evaluateRange (number: int) = match number >= 0 && number <= Int32.MaxValue with
                                        |true -> Success number
                                        |false -> Failure InvalidRange