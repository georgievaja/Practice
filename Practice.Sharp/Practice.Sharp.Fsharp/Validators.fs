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