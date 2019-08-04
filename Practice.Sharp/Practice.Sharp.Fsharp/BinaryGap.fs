module BinaryGap

open System
open Monads.Operators
open Validators

let allOnes (num: int) =
    ((num+1) &&& num = 0) && (num <> 0)

let rec removeTrailingZeros (num: int) =
    match num &&& 1 = 0 with
    | true      ->  removeTrailingZeros (num >>> 1)
    | false     ->  num

let rec shift (steps: int) (num: int) =
    match allOnes(num) with
        | true    ->  steps
        | false   ->  shift (steps + 1) (num ||| (num <<< 1))

let getBinaryGap =
    evaluateType
        >=> evaluateRange 1 2147483647
        =>> (removeTrailingZeros
             >> shift 0)
    

