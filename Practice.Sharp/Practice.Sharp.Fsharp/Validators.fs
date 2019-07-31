module Validators
open Monads
open System
open Constants

let evaluateType (number: string) = match Int64.TryParse(number) with
| true, num -> Success num
| false, _ -> Failure InvalidIntType

let evaluateRange (number: int64) = match number >= int64(1) && number <= int64(2147483647) with
    |true -> Success number
    |false -> Failure InvalidRange